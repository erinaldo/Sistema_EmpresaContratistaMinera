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
    public partial class FormCapacitacionLaboral : Biblioteca.Formularios.FormBaseABM_RRHH
    {
        #region Atributos
        private bool _nuevoRegitroDesdeNavegacion = false;
        private string[] consultaCapacitacionLaboral;
        private Legajo objLegajo; //Objeto Primario
        private LegajoLaboral objLegajoLaboral; //Objeto Secundario
        private CapacitacionLaboral objCapacitacionLaboral; //Objeto del Módulo
        private CapacitacionLaboral objCapacitacionLaboralDB; //Objeto de la Base de Datos
        private N_Legajo nLegajo = new N_Legajo();
        private N_LegajoLaboral nLegajoLaboral = new N_LegajoLaboral();
        private N_CapacitacionLaboral nCapacitacionLaboral = new N_CapacitacionLaboral();
        #endregion

        #region Constructores
        public FormCapacitacionLaboral()
        {
            InitializeComponent();
        }
        public FormCapacitacionLaboral(Legajo navLegajo, bool nuevoRegitroDesdeNavegacion = false) //Utilizado por el navegador de formularios
        {
            objLegajo = navLegajo;
            _nuevoRegitroDesdeNavegacion = nuevoRegitroDesdeNavegacion;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormCapacitacionLaboral_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { }), 0);
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO",
                "FILTRAR POR ESTADO: ANULADO", "TODOS LOS ESTADOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT",
                "FILTRAR POR DENOMINACION", "FILTRAR POR FECHA" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
            if (objLegajo != null) instanciarDesdeNavegacion(objLegajo);
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
            if (Global.UsuarioActivo_Privilegios.Contains(92))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objCapacitacionLaboral != null)
            {
                if (objCapacitacionLaboral.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(92)) //Verifica que el usuario posea el privilegio requerido
            {
                //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        this.objLegajo = nLegajo.obtenerObjeto("ID", objCapacitacionLaboral.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                        objCapacitacionLaboral.Id = nCapacitacionLaboral.generarNumeroID(); //Paso 3: Genera un ID para cada Objeto
                        if (nCapacitacionLaboral.insertar(objCapacitacionLaboral)) //Paso 4: Inserta el objeto principal
                        {
                            mostrarRegistro(objCapacitacionLaboral);
                            Mensaje.RegistroCorrecto("REGISTRACION");
                        }
                    }
                }
            }
                else if (objCapacitacionLaboral.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(94)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (objCapacitacionLaboralDB.Estado == "ACTIVO") //Verifica que la capacitación este Activo
                    {
                        if (ValidarCampoVacio())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                this.objLegajo = nLegajo.obtenerObjeto("ID", objCapacitacionLaboral.Legajo.Id.ToString(), false); //Paso 3: Importante: Re-Almacena el Objeto de la Base de Datos
                                if (!objCapacitacionLaboral.Equals(objCapacitacionLaboralDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                                {
                                    if (nCapacitacionLaboral.actualizar(objCapacitacionLaboral))
                                    {
                                        mostrarRegistro(objCapacitacionLaboral);
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
                    return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion, txtCuit, cmbCapacitador,
                        cmbCapacitacion });
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objCapacitacionLaboral.Id > 0) escribirControles(objCapacitacionLaboralDB); //Restaura los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(93)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objCapacitacionLaboral.Id > 0)
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea anular el registro ID: " + objCapacitacionLaboral.Id.ToString() + "?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        objLegajo = nLegajo.obtenerObjeto("ID", objCapacitacionLaboral.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                        if (nCapacitacionLaboral.anular(objCapacitacionLaboral)) //Paso 3: Verifica el exito de la actualización y muestra los datos actualizados
                        {
                            objCapacitacionLaboral.Estado = "ANULADO"; //Paso 4: Importante: Establece el cambio de estado en el Objeto del Módulo 
                            mostrarRegistro(objCapacitacionLaboral);
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

        private void escribirControles(CapacitacionLaboral objRegistro)
        {
            this.objCapacitacionLaboral = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            if (objCapacitacionLaboral != null && objCapacitacionLaboral.Legajo != null)
            {
                if (!objCapacitacionLaboral.Legajo.InformacionRestringida || (objCapacitacionLaboral.Legajo.InformacionRestringida && Global.UsuarioActivo_Privilegios.Contains(1))) //Verifica que el usuario posea el privilegio requerido
                {
                    _controladorDeNuevoRegistro = false;
                    DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
                    objCapacitacionLaboral.Id = (objCapacitacionLaboral != null) ? objCapacitacionLaboral.Id : 0;
                    objLegajo = objCapacitacionLaboral.Legajo;
                    objLegajoLaboral = new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id));
                    txtDenominacion.Text = objCapacitacionLaboral.Legajo.Denominacion;
                    txtCuit.Text = Convert.ToString(objCapacitacionLaboral.Legajo.Cuit);
                    cmbCentroCosto.Text = (objCapacitacionLaboral.CentroCosto != null) ? objCapacitacionLaboral.CentroCosto.Denominacion : "";
                    cmbCapacitador.Text = objCapacitacionLaboral.Capacitador;
                    cmbCapacitacion.Text = objCapacitacionLaboral.Capacitacion;
                    pkrFechaEmision.Value = objCapacitacionLaboral.FechaEmision;
                    txtObservacion.Text = objCapacitacionLaboral.Observacion;
                    txtEstado.Text = objCapacitacionLaboral.Estado;
                    labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objCapacitacionLaboral.EdicionFecha) + " por " + objCapacitacionLaboral.EdicionUsuarioDenominacion;
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
                objCapacitacionLaboralDB = nCapacitacionLaboral.obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)); //Paso 1: Busca el registro en la Base de Datos en relación al objeto maestro recibido 
                if (objCapacitacionLaboralDB != null)
                {
                    lstCatalogo.SelectedValue = objCapacitacionLaboralDB.Id; //Paso 2: Posiona la selección de la fila en el registro guardado
                    escribirControles(objCapacitacionLaboralDB); //Paso 3: Escribe los datos del registro indicado
                }
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objCapacitacionLaboral = new CapacitacionLaboral(
                (objCapacitacionLaboral.Id <= 0) ? 0 : objCapacitacionLaboral.Id,
                objLegajo,
                new N_CentroCosto().obtenerObjeto("DENOMINACION", cmbCentroCosto.Text),
                cmbCapacitador.Text,
                cmbCapacitacion.Text,
                pkrFechaEmision.Value,
                txtObservacion.Text,
                txtEstado.Text,
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objLegajo = new Legajo(); //Restaura el Objeto Primario
            objLegajoLaboral = new LegajoLaboral(); //Restaura el Objeto SubPrimario
            objCapacitacionLaboral = new CapacitacionLaboral(); //Importante: Restaura el Objeto del Móludo
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(cmbCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { }), 0); //Restauración de los items del ComboBox
            objCapacitacionLaboral.Id = 0; //Libera el Id del Objeto seleccionado
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            cmbCapacitador.Text = "EMPREMINSA";
            cmbCapacitacion.Text = "CAMPAÑA MANOS";
            pkrFechaEmision.Value = fechaActual;
            txtObservacion.Text = "";
            txtEstado.Text = "ACTIVO";
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, txtCuit, cmbCapacitador,
                cmbCapacitacion }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(CapacitacionLaboral objRegistro) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objCapacitacionLaboralDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            escribirControles(objCapacitacionLaboralDB); //Escribe los datos del registro seleccionado
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
            if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ACTIVO") filtroEstado = "ACTIVO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ANULADO") filtroEstado = "ANULADO";
            if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de CUIL/CUIT
            {
                consultaCapacitacionLaboral = new string[] { filtroEstado, "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCapacitacionLaboral.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la denominacón
            {
                consultaCapacitacionLaboral = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCapacitacionLaboral.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA") //Verifica que el tipo de filtro es por fecha
            {
                consultaCapacitacionLaboral = new string[] { filtroEstado, "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nCapacitacionLaboral.obtenerCatalago(filtroEstado, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objCapacitacionLaboralDB = nCapacitacionLaboral.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objCapacitacionLaboralDB); //Escribe los datos del registro seleccionado
        }

        protected override void navegarA_Formulario(string destino) { NavegacionRRHH.navegarA_Formulario(destino, this, objLegajo); }

        protected override void reportarRegistro(string programa)
        {
            if (objCapacitacionLaboral.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "N° Legajo: ",
                    "Denominación: ",
                    "CUIL/CUIT: ",
                    "Centro de costo: ",
                    "Capacitador: ",
                    "Capacitación: ",
                    "Fecha de emisión: ",
                    "Observaciones: ",
                    "Estado: " };
                string[] datoDB = {
                    objCapacitacionLaboral.Legajo.Id.ToString().PadLeft(8, '0'),
                    objCapacitacionLaboral.Legajo.Denominacion,
                    objCapacitacionLaboral.Legajo.Cuit.ToString("00-00000000/0"),
                    objCapacitacionLaboral.CentroCosto.Denominacion,
                    objCapacitacionLaboral.Capacitador,
                    objCapacitacionLaboral.Capacitacion,
                    Fecha.ConvertirFecha(objCapacitacionLaboral.FechaEmision),
                    objCapacitacionLaboral.Observacion,
                    objCapacitacionLaboral.Estado };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Capacitación Laboral", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Capacitación Laboral", subTitulo, datoDB);
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
                lista = nCapacitacionLaboral.obtenerCatalago(consultaCapacitacionLaboral[0], consultaCapacitacionLaboral[1], consultaCapacitacionLaboral[2], "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Denominación",
                    "CUIL/CUIT",
                    "Capacitador",
                    "Capacitación",
                    "F. Emisión",
                    "Estado" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //ID
                    campo[1].Trim(), //Denominación
                    campo[2].Trim(), //CUIL/CUIT
                    campo[3].Trim(), //Capacitador
                    campo[4].Trim(), //Capacitación
                    campo[5].Trim(), //F. Emisión
                    campo[6].Trim() }; //Estado
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Capacitaciones Laborales", subTitulos, new int[] { 8, 58, 13, 16, 16, 10, 8 }, _listaDelReporte, new List<int> { 5 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Capacitaciones Laborales", subTitulos, new float[] { 7, 51, 11, 13, 13, 9, 7 }, _listaDelReporte); //Ancho: 111
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
