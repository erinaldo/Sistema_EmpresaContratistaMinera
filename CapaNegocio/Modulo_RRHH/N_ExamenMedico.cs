using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_ExamenMedico : IExamenMedico, IDisposable
    {
        #region Atributos
        private D_ExamenMedico dExamenMedico = new D_ExamenMedico();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dExamenMedico.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dExamenMedico.obtenerCatalago(estado, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<ExamenMedico> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<ExamenMedico> resultado = dExamenMedico.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<ExamenMedico> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<ExamenMedico> resultado = dExamenMedico.obtenerObjetos(estado, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public ExamenMedico obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            ExamenMedico resultado = dExamenMedico.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(ExamenMedico objExamenMedico)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dExamenMedico.actualizar(objExamenMedico);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool anular(ExamenMedico objExamenMedico)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dExamenMedico.anular(objExamenMedico);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(ExamenMedico objExamenMedico)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dExamenMedico.insertar(objExamenMedico);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_examen_medico"); }
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
                dExamenMedico.Dispose();
            }
        }
        #endregion
    }
}