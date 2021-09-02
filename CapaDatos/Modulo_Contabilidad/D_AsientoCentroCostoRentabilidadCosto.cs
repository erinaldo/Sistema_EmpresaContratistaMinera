using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_AsientoCentroCostoRentabilidadCosto : IAsientoCentroCostoRentabilidadCosto, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        private double _totalCosto_CostoDeNomina = 0.00;
        private double _totalCosto_BienesDeCambio = 0.00;
        private double _totalCosto_BienesDeUso = 0.00;
        private double _totalCosto_OtrosEgresos = 0.00;
        #endregion

        #region Consultas SQL
        private const string QUERY_NOMINA = @"SELECT data_cuenta_contable.denominacion, SUM(data_asiento_contable.debe) AS debe, SUM(data_asiento_contable.haber) AS haber
            FROM data_asiento_contable
            INNER JOIN data_cuenta_contable ON data_asiento_contable.id_cuenta_contable = data_cuenta_contable.id AND data_cuenta_contable.tipo_cuenta = '520000 EGRESOS > COSTO DE NOMINA'
            INNER JOIN data_sueldo ON (origen_tipo = 'LQS' AND origen_id = data_sueldo.id)
            INNER JOIN data_centro_costo ON data_sueldo.id_centro_costo = data_centro_costo.id
            WHERE data_centro_costo.denominacion = @centro_costo AND (MONTH(data_asiento_contable.asiento_fecha) = @mes AND YEAR(data_asiento_contable.asiento_fecha) = @anio)";
        private const string QUERY_BIENESDECAMBIO = @"SELECT data_cuenta_contable.denominacion,
            SUM(IF(data_compra.afip_cbte_tipo = 01 OR data_compra.afip_cbte_tipo = 06 OR data_compra.afip_cbte_tipo = 11 OR data_compra.afip_cbte_tipo = 51 OR data_compra.afip_cbte_tipo = 02 OR data_compra.afip_cbte_tipo = 07 OR data_compra.afip_cbte_tipo = 12 OR data_compra.afip_cbte_tipo = 52, data_compra_detalle.costo_unitario * data_compra_detalle.cantidad, 0.00) / (1 + (data_compra.descuento_porcentual / 100))) as debe,
            SUM(IF(data_compra.afip_cbte_tipo = 03 OR data_compra.afip_cbte_tipo = 08 OR data_compra.afip_cbte_tipo = 13 OR data_compra.afip_cbte_tipo = 53, data_compra_detalle.costo_unitario * data_compra_detalle.cantidad, 0.00) / (1 + (data_compra.descuento_porcentual / 100))) as haber
            FROM data_compra
            INNER JOIN data_compra_detalle ON data_compra.id = data_compra_detalle.id_compra
            INNER JOIN data_cuenta_contable ON data_compra.id_cuenta_contable = data_cuenta_contable.id AND data_cuenta_contable.tipo_cuenta = '115000 ACTIVO CORRIENTE > BIENES DE CAMBIO'
            INNER JOIN data_centro_costo ON data_compra_detalle.id_centro_costo = data_centro_costo.id
            WHERE data_centro_costo.denominacion = @centro_costo AND (MONTH(data_compra.afip_cbte_fecha) = @mes AND YEAR(data_compra.afip_cbte_fecha) = @anio)";
        private const string QUERY_BIENESDEUSO = @"SELECT data_cuenta_contable.denominacion,
            SUM(IF(data_compra.afip_cbte_tipo = 01 OR data_compra.afip_cbte_tipo = 06 OR data_compra.afip_cbte_tipo = 11 OR data_compra.afip_cbte_tipo = 51 OR data_compra.afip_cbte_tipo = 02 OR data_compra.afip_cbte_tipo = 07 OR data_compra.afip_cbte_tipo = 12 OR data_compra.afip_cbte_tipo = 52, data_compra_detalle.costo_unitario * data_compra_detalle.cantidad, 0.00) / (1 + (data_compra.descuento_porcentual / 100))) as debe,
            SUM(IF(data_compra.afip_cbte_tipo = 03 OR data_compra.afip_cbte_tipo = 08 OR data_compra.afip_cbte_tipo = 13 OR data_compra.afip_cbte_tipo = 53, data_compra_detalle.costo_unitario * data_compra_detalle.cantidad, 0.00) / (1 + (data_compra.descuento_porcentual / 100))) as haber
            FROM data_compra
            INNER JOIN data_compra_detalle ON data_compra.id = data_compra_detalle.id_compra
            INNER JOIN data_cuenta_contable ON data_compra.id_cuenta_contable = data_cuenta_contable.id AND data_cuenta_contable.tipo_cuenta = '116000 ACTIVO CORRIENTE > BIENES DE USO'
            INNER JOIN data_centro_costo ON data_compra_detalle.id_centro_costo = data_centro_costo.id
            WHERE data_centro_costo.denominacion = @centro_costo AND (MONTH(data_compra.afip_cbte_fecha) = @mes AND YEAR(data_compra.afip_cbte_fecha) = @anio)";
        private const string QUERY_OTROSEGRESOS = @"SELECT data_cuenta_contable.denominacion,
            SUM(IF(data_compra.afip_cbte_tipo = 01 OR data_compra.afip_cbte_tipo = 06 OR data_compra.afip_cbte_tipo = 11 OR data_compra.afip_cbte_tipo = 51 OR data_compra.afip_cbte_tipo = 02 OR data_compra.afip_cbte_tipo = 07 OR data_compra.afip_cbte_tipo = 12 OR data_compra.afip_cbte_tipo = 52, data_compra_detalle.costo_unitario * data_compra_detalle.cantidad, 0.00) / (1 + (data_compra.descuento_porcentual / 100))) as debe,
            SUM(IF(data_compra.afip_cbte_tipo = 03 OR data_compra.afip_cbte_tipo = 08 OR data_compra.afip_cbte_tipo = 13 OR data_compra.afip_cbte_tipo = 53, data_compra_detalle.costo_unitario * data_compra_detalle.cantidad, 0.00) / (1 + (data_compra.descuento_porcentual / 100))) as haber
            FROM data_compra
            INNER JOIN data_compra_detalle ON data_compra.id = data_compra_detalle.id_compra
            INNER JOIN data_cuenta_contable ON data_compra.id_cuenta_contable = data_cuenta_contable.id AND data_cuenta_contable.tipo_cuenta = '530000 EGRESOS > OTROS EGRESOS'
            INNER JOIN data_centro_costo ON data_compra_detalle.id_centro_costo = data_centro_costo.id
            WHERE data_centro_costo.denominacion = @centro_costo AND (MONTH(data_compra.afip_cbte_fecha) = @mes AND YEAR(data_compra.afip_cbte_fecha) = @anio)";
        private const string GROUP = @" GROUP BY id_cuenta_contable";
        private const string ORDER = @" ORDER BY id_cuenta_contable ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        #endregion

        #region Métodos
        private List<AsientoCentroCostoRentabilidadCosto> obtenerCosto_CostoDeNomina(string centroCosto, string periodo)
        {
            List<AsientoCentroCostoRentabilidadCosto> ListaDeObjetos = new List<AsientoCentroCostoRentabilidadCosto>();
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(QUERY_NOMINA + GROUP)) //Crea un comando de Base de Datos (6 = DEUDORES POR VENTAS)
                    {
                        comandoDB.Parameters.AddWithValue("@centro_costo", centroCosto); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            _totalCosto_CostoDeNomina = 0.00; //Resetea el valor por seguridad
                            while (lectorDB.Read())
                            {
                                double debe = (!lectorDB["debe"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["debe"]) : 0.00;
                                _totalCosto_CostoDeNomina += (debe);
                                if (debe > 0) ListaDeObjetos.Add(new AsientoCentroCostoRentabilidadCosto("COSTO DE NOMINA:", Convert.ToString(lectorDB["denominacion"]), 0.00, 0.00, debe, 0.00));
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002ASIENTO_CC_RENTABILIDAD: Hay un conflicto en la consulta de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        private List<AsientoCentroCostoRentabilidadCosto> obtenerCosto_BienesDeCambio(string centroCosto, string periodo)
        {
            List<AsientoCentroCostoRentabilidadCosto> ListaDeObjetos = new List<AsientoCentroCostoRentabilidadCosto>();
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(QUERY_BIENESDECAMBIO + GROUP)) //Crea un comando de Base de Datos (6 = DEUDORES POR VENTAS)
                    {
                        comandoDB.Parameters.AddWithValue("@centro_costo", centroCosto); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            _totalCosto_BienesDeCambio = 0.00; //Resetea el valor por seguridad
                            while (lectorDB.Read())
                            {
                                double debe = (!lectorDB["debe"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["debe"]) : 0.00;
                                double haber = (!lectorDB["haber"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["haber"]) : 0.00;
                                double diferencia = (debe - haber);
                                _totalCosto_BienesDeCambio += diferencia;
                                if (diferencia > 0) ListaDeObjetos.Add(new AsientoCentroCostoRentabilidadCosto("BIENES DE CAMBIO:", Convert.ToString(lectorDB["denominacion"]), 0.00, 0.00, diferencia, 0.00));
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004ASIENTO_CC_RENTABILIDAD: Hay un conflicto en la consulta de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        private List<AsientoCentroCostoRentabilidadCosto> obtenerCosto_BienesDeUso(string centroCosto, string periodo)
        {
            List<AsientoCentroCostoRentabilidadCosto> ListaDeObjetos = new List<AsientoCentroCostoRentabilidadCosto>();
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(QUERY_BIENESDEUSO + GROUP)) //Crea un comando de Base de Datos (6 = DEUDORES POR VENTAS)
                    {
                        comandoDB.Parameters.AddWithValue("@centro_costo", centroCosto); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            _totalCosto_BienesDeUso = 0.00; //Resetea el valor por seguridad
                            while (lectorDB.Read())
                            {
                                double debe = (!lectorDB["debe"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["debe"]) : 0.00;
                                double haber = (!lectorDB["haber"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["haber"]) : 0.00;
                                double diferencia = (debe - haber);
                                _totalCosto_BienesDeUso += diferencia;
                                if (diferencia > 0) ListaDeObjetos.Add(new AsientoCentroCostoRentabilidadCosto("BIENES DE USO:", Convert.ToString(lectorDB["denominacion"]), 0.00, 0.00, diferencia, 0.00));
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006ASIENTO_CC_RENTABILIDAD: Hay un conflicto en la consulta de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        private List<AsientoCentroCostoRentabilidadCosto> obtenerCosto_OtrosEgresos(string centroCosto, string periodo)
        {
            List<AsientoCentroCostoRentabilidadCosto> ListaDeObjetos = new List<AsientoCentroCostoRentabilidadCosto>();
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(QUERY_OTROSEGRESOS + GROUP)) //Crea un comando de Base de Datos (6 = DEUDORES POR VENTAS)
                    {
                        comandoDB.Parameters.AddWithValue("@centro_costo", centroCosto); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            _totalCosto_OtrosEgresos = 0.00; //Resetea el valor por seguridad
                            while (lectorDB.Read())
                            {
                                double debe = (!lectorDB["debe"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["debe"]) : 0.00;
                                double haber = (!lectorDB["haber"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["haber"]) : 0.00;
                                double diferencia = (debe - haber);
                                _totalCosto_OtrosEgresos += diferencia;
                                if (diferencia > 0) ListaDeObjetos.Add(new AsientoCentroCostoRentabilidadCosto("OTROS EGRESOS:", Convert.ToString(lectorDB["denominacion"]), 0.00, 0.00, diferencia, 0.00));
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008ASIENTO_CC_RENTABILIDAD: Hay un conflicto en la consulta de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<AsientoCentroCostoRentabilidadCosto> obtenerObjetos(string centroCosto, string periodo)
        {
            List<AsientoCentroCostoRentabilidadCosto> ListaDeObjetos = new List<AsientoCentroCostoRentabilidadCosto>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            ListaDeObjetos.AddRange(obtenerCosto_CostoDeNomina(centroCosto, periodo));
            ListaDeObjetos.AddRange(obtenerCosto_BienesDeCambio(centroCosto, periodo));
            ListaDeObjetos.AddRange(obtenerCosto_BienesDeUso(centroCosto, periodo));
            ListaDeObjetos.AddRange(obtenerCosto_OtrosEgresos(centroCosto, periodo));
            foreach (AsientoCentroCostoRentabilidadCosto item in ListaDeObjetos)
            {
                double totalCostoReal = (_totalCosto_CostoDeNomina + _totalCosto_BienesDeCambio + _totalCosto_BienesDeUso + _totalCosto_OtrosEgresos);
                item.RealCostoIncidencia = Math.Round((100 / totalCostoReal) * item.RealCosto, 2); //Calcula la incidencia del costo real
            }
            return ListaDeObjetos;
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