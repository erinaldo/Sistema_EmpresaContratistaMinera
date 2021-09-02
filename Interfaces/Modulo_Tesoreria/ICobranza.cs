using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ICobranza
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<Cobranza> obtenerObjetos(string estado, string campo, string valor);
        List<Cobranza> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        Cobranza obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(Cobranza objCobranza);
        bool anular(Cobranza objCobranza);
        bool insertar(Cobranza objCobranza);
    }
}