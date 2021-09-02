using Entidades.Sistema;

namespace Interfaces.Sistema
{
    public interface ICredencialFTP
    {
        CredencialFTP obtenerObjeto(string campo, string valor);
    }
}