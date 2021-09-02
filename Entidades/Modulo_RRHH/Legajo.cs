using Entidades.Catalogo;
using System;

namespace Entidades
{
    public class Legajo : IEquatable<Legajo>
    {
        #region Atributos
        private long _id;
        private string _denominacion;
        private string _sexo;
        private long _documento;
        private long _cuit;
        private DateTime _fechaNacimiento;
        private string _tipoSangre;
        private string _nacionalidad;
        private string _estadoCivil;
        private int _cantidadHijo;
        private string _domicilio;
        private string _provincia;
        private string _distrito;
        private int _cp;
        private bool _comunidad;
        private string _celular1;
        private string _celular2;
        private string _celular3;
        private string _email;
        private Banco _banco;
        private string _ctaBancariaTipo;
        private string _ctaBancariaNro;
        private string _observacion;
        private double _saldo;
        private bool _baja;
        private bool _informacionRestringida;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public string Sexo { get => _sexo; set => _sexo = value; }
        public long Documento { get => _documento; set => _documento = value; }
        public long Cuit { get => _cuit; set => _cuit = value; }
        public DateTime FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public string TipoSangre { get => _tipoSangre; set => _tipoSangre = value; }
        public string Nacionalidad { get => _nacionalidad; set => _nacionalidad = value; }
        public string EstadoCivil { get => _estadoCivil; set => _estadoCivil = value; }
        public int CantidadHijo { get => _cantidadHijo; set => _cantidadHijo = value; }
        public string Domicilio { get => _domicilio; set => _domicilio = value; }
        public string Provincia { get => _provincia; set => _provincia = value; }
        public string Distrito { get => _distrito; set => _distrito = value; }
        public int Cp { get => _cp; set => _cp = value; }
        public bool Comunidad { get => _comunidad; set => _comunidad = value; }
        public string Celular1 { get => _celular1; set => _celular1 = value; }
        public string Celular2 { get => _celular2; set => _celular2 = value; }
        public string Celular3 { get => _celular3; set => _celular3 = value; }
        public string Email { get => _email; set => _email = value; }
        public Banco Banco { get => _banco; set => _banco = value; }
        public string CtaBancariaTipo { get => _ctaBancariaTipo; set => _ctaBancariaTipo = value; }
        public string CtaBancariaNro { get => _ctaBancariaNro; set => _ctaBancariaNro = value; }
        public string Observacion { get => _observacion; set => _observacion = value; }
        public double Saldo { get => _saldo; set => _saldo = value; }
        public bool Baja { get => _baja; set => _baja = value; }
        public bool InformacionRestringida { get => _informacionRestringida; set => _informacionRestringida = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public Legajo() { }
        public Legajo(long id, string denominacion, long cuit, bool informacionRestringida)
        {
            _id = id;
            _denominacion = denominacion;
            _cuit = cuit;
            _informacionRestringida = informacionRestringida;
        }
        public Legajo(long id, string denominacion, long cuit, string celular1, string celular2, string celular3, double saldo, bool baja, bool informacionRestringida)
        {
            _id = id;
            _denominacion = denominacion;
            _cuit = cuit;
            _celular1 = celular1;
            _celular2 = celular2;
            _celular3 = celular3;
            _saldo = saldo;
            _baja = baja;
            _informacionRestringida = informacionRestringida;
        }
        public Legajo(long id, string denominacion, string sexo, long documento, long cuit, DateTime fechaNacimiento, string tipoSangre, string nacionalidad, string estadoCivil, int cantidadHijo, string domicilio, string provincia, string distrito, int cp, bool comunidad, string celular1, string celular2, string celular3, string email, Banco banco, string ctaBancariaTipo, string ctaBancariaNro, string observacion, double saldo, bool baja, bool informacionRestringida, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _denominacion = denominacion;
            _sexo = sexo;
            _documento = documento;
            _cuit = cuit;
            _fechaNacimiento = fechaNacimiento;
            _tipoSangre = tipoSangre;
            _nacionalidad = nacionalidad;
            _estadoCivil = estadoCivil;
            _cantidadHijo = cantidadHijo;
            _domicilio = domicilio;
            _provincia = provincia;
            _distrito = distrito;
            _cp = cp;
            _comunidad = comunidad;
            _celular1 = celular1;
            _celular2 = celular2;
            _celular3 = celular3;
            _email = email;
            _banco = banco;
            _ctaBancariaTipo = ctaBancariaTipo;
            _ctaBancariaNro = ctaBancariaNro;
            _observacion = observacion;
            _saldo = saldo;
            _baja = baja;
            _informacionRestringida = informacionRestringida;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(Legajo objLegajo)
        {
            if (objLegajo != null &&
                   _id == objLegajo._id &&
                   _denominacion == objLegajo._denominacion &&
                   _sexo == objLegajo._sexo &&
                   _documento == objLegajo._documento &&
                   _cuit == objLegajo._cuit &&
                   _fechaNacimiento == objLegajo._fechaNacimiento &&
                   _tipoSangre == objLegajo._tipoSangre &&
                   _nacionalidad == objLegajo._nacionalidad &&
                   _estadoCivil == objLegajo._estadoCivil &&
                   _cantidadHijo == objLegajo._cantidadHijo &&
                   _domicilio == objLegajo._domicilio &&
                   _provincia == objLegajo._provincia &&
                   _distrito == objLegajo._distrito &&
                   _cp == objLegajo._cp &&
                   _comunidad == objLegajo._comunidad &&
                   _celular1 == objLegajo._celular1 &&
                   _celular2 == objLegajo._celular2 &&
                   _celular3 == objLegajo._celular3 &&
                   _email == objLegajo._email &&
                   _banco.Id == objLegajo._banco.Id &&
                   _ctaBancariaTipo == objLegajo._ctaBancariaTipo &&
                   _ctaBancariaNro == objLegajo._ctaBancariaNro &&
                   _observacion == objLegajo._observacion &&
                   _saldo == objLegajo._saldo &&
                   _baja == objLegajo._baja &&
                   _informacionRestringida == objLegajo._informacionRestringida) return true;
            return false;
        }
        #endregion
    }
}
