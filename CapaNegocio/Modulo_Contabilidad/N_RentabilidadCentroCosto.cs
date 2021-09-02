using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_RentabilidadCentroCosto: IRentabilidadCentroCosto, IDisposable
    {
        #region Atributos
        private D_RentabilidadCentroCosto dRentabilidadCentroCosto = new D_RentabilidadCentroCosto();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dRentabilidadCentroCosto.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<RentabilidadCentroCosto> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<RentabilidadCentroCosto> resultado = dRentabilidadCentroCosto.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public RentabilidadCentroCosto obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            RentabilidadCentroCosto resultado = dRentabilidadCentroCosto.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(RentabilidadCentroCosto objRentabilidadCentroCosto)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dRentabilidadCentroCosto.actualizar(objRentabilidadCentroCosto);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool anular(RentabilidadCentroCosto objRentabilidadCentroCosto)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dRentabilidadCentroCosto.anular(objRentabilidadCentroCosto);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(RentabilidadCentroCosto objRentabilidadCentroCosto)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dRentabilidadCentroCosto.insertar(objRentabilidadCentroCosto);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_rentabilidad_cc"); }
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
                dRentabilidadCentroCosto.Dispose();
            }
        }
        #endregion
    }
}
