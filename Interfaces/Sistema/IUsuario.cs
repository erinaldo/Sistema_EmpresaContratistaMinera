using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IUsuario
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<Usuario> obtenerObjetos(string estado, string campo, string valor);
        Usuario obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(Usuario objUsuario);
        bool eliminar(Usuario objUsuario);
        bool insertar(Usuario objUsuario);
        bool iniciarSesion(string documento, string contrasenia, bool notificarExito);
        bool recuperarUsuario(string documento, string correo, bool notificarExito);
    }
}
