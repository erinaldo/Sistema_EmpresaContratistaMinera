using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace Biblioteca.Ayudantes
{
    public static class Actualizacion
    {
        #region Atributos
        private static string _servidorFTP = Global.FtpServidor;
        private static string _usuarioFTP = Global.FtpUsuario;
        private static string _contraseniaFTP = Global.FtpClave;
        private static string _directorio = (Archivo.ValidarDirectorio(@"Update\"));
        private static int _versionFTP = 000000;
        private static int _versionLocal = 000000;
        #endregion

        #region Métodos Controladores de Versiones
        private static bool ActualizarVersion_FTP()
        {
            try
            {
                if (LeerVersion_FTP())
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_servidorFTP + "version.sys"); //Establece la comunicación con el servidor FTP y especifica el archivo a subir
                    request.Method = WebRequestMethods.Ftp.UploadFile; //Establece un comando para subir un archivo
                    request.Credentials = new NetworkCredential(_usuarioFTP, _contraseniaFTP); //Establece las credenciales de acesso del usuario
                    request.UsePassive = true;
                    request.UseBinary = true;
                    request.KeepAlive = true;
                    string nuevaVersion = Convert.ToString(_versionFTP + 1); //Paso 1: Incrementa la versión del archivo FTP del sistema en uno
                    byte[] buffer = new UTF8Encoding().GetBytes(nuevaVersion); //Paso 2: Convierte la nueva versión en un arreglo de tipo byte
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(buffer, 0, buffer.Length); //Paso 3: Escribe la nueva versión FTP del sistema dentro del archvio "version.sys" hospedada en el servidor FTP 
                        requestStream.Flush();
                        return true;
                    }
                }
            }
            catch (WebException e) { Mensaje.Error("Error-A002UPDATE: Imposible acceder al archivo requerido.\nNo se pudo actualizar la versión de la actualización del sistema.\nVerifique su conexión a internet.", e); }
            return false;
        }

        private static bool ActualizarVersion_Local()
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(_directorio + @"Version.sys")) //Crea un archivo que contendrá el código que ejecutará la actualización
                {
                    escritor.Write(Convert.ToString(_versionFTP));
                    escritor.Flush();
                    return true;
                }
            }
            catch (FileNotFoundException e) { Mensaje.Error("Error-A004UPDATE: Imposible acceder al archivo requerido.\nNo se pudo actualizar la versión del sistema.", e); }
            return false;
        }

        private static bool LeerVersion_FTP()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_servidorFTP + "version.sys"); //Establece la comunicación con el servidor FTP y especifica el archivo a descargar
                request.Method = WebRequestMethods.Ftp.DownloadFile; //Establece un comando para descargar un archivo
                request.Credentials = new NetworkCredential(_usuarioFTP, _contraseniaFTP); //Establece las credenciales de acesso del usuario
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse()) //Obtiene la respuesta de la comunicación FTP
                {
                    using (Stream responseStream = response.GetResponseStream()) //Almacena la respuesta de la comunicación FTP dentro de un Stream
                    {
                        StreamReader lectorFTP = new StreamReader(responseStream, Encoding.GetEncoding("utf-8")); //Lee la versión del sistema que hay en el servidor FTP
                        _versionFTP = Formulario.ValidarNumeroEntero(lectorFTP.ReadToEnd()); //Almacena y convierte en entero para posteriormente realizar la comparación 
                    }
                }
                return true;
            }
            catch (WebException e) { Mensaje.Error("Error-A006UPDATE: Imposible acceder al archivo requerido.\nNo se pudo obtener la versión de la actualización del sistema.\nVerifique su conexión a internet.", e); }
            return false;
        }

        private static bool LeerVersion_Local()
        {
            try
            {
                using (StreamReader lectorLocal = new StreamReader(_directorio + "version.sys", Encoding.GetEncoding("utf-8"))) //Lee la versión actual del sistema
                {
                    _versionLocal = Formulario.ValidarNumeroEntero(lectorLocal.ReadToEnd()); //Almacena y convierte en entero para posteriormente realizar la comparación 
                    return true;
                }
            }
            catch (FileNotFoundException e) { Mensaje.Error("Error-A008UPDATE: Imposible acceder al archivo requerido.\nNo se pudo obtener la versión del sistema.", e); }
            return false;
        }
        #endregion

        #region Métodos 
        private static bool CrearArchivoBatch()
        {
            using (StreamWriter escritor = new StreamWriter(_directorio + @"actualizar.bat")) //Crea un archivo que contendrá el código que ejecutará la actualización
            {
                escritor.WriteLine(@"@echo OFF");             
                escritor.WriteLine(@"CLS");
                escritor.WriteLine(@"ECHO **********************************************");
                escritor.WriteLine(@"ECHO SISTEMA DE GESTION ADMINISTRATIVA DE EMPREMISA");
                escritor.WriteLine(@"ECHO **********************************************");
                escritor.WriteLine(@"ECHO Cerrando el sistema...");
                escritor.WriteLine(@"TASKKILL /IM Empreminsa.exe /F");
                escritor.WriteLine(@"CLS");
                escritor.WriteLine(@"ECHO **********************************************");
                escritor.WriteLine(@"ECHO SISTEMA DE GESTION ADMINISTRATIVA DE EMPREMISA");
                escritor.WriteLine(@"ECHO **********************************************");
                escritor.WriteLine(@"ECHO Actualizando el sistema...");
                escritor.WriteLine(@"COPY " + _directorio + @"Debug\*.* " + Archivo.ValidarDirectorio(@"").Substring(0, Archivo.ValidarDirectorio(@"").Length - 1) + @" /Y /V");
                escritor.WriteLine(@"COPY " + _directorio + @"Debug\Plantillas\*.* " + Archivo.ValidarDirectorio(@"Plantillas\").Substring(0, Archivo.ValidarDirectorio(@"Plantillas\").Length - 1) + @" /Y /V");
                escritor.WriteLine(@"RMDIR " + _directorio + @"Debug /S /Q");
                escritor.WriteLine(@"DEL " + _directorio + @"actualizacion.emp /S /Q");
                escritor.WriteLine(@"START " + Archivo.ValidarDirectorio(@"") + @"Empreminsa.exe /WAIT");
                escritor.WriteLine(@"EXIT");
            }
            return true;
        }

        public static void CancelarActualizacion()
        {
            using (StreamWriter escritor = new StreamWriter(_directorio + @"cancelar.bat")) //Crea un archivo que contendrá el código que ejecutará la actualización
            {
                escritor.WriteLine(@"@echo OFF");
                escritor.WriteLine(@"CLS");
                escritor.WriteLine(@"ECHO **********************************************");
                escritor.WriteLine(@"ECHO SISTEMA DE GESTION ADMINISTRATIVA DE EMPREMISA");
                escritor.WriteLine(@"ECHO **********************************************");
                escritor.WriteLine(@"ECHO Cerrando el sistema...");
                escritor.WriteLine(@"TASKKILL /IM Empreminsa.exe /F");
                escritor.WriteLine(@"EXIT");
            }
            CrearArchivoBatch(); //Crea el archivo cancelar.bat que forzará el cierre del Sistema
            Process.Start(_directorio + "cancelar.bat"); //Ejecuta el archivo cancelar.bat
        }

        public static bool CompararActualizacionFTP()
        {
            LeerVersion_Local(); //Paso 1: Obtener la versión local del sistema
            LeerVersion_FTP(); //Paso 2: Obtener la versión FTP del sistema
            if (_versionFTP > _versionLocal) return true; //Compara las versiones y determina si el sistema debe actualizarse
            return false;
        }

        public static bool DescargarActualizacionFTP()
        {
            if (File.Exists(_directorio + "actualizacion.emp")) File.Delete(_directorio + "actualizacion.emp"); //Busca y elimina un archivo obsoleto de actualización 
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_servidorFTP + "actualizacion.emp"); //Establece la comunicación con el servidor FTP y especifica el archivo a descargar
                request.Method = WebRequestMethods.Ftp.DownloadFile; //Establece un comando para descargar un archivo
                request.Credentials = new NetworkCredential(_usuarioFTP, _contraseniaFTP); //Establece las credenciales de acesso del usuario
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse()) //Obtiene la respuesta de la comunicación FTP
                {
                    using (Stream responseStream = response.GetResponseStream()) //Almacena la respuesta de la comunicación FTP dentro de un Stream
                    {
                        using (FileStream archivoLocal = File.Create(_directorio + "actualizacion.emp")) //Crea el archivo donde se guardará el contenido del archivo descargado 
                        {
                            byte[] buffer = new byte[32 * 1024]; //Define el buffer
                            int read;
                            while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0) //Lee el contenido de la respuesta que se aloja en el buffer
                            {
                                archivoLocal.Write(buffer, 0, read); //Escribe los datos descargados en el archivo local
                            }
                            if (File.Exists(_directorio + "actualizacion.emp")) return true; //Verifica si se creo correctamente el archivo local y retorna verdadero
                        }
                    }
                }
            }
            catch (WebException e) { Mensaje.Error("Error-A010UPDATE: Imposible acceder al archivo requerido.\nNo se pudo descargar la actualización del sistema.\nVerifique su conexión a internet.", e); }
            return false;
        }

        public static bool DescomprimirActualizacion()
        {
            Archivo.DescomprimirDirectorio(_directorio + "actualizacion.emp", _directorio); //Paso 1: Descomprime el archivo de la actualización
            if (ActualizarVersion_Local()) return true; //Actualiza la versión local del sistema y retorna verdadero
            return false;
        }

        public static void EjecutarArchivoBatch()
        {
            CrearArchivoBatch(); //Crea el archivo actualizar.bat que copiará los archvios de la actualización
            Process proceso = new Process();
            proceso.StartInfo.FileName = _directorio + "actualizar.bat"; //Establece la ruta y el archivo a ejecutarse
            proceso.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; //Establece que el proceso se ejecute en modo silencioso
            proceso.Start(); //Ejecuta el proceso (actualizar.bat)
        }

        public static bool SubirActualizacionFTP(string rutaSistema, string servidorFTP, string usuarioFTP, string contraseniaFTP)
        {
            _servidorFTP = servidorFTP;
            _usuarioFTP = usuarioFTP;
            _contraseniaFTP = contraseniaFTP;
            if (File.Exists(rutaSistema + "actualizacion.emp")) File.Delete(rutaSistema + "actualizacion.emp"); //Busca y elimina un archivo obsoleto de actualización 
            Archivo.ComprimirDirectorio(rutaSistema, "actualizacion"); //Crea un nuevo archivo de actualización

/*
                FileStream fs = new FileStream(rutaSistema + "actualizacion1.emp", FileMode.Open, FileAccess.Read);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_servidorFTP + "actualizacion.emp"); //Establece la comunicación con el servidor FTP y especifica el archivo a subir
                request.Method = WebRequestMethods.Ftp.UploadFile; //Establece un comando para subir un nuevo archivo ó agregar datos a un archivo existente
                request.Credentials = new NetworkCredential(_usuarioFTP, _contraseniaFTP); //Establece las credenciales de acesso del usuario
                request.UsePassive = true;
                request.KeepAlive = false;
                request.UseBinary = true;
                request.Timeout = -1;
      /*          using (Stream requestStream = request.GetRequestStream())
                {
                    byte[] buffer = new byte[8092];
                    int read = 0;
                    while ((read = fs.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        requestStream.Write(buffer, 0, read);
                        requestStream.Flush();
                    }
                }

            */




            try
            {

                /*       byte[] buffer;
                       byte[] bufferComplementario;
                       int secciones = 0;
                       using (FileStream archivo = File.OpenRead(rutaSistema + "actualizacion1.emp"))
                       {
                           buffer = new byte[archivo.Length];
                           archivo.Read(buffer, 0, buffer.Length);
                           secciones = (int)Math.Ceiling((double)buffer.Length / 5000000);
                           subirSeccion(buffer, 0);
                       }
                       for (int seccionComplementaria = 1; seccionComplementaria < secciones; seccionComplementaria++)
                       {
                           long seccionIndiceInicial = 5000000 * seccionComplementaria;
                           long seccionIndiceFinal = (seccionComplementaria != (secciones - 1)) ? ((5000000 * seccionComplementaria) + 5000000) : buffer.Length;
                           bufferComplementario = new byte[(((seccionIndiceFinal % 5000000) == 0) ? 5000000 : (seccionIndiceFinal % 5000000))];
                           long indicebufferComplementario = 0;
                           for (long indiceBuffer = seccionIndiceInicial; indiceBuffer < seccionIndiceFinal; indiceBuffer++)
                           {
                               bufferComplementario[indicebufferComplementario] = buffer[indiceBuffer];
                               indicebufferComplementario++;
                           }
                           subirSeccion(bufferComplementario, seccionComplementaria);
                       }
                       void subirSeccion(byte[] array, int seccion)
                       {
                           FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_servidorFTP + "actualizacion.emp"); //Establece la comunicación con el servidor FTP y especifica el archivo a subir
                           request.Method = (seccion < 0) ? WebRequestMethods.Ftp.UploadFile : WebRequestMethods.Ftp.AppendFile; //Establece un comando para subir un nuevo archivo ó agregar datos a un archivo existente
                           request.Credentials = new NetworkCredential(_usuarioFTP, _contraseniaFTP); //Establece las credenciales de acesso del usuario
                           request.UsePassive = true;
                           request.KeepAlive = false;
                           request.UseBinary = true;
                           request.Timeout = -1;
                           request.ContentLength = ((array.Length % 5000000 == 0) ? 5000000 : array.Length % 5000000);
                           using (Stream requestStream = request.GetRequestStream())
                           {
                               requestStream.Write(array, 0, ((array.Length % 5000000 == 0) ? 5000000 : array.Length % 5000000)); //Escribe la nueva actualizacion del sistema dentro del archvio "actualizacion.emp" hospedada en el servidor FTP 
                               requestStream.Flush();
                           }
                           FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                           response.Close();
                       }
                       */



                              if (ActualizarVersion_FTP())
                              {
                                  Mensaje.Informacion("Los archivos de actualización se publicaron correctamente."); //Actualiza la versión FTP del sistema
                                  return true;
                              }
            }
            catch (WebException e) { Mensaje.Error("Error-A012UPDATE: Imposible acceder al archivo requerido.\nNo se pudo publicar la actualización del sistema.\nVerifique su conexión a internet.", e); }
            return false;
        }
        #endregion
    }
}
