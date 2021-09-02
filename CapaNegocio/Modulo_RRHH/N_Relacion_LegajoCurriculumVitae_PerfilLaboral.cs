using CapaDatos;
using Entidades;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_Relacion_LegajoCurriculumVitae_PerfilLaboral : IRelacion_LegajoCurriculumVitae_PerfilLaboral, IDisposable
    {
        #region Atributos
        private D_Relacion_LegajoCurriculumVitae_PerfilLaboral dRelacion_LegajoCurriculumVitae_PerfilLaboral = new D_Relacion_LegajoCurriculumVitae_PerfilLaboral();
        #endregion

        #region Métodos
        public string obtenerElementos(long idLegajo)
        {
            Cursor.Current = Cursors.WaitCursor;
            string resultado = dRelacion_LegajoCurriculumVitae_PerfilLaboral.obtenerElementos(idLegajo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<string> obtenerListaDeElementos(long idLegajo)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<string> resultado = dRelacion_LegajoCurriculumVitae_PerfilLaboral.obtenerListaDeElementos(idLegajo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Relacion_LegajoCurriculumVitae_PerfilLaboral> obtenerObjetos(long idLegajo)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Relacion_LegajoCurriculumVitae_PerfilLaboral> resultado = dRelacion_LegajoCurriculumVitae_PerfilLaboral.obtenerObjetos(idLegajo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public Relacion_LegajoCurriculumVitae_PerfilLaboral obtenerObjeto(long id, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            Relacion_LegajoCurriculumVitae_PerfilLaboral resultado = dRelacion_LegajoCurriculumVitae_PerfilLaboral.obtenerObjeto(id, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool asociar_PerfilesTemporales(long idLegajoTemporal, long idLegajoDefinitivo)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dRelacion_LegajoCurriculumVitae_PerfilLaboral.asociar_PerfilesTemporales(idLegajoTemporal, idLegajoDefinitivo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool eliminar(long id, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dRelacion_LegajoCurriculumVitae_PerfilLaboral.eliminar(id, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool eliminar_PerfilesLegajoles(long idLegajo)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dRelacion_LegajoCurriculumVitae_PerfilLaboral.eliminar_PerfilesLegajoles(idLegajo);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool eliminar_PerfilesTemporales()
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dRelacion_LegajoCurriculumVitae_PerfilLaboral.eliminar_PerfilesTemporales();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(Relacion_LegajoCurriculumVitae_PerfilLaboral objRelacion_LegajoCurriculumVitae_PerfilLaboral, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dRelacion_LegajoCurriculumVitae_PerfilLaboral.insertar(objRelacion_LegajoCurriculumVitae_PerfilLaboral, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("relation_curriculum_vitae__perfil_laboral"); }
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
                dRelacion_LegajoCurriculumVitae_PerfilLaboral.Dispose();
            }
        }
        #endregion
    }
}