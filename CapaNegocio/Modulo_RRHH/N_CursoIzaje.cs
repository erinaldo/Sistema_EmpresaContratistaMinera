using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_CursoIzaje : ICursoIzaje, IDisposable
    {
        #region Atributos
        private D_CursoIzaje dCursoIzaje = new D_CursoIzaje();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCursoIzaje.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCursoIzaje.obtenerCatalago(estado, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CursoIzaje> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CursoIzaje> resultado = dCursoIzaje.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CursoIzaje> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CursoIzaje> resultado = dCursoIzaje.obtenerObjetos(estado, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public CursoIzaje obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            CursoIzaje resultado = dCursoIzaje.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(CursoIzaje objCursoIzaje)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCursoIzaje.actualizar(objCursoIzaje);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool anular(CursoIzaje objCursoIzaje)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCursoIzaje.anular(objCursoIzaje);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(CursoIzaje objCursoIzaje)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCursoIzaje.insertar(objCursoIzaje);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_curso_izaje"); }
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
                dCursoIzaje.Dispose();
            }
        }
        #endregion
    }
}