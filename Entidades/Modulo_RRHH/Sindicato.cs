using System;

namespace Entidades
{
    public class Sindicato : IEquatable<Sindicato>
    {
        #region Atributos
        private long _id;
        private string _convenio;
        private string _denominacion;
        private double _aporteSolidarioFijo;
        private double _aporteSolidarioTasa;
        private double _cuotaSindicalFijo;
        private double _cuotaSindicalTasa;
        private double _seguroSocialFijo;
        private double _seguroSocialTasa;
        private double _FCL_PrimerAnioTasa;
        private double _FCL_MasDeUnAnioTasa;
        private bool _incluyeTotalNR;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public string Convenio { get => _convenio; set => _convenio = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public double AporteSolidarioFijo { get => _aporteSolidarioFijo; set => _aporteSolidarioFijo = value; }
        public double AporteSolidarioTasa { get => _aporteSolidarioTasa; set => _aporteSolidarioTasa = value; }
        public double CuotaSindicalFijo { get => _cuotaSindicalFijo; set => _cuotaSindicalFijo = value; }
        public double CuotaSindicalTasa { get => _cuotaSindicalTasa; set => _cuotaSindicalTasa = value; }
        public double SeguroSocialFijo { get => _seguroSocialFijo; set => _seguroSocialFijo = value; }
        public double SeguroSocialTasa { get => _seguroSocialTasa; set => _seguroSocialTasa = value; }
        public double FCL_PrimerAnioTasa { get => _FCL_PrimerAnioTasa; set => _FCL_PrimerAnioTasa = value; }
        public double FCL_MasDeUnAnioTasa { get => _FCL_MasDeUnAnioTasa; set => _FCL_MasDeUnAnioTasa = value; }
        public bool IncluyeTotalNR { get => _incluyeTotalNR; set => _incluyeTotalNR = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public Sindicato() { }
        public Sindicato(long id, string convenio, string denominacion, double aporteSolidarioFijo, double aporteSolidarioTasa, double cuotaSindicalFijo, double cuotaSindicalTasa, double seguroSocialFijo, double seguroSocialTasa, double FCL_PrimerAnioTasa, double FCL_MasDeUnAnioTasa, bool incluyeTotalNR, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _convenio = convenio;
            _denominacion = denominacion;
            _aporteSolidarioFijo = aporteSolidarioFijo;
            _aporteSolidarioTasa = aporteSolidarioTasa;
            _cuotaSindicalFijo = cuotaSindicalFijo;
            _cuotaSindicalTasa = cuotaSindicalTasa;
            _seguroSocialFijo = seguroSocialFijo;
            _seguroSocialTasa = seguroSocialTasa;
            _FCL_PrimerAnioTasa = FCL_PrimerAnioTasa;
            _FCL_MasDeUnAnioTasa = FCL_MasDeUnAnioTasa;
            _incluyeTotalNR = incluyeTotalNR;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(Sindicato objSindicato)
        {
            if (objSindicato != null &&
                _id == objSindicato._id &&
                _convenio == objSindicato._convenio &&
                _denominacion == objSindicato._denominacion &&
                _aporteSolidarioFijo == objSindicato._aporteSolidarioFijo &&
                _aporteSolidarioTasa == objSindicato._aporteSolidarioTasa &&
                _cuotaSindicalFijo == objSindicato._cuotaSindicalFijo &&
                _cuotaSindicalTasa == objSindicato._cuotaSindicalTasa &&
                _seguroSocialFijo == objSindicato._seguroSocialFijo &&
                _seguroSocialTasa == objSindicato._seguroSocialTasa &&
                _FCL_PrimerAnioTasa == objSindicato._FCL_PrimerAnioTasa &&
                _FCL_MasDeUnAnioTasa == objSindicato._FCL_MasDeUnAnioTasa &&
                _incluyeTotalNR == objSindicato._incluyeTotalNR) return true;
            return false;
        }
        #endregion
    }
}
