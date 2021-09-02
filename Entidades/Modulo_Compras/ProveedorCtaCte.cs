using System;

namespace Entidades
{
    public class ProveedorCtaCte : AsientoContable
    {
        // Herencia: Esta clase hereda de la clase AsientoContable
        #region Atributos
        private double _saldo;
        private string _denominacion;
        private string _cuit;
        #endregion

        #region Propiedades
        public double Saldo { get => _saldo; set => _saldo = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public string Cuit { get => _cuit; set => _cuit = value; }
        #endregion

        #region Constructores
        public ProveedorCtaCte() { }
        public ProveedorCtaCte(long id, long asientoNro, DateTime asientoFecha, CuentaContable cuentaContable, string descripcion, double debe, double haber, double saldo, string origenTipo, long origenId, string denominacion, string cuit)
            : base(id, asientoNro, asientoFecha, cuentaContable, descripcion, debe, haber, origenTipo, origenId)
        {
            _saldo = saldo;
            _denominacion = denominacion;
            _cuit = cuit;
        }
        #endregion
    }
}