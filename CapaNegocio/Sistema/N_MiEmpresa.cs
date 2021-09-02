using CapaDatos.Sistema;
using Entidades.Sistema;
using System;
using System.Windows.Forms;

namespace CapaNegocio.Sistema
{
    public class N_MiEmpresa : IDisposable
    {
        #region Atributos
        private D_MiEmpresa dMiEmpresa = new D_MiEmpresa();
        #endregion

        #region Métodos
        public MiEmpresa obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            MiEmpresa resultado = dMiEmpresa.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(MiEmpresa objMiEmpresa, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dMiEmpresa.actualizar(objMiEmpresa, notificarExito);
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
                dMiEmpresa.Dispose();
            }
        }
        #endregion
    }
}
