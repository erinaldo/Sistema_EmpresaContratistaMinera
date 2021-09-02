namespace Entidades
{
    public class VentaDetalle
    {
        #region Atributos
        private long _id;
        private Venta _venta;
        private long _idArticulo;
        private string _denominacion;
        private int _cantidad;
        private string _unidad;
        private string _deposito;
        private double _precioUnitario;
        private string _alicuotaIVA;
        private double _BaseIVA;
        private double _precioNeto;
        private CentroCosto _centroCosto;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public Venta Venta { get => _venta; set => _venta = value; }
        public long IdArticulo { get => _idArticulo; set => _idArticulo = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public string Unidad { get => _unidad; set => _unidad = value; }
        public string Deposito { get => _deposito; set => _deposito = value; }
        public double PrecioUnitario { get => _precioUnitario; set => _precioUnitario = value; }
        public string AlicuotaIVA { get => _alicuotaIVA; set => _alicuotaIVA = value; }
        public double BaseIVA { get => _BaseIVA; set => _BaseIVA = value; }
        public double PrecioNeto { get => _precioNeto; set => _precioNeto = value; }
        public CentroCosto CentroCosto { get => _centroCosto; set => _centroCosto = value; }
        #endregion

        #region Constructores
        public VentaDetalle() { }
        public VentaDetalle(long id, Venta venta, long idArticulo, string denominacion, int cantidad, string unidad, string deposito, double precioUnitario, string alicuotaIVA, double BaseIVA, double precioNeto, CentroCosto centroCosto)
        {
            _id = id;
            _venta = venta;
            _idArticulo = idArticulo;
            _denominacion = denominacion;
            _cantidad = cantidad;
            _unidad = unidad;
            _deposito = deposito;
            _precioUnitario = precioUnitario;
            _alicuotaIVA = alicuotaIVA;
            _BaseIVA = BaseIVA;
            _precioNeto = precioNeto;
            _centroCosto = centroCosto;
        }
        #endregion
    }
}