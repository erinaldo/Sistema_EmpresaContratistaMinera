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
    public class D_Proveedor : IProveedor, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT1 = @"SELECT data_proveedor.id, id_cuenta_contable, data_proveedor.denominacion, 
            nombre_fantasia, cuit, data_cuenta_contable.denominacion AS cuenta_contable, data_proveedor.saldo, estado";
        private const string SELECT2 = @"SELECT data_proveedor.*,
            cat_banco.denominacion AS banco";
        private const string FROM = @" FROM data_proveedor 
            LEFT JOIN cat_banco ON data_proveedor.cta_bancaria_id = cat_banco.id
            LEFT JOIN data_cuenta_contable ON data_proveedor.id_cuenta_contable = data_cuenta_contable.id";
        private const string WHERE1 = @" WHERE data_proveedor.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE estado = @estado AND data_proveedor.id = @id"; //Filtrar Objeto por Estado y ID
        private const string WHERE3 = @" WHERE cuit = @cuit"; //Filtrar Objeto por CUIT
        private const string WHERE4 = @" WHERE estado = @estado AND cuit = @cuit"; //Filtrar Objeto por Estado y CUIT
        private const string WHERE5 = @" WHERE LOWER(data_proveedor.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE6 = @" WHERE estado = @estado AND LOWER(data_proveedor.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Estado y Denominación
        private const string WHERE7 = @" WHERE LOWER(data_proveedor.nombre_fantasia) LIKE LOWER(@nombre_fantasia)"; //Filtrar Objeto por Nombre de Fantasía
        private const string WHERE8 = @" WHERE estado = @estado AND LOWER(data_proveedor.nombre_fantasia) LIKE LOWER(@nombre_fantasia)"; //Filtrar Objeto por Estado y Nombre de Fantasía
        private const string ORDER = @" ORDER BY data_proveedor.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_proveedor WHERE cuit = @cuit AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ELIMINAR = @"SELECT * FROM data_proveedor WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_proveedor WHERE cuit = @cuit"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_proveedor SET 
            id = @id,
            denominacion= @denominacion,
            nombre_fantasia= @nombre_fantasia,
            cuit = @cuit,
            iva = @iva,
            domicilio = @domicilio,
            provincia = @provincia,
            distrito = @distrito,
            cp = @cp,
            telefono = @telefono,
            celular = @celular,
            email = @email,
            pagina_web = @pagina_web,
            cta_bancaria_id = @cta_bancaria_id,
            cta_bancaria_tipo = @cta_bancaria_tipo,
            cta_bancaria_nro = @cta_bancaria_nro,
            id_cuenta_contable= @id_cuenta_contable,
            saldo = @saldo,
            contacto_nom = @contacto_nom,
            contacto_tel = @contacto_tel,
            contacto_cel = @contacto_cel,
            contacto_email = @contacto_email,
            estado = @estado,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ACTUALIZAR_SALDO = @"UPDATE data_proveedor SET saldo = @saldo WHERE id = @id";
        private const string ELIMINAR = @"DELETE FROM data_proveedor WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_proveedor(id, denominacion, nombre_fantasia, cuit, iva,
            domicilio, provincia, distrito, cp, telefono, celular, email, pagina_web, cta_bancaria_id, cta_bancaria_tipo,
            cta_bancaria_nro, id_cuenta_contable, saldo, contacto_nom, contacto_tel, contacto_cel, contacto_email, estado,
            edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @denominacion, @nombre_fantasia, @cuit, @iva, @domicilio, @provincia, @distrito, @cp, @telefono,
            @celular, @email, @pagina_web, @cta_bancaria_id, @cta_bancaria_tipo, @cta_bancaria_nro, @id_cuenta_contable,
            @saldo, @contacto_nom, @contacto_tel, @contacto_cel, @contacto_email, @estado, @edicion_fecha, 
            @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "CUIT") condicional = (estado != "TODOS") ? WHERE4 : WHERE3; //Consulta filtrada por CUIT y/o Estado
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Denominación y/o Estado
            if (campo == "FANTASIA") condicional = (estado != "TODOS") ? WHERE8 : WHERE7; //Consulta filtrada por Nombre de fantasía y/o Estado
            if (campo == "ID") condicional = (estado != "TODOS") ? WHERE2 : WHERE1; //Consulta filtrada por Denominación y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "FANTASIA") comandoDB.Parameters.AddWithValue("@nombre_fantasia", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "FANTASIA") comandoDB.Parameters.AddWithValue("@nombre_fantasia", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
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
                                        Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["saldo"])).PadLeft(12, ' ') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(10, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToString(lectorDB["nombre_fantasia"]).PadRight(20, ' ') +
                                            " | " + Convert.ToInt64(lectorDB["cuit"]).ToString("00-00000000/0") +
                                            " | " + Convert.ToString(lectorDB["cuenta_contable"]).PadRight(25, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["saldo"])).PadLeft(12, ' ') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(10, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002PROVEEDOR: Hay un conflicto en la consulta de proveedores.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<Proveedor> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "CUIT") condicional = (estado != "TODOS") ? WHERE4 : WHERE3; //Consulta filtrada por CUIT y/o Estado
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Denominación y/o Estado
            if (campo == "FANTASIA") condicional = (estado != "TODOS") ? WHERE8 : WHERE7; //Consulta filtrada por Nombre de fantasía y/o Estado
            if (campo == "ID") condicional = (estado != "TODOS") ? WHERE2 : WHERE1; //Consulta filtrada por Denominación y/o Estado
            List<Proveedor> ListaDeObjetos = new List<Proveedor>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "FANTASIA") comandoDB.Parameters.AddWithValue("@nombre_fantasia", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Proveedor objProveedor = instanciarParcialmente(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objProveedor); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004PROVEEDOR: Hay un conflicto en la consulta de proveedores.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public Proveedor obtenerObjeto(string estado, string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "CUIT") condicional = (estado != "TODOS") ? WHERE4 : WHERE3; //Consulta filtrada por CUIT y/o Estado
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Denominación y/o Estado
            if (campo == "FANTASIA") condicional = (estado != "TODOS") ? WHERE8 : WHERE7; //Consulta filtrada por Nombre de fantasía y/o Estado
            if (campo == "ID") condicional = (estado != "TODOS") ? WHERE2 : WHERE1; //Consulta filtrada por Denominación y/o Estado
            Proveedor objProveedor = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT2 + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "CUIT") comandoDB.Parameters.AddWithValue("@cuit", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "FANTASIA") comandoDB.Parameters.AddWithValue("@nombre_fantasia", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objProveedor = instanciarCompletamente(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos del proveedor e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006PROVEEDOR: Hay un conflicto en la consulta del proveedor.", e); }
            finally { _conexion.Dispose(); }
            return objProveedor;
        }

        public bool actualizar(Proveedor objProveedor)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objProveedor.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cuit", objProveedor.Cuit); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objProveedor.Id);
                                comandoDB_update.Parameters.AddWithValue("@denominacion", objProveedor.Denominacion);
                                comandoDB_update.Parameters.AddWithValue("@nombre_fantasia", objProveedor.NombreFantasia);
                                comandoDB_update.Parameters.AddWithValue("@cuit", objProveedor.Cuit);
                                comandoDB_update.Parameters.AddWithValue("@iva", objProveedor.Iva);
                                comandoDB_update.Parameters.AddWithValue("@domicilio", objProveedor.Domicilio);
                                comandoDB_update.Parameters.AddWithValue("@provincia", objProveedor.Provincia);
                                comandoDB_update.Parameters.AddWithValue("@distrito", objProveedor.Distrito);
                                comandoDB_update.Parameters.AddWithValue("@cp", objProveedor.Cp);
                                comandoDB_update.Parameters.AddWithValue("@telefono", objProveedor.Telefono);
                                comandoDB_update.Parameters.AddWithValue("@celular", objProveedor.Celular);
                                comandoDB_update.Parameters.AddWithValue("@email", objProveedor.Email);
                                comandoDB_update.Parameters.AddWithValue("@pagina_web", objProveedor.PaginaWeb);
                                comandoDB_update.Parameters.AddWithValue("@cta_bancaria_id", ((objProveedor.Banco != null) ? objProveedor.Banco.Id : 0));
                                comandoDB_update.Parameters.AddWithValue("@cta_bancaria_tipo", objProveedor.CtaBancariaTipo);
                                comandoDB_update.Parameters.AddWithValue("@cta_bancaria_nro", objProveedor.CtaBancariaNro);
                                comandoDB_update.Parameters.AddWithValue("@contacto_nom", objProveedor.ContactoDenominacion);
                                comandoDB_update.Parameters.AddWithValue("@contacto_tel", objProveedor.ContactoTelefono);
                                comandoDB_update.Parameters.AddWithValue("@contacto_cel", objProveedor.ContactoCelular);
                                comandoDB_update.Parameters.AddWithValue("@contacto_email", objProveedor.ContactoEmail);
                                comandoDB_update.Parameters.AddWithValue("@id_cuenta_contable", objProveedor.CuentaContable.Id);
                                comandoDB_update.Parameters.AddWithValue("@saldo", objProveedor.Saldo);
                                comandoDB_update.Parameters.AddWithValue("@estado", objProveedor.Estado);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objProveedor.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objProveedor.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objProveedor.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Proveedores", "Modificó el registro ID:" + objProveedor.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl CUIT ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M008PROVEEDOR", "M010PROVEEDOR", "M012PROVEEDOR", "M014PROVEEDOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool actualizarSaldo(long id, double saldo, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + WHERE1)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR_SALDO)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", id);
                                comandoDB_update.Parameters.AddWithValue("@saldo", saldo);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                if (notificarExito) Mensaje.Informacion("El nuevo saldo del proveedor ID:" + id.ToString() + "\nse registró correctamente.");
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro Inexistente.\nEl proveedor No se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M016PROVEEDOR", "M018PROVEEDOR", "M020PROVEEDOR", "M022PROVEEDOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool eliminar(Proveedor objProveedor)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ELIMINAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objProveedor.Id); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_delete = _conexion.crearComandoDB(ELIMINAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_delete.Parameters.AddWithValue("@id", objProveedor.Id);
                                comandoDB_delete.ExecuteNonQuery(); //Ejecuta el DELETE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Proveedores", "Eliminó el registro ID:" + objProveedor.Id + "."); //Registra la eliminación de un registro
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Inexistente.\nEl proveedor No se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M024PROVEEDOR", "M026PROVEEDOR", "M028PROVEEDOR", "M030PROVEEDOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(Proveedor objProveedor)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@cuit", objProveedor.Cuit); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objProveedor.Id);
                                comandoDB_insert.Parameters.AddWithValue("@denominacion", objProveedor.Denominacion);
                                comandoDB_insert.Parameters.AddWithValue("@nombre_fantasia", objProveedor.NombreFantasia);
                                comandoDB_insert.Parameters.AddWithValue("@cuit", objProveedor.Cuit);
                                comandoDB_insert.Parameters.AddWithValue("@iva", objProveedor.Iva);
                                comandoDB_insert.Parameters.AddWithValue("@domicilio", objProveedor.Domicilio);
                                comandoDB_insert.Parameters.AddWithValue("@provincia", objProveedor.Provincia);
                                comandoDB_insert.Parameters.AddWithValue("@distrito", objProveedor.Distrito);
                                comandoDB_insert.Parameters.AddWithValue("@cp", objProveedor.Cp);
                                comandoDB_insert.Parameters.AddWithValue("@telefono", objProveedor.Telefono);
                                comandoDB_insert.Parameters.AddWithValue("@celular", objProveedor.Celular);
                                comandoDB_insert.Parameters.AddWithValue("@email", objProveedor.Email);
                                comandoDB_insert.Parameters.AddWithValue("@pagina_web", objProveedor.PaginaWeb);
                                comandoDB_insert.Parameters.AddWithValue("@cta_bancaria_id", ((objProveedor.Banco != null) ? objProveedor.Banco.Id : 0));
                                comandoDB_insert.Parameters.AddWithValue("@cta_bancaria_tipo", objProveedor.CtaBancariaTipo);
                                comandoDB_insert.Parameters.AddWithValue("@cta_bancaria_nro", objProveedor.CtaBancariaNro);
                                comandoDB_insert.Parameters.AddWithValue("@contacto_nom", objProveedor.ContactoDenominacion);
                                comandoDB_insert.Parameters.AddWithValue("@contacto_tel", objProveedor.ContactoTelefono);
                                comandoDB_insert.Parameters.AddWithValue("@contacto_cel", objProveedor.ContactoCelular);
                                comandoDB_insert.Parameters.AddWithValue("@contacto_email", objProveedor.ContactoEmail);
                                comandoDB_insert.Parameters.AddWithValue("@id_cuenta_contable", objProveedor.CuentaContable.Id);
                                comandoDB_insert.Parameters.AddWithValue("@saldo", objProveedor.Saldo);
                                comandoDB_insert.Parameters.AddWithValue("@estado", objProveedor.Estado);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objProveedor.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objProveedor.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objProveedor.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Proveedores", "Agregó un nuevo registro ID:" + objProveedor.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl proveedor ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M032PROVEEDOR", "M034PROVEEDOR", "M036PROVEEDOR", "M038PROVEEDOR", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private Proveedor instanciarCompletamente(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Proveedor(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToString(lectorDB["nombre_fantasia"]),
                Convert.ToString(lectorDB["cuit"]),
                Convert.ToString(lectorDB["iva"]),
                Convert.ToString(lectorDB["domicilio"]),
                Convert.ToString(lectorDB["provincia"]),
                Convert.ToString(lectorDB["distrito"]),
                Convert.ToString(lectorDB["cp"]),
                Convert.ToString(lectorDB["telefono"]),
                Convert.ToString(lectorDB["celular"]),
                Convert.ToString(lectorDB["email"]),
                Convert.ToString(lectorDB["pagina_web"]),
                ((Convert.ToInt32(lectorDB["cta_bancaria_id"]) > 0) ? new D_Banco().obtenerObjeto("ID", Convert.ToString(lectorDB["cta_bancaria_id"]), false) : new Banco(0, "")),
                Convert.ToString(lectorDB["cta_bancaria_tipo"]),
                Convert.ToString(lectorDB["cta_bancaria_nro"]),
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable"]), false),
                Convert.ToDouble(lectorDB["saldo"]),
                Convert.ToString(lectorDB["contacto_nom"]),
                Convert.ToString(lectorDB["contacto_tel"]),
                Convert.ToString(lectorDB["contacto_cel"]),
                Convert.ToString(lectorDB["contacto_email"]),
                Convert.ToString(lectorDB["estado"]),
                Convert.ToDateTime(lectorDB["edicion_fecha"]),
                Convert.ToInt32(lectorDB["edicion_usuario_id"]),
                Convert.ToString(lectorDB["edicion_usuario"]));
        }

        private Proveedor instanciarParcialmente(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Proveedor(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToString(lectorDB["nombre_fantasia"]),
                Convert.ToString(lectorDB["cuit"]),
                Convert.ToDouble(lectorDB["saldo"]),
                Convert.ToString(lectorDB["estado"]));
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
