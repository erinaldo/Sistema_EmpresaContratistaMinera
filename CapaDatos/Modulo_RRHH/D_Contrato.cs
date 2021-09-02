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
    public class D_Contrato : IContrato, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_contrato.*, 
            data_legajo.denominacion, data_legajo.documento, data_legajo.cuit,
            data_centro_costo.denominacion AS centro_costo, 
            cat_categoria_trabajo.denominacion AS categoria, 
            data_sindicato.denominacion AS sindicato, 
            cat_obra_social.denominacion AS obra_social";
        private const string FROM = @" FROM data_contrato
            INNER JOIN data_legajo ON data_contrato.id_legajo = data_legajo.id
            LEFT JOIN data_centro_costo ON data_contrato.id_centro_costo = data_centro_costo.id 
            LEFT JOIN cat_categoria_trabajo ON data_contrato.id_categoria = cat_categoria_trabajo.id
            LEFT JOIN data_sindicato ON data_contrato.id_sindicato = data_sindicato.id 
            LEFT JOIN cat_obra_social ON data_contrato.id_obra_social = cat_obra_social.id";
        private const string WHERE1 = @" WHERE data_contrato.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_contrato.id_legajo = @id_legajo"; //Filtrar Objeto por ID Legajo
        private const string WHERE3 = @" WHERE data_contrato.id_legajo = @id_legajo AND data_contrato.id = (SELECT MAX(data_contrato.id) FROM data_contrato WHERE data_contrato.id_legajo = @id_legajo AND data_contrato.estado <> 'ANULADO')"; //Filtrar Objeto por ID Legajo (obtiene el registro más reciente y No anulado)
        private const string WHERE4 = @" WHERE data_legajo.cuit = @cuit"; //Filtrar Objeto por CUIL/CUIT
        private const string WHERE5 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE6 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion) AND data_contrato.estado = @estado"; //Filtrar Objeto por Denominación y Estado
        private const string WHERE7 = @" WHERE date(fecha_alta) >= date(@desde) AND date(fecha_alta) <= date(@hasta)"; //Filtrar Objeto por Fecha de Alta
        private const string WHERE8 = @" WHERE date(fecha_alta) >= date(@desde) AND date(fecha_alta) <= date(@hasta) AND data_contrato.estado = @estado"; //Filtrar Objeto por Fecha de Alta y Estado
        private const string WHERE9 = @" WHERE date(rescision_fecha) >= date(@desde) AND date(rescision_fecha) <= date(@hasta)"; //Filtrar Objeto por Fecha de Baja
        private const string WHERE10 = @" WHERE date(rescision_fecha) >= date(@desde) AND date(rescision_fecha) <= date(@hasta) AND data_contrato.estado = @estado"; //Filtrar Objeto por Fecha de Baja y Estado
        private const string ORDER = @" ORDER BY data_contrato.fecha_alta DESC, data_legajo.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_contrato WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ANULAR = @"SELECT * FROM data_contrato WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_contrato WHERE id_legajo = @id_legajo AND estado = 'VIGENTE'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_contrato SET 
            id_legajo = @id_legajo, 
            id_centro_costo = @id_centro_costo, 
            fecha_alta = @fecha_alta,
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
            estado = @estado, 
            rescision = @rescision, 
            rescision_fecha = @rescision_fecha, 
            rescision_observacion = @rescision_observacion, 
            edicion_fecha = @edicion_fecha, 
            edicion_usuario_id = @edicion_usuario_id, 
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ANULAR = @"UPDATE data_contrato SET estado = 'ANULADO' WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_contrato (id, id_legajo, id_centro_costo, fecha_alta,
            modalidad_contratacion, modalidad_contratacion_tiempo, id_sindicato, afiliado_sindical, id_categoria,
            puesto, sector, modalidad_liquidacion, remuneracion, id_obra_social, estado, rescision, rescision_fecha,
            rescision_observacion, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @id_legajo, @id_centro_costo, @fecha_alta, @modalidad_contratacion, @modalidad_contratacion_tiempo, 
            @id_sindicato, @afiliado_sindical, @id_categoria, @puesto, @sector, @modalidad_liquidacion, @remuneracion,
            @id_obra_social, @estado, @rescision, @rescision_fecha, @rescision_observacion, @edicion_fecha,
            @edicion_usuario_id, @edicion_usuario)";
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
                                string fechaBaja = Convert.ToBoolean(lectorDB["rescision"]) ? Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["rescision_fecha"])) : "";
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + Convert.ToString(lectorDB["centro_costo"]).PadRight(25, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha_alta"])).PadLeft(10, '0') +
                                            " | " + fechaBaja.PadLeft(10, ' ') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(10, ' '));
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
            catch (MySqlException e) { Mensaje.Error("Error-M002CONTRATO: Hay un conflicto en la consulta de contratos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "FECHA_ALTA") condicional = ((estado != "TODOS") ? WHERE8 : WHERE7); //Consulta filtrada por Fecha de Alta y/o Estado
            if (campo == "FECHA_BAJA") condicional = ((estado != "TODOS") ? WHERE10 : WHERE9); //Consulta filtrada por Fecha de Baja y/o Estado
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
                                string fechaBaja = Convert.ToBoolean(lectorDB["rescision"]) ? Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["rescision_fecha"])) : "";
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + Convert.ToString(lectorDB["centro_costo"]).PadRight(25, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha_alta"])).PadLeft(10, '0') +
                                            " | " + fechaBaja.PadLeft(10, ' ') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(10, ' '));
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
            catch (MySqlException e) { Mensaje.Error("Error-M004CONTRATO: Hay un conflicto en la consulta de contratos", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<Contrato> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "CUIT") condicional = WHERE4; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Denominación y/o Estado
            List<Contrato> ListaDeObjetos = new List<Contrato>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                Contrato objContrato = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objContrato); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006CONTRATO: Hay un conflicto en la consulta de contratos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<Contrato> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            string condicional = "";
            if (campo == "FECHA_ALTA") condicional = ((estado != "TODOS") ? WHERE8 : WHERE7); //Consulta filtrada por Fecha de Alta y/o Estado
            if (campo == "FECHA_BAJA") condicional = ((estado != "TODOS") ? WHERE10 : WHERE9); //Consulta filtrada por Fecha de Baja y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            List<Contrato> ListaDeObjetos = new List<Contrato>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                Contrato objContrato = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objContrato); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008CONTRATO: Hay un conflicto en la consulta de contratos", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public Contrato obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            if (campo == "ID_LEGAJO") condicional = WHERE2; //Consulta filtrada por ID Legajo
            if (campo == "ID_LEGAJO_RECIENTE") condicional = WHERE3; //Consulta filtrada por ID Legajo (obtiene el registro más reciente y No anulado)
            if (campo == "CUIT") condicional = WHERE4; //Consulta filtrada por CUIL/CUIT
            Contrato objContrato = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objContrato = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos del contrato e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010CONTRATO: Hay un conflicto en la consulta del contrato.", e); }
            finally { _conexion.Dispose(); }
            return objContrato;
        }

        public bool actualizar(Contrato objContrato)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objContrato.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objContrato.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_legajo", objContrato.Legajo.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_centro_costo", objContrato.CentroCosto.Id);
                                comandoDB_update.Parameters.AddWithValue("@fecha_alta", objContrato.FechaAlta);
                                comandoDB_update.Parameters.AddWithValue("@modalidad_contratacion", objContrato.ModalidadContratacion);
                                comandoDB_update.Parameters.AddWithValue("@modalidad_contratacion_tiempo", objContrato.ModalidadContratacionTiempo);
                                comandoDB_update.Parameters.AddWithValue("@id_sindicato", objContrato.Sindicato.Id);
                                comandoDB_update.Parameters.AddWithValue("@afiliado_sindical", objContrato.AfiliadoSindical);
                                comandoDB_update.Parameters.AddWithValue("@id_categoria", objContrato.CategoriaTrabajo.Id);
                                comandoDB_update.Parameters.AddWithValue("@puesto", objContrato.Puesto);
                                comandoDB_update.Parameters.AddWithValue("@sector", objContrato.Sector);
                                comandoDB_update.Parameters.AddWithValue("@modalidad_liquidacion", objContrato.ModalidadLiquidacion);
                                comandoDB_update.Parameters.AddWithValue("@remuneracion", objContrato.Remuneracion);
                                comandoDB_update.Parameters.AddWithValue("@id_obra_social", objContrato.ObraSocial.Id);
                                comandoDB_update.Parameters.AddWithValue("@estado", objContrato.Estado);
                                comandoDB_update.Parameters.AddWithValue("@rescision", objContrato.Rescision);
                                comandoDB_update.Parameters.AddWithValue("@rescision_fecha", objContrato.RescisionFecha);
                                comandoDB_update.Parameters.AddWithValue("@rescision_observacion", objContrato.RescisionObservacion);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objContrato.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objContrato.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objContrato.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Contratos de Trabajo", "Modificó el registro Id:" + objContrato.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl contrato ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M012CONTRATO", "M014CONTRATO", "M016CONTRATO", "M018CONTRATO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool anular(Contrato objContrato)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ANULAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objContrato.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ANULAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objContrato.Id);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Contratos de Trabajo", "Anuló el registro Id:" + objContrato.Id + "."); //Registra la eliminación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Anulado.\nEl contrato ya se encuentra anulado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M020CONTRATO", "M022CONTRATO", "M024CONTRATO", "M026CONTRATO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(Contrato objContrato)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_legajo", objContrato.Legajo.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objContrato.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_legajo", objContrato.Legajo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_centro_costo", objContrato.CentroCosto.Id);
                                comandoDB_insert.Parameters.AddWithValue("@fecha_alta", objContrato.FechaAlta);
                                comandoDB_insert.Parameters.AddWithValue("@modalidad_contratacion", objContrato.ModalidadContratacion);
                                comandoDB_insert.Parameters.AddWithValue("@modalidad_contratacion_tiempo", objContrato.ModalidadContratacionTiempo);
                                comandoDB_insert.Parameters.AddWithValue("@id_sindicato", objContrato.Sindicato.Id);
                                comandoDB_insert.Parameters.AddWithValue("@afiliado_sindical", objContrato.AfiliadoSindical);
                                comandoDB_insert.Parameters.AddWithValue("@id_categoria", objContrato.CategoriaTrabajo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@puesto", objContrato.Puesto);
                                comandoDB_insert.Parameters.AddWithValue("@sector", objContrato.Sector);
                                comandoDB_insert.Parameters.AddWithValue("@modalidad_liquidacion", objContrato.ModalidadLiquidacion);
                                comandoDB_insert.Parameters.AddWithValue("@remuneracion", objContrato.Remuneracion);
                                comandoDB_insert.Parameters.AddWithValue("@id_obra_social", objContrato.ObraSocial.Id);
                                comandoDB_insert.Parameters.AddWithValue("@estado", objContrato.Estado);
                                comandoDB_insert.Parameters.AddWithValue("@rescision", objContrato.Rescision);
                                comandoDB_insert.Parameters.AddWithValue("@rescision_fecha", objContrato.RescisionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@rescision_observacion", objContrato.RescisionObservacion);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objContrato.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objContrato.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objContrato.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Contratos de Trabajo", "Agregó un nuevo registro ID:" + objContrato.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl contrato ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M028CONTRATO", "M030CONTRATO", "M032CONTRATO", "M034CONTRATO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private Contrato instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Contrato(
                Convert.ToInt64(lectorDB["id"]),
                new D_Legajo().obtenerObjeto("ID", Convert.ToString(lectorDB["id_legajo"]), false),
                new D_CentroCosto().obtenerObjeto("ID", Convert.ToString(lectorDB["id_centro_costo"]), false),
                Convert.ToDateTime(lectorDB["fecha_alta"]),
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
                Convert.ToString(lectorDB["estado"]),
                Convert.ToBoolean(lectorDB["rescision"]),
                Convert.ToDateTime(lectorDB["rescision_fecha"]),
                Convert.ToString(lectorDB["rescision_observacion"]),
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