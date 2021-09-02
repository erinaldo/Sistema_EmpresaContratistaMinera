using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ILegajoDocumentacion
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<LegajoDocumentacion> obtenerObjetos(string estado, string campo, string valor);
        LegajoDocumentacion obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(LegajoDocumentacion objLegajoDocumentacion);
        bool insertar(LegajoDocumentacion objLegajoDocumentacion);
    }
}
