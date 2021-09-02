using CapaDatos;
using CapaDatos.Sistema;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio.Sistema
{
    public class N_Usuario : IUsuario, IDisposable
    {
        #region Atributos
        private D_Usuario dUsuario = new D_Usuario();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dUsuario.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Usuario> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Usuario> resultado = dUsuario.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public Usuario obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            Usuario resultado = dUsuario.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(Usuario objUsuario)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dUsuario.actualizar(objUsuario);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool eliminar(Usuario objUsuario)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dUsuario.eliminar(objUsuario);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(Usuario objUsuario)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dUsuario.insertar(objUsuario);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool iniciarSesion(string documento, string contrasenia, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dUsuario.iniciarSesion(documento, contrasenia, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool recuperarUsuario(string documento, string emailRecuperacion, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dUsuario.recuperarUsuario(documento, emailRecuperacion, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_usuario"); }
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
                dUsuario.Dispose();
            }
        }
        #endregion
    }
}
