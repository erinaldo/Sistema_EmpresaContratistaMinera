using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IExamenMedico
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<ExamenMedico> obtenerObjetos(string estado, string campo, string valor);
        List<ExamenMedico> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta);
        ExamenMedico obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(ExamenMedico objExamenMedico);
        bool anular(ExamenMedico objExamenMedico);
        bool insertar(ExamenMedico objExamenMedico);
    }
}
