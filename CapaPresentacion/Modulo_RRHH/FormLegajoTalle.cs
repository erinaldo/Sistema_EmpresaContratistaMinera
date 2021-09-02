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
    public partial class FormLegajoTalle : Biblioteca.Formularios.FormBaseABM_RRHH
    {
        #region Atributos
        private string[] consultaLegajoTalle;
        private Legajo objLegajo; //Objeto Maestro
        private LegajoTalle objLegajoTalle;
        private LegajoTalle objLegajoTalleDB;
        private N_LegajoTalle nLegajoTalle = new N_LegajoTalle();
        #endregion

        #region Constructores
        public FormLegajoTalle()
        {
            InitializeComponent();
        }
        public FormLegajoTalle(Legajo navLegajo) //Utilizado por el navegador de formularios
        {
            objLegajo = navLegajo;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormLegajoTalle_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR LEGAJOS C/BAJA",
                "FILTRAR POR LEGAJOS S/BAJA", "TODOS LOS LEGAJOS" }, 1); //Establece los items del ComboBox 
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT", "FILTRAR POR DENOMINACION" }, 1); //Establece los items del ComboBox
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
            if (Global.UsuarioActivo_Privilegios.Contains(128))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objLegajoTalle != null)
            {
                if (objLegajoTalle.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(128)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            objLegajoTalle.Id = nLegajoTalle.generarNumeroID(); //Paso 2: Genera un ID para cada Objeto
                            if (nLegajoTalle.insertar(objLegajoTalle)) //Paso 3: Inserta el objeto principal
                            {
                                mostrarRegistro(objLegajoTalle);
                                Mensaje.RegistroCorrecto("REGISTRACION");
                            }
                        }
                    }
                }
                else if (objLegajoTalle.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(129)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (ValidarCampoVacio())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            if (!objLegajoTalle.Equals(objLegajoTalleDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                            {
                                if (nLegajoTalle.actualizar(objLegajoTalle))
                                {
                                    mostrarRegistro(objLegajoTalle);
                                    Mensaje.RegistroCorrecto("MODIFICACION");
                                }
                            }
                        }
                    }
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
            if (objLegajoTalle.Id > 0) escribirControles(objLegajoTalleDB); //Restaura los datos originales en base al registro seleccionado
            else restaurarControles();
        }
        #endregion

        #region Métodos
        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(LegajoTalle objLegajoTalle)
        {
            this.objLegajoTalle = objLegajoTalle; //Iguala el Atributo de la clase con el Objeto recibido
            if (objLegajoTalle != null && objLegajoTalle.Legajo != null)
            {
                if (!objLegajoTalle.Legajo.InformacionRestringida || (objLegajoTalle.Legajo.InformacionRestringida && Global.UsuarioActivo_Privilegios.Contains(1))) //Verifica que el usuario posea el privilegio requerido
                {
                    _controladorDeNuevoRegistro = false;
                    objLegajoTalle.Id = (objLegajoTalle != null) ? objLegajoTalle.Id : 0;
                    objLegajo = objLegajoTalle.Legajo;
                    txtDenominacion.Text = objLegajoTalle.Legajo.Denominacion;
                    txtCuit.Text = Convert.ToString(objLegajoTalle.Legajo.Cuit);
                    cmbTalleCamisa.Text = objLegajoTalle.TalleCamisa;
                    cmbTallePantalon.Text = objLegajoTalle.TallePantalon;
                    cmbTalleCalzado.Text = objLegajoTalle.TalleCalzado;
                    labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objLegajoTalle.EdicionFecha) + " por " + objLegajoTalle.EdicionUsuarioDenominacion;
                }
                else restaurarControles();
            }
        }

        private void instanciarDesdeNavegacion(Legajo objLegajo)
        {
            objLegajoTalleDB = nLegajoTalle.obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)); //Paso 1: Busca el registro en la Base de Datos en relación al objeto maestro recibido 
            if (objLegajoTalleDB != null)
            {
                lstCatalogo.SelectedValue = objLegajoTalleDB.Id; //Posiona la selección de la fila en el registro guardado
                escribirControles(objLegajoTalleDB); //Paso 2a: Escribe los datos del registro indicado
            }
            else
            {
                btnNuevo.PerformClick(); //Paso 2b: Ejecuta automáticamente el botón "Nuevo"
                this.objLegajo = objLegajo; //Iguala el Atributo de la clase con el Objeto recibido
                txtDenominacion.Text = objLegajo.Denominacion;
                txtCuit.Text = Convert.ToString(objLegajo.Cuit);
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objLegajoTalle = new LegajoTalle(
                (objLegajoTalle.Id <= 0) ? 0 : objLegajoTalle.Id,
                objLegajo,
                cmbTalleCamisa.Text,
                cmbTallePantalon.Text,
                cmbTalleCalzado.Text,
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objLegajo = new Legajo(); //Restaura el Objeto Primario
            objLegajoTalle = new LegajoTalle(); //Importante: Restaura el Objeto del Móludo
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            cmbTalleCamisa.Text = "S/D";
            cmbTallePantalon.Text = "S/D";
            cmbTalleCalzado.Text = "S/D";
            labelPublicacion.Text = "";          
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion , txtCuit }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(LegajoTalle objLegajoTalle) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objLegajoTalle.Id; //Posiona la selección de la fila en el registro guardado
            escribirControles(objLegajoTalle); //Escribe los datos del registro seleccionado
            objLegajoTalleDB = objLegajoTalle; //Importante: Se debe actualizar el Objeto precedente con el actual (evita el error de nulidad) 
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR CUIT")
            {
                cmbFiltroLista1.Enabled = false;
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
            {
                cmbFiltroLista1.Enabled = true;
            }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroEstado = "TODOS";
            if (cmbFiltroLista1.Text == "FILTRAR POR LEGAJOS C/BAJA") filtroEstado = "C/BAJA";
            else if (cmbFiltroLista1.Text == "FILTRAR POR LEGAJOS S/BAJA") filtroEstado = "S/BAJA";
            if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de CUIL/CUIT
            {
                consultaLegajoTalle = new string[] { "TODOS", "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nLegajoTalle.obtenerCatalago("TODOS", "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la denominacón
            {
                consultaLegajoTalle = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nLegajoTalle.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objLegajoTalleDB = nLegajoTalle.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objLegajoTalleDB); //Escribe los datos del registro seleccionado
        }

        protected override void navegarA_Formulario(string destino) { NavegacionRRHH.navegarA_Formulario(destino, this, objLegajo); }

        protected override void reportarRegistro(string programa)
        {
            if (objLegajoTalle.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "N° Legajo: ",
                    "Denominación: ",
                    "CUIL/CUIT: ",
                    "Talle de camisa: ",
                    "Talle de pantalón: ",
                    "Talle de calzado: " };
                string[] datoDB = {
                    objLegajo.Id.ToString().PadLeft(8, '0'),
                    objLegajo.Denominacion,
                    objLegajo.Cuit.ToString("00-00000000/0"),
                    objLegajoTalle.TalleCamisa,
                    objLegajoTalle.TallePantalon,
                    objLegajoTalle.TalleCalzado };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Legajo - Talles de Indumentaria", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Legajo - Talles de Indumentaria", subTitulo, datoDB);
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
                lista = nLegajoTalle.obtenerCatalago(consultaLegajoTalle[0], consultaLegajoTalle[1], consultaLegajoTalle[2], "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Denominación",
                    "CUIL/CUIT",
                    "T. Camisa",
                    "T. Pantalón",
                    "T. Calzado" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //ID
                    campo[1].Trim(), //Denominación
                    campo[2].Trim(), //CUIL/CUIT
                    campo[3].Trim(), //T. Camisa
                    campo[4].Trim(), //T. Pantalón
                    campo[5].Trim() }; //T. Calzado
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Legajos - Talles de Indumentaria", subTitulos, new int[] { 8, 78, 13, 10, 10, 10 }, _listaDelReporte, new List<int> { }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Legajos - Talles de Indumentaria", subTitulos, new float[] { 7, 66, 11, 9, 9, 9 }, _listaDelReporte); //Ancho: 111
            }
        }

        public override void asignarVariablesDeFormulario(string[] variablesDeFormulario)
        {
            if (variablesDeFormulario[0] == "Catalogo_Legajo") //Catálogo de Legajos
            {
                this.objLegajo = new N_Legajo().obtenerObjeto("ID", variablesDeFormulario[1], true);
                txtDenominacion.Text = objLegajo.Denominacion;
                txtCuit.Text = Convert.ToString(objLegajo.Cuit);
            }
        }
        #endregion
    }
}
