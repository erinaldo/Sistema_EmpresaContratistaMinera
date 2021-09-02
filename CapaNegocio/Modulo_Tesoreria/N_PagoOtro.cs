using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_PagoOtro : IPagoOtro, IDisposable
    {
        #region Atributos
        private D_PagoOtro dPagoOtro = new D_PagoOtro();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dPagoOtro.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dPagoOtro.obtenerCatalago(estado, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<PagoOtro> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<PagoOtro> resultado = dPagoOtro.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<PagoOtro> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<PagoOtro> resultado = dPagoOtro.obtenerObjetos(estado, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public PagoOtro obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            PagoOtro resultado = dPagoOtro.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(PagoOtro objPagoOtro)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPagoOtro.actualizar(objPagoOtro);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool anular(PagoOtro objPagoOtro)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPagoOtro.anular(objPagoOtro);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(PagoOtro objPagoOtro)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dPagoOtro.insertar(objPagoOtro);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_pago_otro"); }
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
                dPagoOtro.Dispose();
            }
        }
        #endregion
    }
}