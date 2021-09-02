using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces.Catalogo
{
    public interface IConceptoSueldo
    {
        List<string> obtenerListaDeElementos();
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<ConceptoSueldo> obtenerObjetos(string campo, string valor);
        ConceptoSueldo obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(ConceptoSueldo objConceptoSueldo, bool notificarExito);
        bool eliminar(long id, bool notificarExito);
        bool insertar(ConceptoSueldo objConceptoSueldo, bool notificarExito);
    }
}