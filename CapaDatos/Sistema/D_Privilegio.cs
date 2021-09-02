using Biblioteca.Ayudantes;
using Entidades.Sistema;
using Interfaces.Sistema;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos.Sistema
{
    public class D_Privilegio : IPrivilegio, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string OBTENER_VERIFICACION_COLUMNA = @"SHOW COLUMNS FROM sys_privilegio WHERE FIELD = @usuario";
        private const string OBTENER_VERIFICACION_COLUMNA_TEMPORAL = @"SHOW COLUMNS FROM sys_privilegio WHERE FIELD LIKE @usuario";
        #endregion

        #region Métodos
        public List<long> obtenerElementos(long idUsuario)
        {
            List<long> ListaDeElementos = new List<long>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                string consultaSQL = @"SELECT sys_privilegio.id FROM sys_privilegio WHERE `usuario" + idUsuario.ToString() + "` = true";
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(consultaSQL)) //Crea un comando de Base de Datos
                    {
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                ListaDeElementos.Add(Convert.ToInt64(lectorDB["id"])); //Agrega este ID a la lista de elementos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002PRIVILEGIO: Hay un conflicto en la consulta de la lista de privilegios.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<Privilegio> obtenerObjetos(long idUsuario)
        {
            List<Privilegio> ListaDeObjetos = new List<Privilegio>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                string consultaSQL = @"SELECT sys_privilegio.id, sys_privilegio.denominacion, `usuario"
                    + idUsuario.ToString() + "` AS permiso FROM sys_privilegio ORDER BY denominacion ASC"; //Confecciona la consulta SQL
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(consultaSQL)) //Crea un comando de Base de Datos
                    {
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Privilegio objPrivilegio = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objPrivilegio); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004PRIVILEGIO: Hay un conflicto en la consulta de privilegios.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public bool actualizar(long idUsuario, List<Privilegio> listaDePrivilegios)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_COLUMNA)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@usuario", "usuario" + idUsuario.ToString()); //Agrega un parámetro al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta No tenga éxito
                        {
                            string ejecucionSQL = @"UPDATE sys_privilegio SET usuario" + idUsuario.ToString() + @" = @permiso WHERE id = @id"; //Cadena de ejecución SQL
                            foreach (Privilegio item in listaDePrivilegios)
                            {
                                using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ejecucionSQL)) //Crea un comando de Base de Datos
                                {
                                    comandoDB_update.Parameters.AddWithValue("@id", item.Id);
                                    comandoDB_update.Parameters.AddWithValue("@permiso", item.Permiso);
                                    comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                }
                            }
                            return true;
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M006PRIVILEGIO", "M008PRIVILEGIO", "M010PRIVILEGIO", "M012PRIVILEGIO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool agregarColumna(long idUsuario)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_COLUMNA)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@usuario", "usuario" + idUsuario.ToString()); //Agrega un parámetro al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            string ejecucionSQL = @"ALTER TABLE sys_privilegio ADD `usuario" + idUsuario.ToString() + @"` BOOLEAN NOT NULL AFTER denominacion"; //Cadena de ejecución SQL
                            using (MySqlCommand comandoDB_add = _conexion.crearComandoDB(ejecucionSQL)) //Crea un comando de Base de Datos (ALTER: No reconoce parámetros)
                            {
                                comandoDB_add.ExecuteNonQuery(); //Ejecuta el ADD en la Base de Datos
                                return true;
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M014PRIVILEGIO", "M016PRIVILEGIO", "M018PRIVILEGIO", "M020PRIVILEGIO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool asociarColumna(long idUsuario, long idTemporal)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_COLUMNA)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@usuario", "usuario" + idTemporal.ToString()); //Agrega un parámetro al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta No tenga éxito
                        {
                            string ejecucionSQL = @"ALTER TABLE sys_privilegio CHANGE `usuario" + idTemporal.ToString() + "` `usuario" + idUsuario.ToString() + "` TINYINT(1) NOT NULL"; //Cadena de ejecución SQL
                            using (MySqlCommand comandoDB_add = _conexion.crearComandoDB(ejecucionSQL)) //Crea un comando de Base de Datos (ALTER: No reconoce parámetros)
                            {
                                comandoDB_add.ExecuteNonQuery(); //Ejecuta el ADD en la Base de Datos
                                return true;
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M022PRIVILEGIO", "M024PRIVILEGIO", "M026PRIVILEGIO", "M028PRIVILEGIO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool quitarColumna(long idUsuario)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_COLUMNA)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@usuario", "usuario" + idUsuario.ToString()); //Agrega un parámetro al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta No tenga éxito
                        {
                            string ejecucionSQL = @"ALTER TABLE sys_privilegio DROP `usuario" + idUsuario.ToString() + "`"; //Cadena de ejecución SQL
                            using (MySqlCommand comandoDB_drop = _conexion.crearComandoDB(ejecucionSQL)) //Crea un comando de Base de Datos (DROP: No reconoce parámetros)
                            {
                                comandoDB_drop.ExecuteNonQuery(); //Ejecuta el ADD en la Base de Datos
                            }
                        }
                    }
                    return true;
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M030PRIVILEGIO", "M032PRIVILEGIO", "M034PRIVILEGIO", "M036PRIVILEGIO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool quitarColumnas_Temporales()
        {
            List<string> listaDeColumnas = new List<string>(); //Importante: Utilizo una lista para almacenar los nombres de las columnas y poder ejecutar el DROP correctamente.
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_COLUMNA_TEMPORAL)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@usuario", "%-%"); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                listaDeColumnas.Add(lectorDB["Field"].ToString()); //Agrega el nombre de la columna a la lista de columna
                            }
                        }
                        foreach (string columna in listaDeColumnas)
                        {
                            string ejecucionSQL = @"ALTER TABLE sys_privilegio DROP `" + columna + "`"; //Cadena de ejecución SQL
                            using (MySqlCommand comandoDB_drop = _conexion.crearComandoDB(ejecucionSQL)) //Crea un comando de Base de Datos (DROP: No reconoce parámetros y debe llevar comillas diagonales)
                            {
                                comandoDB_drop.ExecuteNonQuery(); //Ejecuta el ADD en la Base de Datos
                            }
                        }
                        return true;
                    }
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M038PRIVILEGIO", "M040PRIVILEGIO", "M042PRIVILEGIO", "M044PRIVILEGIO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private Privilegio instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Privilegio(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToBoolean(lectorDB["permiso"]));
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