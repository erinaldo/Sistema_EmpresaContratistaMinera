using System;

namespace Entidades.Sistema
{
    public class Alerta
    {
        #region Atributos
        private long _id;
        private string _tipoAlerta;
        private string _denominacion;
        private DateTime _fechaVencimiento;
        private string _estado;
        private string _idNavegador;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public string TipoAlerta { get => _tipoAlerta; set => _tipoAlerta = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public DateTime FechaVencimiento { get => _fechaVencimiento; set => _fechaVencimiento = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string IdNavegador { get => _idNavegador; set => _idNavegador = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public Alerta() { }
        public Alerta(string tipoAlerta, string denominacion, DateTime fechaVencimiento, string estado, string idNavegador)
        {
            _tipoAlerta = tipoAlerta;
            _denominacion = denominacion;
            _fechaVencimiento = fechaVencimiento;
            _estado = estado;
            _idNavegador = idNavegador;
        }
        public Alerta(long id, string tipoAlerta, string denominacion, DateTime fechaVencimiento, string estado, string idNavegador, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _tipoAlerta = tipoAlerta;
            _denominacion = denominacion;
            _fechaVencimiento = fechaVencimiento;
            _estado = estado;
            _idNavegador = idNavegador;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion
    }
}
