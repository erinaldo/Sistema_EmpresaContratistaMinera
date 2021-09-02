using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_AsientoManual : IAsientoManual, IDisposable
    {
        #region Atributos
        private D_AsientoManual dAsientoManual = new D_AsientoManual();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dAsientoManual.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dAsientoManual.obtenerCatalago(estado, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<AsientoManual> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<AsientoManual> resultado = dAsientoManual.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<AsientoManual> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<AsientoManual> resultado = dAsientoManual.obtenerObjetos(estado, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public AsientoManual obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            AsientoManual resultado = dAsientoManual.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(AsientoManual objAsientoManual)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dAsientoManual.actualizar(objAsientoManual);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool anular(AsientoManual objAsientoManual)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dAsientoManual.anular(objAsientoManual);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(AsientoManual objAsientoManual)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dAsientoManual.insertar(objAsientoManual);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_asiento_manual"); }
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
                dAsientoManual.Dispose();
            }
        }
        #endregion
    }
}
