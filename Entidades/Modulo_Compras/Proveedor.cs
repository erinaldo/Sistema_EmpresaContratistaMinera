using Entidades.Catalogo;
using System;

namespace Entidades
{
    public class Proveedor : IEquatable<Proveedor>
    {
        #region Atributos
        private long _id;
        private string _denominacion;
        private string _nombreFantasia;
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
        private string _contactoDenominacion;
        private string _contactoTelefono;
        private string _contactoCelular;
        private string _contactoEmail;
        private string _estado;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public string NombreFantasia { get => _nombreFantasia; set => _nombreFantasia = value; }
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
        public string ContactoDenominacion { get => _contactoDenominacion; set => _contactoDenominacion = value; }
        public string ContactoTelefono { get => _contactoTelefono; set => _contactoTelefono = value; }
        public string ContactoCelular { get => _contactoCelular; set => _contactoCelular = value; }
        public string ContactoEmail { get => _contactoEmail; set => _contactoEmail = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public Proveedor() { }
        public Proveedor(long id, string denominacion, string cuit) //Constructor parcial del Catálogo 
        {
            _id = id;
            _denominacion = denominacion;
            _cuit = cuit;
        }
        public Proveedor(long id, string denominacion, string nombreFantasia, string cuit, double saldo, string estado) //Constructor parcial para lista de Campos Especificos (Reporte Espécifico - Basico)
        {
            _id = id;
            _denominacion = denominacion;
            _nombreFantasia = nombreFantasia;
            _cuit = cuit;
            _saldo = saldo;
            _estado = estado;
        }
        public Proveedor(long id, string denominacion, string nombreFantasia, string cuit, string iva, string domicilio, string provincia, string distrito, string cp, string telefono, string celular, string email, string paginaWeb, Banco banco, string ctaBancariaTipo, string ctaBancariaNro, CuentaContable cuentaContable, double saldo, string contactoDenominacion, string contactoTelefono, string contactoCelular, string contactoEmail, string estado, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _denominacion = denominacion;
            _nombreFantasia = nombreFantasia;
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
            _contactoDenominacion = contactoDenominacion;
            _contactoTelefono = contactoTelefono;
            _contactoCelular = contactoCelular;
            _contactoEmail = contactoEmail;
            _estado = estado;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(Proveedor objProveedor)
        {
            if (objProveedor != null &&
                _id == objProveedor._id &&
                _denominacion == objProveedor._denominacion &&
                _nombreFantasia == objProveedor._nombreFantasia &&
                _cuit == objProveedor._cuit &&
                _iva == objProveedor._iva &&
                _domicilio == objProveedor._domicilio &&
                _provincia == objProveedor._provincia &&
                _distrito == objProveedor._distrito &&
                _cp == objProveedor._cp &&
                _telefono == objProveedor._telefono &&
                _celular == objProveedor._celular &&
                _email == objProveedor._email &&
                _paginaWeb == objProveedor._paginaWeb &&
                _banco.Id == objProveedor._banco.Id &&
                _ctaBancariaTipo == objProveedor._ctaBancariaTipo &&
                _ctaBancariaNro == objProveedor._ctaBancariaNro &&
                _cuentaContable.Id == objProveedor._cuentaContable.Id &&
                _saldo == objProveedor._saldo &&
                _contactoDenominacion == objProveedor._contactoDenominacion &&
                _contactoTelefono == objProveedor._contactoTelefono &&
                _contactoCelular == objProveedor._contactoCelular &&
                _contactoEmail == objProveedor._contactoEmail &&
                _estado == objProveedor._estado) return true;
            return false;
        }
        #endregion
    }
}