using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ICapacitacionLaboral
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<CapacitacionLaboral> obtenerObjetos(string estado, string campo, string valor);
        List<CapacitacionLaboral> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        CapacitacionLaboral obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(CapacitacionLaboral objCapacitacionLaboral);
        bool anular(CapacitacionLaboral objCapacitacionLaboral);
        bool insertar(CapacitacionLaboral objCapacitacionLaboral);
    }
}
