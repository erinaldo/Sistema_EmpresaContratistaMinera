using System;

namespace Entidades
{
    public class RentabilidadCentroCostoDetalleImporte : IEquatable<RentabilidadCentroCostoDetalleImporte>
    {
        #region Atributos
        private long _id;
        private RentabilidadCentroCosto _rentabilidadCentroCosto;
        private string _denominacion;
        private double _valorHora;
        private int _presupuestoHH;
        private double _presupuestoImporte;
        private int _realHH;
        private double _realImporte;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public RentabilidadCentroCosto RentabilidadCentroCosto { get => _rentabilidadCentroCosto; set => _rentabilidadCentroCosto = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public double ValorHora { get => _valorHora; set => _valorHora = value; }
        public int PresupuestoHH { get => _presupuestoHH; set => _presupuestoHH = value; }
        public double PresupuestoImporte { get => _presupuestoImporte; set => _presupuestoImporte = value; }
        public int RealHH { get => _realHH; set => _realHH = value; }
        public double RealImporte { get => _realImporte; set => _realImporte = value; }
        #endregion

        #region Constructores
        public RentabilidadCentroCostoDetalleImporte() { }
        public RentabilidadCentroCostoDetalleImporte(long id, RentabilidadCentroCosto rentabilidadCentroCosto, string denominacion, double valorHora, int presupuestoHH, double presupuestoImporte, int realHH, double realImporte)
        {
            _id = id;
            _rentabilidadCentroCosto = rentabilidadCentroCosto;
            _denominacion = denominacion;
            _valorHora = valorHora;
            _presupuestoHH = presupuestoHH;
            _presupuestoImporte = presupuestoImporte;
            _realHH = realHH;
            _realImporte = realImporte;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(RentabilidadCentroCostoDetalleImporte objRentabilidadCentroCostoDetalleImporte)
        {
            if (objRentabilidadCentroCostoDetalleImporte != null &&
                _id == objRentabilidadCentroCostoDetalleImporte._id &&
                _denominacion == objRentabilidadCentroCostoDetalleImporte._denominacion &&
                _valorHora == objRentabilidadCentroCostoDetalleImporte._valorHora &&
                _presupuestoHH == objRentabilidadCentroCostoDetalleImporte._presupuestoHH &&
                _presupuestoImporte == objRentabilidadCentroCostoDetalleImporte._presupuestoImporte &&
                _realHH == objRentabilidadCentroCostoDetalleImporte._realHH &&
                _realImporte == objRentabilidadCentroCostoDetalleImporte._realImporte) return true;
            return false;
        }
        #endregion
    }
}