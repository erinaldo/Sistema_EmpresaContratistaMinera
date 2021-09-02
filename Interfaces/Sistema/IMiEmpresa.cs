using Entidades.Sistema;

namespace Interfaces.Sistema
{
    public interface IMiEmpresa
    {
        MiEmpresa obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(MiEmpresa objMiEmpresa, bool notificarExito);
    }
}