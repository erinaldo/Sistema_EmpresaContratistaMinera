using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_BusquedaPostulante : IBusquedaPostulante, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT DISTINCT data_legajo.id, data_legajo.denominacion, data_legajo.cuit,
            data_legajo.celular1, data_legajo.celular2, data_legajo.celular3,          
            cat_perfil_laboral.denominacion AS perfil_laboral,
            data_legajo_curriculum_vitae.trabajo_empreminsa,
            data_legajo_curriculum_vitae.cv_disponibilidad,
            data_legajo_curriculum_vitae.cv_calificacion,
            data_legajo_curriculum_vitae.cv_estado,
            data_legajo_curriculum_vitae.cert_antecedentes_emision,
            data_legajo_curriculum_vitae.cert_antecedentes_tipo,
            data_legajo_curriculum_vitae.lic_conducir_vto,
            data_curso_induccion.fecha_emision AS curso_induccion_emision,
            data_curso_induccion.evaluacion AS curso_induccion_evaluacion,
            data_curso_izaje.fecha_emision AS curso_izaje_emision,
            data_examen_medico.examen_emision AS examen_medico_emision,
            data_examen_medico.evaluacion_medica AS examen_medico_evaluacion,
            data_examen_medico.tipo_examen AS examen_medico_tipo";
        private const string FROM = @" FROM data_legajo
            LEFT JOIN data_legajo_laboral ON (data_legajo.id = data_legajo_laboral.id_legajo AND data_legajo_laboral.estado = 'INACTIVO')
            INNER JOIN relation_curriculum_vitae__perfil_laboral ON data_legajo.id = relation_curriculum_vitae__perfil_laboral.id_legajo
            INNER JOIN cat_perfil_laboral ON relation_curriculum_vitae__perfil_laboral.id_perfil_laboral = cat_perfil_laboral.id
            INNER JOIN data_legajo_curriculum_vitae ON (data_legajo.id = data_legajo_curriculum_vitae.id_legajo AND data_legajo_laboral.estado = 'INACTIVO')
            LEFT JOIN data_curso_induccion ON data_legajo.id = data_curso_induccion.id_legajo
            LEFT JOIN data_curso_izaje ON data_legajo.id = data_curso_izaje.id_legajo
            LEFT JOIN data_examen_medico ON data_legajo.id = data_examen_medico.id_legajo";
        private const string WHERE1 = @" WHERE data_legajo.baja = 0 AND cat_perfil_laboral.denominacion = @perfil_laboral AND data_legajo.id = @id"; //Filtrar Objeto por sin Baja y Perfil Laboral y ID
        private const string WHERE2 = @" WHERE data_legajo.baja = 0 AND cat_perfil_laboral.denominacion = @perfil_laboral"; //Filtrar Objeto por sin Baja y Perfil Laboral
        private const string AND1 = @" AND data_legajo_curriculum_vitae.trabajo_empreminsa = @trabajo_empreminsa"; //Filtrar Objeto por Trabajó en Empreminsa
        private const string AND2 = @" AND data_legajo_curriculum_vitae.cv_disponibilidad = @cv_disponibilidad"; //Filtrar Objeto por Disponibilidad
        private const string AND3 = @" AND data_legajo_curriculum_vitae.cv_calificacion = @cv_calificacion"; //Filtrar Objeto por Disponibilidad
        private const string AND4 = @" AND data_legajo_curriculum_vitae.cv_estado = 'VIGENTE'"; //Filtrar Objeto por Estado (CV)
        private const string AND5 = @" AND (data_legajo_curriculum_vitae.cert_antecedentes = 1 AND date(data_legajo_curriculum_vitae.cert_antecedentes_emision) >= date(@cert_antecedentes_emision))"; //Filtrar Objeto por Certificado de Antecedentes
        private const string AND6 = @" AND (data_legajo_curriculum_vitae.lic_conducir = 1 AND date(data_legajo_curriculum_vitae.lic_conducir_vto) >= date(@lic_conducir_vto))"; //Filtrar Objeto por Licencia de Conducir
        private const string AND7 = @" AND data_curso_induccion.id = (SELECT MAX(data_curso_induccion.id) FROM data_curso_induccion	WHERE data_curso_induccion.id_legajo = data_legajo.id AND data_curso_induccion.estado = 'VIGENTE' AND data_curso_induccion.evaluacion = 'APROBADO')"; //Filtrar Objeto por Curso de Inducción
        private const string AND8 = @" AND data_curso_izaje.id = (SELECT MAX(data_curso_izaje.id) FROM data_curso_izaje WHERE data_curso_izaje.id_legajo = data_legajo.id AND data_curso_izaje.estado = 'VIGENTE')"; //Filtrar Objeto por Curso de Izaje
        private const string AND9 = @" AND data_examen_medico.id = (SELECT MAX(data_examen_medico.id) FROM data_examen_medico WHERE data_examen_medico.id_legajo = data_legajo.id AND data_examen_medico.estado = 'VIGENTE' AND data_examen_medico.evaluacion_medica = 'APTO')"; //Filtrar Objeto por Examen Médico
        private const string ORDER = @" ORDER BY data_legajo.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string perfilLaboral, bool trabajoEmpreminsa, string disponibilidadCV, string calificacionCV, bool estadoCV, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = WHERE2;
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (trabajoEmpreminsa) condicional += AND1; //Consulta filtrada por Trabajó en Empreminsa
            if (disponibilidadCV != "TODOS") condicional += AND2; //Consulta filtrada por Disponibilidad Laboral
            if (calificacionCV != "TODOS") condicional += AND3; //Consulta filtrada por Calificación Laboral
            if (estadoCV) condicional += AND4; //Consulta filtrada por Estado del CV
            if (certificadoAntecedentes) condicional += AND5; //Consulta filtrada por Certificado de Antecedentes vigente
            if (licenciaConducir) condicional += AND6; //Consulta filtrada por Licencia de Conducir vigente
            if (cursoInduccion) condicional += AND7; //Consulta filtrada Curso de Induccion vigente y aprobado
            if (cursoIzaje) condicional += AND8; //Consulta filtrada por Curso de Izaje vigente
            if (examenMedico) condicional += AND9; //Consulta filtrada por Examen Médico vigente y apto
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@perfil_laboral", perfilLaboral); //Agrega el parámetro en la condición del contador
                        if (trabajoEmpreminsa) comandoDB.Parameters.AddWithValue("@trabajo_empreminsa", trabajoEmpreminsa); //Agrega el parámetro en la condición del contador
                        if (disponibilidadCV != "TODOS") comandoDB.Parameters.AddWithValue("@cv_disponibilidad", disponibilidadCV); //Agrega el parámetro en la condición del contador
                        if (calificacionCV != "TODOS") comandoDB.Parameters.AddWithValue("@cv_calificacion", calificacionCV); //Agrega el parámetro en la condición del contador
                        if (certificadoAntecedentes) comandoDB.Parameters.AddWithValue("@cert_antecedentes_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_Antecedentes))); //Agrega el parámetro en la condición del contador
                        if (licenciaConducir) comandoDB.Parameters.AddWithValue("@lic_conducir_vto", Fecha.DTSistemaFecha()); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@perfil_laboral", perfilLaboral); //Agrega el parámetro en la condición de la consulta
                        if (trabajoEmpreminsa) comandoDB.Parameters.AddWithValue("@trabajo_empreminsa", trabajoEmpreminsa); //Agrega el parámetro en la condición de la consulta
                        if (disponibilidadCV != "TODOS") comandoDB.Parameters.AddWithValue("@cv_disponibilidad", disponibilidadCV); //Agrega el parámetro en la condición de la consulta
                        if (calificacionCV != "TODOS") comandoDB.Parameters.AddWithValue("@cv_calificacion", calificacionCV); //Agrega el parámetro en la condición de la consulta
                        if (certificadoAntecedentes) comandoDB.Parameters.AddWithValue("@cert_antecedentes_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_Antecedentes))); //Agrega el parámetro en la condición de la consulta
                        if (licenciaConducir) comandoDB.Parameters.AddWithValue("@lic_conducir_vto", Fecha.DTSistemaFecha()); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                string celular1 = Convert.ToString(lectorDB["celular1"]).Trim();
                                string celular2 = Convert.ToString(lectorDB["celular2"]).Trim();
                                string celular3 = Convert.ToString(lectorDB["celular3"]).Trim();
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                        " | " + (Convert.ToString(lectorDB["denominacion"])).PadRight(35, ' ') +
                                        " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                        " | " + (celular1 + ((celular1.Length > 0 && celular2.Length > 0) ? ", " : "") + celular2 + (((celular1.Length > 0 || celular2.Length > 0) && celular3.Length > 0) ? ", " : "") + celular3).PadRight(43, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    string trabajoEmpreminsa_LectorDB = (!lectorDB["trabajo_empreminsa"].Equals(DBNull.Value)) ? ((Convert.ToBoolean(lectorDB["trabajo_empreminsa"])) ? "SI" : "NO") : "";
                                    string disponibilidad_LectorDB = (!lectorDB["cv_disponibilidad"].Equals(DBNull.Value)) ? Convert.ToString(lectorDB["cv_disponibilidad"]) : "";
                                    string calificacion_LectorDB = (!lectorDB["cv_calificacion"].Equals(DBNull.Value)) ? Convert.ToString(lectorDB["cv_calificacion"]) : "";
                                    string cvEstado_LectorDB = (!lectorDB["cv_estado"].Equals(DBNull.Value)) ? Convert.ToString(lectorDB["cv_estado"]) : "";
                                    string antecedentesVto_LectorDB = (!lectorDB["cert_antecedentes_emision"].Equals(DBNull.Value)) ? Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cert_antecedentes_emision"]).AddMonths(Global.Vigencia_Antecedentes)) : "";
                                    string antecedentesTipo_LectorDB = (!lectorDB["cert_antecedentes_tipo"].Equals(DBNull.Value)) ? " (" + Convert.ToString(lectorDB["cert_antecedentes_tipo"]) + ")" : "";
                                    string licenciaConducirVto_LectorDB = (!lectorDB["lic_conducir_vto"].Equals(DBNull.Value)) ? Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["lic_conducir_vto"])) : "";
                                    string cursoInduccionVto_LectorDB = (!lectorDB["curso_induccion_emision"].Equals(DBNull.Value)) ? Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["curso_induccion_emision"]).AddMonths(Global.Vigencia_CursoInduccion)) : "";
                                    string cursoInduccionEvaluacion_LectorDB = (!lectorDB["curso_induccion_evaluacion"].Equals(DBNull.Value)) ? " (" + Convert.ToString(lectorDB["curso_induccion_evaluacion"] + ")") : "";
                                    string cursoIzajeVto_LectorDB = (!lectorDB["curso_izaje_emision"].Equals(DBNull.Value)) ? Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["curso_izaje_emision"]).AddMonths(Global.Vigencia_CursoIzaje)) : "";
                                    string examenMedicoVto_LectorDB = (!lectorDB["examen_medico_emision"].Equals(DBNull.Value)) ? Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["examen_medico_emision"]).AddMonths(Global.Vigencia_ExamenMedico)) : "";
                                    string examenMedicoEvaluacion_LectorDB = (!lectorDB["examen_medico_evaluacion"].Equals(DBNull.Value)) ? " (" + Convert.ToString(lectorDB["examen_medico_evaluacion"]) + " - " : "";
                                    string examenMedicoTipo_LectorDB = (!lectorDB["examen_medico_tipo"].Equals(DBNull.Value)) ? Convert.ToString(lectorDB["examen_medico_tipo"]) + ")" : "";
                                    CatalogoBase elemento = new CatalogoBase(
                                       Convert.ToInt64(lectorDB["id"]),
                                       (Convert.ToString(lectorDB["denominacion"])).PadRight(35, ' ') +
                                       " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                       " | " + (celular1 + ((celular1.Length > 0 && celular2.Length > 0) ? ", " : "") + celular2 + (((celular1.Length > 0 || celular2.Length > 0) && celular3.Length > 0) ? ", " : "") + celular3).PadRight(43, ' ') +
                                       " | " + trabajoEmpreminsa_LectorDB.PadRight(5, ' ') +
                                       " | " + disponibilidad_LectorDB.PadRight(5, ' ') +
                                       " | " + calificacion_LectorDB.PadRight(14, ' ') +
                                       " | " + cvEstado_LectorDB.PadRight(8, ' ') +
                                       " | " + (antecedentesVto_LectorDB + antecedentesTipo_LectorDB).PadRight(23, ' ') +
                                       " | " + licenciaConducirVto_LectorDB.PadRight(10, ' ') +
                                       " | " + (cursoInduccionVto_LectorDB + cursoInduccionEvaluacion_LectorDB).PadRight(22, ' ') +
                                       " | " + cursoIzajeVto_LectorDB.PadRight(10, ' ') +
                                       " | " + (examenMedicoVto_LectorDB + examenMedicoEvaluacion_LectorDB + examenMedicoTipo_LectorDB).PadRight(37, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002BUSQUEDA_POSTULANTE: Hay un conflicto en la consulta de legajos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<BusquedaPostulante> obtenerObjetos(string perfilLaboral, bool trabajoEmpreminsa, string disponibilidadCV, string calificacionCV, bool estadoCV, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico)
        {
            string condicional = WHERE2;
            if (trabajoEmpreminsa) condicional += AND1; //Consulta filtrada por Trabajó en Empreminsa
            if (disponibilidadCV != "TODOS") condicional += AND2; //Consulta filtrada por Disponibilidad Laboral
            if (calificacionCV != "TODOS") condicional += AND3; //Consulta filtrada por Calificación Laboral
            if (estadoCV) condicional += AND4; //Consulta filtrada por Estado del CV
            if (certificadoAntecedentes) condicional += AND5; //Consulta filtrada por Certificado de Antecedentes vigente
            if (licenciaConducir) condicional += AND6; //Consulta filtrada por Licencia de Conducir vigente
            if (cursoInduccion) condicional += AND7; //Consulta filtrada Curso de Induccion vigente y aprobado
            if (cursoIzaje) condicional += AND8; //Consulta filtrada por Curso de Izaje vigente
            if (examenMedico) condicional += AND9; //Consulta filtrada por Examen Médico vigente y apto
            List<BusquedaPostulante> ListaDeObjetos = new List<BusquedaPostulante>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (trabajoEmpreminsa) comandoDB.Parameters.AddWithValue("@trabajo_empreminsa", trabajoEmpreminsa); //Agrega el parámetro en la condición de la consulta
                        if (disponibilidadCV != "TODOS") comandoDB.Parameters.AddWithValue("@cv_disponibilidad", disponibilidadCV); //Agrega el parámetro en la condición de la consulta
                        if (calificacionCV != "TODOS") comandoDB.Parameters.AddWithValue("@cv_calificacion", calificacionCV); //Agrega el parámetro en la condición de la consulta
                        if (certificadoAntecedentes) comandoDB.Parameters.AddWithValue("@cert_antecedentes_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_Antecedentes))); //Agrega el parámetro en la condición de la consulta
                        if (licenciaConducir) comandoDB.Parameters.AddWithValue("@lic_conducir_vto", Fecha.DTSistemaFecha()); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@perfil_laboral", perfilLaboral); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                BusquedaPostulante objBusquedaPostulante = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objBusquedaPostulante); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004BUSQUEDA_POSTULANTE: Hay un conflicto en la consulta de legajos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public BusquedaPostulante obtenerObjeto(long id, string perfilLaboral, bool trabajoEmpreminsa, string disponibilidadCV, string calificacionCV, bool estadoCV, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico, bool notificarExito)
        {
            string condicional = WHERE1;
            if (trabajoEmpreminsa) condicional += AND1; //Consulta filtrada por Trabajó en Empreminsa
            if (disponibilidadCV != "TODOS") condicional += AND2; //Consulta filtrada por Disponibilidad Laboral
            if (calificacionCV != "TODOS") condicional += AND3; //Consulta filtrada por Calificación Laboral
            if (estadoCV) condicional += AND4; //Consulta filtrada por Estado del CV
            if (certificadoAntecedentes) condicional += AND5; //Consulta filtrada por Certificado de Antecedentes vigente
            if (licenciaConducir) condicional += AND6; //Consulta filtrada por Licencia de Conducir vigente
            if (cursoInduccion) condicional += AND7; //Consulta filtrada Curso de Induccion vigente y aprobado
            if (cursoIzaje) condicional += AND8; //Consulta filtrada por Curso de Izaje vigente
            if (examenMedico) condicional += AND9; //Consulta filtrada por Examen Médico vigente y apto
            BusquedaPostulante objBusquedaPostulante = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        comandoDB.Parameters.AddWithValue("@id", id); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@perfil_laboral", perfilLaboral); //Agrega el parámetro en la condición de la consulta
                        if (trabajoEmpreminsa) comandoDB.Parameters.AddWithValue("@trabajo_empreminsa", trabajoEmpreminsa); //Agrega el parámetro en la condición de la consulta
                        if (disponibilidadCV != "TODOS") comandoDB.Parameters.AddWithValue("@cv_disponibilidad", disponibilidadCV); //Agrega el parámetro en la condición de la consulta
                        if (calificacionCV != "TODOS") comandoDB.Parameters.AddWithValue("@cv_calificacion", calificacionCV); //Agrega el parámetro en la condición de la consulta
                        if (certificadoAntecedentes) comandoDB.Parameters.AddWithValue("@cert_antecedentes_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_Antecedentes))); //Agrega el parámetro en la condición de la consulta
                        if (licenciaConducir) comandoDB.Parameters.AddWithValue("@lic_conducir_vto", Fecha.DTSistemaFecha()); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objBusquedaPostulante = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Búsqueda solicitada No hallada.\nVerifique los datos de la búsqueda e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006BUSQUEDA_POSTULANTE: Hay un conflicto en la consulta del legajo.", e); }
            finally { _conexion.Dispose(); }
            return objBusquedaPostulante;
        }
        #endregion

        #region Métodos de Instanciación
        private BusquedaPostulante instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new BusquedaPostulante(
                new D_Legajo().obtenerObjeto("ID", Convert.ToString(lectorDB["id"]), false),
                ((!lectorDB["perfil_laboral"].Equals(DBNull.Value)) ? Convert.ToString(lectorDB["perfil_laboral"]) : ""),
                ((!lectorDB["trabajo_empreminsa"].Equals(DBNull.Value)) ? Convert.ToBoolean(lectorDB["trabajo_empreminsa"]) : false),
                ((!lectorDB["cv_disponibilidad"].Equals(DBNull.Value)) ? Convert.ToString(lectorDB["cv_disponibilidad"]) : ""),
                ((!lectorDB["cv_calificacion"].Equals(DBNull.Value)) ? Convert.ToString(lectorDB["cv_calificacion"]) : ""),
                ((!lectorDB["cv_estado"].Equals(DBNull.Value)) ? Convert.ToString(lectorDB["cv_estado"]) : ""),
                ((!lectorDB["cert_antecedentes_emision"].Equals(DBNull.Value)) ? Convert.ToDateTime(lectorDB["cert_antecedentes_emision"]) : Fecha.ValidarFecha("01-01-1900")),
                ((!lectorDB["cert_antecedentes_tipo"].Equals(DBNull.Value)) ? Convert.ToString(lectorDB["cert_antecedentes_tipo"]) : ""),
                ((!lectorDB["lic_conducir_vto"].Equals(DBNull.Value)) ? Convert.ToDateTime(lectorDB["lic_conducir_vto"]) : Fecha.ValidarFecha("01-01-1900")),
                ((!lectorDB["curso_induccion_emision"].Equals(DBNull.Value)) ? Convert.ToDateTime(lectorDB["curso_induccion_emision"]) : Fecha.ValidarFecha("01-01-1900")),
                ((!lectorDB["curso_induccion_evaluacion"].Equals(DBNull.Value)) ? Convert.ToString(lectorDB["curso_induccion_evaluacion"]) : ""),
                ((!lectorDB["curso_izaje_emision"].Equals(DBNull.Value)) ? Convert.ToDateTime(lectorDB["curso_izaje_emision"]) : Fecha.ValidarFecha("01-01-1900")),
                ((!lectorDB["examen_medico_emision"].Equals(DBNull.Value)) ? Convert.ToDateTime(lectorDB["examen_medico_emision"]) : Fecha.ValidarFecha("01-01-1900")),
                ((!lectorDB["examen_medico_tipo"].Equals(DBNull.Value)) ? Convert.ToString(lectorDB["examen_medico_tipo"]) : ""),
                ((!lectorDB["examen_medico_evaluacion"].Equals(DBNull.Value)) ? Convert.ToString(lectorDB["examen_medico_evaluacion"]) : ""));
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