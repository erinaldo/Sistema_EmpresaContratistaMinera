using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRentabilidadCentroCostoDetalleCosto
    {
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<RentabilidadCentroCostoDetalleCosto> obtenerObjetos(long idRentabilidad);
        List<RentabilidadCentroCostoDetalleCosto> obtenerObjetos(long idRentabilidad, string tipoCuenta);
        List<RentabilidadCentroCostoDetalleCosto> obtenerObjetos(string campo, string valor);
        RentabilidadCentroCostoDetalleCosto obtenerObjeto(string campo, string valor, bool notificarExito);
        bool insertar(RentabilidadCentroCostoDetalleCosto objRentabilidadCentroCostoDetalleCosto);
    }
}