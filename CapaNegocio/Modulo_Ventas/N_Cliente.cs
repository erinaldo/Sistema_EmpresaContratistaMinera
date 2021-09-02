using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_Cliente : ICliente, IDisposable
    {
        #region Atributos
        private D_Cliente dCliente = new D_Cliente();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCliente.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Cliente> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Cliente> resultado = dCliente.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public Cliente obtenerObjeto(string estado, string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cliente resultado = dCliente.obtenerObjeto(estado, campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(Cliente objCliente)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCliente.actualizar(objCliente);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizarSaldo(long id, double saldo, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCliente.actualizarSaldo(id, saldo, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool eliminar(Cliente objCliente)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCliente.eliminar(objCliente);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(Cliente objCliente)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCliente.insertar(objCliente);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_cliente"); }
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
                dCliente.Dispose();
            }
        }
        #endregion
    }
}
