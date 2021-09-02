namespace Entidades
{
    public class ResumenAsientoVenta : AsientoContable
    {
        // Herencia: Esta clase hereda de la clase AsientoContable
        #region Constructores
        public ResumenAsientoVenta() { }
        public ResumenAsientoVenta(CuentaContable cuentaContable, double debe, double haber)
            : base(cuentaContable, debe, haber) { }
        #endregion
    }
}