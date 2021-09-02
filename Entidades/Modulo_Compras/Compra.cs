using System;

namespace Entidades
{
    public class Compra : IEquatable<Compra>
    {
        #region Atributos
        private long _id;
        private DateTime _fecha;
        private string _periodo;
        private int _afipCbteTipo;
        private int _afipCbteTPV;
        private long _afipCbteNro;
        private DateTime _afipCbteFecha;
        private string _afipCodigoBarras;
        private Proveedor _Proveedor;
        private CuentaContable _cuentaContable;
        private DateTime _pagoVto;
        private string _pagoEstado;
        private bool _pagoAlertado;
        private long _asociacionId;
        private int _asociacionAfipCbteTipo;
        private int _asociacionAfipCbteTPV;
        private long _asociacionAfipCbteNro;
        private DateTime _asociacionAfipCbteFecha;
        private bool _asociacionAplicada;
        private double _descuentoPorcentual;
        private double _descuento;
        private double _subtotal;
        private double _iva105;
        private double _iva210;
        private double _iva270;
        private double _percepcionIIBB;
        private double _percepcionLH;
        private double _percepcionIVA;
        private double _noGravado;
        private double _impuestoInterno;
        private double _total;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Periodo { get => _periodo; set => _periodo = value; }
        public int AfipCbteTipo { get => _afipCbteTipo; set => _afipCbteTipo = value; }
        public int AfipCbteTPV { get => _afipCbteTPV; set => _afipCbteTPV = value; }
        public long AfipCbteNro { get => _afipCbteNro; set => _afipCbteNro = value; }
        public DateTime AfipCbteFecha { get => _afipCbteFecha; set => _afipCbteFecha = value; }
        public string AfipCodigoBarras { get => _afipCodigoBarras; set => _afipCodigoBarras = value; }
        public Proveedor Proveedor { get => _Proveedor; set => _Proveedor = value; }
        public CuentaContable CuentaContable { get => _cuentaContable; set => _cuentaContable = value; }
        public DateTime PagoVto { get => _pagoVto; set => _pagoVto = value; }
        public string PagoEstado { get => _pagoEstado; set => _pagoEstado = value; }
        public bool PagoAlertado { get => _pagoAlertado; set => _pagoAlertado = value; }
        public long AsociacionId { get => _asociacionId; set => _asociacionId = value; }
        public int AsociacionAfipCbteTipo { get => _asociacionAfipCbteTipo; set => _asociacionAfipCbteTipo = value; }
        public int AsociacionAfipCbteTPV { get => _asociacionAfipCbteTPV; set => _asociacionAfipCbteTPV = value; }
        public long AsociacionAfipCbteNro { get => _asociacionAfipCbteNro; set => _asociacionAfipCbteNro = value; }
        public DateTime AsociacionAfipCbteFecha { get => _asociacionAfipCbteFecha; set => _asociacionAfipCbteFecha = value; }
        public bool AsociacionAplicada { get => _asociacionAplicada; set => _asociacionAplicada = value; }
        public double DescuentoPorcentual { get => _descuentoPorcentual; set => _descuentoPorcentual = value; }
        public double Descuento { get => _descuento; set => _descuento = value; }
        public double Subtotal { get => _subtotal; set => _subtotal = value; }
        public double Iva105 { get => _iva105; set => _iva105 = value; }
        public double Iva210 { get => _iva210; set => _iva210 = value; }
        public double Iva270 { get => _iva270; set => _iva270 = value; }
        public double PercepcionIIBB { get => _percepcionIIBB; set => _percepcionIIBB = value; }
        public double PercepcionLH { get => _percepcionLH; set => _percepcionLH = value; }
        public double PercepcionIVA { get => _percepcionIVA; set => _percepcionIVA = value; }
        public double NoGravado { get => _noGravado; set => _noGravado = value; }
        public double ImpuestoInterno { get => _impuestoInterno; set => _impuestoInterno = value; }
        public double Total { get => _total; set => _total = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public Compra() { }
        public Compra(long id, DateTime fecha, string periodo, int afipCbteTipo, int afipCbteTPV, long afipCbteNro, DateTime afipCbteFecha, string afipCodigoBarras, Proveedor Proveedor, CuentaContable cuentaContable, DateTime pagoVto, string pagoEstado, bool pagoAlertado, long asociacionId, int asociacionAfipCbteTipo, int asociacionAfipCbteTPV, long asociacionAfipCbteNro, DateTime asociacionAfipCbteFecha, bool asociacionAplicada, double descuentoPorcentual, double descuento, double subtotal, double iva105, double iva210, double iva270, double percepcionIIBB, double percepcionLH, double percepcionIVA, double noGravado, double impuestoInterno, double total, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _fecha = fecha;
            _periodo = periodo;
            _afipCbteTipo = afipCbteTipo;
            _afipCbteTPV = afipCbteTPV;
            _afipCbteNro = afipCbteNro;
            _afipCbteFecha = afipCbteFecha;
            _afipCodigoBarras = afipCodigoBarras;
            _Proveedor = Proveedor;
            _cuentaContable = cuentaContable;
            _pagoVto = pagoVto;
            _pagoEstado = pagoEstado;
            _pagoAlertado = pagoAlertado;
            _asociacionId = asociacionId;
            _asociacionAfipCbteTipo = asociacionAfipCbteTipo;
            _asociacionAfipCbteTPV = asociacionAfipCbteTPV;
            _asociacionAfipCbteNro = asociacionAfipCbteNro;
            _asociacionAfipCbteFecha = asociacionAfipCbteFecha;
            _asociacionAplicada = asociacionAplicada;
            _descuentoPorcentual = descuentoPorcentual;
            _descuento = descuento;
            _subtotal = subtotal;
            _iva105 = iva105;
            _iva210 = iva210;
            _iva270 = iva270;
            _percepcionIIBB = percepcionIIBB;
            _percepcionLH = percepcionLH;
            _percepcionIVA = percepcionIVA;
            _noGravado = noGravado;
            _impuestoInterno = impuestoInterno;
            _total = total;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(Compra objCompra)
        {
            if (objCompra != null &&
                _id == objCompra._id &&
                _fecha.Date == objCompra._fecha.Date &&
                _periodo == objCompra._periodo &&
                _afipCbteTipo == objCompra._afipCbteTipo &&
                _afipCbteTPV == objCompra._afipCbteTPV &&
                _afipCbteNro == objCompra._afipCbteNro &&
                _afipCbteFecha.Date == objCompra._afipCbteFecha.Date &&
                _afipCodigoBarras == objCompra._afipCodigoBarras &&
                _Proveedor.Id == objCompra._Proveedor.Id &&
                _cuentaContable.Id == objCompra._cuentaContable.Id &&
                _pagoVto.Date == objCompra._pagoVto.Date &&
                _pagoEstado == objCompra._pagoEstado &&
                _pagoAlertado == objCompra._pagoAlertado &&
                _asociacionId == objCompra._asociacionId &&
                _asociacionAfipCbteTipo == objCompra._asociacionAfipCbteTipo &&
                _asociacionAfipCbteTPV == objCompra._asociacionAfipCbteTPV &&
                _asociacionAfipCbteNro == objCompra._asociacionAfipCbteNro &&
                _asociacionAfipCbteFecha.Date == objCompra._asociacionAfipCbteFecha.Date &&
                _asociacionAplicada == objCompra._asociacionAplicada &&
                _descuentoPorcentual == objCompra._descuentoPorcentual &&
                _descuento == objCompra._descuento &&
                _subtotal == objCompra._subtotal &&
                _iva105 == objCompra._iva105 &&
                _iva210 == objCompra._iva210 &&
                _iva270 == objCompra._iva270 &&
                _percepcionIIBB == objCompra._percepcionIIBB &&
                _percepcionLH == objCompra._percepcionLH &&
                _percepcionIVA == objCompra._percepcionIVA &&
                _noGravado == objCompra._noGravado &&
                _impuestoInterno == objCompra._impuestoInterno &&
                _total == objCompra._total) return true;
            return false;
        }
        #endregion
    }
}