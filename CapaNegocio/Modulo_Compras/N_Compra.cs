using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_Compra : ICompra, IDisposable
    {
        #region Atributos
        private D_Compra dCompra = new D_Compra();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(int afipTipoCbte, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50, string filtroExclusivoPagoCUIT = "TODOS")
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCompra.obtenerCatalago(afipTipoCbte, campo, valor, catalogo, indicePagina, tamanioPagina, filtroExclusivoPagoCUIT);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(int afipTipoCbte, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50, string filtroExclusivoPagoCUIT = "TODOS")
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCompra.obtenerCatalago(afipTipoCbte, campo, desde, hasta, catalogo, indicePagina, tamanioPagina, filtroExclusivoPagoCUIT);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerLibroIVA(string periodo, string catalogo = "CATALOGO1")
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCompra.obtenerLibroIVA(periodo, catalogo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerInformativo(string periodo, string catalogo = "CATALOGO1")
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCompra.obtenerInformativo(periodo, catalogo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Compra> obtenerObjetos(int afipTipoCbte, string campo, string valor, string filtroExclusivoPagoCUIT = "TODOS")
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Compra> resultado = dCompra.obtenerObjetos(afipTipoCbte, campo, valor, filtroExclusivoPagoCUIT);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Compra> obtenerObjetos(int afipTipoCbte, string campo, DateTime desde, DateTime hasta, string filtroExclusivoPagoCUIT = "TODOS")
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Compra> resultado = dCompra.obtenerObjetos(afipTipoCbte, campo, desde, hasta, filtroExclusivoPagoCUIT);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public Compra obtenerObjeto(string campo, string valor, bool notificarExito = false, string filtroExclusivoPagoCUIT = "TODOS")
        {
            Cursor.Current = Cursors.WaitCursor;
            Compra resultado = dCompra.obtenerObjeto(campo, valor, notificarExito, filtroExclusivoPagoCUIT);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(Compra objCompra)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCompra.actualizar(objCompra);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(Compra objCompra)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCompra.insertar(objCompra);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool registrarComoCbteAsociado(long id, bool referenciado)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCompra.registrarComoCbteAsociado(id, referenciado);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_compra"); }
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
                dCompra.Dispose();
            }
        }
        #endregion
    }
}