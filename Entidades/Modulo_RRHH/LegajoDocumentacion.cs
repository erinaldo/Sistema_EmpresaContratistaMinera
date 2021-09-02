using System;

namespace Entidades
{
    public class LegajoDocumentacion : IEquatable<LegajoDocumentacion>
    {
        #region Atributos
        private long _id;
        private Legajo _legajo;
        private bool _altaAfip;
        private bool _contrato;
        private bool _copiaCA;
        private bool _copiaDNI;
        private bool _copiaLicenciaConducir;
        private bool _copiaMatricula;
        private bool _copiaTitulo;
        private bool _credencialART;
        private bool _curriculumVitae;
        private bool _declaracionJurada;
        private bool _documentacionFamiliar;
        private bool _examenMedico;
        private bool _reglamentoRRHH;
        private bool _roles;
        private string _otraDocumentacion;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public Legajo Legajo { get => _legajo; set => _legajo = value; }
        public bool AltaAfip { get => _altaAfip; set => _altaAfip = value; }
        public bool Contrato { get => _contrato; set => _contrato = value; }
        public bool CopiaCA { get => _copiaCA; set => _copiaCA = value; }
        public bool CopiaDNI { get => _copiaDNI; set => _copiaDNI = value; }
        public bool CopiaLicenciaConducir { get => _copiaLicenciaConducir; set => _copiaLicenciaConducir = value; }
        public bool CopiaMatricula { get => _copiaMatricula; set => _copiaMatricula = value; }
        public bool CopiaTitulo { get => _copiaTitulo; set => _copiaTitulo = value; }
        public bool CredencialART { get => _credencialART; set => _credencialART = value; }
        public bool CurriculumVitae { get => _curriculumVitae; set => _curriculumVitae = value; }
        public bool DeclaracionJurada { get => _declaracionJurada; set => _declaracionJurada = value; }
        public bool DocumentacionFamiliar { get => _documentacionFamiliar; set => _documentacionFamiliar = value; }
        public bool ExamenMedico { get => _examenMedico; set => _examenMedico = value; }
        public bool ReglamentoRRHH { get => _reglamentoRRHH; set => _reglamentoRRHH = value; }
        public bool Roles { get => _roles; set => _roles = value; }
        public string OtraDocumentacion { get => _otraDocumentacion; set => _otraDocumentacion = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public LegajoDocumentacion() { }
        public LegajoDocumentacion(long id, Legajo legajo, bool altaAfip, bool contrato, bool copiaCA, bool copiaDNI, bool copiaLicenciaConducir, bool copiaMatricula, bool copiaTitulo, bool credencialART, bool curriculumVitae, bool declaracionJurada, bool documentacionFamiliar, bool examenMedico, bool reglamentoRRHH, bool roles, string otraDocumentacion, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _legajo = legajo;
            _altaAfip = altaAfip;
            _contrato = contrato;
            _copiaCA = copiaCA;
            _copiaDNI = copiaDNI;
            _copiaLicenciaConducir = copiaLicenciaConducir;
            _copiaMatricula = copiaMatricula;
            _copiaTitulo = copiaTitulo;
            _credencialART = credencialART;
            _curriculumVitae = curriculumVitae;
            _declaracionJurada = declaracionJurada;
            _documentacionFamiliar = documentacionFamiliar;
            _examenMedico = examenMedico;
            _reglamentoRRHH = reglamentoRRHH;
            _roles = roles;
            _otraDocumentacion = otraDocumentacion;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(LegajoDocumentacion objLegajoDocumentacion)
        {
            if (objLegajoDocumentacion != null &&
                _id == objLegajoDocumentacion._id &&
                _legajo.Id == objLegajoDocumentacion._legajo.Id &&
                _altaAfip == objLegajoDocumentacion._altaAfip &&
                _contrato == objLegajoDocumentacion._contrato &&
                _copiaCA == objLegajoDocumentacion._copiaCA &&
                _copiaDNI == objLegajoDocumentacion._copiaDNI &&
                _copiaLicenciaConducir == objLegajoDocumentacion._copiaLicenciaConducir &&
                _copiaMatricula == objLegajoDocumentacion._copiaMatricula &&
                _copiaTitulo == objLegajoDocumentacion._copiaTitulo &&
                _credencialART == objLegajoDocumentacion._credencialART &&
                _curriculumVitae == objLegajoDocumentacion._curriculumVitae &&
                _declaracionJurada == objLegajoDocumentacion._declaracionJurada &&
                _documentacionFamiliar == objLegajoDocumentacion._documentacionFamiliar &&
                _examenMedico == objLegajoDocumentacion._examenMedico &&
                _reglamentoRRHH == objLegajoDocumentacion._reglamentoRRHH &&
                _roles == objLegajoDocumentacion._roles &&
                _otraDocumentacion == objLegajoDocumentacion._otraDocumentacion) return true;
            return false;
        }
        #endregion
    }
}
