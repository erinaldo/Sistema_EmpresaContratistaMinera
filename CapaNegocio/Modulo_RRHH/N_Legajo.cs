using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_Legajo : ILegajo, IDisposable
    {
        #region Atributos
        private D_Legajo dLegajo = new D_Legajo();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dLegajo.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Legajo> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Legajo> resultado = dLegajo.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public Legajo obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            Legajo resultado = dLegajo.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(Legajo objLegajo)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dLegajo.actualizar(objLegajo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizarEstado(long id, bool baja, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dLegajo.actualizarEstado(id, baja, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizarSaldo(long id, double saldo, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dLegajo.actualizarSaldo(id, saldo, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(Legajo objLegajo)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dLegajo.insertar(objLegajo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_legajo"); }
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
                dLegajo.Dispose();
            }
        }
        #endregion
    }
}
