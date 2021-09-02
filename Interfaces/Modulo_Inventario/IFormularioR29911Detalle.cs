using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IFormularioR29911Detalle
    {
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<FormularioR29911Detalle> obtenerObjetos(long idFormularioR29911);
        List<FormularioR29911Detalle> obtenerObjetos(string campo, string valor);
        FormularioR29911Detalle obtenerObjeto(string campo, string valor, bool notificarExito);
        bool insertar(FormularioR29911Detalle objFormularioR29911Detalle, bool notificarExito);
    }
}
