using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ICompraDetalle
    {
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CompraDetalle> obtenerObjetos(long idCompra);
        List<CompraDetalle> obtenerObjetos(string campo, string valor);
        CompraDetalle obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(List<CompraDetalle> listaDeCompraDetalle);
        bool insertar(List<CompraDetalle> listaDeCompraDetalle);
    }
}