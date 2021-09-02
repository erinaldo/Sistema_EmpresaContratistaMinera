using System;

namespace Entidades
{
    public class CursoInduccion : IEquatable<CursoInduccion>
    {
        #region Atributos
        private long _id;
        private Legajo _legajo;
        private CentroCosto _centroCosto;
        private DateTime _fechaEmision;
        private bool _fechaEmisionAlertado;
        private string _evaluacion;
        private string _observacion;
        private string _estado;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public Legajo Legajo { get => _legajo; set => _legajo = value; }
        public CentroCosto CentroCosto { get => _centroCosto; set => _centroCosto = value; }
        public DateTime FechaEmision { get => _fechaEmision; set => _fechaEmision = value; }
        public bool FechaEmisionAlertado { get => _fechaEmisionAlertado; set => _fechaEmisionAlertado = value; }
        public string Evaluacion { get => _evaluacion; set => _evaluacion = value; }
        public string Observacion { get => _observacion; set => _observacion = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public CursoInduccion() { }
        public CursoInduccion(long id, Legajo legajo, CentroCosto centroCosto, DateTime fechaEmision, bool fechaEmisionAlertado, string evaluacion, string observacion, string estado, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _legajo = legajo;
            _centroCosto = centroCosto;
            _fechaEmision = fechaEmision;
            _fechaEmisionAlertado = fechaEmisionAlertado;
            _evaluacion = evaluacion;
            _observacion = observacion;
            _estado = estado;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(CursoInduccion objCursoInduccion)
        {
            if (objCursoInduccion != null &&
                _id == objCursoInduccion._id &&
                _legajo.Id == objCursoInduccion._legajo.Id &&
                _centroCosto.Id == objCursoInduccion._centroCosto.Id &&
                _fechaEmision == objCursoInduccion._fechaEmision &&
                _fechaEmisionAlertado == objCursoInduccion._fechaEmisionAlertado &&
                _evaluacion == objCursoInduccion._evaluacion &&
                _observacion == objCursoInduccion._observacion &&
                _estado == objCursoInduccion._estado) return true;
            return false;
        }
        #endregion
    }
}
