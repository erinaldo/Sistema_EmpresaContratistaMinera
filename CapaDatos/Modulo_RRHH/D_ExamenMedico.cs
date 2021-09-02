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
    public class D_ExamenMedico : IExamenMedico, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_examen_medico.*, 
            data_legajo.denominacion, data_legajo.documento, data_legajo.cuit";
        private const string FROM = @" FROM data_examen_medico
            INNER JOIN data_legajo ON data_examen_medico.id_legajo = data_legajo.id";
        private const string WHERE1 = @" WHERE data_examen_medico.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_examen_medico.id_legajo = @id_legajo"; //Filtrar Objeto por ID Legajo
        private const string WHERE3 = @" WHERE data_examen_medico.id_legajo = @id_legajo AND data_examen_medico.id = (SELECT MAX(data_examen_medico.id) FROM data_examen_medico WHERE data_examen_medico.id_legajo = @id_legajo AND data_examen_medico.estado <> 'ANULADO')"; //Filtrar Objeto por ID Legajo (obtiene el registro más reciente y No anulado)
        private const string WHERE4 = @" WHERE data_legajo.cuit = @cuit"; //Filtrar Objeto por CUIL/CUIT
        private const string WHERE5 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE6 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion) AND data_examen_medico.estado = @estado"; //Filtrar Objeto por Denominación y Estado
        private const string WHERE7 = @" WHERE date(examen_emision) >= date(@desde) AND date(examen_emision) <= date(@hasta)"; //Filtrar Objeto por Fecha de Alta
        private const string WHERE8 = @" WHERE date(examen_emision) >= date(@desde) AND date(examen_emision) <= date(@hasta) AND data_examen_medico.estado = @estado"; //Filtrar Objeto por Fecha de Alta y Estado
        private const string ORDER = @" ORDER BY data_examen_medico.examen_emision DESC, data_legajo.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_examen_medico WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ANULAR = @"SELECT * FROM data_examen_medico WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_examen_medico WHERE id_legajo = @id_legajo AND estado = 'VIGENTE'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_examen_medico SET 
            id = @id,
            id_legajo = @id_legajo,
            tipo_examen = @tipo_examen,
            institucion = @institucion,
            examen_emision = @examen_emision,
            examen_emision_alertado = @examen_emision_alertado,
            evaluacion_respirador = @evaluacion_respirador,
            evaluacion_respirador_emision = @evaluacion_respirador_emision,
            evaluacion_respirador_vto = @evaluacion_respirador_vto,
            cara_completa = @cara_completa,
            cara_completa_prueba = @cara_completa_prueba,
            cara_completa_marca = @cara_completa_marca,
            cara_completa_modelo = @cara_completa_modelo,
            cara_completa_tamanio = @cara_completa_tamanio,
            media_cara = @media_cara,
            media_cara_prueba = @media_cara_prueba,
            media_cara_marca = @media_cara_marca,
            media_cara_modelo = @media_cara_modelo,
            media_cara_tamanio = @media_cara_tamanio,
            observacion = @observacion,
            evaluacion_medica = @evaluacion_medica,
            estado = @estado,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ANULAR = @"UPDATE data_examen_medico SET estado = 'ANULADO' WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_examen_medico (id, id_legajo, tipo_examen, institucion, 
            examen_emision, examen_emision_alertado, evaluacion_respirador, evaluacion_respirador_emision,
            evaluacion_respirador_vto, cara_completa, cara_completa_prueba, cara_completa_marca, cara_completa_modelo,
            cara_completa_tamanio, media_cara, media_cara_prueba, media_cara_marca, media_cara_modelo, media_cara_tamanio,
            observacion, evaluacion_medica, estado, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @id_legajo, @tipo_examen, @institucion, @examen_emision, @examen_emision_alertado,
            @evaluacion_respirador, @evaluacion_respirador_emision, @evaluacion_respirador_vto, @cara_completa, 
            @cara_completa_prueba, @cara_completa_marca, @cara_completa_modelo, @cara_completa_tamanio, @media_cara,
            @media_cara_prueba, @media_cara_marca, @media_cara_modelo, @media_cara_tamanio, @observacion,
            @evaluacion_medica, @estado, @edicion_fecha, @edicion_usuario_id, @edicion_usuario)";
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
                                    string fechaVto = Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["examen_emision"]).AddMonths(Global.Vigencia_ExamenMedico));
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + Convert.ToString(lectorDB["tipo_examen"]).PadRight(14, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["examen_emision"])).PadLeft(10, '0') +
                                            " | " + fechaVto.PadRight(10, ' ') +
                                            " | " + Convert.ToString(lectorDB["evaluacion_medica"]).PadRight(7, ' ') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(7, ' '));
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
            catch (MySqlException e) { Mensaje.Error("Error-M002EXAMEN_MEDICO: Hay un conflicto en la consulta de exámenes médicos.", e); }
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
                                if (catalogo == "CATALOGO1")
                                {
                                    string fechaVto = Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["examen_emision"]).AddMonths(Global.Vigencia_ExamenMedico));
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + Convert.ToString(lectorDB["tipo_examen"]).PadRight(14, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["examen_emision"])).PadLeft(10, '0') +
                                            " | " + fechaVto.PadRight(10, ' ') +
                                            " | " + Convert.ToString(lectorDB["evaluacion_medica"]).PadRight(7, ' ') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(7, ' '));
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
            catch (MySqlException e) { Mensaje.Error("Error-M004EXAMEN_MEDICO: Hay un conflicto en la consulta de exámenes médicos", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<ExamenMedico> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "CUIT") condicional = WHERE4; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Denominación y/o Estado
            List<ExamenMedico> ListaDeObjetos = new List<ExamenMedico>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                ExamenMedico objExamenMedico = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objExamenMedico); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006EXAMEN_MEDICO: Hay un conflicto en la consulta de exámenes médicos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<ExamenMedico> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            string condicional = "";
            if (campo == "FECHA") condicional = ((estado != "TODOS") ? WHERE8 : WHERE7); //Consulta filtrada por Fecha de Alta y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            List<ExamenMedico> ListaDeObjetos = new List<ExamenMedico>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                ExamenMedico objExamenMedico = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objExamenMedico); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008EXAMEN_MEDICO: Hay un conflicto en la consulta de exámenes médicos", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public ExamenMedico obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            if (campo == "ID_LEGAJO") condicional = WHERE2; //Consulta filtrada por ID Legajo
            if (campo == "ID_LEGAJO_RECIENTE") condicional = WHERE3; //Consulta filtrada por ID Legajo (obtiene el registro más reciente y No anulado)
            if (campo == "CUIT") condicional = WHERE4; //Consulta filtrada por CUIL/CUIT
            ExamenMedico objExamenMedico = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objExamenMedico = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos del examen médico e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010EXAMEN_MEDICO: Hay un conflicto en la consulta del examen médico.", e); }
            finally { _conexion.Dispose(); }
            return objExamenMedico;
        }

        public bool actualizar(ExamenMedico objExamenMedico)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objExamenMedico.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objExamenMedico.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_legajo", objExamenMedico.Legajo.Id);
                                comandoDB_update.Parameters.AddWithValue("@institucion", objExamenMedico.Institucion);
                                comandoDB_update.Parameters.AddWithValue("@tipo_examen", objExamenMedico.TipoExamen);
                                comandoDB_update.Parameters.AddWithValue("@examen_emision", objExamenMedico.ExamenEmision);
                                comandoDB_update.Parameters.AddWithValue("@examen_emision_alertado", objExamenMedico.ExamenAlertado);
                                comandoDB_update.Parameters.AddWithValue("@evaluacion_respirador", objExamenMedico.EvaluacionRespirador);
                                comandoDB_update.Parameters.AddWithValue("@evaluacion_respirador_emision", objExamenMedico.EvaluacionRespiradorEmision);
                                comandoDB_update.Parameters.AddWithValue("@evaluacion_respirador_vto", objExamenMedico.EvaluacionRespiradorVto);
                                comandoDB_update.Parameters.AddWithValue("@cara_completa", objExamenMedico.CaraCompleta);
                                comandoDB_update.Parameters.AddWithValue("@cara_completa_prueba", objExamenMedico.CaraCompletaPrueba);
                                comandoDB_update.Parameters.AddWithValue("@cara_completa_marca", objExamenMedico.CaraCompletaMarca);
                                comandoDB_update.Parameters.AddWithValue("@cara_completa_modelo", objExamenMedico.CaraCompletaModelo);
                                comandoDB_update.Parameters.AddWithValue("@cara_completa_tamanio", objExamenMedico.CaraCompletaTamanio);
                                comandoDB_update.Parameters.AddWithValue("@media_cara", objExamenMedico.MediaCara);
                                comandoDB_update.Parameters.AddWithValue("@media_cara_prueba", objExamenMedico.MediaCaraPrueba);
                                comandoDB_update.Parameters.AddWithValue("@media_cara_marca", objExamenMedico.MediaCaraMarca);
                                comandoDB_update.Parameters.AddWithValue("@media_cara_modelo", objExamenMedico.MediaCaraModelo);
                                comandoDB_update.Parameters.AddWithValue("@media_cara_tamanio", objExamenMedico.MediaCaraTamanio);
                                comandoDB_update.Parameters.AddWithValue("@observacion", objExamenMedico.Observacion);
                                comandoDB_update.Parameters.AddWithValue("@evaluacion_medica", objExamenMedico.EvaluacionMedica);
                                comandoDB_update.Parameters.AddWithValue("@estado", objExamenMedico.Estado);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objExamenMedico.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objExamenMedico.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objExamenMedico.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Exámenes Médicos", "Modificó el registro Id:" + objExamenMedico.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl examen médico ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M012EXAMEN_MEDICO", "M014EXAMEN_MEDICO", "M016EXAMEN_MEDICO", "M018EXAMEN_MEDICO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool anular(ExamenMedico objExamenMedico)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ANULAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objExamenMedico.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ANULAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objExamenMedico.Id);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Exámenes Médicos", "Anuló el registro Id:" + objExamenMedico.Id + "."); //Registra la eliminación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Anulado.\nEl examen médico ya se encuentra anulado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M020EXAMEN_MEDICO", "M022EXAMEN_MEDICO", "M024EXAMEN_MEDICO", "M026EXAMEN_MEDICO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(ExamenMedico objExamenMedico)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_legajo", objExamenMedico.Legajo.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objExamenMedico.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_legajo", objExamenMedico.Legajo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@institucion", objExamenMedico.Institucion);
                                comandoDB_insert.Parameters.AddWithValue("@tipo_examen", objExamenMedico.TipoExamen);
                                comandoDB_insert.Parameters.AddWithValue("@examen_emision", objExamenMedico.ExamenEmision);
                                comandoDB_insert.Parameters.AddWithValue("@examen_emision_alertado", objExamenMedico.ExamenAlertado);
                                comandoDB_insert.Parameters.AddWithValue("@evaluacion_respirador", objExamenMedico.EvaluacionRespirador);
                                comandoDB_insert.Parameters.AddWithValue("@evaluacion_respirador_emision", objExamenMedico.EvaluacionRespiradorEmision);
                                comandoDB_insert.Parameters.AddWithValue("@evaluacion_respirador_vto", objExamenMedico.EvaluacionRespiradorVto);
                                comandoDB_insert.Parameters.AddWithValue("@cara_completa", objExamenMedico.CaraCompleta);
                                comandoDB_insert.Parameters.AddWithValue("@cara_completa_prueba", objExamenMedico.CaraCompletaPrueba);
                                comandoDB_insert.Parameters.AddWithValue("@cara_completa_marca", objExamenMedico.CaraCompletaMarca);
                                comandoDB_insert.Parameters.AddWithValue("@cara_completa_modelo", objExamenMedico.CaraCompletaModelo);
                                comandoDB_insert.Parameters.AddWithValue("@cara_completa_tamanio", objExamenMedico.CaraCompletaTamanio);
                                comandoDB_insert.Parameters.AddWithValue("@media_cara", objExamenMedico.MediaCara);
                                comandoDB_insert.Parameters.AddWithValue("@media_cara_prueba", objExamenMedico.MediaCaraPrueba);
                                comandoDB_insert.Parameters.AddWithValue("@media_cara_marca", objExamenMedico.MediaCaraMarca);
                                comandoDB_insert.Parameters.AddWithValue("@media_cara_modelo", objExamenMedico.MediaCaraModelo);
                                comandoDB_insert.Parameters.AddWithValue("@media_cara_tamanio", objExamenMedico.MediaCaraTamanio);
                                comandoDB_insert.Parameters.AddWithValue("@observacion", objExamenMedico.Observacion);
                                comandoDB_insert.Parameters.AddWithValue("@evaluacion_medica", objExamenMedico.EvaluacionMedica);
                                comandoDB_insert.Parameters.AddWithValue("@estado", objExamenMedico.Estado);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objExamenMedico.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objExamenMedico.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objExamenMedico.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Exámenes Médicos", "Agregó un nuevo registro ID:" + objExamenMedico.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl examen médico ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M028EXAMEN_MEDICO", "M030EXAMEN_MEDICO", "M032EXAMEN_MEDICO", "M034EXAMEN_MEDICO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private ExamenMedico instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new ExamenMedico(
                Convert.ToInt64(lectorDB["id"]),
                new D_Legajo().obtenerObjeto("ID", Convert.ToString(lectorDB["id_legajo"]), false),
                Convert.ToString(lectorDB["institucion"]),
                Convert.ToString(lectorDB["tipo_examen"]),
                Convert.ToDateTime(lectorDB["examen_emision"]),
                Convert.ToBoolean(lectorDB["examen_emision_alertado"]),
                Convert.ToBoolean(lectorDB["evaluacion_respirador"]),
                Convert.ToDateTime(lectorDB["evaluacion_respirador_emision"]),
                Convert.ToDateTime(lectorDB["evaluacion_respirador_vto"]),
                Convert.ToBoolean(lectorDB["cara_completa"]),
                Convert.ToDateTime(lectorDB["cara_completa_prueba"]),
                Convert.ToString(lectorDB["cara_completa_marca"]),
                Convert.ToString(lectorDB["cara_completa_modelo"]),
                Convert.ToString(lectorDB["cara_completa_tamanio"]),
                Convert.ToBoolean(lectorDB["media_cara"]),
                Convert.ToDateTime(lectorDB["media_cara_prueba"]),
                Convert.ToString(lectorDB["media_cara_marca"]),
                Convert.ToString(lectorDB["media_cara_modelo"]),
                Convert.ToString(lectorDB["media_cara_tamanio"]),
                Convert.ToString(lectorDB["observacion"]),
                Convert.ToString(lectorDB["evaluacion_medica"]),
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