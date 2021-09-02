using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_AsientoManualDetalle : IAsientoManualDetalle, IDisposable
    {
        #region Atributos
        private D_AsientoManualDetalle dAsientoManualDetalle = new D_AsientoManualDetalle();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dAsientoManualDetalle.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<AsientoManualDetalle> obtenerObjetos(long idAsientoManual)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<AsientoManualDetalle> resultado = dAsientoManualDetalle.obtenerObjetos(idAsientoManual);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<AsientoManualDetalle> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<AsientoManualDetalle> resultado = dAsientoManualDetalle.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public AsientoManualDetalle obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            AsientoManualDetalle resultado = dAsientoManualDetalle.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(AsientoManualDetalle objAsientoManualDetalle)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dAsientoManualDetalle.actualizar(objAsientoManualDetalle);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(AsientoManualDetalle objAsientoManualDetalle)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dAsientoManualDetalle.insertar(objAsientoManualDetalle);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_asiento_manual_detalle"); }
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
                dAsientoManualDetalle.Dispose();
            }
        }
        #endregion
    }
}
