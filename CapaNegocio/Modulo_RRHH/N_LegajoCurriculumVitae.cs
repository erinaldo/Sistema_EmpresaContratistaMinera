using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_LegajoCurriculumVitae : ILegajoCurriculumVitae, IDisposable
    {
        #region Atributos
        private D_LegajoCurriculumVitae dLegajoCurriculumVitae = new D_LegajoCurriculumVitae();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dLegajoCurriculumVitae.obtenerCatalago(estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<LegajoCurriculumVitae> obtenerObjetos(string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<LegajoCurriculumVitae> resultado = dLegajoCurriculumVitae.obtenerObjetos(estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public LegajoCurriculumVitae obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            LegajoCurriculumVitae resultado = dLegajoCurriculumVitae.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(LegajoCurriculumVitae objLegajoCurriculumVitae)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dLegajoCurriculumVitae.actualizar(objLegajoCurriculumVitae);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(LegajoCurriculumVitae objLegajoCurriculumVitae)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dLegajoCurriculumVitae.insertar(objLegajoCurriculumVitae);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_legajo_curriculum_vitae"); }
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
                dLegajoCurriculumVitae.Dispose();
            }
        }
        #endregion
    }
}
