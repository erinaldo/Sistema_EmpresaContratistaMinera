using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_ConsumoStockDetalle : IConsumoStockDetalle, IDisposable
    {
        #region Atributos
        private D_ConsumoStockDetalle dConsumoStockDetalle = new D_ConsumoStockDetalle();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dConsumoStockDetalle.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<ConsumoStockDetalle> obtenerObjetos(long idConsumoStock)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<ConsumoStockDetalle> resultado = dConsumoStockDetalle.obtenerObjetos(idConsumoStock);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<ConsumoStockDetalle> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<ConsumoStockDetalle> resultado = dConsumoStockDetalle.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public ConsumoStockDetalle obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            ConsumoStockDetalle resultado = dConsumoStockDetalle.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(ConsumoStockDetalle objConsumoStockDetalle, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dConsumoStockDetalle.insertar(objConsumoStockDetalle, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_stk_consumo_detalle"); }
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
                dConsumoStockDetalle.Dispose();
            }
        }
        #endregion
    }
}
