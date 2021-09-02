using System;

namespace Entidades
{
    public class BusquedaPostulante
    {
        #region Atributos
        private Legajo _legajo;
        private string _perfilLaboral;
        private bool _trabajoEmpreminsa;
        private string _curriculumVitaeDisponibilidad;
        private string _curriculumVitaeCalificacion;
        private string _curriculumVitaeEstado;
        private DateTime _certificadoAntecedenteVto;
        private string _certificadoAntecedenteTipo;
        private DateTime _licenciaConducirVto;
        private DateTime _cursoInduccionVto;
        private string _cursoInduccionEvaluacion;
        private DateTime _cursoIzajeVto;
        private DateTime _examenMedicoVto;
        private string _examenMedicoTipo;
        private string _examenMedicoEvaluacion;
        #endregion

        #region Propiedades
        public Legajo Legajo { get => _legajo; set => _legajo = value; }
        public string PerfilLaboral { get => _perfilLaboral; set => _perfilLaboral = value; }
        public bool TrabajoEmpreminsa { get => _trabajoEmpreminsa; set => _trabajoEmpreminsa = value; }
        public string CurriculumVitaeDisponibilidad { get => _curriculumVitaeDisponibilidad; set => _curriculumVitaeDisponibilidad = value; }
        public string CurriculumVitaeCalificacion { get => _curriculumVitaeCalificacion; set => _curriculumVitaeCalificacion = value; }
        public string CurriculumVitaeEstado { get => _curriculumVitaeEstado; set => _curriculumVitaeEstado = value; }
        public DateTime CertificadoAntecedenteVto { get => _certificadoAntecedenteVto; set => _certificadoAntecedenteVto = value; }
        public string CertificadoAntecedenteTipo { get => _certificadoAntecedenteTipo; set => _certificadoAntecedenteTipo = value; }
        public DateTime LicenciaConducirVto { get => _licenciaConducirVto; set => _licenciaConducirVto = value; }
        public DateTime CursoInduccionVto { get => _cursoInduccionVto; set => _cursoInduccionVto = value; }
        public string CursoInduccionEvaluacion { get => _cursoInduccionEvaluacion; set => _cursoInduccionEvaluacion = value; }
        public DateTime CursoIzajeVto { get => _cursoIzajeVto; set => _cursoIzajeVto = value; }
        public DateTime ExamenMedicoVto { get => _examenMedicoVto; set => _examenMedicoVto = value; }
        public string ExamenMedicoTipo { get => _examenMedicoTipo; set => _examenMedicoTipo = value; }
        public string ExamenMedicoEvaluacion { get => _examenMedicoEvaluacion; set => _examenMedicoEvaluacion = value; }
        #endregion

        #region Constructores
        public BusquedaPostulante() { }
        public BusquedaPostulante(Legajo legajo, string perfilLaboral, bool trabajoEmpreminsa, string curriculumVitaeDisponibilidad, string curriculumVitaeCalificacion, string curriculumVitaeEstado, DateTime certificadoAntecedenteVto, string certificadoAntecedenteTipo, DateTime licenciaConducirVto, DateTime cursoInduccionVto, string cursoInduccionEvaluacion, DateTime cursoIzajeVto, DateTime examenMedicoVto, string examenMedicoTipo, string examenMedicoEvaluacion)
        {
            _legajo = legajo;
            _perfilLaboral = perfilLaboral;
            _trabajoEmpreminsa = trabajoEmpreminsa;
            _curriculumVitaeDisponibilidad = curriculumVitaeDisponibilidad;
            _curriculumVitaeCalificacion = curriculumVitaeCalificacion;
            _curriculumVitaeEstado = curriculumVitaeEstado;
            _certificadoAntecedenteVto = certificadoAntecedenteVto;
            _certificadoAntecedenteTipo = certificadoAntecedenteTipo;
            _licenciaConducirVto = licenciaConducirVto;
            _cursoInduccionVto = cursoInduccionVto;
            _cursoInduccionEvaluacion = cursoInduccionEvaluacion;
            _cursoIzajeVto = cursoIzajeVto;
            _examenMedicoVto = examenMedicoVto;
            _examenMedicoTipo = examenMedicoTipo;
            _examenMedicoEvaluacion = examenMedicoEvaluacion;
        }
        #endregion
    }
}