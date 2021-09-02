using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IConsumoCentroCosto
    {
        List<CatalogoBase> obtenerCatalago(string centroCosto, string periodo, string catalogo, int indicePagina, int tamanioPagina);
        List<ConsumoCentroCosto> obtenerObjetos(string centroCosto, string periodo);
        double[] obtenerConsumoTotal(string centroCosto, string periodo);
    }
}