using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    static class NavegacionRRHH
    {
        public static void navegarA_Formulario(string destino, Form formularioDeOrigen, Legajo objLegajo)
        {
             if (objLegajo != null) objLegajo = new N_Legajo().obtenerObjeto("ID", Convert.ToString(objLegajo.Id)); //Importante: Re-Obtiene los valores del Objeto recibido ante cualquier modificación sufrida
            if (destino == "CURRICULUM_VITAE") { Formulario.AbrirFormularioHermano(formularioDeOrigen, new FormLegajoCurriculumVitae(objLegajo)); }
            else if (destino == "DOCUMENTACION") { Formulario.AbrirFormularioHermano(formularioDeOrigen, new FormLegajoDocumentacion(objLegajo)); }
            else if (destino == "LABORAL") { Formulario.AbrirFormularioHermano(formularioDeOrigen, new FormLegajoLaboral(objLegajo)); }
            else if (destino == "PERSONAL") { Formulario.AbrirFormularioHermano(formularioDeOrigen, new FormLegajo(objLegajo)); }
            else if (destino == "TALLES") { Formulario.AbrirFormularioHermano(formularioDeOrigen, new FormLegajoTalle(objLegajo)); }
            else if (destino == "CAPACITACION") { Formulario.AbrirFormularioHermano(formularioDeOrigen, new FormCapacitacionLaboral(objLegajo, true)); }
            else if (destino == "ENTREVISTA") { Formulario.AbrirFormularioHermano(formularioDeOrigen, new FormEntrevista(objLegajo, true)); }
            else if (destino == "NOVEDAD") { Formulario.AbrirFormularioHermano(formularioDeOrigen, new FormNovedadNomina(objLegajo, true)); }
            else if (destino == "CONTRATO") { Formulario.AbrirFormularioHermano(formularioDeOrigen, new FormContrato(objLegajo, true)); }
            else if (destino == "CURSO_INDUCCION") { Formulario.AbrirFormularioHermano(formularioDeOrigen, new FormCursoInduccion(objLegajo, true)); }
            else if (destino == "CURSO_IZAJE") { Formulario.AbrirFormularioHermano(formularioDeOrigen, new FormCursoIzaje(objLegajo, true)); }
            else if (destino == "EXAMEN_MEDICO") { Formulario.AbrirFormularioHermano(formularioDeOrigen, new FormExamenMedico(objLegajo, true)); }
            else if (destino == "PAGO") { Formulario.AbrirFormularioHermano(formularioDeOrigen, new FormPagoNomina(objLegajo, true)); }
            else if (destino == "SUELDO") { Formulario.AbrirFormularioHermano(formularioDeOrigen, new FormSueldo(objLegajo, true)); }
        }
    }
}
