using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_AsientoContable : IAsientoContable, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT1 = @"SELECT data_asiento_contable.*,
            data_cuenta_contable.denominacion AS cuenta_contable";
        private const string FROM = @" FROM data_asiento_contable
            INNER JOIN data_cuenta_contable ON data_asiento_contable.id_cuenta_contable = data_cuenta_contable.id";
        private const string WHERE1 = @" WHERE data_asiento_contable.id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE asiento_nro = @asiento_nro"; //Filtrar Objeto por Número de Asiento
        private const string WHERE3 = @" WHERE origen_tipo = @origen_tipo AND origen_id = @origen_id"; //Filtrar Objeto por Tipo e ID de Origen
        private const string WHERE4 = @" WHERE LOWER(descripcion) LIKE LOWER(@descripcion)"; //Filtrar Objeto por Descripción
        private const string WHERE5 = @" WHERE LOWER(descripcion) LIKE LOWER(@descripcion) AND id_cuenta_contable = @id_cuenta_contable"; //Filtrar Objeto por Descripción y Cuenta Contable
        private const string WHERE6 = @" WHERE date(asiento_fecha) >= date(@desde) AND date(asiento_fecha) <= date(@hasta)"; //Filtrar Objeto por Denominación
        private const string WHERE7 = @" WHERE date(asiento_fecha) >= date(@desde) AND date(asiento_fecha) <= date(@hasta) AND id_cuenta_contable = @id_cuenta_contable"; //Filtrar Objeto por Fecha de Asiento y Cuenta Contable
        private const string ORDER1 = @" ORDER BY asiento_fecha ASC, asiento_nro ASC, id ASC"; //Libro Diario
        private const string ORDER2 = @" ORDER BY cuenta_contable ASC, asiento_fecha ASC, asiento_nro ASC"; //Libro Mayor
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_asiento_contable WHERE descripcion = @descripcion AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_ELIMINAR = @"SELECT * FROM data_asiento_contable WHERE id = @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_asiento_contable WHERE descripcion = @descripcion AND asiento_nro <> @asiento_nro"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_asiento_contable SET 
            id = @id,
            asiento_nro = @asiento_nro,
            asiento_fecha = @asiento_fecha,
            id_cuenta_contable = @id_cuenta_contable,
            descripcion = @descripcion,
            debe = @debe,
            haber = @haber,
            conciliacion = @conciliacion,
            origen_tipo = @origen_tipo,
            origen_id = @origen_id WHERE id = @id";
        private const string ELIMINAR1 = @"DELETE FROM data_asiento_contable WHERE id = @id";
        private const string ELIMINAR2 = @"DELETE FROM data_asiento_contable WHERE asiento_nro = @asiento_nro";
        private const string INSERTAR = @"INSERT INTO data_asiento_contable (id, asiento_nro, asiento_fecha,
            id_cuenta_contable, descripcion, debe, haber, conciliacion, origen_tipo, origen_id)
            VALUES (@id, @asiento_nro, @asiento_fecha, @id_cuenta_contable, @descripcion, @debe, @haber,
            @conciliacion, @origen_tipo, @origen_id)";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string libro, long idCuentaContable, string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string ordenamiento = (libro == "LIBRO_DIARIO") ? ORDER1 : ORDER2;
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "ASIENTO") condicional = WHERE2; //Consulta filtrada por Número de Asiento
            if (campo == "DESCRIPCION") condicional = (idCuentaContable > 0) ? WHERE5 : WHERE4; //Consulta filtrada por Descripción y/o Cuenta Contable
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ASIENTO") comandoDB.Parameters.AddWithValue("@asiento_nro", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "DESCRIPCION") comandoDB.Parameters.AddWithValue("@descripcion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ordenamiento + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ASIENTO") comandoDB.Parameters.AddWithValue("@asiento_nro", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DESCRIPCION") comandoDB.Parameters.AddWithValue("@descripcion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición de la consulta
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
                                         Convert.ToString(lectorDB["asiento_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["asiento_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["cuenta_contable"]).PadRight(25, ' ') +
                                            " | " + Convert.ToString(lectorDB["descripcion"]).PadRight(35, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["debe"])).PadLeft(12, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["haber"])).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                else if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                         Convert.ToInt64(lectorDB["id"]),
                                         Convert.ToString(lectorDB["asiento_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["asiento_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["cuenta_contable"]).PadRight(25, ' ') +
                                            " | " + Convert.ToString(lectorDB["descripcion"]).PadRight(35, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["debe"]))).PadLeft(12, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["haber"]))).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                else if(catalogo == "CATALOGO3")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                         Convert.ToInt64(lectorDB["id"]),
                                         Convert.ToString(lectorDB["cuenta_contable"]).PadRight(25, ' ') + 
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["asiento_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["descripcion"]).PadRight(35, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["debe"])).PadLeft(11, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["haber"])).PadLeft(11, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["saldo"])).PadLeft(11, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                else if (catalogo == "CATALOGO4")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                         Convert.ToInt64(lectorDB["id"]),
                                         Convert.ToString(lectorDB["cuenta_contable"]).PadRight(25, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["asiento_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["descripcion"]).PadRight(35, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["debe"]))).PadLeft(11, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["haber"]))).PadLeft(11, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["saldo"]))).PadLeft(11, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002ASIENTO_CONTABLE: Hay un conflicto en la consulta del libro diario.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string libro, long idCuentaContable, string campo, DateTime desde, DateTime hasta, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string ordenamiento = (libro == "LIBRO_DIARIO") ? ORDER1 : ORDER2;
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "FECHA") condicional = (idCuentaContable > 0) ? WHERE7 : WHERE6; //Consulta filtrada por Fecha de Asiento y/o Cuenta Contable
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega el parámetro en la condición del contador
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega el parámetro en la condición del contador
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ordenamiento + paginacion)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición de la consulta
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
                                         Convert.ToString(lectorDB["asiento_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["asiento_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["cuenta_contable"]).PadRight(25, ' ') +
                                            " | " + Convert.ToString(lectorDB["descripcion"]).PadRight(35, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["debe"])).PadLeft(12, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["haber"])).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                else if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                         Convert.ToInt64(lectorDB["id"]),
                                         Convert.ToString(lectorDB["asiento_nro"]).PadLeft(8, '0') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["asiento_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["cuenta_contable"]).PadRight(25, ' ') +
                                            " | " + Convert.ToString(lectorDB["descripcion"]).PadRight(35, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["debe"]))).PadLeft(12, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["haber"]))).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                else if (catalogo == "CATALOGO3")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                         Convert.ToInt64(lectorDB["id"]),
                                         Convert.ToString(lectorDB["cuenta_contable"]).PadRight(25, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["asiento_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["descripcion"]).PadRight(35, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["debe"])).PadLeft(11, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["haber"])).PadLeft(11, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["saldo"])).PadLeft(11, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                else if (catalogo == "CATALOGO4")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                         Convert.ToInt64(lectorDB["id"]),
                                         Convert.ToString(lectorDB["cuenta_contable"]).PadRight(25, ' ') +
                                            " | " + Fecha.ConvertirFecha(Convert.ToDateTime(lectorDB["asiento_fecha"])).PadLeft(10, '0') +
                                            " | " + Convert.ToString(lectorDB["descripcion"]).PadRight(35, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["debe"]))).PadLeft(11, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["haber"]))).PadLeft(11, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["saldo"]))).PadLeft(11, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004ASIENTO_CONTABLE: Hay un conflicto en la consulta del libro diario.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<AsientoContable> obtenerObjetos(string libro, long idCuentaContable, string campo, string valor)
        {
            string condicional = "";
            string ordenamiento = (libro == "LIBRO_DIARIO") ? ORDER1 : ORDER2;
            if (campo == "ASIENTO") condicional = WHERE2; //Consulta filtrada por Número de Asiento
            if (campo == "DESCRIPCION") condicional = (idCuentaContable > 0) ? WHERE5 : WHERE4; //Consulta filtrada por Descripción y/o Cuenta Contable
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            List<AsientoContable> ListaDeObjetos = new List<AsientoContable>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos

                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ordenamiento)) //Crea un comando de Base de Datos
                    {
                        if (campo == "ASIENTO") comandoDB.Parameters.AddWithValue("@asiento_nro", valor); //Agrega el parámetro en la condición de la consulta
                        if (campo == "DESCRIPCION") comandoDB.Parameters.AddWithValue("@descripcion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición de la consulta
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                AsientoContable objAsientoContable = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objAsientoContable); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006ASIENTO_CONTABLE: Hay un conflicto en la consulta del libro diario.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public List<AsientoContable> obtenerObjetos(string libro, long idCuentaContable, string campo, DateTime desde, DateTime hasta)
        {
            string condicional = "";
            string ordenamiento = (libro == "LIBRO_DIARIO") ? ORDER1 : ORDER2;
            if (campo == "FECHA") condicional = (idCuentaContable > 0) ? WHERE7 : WHERE6; //Consulta filtrada por Fecha de Asiento y/o Cuenta Contable
            List<AsientoContable> ListaDeObjetos = new List<AsientoContable>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional + ordenamiento)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@desde", desde); //Agrega un parámetro al filtro terciario
                        comandoDB.Parameters.AddWithValue("@hasta", hasta); //Agrega un parámetro al filtro terciario
                        if (idCuentaContable > 0) comandoDB.Parameters.AddWithValue("@id_cuenta_contable", idCuentaContable); //Agrega el parámetro en la condición de la consulta
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                AsientoContable objAsientoContable = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objAsientoContable); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008ASIENTO_CONTABLE: Hay un conflicto en la consulta del libro diario.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public AsientoContable obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "ASIENTO") condicional = WHERE2; //Consulta filtrada por Número de Asiento
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            AsientoContable objAsientoContable = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "ASIENTO") comandoDB.Parameters.AddWithValue("@asiento_nro", valor); //Agrega un parámetro al filtro
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objAsientoContable = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos del asiento contable e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M010ASIENTO_CONTABLE: Hay un conflicto en la consulta del asiento contable.", e); }
            finally { _conexion.Dispose(); }
            return objAsientoContable;
        }

        public AsientoContable obtenerObjeto(string origenTipo, long origenId, bool notificarExito)
        {
            AsientoContable objAsientoContable = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT1 + FROM + WHERE3)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        comandoDB.Parameters.AddWithValue("@origen_tipo", origenTipo); //Agrega un parámetro al filtro
                        comandoDB.Parameters.AddWithValue("@origen_id", origenId); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objAsientoContable = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos del asiento contable e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M012ASIENTO_CONTABLE: Hay un conflicto en la consulta del asiento contable.", e); }
            finally { _conexion.Dispose(); }
            return objAsientoContable;
        }

        public bool actualizar(AsientoContable objAsientoContable, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objAsientoContable.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@descripcion", objAsientoContable.Descripcion); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR)) //Crea un comando de Base de Datos
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objAsientoContable.Id);
                                comandoDB_update.Parameters.AddWithValue("@asiento_nro", objAsientoContable.AsientoNro);
                                comandoDB_update.Parameters.AddWithValue("@asiento_fecha", objAsientoContable.AsientoFecha);
                                comandoDB_update.Parameters.AddWithValue("@id_cuenta_contable", objAsientoContable.CuentaContable.Id);
                                comandoDB_update.Parameters.AddWithValue("@descripcion", objAsientoContable.Descripcion);
                                comandoDB_update.Parameters.AddWithValue("@debe", objAsientoContable.Debe);
                                comandoDB_update.Parameters.AddWithValue("@haber", objAsientoContable.Haber);
                                comandoDB_update.Parameters.AddWithValue("@conciliacion", objAsientoContable.Conciliacion);
                                comandoDB_update.Parameters.AddWithValue("@origen_tipo", objAsientoContable.OrigenTipo);
                                comandoDB_update.Parameters.AddWithValue("@origen_id", objAsientoContable.OrigenId);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                if (notificarExito) Mensaje.Informacion("Los datos de asiento contable ID:" + objAsientoContable.Id.ToString() + "\nse registraron correctamente.");
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro Inaccesible.\nEl asiento contable No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M014CBTE_ASIENTO_CONTABLE", "M016CBTE_ASIENTO_CONTABLE", "M018CBTE_ASIENTO_CONTABLE", "M020CBTE_ASIENTO_CONTABLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool eliminar(AsientoContable objAsientoContable, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ELIMINAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objAsientoContable.Id); //Agrega parámetros al comando de Base de Datos

                        if (comandoDB.ExecuteScalar() != null) //Verifica que la consulta tenga éxito
                        {
                            using (MySqlCommand comandoDB_delete = _conexion.crearComandoDB(ELIMINAR1)) //Crea un comando de Base de Datos
                            {
                                comandoDB_delete.Parameters.AddWithValue("@id", objAsientoContable.Id);
                                comandoDB_delete.ExecuteNonQuery(); //Ejecuta el DELETE en la Base de Datos
                                if (notificarExito) Mensaje.Informacion("El asiento contable ID:" + objAsientoContable.Id.ToString() + "\nse eliminó correctamente."); return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro Inaccesible.\nEl asiento contable No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M022CBTE_ASIENTO_CONTABLE", "M024CBTE_ASIENTO_CONTABLE", "M026CBTE_ASIENTO_CONTABLE", "M028CBTE_ASIENTO_CONTABLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool eliminar(long asientoNro)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB_delete = _conexion.crearComandoDB(ELIMINAR2)) //Crea un comando de Base de Datos
                    {
                        comandoDB_delete.Parameters.AddWithValue("@asiento_nro", asientoNro);
                        comandoDB_delete.ExecuteNonQuery(); //Ejecuta el DELETE en la Base de Datos
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Inaccesible.\nEl asiento contable No se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M030ASIENTO_CONTABLE", "M032ASIENTO_CONTABLE", "M034ASIENTO_CONTABLE", "M036ASIENTO_CONTABLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(AsientoContable objAsientoContable, bool notificarExito)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@descripcion", objAsientoContable.Descripcion); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@asiento_nro", objAsientoContable.AsientoNro); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            //Crea un comando de Base de Datos
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR))
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objAsientoContable.Id);
                                comandoDB_insert.Parameters.AddWithValue("@asiento_nro", objAsientoContable.AsientoNro);
                                comandoDB_insert.Parameters.AddWithValue("@asiento_fecha", objAsientoContable.AsientoFecha);
                                comandoDB_insert.Parameters.AddWithValue("@id_cuenta_contable", objAsientoContable.CuentaContable.Id);
                                comandoDB_insert.Parameters.AddWithValue("@descripcion", objAsientoContable.Descripcion);
                                comandoDB_insert.Parameters.AddWithValue("@debe", objAsientoContable.Debe);
                                comandoDB_insert.Parameters.AddWithValue("@haber", objAsientoContable.Haber);
                                comandoDB_insert.Parameters.AddWithValue("@conciliacion", objAsientoContable.Conciliacion);
                                comandoDB_insert.Parameters.AddWithValue("@origen_tipo", objAsientoContable.OrigenTipo);
                                comandoDB_insert.Parameters.AddWithValue("@origen_id", objAsientoContable.OrigenId);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                if (notificarExito) Mensaje.Informacion("Los datos del asiento contable ID:" + objAsientoContable.Id.ToString() + "\nse registraron correctamente.");
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro Existente.\nEl asiento contable ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M038ASIENTO_CONTABLE", "M040ASIENTO_CONTABLE", "M042ASIENTO_CONTABLE", "M044ASIENTO_CONTABLE", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public long generarNumeroAsiento()
        {
            ConexionDB conexion = new ConexionDB();
            long nuevoID = 1; //Crea una variable para almacenar el ID
            try
            {
                conexion.crearConexion(); //Crea una conexión con la Base de Datos
                using (MySqlCommand comandoDB = conexion.crearComandoDB(@"SELECT MAX(asiento_nro) FROM data_asiento_contable")) //Crea un comando de Base de Datos
                {
                    var respuesta = comandoDB.ExecuteScalar();
                    nuevoID = (respuesta != DBNull.Value) ? (Convert.ToInt64(respuesta) + 1) : 1; //Ejecuta el cálculo del ID máximo para determinar el ultimo ID asignado y lo incrementa en uno
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M046ASIENTO_CONTABLE: Hay un conflicto en la generación del número de asiento.", e); }
            finally { conexion.Dispose(); }
            return nuevoID;
        }
        #endregion

        #region Métodos de Instanciación
        private AsientoContable instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new AsientoContable(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToInt64(lectorDB["asiento_nro"]),
                Convert.ToDateTime(lectorDB["asiento_fecha"]),
                new D_CuentaContable().obtenerObjeto("ID", Convert.ToString(lectorDB["id_cuenta_contable"]), false),
                Convert.ToString(lectorDB["descripcion"]),
                Convert.ToDouble(lectorDB["debe"]),
                Convert.ToDouble(lectorDB["haber"]),
                Convert.ToString(lectorDB["conciliacion"]),
                Convert.ToString(lectorDB["origen_tipo"]),
                Convert.ToInt64(lectorDB["origen_id"]));
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
