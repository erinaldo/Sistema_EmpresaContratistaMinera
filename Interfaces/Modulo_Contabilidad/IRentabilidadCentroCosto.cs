using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRentabilidadCentroCosto
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<RentabilidadCentroCosto> obtenerObjetos(string estado, string campo, string valor);
        RentabilidadCentroCosto obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(RentabilidadCentroCosto objRentabilidadCentroCosto);
        bool anular(RentabilidadCentroCosto objRentabilidadCentroCosto);
        bool insertar(RentabilidadCentroCosto objRentabilidadCentroCosto);
    }
}