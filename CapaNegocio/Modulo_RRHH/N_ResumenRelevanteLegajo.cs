using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_ResumenRelevanteLegajo : IResumenRelevanteLegajo, IDisposable
    {
        #region Atributos
        private D_ResumenRelevanteLegajo dResumenRelevanteLegajo = new D_ResumenRelevanteLegajo();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estadoLaboral, CentroCosto centroCosto, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dResumenRelevanteLegajo.obtenerCatalago(estadoLaboral, centroCosto, certificadoAntecedentes, licenciaConducir, cursoInduccion, cursoIzaje, examenMedico, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<ResumenRelevanteLegajo> obtenerObjetos(string estadoLaboral, CentroCosto centroCosto, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<ResumenRelevanteLegajo> resultado = dResumenRelevanteLegajo.obtenerObjetos(estadoLaboral, centroCosto, certificadoAntecedentes, licenciaConducir, cursoInduccion, cursoIzaje, examenMedico);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public ResumenRelevanteLegajo obtenerObjeto(long id, string estadoLaboral, CentroCosto centroCosto, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            ResumenRelevanteLegajo resultado = dResumenRelevanteLegajo.obtenerObjeto(id, estadoLaboral, centroCosto, certificadoAntecedentes, licenciaConducir, cursoInduccion, cursoIzaje, examenMedico, notificarExito);
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
                dResumenRelevanteLegajo.Dispose();
            }
        }
        #endregion
    }
}