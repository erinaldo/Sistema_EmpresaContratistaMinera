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
    public class D_CapacitacionLaboral : ICapacitacionLaboral, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_capacitacion_laboral.*, 
            data_legajo.denominacion, data_legajo.documento, data_legajo.cuit, data_legajo.baja,
            data_centro_costo.denominacion AS centro_costo";
        private const string FROM = @" FROM data_capacitacion_laboral
            INNER JOIN data_legajo ON data_capacitacion_laboral.id_legajo = data_legajo.id
            LEFT JOIN data_centro_costo ON data_capacitacion_laboral.id_centro_costo = data_centro_costo.id";
        private const string WHERE1 = @" WHERE data_capacitacion_laboral.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_capacitacion_laboral.id_legajo = @id_legajo"; //Filtrar Objeto por ID Legajo
        private const string WHERE3 = @" WHERE data_capacitacion_laboral.id_legajo = @id_legajo AND data_capacitacion_laboral.id = (SELECT MAX(data_capacitacion_laboral.id) FROM data_capacitacion_laboral WHERE data_capacitacion_laboral.id_legajo = @id_legajo AND data_capacitacion_laboral.estado <> 'ANULADO')"; //Filtrar Objeto por ID Legajo (obtiene el registro más reciente y No anulado)
        private const string WHERE4 = @" WHERE data_legajo.cuit = @cuit"; //Filtrar Objeto por CUIL/CUIT
        private const string WHERE5 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE6 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion) AND data_capacitacion_laboral.estado = @estado"; //Filtrar Objeto por Denominación y Estado
        private const string WHERE7 = @" WHERE date(fecha_emision) >= date(@desde) AND date(fecha_emision) <= date(@hasta)"; //Filtrar Objeto por Fecha de Alta
        private const string WHERE8 = @" WHERE date(fecha_emision) >= date(@desde) AND date(fecha_emision) <= date(@hasta) AND data_capacitacion_laboral.estado = @estado"; //Filtrar Objeto por Fecha de Alta y Estado
        private const string ORDER = @" ORDER BY data_capacitacion_laboral.fecha_emision DESC, data_legajo.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_capacitacion_laboral WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ANULAR = @"SELECT * FROM data_capacitacion_laboral WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_capacitacion_laboral WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_capacitacion_laboral SET 
            id = @id,
            id_legajo = @id_legajo,
            id_centro_costo = @id_centro_costo,
            capacitador = @capacitador,
            capacitacion = @capacitacion,
            fecha_emision = @fecha_emision,
            observacion = @observacion,
            estado = @estado,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ANULAR = @"UPDATE data_capacitacion_laboral SET estado = 'ANULADO' WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_capacitacion_laboral (id, id_legajo, id_centro_costo, capacitador,
            capacitacion, fecha_emision, observacion, estado, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @id_legajo, @id_centro_costo, @capacitador, @capacitacion, @fecha_emision, @observacion,
            @estado, @edicion_fecha, @edicion_usuario_id, @edicion_usuario)";
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
                                string bajaLegajo = (Convert.ToBoolean(lectorDB["baja"])) ? " (BAJA)" : "";
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + Convert.ToString(lectorDB["capacitador"]).PadRight(15, ' ') +
                                            " | " + Convert.ToString(lectorDB["capacitacion"]).PadRight(15, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha_emision"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(8, ' '));
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
            catch (MySqlException e) { Mensaje.Error("Error-M002CAPACITACION: Hay un conflicto en la consulta de capacitaciones.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "FECHA") condicional = ((estado != "TODOS") ? WHERE8 : WHERE7); //Consulta filtrada por Fecha de Alta y/o Estado
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
                                string bajaLegajo = (Convert.ToBoolean(lectorDB["baja"])) ? " (BAJA)" : "";
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + Convert.ToString(lectorDB["capacitador"]).PadRight(15, ' ') +
                                            " | " + Convert.ToString(lectorDB["capacitacion"]).PadRight(15, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha_emision"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(8, ' '));
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
            catch (MySqlException e) { Mensaje.Error("Error-M004CAPACITACION: Hay un conflicto en la consulta de capacitaciones.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CapacitacionLaboral> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "CUIT") condicional = WHERE4; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Denominación y/o Estado
            List<CapacitacionLaboral> ListaDeObjetos = new List<CapacitacionLaboral>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                CapacitacionLaboral objCapacitacionLaboral = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objCapacitacionLaboral); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006CAPACITACION: Hay un conflicto en la consulta de capacitaciones.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<CapacitacionLaboral> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            string condicional = "";
            if (campo == "FECHA") condicional = ((estado != "TODOS") ? WHERE8 : WHERE7); //Consulta filtrada por Fecha de Alta y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            List<CapacitacionLaboral> ListaDeObjetos = new List<CapacitacionLaboral>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                CapacitacionLaboral objCapacitacionLaboral = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objCapacitacionLaboral); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008CAPACITACION: Hay un conflicto en la consulta de capacitaciones.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public CapacitacionLaboral obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            if (campo == "ID_LEGAJO") condicional = WHERE2; //Consulta filtrada por ID Legajo
            if (campo == "ID_LEGAJO_RECIENTE") condicional = WHERE3; //Consulta filtrada por ID Legajo (obtiene el registro más reciente y No anulado)
            if (campo == "CUIT") condicional = WHERE4; //Consulta filtrada por CUIL/CUIT
            CapacitacionLaboral objCapacitacionLaboral = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objCapacitacionLaboral = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos de la capacitación e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010CAPACITACION: Hay un conflicto en la consulta de la capacitación.", e); }
            finally { _conexion.Dispose(); }
            return objCapacitacionLaboral;
        }

        public bool actualizar(CapacitacionLaboral objCapacitacionLaboral)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objCapacitacionLaboral.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objCapacitacionLaboral.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_legajo", objCapacitacionLaboral.Legajo.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_centro_costo", objCapacitacionLaboral.CentroCosto.Id);
                                comandoDB_update.Parameters.AddWithValue("@capacitador", objCapacitacionLaboral.Capacitador);
                                comandoDB_update.Parameters.AddWithValue("@capacitacion", objCapacitacionLaboral.Capacitacion);
                                comandoDB_update.Parameters.AddWithValue("@fecha_emision", objCapacitacionLaboral.FechaEmision);
                                comandoDB_update.Parameters.AddWithValue("@observacion", objCapacitacionLaboral.Observacion);
                                comandoDB_update.Parameters.AddWithValue("@estado", objCapacitacionLaboral.Estado);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objCapacitacionLaboral.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objCapacitacionLaboral.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objCapacitacionLaboral.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("CapacitacionLaborales", "Modificó el registro Id:" + objCapacitacionLaboral.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nLa capacitación ya se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M012CAPACITACION", "M014CAPACITACION", "M016CAPACITACION", "M018CAPACITACION", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool anular(CapacitacionLaboral objCapacitacionLaboral)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ANULAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objCapacitacionLaboral.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ANULAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objCapacitacionLaboral.Id);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("CapacitacionLaborales", "Anuló el registro Id:" + objCapacitacionLaboral.Id + "."); //Registra la eliminación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Anulado.\nLa capacitación ya se encuentra anulado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M020CAPACITACION", "M022CAPACITACION", "M024CAPACITACION", "M026CAPACITACION", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(CapacitacionLaboral objCapacitacionLaboral)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objCapacitacionLaboral.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objCapacitacionLaboral.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_legajo", objCapacitacionLaboral.Legajo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_centro_costo", objCapacitacionLaboral.CentroCosto.Id);
                                comandoDB_insert.Parameters.AddWithValue("@capacitador", objCapacitacionLaboral.Capacitador);
                                comandoDB_insert.Parameters.AddWithValue("@capacitacion", objCapacitacionLaboral.Capacitacion);
                                comandoDB_insert.Parameters.AddWithValue("@fecha_emision", objCapacitacionLaboral.FechaEmision);
                                comandoDB_insert.Parameters.AddWithValue("@observacion", objCapacitacionLaboral.Observacion);
                                comandoDB_insert.Parameters.AddWithValue("@estado", objCapacitacionLaboral.Estado);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objCapacitacionLaboral.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objCapacitacionLaboral.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objCapacitacionLaboral.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("CapacitacionLaborales", "Agregó un nuevo registro ID:" + objCapacitacionLaboral.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nLa capacitación ya se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M028CAPACITACION", "M030CAPACITACION", "M032CAPACITACION", "M034CAPACITACION", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private CapacitacionLaboral instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new CapacitacionLaboral(
                Convert.ToInt64(lectorDB["id"]),
                new D_Legajo().obtenerObjeto("ID", Convert.ToString(lectorDB["id_legajo"]), false),
                new D_CentroCosto().obtenerObjeto("ID", Convert.ToString(lectorDB["id_centro_costo"]), false),
                Convert.ToString(lectorDB["capacitador"]),
                Convert.ToString(lectorDB["capacitacion"]),
                Convert.ToDateTime(lectorDB["fecha_emision"]),
                Convert.ToString(lectorDB["observacion"]),
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