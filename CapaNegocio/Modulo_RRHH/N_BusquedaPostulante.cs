using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_BusquedaPostulante : IBusquedaPostulante, IDisposable
    {
        #region Atributos
        private D_BusquedaPostulante dBusquedaPostulante = new D_BusquedaPostulante();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string perfilLaboral, bool trabajoEmpreminsa, string disponibilidadCV, string calificacionCV, bool estadoCV, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dBusquedaPostulante.obtenerCatalago(perfilLaboral, trabajoEmpreminsa, disponibilidadCV, calificacionCV, estadoCV, certificadoAntecedentes, licenciaConducir, cursoInduccion, cursoIzaje, examenMedico, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<BusquedaPostulante> obtenerObjetos(string perfilLaboral, bool trabajoEmpreminsa, string disponibilidadCV, string calificacionCV, bool estadoCV, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<BusquedaPostulante> resultado = dBusquedaPostulante.obtenerObjetos(perfilLaboral, trabajoEmpreminsa, disponibilidadCV, calificacionCV, estadoCV, certificadoAntecedentes, licenciaConducir, cursoInduccion, cursoIzaje, examenMedico);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public BusquedaPostulante obtenerObjeto(long id, string perfilLaboral, bool trabajoEmpreminsa, string disponibilidadCV, string calificacionCV, bool estadoCV, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            BusquedaPostulante resultado = dBusquedaPostulante.obtenerObjeto(id, perfilLaboral, trabajoEmpreminsa, disponibilidadCV, calificacionCV, estadoCV, certificadoAntecedentes, licenciaConducir, cursoInduccion, cursoIzaje, examenMedico, notificarExito);
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
                dBusquedaPostulante.Dispose();
            }
        }
        #endregion
    }
}