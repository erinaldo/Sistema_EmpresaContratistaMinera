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
    public class D_Legajo : ILegajo, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT1 = @"SELECT data_legajo.id, data_legajo.denominacion, documento,
            cuit, fecha_nacimiento, celular1, celular2, celular3, saldo, baja, informacion_restringida";
        private const string SELECT2 = @"SELECT data_legajo.*";
        private const string FROM = @" FROM data_legajo";
        private const string WHERE1 = @" WHERE data_legajo.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_legajo.cuit = @cuit"; //Filtrar Objeto por CUIL/CUIT
        private const string WHERE3 = @" WHERE data_legajo.cuit = @cuit AND data_legajo.baja = @baja"; //Filtrar Objeto por CUIL/CUIT y Baja
        private const string WHERE4 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE5 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion) AND data_legajo.baja = @baja"; //Filtrar Objeto por Denominación y Baja
        private const string ORDER = @" ORDER BY data_legajo.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_legajo WHERE documento = @documento AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_legajo WHERE documento = @documento"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_legajo SET 
            denominacion = @denominacion,
            sexo = @sexo,
            documento = @documento,
            cuit = @cuit,
            fecha_nacimiento = @fecha_nacimiento,
            tipo_sangre = @tipo_sangre,
            nacionalidad = @nacionalidad,
            estado_civil = @estado_civil,
            cantidad_hijo = @cantidad_hijo,
            domicilio = @domicilio,
            provincia = @provincia,
            distrito = @distrito,
            cp = @cp,
            comunidad = @comunidad,
            celular1 = @celular1,
            celular2 = @celular2,
            celular3 = @celular3,
            email = @email,
            cta_bancaria_id = @cta_bancaria_id,
            cta_bancaria_tipo = @cta_bancaria_tipo,
            cta_bancaria_nro = @cta_bancaria_nro,
            observacion = @observacion,
            saldo = @saldo,
            baja = @baja,
            informacion_restringida = @informacion_restringida,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ACTUALIZAR_ESTADO = @"UPDATE data_legajo SET baja = @baja WHERE id = @id";
        private const string ACTUALIZAR_SALDO = @"UPDATE data_legajo SET saldo = @saldo WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_legajo(id, denominacion, sexo, documento, cuit,
            fecha_nacimiento, tipo_sangre, nacionalidad, estado_civil, cantidad_hijo, domicilio, provincia, distrito,
            cp, comunidad, celular1, celular2, celular3, email, cta_bancaria_id, cta_bancaria_tipo, cta_bancaria_nro,
            observacion, saldo, baja, informacion_restringida, edicion_fecha, edicion_usuario_id, edicion_usuario) 
            VALUES (@id, @denominacion, @sexo, @documento, @cuit, @fecha_nacimiento, @tipo_sangre, @nacionalidad,
            @estado_civil, @cantidad_hijo, @domicilio, @provincia, @distrito, @cp, @comunidad, @celular1, @celular2,
            @celular3, @email, @cta_bancaria_id, @cta_bancaria_tipo, @cta_bancaria_nro, @observacion, @saldo, @baja,
            @informacion_restringida, @edicion_fecha, @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "CUIT") condicional = ((estado != "TODOS") ? WHERE3 : WHERE2); //Consulta filtrada por CUIL/CUIT y/o Baja
            if (campo == "DENOMINACION") condicional = ((estado != "TODOS") ? WHERE5 : WHERE4); //Consulta filtrada por Denominación y/o Baja
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (estado == "C/BAJA") comandoDB.Parameters.AddWithValue("@baja", "1"); //Agrega el parámetro en la condición del contador
                        if (estado == "S/BAJA") comandoDB.Parameters.AddWithValue("@baja", "0"); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (estado == "C/BAJA") comandoDB.Parameters.AddWithValue("@baja", "1"); //Agrega el parámetro en la condición de la consulta
                        if (estado == "S/BAJA") comandoDB.Parameters.AddWithValue("@baja", "0"); //Agrega el parámetro en la condición de la consulta
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
                                        (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["saldo"])).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    string celular1 = Convert.ToString(lectorDB["celular1"]).Trim();
                                    string celular2 = Convert.ToString(lectorDB["celular2"]).Trim();
                                    string celular3 = Convert.ToString(lectorDB["celular3"]).Trim();
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha_nacimiento"])).PadLeft(10, '0') +
                                            " | " + (celular1 + ((celular1.Length > 0 && celular2.Length > 0) ? ", " : "") + celular2 + (((celular1.Length > 0 || celular2.Length > 0) && celular3.Length > 0) ? ", " : "") + celular3).PadRight(43, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002LEGAJO_PERSONAL: Hay un conflicto en la consulta de legajos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<Legajo> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "CUIT") condicional = ((estado != "TODOS") ? WHERE3 : WHERE2); //Consulta filtrada por CUIL/CUIT y/o Baja
            if (campo == "DENOMINACION") condicional = ((estado != "TODOS") ? WHERE5 : WHERE4); //Consulta filtrada por Denominación y/o Baja
            List<Legajo> ListaDeObjetos = new List<Legajo>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega un parámetro al filtro
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega un parámetro al filtro
                        if (estado == "C/BAJA") comandoDB.Parameters.AddWithValue("@baja", "1"); //Agrega el parámetro en la condición de la consulta
                        if (estado == "S/BAJA") comandoDB.Parameters.AddWithValue("@baja", "0"); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Legajo objLegajo = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objLegajo); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004LEGAJO_PERSONAL: Hay un conflicto en la consulta de legajos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public Legajo obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "CUIT") condicional = WHERE2; //Consulta filtrada por CUIL/CUIT
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            Legajo objLegajo = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT2 + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega un parámetro al filtro
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objLegajo = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
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
            catch (MySqlException e) { Mensaje.Error("Error-M006LEGAJO_PERSONAL: Hay un conflicto en la consulta del legajo.", e); }
            finally { _conexion.Dispose(); }
            return objLegajo;
        }

        public bool actualizar(Legajo objLegajo)
       {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objLegajo.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@documento", objLegajo.Documento); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objLegajo.Id);
                                comandoDB_update.Parameters.AddWithValue("@denominacion", objLegajo.Denominacion);
                                comandoDB_update.Parameters.AddWithValue("@sexo", objLegajo.Sexo);
                                comandoDB_update.Parameters.AddWithValue("@documento", objLegajo.Documento);
                                comandoDB_update.Parameters.AddWithValue("@cuit", objLegajo.Cuit);
                                comandoDB_update.Parameters.AddWithValue("@fecha_nacimiento", objLegajo.FechaNacimiento);
                                comandoDB_update.Parameters.AddWithValue("@tipo_sangre", objLegajo.TipoSangre);
                                comandoDB_update.Parameters.AddWithValue("@nacionalidad", objLegajo.Nacionalidad);
                                comandoDB_update.Parameters.AddWithValue("@estado_civil", objLegajo.EstadoCivil);
                                comandoDB_update.Parameters.AddWithValue("@cantidad_hijo", objLegajo.CantidadHijo);
                                comandoDB_update.Parameters.AddWithValue("@domicilio", objLegajo.Domicilio);
                                comandoDB_update.Parameters.AddWithValue("@provincia", objLegajo.Provincia);
                                comandoDB_update.Parameters.AddWithValue("@distrito", objLegajo.Distrito);
                                comandoDB_update.Parameters.AddWithValue("@cp", objLegajo.Cp);
                                comandoDB_update.Parameters.AddWithValue("@comunidad", objLegajo.Comunidad);
                                comandoDB_update.Parameters.AddWithValue("@celular1", objLegajo.Celular1);
                                comandoDB_update.Parameters.AddWithValue("@celular2", objLegajo.Celular2);
                                comandoDB_update.Parameters.AddWithValue("@celular3", objLegajo.Celular3);
                                comandoDB_update.Parameters.AddWithValue("@email", objLegajo.Email);
                                comandoDB_update.Parameters.AddWithValue("@cta_bancaria_id", ((objLegajo.Banco != null) ? objLegajo.Banco.Id : 0));
                                comandoDB_update.Parameters.AddWithValue("@cta_bancaria_tipo", objLegajo.CtaBancariaTipo);
                                comandoDB_update.Parameters.AddWithValue("@cta_bancaria_nro", objLegajo.CtaBancariaNro);
                                comandoDB_update.Parameters.AddWithValue("@observacion", objLegajo.Observacion);
                                comandoDB_update.Parameters.AddWithValue("@saldo", objLegajo.Saldo);
                                comandoDB_update.Parameters.AddWithValue("@baja", objLegajo.Baja);
                                comandoDB_update.Parameters.AddWithValue("@informacion_restringida", objLegajo.InformacionRestringida);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objLegajo.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objLegajo.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objLegajo.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Legajos - Personal", "Modificó el registro Id:" + objLegajo.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl documento de identidad ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M008LEGAJO_PERSONAL", "M010LEGAJO_PERSONAL", "M012LEGAJO_PERSONAL", "M014LEGAJO_PERSONAL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool actualizarEstado(long id, bool baja, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + WHERE1)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR_ESTADO)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", id);
                                comandoDB.Parameters.AddWithValue("@baja", baja); //Agrega el parámetro en la condición de la consulta
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                if (notificarExito) Mensaje.Informacion("El nuevo estado del legajo Id:" + id.ToString() + "\nse registró correctamente.");
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro Existente.\nEl documento de identidad ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M016LEGAJO_PERSONAL", "M018LEGAJO_PERSONAL", "M020LEGAJO_PERSONAL", "M022LEGAJO_PERSONAL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool actualizarSaldo(long id, double saldo, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + WHERE1)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR_SALDO)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", id);
                                comandoDB_update.Parameters.AddWithValue("@saldo", saldo);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                if (notificarExito) Mensaje.Informacion("El nuevo saldo del legajo Id:" + id.ToString() + "\nse registró correctamente.");
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro Existente.\nEl documento de identidad ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M024LEGAJO_PERSONAL", "M026LEGAJO_PERSONAL", "M028LEGAJO_PERSONAL", "M030LEGAJO_PERSONAL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(Legajo objLegajo)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@documento", objLegajo.Documento); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objLegajo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@denominacion", objLegajo.Denominacion);
                                comandoDB_insert.Parameters.AddWithValue("@sexo", objLegajo.Sexo);
                                comandoDB_insert.Parameters.AddWithValue("@documento", objLegajo.Documento);
                                comandoDB_insert.Parameters.AddWithValue("@cuit", objLegajo.Cuit);
                                comandoDB_insert.Parameters.AddWithValue("@fecha_nacimiento", objLegajo.FechaNacimiento);
                                comandoDB_insert.Parameters.AddWithValue("@tipo_sangre", objLegajo.TipoSangre);
                                comandoDB_insert.Parameters.AddWithValue("@nacionalidad", objLegajo.Nacionalidad);
                                comandoDB_insert.Parameters.AddWithValue("@estado_civil", objLegajo.EstadoCivil);
                                comandoDB_insert.Parameters.AddWithValue("@cantidad_hijo", objLegajo.CantidadHijo);
                                comandoDB_insert.Parameters.AddWithValue("@domicilio", objLegajo.Domicilio);
                                comandoDB_insert.Parameters.AddWithValue("@provincia", objLegajo.Provincia);
                                comandoDB_insert.Parameters.AddWithValue("@distrito", objLegajo.Distrito);
                                comandoDB_insert.Parameters.AddWithValue("@cp", objLegajo.Cp);
                                comandoDB_insert.Parameters.AddWithValue("@comunidad", objLegajo.Comunidad);
                                comandoDB_insert.Parameters.AddWithValue("@celular1", objLegajo.Celular1);
                                comandoDB_insert.Parameters.AddWithValue("@celular2", objLegajo.Celular2);
                                comandoDB_insert.Parameters.AddWithValue("@celular3", objLegajo.Celular3);
                                comandoDB_insert.Parameters.AddWithValue("@email", objLegajo.Email);
                                comandoDB_insert.Parameters.AddWithValue("@cta_bancaria_id", ((objLegajo.Banco != null) ? objLegajo.Banco.Id : 0));
                                comandoDB_insert.Parameters.AddWithValue("@cta_bancaria_tipo", objLegajo.CtaBancariaTipo);
                                comandoDB_insert.Parameters.AddWithValue("@cta_bancaria_nro", objLegajo.CtaBancariaNro);
                                comandoDB_insert.Parameters.AddWithValue("@observacion", objLegajo.Observacion);
                                comandoDB_insert.Parameters.AddWithValue("@saldo", objLegajo.Saldo);
                                comandoDB_insert.Parameters.AddWithValue("@baja", objLegajo.Baja);
                                comandoDB_insert.Parameters.AddWithValue("@informacion_restringida", objLegajo.InformacionRestringida);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objLegajo.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objLegajo.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objLegajo.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Legajos - Personal", "Agregó un nuevo registro ID:" + objLegajo.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl legajo ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M032LEGAJO_PERSONAL", "M034LEGAJO_PERSONAL", "M036LEGAJO_PERSONAL", "M038LEGAJO_PERSONAL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private Legajo instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Legajo(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToString(lectorDB["sexo"]),
                Convert.ToInt64(lectorDB["documento"]),
                Convert.ToInt64(lectorDB["cuit"]),
                Convert.ToDateTime(lectorDB["fecha_nacimiento"]),
                Convert.ToString(lectorDB["tipo_sangre"]),
                Convert.ToString(lectorDB["nacionalidad"]),
                Convert.ToString(lectorDB["estado_civil"]),
                Convert.ToInt32(lectorDB["cantidad_hijo"]),
                Convert.ToString(lectorDB["domicilio"]),
                Convert.ToString(lectorDB["provincia"]),
                Convert.ToString(lectorDB["distrito"]),
                Convert.ToInt32(lectorDB["cp"]),
                Convert.ToBoolean(lectorDB["comunidad"]),
                Convert.ToString(lectorDB["celular1"]),
                Convert.ToString(lectorDB["celular2"]),
                Convert.ToString(lectorDB["celular3"]),
                Convert.ToString(lectorDB["email"]),
                ((Convert.ToInt32(lectorDB["cta_bancaria_id"]) > 0) ? new D_Banco().obtenerObjeto("ID", Convert.ToString(lectorDB["cta_bancaria_id"]), false) : new Banco(0, "")),
                Convert.ToString(lectorDB["cta_bancaria_tipo"]),
                Convert.ToString(lectorDB["cta_bancaria_nro"]),
                Convert.ToString(lectorDB["observacion"]),
                Convert.ToDouble(lectorDB["saldo"]),
                Convert.ToBoolean(lectorDB["baja"]),
                Convert.ToBoolean(lectorDB["informacion_restringida"]),
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
