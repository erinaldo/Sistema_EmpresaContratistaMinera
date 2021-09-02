using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_MovimientoFondo : IMovimientoFondo, IDisposable
    {
        #region Atributos
        private D_MovimientoFondo dMovimientoFondo = new D_MovimientoFondo();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dMovimientoFondo.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dMovimientoFondo.obtenerCatalago(estado, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<MovimientoFondo> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<MovimientoFondo> resultado = dMovimientoFondo.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<MovimientoFondo> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<MovimientoFondo> resultado = dMovimientoFondo.obtenerObjetos(estado, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public MovimientoFondo obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            MovimientoFondo resultado = dMovimientoFondo.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(MovimientoFondo objMovimientoFondo)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dMovimientoFondo.actualizar(objMovimientoFondo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool anular(MovimientoFondo objMovimientoFondo)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dMovimientoFondo.anular(objMovimientoFondo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(MovimientoFondo objMovimientoFondo)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dMovimientoFondo.insertar(objMovimientoFondo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_movimiento_fondo"); }
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
                dMovimientoFondo.Dispose();
            }
        }
        #endregion
    }
}
