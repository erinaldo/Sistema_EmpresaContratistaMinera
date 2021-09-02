using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ILegajo
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<Legajo> obtenerObjetos(string estado, string campo, string valor);
        Legajo obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(Legajo objLegajo);
        bool actualizarEstado(long id, bool baja, bool notificarExito);
        bool actualizarSaldo(long id, double saldo, bool notificarExito);
        bool insertar(Legajo objLegajo);
    }
}
