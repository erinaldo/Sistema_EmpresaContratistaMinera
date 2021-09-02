using Biblioteca.Ayudantes;
using Entidades.Sistema;
using Interfaces.Sistema;
using MySql.Data.MySqlClient;
using System;

namespace CapaDatos.Sistema
{
    public class D_OpcionGeneral : IOpcionGeneral, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT sys_opcion_general.*";
        private const string FROM = @" FROM sys_opcion_general";
        private const string WHERE = @" WHERE sys_opcion_general.id = @id"; //Filtrar Objeto por ID
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM sys_opcion_general WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE sys_opcion_general SET 
            id = @id,
            ptovta = @ptovta,
            alerta_antecedentes = @alerta_antecedentes,
            alerta_curso_induccion = @alerta_curso_induccion,
            alerta_curso_izaje = @alerta_curso_izaje,
            alerta_entrevista = @alerta_entrevista,
            alerta_examen_medico = @alerta_examen_medico,
            alerta_licencia_conducir = @alerta_licencia_conducir,
            vigencia_antecedentes = @vigencia_antecedentes,
            vigencia_curriculum_vitae = @vigencia_curriculum_vitae,
            vigencia_curso_induccion = @vigencia_curso_induccion,
            vigencia_curso_izaje = @vigencia_curso_izaje,
            vigencia_examen_medico = @vigencia_examen_medico,
            liq_sueldo_aporte_tasa = @liq_sueldo_aporte_tasa,
            liq_sueldo_contrib_tiempo_completo_tasa = @liq_sueldo_contrib_tiempo_completo_tasa,
            liq_sueldo_contrib_tiempo_parcial_tasa = @liq_sueldo_contrib_tiempo_parcial_tasa,
            liq_sueldo_art_fijo = @liq_sueldo_art_fijo,
            liq_sueldo_art_tasa = @liq_sueldo_art_tasa,
            liq_sueldo_scvo = @liq_sueldo_scvo,
            estado_resultado_iibb_tasa = @estado_resultado_iibb_tasa,
            estado_resultado_sac_tasa = @estado_resultado_sac_tasa,
            estado_resultado_ganancias_tasa = @estado_resultado_ganancias_tasa,
            registro_anulacion = @registro_anulacion,
            registro_modificacion = @registro_modificacion,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        #endregion

