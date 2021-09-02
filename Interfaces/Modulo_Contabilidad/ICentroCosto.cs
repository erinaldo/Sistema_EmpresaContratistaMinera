using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ICentroCosto
    {
        List<string> obtenerListaDeElementos(string[] deposito);
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CentroCosto> obtenerObjetos(string campo, string valor);
        CentroCosto obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(CentroCosto objCentroCosto);
        bool insertar(CentroCosto objCentroCosto);
    }
}
