using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_Sindicato : ISindicato, IDisposable
    {
        #region Atributos
        private D_Sindicato dSindicato = new D_Sindicato();
        #endregion

        #region Métodos
        public List<string> obtenerListaDeElementos(string[] deposito)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<string> resultado = dSindicato.obtenerListaDeElementos(deposito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dSindicato.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Sindicato> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Sindicato> resultado = dSindicato.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public Sindicato obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            Sindicato resultado = dSindicato.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(Sindicato objSindicato)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dSindicato.actualizar(objSindicato);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(Sindicato objSindicato)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dSindicato.insertar(objSindicato);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_sindicato"); }
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
                dSindicato.Dispose();
            }
        }
        #endregion
    }
}