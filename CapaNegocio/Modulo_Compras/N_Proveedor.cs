using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_Proveedor : IProveedor, IDisposable
    {
        #region Atributos
        private D_Proveedor dProveedor = new D_Proveedor();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dProveedor.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Proveedor> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Proveedor> resultado = dProveedor.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public Proveedor obtenerObjeto(string estado, string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            Proveedor resultado = dProveedor.obtenerObjeto(estado, campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(Proveedor objProveedor)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dProveedor.actualizar(objProveedor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizarSaldo(long id, double saldo, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dProveedor.actualizarSaldo(id, saldo, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool eliminar(Proveedor objProveedor)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dProveedor.eliminar(objProveedor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(Proveedor objProveedor)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dProveedor.insertar(objProveedor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_proveedor"); }
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
                dProveedor.Dispose();
            }
        }
        #endregion
    }
}
