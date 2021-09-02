using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IMovimientoFondo
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<MovimientoFondo> obtenerObjetos(string estado, string campo, string valor);
        List<MovimientoFondo> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        MovimientoFondo obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(MovimientoFondo objMovimientoFondo);
        bool anular(MovimientoFondo objMovimientoFondo);
        bool insertar(MovimientoFondo objMovimientoFondo);
    }
}