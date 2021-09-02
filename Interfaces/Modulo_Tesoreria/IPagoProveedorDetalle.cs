using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IPagoProveedorDetalle
    {
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<PagoProveedorDetalle> obtenerObjetos(long idPagoProveedor);
        List<PagoProveedorDetalle> obtenerObjetos(string campo, string valor);
        PagoProveedorDetalle obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(List<PagoProveedorDetalle> listaDePagoProveedorDetalle);
        bool insertar(List<PagoProveedorDetalle> listaDePagoProveedorDetalle);
    }
}
