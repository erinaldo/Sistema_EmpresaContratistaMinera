using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IFormularioR29911
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<FormularioR29911> obtenerObjetos(string estado, string campo, string valor);
        List<FormularioR29911> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        FormularioR29911 obtenerObjeto(string campo, string valor, bool notificarExito);
        bool anular(long id, bool notificarExito);
        bool insertar(FormularioR29911 objFormularioR29911, bool notificarExito);
    }
}
