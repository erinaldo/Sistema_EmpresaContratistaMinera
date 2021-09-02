using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ISuministracionIEPPDetalle
    {
        List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<SuministracionIEPPDetalle> obtenerObjetos(long idSuministracionIEPP);
        List<SuministracionIEPPDetalle> obtenerObjetos(string campo, string valor);
        SuministracionIEPPDetalle obtenerObjeto(string campo, string valor, bool notificarExito);
        bool insertar(SuministracionIEPPDetalle objSuministracionIEPPDetalle, bool notificarExito);
    }
}
