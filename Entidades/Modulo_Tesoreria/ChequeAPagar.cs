using System;

namespace Entidades
{
    public class ChequeAPagar
    {
        #region Atributos
        private long _idAsiento;
        private DateTime _chequeEmision;
        private DateTime _chequeVto;
        private string _chequeNro;
        private string _denominacion;
        private double _chequeMonto;
        private string _descripcion;
        #endregion

        #region Propiedades
        public long IdAsiento { get => _idAsiento; set => _idAsiento = value; }
        public DateTime ChequeEmision { get => _chequeEmision; set => _chequeEmision = value; }
        public DateTime ChequeVto { get => _chequeVto; set => _chequeVto = value; }
        public string ChequeNro { get => _chequeNro; set => _chequeNro = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public double ChequeMonto { get => _chequeMonto; set => _chequeMonto = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        #endregion

        #region Constructores
        public ChequeAPagar() { }
        public ChequeAPagar(long idAsiento, DateTime chequeEmision, DateTime chequeVto, string chequeNro, string denominacion, double chequeMonto, string descripcion)
        {
            _idAsiento = idAsiento;
            _chequeEmision = chequeEmision;
            _chequeVto = chequeVto;
            _chequeNro = chequeNro;
            _denominacion = denominacion;
            _chequeMonto = chequeMonto;
            _descripcion = descripcion;
        }
        #endregion
    }
}