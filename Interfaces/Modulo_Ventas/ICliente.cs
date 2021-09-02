using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ICliente
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<Cliente> obtenerObjetos(string estado, string campo, string valor);
        Cliente obtenerObjeto(string estado, string campo, string valor, bool notificarExito);
        bool actualizar(Cliente objCliente);
        bool actualizarSaldo(long id, double saldo, bool notificarExito);
        bool eliminar(Cliente objCliente);
        bool insertar(Cliente objCliente);
    }
}