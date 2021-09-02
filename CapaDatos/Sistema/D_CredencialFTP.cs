using Biblioteca.Ayudantes;
using Entidades.Sistema;
using Interfaces.Sistema;
using MySql.Data.MySqlClient;
using System;

namespace CapaDatos.Sistema
{
    public class D_CredencialFTP : ICredencialFTP, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT sys_credencial_ftp.*";
        private const string FROM = @" FROM sys_credencial_ftp";
        private const string WHERE = @" WHERE sys_credencial_ftp.id = @id"; //Filtrar Objeto por ID
        #endregion

        #region Métodos
        public CredencialFTP obtenerObjeto(string campo, string valor)
        {
            CredencialFTP objCredencialFTP = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objCredencialFTP = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos de su credencial FTP e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002CREDENCIAL_FTP: Hay un conflicto en la consulta de su credencial FTP.", e); }
            finally { _conexion.Dispose(); }
            return objCredencialFTP;
        }
        #endregion

        #region Métodos de Instanciación
        private CredencialFTP instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new CredencialFTP(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToString(lectorDB["ftp_servidor"]),
                Convert.ToString(lectorDB["ftp_usuario"]),
                Convert.ToString(lectorDB["ftp_clave"]));
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
