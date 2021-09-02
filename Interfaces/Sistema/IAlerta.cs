using Entidades.Catalogo;
using Entidades.Sistema;
using System;
using System.Collections.Generic;

namespace Interfaces.Sistema
{
    public interface IAlerta
    {
        List<CatalogoBase> obtenerCatalago(string TipoAlerta, string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string TipoAlerta, string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<Alerta> obtenerObjetos(string TipoAlerta, string estado, string campo, string valor);
        List<Alerta> obtenerObjetos(string TipoAlerta, string estado, string campo, DateTime desde, DateTime hasta);
        Alerta obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(Alerta objAlerta, bool notificarExito);
        bool eliminar(long id, bool notificarExito);
        bool insertar(Alerta objAlerta);
        void insertar(List<Alerta> listaDeAlertas);
    }
}
