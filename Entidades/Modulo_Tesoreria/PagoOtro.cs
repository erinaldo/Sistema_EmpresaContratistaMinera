using Entidades.Catalogo;
using System;

namespace Entidades
{
    public class PagoOtro : IEquatable<PagoOtro>
    {
        #region Atributos
        private long _id;
        private int _cbteTPV;
        private long _cbteNro;
        private DateTime _cbteFecha;
        private string _estado;
        private string _denominacion;
        private CentroCosto _centroCosto;
        private CuentaContable _cuentaContableDestino;
        private string _concepto;
        private double _montoPagado;
        private CuentaContable _cuentaContableOrigen;
        private string _medioPago;
        private long _medioNro;
        private DateTime _medioChequeVto;
        private Banco _banco;
        private string _ctaBancariaTipo;
        private string _ctaBancariaNro;
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
        public CentroCosto CentroCosto { get => _centroCosto; set => _centroCosto = value; }
        public CuentaContable CuentaContableDestino { get => _cuentaContableDestino; set => _cuentaContableDestino = value; }
        public string Concepto { get => _concepto; set => _concepto = value; }
        public double MontoPagado { get => _montoPagado; set => _montoPagado = value; }
        public CuentaContable CuentaContableOrigen { get => _cuentaContableOrigen; set => _cuentaContableOrigen = value; }
        public string MedioPago { get => _medioPago; set => _medioPago = value; }
        public long MedioNro { get => _medioNro; set => _medioNro = value; }
        public DateTime MedioChequeVto { get => _medioChequeVto; set => _medioChequeVto = value; }
        public Banco Banco { get => _banco; set => _banco = value; }
        public string CtaBancariaTipo { get => _ctaBancariaTipo; set => _ctaBancariaTipo = value; }
        public string CtaBancariaNro { get => _ctaBancariaNro; set => _ctaBancariaNro = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public PagoOtro() { }
        public PagoOtro(long id, int cbteTPV, long cbteNro, DateTime cbteFecha, string estado, string denominacion, CentroCosto centroCosto, CuentaContable cuentaContableDestino, string concepto, double montoPagado, CuentaContable cuentaContableOrigen, string medioPago, long medioNro, DateTime medioChequeVto, Banco banco, string ctaBancariaTipo, string ctaBancariaNro, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _cbteTPV = cbteTPV;
            _cbteNro = cbteNro;
            _cbteFecha = cbteFecha;
            _estado = estado;
            _denominacion = denominacion;
            _centroCosto = centroCosto;
            _cuentaContableDestino = cuentaContableDestino;
            _concepto = concepto;
            _montoPagado = montoPagado;
            _cuentaContableOrigen = cuentaContableOrigen;
            _medioPago = medioPago;
            _medioNro = medioNro;
            _medioChequeVto = medioChequeVto;
            _banco = banco;
            _ctaBancariaTipo = ctaBancariaTipo;
            _ctaBancariaNro = ctaBancariaNro;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(PagoOtro objPagoOtro)
        {
            if (objPagoOtro != null &&
                _id == objPagoOtro._id &&
                _cbteTPV == objPagoOtro._cbteTPV &&
                _cbteNro == objPagoOtro._cbteNro &&
                _cbteFecha.Date == objPagoOtro._cbteFecha.Date &&
                _estado == objPagoOtro._estado &&
                _denominacion == objPagoOtro._denominacion &&
                _centroCosto.Id == objPagoOtro._centroCosto.Id &&
                _cuentaContableDestino.Id == objPagoOtro._cuentaContableDestino.Id &&
                _concepto == objPagoOtro._concepto &&
                _montoPagado == objPagoOtro._montoPagado &&
                _cuentaContableOrigen.Id == objPagoOtro._cuentaContableOrigen.Id &&
                _medioPago == objPagoOtro._medioPago &&
                _medioNro == objPagoOtro._medioNro &&
                _medioChequeVto == objPagoOtro._medioChequeVto &&
                _banco.Id == objPagoOtro._banco.Id &&
                _ctaBancariaTipo == objPagoOtro._ctaBancariaTipo &&
                _ctaBancariaNro == objPagoOtro._ctaBancariaNro) return true;
            return false;
        }
        #endregion
    }
}