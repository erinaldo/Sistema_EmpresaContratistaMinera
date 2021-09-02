using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_FormularioR29911Detalle : IFormularioR29911Detalle, IDisposable
    {
        #region Atributos
        private D_FormularioR29911Detalle dFormularioR29911Detalle = new D_FormularioR29911Detalle();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dFormularioR29911Detalle.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<FormularioR29911Detalle> obtenerObjetos(long idFormularioR29911)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<FormularioR29911Detalle> resultado = dFormularioR29911Detalle.obtenerObjetos(idFormularioR29911);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<FormularioR29911Detalle> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<FormularioR29911Detalle> resultado = dFormularioR29911Detalle.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public FormularioR29911Detalle obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            FormularioR29911Detalle resultado = dFormularioR29911Detalle.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(FormularioR29911Detalle objFormularioR29911Detalle, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dFormularioR29911Detalle.insertar(objFormularioR29911Detalle, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_formulario_r29911_detalle"); }
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
                dFormularioR29911Detalle.Dispose();
            }
        }
        #endregion
    }
}
