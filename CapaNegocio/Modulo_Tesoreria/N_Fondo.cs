using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_Fondo: IFondo, IDisposable
    {
        #region Atributos
        private D_Fondo dFondo = new D_Fondo();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dFondo.obtenerCatalago(catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Fondo> obtenerObjetos()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Fondo> resultado = dFondo.obtenerObjetos();
            Cursor.Current = Cursors.Default;
            return resultado;
        }
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
                dFondo.Dispose();
            }
        }
        #endregion
    }
}
