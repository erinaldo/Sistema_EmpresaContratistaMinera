using CapaDatos;
using CapaDatos.Catalogo;
using Entidades.Catalogo;
using Interfaces.Catalogo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio.Catalogo
{
    public class N_PerfilLaboral : IPerfilLaboral, IDisposable
    {
        #region Atributos
        private D_PerfilLaboral dPerfilLaboral = new D_PerfilLaboral();
        #endregion

        #region Métodos
        public List<string> obtenerListaDeElementos()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<string> resultado = dPerfilLaboral.obtenerListaDeElementos();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<PerfilLaboral> obtenerObjetos()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<PerfilLaboral> resultado = dPerfilLaboral.obtenerObjetos();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public PerfilLaboral obtenerObjeto(string denominacion, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            PerfilLaboral resultado = dPerfilLaboral.obtenerObjeto(denominacion, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public PerfilLaboral obtenerObjeto(long id, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            PerfilLaboral resultado = dPerfilLaboral.obtenerObjeto(id, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(PerfilLaboral objPerfilLaboral, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPerfilLaboral.actualizar(objPerfilLaboral, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool eliminar(long id, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPerfilLaboral.eliminar(id, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(PerfilLaboral objPerfilLaboral, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPerfilLaboral.insertar(objPerfilLaboral, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("cat_perfil_laboral"); }
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
                dPerfilLaboral.Dispose();
            }
        }
        #endregion
    }
}