using CapaDatos.Sistema;
using Interfaces.Sistema;
using System;
using System.Windows.Forms;

namespace CapaNegocio.Sistema
{
    public class N_Monitor : IMonitor, IDisposable
    {
        #region Atributos
        private D_Monitor dMonitor = new D_Monitor();
        #endregion

        #region Métodos
        public bool monitorearAlertas()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dMonitor.monitorearAlertas();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool monitorearAlertasDeArticulo()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dMonitor.monitorearAlertasDeArticulo();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool monitorearAlertasDeAntecedentes()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dMonitor.monitorearAlertasDeAntecedentes();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool monitorearAlertasDeCobro()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dMonitor.monitorearAlertasDeCobro();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool monitorearAlertasDeCursoInduccion()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dMonitor.monitorearAlertasDeCursoInduccion();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool monitorearAlertasDeCursoIzaje()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dMonitor.monitorearAlertasDeCursoIzaje();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool monitorearAlertasDeEntrevista()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dMonitor.monitorearAlertasDeEntrevista();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool monitorearAlertasDeExamenMedico()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dMonitor.monitorearAlertasDeExamenMedico();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool monitorearAlertasDeLicenciaConducir()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dMonitor.monitorearAlertasDeLicenciaConducir();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool monitorearAlertasDePago()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dMonitor.monitorearAlertasDePago();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool monitorearEstados()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dMonitor.monitorearEstados();
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
                dMonitor.Dispose();
            }
        }
        #endregion
    }
}
