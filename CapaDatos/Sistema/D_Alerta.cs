using Biblioteca.Ayudantes;
using Entidades.Catalogo;
using Entidades.Sistema;
using Interfaces.Sistema;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos.Sistema
{
    public class D_Alerta : IAlerta, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT *";
        private const string FROM = @" FROM sys_alerta";
        private const string WHERE1 = @" WHERE id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE LOWER(denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE3 = @" WHERE LOWER(denominacion) LIKE LOWER(@denominacion) AND estado = @estado"; //Filtrar Objeto por Denominación y Estado
        private const string WHERE4 = @" WHERE date(fecha_vto) >= date(@desde) AND date(fecha_vto) <= date(@hasta)"; //Filtrar Objeto por Fecha de Vencimiento 
        private const string WHERE5 = @" WHERE date(fecha_vto) >= date(@desde) AND date(fecha_vto) <= date(@hasta) AND estado = @estado"; //Filtrar Objeto por Fecha de Vencimiento y Estado
        private const string ORDER = @" ORDER BY fecha_vto DESC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM sys_alerta WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ELIMINAR = @"SELECT * FROM sys_alerta WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM sys_alerta WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE sys_alerta SET 
            id = @id,
            tipo_alerta = @tipo_alerta,
            denominacion = @denominacion,
            fecha_vto = @fecha_vto,
            estado = @estado,
            id_navegador = @id_navegador,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ELIMINAR = @"DELETE FROM sys_alerta WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO sys_alerta (id, tipo_alerta, denominacion, fecha_vto, 
            estado, id_navegador, edicion_fecha, edicion_usuario_id, edicion_usuario) 
            VALUES (@id, @tipo_alerta, @denominacion, @fecha_vto, @estado, @id_navegador, @edicion_fecha,
            @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string tipoAlerta, string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE3 : WHERE2; //Consulta filtrada por Estado y/o Denominación
            if (tipoAlerta != "ALERTAS PERSONALIZADAS") condicional += " AND tipo_alerta = @tipo_alerta";
            else if (tipoAlerta == "ALERTAS PERSONALIZADAS" && Global.UsuarioActivo_Alertas.Count == 1) condicional += " AND tipo_alerta = '" + Global.UsuarioActivo_Alertas[0] + "'";
            else if (tipoAlerta == "ALERTAS PERSONALIZADAS" && Global.UsuarioActivo_Alertas.Count == 2) condicional += " AND (tipo_alerta = '" + Global.UsuarioActivo_Alertas[0] + "' OR tipo_alerta = '" + Global.UsuarioActivo_Alertas[1] + "')";
            else if (tipoAlerta == "ALERTAS PERSONALIZADAS" && Global.UsuarioActivo_Alertas.Count == 3) condicional += " AND (tipo_alerta = '" + Global.UsuarioActivo_Alertas[0] + "' OR tipo_alerta = '" + Global.UsuarioActivo_Alertas[1] + "' OR tipo_alerta = '" + Global.UsuarioActivo_Alertas[2] + "')";
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (tipoAlerta != "ALERTAS PERSONALIZADAS") comandoDB.Parameters.AddWithValue("@tipo_alerta", tipoAlerta); //Agrega el parámetro en la condición del contador
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (tipoAlerta != "ALERTAS PERSONALIZADAS") comandoDB.Parameters.AddWithValue("@tipo_alerta", tipoAlerta); //Agrega el parámetro en la condición de la consulta
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
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(95, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha_vto"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(12, ' '));
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
            catch (MySqlException e) { Mensaje.Error("Error-M002ALERTA: Hay un conflicto en la consulta de alertas.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string tipoAlerta, string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "FECHA_VTO") condicional = (estado != "TODOS") ? WHERE5 : WHERE4; //Consulta filtrada por Estado y/o Fecha de Vencimiento
            if (tipoAlerta != "ALERTAS PERSONALIZADAS") condicional += " AND tipo_alerta = @tipo_alerta";
            else if (tipoAlerta == "ALERTAS PERSONALIZADAS" && Global.UsuarioActivo_Alertas.Count == 1) condicional += " AND tipo_alerta = '" + Global.UsuarioActivo_Alertas[0] + "'";
            else if (tipoAlerta == "ALERTAS PERSONALIZADAS" && Global.UsuarioActivo_Alertas.Count == 2) condicional += " AND (tipo_alerta = '" + Global.UsuarioActivo_Alertas[0] + "' OR tipo_alerta = '" + Global.UsuarioActivo_Alertas[1] + "')";
            else if (tipoAlerta == "ALERTAS PERSONALIZADAS" && Global.UsuarioActivo_Alertas.Count == 3) condicional += " AND (tipo_alerta = '" + Global.UsuarioActivo_Alertas[0] + "' OR tipo_alerta = '" + Global.UsuarioActivo_Alertas[1] + "' OR tipo_alerta = '" + Global.UsuarioActivo_Alertas[2] + "')";
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega el parámetro en la condición del contador
                        if (tipoAlerta != "ALERTAS PERSONALIZADAS") comandoDB.Parameters.AddWithValue("@tipo_alerta", tipoAlerta); //Agrega el parámetro en la condición del contador
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición de la consulta
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        if (tipoAlerta != "ALERTAS PERSONALIZADAS") comandoDB.Parameters.AddWithValue("@tipo_alerta", tipoAlerta); //Agrega el parámetro en la condición de la consulta
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
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(95, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["fecha_vto"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(12, ' '));
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
            catch (MySqlException e) { Mensaje.Error("Error-M004ALERTA: Hay un conflicto en la consulta de alertas.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<Alerta> obtenerObjetos(string tipoAlerta, string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE3 : WHERE2; //Consulta filtrada por Estado y/o Denominación
            if (tipoAlerta != "ALERTAS PERSONALIZADAS") condicional += " AND tipo_alerta = @tipo_alerta";
            else if (tipoAlerta == "ALERTAS PERSONALIZADAS" && Global.UsuarioActivo_Alertas.Count == 1) condicional += " AND tipo_alerta = '" + Global.UsuarioActivo_Alertas[0] + "'";
            else if (tipoAlerta == "ALERTAS PERSONALIZADAS" && Global.UsuarioActivo_Alertas.Count == 2) condicional += " AND (tipo_alerta = '" + Global.UsuarioActivo_Alertas[0] + "' OR tipo_alerta = '" + Global.UsuarioActivo_Alertas[1] + "')";
            else if (tipoAlerta == "ALERTAS PERSONALIZADAS" && Global.UsuarioActivo_Alertas.Count == 3) condicional += " AND (tipo_alerta = '" + Global.UsuarioActivo_Alertas[0] + "' OR tipo_alerta = '" + Global.UsuarioActivo_Alertas[1] + "' OR tipo_alerta = '" + Global.UsuarioActivo_Alertas[2] + "')";
            List<Alerta> ListaDeObjetos = new List<Alerta>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega un parámetro al filtro
                        if (tipoAlerta != "ALERTAS PERSONALIZADAS") comandoDB.Parameters.AddWithValue("@tipo_alerta", tipoAlerta); //Agrega el parámetro en la condición de la consulta
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Alerta objAlerta = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objAlerta); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006ALERTA: Hay un conflicto en la consulta de alertas.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<Alerta> obtenerObjetos(string tipoAlerta, string estado, string campo, DateTime desde, DateTime hasta)
        {
            string condicional = "";
            if (campo == "FECHA_VTO") condicional = (estado != "TODOS") ? WHERE5 : WHERE4; //Consulta filtrada por Estado y/o Fecha de Vencimiento
            if (tipoAlerta != "ALERTAS PERSONALIZADAS") condicional += " AND tipo_alerta = @tipo_alerta";
            else if (tipoAlerta == "ALERTAS PERSONALIZADAS" && Global.UsuarioActivo_Alertas.Count == 1) condicional += " AND tipo_alerta = '" + Global.UsuarioActivo_Alertas[0] + "'";
            else if (tipoAlerta == "ALERTAS PERSONALIZADAS" && Global.UsuarioActivo_Alertas.Count == 2) condicional += " AND (tipo_alerta = '" + Global.UsuarioActivo_Alertas[0] + "' OR tipo_alerta = '" + Global.UsuarioActivo_Alertas[1] + "')";
            else if (tipoAlerta == "ALERTAS PERSONALIZADAS" && Global.UsuarioActivo_Alertas.Count == 3) condicional += " AND (tipo_alerta = '" + Global.UsuarioActivo_Alertas[0] + "' OR tipo_alerta = '" + Global.UsuarioActivo_Alertas[1] + "' OR tipo_alerta = '" + Global.UsuarioActivo_Alertas[2] + "')";
            List<Alerta> ListaDeObjetos = new List<Alerta>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro terciario
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro terciario
                        if (tipoAlerta != "ALERTAS PERSONALIZADAS") comandoDB.Parameters.AddWithValue("@tipo_alerta", tipoAlerta); //Agrega el parámetro en la condición de la consulta
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Alerta objAlerta = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objAlerta); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008ALERTA: Hay un conflicto en la consulta de alertas.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public Alerta obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            Alerta objAlerta = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objAlerta = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Alerta solicitada No hallada.\nVerifique los datos de la entrevista e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010ALERTA: Hay un conflicto en la consulta de la entrevista.", e); }
            finally { _conexion.Dispose(); }
            return objAlerta;
        }

        public bool actualizar(Alerta objAlerta, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objAlerta.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objAlerta.Id);
                                comandoDB_update.Parameters.AddWithValue("@tipo_alerta", objAlerta.TipoAlerta);
                                comandoDB_update.Parameters.AddWithValue("@denominacion", objAlerta.Denominacion);
                                comandoDB_update.Parameters.AddWithValue("@fecha_vto", objAlerta.FechaVencimiento);
                                comandoDB_update.Parameters.AddWithValue("@estado", objAlerta.Estado);
                                comandoDB_update.Parameters.AddWithValue("@id_navegador", objAlerta.IdNavegador);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objAlerta.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objAlerta.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objAlerta.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Alertas de Sistema", "Modificó el estado del alerta ID:" + objAlerta.Id.ToString() + " como " + objAlerta.Estado + "."); //Registra la modificación de un registro
                                if (notificarExito) Mensaje.Informacion("El estado del alerta ID:" + objAlerta.Id.ToString() + "\nse registró correctamente.");
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Alerta Inexistente.\nLa entrevista No se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M012ALERTA", "M014ALERTA", "M016ALERTA", "M018ALERTA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool eliminar(long id, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ELIMINAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_delete = _conexion.crearComandoDB(ELIMINAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_delete.Parameters.AddWithValue("@id", id);
                                comandoDB_delete.ExecuteNonQuery(); //Ejecuta el DELETE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Alertas de Sistema", "Eliminó el alerta ID:" + id.ToString() + "."); //Registra la modificación de un registro
                                if (notificarExito) Mensaje.Informacion("Los datos del alerta ID:" + id.ToString() + "\nse eliminaron correctamente.");
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Alerta Inexistente.\nLa entrevista No se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M020ALERTA", "M022ALERTA", "M024ALERTA", "M026ALERTA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(Alerta objAlerta)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objAlerta.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objAlerta.Id);
                                comandoDB_insert.Parameters.AddWithValue("@tipo_alerta", objAlerta.TipoAlerta);
                                comandoDB_insert.Parameters.AddWithValue("@denominacion", objAlerta.Denominacion);
                                comandoDB_insert.Parameters.AddWithValue("@fecha_vto", objAlerta.FechaVencimiento);
                                comandoDB_insert.Parameters.AddWithValue("@estado", objAlerta.Estado);
                                comandoDB_insert.Parameters.AddWithValue("@id_navegador", objAlerta.IdNavegador);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", Fecha.DTSistemaFecha());
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", 0);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", "Monitor de Sistema");
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
                Mensaje.Advertencia("Alerta Existente.\nEl alerta ya se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M028ALERTA", "M030ALERTA", "M032ALERTA", "M034ALERTA", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public void insertar(List<Alerta> listaDeAlertas)
        {
            try
            {
                foreach (Alerta item in listaDeAlertas)
                {
                    if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                    {
                        using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                        {
                            comandoDB.Parameters.AddWithValue("@id", item.Id); //Agrega parámetros al comando de Base de Datos
                            if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                            {
                                using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                                {
                                    comandoDB_insert.Parameters.AddWithValue("@id", item.Id);
                                    comandoDB_insert.Parameters.AddWithValue("@tipo_alerta", item.TipoAlerta);
                                    comandoDB_insert.Parameters.AddWithValue("@denominacion", item.Denominacion);
                                    comandoDB_insert.Parameters.AddWithValue("@fecha_vto", item.FechaVencimiento);
                                    comandoDB_insert.Parameters.AddWithValue("@estado", item.Estado);
                                    comandoDB_insert.Parameters.AddWithValue("@id_navegador", item.IdNavegador);
                                    comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", Fecha.DTSistemaFecha());
                                    comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", 0);
                                    comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", "Monitor de Sistema");
                                    comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Alerta Existente.\nEl alerta ya se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M036ALERTA", "M038ALERTA", "M040ALERTA", "M042ALERTA", e); }
            finally { _conexion.Dispose(); }
        }
        #endregion

        #region Métodos de Instanciación
        private Alerta instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Alerta(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToString(lectorDB["tipo_alerta"]),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToDateTime(lectorDB["fecha_vto"]),
                Convert.ToString(lectorDB["estado"]),
                Convert.ToString(lectorDB["id_navegador"]),
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
