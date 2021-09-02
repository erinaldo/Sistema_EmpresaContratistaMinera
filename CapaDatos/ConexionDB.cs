using Biblioteca.Ayudantes;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace CapaDatos
{
    public class ConexionDB : IDisposable
    {
        #region Atributos
        private MySqlConnection _conexion;
        private string _cadenaDeConexion;
        #endregion

        #region Constructores
        public ConexionDB()
        {
            try
            {
                _cadenaDeConexion = ConfigurationManager.ConnectionStrings["CNX-Empreminsa_Admin"].ConnectionString; //Consulta la cadena de conexión almacenada en el archivo app.config
                //_cadenaDeConexion = ConfigurationManager.ConnectionStrings["CNX-Empreminsa_Admin_LocalHost"].ConnectionString; //Consulta la cadena de conexión almacenada en el archivo app.config
                //_cadenaDeConexion = ConfigurationManager.ConnectionStrings["CNX-Empreminsa_Debug"].ConnectionString; //Consulta la cadena de conexión almacenada en el archivo app.config
                if (String.IsNullOrWhiteSpace(_cadenaDeConexion)) throw new ArgumentNullException("ConnectionStrings"); //Verifica que la cadena de conexión sea válida
                _conexion = new MySqlConnection(_cadenaDeConexion);
            }
            catch (ArgumentNullException e)
            {
                Mensaje.Error("Error-002CNX: La cadena de conexión es inválida o en su defecto está vacía.", e);
            }
        }
        #endregion

        #region Métodos
        public bool crearConexion() //Método que crea una conexión con el Servidor de bases de datos.
        {
            //Verifica si existe una conexión sin cerrar
            if (_conexion.State == ConnectionState.Open) _conexion.Close();
            try
            {
                _conexion.Open();
                return true;
            }
            catch (MySqlException e)
            {
                Dispose();
                if (e.Number == 1042) Mensaje.Error("Error-004CNX: La conexión con el Servidor ha fallado.", e);
                else Mensaje.Error("Error-006CNX: La conexión con la Base de Datos ha fallado.", e);
                return false;
            }
        }

        public MySqlCommand crearComandoDB() //Método que crea un comando de base de datos.
        {
            using (MySqlCommand comandoDB = new MySqlCommand())
            {
                comandoDB.Connection = _conexion;
                comandoDB.CommandType = CommandType.Text;
                return comandoDB;
            }
        }

        public MySqlCommand crearComandoDB(String sqlQuery) //Método que crea un comando de base de datos para ejecutar Queries.
        {
            using (MySqlCommand comandoDB = new MySqlCommand(sqlQuery, _conexion))
            {
                comandoDB.CommandType = CommandType.Text;
                return comandoDB;
            }
        }

        public static long GenerarNumeroID(string tabla) //Importante: Genera el Id para un registro a insertar 
        {
            ConexionDB conexion = new ConexionDB();
            long nuevoID = 1; //Crea una variable para almacenar el ID
            try
            {
                conexion.crearConexion(); //Crea una conexión con la Base de Datos
                using (MySqlCommand comandoDB = conexion.crearComandoDB(@"SELECT MAX(id) AS id_ultimo FROM " + tabla)) //Crea un comando de Base de Datos en base al campo indicado
                {
                    var respuesta = comandoDB.ExecuteScalar();
                    nuevoID = (respuesta != DBNull.Value) ? (Convert.ToInt64(respuesta) + 1) : 1; //Ejecuta el cálculo del ID máximo para determinar el ultimo ID asignado y lo incrementa en uno
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008CNX: Hay un conflicto en la generación del número ID.", e); }
            finally { conexion.Dispose(); }
            return nuevoID;
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
                if (_conexion.State == System.Data.ConnectionState.Open)
                {
                    _conexion.Close();
                    _conexion.Dispose();
                }
            }
        }
        #endregion
    }
}
