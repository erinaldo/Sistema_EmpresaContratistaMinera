using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ILegajoTalle
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<LegajoTalle> obtenerObjetos(string estado, string campo, string valor);
        LegajoTalle obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(LegajoTalle objLegajoTalle);
        bool insertar(LegajoTalle objLegajoTalle);
    }
}
