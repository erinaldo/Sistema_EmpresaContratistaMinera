namespace Entidades
{
    public class ControlStockDetalle
    {
        #region Atributos
        private long _id;
        private ControlStock _controlStock;
        private long _idArticulo;
        private string _denominacion;
        private int _stock;
        private string _unidad;
        private int _recuento;
        private int _deduccion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public ControlStock ControlStock { get => _controlStock; set => _controlStock = value; }
        public long IdArticulo { get => _idArticulo; set => _idArticulo = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public string Unidad { get => _unidad; set => _unidad = value; }
        public int Recuento { get => _recuento; set => _recuento = value; }
        public int Deduccion { get => _deduccion; set => _deduccion = value; }
        #endregion

        #region Constructores
        public ControlStockDetalle() { }
        public ControlStockDetalle(long id, ControlStock controlStock, long idArticulo, string denominacion, int stock, string unidad, int recuento, int deduccion)
        {
            _id = id;
            _controlStock = controlStock;
            _idArticulo = idArticulo;
            _denominacion = denominacion;
            _stock = stock;
            _unidad = unidad;
            _recuento = recuento;
            _deduccion = deduccion;
        }
        #endregion
    }
}