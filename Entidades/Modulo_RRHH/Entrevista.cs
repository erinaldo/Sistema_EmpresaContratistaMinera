using System;

namespace Entidades
{
    public class Entrevista : IEquatable<Entrevista>
    {
        #region Atributos
        private long _id;
        private Legajo _legajo;
        private DateTime _cita;
        private bool _citaAlertado;
        private string _modalidad;
        private string _propuesta;
        private string _analisis;
        private string _disponibilidad;
        private string _calificacion;
        private string _estado;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public Legajo Legajo { get => _legajo; set => _legajo = value; }
        public DateTime Cita { get => _cita; set => _cita = value; }
        public bool CitaAlertado { get => _citaAlertado; set => _citaAlertado = value; }
        public string Modalidad { get => _modalidad; set => _modalidad = value; }
        public string Propuesta { get => _propuesta; set => _propuesta = value; }
        public string Analisis { get => _analisis; set => _analisis = value; }
        public string Disponibilidad { get => _disponibilidad; set => _disponibilidad = value; }
        public string Calificacion { get => _calificacion; set => _calificacion = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public Entrevista() { }
        public Entrevista(long id, Legajo legajo, DateTime cita, bool citaAlertado, string modalidad, string propuesta, string analisis, string disponibilidad, string calificacion, string estado, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _legajo = legajo;
            _cita = cita;
            _citaAlertado = citaAlertado;
            _modalidad = modalidad;
            _propuesta = propuesta;
            _analisis = analisis;
            _disponibilidad = disponibilidad;
            _calificacion = calificacion;
            _estado = estado;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(Entrevista objEntrevista)
        {
            if (objEntrevista != null &&
                _id == objEntrevista._id &&
                _legajo.Id == objEntrevista._legajo.Id &&
                _cita == objEntrevista._cita &&
                _citaAlertado == objEntrevista._citaAlertado &&
                _modalidad == objEntrevista._modalidad &&
                _propuesta == objEntrevista._propuesta &&
                _analisis == objEntrevista._analisis &&
                _disponibilidad == objEntrevista._disponibilidad &&
                _calificacion == objEntrevista._calificacion &&
                _estado == objEntrevista._estado) return true;
            return false;
        }
        #endregion
    }
}
