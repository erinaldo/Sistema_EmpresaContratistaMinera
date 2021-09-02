using CapaDatos;
using CapaDatos.Catalogo;
using Entidades.Catalogo;
using Interfaces.Catalogo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio.Catalogo
{
    public class N_ConceptoSueldo : IConceptoSueldo, IDisposable
    {
        #region Atributos
        private D_ConceptoSueldo dConceptoSueldo = new D_ConceptoSueldo();
        #endregion

        #region Métodos
        public List<string> obtenerListaDeElementos()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<string> resultado = dConceptoSueldo.obtenerListaDeElementos();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dConceptoSueldo.obtenerCatalago(campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<ConceptoSueldo> obtenerObjetos(string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<ConceptoSueldo> resultado = dConceptoSueldo.obtenerObjetos(campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public ConceptoSueldo obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            ConceptoSueldo resultado = dConceptoSueldo.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(ConceptoSueldo objConceptoSueldo, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dConceptoSueldo.actualizar(objConceptoSueldo, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool eliminar(long id, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dConceptoSueldo.eliminar(id, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(ConceptoSueldo objConceptoSueldo, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dConceptoSueldo.insertar(objConceptoSueldo, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("cat_concepto_sueldo"); }
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
                dConceptoSueldo.Dispose();
            }
        }
        #endregion
    }
}
