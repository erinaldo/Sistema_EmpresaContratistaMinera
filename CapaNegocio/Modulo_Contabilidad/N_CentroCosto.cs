using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_CentroCosto : ICentroCosto, IDisposable
    {
        #region Atributos
        private D_CentroCosto dCentroCosto = new D_CentroCosto();
        #endregion

        #region Métodos
        public List<string> obtenerListaDeElementos(string[] deposito)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<string> resultado = dCentroCosto.obtenerListaDeElementos(deposito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCentroCosto.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CentroCosto> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CentroCosto> resultado = dCentroCosto.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public CentroCosto obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            CentroCosto resultado = dCentroCosto.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(CentroCosto objCentroCosto)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCentroCosto.actualizar(objCentroCosto);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(CentroCosto objCentroCosto)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCentroCosto.insertar(objCentroCosto);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_centro_costo"); }
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
                dCentroCosto.Dispose();
            }
        }
        #endregion
    }
}