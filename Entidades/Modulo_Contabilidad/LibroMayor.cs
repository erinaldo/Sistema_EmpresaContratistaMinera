using System;

namespace Entidades
{
    public class LibroMayor : AsientoContable
    {
        // Herencia: Esta clase hereda de la clase AsientoContable
        #region Atributos
        private double _saldo;
        #endregion

        #region Propiedades
        public double Saldo { get => _saldo; set => _saldo = value; }
        #endregion

        #region Constructores
        public LibroMayor() { }
        public LibroMayor(long id, long asientoNro, DateTime asientoFecha, CuentaContable cuentaContable, string descripcion, double debe, double haber, double saldo, string conciliacion, string origenTipo, long origenId)
            : base(id, asientoNro, asientoFecha, cuentaContable, descripcion, debe, haber, conciliacion, origenTipo, origenId)
        {
            _saldo = saldo;
        }
        #endregion
    }
}