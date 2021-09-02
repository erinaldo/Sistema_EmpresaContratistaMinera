using System;

namespace Entidades.Sistema
{
    public class Auditoria
    {
        #region Atributos
        private long _id;
        private string _documento;
        private DateTime _fecha;
        private string _modulo;
        private string _denominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public string Documento { get => _documento; set => _documento = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string Modulo { get => _modulo; set => _modulo = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        #endregion

        #region Constructores
        public Auditoria() { }
        public Auditoria(long id, DateTime fecha, string modulo, string denominacion)
        {
            _id = id;
            _fecha = fecha;
            _modulo = modulo;
            _denominacion = denominacion;
        }
        public Auditoria(long id, string documento, DateTime fecha, string modulo, string denominacion)
        {
            _id = id;
            _documento = documento;
            _fecha = fecha;
            _modulo = modulo;
            _denominacion = denominacion;
        }
        #endregion
    }
}
