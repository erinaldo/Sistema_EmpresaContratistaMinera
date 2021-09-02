using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IFondo
    {
        List<CatalogoBase> obtenerCatalago(string catalogo, int indicePagina, int tamanioPagina);
        List<Fondo> obtenerObjetos();
    }
}