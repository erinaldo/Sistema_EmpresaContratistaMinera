using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_ControlStockDetalle : IControlStockDetalle, IDisposable
    {
        #region Atributos
        private D_ControlStockDetalle dControlStockDetalle = new D_ControlStockDetalle();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dControlStockDetalle.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<ControlStockDetalle> obtenerObjetos(long idControlStock)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<ControlStockDetalle> resultado = dControlStockDetalle.obtenerObjetos(idControlStock);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<ControlStockDetalle> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<ControlStockDetalle> resultado = dControlStockDetalle.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public ControlStockDetalle obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            ControlStockDetalle resultado = dControlStockDetalle.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(ControlStockDetalle objControlStockDetalle, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dControlStockDetalle.insertar(objControlStockDetalle, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_stk_control_detalle"); }
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
                dControlStockDetalle.Dispose();
            }
        }
        #endregion
    }
}
