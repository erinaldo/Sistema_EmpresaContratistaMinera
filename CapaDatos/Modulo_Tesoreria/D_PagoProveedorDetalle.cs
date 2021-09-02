using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_PagoProveedorDetalle : IPagoProveedorDetalle, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_pago_proveedor_detalle.id, id_pago_proveedor, id_compra,
            data_compra.afip_cbte_tipo, afip_cbte_tpv, afip_cbte_nro, afip_cbte_fecha, data_compra.subtotal, 
            data_compra.iva105, data_compra.iva210, data_compra.iva270, data_compra.total";
        private const string FROM = @" FROM data_pago_proveedor_detalle 
            INNER JOIN data_pago_proveedor ON data_pago_proveedor_detalle.id_pago_proveedor = data_pago_proveedor.id
            INNER JOIN data_compra ON data_pago_proveedor_detalle.id_compra = data_compra.id";
        private const string WHERE1 = @" WHERE data_pago_proveedor_detalle.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_pago_proveedor_detalle.id_pago_proveedor = @id_pago_proveedor"; //Filtrar Objeto por ID Orden de cobro
        private const string WHERE3 = @" WHERE data_pago_proveedor_detalle.id_compra = @id_compra"; //Filtrar Objeto por ID Compra
        private const string ORDER = @" ORDER BY data_pago_proveedor_detalle.id_compra ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_pago_proveedor_detalle WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_pago_proveedor_detalle WHERE id = @id "; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_pago_proveedor_detalle SET 
            id = @id,
            id_pago_proveedor = @id_pago_proveedor,
            id_compra = @id_compra WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_pago_proveedor_detalle(id, id_pago_proveedor,
            id_compra)
            VALUES (@id, @id_pago_proveedor, @id_compra)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID del Detalle
            if (campo == "ID_PAGO") condicional = WHERE2; //Consulta filtrada por ID del Pago a Proveedor
            if (campo == "ID_COMPRA") condicional = WHERE3; //Consulta filtrada por ID de la Compra
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "ID_PAGO") comandoDB.Parameters.AddWithValue("@id_pago_proveedor", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "ID_COMPRA") comandoDB.Parameters.AddWithValue("@id_compra", valor); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_PAGO") comandoDB.Parameters.AddWithValue("@id_pago_proveedor", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_COMPRA") comandoDB.Parameters.AddWithValue("@id_compra", valor); //Agrega un parámetro al comando de Base de Datos
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
                                            " | " + Convert.ToString(lectorDB["id_pago_proveedor"]).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["id_compra"]).PadLeft(8, '0') +
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
            catch (MySqlException e) { Mensaje.Error("Error-M002PAGO_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<PagoProveedorDetalle> obtenerObjetos(long idPagoProveedor)
        {
            List<PagoProveedorDetalle> ListaDeObjetos = new List<PagoProveedorDetalle>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE2 + ORDER)) //Crea un comando de Base de Datos
                {
                    comandoDB.Parameters.AddWithValue("@id_pago_proveedor", idPagoProveedor); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                PagoProveedorDetalle objPagoProveedorDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objPagoProveedorDetalle); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004PAGO_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<PagoProveedorDetalle> obtenerObjetos(string campo, string valor)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID del Detalle
            if (campo == "ID_PAGO") condicional = WHERE2; //Consulta filtrada por ID del Pago a Proveedor
            if (campo == "ID_COMPRA") condicional = WHERE3; //Consulta filtrada por ID de la Compra
            List<PagoProveedorDetalle> ListaDeObjetos = new List<PagoProveedorDetalle>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_PAGO") comandoDB.Parameters.AddWithValue("@id_pago_proveedor", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_COMPRA") comandoDB.Parameters.AddWithValue("@id_compra", valor); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                PagoProveedorDetalle objPagoProveedorDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objPagoProveedorDetalle); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006PAGO_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public PagoProveedorDetalle obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            PagoProveedorDetalle objPagoProveedorDetalle = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objPagoProveedorDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
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
            catch (MySqlException e) { Mensaje.Error("Error-M008PAGO_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return objPagoProveedorDetalle;
        }

        public bool actualizar(List<PagoProveedorDetalle> listaDePagoProveedorDetalle)
        {
            try
            {
                foreach (PagoProveedorDetalle objPagoProveedorDetalle in listaDePagoProveedorDetalle)
                {
                    if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                    {
                        using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                        {
                            comandoDB.Parameters.AddWithValue("@id", objPagoProveedorDetalle.Id); //Agrega parámetros al comando de Base de Datos
                            if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                            {
                                using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                                {
                                    comandoDB_update.Parameters.AddWithValue("@id", objPagoProveedorDetalle.Id);
                                    comandoDB_update.Parameters.AddWithValue("@id_pago_proveedor", objPagoProveedorDetalle.PagoProveedor.Id);
                                    comandoDB_update.Parameters.AddWithValue("@id_compra", objPagoProveedorDetalle.Compra.Id);
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
            catch (MySqlException e) { Mensaje.ErrorMySql("M010PAGO_DETALLE", "M012PAGO_DETALLE", "M014PAGO_DETALLE", "M016PAGO_DETALLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(List<PagoProveedorDetalle> listaDePagoProveedorDetalle)
        {
            try
            {
                foreach (PagoProveedorDetalle objPagoProveedorDetalle in listaDePagoProveedorDetalle)
                {
                    if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                    {
                        using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                        {
                            comandoDB.Parameters.AddWithValue("@id", objPagoProveedorDetalle.Id); //Agrega parámetros al comando de Base de Datos

                            if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                            {
                                using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                                {
                                    comandoDB_insert.Parameters.AddWithValue("@id", objPagoProveedorDetalle.Id);
                                    comandoDB_insert.Parameters.AddWithValue("@id_pago_proveedor", objPagoProveedorDetalle.PagoProveedor.Id);
                                    comandoDB_insert.Parameters.AddWithValue("@id_compra", objPagoProveedorDetalle.Compra.Id);
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
            catch (MySqlException e) { Mensaje.ErrorMySql("M018PAGO_DETALLE", "M020PAGO_DETALLE", "M022PAGO_DETALLE", "M024PAGO_DETALLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private PagoProveedorDetalle instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new PagoProveedorDetalle(
                Convert.ToInt64(lectorDB["id"]),
                new D_PagoProveedor().obtenerObjeto("ID", Convert.ToString(lectorDB["id_pago_proveedor"]), false),
                new D_Compra().obtenerObjeto("ID", Convert.ToString(lectorDB["id_compra"]), false, "TODOS"));
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
