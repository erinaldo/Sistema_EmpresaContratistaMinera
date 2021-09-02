using Biblioteca.Ayudantes;
using CapaDatos.Sistema;
using Entidades.Catalogo;
using Interfaces.Catalogo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos.Catalogo
{
    public class D_PerfilLaboral : IPerfilLaboral, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        private const string ACTUALIZAR = @"UPDATE cat_perfil_laboral SET denominacion = @denominacion WHERE id = @id";
        private const string ELIMINAR = @"DELETE FROM cat_perfil_laboral WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO cat_perfil_laboral (id, denominacion) VALUES (@id, @denominacion)";
        private const string OBTENER_OBJETO_DENOMINACION = @"SELECT * FROM cat_perfil_laboral 
            WHERE LOWER(denominacion) = LOWER(@denominacion)";
        private const string OBTENER_OBJETO_ID = @"SELECT * FROM cat_perfil_laboral WHERE id = @id";
        private const string OBTENER_OBJETOS = @"SELECT * FROM cat_perfil_laboral ORDER BY denominacion ASC";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM cat_perfil_laboral
            WHERE denominacion = @denominacion AND id <> @id";
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM cat_perfil_laboral
            WHERE denominacion = @denominacion";
        #endregion

        #region Métodos
        public List<string> obtenerListaDeElementos()
        {
            List<string> listaDeElementos = new List<string>(); //Crea una lista de Objetos para almacenar los registros del tabla
            try
            {
                int iteracion = 0;
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_OBJETOS)) //Crea un comando de Base de Datos
                    {
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                if (iteracion == 0) listaDeElementos.Add(Convert.ToString(lectorDB["denominacion"])); //Agrega el elemento a la lista de elementos
                                else listaDeElementos.Add(" ," + Convert.ToString(lectorDB["denominacion"])); //Agrega el elemento a la lista de elementos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002PRFL: Hay un conflicto en la consulta de la lista de perfiles laborales.", e); }
            finally { _conexion.Dispose(); }
            return listaDeElementos;
        }

        public List<PerfilLaboral> obtenerObjetos()
        {
            List<PerfilLaboral> listaDeObjetos = new List<PerfilLaboral>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_OBJETOS)) //Crea un comando de Base de Datos
                    {
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                PerfilLaboral objPerfilLaboral = instanciarPerfilLaboral(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                listaDeObjetos.Add(objPerfilLaboral); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004PRFL: Hay un conflicto en la consulta de perfiles laborales.", e); }
            finally { _conexion.Dispose(); }
            return listaDeObjetos;
        }

        public PerfilLaboral obtenerObjeto(string denominacion, bool notificarExito)
        {
            PerfilLaboral objPerfilLaboral = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_OBJETO_DENOMINACION)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@denominacion", denominacion); //Agrega parámetros al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objPerfilLaboral = instanciarPerfilLaboral(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Perfil Laboral solicitado No hallado.\nVerifique el id del perfil laboral e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006PRFL: Hay un conflicto en la consulta del perfil laboral.", e); }
            finally { _conexion.Dispose(); }
            return objPerfilLaboral;
        }

        public PerfilLaboral obtenerObjeto(long id, bool notificarExito)
        {
            PerfilLaboral objPerfilLaboral = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_OBJETO_ID)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", id); //Agrega parámetros al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objPerfilLaboral = instanciarPerfilLaboral(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Perfil Laboral solicitado No hallado.\nVerifique el id del perfil laboral e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008PRFL: Hay un conflicto en la consulta del perfil laboral.", e); }
            finally { _conexion.Dispose(); }
            return objPerfilLaboral;
        }

        public bool actualizar(PerfilLaboral objPerfilLaboral, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objPerfilLaboral.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@denominacion", objPerfilLaboral.Denominacion); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            //Crea un comando de Base de Datos
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR))
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objPerfilLaboral.Id);
                                comandoDB_update.Parameters.AddWithValue("@denominacion", objPerfilLaboral.Denominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Catálogo de Perfiles Laborales", "Modificó el perfil laboral ID:" + objPerfilLaboral.Id.ToString() + "."); //Registra la modificación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Perfil Laboral Existente.\nEl perfil laboral ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M010PRFL", "M012PRFL", "M014PRFL", "M016PRFL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool eliminar(long id, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_OBJETO_ID)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_delete = _conexion.crearComandoDB(ELIMINAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_delete.Parameters.AddWithValue("@id", id);
                                comandoDB_delete.ExecuteNonQuery(); //Ejecuta el DELETE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Catálogo de Perfiles Laborales", "Eliminó el perfil laboral ID:" + id.ToString() + "."); //Registra la eliminación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Perfil Laboral Inexistente.\nEl perfil laboral No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M018PRFL", "M020PRFL", "M022PRFL", "M024PRFL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(PerfilLaboral objPerfilLaboral, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@denominacion", objPerfilLaboral.Denominacion); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            //Crea un comando de Base de Datos
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR))
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objPerfilLaboral.Id);
                                comandoDB_insert.Parameters.AddWithValue("@denominacion", objPerfilLaboral.Denominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Catálogo de Perfiles Laborales", "Agregó el perfil laboral ID:" + objPerfilLaboral.Id.ToString() + "."); //Registra la agregación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Perfil Laboral Existente.\nEl perfil laboral ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M026PRFL", "M028PRFL", "M030PRFL", "M032PRFL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        private PerfilLaboral instanciarPerfilLaboral(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            PerfilLaboral objPerfilLaboral = new PerfilLaboral(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToString(lectorDB["denominacion"])
            );
            return objPerfilLaboral;
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