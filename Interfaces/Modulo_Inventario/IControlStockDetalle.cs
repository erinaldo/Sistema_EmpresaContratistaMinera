using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IControlStockDetalle
    {
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<ControlStockDetalle> obtenerObjetos(long idControlStock);
        List<ControlStockDetalle> obtenerObjetos(string campo, string valor);
        ControlStockDetalle obtenerObjeto(string campo, string valor, bool notificarExito);
        bool insertar(ControlStockDetalle objControlStockDetalle, bool notificarExito);
    }
}
