using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces.Catalogo
{
    public interface IObraSocial
    {
        List<string> obtenerListaDeElementos();
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<ObraSocial> obtenerObjetos(string campo, string valor);
        ObraSocial obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(ObraSocial objObraSocial, bool notificarExito);
        bool eliminar(long id, bool notificarExito);
        bool insertar(ObraSocial objObraSocial, bool notificarExito);
    }
}
