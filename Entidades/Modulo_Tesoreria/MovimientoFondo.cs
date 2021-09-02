using System;

namespace Entidades
{
    public class MovimientoFondo : IEquatable<MovimientoFondo>
    {
        #region Atributos
        private long _id;
        private int _cbteTPV;
        private long _cbteNro;
        private DateTime _cbteFecha;
        private string _estado;
        private string _denominacion;
        private double _monto;
        private CuentaContable _cuentaContableOrigen;
        private CuentaContable _cuentaContableDestino;
        private string _medioPago;
        private long _medioNro;
        private DateTime _medioChequeVto;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public int CbteTPV { get => _cbteTPV; set => _cbteTPV = value; }
        public long CbteNro { get => _cbteNro; set => _cbteNro = value; }
        public DateTime CbteFecha { get => _cbteFecha; set => _cbteFecha = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public double Monto { get => _monto; set => _monto = value; }
        public CuentaContable CuentaContableOrigen { get => _cuentaContableOrigen; set => _cuentaContableOrigen = value; }
        public CuentaContable CuentaContableDestino { get => _cuentaContableDestino; set => _cuentaContableDestino = value; }
        public string MedioPago { get => _medioPago; set => _medioPago = value; }
        public long MedioNro { get => _medioNro; set => _medioNro = value; }
        public DateTime MedioChequeVto { get => _medioChequeVto; set => _medioChequeVto = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public MovimientoFondo() { }
        public MovimientoFondo(long id, int cbteTPV, long cbteNro, DateTime cbteFecha, string estado, string denominacion, double monto, CuentaContable cuentaContableOrigen, CuentaContable cuentaContableDestino, string medioPago, long medioNro, DateTime medioChequeVto, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _cbteTPV = cbteTPV;
            _cbteNro = cbteNro;
            _cbteFecha = cbteFecha;
            _estado = estado;
            _denominacion = denominacion;
            _monto = monto;
            _cuentaContableOrigen = cuentaContableOrigen;
            _cuentaContableDestino = cuentaContableDestino;
            _medioPago = medioPago;
            _medioNro = medioNro;
            _medioChequeVto = medioChequeVto;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(MovimientoFondo objMovimientoFondo)
        {
            if (objMovimientoFondo != null &&
                _id == objMovimientoFondo._id &&
                _cbteTPV == objMovimientoFondo._cbteTPV &&
                _cbteNro == objMovimientoFondo._cbteNro &&
                _cbteFecha.Date == objMovimientoFondo._cbteFecha.Date &&
                _estado == objMovimientoFondo._estado &&
                _denominacion == objMovimientoFondo._denominacion &&
                _monto == objMovimientoFondo._monto &&
                _cuentaContableOrigen.Id == objMovimientoFondo._cuentaContableOrigen.Id &&
                _cuentaContableDestino.Id == objMovimientoFondo._cuentaContableDestino.Id &&
                _medioPago == objMovimientoFondo._medioPago &&
                _medioNro == objMovimientoFondo._medioNro &&
                _medioChequeVto == objMovimientoFondo._medioChequeVto) return true;
            return false;
        }
        #endregion
    }
}