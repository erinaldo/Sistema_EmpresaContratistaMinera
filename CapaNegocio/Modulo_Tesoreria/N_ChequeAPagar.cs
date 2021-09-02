using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_ChequeAPagar: IChequeAPagar, IDisposable
    {
        #region Atributos
        private D_ChequeAPagar dChequeAPagar = new D_ChequeAPagar();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dChequeAPagar.obtenerCatalago(desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<ChequeAPagar> obtenerObjetos(DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<ChequeAPagar> resultado = dChequeAPagar.obtenerObjetos(desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public double obtenerDeudaAProveedor(DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            double resultado = dChequeAPagar.obtenerDeudaAProveedor(desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public double obtenerDeudaANomina(DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            double resultado = dChequeAPagar.obtenerDeudaANomina(desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public double obtenerDeudaAOtro(DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            double resultado = dChequeAPagar.obtenerDeudaAOtro(desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public double obtenerDeudaAMovimiento(DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            double resultado = dChequeAPagar.obtenerDeudaAMovimiento(desde, hasta);
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
                dChequeAPagar.Dispose();
            }
        }
        #endregion
    }
}
