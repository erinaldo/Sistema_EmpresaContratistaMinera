using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_FacturaAPagar : IFacturaAPagar, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_asiento_contable.id AS id_asiento, asiento_nro, asiento_fecha,
            data_asiento_contable.id_cuenta_contable, descripcion, debe, haber, origen_tipo, origen_id,
            data_proveedor.denominacion AS proveedor, cuit, data_compra.pago_estado";
        private const string FROM = @" FROM data_asiento_contable 
            LEFT JOIN data_compra ON origen_tipo = 'CPR' AND origen_id = data_compra.id AND data_compra.pago_estado <> 'PAGADO' 
                AND (data_compra.afip_cbte_tipo = 01
                    OR data_compra.afip_cbte_tipo = 06
                    OR data_compra.afip_cbte_tipo = 11
                    OR data_compra.afip_cbte_tipo = 51
                    OR data_compra.afip_cbte_tipo = 02
                    OR data_compra.afip_cbte_tipo = 07
                    OR data_compra.afip_cbte_tipo = 12
                    OR data_compra.afip_cbte_tipo = 52
                    OR data_compra.afip_cbte_tipo = 01)
            INNER JOIN data_proveedor ON data_compra.id_proveedor = data_proveedor.id";
        private const string WHERE1 = @" WHERE data_asiento_contable.id_cuenta_contable = 10 AND (date(data_asiento_contable.asiento_fecha) >= date(@desde) AND date(data_asiento_contable.asiento_fecha) <= date(@hasta))"; //Filtro por Objeto Cuenta Contable (DEUDORES POR VENTA) y Fecha de Asiento
        private const string WHERE2 = @" WHERE data_asiento_contable.id_cuenta_contable = 10 AND (date(data_asiento_contable.asiento_fecha) >= date(@desde) AND date(data_asiento_contable.asiento_fecha) <= date(@hasta)) AND data_proveedor.cuit = @cuit"; //Filtro por Objeto Cuenta Contable (DEUDORES POR VENTA), Fecha de Asiento y CUIT
        private const string SUM_DEBE = @"SELECT SUM(data_asiento_contable.debe)"; //Obtiene la sumatoria de la columna Debe
        private const string SUM_HABER = @"SELECT SUM(data_asiento_contable.haber)"; //Obtiene la sumatoria de la columna Haber
        private const string SUM_SALDO_ANTECESOR = @"SELECT (SUM(data_asiento_contable.debe) - SUM(data_asiento_contable.haber)) AS saldo_inicial" + FROM + @" WHERE data_asiento_contable.id_cuenta_contable = 6 AND date(data_asiento_contable.asiento_fecha) < date(@desde) AND data_proveedor.cuit = @cuit"; //Calcula el Saldo antecesor entre Debe y el Haber filtrado por CUIT
        private const string ORDER = @" ORDER BY data_proveedor.cuit ASC, data_asiento_contable.asiento_fecha ASC, data_asiento_contable.asiento_nro ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campoEspecifico, string valorEspecifico, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            string condicional = (campoEspecifico == "CUIT") ? WHERE2 : WHERE1; //Consulta filtrada por cuenta contable (DEUDORES POR VENTA), Fecha de Asiento y/o Denominación
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            string cuitAntecesor = "";
            List<FacturaAPagar> ListaDeObjetos = new List<FacturaAPagar>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campoEspecifico == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valorEspecifico); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campoEspecifico == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valorEspecifico); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                FacturaAPagar objFacturaAPagar = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objFacturaAPagar); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                    foreach (FacturaAPagar itemFacturaAPagar in ListaDeObjetos)
                    {
                        if (catalogo == "CATALOGO1")
                        {
                            CatalogoBase elemento = new CatalogoBase(
                                 itemFacturaAPagar.Id,
                                 Convert.ToInt64(itemFacturaAPagar.Cuit).ToString("00-00000000/0") +
                                    " | " + Fecha.ConvertirFecha(itemFacturaAPagar.AsientoFecha).PadLeft(10, '0') +
                                    " | " + itemFacturaAPagar.Descripcion.PadRight(44, ' ') + //Establecí el valor del ancho de esta columna en 44 para rellenar el ListBox
                                    " | " + Formulario.ValidarCampoMoneda(itemFacturaAPagar.Haber).PadLeft(12, ' ') +
                                    " | " + (itemFacturaAPagar.EstadoPago).PadRight(7, ' '));
                            ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                        }
                        else if (catalogo == "CATALOGO2")
                        {
                            CatalogoBase elemento;
                            #region Fila Tipo SubTitulo
                            if (cuitAntecesor != itemFacturaAPagar.Cuit)
                            {
                                double[] Totales = contabilizarDebeHaber("CUIT", itemFacturaAPagar.Cuit, desde, hasta);
                                elemento = new CatalogoBase(
                                     -1, //ID nulo
                                     itemFacturaAPagar.Denominacion.PadRight(35, ' ') +
                                        " | " + Convert.ToInt64(itemFacturaAPagar.Cuit).ToString("00-00000000/0").PadRight(13, ' ') +
                                        " | " + ("").PadLeft(10, ' ') +
                                        " | " + ("").PadRight(44, ' ') + //Establecí el valor del ancho de esta columna en 44 para rellenar el ListBox
                                        " | " + ("$" + Formulario.ValidarCampoMoneda(Totales[1])).PadLeft(12, ' ') +
                                        " | " + ("").PadRight(7, ' '));
                                ListaDeElementos.Add(elemento); //Agrega el subTitulo a la lista de elementos
                            }
                            #endregion
                            elemento = new CatalogoBase(
                                 itemFacturaAPagar.Id,
                                 ("").PadRight(35, ' ') + //Dato omitido por ser repetitivo
                                    " | " + ("").PadRight(13, ' ') + //Dato omitido por ser repetitivo
                                    " | " + Fecha.ConvertirFecha(itemFacturaAPagar.AsientoFecha).PadLeft(10, '0') +
                                    " | " + itemFacturaAPagar.Descripcion.PadRight(44, ' ') + //Establecí el valor del ancho de esta columna en 44 para rellenar el ListBox
                                    " | " + ("$" + Formulario.ValidarCampoMoneda(itemFacturaAPagar.Haber)).PadLeft(12, ' ') +
                                    " | " + (itemFacturaAPagar.EstadoPago).PadRight(7, ' '));
                            ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                        }
                        cuitAntecesor = itemFacturaAPagar.Cuit; //Deducción de Saldo Antecesor - Paso 2: Establece el CUIT actual (Importante para completar el ciclo)
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002CTA_APAGAR: Hay un conflicto en la consulta de las cuentas a pagar.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public double[] contabilizarDebeHaber(string campoEspecifico, string valorEspecifico, DateTime desde, DateTime hasta)
        {
            double[] valorDebeHaber = new double[] { 0.00, 0.00 };
            string condicional = (campoEspecifico == "CUIT") ? WHERE2 : WHERE1; //Consulta filtrada por cuenta contable (DEUDORES POR VENTA), Fecha de Asiento y/o Denominación
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_DEBE + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campoEspecifico == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valorEspecifico); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        object resultado = comandoDB.ExecuteScalar();
                        if (resultado != DBNull.Value) valorDebeHaber[0] = (double)resultado; //Almacena la sumatoria del Debe
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_HABER + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campoEspecifico == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valorEspecifico); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        object resultado = comandoDB.ExecuteScalar();
                        if (resultado != DBNull.Value) valorDebeHaber[1] = (double)resultado; //Almacena la sumatoria del Haber
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004CTA_APAGAR: Hay un conflicto en el cálculo del debe y haber de las cuentas a pagar.", e); }
            finally { _conexion.Dispose(); }
            return valorDebeHaber;
        }
        #endregion

        #region Métodos de Instanciación
        private FacturaAPagar instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new FacturaAPagar(
                Convert.ToInt64(lectorDB["id_asiento"]),
                Convert.ToInt64(lectorDB["asiento_nro"]),
                Convert.ToDateTime(lectorDB["asiento_fecha"]),
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable"]), false),
                Convert.ToString(lectorDB["descripcion"]),
                Convert.ToDouble(lectorDB["debe"]),
                Convert.ToDouble(lectorDB["haber"]),
                Convert.ToString(lectorDB["pago_estado"]),
                Convert.ToString(lectorDB["origen_tipo"]),
                Convert.ToInt64(lectorDB["origen_id"]),
                Convert.ToString(lectorDB["proveedor"]),
                Convert.ToString(lectorDB["cuit"]));
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