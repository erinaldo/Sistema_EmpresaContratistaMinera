using CapaDatos.Sistema;
using Entidades.Sistema;
using System;
using System.Windows.Forms;

namespace CapaNegocio.Sistema
{
    public class N_OpcionGeneral : IDisposable
    {
        #region Atributos
        private D_OpcionGeneral dOpcionGeneral = new D_OpcionGeneral();
        #endregion

        #region Métodos
        public OpcionGeneral obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            OpcionGeneral resultado = dOpcionGeneral.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(OpcionGeneral objOpcionGeneral, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dOpcionGeneral.actualizar(objOpcionGeneral, notificarExito);
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
                dOpcionGeneral.Dispose();
            }
        }
        #endregion
    }
}
