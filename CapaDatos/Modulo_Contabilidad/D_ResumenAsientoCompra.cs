using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_ResumenAsientoCompra : IResumenAsientoCompra, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_asiento_contable.id_cuenta_contable, data_cuenta_contable.denominacion,
            SUM(data_asiento_contable.debe) AS debe, SUM(data_asiento_contable.haber) AS haber";
        private const string FROM = @" FROM data_asiento_contable
            LEFT JOIN data_cuenta_contable ON data_asiento_contable.id_cuenta_contable = data_cuenta_contable.id";
        private const string WHERE = @" WHERE (LOWER(data_cuenta_contable.tipo_cuenta) LIKE LOWER('%ACTIVO CORRIENTE > BIENES DE USO%') 
            OR LOWER(data_cuenta_contable.tipo_cuenta) LIKE LOWER('%ACTIVO CORRIENTE > BIENES DE CAMBIO%') 
            OR data_cuenta_contable.id = 13 OR data_cuenta_contable.id = 10)
            AND (MONTH(data_asiento_contable.asiento_fecha) = @mes AND YEAR(data_asiento_contable.asiento_fecha) = @anio)"; //Filtro Objeto por Rama Contable y Fecha de Asiento
        private const string GROUP = @" GROUP BY id_cuenta_contable";
        private const string SUM_DEBE = @"SELECT SUM(data_asiento_contable.debe)"; //Obtiene la sumatoria de la columna Debe
        private const string SUM_HABER = @"SELECT SUM(data_asiento_contable.haber)"; //Obtiene la sumatoria de la columna Haber
        private const string ORDER = @" ORDER BY (data_cuenta_contable.id = 10), (data_cuenta_contable.id = 13), data_cuenta_contable.denominacion"; //Ordena por nombre de Cuenta Contable y coloca al final de la lista la Cuenta Contable "IVA CREDITO FISCAL" y "PROVEEDORES"
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string periodo, string catalogo, int indicePagina, int tamanioPagina)
        {
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            List<ResumenAsientoCompra> ListaDeObjetos = new List<ResumenAsientoCompra>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + WHERE + GROUP)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE + GROUP + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                ResumenAsientoCompra objResumenAsientoCompra = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objResumenAsientoCompra); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                    foreach (ResumenAsientoCompra itemResumenAsientoCompra in ListaDeObjetos)
                    {
                        if (catalogo == "CATALOGO1")
                        {
                            CatalogoBase elemento = new CatalogoBase(
                                itemResumenAsientoCompra.CuentaContable.Id,
                                itemResumenAsientoCompra.CuentaContable.Denominacion.PadRight(88, ' ') + //Asigné el valor en 85 para cubrir el ancho del ListBox 
                                    " | " + Formulario.ValidarCampoMoneda(itemResumenAsientoCompra.Debe).PadLeft(12, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemResumenAsientoCompra.Haber).PadLeft(12, ' '));
                                ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                        }
                        else if (catalogo == "CATALOGO2")
                        {
                            CatalogoBase elemento = new CatalogoBase(
                                itemResumenAsientoCompra.CuentaContable.Id,
                                itemResumenAsientoCompra.CuentaContable.Denominacion.PadRight(25, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemResumenAsientoCompra.Debe).PadLeft(12, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemResumenAsientoCompra.Haber).PadLeft(12, ' '));
                            ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002RESUMEN_COMPRA: Hay un conflicto en la consulta de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public double[] contabilizarDebeHaber(string periodo)
        {
            double[] valorDebeHaber = new double[] { 0.00, 0.00 };
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_DEBE + FROM + WHERE)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        object resultado = comandoDB.ExecuteScalar();
                        if (resultado != DBNull.Value) valorDebeHaber[0] = (double)resultado; //Almacena la sumatoria del Debe
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_HABER + FROM + WHERE)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        object resultado = comandoDB.ExecuteScalar();
                        if (resultado != DBNull.Value) valorDebeHaber[1] = (double)resultado; //Almacena la sumatoria del Haber
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004RESUMEN_COMPRA: Hay un conflicto en el cálculo del debe y haber del balance de sumas y saldos .", e); }
            finally { _conexion.Dispose(); }
            return valorDebeHaber;
        }
        #endregion

        #region Métodos de Instanciación
        private ResumenAsientoCompra instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new ResumenAsientoCompra(
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable"]), false),
                Convert.ToDouble(lectorDB["debe"]),
                Convert.ToDouble(lectorDB["haber"]) ); 
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