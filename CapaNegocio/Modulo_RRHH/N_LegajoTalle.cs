using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_LegajoTalle : ILegajoTalle, IDisposable
    {
        #region Atributos
        private D_LegajoTalle dLegajoTalle = new D_LegajoTalle();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dLegajoTalle.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<LegajoTalle> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<LegajoTalle> resultado = dLegajoTalle.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public LegajoTalle obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            LegajoTalle resultado = dLegajoTalle.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(LegajoTalle objLegajoTalle)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dLegajoTalle.actualizar(objLegajoTalle);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(LegajoTalle objLegajoTalle)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dLegajoTalle.insertar(objLegajoTalle);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_legajo_talle"); }
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
                dLegajoTalle.Dispose();
            }
        }
        #endregion
    }
}
