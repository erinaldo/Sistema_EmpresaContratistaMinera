using Entidades.Catalogo;
using System;

namespace Entidades
{
    public class LegajoLaboral : IEquatable<LegajoLaboral>
    {
        #region Atributos
        private long _id;
        private Legajo _legajo;
        private CentroCosto _centroCosto;
        private DateTime _fechaIngreso;
        private DateTime _fechaEgreso;
        private string _modalidadContratacion;
        private string _modalidadContratacionTiempo;
        private Sindicato _sindicato;
        private bool _afiliadoSindical;
        private CategoriaTrabajo _categoriaTrabajo;
        private string _puesto;
        private string _sector;
        private string _modalidadLiquidacion;
        private double _remuneracion;
        private ObraSocial _obraSocial;
        private string _observacion;
        private string _estado;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public Legajo Legajo { get => _legajo; set => _legajo = value; }
        public CentroCosto CentroCosto { get => _centroCosto; set => _centroCosto = value; }
        public DateTime FechaIngreso { get => _fechaIngreso; set => _fechaIngreso = value; }
        public DateTime FechaEgreso { get => _fechaEgreso; set => _fechaEgreso = value; }
        public string ModalidadContratacion { get => _modalidadContratacion; set => _modalidadContratacion = value; }
        public string ModalidadContratacionTiempo { get => _modalidadContratacionTiempo; set => _modalidadContratacionTiempo = value; }
        public Sindicato Sindicato { get => _sindicato; set => _sindicato = value; }
        public bool AfiliadoSindical { get => _afiliadoSindical; set => _afiliadoSindical = value; }
        public CategoriaTrabajo CategoriaTrabajo { get => _categoriaTrabajo; set => _categoriaTrabajo = value; }
        public string Puesto { get => _puesto; set => _puesto = value; }
        public string Sector { get => _sector; set => _sector = value; }
        public string ModalidadLiquidacion { get => _modalidadLiquidacion; set => _modalidadLiquidacion = value; }
        public double Remuneracion { get => _remuneracion; set => _remuneracion = value; }
        public ObraSocial ObraSocial { get => _obraSocial; set => _obraSocial = value; }
        public string Observacion { get => _observacion; set => _observacion = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public LegajoLaboral() { }
        public LegajoLaboral(long id, Legajo legajo, CentroCosto centroCosto, DateTime fechaIngreso, DateTime fechaEgreso, string modalidadContratacion, string modalidadContratacionTiempo, Sindicato sindicato, bool afiliadoSindical, CategoriaTrabajo categoriaTrabajo, string puesto, string sector, string modalidadLiquidacion, double remuneracion, ObraSocial obraSocial, string observacion, string estado, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _legajo = legajo;
            _centroCosto = centroCosto;
            _fechaIngreso = fechaIngreso;
            _fechaEgreso = fechaEgreso;
            _modalidadContratacion = modalidadContratacion;
            _modalidadContratacionTiempo = modalidadContratacionTiempo;
            _sindicato = sindicato;
            _afiliadoSindical = afiliadoSindical;
            _categoriaTrabajo = categoriaTrabajo;
            _puesto = puesto;
            _sector = sector;
            _modalidadLiquidacion = modalidadLiquidacion;
            _remuneracion = remuneracion;
            _obraSocial = obraSocial;
            _observacion = observacion;
            _estado = estado;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(LegajoLaboral objLegajoLaboral)
        {
            if (objLegajoLaboral != null &&
                   _id == objLegajoLaboral._id &&
                   _legajo.Id == objLegajoLaboral._legajo.Id &&
                   _centroCosto.Id == objLegajoLaboral._centroCosto.Id &&
                   _fechaIngreso == objLegajoLaboral._fechaIngreso &&
                   _fechaEgreso == objLegajoLaboral._fechaEgreso &&
                   _modalidadContratacion == objLegajoLaboral._modalidadContratacion &&
                   _modalidadContratacionTiempo == objLegajoLaboral._modalidadContratacionTiempo &&
                   _sindicato.Id == objLegajoLaboral._sindicato.Id &&
                   _afiliadoSindical == objLegajoLaboral._afiliadoSindical &&
                   _categoriaTrabajo.Id == objLegajoLaboral._categoriaTrabajo.Id &&
                   _puesto == objLegajoLaboral._puesto &&
                   _sector == objLegajoLaboral._sector &&
                   _modalidadLiquidacion == objLegajoLaboral._modalidadLiquidacion &&
                   _remuneracion == objLegajoLaboral._remuneracion &&
                   _obraSocial.Id == objLegajoLaboral._obraSocial.Id &&
                   _observacion == objLegajoLaboral._observacion &&
                   _estado == objLegajoLaboral._estado) return true;
            return false;
        }
        #endregion
    }
}
