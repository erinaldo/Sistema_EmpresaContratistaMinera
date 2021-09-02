using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_Cobranza : ICobranza, IDisposable
    {
        #region Atributos
        private D_Cobranza dCobranza = new D_Cobranza();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCobranza.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCobranza.obtenerCatalago(estado, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Cobranza> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Cobranza> resultado = dCobranza.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Cobranza> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Cobranza> resultado = dCobranza.obtenerObjetos(estado, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public Cobranza obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            Cobranza resultado = dCobranza.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(Cobranza objCobranza)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCobranza.actualizar(objCobranza);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool anular(Cobranza objCobranza)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCobranza.anular(objCobranza);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(Cobranza objCobranza)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCobranza.insertar(objCobranza);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_cobranza"); }
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
                dCobranza.Dispose();
            }
        }
        #endregion
    }
}
