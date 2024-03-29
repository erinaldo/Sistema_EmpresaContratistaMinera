﻿using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IResumenAsientoSueldo
    {
        List<CatalogoBase> obtenerCatalago(string periodo, string catalogo, int indicePagina, int tamanioPagina);
        double[] contabilizarDebeHaber(string periodo);
    }
}