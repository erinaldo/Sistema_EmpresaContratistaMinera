using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_EstadoFinanciero : IEstadoFinanciero, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        private double _totalIngreso_Fondo = 0.00;
        private double _totalIngreso_OtroCredito = 0.00;
        private double _totalEgreso_Proveedor = 0.00;
        private double _totalEgreso_Nomina = 0.00;
        private double _totalEgreso_Otro = 0.00;
        private double _totalEgreso_Retiro = 0.00;
        #endregion

        #region Consultas SQL
        private const string SELECT_EGRESO = @"SELECT data_cuenta_contable.denominacion, SUM(fondo.debe) AS debe, SUM(fondo.haber) AS haber";
        private const string SELECT_INGRESO = @"SELECT data_cuenta_contable.denominacion, SUM(fondo.debe) AS debe, SUM(fondo.haber) AS haber";
        private const string FROM_EGRESO1 = @" FROM data_asiento_contable AS asiento
            INNER JOIN data_cuenta_contable ON (asiento.id_cuenta_contable = data_cuenta_contable.id AND (data_cuenta_contable.tipo_cuenta = '211000 PASIVO CORRIENTE > DEUDAS COMERCIALES') AND asiento.origen_tipo = 'PAP')
            INNER JOIN data_asiento_contable AS fondo ON (asiento.asiento_nro = fondo.asiento_nro AND fondo.conciliacion = 'CONCILIADO')";
        private const string FROM_EGRESO2 = @" FROM data_asiento_contable AS asiento
            INNER JOIN data_cuenta_contable ON (asiento.id_cuenta_contable = data_cuenta_contable.id AND (data_cuenta_contable.tipo_cuenta = '214000 PASIVO CORRIENTE > DEUDAS SOCIALES' OR data_cuenta_contable.tipo_cuenta = '114000 ACTIVO CORRIENTE > OTROS CREDITOS') AND asiento.origen_tipo = 'PAN')
            INNER JOIN data_asiento_contable AS fondo ON (asiento.asiento_nro = fondo.asiento_nro AND fondo.conciliacion = 'CONCILIADO')";
        private const string FROM_EGRESO3 = @" FROM data_asiento_contable AS asiento
            INNER JOIN data_cuenta_contable ON (asiento.id_cuenta_contable = data_cuenta_contable.id AND (data_cuenta_contable.tipo_cuenta = '213000 PASIVO CORRIENTE > DEUDAS FISCALES' OR data_cuenta_contable.tipo_cuenta = '214000 PASIVO CORRIENTE > DEUDAS SOCIALES') AND asiento.origen_tipo = 'PAO')
            INNER JOIN data_asiento_contable AS fondo ON (asiento.asiento_nro = fondo.asiento_nro AND fondo.conciliacion = 'CONCILIADO')";
        private const string FROM_EGRESO4 = @" FROM data_asiento_contable AS asiento
            INNER JOIN data_cuenta_contable ON (asiento.id_cuenta_contable = data_cuenta_contable.id AND (data_cuenta_contable.denominacion = 'RETIRO DE SOCIO' OR data_cuenta_contable.denominacion = 'RETIRO DE OTROS SOCIOS'))
            INNER JOIN data_asiento_contable AS fondo ON (asiento.asiento_nro = fondo.asiento_nro AND fondo.conciliacion = 'CONCILIADO')";
        private const string FROM_INGRESO1 = @" FROM data_asiento_contable AS fondo
            INNER JOIN data_cuenta_contable ON (fondo.id_cuenta_contable = data_cuenta_contable.id AND (data_cuenta_contable.tipo_cuenta LIKE '%ACTIVO CORRIENTE > DISPONIBILIDADES%' AND fondo.origen_tipo = 'COB' AND fondo.conciliacion = 'CONCILIADO'))";
        private const string FROM_INGRESO2 = @" FROM data_asiento_contable AS fondo
            INNER JOIN data_cuenta_contable ON (fondo.id_cuenta_contable = data_cuenta_contable.id AND ((data_cuenta_contable.denominacion <> 'RETIRO DE SOCIO' OR data_cuenta_contable.denominacion <> 'RETIRO DE OTROS SOCIOS') AND data_cuenta_contable.denominacion <> 'ANTICIPOS DE SUELDOS' AND data_cuenta_contable.tipo_cuenta = '114000 ACTIVO CORRIENTE > OTROS CREDITOS'))";
        private const string WHERE = @" WHERE (MONTH(fondo.asiento_fecha) = @mes AND YEAR(fondo.asiento_fecha) = @anio)"; //Filtro Objeto por Fecha de Asiento
        private const string GROUP = @" GROUP BY data_cuenta_contable.denominacion";
        private const string ORDER = @" ORDER BY id_cuenta_contable ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        #endregion

        #region Métodos
        private List<EstadoFinanciero> obtenerIngreso_Fondo(string periodo)
        {
            List<EstadoFinanciero> ListaDeObjetos = new List<EstadoFinanciero>();
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT_INGRESO + FROM_INGRESO1 + WHERE + GROUP)) //Crea un comando de Base de Datos (6 = DEUDORES POR VENTAS)
                    {
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            _totalIngreso_Fondo = 0.00; //Resetea el valor por seguridad
                            while (lectorDB.Read())
                            {
                                double debe = (!lectorDB["debe"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["debe"]) : 0.00;
                                _totalIngreso_Fondo += (debe);
                                ListaDeObjetos.Add(new EstadoFinanciero("INGRESOS:", Convert.ToString(lectorDB["denominacion"]), debe));
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002ESTADO_FINANCIERO: Hay un conflicto en la consulta de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        private List<EstadoFinanciero> obtenerIngreso_OtroCredito(string periodo)
        {
            List<EstadoFinanciero> ListaDeObjetos = new List<EstadoFinanciero>();
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT_INGRESO + FROM_INGRESO2 + WHERE + GROUP)) //Crea un comando de Base de Datos (6 = DEUDORES POR VENTAS)
                    {
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            _totalIngreso_OtroCredito = 0.00; //Resetea el valor por seguridad
                            while (lectorDB.Read())
                            {
                                double debe = (!lectorDB["debe"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["debe"]) : 0.00;
                                _totalIngreso_OtroCredito += (debe);
                                ListaDeObjetos.Add(new EstadoFinanciero("INGRESOS:", Convert.ToString(lectorDB["denominacion"]), debe));
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004ESTADO_FINANCIERO: Hay un conflicto en la consulta de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        private List<EstadoFinanciero> obtenerEgreso_Proveedor(string periodo)
        {
            List<EstadoFinanciero> ListaDeObjetos = new List<EstadoFinanciero>();
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT_EGRESO + FROM_EGRESO1 + WHERE + GROUP)) //Crea un comando de Base de Datos (6 = DEUDORES POR VENTAS)
                    {
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            _totalEgreso_Proveedor = 0.00; //Resetea el valor por seguridad
                            while (lectorDB.Read())
                            {
                                double haber = (!lectorDB["haber"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["haber"]) : 0.00;
                                _totalEgreso_Proveedor += (haber);
                                ListaDeObjetos.Add(new EstadoFinanciero("EGRESOS:", Convert.ToString(lectorDB["denominacion"]), haber));
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006ESTADO_FINANCIERO: Hay un conflicto en la consulta de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        private List<EstadoFinanciero> obtenerEgreso_Nomina(string periodo)
        {
            List<EstadoFinanciero> ListaDeObjetos = new List<EstadoFinanciero>();
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT_EGRESO + FROM_EGRESO2 + WHERE + GROUP)) //Crea un comando de Base de Datos (6 = DEUDORES POR VENTAS)
                    {
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            _totalEgreso_Nomina = 0.00; //Resetea el valor por seguridad
                            while (lectorDB.Read())
                            {
                                double haber = (!lectorDB["haber"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["haber"]) : 0.00;
                                _totalEgreso_Nomina += (haber);
                                ListaDeObjetos.Add(new EstadoFinanciero("EGRESOS:", Convert.ToString(lectorDB["denominacion"]), haber));
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008ESTADO_FINANCIERO: Hay un conflicto en la consulta de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        private List<EstadoFinanciero> obtenerEgreso_Otro(string periodo)
        {
            List<EstadoFinanciero> ListaDeObjetos = new List<EstadoFinanciero>();
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT_EGRESO + FROM_EGRESO3 + WHERE + GROUP)) //Crea un comando de Base de Datos (6 = DEUDORES POR VENTAS)
                    {
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            _totalEgreso_Otro = 0.00; //Resetea el valor por seguridad
                            while (lectorDB.Read())
                            {
                                double haber = (!lectorDB["haber"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["haber"]) : 0.00;
                                _totalEgreso_Otro += (haber);
                                ListaDeObjetos.Add(new EstadoFinanciero("EGRESOS:", Convert.ToString(lectorDB["denominacion"]), haber));
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M0010ESTADO_FINANCIERO: Hay un conflicto en la consulta de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        private List<EstadoFinanciero> obtenerEgreso_Retiro(string periodo)
        {
            List<EstadoFinanciero> ListaDeObjetos = new List<EstadoFinanciero>();
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT_EGRESO + FROM_EGRESO4 + WHERE + GROUP)) //Crea un comando de Base de Datos (6 = DEUDORES POR VENTAS)
                    {
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            _totalEgreso_Retiro = 0.00; //Resetea el valor por seguridad
                            while (lectorDB.Read())
                            {
                                double haber = (!lectorDB["haber"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["haber"]) : 0.00;
                                _totalEgreso_Retiro += (haber);
                                ListaDeObjetos.Add(new EstadoFinanciero("EGRESOS:", Convert.ToString(lectorDB["denominacion"]), haber));
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M0012ESTADO_FINANCIERO: Hay un conflicto en la consulta de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<CatalogoBase> obtenerCatalago(string periodo, string catalogo)
        {
            int idItem = 0;
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            List<EstadoFinanciero> ListaDeObjetos = new List<EstadoFinanciero>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            ListaDeObjetos.AddRange(obtenerIngreso_Fondo(periodo));
            ListaDeObjetos.AddRange(obtenerIngreso_OtroCredito(periodo));
            ListaDeObjetos.Add(new EstadoFinanciero("INGRESOS", "TOTAL", _totalIngreso_Fondo + _totalIngreso_OtroCredito));
            ListaDeObjetos.AddRange(obtenerEgreso_Proveedor(periodo));
            ListaDeObjetos.AddRange(obtenerEgreso_Nomina(periodo));
            ListaDeObjetos.AddRange(obtenerEgreso_Otro(periodo));
            ListaDeObjetos.AddRange(obtenerEgreso_Retiro(periodo));
            ListaDeObjetos.Add(new EstadoFinanciero("EGRESOS", "TOTAL", _totalEgreso_Proveedor + _totalEgreso_Nomina + _totalEgreso_Otro));
            ListaDeObjetos.Add(new EstadoFinanciero("REDONDEO FINANCIERO", "TOTAL", (_totalIngreso_Fondo + _totalIngreso_OtroCredito) - (_totalEgreso_Proveedor + _totalEgreso_Nomina + _totalEgreso_Otro)));
            foreach (EstadoFinanciero itemEstadoFinanciero in ListaDeObjetos)
            {
                if (catalogo == "CATALOGO1")
                {
                    CatalogoBase elemento = new CatalogoBase(
                        idItem++,
                        itemEstadoFinanciero.SubTitulo.Trim().PadRight(30, ' ') +
                            " | " + itemEstadoFinanciero.Denominacion.Trim().PadRight(71, ' ') + //Establece elvalor de 71 para completar el ancho de ListBox
                            " | " + Formulario.ValidarCampoMoneda(itemEstadoFinanciero.Monto).PadLeft(12, ' '));
                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                }
                else if (catalogo == "CATALOGO2")
                {
                    CatalogoBase elemento = new CatalogoBase(
                        idItem++,
                        ((itemEstadoFinanciero.Denominacion == "TOTAL") ? itemEstadoFinanciero.SubTitulo.Trim().PadRight(30, ' ') : "") +
                            " | " + itemEstadoFinanciero.Denominacion.Trim().PadRight(40, ' ') +
                            " | " + Formulario.ValidarCampoMoneda(itemEstadoFinanciero.Monto).PadLeft(12, ' '));
                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                }
            }
            return ListaDeElementos;
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