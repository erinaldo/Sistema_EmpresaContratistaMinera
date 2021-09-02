using CapaDatos;
using CapaDatos.Sistema;
using Entidades.Catalogo;
using Entidades.Sistema;
using Interfaces.Sistema;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio.Sistema
{
    public class N_Auditoria : IAuditoria, IDisposable
    {
        #region Atributos
        private D_Auditoria dAuditoria = new D_Auditoria();
        #endregion

        #region Métodos
        public List<string> obtenerListaDeModulo()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<string> resultado = dAuditoria.obtenerListaDeModulo();
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string modulo, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dAuditoria.obtenerCatalago(modulo, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string modulo, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dAuditoria.obtenerCatalago(modulo, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Auditoria> obtenerObjetos(string modulo, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Auditoria> resultado = dAuditoria.obtenerObjetos(modulo, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Auditoria> obtenerObjetos(string modulo, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Auditoria> resultado = dAuditoria.obtenerObjetos(modulo, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public Auditoria obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            Auditoria resultado = dAuditoria.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(Auditoria objAuditoria)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dAuditoria.insertar(objAuditoria);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public void RegistrarAuditoria(string modulo, string denominacion) { D_Auditoria.RegistrarAuditoria(modulo, denominacion); }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("sys_auditoria"); }
        #endregion

        #region Liberación de Recursos
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) //Método que cierra y liberar los recursos utilizados
        {
            if (disposing)
            {
                dAuditoria.Dispose();
            }
        }
        #endregion
    }
}