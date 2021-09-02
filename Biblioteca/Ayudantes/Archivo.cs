using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;

namespace Biblioteca.Ayudantes
{
    public static class Archivo
    {
        #region Métodos
        public static string DescomprimirArchivo(string rutaArchivo)
        {
            FileInfo archivo = new FileInfo(rutaArchivo); //Crea un Objeto de tipo FileInfo para almacenar el archivo que se desea descomprimir
            string denominacionOriginal = "";
            try
            {
                denominacionOriginal = (archivo.FullName).Remove(archivo.FullName.Length - archivo.Extension.Length); //Deduce el nombre orginal del archivo comprimido
                using (FileStream archivoComprimido = archivo.OpenRead()) //Abre y lee el archivo comprimido
                {
                    using (FileStream archivoFinal = File.Create(denominacionOriginal)) //Crea un archivo donde se almacenará el resultado final de la descompresión
                    { 
                        /*Importante: GZipStream debe declararse dentro de una instrucción "using" para lograr su correcto
                        * funcionamiento. Caso contrario generará un archivo inaccesible a causa de su mala descompresión. 
                        * La instrucción "using" en este caso es obligatoria.
                        */
                        using (GZipStream descompresion = new GZipStream(archivoComprimido, CompressionMode.Decompress)) //Convierte el archivo final en un archivo de tipo comprimible
                        {
                            descompresion.CopyTo(archivoFinal); //Copia el contenido del archivo comprimido y automáticamente se genera la descompresión
                        }
                    }
                }
            }
            catch (FileNotFoundException e) { Mensaje.Error("Error-A002ARCHIVO: Hay un conflicto al intentar descomprimir el archivo " + archivo.Name, e); }
            return denominacionOriginal;
        }

        public static bool DescomprimirDirectorio(string rutaArchivo, string rutaDestino)
        {
            FileInfo archivo = new FileInfo(rutaArchivo); //Crea un Objeto de tipo FileInfo para almacenar el archivo que se desea descomprimir
            string nombreDeDescompresion = Directory.GetCurrentDirectory().Split('\\')[Directory.GetCurrentDirectory().Split('\\').Length-1]; //Determina el nombre de la carpeta de descompresión
            if (Directory.Exists(rutaDestino + nombreDeDescompresion)) Directory.Delete(rutaDestino + nombreDeDescompresion, true); //Elimina el directorio de descompresión
            try
            {
                ZipFile.ExtractToDirectory(rutaArchivo, rutaDestino);
                return true;
            }
            catch (FileNotFoundException e) { Mensaje.Error("Error-A004ARCHIVO: Hay un conflicto al intentar descomprimir el archivo " + archivo.Name, e); }
            return false;
        }

