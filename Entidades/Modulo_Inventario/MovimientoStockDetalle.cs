namespace Entidades
{
    public class MovimientoStockDetalle
    {
        #region Atributos
        private long _id;
        private MovimientoStock _movimientoStock;
        private long _idArticulo;
        private string _denominacion;
        private int _cantidad;
        private string _unidad;
        private string _nroSerie;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public MovimientoStock MovimientoStock { get => _movimientoStock; set => _movimientoStock = value; }
        public long IdArticulo { get => _idArticulo; set => _idArticulo = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public string Unidad { get => _unidad; set => _unidad = value; }
        public string NroSerie { get => _nroSerie; set => _nroSerie = value; }
        #endregion

        #region Constructores
        public MovimientoStockDetalle() { }
        public MovimientoStockDetalle(long id, MovimientoStock movimientoStock, long idArticulo, string denominacion, int cantidad, string unidad, string nroSerie)
        {
            _id = id;
            _movimientoStock = movimientoStock;
            _idArticulo = idArticulo;
            _denominacion = denominacion;
            _cantidad = cantidad;
            _unidad = unidad;
            _nroSerie = nroSerie;
        }
        #endregion
    }
}