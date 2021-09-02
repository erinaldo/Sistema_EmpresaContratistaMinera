using CapaDatos;
using CapaDatos.Sistema;
using Entidades.Sistema;
using Interfaces.Sistema;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio.Sistema
{
    public class N_Privilegio : IPrivilegio, IDisposable
    {
        #region Atributos
        private D_Privilegio dPrivilegio = new D_Privilegio();
        #endregion

        #region Métodos
        public List<long> obtenerElementos(long idUsuario)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<long> resultado = dPrivilegio.obtenerElementos(idUsuario);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Privilegio> obtenerObjetos(long idUsuario)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Privilegio> resultado = dPrivilegio.obtenerObjetos(idUsuario);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(long idUsuario, List<Privilegio> listaDePrivilegios)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPrivilegio.actualizar(idUsuario, listaDePrivilegios);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool agregarColumna(long idUsuario)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPrivilegio.agregarColumna(idUsuario);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool asociarColumna(long idUsuario, long idTemporal)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPrivilegio.asociarColumna(idUsuario, idTemporal);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool quitarColumna(long idUsuario)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPrivilegio.quitarColumna(idUsuario);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool quitarColumnas_Temporales()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPrivilegio.quitarColumnas_Temporales();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("sys_privilegio"); }
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
                dPrivilegio.Dispose();
            }
        }
        #endregion
    }
}