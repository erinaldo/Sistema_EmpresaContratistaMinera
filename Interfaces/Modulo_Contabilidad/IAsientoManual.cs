using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IAsientoManual
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<AsientoManual> obtenerObjetos(string estado, string campo, string valor);
        List<AsientoManual> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        AsientoManual obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(AsientoManual objAsientoManual);
        bool anular(AsientoManual objAsientoManual);
        bool insertar(AsientoManual objAsientoManual);
    }
}