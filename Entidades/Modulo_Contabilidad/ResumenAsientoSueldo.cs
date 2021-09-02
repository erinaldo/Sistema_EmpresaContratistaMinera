namespace Entidades
{
    public class ResumenAsientoSueldo : AsientoContable
    {
        // Herencia: Esta clase hereda de la clase AsientoContable
        #region Constructores
        public ResumenAsientoSueldo() { }
        public ResumenAsientoSueldo(CuentaContable cuentaContable, double debe, double haber) 
            : base(cuentaContable, debe, haber) { }
        #endregion
    }
}