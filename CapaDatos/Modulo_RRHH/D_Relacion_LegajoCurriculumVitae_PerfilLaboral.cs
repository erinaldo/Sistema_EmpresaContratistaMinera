using Biblioteca.Ayudantes;
using CapaDatos.Catalogo;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_Relacion_LegajoCurriculumVitae_PerfilLaboral : PerfilLaboral, IRelacion_LegajoCurriculumVitae_PerfilLaboral, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        private const string RELACION = @"SELECT relation_curriculum_vitae__perfil_laboral.*,
            cat_perfil_laboral.denominacion AS perfil_laboral 
            FROM relation_curriculum_vitae__perfil_laboral 
            LEFT JOIN data_legajo ON relation_curriculum_vitae__perfil_laboral.id_legajo = data_legajo.id 
            LEFT JOIN cat_perfil_laboral ON relation_curriculum_vitae__perfil_laboral.id_perfil_laboral = cat_perfil_laboral.id";
        private const string ASOCIAR_PERFILES_TEMPORALES = @"UPDATE relation_curriculum_vitae__perfil_laboral SET 
            id_legajo = @id_definitivo WHERE id_legajo = @id_temporal";
        private const string ELIMINAR = @"DELETE FROM relation_curriculum_vitae__perfil_laboral WHERE id = @id";
        private const string ELIMINAR_PERFILES_PERSONALES = @"DELETE FROM relation_curriculum_vitae__perfil_laboral WHERE id_legajo = @id_legajo";
        private const string ELIMINAR_PERFILES_TEMPORALES = @"DELETE FROM relation_curriculum_vitae__perfil_laboral WHERE id_legajo < 0";
        private const string INSERTAR = @"INSERT INTO relation_curriculum_vitae__perfil_laboral 
            (id, id_legajo, id_perfil_laboral) VALUES (@id, @id_legajo, @id_perfil_laboral)";
        private const string OBTENER_OBJETO_ID = RELACION +
            @" WHERE relation_curriculum_vitae__perfil_laboral.id = @id";
        private const string OBTENER_OBJETOS = RELACION +
            @" WHERE id_legajo = @id_legajo ORDER BY perfil_laboral ASC";
        private const string OBTENER_VERIFICACION_ELIMINAR = @"SELECT * FROM relation_curriculum_vitae__perfil_laboral WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM relation_curriculum_vitae__perfil_laboral 
            WHERE (id_legajo = @id_legajo AND id_perfil_laboral = @id_perfil_laboral AND id <> @id)"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Métodos
        public string obtenerElementos(long idLegajo)
        {
            int iteracion = 0;
            string cadenaDeElementos = ""; //Crea una variable para almacenar los datos de los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_OBJETOS)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_legajo", idLegajo); //Agrega parámetros al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                if (iteracion == 0) cadenaDeElementos += Convert.ToString(lectorDB["perfil_laboral"]); //Agrega el elemento a la cadena de elementos
                                else cadenaDeElementos += ", " + Convert.ToString(lectorDB["perfil_laboral"]); //Agrega el elemento con una "coma" el la cadena de elementos
                                iteracion++;
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002RELPRF: Hay un conflicto en la consulta de la cadena de perfiles laborales.", e); }
            finally { _conexion.Dispose(); }
            return cadenaDeElementos;
        }

        public List<string> obtenerListaDeElementos(long idLegajo)
        {
            List<string> listaDeElementos = new List<string>(); //Crea una lista de Objetos para almacenar los registros del tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_OBJETOS)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_legajo", idLegajo); //Agrega parámetros al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                listaDeElementos.Add(Convert.ToString(lectorDB["denominacion"])); //Agrega el elemento a la lista de elementos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004RELPRF: Hay un conflicto en la consulta de la lista de perfiles laborales.", e); }
            finally { _conexion.Dispose(); }
            return listaDeElementos;
        }

        public List<Relacion_LegajoCurriculumVitae_PerfilLaboral> obtenerObjetos(long idLegajo)
        {
            List<Relacion_LegajoCurriculumVitae_PerfilLaboral> listaDeObjetos = new List<Relacion_LegajoCurriculumVitae_PerfilLaboral>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_OBJETOS)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_legajo", idLegajo); //Agrega parámetros al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Relacion_LegajoCurriculumVitae_PerfilLaboral objRelacion_LegajoCurriculumVitae_PerfilLaboral = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                listaDeObjetos.Add(objRelacion_LegajoCurriculumVitae_PerfilLaboral); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006RELPRF: Hay un conflicto en la consulta de perfiles laborales.", e); }
            finally { _conexion.Dispose(); }
            return listaDeObjetos;
        }

        public Relacion_LegajoCurriculumVitae_PerfilLaboral obtenerObjeto(long id, bool notificarExito)
        {
            Relacion_LegajoCurriculumVitae_PerfilLaboral objRelacion_LegajoCurriculumVitae_PerfilLaboral = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objRelacion_LegajoCurriculumVitae_PerfilLaboral = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
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
            catch (MySqlException e) { Mensaje.Error("Error-M008RELPRF: Hay un conflicto en la consulta del perfil laboral.", e); }
            finally { _conexion.Dispose(); }
            return objRelacion_LegajoCurriculumVitae_PerfilLaboral;
        }

        public bool asociar_PerfilesTemporales(long idLegajoTemporal, long idLegajoDefinitivo)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ASOCIAR_PERFILES_TEMPORALES)) //Crea un comando de Base de Datos
                    {
                        comandoDB_update.Parameters.AddWithValue("@id_temporal", idLegajoTemporal); //Agrega parámetros al comando de Base de Datos
                        comandoDB_update.Parameters.AddWithValue("@id_definitivo", idLegajoDefinitivo); //Agrega parámetros al comando de Base de Datos
                        comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                        return true;
                    }
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M016PRS", "M018PRS", "M020PRS", "M022PRS", e); }
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
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Perfil Laboral Inexistente.\nEl perfil laboral No se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M010RELPRF", "M012RELPRF", "M014RELPRF", "M016RELPRF", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool eliminar_PerfilesLegajoles(long idLegajo)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB_delete = _conexion.crearComandoDB(ELIMINAR_PERFILES_PERSONALES)) //Crea un comando de Base de Datos
                    {
                        comandoDB_delete.Parameters.AddWithValue("@id_legajo", idLegajo);
                        comandoDB_delete.ExecuteNonQuery(); //Ejecuta el DELETE en la Base de Datos
                        return true;
                    }
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M018RELPRF", "M020RELPRF", "M022RELPRF", "M024RELPRF", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool eliminar_PerfilesTemporales()
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB_delete = _conexion.crearComandoDB(ELIMINAR_PERFILES_TEMPORALES)) //Crea un comando de Base de Datos
                    {
                        comandoDB_delete.ExecuteNonQuery(); //Ejecuta el DELETE en la Base de Datos
                        return true;
                    }
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M026RELPRF", "M028RELPRF", "M030RELPRF", "M032RELPRF", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(Relacion_LegajoCurriculumVitae_PerfilLaboral objRelacion_LegajoCurriculumVitae_PerfilLaboral, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objRelacion_LegajoCurriculumVitae_PerfilLaboral.Id);
                        comandoDB.Parameters.AddWithValue("@id_legajo", objRelacion_LegajoCurriculumVitae_PerfilLaboral.Legajo.Id);
                        comandoDB.Parameters.AddWithValue("@id_perfil_laboral", objRelacion_LegajoCurriculumVitae_PerfilLaboral.PerfilLaboral.Id);
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            //Crea un comando de Base de Datos
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR))
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objRelacion_LegajoCurriculumVitae_PerfilLaboral.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_legajo", objRelacion_LegajoCurriculumVitae_PerfilLaboral.Legajo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_perfil_laboral", objRelacion_LegajoCurriculumVitae_PerfilLaboral.PerfilLaboral.Id);
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
                if (notificarExito) Mensaje.Advertencia("Perfil Laboral Existente.\nEl perfil laboral ya se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M034RELPRF", "M036RELPRF", "M038RELPRF", "M040RELPRF", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private Relacion_LegajoCurriculumVitae_PerfilLaboral instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Relacion_LegajoCurriculumVitae_PerfilLaboral(
                Convert.ToInt64(lectorDB["id"]),
                new D_Legajo().obtenerObjeto("ID", Convert.ToString(lectorDB["id_legajo"]), false),
                new D_PerfilLaboral().obtenerObjeto(Convert.ToInt64(lectorDB["id_perfil_laboral"]), false),
                Convert.ToString(lectorDB["perfil_laboral"]));
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
