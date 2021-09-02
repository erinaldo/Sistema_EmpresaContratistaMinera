using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ICuentaContable
    {
        List<string> obtenerListaDeElementos(string[] ramaContable, bool exclusionDeCuenta);
        List<CatalogoBase> obtenerCatalago(string ramaPrincipal, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CuentaContable> obtenerObjetos(string ramaPrincipal, string campo, string valor);
        CuentaContable obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(CuentaContable objCuentaContable);
        bool actualizarSaldo(long id, double saldo, bool notificarExito);
        bool insertar(CuentaContable objCuentaContable);
    }
}