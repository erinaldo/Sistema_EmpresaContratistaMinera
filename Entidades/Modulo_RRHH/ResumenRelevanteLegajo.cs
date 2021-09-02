using System;

namespace Entidades
{
    public class ResumenRelevanteLegajo
    {
        #region Atributos
        private Legajo _legajo;
        private string _estadoLaboral;
        private CentroCosto _centroCosto;
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
        public string EstadoLaboral { get => _estadoLaboral; set => _estadoLaboral = value; }
        public CentroCosto CentroCosto { get => _centroCosto; set => _centroCosto = value; }
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
        public ResumenRelevanteLegajo() { }
        public ResumenRelevanteLegajo(Legajo legajo, string estadoLaboral, CentroCosto centroCosto, DateTime certificadoAntecedenteVto, string certificadoAntecedenteTipo, DateTime licenciaConducirVto, DateTime cursoInduccionVto, string cursoInduccionEvaluacion, DateTime cursoIzajeVto, DateTime examenMedicoVto, string examenMedicoTipo, string examenMedicoEvaluacion)
        {
            _legajo = legajo;
            _estadoLaboral = estadoLaboral;
            _centroCosto = centroCosto;
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