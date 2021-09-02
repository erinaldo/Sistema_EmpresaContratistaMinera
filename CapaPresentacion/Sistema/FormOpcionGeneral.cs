using System;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio.Sistema;
using Entidades.Sistema;

namespace CapaPresentacion
{ 
    public partial class FormOpcionGeneral : Biblioteca.Formularios.FormBase
    {
        #region Atributos
        private long _idOpcionGeneral = 1;
        private OpcionGeneral objOpcionGeneral;
        private N_OpcionGeneral nOpcionGeneral = new N_OpcionGeneral();
        #endregion

        public FormOpcionGeneral()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FormOpcionGeneral_Load(object sender, EventArgs e)
        {
            escribirControles(nOpcionGeneral.obtenerObjeto("ID", _idOpcionGeneral.ToString(), true)); //Escribe los datos del único registro existente
        }

        private void txtTPV_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoNumerico(e, txtTPV.Text);
        }

        private void txtTPV_Validated(object sender, EventArgs e)
        {
            txtTPV.Text = txtTPV.Text.PadLeft(5, '0');
        }

        private void txtLiquidacionSueldoAporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtLiquidacionSueldoAporte.Text);
        }

        private void txtLiquidacionSueldoART_Fijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtLiquidacionSueldoART_Fijo.Text);
        }

        private void txtLiquidacionSueldoART_Tasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtLiquidacionSueldoART_Tasa.Text);
        }

        private void txtLiquidacionSueldoTiempoCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtLiquidacionSueldoTiempoCompleto.Text);
        }

        private void txtLiquidacionSueldoTiempoParcial_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtLiquidacionSueldoTiempoParcial.Text);
        }

        private void txtLiquidacionSueldoSCVO_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtLiquidacionSueldoSCVO.Text);
        }

        private void txtEstadoResultado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtEstadoResultadoIIBB.Text);
        }

        private void txtEstadoResultadoSAC_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtEstadoResultadoSAC.Text);
        }

        private void txtEstadoResultadoGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtEstadoResultadoGanancia.Text);
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idOpcionGeneral > 0 && Global.UsuarioActivo_Privilegios.Contains(85)) //Verifica que el usuario posea el privilegio requerido
            {
                //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                if (ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        if (nOpcionGeneral.actualizar(objOpcionGeneral, true))
                        {
                            Global.cargarVariablesDeOpcionesGenerales(new N_OpcionGeneral().obtenerObjeto("ID", "1", true)); //Importante: Actualiza las variables globales
                        }
                        mostrarDatos();
                    }
                }
            }
            else Mensaje.Restriccion();
            bool ValidarCampoVacio() // Método que valida los campos requeridos
            {
                return Formulario.ValidarCampoVacio(false, new Control[] { txtVigenciaCertificadoAntecedente, 
                    txtVigenciaCurriculumVitae, txtVigenciaCursoInduccion, txtVigenciaCursoIzaje, txtVigenciaExamenMedico,
                    txtAlertaCertificadoAntecedente, txtAlertaCursoInduccion, txtAlertaCursoIzaje, txtAlertaEntrevistaTrabajo,
                    txtAlertaExamenMedico, txtAlertaLicenciaConducir, txtLiquidacionSueldoAporte, txtLiquidacionSueldoART_Fijo,
                    txtLiquidacionSueldoART_Tasa, txtLiquidacionSueldoTiempoCompleto, txtLiquidacionSueldoTiempoParcial,
                    txtLiquidacionSueldoSCVO, txtEstadoResultadoIIBB, txtEstadoResultadoSAC, txtEstadoResultadoGanancia });
            }
            void mostrarDatos() //Método que muestra en la pantalla los cambios generados
            {
                escribirControles(nOpcionGeneral.obtenerObjeto("ID", _idOpcionGeneral.ToString(), true)); //Importante: Por ultimo re-Escribe todos los controles para mayor seguridad                      }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idOpcionGeneral > 0) escribirControles(nOpcionGeneral.obtenerObjeto("ID", _idOpcionGeneral.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
        }

        private void btnExcel_Registro_Click(object sender, EventArgs e)
        {
            reportarRegistro("EXCEL");
        }

        private void btnPDF_Registro_Click(object sender, EventArgs e)
        {
            reportarRegistro("PDF");
        }
        #endregion

        #region Métodos
        private void escribirControles(OpcionGeneral objOpcionGeneral)
        {
            this.objOpcionGeneral = objOpcionGeneral; //Obtiene los datos del objeto recibido
            if (objOpcionGeneral != null)
            {
                _idOpcionGeneral = (objOpcionGeneral != null) ? objOpcionGeneral.Id : 0;
                txtTPV.Text = Convert.ToString(objOpcionGeneral.PtoVta).PadLeft(5, '0');
                txtAlertaCertificadoAntecedente.Text = Convert.ToString(objOpcionGeneral.AlertaAntecedentes);
                txtAlertaCursoInduccion.Text = Convert.ToString(objOpcionGeneral.AlertaCursoInduccion);
                txtAlertaCursoIzaje.Text = Convert.ToString(objOpcionGeneral.AlertaCursoIzaje);
                txtAlertaEntrevistaTrabajo.Text = Convert.ToString(objOpcionGeneral.AlertaEntrevista);
                txtAlertaExamenMedico.Text = Convert.ToString(objOpcionGeneral.AlertaExamenMedico);
                txtAlertaLicenciaConducir.Text = Convert.ToString(objOpcionGeneral.AlertaLicenciaConducir);
                txtVigenciaCertificadoAntecedente.Text = Convert.ToString(objOpcionGeneral.VigenciaAntecedentes);
                txtVigenciaCurriculumVitae.Text = Convert.ToString(objOpcionGeneral.VigenciaCurriculumVitae);
                txtVigenciaCursoInduccion.Text = Convert.ToString(objOpcionGeneral.VigenciaCursoInduccion);
                txtVigenciaCursoIzaje.Text = Convert.ToString(objOpcionGeneral.VigenciaCursoIzaje);
                txtVigenciaExamenMedico.Text = Convert.ToString(objOpcionGeneral.VigenciaExamenMedico);
                txtLiquidacionSueldoAporte.Text = Formulario.ValidarCampoMoneda(objOpcionGeneral.LiquidacionSueldo_AporteTasa);
                txtLiquidacionSueldoART_Fijo.Text = Formulario.ValidarCampoMoneda(objOpcionGeneral.LiquidacionSueldo_ArtFijo);
                txtLiquidacionSueldoART_Tasa.Text = Formulario.ValidarCampoMoneda(objOpcionGeneral.LiquidacionSueldo_ArtTasa);
                txtLiquidacionSueldoTiempoCompleto.Text = Formulario.ValidarCampoMoneda(objOpcionGeneral.LiquidacionSueldo_ContribTiempoCompletoTasa);
                txtLiquidacionSueldoTiempoParcial.Text = Formulario.ValidarCampoMoneda(objOpcionGeneral.LiquidacionSueldo_ContribTiempoParcialTasa);
                txtLiquidacionSueldoSCVO.Text = Formulario.ValidarCampoMoneda(objOpcionGeneral.LiquidacionSueldo_SCVO);
                txtEstadoResultadoIIBB.Text = Formulario.ValidarCampoMoneda(objOpcionGeneral.EstadoResultado_IIBBTasa);
                txtEstadoResultadoSAC.Text = Formulario.ValidarCampoMoneda(objOpcionGeneral.EstadoResultado_PrevisionSACDesempleoTasa);
                txtEstadoResultadoGanancia.Text = Formulario.ValidarCampoMoneda(objOpcionGeneral.EstadoResultado_PrevisionImpGananciaTasa);
                txtTiempoAnulacion.Text = Convert.ToString(objOpcionGeneral.RegistroAnulacion);
                txtTiempoModificacion.Text = Convert.ToString(objOpcionGeneral.RegistroModificion);
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objOpcionGeneral.EdicionFecha) + " por " + objOpcionGeneral.EdicionUsuarioDenominacion;
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objOpcionGeneral = new OpcionGeneral(
                (_idOpcionGeneral <= 0) ? 0 : _idOpcionGeneral,
                Formulario.ValidarNumeroEntero(txtTPV.Text),
                Formulario.ValidarNumeroEntero(txtAlertaCertificadoAntecedente.Text),
                Formulario.ValidarNumeroEntero(txtAlertaCursoInduccion.Text),
                Formulario.ValidarNumeroEntero(txtAlertaCursoIzaje.Text),
                Formulario.ValidarNumeroEntero(txtAlertaEntrevistaTrabajo.Text),
                Formulario.ValidarNumeroEntero(txtAlertaExamenMedico.Text),
                Formulario.ValidarNumeroEntero(txtAlertaLicenciaConducir.Text),
                Formulario.ValidarNumeroEntero(txtVigenciaCertificadoAntecedente.Text),
                Formulario.ValidarNumeroEntero(txtVigenciaCurriculumVitae.Text),
                Formulario.ValidarNumeroEntero(txtVigenciaCursoInduccion.Text),
                Formulario.ValidarNumeroEntero(txtVigenciaCursoIzaje.Text),
                Formulario.ValidarNumeroEntero(txtVigenciaExamenMedico.Text),
                Formulario.ValidarNumeroDoble(txtLiquidacionSueldoAporte.Text),
                Formulario.ValidarNumeroDoble(txtLiquidacionSueldoTiempoCompleto.Text),
                Formulario.ValidarNumeroDoble(txtLiquidacionSueldoTiempoParcial.Text),
                Formulario.ValidarNumeroDoble(txtLiquidacionSueldoART_Fijo.Text),
                Formulario.ValidarNumeroDoble(txtLiquidacionSueldoART_Tasa.Text),
                Formulario.ValidarNumeroDoble(txtLiquidacionSueldoSCVO.Text),
                Formulario.ValidarNumeroDoble(txtEstadoResultadoIIBB.Text),
                Formulario.ValidarNumeroDoble(txtEstadoResultadoSAC.Text),
                Formulario.ValidarNumeroDoble(txtEstadoResultadoGanancia.Text),
                Formulario.ValidarNumeroEntero(txtTiempoAnulacion.Text),
                Formulario.ValidarNumeroEntero(txtTiempoModificacion.Text),
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void reportarRegistro(string programa)
        {
            if (_idOpcionGeneral > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "Punto de venta: ",
                    "Alerta de certif. de antecedentes: ",
                    "Alerta de curso de inducción: ",
                    "Alerta de curso de izaje: ",
                    "Alerta de entrevista de trabajo: ",
                    "Alerta de exámen médico: ",
                    "Alerta de licencia de conducir: ",
                    "Vigencia de certif. de antecedente: ",
                    "Vigencia de currículum vitae: ",
                    "Vigencia de curso de induccion: ",
                    "Vigencia de curso de izaje: ",
                    "Vigencia de exámen médico: ",
                    "Liquid. de Sueldo - Aportes: ",
                    "Liquid. de Sueldo - Contrib. tiempo completo: ",
                    "Liquid. de Sueldo - Contrib. tiempo parcial: ",
                    "Liquid. de Sueldo - ART (fijo): ",
                    "Liquid. de Sueldo - ART (tasa): ",
                    "Liquid. de Sueldo - SCVO: ",
                    "Reporte - Estado resultados IIBB: ",
                    "Reporte - Estado resultados SAC: ",
                    "Reporte - Estado resultados Ganancias: ",
                    "Tiempo de Anulación: ",
                    "Tiempo de Modificación: " };
                string[] datoDB = {
                    Convert.ToString(objOpcionGeneral.PtoVta).PadLeft(5, '0'),
                    Convert.ToString(objOpcionGeneral.AlertaAntecedentes) + " día/s",
                    Convert.ToString(objOpcionGeneral.AlertaCursoInduccion) + " día/s",
                    Convert.ToString(objOpcionGeneral.AlertaCursoIzaje) + " día/s",
                    Convert.ToString(objOpcionGeneral.AlertaEntrevista) + " día/s",
                    Convert.ToString(objOpcionGeneral.AlertaExamenMedico) + " día/s",
                    Convert.ToString(objOpcionGeneral.AlertaLicenciaConducir) + " día/s",
                    Convert.ToString(objOpcionGeneral.VigenciaAntecedentes) + " mes/es",
                    Convert.ToString(objOpcionGeneral.VigenciaCurriculumVitae) + " mes/es",
                    Convert.ToString(objOpcionGeneral.VigenciaCursoInduccion) + " mes/es",
                    Convert.ToString(objOpcionGeneral.VigenciaCursoIzaje) + " mes/es",
                    Convert.ToString(objOpcionGeneral.VigenciaExamenMedico) + " mes/es",
                    "%" + Formulario.ValidarCampoMoneda(objOpcionGeneral.LiquidacionSueldo_AporteTasa),
                    "$" + Formulario.ValidarCampoMoneda(objOpcionGeneral.LiquidacionSueldo_ArtFijo),
                    "%" + Formulario.ValidarCampoMoneda(objOpcionGeneral.LiquidacionSueldo_ArtTasa),
                    "%" + Formulario.ValidarCampoMoneda(objOpcionGeneral.LiquidacionSueldo_ContribTiempoCompletoTasa),
                    "%" + Formulario.ValidarCampoMoneda(objOpcionGeneral.LiquidacionSueldo_ContribTiempoParcialTasa),
                    "%" + Formulario.ValidarCampoMoneda(objOpcionGeneral.LiquidacionSueldo_SCVO),
                    "%" + Formulario.ValidarCampoMoneda(objOpcionGeneral.EstadoResultado_IIBBTasa),
                    "%" + Formulario.ValidarCampoMoneda(objOpcionGeneral.EstadoResultado_PrevisionSACDesempleoTasa),
                    "%" + Formulario.ValidarCampoMoneda(objOpcionGeneral.EstadoResultado_PrevisionImpGananciaTasa),
                    Convert.ToString(objOpcionGeneral.RegistroAnulacion) + " día/s",
                    Convert.ToString(objOpcionGeneral.RegistroModificion) + " día/s" };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Opciones Generales", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Opciones Generales", subTitulo, datoDB);
                Cursor.Current = Cursors.Default;
            }
            else Mensaje.Advertencia("Operación incorrecta.\nSeleccione un registro en la pantalla e intente nuevamente.");
        }
        #endregion
    }
}
