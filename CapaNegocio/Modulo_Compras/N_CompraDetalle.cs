using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_CompraDetalle : ICompraDetalle, IDisposable
    {
        #region Atributos
        private D_CompraDetalle dCompraDetalle = new D_CompraDetalle();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCompraDetalle.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CompraDetalle> obtenerObjetos(long idCompra)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CompraDetalle> resultado = dCompraDetalle.obtenerObjetos(idCompra);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CompraDetalle> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CompraDetalle> resultado = dCompraDetalle.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public CompraDetalle obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            CompraDetalle resultado = dCompraDetalle.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(List<CompraDetalle> listaDeCompraDetalle)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCompraDetalle.actualizar(listaDeCompraDetalle);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(List<CompraDetalle> listaDeCompraDetalle)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCompraDetalle.insertar(listaDeCompraDetalle);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool compararDetalle(List<CompraDetalle> detalleDB, List<CompraDetalle> detalle)
        {
            if (detalleDB.Count > 0)
            {
                if (detalleDB.Count != detalle.Count) return false;
                else if (detalleDB.Count == detalle.Count)
                {
                    for (int i = 0; i < detalleDB.Count; i++)
                    {
                        if (detalleDB[i].Id != detalle[i].Id ||
                            detalleDB[i].Compra.Id != detalle[i].Compra.Id ||
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

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_compra_detalle"); }
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
                dCompraDetalle.Dispose();
            }
        }
        #endregion
    }
}

