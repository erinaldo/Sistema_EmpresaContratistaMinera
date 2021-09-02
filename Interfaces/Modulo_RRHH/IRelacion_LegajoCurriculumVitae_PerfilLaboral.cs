using Entidades;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRelacion_LegajoCurriculumVitae_PerfilLaboral
    {
        string obtenerElementos(long idLegajo);
        List<string> obtenerListaDeElementos(long idLegajo);
        List<Relacion_LegajoCurriculumVitae_PerfilLaboral> obtenerObjetos(long idLegajo);
        Relacion_LegajoCurriculumVitae_PerfilLaboral obtenerObjeto(long id, bool notificarExito);
        bool asociar_PerfilesTemporales(long idLegajoTemporal, long idLegajoDefinitivo);
        bool eliminar(long id, bool notificarExito);
        bool eliminar_PerfilesLegajoles(long idLegajo);
        bool eliminar_PerfilesTemporales();
        bool insertar(Relacion_LegajoCurriculumVitae_PerfilLaboral objRelacion_LegajoCurriculumVitae_PerfilLaboral, bool notificarExito);
    }
}