using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IAsientoContable
    {
        List<CatalogoBase> obtenerCatalago(string libro, long idCuentaContable, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string libro, long idCuentaContable, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<AsientoContable> obtenerObjetos(string libro, long idCuentaContable, string campo, string valor);
        List<AsientoContable> obtenerObjetos(string libro, long idCuentaContable, string campo, DateTime desde, DateTime hasta);
        AsientoContable obtenerObjeto(string campo, string valor, bool notificarExito);
        AsientoContable obtenerObjeto(string origenTipo, long origenId, bool notificarExito);
        bool actualizar(AsientoContable objAsientoContable, bool notificarExito);
        bool eliminar(AsientoContable objAsientoContable, bool notificarExito);
        bool eliminar(long asientoNro);
        bool insertar(AsientoContable objAsientoContable, bool notificarExito);
        long generarNumeroAsiento();
    }
}