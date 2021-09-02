namespace Entidades
{
    public class OrdenCompraDetalle
    {
        #region Atributos
        private long _id;
        private OrdenCompra _ordenCompra;
        private long _idArticulo;
        private string _denominacion;
        private int _cantidad;
        private string _unidad;
        private string _deposito;
        private double _costoUnitario;
        private string _alicuotaIVA;
        private double _BaseIVA;
        private double _costoNeto;
        private CentroCosto _centroCosto;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public OrdenCompra OrdenCompra { get => _ordenCompra; set => _ordenCompra = value; }
        public long IdArticulo { get => _idArticulo; set => _idArticulo = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public string Unidad { get => _unidad; set => _unidad = value; }
        public string Deposito { get => _deposito; set => _deposito = value; }
        public double CostoUnitario { get => _costoUnitario; set => _costoUnitario = value; }
        public string AlicuotaIVA { get => _alicuotaIVA; set => _alicuotaIVA = value; }
        public double BaseIVA { get => _BaseIVA; set => _BaseIVA = value; }
        public double CostoNeto { get => _costoNeto; set => _costoNeto = value; }
        public CentroCosto CentroCosto { get => _centroCosto; set => _centroCosto = value; }
        #endregion

        #region Constructores
        public OrdenCompraDetalle() { }
        public OrdenCompraDetalle(long id, OrdenCompra ordenCompra, long idArticulo, string denominacion, int cantidad, string unidad, string deposito, double costoUnitario, string alicuotaIVA, double BaseIVA, double costoNeto, CentroCosto centroCosto)
        {
            _id = id;
            _ordenCompra = ordenCompra;
            _idArticulo = idArticulo;
            _denominacion = denominacion;
            _cantidad = cantidad;
            _unidad = unidad;
            _deposito = deposito;
            _costoUnitario = costoUnitario;
            _alicuotaIVA = alicuotaIVA;
            _BaseIVA = BaseIVA;
            _costoNeto = costoNeto;
            _centroCosto = centroCosto;
        }
        #endregion
    }
}