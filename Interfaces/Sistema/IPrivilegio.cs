using Entidades.Sistema;
using System.Collections.Generic;

namespace Interfaces.Sistema
{
    public interface IPrivilegio
    {
        List<long> obtenerElementos(long idUsuario);
        List<Privilegio> obtenerObjetos(long idUsuario);
        bool actualizar(long idUsuario, List<Privilegio> listaDePrivilegios);
        bool agregarColumna(long idUsuario);
        bool asociarColumna(long idUsuario, long idTemporal);
        bool quitarColumna(long idUsuario);
        bool quitarColumnas_Temporales();
    }
}