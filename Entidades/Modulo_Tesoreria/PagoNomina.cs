using Entidades.Catalogo;
using System;

namespace Entidades
{
    public class PagoNomina : IEquatable<PagoNomina>
    {
        #region Atributos
        private long _id;
        private int _cbteTPV;
        private long _cbteNro;
        private DateTime _cbteFecha;
        private string _estado;
        private Legajo _legajo;
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
        public Legajo Legajo { get => _legajo; set => _legajo = value; }
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
        public PagoNomina() { }
        public PagoNomina(long id, int cbteTPV, long cbteNro, DateTime cbteFecha, string estado, Legajo legajo, CentroCosto centroCosto, CuentaContable cuentaContableDestino, string concepto, double montoPagado, CuentaContable cuentaContableOrigen, string medioPago, long medioNro, DateTime medioChequeVto, Banco banco, string ctaBancariaTipo, string ctaBancariaNro, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _cbteTPV = cbteTPV;
            _cbteNro = cbteNro;
            _cbteFecha = cbteFecha;
            _estado = estado;
            _legajo = legajo;
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
        public bool Equals(PagoNomina objPagoNomina)
        {
            if (objPagoNomina != null &&
                _id == objPagoNomina._id &&
                _cbteTPV == objPagoNomina._cbteTPV &&
                _cbteNro == objPagoNomina._cbteNro &&
                _cbteFecha.Date == objPagoNomina._cbteFecha.Date &&
                _estado == objPagoNomina._estado &&
                _legajo.Id == objPagoNomina._legajo.Id &&
                _centroCosto.Id == objPagoNomina._centroCosto.Id &&
                _cuentaContableDestino.Id == objPagoNomina._cuentaContableDestino.Id &&
                _concepto == objPagoNomina._concepto &&
                _montoPagado == objPagoNomina._montoPagado &&
                _cuentaContableOrigen.Id == objPagoNomina._cuentaContableOrigen.Id &&
                _medioPago == objPagoNomina._medioPago &&
                _medioNro == objPagoNomina._medioNro &&
                _medioChequeVto == objPagoNomina._medioChequeVto &&
                _banco.Id == objPagoNomina._banco.Id &&
                _ctaBancariaTipo == objPagoNomina._ctaBancariaTipo &&
                _ctaBancariaNro == objPagoNomina._ctaBancariaNro) return true;
            return false;
        }
        #endregion
    }
}