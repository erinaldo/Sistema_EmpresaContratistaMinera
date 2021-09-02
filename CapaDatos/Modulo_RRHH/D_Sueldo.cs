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
    public class D_Sueldo : ISueldo, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_sueldo.*, 
            data_legajo.denominacion, data_legajo.documento, data_legajo.cuit, data_legajo.baja";
        private const string FROM = @" FROM data_sueldo
            INNER JOIN data_legajo ON data_sueldo.id_legajo = data_legajo.id";
        private const string WHERE1 = @" WHERE data_sueldo.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_sueldo.id_legajo = @id_legajo"; //Filtrar Objeto por ID Legajo
        private const string WHERE3 = @" WHERE data_sueldo.id_legajo = @id_legajo AND data_sueldo.id = (SELECT MAX(data_sueldo.id) FROM data_sueldo WHERE data_sueldo.id_legajo = @id_legajo AND data_sueldo.estado <> 'ANULADO')"; //Filtrar Objeto por ID Legajo (obtiene el registro más reciente y No anulado)
        private const string WHERE4 = @" WHERE data_legajo.cuit = @cuit"; //Filtrar Objeto por CUIL/CUIT
        private const string WHERE5 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE6 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion) AND data_sueldo.estado = @estado"; //Filtrar Objeto por Denominación y Estado
        private const string WHERE7 = @" WHERE periodo = @periodo"; //Filtrar Objeto por Periodo
        private const string WHERE8 = @" WHERE periodo = @periodo AND data_sueldo.estado = @estado"; //Filtrar Objeto por Periodo y Estado
        private const string WHERE9 = @" WHERE date(fecha_emision) >= date(@desde) AND date(fecha_emision) <= date(@hasta)"; //Filtrar Objeto por Fecha de Emisión
        private const string WHERE10 = @" WHERE date(fecha_emision) >= date(@desde) AND date(fecha_emision) <= date(@hasta) AND data_sueldo.estado = @estado"; //Filtrar Objeto por Fecha de Emisión y Estado
        private const string ORDER = @" ORDER BY data_sueldo.fecha_emision DESC, data_legajo.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_sueldo WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ANULAR = @"SELECT * FROM data_sueldo WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_sueldo WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_sueldo SET 
            id = @id,
            fecha_emision = @fecha_emision,
            periodo = @periodo,
            estado = @estado,
            id_legajo = @id_legajo,
            id_centro_costo = @id_centro_costo,
            id_sindicato = @id_sindicato,
            sueldo_bruto = @sueldo_bruto,
            sac = @sac,
            no_remunerativo = @no_remunerativo,
            indemnizacion_nr = @indemnizacion_nr,
            anticipo_sueldo = @anticipo_sueldo,
            embargo = @embargo,
            aporte = @aporte,
            aporte_sindicato = @aporte_sindicato,
            imp_ganancia = @imp_ganancia,
            sueldo_neto = @sueldo_neto,
            contribucion_patronal = @contribucion_patronal,
            art_scvo = @art_scvo,
            fcl = @fcl,
            observacion = @observacion,
            edicion_fecha = @edicion_fecha, 
            edicion_usuario_id = @edicion_usuario_id, 
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ANULAR = @"UPDATE data_sueldo SET estado = 'ANULADO' WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_sueldo (id, fecha_emision, periodo, estado, id_legajo,
            id_centro_costo, id_sindicato, sueldo_bruto, sac, no_remunerativo, indemnizacion_nr, anticipo_sueldo,
            embargo, aporte, aporte_sindicato, imp_ganancia, sueldo_neto, contribucion_patronal, art_scvo, fcl, 
            observacion, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @fecha_emision, @periodo, @estado, @id_legajo, @id_centro_costo, @id_sindicato, @sueldo_bruto, 
            @sac, @no_remunerativo, @indemnizacion_nr, @anticipo_sueldo, @embargo, @aporte, @aporte_sindicato, 
            @imp_ganancia, @sueldo_neto, @contribucion_patronal, @art_scvo, @fcl, @observacion, @edicion_fecha,
            @edicion_usuario_id, @edicion_usuario)";
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
                                            " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                       Convert.ToInt64(lectorDB["id"]),
                                       Convert.ToString(lectorDB["periodo"]).Replace("-", "~").PadLeft(7, ' ') +
                                           " | " + Convert.ToString(lectorDB["estado"]).PadRight(10, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["sueldo_bruto"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["sac"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["no_remunerativo"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["indemnizacion_nr"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["anticipo_sueldo"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["embargo"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["aporte"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["aporte_sindicato"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["imp_ganancia"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["sueldo_neto"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["contribucion_patronal"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["art_scvo"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["fcl"])).PadRight(11, ' ') +
                                           " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002SUELDO: Hay un conflicto en la consulta de sueldos.", e); }
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
                                            " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                       Convert.ToInt64(lectorDB["id"]),
                                       Convert.ToString(lectorDB["periodo"]).Replace("-", "~").PadLeft(7, ' ') +
                                           " | " + Convert.ToString(lectorDB["estado"]).PadRight(10, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["sueldo_bruto"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["sac"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["no_remunerativo"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["indemnizacion_nr"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["anticipo_sueldo"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["embargo"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["aporte"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["aporte_sindicato"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["imp_ganancia"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["sueldo_neto"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["contribucion_patronal"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["art_scvo"])).PadRight(11, ' ') +
                                           " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["fcl"])).PadRight(11, ' ') +
                                           " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004SUELDO: Hay un conflicto en la consulta de sueldos", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<Sueldo> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "CUIT") condicional = WHERE4; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Denominación y/o Estado
            if (campo == "PERIODO") condicional = ((estado != "TODOS") ? WHERE8 : WHERE7); //Consulta filtrada por Periodo y/o Estado
            List<Sueldo> ListaDeObjetos = new List<Sueldo>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                Sueldo objSueldo = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objSueldo); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006SUELDO: Hay un conflicto en la consulta de sueldos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<Sueldo> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            string condicional = "";
            if (campo == "FECHA") condicional = ((estado != "TODOS") ? WHERE10 : WHERE9); //Consulta filtrada por Fecha de Emisión y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            List<Sueldo> ListaDeObjetos = new List<Sueldo>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                Sueldo objSueldo = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objSueldo); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008SUELDO: Hay un conflicto en la consulta de sueldos", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public Sueldo obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            if (campo == "ID_LEGAJO") condicional = WHERE2; //Consulta filtrada por ID Legajo
            if (campo == "ID_LEGAJO_RECIENTE") condicional = WHERE3; //Consulta filtrada por ID Legajo (obtiene el registro más reciente y No anulado)
            if (campo == "CUIT") condicional = WHERE4; //Consulta filtrada por CUIL/CUIT
            Sueldo objSueldo = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objSueldo = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos del sueldo e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010SUELDO: Hay un conflicto en la consulta del sueldo.", e); }
            finally { _conexion.Dispose(); }
            return objSueldo;
        }

        public bool actualizar(Sueldo objSueldo)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objSueldo.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objSueldo.Id);
                                comandoDB_update.Parameters.AddWithValue("@fecha_emision", objSueldo.FechaEmision);
                                comandoDB_update.Parameters.AddWithValue("@periodo", objSueldo.Periodo);
                                comandoDB_update.Parameters.AddWithValue("@estado", objSueldo.Estado);
                                comandoDB_update.Parameters.AddWithValue("@id_legajo", objSueldo.Legajo.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_centro_costo", objSueldo.CentroCosto.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_sindicato", objSueldo.Sindicato.Id);
                                comandoDB_update.Parameters.AddWithValue("@sueldo_bruto", objSueldo.SueldoBruto);
                                comandoDB_update.Parameters.AddWithValue("@sac", objSueldo.Sac);
                                comandoDB_update.Parameters.AddWithValue("@no_remunerativo", objSueldo.NoRemunerativo);
                                comandoDB_update.Parameters.AddWithValue("@indemnizacion_nr", objSueldo.IndemnizacionNR);
                                comandoDB_update.Parameters.AddWithValue("@anticipo_sueldo", objSueldo.AnticipoSueldo);
                                comandoDB_update.Parameters.AddWithValue("@embargo", objSueldo.Embargo);
                                comandoDB_update.Parameters.AddWithValue("@aporte", objSueldo.Aporte);
                                comandoDB_update.Parameters.AddWithValue("@aporte_sindicato", objSueldo.AporteSindicato);
                                comandoDB_update.Parameters.AddWithValue("@imp_ganancia", objSueldo.ImpuestoGanancia);
                                comandoDB_update.Parameters.AddWithValue("@sueldo_neto", objSueldo.SueldoNeto);
                                comandoDB_update.Parameters.AddWithValue("@contribucion_patronal", objSueldo.ContribucionPatronal);
                                comandoDB_update.Parameters.AddWithValue("@art_scvo", objSueldo.ArtScvo);
                                comandoDB_update.Parameters.AddWithValue("@fcl", objSueldo.FondoCeseLaboral);
                                comandoDB_update.Parameters.AddWithValue("@observacion", objSueldo.Observacion);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objSueldo.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objSueldo.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objSueldo.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Sueldos", "Modificó el registro Id:" + objSueldo.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Inexistente.\nEl sueldo No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M012SUELDO", "M014SUELDO", "M016SUELDO", "M018SUELDO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool anular(Sueldo objSueldo)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ANULAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objSueldo.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ANULAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objSueldo.Id);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Sueldos", "Anuló el registro Id:" + objSueldo.Id + "."); //Registra la eliminación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Anulado.\nEl sueldo ya se encuentra anulado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M020SUELDO", "M022SUELDO", "M024SUELDO", "M026SUELDO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(Sueldo objSueldo)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objSueldo.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objSueldo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@fecha_emision", objSueldo.FechaEmision);
                                comandoDB_insert.Parameters.AddWithValue("@periodo", objSueldo.Periodo);
                                comandoDB_insert.Parameters.AddWithValue("@estado", objSueldo.Estado);
                                comandoDB_insert.Parameters.AddWithValue("@id_legajo", objSueldo.Legajo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_centro_costo", objSueldo.CentroCosto.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_sindicato", objSueldo.Sindicato.Id);
                                comandoDB_insert.Parameters.AddWithValue("@sueldo_bruto", objSueldo.SueldoBruto);
                                comandoDB_insert.Parameters.AddWithValue("@sac", objSueldo.Sac);
                                comandoDB_insert.Parameters.AddWithValue("@no_remunerativo", objSueldo.NoRemunerativo);
                                comandoDB_insert.Parameters.AddWithValue("@indemnizacion_nr", objSueldo.IndemnizacionNR);
                                comandoDB_insert.Parameters.AddWithValue("@anticipo_sueldo", objSueldo.AnticipoSueldo);
                                comandoDB_insert.Parameters.AddWithValue("@embargo", objSueldo.Embargo);
                                comandoDB_insert.Parameters.AddWithValue("@aporte", objSueldo.Aporte);
                                comandoDB_insert.Parameters.AddWithValue("@aporte_sindicato", objSueldo.AporteSindicato);
                                comandoDB_insert.Parameters.AddWithValue("@imp_ganancia", objSueldo.ImpuestoGanancia);
                                comandoDB_insert.Parameters.AddWithValue("@sueldo_neto", objSueldo.SueldoNeto);
                                comandoDB_insert.Parameters.AddWithValue("@contribucion_patronal", objSueldo.ContribucionPatronal);
                                comandoDB_insert.Parameters.AddWithValue("@art_scvo", objSueldo.ArtScvo);
                                comandoDB_insert.Parameters.AddWithValue("@fcl", objSueldo.FondoCeseLaboral);
                                comandoDB_insert.Parameters.AddWithValue("@observacion", objSueldo.Observacion);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objSueldo.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objSueldo.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objSueldo.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Sueldos", "Agregó un nuevo registro ID:" + objSueldo.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl sueldo ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M028SUELDO", "M030SUELDO", "M032SUELDO", "M034SUELDO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private Sueldo instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Sueldo(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToDateTime(lectorDB["fecha_emision"]),
                Convert.ToString(lectorDB["periodo"]),
                Convert.ToString(lectorDB["estado"]),
                new D_Legajo().obtenerObjeto("ID", Convert.ToString(lectorDB["id_legajo"]), false),
                new D_CentroCosto().obtenerObjeto("ID", Convert.ToString(lectorDB["id_centro_costo"]), false),
                new D_Sindicato().obtenerObjeto("ID", Convert.ToString(lectorDB["id_sindicato"]), false),
                Convert.ToDouble(lectorDB["sueldo_bruto"]),
                Convert.ToDouble(lectorDB["sac"]),
                Convert.ToDouble(lectorDB["no_remunerativo"]),
                Convert.ToDouble(lectorDB["indemnizacion_nr"]),
                Convert.ToDouble(lectorDB["anticipo_sueldo"]),
                Convert.ToDouble(lectorDB["embargo"]),
                Convert.ToDouble(lectorDB["aporte"]),
                Convert.ToDouble(lectorDB["aporte_sindicato"]),
                Convert.ToDouble(lectorDB["imp_ganancia"]),
                Convert.ToDouble(lectorDB["sueldo_neto"]),
                Convert.ToDouble(lectorDB["contribucion_patronal"]),
                Convert.ToDouble(lectorDB["art_scvo"]),
                Convert.ToDouble(lectorDB["fcl"]),
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