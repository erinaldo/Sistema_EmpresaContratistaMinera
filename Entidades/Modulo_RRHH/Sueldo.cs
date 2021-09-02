using System;

namespace Entidades
{
    public class Sueldo : IEquatable<Sueldo>
    {
        #region Atributos
        private long _id;
        private DateTime _fechaEmision;
        private string _periodo;
        private string _estado;
        private Legajo _legajo;
        private CentroCosto _centroCosto;
        private Sindicato _sindicato;
        private double _sueldoBruto;
        private double _sac;
        private double _noRemunerativo;
        private double _indemnizacionNR;
        private double _anticipoSueldo;
        private double _embargo;
        private double _aporte;
        private double _aporteSindicato;
        private double _impuestoGanancia;
        private double _sueldoNeto;
        private double _contribucionPatronal;
        private double _artScvo;
        private double _fondoCeseLaboral;
        private string _observacion;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public DateTime FechaEmision { get => _fechaEmision; set => _fechaEmision = value; }
        public string Periodo { get => _periodo; set => _periodo = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public Legajo Legajo { get => _legajo; set => _legajo = value; }
        public CentroCosto CentroCosto { get => _centroCosto; set => _centroCosto = value; }
        public Sindicato Sindicato { get => _sindicato; set => _sindicato = value; }
        public double SueldoBruto { get => _sueldoBruto; set => _sueldoBruto = value; }
        public double Sac { get => _sac; set => _sac = value; }
        public double NoRemunerativo { get => _noRemunerativo; set => _noRemunerativo = value; }
        public double IndemnizacionNR { get => _indemnizacionNR; set => _indemnizacionNR = value; }
        public double AnticipoSueldo { get => _anticipoSueldo; set => _anticipoSueldo = value; }
        public double Embargo { get => _embargo; set => _embargo = value; }
        public double Aporte { get => _aporte; set => _aporte = value; }
        public double AporteSindicato { get => _aporteSindicato; set => _aporteSindicato = value; }
        public double ImpuestoGanancia { get => _impuestoGanancia; set => _impuestoGanancia = value; }
        public double SueldoNeto { get => _sueldoNeto; set => _sueldoNeto = value; }
        public double ContribucionPatronal { get => _contribucionPatronal; set => _contribucionPatronal = value; }
        public double ArtScvo { get => _artScvo; set => _artScvo = value; }
        public double FondoCeseLaboral { get => _fondoCeseLaboral; set => _fondoCeseLaboral = value; }
        public string Observacion { get => _observacion; set => _observacion = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public Sueldo() { }
        public Sueldo(long id, DateTime fechaEmision, string periodo, string estado, Legajo legajo, CentroCosto centroCosto, Sindicato sindicato, double sueldoBruto, double sac, double noRemunerativo, double indemnizacionNR, double anticipoSueldo, double embargo, double aporte, double aporteSindicato, double impuestoGanancia, double sueldoNeto, double contribucionPatronal, double artScvo, double fondoCeseLaboral, string observacion, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _fechaEmision = fechaEmision;
            _periodo = periodo;
            _estado = estado;
            _legajo = legajo;
            _centroCosto = centroCosto;
            _sindicato = sindicato;
            _sueldoBruto = sueldoBruto;
            _sac = sac;
            _noRemunerativo = noRemunerativo;
            _indemnizacionNR = indemnizacionNR;
            _anticipoSueldo = anticipoSueldo;
            _embargo = embargo;
            _aporte = aporte;
            _aporteSindicato = aporteSindicato;
            _impuestoGanancia = impuestoGanancia;
            _sueldoNeto = sueldoNeto;
            _contribucionPatronal = contribucionPatronal;
            _artScvo = artScvo;
            _fondoCeseLaboral = fondoCeseLaboral;
            _observacion = observacion;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(Sueldo objSueldo)
        {
            if (objSueldo != null &&
                _id == objSueldo._id &&
                _fechaEmision.Date == objSueldo._fechaEmision.Date &&
                _periodo == objSueldo._periodo &&
                _estado == objSueldo._estado &&
                _legajo.Id == objSueldo._legajo.Id &&
                _centroCosto.Id == objSueldo._centroCosto.Id &&
                _sindicato.Id == objSueldo._sindicato.Id &&
                _sueldoBruto == objSueldo._sueldoBruto &&
                _sac == objSueldo._sac &&
                _noRemunerativo == objSueldo._noRemunerativo &&
                _indemnizacionNR == objSueldo._indemnizacionNR &&
                _anticipoSueldo == objSueldo._anticipoSueldo &&
                _embargo == objSueldo._embargo &&
                _aporte == objSueldo._aporte &&
                _aporteSindicato == objSueldo._aporteSindicato &&
                _impuestoGanancia == objSueldo._impuestoGanancia &&
                _sueldoNeto == objSueldo._sueldoNeto &&
                _contribucionPatronal == objSueldo._contribucionPatronal &&
                _artScvo == objSueldo._artScvo &&
                _fondoCeseLaboral == objSueldo._fondoCeseLaboral &&
                _observacion == objSueldo._observacion) return true;
            return false;
        }
        #endregion
    }
}