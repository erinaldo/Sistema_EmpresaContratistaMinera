using CapaDatos.Sistema;
using System;
using System.Windows.Forms;

namespace CapaNegocio.Sistema
{
    public class N_Herramienta : IDisposable
    {
        #region Atributos
        private D_Herramienta dHerramienta = new D_Herramienta();
        #endregion

        #region Métodos
        public string crearBackupDB()
        {
            Cursor.Current = Cursors.WaitCursor;
            string respuesta = dHerramienta.crearBackupDB();
            Cursor.Current = Cursors.Default;
            return respuesta;
        }
        
        public void restaurarDB(string archivoBackup)
        {
            Cursor.Current = Cursors.WaitCursor;
            dHerramienta.restaurarDB(archivoBackup);
            Cursor.Current = Cursors.Default;
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
                dHerramienta.Dispose();
            }
        }
        #endregion
    }
}
