using CapaDatos;
using CapaDatos.Catalogo;
using Entidades.Catalogo;
using Interfaces.Catalogo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio.Catalogo
{
    public class N_CategoriaTrabajo : ICategoriaTrabajo, IDisposable
    {
        #region Atributos
        private D_CategoriaTrabajo dCategoriaTrabajo = new D_CategoriaTrabajo();
        #endregion

        #region Métodos
        public List<string> obtenerListaDeElementos()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<string> resultado = dCategoriaTrabajo.obtenerListaDeElementos();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCategoriaTrabajo.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CategoriaTrabajo> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CategoriaTrabajo> resultado = dCategoriaTrabajo.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public CategoriaTrabajo obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            CategoriaTrabajo resultado = dCategoriaTrabajo.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(CategoriaTrabajo objCategoriaTrabajo, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCategoriaTrabajo.actualizar(objCategoriaTrabajo, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool eliminar(long id, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCategoriaTrabajo.eliminar(id, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(CategoriaTrabajo objCategoriaTrabajo, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCategoriaTrabajo.insertar(objCategoriaTrabajo, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("cat_categoria_trabajo"); }
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
                dCategoriaTrabajo.Dispose();
            }
        }
        #endregion
    }
}
