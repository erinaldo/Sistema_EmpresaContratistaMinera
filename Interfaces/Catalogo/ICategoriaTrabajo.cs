using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces.Catalogo
{
    public interface ICategoriaTrabajo
    {
        List<string> obtenerListaDeElementos();
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CategoriaTrabajo> obtenerObjetos(string campo, string valor);
        bool actualizar(CategoriaTrabajo objCategoriaTrabajo, bool notificarExito);
        bool eliminar(long id, bool notificarExito);
        bool insertar(CategoriaTrabajo objCategoriaTrabajo, bool notificarExito);
    }
}
