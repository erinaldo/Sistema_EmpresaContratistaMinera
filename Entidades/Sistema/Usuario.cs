using Entidades.Sistema;
using System;
using System.Collections.Generic;

namespace Entidades
{
    public class Usuario : IEquatable<Usuario>
    {
        #region Atributos
        private long _id;
        private Legajo _legajo;
        private byte[] _contrasenia;
        private string _tipoUsuario;
        private string _emailRecuperacion;
        private bool _alertaFacturacion;
        private bool _alertaInventario;
        private bool _alertaRRHH;
        private List<Privilegio> _listaDePrivilegios;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public Legajo Legajo { get => _legajo; set => _legajo = value; }
        public byte[] Contrasenia { get => _contrasenia; set => _contrasenia = value; }
        public string TipoUsuario { get => _tipoUsuario; set => _tipoUsuario = value; }
        public string EmailRecuperacion { get => _emailRecuperacion; set => _emailRecuperacion = value; }
        public bool AlertaFacturacion { get => _alertaFacturacion; set => _alertaFacturacion = value; }
        public bool AlertaInventario { get => _alertaInventario; set => _alertaInventario = value; }
        public bool AlertaRRHH { get => _alertaRRHH; set => _alertaRRHH = value; }
        public List<Privilegio> ListaDePrivilegios { get => _listaDePrivilegios; set => _listaDePrivilegios = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public Usuario() { }
        public Usuario(long id, Legajo legajo, byte[] contrasenia, string tipoUsuario, string emailRecuperacion, bool alertaFacturacion, bool alertaInventario, bool alertaRRHH, List<Privilegio> listaDePrivilegios, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _legajo = legajo;
            _contrasenia = contrasenia;
            _tipoUsuario = tipoUsuario;
            _emailRecuperacion = emailRecuperacion;
            _alertaFacturacion = alertaFacturacion;
            _alertaInventario = alertaInventario;
            _alertaRRHH = alertaRRHH;
            _listaDePrivilegios = listaDePrivilegios;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(Usuario objUsuario)
        {
            if (objUsuario != null &&
                   _id == objUsuario._id &&
                   EqualityComparer<byte[]>.Default.Equals(_contrasenia, objUsuario._contrasenia) &&
                   _tipoUsuario == objUsuario._tipoUsuario &&
                   _emailRecuperacion == objUsuario._emailRecuperacion &&
                   _alertaFacturacion == objUsuario._alertaFacturacion &&
                   _alertaInventario == objUsuario._alertaInventario &&
                   _alertaRRHH == objUsuario._alertaRRHH &&
                   EqualityComparer<List<Privilegio>>.Default.Equals(_listaDePrivilegios, objUsuario._listaDePrivilegios)) return true;
            return false;
        }
        #endregion
    }
}
