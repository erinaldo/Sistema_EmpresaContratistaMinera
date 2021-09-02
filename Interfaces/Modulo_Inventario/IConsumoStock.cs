﻿using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IConsumoStock
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<ConsumoStock> obtenerObjetos(string estado, string campo, string valor);
        List<ConsumoStock> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        ConsumoStock obtenerObjeto(string campo, string valor, bool notificarExito);
        bool anular(long id, bool notificarExito);
        bool insertar(ConsumoStock objConsumoStock, bool notificarExito);
    }
}
