using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_PagoProveedor : IPagoProveedor, IDisposable
    {
        #region Atributos
        private D_PagoProveedor dPagoProveedor = new D_PagoProveedor();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dPagoProveedor.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dPagoProveedor.obtenerCatalago(estado, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<PagoProveedor> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<PagoProveedor> resultado = dPagoProveedor.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<PagoProveedor> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<PagoProveedor> resultado = dPagoProveedor.obtenerObjetos(estado, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public PagoProveedor obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            PagoProveedor resultado = dPagoProveedor.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(PagoProveedor objPagoProveedor)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPagoProveedor.actualizar(objPagoProveedor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool anular(PagoProveedor objPagoProveedor)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPagoProveedor.anular(objPagoProveedor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(PagoProveedor objPagoProveedor)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPagoProveedor.insertar(objPagoProveedor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_pago_proveedor"); }
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
                dPagoProveedor.Dispose();
            }
        }
        #endregion
    }
}
