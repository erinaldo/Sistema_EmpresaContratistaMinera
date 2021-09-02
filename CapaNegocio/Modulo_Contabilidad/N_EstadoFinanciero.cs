using CapaDatos;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_EstadoFinanciero: IEstadoFinanciero, IDisposable
    {
        #region Atributos
        private D_EstadoFinanciero dEstadoFinanciero = new D_EstadoFinanciero();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string periodo, string catalogo = "CATALOGO1")
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dEstadoFinanciero.obtenerCatalago(periodo, catalogo);
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
                dEstadoFinanciero.Dispose();
            }
        }
        #endregion
    }
}
