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
    public class D_OrdenCompra : IOrdenCompra, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT1 = @"SELECT data_orden_compra.id, cbte_tpv, cbte_nro, cbte_fecha, 
            data_orden_compra.estado, autorizacion, fecha_arribo, total, data_proveedor.denominacion, data_proveedor.cuit";
        private const string SELECT2 = @"SELECT data_orden_compra.*, 
            data_proveedor.denominacion, data_proveedor.cuit";
        private const string FROM = @" FROM data_orden_compra 
            INNER JOIN data_proveedor ON data_orden_compra.id_proveedor = data_proveedor.id";
        private const string WHERE1 = @" WHERE data_orden_compra.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE (data_orden_compra.cbte_tpv = @cbte_tpv AND data_orden_compra.cbte_nro = @cbte_nro)"; //Filtrar Objeto por Comprobante (TPV y Nro. De Comprobante)
        private const string WHERE3 = @" WHERE data_proveedor.cuit = @cuit"; //Filtrar Objeto por CUIT
        private const string WHERE4 = @" WHERE data_proveedor.cuit = @cuit AND data_orden_compra.estado = @estado"; //Filtrar Objeto por Tipo de Comprobante y CUIT
        private const string WHERE5 = @" WHERE LOWER(data_proveedor.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE6 = @" WHERE LOWER(data_proveedor.denominacion) LIKE LOWER(@denominacion) AND data_orden_compra.estado = @estado"; //Filtrar Objeto por Tipo de Comprobante y Denominación
        private const string WHERE7 = @" WHERE date(data_orden_compra.cbte_fecha) >= date(@desde) AND date(data_orden_compra.cbte_fecha) <= date(@hasta)"; //Filtrar Objeto por Fecha de Comprobante
        private const string WHERE8 = @" WHERE date(data_orden_compra.cbte_fecha) >= date(@desde) AND date(data_orden_compra.cbte_fecha) <= date(@hasta) AND data_orden_compra.estado = @estado"; //Filtrar Objeto por Tipo de Comprobante y Fecha de Comprobante
        private const string ORDER = @" ORDER BY data_orden_compra.cbte_fecha DESC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_orden_compra WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ANULAR = @"SELECT * FROM data_orden_compra WHERE id = @id AND estado = 'ANULADO'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_AUTORIZAR = @"SELECT * FROM data_orden_compra WHERE id = @id AND autorizacion = 'AUTORIZADO'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_orden_compra WHERE cbte_tpv = @cbte_tpv AND cbte_nro = @cbte_nro AND id_proveedor = @id_proveedor"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_orden_compra SET 
            id = @id,
            cbte_tpv = @cbte_tpv,
            cbte_nro = @cbte_nro,
            cbte_fecha = @cbte_fecha,
            estado = @estado,
            autorizacion = @autorizacion,
            id_proveedor = @id_proveedor,
            id_cuenta_contable = @id_cuenta_contable,
            fecha_arribo = @fecha_arribo,
            descuento_porcentual = @descuento_porcentual,
            descuento = @descuento,
            subtotal = @subtotal,
            iva105 = @iva105,
            iva210 = @iva210,
            iva270 = @iva270,
            percepcion_iibb = @percepcion_iibb,
            percepcion_lh = @percepcion_lh,
            percepcion_iva = @percepcion_iva,
            no_gravado = @no_gravado,
            impuesto_interno = @impuesto_interno,
            total = @total,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ANULAR = @"UPDATE data_orden_compra SET estado = 'ANULADO' WHERE id = @id";
        private const string AUTORIZAR = @"UPDATE data_orden_compra SET autorizacion = 'AUTORIZADO' WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_orden_compra(id, cbte_tpv, cbte_nro, cbte_fecha,
            estado, autorizacion, id_proveedor, id_cuenta_contable, fecha_arribo, descuento_porcentual,
            descuento, subtotal, iva105, iva210, iva270, percepcion_iibb, percepcion_lh, percepcion_iva,
            no_gravado, impuesto_interno, total, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @cbte_tpv, @cbte_nro, @cbte_fecha, @estado, @autorizacion, @id_proveedor,
            @id_cuenta_contable, @fecha_arribo, @descuento_porcentual, @descuento, @subtotal, @iva105,
            @iva210, @iva270, @percepcion_iibb, @percepcion_lh, @percepcion_iva, @no_gravado,
            @impuesto_interno, @total, @edicion_fecha, @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "COMPROBANTE") condicional = WHERE2; //Consulta filtrada por Comprobante (TPV y Nro. De Comprobante)
            if (campo == "CUIT") condicional = ((estado != "TODOS") ? WHERE4 : WHERE3); //Consulta filtrada por Tipo de Comprobante y/o CUIT
            if (campo == "DENOMINACION") condicional = ((estado != "TODOS") ? WHERE6 : WHERE5); //Consulta filtrada por Tipo de Comprobante y/o Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID OrdenCompra
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
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(7, ' ') +
                                            " | " + Convert.ToString(lectorDB["autorizacion"]).PadRight(11, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha_arribo"])).PadLeft(10, '0') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total"])).PadLeft(12, ' ') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                else if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002ORDEN_COMPRA: Hay un conflicto en la consulta de las ordenes de compra", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "FECHA") condicional = ((estado != "TODOS") ? WHERE8 : WHERE7); //Consulta filtrada por Tipo de Comprobante y/o Fecha de Combropante
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
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(7, ' ') +
                                            " | " + Convert.ToString(lectorDB["autorizacion"]).PadRight(11, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha_arribo"])).PadLeft(10, '0') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total"])).PadLeft(12, ' ') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                else if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004ORDEN_COMPRA: Hay un conflicto en la consulta de las ordenes de compra", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<OrdenCompra> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "COMPROBANTE") condicional = WHERE2; //Consulta filtrada por Comprobante (TPV y Nro. De Comprobante)
            if (campo == "CUIT") condicional = ((estado != "TODOS") ? WHERE4 : WHERE3); //Consulta filtrada por Tipo de Comprobante y/o CUIT
            if (campo == "DENOMINACION") condicional = ((estado != "TODOS") ? WHERE6 : WHERE5); //Consulta filtrada por Tipo de Comprobante y/o Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID OrdenCompra
            List<OrdenCompra> ListaDeObjetos = new List<OrdenCompra>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                OrdenCompra objOrdenCompra = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objOrdenCompra); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006ORDEN_COMPRA: Hay un conflicto en la consulta de las ordenes de compra", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<OrdenCompra> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            string condicional = "";
            if (campo == "FECHA") condicional = ((estado != "TODOS") ? WHERE8 : WHERE7); //Consulta filtrada por Tipo de Comprobante y/o Fecha de Combropante
            List<OrdenCompra> ListaDeObjetos = new List<OrdenCompra>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro terciario
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro terciario
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                OrdenCompra objOrdenCompra = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objOrdenCompra); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008ORDEN_COMPRA: Hay un conflicto en la consulta de las ordenes de compra", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public OrdenCompra obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID (Filtro Exclusivo de Pago por CUIT)
            OrdenCompra objOrdenCompra = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objOrdenCompra = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos de la orden de compra e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010ORDEN_COMPRA: Hay un conflicto en la consulta de la orden de compra.", e); }
            finally { _conexion.Dispose(); }
            return objOrdenCompra;
        }

        public bool actualizar(OrdenCompra objOrdenCompra)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objOrdenCompra.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objOrdenCompra.Id);
                                comandoDB_update.Parameters.AddWithValue("@cbte_tpv", objOrdenCompra.CbteTPV);
                                comandoDB_update.Parameters.AddWithValue("@cbte_nro", objOrdenCompra.CbteNro);
                                comandoDB_update.Parameters.AddWithValue("@cbte_fecha", objOrdenCompra.CbteFecha);
                                comandoDB_update.Parameters.AddWithValue("@estado", objOrdenCompra.Estado);
                                comandoDB_update.Parameters.AddWithValue("@autorizacion", objOrdenCompra.Autorizacion);
                                comandoDB_update.Parameters.AddWithValue("@id_proveedor", objOrdenCompra.Proveedor.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_cuenta_contable", objOrdenCompra.CuentaContable.Id);
                                comandoDB_update.Parameters.AddWithValue("@fecha_arribo", objOrdenCompra.FechaArribo);
                                comandoDB_update.Parameters.AddWithValue("@descuento_porcentual", objOrdenCompra.DescuentoPorcentual);
                                comandoDB_update.Parameters.AddWithValue("@descuento", objOrdenCompra.Descuento);
                                comandoDB_update.Parameters.AddWithValue("@subtotal", objOrdenCompra.Subtotal);
                                comandoDB_update.Parameters.AddWithValue("@iva105", objOrdenCompra.Iva105);
                                comandoDB_update.Parameters.AddWithValue("@iva210", objOrdenCompra.Iva210);
                                comandoDB_update.Parameters.AddWithValue("@iva270", objOrdenCompra.Iva270);
                                comandoDB_update.Parameters.AddWithValue("@percepcion_iibb", objOrdenCompra.PercepcionIIBB);
                                comandoDB_update.Parameters.AddWithValue("@percepcion_lh", objOrdenCompra.PercepcionLH);
                                comandoDB_update.Parameters.AddWithValue("@percepcion_iva", objOrdenCompra.PercepcionIVA);
                                comandoDB_update.Parameters.AddWithValue("@no_gravado", objOrdenCompra.NoGravado);
                                comandoDB_update.Parameters.AddWithValue("@impuesto_interno", objOrdenCompra.ImpuestoInterno);
                                comandoDB_update.Parameters.AddWithValue("@total", objOrdenCompra.Total);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objOrdenCompra.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objOrdenCompra.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objOrdenCompra.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Ordenes de Compra", "Modificó el registro ID:" + objOrdenCompra.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Inaccesible.\nLa orden de compra compra podría estar asoc_aplicada o\n No se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M012ORDEN_COMPRA", "M014ORDEN_COMPRA", "M016ORDEN_COMPRA", "M018ORDEN_COMPRA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool anular(OrdenCompra objOrdenCompra)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ANULAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objOrdenCompra.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ANULAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objOrdenCompra.Id);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Ordenes de Compra", "Anuló el registro Id:" + objOrdenCompra.Id + "."); //Registra la eliminación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Anulado.\nLa orden de compra ya se encuentra anulada en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M020ORDEN_COMPRA", "M022ORDEN_COMPRA", "M024ORDEN_COMPRA", "M026ORDEN_COMPRA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool autorizar(OrdenCompra objOrdenCompra, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_AUTORIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objOrdenCompra.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(AUTORIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objOrdenCompra.Id);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Ordenes de Compra", "Autorizó el registro Id:" + objOrdenCompra.Id + "."); //Registra la eliminación de un registro
                                if (notificarExito) Mensaje.Informacion("La orden de compra ID:" + objOrdenCompra.Id + "\nse autorizó correctamente.");
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro Autorizado.\nLa orden de compra ya se encuentra autorizada en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M028ORDEN_COMPRA", "M030ORDEN_COMPRA", "M032RDEN_COMPRA", "M034ORDEN_COMPRA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(OrdenCompra objOrdenCompra)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@cbte_tpv", objOrdenCompra.CbteTPV); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cbte_nro", objOrdenCompra.CbteNro); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@id_proveedor", objOrdenCompra.Proveedor.Id); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objOrdenCompra.Id);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_tpv", objOrdenCompra.CbteTPV);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_nro", objOrdenCompra.CbteNro);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_fecha", objOrdenCompra.CbteFecha);
                                comandoDB_insert.Parameters.AddWithValue("@estado", objOrdenCompra.Estado);
                                comandoDB_insert.Parameters.AddWithValue("@autorizacion", objOrdenCompra.Autorizacion);
                                comandoDB_insert.Parameters.AddWithValue("@id_proveedor", objOrdenCompra.Proveedor.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_cuenta_contable", objOrdenCompra.CuentaContable.Id);
                                comandoDB_insert.Parameters.AddWithValue("@fecha_arribo", objOrdenCompra.FechaArribo);
                                comandoDB_insert.Parameters.AddWithValue("@descuento_porcentual", objOrdenCompra.DescuentoPorcentual);
                                comandoDB_insert.Parameters.AddWithValue("@descuento", objOrdenCompra.Descuento);
                                comandoDB_insert.Parameters.AddWithValue("@subtotal", objOrdenCompra.Subtotal);
                                comandoDB_insert.Parameters.AddWithValue("@iva105", objOrdenCompra.Iva105);
                                comandoDB_insert.Parameters.AddWithValue("@iva210", objOrdenCompra.Iva210);
                                comandoDB_insert.Parameters.AddWithValue("@iva270", objOrdenCompra.Iva270);
                                comandoDB_insert.Parameters.AddWithValue("@percepcion_iibb", objOrdenCompra.PercepcionIIBB);
                                comandoDB_insert.Parameters.AddWithValue("@percepcion_lh", objOrdenCompra.PercepcionLH);
                                comandoDB_insert.Parameters.AddWithValue("@percepcion_iva", objOrdenCompra.PercepcionIVA);
                                comandoDB_insert.Parameters.AddWithValue("@no_gravado", objOrdenCompra.NoGravado);
                                comandoDB_insert.Parameters.AddWithValue("@impuesto_interno", objOrdenCompra.ImpuestoInterno);
                                comandoDB_insert.Parameters.AddWithValue("@total", objOrdenCompra.Total);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objOrdenCompra.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objOrdenCompra.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objOrdenCompra.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Ordenes de Compra", "Agregó un nuevo registro ID:" + objOrdenCompra.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nLa orden de compra ya se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M036ORDEN_COMPRA", "M038ORDEN_COMPRA", "M040ORDEN_COMPRA", "M042ORDEN_COMPRA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private OrdenCompra instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new OrdenCompra(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToInt32(lectorDB["cbte_tpv"]),
                Convert.ToInt64(lectorDB["cbte_nro"]),
                Convert.ToDateTime(lectorDB["cbte_fecha"]),
                Convert.ToString(lectorDB["estado"]),
                Convert.ToString(lectorDB["autorizacion"]),
                new D_Proveedor().obtenerObjeto("TODOS", "ID", Convert.ToString(lectorDB["id_proveedor"]), false),
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable"]), false),
                Convert.ToDateTime(lectorDB["fecha_arribo"]),
                Convert.ToDouble(lectorDB["descuento_porcentual"]),
                Convert.ToDouble(lectorDB["descuento"]),
                Convert.ToDouble(lectorDB["subtotal"]),
                Convert.ToDouble(lectorDB["iva105"]),
                Convert.ToDouble(lectorDB["iva210"]),
                Convert.ToDouble(lectorDB["iva270"]),
                Convert.ToDouble(lectorDB["percepcion_iibb"]),
                Convert.ToDouble(lectorDB["percepcion_lh"]),
                Convert.ToDouble(lectorDB["percepcion_iva"]),
                Convert.ToDouble(lectorDB["no_gravado"]),
                Convert.ToDouble(lectorDB["impuesto_interno"]),
                Convert.ToDouble(lectorDB["total"]),
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
