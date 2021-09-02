using System;

namespace Entidades
{
    public class Venta : IEquatable<Venta>
    {
        #region Atributos
        private long _id;
        private DateTime _fecha;
        private string _periodo;
        private int _afipCbteTipo;
        private int _afipCbteTPV;
        private long _afipCbteNro;
        private DateTime _afipCbteFecha;
        private Cliente _cliente;
        private CuentaContable _cuentaContable;
        private DateTime _cobranzaVto;
        private string _cobranzaEstado;
        private bool _cobranzaAlertado;
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
        private double _noGravado;
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
        public Cliente Cliente { get => _cliente; set => _cliente = value; }
        public CuentaContable CuentaContable { get => _cuentaContable; set => _cuentaContable = value; }
        public DateTime CobranzaVto { get => _cobranzaVto; set => _cobranzaVto = value; }
        public string CobranzaEstado { get => _cobranzaEstado; set => _cobranzaEstado = value; }
        public bool CobranzaAlertado { get => _cobranzaAlertado; set => _cobranzaAlertado = value; }
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
        public double NoGravado { get => _noGravado; set => _noGravado = value; }
        public double Total { get => _total; set => _total = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public Venta() { }
        public Venta(long id, DateTime fecha, string periodo, int afipCbteTipo, int afipCbteTPV, long afipCbteNro, DateTime afipCbteFecha, Cliente cliente, CuentaContable cuentaContable, DateTime cobranzaVto, string cobranzaEstado, bool cobranzaAlertado, long asociacionId, int asociacionAfipCbteTipo, int asociacionAfipCbteTPV, long asociacionAfipCbteNro, DateTime asociacionAfipCbteFecha, bool asociacionAplicada, double descuentoPorcentual, double descuento, double subtotal, double iva105, double iva210, double iva270, double noGravado, double total, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _fecha = fecha;
            _periodo = periodo;
            _afipCbteTipo = afipCbteTipo;
            _afipCbteTPV = afipCbteTPV;
            _afipCbteNro = afipCbteNro;
            _afipCbteFecha = afipCbteFecha;
            _cliente = cliente;
            _cuentaContable = cuentaContable;
            _cobranzaVto = cobranzaVto;
            _cobranzaEstado = cobranzaEstado;
            _cobranzaAlertado = cobranzaAlertado;
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
            _noGravado = noGravado;
            _total = total;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(Venta objVenta)
        {
            if (objVenta != null &&
                _id == objVenta._id &&
                _fecha.Date == objVenta._fecha.Date &&
                _periodo == objVenta._periodo &&
                _afipCbteTipo == objVenta._afipCbteTipo &&
                _afipCbteTPV == objVenta._afipCbteTPV &&
                _afipCbteNro == objVenta._afipCbteNro &&
                _afipCbteFecha.Date == objVenta._afipCbteFecha.Date &&
                _cliente.Id == objVenta._cliente.Id &&
                _cuentaContable.Id == objVenta._cuentaContable.Id &&
                _cobranzaVto.Date == objVenta._cobranzaVto.Date &&
                _cobranzaEstado == objVenta._cobranzaEstado &&
                _cobranzaAlertado == objVenta._cobranzaAlertado &&
                _asociacionId == objVenta._asociacionId &&
                _asociacionAfipCbteTipo == objVenta._asociacionAfipCbteTipo &&
                _asociacionAfipCbteTPV == objVenta._asociacionAfipCbteTPV &&
                _asociacionAfipCbteNro == objVenta._asociacionAfipCbteNro &&
                _asociacionAfipCbteFecha.Date == objVenta._asociacionAfipCbteFecha.Date &&
                _asociacionAplicada == objVenta._asociacionAplicada &&
                _descuentoPorcentual == objVenta._descuentoPorcentual &&
                _descuento == objVenta._descuento &&
                _subtotal == objVenta._subtotal &&
                _iva105 == objVenta._iva105 &&
                _iva210 == objVenta._iva210 &&
                _iva270 == objVenta._iva270 &&
                _noGravado == objVenta._noGravado &&
                _total == objVenta._total) return true;
            return false;
        }
        #endregion
    }
}