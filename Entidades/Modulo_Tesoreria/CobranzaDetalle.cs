namespace Entidades
{
    public class CobranzaDetalle
    {
        #region Atributos
        private long _id;
        private Cobranza _cobranza;
        private Venta _venta;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public Cobranza Cobranza { get => _cobranza; set => _cobranza = value; }
        public Venta Venta { get => _venta; set => _venta = value; }
        #endregion

        #region Constructores
        public CobranzaDetalle() { }
        public CobranzaDetalle(long id, Cobranza cobranza, Venta venta)
        {
            _id = id;
            _cobranza = cobranza;
            _venta = venta;
        }
        #endregion
    }
}