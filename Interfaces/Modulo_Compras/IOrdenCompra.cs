using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IOrdenCompra
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<OrdenCompra> obtenerObjetos(string estado, string campo, string valor);
        List<OrdenCompra> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        OrdenCompra obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(OrdenCompra objOrdenCompra);
        bool anular(OrdenCompra objOrdenCompra);
        bool autorizar(OrdenCompra objOrdenCompra, bool notificarExito);
        bool insertar(OrdenCompra objOrdenCompra);
    }
}