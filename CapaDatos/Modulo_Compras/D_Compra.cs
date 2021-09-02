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
    public class D_Compra : ICompra, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT1 = @"SELECT data_compra.id, afip_cbte_tipo, afip_cbte_tpv, afip_cbte_nro,
            afip_cbte_fecha, periodo, pago_vto, total, data_proveedor.denominacion, data_proveedor.cuit";
        private const string SELECT2 = @"SELECT data_compra.*, 
            data_proveedor.denominacion, data_proveedor.cuit";
        private const string FROM = @" FROM data_compra 
            INNER JOIN data_proveedor ON data_compra.id_proveedor = data_proveedor.id";
        private const string WHERE1 = @" WHERE data_compra.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE (data_compra.afip_cbte_tpv = @afip_cbte_tpv AND data_compra.afip_cbte_nro = @afip_cbte_nro)"; //Filtrar Objeto por Comprobante (TPV y Nro. De Comprobante)
        private const string WHERE3 = @" WHERE data_proveedor.cuit = @cuit"; //Filtrar Objeto por CUIT
        private const string WHERE4 = @" WHERE data_proveedor.cuit = @cuit AND data_compra.afip_cbte_tipo = @afip_cbte_tipo"; //Filtrar Objeto por Tipo de Comprobante y CUIT
        private const string WHERE5 = @" WHERE LOWER(data_proveedor.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE6 = @" WHERE LOWER(data_proveedor.denominacion) LIKE LOWER(@denominacion) AND data_compra.afip_cbte_tipo = @afip_cbte_tipo"; //Filtrar Objeto por Tipo de Comprobante y Denominación
        private const string WHERE7 = @" WHERE periodo = @periodo"; //Filtrar Objeto por Periodo
        private const string WHERE8 = @" WHERE periodo = @periodo AND data_compra.afip_cbte_tipo = @afip_cbte_tipo"; //Filtrar Objeto por Tipo de Comprobante y Periodo
        private const string WHERE9 = @" WHERE date(data_compra.afip_cbte_fecha) >= date(@desde) AND date(data_compra.afip_cbte_fecha) <= date(@hasta)"; //Filtrar Objeto por Fecha de Comprobante
        private const string WHERE10 = @" WHERE date(data_compra.afip_cbte_fecha) >= date(@desde) AND date(data_compra.afip_cbte_fecha) <= date(@hasta) AND data_compra.afip_cbte_tipo = @afip_cbte_tipo"; //Filtrar Objeto por Tipo de Comprobante y Fecha de Comprobante
        private const string WHERE11 = @" WHERE date(data_compra.pago_vto) >= date(@desde) AND date(data_compra.pago_vto) <= date(@hasta)"; //Filtrar Objeto por Fecha de Pago
        private const string WHERE12 = @" WHERE date(data_compra.pago_vto) >= date(@desde) AND date(data_compra.pago_vto) <= date(@hasta) AND data_compra.afip_cbte_tipo = @afip_cbte_tipo"; //Filtrar Objeto por Tipo de Comprobante y Fecha de Pago
        private const string WHERE_LIBRO_IVA = @" WHERE periodo = @periodo
            AND (data_compra.afip_cbte_tipo = 1 OR data_compra.afip_cbte_tipo = 2 OR data_compra.afip_cbte_tipo = 3
            OR data_compra.afip_cbte_tipo = 6 OR data_compra.afip_cbte_tipo = 7 OR data_compra.afip_cbte_tipo = 8 
            OR data_compra.afip_cbte_tipo = 11 OR data_compra.afip_cbte_tipo = 12 OR data_compra.afip_cbte_tipo = 13 
            OR data_compra.afip_cbte_tipo = 51 OR data_compra.afip_cbte_tipo = 52 OR data_compra.afip_cbte_tipo = 53)"; //Filtrar Objeto por Estado, Estado y Periodo (LIBRO DE IVA)
        private const string WHERE_INFORMATIVO = @" WHERE periodo = @periodo
            AND (data_compra.afip_cbte_tipo = 1 OR data_compra.afip_cbte_tipo = 2 OR data_compra.afip_cbte_tipo = 3
            OR data_compra.afip_cbte_tipo = 6 OR data_compra.afip_cbte_tipo = 7 OR data_compra.afip_cbte_tipo = 8 
            OR data_compra.afip_cbte_tipo = 11 OR data_compra.afip_cbte_tipo = 12 OR data_compra.afip_cbte_tipo = 13 
            OR data_compra.afip_cbte_tipo = 51 OR data_compra.afip_cbte_tipo = 52 OR data_compra.afip_cbte_tipo = 53)"; //Filtrar Objeto por Estado, Estado y Periodo (LIBRO DE IVA)
        private const string AND_EXCLUSIVO_PAGO = @" AND (data_compra.afip_cbte_tipo = '1' OR data_compra.afip_cbte_tipo = '6' OR data_compra.afip_cbte_tipo = '11' OR data_compra.afip_cbte_tipo = '51'
            OR data_compra.afip_cbte_tipo = '2' OR data_compra.afip_cbte_tipo = '7' OR data_compra.afip_cbte_tipo = '12' OR data_compra.afip_cbte_tipo = '52')
            AND data_compra.pago_estado <> 'PAGADO' AND data_proveedor.cuit = @cuit_exclusivo_pago"; //Filtrar Objeto por Estado (FAC-A, FAC-B, FAC-C, FAC-M, NDE-A, NDE-B, NDE-C, NDE-M), Estado de Cobro y CUIT
        private const string ORDER = @" ORDER BY data_compra.afip_cbte_fecha DESC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_compra WHERE id = @id AND asoc_aplicada = false"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ASOCIAR = @"SELECT * FROM data_compra WHERE id = @id AND asoc_aplicada = true"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_compra WHERE afip_cbte_tipo = @afip_cbte_tipo 
            AND afip_cbte_tpv = @afip_cbte_tpv AND afip_cbte_nro = @afip_cbte_nro AND id_proveedor = @id_proveedor"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_compra SET 
            id = @id,
            fecha = @fecha,
            periodo = @periodo,
            afip_cbte_tipo = @afip_cbte_tipo,
            afip_cbte_tpv = @afip_cbte_tpv,
            afip_cbte_nro = @afip_cbte_nro,
            afip_cbte_fecha = @afip_cbte_fecha,
            afip_cod_barras = @afip_cod_barras,
            id_proveedor = @id_proveedor,
            id_cuenta_contable = @id_cuenta_contable,
            pago_vto = @pago_vto,
            pago_estado = @pago_estado,
            pago_alertado = @pago_alertado,
            asoc_id = @asoc_id,
            asoc_afip_cbte_tipo = @asoc_afip_cbte_tipo,
            asoc_afip_cbte_tpv = @asoc_afip_cbte_tpv,
            asoc_afip_cbte_nro = @asoc_afip_cbte_nro,
            asoc_afip_cbte_fecha = @asoc_afip_cbte_fecha,
            asoc_aplicada = @asoc_aplicada,
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
        private const string ASOCIAR = @"UPDATE data_compra SET referenciado = @referenciado WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_compra(id, fecha, periodo, afip_cbte_tipo, 
            afip_cbte_tpv, afip_cbte_nro, afip_cbte_fecha, afip_cod_barras, id_proveedor, id_cuenta_contable,
            pago_vto, pago_estado, pago_alertado, asoc_id, asoc_afip_cbte_tipo, asoc_afip_cbte_tpv,
            asoc_afip_cbte_nro, asoc_afip_cbte_fecha, asoc_aplicada, descuento_porcentual, descuento,
            subtotal, iva105, iva210, iva270, percepcion_iibb, percepcion_lh, percepcion_iva, no_gravado,
            impuesto_interno, total, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @fecha, @periodo, @afip_cbte_tipo, @afip_cbte_tpv, @afip_cbte_nro, @afip_cbte_fecha,
            @afip_cod_barras, @id_proveedor, @id_cuenta_contable, @pago_vto, @pago_estado, @pago_alertado,
            @asoc_id, @asoc_afip_cbte_tipo, @asoc_afip_cbte_tpv, @asoc_afip_cbte_nro, @asoc_afip_cbte_fecha,
            @asoc_aplicada, @descuento_porcentual, @descuento, @subtotal, @iva105, @iva210, @iva270,
            @percepcion_iibb, @percepcion_lh, @percepcion_iva, @no_gravado, @impuesto_interno, @total,
            @edicion_fecha, @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(int afipTipoCbte, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina, string filtroExclusivoPagoCUIT)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "COMPROBANTE") condicional = WHERE2; //Consulta filtrada por Comprobante (TPV y Nro. De Comprobante)
            if (campo == "CUIT") condicional = ((afipTipoCbte > 0) ? WHERE4 : WHERE3) + ((filtroExclusivoPagoCUIT != "TODOS") ? AND_EXCLUSIVO_PAGO : ""); //Consulta filtrada por Tipo de Comprobante y/o CUIT (Filtro Exclusivo de Pago)
            if (campo == "DENOMINACION") condicional = ((afipTipoCbte > 0) ? WHERE6 : WHERE5) + ((filtroExclusivoPagoCUIT != "TODOS") ? AND_EXCLUSIVO_PAGO : ""); //Consulta filtrada por Tipo de Comprobante y/o Denominación (Filtro Exclusivo de Pago)
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID Compra
            if (campo == "PERIODO") condicional = ((afipTipoCbte > 0) ? WHERE8 : WHERE7) + ((filtroExclusivoPagoCUIT != "TODOS") ? AND_EXCLUSIVO_PAGO : ""); //Consulta filtrada por Tipo de Comprobante y/o Periodo (Filtro Exclusivo de Pago)
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@afip_cbte_tpv", valor.Split('-')[0]); //Agrega el parámetro en la condición del contador
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@afip_cbte_nro", valor.Split('-')[1]); //Agrega el parámetro en la condición del contador
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "PERIODO") comandoDB.Parameters.AddWithValue("@periodo", valor); //Agrega el parámetro en la condición del contador
                        if (afipTipoCbte > 0) comandoDB.Parameters.AddWithValue("@afip_cbte_tipo", afipTipoCbte); //Agrega el parámetro en la condición del contador
                        if (filtroExclusivoPagoCUIT != "TODOS") comandoDB.Parameters.AddWithValue("@cuit_exclusivo_pago", filtroExclusivoPagoCUIT); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@afip_cbte_tpv", valor.Split('-')[0]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@afip_cbte_nro", valor.Split('-')[1]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "PERIODO") comandoDB.Parameters.AddWithValue("@periodo", valor); //Agrega el parámetro en la condición de la consulta
                        if (afipTipoCbte > 0) comandoDB.Parameters.AddWithValue("@afip_cbte_tipo", afipTipoCbte); //Agrega el parámetro en la condición de la consulta
                        if (filtroExclusivoPagoCUIT != "TODOS") comandoDB.Parameters.AddWithValue("@cuit_exclusivo_pago", filtroExclusivoPagoCUIT); //Agrega el parámetro en la condición de la consulta
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
                                        Formulario.GenerarTipoComprobante(Convert.ToInt32(lectorDB["afip_cbte_tipo"])).PadLeft(5, ' ') +
                                            " | " + Convert.ToString(lectorDB["afip_cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["afip_cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["afip_cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["periodo"]).PadLeft(7, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["pago_vto"])).PadLeft(10, '0') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total"])).PadLeft(12, ' ') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                            ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                else if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Formulario.GenerarTipoComprobante(Convert.ToInt32(lectorDB["afip_cbte_tipo"])).PadLeft(5, ' ') +
                                            " | " + Convert.ToString(lectorDB["afip_cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["afip_cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["afip_cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002CBTE_COMPRA: Hay un conflicto en la consulta de comprobantes de compra.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(int afipTipoCbte, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina, string filtroExclusivoPagoCUIT)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "FECHA") condicional = ((afipTipoCbte > 0) ? WHERE10 : WHERE9) + ((filtroExclusivoPagoCUIT != "TODOS") ? AND_EXCLUSIVO_PAGO : ""); //Consulta filtrada por Tipo de Comprobante y/o Fecha de Combropante (Filtro Exclusivo de Pago)
            if (campo == "FECHA_PAGO") condicional = ((afipTipoCbte > 0) ? WHERE12 : WHERE11) + ((filtroExclusivoPagoCUIT != "TODOS") ? AND_EXCLUSIVO_PAGO : ""); //Consulta filtrada por Tipo de Comprobante y/o Fecha de Pago (Filtro Exclusivo de Pago)
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega el parámetro en la condición del contador
                        if (afipTipoCbte > 0) comandoDB.Parameters.AddWithValue("@afip_cbte_tipo", afipTipoCbte); //Agrega el parámetro en la condición del contador
                        if (filtroExclusivoPagoCUIT != "TODOS") comandoDB.Parameters.AddWithValue("@cuit_exclusivo_pago", filtroExclusivoPagoCUIT); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        if (afipTipoCbte > 0) comandoDB.Parameters.AddWithValue("@afip_cbte_tipo", afipTipoCbte); //Agrega el parámetro en la condición de la consulta
                        if (filtroExclusivoPagoCUIT != "TODOS") comandoDB.Parameters.AddWithValue("@cuit_exclusivo_pago", filtroExclusivoPagoCUIT); //Agrega el parámetro en la condición de la consulta
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
                                        Formulario.GenerarTipoComprobante(Convert.ToInt32(lectorDB["afip_cbte_tipo"])).PadLeft(5, ' ') +
                                            " | " + Convert.ToString(lectorDB["afip_cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["afip_cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["afip_cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["periodo"]).PadLeft(7, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["pago_vto"])).PadLeft(10, '0') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total"])).PadLeft(12, ' ') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                else if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Formulario.GenerarTipoComprobante(Convert.ToInt32(lectorDB["afip_cbte_tipo"])).PadLeft(5, ' ') +
                                            " | " + Convert.ToString(lectorDB["afip_cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["afip_cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["afip_cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') + " " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004CBTE_COMPRA: Hay un conflicto en la consulta de comprobantes de compra.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerLibroIVA(string periodo, string catalogo)
        {
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT2 + FROM + WHERE_LIBRO_IVA + ORDER)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@periodo", periodo); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                string signoNCR = (Formulario.GenerarTipoComprobante(Convert.ToInt32(lectorDB["afip_cbte_tipo"])).Substring(0, 3) == "NCR") ? "-" : "";
                                string categoriaIVA = new D_Proveedor().obtenerObjeto("TODOS", "ID", Convert.ToString(lectorDB["id_proveedor"]), true).Iva;
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Formulario.GenerarTipoComprobante(Convert.ToInt32(lectorDB["afip_cbte_tipo"])).PadLeft(5, ' ') +
                                            " | " + Convert.ToString(lectorDB["afip_cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["afip_cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["afip_cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["subtotal"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total"]))).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                else if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Formulario.GenerarTipoComprobante(Convert.ToInt32(lectorDB["afip_cbte_tipo"])).PadLeft(5, ' ') +
                                            " | " + Convert.ToString(lectorDB["afip_cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["afip_cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["afip_cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["subtotal"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["no_gravado"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["impuesto_interno"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["iva105"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["iva210"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["iva270"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["percepcion_iibb"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["percepcion_lh"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["percepcion_iva"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total"]))).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos      
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006CBTE_COMPRA: Hay un conflicto en la consulta de comprobantes de compra.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerInformativo(string periodo, string catalogo)
        {
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT2 + FROM + WHERE_INFORMATIVO + ORDER)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@periodo", periodo); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                string signoNCR = (Formulario.GenerarTipoComprobante(Convert.ToInt32(lectorDB["afip_cbte_tipo"])).Substring(0, 3) == "NCR") ? "-" : "";
                                string categoriaIVA = new D_Proveedor().obtenerObjeto("TODOS", "ID", Convert.ToString(lectorDB["id_proveedor"]), true).Iva;
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Formulario.GenerarTipoComprobante(Convert.ToInt32(lectorDB["afip_cbte_tipo"])).PadLeft(5, ' ') +
                                            " | " + Convert.ToString(lectorDB["afip_cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["afip_cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["afip_cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["subtotal"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total"]))).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                else if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Formulario.GenerarTipoComprobante(Convert.ToInt32(lectorDB["afip_cbte_tipo"])).PadLeft(5, ' ') +
                                            " | " + Convert.ToString(lectorDB["afip_cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["afip_cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["afip_cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["subtotal"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["no_gravado"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["impuesto_interno"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["iva105"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["iva210"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["iva270"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["percepcion_iibb"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["percepcion_lh"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["percepcion_iva"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total"]))).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos      
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008CBTE_COMPRA: Hay un conflicto en la consulta de comprobantes de compra.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<Compra> obtenerObjetos(int afipTipoCbte, string campo, string valor, string filtroExclusivoPagoCUIT)
        {
            string condicional = "";
            if (campo == "COMPROBANTE") condicional = WHERE2; //Consulta filtrada por Comprobante (TPV y Nro. De Comprobante)
            if (campo == "CUIT") condicional = ((afipTipoCbte > 0) ? WHERE4 : WHERE3) + ((filtroExclusivoPagoCUIT != "TODOS") ? AND_EXCLUSIVO_PAGO : ""); //Consulta filtrada por Tipo de Comprobante y/o CUIT (Filtro Exclusivo de Pago)
            if (campo == "DENOMINACION") condicional = ((afipTipoCbte > 0) ? WHERE6 : WHERE5) + ((filtroExclusivoPagoCUIT != "TODOS") ? AND_EXCLUSIVO_PAGO : ""); //Consulta filtrada por Tipo de Comprobante y/o Denominación (Filtro Exclusivo de Pago)
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID Compra
            if (campo == "PERIODO") condicional = ((afipTipoCbte > 0) ? WHERE8 : WHERE7) + ((filtroExclusivoPagoCUIT != "TODOS") ? AND_EXCLUSIVO_PAGO : ""); //Consulta filtrada por Tipo de Comprobante y/o Periodo (Filtro Exclusivo de Pago)
            List<Compra> ListaDeObjetos = new List<Compra>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@afip_cbte_tpv", valor.Split('-')[0]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@afip_cbte_nro", valor.Split('-')[1]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "PERIODO") comandoDB.Parameters.AddWithValue("@periodo", valor); //Agrega el parámetro en la condición de la consulta
                        if (afipTipoCbte > 0) comandoDB.Parameters.AddWithValue("@afip_cbte_tipo", afipTipoCbte); //Agrega el parámetro en la condición de la consulta
                        if (filtroExclusivoPagoCUIT != "TODOS") comandoDB.Parameters.AddWithValue("@cuit_exclusivo_pago", filtroExclusivoPagoCUIT); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Compra objCompra = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objCompra); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010CBTE_COMPRA: Hay un conflicto en la consulta de comprobantes de compra.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<Compra> obtenerObjetos(int afipTipoCbte, string campo, DateTime desde, DateTime hasta, string filtroExclusivoPagoCUIT)
        {
            string condicional = "";
            if (campo == "FECHA") condicional = ((afipTipoCbte > 0) ? WHERE10 : WHERE9) + ((filtroExclusivoPagoCUIT != "TODOS") ? AND_EXCLUSIVO_PAGO : ""); //Consulta filtrada por Tipo de Comprobante y/o Fecha de Combropante (Filtro Exclusivo de Pago)
            if (campo == "FECHA_PAGO") condicional = ((afipTipoCbte > 0) ? WHERE12 : WHERE11) + ((filtroExclusivoPagoCUIT != "TODOS") ? AND_EXCLUSIVO_PAGO : ""); //Consulta filtrada por Tipo de Comprobante y/o Fecha de Pago (Filtro Exclusivo de Pago)
            List<Compra> ListaDeObjetos = new List<Compra>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro terciario
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro terciario
                        if (afipTipoCbte > 0) comandoDB.Parameters.AddWithValue("@afip_cbte_tipo", afipTipoCbte); //Agrega el parámetro en la condición de la consulta
                        if (filtroExclusivoPagoCUIT != "TODOS") comandoDB.Parameters.AddWithValue("@cuit_exclusivo_pago", filtroExclusivoPagoCUIT); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Compra objCompra = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objCompra); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M012CBTE_COMPRA: Hay un conflicto en la consulta de comprobantes de compra.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public Compra obtenerObjeto(string campo, string valor, bool notificarExito, string filtroExclusivoPagoCUIT)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1 + ((filtroExclusivoPagoCUIT != "TODOS") ? AND_EXCLUSIVO_PAGO : ""); //Consulta filtrada por ID (Filtro Exclusivo de Pago por CUIT)
            Compra objCompra = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT2 + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        if (filtroExclusivoPagoCUIT != "TODOS") comandoDB.Parameters.AddWithValue("@cuit_exclusivo_pago", filtroExclusivoPagoCUIT); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objCompra = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos del comprobante de compra e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M014CBTE_COMPRA: Hay un conflicto en la consulta del comprobante de compra.", e); }
            finally { _conexion.Dispose(); }
            return objCompra;
        }

        public bool actualizar(Compra objCompra)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objCompra.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objCompra.Id);
                                comandoDB_update.Parameters.AddWithValue("@fecha", objCompra.Fecha);
                                comandoDB_update.Parameters.AddWithValue("@periodo", objCompra.Periodo);
                                comandoDB_update.Parameters.AddWithValue("@afip_cbte_tipo", objCompra.AfipCbteTipo);
                                comandoDB_update.Parameters.AddWithValue("@afip_cbte_tpv", objCompra.AfipCbteTPV);
                                comandoDB_update.Parameters.AddWithValue("@afip_cbte_nro", objCompra.AfipCbteNro);
                                comandoDB_update.Parameters.AddWithValue("@afip_cbte_fecha", objCompra.AfipCbteFecha);
                                comandoDB_update.Parameters.AddWithValue("@afip_cod_barras", objCompra.AfipCodigoBarras);
                                comandoDB_update.Parameters.AddWithValue("@id_proveedor", objCompra.Proveedor.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_cuenta_contable", objCompra.CuentaContable.Id);
                                comandoDB_update.Parameters.AddWithValue("@pago_vto", objCompra.PagoVto);
                                comandoDB_update.Parameters.AddWithValue("@pago_estado", objCompra.PagoEstado);
                                comandoDB_update.Parameters.AddWithValue("@pago_alertado", objCompra.PagoAlertado);
                                comandoDB_update.Parameters.AddWithValue("@asoc_id", objCompra.AsociacionId);
                                comandoDB_update.Parameters.AddWithValue("@asoc_afip_cbte_tipo", objCompra.AsociacionAfipCbteTipo);
                                comandoDB_update.Parameters.AddWithValue("@asoc_afip_cbte_tpv", objCompra.AsociacionAfipCbteTPV);
                                comandoDB_update.Parameters.AddWithValue("@asoc_afip_cbte_nro", objCompra.AsociacionAfipCbteNro);
                                comandoDB_update.Parameters.AddWithValue("@asoc_afip_cbte_fecha", objCompra.AsociacionAfipCbteFecha);
                                comandoDB_update.Parameters.AddWithValue("@asoc_aplicada", objCompra.AsociacionAplicada);
                                comandoDB_update.Parameters.AddWithValue("@descuento_porcentual", objCompra.DescuentoPorcentual);
                                comandoDB_update.Parameters.AddWithValue("@descuento", objCompra.Descuento);
                                comandoDB_update.Parameters.AddWithValue("@subtotal", objCompra.Subtotal);
                                comandoDB_update.Parameters.AddWithValue("@iva105", objCompra.Iva105);
                                comandoDB_update.Parameters.AddWithValue("@iva210", objCompra.Iva210);
                                comandoDB_update.Parameters.AddWithValue("@iva270", objCompra.Iva270);
                                comandoDB_update.Parameters.AddWithValue("@percepcion_iibb", objCompra.PercepcionIIBB);
                                comandoDB_update.Parameters.AddWithValue("@percepcion_lh", objCompra.PercepcionLH);
                                comandoDB_update.Parameters.AddWithValue("@percepcion_iva", objCompra.PercepcionIVA);
                                comandoDB_update.Parameters.AddWithValue("@no_gravado", objCompra.NoGravado);
                                comandoDB_update.Parameters.AddWithValue("@impuesto_interno", objCompra.ImpuestoInterno);
                                comandoDB_update.Parameters.AddWithValue("@total", objCompra.Total);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objCompra.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objCompra.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objCompra.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Comprobantes de Compra", "Modificó el registro ID:" + objCompra.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Inaccesible.\nEl comprobante de compra podría estar asociado o\n No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M016CBTE_COMPRA", "M018CBTE_COMPRA", "M020CBTE_COMPRA", "M022CBTE_COMPRA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(Compra objCompra)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@afip_cbte_tipo", objCompra.AfipCbteTipo); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@afip_cbte_tpv", objCompra.AfipCbteTPV); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@afip_cbte_nro", objCompra.AfipCbteNro); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@id_proveedor", objCompra.Proveedor.Id); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objCompra.Id);
                                comandoDB_insert.Parameters.AddWithValue("@fecha", objCompra.Fecha);
                                comandoDB_insert.Parameters.AddWithValue("@periodo", objCompra.Periodo);
                                comandoDB_insert.Parameters.AddWithValue("@afip_cbte_tipo", objCompra.AfipCbteTipo);
                                comandoDB_insert.Parameters.AddWithValue("@afip_cbte_tpv", objCompra.AfipCbteTPV);
                                comandoDB_insert.Parameters.AddWithValue("@afip_cbte_nro", objCompra.AfipCbteNro);
                                comandoDB_insert.Parameters.AddWithValue("@afip_cbte_fecha", objCompra.AfipCbteFecha);
                                comandoDB_insert.Parameters.AddWithValue("@afip_cod_barras", objCompra.AfipCodigoBarras);
                                comandoDB_insert.Parameters.AddWithValue("@id_proveedor", objCompra.Proveedor.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_cuenta_contable", objCompra.CuentaContable.Id);
                                comandoDB_insert.Parameters.AddWithValue("@pago_vto", objCompra.PagoVto);
                                comandoDB_insert.Parameters.AddWithValue("@pago_estado", objCompra.PagoEstado);
                                comandoDB_insert.Parameters.AddWithValue("@pago_alertado", objCompra.PagoAlertado);
                                comandoDB_insert.Parameters.AddWithValue("@asoc_id", objCompra.AsociacionId);
                                comandoDB_insert.Parameters.AddWithValue("@asoc_afip_cbte_tipo", objCompra.AsociacionAfipCbteTipo);
                                comandoDB_insert.Parameters.AddWithValue("@asoc_afip_cbte_tpv", objCompra.AsociacionAfipCbteTPV);
                                comandoDB_insert.Parameters.AddWithValue("@asoc_afip_cbte_nro", objCompra.AsociacionAfipCbteNro);
                                comandoDB_insert.Parameters.AddWithValue("@asoc_afip_cbte_fecha", objCompra.AsociacionAfipCbteFecha);
                                comandoDB_insert.Parameters.AddWithValue("@asoc_aplicada", objCompra.AsociacionAplicada);
                                comandoDB_insert.Parameters.AddWithValue("@descuento_porcentual", objCompra.DescuentoPorcentual);
                                comandoDB_insert.Parameters.AddWithValue("@descuento", objCompra.Descuento);
                                comandoDB_insert.Parameters.AddWithValue("@subtotal", objCompra.Subtotal);
                                comandoDB_insert.Parameters.AddWithValue("@iva105", objCompra.Iva105);
                                comandoDB_insert.Parameters.AddWithValue("@iva210", objCompra.Iva210);
                                comandoDB_insert.Parameters.AddWithValue("@iva270", objCompra.Iva270);
                                comandoDB_insert.Parameters.AddWithValue("@percepcion_iibb", objCompra.PercepcionIIBB);
                                comandoDB_insert.Parameters.AddWithValue("@percepcion_lh", objCompra.PercepcionLH);
                                comandoDB_insert.Parameters.AddWithValue("@percepcion_iva", objCompra.PercepcionIVA);
                                comandoDB_insert.Parameters.AddWithValue("@no_gravado", objCompra.NoGravado);
                                comandoDB_insert.Parameters.AddWithValue("@impuesto_interno", objCompra.ImpuestoInterno);
                                comandoDB_insert.Parameters.AddWithValue("@total", objCompra.Total);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objCompra.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objCompra.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objCompra.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Comprobantes de Compra", "Agregó un nuevo registro ID:" + objCompra.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl comprobante de compra ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M032CBTE_COMPRA", "M034CBTE_COMPRA", "M036CBTE_COMPRA", "M038CBTE_COMPRA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool registrarComoCbteAsociado(long id, bool asociado)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ASOCIAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ASOCIAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", id);
                                comandoDB_update.Parameters.AddWithValue("@asoc_aplicada", asociado);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Asociado.\nEl comprobante de compra ya se encuentra asociado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M040CBTE_COMPRA", "M042CBTE_COMPRA", "M044CBTE_COMPRA", "M046CBTE_COMPRA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private Compra instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Compra(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToDateTime(lectorDB["fecha"]),
                Convert.ToString(lectorDB["periodo"]),
                Convert.ToInt32(lectorDB["afip_cbte_tipo"]),
                Convert.ToInt32(lectorDB["afip_cbte_tpv"]),
                Convert.ToInt64(lectorDB["afip_cbte_nro"]),
                Convert.ToDateTime(lectorDB["afip_cbte_fecha"]),
                Convert.ToString(lectorDB["afip_cod_barras"]),
                new D_Proveedor().obtenerObjeto("TODOS", "ID", Convert.ToString(lectorDB["id_proveedor"]), false),
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable"]), false),
                Convert.ToDateTime(lectorDB["pago_vto"]),
                Convert.ToString(lectorDB["pago_estado"]),
                Convert.ToBoolean(lectorDB["pago_alertado"]),
                Convert.ToInt64(lectorDB["asoc_id"]),
                Convert.ToInt32(lectorDB["asoc_afip_cbte_tipo"]),
                Convert.ToInt32(lectorDB["asoc_afip_cbte_tpv"]),
                Convert.ToInt64(lectorDB["asoc_afip_cbte_nro"]),
                Convert.ToDateTime(lectorDB["asoc_afip_cbte_fecha"]),
                Convert.ToBoolean(lectorDB["asoc_aplicada"]),
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
