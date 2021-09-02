using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IProveedor
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<Proveedor> obtenerObjetos(string estado, string campo, string valor);
        Proveedor obtenerObjeto(string estado, string campo, string valor, bool notificarExito);
        bool actualizar(Proveedor objProveedor);
        bool actualizarSaldo(long id, double saldo, bool notificarExito);
        bool eliminar(Proveedor objProveedor);
        bool insertar(Proveedor objProveedor);
    }
}