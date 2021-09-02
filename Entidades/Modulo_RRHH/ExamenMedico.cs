using System;

namespace Entidades
{
    public class ExamenMedico : IEquatable<ExamenMedico>
    {
        #region Atributos
        private long _id;
        private Legajo _legajo;
        private string _institucion;
        private string _tipoExamen;
        private DateTime _examenEmision;
        private bool _examenAlertado;
        private bool _evaluacionRespirador;
        private DateTime _evaluacionRespiradorEmision;
        private DateTime _evaluacionRespiradorVto;
        private bool _caraCompleta;
        private DateTime _caraCompletaPrueba;
        private string _caraCompletaMarca;
        private string _caraCompletaModelo;
        private string _caraCompletaTamanio;
        private bool _mediaCara;
        private DateTime _mediaCaraPrueba;
        private string _mediaCaraMarca;
        private string _mediaCaraModelo;
        private string _mediaCaraTamanio;
        private string _observacion;
        private string _evaluacionMedica;
        private string _estado;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public Legajo Legajo { get => _legajo; set => _legajo = value; }
        public string Institucion { get => _institucion; set => _institucion = value; }
        public string TipoExamen { get => _tipoExamen; set => _tipoExamen = value; }
        public DateTime ExamenEmision { get => _examenEmision; set => _examenEmision = value; }
        public bool ExamenAlertado { get => _examenAlertado; set => _examenAlertado = value; }
        public bool EvaluacionRespirador { get => _evaluacionRespirador; set => _evaluacionRespirador = value; }
        public DateTime EvaluacionRespiradorEmision { get => _evaluacionRespiradorEmision; set => _evaluacionRespiradorEmision = value; }
        public DateTime EvaluacionRespiradorVto { get => _evaluacionRespiradorVto; set => _evaluacionRespiradorVto = value; }
        public bool CaraCompleta { get => _caraCompleta; set => _caraCompleta = value; }
        public DateTime CaraCompletaPrueba { get => _caraCompletaPrueba; set => _caraCompletaPrueba = value; }
        public string CaraCompletaMarca { get => _caraCompletaMarca; set => _caraCompletaMarca = value; }
        public string CaraCompletaModelo { get => _caraCompletaModelo; set => _caraCompletaModelo = value; }
        public string CaraCompletaTamanio { get => _caraCompletaTamanio; set => _caraCompletaTamanio = value; }
        public bool MediaCara { get => _mediaCara; set => _mediaCara = value; }
        public DateTime MediaCaraPrueba { get => _mediaCaraPrueba; set => _mediaCaraPrueba = value; }
        public string MediaCaraMarca { get => _mediaCaraMarca; set => _mediaCaraMarca = value; }
        public string MediaCaraModelo { get => _mediaCaraModelo; set => _mediaCaraModelo = value; }
        public string MediaCaraTamanio { get => _mediaCaraTamanio; set => _mediaCaraTamanio = value; }
        public string Observacion { get => _observacion; set => _observacion = value; }
        public string EvaluacionMedica { get => _evaluacionMedica; set => _evaluacionMedica = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public ExamenMedico() { }
        public ExamenMedico(long id, Legajo legajo, string institucion, string tipoExamen, DateTime examenEmision, bool examenAlertado, bool evaluacionRespirador, DateTime evaluacionRespiradorEmision, DateTime evaluacionRespiradorVto, bool caraCompleta, DateTime caraCompletaPrueba, string caraCompletaMarca, string caraCompletaModelo, string caraCompletaTamanio, bool mediaCara, DateTime mediaCaraPrueba, string mediaCaraMarca, string mediaCaraModelo, string mediaCaraTamanio, string observacion, string evaluacionMedica, string estado, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _legajo = legajo;
            _institucion = institucion;
            _tipoExamen = tipoExamen;
            _examenEmision = examenEmision;
            _examenAlertado = examenAlertado;
            _evaluacionRespirador = evaluacionRespirador;
            _evaluacionRespiradorEmision = evaluacionRespiradorEmision;
            _evaluacionRespiradorVto = evaluacionRespiradorVto;
            _caraCompleta = caraCompleta;
            _caraCompletaPrueba = caraCompletaPrueba;
            _caraCompletaMarca = caraCompletaMarca;
            _caraCompletaModelo = caraCompletaModelo;
            _caraCompletaTamanio = caraCompletaTamanio;
            _mediaCara = mediaCara;
            _mediaCaraPrueba = mediaCaraPrueba;
            _mediaCaraMarca = mediaCaraMarca;
            _mediaCaraModelo = mediaCaraModelo;
            _mediaCaraTamanio = mediaCaraTamanio;
            _observacion = observacion;
            _evaluacionMedica = evaluacionMedica;
            _estado = estado;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(ExamenMedico objExamenMedico)
        {
            if (objExamenMedico != null &&
                _id == objExamenMedico._id &&
                _legajo.Id == objExamenMedico._legajo.Id &&
                _institucion == objExamenMedico._institucion &&
                _tipoExamen == objExamenMedico._tipoExamen &&
                _examenEmision == objExamenMedico._examenEmision &&
                _examenAlertado == objExamenMedico._examenAlertado &&
                _evaluacionRespirador == objExamenMedico._evaluacionRespirador &&
                _evaluacionRespiradorEmision == objExamenMedico._evaluacionRespiradorEmision &&
                _evaluacionRespiradorVto == objExamenMedico._evaluacionRespiradorVto &&
                _caraCompleta == objExamenMedico._caraCompleta &&
                _caraCompletaPrueba == objExamenMedico._caraCompletaPrueba &&
                _caraCompletaMarca == objExamenMedico._caraCompletaMarca &&
                _caraCompletaModelo == objExamenMedico._caraCompletaModelo &&
                _caraCompletaTamanio == objExamenMedico._caraCompletaTamanio &&
                _mediaCara == objExamenMedico._mediaCara &&
                _mediaCaraPrueba == objExamenMedico._mediaCaraPrueba &&
                _mediaCaraMarca == objExamenMedico._mediaCaraMarca &&
                _mediaCaraModelo == objExamenMedico._mediaCaraModelo &&
                _mediaCaraTamanio == objExamenMedico._mediaCaraTamanio &&
                _observacion == objExamenMedico._observacion &&
                _evaluacionMedica == objExamenMedico._evaluacionMedica &&
                _estado == objExamenMedico._estado) return true;
            return false;
        }
        #endregion
    }
}
