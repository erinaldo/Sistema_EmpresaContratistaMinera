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
    public class D_LegajoCurriculumVitae : ILegajoCurriculumVitae, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_legajo_curriculum_vitae.*,
            data_legajo.denominacion, data_legajo.documento, data_legajo.cuit, data_legajo.baja";
        private const string FROM = @" FROM data_legajo_curriculum_vitae
            INNER JOIN data_legajo ON data_legajo_curriculum_vitae.id_legajo = data_legajo.id";
        private const string WHERE1 = @" WHERE data_legajo_curriculum_vitae.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_legajo_curriculum_vitae.id_legajo = @id_legajo"; //Filtrar Objeto por ID Legajo
        private const string WHERE3 = @" WHERE data_legajo.cuit = @cuit"; //Filtrar Objeto por CUIL/CUIT
        private const string WHERE4 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE5 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion) AND data_legajo.baja = @baja"; //Filtrar Objeto por Denominación y Baja
        private const string ORDER = @" ORDER BY data_legajo.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_legajo_curriculum_vitae WHERE id_legajo = @id_legajo AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_legajo_curriculum_vitae WHERE id_legajo = @id_legajo"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_legajo_curriculum_vitae SET 
            id = @id,
            id_legajo = @id_legajo,
            modalidad_admision = @modalidad_admision,
            nivel_estudio = @nivel_estudio,
            experiencia = @experiencia,
            trabajo_empreminsa = @trabajo_empreminsa,
            lic_conducir = @lic_conducir,
            lic_conducir_cat = @lic_conducir_cat,
            lic_conducir_color = @lic_conducir_color,
            lic_conducir_vto = @lic_conducir_vto,
            lic_conducir_alertado = @lic_conducir_alertado,
            cert_antecedentes = @cert_antecedentes,
            cert_antecedentes_tipo = @cert_antecedentes_tipo,
            cert_antecedentes_emision = @cert_antecedentes_emision,
            cert_antecedentes_alertado = @cert_antecedentes_alertado,
            cv_disponibilidad = @cv_disponibilidad,
            cv_calificacion = @cv_calificacion,
            cv_estado = @cv_estado,
            cv_vto = @cv_vto,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_legajo_curriculum_vitae(id, id_legajo, modalidad_admision, 
            nivel_estudio, experiencia, trabajo_empreminsa, lic_conducir, lic_conducir_cat, lic_conducir_color,
            lic_conducir_vto, lic_conducir_alertado, cert_antecedentes, cert_antecedentes_tipo, cert_antecedentes_emision,
            cert_antecedentes_alertado, cv_disponibilidad, cv_calificacion, cv_estado, cv_vto, edicion_fecha,
            edicion_usuario_id, edicion_usuario) 
            VALUES (@id, @id_legajo, @modalidad_admision, @nivel_estudio, @experiencia, @trabajo_empreminsa, 
            @lic_conducir, @lic_conducir_cat, @lic_conducir_color, @lic_conducir_vto, @lic_conducir_alertado,
            @cert_antecedentes, @cert_antecedentes_tipo, @cert_antecedentes_emision, @cert_antecedentes_alertado, 
            @cv_disponibilidad, @cv_calificacion, @cv_estado, @cv_vto, @edicion_fecha, @edicion_usuario_id,
            @edicion_usuario)";
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
                                        " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                        " | " + Convert.ToString(lectorDB["cv_estado"]).PadRight(10, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                       Convert.ToInt64(lectorDB["id"]),
                                            Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + Convert.ToString(lectorDB["modalidad_admision"]).PadRight(23, ' ') +
                                            " | " + ((Convert.ToBoolean(lectorDB["trabajo_empreminsa"])) ? "SI, TRABAJÓ" : "NO, TRABAJÓ").PadRight(11, ' ') +
                                            " | " + Convert.ToString(lectorDB["cv_disponibilidad"]).PadRight(5, ' ') +
                                            " | " + Convert.ToString(lectorDB["cv_calificacion"]).PadRight(14, ' ') +
                                            " | " + Convert.ToString(lectorDB["cv_estado"]).PadRight(10, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cv_vto"])).PadLeft(10, '0'));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002LEGAJO_CV: Hay un conflicto en la consulta de legajos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<LegajoCurriculumVitae> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "CUIT") condicional = WHERE3; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE5 : WHERE4; //Consulta filtrada por Denominación y/o Estado
            List<LegajoCurriculumVitae> ListaDeObjetos = new List<LegajoCurriculumVitae>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                LegajoCurriculumVitae objLegajoCurriculumVitae = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objLegajoCurriculumVitae); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004LEGAJO_CV: Hay un conflicto en la consulta de legajos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public LegajoCurriculumVitae obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            if (campo == "ID_LEGAJO") condicional = WHERE2; //Consulta filtrada por ID Legajo
            if (campo == "CUIT") condicional = WHERE3; //Consulta filtrada por CUIL/CUIT
            LegajoCurriculumVitae objLegajoCurriculumVitae = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objLegajoCurriculumVitae = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
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
            catch (MySqlException e) { Mensaje.Error("Error-M006LEGAJO_CV: Hay un conflicto en la consulta del legajo.", e); }
            finally { _conexion.Dispose(); }
            return objLegajoCurriculumVitae;
        }

        public bool actualizar(LegajoCurriculumVitae objLegajoCurriculumVitae)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objLegajoCurriculumVitae.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@id_legajo", objLegajoCurriculumVitae.Legajo.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objLegajoCurriculumVitae.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_legajo", objLegajoCurriculumVitae.Legajo.Id);
                                comandoDB_update.Parameters.AddWithValue("@modalidad_admision", objLegajoCurriculumVitae.ModalidadAdmision);
                                comandoDB_update.Parameters.AddWithValue("@nivel_estudio", objLegajoCurriculumVitae.NivelEstudio);
                                comandoDB_update.Parameters.AddWithValue("@experiencia", objLegajoCurriculumVitae.Experiencia);
                                comandoDB_update.Parameters.AddWithValue("@trabajo_empreminsa", objLegajoCurriculumVitae.TrabajoEmpreminsa);
                                comandoDB_update.Parameters.AddWithValue("@lic_conducir", objLegajoCurriculumVitae.LicenciaConducir);
                                comandoDB_update.Parameters.AddWithValue("@lic_conducir_cat", objLegajoCurriculumVitae.LicenciaConducirCategoria);
                                comandoDB_update.Parameters.AddWithValue("@lic_conducir_color", objLegajoCurriculumVitae.LicenciaConducirColor);
                                comandoDB_update.Parameters.AddWithValue("@lic_conducir_vto", objLegajoCurriculumVitae.LicenciaConducirVto);
                                comandoDB_update.Parameters.AddWithValue("@lic_conducir_alertado", objLegajoCurriculumVitae.LicenciaConducirAlertado);
                                comandoDB_update.Parameters.AddWithValue("@cert_antecedentes", objLegajoCurriculumVitae.CertificadoAntecedente);
                                comandoDB_update.Parameters.AddWithValue("@cert_antecedentes_tipo", objLegajoCurriculumVitae.CertificadoAntecedenteTipo);
                                comandoDB_update.Parameters.AddWithValue("@cert_antecedentes_emision", objLegajoCurriculumVitae.CertificadoAntecedenteEmision);
                                comandoDB_update.Parameters.AddWithValue("@cert_antecedentes_alertado", objLegajoCurriculumVitae.CertificadoAntecedenteAlertado);
                                comandoDB_update.Parameters.AddWithValue("@cv_disponibilidad", objLegajoCurriculumVitae.CurriculumVitaeDisponibilidad);
                                comandoDB_update.Parameters.AddWithValue("@cv_calificacion", objLegajoCurriculumVitae.CurriculumVitaeCalificacion);
                                comandoDB_update.Parameters.AddWithValue("@cv_estado", objLegajoCurriculumVitae.CurriculumVitaeEstado);
                                comandoDB_update.Parameters.AddWithValue("@cv_vto", objLegajoCurriculumVitae.CurriculumVitaeVto);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objLegajoCurriculumVitae.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objLegajoCurriculumVitae.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objLegajoCurriculumVitae.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Legajos - Currículum Vitae", "Modificó el registro Id:" + objLegajoCurriculumVitae.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl currículum vitae ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M008LEGAJO_CV", "M010LEGAJO_CV", "M012LEGAJO_CV", "M014LEGAJO_CV", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(LegajoCurriculumVitae objLegajoCurriculumVitae)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_legajo", objLegajoCurriculumVitae.Legajo.Id); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objLegajoCurriculumVitae.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_legajo", objLegajoCurriculumVitae.Legajo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@modalidad_admision", objLegajoCurriculumVitae.ModalidadAdmision);
                                comandoDB_insert.Parameters.AddWithValue("@nivel_estudio", objLegajoCurriculumVitae.NivelEstudio);
                                comandoDB_insert.Parameters.AddWithValue("@experiencia", objLegajoCurriculumVitae.Experiencia);
                                comandoDB_insert.Parameters.AddWithValue("@trabajo_empreminsa", objLegajoCurriculumVitae.TrabajoEmpreminsa);
                                comandoDB_insert.Parameters.AddWithValue("@lic_conducir", objLegajoCurriculumVitae.LicenciaConducir);
                                comandoDB_insert.Parameters.AddWithValue("@lic_conducir_cat", objLegajoCurriculumVitae.LicenciaConducirCategoria);
                                comandoDB_insert.Parameters.AddWithValue("@lic_conducir_color", objLegajoCurriculumVitae.LicenciaConducirColor);
                                comandoDB_insert.Parameters.AddWithValue("@lic_conducir_vto", objLegajoCurriculumVitae.LicenciaConducirVto);
                                comandoDB_insert.Parameters.AddWithValue("@lic_conducir_alertado", objLegajoCurriculumVitae.LicenciaConducirAlertado);
                                comandoDB_insert.Parameters.AddWithValue("@cert_antecedentes", objLegajoCurriculumVitae.CertificadoAntecedente);
                                comandoDB_insert.Parameters.AddWithValue("@cert_antecedentes_tipo", objLegajoCurriculumVitae.CertificadoAntecedenteTipo);
                                comandoDB_insert.Parameters.AddWithValue("@cert_antecedentes_emision", objLegajoCurriculumVitae.CertificadoAntecedenteEmision);
                                comandoDB_insert.Parameters.AddWithValue("@cert_antecedentes_alertado", objLegajoCurriculumVitae.CertificadoAntecedenteAlertado);
                                comandoDB_insert.Parameters.AddWithValue("@cv_disponibilidad", objLegajoCurriculumVitae.CurriculumVitaeDisponibilidad);
                                comandoDB_insert.Parameters.AddWithValue("@cv_calificacion", objLegajoCurriculumVitae.CurriculumVitaeCalificacion);
                                comandoDB_insert.Parameters.AddWithValue("@cv_estado", objLegajoCurriculumVitae.CurriculumVitaeEstado);
                                comandoDB_insert.Parameters.AddWithValue("@cv_vto", objLegajoCurriculumVitae.CurriculumVitaeVto);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objLegajoCurriculumVitae.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objLegajoCurriculumVitae.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objLegajoCurriculumVitae.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Legajos - Currículum Vitae", "Agregó un nuevo registro ID:" + objLegajoCurriculumVitae.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl currículum vitae ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M016LEGAJO_CV", "M018LEGAJO_CV", "M020LEGAJO_CV", "M022LEGAJO_CV", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private LegajoCurriculumVitae instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new LegajoCurriculumVitae(
                Convert.ToInt64(lectorDB["id"]),
                new D_Legajo().obtenerObjeto("ID", Convert.ToString(lectorDB["id_legajo"]), false),
                Convert.ToString(lectorDB["modalidad_admision"]),
                Convert.ToString(lectorDB["nivel_estudio"]),
                Convert.ToString(lectorDB["experiencia"]),
                Convert.ToBoolean(lectorDB["trabajo_empreminsa"]),
                Convert.ToBoolean(lectorDB["lic_conducir"]),
                Convert.ToString(lectorDB["lic_conducir_cat"]),
                Convert.ToString(lectorDB["lic_conducir_color"]),
                Convert.ToDateTime(lectorDB["lic_conducir_vto"]),
                Convert.ToBoolean(lectorDB["lic_conducir_alertado"]),
                Convert.ToBoolean(lectorDB["cert_antecedentes"]),
                Convert.ToString(lectorDB["cert_antecedentes_tipo"]),
                Convert.ToDateTime(lectorDB["cert_antecedentes_emision"]),
                Convert.ToBoolean(lectorDB["cert_antecedentes_alertado"]),
                Convert.ToString(lectorDB["cv_disponibilidad"]),
                Convert.ToString(lectorDB["cv_calificacion"]),
                Convert.ToString(lectorDB["cv_estado"]),
                Convert.ToDateTime(lectorDB["cv_vto"]),
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
