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
    public partial class FormLegajoDocumentacion : Biblioteca.Formularios.FormBaseABM_RRHH
    {
        #region Atributos
        private string[] consultaLegajoDocumentacion;
        private Legajo objLegajo; //Objeto Maestro
        private LegajoDocumentacion objLegajoDocumentacion;
        private LegajoDocumentacion objLegajoDocumentacionDB;
        private N_LegajoDocumentacion nLegajoDocumentacion = new N_LegajoDocumentacion();
        #endregion

        #region Constructores
        public FormLegajoDocumentacion()
        {
            InitializeComponent();
        }
        public FormLegajoDocumentacion(Legajo navLegajo) //Utilizado por el navegador de formularios
        {
            objLegajo = navLegajo;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormLegajoDocumentacion_Load(object sender, EventArgs e)
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
            if (Global.UsuarioActivo_Privilegios.Contains(118))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objLegajoDocumentacion != null)
            {
                if (objLegajoDocumentacion.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(118)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            objLegajoDocumentacion.Id = nLegajoDocumentacion.generarNumeroID(); //Paso 2: Genera un ID para cada Objeto
                            if (nLegajoDocumentacion.insertar(objLegajoDocumentacion)) //Paso 3: Inserta el objeto principal
                            {
                                mostrarRegistro(objLegajoDocumentacion);
                                Mensaje.RegistroCorrecto("REGISTRACION");
                            }
                        }
                    }
                }
                else if (objLegajoDocumentacion.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(119)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (ValidarCampoVacio())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            if (!objLegajoDocumentacion.Equals(objLegajoDocumentacionDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                            {
                                if (nLegajoDocumentacion.actualizar(objLegajoDocumentacion))
                                {
                                    mostrarRegistro(objLegajoDocumentacion);
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
            if (objLegajoDocumentacion.Id > 0) escribirControles(objLegajoDocumentacionDB); //Restaura los datos originales en base al registro seleccionado
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

        private void escribirControles(LegajoDocumentacion objLegajoDocumentacion)
        {
            this.objLegajoDocumentacion = objLegajoDocumentacion; //Iguala el Atributo de la clase con el Objeto recibido
            if (objLegajoDocumentacion != null && objLegajoDocumentacion.Legajo != null)
            {
                if (!objLegajoDocumentacion.Legajo.InformacionRestringida || (objLegajoDocumentacion.Legajo.InformacionRestringida && Global.UsuarioActivo_Privilegios.Contains(1))) //Verifica que el usuario posea el privilegio requerido
                {
                    _controladorDeNuevoRegistro = false;
                    objLegajoDocumentacion.Id = (objLegajoDocumentacion != null) ? objLegajoDocumentacion.Id : 0;
                    objLegajo = objLegajoDocumentacion.Legajo;
                    txtDenominacion.Text = objLegajoDocumentacion.Legajo.Denominacion;
                    txtCuit.Text = Convert.ToString(objLegajoDocumentacion.Legajo.Cuit);
                    chkAltaAFIP.Checked = objLegajoDocumentacion.AltaAfip;
                    chkContratoLaboral.Checked = objLegajoDocumentacion.Contrato;
                    chkCopiaCA.Checked = objLegajoDocumentacion.CopiaCA;
                    chkCopiaDNI.Checked = objLegajoDocumentacion.CopiaDNI;
                    chkCopiaLC.Checked = objLegajoDocumentacion.CopiaLicenciaConducir;
                    chkCopiaMatricula.Checked = objLegajoDocumentacion.CopiaMatricula;
                    chkCopiaTitulo.Checked = objLegajoDocumentacion.CopiaTitulo;
                    chkCredencialART.Checked = objLegajoDocumentacion.CredencialART;
                    chkCurriculumVitae.Checked = objLegajoDocumentacion.CurriculumVitae;
                    chkDDJJ.Checked = objLegajoDocumentacion.DeclaracionJurada;
                    chkDocumentacionFamiliar.Checked = objLegajoDocumentacion.DocumentacionFamiliar;
                    chkExamenMedico.Checked = objLegajoDocumentacion.ExamenMedico;
                    chkReglamentoRRHH.Checked = objLegajoDocumentacion.ReglamentoRRHH;
                    chkRoles.Checked = objLegajoDocumentacion.Roles;
                    txtOtraDocumentacion.Text = objLegajoDocumentacion.OtraDocumentacion;
                    labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objLegajoDocumentacion.EdicionFecha) + " por " + objLegajoDocumentacion.EdicionUsuarioDenominacion;
                }
                else restaurarControles();
            }
        }

        private void instanciarDesdeNavegacion(Legajo objLegajo)
        {
            objLegajoDocumentacionDB = nLegajoDocumentacion.obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)); //Paso 1: Busca el registro en la Base de Datos en relación al objeto maestro recibido 
            if (objLegajoDocumentacionDB != null)
            {
                lstCatalogo.SelectedValue = objLegajoDocumentacionDB.Id; //Posiona la selección de la fila en el registro guardado
                escribirControles(objLegajoDocumentacionDB); //Paso 2a: Escribe los datos del registro indicado
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
            this.objLegajoDocumentacion = new LegajoDocumentacion(
                (objLegajoDocumentacion.Id <= 0) ? 0 : objLegajoDocumentacion.Id,
                objLegajo,
                chkAltaAFIP.Checked,
                chkContratoLaboral.Checked,
                chkCopiaCA.Checked,
                chkCopiaDNI.Checked,
                chkCopiaLC.Checked,
                chkCopiaMatricula.Checked,
                chkCopiaTitulo.Checked,
                chkCredencialART.Checked,
                chkCurriculumVitae.Checked,
                chkDDJJ.Checked,
                chkDocumentacionFamiliar.Checked,
                chkExamenMedico.Checked,
                chkReglamentoRRHH.Checked,
                chkRoles.Checked,
                txtOtraDocumentacion.Text,
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objLegajo = new Legajo(); //Restaura el Objeto Primario
            objLegajoDocumentacion = new LegajoDocumentacion(); //Importante: Restaura el Objeto del Móludo
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            objLegajoDocumentacion.Id = 0; //Libera el Id del Objeto seleccionado
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            chkAltaAFIP.Checked = false;
            chkContratoLaboral.Checked = false;
            chkCopiaCA.Checked = false;
            chkCopiaDNI.Checked = false;
            chkCopiaLC.Checked = false;
            chkCopiaMatricula.Checked = false;
            chkCopiaTitulo.Checked = false;
            chkCredencialART.Checked = false;
            chkCurriculumVitae.Checked = false;
            chkDDJJ.Checked = false;
            chkDocumentacionFamiliar.Checked = false;
            chkExamenMedico.Checked = false;
            chkReglamentoRRHH.Checked = false;
            chkRoles.Checked = false;
            txtOtraDocumentacion.Text = "";
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, txtCuit }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(LegajoDocumentacion objLegajoDocumentacion) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objLegajoDocumentacion.Id; //Posiona la selección de la fila en el registro guardado
            escribirControles(objLegajoDocumentacion); //Escribe los datos del registro seleccionado
            objLegajoDocumentacionDB = objLegajoDocumentacion; //Importante: Se debe actualizar el Objeto precedente con el actual (evita el error de nulidad) 
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
                consultaLegajoDocumentacion = new string[] { "TODOS", "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nLegajoDocumentacion.obtenerCatalago("TODOS", "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la denominacón
            {
                consultaLegajoDocumentacion = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nLegajoDocumentacion.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objLegajoDocumentacionDB = nLegajoDocumentacion.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objLegajoDocumentacionDB); //Escribe los datos del registro seleccionado
        }

        protected override void navegarA_Formulario(string destino) { NavegacionRRHH.navegarA_Formulario(destino, this, objLegajo); }

        protected override void reportarRegistro(string programa)
        {
            if (objLegajoDocumentacion.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "N° Legajo: ",
                    "Denominación: ",
                    "CUIL/CUIT: ",
                    "Alta AFIP: ",
                    "Contrato laboral: ",
                    "Copia de CA: ",
                    "Copia de DNI: ",
                    "Copia de LC: ",
                    "Copia de matrícula: ",
                    "Copia de título: ",
                    "Credencial de ART: ",
                    "Currículum Vitae: ",
                    "DDJJ: ",
                    "Documentación familiar: ",
                    "Estudio médico: ",
                    "Reglamento de RRHH: ",
                    "Roles: ",
                    "Otra documentación: " };
                string[] datoDB = {
                    objLegajo.Id.ToString().PadLeft(8, '0'),
                    objLegajo.Denominacion,
                    objLegajo.Cuit.ToString("00-00000000/0"),
                    (objLegajoDocumentacion.AltaAfip) ? "Si" : "No",
                    (objLegajoDocumentacion.Contrato) ? "Si" : "No",
                    (objLegajoDocumentacion.CopiaCA) ? "Si" : "No",
                    (objLegajoDocumentacion.CopiaDNI) ? "Si" : "No",
                    (objLegajoDocumentacion.CopiaLicenciaConducir) ? "Si" : "No",
                    (objLegajoDocumentacion.CopiaMatricula) ? "Si" : "No",
                    (objLegajoDocumentacion.CopiaTitulo) ? "Si" : "No",
                    (objLegajoDocumentacion.CredencialART) ? "Si" : "No",
                    (objLegajoDocumentacion.CurriculumVitae) ? "Si" : "No",
                    (objLegajoDocumentacion.DeclaracionJurada) ? "Si" : "No",
                    (objLegajoDocumentacion.DocumentacionFamiliar) ? "Si" : "No",
                    (objLegajoDocumentacion.ExamenMedico) ? "Si" : "No",
                    (objLegajoDocumentacion.ReglamentoRRHH) ? "Si" : "No",
                    (objLegajoDocumentacion.Roles) ? "Si" : "No",
                    objLegajoDocumentacion.OtraDocumentacion };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Legajo - Documentación", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Legajo - Documentación", subTitulo, datoDB);
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
                lista = nLegajoDocumentacion.obtenerCatalago(consultaLegajoDocumentacion[0], consultaLegajoDocumentacion[1], consultaLegajoDocumentacion[2], "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Denominación",
                    "CUIL/CUIT",
                    "Documentación" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //ID
                    campo[1].Trim(), //Denominación
                    campo[2].Trim(), //CUIL/CUIT
                    campo[3].Trim() }; //Documentación
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Legajos - Documentación", subTitulos, new int[] { 8, 43, 13, 65 }, _listaDelReporte, new List<int> { }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Legajos - Documentación", subTitulos, new float[] { 8, 39, 11, 53 }, _listaDelReporte); //Ancho: 111
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
