using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_NovedadNomina : INovedadNomina, IDisposable
    {
        #region Atributos
        private D_NovedadNomina dNovedadNomina = new D_NovedadNomina();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dNovedadNomina.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dNovedadNomina.obtenerCatalago(estado, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<NovedadNomina> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<NovedadNomina> resultado = dNovedadNomina.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<NovedadNomina> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<NovedadNomina> resultado = dNovedadNomina.obtenerObjetos(estado, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public NovedadNomina obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            NovedadNomina resultado = dNovedadNomina.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(NovedadNomina objNovedadNomina)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dNovedadNomina.actualizar(objNovedadNomina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool anular(NovedadNomina objNovedadNomina)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dNovedadNomina.anular(objNovedadNomina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(NovedadNomina objNovedadNomina)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dNovedadNomina.insertar(objNovedadNomina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool liquidar(string periodo)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dNovedadNomina.liquidar(periodo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_novedad_nomina"); }
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
                dNovedadNomina.Dispose();
            }
        }
        #endregion
    }
}