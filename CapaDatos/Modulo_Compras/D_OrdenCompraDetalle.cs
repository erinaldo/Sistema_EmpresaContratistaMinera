using Biblioteca.Ayudantes;
using CapaDatos.Catalogo;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_OrdenCompraDetalle : IOrdenCompraDetalle, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_orden_compra_detalle.id, id_orden_compra, id_articulo, data_orden_compra_detalle.denominacion,
            cantidad, unidad, deposito, costo_unitario, alicuota_iva, base_iva, costo_neto, id_centro_costo";
        private const string FROM = @" FROM data_orden_compra_detalle 
            INNER JOIN data_orden_compra ON data_orden_compra_detalle.id_orden_compra = data_orden_compra.id";
        private const string WHERE1 = @" WHERE data_orden_compra_detalle.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_orden_compra_detalle.id_orden_compra = @id_orden_compra"; //Filtrar Objeto por ID Orden de compra
        private const string WHERE3 = @" WHERE data_orden_compra_detalle.id_articulo = @id_articulo"; //Filtrar Objeto por ID Artículo
        private const string WHERE4 = @" WHERE LOWER(data_orden_compra_detalle.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string ORDER = @" ORDER BY data_orden_compra_detalle.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_orden_compra_detalle WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_orden_compra_detalle WHERE id = @id "; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_orden_compra_detalle SET 
            id = @id,
            id_orden_compra = @id_orden_compra,
            id_articulo = @id_articulo,
            denominacion = @denominacion,
            cantidad = @cantidad,
            unidad = @unidad,
            deposito = @deposito,
            costo_unitario = @costo_unitario,
            alicuota_iva = @alicuota_iva,
            base_iva = @base_iva,
            costo_neto = @costo_neto,
            id_centro_costo = @id_centro_costo WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_orden_compra_detalle(id, id_orden_compra, id_articulo, denominacion,
            cantidad, unidad, deposito, costo_unitario, alicuota_iva, base_iva, costo_neto, id_centro_costo)
            VALUES (@id, @id_orden_compra, @id_articulo, @denominacion, @cantidad, @unidad, @deposito, @costo_unitario,
            @alicuota_iva, @base_iva, @costo_neto, @id_centro_costo)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "DENOMINACION") condicional = WHERE4; //Consulta filtrada por Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID del Detalle
            if (campo == "ID_ORDEN") condicional = WHERE2; //Consulta filtrada por ID de la Orden de OrdenCompra
            if (campo == "ID_ARTICULO") condicional = WHERE3; //Consulta filtrada por ID del Artículo
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "ID_ORDEN") comandoDB.Parameters.AddWithValue("@id_orden_compra", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "ID_ARTICULO") comandoDB.Parameters.AddWithValue("@id_articulo", valor); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_ORDEN") comandoDB.Parameters.AddWithValue("@id_orden_compra", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_ARTICULO") comandoDB.Parameters.AddWithValue("@id_articulo", valor); //Agrega un parámetro al comando de Base de Datos
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
                                            " | " + Convert.ToString(lectorDB["id_orden_compra"]).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["id_articulo"]).PadLeft(6, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToString(lectorDB["unidad"]).PadRight(3, ' ') +
                                            " | " + Convert.ToString(lectorDB["cantidad"]).PadLeft(6, ' ') +
                                            " | " + Convert.ToDouble(lectorDB["costo_unitario"]).ToString("0000000,00") +
                                            " | " + Convert.ToDouble(lectorDB["alicuota_iva"]).ToString("00.00") +
                                            " | " + Convert.ToDouble(lectorDB["base_iva"]).ToString("0000000,00") +
                                            " | " + Convert.ToDouble(lectorDB["costo_neto"]).ToString("0000000,00"));
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
            catch (MySqlException e) { Mensaje.Error("Error-M002ORDEN_CPR_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<OrdenCompraDetalle> obtenerObjetos(long idOrdenCompra)
        {
            List<OrdenCompraDetalle> ListaDeObjetos = new List<OrdenCompraDetalle>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE2 + ORDER)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_orden_compra", idOrdenCompra); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                OrdenCompraDetalle objOrdenCompraDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objOrdenCompraDetalle); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004ORDEN_CPR_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<OrdenCompraDetalle> obtenerObjetos(string campo, string valor)
        {
            string condicional = "";
            if (campo == "DENOMINACION") condicional = WHERE4; //Consulta filtrada por Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID del Detalle
            if (campo == "ID_ORDEN") condicional = WHERE2; //Consulta filtrada por ID de la Orden de OrdenCompra
            if (campo == "ID_ARTICULO") condicional = WHERE3; //Consulta filtrada por ID del Artículo
            List<OrdenCompraDetalle> ListaDeObjetos = new List<OrdenCompraDetalle>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_ORDEN") comandoDB.Parameters.AddWithValue("@id_orden_compra", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_ARTICULO") comandoDB.Parameters.AddWithValue("@id_articulo", valor); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                OrdenCompraDetalle objOrdenCompraDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objOrdenCompraDetalle); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006ORDEN_CPR_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public OrdenCompraDetalle obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            OrdenCompraDetalle objOrdenCompraDetalle = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objOrdenCompraDetalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
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
            catch (MySqlException e) { Mensaje.Error("Error-M008ORDEN_CPR_DETALLE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return objOrdenCompraDetalle;
        }

        public bool actualizar(List<OrdenCompraDetalle> listaDeOrdenCompraDetalle)
        {
            try
            {
                foreach (OrdenCompraDetalle objOrdenCompraDetalle in listaDeOrdenCompraDetalle)
                {
                    if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                    {
                        using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                        {
                            comandoDB.Parameters.AddWithValue("@id", objOrdenCompraDetalle.Id); //Agrega parámetros al comando de Base de Datos
                            if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                            {
                                using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                                {
                                    comandoDB_update.Parameters.AddWithValue("@id", objOrdenCompraDetalle.Id);
                                    comandoDB_update.Parameters.AddWithValue("@id_orden_compra", objOrdenCompraDetalle.OrdenCompra.Id);
                                    comandoDB_update.Parameters.AddWithValue("@id_articulo", objOrdenCompraDetalle.IdArticulo);
                                    comandoDB_update.Parameters.AddWithValue("@denominacion", objOrdenCompraDetalle.Denominacion);
                                    comandoDB_update.Parameters.AddWithValue("@cantidad", objOrdenCompraDetalle.Cantidad);
                                    comandoDB_update.Parameters.AddWithValue("@unidad", objOrdenCompraDetalle.Unidad);
                                    comandoDB_update.Parameters.AddWithValue("@deposito", objOrdenCompraDetalle.Deposito);
                                    comandoDB_update.Parameters.AddWithValue("@costo_unitario", objOrdenCompraDetalle.CostoUnitario);
                                    comandoDB_update.Parameters.AddWithValue("@alicuota_iva", objOrdenCompraDetalle.AlicuotaIVA);
                                    comandoDB_update.Parameters.AddWithValue("@base_iva", objOrdenCompraDetalle.BaseIVA);
                                    comandoDB_update.Parameters.AddWithValue("@costo_neto", objOrdenCompraDetalle.CostoNeto);
                                    comandoDB_update.Parameters.AddWithValue("@id_centro_costo", objOrdenCompraDetalle.CentroCosto.Id);
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
            catch (MySqlException e) { Mensaje.ErrorMySql("M010ORDEN_CPR_DETALLE", "M012ORDEN_CPR_DETALLE", "M014ORDEN_CPR_DETALLE", "M016ORDEN_CPR_DETALLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(List<OrdenCompraDetalle> listaDeOrdenCompraDetalle)
        {
            try
            {
                foreach (OrdenCompraDetalle objOrdenCompraDetalle in listaDeOrdenCompraDetalle)
                {
                    if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                    {
                        using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                        {
                            comandoDB.Parameters.AddWithValue("@id", objOrdenCompraDetalle.Id); //Agrega parámetros al comando de Base de Datos

                            if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                            {
                                using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                                {
                                    comandoDB_insert.Parameters.AddWithValue("@id", objOrdenCompraDetalle.Id);
                                    comandoDB_insert.Parameters.AddWithValue("@id_orden_compra", objOrdenCompraDetalle.OrdenCompra.Id);
                                    comandoDB_insert.Parameters.AddWithValue("@id_articulo", objOrdenCompraDetalle.IdArticulo);
                                    comandoDB_insert.Parameters.AddWithValue("@denominacion", objOrdenCompraDetalle.Denominacion);
                                    comandoDB_insert.Parameters.AddWithValue("@cantidad", objOrdenCompraDetalle.Cantidad);
                                    comandoDB_insert.Parameters.AddWithValue("@unidad", objOrdenCompraDetalle.Unidad);
                                    comandoDB_insert.Parameters.AddWithValue("@deposito", objOrdenCompraDetalle.Deposito);
                                    comandoDB_insert.Parameters.AddWithValue("@costo_unitario", objOrdenCompraDetalle.CostoUnitario);
                                    comandoDB_insert.Parameters.AddWithValue("@alicuota_iva", objOrdenCompraDetalle.AlicuotaIVA);
                                    comandoDB_insert.Parameters.AddWithValue("@base_iva", objOrdenCompraDetalle.BaseIVA);
                                    comandoDB_insert.Parameters.AddWithValue("@costo_neto", objOrdenCompraDetalle.CostoNeto);
                                    comandoDB_insert.Parameters.AddWithValue("@id_centro_costo", objOrdenCompraDetalle.CentroCosto.Id);
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
            catch (MySqlException e) { Mensaje.ErrorMySql("M018ORDEN_CPR_DETALLE", "M020ORDEN_CPR_DETALLE", "M022ORDEN_CPR_DETALLE", "M024ORDEN_CPR_DETALLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private OrdenCompraDetalle instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new OrdenCompraDetalle(
                Convert.ToInt64(lectorDB["id"]),
                new D_OrdenCompra().obtenerObjeto("ID", Convert.ToString(lectorDB["id_orden_compra"]), false),
                Convert.ToInt64(lectorDB["id_articulo"]),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToInt32(lectorDB["cantidad"]),
                Convert.ToString(lectorDB["unidad"]),
                Convert.ToString(lectorDB["deposito"]),
                Convert.ToDouble(lectorDB["costo_unitario"]),
                Convert.ToString(lectorDB["alicuota_iva"]),
                Convert.ToDouble(lectorDB["base_iva"]),
                Convert.ToDouble(lectorDB["costo_neto"]),
                new D_CentroCosto().obtenerObjeto("ID", Convert.ToString(lectorDB["id_centro_costo"]), false));
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