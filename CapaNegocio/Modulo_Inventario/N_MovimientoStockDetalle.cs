using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_MovimientoStockDetalle : IMovimientoStockDetalle, IDisposable
    {
        #region Atributos
        private D_MovimientoStockDetalle dMovimientoStockDetalle = new D_MovimientoStockDetalle();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dMovimientoStockDetalle.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<MovimientoStockDetalle> obtenerObjetos(long idMovimientoStock)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<MovimientoStockDetalle> resultado = dMovimientoStockDetalle.obtenerObjetos(idMovimientoStock);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<MovimientoStockDetalle> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<MovimientoStockDetalle> resultado = dMovimientoStockDetalle.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public MovimientoStockDetalle obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            MovimientoStockDetalle resultado = dMovimientoStockDetalle.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(MovimientoStockDetalle objMovimientoStockDetalle, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dMovimientoStockDetalle.insertar(objMovimientoStockDetalle, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_stk_movimiento_detalle"); }
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
                dMovimientoStockDetalle.Dispose();
            }
        }
        #endregion
    }
}
