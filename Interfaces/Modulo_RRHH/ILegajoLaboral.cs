using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ILegajoLaboral
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<LegajoLaboral> obtenerObjetos(string estado, string campo, string valor);
        List<LegajoLaboral> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        LegajoLaboral obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(LegajoLaboral objLegajoLaboral);
        bool actualizarEstado(Legajo objLegajo, string estado, bool notificarExito);
        bool insertar(LegajoLaboral objLegajoLaboral);
    }
}
