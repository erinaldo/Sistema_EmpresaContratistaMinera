namespace Entidades
{
    public class ConsumoStockDetalle
    {
        #region Atributos
        private long _id;
        private ConsumoStock _consumoStock;
        private long _idArticulo;
        private string _denominacion;
        private int _consumo;
        private int _desecho;
        private string _unidad;
        private double _costoBruto;
        private double _costoNeto;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public ConsumoStock ConsumoStock { get => _consumoStock; set => _consumoStock = value; }
        public long IdArticulo { get => _idArticulo; set => _idArticulo = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public int Consumo { get => _consumo; set => _consumo = value; }
        public int Desecho { get => _desecho; set => _desecho = value; }
        public string Unidad { get => _unidad; set => _unidad = value; }
        public double CostoBruto { get => _costoBruto; set => _costoBruto = value; }
        public double CostoNeto { get => _costoNeto; set => _costoNeto = value; }
        #endregion

        #region Constructores
        public ConsumoStockDetalle() { }
        public ConsumoStockDetalle(long id, ConsumoStock consumoStock, long idArticulo, string denominacion, int consumo, int desecho, string unidad, double costoBruto, double costoNeto)
        {
            _id = id;
            _consumoStock = consumoStock;
            _idArticulo = idArticulo;
            _denominacion = denominacion;
            _consumo = consumo;
            _desecho = desecho;
            _unidad = unidad;
            _costoBruto = costoBruto;
            _costoNeto = costoNeto;
        }
        #endregion
    }
}