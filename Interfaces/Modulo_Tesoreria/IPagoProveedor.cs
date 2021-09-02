using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IPagoProveedor
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<PagoProveedor> obtenerObjetos(string estado, string campo, string valor);
        List<PagoProveedor> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        PagoProveedor obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(PagoProveedor objPagoProveedor);
        bool anular(PagoProveedor objPagoProveedor);
        bool insertar(PagoProveedor objPagoProveedor);
    }
}