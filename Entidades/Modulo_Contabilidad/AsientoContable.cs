using System;

namespace Entidades
{
    public class AsientoContable
    {
        #region Atributos
        private long _id;
        private long _asientoNro;
        private DateTime _asientoFecha;
        private CuentaContable _cuentaContable;
        private string _descripcion;
        private double _debe;
        private double _haber;
        private string _conciliacion;
        private string _origenTipo;
        private long _origenId;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public long AsientoNro { get => _asientoNro; set => _asientoNro = value; }
        public DateTime AsientoFecha { get => _asientoFecha; set => _asientoFecha = value; }
        public CuentaContable CuentaContable { get => _cuentaContable; set => _cuentaContable = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public double Debe { get => _debe; set => _debe = value; }
        public double Haber { get => _haber; set => _haber = value; }
        public string Conciliacion { get => _conciliacion; set => _conciliacion = value; }
        public string OrigenTipo { get => _origenTipo; set => _origenTipo = value; }
        public long OrigenId { get => _origenId; set => _origenId = value; }
        #endregion

        #region Constructores
        public AsientoContable() { }
        public AsientoContable(CuentaContable cuentaContable, double debe, double haber) //Constructor Parcial: Es heredado por la Clase BalanceSumasSaldos
        {
            CuentaContable = cuentaContable;
            Debe = debe;
            Haber = haber;
        }
        public AsientoContable(long id, long asientoNro, DateTime asientoFecha, CuentaContable cuentaContable, string descripcion, double debe, double haber, string origenTipo, long origenId)
        {
            _id = id;
            _asientoNro = asientoNro;
            _asientoFecha = asientoFecha;
            _cuentaContable = cuentaContable;
            _descripcion = descripcion;
            _debe = debe;
            _haber = haber;
            _origenTipo = origenTipo;
            _origenId = origenId;
        }
        public AsientoContable(long id, long asientoNro, DateTime asientoFecha, CuentaContable cuentaContable, string descripcion, double debe, double haber, string conciliacion, string origenTipo, long origenId)
        {
            _id = id;
            _asientoNro = asientoNro;
            _asientoFecha = asientoFecha;
            _cuentaContable = cuentaContable;
            _descripcion = descripcion;
            _debe = debe;
            _haber = haber;
            _conciliacion = conciliacion;
            _origenTipo = origenTipo;
            _origenId = origenId;
        }
        #endregion
    }
}