using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ICursoIzaje
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<CursoIzaje> obtenerObjetos(string estado, string campo, string valor);
        List<CursoIzaje> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        CursoIzaje obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(CursoIzaje objCursoIzaje);
        bool anular(CursoIzaje objCursoIzaje);
        bool insertar(CursoIzaje objCursoIzaje);
    }
}
