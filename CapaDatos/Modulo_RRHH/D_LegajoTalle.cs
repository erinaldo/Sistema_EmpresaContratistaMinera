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
    public class D_LegajoTalle : ILegajoTalle, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_legajo_talle.*,
            data_legajo.denominacion, data_legajo.documento, data_legajo.cuit, data_legajo.baja";
        private const string FROM = @" FROM data_legajo_talle
            INNER JOIN data_legajo ON data_legajo_talle.id_legajo = data_legajo.id";
        private const string WHERE1 = @" WHERE data_legajo_talle.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_legajo_talle.id_legajo = @id_legajo"; //Filtrar Objeto por ID Legajo
        private const string WHERE3 = @" WHERE data_legajo.cuit = @cuit"; //Filtrar Objeto por CUIL/CUIT
        private const string WHERE4 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE5 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion) AND data_legajo.baja = @baja"; //Filtrar Objeto por Denominación y Baja
        private const string ORDER = @" ORDER BY data_legajo.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_legajo_talle WHERE id_legajo = @id_legajo AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_legajo_talle WHERE id_legajo = @id_legajo"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_legajo_talle SET 
            id = @id,
            id_legajo = @id_legajo,
            talle_camisa = @talle_camisa,
            talle_pantalon = @talle_pantalon,
            talle_calzado = @talle_calzado,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_legajo_talle(id, id_legajo, talle_camisa, talle_pantalon,
            talle_calzado, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @id_legajo, @talle_camisa, @talle_pantalon, @talle_calzado, @edicion_fecha, 
            @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "CUIT") condicional = WHERE3; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE5 : WHERE4; //Consulta filtrada por Denominación y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (estado == "C/BAJA") comandoDB.Parameters.AddWithValue("@baja", "1"); //Agrega el parámetro en la condición del contador
                        if (estado == "S/BAJA") comandoDB.Parameters.AddWithValue("@baja", "0"); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (estado == "C/BAJA") comandoDB.Parameters.AddWithValue("@baja", "1"); //Agrega el parámetro en la condición de la consulta
                        if (estado == "S/BAJA") comandoDB.Parameters.AddWithValue("@baja", "0"); //Agrega el parámetro en la condición de la consulta
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                string bajaLegajo = (Convert.ToBoolean(lectorDB["baja"])) ? " (BAJA)" : "";
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0"));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                       Convert.ToInt64(lectorDB["id"]),
                                       Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                           " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(42, ' ') +
                                           " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                           " | " + Convert.ToString(lectorDB["talle_camisa"]).PadRight(6, ' ') +
                                           " | " + Convert.ToString(lectorDB["talle_pantalon"]).PadRight(7, ' ') +
                                           " | " + Convert.ToString(lectorDB["talle_calzado"]).PadRight(3, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002LEGAJO_TALLE: Hay un conflicto en la consulta de legajos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<LegajoTalle> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "CUIT") condicional = WHERE3; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE5 : WHERE4; //Consulta filtrada por Denominación y/o Estado
            List<LegajoTalle> ListaDeObjetos = new List<LegajoTalle>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega un parámetro al filtro
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega un parámetro al filtro
                        if (estado == "C/BAJA") comandoDB.Parameters.AddWithValue("@baja", "1"); //Agrega el parámetro en la condición de la consulta
                        if (estado == "S/BAJA") comandoDB.Parameters.AddWithValue("@baja", "0"); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                LegajoTalle objLegajoTalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objLegajoTalle); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004LEGAJO_TALLE: Hay un conflicto en la consulta de legajos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public LegajoTalle obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            if (campo == "ID_LEGAJO") condicional = WHERE2; //Consulta filtrada por ID Legajo
            if (campo == "CUIT") condicional = WHERE3; //Consulta filtrada por CUIL/CUIT
            LegajoTalle objLegajoTalle = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        if (campo == "ID_LEGAJO") comandoDB.Parameters.AddWithValue("@id_legajo", valor); //Agrega un parámetro al filtro
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objLegajoTalle = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos del legajo e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006LEGAJO_TALLE: Hay un conflicto en la consulta del legajo.", e); }
            finally { _conexion.Dispose(); }
            return objLegajoTalle;
        }

        public bool actualizar(LegajoTalle objLegajoTalle)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objLegajoTalle.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@id_legajo", objLegajoTalle.Legajo.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objLegajoTalle.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_legajo", objLegajoTalle.Legajo.Id);
                                comandoDB_update.Parameters.AddWithValue("@talle_camisa", objLegajoTalle.TalleCamisa);
                                comandoDB_update.Parameters.AddWithValue("@talle_pantalon", objLegajoTalle.TallePantalon);
                                comandoDB_update.Parameters.AddWithValue("@talle_calzado", objLegajoTalle.TalleCalzado);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objLegajoTalle.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objLegajoTalle.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objLegajoTalle.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Legajos - Talles de Indum.", "Modificó el registro Id:" + objLegajoTalle.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nLos talles ya se encuentran registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M008LEGAJO_TALLE", "M010LEGAJO_TALLE", "M012LEGAJO_TALLE", "M014LEGAJO_TALLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(LegajoTalle objLegajoTalle)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_legajo", objLegajoTalle.Legajo.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objLegajoTalle.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_legajo", objLegajoTalle.Legajo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@talle_camisa", objLegajoTalle.TalleCamisa);
                                comandoDB_insert.Parameters.AddWithValue("@talle_pantalon", objLegajoTalle.TallePantalon);
                                comandoDB_insert.Parameters.AddWithValue("@talle_calzado", objLegajoTalle.TalleCalzado);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objLegajoTalle.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objLegajoTalle.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objLegajoTalle.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Legajos - Talles de Indum.", "Agregó un nuevo registro ID:" + objLegajoTalle.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nLos talles ya se encuentran registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M016LEGAJO_TALLE", "M018LEGAJO_TALLE", "M020LEGAJO_TALLE", "M022LEGAJO_TALLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private LegajoTalle instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new LegajoTalle(
                Convert.ToInt64(lectorDB["id"]),
                new D_Legajo().obtenerObjeto("ID", Convert.ToString(lectorDB["id_legajo"]), false),
                Convert.ToString(lectorDB["talle_camisa"]),
                Convert.ToString(lectorDB["talle_pantalon"]),
                Convert.ToString(lectorDB["talle_calzado"]),
                Convert.ToDateTime(lectorDB["edicion_fecha"]),
                Convert.ToInt64(lectorDB["edicion_usuario_id"]),
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
