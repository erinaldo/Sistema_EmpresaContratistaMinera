using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IConsumoStockDetalle
    {
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<ConsumoStockDetalle> obtenerObjetos(long idConsumoStock);
        List<ConsumoStockDetalle> obtenerObjetos(string campo, string valor);
        ConsumoStockDetalle obtenerObjeto(string campo, string valor, bool notificarExito);
        bool insertar(ConsumoStockDetalle objConsumoStockDetalle, bool notificarExito);
    }
}
