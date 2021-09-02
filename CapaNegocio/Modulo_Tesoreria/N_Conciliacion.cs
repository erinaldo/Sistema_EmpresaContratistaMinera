using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_Conciliacion : IConciliacion, IDisposable
    {
        #region Atributos
        private D_Conciliacion dConciliacion = new D_Conciliacion();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estadoConciliacion, long idCuentaContable, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dConciliacion.obtenerCatalago(estadoConciliacion, idCuentaContable, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public Conciliacion obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            Conciliacion resultado = dConciliacion.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool conciliar(List<Conciliacion> lista, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dConciliacion.conciliar(lista, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool desconciliar(List<Conciliacion> lista, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dConciliacion.desconciliar(lista, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public double[] contabilizarDebeHaber(long idCuentaContable)
        {
            Cursor.Current = Cursors.WaitCursor;
            double[] resultado = dConciliacion.contabilizarDebeHaber(idCuentaContable);
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
                dConciliacion.Dispose();
            }
        }
        #endregion
    }
}
