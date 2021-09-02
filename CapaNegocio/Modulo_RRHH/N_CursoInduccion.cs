using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_CursoInduccion : ICursoInduccion, IDisposable
    {
        #region Atributos
        private D_CursoInduccion dCursoInduccion = new D_CursoInduccion();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCursoInduccion.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCursoInduccion.obtenerCatalago(estado, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CursoInduccion> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CursoInduccion> resultado = dCursoInduccion.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CursoInduccion> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CursoInduccion> resultado = dCursoInduccion.obtenerObjetos(estado, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public CursoInduccion obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            CursoInduccion resultado = dCursoInduccion.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(CursoInduccion objCursoInduccion)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCursoInduccion.actualizar(objCursoInduccion);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool anular(CursoInduccion objCursoInduccion)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCursoInduccion.anular(objCursoInduccion);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(CursoInduccion objCursoInduccion)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCursoInduccion.insertar(objCursoInduccion);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_curso_induccion"); }
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
                dCursoInduccion.Dispose();
            }
        }
        #endregion
    }
}