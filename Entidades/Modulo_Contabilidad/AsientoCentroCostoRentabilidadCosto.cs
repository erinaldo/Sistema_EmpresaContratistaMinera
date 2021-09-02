namespace Entidades
{
    public class AsientoCentroCostoRentabilidadCosto
    {
        #region Atributos
        private string _subTitulo;
        private string _denominacion;
        private double _presupuestoCosto;
        private double _presupuestoCostoIncidencia;
        private double _realCosto;
        private double _realCostoIncidencia;
        #endregion

        #region Propiedades
        public string SubTitulo { get => _subTitulo; set => _subTitulo = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public double PresupuestoCosto { get => _presupuestoCosto; set => _presupuestoCosto = value; }
        public double PresupuestoCostoIncidencia { get => _presupuestoCostoIncidencia; set => _presupuestoCostoIncidencia = value; }
        public double RealCosto { get => _realCosto; set => _realCosto = value; }
        public double RealCostoIncidencia { get => _realCostoIncidencia; set => _realCostoIncidencia = value; }
        #endregion

        #region Constructores
        public AsientoCentroCostoRentabilidadCosto() { }
        public AsientoCentroCostoRentabilidadCosto(string subTitulo, string denominacion, double presupuestoCosto, double presupuestoCostoIncidencia, double realCosto, double realCostoIncidencia)
        {
            _subTitulo = subTitulo;
            _denominacion = denominacion;
            _presupuestoCosto = presupuestoCosto;
            _presupuestoCostoIncidencia = presupuestoCostoIncidencia;
            _realCosto = realCosto;
            _realCostoIncidencia = realCostoIncidencia;
        }
        #endregion
    }
}