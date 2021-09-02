namespace Entidades
{
    public class EstadoResultados
    {
        #region Atributos
        private string _subTitulo;
        private string _denominacion;
        private double _monto;
        #endregion

        #region Propiedades
        public string SubTitulo { get => _subTitulo; set => _subTitulo = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public double Monto { get => _monto; set => _monto = value; }
        #endregion

        #region Constructores
        public EstadoResultados() { }
        public EstadoResultados(string subTitulo, string denominacion, double monto)
        {
            _subTitulo = subTitulo;
            _denominacion = denominacion;
            _monto = monto;
        }
        #endregion
    }
}