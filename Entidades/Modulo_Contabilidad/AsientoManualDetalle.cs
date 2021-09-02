using System;
using System.Collections.Generic;

namespace Entidades
{
    public class AsientoManualDetalle : IEquatable<AsientoManualDetalle>
    {
        #region Atributos
        private long _id;
        private AsientoManual _asientoManual;
        private CuentaContable _cuentaContable;
        private double _debe;
        private double _haber;
        private string _conciliacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public AsientoManual AsientoManual { get => _asientoManual; set => _asientoManual = value; }
        public CuentaContable CuentaContable { get => _cuentaContable; set => _cuentaContable = value; }
        public double Debe { get => _debe; set => _debe = value; }
        public double Haber { get => _haber; set => _haber = value; }
        public string Conciliacion { get => _conciliacion; set => _conciliacion = value; }
        #endregion

        #region Constructores
        public AsientoManualDetalle() { }
        public AsientoManualDetalle(long id, AsientoManual asientoManual, CuentaContable cuentaContable, double debe, double haber, string conciliacion)
        {
            _id = id;
            _asientoManual = asientoManual;
            _cuentaContable = cuentaContable;
            _debe = debe;
            _haber = haber;
            _conciliacion = conciliacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(AsientoManualDetalle objAsientoManualDetalle)
        {
            if (objAsientoManualDetalle != null &&
                _id == objAsientoManualDetalle._id &&
                EqualityComparer<AsientoManual>.Default.Equals(_asientoManual, objAsientoManualDetalle._asientoManual) &&
                EqualityComparer<CuentaContable>.Default.Equals(_cuentaContable, objAsientoManualDetalle._cuentaContable) &&
                _debe == objAsientoManualDetalle._debe &&
                _haber == objAsientoManualDetalle._haber &&
                _conciliacion == objAsientoManualDetalle._conciliacion) return true;
            return false;
        }
        #endregion
    }
}