using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IConciliacion
    {
        List<CatalogoBase> obtenerCatalago(string estadoConciliacion, long idCuentaContable, string catalogo, int indicePagina, int tamanioPagina);
        Conciliacion obtenerObjeto(string campo, string valor, bool notificarExito);
        bool conciliar(List<Conciliacion> lista, bool notificarExito);
        bool desconciliar(List<Conciliacion> lista, bool notificarExito);
        double[] contabilizarDebeHaber(long idCuentaContable);
    }
}