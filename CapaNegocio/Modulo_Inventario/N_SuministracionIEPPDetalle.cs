using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_SuministracionIEPPDetalle : ISuministracionIEPPDetalle, IDisposable
    {
        #region Atributos
        private D_SuministracionIEPPDetalle dSuministracionIEPPDetalle = new D_SuministracionIEPPDetalle();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dSuministracionIEPPDetalle.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<SuministracionIEPPDetalle> obtenerObjetos(long idSuministracionIEPP)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<SuministracionIEPPDetalle> resultado = dSuministracionIEPPDetalle.obtenerObjetos(idSuministracionIEPP);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<SuministracionIEPPDetalle> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<SuministracionIEPPDetalle> resultado = dSuministracionIEPPDetalle.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public SuministracionIEPPDetalle obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            SuministracionIEPPDetalle resultado = dSuministracionIEPPDetalle.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(SuministracionIEPPDetalle objSuministracionIEPPDetalle, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dSuministracionIEPPDetalle.insertar(objSuministracionIEPPDetalle, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_suministracion_iepp_detalle"); }
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
                dSuministracionIEPPDetalle.Dispose();
            }
        }
        #endregion
    }
}
