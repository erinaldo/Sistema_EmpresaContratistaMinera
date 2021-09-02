using System;

namespace Entidades
{
    public class FormularioR29911
    {
        #region Atributos
        private long _id;
        private DateTime _fecha;
        private string _estado;
        private Legajo _legajo;
        private CentroCosto _centroCosto;
        private string _descripcionPuesto;
        private string _eppPuesto;
        private string _informacionAdicional;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public Legajo Legajo { get => _legajo; set => _legajo = value; }
        public CentroCosto CentroCosto { get => _centroCosto; set => _centroCosto = value; }
        public string DescripcionPuesto { get => _descripcionPuesto; set => _descripcionPuesto = value; }
        public string EppPuesto { get => _eppPuesto; set => _eppPuesto = value; }
        public string InformacionAdicional { get => _informacionAdicional; set => _informacionAdicional = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public FormularioR29911() { }
        public FormularioR29911(long id, DateTime fecha, string estado, Legajo legajo, CentroCosto centroCosto, string descripcionPuesto, string eppPuesto, string informacionAdicional, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _fecha = fecha;
            _estado = estado;
            _legajo = legajo;
            _centroCosto = centroCosto;
            _descripcionPuesto = descripcionPuesto;
            _eppPuesto = eppPuesto;
            _informacionAdicional = informacionAdicional;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion
    }
}