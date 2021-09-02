using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_OrdenCompra : IOrdenCompra, IDisposable
    {
        #region Atributos
        private D_OrdenCompra dOrdenCompra = new D_OrdenCompra();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dOrdenCompra.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dOrdenCompra.obtenerCatalago(estado, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<OrdenCompra> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<OrdenCompra> resultado = dOrdenCompra.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<OrdenCompra> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<OrdenCompra> resultado = dOrdenCompra.obtenerObjetos(estado, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public OrdenCompra obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            OrdenCompra resultado = dOrdenCompra.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(OrdenCompra objOrdenCompra)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dOrdenCompra.actualizar(objOrdenCompra);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool anular(OrdenCompra objOrdenCompra)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dOrdenCompra.anular(objOrdenCompra);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool autorizar(OrdenCompra objOrdenCompra, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dOrdenCompra.autorizar(objOrdenCompra, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(OrdenCompra objOrdenCompra)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dOrdenCompra.insertar(objOrdenCompra);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_orden_compra"); }
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
                dOrdenCompra.Dispose();
            }
        }
        #endregion
    }
}