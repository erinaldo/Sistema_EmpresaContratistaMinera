using System;

namespace Entidades
{
    public class MovimientoStock
    {
        #region Atributos
        private long _id;
        private DateTime _fecha;
        private string _estado;
        private string _depositoOrigen;
        private string _depositoDestino;
        private DateTime _fechaArribo;
        private string _observacion;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string DepositoOrigen { get => _depositoOrigen; set => _depositoOrigen = value; }
        public string DepositoDestino { get => _depositoDestino; set => _depositoDestino = value; }
        public DateTime FechaArribo { get => _fechaArribo; set => _fechaArribo = value; }
        public string Observacion { get => _observacion; set => _observacion = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public MovimientoStock() { }
        public MovimientoStock(long id, DateTime fecha, string estado, string depositoOrigen, string depositoDestino, DateTime fechaArribo, string observacion, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _fecha = fecha;
            _estado = estado;
            _depositoOrigen = depositoOrigen;
            _depositoDestino = depositoDestino;
            _fechaArribo = fechaArribo;
            _observacion = observacion;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion
    }
}