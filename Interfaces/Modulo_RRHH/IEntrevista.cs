using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IEntrevista
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<Entrevista> obtenerObjetos(string estado, string campo, string valor);
        List<Entrevista> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        Entrevista obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(Entrevista objEntrevista);
        bool anular(Entrevista objEntrevista);
        bool insertar(Entrevista objEntrevista);
    }
}
