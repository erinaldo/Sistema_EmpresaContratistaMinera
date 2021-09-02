using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IAsientoManualDetalle
    {
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<AsientoManualDetalle> obtenerObjetos(long idAsientoManual);
        List<AsientoManualDetalle> obtenerObjetos(string campo, string valor);
        AsientoManualDetalle obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(AsientoManualDetalle objAsientoManualDetalle);
        bool insertar(AsientoManualDetalle objAsientoManualDetalle);
    }
}