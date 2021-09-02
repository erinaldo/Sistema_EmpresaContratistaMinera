using System;
using System.Collections.Generic;

namespace Entidades
{
    public class RentabilidadCentroCostoDetalleCosto : IEquatable<RentabilidadCentroCostoDetalleCosto>
    {
        #region Atributos
        private long _id;
        private RentabilidadCentroCosto _rentabilidadCentroCosto;
        private CuentaContable _cuentaContable;
        private double _presupuestoCosto;
        private double _presupuestoCostoIncidencia;
        private double _realCosto;
        private double _realCostoIncidencia;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public RentabilidadCentroCosto RentabilidadCentroCosto { get => _rentabilidadCentroCosto; set => _rentabilidadCentroCosto = value; }
        public CuentaContable CuentaContable { get => _cuentaContable; set => _cuentaContable = value; }
        public double PresupuestoCosto { get => _presupuestoCosto; set => _presupuestoCosto = value; }
        public double PresupuestoCostoIncidencia { get => _presupuestoCostoIncidencia; set => _presupuestoCostoIncidencia = value; }
        public double RealCosto { get => _realCosto; set => _realCosto = value; }
        public double RealCostoIncidencia { get => _realCostoIncidencia; set => _realCostoIncidencia = value; }
        #endregion

        #region Constructores
        public RentabilidadCentroCostoDetalleCosto() { }
        public RentabilidadCentroCostoDetalleCosto(long id, RentabilidadCentroCosto rentabilidadCentroCosto, CuentaContable cuentaContable, double presupuestoCosto, double presupuestoCostoIncidencia, double realCosto, double realCostoIncidencia)
        {
            _id = id;
            _rentabilidadCentroCosto = rentabilidadCentroCosto;
            _cuentaContable = cuentaContable;
            _presupuestoCosto = presupuestoCosto;
            _presupuestoCostoIncidencia = presupuestoCostoIncidencia;
            _realCosto = realCosto;
            _realCostoIncidencia = realCostoIncidencia;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(RentabilidadCentroCostoDetalleCosto objRentabilidadCentroCostoDetalleCosto)
        {
            if (objRentabilidadCentroCostoDetalleCosto != null &&
                _id == objRentabilidadCentroCostoDetalleCosto._id &&
                EqualityComparer<CuentaContable>.Default.Equals(_cuentaContable, objRentabilidadCentroCostoDetalleCosto._cuentaContable) &&
                _presupuestoCosto == objRentabilidadCentroCostoDetalleCosto._presupuestoCosto &&
                _presupuestoCostoIncidencia == objRentabilidadCentroCostoDetalleCosto._presupuestoCostoIncidencia &&
                _realCosto == objRentabilidadCentroCostoDetalleCosto._realCosto &&
                _realCostoIncidencia == objRentabilidadCentroCostoDetalleCosto._realCostoIncidencia) return true;
            return false;
        }
        #endregion
    }
}