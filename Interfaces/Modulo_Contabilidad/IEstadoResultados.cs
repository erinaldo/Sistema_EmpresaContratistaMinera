using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IEstadoResultados
    {
        List<CatalogoBase> obtenerCatalago(string periodo, string catalogo);
    }
}