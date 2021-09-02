using CapaDatos;
using Entidades;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_AsientoCentroCostoRentabilidadCosto: IAsientoCentroCostoRentabilidadCosto, IDisposable
    {
        #region Atributos
        private D_AsientoCentroCostoRentabilidadCosto dAsientoCentroCostoRentabilidadCosto = new D_AsientoCentroCostoRentabilidadCosto();
        #endregion

        #region Métodos
        public List<AsientoCentroCostoRentabilidadCosto> obtenerObjetos(string centroCosto, string periodo)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<AsientoCentroCostoRentabilidadCosto> resultado = dAsientoCentroCostoRentabilidadCosto.obtenerObjetos(centroCosto, periodo);
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
                dAsientoCentroCostoRentabilidadCosto.Dispose();
            }
        }
        #endregion
    }
}
