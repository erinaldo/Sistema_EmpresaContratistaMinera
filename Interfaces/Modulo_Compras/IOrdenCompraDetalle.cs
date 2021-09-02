using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IOrdenCompraDetalle
    {
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<OrdenCompraDetalle> obtenerObjetos(long idOrdenCompra);
        List<OrdenCompraDetalle> obtenerObjetos(string campo, string valor);
        OrdenCompraDetalle obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(List<OrdenCompraDetalle> listaDeOrdenCompraDetalle);
        bool insertar(List<OrdenCompraDetalle> listaDeOrdenCompraDetalle);
    }
}