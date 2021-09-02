using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_SuministracionIEPPDetalle : ISuministracionIEPPDetalle, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_suministracion_iepp_detalle.id, id_suministracion, id_articulo, 
            data_suministracion_iepp_detalle.denominacion, certificacion, cantidad, unidad, deposito, inventario";
        private const string FROM = @" FROM data_suministracion_iepp_detalle 
            INNER JOIN data_suministracion_iepp ON data_suministracion_iepp_detalle.id_suministracion = data_suministracion_iepp.id";
        private const string WHERE1 = @" WHERE data_suministracion_iepp_detalle.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_suministracion_iepp_detalle.id_suministracion = @id_suministracion"; //Filtrar Objeto por ID Suministracion
        private const string WHERE3 = @" WHERE data_suministracion_iepp_detalle.id_articulo = @id_articulo"; //Filtrar Objeto por ID Artículo
        private const string WHERE4 = @" WHERE LOWER(data_suministracion_iepp_detalle.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string ORDER = @" ORDER BY data_suministracion_iepp_detalle.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_suministracion_iepp_detalle WHERE id = @id "; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string INSERTAR = @"INSERT INTO data_suministracion_iepp_detalle(id, id_suministracion, id_articulo,
            denominacion, certificacion, cantidad, unidad, deposito, inventario)
            VALUES (@id, @id_suministracion, @id_articulo, @denominacion, @certificacion, @cantidad, @unidad, @deposito,
            @inventario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "DENOMINACION") condicional = WHERE4; //Consulta filtrada por Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID del Detalle
            if (campo == "ID_MOVIMIENTO") condicional = WHERE2; //Consulta filtrada por ID del Suministracion
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
                        if (campo == "ID_MOVIMIENTO") comandoDB.Parameters.AddWithValue("@id_suministracion", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "ID_ARTICULO") comandoDB.Parameters.AddWithValue("@id_articulo", valor); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_MOVIMIENTO") comandoDB.Parameters.AddWithValue("@id_suministracion", valor); //Agrega un parámetro al comando de Base de Datos
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
                                            " | " + Convert.ToString(lectorDB["id_suministracion"]).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["id_articulo"]).PadLeft(6, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToString(lectorDB["certificacion"]).PadRight(2, ' ') +
                                            " | " + Convert.ToString(lectorDB["cantidad"]).PadRight(6, ' ') +
                                            " | " + Convert.ToString(lectorDB["unidad"]).PadRight(3, ' ') +
                                            " | " + Convert.ToString(lectorDB["deposito"]).PadRight(10, ' ') +
                                            " | " + Convert.ToString(lectorDB["inventario"]).PadLeft(23, ' '));
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
            catch (MySqlException e) { Mensaje.Error("Error-M002SUMINISTRACION_IEPP_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<SuministracionIEPPDetalle> obtenerObjetos(long idCompra)
        {
            List<SuministracionIEPPDetalle> ListaDeObjetos = new List<SuministracionIEPPDetalle>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE2 + ORDER)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_suministracion", idCompra); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                SuministracionIEPPDetalle objSuministracionIEPPDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objSuministracionIEPPDetalle); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004SUMINISTRACION_IEPP_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<SuministracionIEPPDetalle> obtenerObjetos(string campo, string valor)
        {
            string condicional = "";
            if (campo == "DENOMINACION") condicional = WHERE4; //Consulta filtrada por Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID del Detalle
            if (campo == "ID_MOVIMIENTO") condicional = WHERE2; //Consulta filtrada por ID del Suministracion
            if (campo == "ID_ARTICULO") condicional = WHERE3; //Consulta filtrada por ID del Artículo
            List<SuministracionIEPPDetalle> ListaDeObjetos = new List<SuministracionIEPPDetalle>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_MOVIMIENTO") comandoDB.Parameters.AddWithValue("@id_suministracion", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_ARTICULO") comandoDB.Parameters.AddWithValue("@id_articulo", valor); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                SuministracionIEPPDetalle objSuministracionIEPPDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objSuministracionIEPPDetalle); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006SUMINISTRACION_IEPP_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public SuministracionIEPPDetalle obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            SuministracionIEPPDetalle objSuministracionIEPPDetalle = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objSuministracionIEPPDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
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
            catch (MySqlException e) { Mensaje.Error("Error-M008SUMINISTRACION_IEPP_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return objSuministracionIEPPDetalle;
        }

        public bool insertar(SuministracionIEPPDetalle objSuministracionIEPPDetalle, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objSuministracionIEPPDetalle.Id); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objSuministracionIEPPDetalle.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_suministracion", objSuministracionIEPPDetalle.SuministracionIEPP.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_articulo", objSuministracionIEPPDetalle.IdArticulo);
                                comandoDB_insert.Parameters.AddWithValue("@denominacion", objSuministracionIEPPDetalle.Denominacion);
                                comandoDB_insert.Parameters.AddWithValue("@certificacion", objSuministracionIEPPDetalle.Certificacion);
                                comandoDB_insert.Parameters.AddWithValue("@cantidad", objSuministracionIEPPDetalle.Cantidad);
                                comandoDB_insert.Parameters.AddWithValue("@unidad", objSuministracionIEPPDetalle.Unidad);
                                comandoDB_insert.Parameters.AddWithValue("@deposito", objSuministracionIEPPDetalle.Deposito);
                                comandoDB_insert.Parameters.AddWithValue("@inventario", objSuministracionIEPPDetalle.Inventario);
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
            catch (MySqlException e) { Mensaje.ErrorMySql("M010SUMINISTRACION_IEPP_DETALLE", "M012SUMINISTRACION_IEPP_DETALLE", "M014SUMINISTRACION_IEPP_DETALLE", "M016SUMINISTRACION_IEPP_DETALLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private SuministracionIEPPDetalle instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new SuministracionIEPPDetalle(
                Convert.ToInt64(lectorDB["id"]),
                new D_SuministracionIEPP().obtenerObjeto("ID", Convert.ToString(lectorDB["id_suministracion"]), false),
                Convert.ToInt64(lectorDB["id_articulo"]),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToString(lectorDB["certificacion"]),
                Convert.ToInt32(lectorDB["cantidad"]),
                Convert.ToString(lectorDB["unidad"]),
                Convert.ToString(lectorDB["deposito"]),
                Convert.ToString(lectorDB["inventario"]));
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
