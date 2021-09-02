using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces.Catalogo
{
    public interface ITipoNovedad
    {
        List<string> obtenerListaDeElementos();
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<TipoNovedad> obtenerObjetos(string campo, string valor);
        TipoNovedad obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(TipoNovedad objTipoNovedad, bool notificarExito);
        bool eliminar(long id, bool notificarExito);
        bool insertar(TipoNovedad objTipoNovedad, bool notificarExito);
    }
}