using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_RentabilidadCentroCostoDetalleImporte : IRentabilidadCentroCostoDetalleImporte, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_rentabilidad_cc_detalle_importe.*";
        private const string FROM = @" FROM data_rentabilidad_cc_detalle_importe 
            INNER JOIN data_rentabilidad_cc ON data_rentabilidad_cc_detalle_importe.id_rentabilidad = data_rentabilidad_cc.id";
        private const string WHERE1 = @" WHERE data_rentabilidad_cc_detalle_importe.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE data_rentabilidad_cc_detalle_importe.id_rentabilidad = @id_rentabilidad"; //Filtrar Objeto por ID Orden de cobro
        private const string ORDER = @" ORDER BY data_rentabilidad_cc_detalle_importe.id ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_rentabilidad_cc_detalle_importe WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_rentabilidad_cc_detalle_importe WHERE id = @id "; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_rentabilidad_cc_detalle_importe SET 
            id = @id,
            id_rentabilidad = @id_rentabilidad,
            denominacion = @denominacion,
            valor_hora = @valor_hora,
            ppto_hh = @ppto_hh,
            ppto_importe = @ppto_importe,
            real_hh = @real_hh,
            real_importe = @real_importe WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_rentabilidad_cc_detalle_importe(id, id_rentabilidad,
            denominacion, valor_hora, ppto_hh, ppto_importe, real_hh, real_importe)
            VALUES (@id, @id_rentabilidad, @denominacion, @valor_hora, @ppto_hh, @ppto_importe, @real_hh,
            @real_importe)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "ID_RENTABILIDAD") condicional = WHERE2; //Consulta filtrada por ID del Asiento Manual
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
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ID_RENTABILIDAD") comandoDB.Parameters.AddWithValue("@id_rentabilidad", valor); //Agrega un parámetro al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                double valorHora = Formulario.ValidarNumeroDoble(Convert.ToString(lectorDB["valor_hora"]));
                                double presupuestoHH = Formulario.ValidarNumeroDoble(Convert.ToString(lectorDB["ppto_hh"]));
                                double presupuestoImporte = Formulario.ValidarNumeroDoble(Convert.ToString(lectorDB["ppto_importe"]));
                                double realHH = Formulario.ValidarNumeroDoble(Convert.ToString(lectorDB["real_hh"]));
                                double realImporte = Formulario.ValidarNumeroDoble(Convert.ToString(lectorDB["real_importe"]));
                                double diferenciaHH = (realHH - presupuestoHH);
                                double diferenciaImporte = (realImporte - presupuestoImporte);
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["denominacion"]).PadRight(25, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(valorHora).PadLeft(6, ' ') +
                                            " | " + Convert.ToString(presupuestoHH).PadLeft(12, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(presupuestoImporte).PadLeft(12, ' ') +
                                            " | " + Convert.ToString(realHH).PadLeft(6, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(realImporte).PadLeft(12, ' ') +
                                            " | " + Convert.ToString(diferenciaHH).PadLeft(6, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(diferenciaImporte).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["denominacion"]).PadRight(25, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(valorHora)).PadLeft(12, ' ') +
                                            " | " + Convert.ToString(presupuestoHH).PadLeft(12, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(presupuestoImporte)).PadLeft(12, ' ') +
                                            " | " + Convert.ToString(realHH).PadLeft(12, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(realImporte)).PadLeft(12, ' ') +
                                            " | " + Convert.ToString(diferenciaHH).PadLeft(12, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(diferenciaImporte)).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002RENTABILIDAD_DETALLE_IMPORTE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<RentabilidadCentroCostoDetalleImporte> obtenerObjetos(long idRentabilidad)
        {
            List<RentabilidadCentroCostoDetalleImporte> ListaDeObjetos = new List<RentabilidadCentroCostoDetalleImporte>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE2 + ORDER)) //Crea un comando de Base de Datos
                {
                    comandoDB.Parameters.AddWithValue("@id_rentabilidad", idRentabilidad); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                RentabilidadCentroCostoDetalleImporte objRentabilidadCentroCostoDetalleImporte = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objRentabilidadCentroCostoDetalleImporte); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004RENTABILIDAD_DETALLE_IMPORTE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<RentabilidadCentroCostoDetalleImporte> obtenerObjetos(string campo, string valor)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID del Detalle
            if (campo == "ID_RENTABILIDAD") condicional = WHERE2; //Consulta filtrada por ID del Asiento Manual
            List<RentabilidadCentroCostoDetalleImporte> ListaDeObjetos = new List<RentabilidadCentroCostoDetalleImporte>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al comando de Base de Datos
                        if (campo == "ID_RENTABILIDAD") comandoDB.Parameters.AddWithValue("@id_rentabilidad", valor); //Agrega un parámetro al comando de Base de Datos
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                RentabilidadCentroCostoDetalleImporte objRentabilidadCentroCostoDetalleImporte = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objRentabilidadCentroCostoDetalleImporte); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006RENTABILIDAD_DETALLE_IMPORTE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public RentabilidadCentroCostoDetalleImporte obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            RentabilidadCentroCostoDetalleImporte objRentabilidadCentroCostoDetalleImporte = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
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
                                    objRentabilidadCentroCostoDetalleImporte = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
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
            catch (MySqlException e) { Mensaje.Error("Error-M008RENTABILIDAD_DETALLE_IMPORTE: Hay un conflicto en la consulta del detalle del comprobante.", e); }
            finally { _conexion.Dispose(); }
            return objRentabilidadCentroCostoDetalleImporte;
        }

        public bool insertar(RentabilidadCentroCostoDetalleImporte objRentabilidadCentroCostoDetalleImporte)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objRentabilidadCentroCostoDetalleImporte.Id); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objRentabilidadCentroCostoDetalleImporte.Id);
                                comandoDB_insert.Parameters.AddWithValue("@id_rentabilidad", objRentabilidadCentroCostoDetalleImporte.RentabilidadCentroCosto.Id);
                                comandoDB_insert.Parameters.AddWithValue("@denominacion", objRentabilidadCentroCostoDetalleImporte.Denominacion);
                                comandoDB_insert.Parameters.AddWithValue("@valor_hora", objRentabilidadCentroCostoDetalleImporte.ValorHora);
                                comandoDB_insert.Parameters.AddWithValue("@ppto_hh", objRentabilidadCentroCostoDetalleImporte.PresupuestoHH);
                                comandoDB_insert.Parameters.AddWithValue("@ppto_importe", objRentabilidadCentroCostoDetalleImporte.PresupuestoImporte);
                                comandoDB_insert.Parameters.AddWithValue("@real_hh", objRentabilidadCentroCostoDetalleImporte.RealHH);
                                comandoDB_insert.Parameters.AddWithValue("@real_importe", objRentabilidadCentroCostoDetalleImporte.RealImporte);
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
            catch (MySqlException e) { Mensaje.ErrorMySql("M010RENTABILIDAD_DETALLE_IMPORTE", "M012RENTABILIDAD_DETALLE_IMPORTE", "M014RENTABILIDAD_DETALLE_IMPORTE", "M016RENTABILIDAD_DETALLE_IMPORTE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private RentabilidadCentroCostoDetalleImporte instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new RentabilidadCentroCostoDetalleImporte(
                Convert.ToInt64(lectorDB["id"]),
                new D_RentabilidadCentroCosto().obtenerObjeto("ID", Convert.ToString(lectorDB["id_rentabilidad"]), false),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToDouble(lectorDB["valor_hora"]),
                Convert.ToInt32(lectorDB["ppto_hh"]),
                Convert.ToDouble(lectorDB["ppto_importe"]),
                Convert.ToInt32(lectorDB["real_hh"]),
                Convert.ToDouble(lectorDB["real_importe"]));
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