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
    public partial class FormLegajoLaboral : Biblioteca.Formularios.FormBaseABM_RRHH
    {
        #region Atributos
        private string[] consultaLegajoLaboral;
        private Legajo objLegajo; //Objeto Maestro
        private LegajoLaboral objLegajoLaboral;
        private LegajoLaboral objLegajoLaboralDB;
        private N_LegajoLaboral nLegajoLaboral = new N_LegajoLaboral();
        #endregion

        #region Constructores
        public FormLegajoLaboral()
        {
            InitializeComponent();
        }
        public FormLegajoLaboral(Legajo navLegajo) //Utilizado por el navegador de formularios
        {
            objLegajo = navLegajo;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormLegajoLaboral_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO",
                "FILTRAR POR ESTADO: EN PROCESO", "FILTRAR POR ESTADO: INACTIVO", "TODOS LOS ESTADOS" }, 3); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT", "FILTRAR POR DENOMINACION",
                "FILTRAR POR F. DE EGRESO", "FILTRAR POR F. DE INGRESO" }, 1); //Establece los items del ComboBox
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

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            if (objLegajoLaboralDB != null) {
                Formulario.Visibilidad(((objLegajoLaboralDB.Estado == "INACTIVO") ? true : false), new Control[] { chkEstablecerEnProceso });
            }
        }

        private void chkEstablecerEnProceso_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = (chkEstablecerEnProceso.Checked) ? "EN PROCESO" : "INACTIVO";
            txtFechaIngreso.Text = (chkEstablecerEnProceso.Checked) ? "" : Fecha.ConvertirFecha(objLegajoLaboralDB.FechaIngreso);
            txtFechaEgreso.Text = (chkEstablecerEnProceso.Checked) ? "" : Fecha.ConvertirFecha(objLegajoLaboralDB.FechaEgreso);
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(121))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objLegajoLaboral != null)
            {
                if (objLegajoLaboral.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(121)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            objLegajoLaboral.Id = nLegajoLaboral.generarNumeroID(); //Paso 2: Genera un ID para cada Objeto
                            if (nLegajoLaboral.insertar(objLegajoLaboral)) //Paso 3: Inserta el objeto principal
                            {
                                mostrarRegistro(objLegajoLaboral);
                                Mensaje.RegistroCorrecto("REGISTRACION");
                            }
                        }
                    }
                }
                else if (objLegajoLaboral.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(122)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (ValidarCampoVacio())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            if (!objLegajoLaboral.Equals(objLegajoLaboralDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                            {
                                if (nLegajoLaboral.actualizar(objLegajoLaboral))
                                {
                                    mostrarRegistro(objLegajoLaboral);
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
            if (objLegajoLaboral.Id > 0) escribirControles(objLegajoLaboralDB); //Restaura los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnLegajoLaboralDDJJ_Click(object sender, EventArgs e)
        {
            if (objLegajoLaboral.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string DDJJ = "";
                if (cmbLegajoLaboralDDJJ.Text == "GENERAR DDJJ ANSES") DDJJ = "ANSES";
                else if (cmbLegajoLaboralDDJJ.Text == "GENERAR DDJJ DESEMPLEO") DDJJ = "DESEMPLEO";
                else if (cmbLegajoLaboralDDJJ.Text == "GENERAR DDJJ DOMICILIO") DDJJ = "DOMICILIO";
                else if (cmbLegajoLaboralDDJJ.Text == "GENERAR DDJJ OBRA SOCIAL") DDJJ = "OBRA SOCIAL";
                else if (cmbLegajoLaboralDDJJ.Text == "GENERAR DDJJ PERSONAL") DDJJ = "PERSONAL";
                else if (cmbLegajoLaboralDDJJ.Text == "GENERAR DDJJ SEGURO") DDJJ = "SEGURO";
                else if (cmbLegajoLaboralDDJJ.Text == "GENERAR NOTIFICACION ART") DDJJ = "ART";
                // ---------- Genera el vector de datos en relación al item seleccionado ---------- // 
                string[] datoDB = {
                        objLegajoLaboral.Legajo.Denominacion,
                        Convert.ToString(objLegajoLaboral.Legajo.Id).PadLeft(8, '0'),
                        Formulario.enmascararDNI(Convert.ToString(objLegajoLaboral.Legajo.Documento)),
                        objLegajoLaboral.Legajo.Cuit.ToString("00-00000000/0"),
                        objLegajoLaboral.Sector };
                if (DDJJ == "DOMICILIO")
                {
                    datoDB = new string[]{
                        objLegajoLaboral.Legajo.Denominacion,
                        Convert.ToString(objLegajoLaboral.Legajo.Id).PadLeft(8, '0'),
                        Formulario.enmascararDNI(Convert.ToString(objLegajoLaboral.Legajo.Documento)),
                        objLegajoLaboral.Legajo.Cuit.ToString("00-00000000/0"),
                        objLegajoLaboral.CentroCosto.Denominacion,
                        objLegajoLaboral.Legajo.Domicilio,
                        objLegajoLaboral.Legajo.Provincia,
                        objLegajoLaboral.Legajo.Distrito,
                        Convert.ToString(objLegajoLaboral.Legajo.Cp) };
                }
                else if (DDJJ == "OBRA SOCIAL")
                {
                    datoDB = new string[]{
                        objLegajoLaboral.Legajo.Denominacion,
                        Convert.ToString(objLegajoLaboral.Legajo.Id).PadLeft(8, '0'),
                        Formulario.enmascararDNI(Convert.ToString(objLegajoLaboral.Legajo.Documento)),
                        objLegajoLaboral.Legajo.Cuit.ToString("00-00000000/0"),
                        objLegajoLaboral.Sector,
                        objLegajoLaboral.ObraSocial.Denominacion,
                        objLegajoLaboral.ObraSocial.Codigo };
                }
                else if (DDJJ == "PERSONAL")
                {
                    LegajoCurriculumVitae objCurriculumVitae = new N_LegajoCurriculumVitae().obtenerObjeto("ID_LEGAJO", objLegajo.Id.ToString());
                    CursoInduccion objCursoInduccion = new N_CursoInduccion().obtenerObjeto("ID_LEGAJO_RECIENTE", objLegajo.Id.ToString());
                    ExamenMedico objExamenMedico = new N_ExamenMedico().obtenerObjeto("ID_LEGAJO_RECIENTE", objLegajo.Id.ToString());
                    LegajoTalle objLegajoTalle = new N_LegajoTalle().obtenerObjeto("ID_LEGAJO", objLegajo.Id.ToString());
                    datoDB = new string[]{
                        objLegajoLaboral.Legajo.Denominacion,
                        Convert.ToString(objLegajoLaboral.Legajo.Id).PadLeft(8, '0'),
                        Formulario.enmascararDNI(Convert.ToString(objLegajoLaboral.Legajo.Documento)),
                        objLegajoLaboral.Legajo.Cuit.ToString("00-00000000/0"),
                        objLegajoLaboral.Sector,
                        Fecha.ConvertirFecha(objLegajoLaboral.Legajo.FechaNacimiento),
                        objLegajoLaboral.Legajo.Nacionalidad,
                        objLegajoLaboral.Legajo.EstadoCivil,
                        objLegajoLaboral.Legajo.Domicilio,
                        objLegajoLaboral.Legajo.Provincia,
                        objLegajoLaboral.Legajo.Distrito,
                        Convert.ToString(objLegajoLaboral.Legajo.Cp),
                        objLegajoLaboral.Legajo.Celular1 + "  " + objLegajoLaboral.Legajo.Celular2,
                        objLegajoLaboral.Sindicato.Convenio + "  -  " + objLegajoLaboral.Sindicato.Denominacion,
                        objLegajoLaboral.ObraSocial.Codigo + "  -  " +  objLegajoLaboral.ObraSocial.Denominacion,
                        objLegajoLaboral.CategoriaTrabajo.Denominacion,
                        objLegajoLaboral.Puesto,
                        ((objCurriculumVitae != null && objCurriculumVitae.LicenciaConducir) ? "CATEGORIA: " + objCurriculumVitae.LicenciaConducirCategoria + " -  VTO. " +
                            Fecha.ConvertirFecha(objCurriculumVitae.LicenciaConducirVto) + ((objCurriculumVitae.LicenciaConducirVto < DateTime.Now) ? "  (LICENCIA CADUCADA)" : "") : "NO TIENE LICENCIA DE CONDUCIR"),
                        ((objCurriculumVitae != null) ? objCurriculumVitae.NivelEstudio : "S/D"),
                        ((objLegajoLaboral.AfiliadoSindical) ? objLegajoLaboral.Sindicato.Denominacion : ""),
                        ((objCurriculumVitae != null && objCurriculumVitae.Legajo != null) ? objCurriculumVitae.Legajo.TipoSangre : "S/D"),
                        ((objLegajoTalle != null) ? objLegajoTalle.TalleCamisa : "S/D"),
                        ((objLegajoTalle != null) ? objLegajoTalle.TallePantalon : "S/D"),
                        ((objLegajoTalle != null) ? objLegajoTalle.TalleCalzado : "S/D"),
                        ((objCursoInduccion != null) ? objCursoInduccion.Evaluacion + " \n" + objCursoInduccion.Estado : "NO TIENE"),
                        ((objCursoInduccion != null) ? Fecha.ConvertirFecha(objCursoInduccion.FechaEmision.AddMonths(Global.Vigencia_CursoInduccion)) : "- - -"),
                        ((objExamenMedico != null) ? objExamenMedico.EvaluacionMedica + " \n" + objLegajoLaboral.Estado : "NO TIENE"),
                        ((objExamenMedico != null) ? Fecha.ConvertirFecha(objExamenMedico.ExamenEmision.AddMonths(Global.Vigencia_ExamenMedico)) : "- - -"),
                        ((objCurriculumVitae != null && objCurriculumVitae.CertificadoAntecedente) ? (objCurriculumVitae.CertificadoAntecedenteEmision.AddMonths(Global.Vigencia_Antecedentes) < DateTime.Now) ? "CADUCADO" : "VIGENTE" : "NO TIENE"),
                        ((objCurriculumVitae != null && objCurriculumVitae.CertificadoAntecedente) ? Fecha.ConvertirFecha(objCurriculumVitae.CertificadoAntecedenteEmision.AddMonths(Global.Vigencia_Antecedentes)) : "- - -"),
                        ((objLegajoTalle != null) ? objLegajoTalle.TalleCalzado : "S/D"),
                    };
                }
                Reporte reporte = new Reporte();
                reporte.crearDocumentoWord_LegajoLaboralDDJJ(objLegajoLaboral.Legajo.Denominacion, datoDB, DDJJ);
                Cursor.Current = Cursors.Default;
            }
            else Mensaje.Advertencia("Operación incorrecta.\nSeleccione un registro en la pantalla e intente nuevamente.");
        }
        #endregion

        #region Métodos
        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(LegajoLaboral objLegajoLaboral)
        {
            this.objLegajoLaboral = objLegajoLaboral; //Iguala el Atributo de la clase con el Objeto recibido
            if (objLegajoLaboral != null && objLegajoLaboral.Legajo != null)
            {
                if (!objLegajoLaboral.Legajo.InformacionRestringida || (objLegajoLaboral.Legajo.InformacionRestringida && Global.UsuarioActivo_Privilegios.Contains(1))) //Verifica que el usuario posea el privilegio requerido
                {
                    _controladorDeNuevoRegistro = false;
                    objLegajoLaboral.Id = (objLegajoLaboral != null) ? objLegajoLaboral.Id : 0;
                    objLegajo = objLegajoLaboral.Legajo;
                    txtCentroCosto.Text = (objLegajoLaboral.CentroCosto != null) ? objLegajoLaboral.CentroCosto.Denominacion : "";
                    txtDenominacion.Text = objLegajoLaboral.Legajo.Denominacion;
                    txtCuit.Text = Convert.ToString(objLegajoLaboral.Legajo.Cuit);
                    txtFechaIngreso.Text = ((objLegajoLaboral.Estado != "EN PROCESO") ? Fecha.ConvertirFecha(objLegajoLaboral.FechaIngreso) : "");
                    txtFechaEgreso.Text = ((objLegajoLaboral.Estado == "INACTIVO") ? Fecha.ConvertirFecha(objLegajoLaboral.FechaEgreso) : "");
                    txtAntiguedad.Text = Fecha.CalcularAntiguedadLaboral(txtFechaIngreso.Text, txtFechaEgreso.Text, objLegajoLaboral.Estado);
                    txtModalidadContratacion.Text = objLegajoLaboral.ModalidadContratacion;
                    txtModalidadContratacionTiempo.Text = objLegajoLaboral.ModalidadContratacionTiempo;
                    txtSindicato.Text = (objLegajoLaboral.CategoriaTrabajo != null) ? objLegajoLaboral.Sindicato.Denominacion : "";
                    chkAfiliadoSindical.Checked = objLegajoLaboral.AfiliadoSindical;
                    txtCategoria.Text = (objLegajoLaboral.CategoriaTrabajo != null) ? objLegajoLaboral.CategoriaTrabajo.Denominacion : "";
                    txtPuesto.Text = objLegajoLaboral.Puesto;
                    txtSector.Text = objLegajoLaboral.Sector;
                    txtModalidadLiquidacion.Text = objLegajoLaboral.ModalidadLiquidacion;
                    txtRemuneracion.Text = Formulario.ValidarCampoMoneda(objLegajoLaboral.Remuneracion);
                    txtObraSocial.Text = (objLegajoLaboral.ObraSocial != null) ? objLegajoLaboral.ObraSocial.Codigo + " " + objLegajoLaboral.ObraSocial.Denominacion : "";
                    txtObservacion.Text = objLegajoLaboral.Observacion;
                    txtEstado.Text = objLegajoLaboral.Estado;
                    labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objLegajoLaboral.EdicionFecha) + " por " + objLegajoLaboral.EdicionUsuarioDenominacion;
                }
                else restaurarControles();
            }
        }

        private void instanciarDesdeNavegacion(Legajo objLegajo)
        {
            objLegajoLaboralDB = nLegajoLaboral.obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)); //Paso 1: Busca el registro en la Base de Datos en relación al objeto maestro recibido 
            if (objLegajoLaboralDB != null)
            {
                lstCatalogo.SelectedValue = objLegajoLaboralDB.Id; //Posiona la selección de la fila en el registro guardado
                escribirControles(objLegajoLaboralDB); //Paso 2a: Escribe los datos del registro indicado
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
            this.objLegajoLaboral = new LegajoLaboral(
                (objLegajoLaboral.Id <= 0) ? 0 : objLegajoLaboral.Id,
                objLegajo,
                ((string.IsNullOrWhiteSpace(txtCentroCosto.Text)) ? new CentroCosto() : new N_CentroCosto().obtenerObjeto("DENOMINACION", txtCentroCosto.Text)),
                Fecha.ValidarFecha((txtEstado.Text != "EN PROCESO") ? txtFechaIngreso.Text : "01/01/9950"),
                Fecha.ValidarFecha((txtEstado.Text == "INACTIVO") ? txtFechaEgreso.Text : "01/01/9950"),
                txtModalidadContratacion.Text,
                txtModalidadContratacionTiempo.Text,
                ((string.IsNullOrWhiteSpace(txtSindicato.Text)) ? new Sindicato() : new N_Sindicato().obtenerObjeto("DENOMINACION", txtSindicato.Text)),
                Convert.ToBoolean(chkAfiliadoSindical.Checked),
                ((string.IsNullOrWhiteSpace(txtCategoria.Text)) ? new CategoriaTrabajo() : new N_CategoriaTrabajo().obtenerObjeto("DENOMINACION", txtCategoria.Text)),
                txtPuesto.Text,
                txtSector.Text,
                txtModalidadLiquidacion.Text,
                Formulario.ValidarNumeroDoble(txtRemuneracion.Text),
                ((string.IsNullOrWhiteSpace(txtObraSocial.Text)) ? new ObraSocial() : new N_ObraSocial().obtenerObjeto("CODIGO", txtObraSocial.Text.Substring(0, 6))),
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
            objLegajoLaboral = new LegajoLaboral(); //Importante: Restaura el Objeto del Móludo
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            objLegajoLaboral.Id = 0; //Libera el Id del Objeto seleccionado
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            txtCentroCosto.Text = "";
            txtFechaIngreso.Text = "";
            txtFechaEgreso.Text = "";
            txtAntiguedad.Text = "";
            txtModalidadContratacion.Text = "S/D";
            txtModalidadContratacionTiempo.Text = "S/D";
            txtSindicato.Text = "";
            chkAfiliadoSindical.Checked = false;
            txtCategoria.Text = "";
            txtModalidadLiquidacion.Text = "S/D";
            txtPuesto.Text = "S/D";
            txtSector.Text = "";
            txtRemuneracion.Text = "0,00";
            txtObraSocial.Text = "";
            txtObservacion.Text = "";
            txtEstado.Text = "EN PROCESO";
            labelPublicacion.Text = "";          
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion , txtCuit }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(LegajoLaboral objLegajoLaboral) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objLegajoLaboral.Id; //Posiona la selección de la fila en el registro guardado
            escribirControles(objLegajoLaboral); //Escribe los datos del registro seleccionado
            objLegajoLaboralDB = objLegajoLaboral; //Importante: Se debe actualizar el Objeto precedente con el actual (evita el error de nulidad) 
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
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR F. DE EGRESO" || cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR F. DE INGRESO")
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
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: EN PROCESO") filtroEstado = "EN PROCESO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: INACTIVO") filtroEstado = "INACTIVO";
            if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de CUIL/CUIT
            {
                consultaLegajoLaboral = new string[] { filtroEstado, "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nLegajoLaboral.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la denominacón
            {
                consultaLegajoLaboral = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nLegajoLaboral.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR F. DE EGRESO") //Verifica que el tipo de filtro es por el numero de documento
            {
                consultaLegajoLaboral = new string[] { filtroEstado, "EGRESO", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nLegajoLaboral.obtenerCatalago(filtroEstado, "EGRESO", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR F. DE INGRESO") //Verifica que el tipo de filtro es por el numero de documento
            {
                consultaLegajoLaboral = new string[] { filtroEstado, "INGRESO", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nLegajoLaboral.obtenerCatalago(filtroEstado, "INGRESO", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objLegajoLaboralDB = nLegajoLaboral.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objLegajoLaboralDB); //Escribe los datos del registro seleccionado
        }

        protected override void navegarA_Formulario(string destino) { NavegacionRRHH.navegarA_Formulario(destino, this, objLegajo); }

        protected override void reportarRegistro(string programa)
        {
            if (objLegajoLaboral.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "N° Legajo: ",
                    "Denominación: ",
                    "CUIL/CUIT: ",
                    "Centro de costo: ",
                    "Fecha de ingreso: ",
                    "Fecha de egreso: ",
                    "Antiguedad: ",
                    "Modalidad de contratación: ",
                    "Sindicato: ",
                    "Afiliado al sindicato: ",
                    "Categoría: ",
                    "Puesto: ",
                    "Sector: ",
                    "Modalidad de liquidación: ",
                    "Remuneración: ",
                    "Obra social: ",
                    "Observaciones: ",
                    "Estado: " };
                string[] datoDB = {
                    objLegajoLaboral.Legajo.Id.ToString().PadLeft(8, '0'),
                    objLegajoLaboral.Legajo.Denominacion,
                    objLegajoLaboral.Legajo.Cuit.ToString("00-00000000/0"),
                    objLegajoLaboral.CentroCosto.Denominacion,
                    ((Fecha.ConvertirFecha(objLegajoLaboral.FechaIngreso) == "01/01/9950")) ? "" : Fecha.ConvertirFecha(objLegajoLaboral.FechaIngreso),
                    ((Fecha.ConvertirFecha(objLegajoLaboral.FechaEgreso) == "01/01/9950")) ? "" : Fecha.ConvertirFecha(objLegajoLaboral.FechaEgreso),
                    txtAntiguedad.Text,
                    objLegajoLaboral.ModalidadContratacion + " (" + objLegajoLaboral.ModalidadContratacionTiempo + ")",
                    objLegajoLaboral.Sindicato.Denominacion,
                    ((objLegajoLaboral.AfiliadoSindical) ? "Si" : "No"),
                    objLegajoLaboral.CategoriaTrabajo.Denominacion,
                    objLegajoLaboral.Puesto,
                    objLegajoLaboral.Sector,
                    objLegajoLaboral.ModalidadLiquidacion,
                    "$" + Formulario.ValidarCampoMoneda(objLegajoLaboral.Remuneracion),
                    objLegajoLaboral.ObraSocial.Codigo + " " + objLegajoLaboral.ObraSocial.Denominacion,
                    objLegajoLaboral.Observacion,
                    objLegajoLaboral.Estado };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Legajo - Laboral", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Legajo - Laboral", subTitulo, datoDB);
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
                lista = nLegajoLaboral.obtenerCatalago(consultaLegajoLaboral[0], consultaLegajoLaboral[1], consultaLegajoLaboral[2], "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Denominación",
                    "CUIL/CUIT",
                    "F. Ingreso",
                    "F. Egreso",
                    "Antiguedad",
                    "Sindicato",
                    "Estado" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //ID
                    campo[1].Trim(), //Denominación
                    campo[2].Trim(), //CUIL/CUIT
                    campo[3].Trim(), //Fecha de ingreso
                    campo[4].Trim(), //Fecha de egreso
                    campo[5].Trim(), //Antiguedad
                    campo[6].Trim(), //Sindicato
                    campo[7].Trim() }; //Estado
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Legajos - Datos Laborales", subTitulos, new int[] { 8, 42, 13, 10, 10, 11, 25, 10 }, _listaDelReporte, new List<int> { 3, 4 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Legajos - Datos Laborales", subTitulos, new float[] { 7, 34, 11, 9, 9, 10, 22, 9 }, _listaDelReporte); //Ancho: 111
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
