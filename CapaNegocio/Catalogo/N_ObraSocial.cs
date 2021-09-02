using CapaDatos;
using CapaDatos.Catalogo;
using Entidades.Catalogo;
using Interfaces.Catalogo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio.Catalogo
{
    public class N_ObraSocial : IObraSocial, IDisposable
    {
        #region Atributos
        private D_ObraSocial dObraSocial = new D_ObraSocial();
        #endregion

        #region Métodos
        public List<string> obtenerListaDeElementos()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<string> resultado = dObraSocial.obtenerListaDeElementos();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dObraSocial.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<ObraSocial> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<ObraSocial> resultado = dObraSocial.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public ObraSocial obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            ObraSocial resultado = dObraSocial.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(ObraSocial objObraSocial, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dObraSocial.actualizar(objObraSocial, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool eliminar(long id, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dObraSocial.eliminar(id, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(ObraSocial objObraSocial, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dObraSocial.insertar(objObraSocial, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("cat_obra_social"); }
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
                dObraSocial.Dispose();
            }
        }
        #endregion
    }
}
