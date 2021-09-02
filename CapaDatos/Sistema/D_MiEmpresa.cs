using Biblioteca.Ayudantes;
using Entidades.Sistema;
using Interfaces.Sistema;
using MySql.Data.MySqlClient;
using System;

namespace CapaDatos.Sistema
{
    public class D_MiEmpresa : IMiEmpresa, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_empresa.*";
        private const string FROM = @" FROM data_empresa";
        private const string WHERE1 = @" WHERE data_empresa.id = @id"; //Filtrar Objeto por ID
        private const string ORDER = @" ORDER BY data_empresa.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_empresa WHERE cuit = @cuit AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_empresa SET 
            id = @id,
            denominacion= @denominacion,
            nombre_fantasia= @nombre_fantasia,
            cuit = @cuit,
            iva = @iva,
            nro_ingresos_brutos = @nro_ingresos_brutos,
            incio_actividad = @incio_actividad,
            domicilio = @domicilio,
            provincia = @provincia,
            distrito = @distrito,
            cp = @cp,
            telefono = @telefono,
            celular = @celular,
            email = @email,
            pagina_web = @pagina_web,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        #endregion

        #region Métodos
        public MiEmpresa obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            MiEmpresa objMiEmpresa = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objMiEmpresa = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos de su empresa e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004EMPRESA: Hay un conflicto en la consulta de su empresa.", e); }
            finally { _conexion.Dispose(); }
            return objMiEmpresa;
        }

        public bool actualizar(MiEmpresa objMiEmpresa, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objMiEmpresa.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cuit", objMiEmpresa.Cuit); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objMiEmpresa.Id);
                                comandoDB_update.Parameters.AddWithValue("@denominacion", objMiEmpresa.Denominacion);
                                comandoDB_update.Parameters.AddWithValue("@nombre_fantasia", objMiEmpresa.NombreFantasia);
                                comandoDB_update.Parameters.AddWithValue("@cuit", objMiEmpresa.Cuit);
                                comandoDB_update.Parameters.AddWithValue("@iva", objMiEmpresa.Iva);
                                comandoDB_update.Parameters.AddWithValue("@nro_ingresos_brutos", objMiEmpresa.NroIngresosBrutos);
                                comandoDB_update.Parameters.AddWithValue("@incio_actividad", objMiEmpresa.InicioDeActividad);
                                comandoDB_update.Parameters.AddWithValue("@domicilio", objMiEmpresa.Domicilio);
                                comandoDB_update.Parameters.AddWithValue("@provincia", objMiEmpresa.Provincia);
                                comandoDB_update.Parameters.AddWithValue("@distrito", objMiEmpresa.Distrito);
                                comandoDB_update.Parameters.AddWithValue("@cp", objMiEmpresa.Cp);
                                comandoDB_update.Parameters.AddWithValue("@telefono", objMiEmpresa.Telefono);
                                comandoDB_update.Parameters.AddWithValue("@celular", objMiEmpresa.Celular);
                                comandoDB_update.Parameters.AddWithValue("@email", objMiEmpresa.Email);
                                comandoDB_update.Parameters.AddWithValue("@pagina_web", objMiEmpresa.PaginaWeb);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objMiEmpresa.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objMiEmpresa.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objMiEmpresa.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Mi MiEmpresa", "Modificó el registro ID:" + objMiEmpresa.Id.ToString() + "."); //Registra la actualización de un registro
                                if (notificarExito) Mensaje.Informacion("Los datos de su empresa " + objMiEmpresa.Denominacion.ToString() + "\nse registraron correctamente.");
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro Existente.\nEl CUIT ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M006EMPRESA", "M008EMPRESA", "M010EMPRESA", "M012EMPRESA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private MiEmpresa instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new MiEmpresa(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToString(lectorDB["nombre_fantasia"]),
                Convert.ToString(lectorDB["cuit"]),
                Convert.ToString(lectorDB["iva"]),
                Convert.ToString(lectorDB["nro_ingresos_brutos"]),
                Convert.ToDateTime(lectorDB["incio_actividad"]),
                Convert.ToString(lectorDB["domicilio"]),
                Convert.ToString(lectorDB["provincia"]),
                Convert.ToString(lectorDB["distrito"]),
                Convert.ToString(lectorDB["cp"]),
                Convert.ToString(lectorDB["telefono"]),
                Convert.ToString(lectorDB["celular"]),
                Convert.ToString(lectorDB["email"]),
                Convert.ToString(lectorDB["pagina_web"]),
                Convert.ToDateTime(lectorDB["edicion_fecha"]),
                Convert.ToInt32(lectorDB["edicion_usuario_id"]),
                Convert.ToString(lectorDB["edicion_usuario"]));
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
