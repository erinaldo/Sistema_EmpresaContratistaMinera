using Biblioteca.Ayudantes;
using Entidades.Sistema;
using Interfaces.Sistema;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos.Sistema
{
    public class D_Monitor : IMonitor, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        private List<Alerta> _listaDeAlertas = new List<Alerta>();
        #endregion

        #region Consultas SQL
        private const string CAPTURAR_ANTECEDENTES = @"SELECT data_legajo_curriculum_vitae.cert_antecedentes_emision,
            data_legajo_curriculum_vitae.id, data_legajo.denominacion, data_legajo.cuit FROM data_legajo_curriculum_vitae 
            INNER JOIN data_legajo ON data_legajo_curriculum_vitae.id_legajo = data_legajo.id
            INNER JOIN data_legajo_laboral ON data_legajo_curriculum_vitae.id_legajo = data_legajo_laboral.id_legajo
            WHERE DATE(@alerta) >= DATE(data_legajo_curriculum_vitae.cert_antecedentes_emision) AND data_legajo_curriculum_vitae.cert_antecedentes_alertado = false 
            AND data_legajo_laboral.estado <> 'INACTIVO'";
        private const string CAPTURAR_CURSOINDUCCION = @"SELECT data_curso_induccion.fecha_emision,
            data_curso_induccion.id, data_legajo.denominacion, data_legajo.cuit FROM data_curso_induccion 
            INNER JOIN data_legajo ON data_curso_induccion.id_legajo = data_legajo.id
            INNER JOIN data_legajo_laboral ON data_curso_induccion.id_legajo = data_legajo_laboral.id_legajo
            WHERE DATE(@alerta) >= DATE(data_curso_induccion.fecha_emision) AND data_curso_induccion.fecha_emision_alertado = false 
            AND data_curso_induccion.estado = 'VIGENTE' AND data_legajo_laboral.estado <> 'INACTIVO'";
        private const string CAPTURAR_CURSOIZAJE = @"SELECT data_curso_izaje.fecha_emision,
            data_curso_izaje.id, data_legajo.denominacion, data_legajo.cuit FROM data_curso_izaje 
            INNER JOIN data_legajo ON data_curso_izaje.id_legajo = data_legajo.id
            INNER JOIN data_legajo_laboral ON data_curso_izaje.id_legajo = data_legajo_laboral.id_legajo
            WHERE DATE(@alerta) >= DATE(data_curso_izaje.fecha_emision) AND data_curso_izaje.fecha_emision_alertado = false 
            AND data_curso_izaje.estado = 'VIGENTE' AND data_legajo_laboral.estado <> 'INACTIVO'";
        private const string CAPTURAR_ENTREVISTA = @"SELECT data_entrevista.cita,
            data_entrevista.id, data_legajo.denominacion, data_legajo.cuit FROM data_entrevista 
            INNER JOIN data_legajo ON data_entrevista.id_legajo = data_legajo.id
            WHERE DATE(@alerta) >= DATE(data_entrevista.cita) AND data_entrevista.cita_alertado = false 
            AND data_entrevista.estado = 'S/REALIZAR'";
        private const string CAPTURAR_EXAMENMEDICO = @"SELECT data_examen_medico.examen_emision,
            data_examen_medico.id, data_legajo.denominacion, data_legajo.cuit FROM data_examen_medico 
            INNER JOIN data_legajo ON data_examen_medico.id_legajo = data_legajo.id
            INNER JOIN data_legajo_laboral ON data_examen_medico.id_legajo = data_legajo_laboral.id_legajo
            WHERE DATE(@alerta) >= DATE(data_examen_medico.examen_emision) AND data_examen_medico.examen_emision_alertado = false 
            AND data_examen_medico.estado = 'VIGENTE' AND data_legajo_laboral.estado <> 'INACTIVO'";
        private const string CAPTURAR_LICENCIACONDUCIR = @"SELECT data_legajo_curriculum_vitae.lic_conducir_vto,
            data_legajo_curriculum_vitae.id, data_legajo.denominacion, data_legajo.cuit FROM data_legajo_curriculum_vitae 
            INNER JOIN data_legajo ON data_legajo_curriculum_vitae.id_legajo = data_legajo.id
            INNER JOIN data_legajo_laboral ON data_legajo_curriculum_vitae.id_legajo = data_legajo_laboral.id_legajo
            WHERE DATE(@alerta) >= DATE(data_legajo_curriculum_vitae.lic_conducir_vto) AND data_legajo_curriculum_vitae.lic_conducir_alertado = false 
            AND data_legajo_laboral.estado <> 'INACTIVO'";
        private const string CAPTURAR_ARTICULO_CRITICO_A1 = @"SELECT data_articulo.id, denominacion,
            a1_pto_critico_limite AS punto_limite FROM data_articulo
            WHERE a1_pto_critico = true AND a1_stock <= a1_pto_critico_limite AND a1_pto_critico_alertado = false AND estado = 'ACTIVO'";
        private const string CAPTURAR_ARTICULO_CRITICO_A2 = @"SELECT data_articulo.id, denominacion,
            a2_pto_critico_limite AS punto_limite FROM data_articulo
            WHERE a2_pto_critico = true AND a2_stock <= a2_pto_critico_limite AND a2_pto_critico_alertado = false AND estado = 'ACTIVO'";
        private const string CAPTURAR_ARTICULO_MINIMO_A1 = @"SELECT data_articulo.id, denominacion,
            a1_pto_minimo_limite AS punto_limite FROM data_articulo
            WHERE a1_pto_minimo = true AND a1_stock <= a1_pto_minimo_limite AND a1_stock > a1_pto_critico AND a1_pto_minimo_alertado = false AND estado = 'ACTIVO'";
        private const string CAPTURAR_ARTICULO_MINIMO_A2 = @"SELECT data_articulo.id, denominacion,
            a2_pto_minimo_limite AS punto_limite FROM data_articulo
            WHERE a2_pto_minimo = true AND a2_stock <= a2_pto_minimo_limite AND a2_stock > a2_pto_critico AND a2_pto_minimo_alertado = false AND estado = 'ACTIVO'";
        private const string CAPTURAR_COBRO = @"SELECT data_venta.id, afip_cbte_tipo, afip_cbte_tpv, afip_cbte_nro, afip_cbte_fecha, cobranza_vto FROM data_venta
            WHERE DATE(cobranza_vto) <= DATE(@fecha) AND cobranza_estado <> 'COBRADO' AND cobranza_alertado = false";
        private const string CAPTURAR_PAGO = @"SELECT data_compra.id, afip_cbte_tipo, afip_cbte_tpv, afip_cbte_nro, afip_cbte_fecha, pago_vto FROM data_compra
            WHERE DATE(pago_vto) <= DATE(@fecha) AND pago_estado <> 'PAGADO' AND pago_alertado = false";
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR_CURRICULUMVITAE = @"UPDATE data_legajo_curriculum_vitae
            SET data_legajo_curriculum_vitae.cv_estado	= 'OBSOLETO'
            WHERE (DATE(@vencimiento) > DATE(data_legajo_curriculum_vitae.cv_vto) AND data_legajo_curriculum_vitae.cv_estado = 'VIGENTE')";
        private const string ACTUALIZAR_CURSOINDUCCION = @"UPDATE data_curso_induccion
            SET data_curso_induccion.estado = 'OBSOLETO'
            WHERE DATE(@vencimiento) > DATE(data_curso_induccion.fecha_emision) AND data_curso_induccion.estado = 'VIGENTE'";
        private const string ACTUALIZAR_CURSOIZAJE = @"UPDATE data_curso_izaje
            SET data_curso_izaje.estado = 'OBSOLETO'
            WHERE DATE(@vencimiento) > DATE(data_curso_izaje.fecha_emision) AND data_curso_izaje.estado = 'VIGENTE'";
        private const string ACTUALIZAR_EXAMENMEDICO = @"UPDATE data_examen_medico
            SET data_examen_medico.estado = 'OBSOLETO'
            WHERE DATE(@vencimiento) > DATE(data_examen_medico.examen_emision) AND data_examen_medico.estado = 'VIGENTE'";
        private const string ALERTAR_ANTECEDENTES = @"UPDATE data_legajo_curriculum_vitae
            INNER JOIN data_legajo ON data_legajo_curriculum_vitae.id_legajo = data_legajo.id
            INNER JOIN data_legajo_laboral ON data_legajo_curriculum_vitae.id_legajo = data_legajo_laboral.id_legajo
            SET data_legajo_curriculum_vitae.cert_antecedentes_alertado = true
            WHERE DATE(@alerta) >= DATE(data_legajo_curriculum_vitae.cert_antecedentes_emision) AND data_legajo_curriculum_vitae.cert_antecedentes_alertado = false 
            AND data_legajo_laboral.estado <> 'INACTIVO'";
        private const string ALERTAR_CURSOINDUCCION = @"UPDATE data_curso_induccion
            INNER JOIN data_legajo ON data_curso_induccion.id_legajo = data_legajo.id
            INNER JOIN data_legajo_laboral ON data_curso_induccion.id_legajo = data_legajo_laboral.id_legajo
            SET data_curso_induccion.fecha_emision_alertado = true
            WHERE DATE(@alerta) >= DATE(data_curso_induccion.fecha_emision) AND data_curso_induccion.fecha_emision_alertado = false 
            AND data_curso_induccion.estado = 'VIGENTE' AND data_legajo_laboral.estado <> 'INACTIVO'";
        private const string ALERTAR_CURSOIZAJE = @"UPDATE data_curso_izaje
            INNER JOIN data_legajo ON data_curso_izaje.id_legajo = data_legajo.id
            INNER JOIN data_legajo_laboral ON data_curso_izaje.id_legajo = data_legajo_laboral.id_legajo
            SET data_curso_izaje.fecha_emision_alertado = true
            WHERE DATE(@alerta) >= DATE(data_curso_izaje.fecha_emision) AND data_curso_izaje.fecha_emision_alertado = false 
            AND data_curso_izaje.estado = 'VIGENTE' AND data_legajo_laboral.estado <> 'INACTIVO'";
        private const string ALERTAR_ENTREVISTA = @"UPDATE data_entrevista
            SET data_entrevista.cita_alertado = true
            WHERE DATE(@alerta) >= DATE(data_entrevista.cita) AND data_entrevista.cita_alertado = false 
            AND data_entrevista.estado = 'S/REALIZAR'";
        private const string ALERTAR_EXAMENMEDICO = @"UPDATE data_examen_medico
            INNER JOIN data_legajo ON data_examen_medico.id_legajo = data_legajo.id
            INNER JOIN data_legajo_laboral ON data_examen_medico.id_legajo = data_legajo_laboral.id_legajo
            SET data_examen_medico.examen_emision_alertado = true
            WHERE DATE(@alerta) >= DATE(data_examen_medico.examen_emision) AND data_examen_medico.examen_emision_alertado = false 
            AND data_examen_medico.estado = 'VIGENTE' AND data_legajo_laboral.estado <> 'INACTIVO'";
        private const string ALERTAR_LICENCIACONDUCIR = @"UPDATE data_legajo_curriculum_vitae
            INNER JOIN data_legajo ON data_legajo_curriculum_vitae.id_legajo = data_legajo.id
            INNER JOIN data_legajo_laboral ON data_legajo_curriculum_vitae.id_legajo = data_legajo_laboral.id_legajo
            SET data_legajo_curriculum_vitae.lic_conducir_alertado = true
            WHERE DATE(@alerta) >= DATE(data_legajo_curriculum_vitae.lic_conducir_vto) AND data_legajo_curriculum_vitae.lic_conducir_alertado = false 
            AND data_legajo_laboral.estado <> 'INACTIVO'";
        private const string ALERTAR_ARTICULO_CRITICO_A1 = @"UPDATE data_articulo SET a1_pto_critico_alertado = true
            WHERE a1_pto_critico = true AND a1_stock <= a1_pto_critico_limite AND a1_pto_critico_alertado = false AND estado = 'ACTIVO'";
        private const string ALERTAR_ARTICULO_CRITICO_A2 = @"UPDATE data_articulo SET a2_pto_critico_alertado = true
            WHERE a2_pto_critico = true AND a2_stock <= a2_pto_critico_limite AND a2_pto_critico_alertado = false AND estado = 'ACTIVO'";
        private const string ALERTAR_ARTICULO_MINIMO_A1 = @"UPDATE data_articulo SET a1_pto_minimo_alertado = true
            WHERE a1_pto_minimo = true AND a1_stock <= a1_pto_minimo_limite AND a1_stock > a1_pto_critico AND a1_pto_minimo_alertado = false AND estado = 'ACTIVO'";
        private const string ALERTAR_ARTICULO_MINIMO_A2 = @"UPDATE data_articulo SET a2_pto_minimo_alertado = true
            WHERE a2_pto_minimo = true AND a2_stock <= a2_pto_minimo_limite AND a2_stock > a2_pto_critico AND a2_pto_minimo_alertado = false AND estado = 'ACTIVO'";
        private const string ALERTAR_COBRO = @"UPDATE data_venta SET cobranza_alertado = true
            WHERE DATE(cobranza_vto) <= DATE(@fecha) AND cobranza_estado <> 'COBRADO' AND cobranza_alertado = false";
        private const string ALERTAR_PAGO = @"UPDATE data_compra SET pago_alertado = true
            WHERE DATE(pago_vto) <= DATE(@fecha) AND pago_estado <> 'PAGADO' AND pago_alertado = false";
        private const string CADUCAR_ALERTA = @"UPDATE sys_alerta SET estado = 'CADUCADO'
            WHERE (DATE(fecha_vto) < DATE(@fecha) AND estado = 'SIN PROCESAR')";
        #endregion

        #region Métodos
        public bool monitorearAlertas()
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(CADUCAR_ALERTA)) //ReAsigna un comando de Base de Datos
                    {
                        comandoDB_update.Parameters.AddWithValue("@fecha", Fecha.DTSistemaFecha());
                        comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                    }
                    return true;
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M002MONITOR", "M004MONITOR", "M006MONITOR", "M008MONITOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool monitorearAlertasDeArticulo()
        {
            _listaDeAlertas.Clear(); //Importante: Libera todo posible item en la lista
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    string[] campos = { "crítico en el almacén de Empreminsa", "crítico en el almacén de Veladero", "mínimo en el almacén de Empreminsa", "mínimo en el almacén de Veladero" }; //Vector que almacena los títulos de los campos
                    foreach (string campo in campos)
                    {
                        string comando1 = "";
                        if (campo == "crítico en el almacén de Empreminsa") comando1 = CAPTURAR_ARTICULO_CRITICO_A1; //ReAsigna un comando de Base de Datos
                        else if (campo == "crítico en el almacén de Veladero") comando1 = CAPTURAR_ARTICULO_CRITICO_A2; //ReAsigna un comando de Base de Datos
                        else if (campo == "mínimo en el almacén de Empreminsa") comando1 = CAPTURAR_ARTICULO_MINIMO_A1; //ReAsigna un comando de Base de Datos
                        else if (campo == "mínimo en el almacén de Veladero") comando1 = CAPTURAR_ARTICULO_MINIMO_A2; //ReAsigna un comando de Base de Datos
                        using (MySqlCommand comandoDB = _conexion.crearComandoDB(comando1)) //Crea un comando de Base de Datos
                        {
                            using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                            {
                                while (lectorDB.Read())
                                {
                                    Alerta alerta = new Alerta(
                                        "ALERTAS DE INVENTARIO",
                                        "El stock del artículo " + Convert.ToString(lectorDB["id"]).PadLeft(8, '0') + ", ha llegado a su punto " + campo + ".",
                                        Global.RelojDeSistema.AddDays(15),
                                        "SIN PROCESAR",
                                        "ART" + Convert.ToString(lectorDB["id"]).PadLeft(10, '0'));
                                    _listaDeAlertas.Add(alerta); //Agrega este Objeto a la lista de Objetos
                                }
                                new D_Alerta().insertar(_listaDeAlertas); //Inserta los registros de alerta
                            }
                            string comando2 = "";
                            if (campo == "crítico en el almacén de Empreminsa") comando2 = ALERTAR_ARTICULO_CRITICO_A1; //ReAsigna un comando de Base de Datos
                            else if (campo == "crítico en el almacén de Veladero") comando2 = ALERTAR_ARTICULO_CRITICO_A2; //ReAsigna un comando de Base de Datos
                            else if (campo == "mínimo en el almacén de Empreminsa") comando2 = ALERTAR_ARTICULO_MINIMO_A1; //ReAsigna un comando de Base de Datos
                            else if (campo == "mínimo en el almacén de Veladero") comando2 = ALERTAR_ARTICULO_MINIMO_A2; //ReAsigna un comando de Base de Datos
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(comando2)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                            }
                        }
                    }
                    return true;
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M010MONITOR", "M012MONITOR", "M014MONITOR", "M016MONITOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool monitorearAlertasDeAntecedentes()
        {
            _listaDeAlertas.Clear(); //Importante: Libera todo posible item en la lista
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(CAPTURAR_ANTECEDENTES)) //Asigna un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@alerta", Fecha.DTSistemaFecha().AddMonths(-Global.Vigencia_Antecedentes).AddDays(-Global.Alerta_Antecedentes));
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Alerta alerta = new Alerta(
                                    "ALERTAS DE RRHH",
                                    "Está próximo a caducar el 'CERTIFICADO DE ANTECEDENTES' de " 
                                        + Formulario.ValidarCampoTipoSubTitulo(Convert.ToString(lectorDB["denominacion"])) 
                                        + ", CUIT: " + lectorDB["cuit"] + ".",
                                    Convert.ToDateTime(lectorDB["cert_antecedentes_emision"]).AddMonths(Global.Vigencia_Antecedentes),
                                    "SIN PROCESAR",
                                    "CAN" + Convert.ToString(lectorDB["id"]).PadLeft(10, '0'));
                                _listaDeAlertas.Add(alerta); //Agrega este Objeto a la lista de Objetos
                            }
                            new D_Alerta().insertar(_listaDeAlertas); //Inserta los registros de alerta
                        }
                        using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ALERTAR_ANTECEDENTES)) //Asigna un comando de Base de Datos
                        {
                            comandoDB_update.Parameters.AddWithValue("@alerta", Fecha.DTSistemaFecha().AddMonths(-Global.Vigencia_Antecedentes).AddDays(-Global.Alerta_Antecedentes));
                            comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                        }
                    }
                    return true;
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M018MONITOR", "M020MONITOR", "M022MONITOR", "M024MONITOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool monitorearAlertasDeCobro()
        {
            _listaDeAlertas.Clear(); //Importante: Libera todo posible item en la lista
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(CAPTURAR_COBRO)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@fecha", Fecha.DTSistemaFecha());
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Alerta alerta = new Alerta(
                                    "ALERTAS DE FACTURACION",
                                    "Ha caducado el plazo de cobro del comprobante "
                                        + Formulario.GenerarTipoComprobante(Convert.ToInt32(lectorDB["afip_cbte_tipo"]))
                                        + " N°" + Convert.ToString(lectorDB["afip_cbte_tpv"]).PadLeft(5, '0')
                                        + "-" + Convert.ToString(lectorDB["afip_cbte_nro"]).PadLeft(8, '0')
                                        + " Fecha: " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["afip_cbte_fecha"])),
                                    Convert.ToDateTime(lectorDB["cobranza_vto"]),
                                    "SIN PROCESAR",
                                    "VTA" + Convert.ToString(lectorDB["id"]).PadLeft(10, '0'));
                                _listaDeAlertas.Add(alerta); //Agrega este Objeto a la lista de Objetos
                            }
                            new D_Alerta().insertar(_listaDeAlertas); //Inserta los registros de alerta
                        }
                        using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ALERTAR_COBRO)) //Crea un comando de Base de Datos
                        {
                            comandoDB_update.Parameters.AddWithValue("@fecha", Fecha.DTSistemaFecha());
                            comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                        }
                    }
                    return true;
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M026MONITOR", "M028MONITOR", "M030MONITOR", "M032MONITOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool monitorearAlertasDeCursoInduccion()
        {
            _listaDeAlertas.Clear(); //Importante: Libera todo posible item en la lista
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(CAPTURAR_CURSOINDUCCION)) //Asigna un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@alerta", Fecha.DTSistemaFecha().AddMonths(-Global.Vigencia_CursoInduccion).AddDays(-Global.Alerta_CursoInduccion));
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Alerta alerta = new Alerta(
                                    "ALERTAS DE RRHH",
                                    "Está próximo a caducar el 'CURSO DE INDUCCION' de "
                                        + Formulario.ValidarCampoTipoSubTitulo(Convert.ToString(lectorDB["denominacion"]))
                                        + ", " + Convert.ToInt64(Convert.ToString(lectorDB["cuit"])).ToString("99-99999999/9"),
                                    Convert.ToDateTime(lectorDB["fecha_emision"]).AddMonths(Global.Vigencia_CursoInduccion),
                                    "SIN PROCESAR",
                                    "CIN" + Convert.ToString(lectorDB["id"]).PadLeft(10, '0'));
                                _listaDeAlertas.Add(alerta); //Agrega este Objeto a la lista de Objetos
                            }
                            new D_Alerta().insertar(_listaDeAlertas); //Inserta los registros de alerta
                        }
                        using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ALERTAR_CURSOINDUCCION)) //Asigna un comando de Base de Datos
                        {
                            comandoDB_update.Parameters.AddWithValue("@alerta", Fecha.DTSistemaFecha().AddMonths(-Global.Vigencia_CursoInduccion).AddDays(-Global.Alerta_CursoInduccion));
                            comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                        }
                    }
                    return true;
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M034MONITOR", "M036MONITOR", "M038MONITOR", "M040MONITOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool monitorearAlertasDeCursoIzaje()
        {
            _listaDeAlertas.Clear(); //Importante: Libera todo posible item en la lista
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(CAPTURAR_CURSOIZAJE)) //Asigna un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@alerta", Fecha.DTSistemaFecha().AddMonths(-Global.Vigencia_CursoIzaje).AddDays(-Global.Alerta_CursoIzaje));
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Alerta alerta = new Alerta(
                                    "ALERTAS DE RRHH",
                                    "Está próximo a caducar el 'CURSO DE IZAJE' de " 
                                        + Formulario.ValidarCampoTipoSubTitulo(Convert.ToString(lectorDB["denominacion"]))
                                        + ", " + Convert.ToInt64(Convert.ToString(lectorDB["cuit"])).ToString("99-99999999/9"),
                                    Convert.ToDateTime(lectorDB["fecha_emision"]).AddMonths(Global.Vigencia_CursoIzaje),
                                    "SIN PROCESAR",
                                    "CIZ" + Convert.ToString(lectorDB["id"]).PadLeft(10, '0'));
                                _listaDeAlertas.Add(alerta); //Agrega este Objeto a la lista de Objetos
                            }
                            new D_Alerta().insertar(_listaDeAlertas); //Inserta los registros de alerta
                        }
                        using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ALERTAR_CURSOIZAJE)) //Asigna un comando de Base de Datos
                        {
                            comandoDB_update.Parameters.AddWithValue("@alerta", Fecha.DTSistemaFecha().AddMonths(-Global.Vigencia_CursoIzaje).AddDays(-Global.Alerta_CursoIzaje));
                            comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                        }
                    }
                    return true;
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M042MONITOR", "M044MONITOR", "M046MONITOR", "M048MONITOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool monitorearAlertasDeEntrevista()
        {
            _listaDeAlertas.Clear(); //Importante: Libera todo posible item en la lista
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(CAPTURAR_ENTREVISTA)) //Asigna un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@alerta", Fecha.DTSistemaFecha().AddDays(Global.Alerta_Entrevista));
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Alerta alerta = new Alerta(
                                    "ALERTAS DE RRHH",
                                    "Se aproxima una 'ENTREVISTA DE TRABAJO' con " 
                                        + Formulario.ValidarCampoTipoSubTitulo(Convert.ToString(lectorDB["denominacion"]))
                                        + ", " + Convert.ToInt64(Convert.ToString(lectorDB["cuit"])).ToString("99-99999999/9"),
                                    Convert.ToDateTime(lectorDB["cita"]),
                                    "SIN PROCESAR",
                                    "ETR" + Convert.ToString(lectorDB["id"]).PadLeft(10, '0'));
                                _listaDeAlertas.Add(alerta); //Agrega este Objeto a la lista de Objetos
                            }
                            new D_Alerta().insertar(_listaDeAlertas); //Inserta los registros de alerta
                        }
                        using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ALERTAR_ENTREVISTA)) //Asigna un comando de Base de Datos
                        {
                            comandoDB_update.Parameters.AddWithValue("@alerta", Fecha.DTSistemaFecha().AddDays(Global.Alerta_Entrevista));
                            comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                        }
                    }
                    return true;
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M050MONITOR", "M052MONITOR", "M054MONITOR", "M056MONITOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool monitorearAlertasDeExamenMedico()
        {
            _listaDeAlertas.Clear(); //Importante: Libera todo posible item en la lista
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(CAPTURAR_EXAMENMEDICO)) //Asigna un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@alerta", Fecha.DTSistemaFecha().AddMonths(-Global.Vigencia_ExamenMedico).AddDays(-Global.Alerta_ExamenMedico));
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Alerta alerta = new Alerta(
                                    "ALERTAS DE RRHH",
                                    "Está próximo a caducar el 'EXAMEN MEDICO' de " 
                                        + Formulario.ValidarCampoTipoSubTitulo(Convert.ToString(lectorDB["denominacion"]))
                                        + ", " + Convert.ToInt64(Convert.ToString(lectorDB["cuit"])).ToString("99-99999999/9"),
                                    Convert.ToDateTime(lectorDB["examen_emision"]).AddMonths(Global.Vigencia_ExamenMedico),
                                    "SIN PROCESAR",
                                    "EME" + Convert.ToString(lectorDB["id"]).PadLeft(10, '0'));
                                _listaDeAlertas.Add(alerta); //Agrega este Objeto a la lista de Objetos
                            }
                            new D_Alerta().insertar(_listaDeAlertas); //Inserta los registros de alerta
                        }
                        using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ALERTAR_EXAMENMEDICO)) //Asigna un comando de Base de Datos
                        {
                            comandoDB_update.Parameters.AddWithValue("@alerta", Fecha.DTSistemaFecha().AddMonths(-Global.Vigencia_ExamenMedico).AddDays(-Global.Alerta_ExamenMedico));
                            comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                        }
                    }
                    return true;
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M058MONITOR", "M060MONITOR", "M062MONITOR", "M064MONITOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool monitorearAlertasDeLicenciaConducir()
        {
            _listaDeAlertas.Clear(); //Importante: Libera todo posible item en la lista
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(CAPTURAR_LICENCIACONDUCIR)) //Asigna un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@alerta", Fecha.DTSistemaFecha().AddDays(Global.Alerta_LicenciaConducir));
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Alerta alerta = new Alerta(
                                    "ALERTAS DE RRHH",
                                    "Está próximo a caducar el 'LICENCIA DE CONDUCIR' de "
                                        + Formulario.ValidarCampoTipoSubTitulo(Convert.ToString(lectorDB["denominacion"]))
                                        + ", " + Convert.ToInt64(Convert.ToString(lectorDB["cuit"])).ToString("99-99999999/9"),
                                    Convert.ToDateTime(lectorDB["lic_conducir_vto"]),
                                    "SIN PROCESAR",
                                    "LCO" + Convert.ToString(lectorDB["id"]).PadLeft(10, '0'));
                                _listaDeAlertas.Add(alerta); //Agrega este Objeto a la lista de Objetos
                            }
                            new D_Alerta().insertar(_listaDeAlertas); //Inserta los registros de alerta
                        }
                        using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ALERTAR_LICENCIACONDUCIR)) //Asigna un comando de Base de Datos
                        {
                            comandoDB_update.Parameters.AddWithValue("@alerta", Fecha.DTSistemaFecha().AddDays(Global.Alerta_LicenciaConducir));
                            comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                        }
                    }
                    return true;
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M066MONITOR", "M068MONITOR", "M070MONITOR", "M072MONITOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool monitorearAlertasDePago()
        {
            _listaDeAlertas.Clear(); //Importante: Libera todo posible item en la lista
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(CAPTURAR_PAGO)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@fecha", Fecha.DTSistemaFecha());
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Alerta alerta = new Alerta(
                                    "ALERTAS DE FACTURACION",
                                    "Ha caducado el plazo de pago del comprobante "
                                        + Formulario.GenerarTipoComprobante(Convert.ToInt32(lectorDB["afip_cbte_tipo"]))
                                        + " N°" + Convert.ToString(lectorDB["afip_cbte_tpv"]).PadLeft(5, '0')
                                        + "-" + Convert.ToString(lectorDB["afip_cbte_nro"]).PadLeft(8, '0')
                                        + " Fecha: " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["afip_cbte_fecha"])),
                                    Convert.ToDateTime(lectorDB["pago_vto"]),
                                    "SIN PROCESAR",
                                    "CPR" + Convert.ToString(lectorDB["id"]).PadLeft(10, '0'));
                                _listaDeAlertas.Add(alerta); //Agrega este Objeto a la lista de Objetos
                            }
                            new D_Alerta().insertar(_listaDeAlertas); //Inserta los registros de alerta
                        }
                        using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ALERTAR_PAGO)) //Crea un comando de Base de Datos
                        {
                            comandoDB_update.Parameters.AddWithValue("@fecha", Fecha.DTSistemaFecha());
                            comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                        }
                    }
                    return true;
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M074MONITOR", "M076MONITOR", "M078MONITOR", "M080MONITOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool monitorearEstados()
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR_CURRICULUMVITAE)) //Asigna un comando de Base de Datos
                    {
                        comandoDB_update.Parameters.AddWithValue("@vencimiento", Fecha.DTSistemaFecha().AddMonths(-Global.Vigencia_CurriculumVitae));
                        comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                    }
                    using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR_CURSOINDUCCION)) //Asigna un comando de Base de Datos
                    {
                        comandoDB_update.Parameters.AddWithValue("@vencimiento", Fecha.DTSistemaFecha().AddMonths(-Global.Vigencia_CursoInduccion));
                        comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                    }
                    using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR_CURSOIZAJE)) //Asigna un comando de Base de Datos
                    {
                        comandoDB_update.Parameters.AddWithValue("@vencimiento", Fecha.DTSistemaFecha().AddMonths(-Global.Vigencia_CursoIzaje));
                        comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                    }
                    using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR_EXAMENMEDICO)) //Asigna un comando de Base de Datos
                    {
                        comandoDB_update.Parameters.AddWithValue("@vencimiento", Fecha.DTSistemaFecha().AddMonths(-Global.Vigencia_ExamenMedico));
                        comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                    }
                    return true;
                }
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M074MONITOR", "M076MONITOR", "M078MONITOR", "M080MONITOR", e); }
            finally { _conexion.Dispose(); }
            return false;
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