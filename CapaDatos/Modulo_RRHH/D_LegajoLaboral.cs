using Biblioteca.Ayudantes;
using CapaDatos.Catalogo;
using CapaDatos.Sistema;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_LegajoLaboral : ILegajoLaboral, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_legajo_laboral.*, 
            data_legajo.denominacion, data_legajo.documento, data_legajo.cuit, data_legajo.baja,
            data_sindicato.denominacion AS sindicato";
        private const string FROM = @" FROM data_legajo_laboral
            INNER JOIN data_legajo ON data_legajo_laboral.id_legajo = data_legajo.id
            LEFT JOIN data_sindicato ON data_legajo_laboral.id_sindicato = data_sindicato.id";
        private const string WHERE1 = @" WHERE data_legajo_laboral.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_legajo_laboral.id_legajo = @id_legajo"; //Filtrar Objeto por ID Legajo
        private const string WHERE3 = @" WHERE data_legajo.cuit = @cuit"; //Filtrar Objeto por CUIL/CUIT
        private const string WHERE4 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE5 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion) AND data_legajo_laboral.estado = @estado"; //Filtrar Objeto por Denominación y Estado
        private const string WHERE6 = @" WHERE date(fecha_ingreso) >= date(@desde) AND date(fecha_ingreso) <= date(@hasta)"; //Filtrar Objeto por Fecha de Alta
        private const string WHERE7 = @" WHERE date(fecha_ingreso) >= date(@desde) AND date(fecha_ingreso) <= date(@hasta) AND data_legajo_laboral.estado = @estado"; //Filtrar Objeto por Fecha de Alta y Estado
        private const string WHERE8 = @" WHERE date(fecha_egreso) >= date(@desde) AND date(fecha_egreso) <= date(@hasta)"; //Filtrar Objeto por Fecha de Alta
        private const string WHERE9 = @" WHERE date(fecha_egreso) >= date(@desde) AND date(fecha_egreso) <= date(@hasta) AND data_legajo_laboral.estado = @estado"; //Filtrar Objeto por Fecha de Alta y Estado
        private const string ORDER = @" ORDER BY data_legajo.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_legajo_laboral WHERE id_legajo = @id_legajo AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_legajo_laboral WHERE id_legajo = @id_legajo"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_legajo_laboral SET 
            id = @id,
            id_legajo = @id_legajo,
            id_centro_costo = @id_centro_costo, 
            fecha_ingreso = @fecha_ingreso,
            fecha_egreso = @fecha_egreso,
            modalidad_contratacion = @modalidad_contratacion,
            modalidad_contratacion_tiempo = @modalidad_contratacion_tiempo,
            id_sindicato = @id_sindicato, 
            afiliado_sindical = @afiliado_sindical,
            id_categoria = @id_categoria, 
            puesto = @puesto,
            sector = @sector,
            modalidad_liquidacion = @modalidad_liquidacion, 
            remuneracion = @remuneracion, 
            id_obra_social = @id_obra_social, 
            observacion = @observacion,
            estado = @estado,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ACTUALIZAR_ESTADO = @"UPDATE data_legajo_laboral SET estado = @estado WHERE id_legajo = @id_legajo";
        private const string INSERTAR = @"INSERT INTO data_legajo_laboral(id, id_legajo, id_centro_costo,
            fecha_ingreso, fecha_egreso, modalidad_contratacion, modalidad_contratacion_tiempo, id_sindicato,
            afiliado_sindical, id_categoria, puesto, sector, modalidad_liquidacion, remuneracion, id_obra_social, 
            observacion, estado, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @id_legajo, @id_centro_costo, @fecha_ingreso, @fecha_egreso, @modalidad_contratacion,
            @modalidad_contratacion_tiempo, @id_sindicato, @afiliado_sindical, @id_categoria, @puesto, @sector,
            @modalidad_liquidacion, @remuneracion, @id_obra_social, @observacion, @estado, @edicion_fecha,
            @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "CUIT") condicional = WHERE3; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE5 : WHERE4; //Consulta filtrada por Denominación y/o Estado
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
                                string estadoLaboral = Convert.ToString(lectorDB["estado"]);
                                string fechaIngreso = (estadoLaboral != "EN PROCESO") ? Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha_ingreso"])) : "";
                                string fechaEgreso = (estadoLaboral == "INACTIVO") ? Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha_egreso"])) : "";
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                       Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + fechaIngreso.PadLeft(10, ' ') +
                                            " | " + fechaEgreso.PadLeft(10, ' ') +
                                            " | " + Fecha.CalcularAntiguedadLaboral(fechaIngreso, ((estadoLaboral == "INACTIVO") ? fechaEgreso : Fecha.SistemaFecha()), estadoLaboral).PadRight(11, ' ') +
                                            " | " + estadoLaboral.PadRight(10, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                         Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                             " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') +
                                             " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                             " | " + fechaIngreso.PadLeft(10, ' ') +
                                             " | " + fechaEgreso.PadLeft(10, ' ') +
                                             " | " + Fecha.CalcularAntiguedadLaboral(fechaIngreso, ((estadoLaboral == "INACTIVO") ? fechaEgreso : Fecha.SistemaFecha()), estadoLaboral).PadRight(11, ' ') +
                                             " | " + (Convert.ToString(lectorDB["sindicato"]) + ((Convert.ToBoolean(lectorDB["afiliado_sindical"])) ? " (AFILIADO)" : "")).PadRight(36, ' ') +
                                             " | " + estadoLaboral.PadRight(10, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002LEGAJO_LABORAL: Hay un conflicto en la consulta de legajos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "EGRESO") condicional = ((estado != "TODOS") ? WHERE7 : WHERE6); //Consulta filtrada por Fecha de Egreso y/o Estado
            if (campo == "INGRESO") condicional = ((estado != "TODOS") ? WHERE9 : WHERE8); //Consulta filtrada por Fecha de Ingreso y/o Estado
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
                                string estadoLaboral = Convert.ToString(lectorDB["estado"]);
                                string fechaIngreso = (estadoLaboral != "EN PROCESO") ? Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha_ingreso"])) : "";
                                string fechaEgreso = (estadoLaboral == "INACTIVO") ? Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha_egreso"])) : "";
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                       Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + fechaIngreso.PadLeft(10, ' ') +
                                            " | " + fechaEgreso.PadLeft(10, ' ') +
                                            " | " + Fecha.CalcularAntiguedadLaboral(fechaIngreso, ((estadoLaboral == "INACTIVO") ? fechaEgreso : Fecha.SistemaFecha()), estadoLaboral).PadRight(11, ' ') +
                                            " | " + estadoLaboral.PadRight(10, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                         Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                             " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') +
                                             " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                             " | " + fechaIngreso.PadLeft(10, ' ') +
                                             " | " + fechaEgreso.PadLeft(10, ' ') +
                                             " | " + Fecha.CalcularAntiguedadLaboral(fechaIngreso, ((estadoLaboral == "INACTIVO") ? fechaEgreso : Fecha.SistemaFecha()), estadoLaboral).PadRight(11, ' ') +
                                             " | " + (Convert.ToString(lectorDB["sindicato"]) + ((Convert.ToBoolean(lectorDB["afiliado_sindical"])) ? " (AFILIADO)" : "")).PadRight(36, ' ') +
                                             " | " + estadoLaboral.PadRight(10, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004LEGAJO_LABORAL: Hay un conflicto en la consulta de legajos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<LegajoLaboral> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "CUIT") condicional = WHERE3; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE5 : WHERE4; //Consulta filtrada por Denominación y/o Estado
            List<LegajoLaboral> ListaDeObjetos = new List<LegajoLaboral>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega un parámetro al filtro
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega un parámetro al filtro
                        if (estado == "C/BAJA") comandoDB.Parameters.AddWithValue("@baja", "1"); //Agrega el parámetro en la condición de la consulta
                        if (estado == "S/BAJA") comandoDB.Parameters.AddWithValue("@baja", "0"); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                LegajoLaboral objLegajoLaboral = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objLegajoLaboral); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006LEGAJO_LABORAL: Hay un conflicto en la consulta de legajos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<LegajoLaboral> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            string condicional = "";
            if (campo == "EGRESO") condicional = ((estado != "TODOS") ? WHERE7 : WHERE6); //Consulta filtrada por Fecha de Egreso y/o Estado
            if (campo == "INGRESO") condicional = ((estado != "TODOS") ? WHERE9 : WHERE8); //Consulta filtrada por Fecha de Ingreso y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            List<LegajoLaboral> ListaDeObjetos = new List<LegajoLaboral>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                LegajoLaboral objLegajoLaboral = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objLegajoLaboral); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008LEGAJO_LABORAL: Hay un conflicto en la consulta de legajos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public LegajoLaboral obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            if (campo == "ID_LEGAJO") condicional = WHERE2; //Consulta filtrada por ID Legajo
            if (campo == "CUIT") condicional = WHERE3; //Consulta filtrada por CUIL/CUIT
            LegajoLaboral objLegajoLaboral = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        if (campo == "ID_LEGAJO") comandoDB.Parameters.AddWithValue("@id_legajo", valor); //Agrega un parámetro al filtro
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objLegajoLaboral = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos del legajo e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010LEGAJO_LABORAL: Hay un conflicto en la consulta del legajo.", e); }
            finally { _conexion.Dispose(); }
            return objLegajoLaboral;
        }

        public bool actualizar(LegajoLaboral objLegajoLaboral)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objLegajoLaboral.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@id_legajo", objLegajoLaboral.Legajo.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objLegajoLaboral.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_legajo", objLegajoLaboral.Legajo.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_centro_costo", objLegajoLaboral.CentroCosto.Id);
                                comandoDB_update.Parameters.AddWithValue("@fecha_ingreso", objLegajoLaboral.FechaIngreso);
                                comandoDB_update.Parameters.AddWithValue("@fecha_egreso", objLegajoLaboral.FechaEgreso);
                                comandoDB_update.Parameters.AddWithValue("@modalidad_contratacion", objLegajoLaboral.ModalidadContratacion);
                                comandoDB_update.Parameters.AddWithValue("@modalidad_contratacion_tiempo", objLegajoLaboral.ModalidadContratacionTiempo);
                                comandoDB_update.Parameters.AddWithValue("@id_sindicato", objLegajoLaboral.Sindicato.Id);
                                comandoDB_update.Parameters.AddWithValue("@afiliado_sindical", objLegajoLaboral.AfiliadoSindical);
                                comandoDB_update.Parameters.AddWithValue("@id_categoria", objLegajoLaboral.CategoriaTrabajo.Id);
                                comandoDB_update.Parameters.AddWithValue("@puesto", objLegajoLaboral.Puesto);
                                comandoDB_update.Parameters.AddWithValue("@sector", objLegajoLaboral.Sector);
                                comandoDB_update.Parameters.AddWithValue("@modalidad_liquidacion", objLegajoLaboral.ModalidadLiquidacion);
                                comandoDB_update.Parameters.AddWithValue("@remuneracion", objLegajoLaboral.Remuneracion);
                                comandoDB_update.Parameters.AddWithValue("@id_obra_social", objLegajoLaboral.ObraSocial.Id);
                                comandoDB_update.Parameters.AddWithValue("@observacion", objLegajoLaboral.Observacion);
                                comandoDB_update.Parameters.AddWithValue("@estado", objLegajoLaboral.Estado);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objLegajoLaboral.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objLegajoLaboral.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objLegajoLaboral.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Legajos - Laboral", "Modificó el registro Id:" + objLegajoLaboral.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nLos datos laborales ya se encuentran registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M012LEGAJO_LABORAL", "M014LEGAJO_LABORAL", "M016LEGAJO_LABORAL", "M018LEGAJO_LABORAL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool actualizarEstado(Legajo objLegajo, string estado, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE2)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_legajo", objLegajo.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR_ESTADO)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id_legajo", objLegajo.Id);
                                comandoDB_update.Parameters.AddWithValue("@estado", estado);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                if (notificarExito) Mensaje.Informacion("El nuevo estado laboral de " + objLegajo.Denominacion.ToString() + "\nse registró correctamente.");
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro Inexistente.\nEl legajo No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M020LEGAJO_LABORAL", "M022LEGAJO_LABORAL", "M024LEGAJO_LABORAL", "M026LEGAJO_LABORAL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(LegajoLaboral objLegajoLaboral)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_legajo", objLegajoLaboral.Legajo.Id); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objLegajoLaboral.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_legajo", objLegajoLaboral.Legajo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_centro_costo", objLegajoLaboral.CentroCosto.Id);
                                comandoDB_insert.Parameters.AddWithValue("@fecha_ingreso", objLegajoLaboral.FechaIngreso);
                                comandoDB_insert.Parameters.AddWithValue("@fecha_egreso", objLegajoLaboral.FechaEgreso);
                                comandoDB_insert.Parameters.AddWithValue("@modalidad_contratacion", objLegajoLaboral.ModalidadContratacion);
                                comandoDB_insert.Parameters.AddWithValue("@modalidad_contratacion_tiempo", objLegajoLaboral.ModalidadContratacionTiempo);
                                comandoDB_insert.Parameters.AddWithValue("@id_sindicato", objLegajoLaboral.Sindicato.Id);
                                comandoDB_insert.Parameters.AddWithValue("@afiliado_sindical", objLegajoLaboral.AfiliadoSindical);
                                comandoDB_insert.Parameters.AddWithValue("@id_categoria", objLegajoLaboral.CategoriaTrabajo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@puesto", objLegajoLaboral.Puesto);
                                comandoDB_insert.Parameters.AddWithValue("@sector", objLegajoLaboral.Sector);
                                comandoDB_insert.Parameters.AddWithValue("@modalidad_liquidacion", objLegajoLaboral.ModalidadLiquidacion);
                                comandoDB_insert.Parameters.AddWithValue("@remuneracion", objLegajoLaboral.Remuneracion);
                                comandoDB_insert.Parameters.AddWithValue("@id_obra_social", objLegajoLaboral.ObraSocial.Id);
                                comandoDB_insert.Parameters.AddWithValue("@observacion", objLegajoLaboral.Observacion);
                                comandoDB_insert.Parameters.AddWithValue("@estado", objLegajoLaboral.Estado);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objLegajoLaboral.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objLegajoLaboral.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objLegajoLaboral.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Legajos - Laboral", "Agregó un nuevo registro ID:" + objLegajoLaboral.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nLos datos laborales ya se encuentran registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M028LEGAJO_LABORAL", "M030LEGAJO_LABORAL", "M032LEGAJO_LABORAL", "M034LEGAJO_LABORAL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private LegajoLaboral instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new LegajoLaboral(
                Convert.ToInt64(lectorDB["id"]),
                new D_Legajo().obtenerObjeto("ID", Convert.ToString(lectorDB["id_legajo"]), false),
                new D_CentroCosto().obtenerObjeto("ID", Convert.ToString(lectorDB["id_centro_costo"]), false),
                Convert.ToDateTime(lectorDB["fecha_ingreso"]),
                Convert.ToDateTime(lectorDB["fecha_egreso"]),
                Convert.ToString(lectorDB["modalidad_contratacion"]),
                Convert.ToString(lectorDB["modalidad_contratacion_tiempo"]),
                new D_Sindicato().obtenerObjeto("ID", Convert.ToString(lectorDB["id_sindicato"]), false),
                Convert.ToBoolean(lectorDB["afiliado_sindical"]),
                new D_CategoriaTrabajo().obtenerObjeto("ID", Convert.ToString(lectorDB["id_categoria"]), false),
                Convert.ToString(lectorDB["puesto"]),
                Convert.ToString(lectorDB["sector"]),
                Convert.ToString(lectorDB["modalidad_liquidacion"]),
                Convert.ToDouble(lectorDB["remuneracion"]),
                new D_ObraSocial().obtenerObjeto("ID", Convert.ToString(lectorDB["id_obra_social"]), false),
                Convert.ToString(lectorDB["observacion"]),
                Convert.ToString(lectorDB["estado"]),
                Convert.ToDateTime(lectorDB["edicion_fecha"]),
                Convert.ToInt64(lectorDB["edicion_usuario_id"]),
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
