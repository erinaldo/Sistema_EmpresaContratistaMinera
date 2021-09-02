using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ISindicato
    {
        List<string> obtenerListaDeElementos(string[] deposito);
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<Sindicato> obtenerObjetos(string campo, string valor);
        Sindicato obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(Sindicato objSindicato);
        bool insertar(Sindicato objSindicato);
    }
}
