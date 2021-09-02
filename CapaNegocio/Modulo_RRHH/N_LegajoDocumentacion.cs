using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_LegajoDocumentacion : ILegajoDocumentacion, IDisposable
    {
        #region Atributos
        private D_LegajoDocumentacion dLegajoDocumentacion = new D_LegajoDocumentacion();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dLegajoDocumentacion.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<LegajoDocumentacion> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<LegajoDocumentacion> resultado = dLegajoDocumentacion.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public LegajoDocumentacion obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            LegajoDocumentacion resultado = dLegajoDocumentacion.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(LegajoDocumentacion objLegajoDocumentacion)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dLegajoDocumentacion.actualizar(objLegajoDocumentacion);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(LegajoDocumentacion objLegajoDocumentacion)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dLegajoDocumentacion.insertar(objLegajoDocumentacion);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_legajo_documentacion"); }
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
                dLegajoDocumentacion.Dispose();
            }
        }
        #endregion
    }
}
