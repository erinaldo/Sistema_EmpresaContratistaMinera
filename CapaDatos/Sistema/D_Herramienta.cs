using Biblioteca.Ayudantes;
using MySql.Data.MySqlClient;
using System;
using System.IO;

namespace CapaDatos.Sistema
{
    public class D_Herramienta : IDisposable
    {
        /* Configuración de MySQL SERVER: Dentro del archivo "my.ini" se debe establecer el valor de la variable
         * max_allowed_packet=512M. (Este archivo probablemente está dentro de la carpeta C:/xampp/my.ini)
         */

        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Métodos
        public string crearBackupDB() //Método que genera un backup comprimido de la base de datos
        {
            try
            {
                string directorioBackup = Archivo.ValidarDirectorio(@"Backups\"); //Valida el directorio de trabajo
                string nombreBackup = Path.Combine(directorioBackup, DateTime.Now.ToString(@"E\mpre\min\saDB_backup_yyyy-MM-dd(hhmmss).\sql"));
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB()) //Crea un comando de Base de Datos
                    {
                        using (MySqlBackup comandoSqlBackup = new MySqlBackup(comandoDB)) //Crea un comando de Backup de Base de Datos
                        {
                            using (MemoryStream stream = new MemoryStream())
                            {
                                comandoSqlBackup.ExportToMemoryStream(stream); //Paso 1: Exporta la Base de Datos a un archivo .sql
                                byte[] bufferEncriptado = Encriptacion.Encriptar(stream.ToArray(), "1rE$2Kt3Ly$4Ñb5jS6iX$7ZoA9$k8lT"); //Paso 2: Encripta el contenido de la exportación
                                File.WriteAllBytes(nombreBackup, bufferEncriptado); //Paso 3: Genera y escribe el archivo en la ruta indicada
                                Archivo.ComprimirArchivo(nombreBackup); //Paso 4: Crea una archivo comprimido y almacena en su interior una copia del archivo .sql
                                Archivo.EliminarArchivo(nombreBackup); //Paso 5: Elimina el archivo original .sql 
                                string[] nombreArchivo = nombreBackup.Split('\\');
                                D_Auditoria.RegistrarAuditoria("Herramientas de Sistema", "Generó un backup de base de datos (" + nombreArchivo[nombreArchivo.Length - 1] + ")."); //Registra la generación de un backup de base de datos
                                Mensaje.Informacion("El Backup de la Base de Datos se procesó correctamente.");
                                return nombreBackup + ".empr";
                            }
                        }
                    }
                }
            }
            catch (Exception e) { Mensaje.Error("Error-M002BACKUP: Hay un conflicto en la generación del backup de Base de Datos.", e); }
            return "";
        }

        public void restaurarDB(string archivoBackupComprimido) //Método que restaura la base de datos desde un backup comprimido
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = this._conexion.crearComandoDB()) //Crea un comando de Base de Datos
                    {
                        using (MySqlBackup comandoSqlBackup = new MySqlBackup(comandoDB)) //Crea un comando de Backup de Base de Datos
                        {
                            string archivoBackup = Archivo.DescomprimirArchivo(archivoBackupComprimido); //Paso 1: Descomprime el archivo comprimido y recupera el nombre del archivo original
                            byte[] bufferEncriptado = File.ReadAllBytes(archivoBackup); //Paso 2: Carga en el buffer el contenido del archivo .sql
                            byte[] bufferDesencriptado = Encriptacion.Desencriptar("1rE$2Kt3Ly$4Ñb5jS6iX$7ZoA9$k8lT", bufferEncriptado); //Paso 3: Desencripta el contenido del buffer que se cargó anteriormente
                            Archivo.EliminarArchivo(archivoBackup); //Paso 3: Elimina el archivo original .sql
                            using (MemoryStream stream = new MemoryStream(bufferDesencriptado))
                            {
                                comandoSqlBackup.ImportFromMemoryStream(stream);
                                string[] nombreArchivo = archivoBackup.Split('\\');
                                D_Auditoria.RegistrarAuditoria("Herramientas de sistema", "Restauró la base de datos desde (" + nombreArchivo[nombreArchivo.Length - 1] + ")."); //Registra la restauración de la base de datos
                                Mensaje.Informacion("La restauración de la Base de Datos se procesó correctamente.");
                            }
                        }
                    }
                }
            }
            catch (Exception e) { Mensaje.Error("Error-M004BACKUP: Hay un conflicto en el proceso de restauración de la Base de Datos." , e); }
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
