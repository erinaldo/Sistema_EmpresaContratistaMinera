using System;

namespace Entidades
{
    public class FacturaACobrar : AsientoContable
    {
        // Herencia: Esta clase hereda de la clase AsientoContable
        #region Atributos
        private string _estadoCobro;
        private string _denominacion;
        private string _cuit;
        #endregion

        #region Propiedades
        public string EstadoCobro { get => _estadoCobro; set => _estadoCobro = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public string Cuit { get => _cuit; set => _cuit = value; }
        #endregion

        #region Constructores
        public FacturaACobrar() { }
        public FacturaACobrar(long id, long asientoNro, DateTime asientoFecha, CuentaContable cuentaContable, string descripcion, double debe, double haber, string estadoCobro, string origenTipo, long origenId, string denominacion, string cuit)
            : base(id, asientoNro, asientoFecha, cuentaContable, descripcion, debe, haber, origenTipo, origenId)
        {
            _estadoCobro = estadoCobro;
            _denominacion = denominacion;
            _cuit = cuit;
        }
        #endregion
    }
}