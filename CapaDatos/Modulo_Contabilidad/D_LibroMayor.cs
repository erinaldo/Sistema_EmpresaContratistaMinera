using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_LibroMayor : ILibroMayor, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_asiento_contable.id, asiento_nro, asiento_fecha,
            id_cuenta_contable, descripcion, debe, haber, conciliacion, origen_tipo, origen_id";
        private const string FROM = @" FROM data_asiento_contable";
        private const string WHERE1 = @" WHERE date(data_asiento_contable.asiento_fecha) >= date(@desde) AND date(data_asiento_contable.asiento_fecha) <= date(@hasta)"; //Filtro por Objeto Fecha de Asiento
        private const string WHERE2 = @" WHERE data_asiento_contable.id_cuenta_contable = @id_cuenta_contable
            AND (date(data_asiento_contable.asiento_fecha) >= date(@desde) AND date(data_asiento_contable.asiento_fecha) <= date(@hasta))"; //Filtro por Objeto cuenta contable y Fecha de Asiento
        private const string SUM_DEBE = @"SELECT SUM(data_asiento_contable.debe)"; //Obtiene la sumatoria de la columna Debe
        private const string SUM_HABER = @"SELECT SUM(data_asiento_contable.haber)"; //Obtiene la sumatoria de la columna Haber
        private const string SUM_SALDO_ANTECESOR = @"SELECT (SUM(data_asiento_contable.debe) - SUM(data_asiento_contable.haber)) AS saldo_inicial" + FROM + @" WHERE data_asiento_contable.id_cuenta_contable = @id_cuenta_contable AND date(data_asiento_contable.asiento_fecha) < date(@desde)"; //Calcula el Saldo antecesor entre Debe y el Haber filtrado por CUIT
        private const string ORDER = @" ORDER BY id_cuenta_contable ASC, asiento_fecha ASC, id ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(long idCuentaContable, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            string condicional = (idCuentaContable > 0) ? WHERE2 : WHERE1; //Consulta filtrada por Fecha de Asiento y/o Cuenta Contable  
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            long cuentaContableAntecesor = 0;
            double saldoAntecesor = 0.00;
            double saldoAsientoContable = 0.00;
            List<LibroMayor> ListaDeObjetos = new List<LibroMayor>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                LibroMayor objLibroMayor = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objLibroMayor); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                    foreach (LibroMayor itemLibroMayor in ListaDeObjetos)
                    {
                        if (cuentaContableAntecesor != itemLibroMayor.CuentaContable.Id) saldoAsientoContable = saldoAntecesor = contabilizarSaldoAntecesor(itemLibroMayor.CuentaContable.Id, desde); //Deducción de Saldo Antecesor - Paso 1: Obtiene el Saldo Antecesor en relación al ID de la Cuenta Contable
                        saldoAsientoContable = Math.Round(((saldoAsientoContable + itemLibroMayor.Debe) - itemLibroMayor.Haber), 2); //Calcula el Saldo del Asiento Contable. Se obtiene sumándolo al Saldo Antecesor el Debe y por último se le resta el Haber
                        if (catalogo == "CATALOGO1")
                        {
                            CatalogoBase elemento = new CatalogoBase(
                                itemLibroMayor.Id,
                                itemLibroMayor.CuentaContable.Denominacion.PadRight(25, ' ') +
                                    " | " + Fecha.ConvertirFecha(itemLibroMayor.AsientoFecha).PadLeft(10, '0') +
                                    " | " + itemLibroMayor.Descripcion.PadRight(35, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemLibroMayor.Debe).PadLeft(11, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemLibroMayor.Haber).PadLeft(11, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(saldoAsientoContable).PadLeft(11, ' '));
                                ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                        }
                        else if (catalogo == "CATALOGO2")
                        {
                            CatalogoBase elemento;
                            #region Fila Tipo SubTitulo
                            if (cuentaContableAntecesor != itemLibroMayor.CuentaContable.Id)
                            {
                                double[] Totales = contabilizarDebeHaber(itemLibroMayor.CuentaContable.Id, desde, hasta);
                                elemento = new CatalogoBase(
                                    itemLibroMayor.Id,
                                    itemLibroMayor.CuentaContable.Denominacion.PadRight(25, ' ') +
                                        " | " + ("").PadLeft(10, ' ') +
                                        " | " + ("").PadRight(35, ' ') +
                                        " | " + ("$" + Formulario.ValidarCampoMoneda(Totales[0])).PadLeft(12, ' ') +
                                        " | " + ("$" + Formulario.ValidarCampoMoneda(Totales[1])).PadLeft(12, ' ') +
                                        " | " + ("$" + Formulario.ValidarCampoMoneda(Math.Round((saldoAntecesor + Totales[0]) - Totales[1], 2))).PadLeft(12, ' '));
                                ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                            }
                            #endregion
                            elemento = new CatalogoBase(
                                itemLibroMayor.Id,
                                ("").PadRight(25, ' ') +
                                    " | " + Fecha.ConvertirFecha(itemLibroMayor.AsientoFecha).PadLeft(10, '0') +
                                    " | " + itemLibroMayor.Descripcion.PadRight(35, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemLibroMayor.Debe).PadLeft(12, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemLibroMayor.Haber).PadLeft(12, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(saldoAsientoContable).PadLeft(12, ' '));
                            ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                        }
                        cuentaContableAntecesor = itemLibroMayor.CuentaContable.Id; //Deducción de Saldo Antecesor - Paso 2: Establece el ID de la Cuenta Contable actual (Importante para completar el ciclo)
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002LIBRO_MAYOR: Hay un conflicto en la consulta de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public double[] contabilizarDebeHaber(long idCuentaContable, DateTime desde, DateTime hasta)
        {
            double[] valorDebeHaber = new double[] { 0.00, 0.00 };
            string condicional = (idCuentaContable > 0) ? WHERE2 : WHERE1; //Consulta filtrada por Fecha de Asiento y/o Cuenta Contable
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_DEBE + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        object resultado = comandoDB.ExecuteScalar();
                        if (resultado != DBNull.Value) valorDebeHaber[0] = (double)resultado; //Almacena la sumatoria del Debe
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_HABER + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        object resultado = comandoDB.ExecuteScalar();
                        if (resultado != DBNull.Value) valorDebeHaber[1] = (double)resultado; //Almacena la sumatoria del Haber
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004LIBRO_MAYOR: Hay un conflicto en el cálculo del debe y haber de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return valorDebeHaber;
        }

        private double contabilizarSaldoAntecesor(long idCuentaContable, DateTime desde)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_SALDO_ANTECESOR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        object resultado = comandoDB.ExecuteScalar(); //Ejecuta la consulta en la Base de Datos
                        if (resultado != DBNull.Value) return (double)resultado; //Devuelve el resultado de la sumatoria del Saldo Antecesor
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006LIBRO_MAYOR: Hay un conflicto en el cálculo del saldo antecesor de la cuenta contable.", e); }
            finally { _conexion.Dispose(); }
            return 0.00;
        }
        #endregion

        #region Métodos de Instanciación
        private LibroMayor instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new LibroMayor(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToInt64(lectorDB["asiento_nro"]),
                Convert.ToDateTime(lectorDB["asiento_fecha"]),
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable"]), false),
                Convert.ToString(lectorDB["descripcion"]),
                Convert.ToDouble(lectorDB["debe"]),
                Convert.ToDouble(lectorDB["haber"]),
                0.00, //Saldo
                Convert.ToString(lectorDB["conciliacion"]),
                Convert.ToString(lectorDB["origen_tipo"]),
                Convert.ToInt64(lectorDB["origen_id"]));
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