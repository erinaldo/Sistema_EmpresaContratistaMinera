using Entidades.Catalogo;
using System;

namespace Entidades
{
    public class Cliente : IEquatable<Cliente>
    {
        #region Atributos
        private long _id;
        private string _denominacion;
        private string _cuit;
        private string _iva;
        private string _domicilio;
        private string _provincia;
        private string _distrito;
        private string _cp;
        private string _telefono;
        private string _celular;
        private string _email;
        private string _paginaWeb;
        private Banco _banco;
        private string _ctaBancariaTipo;
        private string _ctaBancariaNro;
        private CuentaContable _cuentaContable;
        private double _saldo;
        private string _estado;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public string Cuit { get => _cuit; set => _cuit = value; }
        public string Iva { get => _iva; set => _iva = value; }
        public string Domicilio { get => _domicilio; set => _domicilio = value; }
        public string Provincia { get => _provincia; set => _provincia = value; }
        public string Distrito { get => _distrito; set => _distrito = value; }
        public string Cp { get => _cp; set => _cp = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Celular { get => _celular; set => _celular = value; }
        public string Email { get => _email; set => _email = value; }
        public string PaginaWeb { get => _paginaWeb; set => _paginaWeb = value; }
        public Banco Banco { get => _banco; set => _banco = value; }
        public string CtaBancariaTipo { get => _ctaBancariaTipo; set => _ctaBancariaTipo = value; }
        public string CtaBancariaNro { get => _ctaBancariaNro; set => _ctaBancariaNro = value; }
        public CuentaContable CuentaContable { get => _cuentaContable; set => _cuentaContable = value; }
        public double Saldo { get => _saldo; set => _saldo = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public Cliente() { }
        public Cliente(long id, string denominacion, string cuit) //Constructor parcial del Catálogo
        {
            _id = id;
            _denominacion = denominacion;
            _cuit = cuit;
        }
        public Cliente(long id, string denominacion, string cuit, string telefono, string celular, string estado) //Constructor parcial para lista de Campos Especificos (Reporte Espécifico - Basico) 
        {
            _id = id;
            _denominacion = denominacion;
            _cuit = cuit;
            _telefono = telefono;
            _celular = celular;
            _estado = estado;
        }
        public Cliente(long id, string denominacion, string cuit, string iva, string domicilio, string provincia, string distrito, string cp, string telefono, string celular, string email, string paginaWeb, Banco banco, string ctaBancariaTipo, string ctaBancariaNro, CuentaContable cuentaContable, double saldo, string estado, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _denominacion = denominacion;
            _cuit = cuit;
            _iva = iva;
            _domicilio = domicilio;
            _provincia = provincia;
            _distrito = distrito;
            _cp = cp;
            _telefono = telefono;
            _celular = celular;
            _email = email;
            _paginaWeb = paginaWeb;
            _banco = banco;
            _ctaBancariaTipo = ctaBancariaTipo;
            _ctaBancariaNro = ctaBancariaNro;
            _cuentaContable = cuentaContable;
            _saldo = saldo;
            _estado = estado;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(Cliente objCliente)
        {
            if (objCliente != null &&
                _id == objCliente._id &&
                _denominacion == objCliente._denominacion &&
                _cuit == objCliente._cuit &&
                _iva == objCliente._iva &&
                _domicilio == objCliente._domicilio &&
                _provincia == objCliente._provincia &&
                _distrito == objCliente._distrito &&
                _cp == objCliente._cp &&
                _telefono == objCliente._telefono &&
                _celular == objCliente._celular &&
                _email == objCliente._email &&
                _paginaWeb == objCliente._paginaWeb &&
                _banco.Id == objCliente._banco.Id &&
                _ctaBancariaTipo == objCliente._ctaBancariaTipo &&
                _ctaBancariaNro == objCliente._ctaBancariaNro &&
                _cuentaContable.Id == objCliente._cuentaContable.Id &&
                _saldo == objCliente._saldo &&
                _estado == objCliente._estado) return true;
            return false;
        }
        #endregion
    }
}