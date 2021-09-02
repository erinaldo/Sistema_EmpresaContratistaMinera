using Biblioteca.Ayudantes;
using System;
using System.IO;
using System.Windows.Forms;

namespace Actualizador
{
    public partial class FormPublicacionActualizacion : Biblioteca.Formularios.FormBaseModal
    {
        #region Atributos de Conexión
        private static string _servidorFTP = "ftp://ftp.sersystems.store/app_empreminsa/";
        private static string _usuarioFTP = "u172823965.empreminsa";
        private static string _contraseniaFTP = "jrD5fMpF";
        #endregion

        public FormPublicacionActualizacion()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FormPublicacionActualizacion_Load(object sender, EventArgs e)
        {
            txtVersionActual.Text = Archivo.LeerTXT(obtenerRutaDeSistema() + @"\Update\", "version.sys").Trim().PadRight(6, '0').Insert(1, ".").Insert(4, ".");
        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {
            lblLeyenda.Visible = true;
            publicarActualizacion();
            lblLeyenda.Visible = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Cierra la Aplicación 
        }
        #endregion

        #region Métodos
        private void publicarActualizacion()
        {
            if (validarAcceso())
            {
                if (Mensaje.ConfirmacionBoton1("¿Desea publicar una nueva actualización del sistema?") == DialogResult.Yes)
                {
                    Actualizacion.SubirActualizacionFTP(obtenerRutaDeSistema(), _servidorFTP, _usuarioFTP, _contraseniaFTP);
                }
            }
            else Mensaje.Advertencia("Clave Incorrecta.\nVerifique su clave de acceso e intente nuevamente.");
        }

        private string obtenerRutaDeSistema()
        {
            string rutaSistema = @"CapaPresentacion\bin\Debug\";
            string[] directorioProyecto = Directory.GetCurrentDirectory().Replace(@"\", "|").Split('|'); //Obtiene la ruta del proyecto
            for (int i = directorioProyecto.Length - 3; i > 0; i--) rutaSistema = directorioProyecto[i-1] + @"\" + rutaSistema; //Conforma la ruta del Sistema 
            return rutaSistema;
        }

        private bool validarAcceso()
        {
            if (txtClaveAcesso.Text.Trim() == "Sergito1") return true;
            return false;
        }
        #endregion
    }
}
