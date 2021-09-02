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
    public class D_Conciliacion : IConciliacion, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_asiento_contable.id, asiento_nro, asiento_fecha,
            id_cuenta_contable, descripcion, debe, haber, conciliacion, origen_tipo, origen_id";
        private const string FROM = @" FROM data_asiento_contable 
             LEFT JOIN data_cuenta_contable ON data_asiento_contable.id_cuenta_contable = data_cuenta_contable.id AND conciliacion <> 'NO-APLICA'";
        private const string WHERE1 = @" WHERE data_asiento_contable.id = @id"; //TODOS
        private const string WHERE2 = @" WHERE conciliacion <> 'NO-APLICA'"; //TODOS
        private const string WHERE3 = @" WHERE conciliacion <> 'NO-APLICA' AND id_cuenta_contable = @id_cuenta_contable"; //TODOS LOS ESTADO DE UNA CUENTA CONTABLE
        private const string WHERE4 = @" WHERE conciliacion = @conciliacion"; //ESTADO DE CONCILIACION
        private const string WHERE5 = @" WHERE conciliacion = @conciliacion AND id_cuenta_contable = @id_cuenta_contable"; //ESTADO DE CONCILIACION DE UNA CUENTA CONTABLE
        private const string SUM_DEBE = @"SELECT SUM(data_asiento_contable.debe)"; //Obtiene la sumatoria de la columna Debe
        private const string SUM_HABER = @"SELECT SUM(data_asiento_contable.haber)"; //Obtiene la sumatoria de la columna Haber
        private const string ORDER = @" ORDER BY data_cuenta_contable.denominacion ASC, data_asiento_contable.asiento_fecha ASC, data_asiento_contable.asiento_nro ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_CONCILIACION = @"SELECT * FROM data_asiento_contable WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string CONCILIAR = @"UPDATE data_asiento_contable SET conciliacion = 'CONCILIADO' WHERE id = @id";
        private const string DESCONCILIAR = @"UPDATE data_asiento_contable SET conciliacion = 'S/CONCILIAR' WHERE id = @id";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estadoConciliacion, long idCuentaContable, string catalogo, int indicePagina, int tamanioPagina)
        {
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            string condicional = (estadoConciliacion != "TODOS") ? ((idCuentaContable > 0) ? WHERE5 : WHERE4) : ((idCuentaContable > 0) ? WHERE3 : WHERE2); //Consulta filtrada por Estado de conciliacion y/o Cuenta Contable
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            string cuentaContableAntecesor = "";
            List<Conciliacion> ListaDeObjetos = new List<Conciliacion>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (estadoConciliacion != "TODOS") comandoDB.Parameters.AddWithValue("@conciliacion", estadoConciliacion); //Agrega el parámetro en la condición del contador
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (estadoConciliacion != "TODOS") comandoDB.Parameters.AddWithValue("@conciliacion", estadoConciliacion); //Agrega el parámetro en la condición de la consulta
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Conciliacion objConciliacion = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objConciliacion); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                    foreach (Conciliacion itemConciliacion in ListaDeObjetos)
                    {
                        if (catalogo == "CATALOGO1")
                        {
                            CatalogoBase elemento = new CatalogoBase(
                                 itemConciliacion.Id,
                                 itemConciliacion.CuentaContable.Denominacion.PadRight(25, ' ') + //Establecí el valor del ancho de esta columna en 26 para rellenar el ListBox
                                    " | " + Fecha.ConvertirFecha(itemConciliacion.AsientoFecha).PadLeft(10, '0') +
                                    " | " + itemConciliacion.Descripcion.PadRight(35, ' ') + 
                                    " | " + Formulario.ValidarCampoMoneda(itemConciliacion.Debe).PadLeft(11, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(itemConciliacion.Haber).PadLeft(11, ' ') +
                                    " | " + itemConciliacion.Conciliacion.PadRight(11, ' '));
                            ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                        }
                        else if (catalogo == "CATALOGO2")
                        {
                            CatalogoBase elemento;
                            #region Fila Tipo SubTitulo
                            if (cuentaContableAntecesor != itemConciliacion.CuentaContable.Denominacion)
                            {
                                elemento = new CatalogoBase(
                                    -1, //ID nulo
                                    itemConciliacion.CuentaContable.Denominacion.PadRight(26, ' ') + //Asigné el valor en 85 para cubrir el ancho del ListBox 
                                        " | " + ("").PadLeft(10, ' ') +
                                        " | " + ("").PadLeft(25, ' ') +
                                        " | " + ("").PadLeft(11, ' ') +
                                        " | " + ("").PadLeft(11, ' ') +
                                        " | " + ("").PadLeft(11, ' '));
                                ListaDeElementos.Add(elemento); //Agrega el subTitulo a la lista de elementos
                            }
                            #endregion
                            elemento = new CatalogoBase(
                                 itemConciliacion.Id,
                                 ("").PadRight(26, ' ') + //Dato omitido por ser repetitivo
                                    " | " + Fecha.ConvertirFecha(itemConciliacion.AsientoFecha).PadLeft(10, '0') +
                                    " | " + itemConciliacion.Descripcion.PadRight(35, ' ') +
                                    " | " + ("$" + Formulario.ValidarCampoMoneda(itemConciliacion.Debe)).PadLeft(11, ' ') +
                                    " | " + ("$" + Formulario.ValidarCampoMoneda(itemConciliacion.Haber)).PadLeft(11, ' ') +
                                    " | " + itemConciliacion.Conciliacion.PadRight(11, ' '));
                                 ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                        }
                        cuentaContableAntecesor = itemConciliacion.CuentaContable.Denominacion; //Deducción de Cuenta Contable Antecesor - Establece la Cuenta Contable actual (Importante para completar el ciclo)
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002CONCILIACION: Hay un conflicto en la consulta de las cuentas contables", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public Conciliacion obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            Conciliacion objConciliacion = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objConciliacion = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos del asiento e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004CONCILIACION: Hay un conflicto en la consulta de los asientos", e); }
            finally { _conexion.Dispose(); }
            return objConciliacion;
        }

        public bool conciliar(List<Conciliacion> lista, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    foreach (Conciliacion objConciliacion in lista)
                    {
                        using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_CONCILIACION)) //Crea un comando de Base de Datos
                        {
                            comandoDB.Parameters.AddWithValue("@id", objConciliacion.Id); //Agrega parámetros al comando de Base de Datos
                            if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                            {
                                if (objConciliacion.Conciliacion == "S/CONCILIAR")
                                {
                                    //Crea un comando de Base de Datos
                                    using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(CONCILIAR))
                                    {
                                        comandoDB_update.Parameters.AddWithValue("@id", objConciliacion.Id);
                                        comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                        D_Auditoria.RegistrarAuditoria("Conciliación de Cuentas", "Concilió el asiento N°" + Convert.ToString(objConciliacion.AsientoNro).PadLeft(8, '0') + " (" + objConciliacion.Descripcion + ")."); //Registra la actualización de un registro
                                    }
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                    if (notificarExito) Mensaje.Informacion("Los asientos seleccionados se han conciliado correctamente.");
                    return true;
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro Inaccesible.\nEl asiento contable No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M006CONCILIACION", "M008CONCILIACION", "M010CONCILIACION", "M012CONCILIACION", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool desconciliar(List<Conciliacion> lista, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    foreach (Conciliacion objConciliacion in lista)
                    {
                        using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_CONCILIACION)) //Crea un comando de Base de Datos
                        {
                            comandoDB.Parameters.AddWithValue("@id", objConciliacion.Id); //Agrega parámetros al comando de Base de Datos
                            if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                            {
                                if (objConciliacion.Conciliacion == "CONCILIADO")
                                {
                                    //Crea un comando de Base de Datos
                                    using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(DESCONCILIAR))
                                    {
                                        comandoDB_update.Parameters.AddWithValue("@id", objConciliacion.Id);
                                        comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                        D_Auditoria.RegistrarAuditoria("Conciliación de Cuentas", "Desconcilió el asiento N°" + Convert.ToString(objConciliacion.AsientoNro).PadLeft(8, '0') + " (" + objConciliacion.Descripcion + ")."); //Registra la actualización de un registro
                                    }
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                    if (notificarExito) Mensaje.Informacion("Los asientos seleccionados se han conciliado correctamente.");
                    return true;
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro Inaccesible.\nEl asiento contable No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M006CONCILIACION", "M008CONCILIACION", "M010CONCILIACION", "M012CONCILIACION", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public double[] contabilizarDebeHaber(long idCuentaContable)
        {
            double[] valorDebeHaber = new double[] { 0.00, 0.00, 0.00, 0.00, 0.00, 0.00 };
            string condicionalTotalContable = (idCuentaContable > 0) ? WHERE3 : WHERE2; //Consulta filtrada por Estado de conciliacion y/o Cuenta Contable
            string condicionalTotalConciliacion = (idCuentaContable > 0) ? WHERE5 : WHERE4; //Consulta filtrada por Estado de conciliacion y/o Cuenta Contable
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_DEBE + FROM + condicionalTotalContable)) //Crea un comando de Base de Datos (Total Contable - Debe)
                    {
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición del contador
                        object resultado = comandoDB.ExecuteScalar();
                        if (resultado != DBNull.Value) valorDebeHaber[0] = (double)resultado; //Almacena la sumatoria del Debe
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_HABER + FROM + condicionalTotalContable)) //Crea un comando de Base de Datos (Total Contable - Haber)
                    {
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición del contador
                        object resultado = comandoDB.ExecuteScalar();
                        if (resultado != DBNull.Value) valorDebeHaber[1] = (double)resultado; //Almacena la sumatoria del Haber
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_DEBE + FROM + condicionalTotalConciliacion)) //Crea un comando de Base de Datos (Total Conciliado - Debe)
                    {
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@conciliacion", "S/CONCILIAR"); //Agrega el parámetro en la condición de la consulta
                        object resultado = comandoDB.ExecuteScalar();
                        if (resultado != DBNull.Value) valorDebeHaber[2] = (double)resultado; //Almacena la sumatoria del Debe
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_HABER + FROM + condicionalTotalConciliacion)) //Crea un comando de Base de Datos (Total Conciliado - Haber)
                    {
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@conciliacion", "S/CONCILIAR"); //Agrega el parámetro en la condición de la consulta
                        object resultado = comandoDB.ExecuteScalar();
                        if (resultado != DBNull.Value) valorDebeHaber[3] = (double)resultado; //Almacena la sumatoria del Haber
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_DEBE + FROM + condicionalTotalConciliacion)) //Crea un comando de Base de Datos (Total Saldo Real)
                    {
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@conciliacion", "CONCILIADO"); //Agrega el parámetro en la condición de la consulta
                        object resultado = comandoDB.ExecuteScalar();
                        if (resultado != DBNull.Value) valorDebeHaber[4] = (double)resultado; //Almacena la sumatoria del Debe
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SUM_HABER + FROM + condicionalTotalConciliacion)) //Crea un comando de Base de Datos (Total Saldo Real)
                    {
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@conciliacion", "CONCILIADO"); //Agrega el parámetro en la condición de la consulta
                        object resultado = comandoDB.ExecuteScalar();
                        if (resultado != DBNull.Value) valorDebeHaber[5] = (double)resultado; //Almacena la sumatoria del Haber
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M014CONCILIACION: Hay un conflicto en el cálculo del debe y haber de los asientos.", e); }
            finally { _conexion.Dispose(); }
            return valorDebeHaber;
        }
        #endregion

        #region Métodos de Instanciación
        private Conciliacion instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Conciliacion(
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