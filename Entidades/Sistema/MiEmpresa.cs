using System;

namespace Entidades.Sistema
{
    public class MiEmpresa
    {
        #region Atributos
        private long _id;
        private string _denominacion;
        private string _nombreFantasia;
        private string _cuit;
        private string _iva;
        private string _nroIngresosBrutos;
        private DateTime _inicioDeActividad;
        private string _domicilio;
        private string _provincia;
        private string _distrito;
        private string _cp;
        private string _telefono;
        private string _celular;
        private string _email;
        private string _paginaWeb;
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
        public string NroIngresosBrutos { get => _nroIngresosBrutos; set => _nroIngresosBrutos = value; }
        public DateTime InicioDeActividad { get => _inicioDeActividad; set => _inicioDeActividad = value; }
        public string Domicilio { get => _domicilio; set => _domicilio = value; }
        public string Provincia { get => _provincia; set => _provincia = value; }
        public string Distrito { get => _distrito; set => _distrito = value; }
        public string Cp { get => _cp; set => _cp = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Celular { get => _celular; set => _celular = value; }
        public string Email { get => _email; set => _email = value; }
        public string PaginaWeb { get => _paginaWeb; set => _paginaWeb = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public MiEmpresa() { }
        public MiEmpresa(long id, string denominacion, string nombreFantasia, string cuit, string iva, string nroIngresosBrutos, DateTime inicioDeActividad, string domicilio, string provincia, string distrito, string cp, string telefono, string celular, string email, string paginaWeb, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _denominacion = denominacion;
            _nombreFantasia = nombreFantasia;
            _cuit = cuit;
            _iva = iva;
            _nroIngresosBrutos = nroIngresosBrutos;
            _inicioDeActividad = inicioDeActividad;
            _domicilio = domicilio;
            _provincia = provincia;
            _distrito = distrito;
            _cp = cp;
            _telefono = telefono;
            _celular = celular;
            _email = email;
            _paginaWeb = paginaWeb;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion
    }
}
