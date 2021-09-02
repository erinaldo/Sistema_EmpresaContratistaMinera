using CapaDatos;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_LibroMayor: ILibroMayor, IDisposable
    {
        #region Atributos
        private D_LibroMayor dLibroMayor = new D_LibroMayor();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(long idCuentaContable, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dLibroMayor.obtenerCatalago(idCuentaContable, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public double[] contabilizarDebeHaber(long idCuentaContable, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            double[] resultado = dLibroMayor.contabilizarDebeHaber(idCuentaContable, desde, hasta);
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
                dLibroMayor.Dispose();
            }
        }
        #endregion
    }
}
