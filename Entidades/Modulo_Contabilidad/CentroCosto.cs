using System;

namespace Entidades
{
    public class CentroCosto : IEquatable<CentroCosto>
    {
        #region Atributos
        private long _id;
        private string _denominacion;
        private string _deposito;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public string Deposito { get => _deposito; set => _deposito = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public CentroCosto() { }
        public CentroCosto(long id, string denominacion, string deposito, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _denominacion = denominacion;
            _deposito = deposito;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(CentroCosto objCentroCosto)
        {
            if (objCentroCosto != null &&
                _id == objCentroCosto._id &&
                _denominacion == objCentroCosto._denominacion &&
                _deposito == objCentroCosto._deposito) return true;
            return false;
        }
        #endregion
    }
}