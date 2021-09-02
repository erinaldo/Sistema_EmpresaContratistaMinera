using System;

namespace Entidades
{
    public class CapacitacionLaboral : IEquatable<CapacitacionLaboral>
    {
        #region Atributos
        private long _id;
        private Legajo _legajo;
        private CentroCosto _centroCosto;
        private string _capacitador;
        private string _capacitacion;
        private DateTime _fechaEmision;
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
        public string Capacitador { get => _capacitador; set => _capacitador = value; }
        public string Capacitacion { get => _capacitacion; set => _capacitacion = value; }
        public DateTime FechaEmision { get => _fechaEmision; set => _fechaEmision = value; }
        public string Observacion { get => _observacion; set => _observacion = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public CapacitacionLaboral() { }
        public CapacitacionLaboral(long id, Legajo legajo, CentroCosto centroCosto, string capacitador, string capacitacion, DateTime fechaEmision, string observacion, string estado, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _legajo = legajo;
            _centroCosto = centroCosto;
            _capacitador = capacitador;
            _capacitacion = capacitacion;
            _fechaEmision = fechaEmision;
            _observacion = observacion;
            _estado = estado;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(CapacitacionLaboral objCapacitacionLaboral)
        {
            if (objCapacitacionLaboral != null &&
                _id == objCapacitacionLaboral._id &&
                _legajo.Id == objCapacitacionLaboral._legajo.Id &&
                _centroCosto.Id == objCapacitacionLaboral._centroCosto.Id &&
                _capacitador == objCapacitacionLaboral._capacitador &&
                _capacitacion == objCapacitacionLaboral._capacitacion &&
                _fechaEmision == objCapacitacionLaboral._fechaEmision &&
                _observacion == objCapacitacionLaboral._observacion &&
                _estado == objCapacitacionLaboral._estado) return true;
            return false;
        }
        #endregion
    }
}
