using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRentabilidadCentroCostoDetalleImporte
    {
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<RentabilidadCentroCostoDetalleImporte> obtenerObjetos(long idRentabilidad);
        List<RentabilidadCentroCostoDetalleImporte> obtenerObjetos(string campo, string valor);
        RentabilidadCentroCostoDetalleImporte obtenerObjeto(string campo, string valor, bool notificarExito);
        bool insertar(RentabilidadCentroCostoDetalleImporte objRentabilidadCentroCostoDetalleImporte);
    }
}