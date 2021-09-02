using CapaDatos.Sistema;
using Entidades.Sistema;
using System;
using System.Windows.Forms;

namespace CapaNegocio.Sistema
{
    public class N_CredencialFTP : IDisposable
    {
        #region Atributos
        private D_CredencialFTP dCredencialFTP = new D_CredencialFTP();
        #endregion

        #region Métodos
        public CredencialFTP obtenerObjeto(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            CredencialFTP resultado = dCredencialFTP.obtenerObjeto(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
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
                dCredencialFTP.Dispose();
            }
        }
        #endregion
    }
}
