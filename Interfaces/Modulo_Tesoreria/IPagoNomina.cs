using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IPagoNomina
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<PagoNomina> obtenerObjetos(string estado, string campo, string valor);
        List<PagoNomina> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        PagoNomina obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(PagoNomina objPagoNomina);
        bool anular(PagoNomina objPagoNomina);
        bool insertar(PagoNomina objPagoNomina);
    }
}
