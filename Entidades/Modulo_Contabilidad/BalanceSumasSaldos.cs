namespace Entidades
{
    public class BalanceSumasSaldos : AsientoContable
    {
        // Herencia: Esta clase hereda de la clase AsientoContable
        #region Atributos
        private double _saldo;
        #endregion

        #region Propiedades
        public double Saldo { get => _saldo; set => _saldo = value; }
        #endregion

        #region Constructores
        public BalanceSumasSaldos() { }
        public BalanceSumasSaldos(CuentaContable cuentaContable, double debe, double haber, double saldo) 
            : base(cuentaContable, debe, haber)
        {
            _saldo = saldo;
        }
        #endregion
    }
}