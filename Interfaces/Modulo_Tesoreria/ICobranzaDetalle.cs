using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ICobranzaDetalle
    {
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CobranzaDetalle> obtenerObjetos(long idCobranza);
        List<CobranzaDetalle> obtenerObjetos(string campo, string valor);
        CobranzaDetalle obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(List<CobranzaDetalle> listaDeCobranzaDetalle);
        bool insertar(List<CobranzaDetalle> listaDeCobranzaDetalle);
    }
}
