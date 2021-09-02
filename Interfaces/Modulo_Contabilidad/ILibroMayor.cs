using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ILibroMayor
    {
        List<CatalogoBase> obtenerCatalago(long idCuentaContable, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        double[] contabilizarDebeHaber(long idCuentaContable, DateTime desde, DateTime hasta);
    }
}