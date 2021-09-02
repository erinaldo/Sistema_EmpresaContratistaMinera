using System;

namespace Entidades
{
    public class LegajoCurriculumVitae : IEquatable<LegajoCurriculumVitae>
    {
        #region Atributos
        private long _id;
        private Legajo _legajo;
        private string _modalidadAdmision;
        private string _nivelEstudio;
        private string _experiencia;
        private bool _trabajoEmpreminsa;
        private bool _licenciaConducir;
        private string _licenciaConducirCategoria;
        private string _licenciaConducirColor;
        private DateTime _licenciaConducirVto;
        private bool _licenciaConducirAlertado;
        private bool _certificadoAntecedente;
        private string _certificadoAntecedenteTipo;
        private DateTime _certificadoAntecedenteEmision;
        private bool _certificadoAntecedenteAlertado;
        private string _curriculumVitaeDisponibilidad;
        private string _curriculumVitaeCalificacion;
        private string _curriculumVitaeEstado;
        private DateTime _curriculumVitaeVto;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public Legajo Legajo { get => _legajo; set => _legajo = value; }
        public string ModalidadAdmision { get => _modalidadAdmision; set => _modalidadAdmision = value; }
        public string NivelEstudio { get => _nivelEstudio; set => _nivelEstudio = value; }
        public string Experiencia { get => _experiencia; set => _experiencia = value; }
        public bool TrabajoEmpreminsa { get => _trabajoEmpreminsa; set => _trabajoEmpreminsa = value; }
        public bool LicenciaConducir { get => _licenciaConducir; set => _licenciaConducir = value; }
        public string LicenciaConducirCategoria { get => _licenciaConducirCategoria; set => _licenciaConducirCategoria = value; }
        public string LicenciaConducirColor { get => _licenciaConducirColor; set => _licenciaConducirColor = value; }
        public DateTime LicenciaConducirVto { get => _licenciaConducirVto; set => _licenciaConducirVto = value; }
        public bool LicenciaConducirAlertado { get => _licenciaConducirAlertado; set => _licenciaConducirAlertado = value; }
        public bool CertificadoAntecedente { get => _certificadoAntecedente; set => _certificadoAntecedente = value; }
        public string CertificadoAntecedenteTipo { get => _certificadoAntecedenteTipo; set => _certificadoAntecedenteTipo = value; }
        public DateTime CertificadoAntecedenteEmision { get => _certificadoAntecedenteEmision; set => _certificadoAntecedenteEmision = value; }
        public bool CertificadoAntecedenteAlertado { get => _certificadoAntecedenteAlertado; set => _certificadoAntecedenteAlertado = value; }
        public string CurriculumVitaeDisponibilidad { get => _curriculumVitaeDisponibilidad; set => _curriculumVitaeDisponibilidad = value; }
        public string CurriculumVitaeCalificacion { get => _curriculumVitaeCalificacion; set => _curriculumVitaeCalificacion = value; }
        public string CurriculumVitaeEstado { get => _curriculumVitaeEstado; set => _curriculumVitaeEstado = value; }
        public DateTime CurriculumVitaeVto { get => _curriculumVitaeVto; set => _curriculumVitaeVto = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public LegajoCurriculumVitae() { }
        public LegajoCurriculumVitae(long id, Legajo legajo, string modalidadAdmision, string nivelEstudio, string experiencia, bool trabajoEmpreminsa, bool licenciaConducir, string licenciaConducirCategoria, string licenciaConducirColor, DateTime licenciaConducirVto, bool licenciaConducirAlertado, bool certificadoAntecedente, string certificadoAntecedenteTipo, DateTime certificadoAntecedenteEmision, bool certificadoAntecedenteAlertado, string curriculumVitaeDisponibilidad, string curriculumVitaeCalificacion, string curriculumVitaeEstado, DateTime curriculumVitaeVto, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _legajo = legajo;
            _modalidadAdmision = modalidadAdmision;
            _nivelEstudio = nivelEstudio;
            _experiencia = experiencia;
            _trabajoEmpreminsa = trabajoEmpreminsa;
            _licenciaConducir = licenciaConducir;
            _licenciaConducirCategoria = licenciaConducirCategoria;
            _licenciaConducirColor = licenciaConducirColor;
            _licenciaConducirVto = licenciaConducirVto;
            _licenciaConducirAlertado = licenciaConducirAlertado;
            _certificadoAntecedente = certificadoAntecedente;
            _certificadoAntecedenteTipo = certificadoAntecedenteTipo;
            _certificadoAntecedenteEmision = certificadoAntecedenteEmision;
            _certificadoAntecedenteAlertado = certificadoAntecedenteAlertado;
            _curriculumVitaeDisponibilidad = curriculumVitaeDisponibilidad;
            _curriculumVitaeCalificacion = curriculumVitaeCalificacion;
            _curriculumVitaeEstado = curriculumVitaeEstado;
            _curriculumVitaeVto = curriculumVitaeVto;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(LegajoCurriculumVitae objLegajoCurriculumVitae)
        {
            if (objLegajoCurriculumVitae != null &&
                _id == objLegajoCurriculumVitae._id &&
                _legajo.Id == objLegajoCurriculumVitae._legajo.Id &&
                _modalidadAdmision == objLegajoCurriculumVitae._modalidadAdmision &&
                _nivelEstudio == objLegajoCurriculumVitae._nivelEstudio &&
                _experiencia == objLegajoCurriculumVitae._experiencia &&
                _trabajoEmpreminsa == objLegajoCurriculumVitae._trabajoEmpreminsa &&
                _licenciaConducir == objLegajoCurriculumVitae._licenciaConducir &&
                _licenciaConducirCategoria == objLegajoCurriculumVitae._licenciaConducirCategoria &&
                _licenciaConducirColor == objLegajoCurriculumVitae._licenciaConducirColor &&
                _licenciaConducirVto == objLegajoCurriculumVitae._licenciaConducirVto &&
                _licenciaConducirAlertado == objLegajoCurriculumVitae._licenciaConducirAlertado &&
                _certificadoAntecedente == objLegajoCurriculumVitae._certificadoAntecedente &&
                _certificadoAntecedenteTipo == objLegajoCurriculumVitae._certificadoAntecedenteTipo &&
                _certificadoAntecedenteEmision == objLegajoCurriculumVitae._certificadoAntecedenteEmision &&
                _certificadoAntecedenteAlertado == objLegajoCurriculumVitae._certificadoAntecedenteAlertado &&
                _curriculumVitaeDisponibilidad == objLegajoCurriculumVitae._curriculumVitaeDisponibilidad &&
                _curriculumVitaeCalificacion == objLegajoCurriculumVitae._curriculumVitaeCalificacion &&
                _curriculumVitaeEstado == objLegajoCurriculumVitae._curriculumVitaeEstado &&
                _curriculumVitaeVto == objLegajoCurriculumVitae._curriculumVitaeVto) return true;
            return false;
        }
        #endregion
    }
}
