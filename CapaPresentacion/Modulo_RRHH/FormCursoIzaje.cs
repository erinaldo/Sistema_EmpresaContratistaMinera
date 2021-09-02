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
    public partial class FormCursoIzaje : Biblioteca.Formularios.FormBaseABM_RRHH
    {
        #region Atributos
        private bool _nuevoRegitroDesdeNavegacion = false;
        private string[] consultaCursoIzaje;
        private Legajo objLegajo; //Objeto Primario
        private LegajoLaboral objLegajoLaboral; //Objeto Secundario
        private CursoIzaje objCursoIzaje; //Objeto del Módulo
        private CursoIzaje objCursoIzajeDB; //Objeto de la Base de Datos
        private N_Legajo nLegajo = new N_Legajo();
        private N_LegajoLaboral nLegajoLaboral = new N_LegajoLaboral();
        private N_CursoIzaje nCursoIzaje = new N_CursoIzaje();
        #endregion

        #region Constructores
        public FormCursoIzaje()
        {
            InitializeComponent();
        }
        public FormCursoIzaje(Legajo navLegajo, bool nuevoRegitroDesdeNavegacion = false) //Utilizado por el navegador de formularios
        {
            objLegajo = navLegajo;
            _nuevoRegitroDesdeNavegacion = nuevoRegitroDesdeNavegacion;
            InitializeComponent();
        }
        public FormCursoIzaje(CursoIzaje navCursoIzaje) //Utilizado por el navegador de formularios
        {
            objCursoIzajeDB = objCursoIzaje = navCursoIzaje;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormCursoIzaje_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { }), 0);
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ANULADO",
                "FILTRAR POR ESTADO: OBSOLETO", "FILTRAR POR ESTADO: VIGENTE", "TODOS LOS ESTADOS" }, 2); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT",
                "FILTRAR POR DENOMINACION", "FILTRAR POR FECHA" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
            if (objLegajo != null) instanciarDesdeNavegacion(objLegajo);
            if (objCursoIzajeDB != null && !_controladorDeNuevoRegistro) escribirControles(objCursoIzajeDB); //Escribe los datos solicitados mediante la navegación entre formularios
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
            if (Global.UsuarioActivo_Privilegios.Contains(103))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objCursoIzaje != null)
            {
                if (objCursoIzaje.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(103)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        this.objLegajo = nLegajo.obtenerObjeto("ID", objCursoIzaje.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                        objCursoIzaje.Id = nCursoIzaje.generarNumeroID(); //Paso 3: Genera un ID para cada Objeto
                        if (nCursoIzaje.insertar(objCursoIzaje)) //Paso 5: Inserta el objeto principal
                        {
                            mostrarRegistro(objCursoIzaje);
                            Mensaje.RegistroCorrecto("REGISTRACION");
                        }
                    }
                }
                else if (objCursoIzaje.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(105)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (objCursoIzajeDB.Estado == "VIGENTE") //Verifica que el contrato este Vigente
                    {
                        if (ValidarCampoVacio())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                this.objLegajo = nLegajo.obtenerObjeto("ID", objCursoIzaje.Legajo.Id.ToString(), false); //Paso 3: Importante: Re-Almacena el Objeto de la Base de Datos
                                if (!objCursoIzaje.Equals(objCursoIzajeDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                                {
                                    if (nCursoIzaje.actualizar(objCursoIzaje))
                                    {
                                        mostrarRegistro(objCursoIzaje);
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
            if (objCursoIzaje.Id > 0) escribirControles(objCursoIzajeDB); //Restaura los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(104)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objCursoIzaje.Id > 0)
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea anular el registro ID: " + objCursoIzaje.Id.ToString() + "?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        objLegajo = nLegajo.obtenerObjeto("ID", objCursoIzaje.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                        if (nCursoIzaje.anular(objCursoIzaje)) //Paso 3: Verifica el exito de la actualización y muestra los datos actualizados
                        {
                            objCursoIzaje.Estado = "ANULADO"; //Paso 4: Importante: Establece el cambio de estado en el Objeto del Módulo 
                            mostrarRegistro(objCursoIzaje);
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

        private void escribirControles(CursoIzaje objRegistro)
        {
            this.objCursoIzaje = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            if (objCursoIzaje != null && objCursoIzaje.Legajo != null)
            {
                if (!objCursoIzaje.Legajo.InformacionRestringida || (objCursoIzaje.Legajo.InformacionRestringida && Global.UsuarioActivo_Privilegios.Contains(1))) //Verifica que el usuario posea el privilegio requerido
                {
                    _controladorDeNuevoRegistro = false;
                    DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
                    objLegajo = objCursoIzaje.Legajo;
                    objLegajoLaboral = new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id));
                    txtDenominacion.Text = objCursoIzaje.Legajo.Denominacion;
                    txtCuit.Text = Convert.ToString(objCursoIzaje.Legajo.Cuit);
                    cmbCentroCosto.Text = (objCursoIzaje.CentroCosto != null) ? objCursoIzaje.CentroCosto.Denominacion : "";
                    pkrFechaEmision.Value = objCursoIzaje.FechaEmision;
                    chkItem1.Checked = objCursoIzaje.Item1;
                    chkItem2.Checked = objCursoIzaje.Item2;
                    chkItem3.Checked = objCursoIzaje.Item3;
                    chkItem4.Checked = objCursoIzaje.Item4;
                    chkItem5.Checked = objCursoIzaje.Item5;
                    chkItem6.Checked = objCursoIzaje.Item6;
                    chkItem7.Checked = objCursoIzaje.Item7;
                    txtObservacion.Text = objCursoIzaje.Observacion;
                    txtEstado.Text = objCursoIzaje.Estado;
                    labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objCursoIzaje.EdicionFecha) + " por " + objCursoIzaje.EdicionUsuarioDenominacion;
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
                objCursoIzaje = nCursoIzaje.obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)); //Paso 1: Busca el registro en la Base de Datos en relación al objeto maestro recibido 
                if (objCursoIzaje != null)
                {
                    lstCatalogo.SelectedValue = objCursoIzaje.Id; //Paso 2: Posiona la selección de la fila en el registro guardado
                    escribirControles(objCursoIzaje); //Paso 3: Escribe los datos del registro indicado
                }
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objCursoIzaje = new CursoIzaje(
                (objCursoIzaje.Id <= 0) ? 0 : objCursoIzaje.Id,
                objLegajo,
                new N_CentroCosto().obtenerObjeto("DENOMINACION", cmbCentroCosto.Text),
                pkrFechaEmision.Value,
                ((pkrFechaEmision.Value.AddMonths(Global.Vigencia_CursoIzaje).AddDays(Global.Alerta_CursoIzaje) < fechaActual.AddDays(Global.Alerta_CursoIzaje)) ? true : false),
                chkItem1.Checked,
                chkItem2.Checked,
                chkItem3.Checked,
                chkItem4.Checked,
                chkItem5.Checked,
                chkItem6.Checked,
                chkItem7.Checked,
                txtObservacion.Text,
                ((fechaActual > pkrFechaEmision.Value.AddMonths(Global.Vigencia_CursoIzaje) && txtEstado.Text == "VIGENTE") ? "OBSOLETO" : txtEstado.Text),
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objLegajo = new Legajo(); //Restaura el Objeto Primario
            objLegajoLaboral = new LegajoLaboral(); //Restaura el Objeto SubPrimario
            objCursoIzaje = new CursoIzaje(); //Importante: Restaura el Objeto del Móludo
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(cmbCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { }), 0); //Restauración de los items del ComboBox
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            pkrFechaEmision.Value = fechaActual;
            chkItem1.Checked = false;
            chkItem2.Checked = false;
            chkItem3.Checked = false;
            chkItem4.Checked = false;
            chkItem5.Checked = false;
            chkItem6.Checked = false;
            chkItem7.Checked = false;
            txtObservacion.Text = "";
            txtEstado.Text = "VIGENTE";
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, txtCuit }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(CursoIzaje objRegistro) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objCursoIzajeDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            escribirControles(objCursoIzajeDB); //Escribe los datos del registro seleccionado
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
                consultaCursoIzaje = new string[] { filtroEstado, "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCursoIzaje.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la denominacón
            {
                consultaCursoIzaje = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCursoIzaje.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA") //Verifica que el tipo de filtro es por fecha
            {
                consultaCursoIzaje = new string[] { filtroEstado, "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nCursoIzaje.obtenerCatalago(filtroEstado, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objCursoIzajeDB = nCursoIzaje.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objCursoIzajeDB); //Escribe los datos del registro seleccionado
        }

        protected override void navegarA_Formulario(string destino) { NavegacionRRHH.navegarA_Formulario(destino, this, objLegajo); }

        protected override void reportarRegistro(string programa)
        {
            if (objCursoIzaje.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "N° Legajo: ",
                    "Denominación: ",
                    "CUIL/CUIT: ",
                    "Centro de costo: ",
                    "Fecha de emisión: ",
                    "Autoelevadores: ",
                    "Hidrogruas hasta 20t.m.: ",
                    "Manipulador telescópico: ",
                    "Minicargador de dirección deslizante: ",
                    "Plataforma de trabajo en altura: ",
                    "Puente grúa: ",
                    "Otras licencias: ",
                    "Observaciones: ",
                    "Estado: " };
                string[] datoDB = {
                    objCursoIzaje.Legajo.Id.ToString().PadLeft(8, '0'),
                    objCursoIzaje.Legajo.Denominacion,
                    objCursoIzaje.Legajo.Cuit.ToString("00-00000000/0"),
                    objCursoIzaje.CentroCosto.Denominacion,
                    Fecha.ConvertirFecha(objCursoIzaje.FechaEmision),
                    ((objCursoIzaje.Item1) ? "Si" : "No"),
                    ((objCursoIzaje.Item2) ? "Si" : "No"),
                    ((objCursoIzaje.Item3) ? "Si" : "No"),
                    ((objCursoIzaje.Item4) ? "Si" : "No"),
                    ((objCursoIzaje.Item5) ? "Si" : "No"),
                    ((objCursoIzaje.Item6) ? "Si" : "No"),
                    ((objCursoIzaje.Item7) ? "Si" : "No"),
                    objCursoIzaje.Observacion,
                    objCursoIzaje.Estado };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Curso de Equipos de Izaje", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Curso de Equipos de Izaje", subTitulo, datoDB);
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
                lista = nCursoIzaje.obtenerCatalago(consultaCursoIzaje[0], consultaCursoIzaje[1], consultaCursoIzaje[2], "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Denominación",
                    "CUIL/CUIT",
                    "F. Emisión",
                    "F. Vto.",
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
                    campo[5].Trim() }; //Estado
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Cursos de Equipos de Izaje", subTitulos, new int[] { 8, 80, 13, 10, 10, 8 }, _listaDelReporte, new List<int> { 3, 4 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Cursos de Equipos de Izaje", subTitulos, new float[] { 7, 68, 11, 9, 9, 7 }, _listaDelReporte); //Ancho: 111
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
