using System;

namespace Entidades
{
    public class LegajoTalle : IEquatable<LegajoTalle>
    {
        #region Atributos
        private long _id;
        private Legajo _legajo;
        private string _talleCamisa;
        private string _tallePantalon;
        private string _talleCalzado;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public Legajo Legajo { get => _legajo; set => _legajo = value; }
        public string TalleCamisa { get => _talleCamisa; set => _talleCamisa = value; }
        public string TallePantalon { get => _tallePantalon; set => _tallePantalon = value; }
        public string TalleCalzado { get => _talleCalzado; set => _talleCalzado = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public LegajoTalle() { }
        public LegajoTalle(long id, Legajo legajo, string talleCamisa, string tallePantalon, string talleCalzado, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _legajo = legajo;
            _talleCamisa = talleCamisa;
            _tallePantalon = tallePantalon;
            _talleCalzado = talleCalzado;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(LegajoTalle objLegajoTalle)
        {
            if (objLegajoTalle != null &&
                _id == objLegajoTalle._id &&
                _legajo.Id == objLegajoTalle._legajo.Id &&
                _talleCamisa == objLegajoTalle._talleCamisa &&
                _tallePantalon == objLegajoTalle._tallePantalon &&
                _talleCalzado == objLegajoTalle._talleCalzado) return true;
            return false;
        }
        #endregion
    }
}
