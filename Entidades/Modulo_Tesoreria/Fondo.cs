namespace Entidades
{
    public class Fondo : CuentaContable
    {
        // Herencia: Esta clase hereda de la clase CuentaContable
        #region Constructores
        public Fondo() { }
        public Fondo(long id, string codigo, string denominacion, string tipoCuenta, double saldo) 
            : base(id, codigo, denominacion, tipoCuenta, saldo) { }
        #endregion
    }
}