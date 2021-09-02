using CapaDatos;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_BalanceSumasSaldos: IBalanceSumasSaldos, IDisposable
    {
        #region Atributos
        private D_BalanceSumasSaldos dBalanceSumasSaldos = new D_BalanceSumasSaldos();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dBalanceSumasSaldos.obtenerCatalago(desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public double[] contabilizarDebeHaber(DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            double[] resultado = dBalanceSumasSaldos.contabilizarDebeHaber(desde, hasta);
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
                dBalanceSumasSaldos.Dispose();
            }
        }
        #endregion
    }
}
