using Entidades;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IAsientoCentroCostoRentabilidadCosto
    {
        List<AsientoCentroCostoRentabilidadCosto> obtenerObjetos(string centroCosto, string periodo);
    }
}