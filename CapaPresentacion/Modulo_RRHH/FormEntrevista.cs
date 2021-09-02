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
    public partial class FormEntrevista : Biblioteca.Formularios.FormBaseABM_RRHH
    {
        #region Atributos
        private bool _nuevoRegitroDesdeNavegacion = false;
        private string[] consultaEntrevista;
        private Legajo objLegajo; //Objeto Primario
        private LegajoCurriculumVitae objLegajoCurriculumVitae; //Objeto Secundario
        private Entrevista objEntrevista; //Objeto del Módulo
        private Entrevista objEntrevistaDB; //Objeto de la Base de Datos
        private N_Legajo nLegajo = new N_Legajo();
        private N_LegajoCurriculumVitae nLegajoCurriculumVitae = new N_LegajoCurriculumVitae();
        private N_Entrevista nEntrevista = new N_Entrevista();
        #endregion

        #region Constructores
        public FormEntrevista()
        {
            InitializeComponent();
        }
        public FormEntrevista(Legajo navLegajo, bool nuevoRegitroDesdeNavegacion = false) //Utilizado por el navegador de formularios
        {
            objLegajo = navLegajo;
            _nuevoRegitroDesdeNavegacion = nuevoRegitroDesdeNavegacion;
            InitializeComponent();
        }
        public FormEntrevista(Entrevista navEntrevista) //Utilizado por el navegador de formularios
        {
            objEntrevistaDB = objEntrevista = navEntrevista;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormEntrevista_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ANULADO",
                "FILTRAR POR ESTADO: REALIZADO", "FILTRAR POR ESTADO: S/REALIZAR", "TODAS LOS ESTADOS" }, 3); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT",
                "FILTRAR POR DENOMINACION", "FILTRAR POR FECHA DE CITA" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
            if (objLegajo != null) instanciarDesdeNavegacion(objLegajo);
            if (objEntrevistaDB != null && !_controladorDeNuevoRegistro) escribirControles(objEntrevistaDB); //Escribe los datos solicitados mediante la navegación entre formularios
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
            if (Global.UsuarioActivo_Privilegios.Contains(107))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objEntrevista != null)
            {
                if (objEntrevista.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(107)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                    {
                        if (objLegajoCurriculumVitae != null) //Verifica que la persona tenga un Currículum Vitae
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                this.objLegajo = nLegajo.obtenerObjeto("ID", objEntrevista.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                                objEntrevista.Id = nEntrevista.generarNumeroID(); //Paso 3: Genera un ID para cada Objeto
                                if (nEntrevista.insertar(objEntrevista)) //Paso 5: Inserta el objeto principal
                                {
                                    mostrarRegistro(objEntrevista);
                                    Mensaje.RegistroCorrecto("REGISTRACION");
                                }
                            }
                        }
                        else Mensaje.Advertencia("Operación incorrecta.\nLa persona No posee un currículum vitae.\nVerifique los datos e intente nuevamente.");
                    }
                }
                else if (objEntrevista.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(109)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (objEntrevistaDB.Estado != "ANULADO") //Verifica que la entrevista No este anulada
                    {
                        if (ValidarCampoVacio())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                this.objLegajo = nLegajo.obtenerObjeto("ID", objEntrevista.Legajo.Id.ToString(), false); //Paso 3: Importante: Re-Almacena el Objeto de la Base de Datos
                                if (!objEntrevista.Equals(objEntrevistaDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                                {
                                    if (nEntrevista.actualizar(objEntrevista))
                                    {
                                        mostrarRegistro(objEntrevista);
                                        Mensaje.RegistroCorrecto("MODIFICACION");
                                    }
                                }
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación incorrecta.\nLos registros anulados No pueden ser modificados.");
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
            if (objEntrevista.Id > 0) escribirControles(objEntrevistaDB); //Restaura los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(108)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objEntrevista.Id > 0)
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea anular el registro ID: " + objEntrevista.Id.ToString() + "?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        objLegajo = nLegajo.obtenerObjeto("ID", objEntrevista.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                        if (nEntrevista.anular(objEntrevista)) //Paso 3: Verifica el exito de la actualización y muestra los datos actualizados
                        {
                            objEntrevista.Estado = "ANULADO"; //Paso 4: Importante: Establece el cambio de estado en el Objeto del Módulo 
                            mostrarRegistro(objEntrevista);
                            Mensaje.RegistroCorrecto("ANULACION");
                        }
                    }
                }
            }
            else Mensaje.Restriccion();
        }
        #endregion

        #region Métodos
        private void actualizarCurriculumVitae(Entrevista objEntrevista)
        {
            objLegajoCurriculumVitae = nLegajoCurriculumVitae.obtenerObjeto("ID_LEGAJO", Convert.ToString(objEntrevista.Legajo.Id));
            if (objLegajoCurriculumVitae != null)
            {
                objLegajoCurriculumVitae.CurriculumVitaeDisponibilidad = cmbDisponibilidad.Text;
                objLegajoCurriculumVitae.CurriculumVitaeCalificacion = cmbCalificacion.Text;
                nLegajoCurriculumVitae.actualizar(objLegajoCurriculumVitae);
            }
        }

        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(Entrevista objRegistro)
        {
            this.objEntrevista = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            if (objEntrevista != null && objEntrevista.Legajo != null)
            {
                if (!objEntrevista.Legajo.InformacionRestringida || (objEntrevista.Legajo.InformacionRestringida && Global.UsuarioActivo_Privilegios.Contains(1))) //Verifica que el usuario posea el privilegio requerido
                {
                    _controladorDeNuevoRegistro = false;
                    DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
                    objLegajo = objEntrevista.Legajo;
                    txtDenominacion.Text = objEntrevista.Legajo.Denominacion;
                    txtCuit.Text = Convert.ToString(objEntrevista.Legajo.Cuit);
                    pkrCita.Text = Fecha.ConvertirFechaHora(objEntrevista.Cita);
                    cmbModalidad.Text = objEntrevista.Modalidad;
                    txtPropuesta.Text = objEntrevista.Propuesta;
                    txtAnalisis.Text = objEntrevista.Analisis;
                    cmbDisponibilidad.Text = objEntrevista.Disponibilidad;
                    cmbCalificacion.Text = objEntrevista.Calificacion;
                    txtEstado.Text = objEntrevista.Estado;
                    labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objEntrevista.EdicionFecha) + " por " + objEntrevista.EdicionUsuarioDenominacion;
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
                cmbFiltroLista2.Text = "FILTRAR POR CUIT"; //Paso 1c: Selecciona la busqueda por CUIT        
                txtFiltroLista.Text = Convert.ToString(objLegajo.Cuit); //Paso 2: Establece el CUIT recibido
                filtrarCatalogo(0); //Paso 3: Carga el catálogo
                lstCatalogo.ClearSelected(); //Paso 4: Quita la selección de la fila
                btnNuevo.PerformClick(); //Paso 5: Ejecuta automáticamente el botón "Nuevo"
                this.objLegajo = objLegajo; //Paso 6: Iguala el Atributo de la clase con el Objeto recibido
                this.objLegajoCurriculumVitae = nLegajoCurriculumVitae.obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id));
                txtDenominacion.Text = objLegajo.Denominacion;
                txtCuit.Text = Convert.ToString(objLegajo.Cuit);
                cmbDisponibilidad.Text = (objLegajoCurriculumVitae != null) ? objLegajoCurriculumVitae.CurriculumVitaeDisponibilidad : "S/D";
            }
            else
            {
                objEntrevistaDB = nEntrevista.obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)); //Paso 1: Busca el registro en la Base de Datos en relación al objeto maestro recibido 
                if (objEntrevistaDB != null)
                {
                    lstCatalogo.SelectedValue = objEntrevistaDB.Id; //Paso 2: Posiona la selección de la fila en el registro guardado
                    escribirControles(objEntrevistaDB); //Paso 3: Escribe los datos del registro indicado
                }
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objEntrevista = new Entrevista(
                (objEntrevista.Id <= 0) ? 0 : objEntrevista.Id,
                objLegajo,
                pkrCita.Value,
                ((pkrCita.Value.AddDays(Global.Alerta_Entrevista) >= fechaActual.AddDays(Global.Alerta_Entrevista)) ? false : true),
                cmbModalidad.Text,
                txtPropuesta.Text,
                txtAnalisis.Text,
                cmbDisponibilidad.Text,
                cmbCalificacion.Text,
                txtEstado.Text,
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objLegajo = new Legajo(); //Restaura el Objeto Primario
            objEntrevista = new Entrevista(); //Importante: Restaura el Objeto del Móludo
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            pkrCita.Value = fechaActual;
            cmbModalidad.Text = "PRESENCIAL";
            txtPropuesta.Text = "";
            txtAnalisis.Text = "";
            cmbDisponibilidad.Text = "S/D";
            cmbCalificacion.Text = "S/CALIFICACION";
            txtEstado.Text = "S/REALIZAR";
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, txtCuit }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(Entrevista objRegistro) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objEntrevistaDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            escribirControles(objEntrevistaDB); //Escribe los datos del registro seleccionado
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
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA DE CITA")
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
            else if(cmbFiltroLista1.Text == "FILTRAR POR ESTADO: REALIZADO") filtroEstado = "REALIZADO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: S/REALIZAR") filtroEstado = "S/REALIZAR";

            if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de CUIL/CUIT
            {
                consultaEntrevista = new string[] { filtroEstado, "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nEntrevista.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la denominacón
            {
                consultaEntrevista = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nEntrevista.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA DE CITA") //Verifica que el tipo de filtro es por el numero de documento
            {
                consultaEntrevista = new string[] { filtroEstado, "CITA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nEntrevista.obtenerCatalago(filtroEstado, "CITA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objEntrevistaDB = nEntrevista.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objEntrevistaDB); //Escribe los datos del registro seleccionado
        }

        protected override void navegarA_Formulario(string destino) { NavegacionRRHH.navegarA_Formulario(destino, this, objLegajo); }

        protected override void reportarRegistro(string programa)
        {
            if (objEntrevista.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "N° Legajo: ",
                    "Denominación: ",
                    "CUIL/CUIT: ",
                    "Cita (fecha y hora): ",
                    "Modalidad de entrevista: ",
                    "Propuesta laboral: ",
                    "Análisis de la entrevista: ",
                    "Disponibilidad: ",
                    "Calificación: ",
                    "Estado: " };
                string[] datoDB = {
                    objEntrevista.Legajo.Id.ToString().PadLeft(8, '0'),
                    objEntrevista.Legajo.Denominacion,
                    objEntrevista.Legajo.Cuit.ToString("00-00000000/0"),
                    Fecha.ConvertirFechaHora(objEntrevista.Cita),
                    objEntrevista.Modalidad,
                    objEntrevista.Propuesta,
                    objEntrevista.Analisis,
                    objEntrevista.Disponibilidad,
                    objEntrevista.Calificacion,
                    objEntrevista.Estado };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Entrevista de Trabajo", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Entrevista de Trabajo", subTitulo, datoDB);
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
                lista = nEntrevista.obtenerCatalago(consultaEntrevista[0], consultaEntrevista[1], consultaEntrevista[2], "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Denominación",
                    "CUIL/CUIT",
                    "Celular(es)",
                    "Cita",
                    "Disponibilidad",
                    "Calificación",
                    "Estado" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //ID
                    campo[1].Trim(), //Denominación
                    campo[2].Trim(), //CUIL/CUIT
                    campo[3].Trim(), //Celular 1 y 2
                    campo[4].Trim(), //Cita (Fecha y Hora)
                    campo[5].Trim(), //Disponibilidad
                    campo[6].Trim(), //Calificación
                    campo[7].Trim() }; //Estado
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Entrevistas de Trabajo", subTitulos, new int[] { 8, 35, 13, 28, 16, 5, 14, 10 }, _listaDelReporte, new List<int> { 4 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Entrevistas de Trabajo", subTitulos, new float[] { 7, 31, 11, 23, 13, 5, 12, 9 }, _listaDelReporte); //Ancho: 111
            }
        }

        public override void asignarVariablesDeFormulario(string[] variablesDeFormulario)
        {
            if (variablesDeFormulario[0] == "Catalogo_Legajo") //Catálogo de Legajos
            {
                this.objLegajo = new N_Legajo().obtenerObjeto("ID", variablesDeFormulario[1], true);
                txtDenominacion.Text = objLegajo.Denominacion;
                txtCuit.Text = Convert.ToString(objLegajo.Cuit);
                this.objLegajoCurriculumVitae = nLegajoCurriculumVitae.obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id));
                cmbDisponibilidad.Text = (objLegajoCurriculumVitae != null) ? objLegajoCurriculumVitae.CurriculumVitaeDisponibilidad : "S/D";
            }
        }
        #endregion
    }
}