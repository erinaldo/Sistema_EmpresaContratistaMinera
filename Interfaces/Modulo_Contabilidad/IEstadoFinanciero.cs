using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IEstadoFinanciero
    {
        List<CatalogoBase> obtenerCatalago(string periodo, string catalogo);
    }
}