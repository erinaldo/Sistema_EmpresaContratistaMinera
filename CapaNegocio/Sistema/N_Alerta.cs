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
    public class N_Alerta : IAlerta, IDisposable
    {
        #region Atributos
        private D_Alerta dAlerta = new D_Alerta();
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string TipoAlerta, string estado, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dAlerta.obtenerCatalago(TipoAlerta, estado, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string TipoAlerta, string estado, string campo, DateTime desde, DateTime hasta, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dAlerta.obtenerCatalago(TipoAlerta, estado, campo, desde, hasta, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Alerta> obtenerObjetos(string TipoAlerta, string estado, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Alerta> resultado = dAlerta.obtenerObjetos(TipoAlerta, estado, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<Alerta> obtenerObjetos(string TipoAlerta, string estado, string campo, DateTime desde, DateTime hasta)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<Alerta> resultado = dAlerta.obtenerObjetos(TipoAlerta, estado, campo, desde, hasta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public Alerta obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            Alerta resultado = dAlerta.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(Alerta objAlerta, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dAlerta.actualizar(objAlerta, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool eliminar(long id, bool notificarExito)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dAlerta.eliminar(id, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(Alerta objAlerta)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dAlerta.insertar(objAlerta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public void insertar(List<Alerta> listaDeAlertas)
        {
            Cursor.Current = Cursors.WaitCursor;
            dAlerta.insertar(listaDeAlertas);
            Cursor.Current = Cursors.Default;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("sys_alerta"); }
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
                dAlerta.Dispose();
            }
        }
        #endregion
    }
}
