using System;

namespace Entidades
{
    public class LibroDiario : AsientoContable
    {
        // Herencia: Esta clase hereda de la clase AsientoContable
        #region Constructores
        public LibroDiario() { }
        public LibroDiario(long id, long asientoNro, DateTime asientoFecha, CuentaContable cuentaContable, string descripcion, double debe, double haber, string conciliacion, string origenTipo, long origenId)
            : base(id, asientoNro, asientoFecha, cuentaContable, descripcion, debe, haber, conciliacion, origenTipo, origenId)
        {
        }
        #endregion
    }
}