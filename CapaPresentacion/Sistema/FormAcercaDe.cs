using Biblioteca.Ayudantes;

namespace CapaPresentacion
{
    public partial class FormAcercaDe : Biblioteca.Formularios.FormBase
    {
        public FormAcercaDe()
        {
            InitializeComponent();
        }

        private void FormAcercaDe_Load(object sender, System.EventArgs e)
        {
            //lblVersionCompilacion.Text = "Versión: 1.0 (Compilación " + Global.VersionDelSistema_Compilacion + ")";
            //lblFechaCompilacion.Text = "Fecha de compilación: " + Global.VersionDelSistema_Fecha;
            // private static string _versionDelSistema_Compilacion = Archivo.LeerTXT(Archivo.ValidarDirectorio(@"Update\"), "version.sys").Replace(",", ".");
            //  private static string _versionDelSistema_Fecha = Fecha.ConvertirFecha(File.GetLastWriteTime(Archivo.ValidarDirectorio(@"Update\") + "version.sys"));
            //    public static string VersionDelSistema_Compilacion { get => _versionDelSistema_Compilacion; set => _versionDelSistema_Compilacion = value; }
            //    public static string VersionDelSistema_Fecha { get => _versionDelSistema_Fecha; set => _versionDelSistema_Fecha = value; }
        }
    }
}
