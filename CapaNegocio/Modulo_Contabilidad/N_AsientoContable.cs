using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_AsientoContable : IAsientoContable, IDisposable
    {
        #region Atributos
        private D_AsientoContable dAsientoContable = new D_AsientoContable();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string libro, long idCuentaContable, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dAsientoContable.obtenerCatalago(libro, idCuentaContable, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string libro, long idCuentaContable, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dAsientoContable.obtenerCatalago(libro, idCuentaContable, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<AsientoContable> obtenerObjetos(string libro, long idCuentaContable, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<AsientoContable> resultado = dAsientoContable.obtenerObjetos(libro, idCuentaContable, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<AsientoContable> obtenerObjetos(string libro, long idCuentaContable, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<AsientoContable> resultado = dAsientoContable.obtenerObjetos(libro, idCuentaContable, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public AsientoContable obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            AsientoContable resultado = dAsientoContable.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public AsientoContable obtenerObjeto(string origenTipo, long origenId, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            AsientoContable resultado = dAsientoContable.obtenerObjeto(origenTipo, origenId, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(AsientoContable objAsientoContable, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dAsientoContable.actualizar(objAsientoContable, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool eliminar(AsientoContable objAsientoContable, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dAsientoContable.eliminar(objAsientoContable, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool eliminar(long asientoNro)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dAsientoContable.eliminar(asientoNro);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(AsientoContable objAsientoContable, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dAsientoContable.insertar(objAsientoContable, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroAsiento()
        {
            Cursor.Current = Cursors.WaitCursor;
            long resultado = dAsientoContable.generarNumeroAsiento();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_libro_diario"); }
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
                dAsientoContable.Dispose();
            }
        }
        #endregion
    }
}
