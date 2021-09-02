using CapaDatos;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class N_CuentaContable : ICuentaContable, IDisposable
    {
        #region Atributos
        private D_CuentaContable dCuentaContable = new D_CuentaContable();
        #endregion

        #region Métodos
        public List<string> obtenerListaDeElementos(string[] ramaContable = null, bool exclusionDeCuenta = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<string> resultado = dCuentaContable.obtenerListaDeElementos(ramaContable, exclusionDeCuenta);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CatalogoBase> obtenerCatalago(string ramaPrincipal, string campo, string valor, string catalogo = "CATALOGO1", int indicePagina = -1, int tamanioPagina = 50)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CatalogoBase> resultado = dCuentaContable.obtenerCatalago(ramaPrincipal, campo, valor, catalogo, indicePagina, tamanioPagina);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public List<CuentaContable> obtenerObjetos(string ramaPrincipal, string campo, string valor)
        {
            Cursor.Current = Cursors.WaitCursor;
            List<CuentaContable> resultado = dCuentaContable.obtenerObjetos(ramaPrincipal, campo, valor);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public CuentaContable obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            CuentaContable resultado = dCuentaContable.obtenerObjeto(campo, valor, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizar(CuentaContable objCuentaContable)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCuentaContable.actualizar(objCuentaContable);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool actualizarSaldo(long id, double saldo, bool notificarExito = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCuentaContable.actualizarSaldo(id, saldo, notificarExito);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public bool insertar(CuentaContable objCuentaContable)
        {
            Cursor.Current = Cursors.WaitCursor;
            bool resultado = dCuentaContable.insertar(objCuentaContable);
            Cursor.Current = Cursors.Default;
            return resultado;
        }

        public long generarNumeroID() { return ConexionDB.GenerarNumeroID("data_cuenta_contable"); }

        public string generarCodigoContable(int codigoTipoDeCuenta) {
            string codigo = Convert.ToString(codigoTipoDeCuenta + (new Random().Next(1, 99))).PadRight(6, '0'); //Genera un código de 6 dígitos. Los primeros 4 representan el tipo de cuenta y los últimos 2 representan la cuenta en sí.
            while (dCuentaContable.obtenerObjeto("CODIGO", codigo, false) != null) //Se ejecuta hasta verificar que el código No se encuentre registrado en la Base de Datos
            {
                codigo = Convert.ToString(codigoTipoDeCuenta + (new Random().Next(1, 99))).PadRight(6, '0'); //Re-Genera un nuevo código de 6 dígitos en el caso de haberse registrado anteriormente el mismo código
            }
            return codigo;
        }
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
                dCuentaContable.Dispose();
            }
        }
        #endregion
    }
}
