using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_CobranzaDetalle : ICobranzaDetalle, IDisposable
    {
        #region Atributos
        private D_CobranzaDetalle dCobranzaDetalle = new D_CobranzaDetalle();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCobranzaDetalle.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CobranzaDetalle> obtenerObjetos(long idcobranza)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CobranzaDetalle> resultado = dCobranzaDetalle.obtenerObjetos(idcobranza);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CobranzaDetalle> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CobranzaDetalle> resultado = dCobranzaDetalle.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public CobranzaDetalle obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            CobranzaDetalle resultado = dCobranzaDetalle.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(List<CobranzaDetalle> listaDeCobranzaDetalle)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCobranzaDetalle.actualizar(listaDeCobranzaDetalle);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(List<CobranzaDetalle> listaDeCobranzaDetalle)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCobranzaDetalle.insertar(listaDeCobranzaDetalle);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool compararDetalle(List<CobranzaDetalle> detalleDB, List<CobranzaDetalle> detalle)
        {
            if (detalleDB.Count > 0)
            {
                if (detalleDB.Count != detalle.Count) return false;
                else if (detalleDB.Count == detalle.Count)
                {
                    for (int i = 0; i < detalleDB.Count; i++)
                    {
                        if (detalleDB[i].Id != detalle[i].Id ||
                            !EqualityComparer<Cobranza>.Default.Equals(detalleDB[i].Cobranza, detalle[i].Cobranza) ||
                            detalleDB[i].Venta.CobranzaEstado != detalle[i].Venta.CobranzaEstado) return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_cobranza_detalle"); }
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
                dCobranzaDetalle.Dispose();
            }
        }
        #endregion
    }
}
