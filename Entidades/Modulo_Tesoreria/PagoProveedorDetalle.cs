namespace Entidades
{
    public class PagoProveedorDetalle
    {
        #region Atributos
        private long _id;
        private PagoProveedor _pagoProveedor;
        private Compra _compra;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public PagoProveedor PagoProveedor { get => _pagoProveedor; set => _pagoProveedor = value; }
        public Compra Compra { get => _compra; set => _compra = value; }
        #endregion

        #region Constructores
        public PagoProveedorDetalle() { }
        public PagoProveedorDetalle(long id, PagoProveedor pagoProveedor, Compra compra)
        {
            _id = id;
            _pagoProveedor = pagoProveedor;
            _compra = compra;
        }
        #endregion
    }
}