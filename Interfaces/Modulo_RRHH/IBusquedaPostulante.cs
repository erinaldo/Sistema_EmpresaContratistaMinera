using Entidades;
using Entidades.Catalogo;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IBusquedaPostulante
    {
        List<CatalogoBase> obtenerCatalago(string perfilLaboral, bool trabajoEmpreminsa, string disponibilidadCV, string calificacionCV, bool estadoCV, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico, string catalogo, int indicePagina, int tamanioPagina);
        List<BusquedaPostulante> obtenerObjetos(string perfilLaboral, bool trabajoEmpreminsa, string disponibilidadCV, string calificacionCV, bool estadoCV, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico);
        BusquedaPostulante obtenerObjeto(long id, string perfilLaboral, bool trabajoEmpreminsa, string disponibilidadCV, string calificacionCV, bool estadoCV, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico, bool notificarExito);
    }
}
