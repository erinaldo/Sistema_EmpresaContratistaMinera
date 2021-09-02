using System;
using System.Collections.Generic;

namespace Entidades
{
    public class AsientoManual : IEquatable<AsientoManual>
    {
        #region Atributos
        private long _id;
        private int _cbteTPV;
        private long _cbteNro;
        private DateTime _cbteFecha;
        private string _estado;
        private string _denominacion;
        private CentroCosto _centroCosto;
        private double _totalDebe;
        private double _totalHaber;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public int CbteTPV { get => _cbteTPV; set => _cbteTPV = value; }
        public long CbteNro { get => _cbteNro; set => _cbteNro = value; }
        public DateTime CbteFecha { get => _cbteFecha; set => _cbteFecha = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public CentroCosto CentroCosto { get => _centroCosto; set => _centroCosto = value; }
        public double TotalDebe { get => _totalDebe; set => _totalDebe = value; }
        public double TotalHaber { get => _totalHaber; set => _totalHaber = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public AsientoManual() { }
        public AsientoManual(long id, int cbteTPV, long cbteNro, DateTime cbteFecha, string estado, string denominacion, CentroCosto centroCosto, double totalDebe, double totalHaber, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _cbteTPV = cbteTPV;
            _cbteNro = cbteNro;
            _cbteFecha = cbteFecha;
            _estado = estado;
            _denominacion = denominacion;
            _centroCosto = centroCosto;
            _totalDebe = totalDebe;
            _totalHaber = totalHaber;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(AsientoManual objAsientoManual)
        {
            if (objAsientoManual != null &&
                _id == objAsientoManual._id &&
                _cbteTPV == objAsientoManual._cbteTPV &&
                _cbteNro == objAsientoManual._cbteNro &&
                _cbteFecha == objAsientoManual._cbteFecha &&
                _estado == objAsientoManual._estado &&
                _denominacion == objAsientoManual._denominacion &&
                EqualityComparer<CentroCosto>.Default.Equals(_centroCosto, objAsientoManual._centroCosto) &&
                _totalDebe == objAsientoManual._totalDebe &&
                _totalHaber == objAsientoManual._totalHaber) return true;
            return false;
        }
        #endregion
    }
}