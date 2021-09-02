using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_OrdenCompraDetalle : IOrdenCompraDetalle, IDisposable
    {
        #region Atributos
        private D_OrdenCompraDetalle dOrdenCompraDetalle = new D_OrdenCompraDetalle();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dOrdenCompraDetalle.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<OrdenCompraDetalle> obtenerObjetos(long idOrdenCompra)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<OrdenCompraDetalle> resultado = dOrdenCompraDetalle.obtenerObjetos(idOrdenCompra);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<OrdenCompraDetalle> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<OrdenCompraDetalle> resultado = dOrdenCompraDetalle.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public OrdenCompraDetalle obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            OrdenCompraDetalle resultado = dOrdenCompraDetalle.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(List<OrdenCompraDetalle> listaDeOrdenCompraDetalle)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dOrdenCompraDetalle.actualizar(listaDeOrdenCompraDetalle);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(List<OrdenCompraDetalle> listaDeOrdenCompraDetalle)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dOrdenCompraDetalle.insertar(listaDeOrdenCompraDetalle);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool compararDetalle(List<OrdenCompraDetalle> detalleDB, List<OrdenCompraDetalle> detalle)
        {
            if (detalleDB.Count > 0)
            {
                if (detalleDB.Count != detalle.Count) return false;
                else if (detalleDB.Count == detalle.Count)
                {
                    for (int i = 0; i < detalleDB.Count; i++)
                    {
                        if (detalleDB[i].Id != detalle[i].Id ||
                            detalleDB[i].OrdenCompra.Id != detalle[i].OrdenCompra.Id ||
                            detalleDB[i].IdArticulo != detalle[i].IdArticulo ||
                            detalleDB[i].Denominacion != detalle[i].Denominacion ||
                            detalleDB[i].Cantidad != detalle[i].Cantidad ||
                            detalleDB[i].Unidad != detalle[i].Unidad ||
                            detalleDB[i].Deposito != detalle[i].Deposito ||
                            detalleDB[i].CostoUnitario != detalle[i].CostoUnitario ||
                            detalleDB[i].AlicuotaIVA != detalle[i].AlicuotaIVA ||
                            detalleDB[i].BaseIVA != detalle[i].BaseIVA ||
                            detalleDB[i].CostoNeto != detalle[i].CostoNeto ||
                            detalleDB[i].CentroCosto.Denominacion != detalle[i].CentroCosto.Denominacion) return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_orden_compra_detalle"); }
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
                dOrdenCompraDetalle.Dispose();
            }
        }
        #endregion
    }
}

