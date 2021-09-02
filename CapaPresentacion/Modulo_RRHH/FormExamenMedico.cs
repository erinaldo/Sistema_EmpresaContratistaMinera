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
    public partial class FormExamenMedico : Biblioteca.Formularios.FormBaseABM_RRHH
    {
        #region Atributos
        private bool _nuevoRegitroDesdeNavegacion = false;
        private string[] consultaExamenMedico;
        private Legajo objLegajo; //Objeto Primario
        private ExamenMedico objExamenMedico; //Objeto del Módulo
        private ExamenMedico objExamenMedicoDB; //Objeto de la Base de Datos
        private N_Legajo nLegajo = new N_Legajo();
        private N_ExamenMedico nExamenMedico = new N_ExamenMedico();
        #endregion

        #region Constructores
        public FormExamenMedico()
        {
            InitializeComponent();
        }
        public FormExamenMedico(Legajo navLegajo, bool nuevoRegitroDesdeNavegacion = false) //Utilizado por el navegador de formularios
        {
            objLegajo = navLegajo;
            _nuevoRegitroDesdeNavegacion = nuevoRegitroDesdeNavegacion;
            InitializeComponent();
        }
        public FormExamenMedico(ExamenMedico navExamenMedico) //Utilizado por el navegador de formularios
        {
            objExamenMedicoDB = objExamenMedico = navExamenMedico;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormExamenMedico_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ANULADO",
                "FILTRAR POR ESTADO: OBSOLETO", "FILTRAR POR ESTADO: VIGENTE", "TODOS LOS ESTADOS" }, 3); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT",
                "FILTRAR POR DENOMINACION", "FILTRAR POR FECHA" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
            if (objLegajo != null) instanciarDesdeNavegacion(objLegajo);
            if (objExamenMedicoDB != null && !_controladorDeNuevoRegistro) escribirControles(objExamenMedicoDB); //Escribe los datos solicitados mediante la navegación entre formularios
        }

        private void btnBuscarLegajo_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                FormCatalogo_Legajo frm = new FormCatalogo_Legajo(this);
                frm.ShowDialog(this);
            }
        }

        private void chkEvaluacionRespirador_CheckedChanged(object sender, EventArgs e)
        {
            Formulario.Visibilidad(chkEvaluacionRespirador.Checked, new Control[] { lblEvaluacionRespirador1,
                pkrEvaluacionRespiradorEmision, lblEvaluacionRespirador2, pkrEvaluacionRespiradorVto});
        }

        private void chkCaraCompleta_CheckedChanged(object sender, EventArgs e)
        {
            Formulario.Visibilidad(chkCaraCompleta.Checked, new Control[] { lblCaraCompleta1, pkrCaraCompletaEmision,
                lblCaraCompleta2, txtCaraCompletaMarca, lblCaraCompleta3, txtCaraCompletaModelo, lblCaraCompleta4,
                cmbCaraCompletaTamanio});
            txtCaraCompletaMarca.Text = "";
            txtCaraCompletaModelo.Text = "";
        }

        private void chkMediaCara_CheckedChanged(object sender, EventArgs e)
        {
            Formulario.Visibilidad(chkMediaCara.Checked, new Control[] { lblMediaCara1, pkrMediaCaraEmision,
                lblMediaCara2, txtMediaCaraMarca, lblMediaCara3, txtMediaCaraModelo, lblMediaCara4,
                cmbMediaCaraTamanio});
            txtMediaCaraMarca.Text = "";
            txtMediaCaraModelo.Text = "";
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(111))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objExamenMedico != null)
            {
                if (objExamenMedico.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(111)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            this.objLegajo = nLegajo.obtenerObjeto("ID", objExamenMedico.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                            objExamenMedico.Id = nExamenMedico.generarNumeroID(); //Paso 3: Genera un ID para cada Objeto
                            if (nExamenMedico.insertar(objExamenMedico)) //Paso 4: Inserta el objeto principal
                            {
                                mostrarRegistro(objExamenMedico);
                                Mensaje.RegistroCorrecto("REGISTRACION");
                            }
                        }
                    }
                }
                else if (objExamenMedico.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(113)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (ValidarCampoVacio())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            this.objLegajo = nLegajo.obtenerObjeto("ID", objExamenMedico.Legajo.Id.ToString(), false); //Paso 3: Importante: Re-Almacena el Objeto de la Base de Datos
                            if (!objExamenMedico.Equals(objExamenMedicoDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                            {
                                if (nExamenMedico.actualizar(objExamenMedico))
                                {
                                    mostrarRegistro(objExamenMedico);
                                    Mensaje.RegistroCorrecto("MODIFICACION");
                                }
                            }
                        }
                    }
                }
                else Mensaje.Restriccion();
                bool ValidarCampoVacio() // Método que valida los campos requeridos
                {
                    return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion, txtCuit, txtInstitucion,
                    cmbTipoExamen, cmbEvaluacionMedica });
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objExamenMedico.Id > 0) escribirControles(objExamenMedicoDB); //Restaura los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(112)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objExamenMedico.Id > 0)
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea anular el registro ID: " + objExamenMedico.Id.ToString() + "?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        objLegajo = nLegajo.obtenerObjeto("ID", objExamenMedico.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                        if (nExamenMedico.anular(objExamenMedico)) //Paso 3: Verifica el exito de la actualización y muestra los datos actualizados
                        {
                            objExamenMedico.Estado = "ANULADO"; //Paso 4: Importante: Establece el cambio de estado en el Objeto del Módulo 
                            mostrarRegistro(objExamenMedico);
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

        private void escribirControles(ExamenMedico objRegistro)
        {
            this.objExamenMedico = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            if (objExamenMedico != null && objExamenMedico.Legajo != null)
            {
                if (!objExamenMedico.Legajo.InformacionRestringida || (objExamenMedico.Legajo.InformacionRestringida && Global.UsuarioActivo_Privilegios.Contains(1))) //Verifica que el usuario posea el privilegio requerido
                {
                    _controladorDeNuevoRegistro = false;
                    DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
                    objLegajo = objExamenMedico.Legajo;
                    txtDenominacion.Text = objExamenMedico.Legajo.Denominacion;
                    txtCuit.Text = Convert.ToString(objExamenMedico.Legajo.Cuit);
                    txtInstitucion.Text = objExamenMedico.Institucion;
                    cmbTipoExamen.Text = objExamenMedico.TipoExamen;
                    pkrFechaExamen.Value = objExamenMedico.ExamenEmision;
                    chkEvaluacionRespirador.Checked = objExamenMedico.EvaluacionRespirador;
                    pkrEvaluacionRespiradorEmision.Value = objExamenMedico.EvaluacionRespiradorEmision;
                    pkrEvaluacionRespiradorVto.Value = objExamenMedico.EvaluacionRespiradorVto;
                    chkCaraCompleta.Checked = objExamenMedico.CaraCompleta;
                    pkrCaraCompletaEmision.Value = objExamenMedico.CaraCompletaPrueba;
                    txtCaraCompletaMarca.Text = objExamenMedico.CaraCompletaMarca;
                    txtCaraCompletaModelo.Text = objExamenMedico.CaraCompletaModelo;
                    cmbCaraCompletaTamanio.Text = objExamenMedico.CaraCompletaTamanio;
                    chkMediaCara.Checked = objExamenMedico.MediaCara;
                    pkrMediaCaraEmision.Value = objExamenMedico.MediaCaraPrueba;
                    txtMediaCaraMarca.Text = objExamenMedico.MediaCaraMarca;
                    txtMediaCaraModelo.Text = objExamenMedico.MediaCaraModelo;
                    cmbMediaCaraTamanio.Text = objExamenMedico.MediaCaraTamanio;
                    txtObservacion.Text = objExamenMedico.Observacion;
                    cmbEvaluacionMedica.Text = objExamenMedico.EvaluacionMedica;
                    txtEstado.Text = objExamenMedico.Estado;
                    labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objExamenMedico.EdicionFecha) + " por " + objExamenMedico.EdicionUsuarioDenominacion;
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
            }
            else
            {
                objExamenMedicoDB = nExamenMedico.obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)); //Paso 1: Busca el registro en la Base de Datos en relación al objeto maestro recibido 
                if (objExamenMedicoDB != null)
                {
                    lstCatalogo.SelectedValue = objExamenMedicoDB.Id; //Paso 2: Posiona la selección de la fila en el registro guardado
                    escribirControles(objExamenMedicoDB); //Paso 3: Escribe los datos del registro indicado
                }
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objExamenMedico = new ExamenMedico(
                (objExamenMedico.Id <= 0) ? 0 : objExamenMedico.Id,
                objLegajo,
                txtInstitucion.Text,
                cmbTipoExamen.Text,
                pkrFechaExamen.Value,
                ((pkrFechaExamen.Value.AddMonths(Global.Vigencia_ExamenMedico).AddDays(Global.Alerta_ExamenMedico) < fechaActual.AddDays(Global.Alerta_ExamenMedico)) ? true : false),
                chkEvaluacionRespirador.Checked,
                pkrEvaluacionRespiradorEmision.Value,
                pkrEvaluacionRespiradorVto.Value,
                chkCaraCompleta.Checked,
                pkrCaraCompletaEmision.Value,
                txtCaraCompletaMarca.Text,
                txtCaraCompletaModelo.Text,
                ((string.IsNullOrEmpty(cmbCaraCompletaTamanio.Text)) ? "M" : cmbCaraCompletaTamanio.Text), //Importante: Los ENUM en la BD nececitan recibir un dato conocido cuando el control esta oculto
                chkMediaCara.Checked,
                pkrMediaCaraEmision.Value,
                txtMediaCaraMarca.Text,
                txtMediaCaraModelo.Text,
                ((string.IsNullOrEmpty(cmbMediaCaraTamanio.Text)) ? "M" : cmbMediaCaraTamanio.Text), //Importante: Los ENUM en la BD nececitan recibir un dato conocido cuando el control esta oculto
                txtObservacion.Text,
                cmbEvaluacionMedica.Text,
                txtEstado.Text,
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objLegajo = new Legajo(); //Restaura el Objeto Primario
            objExamenMedico = new ExamenMedico(); //Importante: Restaura el Objeto del Móludo
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            txtInstitucion.Text = "";
            cmbTipoExamen.Text = "PERIODICO";
            pkrFechaExamen.Value = fechaActual;
            chkEvaluacionRespirador.Checked = false;
            pkrEvaluacionRespiradorEmision.Value = fechaActual;
            pkrEvaluacionRespiradorVto.Value = fechaActual;
            chkCaraCompleta.Checked = false;
            pkrCaraCompletaEmision.Value = fechaActual;
            txtCaraCompletaMarca.Text = "";
            txtCaraCompletaModelo.Text = "";
            cmbCaraCompletaTamanio.Text = "M";
            chkMediaCara.Checked = false;
            pkrMediaCaraEmision.Value = fechaActual;
            txtMediaCaraMarca.Text = "";
            txtMediaCaraModelo.Text = "";
            cmbMediaCaraTamanio.Text = "M";
            txtObservacion.Text = "";
            cmbEvaluacionMedica.Text = "APTO";
            txtEstado.Text = "VIGENTE";
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, txtCuit, txtInstitucion, cmbTipoExamen,
                cmbEvaluacionMedica }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(ExamenMedico objRegistro) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objExamenMedicoDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            escribirControles(objExamenMedicoDB); //Escribe los datos del registro seleccionado
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
                consultaExamenMedico = new string[] { filtroEstado, "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nExamenMedico.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la denominacón
            {
                consultaExamenMedico = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nExamenMedico.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA") //Verifica que el tipo de filtro es por fecha
            {
                consultaExamenMedico = new string[] { filtroEstado, "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nExamenMedico.obtenerCatalago(filtroEstado, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objExamenMedicoDB = nExamenMedico.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objExamenMedicoDB); //Escribe los datos del registro seleccionado
        }

        protected override void navegarA_Formulario(string destino) { NavegacionRRHH.navegarA_Formulario(destino, this, objLegajo); }

        protected override void reportarRegistro(string programa)
        {
            if (objExamenMedico.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "N° Legajo: ",
                    "Denominación: ",
                    "CUIL/CUIT: ",
                    "Tipo de examen: ",
                    "Institucion: ",
                    "Fecha del examen: ",
                    "Evaluación médica de respirador: ",
                    "Fit Test: Respirador de cara completa: ",
                    "Fit Test: Respirador de media cara: ",
                    "observaciones: ",
                    "Evaluación médica: ",
                    "Estado: " };
                string[] datoDB = {
                    objExamenMedico.Legajo.Id.ToString().PadLeft(8, '0'),
                    objExamenMedico.Legajo.Denominacion,
                    objExamenMedico.Legajo.Cuit.ToString("00-00000000/0"),
                    objExamenMedico.TipoExamen,
                    objExamenMedico.Institucion,
                    Fecha.ConvertirFecha(objExamenMedico.ExamenEmision),
                    ((objExamenMedico.EvaluacionRespirador) ? "Si" +
                    "\nFecha de emisión: " + Fecha.ConvertirFecha(objExamenMedico.EvaluacionRespiradorEmision) +
                    "\nFecha de vto.: " + Fecha.ConvertirFecha(objExamenMedico.EvaluacionRespiradorEmision) : "No"),
                    ((objExamenMedico.CaraCompleta) ? "Si" +
                    "\nFecha de prueba: " + Fecha.ConvertirFecha(objExamenMedico.CaraCompletaPrueba) +
                    "\nMarca: " + objExamenMedico.CaraCompletaMarca +
                    "\nModelo: " + objExamenMedico.CaraCompletaModelo +
                    "\nTamaño: " + objExamenMedico.CaraCompletaTamanio : "No"),
                    ((objExamenMedico.MediaCara) ? "Si" +
                    "\nFecha de prueba: " + Fecha.ConvertirFecha(objExamenMedico.MediaCaraPrueba) +
                    "\nMarca: " + objExamenMedico.MediaCaraMarca +
                    "\nModelo: " + objExamenMedico.MediaCaraModelo +
                    "\nTamaño: " + objExamenMedico.MediaCaraTamanio : "No"),
                    objExamenMedico.Observacion,
                    objExamenMedico.EvaluacionMedica,
                    objExamenMedico.Estado };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Examen Médico", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Examen Médico", subTitulo, datoDB);
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
                lista = nExamenMedico.obtenerCatalago(consultaExamenMedico[0], consultaExamenMedico[1], consultaExamenMedico[2], "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Denominación",
                    "CUIL/CUIT",
                    "Tipo de examen",
                    "F.Examen",
                    "Examen Vto.",
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
                    campo[3].Trim(), //Tipo de examen
                    campo[4].Trim(), //F. Examen
                    campo[5].Trim(), //Examen Vto.
                    campo[6].Trim(), //Evaluación
                    campo[7].Trim() }; //Estado
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Exámenes Médicos", subTitulos, new int[] { 8, 54, 13, 15, 11, 11, 9, 8 }, _listaDelReporte, new List<int> { 4, 5 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Exámenes Médicos", subTitulos, new float[] { 7, 48, 11, 13, 9, 9, 7, 7 }, _listaDelReporte); //Ancho: 111
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
