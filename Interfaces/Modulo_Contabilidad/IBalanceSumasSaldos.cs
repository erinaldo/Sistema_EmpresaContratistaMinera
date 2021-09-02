using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IBalanceSumasSaldos
    {
        List<CatalogoBase> obtenerCatalago(DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        double[] contabilizarDebeHaber(DateTime desde, DateTime hasta);
    }
}