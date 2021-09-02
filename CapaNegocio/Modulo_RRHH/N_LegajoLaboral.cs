using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_LegajoLaboral : ILegajoLaboral, IDisposable
    {
        #region Atributos
        private D_LegajoLaboral dLegajoLaboral = new D_LegajoLaboral();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dLegajoLaboral.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dLegajoLaboral.obtenerCatalago(estado, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<LegajoLaboral> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<LegajoLaboral> resultado = dLegajoLaboral.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<LegajoLaboral> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<LegajoLaboral> resultado = dLegajoLaboral.obtenerObjetos(estado, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public LegajoLaboral obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            LegajoLaboral resultado = dLegajoLaboral.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(LegajoLaboral objLegajoLaboral)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dLegajoLaboral.actualizar(objLegajoLaboral);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizarEstado(Legajo objLegajo, string estado, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dLegajoLaboral.actualizarEstado(objLegajo, estado, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(LegajoLaboral objLegajoLaboral)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dLegajoLaboral.insertar(objLegajoLaboral);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_legajo_laboral"); }
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
                dLegajoLaboral.Dispose();
            }
        }
        #endregion
    }
}
