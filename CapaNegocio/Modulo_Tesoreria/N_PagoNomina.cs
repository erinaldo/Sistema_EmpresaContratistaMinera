using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_PagoNomina : IPagoNomina, IDisposable
    {
        #region Atributos
        private D_PagoNomina dPagoNomina = new D_PagoNomina();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dPagoNomina.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dPagoNomina.obtenerCatalago(estado, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<PagoNomina> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<PagoNomina> resultado = dPagoNomina.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<PagoNomina> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<PagoNomina> resultado = dPagoNomina.obtenerObjetos(estado, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public PagoNomina obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            PagoNomina resultado = dPagoNomina.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(PagoNomina objPagoNomina)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPagoNomina.actualizar(objPagoNomina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool anular(PagoNomina objPagoNomina)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPagoNomina.anular(objPagoNomina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(PagoNomina objPagoNomina)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPagoNomina.insertar(objPagoNomina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_pago_nomina"); }
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
                dPagoNomina.Dispose();
            }
        }
        #endregion
    }
}