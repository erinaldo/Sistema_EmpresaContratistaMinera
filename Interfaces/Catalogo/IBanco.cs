using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces.Catalogo
{
    public interface IBanco
    {
        List<string> obtenerListaDeElementos();
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<Banco> obtenerObjetos(string campo, string valor);
        Banco obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(Banco objBanco, bool notificarExito);
        bool eliminar(long id, bool notificarExito);
        bool insertar(Banco objBanco, bool notificarExito);
    }
}