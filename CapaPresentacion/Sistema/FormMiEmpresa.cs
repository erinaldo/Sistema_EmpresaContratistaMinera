using System;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio.Sistema;
using Entidades.Sistema;

namespace CapaPresentacion
{ 
    public partial class FormMiEmpresa : Biblioteca.Formularios.FormBase
    {
        #region Atributos
        private long _idMiEmpresa = 1;
        private MiEmpresa objMiEmpresa;
        private N_MiEmpresa nMiEmpresa = new N_MiEmpresa();
        #endregion

        public FormMiEmpresa()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FormMiEmpresa_Load(object sender, EventArgs e)
        {
            escribirControles(nMiEmpresa.obtenerObjeto("ID", _idMiEmpresa.ToString(), true)); //Escribe los datos del único registro existente
        }

        private void txtDenominacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '-' && e.KeyChar != '.') Formulario.ValidarCampoAlfaNumerico(e, true);
        }

        private void txtNombreFantasia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '-' && e.KeyChar != '.') Formulario.ValidarCampoAlfaNumerico(e, true);
        }

        private void txtDomicilio_Validated(object sender, EventArgs e)
        {
            txtDomicilio.Text = Formulario.ValidarCampoTipoSubTitulo(txtDomicilio.Text);
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Formulario.GenerarDistritos(cmbProvincia.Text, cmbDistrito);
            txtCodigoPostal.Text = "";
        }

        private void cmbDistrito_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoAlfaNumerico(e, true);
        }

        private void cmbDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigoPostal.Text = Formulario.GenerarCodigoPostal(cmbDistrito.Text);
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idMiEmpresa > 0 && Global.UsuarioActivo_Privilegios.Contains(83)) //Verifica que el usuario posea el privilegio requerido
            {
                //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                if (ValidarCampoVacio())
                {
                    if (ValidarLongitudCuit())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            if (nMiEmpresa.actualizar(objMiEmpresa, true))
                            {
                                Global.cargarVariablesDeEmpresa(new N_MiEmpresa().obtenerObjeto("ID", "1", true)); //Importante: Actualiza las variables globales
                            }
                            mostrarDatos();
                        }
                    }
                    else Mensaje.Informacion("Operación Incorrecta. La longitud del CUIT es inválida.");
                }
            }
            else Mensaje.Restriccion();
            bool ValidarLongitudCuit() // Método que valida la longitud del CUIT
            {
                if (txtCuit.Text.Length == 11) return true;
                return false;
            }
            bool ValidarCampoVacio() // Método que valida los campos requeridos
            {
                return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion , txtCuit, cmbCategoriaIva,
                    txtNroIngresoBruto, txtDomicilio, cmbProvincia, cmbDistrito, txtCodigoPostal })
                    && Formulario.ValidarCampoEmail(txtEmail.Text);
            }
            void mostrarDatos() //Método que muestra en la pantalla los cambios generados
            {
                escribirControles(nMiEmpresa.obtenerObjeto("ID", _idMiEmpresa.ToString(), true)); //Importante: Por ultimo re-Escribe todos los controles para mayor seguridad                      }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idMiEmpresa > 0) escribirControles(nMiEmpresa.obtenerObjeto("ID", _idMiEmpresa.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
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
        private void escribirControles(MiEmpresa objMiEmpresa)
        {
            this.objMiEmpresa = objMiEmpresa; //Obtiene los datos del objeto recibido
            if (objMiEmpresa != null)
            {
                _idMiEmpresa = (objMiEmpresa != null) ? objMiEmpresa.Id : 0;
                txtDenominacion.Text = objMiEmpresa.Denominacion;
                txtNombreFantasia.Text = objMiEmpresa.NombreFantasia;
                txtCuit.Text = objMiEmpresa.Cuit;
                cmbCategoriaIva.Text = Convert.ToString(objMiEmpresa.Iva);
                txtNroIngresoBruto.Text = objMiEmpresa.NroIngresosBrutos;
                pkrInicioActividad.Value = objMiEmpresa.InicioDeActividad;
                txtDomicilio.Text = objMiEmpresa.Domicilio;
                cmbProvincia.Text = objMiEmpresa.Provincia;
                cmbDistrito.Text = objMiEmpresa.Distrito;
                txtCodigoPostal.Text = objMiEmpresa.Cp;
                txtTelefono.Text = objMiEmpresa.Telefono;
                txtCelular.Text = objMiEmpresa.Celular;
                txtEmail.Text = objMiEmpresa.Email;
                txtPaginaWeb.Text = objMiEmpresa.PaginaWeb;
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objMiEmpresa.EdicionFecha) + " por " + objMiEmpresa.EdicionUsuarioDenominacion;
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objMiEmpresa = new MiEmpresa(
                (_idMiEmpresa <= 0) ? 0 : _idMiEmpresa,
                txtDenominacion.Text.Trim(),
                txtNombreFantasia.Text.Trim(),
                txtCuit.Text,
                ((string.IsNullOrEmpty(cmbCategoriaIva.Text)) ? "CONSUMIDOR FINAL" : cmbCategoriaIva.Text), //Importante: Los ENUM en la BD nececitan recibir un dato conocido
                txtNroIngresoBruto.Text,
                pkrInicioActividad.Value,
                txtDomicilio.Text,
                cmbProvincia.Text.ToUpper(),
                cmbDistrito.Text.ToUpper(),
                txtCodigoPostal.Text,
                txtTelefono.Text,
                txtCelular.Text,
                txtEmail.Text.ToLower(),
                txtPaginaWeb.Text.ToLower(),
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void reportarRegistro(string programa)
        {
            if (_idMiEmpresa > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "Razón social: ",
                    "Nombre de fantasía: ",
                    "CUIT: ",
                    "Categoría frente al IVA: ",
                    "N° Ingresos brutos: ",
                    "Inicio de actividad: ",
                    "Domicilio: ",
                    "Provincia: ",
                    "Distrito: ",
                    "Código postal: ",
                    "Teléfono: ",
                    "Celular: ",
                    "E-mail: ",
                    "Página WEB: " };
                string[] datoDB = {
                    objMiEmpresa.Denominacion,
                    objMiEmpresa.NombreFantasia,
                    objMiEmpresa.Cuit,
                    objMiEmpresa.Iva,
                    objMiEmpresa.NroIngresosBrutos,
                    Fecha.ConvertirFecha(objMiEmpresa.InicioDeActividad),
                    objMiEmpresa.Domicilio,
                    objMiEmpresa.Provincia,
                    objMiEmpresa.Distrito,
                    objMiEmpresa.Cp,
                    objMiEmpresa.Telefono,
                    objMiEmpresa.Celular,
                    objMiEmpresa.Email,
                    objMiEmpresa.PaginaWeb };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Mi Empresa", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Mi Empresa", subTitulo, datoDB);
                Cursor.Current = Cursors.Default;
            }
            else Mensaje.Advertencia("Operación incorrecta.\nSeleccione un registro en la pantalla e intente nuevamente.");
        }
        #endregion
    }
}
