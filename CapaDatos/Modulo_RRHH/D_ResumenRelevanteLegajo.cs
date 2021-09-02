using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_ResumenRelevanteLegajo : IResumenRelevanteLegajo, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT DISTINCT data_legajo.id, data_legajo.denominacion, data_legajo.cuit,
            data_legajo.celular1, data_legajo.celular2, data_legajo.celular3,          
            data_legajo_laboral.estado AS estado_laboral,
            data_centro_costo.denominacion AS centro_costo, 
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
            INNER JOIN data_legajo_laboral ON data_legajo.id = data_legajo_laboral.id_legajo AND data_legajo_laboral.estado <> 'INACTIVO'
            LEFT JOIN data_centro_costo ON data_legajo_laboral.id_centro_costo = data_centro_costo.id 
            INNER JOIN data_legajo_curriculum_vitae ON data_legajo.id = data_legajo_curriculum_vitae.id_legajo
            LEFT JOIN data_curso_induccion ON data_legajo.id = data_curso_induccion.id_legajo
            LEFT JOIN data_curso_izaje ON data_legajo.id = data_curso_izaje.id_legajo
            LEFT JOIN data_examen_medico ON data_legajo.id = data_examen_medico.id_legajo";
        private const string WHERE1 = @" WHERE data_legajo.baja = 0 AND data_legajo.id = @id"; //Filtrar Objeto por sin Baja y ID
        private const string WHERE2 = @" WHERE data_legajo.baja = 0"; //Filtrar Objeto por sin Baja
        private const string AND1 = @" AND data_legajo_laboral.estado = @estado_laboral"; //Filtrar Objeto por Estado Laboral
        private const string AND2 = @" AND data_legajo_laboral.id_centro_costo = @id_centro_costo"; //Filtrar Objeto por Centro de Costo
        private const string AND3 = @" AND (data_legajo_curriculum_vitae.cert_antecedentes = 1 AND date(data_legajo_curriculum_vitae.cert_antecedentes_emision) < date(@cert_antecedentes_emision))"; //Filtrar Objeto por Certificado de Antecedentes
        private const string AND4 = @" AND (data_legajo_curriculum_vitae.lic_conducir = 1 AND date(data_legajo_curriculum_vitae.lic_conducir_vto) < date(@lic_conducir_vto))"; //Filtrar Objeto por Licencia de Conducir
        private const string AND5 = @" AND data_curso_induccion.id = (SELECT MAX(data_curso_induccion.id) FROM data_curso_induccion	WHERE data_curso_induccion.id_legajo = data_legajo.id AND date(data_curso_induccion.fecha_emision) < date(@curso_induccion_fecha_emision))"; //Filtrar Objeto por Curso de Inducción
        private const string AND6 = @" AND data_curso_izaje.id = (SELECT MAX(data_curso_izaje.id) FROM data_curso_izaje WHERE data_curso_izaje.id_legajo = data_legajo.id AND date(data_curso_izaje.fecha_emision) < date(@curso_izaje_fecha_emision))"; //Filtrar Objeto por Curso de Izaje
        private const string AND7 = @" AND data_examen_medico.id = (SELECT MAX(data_examen_medico.id) FROM data_examen_medico WHERE data_examen_medico.id_legajo = data_legajo.id AND date(data_examen_medico.examen_emision) < date(@examen_medico_fecha_emision))"; //Filtrar Objeto por Examen Médico
        private const string ORDER = @" ORDER BY data_legajo.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estadoLaboral, CentroCosto centroCosto, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = WHERE2;
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (estadoLaboral != "TODOS") condicional += AND1; //Consulta filtrada por Centro de Costo
            if (centroCosto != null) condicional += AND2; //Consulta filtrada por Estado Laboral
            if (certificadoAntecedentes) condicional += AND3; //Consulta filtrada por Certificado de Antecedentes (vencido y proxima a vencer)
            if (licenciaConducir) condicional += AND4; //Consulta filtrada por Licencia de Conducir (vencida y proxima a vencer)
            if (cursoInduccion) condicional += AND5; //Consulta filtrada Curso de Induccion (vencido y proxima a vencer)
            if (cursoIzaje) condicional += AND6; //Consulta filtrada por Curso de Izaje (vencido y proxima a vencer)
            if (examenMedico) condicional += AND7; //Consulta filtrada por Examen Médico (vencido y proxima a vencer)
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (estadoLaboral != "TODOS") comandoDB.Parameters.AddWithValue("@estado_laboral", estadoLaboral); //Agrega el parámetro en la condición del contador
                        if (centroCosto != null) comandoDB.Parameters.AddWithValue("@id_centro_costo", centroCosto); //Agrega el parámetro en la condición del contador
                        if (certificadoAntecedentes) comandoDB.Parameters.AddWithValue("@cert_antecedentes_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_Antecedentes)).AddDays(Global.Alerta_Antecedentes)); //Agrega el parámetro en la condición del contador
                        if (licenciaConducir) comandoDB.Parameters.AddWithValue("@lic_conducir_vto", Fecha.DTSistemaFecha().AddDays(Global.Alerta_LicenciaConducir)); //Agrega el parámetro en la condición del contador
                        if (cursoInduccion) comandoDB.Parameters.AddWithValue("@curso_induccion_fecha_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_CursoInduccion)).AddDays(Global.Alerta_CursoInduccion)); //Agrega el parámetro en la condición del contador
                        if (cursoIzaje) comandoDB.Parameters.AddWithValue("@curso_izaje_fecha_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_CursoIzaje)).AddDays(Global.Alerta_CursoIzaje)); //Agrega el parámetro en la condición del contador
                        if (examenMedico) comandoDB.Parameters.AddWithValue("@examen_medico_fecha_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_ExamenMedico)).AddDays(Global.Alerta_ExamenMedico)); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (estadoLaboral != "TODOS") comandoDB.Parameters.AddWithValue("@estado_laboral", estadoLaboral); //Agrega el parámetro en la condición de la consulta
                        if (centroCosto != null) comandoDB.Parameters.AddWithValue("@id_centro_costo", centroCosto); //Agrega el parámetro en la condición de la consulta
                        if (certificadoAntecedentes) comandoDB.Parameters.AddWithValue("@cert_antecedentes_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_Antecedentes)).AddDays(Global.Alerta_Antecedentes)); //Agrega el parámetro en la condición de la consulta
                        if (licenciaConducir) comandoDB.Parameters.AddWithValue("@lic_conducir_vto", Fecha.DTSistemaFecha().AddDays(Global.Alerta_LicenciaConducir)); //Agrega el parámetro en la condición de la consulta
                        if (cursoInduccion) comandoDB.Parameters.AddWithValue("@curso_induccion_fecha_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_CursoInduccion)).AddDays(Global.Alerta_CursoInduccion)); //Agrega el parámetro en la condición de la consulta
                        if (cursoIzaje) comandoDB.Parameters.AddWithValue("@curso_izaje_fecha_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_CursoIzaje)).AddDays(Global.Alerta_CursoIzaje)); //Agrega el parámetro en la condición de la consulta
                        if (examenMedico) comandoDB.Parameters.AddWithValue("@examen_medico_fecha_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_ExamenMedico)).AddDays(Global.Alerta_ExamenMedico)); //Agrega el parámetro en la condición de la consulta
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
                                    string estadoLaboral_LectorDB = (!lectorDB["estado_laboral"].Equals(DBNull.Value)) ? Convert.ToString(lectorDB["estado_laboral"]) : "";
                                    string centroCosto_LectorDB = (!lectorDB["centro_costo"].Equals(DBNull.Value)) ? Convert.ToString(lectorDB["centro_costo"]) : "";
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
                                       " | " + estadoLaboral_LectorDB.PadRight(10, ' ') +
                                       " | " + centroCosto_LectorDB.PadRight(25, ' ') +
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
            catch (MySqlException e) { Mensaje.Error("Error-M002RESUMEN_LEGAJO: Hay un conflicto en la consulta de legajos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<ResumenRelevanteLegajo> obtenerObjetos(string estadoLaboral, CentroCosto centroCosto, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico)
        {
            string condicional = WHERE2;
            if (estadoLaboral != "TODOS") condicional += AND1; //Consulta filtrada por Estado Laboral
            if (centroCosto != null) condicional += AND2; //Consulta filtrada por Centro de Costo
            if (certificadoAntecedentes) condicional += AND3; //Consulta filtrada por Certificado de Antecedentes (vencido y proxima a vencer)
            if (licenciaConducir) condicional += AND4; //Consulta filtrada por Licencia de Conducir (vencida y proxima a vencer)
            if (cursoInduccion) condicional += AND5; //Consulta filtrada Curso de Induccion (vencido y proxima a vencer)
            if (cursoIzaje) condicional += AND6; //Consulta filtrada por Curso de Izaje (vencido y proxima a vencer)
            if (examenMedico) condicional += AND7; //Consulta filtrada por Examen Médico (vencido y proxima a vencer)
            List<ResumenRelevanteLegajo> ListaDeObjetos = new List<ResumenRelevanteLegajo>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (estadoLaboral != "TODOS") comandoDB.Parameters.AddWithValue("@estado_laboral", estadoLaboral); //Agrega el parámetro en la condición de la consulta
                        if (centroCosto != null) comandoDB.Parameters.AddWithValue("@id_centro_costo", centroCosto); //Agrega el parámetro en la condición de la consulta
                        if (certificadoAntecedentes) comandoDB.Parameters.AddWithValue("@cert_antecedentes_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_Antecedentes)).AddDays(Global.Alerta_Antecedentes)); //Agrega el parámetro en la condición de la consulta
                        if (licenciaConducir) comandoDB.Parameters.AddWithValue("@lic_conducir_vto", Fecha.DTSistemaFecha().AddDays(Global.Alerta_LicenciaConducir)); //Agrega el parámetro en la condición de la consulta
                        if (cursoInduccion) comandoDB.Parameters.AddWithValue("@curso_induccion_fecha_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_CursoInduccion)).AddDays(Global.Alerta_CursoInduccion)); //Agrega el parámetro en la condición de la consulta
                        if (cursoIzaje) comandoDB.Parameters.AddWithValue("@curso_izaje_fecha_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_CursoIzaje)).AddDays(Global.Alerta_CursoIzaje)); //Agrega el parámetro en la condición de la consulta
                        if (examenMedico) comandoDB.Parameters.AddWithValue("@examen_medico_fecha_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_ExamenMedico)).AddDays(Global.Alerta_ExamenMedico)); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                ResumenRelevanteLegajo objResumenRelevanteLegajo = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objResumenRelevanteLegajo); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004RESUMEN_LEGAJO: Hay un conflicto en la consulta de legajos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public ResumenRelevanteLegajo obtenerObjeto(long id, string estadoLaboral, CentroCosto centroCosto, bool certificadoAntecedentes, bool licenciaConducir, bool cursoInduccion, bool cursoIzaje, bool examenMedico, bool notificarExito)
        {
            string condicional = WHERE1;
            if (estadoLaboral != "TODOS") condicional += AND1; //Consulta filtrada por Estado Laboral
            if (centroCosto != null) condicional += AND2; //Consulta filtrada por Centro de Costo
            if (certificadoAntecedentes) condicional += AND3; //Consulta filtrada por Certificado de Antecedentes (vencido y proxima a vencer)
            if (licenciaConducir) condicional += AND4; //Consulta filtrada por Licencia de Conducir (vencida y proxima a vencer)
            if (cursoInduccion) condicional += AND5; //Consulta filtrada Curso de Induccion (vencido y proxima a vencer)
            if (cursoIzaje) condicional += AND6; //Consulta filtrada por Curso de Izaje (vencido y proxima a vencer)
            if (examenMedico) condicional += AND7; //Consulta filtrada por Examen Médico (vencido y proxima a vencer)
            ResumenRelevanteLegajo objResumenRelevanteLegajo = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        comandoDB.Parameters.AddWithValue("@id", id); //Agrega un parámetro al filtro
                        if (estadoLaboral != "TODOS") comandoDB.Parameters.AddWithValue("@estado_laboral", estadoLaboral); //Agrega el parámetro en la condición de la consulta
                        if (centroCosto != null) comandoDB.Parameters.AddWithValue("@id_centro_costo", centroCosto); //Agrega el parámetro en la condición de la consulta
                        if (certificadoAntecedentes) comandoDB.Parameters.AddWithValue("@cert_antecedentes_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_Antecedentes)).AddDays(Global.Alerta_Antecedentes)); //Agrega el parámetro en la condición de la consulta
                        if (licenciaConducir) comandoDB.Parameters.AddWithValue("@lic_conducir_vto", Fecha.DTSistemaFecha().AddDays(Global.Alerta_LicenciaConducir)); //Agrega el parámetro en la condición de la consulta
                        if (cursoInduccion) comandoDB.Parameters.AddWithValue("@curso_induccion_fecha_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_CursoInduccion)).AddDays(Global.Alerta_CursoInduccion)); //Agrega el parámetro en la condición de la consulta
                        if (cursoIzaje) comandoDB.Parameters.AddWithValue("@curso_izaje_fecha_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_CursoIzaje)).AddDays(Global.Alerta_CursoIzaje)); //Agrega el parámetro en la condición de la consulta
                        if (examenMedico) comandoDB.Parameters.AddWithValue("@examen_medico_fecha_emision", Fecha.DTSistemaFecha().AddMonths(-(Global.Vigencia_ExamenMedico)).AddDays(Global.Alerta_ExamenMedico)); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objResumenRelevanteLegajo = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
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
            catch (MySqlException e) { Mensaje.Error("Error-M006RESUMEN_LEGAJO: Hay un conflicto en la consulta del legajo.", e); }
            finally { _conexion.Dispose(); }
            return objResumenRelevanteLegajo;
        }
        #endregion

        #region Métodos de Instanciación
        private ResumenRelevanteLegajo instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new ResumenRelevanteLegajo(
                new D_Legajo().obtenerObjeto("ID", Convert.ToString(lectorDB["id"]), false),
                ((!lectorDB["estado_laboral"].Equals(DBNull.Value)) ? Convert.ToString(lectorDB["estado_laboral"]) : ""),
                ((!lectorDB["centro_costo"].Equals(DBNull.Value)) ? new D_CentroCosto().obtenerObjeto("DENOMINACION", Convert.ToString(lectorDB["centro_costo"]), false) : new CentroCosto()),
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