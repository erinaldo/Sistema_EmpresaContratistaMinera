using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_ChequeAPagar : IChequeAPagar, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT_PAGO_PROVEEDOR = @"SELECT data_asiento_contable.id, cbte_fecha, medio_cheque_vto, medio_nro, CONCAT(data_proveedor.denominacion, ' (', data_proveedor.cuit, ')') AS denominacion, monto_pagado, descripcion, 'PROVEEDOR' AS modulo";
        private const string SELECT_PAGO_NOMINA = @"SELECT data_asiento_contable.id, cbte_fecha, medio_cheque_vto, medio_nro, CONCAT(data_legajo.denominacion, ' (', data_legajo.cuit, ')') AS denominacion, monto_pagado, descripcion, 'NOMINA' AS modulo";
        private const string SELECT_PAGO_OTRO = @"SELECT data_asiento_contable.id, cbte_fecha, medio_cheque_vto, medio_nro, data_cuenta_contable.denominacion AS denominacion, monto_pagado, descripcion, 'OTROS' AS modulo";
        private const string SELECT_MOVIMIENTO = @"SELECT data_asiento_contable.id, cbte_fecha, medio_cheque_vto, medio_nro, data_cuenta_contable.denominacion AS denominacion, monto AS monto_pagado, descripcion, 'MOV.INT.' AS modulo";
        private const string FROM_PAGO_PROVEEDOR = @" FROM data_asiento_contable 
            INNER JOIN data_pago_proveedor ON (origen_tipo = 'PAP' AND origen_id = data_pago_proveedor.id) AND data_pago_proveedor.medio_pago = 'CHEQUE' AND data_pago_proveedor.estado = 'ACTIVO'
            INNER JOIN data_proveedor ON data_pago_proveedor.id_proveedor = data_proveedor.id";
        private const string FROM_PAGO_NOMINA = @" FROM data_asiento_contable 
            INNER JOIN data_pago_nomina ON (origen_tipo = 'PAN' AND origen_id = data_pago_nomina.id) AND data_pago_nomina.medio_pago = 'CHEQUE' AND data_pago_nomina.estado = 'ACTIVO'
            INNER JOIN data_legajo ON data_pago_nomina.id_legajo = data_legajo.id";
        private const string FROM_PAGO_OTRO = @" FROM data_asiento_contable 
            INNER JOIN data_pago_otro ON (origen_tipo = 'PAO' AND origen_id = data_pago_otro.id) AND data_pago_otro.medio_pago = 'CHEQUE' AND data_pago_otro.estado = 'ACTIVO'
            INNER JOIN data_cuenta_contable ON data_pago_otro.id_cuenta_contable_destino = data_cuenta_contable.id";
        private const string FROM_MOVIMIENTO = @" FROM data_asiento_contable 
            INNER JOIN data_movimiento_fondo ON (origen_tipo = 'MOV' AND origen_id = data_movimiento_fondo.id) AND data_movimiento_fondo.medio_pago = 'CHEQUE' AND data_movimiento_fondo.estado = 'ACTIVO'
            INNER JOIN data_cuenta_contable ON data_movimiento_fondo.id_cuenta_contable_destino = data_cuenta_contable.id";
        private const string WHERE = @" WHERE data_asiento_contable.conciliacion = 'S/CONCILIAR'"; //Filtro por Objeto Estado de Conciliación
        private const string AND = @" AND (date(medio_cheque_vto) >= date(@desde) AND date(medio_cheque_vto) <= date(@hasta))"; //Filtro por Objeto Fecha de Vto.
        private const string SUM_MONTO = @"SELECT SUM(monto_pagado)"; //Obtiene la sumatoria de la columna monto_pagado
        private const string ORDER = @" ORDER BY medio_cheque_vto ASC, denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM_PAGO_PROVEEDOR + WHERE + AND + @" UNION ALL SELECT COUNT(*)" + FROM_PAGO_NOMINA + WHERE + AND + @" UNION ALL SELECT COUNT(*)" + FROM_PAGO_OTRO + WHERE + AND + @" UNION ALL SELECT COUNT(*)" + FROM_MOVIMIENTO + WHERE + AND)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT_PAGO_PROVEEDOR + FROM_PAGO_PROVEEDOR + WHERE + AND + @" UNION ALL " + SELECT_PAGO_NOMINA + FROM_PAGO_NOMINA + WHERE + AND + @" UNION ALL " + SELECT_PAGO_OTRO + FROM_PAGO_OTRO + WHERE + AND + @" UNION ALL " + SELECT_MOVIMIENTO + FROM_MOVIMIENTO + WHERE + AND + ORDER)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
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
                                         Convert.ToString(lectorDB["medio_nro"]).PadLeft(8, '0') + 
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["medio_cheque_vto"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(49, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["monto_pagado"])).PadLeft(12, ' ') +
                                            " | " + Convert.ToString(lectorDB["modulo"]).PadRight(9, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                else if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                         Convert.ToInt64(lectorDB["id"]),
                                         Convert.ToString(lectorDB["medio_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["medio_cheque_vto"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(49, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["monto_pagado"])).PadLeft(12, ' ') +
                                            " | " + Convert.ToString(lectorDB["descripcion"]).PadRight(40, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002CHEQUE_APAGAR: Hay un conflicto en la consulta de los cheques.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<ChequeAPagar> obtenerObjetos(DateTime desde, DateTime hasta)
        {
            List<ChequeAPagar> ListaDeObjetos = new List<ChequeAPagar>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT_PAGO_PROVEEDOR + FROM_PAGO_PROVEEDOR + WHERE + AND + @" UNION ALL " + SELECT_PAGO_NOMINA + FROM_PAGO_NOMINA + WHERE + AND + @" UNION ALL " + SELECT_PAGO_OTRO + FROM_PAGO_OTRO + WHERE + AND + @" UNION ALL " + SELECT_MOVIMIENTO + FROM_MOVIMIENTO + WHERE + AND + ORDER)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                ChequeAPagar objChequeAPagar = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objChequeAPagar); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004CHEQUE_APAGAR: Hay un conflicto en la consulta de los cheques.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public double obtenerDeudaAProveedor(DateTime desde, DateTime hasta)
        {
            double totalDeudaAProveedor = 0.00;
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_MONTO + FROM_PAGO_PROVEEDOR + WHERE + AND)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega el parámetro en la condición del contador
                        var respuesta = comandoDB.ExecuteScalar(); //Ejecuta la consulta para calcular la sumatoria
                        totalDeudaAProveedor = (respuesta != DBNull.Value) ? Convert.ToDouble(respuesta) : 0.00;
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006CHEQUE_APAGAR: Hay un conflicto en la consulta de los cheques.", e); }
            finally { _conexion.Dispose(); }
            return totalDeudaAProveedor;
        }

        public double obtenerDeudaANomina(DateTime desde, DateTime hasta)
        {
            double totalDeudaANomina = 0.00;
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_MONTO + FROM_PAGO_NOMINA + WHERE + AND)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega el parámetro en la condición del contador
                        var respuesta = comandoDB.ExecuteScalar(); //Ejecuta la consulta para calcular la sumatoria
                        totalDeudaANomina = (respuesta != DBNull.Value) ? Convert.ToDouble(respuesta) : 0.00;
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008CHEQUE_APAGAR: Hay un conflicto en la consulta de los cheques.", e); }
            finally { _conexion.Dispose(); }
            return totalDeudaANomina;
        }

        public double obtenerDeudaAOtro(DateTime desde, DateTime hasta)
        {
            double totalDeudaAOtro = 0.00;
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_MONTO + FROM_PAGO_OTRO + WHERE + AND)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega el parámetro en la condición del contador
                        var respuesta = comandoDB.ExecuteScalar(); //Ejecuta la consulta para calcular la sumatoria
                        totalDeudaAOtro = (respuesta != DBNull.Value) ? Convert.ToDouble(respuesta) : 0.00;
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010CHEQUE_APAGAR: Hay un conflicto en la consulta de los cheques.", e); }
            finally { _conexion.Dispose(); }
            return totalDeudaAOtro;
        }

        public double obtenerDeudaAMovimiento(DateTime desde, DateTime hasta)
        {
            double totalDeudaAMovimiento = 0.00;
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_MONTO + FROM_MOVIMIENTO + WHERE + AND)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega el parámetro en la condición del contador
                        var respuesta = comandoDB.ExecuteScalar(); //Ejecuta la consulta para calcular la sumatoria
                        totalDeudaAMovimiento = (respuesta != DBNull.Value) ? Convert.ToDouble(respuesta) : 0.00;
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M012CHEQUE_APAGAR: Hay un conflicto en la consulta de los cheques.", e); }
            finally { _conexion.Dispose(); }
            return totalDeudaAMovimiento;
        }
        #endregion

        #region Métodos de Instanciación
        private ChequeAPagar instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new ChequeAPagar(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToDateTime(lectorDB["cbte_fecha"]),
                Convert.ToDateTime(lectorDB["medio_cheque_vto"]),
                Convert.ToString(lectorDB["medio_nro"]),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToDouble(lectorDB["monto_pagado"]),
                Convert.ToString(lectorDB["descripcion"]) );
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