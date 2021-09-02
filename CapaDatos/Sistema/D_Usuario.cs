using Biblioteca.Ayudantes;
using CapaDatos.Catalogo;
using CapaDatos.Sistema;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_Usuario : IUsuario, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_usuario.*, 
            data_legajo.denominacion, data_legajo.documento, data_legajo.cuit, data_legajo.baja";
        private const string FROM = @" FROM data_usuario
            INNER JOIN data_legajo ON data_usuario.id_legajo = data_legajo.id";
        private const string WHERE1 = @" WHERE data_usuario.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_usuario.id_legajo = @id_legajo"; //Filtrar Objeto por ID Legajo
        private const string WHERE3 = @" WHERE data_legajo.cuit = @cuit"; //Filtrar Objeto por CUIL/CUIT
        private const string WHERE4 = @" WHERE data_legajo.documento = @documento"; //Filtrar Objeto por Documento
        private const string WHERE5 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE6 = @" WHERE LOWER(data_legajo.denominacion) LIKE LOWER(@denominacion) AND data_legajo.baja = @baja"; //Filtrar Objeto por Denominación y Estado
        private const string ORDER = @" ORDER BY data_legajo.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_usuario WHERE id_legajo = @id_legajo AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ELIMINAR = @"SELECT * FROM data_usuario WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_usuario WHERE id_legajo = @id_legajo"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string RECUPERAR_USUARIO = SELECT + FROM + WHERE4 + @" AND data_legajo.baja = '0' AND LOWER(data_usuario.email_recuperacion) = LOWER(@email_recuperacion)"; //Los Usuarios dados de baja no pueden acceder al sistema
        private const string VALIDAR_USUARIO = SELECT + FROM + WHERE4 + @" AND data_legajo.baja = '0' AND LOWER(data_usuario.contrasenia) = LOWER(@contrasenia)"; //Los Usuarios dados de baja no pueden acceder al sistema  
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_usuario SET 
            id = @id,
            id_legajo = @id_legajo,
            tipo_usuario = @tipo_usuario,
            email_recuperacion = @email_recuperacion,
            alerta_facturacion = @alerta_facturacion,
            alerta_inventario = @alerta_inventario,
            alerta_rrhh = @alerta_rrhh, 
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ACTUALIZAR_CONTRASENIA = @"UPDATE data_usuario SET contrasenia = @contrasenia WHERE id = @id";
        private const string ELIMINAR = @"DELETE FROM data_usuario WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_usuario(id, id_legajo, contrasenia, tipo_usuario, email_recuperacion,
            alerta_facturacion, alerta_inventario, alerta_rrhh, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @id_legajo, @contrasenia, @tipo_usuario, @email_recuperacion, @alerta_facturacion,
            @alerta_inventario, @alerta_rrhh, @edicion_fecha, @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "CUIT") condicional = WHERE3; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Denominación y/o Estado
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
                                            " | " + (Convert.ToString(lectorDB["denominacion"]) + bajaLegajo).PadRight(49, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + Convert.ToString(lectorDB["tipo_usuario"]).PadRight(15, ' '));
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
            catch (MySqlException e) { Mensaje.Error("Error-M002USUARIO: Hay un conflicto en la consulta de usuarios.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<Usuario> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "CUIT") condicional = WHERE3; //Consulta filtrada por CUIL/CUIT
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Denominación y/o Estado
            List<Usuario> ListaDeObjetos = new List<Usuario>(); //Crea una lista de Objetos para almacenar los registros de la tabla
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
                                Usuario objUsuario = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objUsuario); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004USUARIO: Hay un conflicto en la consulta de usuarios.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public Usuario obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "CUIT") condicional = WHERE3; //Consulta filtrada por CUIL/CUIT
            if (campo == "DOCUMENTO") condicional = WHERE4; //Consulta filtrada por Documento
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            if (campo == "ID_LEGAJO") condicional = WHERE2; //Consulta filtrada por ID Legajo
            Usuario objUsuario = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega un parámetro al filtro
                        if (campo == "DOCUMENTO") comandoDB.Parameters.AddWithValue("@documento", valor); //Agrega un parámetro al filtro
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        if (campo == "ID_LEGAJO") comandoDB.Parameters.AddWithValue("@id_legajo", valor); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objUsuario = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
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
            catch (MySqlException e) { Mensaje.Error("Error-M006USUARIO: Hay un conflicto en la consulta del legajo.", e); }
            finally { _conexion.Dispose(); }
            return objUsuario;
        }

        public bool actualizar(Usuario objUsuario)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objUsuario.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@id_legajo", objUsuario.Legajo.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objUsuario.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_legajo", objUsuario.Legajo.Id);
                                comandoDB_update.Parameters.AddWithValue("@tipo_usuario", objUsuario.TipoUsuario);
                                comandoDB_update.Parameters.AddWithValue("@email_recuperacion", objUsuario.EmailRecuperacion);
                                comandoDB_update.Parameters.AddWithValue("@alerta_facturacion", objUsuario.AlertaFacturacion);
                                comandoDB_update.Parameters.AddWithValue("@alerta_inventario", objUsuario.AlertaInventario);
                                comandoDB_update.Parameters.AddWithValue("@alerta_rrhh", objUsuario.AlertaRRHH);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objUsuario.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objUsuario.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objUsuario.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Usuarios", "Modificó el registro Id:" + objUsuario.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl usuario ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M008USUARIO", "M010USUARIO", "M012USUARIO", "M014USUARIO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool eliminar(Usuario objUsuario)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ELIMINAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objUsuario.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_delete = _conexion.crearComandoDB(ELIMINAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_delete.Parameters.AddWithValue("@id", objUsuario.Id);
                                comandoDB_delete.ExecuteNonQuery(); //Ejecuta el DELETE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Usuarios", "Eliminó el registro de " + objUsuario.Legajo.Denominacion + "."); //Registra la eliminación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Inexistente.\nEl usuario No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M016USUARIO", "M018USUARIO", "M020USUARIO", "M022USUARIO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(Usuario objUsuario)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_legajo", objUsuario.Legajo.Id); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objUsuario.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_legajo", objUsuario.Legajo.Id);
                                comandoDB_insert.Parameters.AddWithValue("@contrasenia", objUsuario.Contrasenia);
                                comandoDB_insert.Parameters.AddWithValue("@tipo_usuario", objUsuario.TipoUsuario);
                                comandoDB_insert.Parameters.AddWithValue("@email_recuperacion", objUsuario.EmailRecuperacion);
                                comandoDB_insert.Parameters.AddWithValue("@alerta_facturacion", objUsuario.AlertaFacturacion);
                                comandoDB_insert.Parameters.AddWithValue("@alerta_inventario", objUsuario.AlertaInventario);
                                comandoDB_insert.Parameters.AddWithValue("@alerta_rrhh", objUsuario.AlertaRRHH);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objUsuario.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objUsuario.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objUsuario.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Usuarios", "Agregó un nuevo registro ID:" + objUsuario.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl usuario ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M024USUARIO", "M026USUARIO", "M028USUARIO", "M030USUARIO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool iniciarSesion(string documento, string contrasenia, bool notificarExito)
        {
            Usuario objUsuario = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(VALIDAR_USUARIO)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@documento", documento); //Agrega un parámetro al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@contrasenia", Encriptacion.EncriptarContrasenia(contrasenia));
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objUsuario = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes
                                    Global.UsuarioActivo_IdUsuario = objUsuario.Id; //Almacena en una variable global el ID del usuario  
                                    Global.UsuarioActivo_IdUsuario = objUsuario.Legajo.Id; //Almacena en una variable global el ID del usuario  
                                    Global.UsuarioActivo_Denominacion = objUsuario.Legajo.Denominacion; //Almacena en una variable global la denominación del usuario
                                    Global.UsuarioActivo_Documento = Convert.ToString(objUsuario.Legajo.Documento); //Almacena en una variable global la denominación del usuario
                                    Global.UsuarioActivo_TipoUsuario = objUsuario.TipoUsuario; //Almacena en una variable global la denominación del usuario
                                    if (objUsuario.AlertaFacturacion) Global.UsuarioActivo_Alertas.Add("ALERTAS DE FACTURACION");
                                    if (objUsuario.AlertaInventario) Global.UsuarioActivo_Alertas.Add("ALERTAS DE INVENTARIO");
                                    if (objUsuario.AlertaRRHH) Global.UsuarioActivo_Alertas.Add("ALERTAS DE RRHH");
                                    Global.UsuarioActivo_Privilegios = new D_Privilegio().obtenerElementos(objUsuario.Id); //Almacena en una lista global los id de los privilegios que posee el usuario
                                    Archivo.EliminarArchivosTemporales(); //Limpia el directorio temporal borrando los archivos obseletos
                                    D_Auditoria.RegistrarAuditoria("Acceso al Sistema", "Inició sesión de sistema."); //Registra el inicio de sesión del sistema
                                }
                                return true;
                            }
                            else
                            {
                                throw new NullReferenceException();
                            }
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Acceso Incorrecto.\nVerifique el usuario y/o contraseña e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M032USUARIO: Hay un conflicto en la validación del usuario.", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool recuperarUsuario(string documento, string emailRecuperacion, bool notificarExito)
        {
            Usuario objUsuario = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(RECUPERAR_USUARIO)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@documento", documento.Trim()); //Agrega un parámetro al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@email_recuperacion", emailRecuperacion.Trim()); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objUsuario = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                        #region Actualiza la contraseña del Usuario en la Base de Datos
                        if (objUsuario != null && objUsuario.Id > 0) //Verifica que el Objeto se ha instanciado correctamente
                        {
                            string nuevaContrasenia = Encriptacion.GenerarContrasenia(); //Paso 1: Genera una nueva contraseña de tipo string
                            objUsuario.Contrasenia = Encriptacion.EncriptarContrasenia(nuevaContrasenia); //Paso 2: Asigna la nueva contraseña en el Objeto
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR_CONTRASENIA)) //Paso 3: Actualiza la contraseña en la Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objUsuario.Id); //Agrega un parámetro al comando de Base de Datos
                                comandoDB_update.Parameters.AddWithValue("@contrasenia", objUsuario.Contrasenia); //Agrega un parámetro al comando de Base de Datos
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                Correo.EnviarCorreo_Contrasenia("Recuperación de Contraseña", emailRecuperacion, objUsuario.Legajo.Denominacion, documento, nuevaContrasenia); //Envia la nueva contraseña al correo del usuario
                                if (notificarExito) Mensaje.Informacion("Su contraseña se ha enviado correctamente.\nVerifique su correo electrónico e intente acceder al Sistema.");
                                return true;
                            }
                        }
                        #endregion
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Acceso Incorrecto.\nVerifique el DNI y/o correo e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M034USUARIO: Hay un conflicto en la validación del usuario.", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private Usuario instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Usuario(
                Convert.ToInt64(lectorDB["id"]),
                new D_Legajo().obtenerObjeto("ID", Convert.ToString(lectorDB["id_legajo"]), true),
                (byte[])lectorDB["contrasenia"],
                Convert.ToString(lectorDB["tipo_usuario"]),
                Convert.ToString(lectorDB["email_recuperacion"]),
                Convert.ToBoolean(lectorDB["alerta_facturacion"]),
                Convert.ToBoolean(lectorDB["alerta_inventario"]),
                Convert.ToBoolean(lectorDB["alerta_rrhh"]),
                new D_Privilegio().obtenerObjetos(Convert.ToInt64(lectorDB["id"])),
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
