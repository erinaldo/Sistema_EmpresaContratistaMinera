using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_CobranzaDetalle : ICobranzaDetalle, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_cobranza_detalle.id, id_cobranza, id_venta,
            data_venta.afip_cbte_tipo, afip_cbte_tpv, afip_cbte_nro, afip_cbte_fecha, data_venta.subtotal, 
            data_venta.iva105, data_venta.iva210, data_venta.iva270, data_venta.total";
        private const string FROM = @" FROM data_cobranza_detalle 
            INNER JOIN data_cobranza ON data_cobranza_detalle.id_cobranza = data_cobranza.id
            INNER JOIN data_venta ON data_cobranza_detalle.id_venta = data_venta.id";
        private const string WHERE1 = @" WHERE data_cobranza_detalle.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_cobranza_detalle.id_cobranza = @id_cobranza"; //Filtrar Objeto por ID Orden de cobro
        private const string WHERE3 = @" WHERE data_cobranza_detalle.id_venta = @id_venta"; //Filtrar Objeto por ID Venta
        private const string ORDER = @" ORDER BY data_cobranza_detalle.id_venta ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_cobranza_detalle WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_cobranza_detalle WHERE id = @id "; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_cobranza_detalle SET 
            id = @id,
            id_cobranza = @id_cobranza,
            id_venta = @id_venta WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_cobranza_detalle(id, id_cobranza, id_venta)
            VALUES (@id, @id_cobranza, @id_venta)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID del Detalle
            if (campo == "ID_COBRANZA") condicional = WHERE2; //Consulta filtrada por ID de la Cobranza
            if (campo == "ID_VENTA") condicional = WHERE3; //Consulta filtrada por ID de la Venta
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "ID_COBRANZA") comandoDB.Parameters.AddWithValue("@id_cobranza", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "ID_VENTA") comandoDB.Parameters.AddWithValue("@id_venta", valor); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_COBRANZA") comandoDB.Parameters.AddWithValue("@id_cobranza", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_VENTA") comandoDB.Parameters.AddWithValue("@id_venta", valor); //Agrega un parámetro al comando de Base de Datos
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
                                            " | " + Convert.ToString(lectorDB["id_cobranza"]).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["id_venta"]).PadLeft(8, '0') +
                                            " | " + Convert.ToString(lectorDB["afip_cbte_tipo"]).PadRight(5, ' ') + " " + Convert.ToString(lectorDB["afip_cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["afip_cbte_tpv"]).PadLeft(8, '0') +
                                            " | " + Convert.ToString(lectorDB["afip_cbte_fecha"]).PadLeft(10, '0') +
                                            " | " + Convert.ToDouble(lectorDB["subtotal"]).ToString("00000000,00") +
                                            " | " + Convert.ToDouble(lectorDB["iva105"]).ToString("00000000,00") +
                                            " | " + Convert.ToDouble(lectorDB["iva210"]).ToString("00000000,00") +
                                            " | " + Convert.ToDouble(lectorDB["iva270"]).ToString("00000000,00") +
                                            " | " + Convert.ToDouble(lectorDB["total"]).ToString("00000000,00"));
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
            catch (MySqlException e) { Mensaje.Error("Error-M002COBRO_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CobranzaDetalle> obtenerObjetos(long idCobranza)
        {
            List<CobranzaDetalle> ListaDeObjetos = new List<CobranzaDetalle>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE2 + ORDER)) //Crea un comando de Base de Datos
                {
                    comandoDB.Parameters.AddWithValue("@id_cobranza", idCobranza); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                CobranzaDetalle objCobranzaDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objCobranzaDetalle); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004COBRO_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<CobranzaDetalle> obtenerObjetos(string campo, string valor)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID del Detalle
            if (campo == "ID_COBRANZA") condicional = WHERE2; //Consulta filtrada por ID de la Cobranza
            if (campo == "ID_VENTA") condicional = WHERE3; //Consulta filtrada por ID de la Venta
            List<CobranzaDetalle> ListaDeObjetos = new List<CobranzaDetalle>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_COBRANZA") comandoDB.Parameters.AddWithValue("@id_cobranza", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_VENTA") comandoDB.Parameters.AddWithValue("@id_venta", valor); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                CobranzaDetalle objCobranzaDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objCobranzaDetalle); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006COBRO_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public CobranzaDetalle obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            CobranzaDetalle objCobranzaDetalle = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objCobranzaDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
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
            catch (MySqlException e) { Mensaje.Error("Error-M008COBRO_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return objCobranzaDetalle;
        }

        public bool actualizar(List<CobranzaDetalle> listaDeCobranzaDetalle)
        {
            try
            {
                foreach (CobranzaDetalle objCobranzaDetalle in listaDeCobranzaDetalle)
                {
                    if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                    {
                        using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                        {
                            comandoDB.Parameters.AddWithValue("@id", objCobranzaDetalle.Id); //Agrega parámetros al comando de Base de Datos
                            if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                            {
                                using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                                {
                                    comandoDB_update.Parameters.AddWithValue("@id", objCobranzaDetalle.Id);
                                    comandoDB_update.Parameters.AddWithValue("@id_cobranza", objCobranzaDetalle.Cobranza.Id);
                                    comandoDB_update.Parameters.AddWithValue("@id_venta", objCobranzaDetalle.Venta.Id);
                                    comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
                return true;
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Detalle del comprobante Inexistente.\nEl detalle del comprobante No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M010COBRO_DETALLE", "M012COBRO_DETALLE", "M014COBRO_DETALLE", "M016COBRO_DETALLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(List<CobranzaDetalle> listaDeCobranzaDetalle)
        {
            try
            {
                foreach (CobranzaDetalle objCobranzaDetalle in listaDeCobranzaDetalle)
                {
                    if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                    {
                        using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                        {
                            comandoDB.Parameters.AddWithValue("@id", objCobranzaDetalle.Id); //Agrega parámetros al comando de Base de Datos

                            if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                            {
                                using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                                {
                                    comandoDB_insert.Parameters.AddWithValue("@id", objCobranzaDetalle.Id);
                                    comandoDB_insert.Parameters.AddWithValue("@id_cobranza", objCobranzaDetalle.Cobranza.Id);
                                    comandoDB_insert.Parameters.AddWithValue("@id_venta", objCobranzaDetalle.Venta.Id);
                                    comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
                return true;
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Detalle del comprobante Existente.\nEl detalle del comprobante ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M018COBRO_DETALLE", "M020COBRO_DETALLE", "M022COBRO_DETALLE", "M024COBRO_DETALLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private CobranzaDetalle instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new CobranzaDetalle(
                Convert.ToInt64(lectorDB["id"]),
                new D_Cobranza().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cobranza"]), false),
                new D_Venta().obtenerObjeto("ID", Convert.ToString(lectorDB["id_venta"]), false, "TODOS"));
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
