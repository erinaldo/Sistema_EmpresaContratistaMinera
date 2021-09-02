namespace Entidades
{
    public class ConsumoCentroCosto
    {
        #region Atributos
        private long _idArticulo;
        private string _denominacion;
        private int _consumoTotal;
        private int _desechoTotal;
        private double _costoBrutoTotal;
        private double _costoNetoTotal;
        #endregion

        #region Propiedades
        public long IdArticulo { get => _idArticulo; set => _idArticulo = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public int ConsumoTotal { get => _consumoTotal; set => _consumoTotal = value; }
        public int DesechoTotal { get => _desechoTotal; set => _desechoTotal = value; }
        public double CostoBrutoTotal { get => _costoBrutoTotal; set => _costoBrutoTotal = value; }
        public double CostoNetoTotal { get => _costoNetoTotal; set => _costoNetoTotal = value; }
        #endregion

        #region Constructores
        public ConsumoCentroCosto() { }
        public ConsumoCentroCosto(long idArticulo, string denominacion, int consumoTotal, int desechoTotal, double costoBrutoTotal, double costoNetoTotal)
        {
            _idArticulo = idArticulo;
            _denominacion = denominacion;
            _consumoTotal = consumoTotal;
            _desechoTotal = desechoTotal;
            _costoBrutoTotal = costoBrutoTotal;
            _costoNetoTotal = costoNetoTotal;
        }
        #endregion
    }
}