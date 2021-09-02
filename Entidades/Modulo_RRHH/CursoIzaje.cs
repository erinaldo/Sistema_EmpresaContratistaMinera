using System;

namespace Entidades
{
    public class CursoIzaje : IEquatable<CursoIzaje>
    {
        #region Atributos
        private long _id;
        private Legajo _legajo;
        private CentroCosto _centroCosto;
        private DateTime _fechaEmision;
        private bool _fechaEmisionAlertado;
        private bool _item1;
        private bool _item2;
        private bool _item3;
        private bool _item4;
        private bool _item5;
        private bool _item6;
        private bool _item7;
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
        public DateTime FechaEmision { get => _fechaEmision; set => _fechaEmision = value; }
        public bool FechaEmisionAlertado { get => _fechaEmisionAlertado; set => _fechaEmisionAlertado = value; }
        public bool Item1 { get => _item1; set => _item1 = value; }
        public bool Item2 { get => _item2; set => _item2 = value; }
        public bool Item3 { get => _item3; set => _item3 = value; }
        public bool Item4 { get => _item4; set => _item4 = value; }
        public bool Item5 { get => _item5; set => _item5 = value; }
        public bool Item6 { get => _item6; set => _item6 = value; }
        public bool Item7 { get => _item7; set => _item7 = value; }
        public string Observacion { get => _observacion; set => _observacion = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public CursoIzaje() { }
        public CursoIzaje(long id, Legajo legajo, CentroCosto centroCosto, DateTime fechaEmision, bool fechaEmisionAlertado, bool item1, bool item2, bool item3, bool item4, bool item5, bool item6, bool item7, string observacion, string estado, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _legajo = legajo;
            _centroCosto = centroCosto;
            _fechaEmision = fechaEmision;
            _fechaEmisionAlertado = fechaEmisionAlertado;
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
            _item5 = item5;
            _item6 = item6;
            _item7 = item7;
            _observacion = observacion;
            _estado = estado;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(CursoIzaje objCursoIzaje)
        {
            if (objCursoIzaje != null &&
                _id == objCursoIzaje._id &&
                _legajo.Id == objCursoIzaje._legajo.Id &&
                _centroCosto.Id == objCursoIzaje._centroCosto.Id &&
                _fechaEmision == objCursoIzaje._fechaEmision &&
                _fechaEmisionAlertado == objCursoIzaje._fechaEmisionAlertado &&
                _item1 == objCursoIzaje._item1 &&
                _item2 == objCursoIzaje._item2 &&
                _item3 == objCursoIzaje._item3 &&
                _item4 == objCursoIzaje._item4 &&
                _item5 == objCursoIzaje._item5 &&
                _item6 == objCursoIzaje._item6 &&
                _item7 == objCursoIzaje._item7 &&
                _observacion == objCursoIzaje._observacion &&
                _estado == objCursoIzaje._estado) return true;
            return false;
        }
        #endregion
    }
}
