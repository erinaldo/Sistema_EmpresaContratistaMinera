using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_RentabilidadCentroCostoDetalleImporte : IRentabilidadCentroCostoDetalleImporte, IDisposable
    {
        #region Atributos
        private D_RentabilidadCentroCostoDetalleImporte dRentabilidadCentroCostoDetalleImporte = new D_RentabilidadCentroCostoDetalleImporte();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dRentabilidadCentroCostoDetalleImporte.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<RentabilidadCentroCostoDetalleImporte> obtenerObjetos(long idRentabilidad)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<RentabilidadCentroCostoDetalleImporte> resultado = dRentabilidadCentroCostoDetalleImporte.obtenerObjetos(idRentabilidad);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<RentabilidadCentroCostoDetalleImporte> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<RentabilidadCentroCostoDetalleImporte> resultado = dRentabilidadCentroCostoDetalleImporte.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public RentabilidadCentroCostoDetalleImporte obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            RentabilidadCentroCostoDetalleImporte resultado = dRentabilidadCentroCostoDetalleImporte.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(RentabilidadCentroCostoDetalleImporte objRentabilidadCentroCostoDetalleImporte)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dRentabilidadCentroCostoDetalleImporte.insertar(objRentabilidadCentroCostoDetalleImporte);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_rentabilidad_cc_detalle_importe"); }
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
                dRentabilidadCentroCostoDetalleImporte.Dispose();
            }
        }
        #endregion
    }
}
