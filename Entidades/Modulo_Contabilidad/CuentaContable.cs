using System;

namespace Entidades
{
    public class CuentaContable : IEquatable<CuentaContable>
    {
        #region Atributos
        private long _id;
        private string _codigo;
        private string _denominacion;
        private string _tipoCuenta;
        private double _saldo;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public string Codigo { get => _codigo; set => _codigo = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public string TipoCuenta { get => _tipoCuenta; set => _tipoCuenta = value; }
        public double Saldo { get => _saldo; set => _saldo = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public CuentaContable() { }
        public CuentaContable(long id, string codigo, string denominacion, string tipoCuenta, double saldo) //Constructor Parcial: Es heredado por la Clase ResumenCuentaFondo 
        {
            _id = id;
            _codigo = codigo;
            _denominacion = denominacion;
            _tipoCuenta = tipoCuenta;
            _saldo = saldo;
        }
        public CuentaContable(long id, string codigo, string denominacion, string tipoCuenta, double saldo, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _codigo = codigo;
            _denominacion = denominacion;
            _tipoCuenta = tipoCuenta;
            _saldo = saldo;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(CuentaContable objCuentaContable)
        {
            if (objCuentaContable != null &&
                _id == objCuentaContable._id &&
                _codigo == objCuentaContable._codigo &&
                _denominacion == objCuentaContable._denominacion &&
                _tipoCuenta == objCuentaContable._tipoCuenta &&
                _saldo == objCuentaContable._saldo) return true;
            return false;
        }
        #endregion
    }
}