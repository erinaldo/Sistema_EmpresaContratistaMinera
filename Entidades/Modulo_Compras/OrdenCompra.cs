using System;

namespace Entidades
{
    public class OrdenCompra : IEquatable<OrdenCompra>
    {
        #region Atributos
        private long _id;
        private int _cbteTPV;
        private long _cbteNro;
        private DateTime _cbteFecha;
        private string _estado;
        private string _autorizacion;
        private Proveedor _Proveedor;
        private CuentaContable _cuentaContable;
        private DateTime _fechaArribo;
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
        public int CbteTPV { get => _cbteTPV; set => _cbteTPV = value; }
        public long CbteNro { get => _cbteNro; set => _cbteNro = value; }
        public DateTime CbteFecha { get => _cbteFecha; set => _cbteFecha = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Autorizacion { get => _autorizacion; set => _autorizacion = value; }
        public Proveedor Proveedor { get => _Proveedor; set => _Proveedor = value; }
        public CuentaContable CuentaContable { get => _cuentaContable; set => _cuentaContable = value; }
        public DateTime FechaArribo { get => _fechaArribo; set => _fechaArribo = value; }
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
        public OrdenCompra() { }
        public OrdenCompra(long id, int cbteTPV, long cbteNro, DateTime cbteFecha, string estado, string autorizacion, Proveedor Proveedor, CuentaContable cuentaContable, DateTime fechaArribo, double descuentoPorcentual, double descuento, double subtotal, double iva105, double iva210, double iva270, double percepcionIIBB, double percepcionLH, double percepcionIVA, double noGravado, double impuestoInterno, double total, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _cbteTPV = cbteTPV;
            _cbteNro = cbteNro;
            _cbteFecha = cbteFecha;
            _estado = estado;
            _autorizacion = autorizacion;
            _Proveedor = Proveedor;
            _cuentaContable = cuentaContable;
            _fechaArribo = fechaArribo;
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
        public bool Equals(OrdenCompra objOrdenCompra)
        {
            if (objOrdenCompra != null &&
                _id == objOrdenCompra._id &&
                _cbteTPV == objOrdenCompra._cbteTPV &&
                _cbteNro == objOrdenCompra._cbteNro &&
                _cbteFecha.Date == objOrdenCompra._cbteFecha.Date &&
                _estado == objOrdenCompra._estado &&
                _autorizacion == objOrdenCompra._autorizacion &&
                _Proveedor.Id == objOrdenCompra._Proveedor.Id &&
                _cuentaContable.Id == objOrdenCompra._cuentaContable.Id &&
                _fechaArribo.Date == objOrdenCompra._fechaArribo.Date &&
                _descuentoPorcentual == objOrdenCompra._descuentoPorcentual &&
                _descuento == objOrdenCompra._descuento &&
                _subtotal == objOrdenCompra._subtotal &&
                _iva105 == objOrdenCompra._iva105 &&
                _iva210 == objOrdenCompra._iva210 &&
                _iva270 == objOrdenCompra._iva270 &&
                _percepcionIIBB == objOrdenCompra._percepcionIIBB &&
                _percepcionLH == objOrdenCompra._percepcionLH &&
                _percepcionIVA == objOrdenCompra._percepcionIVA &&
                _noGravado == objOrdenCompra._noGravado &&
                _impuestoInterno == objOrdenCompra._impuestoInterno &&
                _total == objOrdenCompra._total) return true;
            return false;
        }
        #endregion
    }
}