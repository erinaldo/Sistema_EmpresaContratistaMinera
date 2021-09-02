using CapaDatos;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_ResumenAsientoSueldo: IResumenAsientoSueldo, IDisposable
    {
        #region Atributos
        private D_ResumenAsientoSueldo dResumenAsientoSueldo = new D_ResumenAsientoSueldo();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string periodo, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dResumenAsientoSueldo.obtenerCatalago(periodo, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public double[] contabilizarDebeHaber(string periodo)
        {
            Cursor.Current = Cursors.WaitCursor;
            double[] resultado = dResumenAsientoSueldo.contabilizarDebeHaber(periodo);
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
                dResumenAsientoSueldo.Dispose();
            }
        }
        #endregion
    }
}
