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
    public class D_MovimientoFondo : IMovimientoFondo, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_movimiento_fondo.*,
            data_cuenta_contable_origen.denominacion AS cuenta_contable1,
            data_cuenta_contable_destino.denominacion AS cuenta_contable2";
        private const string FROM = @" FROM data_movimiento_fondo
            LEFT JOIN data_cuenta_contable data_cuenta_contable_origen ON data_movimiento_fondo.id_cuenta_contable_origen = data_cuenta_contable_origen.id
            LEFT JOIN data_cuenta_contable data_cuenta_contable_destino ON data_movimiento_fondo.id_cuenta_contable_destino = data_cuenta_contable_destino.id";
        private const string WHERE1 = @" WHERE data_movimiento_fondo.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE (data_movimiento_fondo.cbte_tpv = @cbte_tpv AND data_movimiento_fondo.cbte_nro = @cbte_nro)"; //Filtrar Objeto por Comprobante (TPV y Nro. De Comprobante)
        private const string WHERE3 = @" WHERE LOWER(data_movimiento_fondo.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE4 = @" WHERE LOWER(data_movimiento_fondo.denominacion) LIKE LOWER(@denominacion) AND data_movimiento_fondo.estado = @estado"; //Filtrar Objeto por Denominación y Estado
        private const string WHERE5 = @" WHERE date(data_movimiento_fondo.cbte_fecha) >= date(@desde) AND date(data_movimiento_fondo.cbte_fecha) <= date(@hasta)"; //Filtrar Objeto por Fecha de Comprobante
        private const string WHERE6 = @" WHERE date(data_movimiento_fondo.cbte_fecha) >= date(@desde) AND date(data_movimiento_fondo.cbte_fecha) <= date(@hasta) AND data_movimiento_fondo.estado = @estado"; //Filtrar Objeto por Fecha de Comprobante y Estado
        private const string ORDER = @" ORDER BY data_movimiento_fondo.cbte_fecha DESC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_movimiento_fondo WHERE (cbte_tpv = @cbte_tpv AND cbte_nro = @cbte_nro) AND estado = 'ACTIVO' AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ANULAR = @"SELECT * FROM data_movimiento_fondo WHERE id = @id AND estado = 'ANULADO'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_movimiento_fondo WHERE (cbte_tpv = @cbte_tpv AND cbte_nro = @cbte_nro) AND estado = 'ACTIVO'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_movimiento_fondo SET 
            id = @id,
            cbte_tpv = @cbte_tpv,
            cbte_nro = @cbte_nro,
            cbte_fecha = @cbte_fecha,
            estado = @estado,
            denominacion = @denominacion,
            monto = @monto,
            id_cuenta_contable_origen = @id_cuenta_contable_origen,
            id_cuenta_contable_destino = @id_cuenta_contable_destino,
            medio_pago = @medio_pago,
            medio_nro = @medio_nro,
            medio_cheque_vto = @medio_cheque_vto,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ANULAR = @"UPDATE data_movimiento_fondo SET estado = 'ANULADO' WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_movimiento_fondo(id, cbte_tpv, cbte_nro, cbte_fecha,
            estado, denominacion, monto, id_cuenta_contable_origen, id_cuenta_contable_destino, medio_pago,
            medio_nro, medio_cheque_vto, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @cbte_tpv, @cbte_nro, @cbte_fecha, @estado, @denominacion, @monto, @id_cuenta_contable_origen,
            @id_cuenta_contable_destino, @medio_pago, @medio_nro, @medio_cheque_vto, @edicion_fecha,
            @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "COMPROBANTE") condicional = WHERE2; //Consulta filtrada por Comprobante (TPV y Nro. De Comprobante)
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE4 : WHERE3; //Consulta filtrada por Estado y/o Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
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
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_tpv", valor.Split('-')[0]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_nro", valor.Split('-')[1]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición e la consulta
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                string medioDePago = Convert.ToString(lectorDB["medio_pago"]);
                                string numeroDePago = Convert.ToString(lectorDB["medio_nro"]);
                                string montoPagado = Convert.ToString(Formulario.ValidarNumeroDoble(Convert.ToString(lectorDB["monto"])));
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(7, ' ') +
                                            " | " + (medioDePago + ((!string.IsNullOrWhiteSpace(numeroDePago)) ? " (" + numeroDePago.PadLeft(8, '0') + ((medioDePago == "CHEQUE") ? " " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["medio_cheque_vto"])).PadLeft(10, '0') : "") + ")" : "")).PadRight(28, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(montoPagado).PadLeft(12, ' ') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' '));
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
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToString(lectorDB["cuenta_contable1"]).PadRight(25, ' ') +
                                            " | " + Convert.ToString(lectorDB["cuenta_contable2"]).PadRight(25, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002MOV_FONDOS: Hay un conflicto en la consulta de los movimientos de fondos", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "FECHA") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Estado y/o Fecha de Comprobante
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
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                string medioDePago = Convert.ToString(lectorDB["medio_pago"]);
                                string numeroDePago = Convert.ToString(lectorDB["medio_nro"]);
                                string montoPagado = Convert.ToString(Formulario.ValidarNumeroDoble(Convert.ToString(lectorDB["monto"])));
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(7, ' ') +
                                            " | " + (medioDePago + ((!string.IsNullOrWhiteSpace(numeroDePago)) ? " (" + numeroDePago.PadLeft(8, '0') + ((medioDePago == "CHEQUE") ? " " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["medio_cheque_vto"])).PadLeft(10, '0') : "") + ")" : "")).PadRight(28, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(montoPagado).PadLeft(12, ' ') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' '));
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
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToString(lectorDB["cuenta_contable1"]).PadRight(25, ' ') +
                                            " | " + Convert.ToString(lectorDB["cuenta_contable2"]).PadRight(25, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004MOV_FONDOS: Hay un conflicto en la consulta de los movimientos de fondos", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<MovimientoFondo> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "COMPROBANTE") condicional = WHERE2; //Consulta filtrada por Comprobante (TPV y Nro. De Comprobante)
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE4 : WHERE3; //Consulta filtrada por Estado y/o Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            List<MovimientoFondo> ListaDeObjetos = new List<MovimientoFondo>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_tpv", valor.Split('-')[0]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_nro", valor.Split('-')[1]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición e la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                MovimientoFondo objMovimientoFondo = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objMovimientoFondo); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006MOV_FONDOS: Hay un conflicto en la consulta de los movimientos de fondos", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<MovimientoFondo> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            string condicional = "";
            if (campo == "FECHA") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Estado y/o Fecha de Comprobante
            List<MovimientoFondo> ListaDeObjetos = new List<MovimientoFondo>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro terciario
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro terciario
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                MovimientoFondo objMovimientoFondo = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objMovimientoFondo); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008MOV_FONDOS: Hay un conflicto en la consulta de los movimientos de fondos", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public MovimientoFondo obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            MovimientoFondo objMovimientoFondo = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objMovimientoFondo = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos del movimiento de fondos e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010MOV_FONDOS: Hay un conflicto en la consulta del movimiento de fondos", e); }
            finally { _conexion.Dispose(); }
            return objMovimientoFondo;
        }

        public bool actualizar(MovimientoFondo objMovimientoFondo)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objMovimientoFondo.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cbte_tpv", objMovimientoFondo.CbteTPV); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cbte_nro", objMovimientoFondo.CbteNro); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objMovimientoFondo.Id);
                                comandoDB_update.Parameters.AddWithValue("@cbte_tpv", objMovimientoFondo.CbteTPV);
                                comandoDB_update.Parameters.AddWithValue("@cbte_nro", objMovimientoFondo.CbteNro);
                                comandoDB_update.Parameters.AddWithValue("@cbte_fecha", objMovimientoFondo.CbteFecha);
                                comandoDB_update.Parameters.AddWithValue("@estado", objMovimientoFondo.Estado);
                                comandoDB_update.Parameters.AddWithValue("@denominacion", objMovimientoFondo.Denominacion);
                                comandoDB_update.Parameters.AddWithValue("@monto", objMovimientoFondo.Monto);
                                comandoDB_update.Parameters.AddWithValue("@id_cuenta_contable_origen", objMovimientoFondo.CuentaContableOrigen.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_cuenta_contable_destino", objMovimientoFondo.CuentaContableDestino.Id);
                                comandoDB_update.Parameters.AddWithValue("@medio_pago", objMovimientoFondo.MedioPago);
                                comandoDB_update.Parameters.AddWithValue("@medio_nro", objMovimientoFondo.MedioNro);
                                comandoDB_update.Parameters.AddWithValue("@medio_cheque_vto", objMovimientoFondo.MedioChequeVto);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objMovimientoFondo.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objMovimientoFondo.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objMovimientoFondo.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Movimiento de Fondos", "Modificó el registro ID:" + objMovimientoFondo.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Inaccesible.\nEl movimiento de fondos No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M012CBTE_MOV_FONDOS", "M014CBTE_MOV_FONDOS", "M016CBTE_MOV_FONDOS", "M018CBTE_MOV_FONDOS", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool anular(MovimientoFondo objMovimientoFondo)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ANULAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objMovimientoFondo.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ANULAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objMovimientoFondo.Id);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Movimiento de Fondos", "Anuló el registro Id:" + objMovimientoFondo.Id + "."); //Registra la eliminación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Anulado.\nEl movimiento de fondos ya se encuentra anulado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M020CBTE_MOV_FONDOS", "M022CBTE_MOV_FONDOS", "M024CBTE_MOV_FONDOS", "M026CBTE_MOV_FONDOS", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(MovimientoFondo objMovimientoFondo)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@cbte_tpv", objMovimientoFondo.CbteTPV); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cbte_nro", objMovimientoFondo.CbteNro); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objMovimientoFondo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_tpv", objMovimientoFondo.CbteTPV);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_nro", objMovimientoFondo.CbteNro);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_fecha", objMovimientoFondo.CbteFecha);
                                comandoDB_insert.Parameters.AddWithValue("@estado", objMovimientoFondo.Estado);
                                comandoDB_insert.Parameters.AddWithValue("@denominacion", objMovimientoFondo.Denominacion);
                                comandoDB_insert.Parameters.AddWithValue("@monto", objMovimientoFondo.Monto);
                                comandoDB_insert.Parameters.AddWithValue("@id_cuenta_contable_origen", objMovimientoFondo.CuentaContableOrigen.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_cuenta_contable_destino", objMovimientoFondo.CuentaContableDestino.Id);
                                comandoDB_insert.Parameters.AddWithValue("@medio_pago", objMovimientoFondo.MedioPago);
                                comandoDB_insert.Parameters.AddWithValue("@medio_nro", objMovimientoFondo.MedioNro);
                                comandoDB_insert.Parameters.AddWithValue("@medio_cheque_vto", objMovimientoFondo.MedioChequeVto);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objMovimientoFondo.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objMovimientoFondo.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objMovimientoFondo.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Movimiento de Fondos", "Agregó un nuevo registro ID:" + objMovimientoFondo.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl movimiento de fondos ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M028CBTE_MOV_FONDOS", "M030CBTE_MOV_FONDOS", "M032CBTE_MOV_FONDOS", "M034CBTE_MOV_FONDOS", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private MovimientoFondo instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new MovimientoFondo(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToInt32(lectorDB["cbte_tpv"]),
                Convert.ToInt64(lectorDB["cbte_nro"]),
                Convert.ToDateTime(lectorDB["cbte_fecha"]),
                Convert.ToString(lectorDB["estado"]),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToDouble(lectorDB["monto"]),
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable_origen"]), false),
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable_destino"]), false),
                Convert.ToString(lectorDB["medio_pago"]),
                Convert.ToInt64(lectorDB["medio_nro"]),
                Convert.ToDateTime(lectorDB["medio_cheque_vto"]),
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