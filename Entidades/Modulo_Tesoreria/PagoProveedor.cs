using Entidades.Catalogo;
using System;

namespace Entidades
{
    public class PagoProveedor : IEquatable<PagoProveedor>
    {
        #region Atributos
        private long _id;
        private int _cbteTPV;
        private long _cbteNro;
        private DateTime _cbteFecha;
        private string _estado;
        private Proveedor _proveedor;
        private string _concepto;
        private double _montoPagado;
        private CuentaContable _cuentaContable;
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
        public Proveedor Proveedor { get => _proveedor; set => _proveedor = value; }
        public string Concepto { get => _concepto; set => _concepto = value; }
        public double MontoPagado { get => _montoPagado; set => _montoPagado = value; }
        public CuentaContable CuentaContable { get => _cuentaContable; set => _cuentaContable = value; }
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
        public PagoProveedor() { }
        public PagoProveedor(long id, int cbteTPV, long cbteNro, DateTime cbteFecha, string estado, Proveedor proveedor, string concepto, double montoPagado, CuentaContable cuentaContable, string medioPago, long medioNro, DateTime medioChequeVto, Banco banco, string ctaBancariaTipo, string ctaBancariaNro, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _cbteTPV = cbteTPV;
            _cbteNro = cbteNro;
            _cbteFecha = cbteFecha;
            _estado = estado;
            _proveedor = proveedor;
            _concepto = concepto;
            _montoPagado = montoPagado;
            _cuentaContable = cuentaContable;
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
        public bool Equals(PagoProveedor objPagoProveedor)
        {
            if (objPagoProveedor != null &&
                _id == objPagoProveedor._id &&
                _cbteTPV == objPagoProveedor._cbteTPV &&
                _cbteNro == objPagoProveedor._cbteNro &&
                _cbteFecha.Date == objPagoProveedor._cbteFecha.Date &&
                _estado == objPagoProveedor._estado &&
                _proveedor.Id == objPagoProveedor._proveedor.Id &&
                _concepto == objPagoProveedor._concepto &&
                _montoPagado == objPagoProveedor._montoPagado &&
                _cuentaContable.Id == objPagoProveedor._cuentaContable.Id &&
                _medioPago == objPagoProveedor._medioPago &&
                _medioNro == objPagoProveedor._medioNro &&
                _medioChequeVto == objPagoProveedor._medioChequeVto &&
                _banco.Id == objPagoProveedor._banco.Id &&
                _ctaBancariaTipo == objPagoProveedor._ctaBancariaTipo &&
                _ctaBancariaNro == objPagoProveedor._ctaBancariaNro) return true;
            return false;
        }
        #endregion
    }
}