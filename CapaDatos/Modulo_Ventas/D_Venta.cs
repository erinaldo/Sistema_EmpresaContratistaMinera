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
    public class D_Venta : IVenta, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT1 = @"SELECT data_venta.id, afip_cbte_tipo, afip_cbte_tpv, afip_cbte_nro,
            afip_cbte_fecha, periodo, cobranza_vto, total, data_cliente.denominacion, data_cliente.cuit";
        private const string SELECT2 = @"SELECT data_venta.*, 
            data_cliente.denominacion, data_cliente.cuit";
        private const string FROM = @" FROM data_venta 
            INNER JOIN data_cliente ON data_venta.id_cliente = data_cliente.id";
        private const string WHERE1 = @" WHERE data_venta.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE (data_venta.afip_cbte_tpv = @afip_cbte_tpv AND data_venta.afip_cbte_nro = @afip_cbte_nro)"; //Filtrar Objeto por Comprobante (TPV y Nro. De Comprobante)
        private const string WHERE3 = @" WHERE data_cliente.cuit = @cuit"; //Filtrar Objeto por CUIT
        private const string WHERE4 = @" WHERE data_cliente.cuit = @cuit AND data_venta.afip_cbte_tipo = @afip_cbte_tipo"; //Filtrar Objeto por Tipo de Comprobante y CUIT
        private const string WHERE5 = @" WHERE LOWER(data_cliente.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE6 = @" WHERE LOWER(data_cliente.denominacion) LIKE LOWER(@denominacion) AND data_venta.afip_cbte_tipo = @afip_cbte_tipo"; //Filtrar Objeto por Tipo de Comprobante y Denominación
        private const string WHERE7 = @" WHERE periodo = @periodo"; //Filtrar Objeto por Periodo
        private const string WHERE8 = @" WHERE periodo = @periodo AND data_venta.afip_cbte_tipo = @afip_cbte_tipo"; //Filtrar Objeto por Tipo de Comprobante y Periodo
        private const string WHERE9 = @" WHERE date(data_venta.afip_cbte_fecha) >= date(@desde) AND date(data_venta.afip_cbte_fecha) <= date(@hasta)"; //Filtrar Objeto por Fecha de Comprobante
        private const string WHERE10 = @" WHERE date(data_venta.afip_cbte_fecha) >= date(@desde) AND date(data_venta.afip_cbte_fecha) <= date(@hasta) AND data_venta.afip_cbte_tipo = @afip_cbte_tipo"; //Filtrar Objeto por Tipo de Comprobante y Fecha de Comprobante
        private const string WHERE11 = @" WHERE date(data_venta.cobranza_vto) >= date(@desde) AND date(data_venta.cobranza_vto) <= date(@hasta)"; //Filtrar Objeto por Fecha de Cobro
        private const string WHERE12 = @" WHERE date(data_venta.cobranza_vto) >= date(@desde) AND date(data_venta.cobranza_vto) <= date(@hasta) AND data_venta.afip_cbte_tipo = @afip_cbte_tipo"; //Filtrar Objeto por Tipo de Comprobante y Fecha de Cobro
        private const string WHERE_LIBRO_IVA = @" WHERE data_venta.periodo = @periodo
            AND (data_venta.afip_cbte_tipo = 1 OR data_venta.afip_cbte_tipo = 2 OR data_venta.afip_cbte_tipo = 3
            OR data_venta.afip_cbte_tipo = 6 OR data_venta.afip_cbte_tipo = 7 OR data_venta.afip_cbte_tipo = 8 
            OR data_venta.afip_cbte_tipo = 11 OR data_venta.afip_cbte_tipo = 12 OR data_venta.afip_cbte_tipo = 13 
            OR data_venta.afip_cbte_tipo = 51 OR data_venta.afip_cbte_tipo = 52 OR data_venta.afip_cbte_tipo = 53)"; //Filtrar Objeto por Estado, Tipo de Comprobante y Periodo (LIBRO DE IVA)
        private const string WHERE_INFORMATIVO = @" WHERE data_venta.periodo = @periodo
            AND (data_venta.afip_cbte_tipo = 1 OR data_venta.afip_cbte_tipo = 2 OR data_venta.afip_cbte_tipo = 3
            OR data_venta.afip_cbte_tipo = 6 OR data_venta.afip_cbte_tipo = 7 OR data_venta.afip_cbte_tipo = 8 
            OR data_venta.afip_cbte_tipo = 11 OR data_venta.afip_cbte_tipo = 12 OR data_venta.afip_cbte_tipo = 13 
            OR data_venta.afip_cbte_tipo = 51 OR data_venta.afip_cbte_tipo = 52 OR data_venta.afip_cbte_tipo = 53)"; //Filtrar Objeto por Estado, Tipo de Comprobante y Periodo (LIBRO DE IVA)
        private const string AND_EXCLUSIVO_COBRO = @" AND (data_venta.afip_cbte_tipo = '1' OR data_venta.afip_cbte_tipo = '6' OR data_venta.afip_cbte_tipo = '11' OR data_venta.afip_cbte_tipo = '51'
            OR data_venta.afip_cbte_tipo = '2' OR data_venta.afip_cbte_tipo = '7' OR data_venta.afip_cbte_tipo = '12' OR data_venta.afip_cbte_tipo = '52')
            AND data_venta.cobranza_estado <> 'COBRADO' AND data_cliente.cuit = @cuit_exclusivo_cobro"; //Filtrar Objeto por Tipo de Comprobante (FAC-A, FAC-B, FAC-C, FAC-M, NDE-A, NDE-B, NDE-C, NDE-M), Estado de Cobro y CUIT
        private const string ORDER = @" ORDER BY data_venta.afip_cbte_fecha DESC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_venta WHERE id = @id AND asoc_aplicada = false"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ASOCIAR = @"SELECT * FROM data_venta WHERE id = @id AND asoc_aplicada = true"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_venta WHERE afip_cbte_tipo = @afip_cbte_tipo 
            AND afip_cbte_tpv = @afip_cbte_tpv AND afip_cbte_nro = @afip_cbte_nro AND id_cliente = @id_cliente"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_venta SET 
            id = @id,
            fecha = @fecha,
            periodo = @periodo,
            afip_cbte_tipo = @afip_cbte_tipo,
            afip_cbte_tpv = @afip_cbte_tpv,
            afip_cbte_nro = @afip_cbte_nro,
            afip_cbte_fecha = @afip_cbte_fecha,
            id_cliente = @id_cliente,
            id_cuenta_contable = @id_cuenta_contable,
            cobranza_vto = @cobranza_vto,
            cobranza_estado = @cobranza_estado,
            cobranza_alertado = @cobranza_alertado,
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
            no_gravado = @no_gravado,
            total = @total,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ASOCIAR = @"UPDATE data_venta SET asoc_aplicada = @asoc_aplicada WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_venta(id, fecha, periodo, afip_cbte_tipo, afip_cbte_tpv,
            afip_cbte_nro, afip_cbte_fecha, id_cliente, id_cuenta_contable, cobranza_vto, cobranza_estado, 
            cobranza_alertado, asoc_id, asoc_afip_cbte_tipo, asoc_afip_cbte_tpv, asoc_afip_cbte_nro,
            asoc_afip_cbte_fecha, asoc_aplicada, descuento_porcentual, descuento, subtotal, iva105,
            iva210, iva270, no_gravado, total, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @fecha, @periodo, @afip_cbte_tipo, @afip_cbte_tpv, @afip_cbte_nro, @afip_cbte_fecha,
            @id_cliente, @id_cuenta_contable, @cobranza_vto, @cobranza_estado, @cobranza_alertado, @asoc_id,
            @asoc_afip_cbte_tipo, @asoc_afip_cbte_tpv, @asoc_afip_cbte_nro, @asoc_afip_cbte_fecha, @asoc_aplicada,
            @descuento_porcentual, @descuento, @subtotal, @iva105, @iva210, @iva270, @no_gravado, @total,
            @edicion_fecha, @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(int afipTipoCbte, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina, string filtroExclusivoCobroCUIT)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "COMPROBANTE") condicional = WHERE2; //Consulta filtrada por Comprobante (TPV y Nro. De Comprobante)
            if (campo == "CUIT") condicional = (afipTipoCbte > 0) ? WHERE4 : WHERE3 + ((filtroExclusivoCobroCUIT != "TODOS") ? AND_EXCLUSIVO_COBRO : ""); //Consulta filtrada por Tipo de Comprobante y/o CUIT (Filtro Exclusivo de Cobro por CUIT)
            if (campo == "DENOMINACION") condicional = (afipTipoCbte > 0) ? WHERE6 : WHERE5; //Consulta filtrada por Tipo de Comprobante y/o Denominación
            if (campo == "ID") condicional = WHERE1 + ((filtroExclusivoCobroCUIT != "TODOS") ? AND_EXCLUSIVO_COBRO : ""); //Consulta filtrada por ID (Filtro Exclusivo de Cobro por CUIT)
            if (campo == "PERIODO") condicional = (afipTipoCbte > 0) ? WHERE8 : WHERE7 + ((filtroExclusivoCobroCUIT != "TODOS") ? AND_EXCLUSIVO_COBRO : ""); //Consulta filtrada por Tipo de Comprobante y/o Periodo (Filtro Exclusivo de Cobro por CUIT)
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
                        if (filtroExclusivoCobroCUIT != "TODOS") comandoDB.Parameters.AddWithValue("@cuit_exclusivo_cobro", filtroExclusivoCobroCUIT); //Agrega el parámetro en la condición del contador
                        if (afipTipoCbte > 0) comandoDB.Parameters.AddWithValue("@afip_cbte_tipo", afipTipoCbte); //Agrega el parámetro en la condición del contador
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
                        if (filtroExclusivoCobroCUIT != "TODOS") comandoDB.Parameters.AddWithValue("@cuit_exclusivo_cobro", filtroExclusivoCobroCUIT); //Agrega el parámetro en la condición de la consulta
                        if (afipTipoCbte > 0) comandoDB.Parameters.AddWithValue("@afip_cbte_tipo", afipTipoCbte); //Agrega el parámetro en la condición de la consulta
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
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cobranza_vto"])).PadLeft(10, '0') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total"]))).PadLeft(12, ' ') +
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
            catch (MySqlException e) { Mensaje.Error("Error-M002CBTE_VENTA: Hay un conflicto en la consulta de comprobantes de venta.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(int afipTipoCbte, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina, string filtroExclusivoCobroCUIT)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "FECHA") condicional = (afipTipoCbte > 0) ? WHERE10 : WHERE9 + ((filtroExclusivoCobroCUIT != "TODOS") ? AND_EXCLUSIVO_COBRO : ""); //Consulta filtrada por Tipo de Comprobante y/o Fecha de Comprobante (Filtro Exclusivo de Cobro por CUIT)
            if (campo == "FECHA_COBRO") condicional = (afipTipoCbte > 0) ? WHERE12 : WHERE11 + ((filtroExclusivoCobroCUIT != "TODOS") ? AND_EXCLUSIVO_COBRO : ""); //Consulta filtrada por Tipo de Comprobante y/o Fecha de Comprobante (Filtro Exclusivo de Cobro por CUIT)
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega el parámetro en la condición del contador
                        if (filtroExclusivoCobroCUIT != "TODOS") comandoDB.Parameters.AddWithValue("@cuit_exclusivo_cobro", filtroExclusivoCobroCUIT); //Agrega el parámetro en la condición de la consulta
                        if (afipTipoCbte > 0) comandoDB.Parameters.AddWithValue("@afip_cbte_tipo", afipTipoCbte); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        if (filtroExclusivoCobroCUIT != "TODOS") comandoDB.Parameters.AddWithValue("@cuit_exclusivo_cobro", filtroExclusivoCobroCUIT); //Agrega el parámetro en la condición de la consulta
                        if (afipTipoCbte > 0) comandoDB.Parameters.AddWithValue("@afip_cbte_tipo", afipTipoCbte); //Agrega el parámetro en la condición e la consulta
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
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cobranza_vto"])).PadLeft(10, '0') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total"]))).PadLeft(12, ' ') +
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
            catch (MySqlException e) { Mensaje.Error("Error-M004CBTE_VENTA: Hay un conflicto en la consulta de comprobantes de venta.", e); }
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
                                string categoriaIVA = new D_Cliente().obtenerObjeto("TODOS", "ID", Convert.ToString(lectorDB["id_cliente"]), true).Iva;
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
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToDouble(lectorDB["no_gravado"]) + ((categoriaIVA == "SUJETO EXENTO") ? Convert.ToDouble(lectorDB["total"]) : 0.00))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + "0,00") +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["iva105"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["iva210"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["iva270"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + "0,00") +
                                            " | " + (signoNCR + "0,00") +
                                            " | " + (signoNCR + "0,00") +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total"]))).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos      
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006CBTE_VENTA: Hay un conflicto en la consulta de comprobantes de compra.", e); }
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
                                string categoriaIVA = new D_Cliente().obtenerObjeto("TODOS", "ID", Convert.ToString(lectorDB["id_cliente"]), true).Iva;
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
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToDouble(lectorDB["no_gravado"]) + ((categoriaIVA == "SUJETO EXENTO") ? Convert.ToDouble(lectorDB["total"]) : 0.00))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + "0,00") +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["iva105"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["iva210"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["iva270"]))).PadLeft(12, ' ') +
                                            " | " + (signoNCR + "0,00") +
                                            " | " + (signoNCR + "0,00") +
                                            " | " + (signoNCR + "0,00") +
                                            " | " + (signoNCR + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total"]))).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos      
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008CBTE_VENTA: Hay un conflicto en la consulta de comprobantes de compra.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<Venta> obtenerObjetos(int afipTipoCbte, string campo, string valor, string filtroExclusivoCobroCUIT)
        {
            string condicional = "";
            if (campo == "COMPROBANTE") condicional = WHERE2; //Consulta filtrada por Comprobante (TPV y Nro. De Comprobante)
            if (campo == "CUIT") condicional = (afipTipoCbte > 0) ? WHERE4 : WHERE3 + ((filtroExclusivoCobroCUIT != "TODOS") ? AND_EXCLUSIVO_COBRO : ""); //Consulta filtrada por Tipo de Comprobante y/o CUIT (Filtro Exclusivo de Cobro por CUIT)
            if (campo == "DENOMINACION") condicional = (afipTipoCbte > 0) ? WHERE6 : WHERE5; //Consulta filtrada por Tipo de Comprobante y/o Denominación
            if (campo == "ID") condicional = WHERE1 + ((filtroExclusivoCobroCUIT != "TODOS") ? AND_EXCLUSIVO_COBRO : ""); //Consulta filtrada por ID (Filtro Exclusivo de Cobro por CUIT)
            if (campo == "PERIODO") condicional = (afipTipoCbte > 0) ? WHERE8 : WHERE7 + ((filtroExclusivoCobroCUIT != "TODOS") ? AND_EXCLUSIVO_COBRO : ""); //Consulta filtrada por Tipo de Comprobante y/o Periodo (Filtro Exclusivo de Cobro por CUIT)
            List<Venta> ListaDeObjetos = new List<Venta>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                        if (filtroExclusivoCobroCUIT != "TODOS") comandoDB.Parameters.AddWithValue("@cuit_exclusivo_cobro", filtroExclusivoCobroCUIT); //Agrega el parámetro en la condición de la consulta
                        if (afipTipoCbte > 0) comandoDB.Parameters.AddWithValue("@afip_cbte_tipo", afipTipoCbte); //Agrega el parámetro en la condición del contador
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Venta objVenta = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objVenta); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010CBTE_VENTA: Hay un conflicto en la consulta de comprobantes de venta.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<Venta> obtenerObjetos(int afipTipoCbte, string campo, DateTime desde, DateTime hasta, string filtroExclusivoCobroCUIT)
        {
            string condicional = "";
            if (campo == "FECHA") condicional = (afipTipoCbte > 0) ? WHERE10 : WHERE9 + ((filtroExclusivoCobroCUIT != "TODOS") ? AND_EXCLUSIVO_COBRO : ""); //Consulta filtrada por Tipo de Comprobante y/o Fecha de Comprobante (Filtro Exclusivo de Cobro por CUIT)
            if (campo == "FECHA_COBRO") condicional = (afipTipoCbte > 0) ? WHERE12 : WHERE11 + ((filtroExclusivoCobroCUIT != "TODOS") ? AND_EXCLUSIVO_COBRO : ""); //Consulta filtrada por Tipo de Comprobante y/o Fecha de Comprobante (Filtro Exclusivo de Cobro por CUIT)
            List<Venta> ListaDeObjetos = new List<Venta>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro terciario
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro terciario
                        if (filtroExclusivoCobroCUIT != "TODOS") comandoDB.Parameters.AddWithValue("@cuit_exclusivo_cobro", filtroExclusivoCobroCUIT); //Agrega el parámetro en la condición de la consulta
                        if (afipTipoCbte > 0) comandoDB.Parameters.AddWithValue("@afip_cbte_tipo", afipTipoCbte); //Agrega el parámetro en la condición del contador
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Venta objVenta = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objVenta); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M012CBTE_VENTA: Hay un conflicto en la consulta de comprobantes de venta.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public Venta obtenerObjeto(string campo, string valor, bool notificarExito, string filtroExclusivoCobroCUIT)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1 + ((filtroExclusivoCobroCUIT != "TODOS") ? AND_EXCLUSIVO_COBRO : ""); //Consulta filtrada por ID (Filtro Exclusivo de Cobro por CUIT)
            Venta objVenta = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT2 + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        if (filtroExclusivoCobroCUIT != "TODOS") comandoDB.Parameters.AddWithValue("@cuit_exclusivo_cobro", filtroExclusivoCobroCUIT); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objVenta = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos del comprobante de venta e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M014CBTE_VENTA: Hay un conflicto en la consulta del comprobante de venta.", e); }
            finally { _conexion.Dispose(); }
            return objVenta;
        }

        public bool actualizar(Venta objVenta)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objVenta.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objVenta.Id);
                                comandoDB_update.Parameters.AddWithValue("@fecha", objVenta.Fecha);
                                comandoDB_update.Parameters.AddWithValue("@periodo", objVenta.Periodo);
                                comandoDB_update.Parameters.AddWithValue("@afip_cbte_tipo", objVenta.AfipCbteTipo);
                                comandoDB_update.Parameters.AddWithValue("@afip_cbte_tpv", objVenta.AfipCbteTPV);
                                comandoDB_update.Parameters.AddWithValue("@afip_cbte_nro", objVenta.AfipCbteNro);
                                comandoDB_update.Parameters.AddWithValue("@afip_cbte_fecha", objVenta.AfipCbteFecha);
                                comandoDB_update.Parameters.AddWithValue("@id_cliente", objVenta.Cliente.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_cuenta_contable", objVenta.CuentaContable.Id);
                                comandoDB_update.Parameters.AddWithValue("@cobranza_vto", objVenta.CobranzaVto);
                                comandoDB_update.Parameters.AddWithValue("@cobranza_estado", objVenta.CobranzaEstado);
                                comandoDB_update.Parameters.AddWithValue("@cobranza_alertado", objVenta.CobranzaAlertado);
                                comandoDB_update.Parameters.AddWithValue("@asoc_id", objVenta.AsociacionId);
                                comandoDB_update.Parameters.AddWithValue("@asoc_afip_cbte_tipo", objVenta.AsociacionAfipCbteTipo);
                                comandoDB_update.Parameters.AddWithValue("@asoc_afip_cbte_tpv", objVenta.AsociacionAfipCbteTPV);
                                comandoDB_update.Parameters.AddWithValue("@asoc_afip_cbte_nro", objVenta.AsociacionAfipCbteNro);
                                comandoDB_update.Parameters.AddWithValue("@asoc_afip_cbte_fecha", objVenta.AsociacionAfipCbteFecha);
                                comandoDB_update.Parameters.AddWithValue("@asoc_aplicada", objVenta.AsociacionAplicada);
                                comandoDB_update.Parameters.AddWithValue("@descuento_porcentual", objVenta.DescuentoPorcentual);
                                comandoDB_update.Parameters.AddWithValue("@descuento", objVenta.Descuento);
                                comandoDB_update.Parameters.AddWithValue("@subtotal", objVenta.Subtotal);
                                comandoDB_update.Parameters.AddWithValue("@iva105", objVenta.Iva105);
                                comandoDB_update.Parameters.AddWithValue("@iva210", objVenta.Iva210);
                                comandoDB_update.Parameters.AddWithValue("@iva270", objVenta.Iva270);
                                comandoDB_update.Parameters.AddWithValue("@no_gravado", objVenta.NoGravado);
                                comandoDB_update.Parameters.AddWithValue("@total", objVenta.Total);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objVenta.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objVenta.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objVenta.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Comprobantes de Venta", "Modificó el registro ID:" + objVenta.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Inaccesible.\nEl comprobante de venta compra podría estar asoc_aplicada o\n No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M016CBTE_VENTA", "M018CBTE_VENTA", "M020CBTE_VENTA", "M022CBTE_VENTA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(Venta objVenta)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@afip_cbte_tipo", objVenta.AfipCbteTipo); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@afip_cbte_tpv", objVenta.AfipCbteTPV); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@afip_cbte_nro", objVenta.AfipCbteNro); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@id_cliente", objVenta.Cliente.Id); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objVenta.Id);
                                comandoDB_insert.Parameters.AddWithValue("@fecha", objVenta.Fecha);
                                comandoDB_insert.Parameters.AddWithValue("@periodo", objVenta.Periodo);
                                comandoDB_insert.Parameters.AddWithValue("@afip_cbte_tipo", objVenta.AfipCbteTipo);
                                comandoDB_insert.Parameters.AddWithValue("@afip_cbte_tpv", objVenta.AfipCbteTPV);
                                comandoDB_insert.Parameters.AddWithValue("@afip_cbte_nro", objVenta.AfipCbteNro);
                                comandoDB_insert.Parameters.AddWithValue("@afip_cbte_fecha", objVenta.AfipCbteFecha);
                                comandoDB_insert.Parameters.AddWithValue("@id_cliente", objVenta.Cliente.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_cuenta_contable", objVenta.CuentaContable.Id);
                                comandoDB_insert.Parameters.AddWithValue("@cobranza_vto", objVenta.CobranzaVto);
                                comandoDB_insert.Parameters.AddWithValue("@cobranza_estado", objVenta.CobranzaEstado);
                                comandoDB_insert.Parameters.AddWithValue("@cobranza_alertado", objVenta.CobranzaAlertado);
                                comandoDB_insert.Parameters.AddWithValue("@asoc_id", objVenta.AsociacionId);
                                comandoDB_insert.Parameters.AddWithValue("@asoc_afip_cbte_tipo", objVenta.AsociacionAfipCbteTipo);
                                comandoDB_insert.Parameters.AddWithValue("@asoc_afip_cbte_tpv", objVenta.AsociacionAfipCbteTPV);
                                comandoDB_insert.Parameters.AddWithValue("@asoc_afip_cbte_nro", objVenta.AsociacionAfipCbteNro);
                                comandoDB_insert.Parameters.AddWithValue("@asoc_afip_cbte_fecha", objVenta.AsociacionAfipCbteFecha);
                                comandoDB_insert.Parameters.AddWithValue("@asoc_aplicada", objVenta.AsociacionAplicada);
                                comandoDB_insert.Parameters.AddWithValue("@descuento_porcentual", objVenta.DescuentoPorcentual);
                                comandoDB_insert.Parameters.AddWithValue("@descuento", objVenta.Descuento);
                                comandoDB_insert.Parameters.AddWithValue("@subtotal", objVenta.Subtotal);
                                comandoDB_insert.Parameters.AddWithValue("@iva105", objVenta.Iva105);
                                comandoDB_insert.Parameters.AddWithValue("@iva210", objVenta.Iva210);
                                comandoDB_insert.Parameters.AddWithValue("@iva270", objVenta.Iva270);
                                comandoDB_insert.Parameters.AddWithValue("@no_gravado", objVenta.NoGravado);
                                comandoDB_insert.Parameters.AddWithValue("@total", objVenta.Total);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objVenta.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objVenta.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objVenta.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Comprobantes de Venta", "Agregó un nuevo registro ID:" + objVenta.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl comprobante de venta ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M024CBTE_VENTA", "M026CBTE_VENTA", "M028CBTE_VENTA", "M030CBTE_VENTA", e); }
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
                Mensaje.Advertencia("Registro Asociado.\nEl comprobante de venta ya se encuentra asociado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M032CBTE_VENTA", "M034CBTE_VENTA", "M036CBTE_VENTA", "M038CBTE_VENTA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private Venta instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Venta(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToDateTime(lectorDB["fecha"]),
                Convert.ToString(lectorDB["periodo"]),
                Convert.ToInt32(lectorDB["afip_cbte_tipo"]),
                Convert.ToInt32(lectorDB["afip_cbte_tpv"]),
                Convert.ToInt64(lectorDB["afip_cbte_nro"]),
                Convert.ToDateTime(lectorDB["afip_cbte_fecha"]),
                new D_Cliente().obtenerObjeto("TODOS", "ID", Convert.ToString(lectorDB["id_cliente"]), false),
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable"]), false),
                Convert.ToDateTime(lectorDB["cobranza_vto"]),
                Convert.ToString(lectorDB["cobranza_estado"]),
                Convert.ToBoolean(lectorDB["cobranza_alertado"]),
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
                Convert.ToDouble(lectorDB["no_gravado"]),
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