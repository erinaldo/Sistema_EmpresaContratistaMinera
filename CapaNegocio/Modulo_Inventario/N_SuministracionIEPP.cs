using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_SuministracionIEPP : ISuministracionIEPP, IDisposable
    {
        #region Atributos
        private D_SuministracionIEPP dSuministracionIEPP = new D_SuministracionIEPP();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dSuministracionIEPP.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dSuministracionIEPP.obtenerCatalago(estado, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<SuministracionIEPP> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<SuministracionIEPP> resultado = dSuministracionIEPP.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<SuministracionIEPP> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<SuministracionIEPP> resultado = dSuministracionIEPP.obtenerObjetos(estado, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public SuministracionIEPP obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            SuministracionIEPP resultado = dSuministracionIEPP.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool anular(long id, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dSuministracionIEPP.anular(id, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(SuministracionIEPP objSuministracionIEPP, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dSuministracionIEPP.insertar(objSuministracionIEPP, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_suministracion_iepp"); }
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
                dSuministracionIEPP.Dispose();
            }
        }
        #endregion
    }
}