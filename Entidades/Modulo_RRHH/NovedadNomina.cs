using System;

namespace Entidades
{
    public class NovedadNomina : IEquatable<NovedadNomina>
    {
        #region Atributos
        private long _id;
        private DateTime _fechaEmision;
        private string _periodo;
        private string _estado;
        private Legajo _legajo;
        private CentroCosto _centroCosto;
        private string _novedadTipo;
        private DateTime _unidad_inicializacion;
        private DateTime _unidad_finalizacion;
        private int _unidadHoras;
        private int _unidadDias;
        private double _unidadMonto;
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
        public string NovedadTipo { get => _novedadTipo; set => _novedadTipo = value; }
        public DateTime Unidad_inicializacion { get => _unidad_inicializacion; set => _unidad_inicializacion = value; }
        public DateTime Unidad_finalizacion { get => _unidad_finalizacion; set => _unidad_finalizacion = value; }
        public int UnidadHoras { get => _unidadHoras; set => _unidadHoras = value; }
        public int UnidadDias { get => _unidadDias; set => _unidadDias = value; }
        public double UnidadMonto { get => _unidadMonto; set => _unidadMonto = value; }
        public string Observacion { get => _observacion; set => _observacion = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public NovedadNomina() { }
        public NovedadNomina(long id, DateTime fechaEmision, string periodo, string estado, Legajo legajo, CentroCosto centroCosto, string novedadTipo, DateTime unidad_inicializacion, DateTime unidad_finalizacion, int unidadHoras, int unidadDias, double unidadMonto, string observacion, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _fechaEmision = fechaEmision;
            _periodo = periodo;
            _estado = estado;
            _legajo = legajo;
            _centroCosto = centroCosto;
            _novedadTipo = novedadTipo;
            _unidad_inicializacion = unidad_inicializacion;
            _unidad_finalizacion = unidad_finalizacion;
            _unidadHoras = unidadHoras;
            _unidadDias = unidadDias;
            _unidadMonto = unidadMonto;
            _observacion = observacion;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(NovedadNomina objNovedadNomina)
        {
            if (objNovedadNomina != null &&
                Id == objNovedadNomina.Id &&
                FechaEmision == objNovedadNomina.FechaEmision &&
                Periodo == objNovedadNomina.Periodo &&
                Estado == objNovedadNomina.Estado &&
                Legajo.Id == objNovedadNomina.Legajo.Id &&
                CentroCosto.Id == objNovedadNomina.CentroCosto.Id &&
                NovedadTipo == objNovedadNomina.NovedadTipo &&
                Unidad_inicializacion == objNovedadNomina.Unidad_inicializacion &&
                Unidad_finalizacion == objNovedadNomina.Unidad_finalizacion &&
                UnidadHoras == objNovedadNomina.UnidadHoras &&
                UnidadDias == objNovedadNomina.UnidadDias &&
                UnidadMonto == objNovedadNomina.UnidadMonto &&
                Observacion == objNovedadNomina.Observacion) return true;
            return false;
        }
        #endregion
    }
}