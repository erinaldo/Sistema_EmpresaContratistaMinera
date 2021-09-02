using System;

namespace Entidades
{
    public class FacturaAPagar : AsientoContable
    {
        // Herencia: Esta clase hereda de la clase AsientoContable
        #region Atributos
        private string _estadoPago;
        private string _denominacion;
        private string _cuit;
        #endregion

        #region Propiedades
        public string EstadoPago { get => _estadoPago; set => _estadoPago = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public string Cuit { get => _cuit; set => _cuit = value; }
        #endregion

        #region Constructores
        public FacturaAPagar() { }
        public FacturaAPagar(long id, long asientoNro, DateTime asientoFecha, CuentaContable cuentaContable, string descripcion, double debe, double haber, string estadoPago, string origenTipo, long origenId, string denominacion, string cuit)
            : base(id, asientoNro, asientoFecha, cuentaContable, descripcion, debe, haber, origenTipo, origenId)
        {
            _estadoPago = estadoPago;
            _denominacion = denominacion;
            _cuit = cuit;
        }
        #endregion
    }
}