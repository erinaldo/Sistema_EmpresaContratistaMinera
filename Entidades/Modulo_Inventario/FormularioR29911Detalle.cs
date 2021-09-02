using System;

namespace Entidades
{
    public class FormularioR29911Detalle
    {
        #region Atributos
        private long _id;
        private FormularioR29911 _formularioR29911;
        private long _idArticulo;
        private string _denominacion;
        private string _certificacion;
        private int _cantidad;
        private string _unidad;
        private string _deposito;
        private DateTime _fechaEntrega;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public FormularioR29911 FormularioR29911 { get => _formularioR29911; set => _formularioR29911 = value; }
        public long IdArticulo { get => _idArticulo; set => _idArticulo = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public string Certificacion { get => _certificacion; set => _certificacion = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public string Unidad { get => _unidad; set => _unidad = value; }
        public string Deposito { get => _deposito; set => _deposito = value; }
        public DateTime FechaEntrega { get => _fechaEntrega; set => _fechaEntrega = value; }
        #endregion

        #region Constructores
        public FormularioR29911Detalle() { }
        public FormularioR29911Detalle(long id, FormularioR29911 formularioR29911, long idArticulo, string denominacion, string certificacion, int cantidad, string unidad, string deposito, DateTime fechaEntrega)
        {
            _id = id;
            _formularioR29911 = formularioR29911;
            _idArticulo = idArticulo;
            _denominacion = denominacion;
            _certificacion = certificacion;
            _cantidad = cantidad;
            _unidad = unidad;
            _deposito = deposito;
            _fechaEntrega = fechaEntrega;
        }
        #endregion
    }
}