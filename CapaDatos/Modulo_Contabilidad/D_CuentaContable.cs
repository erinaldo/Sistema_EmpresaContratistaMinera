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
    public class D_CuentaContable : ICuentaContable, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT1 = @"SELECT data_cuenta_contable.*";
        private const string FROM = @" FROM data_cuenta_contable";
        private const string WHERE1 = @" WHERE id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE codigo = @codigo"; //Filtrar Objeto por Código de Cuenta
        private const string WHERE3 = @" WHERE LOWER(tipo_cuenta) LIKE LOWER(@tipo_cuenta) AND codigo = @codigo"; //Filtrar Objeto por Rama Principal y Código de Cuenta
        private const string WHERE4 = @" WHERE LOWER(denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE5 = @" WHERE LOWER(tipo_cuenta) LIKE LOWER(@tipo_cuenta) AND LOWER(denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Rama Principal y Denominación
        private const string ORDER = @" ORDER BY data_cuenta_contable.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_cuenta_contable WHERE denominacion = @denominacion AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_cuenta_contable WHERE denominacion = @denominacion"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_cuenta_contable SET 
            id = @id,
            codigo = @codigo,
            denominacion = @denominacion,
            tipo_cuenta = @tipo_cuenta,
            saldo = @saldo,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ACTUALIZAR_SALDO = @"UPDATE data_cuenta_contable SET saldo = @saldo WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_cuenta_contable (id, codigo, denominacion, tipo_cuenta,
            saldo, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @codigo, @denominacion, @tipo_cuenta, @saldo, @edicion_fecha, @edicion_usuario_id, 
            @edicion_usuario)";
        #endregion

        #region Métodos
        public List<string> obtenerListaDeElementos(string[] ramaContable, bool exclusionDeCuenta)
        {
            List<string> listaDeElementos = new List<string>(); //Crea una lista de Objetos para almacenar los registros del tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + ORDER)) //Crea un comando de Base de Datos
                    {
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader()) //Ejecuta una consulta en la Base de Datos
                        {
                            while (lectorDB.Read())
                            {
                                if (lectorDB != null && ramaContable.Length > 0)
                                {
                                    foreach (string rama in ramaContable)
                                    {
                                        if (exclusionDeCuenta == false && Convert.ToString(lectorDB["tipo_cuenta"]).Contains(rama)) listaDeElementos.Add(Convert.ToString(lectorDB["denominacion"])); //Agrega el/los elemento(s) especifico(s) a la lista de elementos 
                                        else if (exclusionDeCuenta == true && !Convert.ToString(lectorDB["tipo_cuenta"]).Contains(rama)) listaDeElementos.Add(Convert.ToString(lectorDB["denominacion"])); //Excluye el/los elemento(s) de la lista de elementos (Agrega el/los No Excluidos)
                                    }
                                }
                                else listaDeElementos.Add(Convert.ToString(lectorDB["denominacion"])); //Agrega el elemento a la lista de elementos
                             }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002CUENTA_CONTABLE: Hay un conflicto en la consulta de la lista contables.", e); }
            finally { _conexion.Dispose(); }
            return listaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string ramaPrincipal, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "CODIGO") condicional = (ramaPrincipal != "TODOS") ? WHERE3 : WHERE2; //Consulta filtrada por Rama Principal y/o Código de Cuenta
            if (campo == "DENOMINACION") condicional = (ramaPrincipal != "TODOS") ? WHERE5 : WHERE4; //Consulta filtrada por Rama Principal y/o Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CODIGO") comandoDB.Parameters.AddWithValue("@codigo", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
                        if (ramaPrincipal != "TODOS") comandoDB.Parameters.AddWithValue("@tipo_cuenta", "%" + ramaPrincipal + "%"); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CODIGO") comandoDB.Parameters.AddWithValue("@codigo", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        if (ramaPrincipal != "TODOS") comandoDB.Parameters.AddWithValue("@tipo_cuenta", "%" + ramaPrincipal + "%"); //Agrega el parámetro en la condición de la consulta
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
                                        Convert.ToString(lectorDB["codigo"]).PadLeft(6, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(25, ' ') +
                                            " | " + Convert.ToString(lectorDB["tipo_cuenta"]).PadRight(65, ' ').Substring(7, 58) +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["saldo"])).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                else if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                         Convert.ToInt64(lectorDB["id"]),
                                         Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + Convert.ToString(lectorDB["codigo"]).PadLeft(6, '0') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(25, ' ') +
                                            " | " + Convert.ToString(lectorDB["tipo_cuenta"]).PadRight(65, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["saldo"])).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004CUENTA_CONTABLE: Hay un conflicto en la consulta de la cuenta.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CuentaContable> obtenerObjetos(string ramaPrincipal, string campo, string valor)
        {
            string condicional = "";
            if (campo == "CODIGO") condicional = (ramaPrincipal != "TODOS") ? WHERE3 : WHERE2; //Consulta filtrada por Rama Principal y/o Código de Cuenta
            if (campo == "DENOMINACION") condicional = (ramaPrincipal != "TODOS") ? WHERE5 : WHERE4; //Consulta filtrada por Rama Principal y/o Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            List<CuentaContable> ListaDeObjetos = new List<CuentaContable>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos

                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CODIGO") comandoDB.Parameters.AddWithValue("@codigo", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        if (ramaPrincipal != "TODOS") comandoDB.Parameters.AddWithValue("@tipo_cuenta", "%" + ramaPrincipal + "%"); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                CuentaContable objCuentaContable = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objCuentaContable); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006CUENTA_CONTABLE: Hay un conflicto en la consulta de la cuenta.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public CuentaContable obtenerObjeto(string campo, string valor, bool notificarExito = false)
        {
            string condicional = "";
            if (campo == "CODIGO") condicional = WHERE2; //Consulta filtrada por Código de Cuenta
            if (campo == "DENOMINACION") condicional = WHERE4; //Consulta filtrada por Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            CuentaContable objCuentaContable = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "CODIGO") comandoDB.Parameters.AddWithValue("@codigo", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objCuentaContable = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Cuenta solicitada No hallado.\nVerifique los datos de cuenta contable e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008CUENTA_CONTABLE: Hay un conflicto en la consulta del pago.", e); }
            finally { _conexion.Dispose(); }
            return objCuentaContable;
        }

        public bool actualizar(CuentaContable objCuentaContable)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objCuentaContable.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@denominacion", objCuentaContable.Denominacion); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objCuentaContable.Id);
                                comandoDB_update.Parameters.AddWithValue("@codigo", objCuentaContable.Codigo);
                                comandoDB_update.Parameters.AddWithValue("@denominacion", objCuentaContable.Denominacion);
                                comandoDB_update.Parameters.AddWithValue("@tipo_cuenta", objCuentaContable.TipoCuenta);
                                comandoDB_update.Parameters.AddWithValue("@saldo", objCuentaContable.Saldo);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objCuentaContable.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objCuentaContable.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objCuentaContable.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Plan de Cuentas", "Modificó el registro ID:" + objCuentaContable.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Inaccesible.\nLa cuenta contable No se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M010CBTE_COBRO", "M012CBTE_COBRO", "M014CBTE_COBRO", "M016CBTE_COBRO", e); }
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
                                if (notificarExito) Mensaje.Informacion("El nuevo saldo de la cuenta contable ID:" + id.ToString() + "\nse registró correctamente.");
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro Inexistente.\nLa cuenta contable No se encuentra registrada en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M018CUENTA_CONTABLE", "M020CUENTA_CONTABLE", "M022CUENTA_CONTABLE", "M024CUENTA_CONTABLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(CuentaContable objCuentaContable)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@denominacion", objCuentaContable.Denominacion); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            //Crea un comando de Base de Datos
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR))
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objCuentaContable.Id);
                                comandoDB_insert.Parameters.AddWithValue("@codigo", objCuentaContable.Codigo);
                                comandoDB_insert.Parameters.AddWithValue("@denominacion", objCuentaContable.Denominacion);
                                comandoDB_insert.Parameters.AddWithValue("@tipo_cuenta", objCuentaContable.TipoCuenta);
                                comandoDB_insert.Parameters.AddWithValue("@saldo", objCuentaContable.Saldo);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objCuentaContable.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objCuentaContable.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objCuentaContable.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Plan de Cuentas", "Agregó un nuevo registro ID:" + objCuentaContable.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nLa cuenta contable ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M026CUENTA_CONTABLE", "M028CUENTA_CONTABLE", "M030CUENTA_CONTABLE", "M032CUENTA_CONTABLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private CuentaContable instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new CuentaContable(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToString(lectorDB["codigo"]),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToString(lectorDB["tipo_cuenta"]),
                Convert.ToDouble(lectorDB["saldo"]),
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
