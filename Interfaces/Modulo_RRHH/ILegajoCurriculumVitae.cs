using Entidades;
using Entidades.Catalogo;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface ILegajoCurriculumVitae
    {
        List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<LegajoCurriculumVitae> obtenerObjetos(string estado, string campo, string valor);
        LegajoCurriculumVitae obtenerObjeto(string campo, string valor, bool notificarExito);
        bool actualizar(LegajoCurriculumVitae objLegajoCurriculumVitae);
        bool insertar(LegajoCurriculumVitae objLegajoCurriculumVitae);
    }
}
