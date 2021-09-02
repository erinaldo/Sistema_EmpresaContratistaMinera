using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IVentaDetalle
    {
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<VentaDetalle> obtenerObjetos(long idVenta);
        List<VentaDetalle> obtenerObjetos(string campo, string valor);
        VentaDetalle obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(List<VentaDetalle> listaDeVentaDetalle);
        bool insertar(List<VentaDetalle> listaDeVentaDetalle);
    }
}
