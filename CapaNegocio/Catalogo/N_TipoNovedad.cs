using CapaDatos;
using CapaDatos.Catalogo;
using Entidades.Catalogo;
using Interfaces.Catalogo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio.Catalogo
{
    public class N_TipoNovedad : ITipoNovedad, IDisposable
    {
        #region Atributos
        private D_TipoNovedad dTipoNovedad = new D_TipoNovedad();
        #endregion

        #region Métodos
        public List<string> obtenerListaDeElementos()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<string> resultado = dTipoNovedad.obtenerListaDeElementos();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dTipoNovedad.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<TipoNovedad> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<TipoNovedad> resultado = dTipoNovedad.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public TipoNovedad obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            TipoNovedad resultado = dTipoNovedad.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(TipoNovedad objTipoNovedad, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dTipoNovedad.actualizar(objTipoNovedad, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool eliminar(long id, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dTipoNovedad.eliminar(id, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(TipoNovedad objTipoNovedad, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dTipoNovedad.insertar(objTipoNovedad, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("cat_novedad_nomina"); }
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
                dTipoNovedad.Dispose();
            }
        }
        #endregion
    }
}
