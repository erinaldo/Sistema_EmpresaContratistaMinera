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
    public class D_RentabilidadCentroCosto : IRentabilidadCentroCosto, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_rentabilidad_cc.*, data_centro_costo.denominacion As centro_costo";
        private const string FROM = @" FROM data_rentabilidad_cc 
            INNER JOIN data_centro_costo ON data_rentabilidad_cc.id_centro_costo = data_centro_costo.id";
        private const string WHERE1 = @" WHERE data_rentabilidad_cc.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE LOWER(data_centro_costo.denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Centro de Costo
        private const string WHERE3 = @" WHERE LOWER(data_centro_costo.denominacion) LIKE LOWER(@denominacion) AND data_rentabilidad_cc.estado = @estado"; //Filtrar Objeto por Centro de Costo y Estado
        private const string WHERE4 = @" WHERE periodo = @periodo"; //Filtrar Objeto por Periodo
        private const string WHERE5 = @" WHERE periodo = @periodo AND data_rentabilidad_cc.estado = @estado"; //Filtrar Objeto por Periodo y Estado
        private const string ORDER = @" ORDER BY data_rentabilidad_cc.periodo DESC, data_centro_costo.denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_rentabilidad_cc WHERE id <> @id AND id_centro_costo = @id_centro_costo AND periodo = @periodo"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ANULAR = @"SELECT * FROM data_rentabilidad_cc WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_rentabilidad_cc WHERE id_centro_costo = @id_centro_costo AND periodo = @periodo  AND estado = 'ACTIVO'"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_rentabilidad_cc SET 
            id = @id,
            id_centro_costo = @id_centro_costo,
            periodo = @periodo,
            estado = @estado,
            ppto_hh = @ppto_hh,
            ppto_importe = @ppto_importe,
            real_hh = @real_hh,
            real_importe = @real_importe,
            reajuste = @reajuste,
            total_importe = @total_importe,
            ppto_costo = @ppto_costo,
            ppto_utilidad = @ppto_utilidad,
            real_costo = @real_costo,
            real_utilidad = @real_utilidad,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ANULAR = @"UPDATE data_rentabilidad_cc SET estado = 'ANULADO' WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_rentabilidad_cc(id, id_centro_costo, periodo, estado,
            ppto_hh, ppto_importe, real_hh, real_importe, reajuste, total_importe, ppto_costo, ppto_utilidad,
            real_costo, real_utilidad, edicion_fecha, edicion_usuario_id, edicion_usuario)
            VALUES (@id, @id_centro_costo, @periodo, @estado, @ppto_hh, @ppto_importe, @real_hh, @real_importe,
            @reajuste, @total_importe, @ppto_costo, @ppto_utilidad, @real_costo, @real_utilidad, @edicion_fecha,
            @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string estado, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE3 : WHERE2; //Consulta filtrada por Centro de Costo y/o Estado
            if (campo == "PERIODO") condicional = (estado != "TODOS") ? WHERE5 : WHERE4; //Consulta filtrada por Periodo y/o Estado
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "PERIODO") comandoDB.Parameters.AddWithValue("@periodo", valor); //Agrega el parámetro en la condición del contador
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "PERIODO") comandoDB.Parameters.AddWithValue("@periodo", valor); //Agrega el parámetro en la condición de la consulta
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
                                        Convert.ToString(lectorDB["centro_costo"]).PadRight(25, ' ') +
                                            " | " + Convert.ToString(lectorDB["periodo"]).PadLeft(7, ' ') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadLeft(7, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["ppto_importe"])).PadLeft(12, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["real_importe"])).PadLeft(12, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["reajuste"])).PadLeft(12, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total_importe"])).PadLeft(12, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["ppto_costo"])).PadLeft(12, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["real_costo"])).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                else if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + Convert.ToString(lectorDB["centro_costo"]).PadRight(25, ' ') +
                                            " | " + Convert.ToString(lectorDB["periodo"]).PadLeft(7, ' ') +
                                            " | " + Convert.ToString(lectorDB["estado"]).PadLeft(7, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["ppto_importe"]))).PadLeft(12, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["real_importe"]))).PadLeft(12, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["reajuste"]))).PadLeft(12, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["total_importe"]))).PadLeft(12, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["ppto_costo"]))).PadLeft(12, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["real_costo"]))).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002RENTABILIDAD: Hay un conflicto en la consulta de la rentabilidad.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<RentabilidadCentroCosto> obtenerObjetos(string estado, string campo, string valor)
        {
            string condicional = "";
            if (campo == "DENOMINACION") condicional = (estado != "TODOS") ? WHERE3 : WHERE2; //Consulta filtrada por Centro de Costo y/o Estado
            if (campo == "PERIODO") condicional = (estado != "TODOS") ? WHERE5 : WHERE4; //Consulta filtrada por Periodo y/o Estado
            List<RentabilidadCentroCosto> ListaDeObjetos = new List<RentabilidadCentroCosto>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "PERIODO") comandoDB.Parameters.AddWithValue("@periodo", valor); //Agrega el parámetro en la condición de la consulta
                        if (estado != "TODOS") comandoDB.Parameters.AddWithValue("@estado", estado); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                RentabilidadCentroCosto objRentabilidadCentroCosto = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objRentabilidadCentroCosto); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004RENTABILIDAD: Hay un conflicto en la consulta de la rentabilidad.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public RentabilidadCentroCosto obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            RentabilidadCentroCosto objRentabilidadCentroCosto = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objRentabilidadCentroCosto = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos de la rentabilidad e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006RENTABILIDAD: Hay un conflicto en la consulta de la rentabilidad.", e); }
            finally { _conexion.Dispose(); }
            return objRentabilidadCentroCosto;
        }

        public bool actualizar(RentabilidadCentroCosto objRentabilidadCentroCosto)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_centro_costo", objRentabilidadCentroCosto.CentroCosto.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@periodo", objRentabilidadCentroCosto.Periodo); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objRentabilidadCentroCosto.Id);
                                comandoDB_update.Parameters.AddWithValue("@id_centro_costo", objRentabilidadCentroCosto.CentroCosto.Id);
                                comandoDB_update.Parameters.AddWithValue("@periodo", objRentabilidadCentroCosto.Periodo);
                                comandoDB_update.Parameters.AddWithValue("@estado", objRentabilidadCentroCosto.Estado);
                                comandoDB_update.Parameters.AddWithValue("@ppto_hh", objRentabilidadCentroCosto.TotalPresupuestoHH);
                                comandoDB_update.Parameters.AddWithValue("@ppto_importe", objRentabilidadCentroCosto.TotalPresupuestoImporte);
                                comandoDB_update.Parameters.AddWithValue("@real_hh", objRentabilidadCentroCosto.TotalRealHH);
                                comandoDB_update.Parameters.AddWithValue("@real_importe", objRentabilidadCentroCosto.TotalRealImporte);
                                comandoDB_update.Parameters.AddWithValue("@reajuste", objRentabilidadCentroCosto.Reajuste);
                                comandoDB_update.Parameters.AddWithValue("@total_importe", objRentabilidadCentroCosto.TotalImporte);
                                comandoDB_update.Parameters.AddWithValue("@ppto_costo", objRentabilidadCentroCosto.TotalCostoPresupuesto);
                                comandoDB_update.Parameters.AddWithValue("@ppto_utilidad", objRentabilidadCentroCosto.UtilidadPresupuesto);
                                comandoDB_update.Parameters.AddWithValue("@real_costo", objRentabilidadCentroCosto.TotalCostoReal);
                                comandoDB_update.Parameters.AddWithValue("@real_utilidad", objRentabilidadCentroCosto.UtilidadReal);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objRentabilidadCentroCosto.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objRentabilidadCentroCosto.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objRentabilidadCentroCosto.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Rentabilidad por Centro de Costo ", "Modificó el registro ID:" + objRentabilidadCentroCosto.Id.ToString() + "."); //Registra la actualización de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Inaccesible.\nEl registro de rentabilidad No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M008RENTABILIDAD", "M010RENTABILIDAD", "M012RENTABILIDAD", "M014RENTABILIDAD", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool anular(RentabilidadCentroCosto objRentabilidadCentroCosto)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ANULAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objRentabilidadCentroCosto.Id); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ANULAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objRentabilidadCentroCosto.Id);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Rentabilidad por Centro de Costo", "Anuló el registro de:" + objRentabilidadCentroCosto.CentroCosto.Denominacion + " (" + objRentabilidadCentroCosto.Periodo + ")."); //Registra la eliminación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Anulado.\nEl registro de rentabilidad ya se encuentra anulado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M016RENTABILIDAD", "M018RENTABILIDAD", "M020RENTABILIDAD", "M022RENTABILIDAD", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(RentabilidadCentroCosto objRentabilidadCentroCosto)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_centro_costo", objRentabilidadCentroCosto.CentroCosto.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@periodo", objRentabilidadCentroCosto.Periodo); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objRentabilidadCentroCosto.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_centro_costo", objRentabilidadCentroCosto.CentroCosto.Id);
                                comandoDB_insert.Parameters.AddWithValue("@periodo", objRentabilidadCentroCosto.Periodo);
                                comandoDB_insert.Parameters.AddWithValue("@estado", objRentabilidadCentroCosto.Estado);
                                comandoDB_insert.Parameters.AddWithValue("@ppto_hh", objRentabilidadCentroCosto.TotalPresupuestoHH);
                                comandoDB_insert.Parameters.AddWithValue("@ppto_importe", objRentabilidadCentroCosto.TotalPresupuestoImporte);
                                comandoDB_insert.Parameters.AddWithValue("@real_hh", objRentabilidadCentroCosto.TotalRealHH);
                                comandoDB_insert.Parameters.AddWithValue("@real_importe", objRentabilidadCentroCosto.TotalRealImporte);
                                comandoDB_insert.Parameters.AddWithValue("@reajuste", objRentabilidadCentroCosto.Reajuste);
                                comandoDB_insert.Parameters.AddWithValue("@total_importe", objRentabilidadCentroCosto.TotalImporte);
                                comandoDB_insert.Parameters.AddWithValue("@ppto_costo", objRentabilidadCentroCosto.TotalCostoPresupuesto);
                                comandoDB_insert.Parameters.AddWithValue("@ppto_utilidad", objRentabilidadCentroCosto.UtilidadPresupuesto);
                                comandoDB_insert.Parameters.AddWithValue("@real_costo", objRentabilidadCentroCosto.TotalCostoReal);
                                comandoDB_insert.Parameters.AddWithValue("@real_utilidad", objRentabilidadCentroCosto.UtilidadReal);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objRentabilidadCentroCosto.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objRentabilidadCentroCosto.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objRentabilidadCentroCosto.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Rentabilidad por Centro de Costo", "Agregó un nuevo registro ID:" + objRentabilidadCentroCosto.Id.ToString() + "."); //Registra la inserción de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl registro de rentabilidad ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M024RENTABILIDAD", "M026RENTABILIDAD", "M028RENTABILIDAD", "M030RENTABILIDAD", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private RentabilidadCentroCosto instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new RentabilidadCentroCosto(
                Convert.ToInt64(lectorDB["id"]),
                new D_CentroCosto().obtenerObjeto("ID", Convert.ToString(lectorDB["id_centro_costo"]), false),
                Convert.ToString(lectorDB["periodo"]),
                Convert.ToString(lectorDB["estado"]),
                Convert.ToInt32(lectorDB["ppto_hh"]),
                Convert.ToDouble(lectorDB["ppto_importe"]),
                Convert.ToInt32(lectorDB["real_hh"]),
                Convert.ToDouble(lectorDB["real_importe"]),
                Convert.ToDouble(lectorDB["reajuste"]),
                Convert.ToDouble(lectorDB["total_importe"]),
                Convert.ToDouble(lectorDB["ppto_costo"]),
                Convert.ToDouble(lectorDB["ppto_utilidad"]),
                Convert.ToDouble(lectorDB["real_costo"]),
                Convert.ToDouble(lectorDB["real_utilidad"]),
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
