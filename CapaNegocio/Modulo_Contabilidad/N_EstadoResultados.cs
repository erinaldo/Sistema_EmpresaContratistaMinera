using CapaDatos;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_EstadoResultados: IEstadoResultados, IDisposable
    {
        #region Atributos
        private D_EstadoResultados dEstadoResultados = new D_EstadoResultados();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string periodo, string catalogo = "CATALOGO1")
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dEstadoResultados.obtenerCatalago(periodo, catalogo);
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
                dEstadoResultados.Dispose();
            }
        }
        #endregion
    }
}
