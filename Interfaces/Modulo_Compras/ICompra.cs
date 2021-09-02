using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ICompra
    {
        List<CatalogoBase> obtenerCatalago(int afipTipoCbte, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina, string filtroExclusivoCobroCUIT);
        List<CatalogoBase> obtenerCatalago(int afipTipoCbte, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina, string filtroExclusivoCobroCUIT);
        List<CatalogoBase> obtenerLibroIVA(string periodo, string catalogo);
        List<CatalogoBase> obtenerInformativo(string periodo, string catalogo);
        List<Compra> obtenerObjetos(int afipTipoCbte, string campo, string valor, string filtroExclusivoCobroCUIT);
        List<Compra> obtenerObjetos(int afipTipoCbte, string campo, DateTime desde, DateTime hasta, string filtroExclusivoCobroCUIT);
        Compra obtenerObjeto(string campo, string valor, bool notificarExito, string filtroExclusivoCobroCUIT);
        bool actualizar(Compra objCompra);
        bool insertar(Compra objCompra);
        bool registrarComoCbteAsociado(long id, bool referenciado);
    }
}