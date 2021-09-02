using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_BalanceSumasSaldos : IBalanceSumasSaldos, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT id_cuenta_contable, SUM(data_asiento_contable.debe) AS debe, SUM(data_asiento_contable.haber) AS haber";
        private const string FROM = @" FROM data_asiento_contable";
        private const string WHERE = @" WHERE date(data_asiento_contable.asiento_fecha) >= date(@desde) AND date(data_asiento_contable.asiento_fecha) <= date(@hasta)"; //Filtro por Objeto Fecha de Asiento
        private const string GROUP = @" GROUP BY id_cuenta_contable";
        private const string SUM_DEBE = @"SELECT SUM(data_asiento_contable.debe)"; //Obtiene la sumatoria de la columna Debe
        private const string SUM_HABER = @"SELECT SUM(data_asiento_contable.haber)"; //Obtiene la sumatoria de la columna Haber
        private const string ORDER = @" ORDER BY id_cuenta_contable ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            string[] tipoCuentaContableAntecesor = new string[] { "" }; //Importante: Se debe inicializar el primer y único valor del vector
            List<BalanceSumasSaldos> ListaDeObjetos = new List<BalanceSumasSaldos>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + WHERE + GROUP)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE + GROUP + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                BalanceSumasSaldos objBalanceSumasSaldos = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objBalanceSumasSaldos); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                    foreach (BalanceSumasSaldos itemBalanceSumasSaldos in ListaDeObjetos)
                    {
                        string[] tipoCuentaContableActual = itemBalanceSumasSaldos.CuentaContable.TipoCuenta.Split('>');
                        if (catalogo == "CATALOGO1")
                        {
                            CatalogoBase elemento = new CatalogoBase(
                                itemBalanceSumasSaldos.CuentaContable.Id,
                                (tipoCuentaContableActual[0].Trim() + " > " + tipoCuentaContableActual[1].Trim()).PadRight(45, ' ') +
                                    " | " + itemBalanceSumasSaldos.CuentaContable.Denominacion.PadRight(25, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemBalanceSumasSaldos.Debe).PadLeft(12, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemBalanceSumasSaldos.Haber).PadLeft(12, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemBalanceSumasSaldos.Debe - itemBalanceSumasSaldos.Haber).PadLeft(12, ' '));
                                ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                        }
                        else if (catalogo == "CATALOGO2")
                        {
                            CatalogoBase elemento;
                            #region Fila Tipo SubTitulo
                            if (((tipoCuentaContableActual.Length >= 2) ? (tipoCuentaContableActual[1]) : tipoCuentaContableActual[0]) 
                                != ((tipoCuentaContableAntecesor.Length >= 2) ? (tipoCuentaContableAntecesor[1]) : tipoCuentaContableAntecesor[0]))
                            {
                                elemento = new CatalogoBase(
                                    itemBalanceSumasSaldos.CuentaContable.Id,
                                    (tipoCuentaContableActual[0].Trim() + " > " + tipoCuentaContableActual[1].Trim()).PadRight(45, ' ') +
                                        " | " + ("").PadRight(25, ' ') +
                                        " | " + ("").PadLeft(12, ' ') +
                                        " | " + ("").PadLeft(12, ' ') +
                                        " | " + ("").PadLeft(12, ' '));
                                ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                            }
                            #endregion
                            elemento = new CatalogoBase(
                                itemBalanceSumasSaldos.CuentaContable.Id,
                                ("").PadRight(45, ' ') +
                                    " | " + itemBalanceSumasSaldos.CuentaContable.Denominacion.PadRight(25, ' ') +
                                    " | " + ("$" + Formulario.ValidarCampoMoneda(itemBalanceSumasSaldos.Debe)).PadLeft(12, ' ') +
                                    " | " + ("$" + Formulario.ValidarCampoMoneda(itemBalanceSumasSaldos.Haber)).PadLeft(12, ' ') +
                                    " | " + ("$" + Formulario.ValidarCampoMoneda(itemBalanceSumasSaldos.Debe - itemBalanceSumasSaldos.Haber)).PadLeft(12, ' '));
                            ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                        }
                        tipoCuentaContableAntecesor = tipoCuentaContableActual; //Deducción de Sub-Título - Paso 2: Establece la rama principal de la Cuenta Contable actual (Importante para completar el ciclo)
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002BALANCE_SS: Hay un conflicto en la consulta de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public double[] contabilizarDebeHaber(DateTime desde, DateTime hasta)
        {
            double[] valorDebeHaber = new double[] { 0.00, 0.00 };
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_DEBE + FROM + WHERE)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        object resultado = comandoDB.ExecuteScalar();
                        if (resultado != DBNull.Value) valorDebeHaber[0] = (double)resultado; //Almacena la sumatoria del Debe
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_HABER + FROM + WHERE)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        object resultado = comandoDB.ExecuteScalar();
                        if (resultado != DBNull.Value) valorDebeHaber[1] = (double)resultado; //Almacena la sumatoria del Haber
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004BALANCE_SS: Hay un conflicto en el cálculo del debe y haber del balance de sumas y saldos .", e); }
            finally { _conexion.Dispose(); }
            return valorDebeHaber;
        }
        #endregion

        #region Métodos de Instanciación
        private BalanceSumasSaldos instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new BalanceSumasSaldos(
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable"]), false),
                Convert.ToDouble(lectorDB["debe"]),
                Convert.ToDouble(lectorDB["haber"]),
                0.00); //Saldo
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
                _conexion.Dispose();
            }
        }
        #endregion
    }
}