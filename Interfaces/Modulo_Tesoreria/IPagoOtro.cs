using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IPagoOtro
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<PagoOtro> obtenerObjetos(string estado, string campo, string valor);
        List<PagoOtro> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        PagoOtro obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(PagoOtro objPagoOtro);
        bool anular(PagoOtro objPagoOtro);
        bool insertar(PagoOtro objPagoOtro);
    }
}
