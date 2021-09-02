using Entidades.Sistema;

namespace Interfaces.Sistema
{
    public interface IOpcionGeneral
    {
        OpcionGeneral obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(OpcionGeneral objOpcionGeneral, bool notificarExito);
    }
}