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
    public class D_PagoProveedor : IPagoProveedor, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT1 = @"SELECT data_pago_proveedor.id, data_pago_proveedor.cbte_tpv,
            data_pago_proveedor.cbte_nro, data_pago_proveedor.cbte_fecha, data_pago_proveedor.estado, 
            medio_pago, medio_nro, medio_cheque_vto, monto_pagado, data_proveedor.denominacion, cuit";
        private const string SELECT2 = @"SELECT data_pago_proveedor.*, data_proveedor.denominacion, cuit";
        private const string FROM = @" FROM data_pago_proveedor
            INNER JOIN data_proveedor ON data_pago_proveedor.id_proveedor = data_proveedor.id";
        private const string WHERE1 = @" WHERE data_pago_proveedor.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE (data_pago_proveedor.cbte_tpv = @cbte_tpv AND data_pago_proveedor.cbte_nro = @cbte_nro)"; //Filtrar Objeto por Comprobante (TPV y Nro. De Comprobante)
        private const string WHERE3 = @" WHERE data_proveedor.cuit = @cuit"; //Filtrar Objeto por CUIT
        private const string WHERE4 = @" WHERE data_proveedor.cuit = @cuit AND data_pago_proveedor.estado = @estado"; //Filtrar Objeto por CUIT y Estado
        private const string WHERE5 = @" WHERE LOWER(data_proveedor.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE6 = @" WHERE LOWER(data_proveedor.denominacion) LIKE LOWER(@denominacion) AND data_pago_proveedor.estado = @estado"; //Filtrar Objeto por Denominación y Estado
        private const string WHERE7 = @" WHERE date(data_pago_proveedor.cbte_fecha) >= date(@desde) AND date(data_pago_proveedor.cbte_fecha) <= date(@hasta)"; //Filtrar Objeto por Fecha de Comprobante
        private const string WHERE8 = @" WHERE date(data_pago_proveedor.cbte_fecha) >= date(@desde) AND date(data_pago_proveedor.cbte_fecha) <= date(@hasta) AND data_pago_proveedor.estado = @estado"; //Filtrar Objeto por Fecha de Comprobante y Estado
        private const string ORDER = @" ORDER BY data_pago_proveedor.cbte_fecha DESC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_pago_proveedor WHERE (cbte_tpv = @cbte_tpv AND cbte_nro = @cbte_nro) AND estado = 'ACTIVO' AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ANULAR = @"SELECT * FROM data_pago_proveedor WHERE id = @id AND estado = 'ANULADO'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_pago_proveedor WHERE (cbte_tpv = @cbte_tpv AND cbte_nro = @cbte_nro) AND estado = 'ACTIVO'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_pago_proveedor SET 
            id = @id,
            cbte_tpv = @cbte_tpv,
            cbte_nro = @cbte_nro,
            cbte_fecha = @cbte_fecha,
            estado = @estado,
            id_proveedor = @id_proveedor,
            concepto = @concepto,
            monto_pagado = @monto_pagado,
            id_cuenta_contable = @id_cuenta_contable,
            medio_pago = @medio_pago,
            medio_nro = @medio_nro,
            medio_cheque_vto = @medio_cheque_vto,
            cta_bancaria_id = @cta_bancaria_id,
            cta_bancaria_tipo = @cta_bancaria_tipo,
            cta_bancaria_nro = @cta_bancaria_nro,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ANULAR = @"UPDATE data_pago_proveedor SET estado = 'ANULADO' WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_pago_proveedor (id, cbte_tpv, cbte_nro, cbte_fecha, estado,
            id_proveedor, concepto, monto_pagado, id_cuenta_contable, medio_pago, medio_nro, medio_cheque_vto,
            cta_bancaria_id, cta_bancaria_tipo, cta_bancaria_nro, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @cbte_tpv, @cbte_nro, @cbte_fecha, @estado, @id_proveedor, @concepto, @monto_pagado,
            @id_cuenta_contable, @medio_pago, @medio_nro, @medio_cheque_vto, @cta_bancaria_id, @cta_bancaria_tipo,
            @cta_bancaria_nro, @edicion_fecha, @edicion_usuario_id, @edicion_usuario)";
        #endregion
        
        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "COMPROBANTE") condicional = WHERE2; //Consulta filtrada por Comprobante (TPV y Nro. De Comprobante)
            if (campo == "CUIT") condicional = (estado != "TODOS") ? WHERE4 : WHERE3; //Consulta filtrada por Estado y/o CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Estado y/o Denominación
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
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_tpv", valor.Split('-')[0]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_nro", valor.Split('-')[1]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición de la consulta
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
                                        " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
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
                                        " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002PAGO_PROVEEDOR: Hay un conflicto en la consulta del pago.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "FECHA") condicional = (estado != "TODOS") ? WHERE8 : WHERE7; //Consulta filtrada por Estado y/o Fecha de Comprobante
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
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
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
                                        " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
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
                                        " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004PAGO_PROVEEDOR: Hay un conflicto en la consulta del pago.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<PagoProveedor> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "COMPROBANTE") condicional = WHERE2; //Consulta filtrada por Comprobante (TPV y Nro. De Comprobante)
            if (campo == "CUIT") condicional = (estado != "TODOS") ? WHERE4 : WHERE3; //Consulta filtrada por Estado y/o CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Estado y/o Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            List<PagoProveedor> ListaDeObjetos = new List<PagoProveedor>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_tpv", valor.Split('-')[0]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_nro", valor.Split('-')[1]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición e la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                PagoProveedor objPagoProveedor = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objPagoProveedor); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006PAGO_PROVEEDOR: Hay un conflicto en la consulta del pago.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<PagoProveedor> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            string condicional = "";
            if (campo == "FECHA") condicional = (estado != "TODOS") ? WHERE8 : WHERE7; //Consulta filtrada por Estado y/o Fecha de Comprobante
            List<PagoProveedor> ListaDeObjetos = new List<PagoProveedor>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro terciario
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro terciario
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                PagoProveedor objPagoProveedor = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objPagoProveedor); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008PAGO_PROVEEDOR: Hay un conflicto en la consulta del pago.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public PagoProveedor obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            PagoProveedor objPagoProveedor = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT2 + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objPagoProveedor = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos del comprobante de pago e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010PAGO_PROVEEDOR: Hay un conflicto en la consulta del comprobante de pago.", e); }
            finally { _conexion.Dispose(); }
            return objPagoProveedor;
        }

        public bool actualizar(PagoProveedor objPagoProveedor)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objPagoProveedor.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cbte_tpv", objPagoProveedor.CbteTPV); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cbte_nro", objPagoProveedor.CbteNro); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objPagoProveedor.Id);
                                comandoDB_update.Parameters.AddWithValue("@cbte_tpv", objPagoProveedor.CbteTPV);
                                comandoDB_update.Parameters.AddWithValue("@cbte_nro", objPagoProveedor.CbteNro);
                                comandoDB_update.Parameters.AddWithValue("@cbte_fecha", objPagoProveedor.CbteFecha);
                                comandoDB_update.Parameters.AddWithValue("@estado", objPagoProveedor.Estado);
                                comandoDB_update.Parameters.AddWithValue("@id_proveedor", objPagoProveedor.Proveedor.Id);
                                comandoDB_update.Parameters.AddWithValue("@concepto", objPagoProveedor.Concepto);
                                comandoDB_update.Parameters.AddWithValue("@monto_pagado", objPagoProveedor.MontoPagado);
                                comandoDB_update.Parameters.AddWithValue("@id_cuenta_contable", objPagoProveedor.CuentaContable.Id);
                                comandoDB_update.Parameters.AddWithValue("@medio_pago", objPagoProveedor.MedioPago);
                                comandoDB_update.Parameters.AddWithValue("@medio_nro", objPagoProveedor.MedioNro);
                                comandoDB_update.Parameters.AddWithValue("@medio_cheque_vto", objPagoProveedor.MedioChequeVto);
                                comandoDB_update.Parameters.AddWithValue("@cta_bancaria_id", ((objPagoProveedor.Banco != null) ? objPagoProveedor.Banco.Id : 0));
                                comandoDB_update.Parameters.AddWithValue("@cta_bancaria_tipo", objPagoProveedor.CtaBancariaTipo);
                                comandoDB_update.Parameters.AddWithValue("@cta_bancaria_nro", objPagoProveedor.CtaBancariaNro);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objPagoProveedor.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objPagoProveedor.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objPagoProveedor.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Pagos a Proveedores", "Modificó el registro ID:" + objPagoProveedor.Id.ToString() + "."); //Registra la actualización de un registro
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
            catch (MySqlException e) { Mensaje.ErrorMySql("M012CBTE_PAGO_PROVEEDOR", "M014CBTE_PAGO_PROVEEDOR", "M016CBTE_PAGO_PROVEEDOR", "M018CBTE_PAGO_PROVEEDOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool anular(PagoProveedor objPagoProveedor)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ANULAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objPagoProveedor.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ANULAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objPagoProveedor.Id);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Pagos a Proveedores", "Anuló el registro Id:" + objPagoProveedor.Id + "."); //Registra la eliminación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Anulado.\nEl comprobante de pago ya se encuentra anulado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M020CBTE_PAGO_PROVEEDOR", "M022CBTE_PAGO_PROVEEDOR", "M024CBTE_PAGO_PROVEEDOR", "M026CBTE_PAGO_PROVEEDOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(PagoProveedor objPagoProveedor)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@cbte_tpv", objPagoProveedor.CbteTPV); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cbte_nro", objPagoProveedor.CbteNro); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objPagoProveedor.Id);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_tpv", objPagoProveedor.CbteTPV);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_nro", objPagoProveedor.CbteNro);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_fecha", objPagoProveedor.CbteFecha);
                                comandoDB_insert.Parameters.AddWithValue("@estado", objPagoProveedor.Estado);
                                comandoDB_insert.Parameters.AddWithValue("@id_proveedor", objPagoProveedor.Proveedor.Id);
                                comandoDB_insert.Parameters.AddWithValue("@concepto", objPagoProveedor.Concepto);
                                comandoDB_insert.Parameters.AddWithValue("@monto_pagado", objPagoProveedor.MontoPagado);
                                comandoDB_insert.Parameters.AddWithValue("@id_cuenta_contable", objPagoProveedor.CuentaContable.Id);
                                comandoDB_insert.Parameters.AddWithValue("@medio_pago", objPagoProveedor.MedioPago);
                                comandoDB_insert.Parameters.AddWithValue("@medio_nro", objPagoProveedor.MedioNro);
                                comandoDB_insert.Parameters.AddWithValue("@medio_cheque_vto", objPagoProveedor.MedioChequeVto);
                                comandoDB_insert.Parameters.AddWithValue("@cta_bancaria_id", ((objPagoProveedor.Banco != null) ? objPagoProveedor.Banco.Id : 0));
                                comandoDB_insert.Parameters.AddWithValue("@cta_bancaria_tipo", objPagoProveedor.CtaBancariaTipo);
                                comandoDB_insert.Parameters.AddWithValue("@cta_bancaria_nro", objPagoProveedor.CtaBancariaNro);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objPagoProveedor.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objPagoProveedor.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objPagoProveedor.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Pagos a Proveedores", "Agregó un nuevo registro ID:" + objPagoProveedor.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M028CBTE_PAGO_PROVEEDOR", "M030CBTE_PAGO_PROVEEDOR", "M032CBTE_PAGO_PROVEEDOR", "M034CBTE_PAGO_PROVEEDOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private PagoProveedor instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new PagoProveedor(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToInt32(lectorDB["cbte_tpv"]),
                Convert.ToInt64(lectorDB["cbte_nro"]),
                Convert.ToDateTime(lectorDB["cbte_fecha"]),
                Convert.ToString(lectorDB["estado"]),
                new D_Proveedor().obtenerObjeto("TODOS", "ID", Convert.ToString(lectorDB["id_proveedor"]), false),
                Convert.ToString(lectorDB["concepto"]),
                Convert.ToDouble(lectorDB["monto_pagado"]),
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable"]), false),
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
