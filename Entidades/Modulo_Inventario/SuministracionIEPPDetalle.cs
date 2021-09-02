namespace Entidades
{
    public class SuministracionIEPPDetalle
    {
        #region Atributos
        private long _id;
        private SuministracionIEPP _suministracionIEPP;
        private long _idArticulo;
        private string _denominacion;
        private string _certificacion;
        private int _cantidad;
        private string _unidad;
        private string _deposito;
        private string _inventario;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public SuministracionIEPP SuministracionIEPP { get => _suministracionIEPP; set => _suministracionIEPP = value; }
        public long IdArticulo { get => _idArticulo; set => _idArticulo = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public string Certificacion { get => _certificacion; set => _certificacion = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public string Unidad { get => _unidad; set => _unidad = value; }
        public string Deposito { get => _deposito; set => _deposito = value; }
        public string Inventario { get => _inventario; set => _inventario = value; }
        #endregion

        #region Constructores
        public SuministracionIEPPDetalle() { }
        public SuministracionIEPPDetalle(long id, SuministracionIEPP suministracionIEPP, long idArticulo, string denominacion, string certificacion, int cantidad, string unidad, string deposito, string inventario)
        {
            _id = id;
            _suministracionIEPP = suministracionIEPP;
            _idArticulo = idArticulo;
            _denominacion = denominacion;
            _certificacion = certificacion;
            _cantidad = cantidad;
            _unidad = unidad;
            _deposito = deposito;
            _inventario = inventario;
        }
        #endregion
    }
}