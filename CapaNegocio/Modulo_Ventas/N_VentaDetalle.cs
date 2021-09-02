using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_VentaDetalle : IVentaDetalle, IDisposable
    {
        #region Atributos
        private D_VentaDetalle dVentaDetalle = new D_VentaDetalle();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dVentaDetalle.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<VentaDetalle> obtenerObjetos(long idVenta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<VentaDetalle> resultado = dVentaDetalle.obtenerObjetos(idVenta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<VentaDetalle> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<VentaDetalle> resultado = dVentaDetalle.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public VentaDetalle obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            VentaDetalle resultado = dVentaDetalle.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(List<VentaDetalle> listaDeVentaDetalle)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dVentaDetalle.actualizar(listaDeVentaDetalle);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(List<VentaDetalle> listaDeVentaDetalle)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dVentaDetalle.insertar(listaDeVentaDetalle);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool compararDetalle(List<VentaDetalle> detalleDB, List<VentaDetalle> detalle)
        {
            if (detalleDB.Count > 0)
            {
                if (detalleDB.Count != detalle.Count) return false;
                else if (detalleDB.Count == detalle.Count)
                {
                    for (int i = 0; i < detalleDB.Count; i++)
                    {
                        if (detalleDB[i].Id != detalle[i].Id ||
                            detalleDB[i].Venta.Id != detalle[i].Venta.Id ||
                            detalleDB[i].IdArticulo != detalle[i].IdArticulo ||
                            detalleDB[i].Denominacion != detalle[i].Denominacion ||
                            detalleDB[i].Cantidad != detalle[i].Cantidad ||
                            detalleDB[i].Unidad != detalle[i].Unidad ||
                            detalleDB[i].Deposito != detalle[i].Deposito ||
                            detalleDB[i].PrecioUnitario != detalle[i].PrecioUnitario ||
                            detalleDB[i].AlicuotaIVA != detalle[i].AlicuotaIVA ||
                            detalleDB[i].BaseIVA != detalle[i].BaseIVA ||
                            detalleDB[i].PrecioNeto != detalle[i].PrecioNeto ||
                            detalleDB[i].CentroCosto.Denominacion != detalle[i].CentroCosto.Denominacion) return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_venta_detalle"); }
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
                dVentaDetalle.Dispose();
            }
        }
        #endregion
    }
}
