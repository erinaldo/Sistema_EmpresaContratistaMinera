using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_CapacitacionLaboral : ICapacitacionLaboral, IDisposable
    {
        #region Atributos
        private D_CapacitacionLaboral dCapacitacionLaboral = new D_CapacitacionLaboral();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCapacitacionLaboral.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCapacitacionLaboral.obtenerCatalago(estado, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CapacitacionLaboral> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CapacitacionLaboral> resultado = dCapacitacionLaboral.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CapacitacionLaboral> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CapacitacionLaboral> resultado = dCapacitacionLaboral.obtenerObjetos(estado, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public CapacitacionLaboral obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            CapacitacionLaboral resultado = dCapacitacionLaboral.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(CapacitacionLaboral objCapacitacionLaboral)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCapacitacionLaboral.actualizar(objCapacitacionLaboral);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool anular(CapacitacionLaboral objCapacitacionLaboral)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCapacitacionLaboral.anular(objCapacitacionLaboral);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(CapacitacionLaboral objCapacitacionLaboral)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCapacitacionLaboral.insertar(objCapacitacionLaboral);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_capacitacion_laboral"); }
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
                dCapacitacionLaboral.Dispose();
            }
        }
        #endregion
    }
}