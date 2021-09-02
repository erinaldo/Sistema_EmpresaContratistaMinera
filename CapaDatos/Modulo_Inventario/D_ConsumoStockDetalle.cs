using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_ConsumoStockDetalle : IConsumoStockDetalle, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_stk_consumo_detalle.id, id_stk_consumo, id_articulo, 
            data_stk_consumo_detalle.denominacion, consumo, desecho, unidad, costo_bruto, costo_neto";
        private const string FROM = @" FROM data_stk_consumo_detalle 
            INNER JOIN data_stk_consumo ON data_stk_consumo_detalle.id_stk_consumo = data_stk_consumo.id";
        private const string WHERE1 = @" WHERE data_stk_consumo_detalle.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_stk_consumo_detalle.id_stk_consumo = @id_stk_consumo"; //Filtrar Objeto por ID Consumo
        private const string WHERE3 = @" WHERE data_stk_consumo_detalle.id_articulo = @id_articulo"; //Filtrar Objeto por ID Artículo
        private const string WHERE4 = @" WHERE LOWER(data_stk_consumo_detalle.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string ORDER = @" ORDER BY data_stk_consumo_detalle.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_stk_consumo_detalle WHERE id = @id "; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string INSERTAR = @"INSERT INTO data_stk_consumo_detalle(id, id_stk_consumo, id_articulo,
            denominacion, consumo, desecho, unidad, costo_bruto, costo_neto)
            VALUES (@id, @id_stk_consumo, @id_articulo, @denominacion, @consumo, @desecho, @unidad, @costo_bruto,
            @costo_neto)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "DENOMINACION") condicional = WHERE4; //Consulta filtrada por Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID del Detalle
            if (campo == "ID_CONSUMO") condicional = WHERE2; //Consulta filtrada por ID del Consumo
            if (campo == "ID_ARTICULO") condicional = WHERE3; //Consulta filtrada por ID del Artículo
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "ID_CONSUMO") comandoDB.Parameters.AddWithValue("@id_stk_consumo", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "ID_ARTICULO") comandoDB.Parameters.AddWithValue("@id_articulo", valor); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_CONSUMO") comandoDB.Parameters.AddWithValue("@id_stk_consumo", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_ARTICULO") comandoDB.Parameters.AddWithValue("@id_articulo", valor); //Agrega un parámetro al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["id_stk_consumo"]).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["id_articulo"]).PadLeft(6, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToString(lectorDB["consumo"]).PadRight(6, ' ') +
                                            " | " + Convert.ToString(lectorDB["desecho"]).PadRight(6, ' ') +
                                            " | " + Convert.ToString(lectorDB["unidad"]).PadRight(3, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToDouble(lectorDB["costo_bruto"])) +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToDouble(lectorDB["costo_neto"])));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002CONSUMO_STK_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<ConsumoStockDetalle> obtenerObjetos(long idCompra)
        {
            List<ConsumoStockDetalle> ListaDeObjetos = new List<ConsumoStockDetalle>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE2 + ORDER)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_stk_consumo", idCompra); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                ConsumoStockDetalle objConsumoStockDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objConsumoStockDetalle); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004CONSUMO_STK_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<ConsumoStockDetalle> obtenerObjetos(string campo, string valor)
        {
            string condicional = "";
            if (campo == "DENOMINACION") condicional = WHERE4; //Consulta filtrada por Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID del Detalle
            if (campo == "ID_CONSUMO") condicional = WHERE2; //Consulta filtrada por ID del Consumo
            if (campo == "ID_ARTICULO") condicional = WHERE3; //Consulta filtrada por ID del Artículo
            List<ConsumoStockDetalle> ListaDeObjetos = new List<ConsumoStockDetalle>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_CONSUMO") comandoDB.Parameters.AddWithValue("@id_stk_consumo", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_ARTICULO") comandoDB.Parameters.AddWithValue("@id_articulo", valor); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                ConsumoStockDetalle objConsumoStockDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objConsumoStockDetalle); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006CONSUMO_STK_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public ConsumoStockDetalle obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            ConsumoStockDetalle objConsumoStockDetalle = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objConsumoStockDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Detalle solicitado No hallado.\nVerifique los datos del comprobante e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008CONSUMO_STK_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return objConsumoStockDetalle;
        }

        public bool insertar(ConsumoStockDetalle objConsumoStockDetalle, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objConsumoStockDetalle.Id); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objConsumoStockDetalle.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_stk_consumo", objConsumoStockDetalle.ConsumoStock.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_articulo", objConsumoStockDetalle.IdArticulo);
                                comandoDB_insert.Parameters.AddWithValue("@denominacion", objConsumoStockDetalle.Denominacion);
                                comandoDB_insert.Parameters.AddWithValue("@consumo", objConsumoStockDetalle.Consumo);
                                comandoDB_insert.Parameters.AddWithValue("@desecho", objConsumoStockDetalle.Desecho);
                                comandoDB_insert.Parameters.AddWithValue("@unidad", objConsumoStockDetalle.Unidad);
                                comandoDB_insert.Parameters.AddWithValue("@costo_bruto", objConsumoStockDetalle.CostoBruto);
                                comandoDB_insert.Parameters.AddWithValue("@costo_neto", objConsumoStockDetalle.CostoNeto);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Detalle de comprobante Existente.\nEl detalle del comprobante ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M010CONSUMO_STK_DETALLE", "M012CONSUMO_STK_DETALLE", "M014CONSUMO_STK_DETALLE", "M016CONSUMO_STK_DETALLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private ConsumoStockDetalle instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new ConsumoStockDetalle(
                Convert.ToInt64(lectorDB["id"]),
                new D_ConsumoStock().obtenerObjeto("ID", Convert.ToString(lectorDB["id_stk_consumo"]), false),
                Convert.ToInt64(lectorDB["id_articulo"]),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToInt32(lectorDB["consumo"]),
                Convert.ToInt32(lectorDB["desecho"]),
                Convert.ToString(lectorDB["unidad"]),
                Convert.ToDouble(lectorDB["costo_bruto"]),
                Convert.ToDouble(lectorDB["costo_neto"]));
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
