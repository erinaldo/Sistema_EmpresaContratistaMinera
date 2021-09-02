using CapaDatos;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_FacturaAPagar : IFacturaAPagar, IDisposable
    {
        #region Atributos
        private D_FacturaAPagar dFacturaAPagar = new D_FacturaAPagar();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campoEspecifico, string valorEspecifico, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dFacturaAPagar.obtenerCatalago(campoEspecifico, valorEspecifico, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public double[] contabilizarDebeHaber(string campoEspecifico, string valorEspecifico, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            double[] resultado = dFacturaAPagar.contabilizarDebeHaber(campoEspecifico, valorEspecifico, desde, hasta);
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
                dFacturaAPagar.Dispose();
            }
        }
        #endregion
    }
}
