using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using CapaNegocio.Catalogo;
using CapaPresentacion.Catalogo;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormNovedadNomina : Biblioteca.Formularios.FormBaseABM_RRHH
    {
        #region Atributos
        private bool _nuevoRegitroDesdeNavegacion = false;
        private string[] consultaNovedadNomina;
        private Legajo objLegajo; //Objeto Primario
        private LegajoLaboral objLegajoLaboral; //Objeto Secundario
        private NovedadNomina objNovedadNomina; //Objeto del Módulo
        private NovedadNomina objNovedadNominaDB; //Objeto de la Base de Datos
        private N_Legajo nLegajo = new N_Legajo();
        private N_LegajoLaboral nLegajoLaboral = new N_LegajoLaboral();
        private N_NovedadNomina nNovedadNomina = new N_NovedadNomina();
        #endregion

        #region Constructores
        public FormNovedadNomina()
        {
            InitializeComponent();
        }
        public FormNovedadNomina(Legajo navLegajo, bool nuevoRegitroDesdeNavegacion = false) //Utilizado por el navegador de formularios
        {
            objLegajo = navLegajo;
            _nuevoRegitroDesdeNavegacion = nuevoRegitroDesdeNavegacion;
            InitializeComponent();
        }
        public FormNovedadNomina(NovedadNomina navNovedadNomina) //Utilizado por el navegador de formularios
        {
            objNovedadNominaDB = objNovedadNomina = navNovedadNomina;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormNovedadNomina_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(txtID, "Número de comprobante");
            toolTip.SetToolTip(pkrFechaEmision, "Fecha de comprobante");
            toolTip.SetToolTip(cmbPeriodo, "Periodo contable - Mes");
            toolTip.SetToolTip(txtPeriodo, "Periodo contable - Año");
            toolTip.SetToolTip(txtEstado, "Estado del comprobante");
            #endregion
            Formulario.ComboBox_CargarElementos(cmbNovedadTipo, new N_TipoNovedad().obtenerListaDeElementos(), 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ANULADO",
                "FILTRAR POR ESTADO: LIQUIDADO", "FILTRAR POR ESTADO: S/LIQUIDAR", "TODOS LOS ESTADOS" }, 2); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT",
                "FILTRAR POR DENOMINACION", "FILTRAR POR FECHA", "FILTRAR POR PERIODO" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
            if (objLegajo != null) instanciarDesdeNavegacion(objLegajo);
            if (objNovedadNominaDB != null && !_controladorDeNuevoRegistro) escribirControles(objNovedadNominaDB); //Escribe los datos solicitados mediante la navegación entre formularios
        }

        private void btnBuscarLegajo_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                FormCatalogo_Legajo frm = new FormCatalogo_Legajo(this);
                frm.ShowDialog(this);
            }
        }

        private void btnNovedadTipo_Click(object sender, EventArgs e)
        {
            FormCatalogo_TipoNovedadNomina frm = new FormCatalogo_TipoNovedadNomina(this);
            frm.ShowDialog(this);
        }

        private void txtUnidadMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtUnidadMonto.Text);
        }

        private void chkFechaInicializacion_CheckedChanged(object sender, EventArgs e)
        {
            Formulario.Visibilidad(chkFechaInicializacion.Checked, new Control[] { pkrFechaInicializacion });
        }

        private void chkFechaFinalizacion_CheckedChanged(object sender, EventArgs e)
        {
            Formulario.Visibilidad(chkFechaFinalizacion.Checked, new Control[] { pkrFechaFinalizacion });
        }

        private void chkCantidadHoras_CheckedChanged(object sender, EventArgs e)
        {
            Formulario.Visibilidad(chkCantidadHoras.Checked, new Control[] { txtUnidadHoras });
            txtUnidadHoras.Text = "";

        }

        private void chkCantidadDias_CheckedChanged(object sender, EventArgs e)
        {
            Formulario.Visibilidad(chkCantidadDias.Checked, new Control[] { txtUnidadDias });
            txtUnidadDias.Text = "";
        }

        private void chkMonto_CheckedChanged(object sender, EventArgs e)
        {
            Formulario.Visibilidad(chkMonto.Checked, new Control[] { txtUnidadMonto });
            txtUnidadMonto.Text = "0,00";
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(131))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objNovedadNomina != null)
            {
                if (objNovedadNomina.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(131)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)) != null) //Verifica que la persona tenga un Legajo Laboral
                    {
                        if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                this.objLegajo = nLegajo.obtenerObjeto("ID", objNovedadNomina.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                                objNovedadNomina.Id = nNovedadNomina.generarNumeroID(); //Paso 3: Genera un ID para cada Objeto
                                objNovedadNomina.Unidad_inicializacion = (chkFechaInicializacion.Checked) ? objNovedadNomina.Unidad_inicializacion : Fecha.ValidarFecha("01/01/9950"); //Asigna una fecha super alta para que No sea alcanzada por los motores de busqueda 
                                objNovedadNomina.Unidad_finalizacion = (chkFechaFinalizacion.Checked) ? objNovedadNomina.Unidad_finalizacion : Fecha.ValidarFecha("01/01/9950"); //Asigna una fecha super alta para que No sea alcanzada por los motores de busqueda 
                                if (nNovedadNomina.insertar(objNovedadNomina)) //Paso 4: Inserta el objeto principal
                                {
                                    mostrarRegistro(objNovedadNomina);
                                    Mensaje.RegistroCorrecto("REGISTRACION");
                                }
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación incorrecta.\nLa persona No posee un legajo laboral.\nVerifique los datos e intente nuevamente.");
                }
                else if (objNovedadNomina.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(133)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (objNovedadNominaDB.Estado == "S/LIQUIDAR") //Verifica que la novedad este sin liquidar
                    {
                        if (ValidarCampoVacio())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                this.objLegajo = nLegajo.obtenerObjeto("ID", objNovedadNomina.Legajo.Id.ToString(), false); //Paso 3: Importante: Re-Almacena el Objeto de la Base de Datos
                                objNovedadNomina.Unidad_inicializacion = (chkFechaInicializacion.Checked) ? objNovedadNomina.Unidad_inicializacion : Fecha.ValidarFecha("01/01/9950"); //Asigna una fecha super alta para que No sea alcanzada por los motores de busqueda 
                                objNovedadNomina.Unidad_finalizacion = (chkFechaFinalizacion.Checked) ? objNovedadNomina.Unidad_finalizacion : Fecha.ValidarFecha("01/01/9950"); //Asigna una fecha super alta para que No sea alcanzada por los motores de busqueda 
                                if (!objNovedadNomina.Equals(objNovedadNominaDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                                {
                                    if (nNovedadNomina.actualizar(objNovedadNomina))
                                    {
                                        mostrarRegistro(objNovedadNomina);
                                        Mensaje.RegistroCorrecto("MODIFICACION");
                                    }
                                }
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación incorrecta.\nLos registros liquidados o anulados No pueden ser modificados.");
                }
                else Mensaje.Restriccion();
                bool ValidarCampoVacio() // Método que valida los campos requeridos
                {
                    return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion, txtCuit, txtCentroCosto });
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objNovedadNomina.Id > 0) escribirControles(objNovedadNominaDB); //Restaura los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(132)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objNovedadNomina.Id > 0)
                {
                    if (objNovedadNomina.FechaEmision.AddDays(10) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea anular el registro ID: " + objNovedadNomina.Id.ToString() + "?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            objLegajo = nLegajo.obtenerObjeto("ID", objNovedadNomina.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                            if (nNovedadNomina.anular(objNovedadNomina)) //Paso 3: Verifica el exito de la actualización y muestra los datos actualizados
                            {
                                objNovedadNomina.Estado = "ANULADO"; //Paso 4: Importante: Establece el cambio de estado en el Objeto del Módulo 
                                mostrarRegistro(objNovedadNomina);
                                Mensaje.RegistroCorrecto("ANULACION");
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación Incorrecta. Los comprobantes que han superado los 10 días de su registración No pueden ser anulados.");
                }
            }
            else Mensaje.Restriccion();
        }

        private void btnWord_NovedadNomina_Click(object sender, EventArgs e)
        {
        }

        private void btnLiquidar_Click(object sender, EventArgs e)
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            if (txtLiquidacionMes.Value < fechaActual.Month && txtLiquidacionAnio.Value <= fechaActual.Year)
            {
                string periodo = Convert.ToString(txtLiquidacionMes.Value).PadLeft(2, '0') + "-" + Convert.ToString(txtLiquidacionAnio.Value).PadLeft(4, '0');
                if (nNovedadNomina.liquidar(periodo))
                {
                    cmbFiltroLista1.Enabled = true; //Paso 1: Re-Activa el filtro de estados
                    cmbFiltroLista1.Text = "FILTRAR POR ESTADO: LIQUIDADO"; //Paso 2: Selecciona el estado LIQUIDADO
                    cmbFiltroLista2.Text = "FILTRAR POR PERIODO"; //Paso 3: Selecciona la busqueda por PERIODO 
                    txtFiltroLista.Text = periodo; //Paso 4: Establece el periodo indicado
                    filtrarCatalogo(0); //Paso 5: Re-Carga el catálogo
                    lstCatalogo.ClearSelected(); //Paso 6: Quita la selección de la fila
                    btnExcel_Lista.PerformClick();
                }
            }
            else Mensaje.Advertencia("Operación incorrecta.\nÚnicamente se pueden liquidar periodos anteriores al actual\nVerifique los datos e intente nuevamente.");
        }
        #endregion

        #region Métodos
        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(NovedadNomina objRegistro)
        {
            this.objNovedadNomina = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            if (objNovedadNomina != null && objNovedadNomina.Legajo != null)
            {
                if (!objNovedadNomina.Legajo.InformacionRestringida || (objNovedadNomina.Legajo.InformacionRestringida && Global.UsuarioActivo_Privilegios.Contains(1))) //Verifica que el usuario posea el privilegio requerido
                {
                    _controladorDeNuevoRegistro = false;
                    DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
                    objLegajo = objNovedadNomina.Legajo;
                    objLegajoLaboral = new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id));
                    txtID.Text = Convert.ToString(objNovedadNomina.Id).PadLeft(8, '0');
                    pkrFechaEmision.Value = objNovedadNomina.FechaEmision;
                    string[] periodo = objNovedadNomina.Periodo.ToString().Split('-');
                    cmbPeriodo.Text = periodo[0];
                    txtPeriodo.Text = periodo[1];
                    txtEstado.Text = objNovedadNomina.Estado;
                    txtDenominacion.Text = objNovedadNomina.Legajo.Denominacion;
                    txtCuit.Text = Convert.ToString(objNovedadNomina.Legajo.Cuit);
                    txtCentroCosto.Text = (objNovedadNomina.CentroCosto != null) ? objNovedadNomina.CentroCosto.Denominacion : "";
                    cmbNovedadTipo.Text = objNovedadNomina.NovedadTipo;
                    chkFechaInicializacion.Checked = ((objNovedadNomina.Unidad_inicializacion != Fecha.ValidarFecha("01/01/9950")) ? true : false);
                    pkrFechaInicializacion.Value = ((objNovedadNomina.Unidad_inicializacion != Fecha.ValidarFecha("01/01/9950")) ? objNovedadNomina.Unidad_inicializacion : fechaActual);
                    chkFechaFinalizacion.Checked = ((objNovedadNomina.Unidad_finalizacion != Fecha.ValidarFecha("01/01/9950")) ? true : false);
                    pkrFechaFinalizacion.Value = ((objNovedadNomina.Unidad_finalizacion != Fecha.ValidarFecha("01/01/9950")) ? objNovedadNomina.Unidad_finalizacion : fechaActual);
                    chkCantidadHoras.Checked = ((objNovedadNomina.UnidadHoras > 0) ? true : false);
                    txtUnidadHoras.Text = Convert.ToString(objNovedadNomina.UnidadHoras);
                    chkCantidadDias.Checked = ((objNovedadNomina.UnidadDias > 0) ? true : false);
                    txtUnidadDias.Text = Convert.ToString(objNovedadNomina.UnidadDias);
                    chkMonto.Checked = ((objNovedadNomina.UnidadMonto > 0) ? true : false);
                    txtUnidadMonto.Text = Formulario.ValidarCampoMoneda(objNovedadNomina.UnidadMonto);
                    txtObservacion.Text = objNovedadNomina.Observacion;
                    labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objNovedadNomina.EdicionFecha) + " por " + objNovedadNomina.EdicionUsuarioDenominacion;
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
                txtDenominacion.Text = objLegajo.Denominacion;
                txtCuit.Text = Convert.ToString(objLegajo.Cuit);
                this.objLegajoLaboral = new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id));
                txtCentroCosto.Text = (objLegajoLaboral != null && objLegajoLaboral.CentroCosto != null) ? objLegajoLaboral.CentroCosto.Denominacion : "";
            }
            else
            {
                objNovedadNominaDB = nNovedadNomina.obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)); //Paso 1: Busca el registro en la Base de Datos en relación al objeto maestro recibido 
                if (objNovedadNominaDB != null)
                {
                    lstCatalogo.SelectedValue = objNovedadNominaDB.Id; //Paso 2: Posiona la selección de la fila en el registro guardado
                    escribirControles(objNovedadNominaDB); //Paso 3: Escribe los datos del registro indicado
                }
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objNovedadNomina = new NovedadNomina(
                (objNovedadNomina.Id <= 0) ? 0 : objNovedadNomina.Id,
                pkrFechaEmision.Value,
                cmbPeriodo.Text + "-" + txtPeriodo.Text,
                txtEstado.Text,
                objLegajo,
                new N_CentroCosto().obtenerObjeto("DENOMINACION", txtCentroCosto.Text),
                cmbNovedadTipo.Text,
                pkrFechaInicializacion.Value,
                pkrFechaFinalizacion.Value,
                Formulario.ValidarNumeroEntero(txtUnidadHoras.Text),
                Formulario.ValidarNumeroEntero(txtUnidadDias.Text),
                Formulario.ValidarNumeroDoble(txtUnidadMonto.Text),
                txtObservacion.Text,
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objLegajo = new Legajo(); //Restaura el Objeto Primario
            objLegajoLaboral = new LegajoLaboral(); //Restaura el Objeto SubPrimario
            objNovedadNomina = new NovedadNomina(); //Importante: Restaura el Objeto del Móludo
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(cmbNovedadTipo, new N_TipoNovedad().obtenerListaDeElementos(), 0); //Re-Establece los items del ComboBox
            txtID.Text = "";
            pkrFechaEmision.Value = fechaActual;
            cmbPeriodo.Text = fechaActual.Month.ToString().PadLeft(2, '0');
            txtPeriodo.Text = fechaActual.Year.ToString();
            txtEstado.Text = "S/LIQUIDAR";
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            txtCentroCosto.Text = "";
            cmbNovedadTipo.SelectedIndex = 0;
            pkrFechaInicializacion.Value = fechaActual;
            pkrFechaFinalizacion.Value = fechaActual;
            chkFechaInicializacion.Checked = false;
            chkFechaFinalizacion.Checked = false;
            chkCantidadHoras.Checked = false;
            chkCantidadDias.Checked = false;
            chkMonto.Checked = false;
            txtObservacion.Text = "";
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, txtCuit, txtCentroCosto }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(NovedadNomina objRegistro) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objNovedadNominaDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            escribirControles(objNovedadNominaDB); //Escribe los datos del registro seleccionado
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
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION" || cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR PERIODO")
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
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: LIQUIDADO") filtroEstado = "LIQUIDADO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: S/LIQUIDAR") filtroEstado = "S/LIQUIDAR";
            if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de CUIL/CUIT
            {
                consultaNovedadNomina = new string[] { filtroEstado, "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nNovedadNomina.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la denominacón
            {
                consultaNovedadNomina = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nNovedadNomina.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA") //Verifica que el tipo de filtro es por fecha de emisión
            {
                consultaNovedadNomina = new string[] { filtroEstado, "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nNovedadNomina.obtenerCatalago(filtroEstado, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR PERIODO") //Verifica que el tipo de filtro es por Periodo
            {
                consultaNovedadNomina = new string[] { filtroEstado, "PERIODO", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nNovedadNomina.obtenerCatalago(filtroEstado, "PERIODO", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objNovedadNominaDB = nNovedadNomina.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objNovedadNominaDB); //Escribe los datos del registro seleccionado
        }

        protected override void navegarA_Formulario(string destino) { NavegacionRRHH.navegarA_Formulario(destino, this, objLegajo); }

        protected override void reportarRegistro(string programa)
        {
            if (objNovedadNomina.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "N° Comprobante: ",
                    "Fecha de emisión: ",
                    "Periodo: ",
                    "Estado: ",
                    "Denominación: ",
                    "CUIL/CUIT: ",
                    "Centro de costo: ",
                    "Tipo de novedad: ",
                    "Observación: " };
                string[] datoDB = {
                    objNovedadNomina.Legajo.Id.ToString().PadLeft(8, '0'),
                    Fecha.ConvertirFecha(objNovedadNomina.FechaEmision),
                    objNovedadNomina.Periodo,
                    objNovedadNomina.Estado,
                    objNovedadNomina.Legajo.Denominacion,
                    objNovedadNomina.Legajo.Cuit.ToString("00-00000000/0"),
                    objNovedadNomina.CentroCosto.Denominacion,
                    objNovedadNomina.NovedadTipo +
                    ((Fecha.ConvertirFecha(objNovedadNomina.Unidad_inicializacion) != "01/01/9950") ? "\nFecha de inicialización: " + Fecha.ConvertirFechaHora(objNovedadNomina.Unidad_inicializacion) : "") +
                    ((Fecha.ConvertirFecha(objNovedadNomina.Unidad_finalizacion) != "01/01/9950") ? "\nFecha de finalización: " + Fecha.ConvertirFechaHora(objNovedadNomina.Unidad_finalizacion) : "") +
                    ((objNovedadNomina.UnidadHoras > 0) ? "\nHoras (cantidad): " + Convert.ToString(objNovedadNomina.UnidadHoras) : "") +
                    ((objNovedadNomina.UnidadDias > 0) ? "\nDías (cantidad): " + Convert.ToString(objNovedadNomina.UnidadDias) : "") +
                    ((objNovedadNomina.UnidadMonto > 0) ? "\nMonto: $" + Formulario.ValidarCampoMoneda(objNovedadNomina.UnidadMonto) : ""),
                    objNovedadNomina.Observacion };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Novedad de Nómina ", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Novedad de Nómina ", subTitulo, datoDB);
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
                lista = nNovedadNomina.obtenerCatalago(consultaNovedadNomina[0], consultaNovedadNomina[1], consultaNovedadNomina[2], "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Periodo",
                    "Estado",
                    "Tipo de Novedad",
                    "F. Ini.",
                    "F. Fin.",
                    "Horas",
                    "Días",
                    "Monto",
                    "Denominación - CUIL/CUIT" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //Periodo
                    campo[1].Trim(), //Estado
                    campo[2].Trim(), //Tipo de Novedad
                    campo[3].Trim(), //F. Ini.
                    campo[4].Trim(), //F. Fin.
                    campo[5].Trim(), //Horas
                    campo[6].Trim(), //Días
                    campo[7].Trim(), //Monto
                    campo[8] }; //Denominación - CUIL/CUIT
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                string tituloPeriodo = (cmbFiltroLista2.Text == "FILTRAR POR PERIODO") ? " (periodo " + txtFiltroLista.Text + ")": "";
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Novedades de Nómina " + tituloPeriodo, subTitulos, new int[] { 7, 10, 35, 10, 10, 5, 5, 10, 55 }, _listaDelReporte, new List<int> { 3, 4 }, 88); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Novedades de Nómina " + tituloPeriodo, subTitulos, new float[] { 6, 8, 29, 7, 7, 5, 5, 7, 39 }, _listaDelReporte); //Ancho: 111
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
                txtCentroCosto.Text = (objLegajoLaboral != null && objLegajoLaboral.CentroCosto != null) ? objLegajoLaboral.CentroCosto.Denominacion : "";
            }
            else if (variablesDeFormulario[0] == "Catalogo_TipoNovedad") //Catálogo de Tipos de Novedad de Nómina
            {
                Formulario.ComboBox_CargarElementos(cmbNovedadTipo, new N_TipoNovedad().obtenerListaDeElementos(), 0); //Establece los items del ComboBox
                cmbNovedadTipo.Text = variablesDeFormulario[2];
            }
        }
        #endregion
    }
}
