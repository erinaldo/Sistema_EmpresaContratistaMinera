using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface INovedadNomina
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<NovedadNomina> obtenerObjetos(string estado, string campo, string valor);
        List<NovedadNomina> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        NovedadNomina obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(NovedadNomina objNovedadNomina);
        bool anular(NovedadNomina objNovedadNomina);
        bool insertar(NovedadNomina objNovedadNomina);
        bool liquidar(string periodo);
    }
}
