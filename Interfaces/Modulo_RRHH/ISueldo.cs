using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ISueldo
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<Sueldo> obtenerObjetos(string estado, string campo, string valor);
        List<Sueldo> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        Sueldo obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(Sueldo objSueldo);
        bool anular(Sueldo objSueldo);
        bool insertar(Sueldo objSueldo);
    }
}
