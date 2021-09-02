using CapaDatos;
using CapaDatos.Catalogo;
using Entidades.Catalogo;
using Interfaces.Catalogo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio.Catalogo
{
    public class N_Banco : IBanco, IDisposable
    {
        #region Atributos
        private D_Banco dBanco = new D_Banco();
        #endregion

        #region Métodos
        public List<string> obtenerListaDeElementos()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<string> resultado = dBanco.obtenerListaDeElementos();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dBanco.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Banco> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Banco> resultado = dBanco.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public Banco obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            Banco resultado = dBanco.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(Banco objBanco, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dBanco.actualizar(objBanco, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool eliminar(long id, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dBanco.eliminar(id, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(Banco objBanco, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dBanco.insertar(objBanco, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("cat_banco");}
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
                dBanco.Dispose();
            }
        }
        #endregion
    }
}
