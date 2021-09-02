using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_ProveedorCtaCte : IProveedorCtaCte, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_asiento_contable.id AS id_asiento, asiento_nro, asiento_fecha,
            data_asiento_contable.id_cuenta_contable, descripcion, debe, haber, origen_tipo, origen_id,
            data_proveedor.denominacion AS proveedor, cuit";
        private const string FROM = @" FROM data_asiento_contable 
            LEFT JOIN data_compra ON (origen_tipo = 'CPR' AND origen_id = data_compra.id) 
            LEFT JOIN data_pago_proveedor ON (origen_tipo = 'PAP' AND origen_id = data_pago_proveedor.id) 
            INNER JOIN data_proveedor ON (data_compra.id_proveedor = data_proveedor.id OR data_pago_proveedor.id_proveedor = data_proveedor.id)";
        private const string WHERE1 = @" WHERE data_asiento_contable.id_cuenta_contable = 10 AND (date(data_asiento_contable.asiento_fecha) >= date(@desde) AND date(data_asiento_contable.asiento_fecha) <= date(@hasta))"; //Filtro por Objeto Cuenta Contable (PROVEEDORES) y Fecha de Asiento
        private const string WHERE2 = @" WHERE data_asiento_contable.id_cuenta_contable = 10 AND (date(data_asiento_contable.asiento_fecha) >= date(@desde) AND date(data_asiento_contable.asiento_fecha) <= date(@hasta)) AND data_proveedor.cuit = @cuit"; //Filtro por Objeto Cuenta Contable (PROVEEDORES), Fecha de Asiento y CUIT
        private const string SUM_DEBE = @"SELECT SUM(data_asiento_contable.debe)"; //Obtiene la sumatoria de la columna Debe
        private const string SUM_HABER = @"SELECT SUM(data_asiento_contable.haber)"; //Obtiene la sumatoria de la columna Haber
        private const string SUM_SALDO_ANTECESOR = @"SELECT (SUM(data_asiento_contable.debe) - SUM(data_asiento_contable.haber)) AS saldo_inicial" + FROM + @" WHERE data_asiento_contable.id_cuenta_contable = 10 AND date(data_asiento_contable.asiento_fecha) < date(@desde) AND data_proveedor.cuit = @cuit"; //Calcula el Saldo antecesor entre Debe y el Haber filtrado por CUIT
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
            double saldoAntecesor = 0.00;
            double saldoAsientoContable = 0.00;
            List<ProveedorCtaCte> ListaDeObjetos = new List<ProveedorCtaCte>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                ProveedorCtaCte objProveedorCtaCte = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objProveedorCtaCte); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                    foreach (ProveedorCtaCte itemProveedorCtaCte in ListaDeObjetos)
                    {
                        if (cuitAntecesor != itemProveedorCtaCte.Cuit) saldoAsientoContable = saldoAntecesor = contabilizarSaldoAntecesor(itemProveedorCtaCte.Cuit, desde); //Deducción de Saldo Antecesor - Paso 1: Obtiene el Saldo Antecesor en relación al CUIT
                        saldoAsientoContable = Math.Round(((saldoAsientoContable + itemProveedorCtaCte.Debe) - itemProveedorCtaCte.Haber), 2); //Calcula el Saldo del Asiento Contable. Se obtiene sumándolo al Saldo Antecesor el Debe y por último se le resta el Haber
                        if (catalogo == "CATALOGO1")
                        {
                            CatalogoBase elemento = new CatalogoBase(
                                 itemProveedorCtaCte.Id,
                                 Convert.ToInt64(itemProveedorCtaCte.Cuit).ToString("00-00000000/0") +
                                    " | " + Fecha.ConvertirFecha(itemProveedorCtaCte.AsientoFecha).PadLeft(10, '0') +
                                    " | " + itemProveedorCtaCte.Descripcion.PadRight(44, ' ') + //Establecí el valor del ancho de esta columna en 44 para rellenar el ListBox
                                    " | " + Formulario.ValidarCampoMoneda(itemProveedorCtaCte.Debe).PadLeft(12, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemProveedorCtaCte.Haber).PadLeft(12, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(saldoAsientoContable).PadLeft(12, ' '));
                            ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                        }
                        else if (catalogo == "CATALOGO2")
                        {
                            CatalogoBase elemento;
                            #region Fila Tipo SubTitulo
                            if (cuitAntecesor != itemProveedorCtaCte.Cuit)
                            {
                                double[] Totales = contabilizarDebeHaber("CUIT", itemProveedorCtaCte.Cuit, desde, hasta);
                                elemento = new CatalogoBase(
                                     -1, //ID nulo
                                     itemProveedorCtaCte.Denominacion.PadRight(35, ' ') +
                                        " | " + Convert.ToInt64(itemProveedorCtaCte.Cuit).ToString("00-00000000/0").PadRight(13, ' ') +
                                        " | " + ("").PadLeft(10, ' ') +
                                        " | " + ("").PadRight(44, ' ') + //Establecí el valor del ancho de esta columna en 44 para rellenar el ListBox
                                        " | " + ("$" + Formulario.ValidarCampoMoneda(Totales[0])).PadLeft(12, ' ') +
                                        " | " + ("$" + Formulario.ValidarCampoMoneda(Totales[1])).PadLeft(12, ' ') +
                                        " | " + ("$" + Formulario.ValidarCampoMoneda(Math.Round((saldoAntecesor + Totales[0]) - Totales[1], 2))).PadLeft(12, ' '));
                                ListaDeElementos.Add(elemento); //Agrega el subTitulo a la lista de elementos
                            }
                            #endregion
                            elemento = new CatalogoBase(
                                 itemProveedorCtaCte.Id,
                                 ("").PadRight(35, ' ') + //Dato omitido por ser repetitivo
                                    " | " + ("").PadRight(13, ' ') + //Dato omitido por ser repetitivo
                                    " | " + Fecha.ConvertirFecha(itemProveedorCtaCte.AsientoFecha).PadLeft(10, '0') +
                                    " | " + itemProveedorCtaCte.Descripcion.PadRight(44, ' ') + //Establecí el valor del ancho de esta columna en 44 para rellenar el ListBox
                                    " | " + ("$" + Formulario.ValidarCampoMoneda(itemProveedorCtaCte.Debe)).PadLeft(12, ' ') +
                                    " | " + ("$" + Formulario.ValidarCampoMoneda(itemProveedorCtaCte.Haber)).PadLeft(12, ' ') +
                                    " | " + ("$" + Formulario.ValidarCampoMoneda(saldoAsientoContable)).PadLeft(12, ' '));
                            ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                        }
                        cuitAntecesor = itemProveedorCtaCte.Cuit; //Deducción de Saldo Antecesor - Paso 2: Establece el CUIT actual (Importante para completar el ciclo)
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002CTACTE_PROVEEDOR: Hay un conflicto en la consulta de la cuenta corriente del proveedor." + e, e); }
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
            catch (MySqlException e) { Mensaje.Error("Error-M004CTACTE_PROVEEDOR: Hay un conflicto en el cálculo del debe y haber de la cuenta corriente del proveedor.", e); }
            finally { _conexion.Dispose(); }
            return valorDebeHaber;
        }

        private double contabilizarSaldoAntecesor(string cuit, DateTime desde)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_SALDO_ANTECESOR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@cuit", cuit); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        object resultado = comandoDB.ExecuteScalar(); //Ejecuta la consulta en la Base de Datos
                        if (resultado != DBNull.Value) return (double)resultado; //Devuelve el resultado de la sumatoria del Saldo Antecesor
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006CTACTE_PROVEEDOR: Hay un conflicto en el cálculo del saldo antecesor de la cuenta corriente del proveedor.", e); }
            finally { _conexion.Dispose(); }
            return 0.00;
        }
        #endregion

        #region Métodos de Instanciación
        private ProveedorCtaCte instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new ProveedorCtaCte(
                Convert.ToInt64(lectorDB["id_asiento"]),
                Convert.ToInt64(lectorDB["asiento_nro"]),
                Convert.ToDateTime(lectorDB["asiento_fecha"]),
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable"]), false),
                Convert.ToString(lectorDB["descripcion"]),
                Convert.ToDouble(lectorDB["debe"]),
                Convert.ToDouble(lectorDB["haber"]),
                0.00, //Saldo
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