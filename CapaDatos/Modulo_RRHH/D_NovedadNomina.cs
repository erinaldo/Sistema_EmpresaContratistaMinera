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
    public class D_NovedadNomina : INovedadNomina, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_novedad_nomina.*, 
            data_legajo.denominacion, data_legajo.documento, data_legajo.cuit, data_legajo.baja";
        private const string FROM = @" FROM data_novedad_nomina
            INNER JOIN data_legajo ON data_novedad_nomina.id_legajo = data_legajo.id";
        private const string WHERE1 = @" WHERE data_novedad_nomina.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_novedad_nomina.id_legajo = @id_legajo"; //Filtrar Objeto por ID Legajo
        private const string WHERE3 = @" WHERE data_novedad_nomina.id_legajo = @id_legajo AND data_novedad_nomina.id = (SELECT MAX(data_novedad_nomina.id) FROM data_novedad_nomina WHERE data_novedad_nomina.id_legajo = @id_legajo AND data_novedad_nomina.estado <> 'ANULADO')"; //Filtrar Objeto por ID Legajo (obtiene el registro más reciente y No anulado)
        private const string WHERE4 = @" WHERE data_legajo.cuit = @cuit"; //Filtrar Objeto por CUIL/CUIT
        private const string WHERE5 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE6 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion) AND data_novedad_nomina.estado = @estado"; //Filtrar Objeto por Denominación y Estado
        private const string WHERE7 = @" WHERE periodo = @periodo"; //Filtrar Objeto por Periodo
        private const string WHERE8 = @" WHERE periodo = @periodo AND data_novedad_nomina.estado = @estado"; //Filtrar Objeto por Periodo y Estado
        private const string WHERE9 = @" WHERE date(fecha_emision) >= date(@desde) AND date(fecha_emision) <= date(@hasta)"; //Filtrar Objeto por Fecha de Emisión
        private const string WHERE10 = @" WHERE date(fecha_emision) >= date(@desde) AND date(fecha_emision) <= date(@hasta) AND data_novedad_nomina.estado = @estado"; //Filtrar Objeto por Fecha de Emisión y Estado
        private const string ORDER = @" ORDER BY data_novedad_nomina.fecha_emision DESC, data_legajo.denominacion ASC, data_novedad_nomina.novedad_tipo ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_novedad_nomina WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ANULAR = @"SELECT * FROM data_novedad_nomina WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_novedad_nomina WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_LIQUIDAR = @"SELECT * FROM data_novedad_nomina WHERE periodo = @periodo AND estado = 'S/LIQUIDAR'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_novedad_nomina SET 
            id = @id,
            fecha_emision = @fecha_emision,
            periodo = @periodo,
            estado = @estado,
            id_legajo = @id_legajo,
            id_centro_costo = @id_centro_costo,
            novedad_tipo = @novedad_tipo,
            unidad_inicializacion = @unidad_inicializacion,
            unidad_finalizacion = @unidad_finalizacion,
            unidad_horas = @unidad_horas,
            unidad_dias = @unidad_dias,
            unidad_monto = @unidad_monto,
            observacion = @observacion,
            edicion_fecha = @edicion_fecha, 
            edicion_usuario_id = @edicion_usuario_id, 
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ANULAR = @"UPDATE data_novedad_nomina SET estado = 'ANULADO' WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_novedad_nomina (id, fecha_emision, periodo, estado, 
            id_legajo, id_centro_costo, novedad_tipo, unidad_inicializacion, unidad_finalizacion, unidad_horas,
            unidad_dias, unidad_monto, observacion, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @fecha_emision, @periodo, @estado, @id_legajo, @id_centro_costo, @novedad_tipo,
            @unidad_inicializacion, @unidad_finalizacion, @unidad_horas, @unidad_dias, @unidad_monto,
            @observacion, @edicion_fecha, @edicion_usuario_id, @edicion_usuario)";
        private const string LIQUIDAR = @"UPDATE data_novedad_nomina SET estado = 'LIQUIDADO' WHERE periodo = @periodo AND estado = 'S/LIQUIDAR'";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "CUIT") condicional = WHERE4; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Denominación y/o Estado
            if (campo == "PERIODO") condicional = ((estado != "TODOS") ? WHERE8 : WHERE7); //Consulta filtrada por Periodo y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "PERIODO") comandoDB.Parameters.AddWithValue("@periodo", valor); //Agrega el parámetro en la condición del contador
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "PERIODO") comandoDB.Parameters.AddWithValue("@periodo", valor); //Agrega el parámetro en la condición de la consulta
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
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha_emision"])).PadRight(10, ' ') +
                                            " | " + Convert.ToString(lectorDB["periodo"]).PadLeft(7, '0') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(10, ' ') +
                                            " | " + Convert.ToString(lectorDB["novedad_tipo"]).PadRight(35, ' ') +
                                            " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    string fechaInicializacion = Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["unidad_inicializacion"]));
                                    string fechaFinalizacion = Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["unidad_finalizacion"]));
                                    CatalogoBase elemento = new CatalogoBase(
                                       Convert.ToInt64(lectorDB["id"]),
                                       Convert.ToString(lectorDB["periodo"]).Replace("-", "~").PadLeft(7, ' ') +
                                           " | " + Convert.ToString(lectorDB["estado"]).PadRight(10, ' ') +
                                           " | " + Convert.ToString(lectorDB["novedad_tipo"]).PadRight(35, ' ') +
                                           " | " + ((fechaInicializacion != "01/01/9950") ? fechaInicializacion : "").PadRight(10, ' ') +
                                           " | " + ((fechaFinalizacion != "01/01/9950") ? fechaFinalizacion : "").PadRight(10, ' ') +
                                           " | " + Convert.ToString(lectorDB["unidad_horas"]).PadRight(3, ' ') +
                                           " | " + Convert.ToString(lectorDB["unidad_dias"]).PadRight(3, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["unidad_monto"])).PadRight(11, ' ') +
                                           " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002NOVEDAD_NOMINA: Hay un conflicto en la consulta de novedades.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "FECHA") condicional = ((estado != "TODOS") ? WHERE10 : WHERE9); //Consulta filtrada por Fecha de Emisión y/o Estado
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
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha_emision"])).PadRight(10, ' ') +
                                            " | " + Convert.ToString(lectorDB["periodo"]).PadLeft(7, '0') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(10, ' ') +
                                            " | " + Convert.ToString(lectorDB["novedad_tipo"]).PadRight(35, ' ') +
                                            " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    string fechaInicializacion = Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["unidad_inicializacion"]));
                                    string fechaFinalizacion = Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["unidad_finalizacion"]));
                                    CatalogoBase elemento = new CatalogoBase(
                                       Convert.ToInt64(lectorDB["id"]),
                                       Convert.ToString(lectorDB["periodo"]).Replace("-", "~").PadLeft(7, ' ') +
                                           " | " + Convert.ToString(lectorDB["estado"]).PadRight(10, ' ') +
                                           " | " + Convert.ToString(lectorDB["novedad_tipo"]).PadRight(35, ' ') +
                                           " | " + ((fechaInicializacion != "01/01/9950") ? fechaInicializacion : "").PadRight(10, ' ') +
                                           " | " + ((fechaFinalizacion != "01/01/9950") ? fechaFinalizacion : "").PadRight(10, ' ') +
                                           " | " + Convert.ToString(lectorDB["unidad_horas"]).PadRight(3, ' ') +
                                           " | " + Convert.ToString(lectorDB["unidad_dias"]).PadRight(3, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["unidad_monto"])).PadRight(11, ' ') +
                                           " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004NOVEDAD_NOMINA: Hay un conflicto en la consulta de novedades", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<NovedadNomina> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "CUIT") condicional = WHERE4; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Denominación y/o Estado
            if (campo == "PERIODO") condicional = ((estado != "TODOS") ? WHERE8 : WHERE7); //Consulta filtrada por Periodo y/o Estado
            List<NovedadNomina> ListaDeObjetos = new List<NovedadNomina>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega un parámetro al filtro
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega un parámetro al filtro
                        if (campo == "PERIODO") comandoDB.Parameters.AddWithValue("@periodo", valor); //Agrega el parámetro en la condición de la consulta
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                NovedadNomina objNovedadNomina = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objNovedadNomina); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006NOVEDAD_NOMINA: Hay un conflicto en la consulta de novedades.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<NovedadNomina> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            string condicional = "";
            if (campo == "FECHA") condicional = ((estado != "TODOS") ? WHERE10 : WHERE9); //Consulta filtrada por Fecha de Emisión y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            List<NovedadNomina> ListaDeObjetos = new List<NovedadNomina>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                NovedadNomina objNovedadNomina = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objNovedadNomina); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008NOVEDAD_NOMINA: Hay un conflicto en la consulta de novedades", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public NovedadNomina obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            if (campo == "ID_LEGAJO") condicional = WHERE2; //Consulta filtrada por ID Legajo
            if (campo == "ID_LEGAJO_RECIENTE") condicional = WHERE3; //Consulta filtrada por ID Legajo (obtiene el registro más reciente y No anulado)
            if (campo == "CUIT") condicional = WHERE4; //Consulta filtrada por CUIL/CUIT
            NovedadNomina objNovedadNomina = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objNovedadNomina = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos de la novedad e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010NOVEDAD_NOMINA: Hay un conflicto en la consulta de la novedad.", e); }
            finally { _conexion.Dispose(); }
            return objNovedadNomina;
        }

        public bool actualizar(NovedadNomina objNovedadNomina)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objNovedadNomina.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objNovedadNomina.Id);
                                comandoDB_update.Parameters.AddWithValue("@fecha_emision", objNovedadNomina.FechaEmision);
                                comandoDB_update.Parameters.AddWithValue("@periodo", objNovedadNomina.Periodo);
                                comandoDB_update.Parameters.AddWithValue("@estado", objNovedadNomina.Estado);
                                comandoDB_update.Parameters.AddWithValue("@id_legajo", objNovedadNomina.Legajo.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_centro_costo", objNovedadNomina.CentroCosto.Id);
                                comandoDB_update.Parameters.AddWithValue("@novedad_tipo", objNovedadNomina.NovedadTipo);
                                comandoDB_update.Parameters.AddWithValue("@unidad_inicializacion", objNovedadNomina.Unidad_inicializacion);
                                comandoDB_update.Parameters.AddWithValue("@unidad_finalizacion", objNovedadNomina.Unidad_finalizacion);
                                comandoDB_update.Parameters.AddWithValue("@unidad_horas", objNovedadNomina.UnidadHoras);
                                comandoDB_update.Parameters.AddWithValue("@unidad_dias", objNovedadNomina.UnidadDias);
                                comandoDB_update.Parameters.AddWithValue("@unidad_monto", objNovedadNomina.UnidadMonto);
                                comandoDB_update.Parameters.AddWithValue("@observacion", objNovedadNomina.Observacion);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objNovedadNomina.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objNovedadNomina.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objNovedadNomina.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Novedades de Nomina", "Modificó el registro Id:" + objNovedadNomina.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Inexistente.\nLa novedad No se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M012NOVEDAD_NOMINA", "M014NOVEDAD_NOMINA", "M016NOVEDAD_NOMINA", "M018NOVEDAD_NOMINA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool anular(NovedadNomina objNovedadNomina)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ANULAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objNovedadNomina.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ANULAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objNovedadNomina.Id);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Novedades de Nomina", "Anuló el registro Id:" + objNovedadNomina.Id + "."); //Registra la eliminación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Anulado.\nLa novedad ya se encuentra anulada en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M020NOVEDAD_NOMINA", "M022NOVEDAD_NOMINA", "M024NOVEDAD_NOMINA", "M026NOVEDAD_NOMINA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(NovedadNomina objNovedadNomina)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objNovedadNomina.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objNovedadNomina.Id);
                                comandoDB_insert.Parameters.AddWithValue("@fecha_emision", objNovedadNomina.FechaEmision);
                                comandoDB_insert.Parameters.AddWithValue("@periodo", objNovedadNomina.Periodo);
                                comandoDB_insert.Parameters.AddWithValue("@estado", objNovedadNomina.Estado);
                                comandoDB_insert.Parameters.AddWithValue("@id_legajo", objNovedadNomina.Legajo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_centro_costo", objNovedadNomina.CentroCosto.Id);
                                comandoDB_insert.Parameters.AddWithValue("@novedad_tipo", objNovedadNomina.NovedadTipo);
                                comandoDB_insert.Parameters.AddWithValue("@unidad_inicializacion", objNovedadNomina.Unidad_inicializacion);
                                comandoDB_insert.Parameters.AddWithValue("@unidad_finalizacion", objNovedadNomina.Unidad_finalizacion);
                                comandoDB_insert.Parameters.AddWithValue("@unidad_horas", objNovedadNomina.UnidadHoras);
                                comandoDB_insert.Parameters.AddWithValue("@unidad_dias", objNovedadNomina.UnidadDias);
                                comandoDB_insert.Parameters.AddWithValue("@unidad_monto", objNovedadNomina.UnidadMonto);
                                comandoDB_insert.Parameters.AddWithValue("@observacion", objNovedadNomina.Observacion);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objNovedadNomina.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objNovedadNomina.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objNovedadNomina.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Novedades de Nomina", "Agregó un nuevo registro ID:" + objNovedadNomina.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nLa novedad ya se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M028NOVEDAD_NOMINA", "M030NOVEDAD_NOMINA", "M032NOVEDAD_NOMINA", "M034NOVEDAD_NOMINA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool liquidar(string periodo)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_LIQUIDAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@periodo", periodo); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(LIQUIDAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@periodo", periodo);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                Mensaje.Informacion("La liquidación de novedades del periodo: " + periodo + "\nse registró correctamente.");
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registros Inaccesibles.\nEl periodo indicado ya esta liquidado o No contiene novedades registradas.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M036NOVEDAD_NOMINA", "M038NOVEDAD_NOMINA", "M040NOVEDAD_NOMINA", "M042NOVEDAD_NOMINA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private NovedadNomina instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new NovedadNomina(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToDateTime(lectorDB["fecha_emision"]),
                Convert.ToString(lectorDB["periodo"]),
                Convert.ToString(lectorDB["estado"]),
                new D_Legajo().obtenerObjeto("ID", Convert.ToString(lectorDB["id_legajo"]), false),
                new D_CentroCosto().obtenerObjeto("ID", Convert.ToString(lectorDB["id_centro_costo"]), false),
                Convert.ToString(lectorDB["novedad_tipo"]),
                Convert.ToDateTime(lectorDB["unidad_inicializacion"]),
                Convert.ToDateTime(lectorDB["unidad_finalizacion"]),
                Convert.ToInt32(lectorDB["unidad_horas"]),
                Convert.ToInt32(lectorDB["unidad_dias"]),
                Convert.ToDouble(lectorDB["unidad_monto"]),
                Convert.ToString(lectorDB["observacion"]),
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