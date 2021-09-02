using Biblioteca.Ayudantes;
using CapaDatos.Sistema;
using Entidades.Catalogo;
using Interfaces.Catalogo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos.Catalogo
{
    public class D_ObraSocial : IObraSocial, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT1 = @"SELECT *";
        private const string FROM = @" FROM cat_obra_social";
        private const string WHERE1 = @" WHERE id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE codigo = @codigo"; //Filtrar Objeto por Código
        private const string WHERE3 = @" WHERE LOWER(denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string ORDER = @" ORDER BY denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM cat_obra_social WHERE codigo = @codigo AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ELIMINAR = @"SELECT * FROM cat_obra_social WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM cat_obra_social WHERE codigo = @codigo"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE cat_obra_social SET denominacion = @denominacion, codigo = @codigo WHERE id = @id";
        private const string ELIMINAR = @"DELETE FROM cat_obra_social WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO cat_obra_social (id, codigo, denominacion) VALUES (@id, @codigo, @denominacion)";
        #endregion

        #region Métodos
        public List<string> obtenerListaDeElementos()
        {
            List<string> listaDeElementos = new List<string>(); //Crea una lista de Objetos para almacenar los registros del tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + ORDER)) //Crea un comando de Base de Datos
                    {
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader()) //Ejecuta una consulta en la Base de Datos
                        {
                            while (lectorDB.Read())
                            {
                                listaDeElementos.Add(Convert.ToString(lectorDB["denominacion"])); //Agrega el elemento a la lista de elementos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002CATOSOCIAL: Hay un conflicto en la consulta de la lista de obras sociales.", e); }
            finally { _conexion.Dispose(); }
            return listaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "CODIGO") condicional = WHERE2; //Consulta filtrada por Código
            if (campo == "DENOMINACION") condicional = WHERE3; //Consulta filtrada por Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CODIGO") comandoDB.Parameters.AddWithValue("@codigo", valor); //Agrega un parámetro al filtro
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CODIGO") comandoDB.Parameters.AddWithValue("@codigo", valor); //Agrega un parámetro al filtro
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
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
                                        Convert.ToString(lectorDB["codigo"]).PadLeft(6, ' ') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(25, ' '));
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
            catch (MySqlException e) { Mensaje.Error("Error-M004CATOSOCIAL: Hay un conflicto en la consulta de obras sociales.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<ObraSocial> obtenerObjetos(string campo, string valor)
        {
            string condicional = "";
            if (campo == "CODIGO") condicional = WHERE2; //Consulta filtrada por Código
            if (campo == "DENOMINACION") condicional = WHERE3; //Consulta filtrada por Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por Código
            List<ObraSocial> ListaDeObjetos = new List<ObraSocial>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CODIGO") comandoDB.Parameters.AddWithValue("@codigo", valor); //Agrega un parámetro al filtro
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega un parámetro al filtro
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                ObraSocial objObraSocial = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objObraSocial); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006CATOSOCIAL: Hay un conflicto en la consulta de obras sociales.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public ObraSocial obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "CODIGO") condicional = WHERE2; //Consulta filtrada por Código
            if (campo == "DENOMINACION") condicional = WHERE3; //Consulta filtrada por Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por Código
            ObraSocial objObraSocial = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "CODIGO") comandoDB.Parameters.AddWithValue("@codigo", valor); //Agrega un parámetro al filtro
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", valor); //Agrega un parámetro al filtro
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objObraSocial = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Obra Social solicitada No hallada.\nVerifique los datos de la obra social e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008CATOSOCIAL: Hay un conflicto en la consulta de la obra social.", e); }
            finally { _conexion.Dispose(); }
            return objObraSocial;
        }

        public bool actualizar(ObraSocial objObraSocial, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objObraSocial.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@codigo", objObraSocial.Codigo); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            //Crea un comando de Base de Datos
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR))
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objObraSocial.Id);
                                comandoDB_update.Parameters.AddWithValue("@codigo", objObraSocial.Codigo);
                                comandoDB_update.Parameters.AddWithValue("@denominacion", objObraSocial.Denominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Catálogo de Obras Sociales", "Modificó la obra social ID:" + objObraSocial.Id.ToString() + "."); //Registra la modificación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Obra Social Existente.\nLa obra social ya se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M010CATOSOCIAL", "M012CATOSOCIAL", "M014CATOSOCIAL", "M016CATOSOCIAL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool eliminar(long id, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ELIMINAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_delete = _conexion.crearComandoDB(ELIMINAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_delete.Parameters.AddWithValue("@id", id);
                                comandoDB_delete.ExecuteNonQuery(); //Ejecuta el DELETE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Catálogo de Obras Sociales", "Eliminó la obra social ID:" + id.ToString() + "."); //Registra la eliminación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Obra Social Inexistente.\nLa obra social No se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M018CATOSOCIAL", "M020CATOSOCIAL", "M022CATOSOCIAL", "M024CATOSOCIAL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(ObraSocial objObraSocial, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@codigo", objObraSocial.Codigo); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            //Crea un comando de Base de Datos
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR))
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objObraSocial.Id);
                                comandoDB_insert.Parameters.AddWithValue("@codigo", objObraSocial.Codigo);
                                comandoDB_insert.Parameters.AddWithValue("@denominacion", objObraSocial.Denominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Catálogo de Obras Sociales", "Agregó la obra social ID:" + objObraSocial.Id.ToString() + "."); //Registra la agregación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Obra Social Existente.\nLa obra social ya se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M026CATOSOCIAL", "M028CATOSOCIAL", "M030CATOSOCIAL", "M032CATOSOCIAL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private ObraSocial instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            ObraSocial objObraSocial = new ObraSocial(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToString(lectorDB["codigo"]),
                Convert.ToString(lectorDB["denominacion"])
            );
            return objObraSocial;
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
