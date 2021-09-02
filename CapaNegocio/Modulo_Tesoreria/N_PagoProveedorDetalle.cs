using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_PagoProveedorDetalle : IPagoProveedorDetalle, IDisposable
    {
        #region Atributos
        private D_PagoProveedorDetalle dPagoProveedorDetalle = new D_PagoProveedorDetalle();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dPagoProveedorDetalle.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<PagoProveedorDetalle> obtenerObjetos(long idcobranza)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<PagoProveedorDetalle> resultado = dPagoProveedorDetalle.obtenerObjetos(idcobranza);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<PagoProveedorDetalle> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<PagoProveedorDetalle> resultado = dPagoProveedorDetalle.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public PagoProveedorDetalle obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            PagoProveedorDetalle resultado = dPagoProveedorDetalle.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(List<PagoProveedorDetalle> listaDePagoProveedorDetalle)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPagoProveedorDetalle.actualizar(listaDePagoProveedorDetalle);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(List<PagoProveedorDetalle> listaDePagoProveedorDetalle)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPagoProveedorDetalle.insertar(listaDePagoProveedorDetalle);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_pago_proveedor_detalle"); }

        public bool compararDetalle(List<PagoProveedorDetalle> detalleDB, List<PagoProveedorDetalle> detalle)
        {
            if (detalleDB.Count > 0)
            {
                if (detalleDB.Count != detalle.Count) return false;
                else if (detalleDB.Count == detalle.Count)
                {
                    for (int i = 0; i < detalleDB.Count; i++)
                    {
                        if (detalleDB[i].Id != detalle[i].Id ||
                            !EqualityComparer<PagoProveedor>.Default.Equals(detalleDB[i].PagoProveedor, detalle[i].PagoProveedor) ||
                            detalleDB[i].Compra.PagoEstado != detalle[i].Compra.PagoEstado) return false;
                    }
                    return true;
                }
            }
            return false;
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
                dPagoProveedorDetalle.Dispose();
            }
        }
        #endregion
    }
}
