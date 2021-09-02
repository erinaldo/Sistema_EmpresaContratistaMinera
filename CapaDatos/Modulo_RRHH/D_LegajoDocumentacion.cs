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
    public class D_LegajoDocumentacion : ILegajoDocumentacion, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_legajo_documentacion.*,
            data_legajo.denominacion, data_legajo.documento, data_legajo.cuit, data_legajo.baja";
        private const string FROM = @" FROM data_legajo_documentacion
            INNER JOIN data_legajo ON data_legajo_documentacion.id_legajo = data_legajo.id";
        private const string WHERE1 = @" WHERE data_legajo_documentacion.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_legajo_documentacion.id_legajo = @id_legajo"; //Filtrar Objeto por ID Legajo
        private const string WHERE3 = @" WHERE data_legajo.cuit = @cuit"; //Filtrar Objeto por CUIL/CUIT
        private const string WHERE4 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE5 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion) AND data_legajo.baja = @baja"; //Filtrar Objeto por Denominación y Baja
        private const string ORDER = @" ORDER BY data_legajo.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_legajo_documentacion WHERE id_legajo = @id_legajo AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_legajo_documentacion WHERE id_legajo = @id_legajo"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_legajo_documentacion SET 
            id = @id,
            id_legajo = @id_legajo,
            alta_afip = @alta_afip,
            contrato = @contrato,
            copia_ca = @copia_ca,
            copia_dni = @copia_dni,
            copia_lc = @copia_lc,
            copia_matricula = @copia_matricula,
            copia_titulo = @copia_titulo,
            credencial_art = @credencial_art,
            curriculum_vitae = @curriculum_vitae,
            ddjj = @ddjj,
            doc_familiar = @doc_familiar,
            examen_medico = @examen_medico,
            reglamento_rrhh = @reglamento_rrhh,
            roles = @roles,
            otra_documentacion = @otra_documentacion,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_legajo_documentacion(id, id_legajo, alta_afip, contrato,
            copia_ca, copia_dni, copia_lc, copia_matricula, copia_titulo, credencial_art, curriculum_vitae, ddjj,
            doc_familiar, examen_medico, reglamento_rrhh, roles, otra_documentacion, edicion_fecha, 
            edicion_usuario_id, edicion_usuario)
            VALUES (@id, @id_legajo, @alta_afip, @contrato, @copia_ca, @copia_dni, @copia_lc, @copia_matricula, 
            @copia_titulo, @credencial_art, @curriculum_vitae, @ddjj, @doc_familiar, @examen_medico, @reglamento_rrhh,
            @roles, @otra_documentacion, @edicion_fecha, @edicion_usuario_id, @edicion_usuario)";
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
                        if (estado == "C/BAJA") comandoDB.Parameters.AddWithValue("@baja", "1"); //Agrega el parámetro en la condición del contador
                        if (estado == "S/BAJA") comandoDB.Parameters.AddWithValue("@baja", "0"); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
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
                                       Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                       Convert.ToInt64(lectorDB["id"]),
                                       Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + ((Convert.ToBoolean(lectorDB["alta_afip"])) ? "AFIP " : "") +
                                                ((Convert.ToBoolean(lectorDB["contrato"])) ? "CONTR. " : "") +
                                                ((Convert.ToBoolean(lectorDB["copia_ca"])) ? "CA " : "") +
                                                ((Convert.ToBoolean(lectorDB["copia_dni"])) ? "DNI " : "") +
                                                ((Convert.ToBoolean(lectorDB["copia_lc"])) ? "Lic.C. " : "") +
                                                ((Convert.ToBoolean(lectorDB["copia_matricula"])) ? "MAT. " : "") +
                                                ((Convert.ToBoolean(lectorDB["copia_titulo"])) ? "TIT. " : "") +
                                                ((Convert.ToBoolean(lectorDB["credencial_art"])) ? "C.ART " : "") +
                                                ((Convert.ToBoolean(lectorDB["curriculum_vitae"])) ? "CV " : "") +
                                                ((Convert.ToBoolean(lectorDB["ddjj"])) ? "DDJJ " : "") +
                                                ((Convert.ToBoolean(lectorDB["doc_familiar"])) ? "DOC.F. " : "") +
                                                ((Convert.ToBoolean(lectorDB["examen_medico"])) ? "E.MED. " : "") +
                                                ((Convert.ToBoolean(lectorDB["reglamento_rrhh"])) ? "RRHH " : "") +
                                                ((Convert.ToBoolean(lectorDB["roles"])) ? "ROLES " : "") +
                                                ((Convert.ToString(lectorDB["otra_documentacion"]).Length > 0) ? "OTRA" : ""));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002LEGAJO_DOCUMENTACION: Hay un conflicto en la consulta de legajos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<LegajoDocumentacion> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "CUIT") condicional = WHERE3; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE5 : WHERE4; //Consulta filtrada por Denominación y/o Estado
            List<LegajoDocumentacion> ListaDeObjetos = new List<LegajoDocumentacion>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                LegajoDocumentacion objLegajoDocumentacion = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objLegajoDocumentacion); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004LEGAJO_DOCUMENTACION: Hay un conflicto en la consulta de legajos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public LegajoDocumentacion obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            if (campo == "ID_LEGAJO") condicional = WHERE2; //Consulta filtrada por ID Legajo
            if (campo == "CUIT") condicional = WHERE3; //Consulta filtrada por CUIL/CUIT
            LegajoDocumentacion objLegajoDocumentacion = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objLegajoDocumentacion = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
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
            catch (MySqlException e) { Mensaje.Error("Error-M006LEGAJO_DOCUMENTACION: Hay un conflicto en la consulta del legajo.", e); }
            finally { _conexion.Dispose(); }
            return objLegajoDocumentacion;
        }

        public bool actualizar(LegajoDocumentacion objLegajoDocumentacion)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objLegajoDocumentacion.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@id_legajo", objLegajoDocumentacion.Legajo.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objLegajoDocumentacion.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_legajo", objLegajoDocumentacion.Legajo.Id);
                                comandoDB_update.Parameters.AddWithValue("@alta_afip", objLegajoDocumentacion.AltaAfip);
                                comandoDB_update.Parameters.AddWithValue("@contrato", objLegajoDocumentacion.Contrato);
                                comandoDB_update.Parameters.AddWithValue("@copia_ca", objLegajoDocumentacion.CopiaCA);
                                comandoDB_update.Parameters.AddWithValue("@copia_dni", objLegajoDocumentacion.CopiaDNI);
                                comandoDB_update.Parameters.AddWithValue("@copia_lc", objLegajoDocumentacion.CopiaLicenciaConducir);
                                comandoDB_update.Parameters.AddWithValue("@copia_matricula", objLegajoDocumentacion.CopiaMatricula);
                                comandoDB_update.Parameters.AddWithValue("@copia_titulo", objLegajoDocumentacion.CopiaTitulo);
                                comandoDB_update.Parameters.AddWithValue("@credencial_art", objLegajoDocumentacion.CredencialART);
                                comandoDB_update.Parameters.AddWithValue("@curriculum_vitae", objLegajoDocumentacion.CurriculumVitae);
                                comandoDB_update.Parameters.AddWithValue("@ddjj", objLegajoDocumentacion.DeclaracionJurada);
                                comandoDB_update.Parameters.AddWithValue("@doc_familiar", objLegajoDocumentacion.DocumentacionFamiliar);
                                comandoDB_update.Parameters.AddWithValue("@examen_medico", objLegajoDocumentacion.ExamenMedico);
                                comandoDB_update.Parameters.AddWithValue("@reglamento_rrhh", objLegajoDocumentacion.ReglamentoRRHH);
                                comandoDB_update.Parameters.AddWithValue("@roles", objLegajoDocumentacion.Roles);
                                comandoDB_update.Parameters.AddWithValue("@otra_documentacion", objLegajoDocumentacion.OtraDocumentacion);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objLegajoDocumentacion.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objLegajoDocumentacion.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objLegajoDocumentacion.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Legajos - Documentación", "Modificó el registro Id:" + objLegajoDocumentacion.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nLa documentacion del legajo ya se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M008LEGAJO_DOCUMENTACION", "M010LEGAJO_DOCUMENTACION", "M012LEGAJO_DOCUMENTACION", "M014LEGAJO_DOCUMENTACION", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(LegajoDocumentacion objLegajoDocumentacion)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_legajo", objLegajoDocumentacion.Legajo.Id); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objLegajoDocumentacion.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_legajo", objLegajoDocumentacion.Legajo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@alta_afip", objLegajoDocumentacion.AltaAfip);
                                comandoDB_insert.Parameters.AddWithValue("@contrato", objLegajoDocumentacion.Contrato);
                                comandoDB_insert.Parameters.AddWithValue("@copia_ca", objLegajoDocumentacion.CopiaCA);
                                comandoDB_insert.Parameters.AddWithValue("@copia_dni", objLegajoDocumentacion.CopiaDNI);
                                comandoDB_insert.Parameters.AddWithValue("@copia_lc", objLegajoDocumentacion.CopiaLicenciaConducir);
                                comandoDB_insert.Parameters.AddWithValue("@copia_matricula", objLegajoDocumentacion.CopiaMatricula);
                                comandoDB_insert.Parameters.AddWithValue("@copia_titulo", objLegajoDocumentacion.CopiaTitulo);
                                comandoDB_insert.Parameters.AddWithValue("@credencial_art", objLegajoDocumentacion.CredencialART);
                                comandoDB_insert.Parameters.AddWithValue("@curriculum_vitae", objLegajoDocumentacion.CurriculumVitae);
                                comandoDB_insert.Parameters.AddWithValue("@ddjj", objLegajoDocumentacion.DeclaracionJurada);
                                comandoDB_insert.Parameters.AddWithValue("@doc_familiar", objLegajoDocumentacion.DocumentacionFamiliar);
                                comandoDB_insert.Parameters.AddWithValue("@examen_medico", objLegajoDocumentacion.ExamenMedico);
                                comandoDB_insert.Parameters.AddWithValue("@reglamento_rrhh", objLegajoDocumentacion.ReglamentoRRHH);
                                comandoDB_insert.Parameters.AddWithValue("@roles", objLegajoDocumentacion.Roles);
                                comandoDB_insert.Parameters.AddWithValue("@otra_documentacion", objLegajoDocumentacion.OtraDocumentacion);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objLegajoDocumentacion.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objLegajoDocumentacion.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objLegajoDocumentacion.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Legajos - Documentación", "Agregó un nuevo registro ID:" + objLegajoDocumentacion.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nLa documentación del legajo ya se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M016LEGAJO_DOCUMENTACION", "M018LEGAJO_DOCUMENTACION", "M020LEGAJO_DOCUMENTACION", "M022LEGAJO_DOCUMENTACION", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private LegajoDocumentacion instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new LegajoDocumentacion(
                Convert.ToInt64(lectorDB["id"]),
                new D_Legajo().obtenerObjeto("ID", Convert.ToString(lectorDB["id_legajo"]), false),
                Convert.ToBoolean(lectorDB["alta_afip"]),
                Convert.ToBoolean(lectorDB["contrato"]),
                Convert.ToBoolean(lectorDB["copia_ca"]),
                Convert.ToBoolean(lectorDB["copia_dni"]),
                Convert.ToBoolean(lectorDB["copia_lc"]),
                Convert.ToBoolean(lectorDB["copia_matricula"]),
                Convert.ToBoolean(lectorDB["copia_titulo"]),
                Convert.ToBoolean(lectorDB["credencial_art"]),
                Convert.ToBoolean(lectorDB["curriculum_vitae"]),
                Convert.ToBoolean(lectorDB["ddjj"]),
                Convert.ToBoolean(lectorDB["doc_familiar"]),
                Convert.ToBoolean(lectorDB["examen_medico"]),
                Convert.ToBoolean(lectorDB["reglamento_rrhh"]),
                Convert.ToBoolean(lectorDB["roles"]),
                Convert.ToString(lectorDB["otra_documentacion"]),
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
