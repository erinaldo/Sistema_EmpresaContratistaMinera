using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ISuministracionIEPP
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<SuministracionIEPP> obtenerObjetos(string estado, string campo, string valor);
        List<SuministracionIEPP> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        SuministracionIEPP obtenerObjeto(string campo, string valor, bool notificarExito);
        bool anular(long id, bool notificarExito);
        bool insertar(SuministracionIEPP objSuministracionIEPP, bool notificarExito);
    }
}
