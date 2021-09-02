using CapaDatos;
using System;
using System.Windows.Forms;

namespace CapaNegocio.Sistema
{
    public class N_Conexion : IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Métodos
        public bool ProbarConexion()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool respuesta = _conexion.crearConexion();
            Cursor.Current = Cursors.Default;
            return respuesta;
        }
        #endregion

        #region Liberación de Recursos
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) //Método que cierra y liberar los recursos utilizados
        {
            if (disposing)
            {
                _conexion.Dispose();
            }
        }
        #endregion
    }
}
