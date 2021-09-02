using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces.Catalogo
{
    public interface IPerfilLaboral
    {
        List<string> obtenerListaDeElementos();
        List<PerfilLaboral> obtenerObjetos();
        PerfilLaboral obtenerObjeto(string denominacion, bool notificarExito);
        PerfilLaboral obtenerObjeto(long id, bool notificarExito);
        bool actualizar(PerfilLaboral objPerfilLaboral, bool notificarExito);
        bool eliminar(long id, bool notificarExito);
        bool insertar(PerfilLaboral objPerfilLaboral, bool notificarExito);
    }
}