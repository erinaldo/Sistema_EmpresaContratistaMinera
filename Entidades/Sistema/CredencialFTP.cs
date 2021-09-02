namespace Entidades.Sistema
{
    public class CredencialFTP
    {
        #region Atributos
        private long _id;
        private string _ftpServidor;
        private string _ftpUsuario;
        private string _ftpClave;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public string FtpServidor { get => _ftpServidor; set => _ftpServidor = value; }
        public string FtpUsuario { get => _ftpUsuario; set => _ftpUsuario = value; }
        public string FtpClave { get => _ftpClave; set => _ftpClave = value; }
        #endregion

        #region Constructores
        public CredencialFTP() { }
        public CredencialFTP(long id, string ftpServidor, string ftpUsuario, string ftpClave)
        {
            _id = id;
            _ftpServidor = ftpServidor;
            _ftpUsuario = ftpUsuario;
            _ftpClave = ftpClave;
        }
        #endregion
    }
}
