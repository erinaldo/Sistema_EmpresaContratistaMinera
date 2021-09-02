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
    public class D_PagoOtro : IPagoOtro, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_pago_otro.*";
        private const string FROM = @" FROM data_pago_otro";
        private const string WHERE1 = @" WHERE data_pago_otro.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE (data_pago_otro.cbte_tpv = @cbte_tpv AND data_pago_otro.cbte_nro = @cbte_nro)"; //Filtrar Objeto por Comprobante (TPV y Nro. De Comprobante)
        private const string WHERE3 = @" WHERE LOWER(denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE4 = @" WHERE LOWER(denominacion) LIKE LOWER(@denominacion) AND data_pago_otro.estado = @estado"; //Filtrar Objeto por Denominación y Estado
        private const string WHERE5 = @" WHERE periodo = @periodo"; //Filtrar Objeto por Periodo
        private const string WHERE6 = @" WHERE periodo = @periodo AND data_pago_otro.estado = @estado"; //Filtrar Objeto por Periodo y Estado
        private const string WHERE7 = @" WHERE date(cbte_fecha) >= date(@desde) AND date(cbte_fecha) <= date(@hasta)"; //Filtrar Objeto por Fecha de Emisión
        private const string WHERE8 = @" WHERE date(cbte_fecha) >= date(@desde) AND date(cbte_fecha) <= date(@hasta) AND data_pago_otro.estado = @estado"; //Filtrar Objeto por Fecha de Emisión y Estado
        private const string ORDER = @" ORDER BY data_pago_otro.cbte_fecha DESC, denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_pago_otro WHERE (cbte_tpv = @cbte_tpv AND cbte_nro = @cbte_nro) AND estado = 'ACTIVO' AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ANULAR = @"SELECT * FROM data_pago_otro WHERE id = @id AND estado = 'ANULADO'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_pago_otro WHERE (cbte_tpv = @cbte_tpv AND cbte_nro = @cbte_nro) AND estado = 'ACTIVO'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_pago_otro SET 
            id = @id,
            cbte_tpv = @cbte_tpv,
            cbte_nro = @cbte_nro,
            cbte_fecha = @cbte_fecha,
            estado = @estado,
            denominacion = @denominacion,
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
        private const string ANULAR = @"UPDATE data_pago_otro SET estado = 'ANULADO' WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_pago_otro (id, cbte_tpv, cbte_nro, cbte_fecha, estado,
            denominacion, id_centro_costo, id_cuenta_contable_destino, concepto, monto_pagado, id_cuenta_contable_origen,
            medio_pago, medio_nro, medio_cheque_vto, cta_bancaria_id, cta_bancaria_tipo, cta_bancaria_nro,
            edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @cbte_tpv, @cbte_nro, @cbte_fecha, @estado, @denominacion, @id_centro_costo,
            @id_cuenta_contable_destino, @concepto, @monto_pagado, @id_cuenta_contable_origen, @medio_pago, 
            @medio_nro, @medio_cheque_vto, @cta_bancaria_id, @cta_bancaria_tipo, @cta_bancaria_nro, @edicion_fecha,
            @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "COMPROBANTE") condicional = WHERE2; //Consulta filtrada por Comprobante (TPV y Nro. De Comprobante)
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE4 : WHERE3; //Consulta filtrada por Denominación y/o Estado
            if (campo == "PERIODO") condicional = ((estado != "TODOS") ? WHERE6 : WHERE5); //Consulta filtrada por Periodo y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_tpv", valor.Split('-')[0]); //Agrega el parámetro en la condición del contador
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_nro", valor.Split('-')[1]); //Agrega el parámetro en la condición del contador
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
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "PERIODO") comandoDB.Parameters.AddWithValue("@periodo", valor); //Agrega el parámetro en la condición de la consulta
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
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
                                            " | " + (Convert.ToString(lectorDB["denominacion"])).PadRight(35, ' '));
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
                                         " | " + (Convert.ToString(lectorDB["denominacion"])).PadRight(35, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002OTRO_PAGO: Hay un conflicto en la consulta de pagos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "FECHA") condicional = ((estado != "TODOS") ? WHERE8 : WHERE7); //Consulta filtrada por Fecha de Emisión y/o Estado
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
                                            " | " + (Convert.ToString(lectorDB["denominacion"])).PadRight(35, ' '));
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
                                         " | " + (Convert.ToString(lectorDB["denominacion"])).PadRight(35, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004OTRO_PAGO: Hay un conflicto en la consulta de pagos", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<PagoOtro> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "COMPROBANTE") condicional = WHERE2; //Consulta filtrada por Comprobante (TPV y Nro. De Comprobante)
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE4 : WHERE3; //Consulta filtrada por Denominación y/o Estado
            if (campo == "PERIODO") condicional = ((estado != "TODOS") ? WHERE6 : WHERE5); //Consulta filtrada por Periodo y/o Estado
            List<PagoOtro> ListaDeObjetos = new List<PagoOtro>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                PagoOtro objPagoOtro = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objPagoOtro); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006OTRO_PAGO: Hay un conflicto en la consulta de pagos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<PagoOtro> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            string condicional = "";
            if (campo == "FECHA") condicional = ((estado != "TODOS") ? WHERE8 : WHERE7); //Consulta filtrada por Fecha de Emisión y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            List<PagoOtro> ListaDeObjetos = new List<PagoOtro>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                PagoOtro objPagoOtro = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objPagoOtro); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008OTRO_PAGO: Hay un conflicto en la consulta de pagos", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public PagoOtro obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            PagoOtro objPagoOtro = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objPagoOtro = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
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
            catch (MySqlException e) { Mensaje.Error("Error-M010OTRO_PAGO: Hay un conflicto en la consulta del pago.", e); }
            finally { _conexion.Dispose(); }
            return objPagoOtro;
        }

        public bool actualizar(PagoOtro objPagoOtro)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objPagoOtro.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cbte_tpv", objPagoOtro.CbteTPV); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cbte_nro", objPagoOtro.CbteNro); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objPagoOtro.Id);
                                comandoDB_update.Parameters.AddWithValue("@cbte_tpv", objPagoOtro.CbteTPV);
                                comandoDB_update.Parameters.AddWithValue("@cbte_nro", objPagoOtro.CbteNro);
                                comandoDB_update.Parameters.AddWithValue("@cbte_fecha", objPagoOtro.CbteFecha);
                                comandoDB_update.Parameters.AddWithValue("@estado", objPagoOtro.Estado);
                                comandoDB_update.Parameters.AddWithValue("@denominacion", objPagoOtro.Denominacion);
                                comandoDB_update.Parameters.AddWithValue("@id_centro_costo", objPagoOtro.CentroCosto.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_cuenta_contable_destino", objPagoOtro.CuentaContableDestino.Id);
                                comandoDB_update.Parameters.AddWithValue("@concepto", objPagoOtro.Concepto);
                                comandoDB_update.Parameters.AddWithValue("@monto_pagado", objPagoOtro.MontoPagado);
                                comandoDB_update.Parameters.AddWithValue("@id_cuenta_contable_origen", objPagoOtro.CuentaContableOrigen.Id);
                                comandoDB_update.Parameters.AddWithValue("@medio_pago", objPagoOtro.MedioPago);
                                comandoDB_update.Parameters.AddWithValue("@medio_nro", objPagoOtro.MedioNro);
                                comandoDB_update.Parameters.AddWithValue("@medio_cheque_vto", objPagoOtro.MedioChequeVto);
                                comandoDB_update.Parameters.AddWithValue("@cta_bancaria_id", ((objPagoOtro.Banco != null) ? objPagoOtro.Banco.Id : 0));
                                comandoDB_update.Parameters.AddWithValue("@cta_bancaria_tipo", objPagoOtro.CtaBancariaTipo);
                                comandoDB_update.Parameters.AddWithValue("@cta_bancaria_nro", objPagoOtro.CtaBancariaNro);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objPagoOtro.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objPagoOtro.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objPagoOtro.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Otros Pagos", "Modificó el registro Id:" + objPagoOtro.Id.ToString() + "."); //Registra la actualización de un registro
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
            catch (MySqlException e) { Mensaje.ErrorMySql("M012OTRO_PAGO", "M014OTRO_PAGO", "M016OTRO_PAGO", "M018OTRO_PAGO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool anular(PagoOtro objPagoOtro)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ANULAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objPagoOtro.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ANULAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objPagoOtro.Id);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Otros Pagos", "Anuló el registro Id:" + objPagoOtro.Id + "."); //Registra la eliminación de un registro
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
            catch (MySqlException e) { Mensaje.ErrorMySql("M020OTRO_PAGO", "M022OTRO_PAGO", "M024OTRO_PAGO", "M026OTRO_PAGO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(PagoOtro objPagoOtro)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@cbte_tpv", objPagoOtro.CbteTPV); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cbte_nro", objPagoOtro.CbteNro); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objPagoOtro.Id);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_tpv", objPagoOtro.CbteTPV);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_nro", objPagoOtro.CbteNro);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_fecha", objPagoOtro.CbteFecha);
                                comandoDB_insert.Parameters.AddWithValue("@estado", objPagoOtro.Estado);
                                comandoDB_insert.Parameters.AddWithValue("@denominacion", objPagoOtro.Denominacion);
                                comandoDB_insert.Parameters.AddWithValue("@id_centro_costo", objPagoOtro.CentroCosto.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_cuenta_contable_destino", objPagoOtro.CuentaContableDestino.Id);
                                comandoDB_insert.Parameters.AddWithValue("@concepto", objPagoOtro.Concepto);
                                comandoDB_insert.Parameters.AddWithValue("@monto_pagado", objPagoOtro.MontoPagado);
                                comandoDB_insert.Parameters.AddWithValue("@id_cuenta_contable_origen", objPagoOtro.CuentaContableOrigen.Id);
                                comandoDB_insert.Parameters.AddWithValue("@medio_pago", objPagoOtro.MedioPago);
                                comandoDB_insert.Parameters.AddWithValue("@medio_nro", objPagoOtro.MedioNro);
                                comandoDB_insert.Parameters.AddWithValue("@medio_cheque_vto", objPagoOtro.MedioChequeVto);
                                comandoDB_insert.Parameters.AddWithValue("@cta_bancaria_id", ((objPagoOtro.Banco != null) ? objPagoOtro.Banco.Id : 0));
                                comandoDB_insert.Parameters.AddWithValue("@cta_bancaria_tipo", objPagoOtro.CtaBancariaTipo);
                                comandoDB_insert.Parameters.AddWithValue("@cta_bancaria_nro", objPagoOtro.CtaBancariaNro);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objPagoOtro.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objPagoOtro.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objPagoOtro.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Otros Pagos", "Agregó un nuevo registro ID:" + objPagoOtro.Id.ToString() + "."); //Registra la inserción de un registro
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
            catch (MySqlException e) { Mensaje.ErrorMySql("M028OTRO_PAGO", "M030OTRO_PAGO", "M032OTRO_PAGO", "M034OTRO_PAGO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private PagoOtro instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new PagoOtro(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToInt32(lectorDB["cbte_tpv"]),
                Convert.ToInt64(lectorDB["cbte_nro"]),
                Convert.ToDateTime(lectorDB["cbte_fecha"]),
                Convert.ToString(lectorDB["estado"]),
                Convert.ToString(lectorDB["denominacion"]),
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