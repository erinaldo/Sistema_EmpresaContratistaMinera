using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_ConsumoCentroCosto : IConsumoCentroCosto, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_stk_consumo_detalle.id_articulo, data_stk_consumo_detalle.denominacion, 
            SUM(data_stk_consumo_detalle.consumo) AS consumo_total, SUM(data_stk_consumo_detalle.desecho) AS desecho_total, 
            SUM(data_stk_consumo_detalle.costo_bruto * (data_stk_consumo_detalle.consumo + data_stk_consumo_detalle.desecho)) AS costo_bruto_total, 
            SUM(data_stk_consumo_detalle.costo_neto * (data_stk_consumo_detalle.consumo + data_stk_consumo_detalle.desecho)) AS costo_neto_total";
        private const string FROM = @" FROM data_stk_consumo_detalle
            INNER JOIN data_stk_consumo ON data_stk_consumo_detalle.id_stk_consumo = data_stk_consumo.id
            INNER JOIN data_centro_costo ON data_stk_consumo.id_centro_costo = data_centro_costo.id";
        private const string WHERE = @" WHERE data_centro_costo.denominacion = @centro_costo 
            AND (MONTH(data_stk_consumo.fecha) = @mes AND YEAR(data_stk_consumo.fecha) = @anio)"; //Filtro Objeto por Centro de Costo y Fecha de Consumo
        private const string GROUP = @" GROUP BY data_stk_consumo_detalle.denominacion";
        private const string ORDER = @" ORDER BY data_stk_consumo_detalle.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string centroCosto, string periodo, string catalogo, int indicePagina, int tamanioPagina)
        {
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            List<ConsumoCentroCosto> ListaDeObjetos = new List<ConsumoCentroCosto>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + WHERE + GROUP)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@centro_costo", centroCosto); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE + GROUP + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@centro_costo", centroCosto); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                ConsumoCentroCosto objConsumoCentroCosto = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objConsumoCentroCosto); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                    foreach (ConsumoCentroCosto itemConsumoCentroCosto in ListaDeObjetos)
                    {
                        if (catalogo == "CATALOGO1")
                        {
                            CatalogoBase elemento = new CatalogoBase(
                                itemConsumoCentroCosto.IdArticulo,
                                Convert.ToString(itemConsumoCentroCosto.IdArticulo).PadLeft(8, '0') +
                                    " | " + itemConsumoCentroCosto.Denominacion.Replace(";", "").PadRight(35, ' ') +
                                    " | " + Convert.ToString(itemConsumoCentroCosto.ConsumoTotal).PadLeft(5, ' ') +
                                    " | " + Convert.ToString(itemConsumoCentroCosto.DesechoTotal).PadLeft(5, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemConsumoCentroCosto.CostoBrutoTotal).PadLeft(12, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemConsumoCentroCosto.CostoNetoTotal).PadLeft(12, ' '));
                            ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                        }
                        else if (catalogo == "CATALOGO2")
                        {
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002CONSUMO_CENTRO_COSTO: Hay un conflicto en la consulta de consumos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<ConsumoCentroCosto> obtenerObjetos(string centroCosto, string periodo)
        {
            List<ConsumoCentroCosto> ListaDeObjetos = new List<ConsumoCentroCosto>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE + GROUP + ORDER)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@centro_costo", centroCosto); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                ConsumoCentroCosto objConsumoCentroCosto = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objConsumoCentroCosto); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004CONSUMO_CENTRO_COSTO: Hay un conflicto en la consulta de consumos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public double[] obtenerConsumoTotal(string centroCosto, string periodo)
        {
            double[] totales = new double[] { 0.00, 0.00, 0.00, 0.00 };
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@centro_costo", centroCosto); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                totales[0] = Formulario.ValidarNumeroDoble(Convert.ToString(lectorDB["consumo_total"]));
                                totales[1] = Formulario.ValidarNumeroDoble(Convert.ToString(lectorDB["desecho_total"]));
                                totales[2] = Formulario.ValidarNumeroDoble(Convert.ToString(lectorDB["costo_bruto_total"]));
                                totales[3] = Formulario.ValidarNumeroDoble(Convert.ToString(lectorDB["costo_neto_total"]));
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006CONSUMO_CENTRO_COSTO: Hay un conflicto en el cálculo de los consumos.", e); }
            finally { _conexion.Dispose(); }
            return totales;
        }
        #endregion

        #region Métodos de Instanciación
        private ConsumoCentroCosto instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new ConsumoCentroCosto(
                Convert.ToInt64(lectorDB["id_articulo"]),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToInt32(lectorDB["consumo_total"]),
                Convert.ToInt32(lectorDB["desecho_total"]),
                Convert.ToDouble(lectorDB["costo_bruto_total"]),
                Convert.ToDouble(lectorDB["costo_neto_total"]));
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