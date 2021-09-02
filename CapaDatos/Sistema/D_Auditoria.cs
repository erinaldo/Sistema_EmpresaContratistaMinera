using Biblioteca.Ayudantes;
using Entidades.Catalogo;
using Entidades.Sistema;
using Interfaces.Sistema;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos.Sistema
{
    public class D_Auditoria : IAuditoria, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT1 = @"SELECT sys_auditoria.id, fecha, modulo, denominacion";
        private const string SELECT2 = @"SELECT sys_auditoria.*";
        private const string FROM = @" FROM sys_auditoria";
        private const string WHERE1 = @" WHERE id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE LOWER(denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE3 = @" WHERE LOWER(denominacion) LIKE LOWER(@denominacion)
            AND modulo = @modulo"; //Filtrar Objeto por Denominación y Módulo
        private const string WHERE4 = @" WHERE documento = @documento"; //Filtrar Objeto por Documento
        private const string WHERE5 = @" WHERE documento = @documento AND modulo = @modulo"; //Filtrar Objeto por Documento y Módulo
        private const string WHERE6 = @" WHERE date(fecha) >= date(@desde) AND date(fecha) <= date(@hasta)"; //Filtrar Objeto por Fecha
        private const string WHERE7 = @" WHERE date(fecha) >= date(@desde) AND date(fecha) <= date(@hasta)
            AND modulo = @modulo"; //Filtrar Objeto por Fecha y Módulo
        private const string ORDER = @" ORDER BY sys_auditoria.fecha DESC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM sys_auditoria WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string INSERTAR = @"INSERT INTO sys_auditoria (id, documento, fecha, modulo, denominacion) 
            VALUES(@id, @documento, @fecha, @modulo, @denominacion)";
        #endregion

        #region Métodos
        public List<string> obtenerListaDeModulo()
        {
            List<string> listaDeElementos = new List<string>(); //Crea una lista de Objetos para almacenar los registros del tabla
            try
            {
                int iteracion = 0;
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT DISTINCT modulo FROM sys_auditoria")) //Crea un comando de Base de Datos
                    {
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                if (iteracion == 0) listaDeElementos.Add(Convert.ToString(lectorDB["modulo"])); //Agrega el elemento a la lista de elementos
                                else listaDeElementos.Add(" ," + Convert.ToString(lectorDB["modulo"])); //Agrega el elemento a la lista de elementos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004AUDITORIA: Hay un conflicto en la consulta de la lista de módulos del sistema.", e); }
            finally { _conexion.Dispose(); }
            return listaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string modulo, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "DENOMINACION") condicional = (modulo != "TODOS") ? WHERE3 : WHERE2; //Consulta filtrada por Denominación y/o Módulo
            if (campo == "DOCUMENTO") condicional = (modulo != "TODOS") ? WHERE5 : WHERE4; //Consulta filtrada por Documento y/o Módulo
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "DOCUMENTO") comandoDB.Parameters.AddWithValue("@documento", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        if (modulo != "TODOS") comandoDB.Parameters.AddWithValue("@modulo", modulo); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DOCUMENTO") comandoDB.Parameters.AddWithValue("@documento", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        if (modulo != "TODOS") comandoDB.Parameters.AddWithValue("@modulo", modulo); //Agrega el parámetro en la condición de la consulta
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
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["modulo"]).PadRight(32, ' ') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(80, ' '));
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
            catch (MySqlException e) { Mensaje.Error("Error-M006AUDITORIA: Hay un conflicto en la consulta de auditorías.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string modulo, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "FECHA") condicional = (modulo != "TODOS") ? WHERE7 : WHERE6; //Consulta filtrada por fecha y/o Módulo
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega el parámetro en la condición del contador
                        if (modulo != "TODOS") comandoDB.Parameters.AddWithValue("@modulo", modulo); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        if (modulo != "TODOS") comandoDB.Parameters.AddWithValue("@modulo", modulo); //Agrega un parámetro al filtro
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
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["modulo"]).PadRight(32, ' ') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(80, ' '));
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
            catch (MySqlException e) { Mensaje.Error("Error-M008AUDITORIA: Hay un conflicto en la consulta de auditorías.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<Auditoria> obtenerObjetos(string modulo, string campo, string valor)
        {
            string condicional = "";
            if (campo == "DENOMINACION") condicional = (modulo != "TODOS") ? WHERE4 : WHERE3; //Consulta filtrada por Denominación y/o Módulo
            if (campo == "DOCUMENTO") condicional = (modulo != "TODOS") ? WHERE5 : WHERE4; //Consulta filtrada por Documento y/o Módulo
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            List<Auditoria> ListaDeObjetos = new List<Auditoria>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT2 + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "DOCUMENTO") comandoDB.Parameters.AddWithValue("@documento", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        if (modulo != "TODOS") comandoDB.Parameters.AddWithValue("@modulo", modulo); //Agrega el parámetro en la condición del contador
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Auditoria objAuditoria = instanciarParcialmente(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objAuditoria); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010AUDITORIA: Hay un conflicto en la consulta de auditorías.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<Auditoria> obtenerObjetos(string modulo, string campo, DateTime desde, DateTime hasta)
        {
            string condicional = "";
            if (campo == "FECHA") condicional = (modulo != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por fecha y/o Módulo
            List<Auditoria> ListaDeObjetos = new List<Auditoria>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (modulo != "TODOS") comandoDB.Parameters.AddWithValue("@modulo", modulo); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro terciario
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro terciario
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Auditoria objAuditoria = instanciarParcialmente(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objAuditoria); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M012AUDITORIA: Hay un conflicto en la consulta de auditorías.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public Auditoria obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            Auditoria objAuditoria = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT2 + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objAuditoria = instanciarCompletamente(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Auditoría solicitada No hallada.\nVerifique los datos de la auditoría e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M014AUDITORIA: Hay un conflicto en la consulta de la auditoría.", e); }
            finally { _conexion.Dispose(); }
            return objAuditoria;
        }

        public bool insertar(Auditoria objAuditoria)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objAuditoria.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objAuditoria.Id);
                                comandoDB_insert.Parameters.AddWithValue("@documento", objAuditoria.Documento);
                                comandoDB_insert.Parameters.AddWithValue("@fecha", objAuditoria.Fecha);
                                comandoDB_insert.Parameters.AddWithValue("@modulo", objAuditoria.Modulo);
                                comandoDB_insert.Parameters.AddWithValue("@denominacion", objAuditoria.Denominacion);
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
                Mensaje.Advertencia("Auditoría Existente.\nLa auditoría ya se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M016AUDITORIA", "M018AUDITORIA", "M020AUDITORIA", "M022AUDITORIA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public static void RegistrarAuditoria(string modulo, string denominacion) //Metodo que registra las operaciones del usuario
        {
            D_Auditoria dAuditoria = new D_Auditoria();
            dAuditoria.insertar(new Auditoria(
                ConexionDB.GenerarNumeroID("sys_auditoria"),
                Global.UsuarioActivo_Documento,
                Fecha.DTSistemaFecha(),
                modulo,
                denominacion));
        }
        #endregion

        #region Métodos de Instanciación
        private Auditoria instanciarCompletamente(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Auditoria(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToString(lectorDB["documento"]),
                Convert.ToDateTime(lectorDB["fecha"]),
                Convert.ToString(lectorDB["modulo"]),
                Convert.ToString(lectorDB["denominacion"]));
        }

        private Auditoria instanciarParcialmente(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Auditoria(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToDateTime(lectorDB["fecha"]),
                Convert.ToString(lectorDB["modulo"]),
                Convert.ToString(lectorDB["denominacion"]));
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
