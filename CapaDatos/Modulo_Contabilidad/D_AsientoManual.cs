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
    public class D_AsientoManual : IAsientoManual, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_asiento_manual.*,
              data_centro_costo.denominacion AS centro_costo";
        private const string FROM = @" FROM data_asiento_manual
            LEFT JOIN data_centro_costo ON data_asiento_manual.id_centro_costo = data_centro_costo.id";
        private const string WHERE1 = @" WHERE data_asiento_manual.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE (data_asiento_manual.cbte_tpv = @cbte_tpv AND data_asiento_manual.cbte_nro = @cbte_nro)"; //Filtrar Objeto por Comprobante (TPV y Nro. De Comprobante)
        private const string WHERE3 = @" WHERE LOWER(data_asiento_manual.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE4 = @" WHERE LOWER(data_asiento_manual.denominacion) LIKE LOWER(@denominacion) AND data_asiento_manual.estado = @estado"; //Filtrar Objeto por Denominación y Estado
        private const string WHERE5 = @" WHERE date(data_asiento_manual.cbte_fecha) >= date(@desde) AND date(data_asiento_manual.cbte_fecha) <= date(@hasta)"; //Filtrar Objeto por Fecha de Comprobante
        private const string WHERE6 = @" WHERE date(data_asiento_manual.cbte_fecha) >= date(@desde) AND date(data_asiento_manual.cbte_fecha) <= date(@hasta) AND data_asiento_manual.estado = @estado"; //Filtrar Objeto por Fecha de Comprobante y Estado
        private const string ORDER = @" ORDER BY data_asiento_manual.cbte_fecha DESC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_asiento_manual WHERE (cbte_tpv = @cbte_tpv AND cbte_nro = @cbte_nro) AND estado = 'ACTIVO' AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ANULAR = @"SELECT * FROM data_asiento_manual WHERE id = @id AND estado = 'ANULADO'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_asiento_manual WHERE (cbte_tpv = @cbte_tpv AND cbte_nro = @cbte_nro) AND estado = 'ACTIVO'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_asiento_manual SET 
            id = @id,
            cbte_tpv = @cbte_tpv,
            cbte_nro = @cbte_nro,
            cbte_fecha = @cbte_fecha,
            estado = @estado,
            denominacion = @denominacion,
            id_centro_costo = @id_centro_costo,
            total_debe = @total_debe,
            total_haber = @total_haber,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ANULAR = @"UPDATE data_asiento_manual SET estado = 'ANULADO' WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_asiento_manual(id, cbte_tpv, cbte_nro, cbte_fecha, estado,
            denominacion, id_centro_costo, total_debe, total_haber, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @cbte_tpv, @cbte_nro, @cbte_fecha, @estado, @denominacion, @id_centro_costo, @total_debe,
            @total_haber, @edicion_fecha, @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "COMPROBANTE") condicional = WHERE2; //Consulta filtrada por Comprobante (TPV y Nro. De Comprobante)
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE4 : WHERE3; //Consulta filtrada por Estado y/o Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_tpv", valor.Split('-')[0]); //Agrega el parámetro en la condición del contador
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_nro", valor.Split('-')[1]); //Agrega el parámetro en la condición del contador
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_tpv", valor.Split('-')[0]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_nro", valor.Split('-')[1]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición e la consulta
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
                                        Convert.ToString(lectorDB["cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(7, ' ') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToString(lectorDB["centro_costo"]).PadRight(25, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total_debe"])).PadLeft(11, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total_haber"])).PadLeft(11, ' '));
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
            catch (MySqlException e) { Mensaje.Error("Error-M002ASIENTO_MANUAL: Hay un conflicto en la consulta de los asientos manuales.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string estado, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "FECHA") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Estado y/o Fecha de Comprobante
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega el parámetro en la condición del contador
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
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
                                        Convert.ToString(lectorDB["cbte_tpv"]).PadLeft(5, '0') + "-" + Convert.ToString(lectorDB["cbte_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["cbte_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadRight(7, ' ') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(35, ' ') +
                                            " | " + Convert.ToString(lectorDB["centro_costo"]).PadRight(25, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total_debe"])).PadLeft(11, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total_haber"])).PadLeft(11, ' '));
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
            catch (MySqlException e) { Mensaje.Error("Error-M004ASIENTO_MANUAL: Hay un conflicto en la consulta de los asientos manuales.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<AsientoManual> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "COMPROBANTE") condicional = WHERE2; //Consulta filtrada por Comprobante (TPV y Nro. De Comprobante)
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE4 : WHERE3; //Consulta filtrada por Estado y/o Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            List<AsientoManual> ListaDeObjetos = new List<AsientoManual>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_tpv", valor.Split('-')[0]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "COMPROBANTE") comandoDB.Parameters.AddWithValue("@cbte_nro", valor.Split('-')[1]); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición e la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                AsientoManual objAsientoManual = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objAsientoManual); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006ASIENTO_MANUAL: Hay un conflicto en la consulta de los asientos manuales.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<AsientoManual> obtenerObjetos(string estado, string campo, DateTime desde, DateTime hasta)
        {
            string condicional = "";
            if (campo == "FECHA") condicional = (estado != "TODOS") ? WHERE6 : WHERE5; //Consulta filtrada por Estado y/o Fecha de Comprobante
            List<AsientoManual> ListaDeObjetos = new List<AsientoManual>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro terciario
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro terciario
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                AsientoManual objAsientoManual = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objAsientoManual); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008ASIENTO_MANUAL: Hay un conflicto en la consulta de los asientos manuales.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public AsientoManual obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            AsientoManual objAsientoManual = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objAsientoManual = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos del asiento manual e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010ASIENTO_MANUAL: Hay un conflicto en la consulta del asiento manual", e); }
            finally { _conexion.Dispose(); }
            return objAsientoManual;
        }

        public bool actualizar(AsientoManual objAsientoManual)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objAsientoManual.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cbte_tpv", objAsientoManual.CbteTPV); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cbte_nro", objAsientoManual.CbteNro); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objAsientoManual.Id);
                                comandoDB_update.Parameters.AddWithValue("@cbte_tpv", objAsientoManual.CbteTPV);
                                comandoDB_update.Parameters.AddWithValue("@cbte_nro", objAsientoManual.CbteNro);
                                comandoDB_update.Parameters.AddWithValue("@cbte_fecha", objAsientoManual.CbteFecha);
                                comandoDB_update.Parameters.AddWithValue("@estado", objAsientoManual.Estado);
                                comandoDB_update.Parameters.AddWithValue("@denominacion", objAsientoManual.Denominacion);
                                comandoDB_update.Parameters.AddWithValue("@id_centro_costo", objAsientoManual.CentroCosto.Id);
                                comandoDB_update.Parameters.AddWithValue("@total_debe", objAsientoManual.TotalDebe);
                                comandoDB_update.Parameters.AddWithValue("@total_haber", objAsientoManual.TotalHaber);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objAsientoManual.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objAsientoManual.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objAsientoManual.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Asientos Manuales", "Modificó el registro ID:" + objAsientoManual.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Inaccesible.\nEl asiento manual No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M012CBTE_ASIENTO_MANUAL", "M014CBTE_ASIENTO_MANUAL", "M016CBTE_ASIENTO_MANUAL", "M018CBTE_ASIENTO_MANUAL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool anular(AsientoManual objAsientoManual)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ANULAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objAsientoManual.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ANULAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objAsientoManual.Id);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Asientos Manuales", "Anuló el registro Id:" + objAsientoManual.Id + "."); //Registra la eliminación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Anulado.\nEl asiento manual ya se encuentra anulado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M020CBTE_ASIENTO_MANUAL", "M022CBTE_ASIENTO_MANUAL", "M024CBTE_ASIENTO_MANUAL", "M026CBTE_ASIENTO_MANUAL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(AsientoManual objAsientoManual)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@cbte_tpv", objAsientoManual.CbteTPV); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@cbte_nro", objAsientoManual.CbteNro); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objAsientoManual.Id);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_tpv", objAsientoManual.CbteTPV);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_nro", objAsientoManual.CbteNro);
                                comandoDB_insert.Parameters.AddWithValue("@cbte_fecha", objAsientoManual.CbteFecha);
                                comandoDB_insert.Parameters.AddWithValue("@estado", objAsientoManual.Estado);
                                comandoDB_insert.Parameters.AddWithValue("@denominacion", objAsientoManual.Denominacion);
                                comandoDB_insert.Parameters.AddWithValue("@id_centro_costo", objAsientoManual.CentroCosto.Id);
                                comandoDB_insert.Parameters.AddWithValue("@total_debe", objAsientoManual.TotalDebe);
                                comandoDB_insert.Parameters.AddWithValue("@total_haber", objAsientoManual.TotalHaber);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objAsientoManual.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objAsientoManual.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objAsientoManual.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Asientos Manuales", "Agregó un nuevo registro ID:" + objAsientoManual.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl asiento manual ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M028CBTE_ASIENTO_MANUAL", "M030CBTE_ASIENTO_MANUAL", "M032CBTE_ASIENTO_MANUAL", "M034CBTE_ASIENTO_MANUAL", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private AsientoManual instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new AsientoManual(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToInt32(lectorDB["cbte_tpv"]),
                Convert.ToInt64(lectorDB["cbte_nro"]),
                Convert.ToDateTime(lectorDB["cbte_fecha"]),
                Convert.ToString(lectorDB["estado"]),
                Convert.ToString(lectorDB["denominacion"]),
                new D_CentroCosto().obtenerObjeto("ID", Convert.ToString(lectorDB["id_centro_costo"]), false),
                Convert.ToDouble(lectorDB["total_debe"]),
                Convert.ToDouble(lectorDB["total_haber"]),
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