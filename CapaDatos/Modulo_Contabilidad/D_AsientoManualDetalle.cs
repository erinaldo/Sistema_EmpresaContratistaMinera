using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_AsientoManualDetalle : IAsientoManualDetalle, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_asiento_manual_detalle.id, id_asiento_manual, id_cuenta_contable,
            data_cuenta_contable.denominacion AS cuenta_contable, debe, haber, conciliacion";
        private const string FROM = @" FROM data_asiento_manual_detalle 
            INNER JOIN data_asiento_manual ON data_asiento_manual_detalle.id_asiento_manual = data_asiento_manual.id
            INNER JOIN data_cuenta_contable ON data_asiento_manual_detalle.id_cuenta_contable = data_cuenta_contable.id";
        private const string WHERE1 = @" WHERE data_asiento_manual_detalle.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_asiento_manual_detalle.id_asiento_manual = @id_asiento_manual"; //Filtrar Objeto por ID Orden de cobro
        private const string ORDER = @" ORDER BY data_asiento_manual_detalle.id ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_asiento_manual_detalle WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_asiento_manual_detalle WHERE id = @id "; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_asiento_manual_detalle SET 
            id = @id,
            id_asiento_manual = @id_asiento_manual,
            id_cuenta_contable = @id_cuenta_contable,
            debe = @debe,
            haber = @haber,
            conciliacion = @conciliacion WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_asiento_manual_detalle(id, id_asiento_manual,
            id_cuenta_contable, debe, haber, conciliacion)
            VALUES (@id, @id_asiento_manual, @id_cuenta_contable, @debe, @haber, @conciliacion)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID del Detalle
            if (campo == "ID_ASIENTO") condicional = WHERE2; //Consulta filtrada por ID del Asiento Manual
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "ID_ASIENTO") comandoDB.Parameters.AddWithValue("@id_asiento_manual", valor); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_ASIENTO") comandoDB.Parameters.AddWithValue("@id_asiento_manual", valor); //Agrega un parámetro al comando de Base de Datos
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
                                        Convert.ToString(lectorDB["id"]).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["id_asiento_manual"]).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["cuenta_contable"]).PadRight(25, '0') +
                                            " | " + Convert.ToDouble(lectorDB["debe"]).ToString("00000000,00") +
                                            " | " + Convert.ToDouble(lectorDB["haber"]).ToString("00000000,00") +
                                            " | " + Convert.ToString(lectorDB["conciliacion"]).PadRight(11, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002ASIENTO_MANUAL_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<AsientoManualDetalle> obtenerObjetos(long idAsientoManual)
        {
            List<AsientoManualDetalle> ListaDeObjetos = new List<AsientoManualDetalle>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE2 + ORDER)) //Crea un comando de Base de Datos
                {
                    comandoDB.Parameters.AddWithValue("@id_asiento_manual", idAsientoManual); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                AsientoManualDetalle objAsientoManualDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objAsientoManualDetalle); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004ASIENTO_MANUAL_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<AsientoManualDetalle> obtenerObjetos(string campo, string valor)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID del Detalle
            if (campo == "ID_ASIENTO") condicional = WHERE2; //Consulta filtrada por ID del Asiento Manual
            List<AsientoManualDetalle> ListaDeObjetos = new List<AsientoManualDetalle>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_ASIENTO") comandoDB.Parameters.AddWithValue("@id_asiento_manual", valor); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                AsientoManualDetalle objAsientoManualDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objAsientoManualDetalle); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006ASIENTO_MANUAL_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public AsientoManualDetalle obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            AsientoManualDetalle objAsientoManualDetalle = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objAsientoManualDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Detalle solicitado No hallado.\nVerifique los datos del comprobante e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008ASIENTO_MANUAL_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return objAsientoManualDetalle;
        }

        public bool actualizar(AsientoManualDetalle objAsientoManualDetalle)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objAsientoManualDetalle.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objAsientoManualDetalle.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_asiento_manual", objAsientoManualDetalle.AsientoManual.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_cuenta_contable", objAsientoManualDetalle.CuentaContable.Id);
                                comandoDB_update.Parameters.AddWithValue("@debe", objAsientoManualDetalle.Debe);
                                comandoDB_update.Parameters.AddWithValue("@haber", objAsientoManualDetalle.Haber);
                                comandoDB_update.Parameters.AddWithValue("@conciliacion", objAsientoManualDetalle.Conciliacion);
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
                Mensaje.Advertencia("Detalle del comprobante Inexistente.\nEl detalle del comprobante No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M010ASIENTO_MANUAL_DETALLE", "M012ASIENTO_MANUAL_DETALLE", "M014ASIENTO_MANUAL_DETALLE", "M016ASIENTO_MANUAL_DETALLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(AsientoManualDetalle objAsientoManualDetalle)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objAsientoManualDetalle.Id); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objAsientoManualDetalle.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_asiento_manual", objAsientoManualDetalle.AsientoManual.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_cuenta_contable", objAsientoManualDetalle.CuentaContable.Id);
                                comandoDB_insert.Parameters.AddWithValue("@debe", objAsientoManualDetalle.Debe);
                                comandoDB_insert.Parameters.AddWithValue("@haber", objAsientoManualDetalle.Haber);
                                comandoDB_insert.Parameters.AddWithValue("@conciliacion", objAsientoManualDetalle.Conciliacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Detalle del comprobante Existente.\nEl detalle del comprobante ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M018ASIENTO_MANUAL_DETALLE", "M020ASIENTO_MANUAL_DETALLE", "M022ASIENTO_MANUAL_DETALLE", "M024ASIENTO_MANUAL_DETALLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private AsientoManualDetalle instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new AsientoManualDetalle(
                Convert.ToInt64(lectorDB["id"]),
                new D_AsientoManual().obtenerObjeto("ID", Convert.ToString(lectorDB["id_asiento_manual"]), false),
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable"]), false),
                Convert.ToDouble(lectorDB["debe"]),
                Convert.ToDouble(lectorDB["haber"]),
                Convert.ToString(lectorDB["conciliacion"]));
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
