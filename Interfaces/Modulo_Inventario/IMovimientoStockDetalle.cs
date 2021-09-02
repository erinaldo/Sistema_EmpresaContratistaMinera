using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IMovimientoStockDetalle
    {
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<MovimientoStockDetalle> obtenerObjetos(long idMovimientoStock);
        List<MovimientoStockDetalle> obtenerObjetos(string campo, string valor);
        MovimientoStockDetalle obtenerObjeto(string campo, string valor, bool notificarExito);
        bool insertar(MovimientoStockDetalle objMovimientoStockDetalle, bool notificarExito);
    }
}
