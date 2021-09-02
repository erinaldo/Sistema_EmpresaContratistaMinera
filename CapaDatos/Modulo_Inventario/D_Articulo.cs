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
    public class D_Articulo : IArticulo, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT1 = @"SELECT data_articulo.*";
        private const string FROM = @" FROM data_articulo";
        private const string WHERE1 = @" WHERE data_articulo.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_articulo.id = @id AND data_articulo.estado = @estado"; //Filtrar Objeto por Estado y ID
        private const string WHERE3 = @" WHERE codigo_barras = @codigo_barras"; //Filtrar Objeto por Código de Barras
        private const string WHERE4 = @" WHERE codigo_barras = @codigo_barras AND data_articulo.estado = @estado"; //Filtrar Objeto por Estado y Código de Barras
        private const string WHERE5 = @" WHERE LOWER(data_articulo.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE6 = @" WHERE LOWER(data_articulo.denominacion) LIKE LOWER(@denominacion) AND data_articulo.estado = @estado"; //Filtrar Objeto por Estado y Denominación 
        private const string WHERE7 = @" WHERE data_articulo.estado = 'ACTIVO' AND a1_stock <> 0"; //Filtrar Objeto por artículo existente y activo en el depósito de Empreminsa
        private const string WHERE8 = @" WHERE data_articulo.estado = 'ACTIVO' AND a2_stock <> 0"; //Filtrar Objeto por artículo existente y activo en el depósito de Veladero
        private const string ORDER = @" ORDER BY data_articulo.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_articulo WHERE (denominacion = @denominacion OR (codigo_barras = @codigo_barras AND LENGTH(codigo_barras) > 0)) AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ELIMINAR = @"SELECT * FROM data_articulo WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_articulo WHERE denominacion = @denominacion OR (codigo_barras = @codigo_barras AND LENGTH(codigo_barras) > 0)"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_articulo SET 
            id = @id,
            denominacion = @denominacion,
            codigo_barras = @codigo_barras,
            criticidad = @criticidad,
            unidad = @unidad,
            stock_global = @stock_global,
            a1_pto_critico = @a1_pto_critico,
            a1_pto_critico_limite = @a1_pto_critico_limite,
            a1_pto_critico_alertado = @a1_pto_critico_alertado,
            a1_pto_minimo = @a1_pto_minimo,
            a1_pto_minimo_limite = @a1_pto_minimo_limite,
            a1_pto_minimo_alertado = @a1_pto_minimo_alertado,
            a1_pto_maximo_limite = @a1_pto_maximo_limite,
            a1_ingreso = @a1_ingreso,
            a1_stock = @a1_stock,
            a2_pto_critico = @a2_pto_critico,
            a2_pto_critico_limite = @a2_pto_critico_limite,
            a2_pto_critico_alertado = @a2_pto_critico_alertado,
            a2_pto_minimo = @a2_pto_minimo,
            a2_pto_minimo_limite = @a2_pto_minimo_limite,
            a2_pto_minimo_alertado = @a2_pto_minimo_alertado,
            a2_pto_maximo_limite = @a2_pto_maximo_limite,
            a2_ingreso = @a2_ingreso,
            a2_stock = @a2_stock,
            costo_bruto = @costo_bruto,
            iva_alicuota = @iva_alicuota,
            iva_base = @iva_base,
            costo_neto = @costo_neto,
            utilidad = @utilidad,
            margen_bruto = @margen_bruto,
            precio_bruto = @precio_bruto,
            estado = @estado,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ELIMINAR = @"DELETE FROM data_articulo WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_articulo(id, denominacion, codigo_barras, criticidad,
            unidad, stock_global, a1_pto_critico, a1_pto_critico_limite, a1_pto_critico_alertado, a1_pto_minimo,
            a1_pto_minimo_limite, a1_pto_minimo_alertado, a1_pto_maximo_limite, a1_ingreso, a1_stock, a2_pto_critico,
            a2_pto_critico_limite, a2_pto_critico_alertado, a2_pto_minimo, a2_pto_minimo_limite, a2_pto_minimo_alertado,
            a2_pto_maximo_limite, a2_ingreso, a2_stock, costo_bruto, iva_alicuota, iva_base, costo_neto, utilidad,
            margen_bruto, precio_bruto, estado, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @denominacion, @codigo_barras, @criticidad, @unidad, @stock_global, @a1_pto_critico, 
            @a1_pto_critico_limite, @a1_pto_critico_alertado, @a1_pto_minimo, @a1_pto_minimo_limite, @a1_pto_minimo_alertado,
            @a1_pto_maximo_limite, @a1_ingreso, @a1_stock, @a2_pto_critico, @a2_pto_critico_limite, @a2_pto_critico_alertado,
            @a2_pto_minimo, @a2_pto_minimo_limite, @a2_pto_minimo_alertado, @a2_pto_maximo_limite, @a2_ingreso,
            @a2_stock, @costo_bruto, @iva_alicuota, @iva_base, @costo_neto, @utilidad, @margen_bruto, @precio_bruto,
            @estado, @edicion_fecha, @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "CODIGO_BARRAS") condicional = (estado != "TODOS") ? WHERE4 : WHERE3; //Consulta filtrada por Código de Barras y/o Estado
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Denominación y/o Estado
            if (campo == "ID") condicional = (estado != "TODOS") ? WHERE2 : WHERE1; //Consulta filtrada por ID Artículo y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CODIGO_BARRAS") comandoDB.Parameters.AddWithValue("@codigo_barras", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CODIGO_BARRAS") comandoDB.Parameters.AddWithValue("@codigo_barras", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición de la consulta
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
                                        Convert.ToString(lectorDB["id"]).PadLeft(6, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(37, ' ') +
                                            " | " + Convert.ToString(lectorDB["a1_stock"]).PadLeft(6, ' ') +
                                            " | " + Convert.ToString(lectorDB["a2_stock"]).PadLeft(6, ' ') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(10, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(6, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(37, ' ') +
                                            " | " + Convert.ToString(lectorDB["a1_stock"]).PadLeft(6, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["a1_ingreso"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["a2_stock"]).PadLeft(6, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["a2_ingreso"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["stock_global"]).PadLeft(6, ' ') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(10, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002ARTICULO: Hay un conflicto en la consulta de artículos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<Articulo> obtenerExistencias(string deposito)
        {
            string condicional = "";
            if (deposito == "EMPREMINSA") condicional = WHERE7; //Consulta filtrada por artículos existentes y activos en el depósito de EMPREMINSA
            if (deposito == "VELADERO") condicional = WHERE8; //Consulta filtrada por artículos existentes y activos en el depósito de VELADERO
            List<Articulo> ListaDeObjetos = new List<Articulo>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Articulo objArticulo = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objArticulo); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M00114ARTICULO: Hay un conflicto en la consulta de existencias.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<Articulo> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "CODIGO_BARRAS") condicional = (estado != "TODOS") ? WHERE4 : WHERE3; //Consulta filtrada por Código de Barras y/o Estado
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Denominación y/o Estado
            if (campo == "ID") condicional = (estado != "TODOS") ? WHERE2 : WHERE1; //Consulta filtrada por ID Artículo y/o Estado
            List<Articulo> ListaDeObjetos = new List<Articulo>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CODIGO_BARRAS") comandoDB.Parameters.AddWithValue("@codigo_barras", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Articulo objArticulo = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objArticulo); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006ARTICULO: Hay un conflicto en la consulta de artículos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public Articulo obtenerObjeto(string estado, string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "CODIGO_BARRAS") condicional = (estado != "TODOS") ? WHERE4 : WHERE3; //Consulta filtrada por Código de Barras y/o Estado
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Denominación y/o Estado
            if (campo == "ID") condicional = (estado != "TODOS") ? WHERE2 : WHERE1; //Consulta filtrada por ID Artículo y/o Estado
            Articulo objArticulo = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "CODIGO_BARRAS") comandoDB.Parameters.AddWithValue("@codigo_barras", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objArticulo = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado ó Inactivo.\nVerifique los datos del artículo e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008ARTICULO: Hay un conflicto en la consulta del artículo.", e); }
            finally { _conexion.Dispose(); }
            return objArticulo;
        }

        public bool actualizar(Articulo objArticulo, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objArticulo.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@denominacion", objArticulo.Denominacion); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@codigo_barras", objArticulo.CodigoBarras); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objArticulo.Id);
                                comandoDB_update.Parameters.AddWithValue("@denominacion", objArticulo.Denominacion);
                                comandoDB_update.Parameters.AddWithValue("@codigo_barras", objArticulo.CodigoBarras);
                                comandoDB_update.Parameters.AddWithValue("@criticidad", objArticulo.Criticidad);
                                comandoDB_update.Parameters.AddWithValue("@unidad", objArticulo.Unidad);
                                comandoDB_update.Parameters.AddWithValue("@stock_global", objArticulo.StockGlobal);
                                comandoDB_update.Parameters.AddWithValue("@a1_pto_critico", objArticulo.A1_PuntoCritico);
                                comandoDB_update.Parameters.AddWithValue("@a1_pto_critico_limite", objArticulo.A1_PuntoCriticoLimite);
                                comandoDB_update.Parameters.AddWithValue("@a1_pto_critico_alertado", objArticulo.A1_PuntoCriticoAlertado);
                                comandoDB_update.Parameters.AddWithValue("@a1_pto_minimo", objArticulo.A1_PuntoMinimo);
                                comandoDB_update.Parameters.AddWithValue("@a1_pto_minimo_limite", objArticulo.A1_PuntoMinimoLimite);
                                comandoDB_update.Parameters.AddWithValue("@a1_pto_minimo_alertado", objArticulo.A1_PuntoMinimoAlertado);
                                comandoDB_update.Parameters.AddWithValue("@a1_pto_maximo_limite", objArticulo.A1_PuntoMaximoLimite);
                                comandoDB_update.Parameters.AddWithValue("@a1_ingreso", objArticulo.A1_FechaIngreso);
                                comandoDB_update.Parameters.AddWithValue("@a1_stock", objArticulo.A1_Stock);
                                comandoDB_update.Parameters.AddWithValue("@a2_pto_critico", objArticulo.A2_PuntoCritico);
                                comandoDB_update.Parameters.AddWithValue("@a2_pto_critico_limite", objArticulo.A2_PuntoCriticoLimite);
                                comandoDB_update.Parameters.AddWithValue("@a2_pto_critico_alertado", objArticulo.A2_PuntoCriticoAlertado);
                                comandoDB_update.Parameters.AddWithValue("@a2_pto_minimo", objArticulo.A2_PuntoMinimo);
                                comandoDB_update.Parameters.AddWithValue("@a2_pto_minimo_limite", objArticulo.A2_PuntoMinimoLimite);
                                comandoDB_update.Parameters.AddWithValue("@a2_pto_minimo_alertado", objArticulo.A2_PuntoMinimoAlertado);
                                comandoDB_update.Parameters.AddWithValue("@a2_pto_maximo_limite", objArticulo.A2_PuntoMaximoLimite);
                                comandoDB_update.Parameters.AddWithValue("@a2_ingreso", objArticulo.A2_FechaIngreso);
                                comandoDB_update.Parameters.AddWithValue("@a2_stock", objArticulo.A2_Stock);
                                comandoDB_update.Parameters.AddWithValue("@costo_bruto", objArticulo.CostoBruto);
                                comandoDB_update.Parameters.AddWithValue("@iva_alicuota", objArticulo.CostoAlicuotaIVA);
                                comandoDB_update.Parameters.AddWithValue("@iva_base", objArticulo.CostoBaseIVA);
                                comandoDB_update.Parameters.AddWithValue("@costo_neto", objArticulo.CostoNeto);
                                comandoDB_update.Parameters.AddWithValue("@utilidad", objArticulo.Utilidad);
                                comandoDB_update.Parameters.AddWithValue("@margen_bruto", objArticulo.MargenBruto);
                                comandoDB_update.Parameters.AddWithValue("@precio_bruto", objArticulo.PrecioBruto);
                                comandoDB_update.Parameters.AddWithValue("@estado", objArticulo.Estado);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objArticulo.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objArticulo.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objArticulo.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Artículos", "Modificó el registro ID:" + objArticulo.Id.ToString() + "."); //Registra la actualización de un registro
                                if (notificarExito) Mensaje.Informacion("Los datos del artículo " + objArticulo.Denominacion.ToString() + "\nse registraron correctamente.");
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro Existente.\nEl artículo ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M010ARTICULO", "M012ARTICULO", "M014ARTICULO", "M016ARTICULO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool eliminar(Articulo objArticulo, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ELIMINAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objArticulo.Id); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_delete = _conexion.crearComandoDB(ELIMINAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_delete.Parameters.AddWithValue("@id", objArticulo.Id);
                                comandoDB_delete.ExecuteNonQuery(); //Ejecuta el DELETE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Artículos", "Eliminó el registro ID:" + objArticulo.Id + "."); //Registra la eliminación de un registro
                                if (notificarExito) Mensaje.Informacion("El artículo " + objArticulo.Denominacion + "\nse eliminó correctamente."); return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro Inexistente.\nEl artículo No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M018ARTICULO", "M020ARTICULO", "M022ARTICULO", "M024ARTICULO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(Articulo objArticulo, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                {
                    comandoDB.Parameters.AddWithValue("@denominacion", objArticulo.Denominacion); //Agrega parámetros al comando de Base de Datos
                    comandoDB.Parameters.AddWithValue("@codigo_barras", objArticulo.CodigoBarras); //Agrega parámetros al comando de Base de Datos
                    object resultado = comandoDB.ExecuteScalar(); //Ejecuta una consulta en la Base de Datos y almacena el resultado en un Objeto
                    if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                    {
                        using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                        {
                            comandoDB_insert.Parameters.AddWithValue("@id", objArticulo.Id);
                            comandoDB_insert.Parameters.AddWithValue("@denominacion", objArticulo.Denominacion);
                            comandoDB_insert.Parameters.AddWithValue("@codigo_barras", objArticulo.CodigoBarras);
                            comandoDB_insert.Parameters.AddWithValue("@criticidad", objArticulo.Criticidad);
                            comandoDB_insert.Parameters.AddWithValue("@unidad", objArticulo.Unidad);
                            comandoDB_insert.Parameters.AddWithValue("@stock_global", objArticulo.StockGlobal);
                            comandoDB_insert.Parameters.AddWithValue("@a1_pto_critico", objArticulo.A1_PuntoCritico);
                            comandoDB_insert.Parameters.AddWithValue("@a1_pto_critico_limite", objArticulo.A1_PuntoCriticoLimite);
                            comandoDB_insert.Parameters.AddWithValue("@a1_pto_critico_alertado", objArticulo.A1_PuntoCriticoAlertado);
                            comandoDB_insert.Parameters.AddWithValue("@a1_pto_minimo", objArticulo.A1_PuntoMinimo);
                            comandoDB_insert.Parameters.AddWithValue("@a1_pto_minimo_limite", objArticulo.A1_PuntoMinimoLimite);
                            comandoDB_insert.Parameters.AddWithValue("@a1_pto_minimo_alertado", objArticulo.A1_PuntoMinimoAlertado);
                            comandoDB_insert.Parameters.AddWithValue("@a1_pto_maximo_limite", objArticulo.A1_PuntoMaximoLimite);
                            comandoDB_insert.Parameters.AddWithValue("@a1_ingreso", objArticulo.A1_FechaIngreso);
                            comandoDB_insert.Parameters.AddWithValue("@a1_stock", objArticulo.A1_Stock);
                            comandoDB_insert.Parameters.AddWithValue("@a2_pto_critico", objArticulo.A2_PuntoCritico);
                            comandoDB_insert.Parameters.AddWithValue("@a2_pto_critico_limite", objArticulo.A2_PuntoCriticoLimite);
                            comandoDB_insert.Parameters.AddWithValue("@a2_pto_critico_alertado", objArticulo.A2_PuntoCriticoAlertado);
                            comandoDB_insert.Parameters.AddWithValue("@a2_pto_minimo", objArticulo.A2_PuntoMinimo);
                            comandoDB_insert.Parameters.AddWithValue("@a2_pto_minimo_limite", objArticulo.A2_PuntoMinimoLimite);
                            comandoDB_insert.Parameters.AddWithValue("@a2_pto_minimo_alertado", objArticulo.A2_PuntoMinimoAlertado);
                            comandoDB_insert.Parameters.AddWithValue("@a2_pto_maximo_limite", objArticulo.A2_PuntoMaximoLimite);
                            comandoDB_insert.Parameters.AddWithValue("@a2_ingreso", objArticulo.A2_FechaIngreso);
                            comandoDB_insert.Parameters.AddWithValue("@a2_stock", objArticulo.A2_Stock);
                            comandoDB_insert.Parameters.AddWithValue("@costo_bruto", objArticulo.CostoBruto);
                            comandoDB_insert.Parameters.AddWithValue("@iva_alicuota", objArticulo.CostoAlicuotaIVA);
                            comandoDB_insert.Parameters.AddWithValue("@iva_base", objArticulo.CostoBaseIVA);
                            comandoDB_insert.Parameters.AddWithValue("@costo_neto", objArticulo.CostoNeto);
                            comandoDB_insert.Parameters.AddWithValue("@utilidad", objArticulo.Utilidad);
                            comandoDB_insert.Parameters.AddWithValue("@margen_bruto", objArticulo.MargenBruto);
                            comandoDB_insert.Parameters.AddWithValue("@precio_bruto", objArticulo.PrecioBruto);
                            comandoDB_insert.Parameters.AddWithValue("@estado", objArticulo.Estado);
                            comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objArticulo.EdicionFecha);
                            comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objArticulo.EdicionUsuarioId);
                            comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objArticulo.EdicionUsuarioDenominacion);
                            comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                            D_Auditoria.RegistrarAuditoria("Artículos", "Agregó un nuevo registro ID:" + objArticulo.Id.ToString() + "."); //Registra la inserción de un registro
                            if (notificarExito) Mensaje.Informacion("Los datos del artículo " + objArticulo.Denominacion.ToString() + "\nse registraron correctamente.");
                            return true;
                        }
                    }
                    else throw new NullReferenceException();
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro Existente.\nEl artículo ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M026ARTICULO", "M028ARTICULO", "M030ARTICULO", "M032ARTICULO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private Articulo instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Articulo(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToString(lectorDB["codigo_barras"]),
                Convert.ToString(lectorDB["criticidad"]),
                Convert.ToString(lectorDB["unidad"]),
                Convert.ToInt32(lectorDB["stock_global"]),
                Convert.ToBoolean(lectorDB["a1_pto_critico"]),
                Convert.ToInt32(lectorDB["a1_pto_critico_limite"]),
                Convert.ToBoolean(lectorDB["a1_pto_critico_alertado"]),
                Convert.ToBoolean(lectorDB["a1_pto_minimo"]),
                Convert.ToInt32(lectorDB["a1_pto_minimo_limite"]),
                Convert.ToBoolean(lectorDB["a1_pto_minimo_alertado"]),
                Convert.ToInt32(lectorDB["a1_pto_maximo_limite"]),
                Convert.ToDateTime(lectorDB["a1_ingreso"]),
                Convert.ToInt32(lectorDB["a1_stock"]),
                Convert.ToBoolean(lectorDB["a2_pto_critico"]),
                Convert.ToInt32(lectorDB["a2_pto_critico_limite"]),
                Convert.ToBoolean(lectorDB["a2_pto_critico_alertado"]),
                Convert.ToBoolean(lectorDB["a2_pto_minimo"]),
                Convert.ToInt32(lectorDB["a2_pto_minimo_limite"]),
                Convert.ToBoolean(lectorDB["a2_pto_minimo_alertado"]),
                Convert.ToInt32(lectorDB["a2_pto_maximo_limite"]),
                Convert.ToDateTime(lectorDB["a2_ingreso"]),
                Convert.ToInt32(lectorDB["a2_stock"]),
                Convert.ToDouble(lectorDB["costo_bruto"]),
                Convert.ToString(lectorDB["iva_alicuota"]),
                Convert.ToDouble(lectorDB["iva_base"]),
                Convert.ToDouble(lectorDB["costo_neto"]),
                Convert.ToDouble(lectorDB["utilidad"]),
                Convert.ToDouble(lectorDB["margen_bruto"]),
                Convert.ToDouble(lectorDB["precio_bruto"]),
                Convert.ToString(lectorDB["estado"]),
                Convert.ToDateTime(lectorDB["edicion_fecha"]),
                Convert.ToInt32(lectorDB["edicion_usuario_id"]),
                Convert.ToString(lectorDB["edicion_usuario"]));
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