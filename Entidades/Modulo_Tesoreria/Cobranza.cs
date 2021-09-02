using Entidades.Catalogo;
using System;

namespace Entidades
{
    public class Cobranza : IEquatable<Cobranza>
    {
        #region Atributos
        private long _id;
        private int _cbteTPV;
        private long _cbteNro;
        private DateTime _cbteFecha;
        private string _estado;
        private long _nroLiquidacion;
        private Cliente _cliente;
        private string _concepto;
        private double _montoBruto;
        private double _iva105;
        private double _iva210;
        private double _iva270;
        private double _retencionIIBB;
        private double _retencionLH;
        private double _retencionIVA;
        private double _retencionGanancia;
        private double _retencionFondoMinero;
        private double _retencionSUSS;
        private double _totalRetencion;
        private double _totalNeto;
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
        public long NroLiquidacion { get => _nroLiquidacion; set => _nroLiquidacion = value; }
        public Cliente Cliente { get => _cliente; set => _cliente = value; }
        public string Concepto { get => _concepto; set => _concepto = value; }
        public double MontoBruto { get => _montoBruto; set => _montoBruto = value; }
        public double Iva105 { get => _iva105; set => _iva105 = value; }
        public double Iva210 { get => _iva210; set => _iva210 = value; }
        public double Iva270 { get => _iva270; set => _iva270 = value; }
        public double RetencionIIBB { get => _retencionIIBB; set => _retencionIIBB = value; }
        public double RetencionLH { get => _retencionLH; set => _retencionLH = value; }
        public double RetencionIVA { get => _retencionIVA; set => _retencionIVA = value; }
        public double RetencionGanancia { get => _retencionGanancia; set => _retencionGanancia = value; }
        public double RetencionFondoMinero { get => _retencionFondoMinero; set => _retencionFondoMinero = value; }
        public double RetencionSUSS { get => _retencionSUSS; set => _retencionSUSS = value; }
        public double TotalRetencion { get => _totalRetencion; set => _totalRetencion = value; }
        public double TotalNeto { get => _totalNeto; set => _totalNeto = value; }
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
        public Cobranza() { }
        public Cobranza(long id, int cbteTPV, long cbteNro, DateTime cbteFecha, string estado, long nroLiquidacion, Cliente cliente, string concepto, double montoBruto, double iva105, double iva210, double iva270, double retencionIIBB, double retencionLH, double retencionIVA, double retencionGanancia, double retencionFondoMinero, double retencionSUSS, double totalRetencion, double totalNeto, CuentaContable cuentaContable, string medioPago, long medioNro, DateTime medioChequeVto, Banco banco, string ctaBancariaTipo, string ctaBancariaNro, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _cbteTPV = cbteTPV;
            _cbteNro = cbteNro;
            _cbteFecha = cbteFecha;
            _estado = estado;
            _nroLiquidacion = nroLiquidacion;
            _cliente = cliente;
            _concepto = concepto;
            _montoBruto = montoBruto;
            _iva105 = iva105;
            _iva210 = iva210;
            _iva270 = iva270;
            _retencionIIBB = retencionIIBB;
            _retencionLH = retencionLH;
            _retencionIVA = retencionIVA;
            _retencionGanancia = retencionGanancia;
            _retencionFondoMinero = retencionFondoMinero;
            _retencionSUSS = retencionSUSS;
            _totalRetencion = totalRetencion;
            _totalNeto = totalNeto;
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
        public bool Equals(Cobranza objCobranza)
        {
            if (objCobranza != null &&
                _id == objCobranza._id &&
                _cbteTPV == objCobranza._cbteTPV &&
                _cbteNro == objCobranza._cbteNro &&
                _cbteFecha.Date == objCobranza._cbteFecha.Date &&
                _estado == objCobranza._estado &&
                _nroLiquidacion == objCobranza._nroLiquidacion &&
                _cliente.Id == objCobranza._cliente.Id &&
                _concepto == objCobranza._concepto &&
                _montoBruto == objCobranza._montoBruto &&
                _iva105 == objCobranza._iva105 &&
                _iva210 == objCobranza._iva210 &&
                _iva270 == objCobranza._iva270 &&
                _retencionIIBB == objCobranza._retencionIIBB &&
                _retencionLH == objCobranza._retencionLH &&
                _retencionIVA == objCobranza._retencionIVA &&
                _retencionGanancia == objCobranza._retencionGanancia &&
                _retencionFondoMinero == objCobranza._retencionFondoMinero &&
                _retencionSUSS == objCobranza._retencionSUSS &&
                _totalRetencion == objCobranza._totalRetencion &&
                _totalNeto == objCobranza._totalNeto &&
                _cuentaContable.Id == objCobranza._cuentaContable.Id &&
                _medioPago == objCobranza._medioPago &&
                _medioNro == objCobranza._medioNro &&
                _medioChequeVto == objCobranza._medioChequeVto &&
                _banco.Id == objCobranza._banco.Id &&
                _ctaBancariaTipo == objCobranza._ctaBancariaTipo &&
                _ctaBancariaNro == objCobranza._ctaBancariaNro) return true;
            return false;
        }
        #endregion
    }
}