        public static string GuardarArchivo(string filtro, string denominacion) //Método que obtiene el directorio de trabajo
        {
            Stream stream = null;
            SaveFileDialog explorador = new SaveFileDialog();
            if (filtro == "SQL") explorador.Filter = "SQL Archivos (*.sql)|*.sql|Todos los Archivos (*.*)|*.*";
            if (filtro == "BACKUP") explorador.Filter = "BACKUP Archivos (*.empr)|*.empr";
            if (filtro == "TEXTO") explorador.Filter = "TXT Archivos (*.txt)|*.txt|Todos los Archivos (*.*)|*.*";
            if (filtro == "XLSX") explorador.Filter = "XLSX Archivos (*.xlsx)|*.xlsx";
            explorador.FileName = denominacion;
            explorador.FilterIndex = 1;
            explorador.RestoreDirectory = true;
            if (explorador.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = explorador.OpenFile()) != null)
                    {
                        using (stream)
                        {
                            return explorador.FileName;
                        }
                    }
                }
                catch (Exception e)
                {
                    Mensaje.Error("Error-A008ARCHIVO: Hay un conflicto en la ruta destino del archivo.", e);
                }
            }
            return "";
        }

        public static string LeerTXT(string directorio, string archivo) //Método que abre y leé el contenido de un archivo txt
        {
            string lectura = "";
            try
            {
                using (StreamReader lector = new StreamReader(directorio + archivo))
                {
                    lectura = lector.ReadToEnd();
                }
            }
            catch (Exception e) { Mensaje.Error("Error-A006ARCHIVO: Hay un conflicto en la lectura del archivo " + archivo, e); }
            return lectura;
        }

        public static string ObtenerArchivo(string directorio, string filtro) //Método que obtiene el directorio de trabajo
        {
            Stream stream = null;
            OpenFileDialog explorador = new OpenFileDialog();
            // ------ Parámentros del explorador de archivos ------ //
            explorador.InitialDirectory = ValidarDirectorio(directorio);
            if (filtro == "SQL") explorador.Filter = "SQL Archivos (*.sql)|*.sql|Todos los Archivos (*.*)|*.*";
            if (filtro == "BACKUP") explorador.Filter = "BACKUP Archivos (*.empr)|*.empr";
            if (filtro == "TEXTO") explorador.Filter = "TXT Archivos (*.txt)|*.txt|Todos los Archivos (*.*)|*.*";
            if (filtro == "XLSX") explorador.Filter = "XLSX Archivos (*.xlsx)|*.xlsx";
            explorador.FilterIndex = 1;
            explorador.RestoreDirectory = true;
            if (explorador.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = explorador.OpenFile()) != null)
                    {
                        using (stream)
                        {
                            return explorador.FileName;
                        }
                    }
                }
                catch (Exception e)
                {
                    Mensaje.Error("Error-A008ARCHIVO: Hay un conflicto en la lectura del archivo.", e);
                }
            }
            return "";
        }

        public static string ValidarDirectorio(string subDirectorio) //Método que valida la existencia del directorio de trabajo
        {
            string directorioDeTrabajo = Global.RutaDeTrabajo + subDirectorio; //Directorio de trabajo.
            try
            {
                //Verifica la existencia del directorio de trabajo
                if (!Directory.Exists(directorioDeTrabajo)) Directory.CreateDirectory(directorioDeTrabajo); //Crea el directorio de trabajo si no existiese
                directorioDeTrabajo = Path.GetFullPath(directorioDeTrabajo);
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A010ARCHIVO: Hay un conflicto en la validación de directorio de trabajo.", e);
            }
            return directorioDeTrabajo;
        }

        public static bool ComprimirArchivo(string rutaArchivo)
        {
            FileInfo archivo = new FileInfo(rutaArchivo); //Crea un Objeto de tipo FileInfo para almacenar el archivo que se desea comprimir
            using (FileStream archivoOriginal = archivo.OpenRead()) //Abre y lee el archivo que se desea comprimir
            {
                using (FileStream archivoFinal = File.Create(archivo.FullName + ".empr")) //Crea un archivo donde se almacenará el resultado final de la compresión (Extensión personalizada .empr)
                {
                    /*Importante: GZipStream debe declararse dentro de una instrucción "using" para lograr su correcto
                    * funcionamiento. Caso contrario generará un archivo inaccesible a causa de su mala compresión. 
                    * La instrucción "using" en este caso es obligatoria.
                    */
                    using (GZipStream compresion = new GZipStream(archivoFinal, CompressionMode.Compress)) //Convierte el archivo final en un archivo de tipo comprimible
                    {
                        archivoOriginal.CopyTo(compresion); //Copia el archivo de origen dentro del archivo final y automáticamente se genera la compresión
                    }
                    if (File.Exists(rutaArchivo + ".empr")) return true; //Verifica si se creo correctamente el archivo local     
                }
            }
            return false;
        }

        public static bool ComprimirDirectorio(string rutaDirectorio, string nombreComprimido)
        {
            string destinoTemporal = Directory.GetDirectoryRoot(rutaDirectorio) + nombreComprimido + ".emp"; //Asigna un destino temporal y designa el nombre del archivo de compresión
            EliminarArchivo(destinoTemporal); //Busca y elimina un archivo temporal de compresión que se creó anteriormente
            ZipFile.CreateFromDirectory(rutaDirectorio, destinoTemporal, CompressionLevel.Optimal, true); //Comprime el directorio indicado
            if (File.Exists(destinoTemporal)) //Verifica si se ha creado correctamente la compresión
            {
                File.Copy(destinoTemporal, (rutaDirectorio + nombreComprimido + ".emp"), true); //Copia y/o sobrescribe el archivo temporal de compresión a su destino final
                EliminarArchivo(destinoTemporal); //Finalmente elimina el archivo temporal de compresión
                return true;
            }
            return false;
        }

        public static bool EliminarArchivo(string rutaArchivo)
        {
            if (File.Exists(rutaArchivo)) File.Delete(rutaArchivo); //Elimina el archivo indicado
            if (File.Exists(rutaArchivo)) return true; //Verifica que el archivo indicado se ha eliminado correctamente
            return false;
        }

        public static bool EliminarArchivos(string rutaDirectorio)
        {
            bool resultado = false;
            if (Directory.Exists(rutaDirectorio))
            {
                foreach (string archivo in Directory.GetFiles(rutaDirectorio)) //Recorre y obtiene todos los archivos del directorio indicado
                {
                    if (File.Exists(archivo)) File.Delete(archivo); //Elimina el archivo indicado
                    if (File.Exists(archivo)) return true; //Verifica que el archivo indicado se ha eliminado correctamente
                    resultado = true;
                }
            }
            return resultado;
        }

        public static void EliminarArchivosTemporales() //Método que elimina los archivos temporales con 2 o más días de su creación
        {
            DateTime fechaDeHoy = DateTime.Now.AddDays(-2);
            string[] directorios = new string[] { @"Temp\", @"Temp\Docx\", @"Temp\PDF\", @"Temp\Xlsx\" };
            foreach (string directorio in directorios)
            {
                foreach (string archivo in Directory.GetFiles(Archivo.ValidarDirectorio(directorio)))
                {
                    FileInfo fechaDeCreacion = new FileInfo(archivo);
                    if (Convert.ToDateTime(fechaDeCreacion.CreationTime) <= fechaDeHoy) fechaDeCreacion.Delete();
                }
            }
        }

        public static void EscribirTXT(string directorio, string archivo, string texto) //Método que crea o abre y escribe dentro de un archivo txt
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(File.Open(ValidarDirectorio(directorio) + archivo, FileMode.Append)))
                {
                    escritor.WriteLine(texto, Encoding.UTF8);
                }
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A012ARCHIVO: Hay un conflicto en la escritura del archivo " + archivo, e);
            }
        }

        public static void EscribirTXT(string ruta, string texto) //Método que crea o abre y escribe dentro de un archivo txt
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(File.Open(ruta, FileMode.Append)))
                {
                    escritor.WriteLine(texto, Encoding.UTF8);
                }
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A014ARCHIVO: Hay un conflicto en la escritura del archivo txt", e);
            }
        }

        public static void SobreEscribirTXT(string directorio, string archivo, string texto) //Método que crea o abre y escribe dentro de un archivo txt
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(File.Open(ValidarDirectorio(directorio) + archivo, FileMode.Create)))
                {
                    escritor.WriteLine(texto, Encoding.UTF8);
                }
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A016ARCHIVO: Hay un conflicto en la escritura del archivo " + archivo, e);
            }
        }

        public static void SobreEscribirTXT(string ruta, string texto) //Método que crea o abre y escribe dentro de un archivo txt
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(File.Open(ruta, FileMode.Create)))
                {
                    escritor.WriteLine(texto, Encoding.UTF8);
               }
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A018ARCHIVO: Hay un conflicto en la escritura del archivo txt", e);
            }
        }

        public static void VaciarContenidoTXT(string ruta) //Método que crea o abre y escribe dentro de un archivo txt
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(File.Open(ruta, FileMode.Create)))
                {
                    escritor.Flush();
                }
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A018ARCHIVO: Hay un conflicto en la escritura del archivo txt", e);
            }
        }
        #endregion
    }
}
