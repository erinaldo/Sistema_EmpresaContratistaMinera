using Biblioteca.Ayudantes;
using CapaDatos.Sistema;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_Entrevista : IEntrevista, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_entrevista.*, 
            data_legajo.denominacion, data_legajo.documento, data_legajo.cuit, data_legajo.celular1, data_legajo.celular2";
        private const string FROM = @" FROM data_entrevista
            INNER JOIN data_legajo ON data_entrevista.id_legajo = data_legajo.id";
        private const string WHERE1 = @" WHERE data_entrevista.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_entrevista.id_legajo = @id_legajo"; //Filtrar Objeto por ID Legajo
        private const string WHERE3 = @" WHERE data_entrevista.id_legajo = @id_legajo AND data_entrevista.id = (SELECT MAX(data_entrevista.id) FROM data_entrevista WHERE data_entrevista.id_legajo = @id_legajo AND data_entrevista.estado <> 'ANULADO')"; //Filtrar Objeto por ID Legajo (obtiene el registro más reciente y No anulado)
        private const string WHERE4 = @" WHERE data_legajo.cuit = @cuit"; //Filtrar Objeto por CUIL/CUIT
        private const string WHERE5 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE6 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion) AND data_entrevista.estado = @estado"; //Filtrar Objeto por Denominación y Estado
        private const string WHERE7 = @" WHERE date(cita) >= date(@desde) AND date(cita) <= date(@hasta)"; //Filtrar Objeto por Cita
        private const string WHERE8 = @" WHERE date(cita) >= date(@desde) AND date(cita) <= date(@hasta) AND data_entrevista.estado = @estado"; //Filtrar Objeto por Cita y Estado
        private const string ORDER = @" ORDER BY data_entrevista.cita DESC, data_legajo.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_entrevista WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ANULAR = @"SELECT * FROM data_entrevista WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_entrevista WHERE id_legajo = @id_legajo AND estado = 'S/REALIZAR'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_entrevista SET 
            id_legajo = @id_legajo, 
            cita = @cita,
            cita_alertado = @cita_alertado,
            modalidad = @modalidad,
            propuesta = @propuesta,
            analisis = @analisis,
            disponibilidad = @disponibilidad,
            calificacion = @calificacion,
            estado = @estado,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ANULAR = @"UPDATE data_entrevista SET estado = 'ANULADO' WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_entrevista (id, id_legajo, cita, cita_alertado, modalidad,
            propuesta, analisis, disponibilidad, calificacion, estado, edicion_fecha, edicion_usuario_id, edicion_usuario) 
            VALUES (@id, @id_legajo, @cita, @cita_alertado, @modalidad, @propuesta, @analisis, @disponibilidad,
            @calificacion, @estado, @edicion_fecha, @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "CUIT") condicional = WHERE4; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Denominación y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición de la consulta
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
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + Fecha.ConvertirFechaHora(Convert.ToDateTime(lectorDB["cita"])).PadLeft(16, ' ') +
                                            " | " + Convert.ToString(lectorDB["disponibilidad"]).PadRight(5, ' ') +
                                            " | " + Convert.ToString(lectorDB["calificacion"]).PadRight(14, ' ') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(10, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    string celular1 = Convert.ToString(lectorDB["celular1"]).Trim();
                                    string celular2 = Convert.ToString(lectorDB["celular2"]).Trim();
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + (celular1 + ((celular1.Length > 0 && celular2.Length > 0) ? ", " : "") + celular2).PadRight(28, ' ') +
                                            " | " + Fecha.ConvertirFechaHora(Convert.ToDateTime(lectorDB["cita"])).PadLeft(16, ' ') +
                                            " | " + Convert.ToString(lectorDB["disponibilidad"]).PadRight(5, ' ') +
                                            " | " + Convert.ToString(lectorDB["calificacion"]).PadRight(14, ' ') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(10, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002ENTREVISTA: Hay un conflicto en la consulta de entrevistas.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "CITA") condicional = ((estado != "TODOS") ? WHERE8 : WHERE7); //Consulta filtrada por Cita y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega el parámetro en la condición del contador
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición de la consulta
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
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + Fecha.ConvertirFechaHora(Convert.ToDateTime(lectorDB["cita"])).PadLeft(16, ' ') +
                                            " | " + Convert.ToString(lectorDB["disponibilidad"]).PadRight(5, ' ') +
                                            " | " + Convert.ToString(lectorDB["calificacion"]).PadRight(14, ' ') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(10, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    string celular1 = Convert.ToString(lectorDB["celular1"]).Trim();
                                    string celular2 = Convert.ToString(lectorDB["celular2"]).Trim();
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + (celular1 + ((celular1.Length > 0 && celular2.Length > 0) ? ", " : "") + celular2).PadRight(28, ' ') +
                                            " | " + Fecha.ConvertirFechaHora(Convert.ToDateTime(lectorDB["cita"])).PadLeft(16, ' ') +
                                            " | " + Convert.ToString(lectorDB["disponibilidad"]).PadRight(5, ' ') +
                                            " | " + Convert.ToString(lectorDB["calificacion"]).PadRight(14, ' ') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(10, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004ENTREVISTA: Hay un conflicto en la consulta de entrevistas.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<Entrevista> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "CUIT") condicional = WHERE4; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Denominación y/o Estado
            List<Entrevista> ListaDeObjetos = new List<Entrevista>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega un parámetro al filtro
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega un parámetro al filtro
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Entrevista objEntrevista = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objEntrevista); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006ENTREVISTA: Hay un conflicto en la consulta de entrevistas.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<Entrevista> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            string condicional = "";
            if (campo == "CITA") condicional = ((estado != "TODOS") ? WHERE8 : WHERE7); //Consulta filtrada por Cita y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            List<Entrevista> ListaDeObjetos = new List<Entrevista>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro terciario
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro terciario
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Entrevista objEntrevista = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objEntrevista); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008ENTREVISTA: Hay un conflicto en la consulta de entrevistas.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public Entrevista obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            if (campo == "ID_LEGAJO") condicional = WHERE2; //Consulta filtrada por ID Legajo
            if (campo == "ID_LEGAJO_RECIENTE") condicional = WHERE3; //Consulta filtrada por ID Legajo (obtiene el registro más reciente y No anulado)
            if (campo == "CUIT") condicional = WHERE4; //Consulta filtrada por CUIL/CUIT
            Entrevista objEntrevista = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        if (campo == "ID_LEGAJO" || campo == "ID_LEGAJO_RECIENTE") comandoDB.Parameters.AddWithValue("@id_legajo", valor); //Agrega un parámetro al filtro
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objEntrevista = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos de la entrevista e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010ENTREVISTA: Hay un conflicto en la consulta de la entrevista.", e); }
            finally { _conexion.Dispose(); }
            return objEntrevista;
        }

        public bool actualizar(Entrevista objEntrevista)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objEntrevista.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objEntrevista.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_legajo", objEntrevista.Legajo.Id);
                                comandoDB_update.Parameters.AddWithValue("@cita", objEntrevista.Cita);
                                comandoDB_update.Parameters.AddWithValue("@cita_alertado", objEntrevista.CitaAlertado);
                                comandoDB_update.Parameters.AddWithValue("@modalidad", objEntrevista.Modalidad);
                                comandoDB_update.Parameters.AddWithValue("@propuesta", objEntrevista.Propuesta);
                                comandoDB_update.Parameters.AddWithValue("@analisis", objEntrevista.Analisis);
                                comandoDB_update.Parameters.AddWithValue("@disponibilidad", objEntrevista.Disponibilidad);
                                comandoDB_update.Parameters.AddWithValue("@calificacion", objEntrevista.Calificacion);
                                comandoDB_update.Parameters.AddWithValue("@estado", objEntrevista.Estado);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objEntrevista.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objEntrevista.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objEntrevista.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Entrevistas de Trabajo", "Modificó el registro Id:" + objEntrevista.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nLa entrevista ya se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M012ENTREVISTA", "M014ENTREVISTA", "M016ENTREVISTA", "M018ENTREVISTA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool anular(Entrevista objEntrevista)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ANULAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objEntrevista.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ANULAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objEntrevista.Id);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Entrevistas de Trabajo", "Anuló el registro Id:" + objEntrevista.Id + "."); //Registra la eliminación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Anulado.\nLa entrevista ya se encuentra anulada en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M020ENTREVISTA", "M022ENTREVISTA", "M024ENTREVISTA", "M026ENTREVISTA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(Entrevista objEntrevista)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_legajo", objEntrevista.Legajo.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objEntrevista.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_legajo", objEntrevista.Legajo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@cita", objEntrevista.Cita);
                                comandoDB_insert.Parameters.AddWithValue("@cita_alertado", objEntrevista.CitaAlertado);
                                comandoDB_insert.Parameters.AddWithValue("@modalidad", objEntrevista.Modalidad);
                                comandoDB_insert.Parameters.AddWithValue("@propuesta", objEntrevista.Propuesta);
                                comandoDB_insert.Parameters.AddWithValue("@analisis", objEntrevista.Analisis);
                                comandoDB_insert.Parameters.AddWithValue("@disponibilidad", objEntrevista.Disponibilidad);
                                comandoDB_insert.Parameters.AddWithValue("@calificacion", objEntrevista.Calificacion);
                                comandoDB_insert.Parameters.AddWithValue("@estado", objEntrevista.Estado);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objEntrevista.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objEntrevista.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objEntrevista.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Entrevistas de Trabajo", "Agregó un nuevo registro ID:" + objEntrevista.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nLa entrevista ya se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M028ENTREVISTA", "M030ENTREVISTA", "M032ENTREVISTA", "M034ENTREVISTA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private Entrevista instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Entrevista(
                Convert.ToInt64(lectorDB["id"]),
                new D_Legajo().obtenerObjeto("ID", Convert.ToString(lectorDB["id_legajo"]), false),
                Convert.ToDateTime(lectorDB["cita"]),
                Convert.ToBoolean(lectorDB["cita_alertado"]),
                Convert.ToString(lectorDB["modalidad"]),
                Convert.ToString(lectorDB["propuesta"]),
                Convert.ToString(lectorDB["analisis"]),
                Convert.ToString(lectorDB["disponibilidad"]),
                Convert.ToString(lectorDB["calificacion"]),
                Convert.ToString(lectorDB["estado"]),
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