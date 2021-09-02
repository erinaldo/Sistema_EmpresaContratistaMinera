using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ICursoInduccion
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<CursoInduccion> obtenerObjetos(string estado, string campo, string valor);
        List<CursoInduccion> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        CursoInduccion obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(CursoInduccion objCursoInduccion);
        bool anular(CursoInduccion objCursoInduccion);
        bool insertar(CursoInduccion objCursoInduccion);
    }
}
