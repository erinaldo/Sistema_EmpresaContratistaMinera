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
    public class D_PagoNomina : IPagoNomina, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_pago_nomina.*, 
            data_legajo.denominacion, data_legajo.documento, data_legajo.cuit, data_legajo.baja";
        private const string FROM = @" FROM data_pago_nomina
            INNER JOIN data_legajo ON data_pago_nomina.id_legajo = data_legajo.id";
        private const string WHERE1 = @" WHERE data_pago_nomina.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_pago_nomina.id_legajo = @id_legajo"; //Filtrar Objeto por ID Legajo
        private const string WHERE3 = @" WHERE data_pago_nomina.id_legajo = @id_legajo AND data_pago_nomina.id = (SELECT MAX(data_pago_nomina.id) FROM data_pago_nomina WHERE data_pago_nomina.id_legajo = @id_legajo AND data_pago_nomina.estado <> 'ANULADO')"; //Filtrar Objeto por ID Legajo (obtiene el registro más reciente y No anulado)
        private const string WHERE4 = @" WHERE (data_pago_nomina.cbte_tpv = @cbte_tpv AND data_pago_nomina.cbte_nro = @cbte_nro)"; //Filtrar Objeto por Comprobante (TPV y Nro. De Comprobante)
        private const string WHERE5 = @" WHERE data_legajo.cuit = @cuit"; //Filtrar Objeto por CUIL/CUIT
        private const string WHERE6 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE7 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion) AND data_pago_nomina.estado = @estado"; //Filtrar Objeto por Denominación y Estado
        private const string WHERE8 = @" WHERE periodo = @periodo"; //Filtrar Objeto por Periodo
        private const string WHERE9 = @" WHERE periodo = @periodo AND data_pago_nomina.estado = @estado"; //Filtrar Objeto por Periodo y Estado
        private const string WHERE10 = @" WHERE date(cbte_fecha) >= date(@desde) AND date(cbte_fecha) <= date(@hasta)"; //Filtrar Objeto por Fecha de Emisión
        private const string WHERE11 = @" WHERE date(cbte_fecha) >= date(@desde) AND date(cbte_fecha) <= date(@hasta) AND data_pago_nomina.estado = @estado"; //Filtrar Objeto por Fecha de Emisión y Estado
        private const string ORDER = @" ORDER BY data_pago_nomina.cbte_fecha DESC, data_legajo.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_pago_nomina WHERE (cbte_tpv = @cbte_tpv AND cbte_nro = @cbte_nro) AND estado = 'ACTIVO' AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ANULAR = @"SELECT * FROM data_pago_nomina WHERE id = @id AND estado = 'ANULADO'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_pago_nomina WHERE (cbte_tpv = @cbte_tpv AND cbte_nro = @cbte_nro) AND estado = 'ACTIVO'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_pago_nomina SET 
            id = @id,
            cbte_tpv = @cbte_tpv,
            cbte_nro = @cbte_nro,
            cbte_fecha = @cbte_fecha,
            estado = @estado,
            id_legajo = @id_legajo,
            id_centro_costo = @id_centro_costo,
            id_cuenta_contable_destino = @id_cuenta_contable_destino,
            concepto = @concepto,
            monto_pagado = @monto_pagado,
            id_cuenta_contable_origen = @id_cuenta_contable_origen,
            medio_pago = @medio_pago,
            medio_nro = @medio_nro,
            medio_cheque_vto = @medio_cheque_vto,
            cta_bancaria_id = @cta_bancaria_id,
            cta_bancaria_tipo = @cta_bancaria_tipo,
            cta_bancaria_nro = @cta_bancaria_nro,
            edicion_fecha = @edicion_fecha, 
            edicion_usuario_id = @edicion_usuario_id, 
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ANULAR = @"UPDATE data_pago_nomina SET estado = 'ANULADO' WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_pago_nomina (id, cbte_tpv, cbte_nro, cbte_fecha, estado,
            id_legajo, id_centro_costo, id_cuenta_contable_destino, concepto, monto_pagado, id_cuenta_contable_origen,
            medio_pago, medio_nro, medio_cheque_vto, cta_bancaria_id, cta_bancaria_tipo, cta_bancaria_nro,
            edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @cbte_tpv, @cbte_nro, @cbte_fecha, @estado, @id_legajo, @id_centro_costo, @id_cuenta_contable_destino,
            @concepto, @monto_pagado, @id_cuenta_contable_origen, @medio_pago, @medio_nro, @medio_cheque_vto, @cta_bancaria_id,
            @cta_bancaria_tipo, @cta_bancaria_nro, @edicion_fecha, @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "COMPROBANTE") condicional = WHERE4; //Consulta filtrada por Comprobante (TPV y Nro. De Comprobante)
            if (campo == "CUIT") condicional = WHERE5; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE7 : WHERE6; //Consulta filtrada por Denominación y/o Estado
            if (campo == "PERIODO") condicional = ((estado != "TODOS") ? WHERE9 : WHERE8); //Consulta filtrada por Periodo y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_tpv", valor.Split('-')[0]); //Agrega el parámetro en la condición del contador
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_nro", valor.Split('-')[1]); //Agrega el parámetro en la condición del contador
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "PERIODO") comandoDB.Parameters.AddWithValue("@periodo", valor); //Agrega el parámetro en la condición del contador
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_tpv", valor.Split('-')[0]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_nro", valor.Split('-')[1]); //Agrega el parámetro en la condición de la consulta
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
                                string medioDePago = Convert.ToString(lectorDB["medio_pago"]);
                                string numeroDePago = Convert.ToString(lectorDB["medio_nro"]);
                                string montoPagado = Convert.ToString(Formulario.ValidarNumeroDoble(Convert.ToString(lectorDB["monto_pagado"])));
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(7, ' ') +
                                            " | " + (medioDePago + ((!string.IsNullOrWhiteSpace(numeroDePago)) ? " (" + numeroDePago.PadLeft(8, '0') + ((medioDePago == "CHEQUE") ? " " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["medio_cheque_vto"])).PadLeft(10, '0') : "") + ")" : "")).PadRight(28, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(montoPagado).PadLeft(12, ' ') +
                                            " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(41, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                     Convert.ToInt64(lectorDB["id"]),
                                     Convert.ToString(lectorDB["cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["cbte_nro"]).PadLeft(8, '0') +
                                         " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cbte_fecha"])).PadLeft(10, '0') +
                                         " | " + Convert.ToString(lectorDB["estado"]).PadRight(7, ' ') +
                                         " | " + (medioDePago + ((!string.IsNullOrWhiteSpace(numeroDePago)) ? " (" + numeroDePago.PadLeft(8, '0') + ((medioDePago == "CHEQUE") ? " " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["medio_cheque_vto"])).PadLeft(10, '0') : "") + ")" : "")).PadRight(28, ' ') +
                                         " | " + Formulario.ValidarCampoMoneda(montoPagado).PadLeft(12, ' ') +
                                         " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002PAGO_NOMINA: Hay un conflicto en la consulta de pagos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "FECHA") condicional = ((estado != "TODOS") ? WHERE11 : WHERE10); //Consulta filtrada por Fecha de Emisión y/o Estado
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
                                string medioDePago = Convert.ToString(lectorDB["medio_pago"]);
                                string numeroDePago = Convert.ToString(lectorDB["medio_nro"]);
                                string montoPagado = Convert.ToString(Formulario.ValidarNumeroDoble(Convert.ToString(lectorDB["monto_pagado"])));
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(7, ' ') +
                                            " | " + (medioDePago + ((!string.IsNullOrWhiteSpace(numeroDePago)) ? " (" + numeroDePago.PadLeft(8, '0') + ((medioDePago == "CHEQUE") ? " " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["medio_cheque_vto"])).PadLeft(10, '0') : "") + ")" : "")).PadRight(28, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(montoPagado).PadLeft(12, ' ') +
                                            " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(41, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                     Convert.ToInt64(lectorDB["id"]),
                                     Convert.ToString(lectorDB["cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["cbte_nro"]).PadLeft(8, '0') +
                                         " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cbte_fecha"])).PadLeft(10, '0') +
                                         " | " + Convert.ToString(lectorDB["estado"]).PadRight(7, ' ') +
                                         " | " + (medioDePago + ((!string.IsNullOrWhiteSpace(numeroDePago)) ? " (" + numeroDePago.PadLeft(8, '0') + ((medioDePago == "CHEQUE") ? " " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["medio_cheque_vto"])).PadLeft(10, '0') : "") + ")" : "")).PadRight(28, ' ') +
                                         " | " + Formulario.ValidarCampoMoneda(montoPagado).PadLeft(12, ' ') +
                                         " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004PAGO_NOMINA: Hay un conflicto en la consulta de pagos", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<PagoNomina> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "COMPROBANTE") condicional = WHERE4; //Consulta filtrada por Comprobante (TPV y Nro. De Comprobante)
            if (campo == "CUIT") condicional = WHERE5; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE7 : WHERE6; //Consulta filtrada por Denominación y/o Estado
            if (campo == "PERIODO") condicional = ((estado != "TODOS") ? WHERE9 : WHERE8); //Consulta filtrada por Periodo y/o Estado
            List<PagoNomina> ListaDeObjetos = new List<PagoNomina>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_tpv", valor.Split('-')[0]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_nro", valor.Split('-')[1]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega un parámetro al filtro
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega un parámetro al filtro
                        if (campo == "PERIODO") comandoDB.Parameters.AddWithValue("@periodo", valor); //Agrega el parámetro en la condición de la consulta
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                PagoNomina objPagoNomina = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objPagoNomina); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006PAGO_NOMINA: Hay un conflicto en la consulta de pagos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<PagoNomina> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            string condicional = "";
            if (campo == "FECHA") condicional = ((estado != "TODOS") ? WHERE11 : WHERE10); //Consulta filtrada por Fecha de Emisión y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            List<PagoNomina> ListaDeObjetos = new List<PagoNomina>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                PagoNomina objPagoNomina = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objPagoNomina); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008PAGO_NOMINA: Hay un conflicto en la consulta de pagos", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public PagoNomina obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            if (campo == "ID_LEGAJO") condicional = WHERE2; //Consulta filtrada por ID Legajo
            if (campo == "ID_LEGAJO_RECIENTE") condicional = WHERE3; //Consulta filtrada por ID Legajo (obtiene el registro más reciente y No anulado)
            if (campo == "CUIT") condicional = WHERE5; //Consulta filtrada por CUIL/CUIT
            PagoNomina objPagoNomina = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objPagoNomina = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos del pago e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010PAGO_NOMINA: Hay un conflicto en la consulta del pago.", e); }
            finally { _conexion.Dispose(); }
            return objPagoNomina;
        }

        public bool actualizar(PagoNomina objPagoNomina)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objPagoNomina.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cbte_tpv", objPagoNomina.CbteTPV); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cbte_nro", objPagoNomina.CbteNro); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objPagoNomina.Id);
                                comandoDB_update.Parameters.AddWithValue("@cbte_tpv", objPagoNomina.CbteTPV);
                                comandoDB_update.Parameters.AddWithValue("@cbte_nro", objPagoNomina.CbteNro);
                                comandoDB_update.Parameters.AddWithValue("@cbte_fecha", objPagoNomina.CbteFecha);
                                comandoDB_update.Parameters.AddWithValue("@estado", objPagoNomina.Estado);
                                comandoDB_update.Parameters.AddWithValue("@id_legajo", objPagoNomina.Legajo.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_centro_costo", objPagoNomina.CentroCosto.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_cuenta_contable_destino", objPagoNomina.CuentaContableDestino.Id);
                                comandoDB_update.Parameters.AddWithValue("@concepto", objPagoNomina.Concepto);
                                comandoDB_update.Parameters.AddWithValue("@monto_pagado", objPagoNomina.MontoPagado);
                                comandoDB_update.Parameters.AddWithValue("@id_cuenta_contable_origen", objPagoNomina.CuentaContableOrigen.Id);
                                comandoDB_update.Parameters.AddWithValue("@medio_pago", objPagoNomina.MedioPago);
                                comandoDB_update.Parameters.AddWithValue("@medio_nro", objPagoNomina.MedioNro);
                                comandoDB_update.Parameters.AddWithValue("@medio_cheque_vto", objPagoNomina.MedioChequeVto);
                                comandoDB_update.Parameters.AddWithValue("@cta_bancaria_id", ((objPagoNomina.Banco != null) ? objPagoNomina.Banco.Id : 0));
                                comandoDB_update.Parameters.AddWithValue("@cta_bancaria_tipo", objPagoNomina.CtaBancariaTipo);
                                comandoDB_update.Parameters.AddWithValue("@cta_bancaria_nro", objPagoNomina.CtaBancariaNro);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objPagoNomina.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objPagoNomina.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objPagoNomina.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Pagos a Nómina", "Modificó el registro Id:" + objPagoNomina.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Inaccesible.\nEl comprobante de pago No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M012PAGO_NOMINA", "M014PAGO_NOMINA", "M016PAGO_NOMINA", "M018PAGO_NOMINA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool anular(PagoNomina objPagoNomina)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ANULAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objPagoNomina.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ANULAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objPagoNomina.Id);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Pagos a Nómina", "Anuló el registro Id:" + objPagoNomina.Id + "."); //Registra la eliminación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Anulado.\nEl pago ya se encuentra anulado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M020PAGO_NOMINA", "M022PAGO_NOMINA", "M024PAGO_NOMINA", "M026PAGO_NOMINA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(PagoNomina objPagoNomina)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@cbte_tpv", objPagoNomina.CbteTPV); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cbte_nro", objPagoNomina.CbteNro); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objPagoNomina.Id);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_tpv", objPagoNomina.CbteTPV);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_nro", objPagoNomina.CbteNro);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_fecha", objPagoNomina.CbteFecha);
                                comandoDB_insert.Parameters.AddWithValue("@estado", objPagoNomina.Estado);
                                comandoDB_insert.Parameters.AddWithValue("@id_legajo", objPagoNomina.Legajo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_centro_costo", objPagoNomina.CentroCosto.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_cuenta_contable_destino", objPagoNomina.CuentaContableDestino.Id);
                                comandoDB_insert.Parameters.AddWithValue("@concepto", objPagoNomina.Concepto);
                                comandoDB_insert.Parameters.AddWithValue("@monto_pagado", objPagoNomina.MontoPagado);
                                comandoDB_insert.Parameters.AddWithValue("@id_cuenta_contable_origen", objPagoNomina.CuentaContableOrigen.Id);
                                comandoDB_insert.Parameters.AddWithValue("@medio_pago", objPagoNomina.MedioPago);
                                comandoDB_insert.Parameters.AddWithValue("@medio_nro", objPagoNomina.MedioNro);
                                comandoDB_insert.Parameters.AddWithValue("@medio_cheque_vto", objPagoNomina.MedioChequeVto);
                                comandoDB_insert.Parameters.AddWithValue("@cta_bancaria_id", ((objPagoNomina.Banco != null) ? objPagoNomina.Banco.Id : 0));
                                comandoDB_insert.Parameters.AddWithValue("@cta_bancaria_tipo", objPagoNomina.CtaBancariaTipo);
                                comandoDB_insert.Parameters.AddWithValue("@cta_bancaria_nro", objPagoNomina.CtaBancariaNro);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objPagoNomina.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objPagoNomina.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objPagoNomina.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Pagos a Nómina", "Agregó un nuevo registro ID:" + objPagoNomina.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl comprobante de pago ya se encuentra registrado en la Base de Datos."); Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M028PAGO_NOMINA", "M030PAGO_NOMINA", "M032PAGO_NOMINA", "M034PAGO_NOMINA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private PagoNomina instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new PagoNomina(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToInt32(lectorDB["cbte_tpv"]),
                Convert.ToInt64(lectorDB["cbte_nro"]),
                Convert.ToDateTime(lectorDB["cbte_fecha"]),
                Convert.ToString(lectorDB["estado"]),
                new D_Legajo().obtenerObjeto("ID", Convert.ToString(lectorDB["id_legajo"]), false),
                new D_CentroCosto().obtenerObjeto("ID", Convert.ToString(lectorDB["id_centro_costo"]), false),
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable_destino"]), false),
                Convert.ToString(lectorDB["concepto"]),
                Convert.ToDouble(lectorDB["monto_pagado"]),
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable_origen"]), false),
                Convert.ToString(lectorDB["medio_pago"]),
                Convert.ToInt64(lectorDB["medio_nro"]),
                Convert.ToDateTime(lectorDB["medio_cheque_vto"]),
                ((Convert.ToInt32(lectorDB["cta_bancaria_id"]) > 0) ? new D_Banco().obtenerObjeto("ID", Convert.ToString(lectorDB["cta_bancaria_id"]), false) : new Banco(0, "")),
                Convert.ToString(lectorDB["cta_bancaria_tipo"]),
                Convert.ToString(lectorDB["cta_bancaria_nro"]),
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