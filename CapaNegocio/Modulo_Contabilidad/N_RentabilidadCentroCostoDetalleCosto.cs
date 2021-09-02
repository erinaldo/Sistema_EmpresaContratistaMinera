using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_RentabilidadCentroCostoDetalleCosto : IRentabilidadCentroCostoDetalleCosto, IDisposable
    {
        #region Atributos
        private D_RentabilidadCentroCostoDetalleCosto dRentabilidadCentroCostoDetalleCosto = new D_RentabilidadCentroCostoDetalleCosto();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dRentabilidadCentroCostoDetalleCosto.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<RentabilidadCentroCostoDetalleCosto> obtenerObjetos(long idRentabilidad)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<RentabilidadCentroCostoDetalleCosto> resultado = dRentabilidadCentroCostoDetalleCosto.obtenerObjetos(idRentabilidad);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<RentabilidadCentroCostoDetalleCosto> obtenerObjetos(long idRentabilidad, string tipoCuenta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<RentabilidadCentroCostoDetalleCosto> resultado = dRentabilidadCentroCostoDetalleCosto.obtenerObjetos(idRentabilidad, tipoCuenta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<RentabilidadCentroCostoDetalleCosto> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<RentabilidadCentroCostoDetalleCosto> resultado = dRentabilidadCentroCostoDetalleCosto.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public RentabilidadCentroCostoDetalleCosto obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            RentabilidadCentroCostoDetalleCosto resultado = dRentabilidadCentroCostoDetalleCosto.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(RentabilidadCentroCostoDetalleCosto objRentabilidadCentroCostoDetalleCosto)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dRentabilidadCentroCostoDetalleCosto.insertar(objRentabilidadCentroCostoDetalleCosto);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_rentabilidad_cc_detalle_costo"); }
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
                dRentabilidadCentroCostoDetalleCosto.Dispose();
            }
        }
        #endregion
    }
}
