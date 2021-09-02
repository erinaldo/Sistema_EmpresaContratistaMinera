using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IArticulo
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<Articulo> obtenerExistencias(string deposito);
        List<Articulo> obtenerObjetos(string estado, string campo, string valor);
        Articulo obtenerObjeto(string estado, string campo, string valor, bool notificarExito);
        bool actualizar(Articulo objArticulo, bool notificarExito);
        bool eliminar(Articulo objArticulo, bool notificarExito);
        bool insertar(Articulo objArticulo, bool notificarExito);
    }
}