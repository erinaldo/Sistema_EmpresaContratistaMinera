using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_EstadoResultados : IEstadoResultados, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        private double _totalCostosDeVenta = 0.00;
        private double _totalGasto = 0.00;
        private double _totalUtilidadBruta = 0.00;
        private double _totalUtilidadAntesDeImpuesto = 0.00;
        private double _totalVentaNeta = 0.00;
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_cuenta_contable.denominacion, SUM(data_asiento_contable.debe) AS debe, SUM(data_asiento_contable.haber) AS haber";
        private const string FROM = @" FROM data_asiento_contable
            INNER JOIN data_cuenta_contable ON data_asiento_contable.id_cuenta_contable = data_cuenta_contable.id";
        private const string WHERE = @" WHERE (MONTH(data_asiento_contable.asiento_fecha) = @mes AND YEAR(data_asiento_contable.asiento_fecha) = @anio)"; //Filtro Objeto por Fecha de Asiento
        private const string AND1 = @" AND data_cuenta_contable.tipo_cuenta = '410000 INGRESOS > INGRESO POR VENTAS'"; //Filtrar y obtener las Ventas Brutas
        private const string AND2 = @" AND (data_cuenta_contable.tipo_cuenta = '115000 ACTIVO CORRIENTE > BIENES DE CAMBIO' OR data_cuenta_contable.tipo_cuenta = '520000 EGRESOS > COSTO DE NOMINA')"; //Filtrar y obtener los Costos de Ventas
        private const string AND3 = @" AND (data_cuenta_contable.tipo_cuenta = '116000 ACTIVO CORRIENTE > BIENES DE USO' OR data_cuenta_contable.tipo_cuenta = '530000 EGRESOS > OTROS EGRESOS')"; //Filtrar y obtener los Gastos
        private const string GROUP = @" GROUP BY id_cuenta_contable";
        private const string ORDER = @" ORDER BY id_cuenta_contable ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        #endregion

        #region Métodos
        private List<EstadoResultados> obtenerVentaBruta_Devolucion_VentaNeta(string periodo)
        {
            List<EstadoResultados> ListaDeObjetos = new List<EstadoResultados>();
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE + AND1)) //Crea un comando de Base de Datos (6 = DEUDORES POR VENTAS)
                    {
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            _totalVentaNeta = 0.00; //Resetea el valor por seguridad
                            while (lectorDB.Read())
                            {
                                double debe = (!lectorDB["debe"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["debe"]) : 0.00;
                                double haber = (!lectorDB["haber"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["haber"]) : 0.00;
                                double diferencia = (haber - debe);
                                _totalVentaNeta += diferencia;
                                ListaDeObjetos.Add(new EstadoResultados("VENTAS:", "VENTAS BRUTAS", haber));
                                ListaDeObjetos.Add(new EstadoResultados("VENTAS:", "DEVOLUCIONES", debe));
                                ListaDeObjetos.Add(new EstadoResultados("VENTAS:", "VENTAS NETAS", _totalVentaNeta));
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002ESTADO_RESULTADOS: Hay un conflicto en la consulta de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        private List<EstadoResultados> obtenerCostosDeVenta_UtilidadBruta(string periodo)
        {
            List<EstadoResultados> ListaDeObjetos = new List<EstadoResultados>();
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE + AND2 + GROUP)) //Crea un comando de Base de Datos (6 = DEUDORES POR VENTAS, 16 = IMP. INTERNOS EFECTUADA, 17 = IVA DEBITO FISCAL)
                    {
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            _totalCostosDeVenta = 0.00; //Resetea el valor por seguridad
                            _totalUtilidadBruta = 0.00; //Resetea el valor por seguridad
                            while (lectorDB.Read())
                            {
                                double debe = (!lectorDB["debe"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["debe"]) : 0.00;
                                double haber = (!lectorDB["haber"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["haber"]) : 0.00;
                                double diferencia = (debe - haber);
                                _totalCostosDeVenta += diferencia;
                                ListaDeObjetos.Add(new EstadoResultados("COSTO DE VENTA:", Convert.ToString(lectorDB["denominacion"]), diferencia));
                            }
                            _totalUtilidadBruta = (_totalVentaNeta - _totalCostosDeVenta);
                            ListaDeObjetos.Add(new EstadoResultados("COSTO DE VENTA:", "TOTAL", _totalCostosDeVenta));
                            ListaDeObjetos.Add(new EstadoResultados("UTILIDAD BRUTA:", "TOTAL", _totalUtilidadBruta));
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004ESTADO_RESULTADOS: Hay un conflicto en la consulta de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        private List<EstadoResultados> obtenerGasto_UtilidadAntesImpuesto(string periodo)
        {
            List<EstadoResultados> ListaDeObjetos = new List<EstadoResultados>();
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE + AND3 + GROUP)) //Crea un comando de Base de Datos (6 = DEUDORES POR VENTAS, 16 = IMP. INTERNOS EFECTUADA, 17 = IVA DEBITO FISCAL)
                    {
                        comandoDB.Parameters.AddWithValue("@mes", periodo.Split('-')[0]); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@anio", periodo.Split('-')[1]); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            _totalGasto = 0.00; //Resetea el valor por seguridad
                            _totalUtilidadAntesDeImpuesto = 0.00; //Resetea el valor por seguridad
                            while (lectorDB.Read())
                            {
                                double debe = (!lectorDB["debe"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["debe"]) : 0.00;
                                double haber = (!lectorDB["haber"].Equals(DBNull.Value)) ? Convert.ToDouble(lectorDB["haber"]) : 0.00;
                                double diferencia = (debe - haber);
                                _totalGasto += diferencia;
                                ListaDeObjetos.Add(new EstadoResultados("GASTOS:", Convert.ToString(lectorDB["denominacion"]), diferencia));
                            }
                            _totalUtilidadAntesDeImpuesto = (_totalUtilidadBruta - _totalGasto);
                            ListaDeObjetos.Add(new EstadoResultados("GASTOS:", "TOTAL", _totalGasto));
                            ListaDeObjetos.Add(new EstadoResultados("UTILIDAD ANTES DE IMPUESTOS:", "TOTAL", _totalUtilidadAntesDeImpuesto));
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006ESTADO_RESULTADOS: Hay un conflicto en la consulta de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        private List<EstadoResultados> obtenerImpuesto_Prevision_UtilidadNeta()
        {
            List<EstadoResultados> ListaDeObjetos = new List<EstadoResultados>();
            double iibb = ((_totalVentaNeta / 100) * Global.EstadoResultado_IIBBTasa);
            double previsionSacDespido = ((_totalVentaNeta / 100) * Global.EstadoResultado_PrevisionSACDesempleoTasa);
            double previsionImpGanancia = ((_totalVentaNeta / 100) * Global.EstadoResultado_PrevisionImpGananciaTasa);
            ListaDeObjetos.Add(new EstadoResultados("IMPUESTOS Y PREVISIONES:", "IIBB + LH (%" + Formulario.ValidarCampoMoneda(Global.EstadoResultado_IIBBTasa) + ")", iibb));
            ListaDeObjetos.Add(new EstadoResultados("IMPUESTOS Y PREVISIONES:", "PREVISION P/SAC Y DESPIDOS (%" + Formulario.ValidarCampoMoneda(Global.EstadoResultado_PrevisionSACDesempleoTasa) + ")", previsionSacDespido));
            ListaDeObjetos.Add(new EstadoResultados("IMPUESTOS Y PREVISIONES:", "PREVISION P/IMP. A LAS GANANCIAS (%" + Formulario.ValidarCampoMoneda(Global.EstadoResultado_PrevisionImpGananciaTasa) + ")", previsionImpGanancia));
            ListaDeObjetos.Add(new EstadoResultados("UTILIDAD NETA:", "TOTAL", _totalUtilidadAntesDeImpuesto - (iibb + previsionSacDespido + previsionImpGanancia)));
            return ListaDeObjetos;
        }

        public List<CatalogoBase> obtenerCatalago(string periodo, string catalogo)
        {
            int idItem = 0;
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            List<EstadoResultados> ListaDeObjetos = new List<EstadoResultados>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            ListaDeObjetos.AddRange(obtenerVentaBruta_Devolucion_VentaNeta(periodo));
            ListaDeObjetos.AddRange(obtenerCostosDeVenta_UtilidadBruta(periodo));
            ListaDeObjetos.AddRange(obtenerGasto_UtilidadAntesImpuesto(periodo));
            ListaDeObjetos.AddRange(obtenerImpuesto_Prevision_UtilidadNeta());
            foreach (EstadoResultados itemEstadoResultados in ListaDeObjetos)
            {
                if (catalogo == "CATALOGO1")
                {
                    CatalogoBase elemento = new CatalogoBase(
                        idItem++,
                        itemEstadoResultados.SubTitulo.Trim().PadRight(30, ' ') +
                            " | " + itemEstadoResultados.Denominacion.Trim().PadRight(71, ' ') + //Establece elvalor de 71 para completar el ancho de ListBox
                            " | " + Formulario.ValidarCampoMoneda(itemEstadoResultados.Monto).PadLeft(12, ' '));
                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                }
                else if (catalogo == "CATALOGO2")
                {
                    CatalogoBase elemento = new CatalogoBase(
                        idItem++,
                        ((itemEstadoResultados.Denominacion == "VENTAS NETAS" || itemEstadoResultados.Denominacion == "TOTAL") ? itemEstadoResultados.SubTitulo.Trim().PadRight(30, ' ') : "") +
                            " | " + itemEstadoResultados.Denominacion.Trim().PadRight(40, ' ') +
                            " | " + Formulario.ValidarCampoMoneda(itemEstadoResultados.Monto).PadLeft(12, ' '));
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