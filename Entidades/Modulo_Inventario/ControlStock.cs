using System;

namespace Entidades
{
    public class ControlStock
    {
        #region Atributos
        private long _id;
        private DateTime _fecha;
        private string _estado;
        private string _deposito;
        private string _observacion;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Deposito { get => _deposito; set => _deposito = value; }
        public string Observacion { get => _observacion; set => _observacion = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public ControlStock() { }
        public ControlStock(long id, DateTime fecha, string estado, string deposito, string observacion, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _fecha = fecha;
            _estado = estado;
            _deposito = deposito;
            _observacion = observacion;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion
    }
}