using Entidades.Catalogo;
using System;

namespace Entidades
{
    public class Contrato : IEquatable<Contrato>
    {
        #region Atributos
        private long _id;
        private Legajo _legajo;
        private CentroCosto _centroCosto;
        private DateTime _fechaAlta;
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
        private string _estado;
        private bool _rescision;
        private DateTime _rescisionFecha;
        private string _rescisionObservacion;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public Legajo Legajo { get => _legajo; set => _legajo = value; }
        public CentroCosto CentroCosto { get => _centroCosto; set => _centroCosto = value; }
        public DateTime FechaAlta { get => _fechaAlta; set => _fechaAlta = value; }
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
        public string Estado { get => _estado; set => _estado = value; }
        public bool Rescision { get => _rescision; set => _rescision = value; }
        public DateTime RescisionFecha { get => _rescisionFecha; set => _rescisionFecha = value; }
        public string RescisionObservacion { get => _rescisionObservacion; set => _rescisionObservacion = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public Contrato() { }
        public Contrato(long id, Legajo legajo, CentroCosto centroCosto, DateTime fechaAlta, string modalidadContratacion, string modalidadContratacionTiempo, Sindicato sindicato, bool afiliadoSindical, CategoriaTrabajo categoriaTrabajo, string puesto, string sector, string modalidadLiquidacion, double remuneracion, ObraSocial obraSocial, string estado, bool rescision, DateTime rescisionFecha, string rescisionObservacion, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _legajo = legajo;
            _centroCosto = centroCosto;
            _fechaAlta = fechaAlta;
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
            _estado = estado;
            _rescision = rescision;
            _rescisionFecha = rescisionFecha;
            _rescisionObservacion = rescisionObservacion;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(Contrato objContrato)
        {
            if (objContrato != null &&
                _id == objContrato._id &&
                _legajo.Id == objContrato._legajo.Id &&
                _centroCosto.Id == objContrato._centroCosto.Id &&
                _fechaAlta == objContrato._fechaAlta &&
                _modalidadContratacion == objContrato._modalidadContratacion &&
                _modalidadContratacionTiempo == objContrato._modalidadContratacionTiempo &&
                _sindicato.Id == objContrato._sindicato.Id &&
                _afiliadoSindical == objContrato._afiliadoSindical &&
                _obraSocial.Id == objContrato._obraSocial.Id &&
                _puesto == objContrato._puesto &&
                _sector == objContrato._sector &&
                _modalidadLiquidacion == objContrato._modalidadLiquidacion &&
                _remuneracion == objContrato._remuneracion &&
                _obraSocial.Id == objContrato._obraSocial.Id &&
                _estado == objContrato._estado &&
                _rescision == objContrato._rescision &&
                _rescisionFecha == objContrato._rescisionFecha &&
                _rescisionObservacion == objContrato._rescisionObservacion) return true;
            return false;
        }
        #endregion
    }
}
