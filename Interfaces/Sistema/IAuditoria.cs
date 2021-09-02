using Entidades.Catalogo;
using Entidades.Sistema;
using System;
using System.Collections.Generic;

namespace Interfaces.Sistema
{
    public interface IAuditoria
    {
        List<string> obtenerListaDeModulo();
        List<CatalogoBase> obtenerCatalago(string modulo, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina);
        List<CatalogoBase> obtenerCatalago(string modulo, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina);
        List<Auditoria> obtenerObjetos(string modulo, string campo, string valor);
        List<Auditoria> obtenerObjetos(string modulo, string campo, DateTime desde, DateTime hasta);
        Auditoria obtenerObjeto(string campo, string valor, bool notificarExito);
        bool insertar(Auditoria objAuditoria);
    }
}