        #region Métodos
        public OpcionGeneral obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            OpcionGeneral objOpcionGeneral = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objOpcionGeneral = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002OPCION_GRAL: Hay un conflicto en la consulta de las opciones generales.", e); }
            finally { _conexion.Dispose(); }
            return objOpcionGeneral;
        }

        public bool actualizar(OpcionGeneral objOpcionGeneral, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objOpcionGeneral.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objOpcionGeneral.Id);
                                comandoDB_update.Parameters.AddWithValue("@ptovta", objOpcionGeneral.PtoVta);
                                comandoDB_update.Parameters.AddWithValue("@alerta_antecedentes", objOpcionGeneral.AlertaAntecedentes);
                                comandoDB_update.Parameters.AddWithValue("@alerta_curso_induccion", objOpcionGeneral.AlertaCursoInduccion);
                                comandoDB_update.Parameters.AddWithValue("@alerta_curso_izaje", objOpcionGeneral.AlertaCursoIzaje);
                                comandoDB_update.Parameters.AddWithValue("@alerta_entrevista", objOpcionGeneral.AlertaEntrevista);
                                comandoDB_update.Parameters.AddWithValue("@alerta_examen_medico", objOpcionGeneral.AlertaExamenMedico);
                                comandoDB_update.Parameters.AddWithValue("@alerta_licencia_conducir", objOpcionGeneral.AlertaLicenciaConducir);
                                comandoDB_update.Parameters.AddWithValue("@vigencia_antecedentes", objOpcionGeneral.VigenciaAntecedentes);
                                comandoDB_update.Parameters.AddWithValue("@vigencia_curriculum_vitae", objOpcionGeneral.VigenciaCurriculumVitae);
                                comandoDB_update.Parameters.AddWithValue("@vigencia_curso_induccion", objOpcionGeneral.VigenciaCursoInduccion);
                                comandoDB_update.Parameters.AddWithValue("@vigencia_curso_izaje", objOpcionGeneral.VigenciaCursoIzaje);
                                comandoDB_update.Parameters.AddWithValue("@vigencia_examen_medico", objOpcionGeneral.VigenciaExamenMedico);
                                comandoDB_update.Parameters.AddWithValue("@liq_sueldo_aporte_tasa", objOpcionGeneral.LiquidacionSueldo_AporteTasa);
                                comandoDB_update.Parameters.AddWithValue("@liq_sueldo_contrib_tiempo_completo_tasa", objOpcionGeneral.LiquidacionSueldo_ContribTiempoCompletoTasa);
                                comandoDB_update.Parameters.AddWithValue("@liq_sueldo_contrib_tiempo_parcial_tasa", objOpcionGeneral.LiquidacionSueldo_ContribTiempoParcialTasa);
                                comandoDB_update.Parameters.AddWithValue("@liq_sueldo_art_fijo", objOpcionGeneral.LiquidacionSueldo_ArtFijo);
                                comandoDB_update.Parameters.AddWithValue("@liq_sueldo_art_tasa", objOpcionGeneral.LiquidacionSueldo_ArtTasa);
                                comandoDB_update.Parameters.AddWithValue("@liq_sueldo_scvo", objOpcionGeneral.LiquidacionSueldo_SCVO);
                                comandoDB_update.Parameters.AddWithValue("@estado_resultado_iibb_tasa", objOpcionGeneral.EstadoResultado_IIBBTasa);
                                comandoDB_update.Parameters.AddWithValue("@estado_resultado_sac_tasa", objOpcionGeneral.EstadoResultado_PrevisionSACDesempleoTasa);
                                comandoDB_update.Parameters.AddWithValue("@estado_resultado_ganancias_tasa", objOpcionGeneral.EstadoResultado_PrevisionImpGananciaTasa);
                                comandoDB_update.Parameters.AddWithValue("@registro_anulacion", objOpcionGeneral.RegistroAnulacion);
                                comandoDB_update.Parameters.AddWithValue("@registro_modificacion", objOpcionGeneral.RegistroModificion);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objOpcionGeneral.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objOpcionGeneral.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objOpcionGeneral.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Opciones Generales", "Modificó el registro ID:" + objOpcionGeneral.Id.ToString() + "."); //Registra la actualización de un registro
                                if (notificarExito) Mensaje.Informacion("Los cambios se registraron correctamente.");
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro Existente.\nEl CUIT ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M006OPCION_GRAL", "M008OPCION_GRAL", "M010OPCION_GRAL", "M012OPCION_GRAL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private OpcionGeneral instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new OpcionGeneral(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToInt32(lectorDB["ptovta"]),
                Convert.ToInt32(lectorDB["alerta_antecedentes"]),
                Convert.ToInt32(lectorDB["alerta_curso_induccion"]),
                Convert.ToInt32(lectorDB["alerta_curso_izaje"]),
                Convert.ToInt32(lectorDB["alerta_entrevista"]),
                Convert.ToInt32(lectorDB["alerta_examen_medico"]),
                Convert.ToInt32(lectorDB["alerta_licencia_conducir"]),
                Convert.ToInt32(lectorDB["vigencia_antecedentes"]),
                Convert.ToInt32(lectorDB["vigencia_curriculum_vitae"]),
                Convert.ToInt32(lectorDB["vigencia_curso_induccion"]),
                Convert.ToInt32(lectorDB["vigencia_curso_izaje"]),
                Convert.ToInt32(lectorDB["vigencia_examen_medico"]),
                Convert.ToDouble(lectorDB["liq_sueldo_aporte_tasa"]),
                Convert.ToDouble(lectorDB["liq_sueldo_contrib_tiempo_completo_tasa"]),
                Convert.ToDouble(lectorDB["liq_sueldo_contrib_tiempo_parcial_tasa"]),
                Convert.ToDouble(lectorDB["liq_sueldo_art_fijo"]),
                Convert.ToDouble(lectorDB["liq_sueldo_art_tasa"]),
                Convert.ToDouble(lectorDB["liq_sueldo_scvo"]),
                Convert.ToDouble(lectorDB["estado_resultado_iibb_tasa"]),
                Convert.ToDouble(lectorDB["estado_resultado_sac_tasa"]),
                Convert.ToDouble(lectorDB["estado_resultado_ganancias_tasa"]),
                Convert.ToInt32(lectorDB["registro_anulacion"]),
                Convert.ToInt32(lectorDB["registro_modificacion"]),
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
