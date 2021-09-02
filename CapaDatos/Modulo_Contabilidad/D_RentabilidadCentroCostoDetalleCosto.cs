using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_RentabilidadCentroCostoDetalleCosto : IRentabilidadCentroCostoDetalleCosto, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_rentabilidad_cc_detalle_costo.*,
            data_cuenta_contable.tipo_cuenta, data_cuenta_contable.denominacion AS cuenta_contable";
        private const string FROM = @" FROM data_rentabilidad_cc_detalle_costo 
            INNER JOIN data_rentabilidad_cc ON data_rentabilidad_cc_detalle_costo.id_rentabilidad = data_rentabilidad_cc.id
            INNER JOIN data_cuenta_contable ON data_rentabilidad_cc_detalle_costo.id_cuenta_contable = data_cuenta_contable.id";
        private const string WHERE1 = @" WHERE data_rentabilidad_cc_detalle_costo.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_rentabilidad_cc_detalle_costo.id_rentabilidad = @id_rentabilidad"; //Filtrar Objeto por ID Orden de cobro
        private const string WHERE3 = @" WHERE data_rentabilidad_cc_detalle_costo.id_rentabilidad = @id_rentabilidad && data_cuenta_contable.tipo_cuenta = @tipo_cuenta"; //Filtrar Objeto por ID Orden de cobro
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_rentabilidad_cc_detalle_costo WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_rentabilidad_cc_detalle_costo WHERE id = @id "; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_rentabilidad_cc_detalle_costo SET 
            id = @id,
            id_rentabilidad = @id_rentabilidad,
            id_cuenta_contable = @id_cuenta_contable,
            ppto_costo = @ppto_costo,
            ppto_incidencia = @ppto_incidencia,
            real_costo = @real_costo,
            real_incidencia = @real_incidencia WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_rentabilidad_cc_detalle_costo(id, id_rentabilidad, 
            id_cuenta_contable, ppto_costo, ppto_incidencia, real_costo, real_incidencia)
            VALUES (@id, @id_rentabilidad, @id_cuenta_contable, @ppto_costo, @ppto_incidencia, @real_costo,
            @real_incidencia)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "ID_RENTABILIDAD") condicional = WHERE2; //Consulta filtrada por ID del Asiento Manual
            List<RentabilidadCentroCostoDetalleCosto> ListaDeObjetos = new List<RentabilidadCentroCostoDetalleCosto>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ID_RENTABILIDAD") comandoDB.Parameters.AddWithValue("@id_rentabilidad", valor); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ID_RENTABILIDAD") comandoDB.Parameters.AddWithValue("@id_rentabilidad", valor); //Agrega un parámetro al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                RentabilidadCentroCostoDetalleCosto objRentabilidadCentroCostoDetalleCosto = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objRentabilidadCentroCostoDetalleCosto); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                    string tipoCuentaContableAntecesor = ""; //Importante: Almacena el Tipo de Cuenta Contable Antecesor
                    int contador = 0;
                    foreach (RentabilidadCentroCostoDetalleCosto objDetalleCosto in ListaDeObjetos)
                    {
                        List<RentabilidadCentroCostoDetalleCosto> detalleCostoPorTipoCuentaContable = obtenerObjetos(objDetalleCosto.RentabilidadCentroCosto.Id, objDetalleCosto.CuentaContable.TipoCuenta); //Importante: Almacena los registros por Tipo de Cuenta Contable
                        string tipoCuentaContableActual = objDetalleCosto.CuentaContable.TipoCuenta.Split('>')[1].Trim();
                        contador = (tipoCuentaContableActual != tipoCuentaContableAntecesor) ? detalleCostoPorTipoCuentaContable.Count : (contador - 1);
                        if (catalogo == "CATALOGO1")
                        {
                            CatalogoBase elemento = new CatalogoBase(
                                objDetalleCosto.Id,
                                tipoCuentaContableActual.PadLeft(20, ' ') +
                                    " | " + objDetalleCosto.CuentaContable.Denominacion.PadRight(25, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(objDetalleCosto.PresupuestoCosto).PadLeft(12, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(objDetalleCosto.PresupuestoCostoIncidencia).PadLeft(6, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(objDetalleCosto.RealCosto).PadLeft(12, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(objDetalleCosto.RealCostoIncidencia).PadLeft(6, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(objDetalleCosto.PresupuestoCosto - objDetalleCosto.RealCosto).PadLeft(12, ' ') +
                                    " | " + Formulario.ValidarCampoMoneda(objDetalleCosto.PresupuestoCostoIncidencia - objDetalleCosto.RealCostoIncidencia).PadLeft(6, ' '));
                            ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                        }
                        if (catalogo == "CATALOGO2")
                        {
                            CatalogoBase elemento = new CatalogoBase(
                                objDetalleCosto.Id,
                                ("").PadLeft(20, ' ') +
                                    " | " + objDetalleCosto.CuentaContable.Denominacion.PadRight(25, ' ') +
                                    " | " + ("$" + Formulario.ValidarCampoMoneda(objDetalleCosto.PresupuestoCosto)).PadLeft(12, ' ') +
                                    " | " + ("%" + Formulario.ValidarCampoMoneda(objDetalleCosto.PresupuestoCostoIncidencia)).PadLeft(12, ' ') +
                                    " | " + ("$" + Formulario.ValidarCampoMoneda(objDetalleCosto.RealCosto)).PadLeft(12, ' ') +
                                    " | " + ("%" + Formulario.ValidarCampoMoneda(objDetalleCosto.RealCostoIncidencia)).PadLeft(12, ' ') +
                                    " | " + ("$" + Formulario.ValidarCampoMoneda(Math.Round(objDetalleCosto.PresupuestoCosto - objDetalleCosto.RealCosto, 2))).PadLeft(12, ' ') +
                                    " | " + ("%" + Formulario.ValidarCampoMoneda(Math.Round(objDetalleCosto.PresupuestoCostoIncidencia - objDetalleCosto.RealCostoIncidencia, 2))).PadLeft(12, ' '));
                            ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                            #region Fila Tipo Total
                            if (contador == 1)
                            {
                                double totalCuentaContable_PresupuestoCosto = 0.00;
                                double totalCuentaContable_PresupuestoIncidencia = 0.00;
                                double totalCuentaContable_RealCosto = 0.00;
                                double totalCuentaContable_RealIncidencia = 0.00;
                                double totalCuentaContable_DiferenciaCosto = 0.00;
                                double totalCuentaContable_DiferenciaIncidencia = 0.00;
                                foreach (RentabilidadCentroCostoDetalleCosto item in detalleCostoPorTipoCuentaContable) //Recorre el detalle del Costo para calcular los totales
                                {
                                    totalCuentaContable_PresupuestoCosto += item.PresupuestoCosto;
                                    totalCuentaContable_PresupuestoIncidencia += item.PresupuestoCostoIncidencia;
                                    totalCuentaContable_RealCosto += item.RealCosto;
                                    totalCuentaContable_RealIncidencia += item.RealCostoIncidencia;
                                    totalCuentaContable_DiferenciaCosto += (item.PresupuestoCosto - item.RealCosto);
                                    totalCuentaContable_DiferenciaIncidencia += (item.PresupuestoCostoIncidencia - item.RealCostoIncidencia);
                                }
                                CatalogoBase elementoTotal = new CatalogoBase(
                                    10000000 + contador, //Id temporal
                                    tipoCuentaContableActual.PadLeft(20, ' ') +
                                        " | " + ("SUBTOTAL:").PadRight(25, ' ') +
                                        " | " + ("$" + Formulario.ValidarCampoMoneda(Math.Round(totalCuentaContable_PresupuestoCosto, 2))).PadLeft(12, ' ') +
                                        " | " + ("%" + Formulario.ValidarCampoMoneda(Math.Round(totalCuentaContable_PresupuestoIncidencia, 2))).PadLeft(12, ' ') +
                                        " | " + ("$" + Formulario.ValidarCampoMoneda(Math.Round(totalCuentaContable_RealCosto, 2))).PadLeft(12, ' ') +
                                        " | " + ("%" + Formulario.ValidarCampoMoneda(Math.Round(totalCuentaContable_RealIncidencia, 2))).PadLeft(12, ' ') +
                                        " | " + ("$" + Formulario.ValidarCampoMoneda(Math.Round(totalCuentaContable_DiferenciaCosto, 2))).PadLeft(12, ' ') +
                                        " | " + ("%" + Formulario.ValidarCampoMoneda(Math.Round(totalCuentaContable_DiferenciaIncidencia, 2))).PadLeft(12, ' '));
                                ListaDeElementos.Add(elementoTotal); //Agrega el Total a la lista de elementos
                            }
                            #endregion
                            tipoCuentaContableAntecesor = tipoCuentaContableActual; //Importante: Iguala el Tipo de Cuenta Contable Antecesor con la Cuenta Contable actual 
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002RENTABILIDAD_DETALLE_COSTO: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<RentabilidadCentroCostoDetalleCosto> obtenerObjetos(long idRentabilidad)
        {
            List<RentabilidadCentroCostoDetalleCosto> ListaDeObjetos = new List<RentabilidadCentroCostoDetalleCosto>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE2)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_rentabilidad", idRentabilidad); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                RentabilidadCentroCostoDetalleCosto objRentabilidadCentroCostoDetalleCosto = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objRentabilidadCentroCostoDetalleCosto); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004RENTABILIDAD_DETALLE_COSTO: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<RentabilidadCentroCostoDetalleCosto> obtenerObjetos(long idRentabilidad, string tipoCuenta)
        {
            List<RentabilidadCentroCostoDetalleCosto> ListaDeObjetos = new List<RentabilidadCentroCostoDetalleCosto>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE3)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id_rentabilidad", idRentabilidad); //Agrega un parámetro al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@tipo_cuenta", tipoCuenta); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                RentabilidadCentroCostoDetalleCosto objRentabilidadCentroCostoDetalleCosto = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objRentabilidadCentroCostoDetalleCosto); //Agrega este Objeto a la lista de Objetos
                             }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006RENTABILIDAD_DETALLE_COSTO: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<RentabilidadCentroCostoDetalleCosto> obtenerObjetos(string campo, string valor)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID del Detalle
            if (campo == "ID_RENTABILIDAD") condicional = WHERE2; //Consulta filtrada por ID del Asiento Manual
            List<RentabilidadCentroCostoDetalleCosto> ListaDeObjetos = new List<RentabilidadCentroCostoDetalleCosto>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_RENTABILIDAD") comandoDB.Parameters.AddWithValue("@id_rentabilidad", valor); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                RentabilidadCentroCostoDetalleCosto objRentabilidadCentroCostoDetalleCosto = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objRentabilidadCentroCostoDetalleCosto); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008RENTABILIDAD_DETALLE_COSTO: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public RentabilidadCentroCostoDetalleCosto obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            RentabilidadCentroCostoDetalleCosto objRentabilidadCentroCostoDetalleCosto = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objRentabilidadCentroCostoDetalleCosto = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
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
            catch (MySqlException e) { Mensaje.Error("Error-M010RENTABILIDAD_DETALLE_COSTO: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return objRentabilidadCentroCostoDetalleCosto;
        }

        public bool insertar(RentabilidadCentroCostoDetalleCosto objRentabilidadCentroCostoDetalleCosto)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objRentabilidadCentroCostoDetalleCosto.Id); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objRentabilidadCentroCostoDetalleCosto.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_rentabilidad", objRentabilidadCentroCostoDetalleCosto.RentabilidadCentroCosto.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_cuenta_contable", objRentabilidadCentroCostoDetalleCosto.CuentaContable.Id);
                                comandoDB_insert.Parameters.AddWithValue("@ppto_costo", objRentabilidadCentroCostoDetalleCosto.PresupuestoCosto);
                                comandoDB_insert.Parameters.AddWithValue("@ppto_incidencia", objRentabilidadCentroCostoDetalleCosto.PresupuestoCostoIncidencia);
                                comandoDB_insert.Parameters.AddWithValue("@real_costo", objRentabilidadCentroCostoDetalleCosto.RealCosto);
                                comandoDB_insert.Parameters.AddWithValue("@real_incidencia", objRentabilidadCentroCostoDetalleCosto.RealCostoIncidencia);
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
                Mensaje.Advertencia("Detalle del comprobante Existente.\nEl detalle del comprobante ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M012RENTABILIDAD_DETALLE_COSTO", "M014RENTABILIDAD_DETALLE_COSTO", "M016RENTABILIDAD_DETALLE_COSTO", "M018RENTABILIDAD_DETALLE_COSTO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private RentabilidadCentroCostoDetalleCosto instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new RentabilidadCentroCostoDetalleCosto(
                Convert.ToInt64(lectorDB["id"]),
                new D_RentabilidadCentroCosto().obtenerObjeto("ID", Convert.ToString(lectorDB["id_rentabilidad"]), false),
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable"]), false),
                Convert.ToDouble(lectorDB["ppto_costo"]),
                Convert.ToDouble(lectorDB["ppto_incidencia"]),
                Convert.ToDouble(lectorDB["real_costo"]),
                Convert.ToDouble(lectorDB["real_incidencia"]));
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