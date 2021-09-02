using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IContrato
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<Contrato> obtenerObjetos(string estado, string campo, string valor);
        List<Contrato> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        Contrato obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(Contrato objContrato);
        bool anular(Contrato objContrato);
        bool insertar(Contrato objContrato);
    }
}
