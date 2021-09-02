using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_LibroDiario : ILibroDiario, IDisposable
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
            AND (date(data_asiento_contable.asiento_fecha) >= date(@desde) AND date(data_asiento_contable.asiento_fecha) <= date(@hasta))"; //Filtro por Objeto Cuenta Contable y Fecha de Asiento
        private const string WHERE3 = @" WHERE data_asiento_contable.asiento_nro = @asiento_nro
            AND (date(data_asiento_contable.asiento_fecha) >= date(@desde) AND date(data_asiento_contable.asiento_fecha) <= date(@hasta))"; //Filtro por Objeto Número de Asiento y Fecha de Asiento
        private const string SUM_DEBE = @"SELECT SUM(data_asiento_contable.debe)"; //Obtiene la sumatoria de la columna Debe
        private const string SUM_HABER = @"SELECT SUM(data_asiento_contable.haber)"; //Obtiene la sumatoria de la columna Haber
        private const string ORDER = @" ORDER BY asiento_nro ASC, id ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(long idCuentaContable, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            string condicional = (idCuentaContable > 0) ? WHERE2 : WHERE1; //Consulta filtrada por Fecha de Asiento y/o Cuenta Contable  
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            long asientoNroAntecesor = 0;
            List<LibroDiario> ListaDeObjetos = new List<LibroDiario>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                LibroDiario objLibroDiario = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objLibroDiario); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                    foreach (LibroDiario itemLibroDiario in ListaDeObjetos)
                    {
                        if (catalogo == "CATALOGO1")
                        {
                            CatalogoBase elemento = new CatalogoBase(
                                itemLibroDiario.Id,
                                Convert.ToString(itemLibroDiario.AsientoNro).PadLeft(8, '0') +
                                    " | " + Fecha.ConvertirFecha(itemLibroDiario.AsientoFecha).PadLeft(10, '0') +
                                    " | " + itemLibroDiario.CuentaContable.Denominacion.PadRight(25, ' ') +
                                    " | " + itemLibroDiario.Descripcion.PadRight(35, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemLibroDiario.Debe).PadLeft(11, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemLibroDiario.Haber).PadLeft(11, ' '));
                                ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                        }
                        else if (catalogo == "CATALOGO2")
                        {
                            CatalogoBase elemento;
                            #region Fila Tipo SubTitulo
                            if (idCuentaContable <= 0 && asientoNroAntecesor != itemLibroDiario.AsientoNro)
                            {
                                double[] Totales = contabilizarDebeHaber("NRO_ASIENTO", itemLibroDiario.AsientoNro, desde, hasta);
                                elemento = new CatalogoBase(
                                    itemLibroDiario.Id,
                                    Convert.ToString(itemLibroDiario.AsientoNro).PadLeft(8, '0') +
                                        " | " + ("").PadLeft(10, ' ') +
                                        " | " + ("").PadLeft(25, ' ') +
                                        " | " + ("").PadRight(35, ' ') +
                                        " | " + ("$" + Formulario.ValidarCampoMoneda(Totales[0])).PadLeft(12, ' ') +
                                        " | " + ("$" + Formulario.ValidarCampoMoneda(Totales[1])).PadLeft(12, ' '));
                                ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                            }
                            #endregion
                            elemento = new CatalogoBase(
                                itemLibroDiario.Id,
                                ((idCuentaContable <= 0) ? ("").PadLeft(8, ' ') : Convert.ToString(itemLibroDiario.AsientoNro).PadRight(8, '0')) + //Muestra el Número de Asiento de manera consecutiva cuando se ha seleccionado una unica Cuenta Contable
                                    " | " + Fecha.ConvertirFecha(itemLibroDiario.AsientoFecha).PadLeft(10, '0') +
                                    " | " + itemLibroDiario.CuentaContable.Denominacion.PadRight(25, ' ') +
                                    " | " + itemLibroDiario.Descripcion.PadRight(35, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemLibroDiario.Debe).PadLeft(12, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemLibroDiario.Haber).PadLeft(12, ' '));
                            ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                        }
                        asientoNroAntecesor = itemLibroDiario.AsientoNro; //Deducción de Saldo Antecesor: Establece el Número de Asiento actual (Importante para completar el ciclo)
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002LIBRO_DIARIO: Hay un conflicto en la consulta del asiento contable.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public double[] contabilizarDebeHaber(string campo, long valor, DateTime desde, DateTime hasta)
        {
            double[] valorDebeHaber = new double[] { 0.00, 0.00 };
            string condicional = "";
            if (campo == "ID_CUENTA") condicional = (valor > 0) ? WHERE2 : WHERE1; //Consulta filtrada por Fecha de Asiento y/o Cuenta Contable
            if (campo == "NRO_ASIENTO") condicional = (valor > 0) ? WHERE3 : WHERE1; //Consulta filtrada por Fecha de Asiento y/o Número de Asiento
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_DEBE + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ID_CUENTA" && valor > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "NRO_ASIENTO" && valor > 0) comandoDB.Parameters.AddWithValue("@asiento_nro", valor); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        object resultado = comandoDB.ExecuteScalar();
                        if (resultado != DBNull.Value) valorDebeHaber[0] = (double)resultado; //Almacena la sumatoria del Debe
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_HABER + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ID_CUENTA" && valor > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "NRO_ASIENTO" && valor > 0) comandoDB.Parameters.AddWithValue("@asiento_nro", valor); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        object resultado = comandoDB.ExecuteScalar();
                        if (resultado != DBNull.Value) valorDebeHaber[1] = (double)resultado; //Almacena la sumatoria del Haber
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004LIBRO_DIARIO: Hay un conflicto en el cálculo del debe y haber del asiento contable.", e); }
            finally { _conexion.Dispose(); }
            return valorDebeHaber;
        }
        #endregion

        #region Métodos de Instanciación
        private LibroDiario instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new LibroDiario(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToInt64(lectorDB["asiento_nro"]),
                Convert.ToDateTime(lectorDB["asiento_fecha"]),
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable"]), false),
                Convert.ToString(lectorDB["descripcion"]),
                Convert.ToDouble(lectorDB["debe"]),
                Convert.ToDouble(lectorDB["haber"]),
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