using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_ConsumoCentroCosto: IConsumoCentroCosto, IDisposable
    {
        #region Atributos
        private D_ConsumoCentroCosto dConsumoCentroCosto = new D_ConsumoCentroCosto();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string centroCosto, string periodo, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dConsumoCentroCosto.obtenerCatalago(centroCosto, periodo, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<ConsumoCentroCosto> obtenerObjetos(string centroCosto, string periodo)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<ConsumoCentroCosto> resultado = dConsumoCentroCosto.obtenerObjetos(centroCosto, periodo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public double[] obtenerConsumoTotal(string centroCosto, string periodo)
        {
            Cursor.Current = Cursors.WaitCursor;
            double[] resultado = dConsumoCentroCosto.obtenerConsumoTotal(centroCosto, periodo);
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
                dConsumoCentroCosto.Dispose();
            }
        }
        #endregion
    }
}
