using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IChequeAPagar
    {
        List<CatalogoBase> obtenerCatalago(DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<ChequeAPagar> obtenerObjetos(DateTime desde, DateTime hasta);
        double obtenerDeudaAProveedor(DateTime desde, DateTime hasta);
        double obtenerDeudaANomina(DateTime desde, DateTime hasta);
        double obtenerDeudaAOtro(DateTime desde, DateTime hasta);
        double obtenerDeudaAMovimiento(DateTime desde, DateTime hasta);
    }
}