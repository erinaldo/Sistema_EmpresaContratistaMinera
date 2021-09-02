namespace Entidades
{
    public class ResumenAsientoCompra : AsientoContable
    {
        // Herencia: Esta clase hereda de la clase AsientoContable
        #region Constructores
        public ResumenAsientoCompra() { }
        public ResumenAsientoCompra(CuentaContable cuentaContable, double debe, double haber) 
            : base(cuentaContable, debe, haber) { }
        #endregion
    }
}