using System;

namespace Entidades
{
    public class RentabilidadCentroCosto : IEquatable<RentabilidadCentroCosto>
    {
        #region Atributos
        private long _id;
        private CentroCosto _centroCosto;
        private string _periodo;
        private string _estado;
        private int _totalPresupuestoHH;
        private double _totalPresupuestoImporte;
        private int _totalRealHH;
        private double _totalRealImporte;
        private double _reajuste;
        private double _totalImporte;
        private double _totalCostoPresupuesto;
        private double _utilidadPresupuesto;
        private double _totalCostoReal;
        private double _utilidadReal;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public CentroCosto CentroCosto { get => _centroCosto; set => _centroCosto = value; }
        public string Periodo { get => _periodo; set => _periodo = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public int TotalPresupuestoHH { get => _totalPresupuestoHH; set => _totalPresupuestoHH = value; }
        public double TotalPresupuestoImporte { get => _totalPresupuestoImporte; set => _totalPresupuestoImporte = value; }
        public int TotalRealHH { get => _totalRealHH; set => _totalRealHH = value; }
        public double TotalRealImporte { get => _totalRealImporte; set => _totalRealImporte = value; }
        public double Reajuste { get => _reajuste; set => _reajuste = value; }
        public double TotalImporte { get => _totalImporte; set => _totalImporte = value; }
        public double TotalCostoPresupuesto { get => _totalCostoPresupuesto; set => _totalCostoPresupuesto = value; }
        public double UtilidadPresupuesto { get => _utilidadPresupuesto; set => _utilidadPresupuesto = value; }
        public double TotalCostoReal { get => _totalCostoReal; set => _totalCostoReal = value; }
        public double UtilidadReal { get => _utilidadReal; set => _utilidadReal = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public RentabilidadCentroCosto() { }
        public RentabilidadCentroCosto(long id, CentroCosto centroCosto, string periodo, string estado, int totalPresupuestoHH, double totalPresupuestoImporte, int totalRealHH, double totalRealImporte, double reajuste, double totalImporte, double totalCostoPresupuesto, double utilidadPresupuesto, double totalCostoReal, double utilidadReal, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _centroCosto = centroCosto;
            _periodo = periodo;
            _estado = estado;
            _totalPresupuestoHH = totalPresupuestoHH;
            _totalPresupuestoImporte = totalPresupuestoImporte;
            _totalRealHH = totalRealHH;
            _totalRealImporte = totalRealImporte;
            _reajuste = reajuste;
            _totalImporte = totalImporte;
            _totalCostoPresupuesto = totalCostoPresupuesto;
            _utilidadPresupuesto = utilidadPresupuesto;
            _totalCostoReal = totalCostoReal;
            _utilidadReal = utilidadReal;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(RentabilidadCentroCosto objRentabilidadCentroCosto)
        {
            if (objRentabilidadCentroCosto != null &&
                _id == objRentabilidadCentroCosto._id &&
                _periodo == objRentabilidadCentroCosto._periodo &&
                _estado == objRentabilidadCentroCosto._estado &&
                _totalPresupuestoHH == objRentabilidadCentroCosto._totalPresupuestoHH &&
                _totalPresupuestoImporte == objRentabilidadCentroCosto._totalPresupuestoImporte &&
                _totalRealHH == objRentabilidadCentroCosto._totalRealHH &&
                _totalRealImporte == objRentabilidadCentroCosto._totalRealImporte &&
                _reajuste == objRentabilidadCentroCosto._reajuste &&
                _totalImporte == objRentabilidadCentroCosto._totalImporte &&
                _totalCostoPresupuesto == objRentabilidadCentroCosto._totalCostoPresupuesto &&
                _utilidadPresupuesto == objRentabilidadCentroCosto._utilidadPresupuesto &&
                _totalCostoReal == objRentabilidadCentroCosto._totalCostoReal &&
                _utilidadReal == objRentabilidadCentroCosto._utilidadReal) return true;
            return false;
        }
        #endregion
    }
}