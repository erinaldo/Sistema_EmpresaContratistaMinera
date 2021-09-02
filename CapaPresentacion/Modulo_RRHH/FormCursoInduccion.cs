using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using CapaPresentacion.Catalogo;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormCursoInduccion : Biblioteca.Formularios.FormBaseABM_RRHH
    {
        #region Atributos
        private bool _nuevoRegitroDesdeNavegacion = false;
        private string[] consultaCursoInduccion;
        private Legajo objLegajo; //Objeto Primario
        private LegajoLaboral objLegajoLaboral; //Objeto Secundario
        private CursoInduccion objCursoInduccion; //Objeto del Módulo
        private CursoInduccion objCursoInduccionDB; //Objeto de la Base de Datos
        private N_Legajo nLegajo = new N_Legajo();
        private N_LegajoLaboral nLegajoLaboral = new N_LegajoLaboral();
        private N_CursoInduccion nCursoInduccion = new N_CursoInduccion();
        #endregion

        #region Constructores
        public FormCursoInduccion()
        {
            InitializeComponent();
        }
        public FormCursoInduccion(Legajo navLegajo, bool nuevoRegitroDesdeNavegacion = false) //Utilizado por el navegador de formularios
        {
            objLegajo = navLegajo;
            _nuevoRegitroDesdeNavegacion = nuevoRegitroDesdeNavegacion;
            InitializeComponent();
        }
        public FormCursoInduccion(CursoInduccion navCursoInduccion) //Utilizado por el navegador de formularios
        {
            objCursoInduccionDB = objCursoInduccion = navCursoInduccion;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormCursoInduccion_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { }), 0);
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ANULADO",
                "FILTRAR POR ESTADO: OBSOLETO", "FILTRAR POR ESTADO: VIGENTE", "TODOS LOS ESTADOS" }, 2); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT",
                "FILTRAR POR DENOMINACION", "FILTRAR POR FECHA" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
            if (objLegajo != null) instanciarDesdeNavegacion(objLegajo);
            if (objCursoInduccion != null && !_controladorDeNuevoRegistro) escribirControles(objCursoInduccion); //Escribe los datos solicitados mediante la navegación entre formularios
        }

        private void btnBuscarLegajo_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                FormCatalogo_Legajo frm = new FormCatalogo_Legajo(this);
                frm.ShowDialog(this);
            }
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(100))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objCursoInduccion != null)
            {
                if (objCursoInduccion.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(100)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            this.objLegajo = nLegajo.obtenerObjeto("ID", objCursoInduccion.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                            objCursoInduccion.Id = nCursoInduccion.generarNumeroID(); //Paso 3: Genera un ID para cada Objeto
                            if (nCursoInduccion.insertar(objCursoInduccion)) //Paso 4: Inserta el objeto principal
                            {
                                mostrarRegistro(objCursoInduccion);
                                Mensaje.RegistroCorrecto("REGISTRACION");
                            }
                        }
                    }
                }
                else if (objCursoInduccion.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(76)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (objCursoInduccionDB.Estado == "VIGENTE") //Verifica que el contrato este Vigente
                    {
                        if (ValidarCampoVacio())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                this.objLegajo = nLegajo.obtenerObjeto("ID", objCursoInduccion.Legajo.Id.ToString(), false); //Paso 3: Importante: Re-Almacena el Objeto de la Base de Datos
                                if (!objCursoInduccion.Equals(objCursoInduccionDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                                {
                                    if (nCursoInduccion.actualizar(objCursoInduccion))
                                    {
                                        mostrarRegistro(objCursoInduccion);
                                        Mensaje.RegistroCorrecto("MODIFICACION");
                                    }
                                }
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación incorrecta.\nLos registros obsoletos o anulados No pueden ser modificados.");
                }
                else Mensaje.Restriccion();
                bool ValidarCampoVacio() // Método que valida los campos requeridos
                {
                    return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion, txtCuit });
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objCursoInduccion.Id > 0) escribirControles(objCursoInduccionDB); //Restaura los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(101)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objCursoInduccion.Id > 0)
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea anular el registro ID: " + objCursoInduccion.Id.ToString() + "?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        objLegajo = nLegajo.obtenerObjeto("ID", objCursoInduccion.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                        if (nCursoInduccion.anular(objCursoInduccion)) //Paso 3: Verifica el exito de la actualización y muestra los datos actualizados
                        {
                            objCursoInduccion.Estado = "ANULADO"; //Paso 4: Importante: Establece el cambio de estado en el Objeto del Módulo 
                            mostrarRegistro(objCursoInduccion);
                            Mensaje.RegistroCorrecto("ANULACION");
                        }
                    }
                }
            }
            else Mensaje.Restriccion();
        }
        #endregion

        #region Métodos
        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(CursoInduccion objRegistro)
        {
            this.objCursoInduccion = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            if (objCursoInduccion != null && objCursoInduccion.Legajo != null)
            {
                if (!objCursoInduccion.Legajo.InformacionRestringida || (objCursoInduccion.Legajo.InformacionRestringida && Global.UsuarioActivo_Privilegios.Contains(1))) //Verifica que el usuario posea el privilegio requerido
                {
                    _controladorDeNuevoRegistro = false;
                    DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
                    objLegajo = objCursoInduccion.Legajo;
                    objLegajoLaboral = new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id));
                    txtDenominacion.Text = objCursoInduccion.Legajo.Denominacion;
                    txtCuit.Text = Convert.ToString(objCursoInduccion.Legajo.Cuit);
                    cmbCentroCosto.Text = (objCursoInduccion.CentroCosto != null) ? objCursoInduccion.CentroCosto.Denominacion : "";
                    pkrFechaEmision.Value = objCursoInduccion.FechaEmision;
                    cmbEvaluacion.Text = objCursoInduccion.Evaluacion;
                    txtObservacion.Text = objCursoInduccion.Observacion;
                    txtEstado.Text = objCursoInduccion.Estado;
                    labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objCursoInduccion.EdicionFecha) + " por " + objCursoInduccion.EdicionUsuarioDenominacion;
                }
                else restaurarControles();
            }
        }

        private void instanciarDesdeNavegacion(Legajo objLegajo)
        {
            if (_nuevoRegitroDesdeNavegacion && !objLegajo.Baja) //Verifica la orden de "nuevo registro" y que el Legajo No este dado de baja
            {
                cmbFiltroLista1.Enabled = false; //Paso 1a: Desactiva el filtro de estados
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS"; //Paso 1b: Selecciona todos los estados 
                cmbFiltroLista2.Text = "FILTRAR POR CUIT"; //Paso 1c: Selecciona la busqueda por CUIT                 txtFiltroLista.Text = Convert.ToString(objLegajo.Cuit); //Paso 2: Establece el CUIT recibido
                filtrarCatalogo(0); //Paso 3: Carga el catálogo
                lstCatalogo.ClearSelected(); //Paso 4: Quita la selección de la fila
                btnNuevo.PerformClick(); //Paso 5: Ejecuta automáticamente el botón "Nuevo"
                this.objLegajo = objLegajo; //Paso 6: Iguala el Atributo de la clase con el Objeto recibido
                txtDenominacion.Text = objLegajo.Denominacion;
                txtCuit.Text = Convert.ToString(objLegajo.Cuit);
                this.objLegajoLaboral = new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id));
                cmbCentroCosto.Text = (objLegajoLaboral != null && objLegajoLaboral.CentroCosto != null) ? objLegajoLaboral.CentroCosto.Denominacion : "";
            }
            else
            {
                objCursoInduccion = nCursoInduccion.obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)); //Paso 1: Busca el registro en la Base de Datos en relación al objeto maestro recibido 
                if (objCursoInduccion != null)
                {
                    lstCatalogo.SelectedValue = objCursoInduccion.Id; //Paso 2: Posiona la selección de la fila en el registro guardado
                    escribirControles(objCursoInduccion); //Paso 3: Escribe los datos del registro indicado
                }
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objCursoInduccion = new CursoInduccion(
                (objCursoInduccion.Id <= 0) ? 0 : objCursoInduccion.Id,
                objLegajo,
                new N_CentroCosto().obtenerObjeto("DENOMINACION", cmbCentroCosto.Text),
                pkrFechaEmision.Value,
                ((pkrFechaEmision.Value.AddMonths(Global.Vigencia_CursoInduccion).AddDays(Global.Alerta_CursoInduccion) < fechaActual.AddDays(Global.Alerta_CursoInduccion)) ? true : false),
                cmbEvaluacion.Text,
                txtObservacion.Text,
                ((fechaActual > pkrFechaEmision.Value.AddMonths(Global.Vigencia_CursoInduccion) && txtEstado.Text == "VIGENTE") ? "OBSOLETO" : txtEstado.Text),
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objLegajo = new Legajo(); //Restaura el Objeto Primario
            objLegajoLaboral = new LegajoLaboral(); //Restaura el Objeto SubPrimario
            objCursoInduccion = new CursoInduccion(); //Importante: Restaura el Objeto del Móludo
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(cmbCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { }), 0); //Restauración de los items del ComboBox
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            pkrFechaEmision.Value = fechaActual;
            cmbEvaluacion.Text = "APROBADO";
            txtObservacion.Text = "";
            txtEstado.Text = "VIGENTE";
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, txtCuit }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(CursoInduccion objRegistro) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objCursoInduccionDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            escribirControles(objCursoInduccionDB); //Escribe los datos del registro seleccionado
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR CUIT")
            {
                cmbFiltroLista1.Enabled = false;
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });

            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
            {
                cmbFiltroLista1.Enabled = true;
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA")
            {
                cmbFiltroLista1.Enabled = true;
                Formulario.Visibilidad(false, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(true, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta }); //Verifica que se ha seleccionado el filtrado por fecha y habilita las casillas "desde y hasta"
            }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroEstado = "TODOS";
            if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ANULADO") filtroEstado = "ANULADO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: OBSOLETO") filtroEstado = "OBSOLETO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: VIGENTE") filtroEstado = "VIGENTE";
            if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de CUIL/CUIT
            {
                consultaCursoInduccion = new string[] { filtroEstado, "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCursoInduccion.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la denominacón
            {
                consultaCursoInduccion = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCursoInduccion.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA") //Verifica que el tipo de filtro es por fecha
            {
                consultaCursoInduccion = new string[] { filtroEstado, "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nCursoInduccion.obtenerCatalago(filtroEstado, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objCursoInduccionDB = nCursoInduccion.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objCursoInduccionDB); //Escribe los datos del registro seleccionado
        }

        protected override void navegarA_Formulario(string destino) { NavegacionRRHH.navegarA_Formulario(destino, this, objLegajo); }

        protected override void reportarRegistro(string programa)
        {
            if (objCursoInduccion.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "N° Legajo: ",
                    "Denominación: ",
                    "CUIL/CUIT: ",
                    "Centro de costo: ",
                    "Fecha de emisión: ",
                    "Evaluación: ",
                    "Observaciones: ",
                    "Estado: " };
                string[] datoDB = {
                    objCursoInduccion.Legajo.Id.ToString().PadLeft(8, '0'),
                    objCursoInduccion.Legajo.Denominacion,
                    objCursoInduccion.Legajo.Cuit.ToString("00-00000000/0"),
                    objCursoInduccion.CentroCosto.Denominacion,
                    Fecha.ConvertirFecha(objCursoInduccion.FechaEmision),
                    objCursoInduccion.Evaluacion,
                    objCursoInduccion.Observacion,
                    objCursoInduccion.Estado };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Curso de Inducción", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Curso de Inducción", subTitulo, datoDB);
                Cursor.Current = Cursors.Default;
            }
            else Mensaje.Advertencia("Operación incorrecta.\nSeleccione un registro en la pantalla e intente nuevamente.");
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                lista = nCursoInduccion.obtenerCatalago(consultaCursoInduccion[0], consultaCursoInduccion[1], consultaCursoInduccion[2], "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Denominación",
                    "CUIL/CUIT",
                    "F. Emisión",
                    "F. Vto.",
                    "Evaluación",
                    "Estado" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //ID
                    campo[1].Trim(), //Denominación
                    campo[2].Trim(), //CUIL/CUIT
                    campo[3].Trim(), //F. Emisión
                    campo[4].Trim(), //F. Vto.
                    campo[5].Trim(), //Evaluación
                    campo[6].Trim() }; //Estado
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Cursos de Inducción", subTitulos, new int[] { 8, 70, 13, 10, 10, 10, 8 }, _listaDelReporte, new List<int> { 3, 4 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Cursos de Inducción", subTitulos, new float[] { 7, 58, 11, 9, 9, 10, 7 }, _listaDelReporte); //Ancho: 111
            }
        }

        public override void asignarVariablesDeFormulario(string[] variablesDeFormulario)
        {
            if (variablesDeFormulario[0] == "Catalogo_Legajo") //Catálogo de Legajos
            {
                this.objLegajo = new N_Legajo().obtenerObjeto("ID", variablesDeFormulario[1], true);
                txtDenominacion.Text = objLegajo.Denominacion;
                txtCuit.Text = Convert.ToString(objLegajo.Cuit);
                this.objLegajoLaboral = new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id));
                cmbCentroCosto.Text = (objLegajoLaboral != null && objLegajoLaboral.CentroCosto != null) ? objLegajoLaboral.CentroCosto.Denominacion : "";
            }
        }
        #endregion
    }
}
