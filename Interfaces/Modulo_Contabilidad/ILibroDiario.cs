using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ILibroDiario
    {
        List<CatalogoBase> obtenerCatalago(long idCuentaContable, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        double[] contabilizarDebeHaber(string campo, long valor, DateTime desde, DateTime hasta);
    }
}