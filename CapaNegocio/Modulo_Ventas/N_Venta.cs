using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_Venta : IVenta, IDisposable
    {
        #region Atributos
        private D_Venta dVenta = new D_Venta();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(int afipTipoCbte, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50, string filtroExclusivoCobroCUIT = "TODOS")
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dVenta.obtenerCatalago(afipTipoCbte, campo, valor, catalogo, indicePagina, tamanioPagina, filtroExclusivoCobroCUIT);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(int afipTipoCbte, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50, string filtroExclusivoCobroCUIT = "TODOS")
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dVenta.obtenerCatalago(afipTipoCbte, campo, desde, hasta, catalogo, indicePagina, tamanioPagina, filtroExclusivoCobroCUIT);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerLibroIVA(string periodo, string catalogo = "CATALOGO1")
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dVenta.obtenerLibroIVA(periodo, catalogo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerInformativo(string periodo, string catalogo = "CATALOGO1")
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dVenta.obtenerInformativo(periodo, catalogo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Venta> obtenerObjetos(int afipTipoCbte, string campo, string valor, string filtroExclusivoCobroCUIT = "TODOS")
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Venta> resultado = dVenta.obtenerObjetos(afipTipoCbte, campo, valor, filtroExclusivoCobroCUIT);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Venta> obtenerObjetos(int afipTipoCbte, string campo, DateTime desde, DateTime hasta, string filtroExclusivoCobroCUIT = "TODOS")
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Venta> resultado = dVenta.obtenerObjetos(afipTipoCbte, campo, desde, hasta, filtroExclusivoCobroCUIT);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public Venta obtenerObjeto(string campo, string valor, bool notificarExito = false, string filtroExclusivoCobroCUIT = "TODOS")
        {
            Cursor.Current = Cursors.WaitCursor;
            Venta resultado = dVenta.obtenerObjeto(campo, valor, notificarExito, filtroExclusivoCobroCUIT);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(Venta objVenta)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dVenta.actualizar(objVenta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(Venta objVenta)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dVenta.insertar(objVenta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool registrarComoCbteAsociado(long id, bool asociacióndo)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dVenta.registrarComoCbteAsociado(id, asociacióndo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_venta"); }
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
                dVenta.Dispose();
            }
        }
        #endregion
    }
}