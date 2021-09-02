using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IResumenRelevanteLegajo
    {
        List<CatalogoBase> obtenerCatalago(string estadoLaboral, CentroCosto centroCosto, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico, string catalogo, int indicePagina, int tamanioPagina);
        List<ResumenRelevanteLegajo> obtenerObjetos(string estadoLaboral, CentroCosto centroCosto, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico);
        ResumenRelevanteLegajo obtenerObjeto(long id, string estadoLaboral, CentroCosto centroCosto, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico, bool notificarExito);
    }
}
