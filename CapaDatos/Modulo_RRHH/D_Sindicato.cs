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
    public class D_Sindicato : ISindicato, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT *";
        private const string FROM = @" FROM data_sindicato";
        private const string WHERE1 = @" WHERE id = @id"; //Filtrar Objeto por ID
        private const string WHERE2 = @" WHERE convenio = @convenio"; //Filtrar Objeto por Convenio
        private const string WHERE3 = @" WHERE LOWER(denominacion) LIKE LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string WHERE4 = @" WHERE LOWER(denominacion) = LOWER(@denominacion)"; //Filtrar Objeto por Denominación
        private const string ORDER = @" ORDER BY denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        private const string OBTENER_VERIFICACION_ACTUALIZAR = @"SELECT * FROM data_sindicato WHERE (denominacion = @denominacion || convenio = @convenio) AND id <> @id"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        private const string OBTENER_VERIFICACION_INSERTAR = @"SELECT * FROM data_sindicato WHERE (denominacion = @denominacion || convenio = @convenio)"; //Importante: Esta verificación se debe realizar de forma directa y No a la relación.
        #endregion

        #region Ejecuciones SQL
        private const string ACTUALIZAR = @"UPDATE data_sindicato SET 
            id = @id,
            convenio = @convenio,
            denominacion = @denominacion,
            aporte_solidario_fijo = @aporte_solidario_fijo,
            aporte_solidario_tasa = @aporte_solidario_tasa,
            cuota_sindical_fijo = @cuota_sindical_fijo,
            cuota_sindical_tasa = @cuota_sindical_tasa,
            seguro_social_fijo = @seguro_social_fijo,
            seguro_social_tasa = @seguro_social_tasa,
            fcl_primer_anio_tasa = @fcl_primer_anio_tasa,
            fcl_masdeun_anio_tasa = @fcl_masdeun_anio_tasa,
            incluye_total_nr = @incluye_total_nr,
            edicion_fecha = @edicion_fecha,
            edicion_usuario_id = @edicion_usuario_id,
            edicion_usuario = @edicion_usuario WHERE id = @id";
        private const string ELIMINAR = @"DELETE FROM data_sindicato WHERE id = @id";
        private const string INSERTAR = @"INSERT INTO data_sindicato (id, convenio, denominacion, aporte_solidario_fijo,
            aporte_solidario_tasa, cuota_sindical_fijo, cuota_sindical_tasa, seguro_social_fijo, seguro_social_tasa,
            fcl_primer_anio_tasa, fcl_masdeun_anio_tasa, incluye_total_nr, edicion_fecha, edicion_usuario_id, edicion_usuario) 
            VALUES (@id, @convenio, @denominacion, @aporte_solidario_fijo, @aporte_solidario_tasa, @cuota_sindical_fijo, 
            @cuota_sindical_tasa, @seguro_social_fijo, @seguro_social_tasa, @fcl_primer_anio_tasa,
            @fcl_masdeun_anio_tasa, @incluye_total_nr, @edicion_fecha, @edicion_usuario_id, @edicion_usuario)";
        #endregion

        #region Métodos
        public List<string> obtenerListaDeElementos(string[] deposito)
        {
            List<string> listaDeElementos = new List<string>(); //Crea una lista de Objetos para almacenar los registros del tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + ORDER)) //Crea un comando de Base de Datos
                    {
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader()) //Ejecuta una consulta en la Base de Datos
                        {
                            while (lectorDB.Read())
                            {
                                if (deposito.Length > 0)
                                {
                                    foreach (string item in deposito)
                                    {
                                        if (Convert.ToString(lectorDB["deposito"]).Contains(item)) listaDeElementos.Add(Convert.ToString(lectorDB["denominacion"])); //Agrega el elemento especifico a la lista de elementos 
                                    }
                                }
                                else listaDeElementos.Add(Convert.ToString(lectorDB["denominacion"])); //Agrega el elemento a la lista de elementos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002SINDICATO: Hay un conflicto en la consulta de la lista de sindicato.", e); }
            finally { _conexion.Dispose(); }
            return listaDeElementos;
        }

        public List<CatalogoBase> obtenerCatalago(string campo, string valor, string catalogo, int indicePagina, int tamanioPagina)
        {
            string condicional = "";
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            if (campo == "CONVENIO") condicional = WHERE2; //Consulta filtrada por Convenio
            if (campo == "DENOMINACION") condicional = WHERE3; //Consulta filtrada por Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por ID
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + condicional)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CONVENIO") comandoDB.Parameters.AddWithValue("@convenio", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición del contador
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CONVENIO") comandoDB.Parameters.AddWithValue("@convenio", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega el parámetro en la condición de la consulta
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega el parámetro en la condición del contador
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
                                            " | " + Convert.ToString(lectorDB["convenio"]).PadRight(8, ' ') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(25, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["aporte_solidario_fijo"])) + " %" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["aporte_solidario_tasa"]))).PadRight(18, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["cuota_sindical_fijo"])) + " %" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["cuota_sindical_tasa"]))).PadRight(18, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["seguro_social_fijo"])) + " %" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["seguro_social_tasa"]))).PadRight(18, ' ') +
                                            " | " + ("%" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["fcl_primer_anio_tasa"])) + " %" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["fcl_masdeun_anio_tasa"]))).PadRight(13, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["id"]).PadLeft(8, '0') +
                                            " | " + Convert.ToString(lectorDB["convenio"]).PadRight(8, ' ') +
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(25, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["aporte_solidario_fijo"])) + " y/o %" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["aporte_solidario_tasa"]))).PadRight(22, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["cuota_sindical_fijo"])) + " y/o %" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["cuota_sindical_tasa"]))).PadRight(22, ' ') +
                                            " | " + ("$" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["seguro_social_fijo"])) + " y/o %" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["seguro_social_tasa"]))).PadRight(22, ' ') +
                                            " | " + ("%" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["fcl_primer_anio_tasa"])) + " y/o %" + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["fcl_masdeun_anio_tasa"]))).PadRight(17, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004SINDICATO: Hay un conflicto en la consulta de sindicato.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<Sindicato> obtenerObjetos(string campo, string valor)
        {
            string condicional = "";
            if (campo == "CONVENIO") condicional = WHERE2; //Consulta filtrada por Convenio
            if (campo == "DENOMINACION") condicional = WHERE3; //Consulta filtrada por Denominación
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por Código
            List<Sindicato> ListaDeObjetos = new List<Sindicato>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional + ORDER)) //Crea un comando de Base de Datos
                    {
                        if (campo == "CONVENIO") comandoDB.Parameters.AddWithValue("@convenio", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", "%" + valor + "%"); //Agrega un parámetro al filtro
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Sindicato objSindicato = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objSindicato); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M006SINDICATO: Hay un conflicto en la consulta de sindicato.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }

        public Sindicato obtenerObjeto(string campo, string valor, bool notificarExito)
        {
            string condicional = "";
            if (campo == "CONVENIO") condicional = WHERE2; //Consulta filtrada por Convenio
            if (campo == "DENOMINACION") condicional = WHERE4; //Consulta filtrada por Denominación exacta
            if (campo == "ID") condicional = WHERE1; //Consulta filtrada por Código
            Sindicato objSindicato = null; //Crea una Objeto nulo para posteriormente almacenar el registro solicitado
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + condicional)) //Crea un comando de Base de Datos en base al campo indicado
                    {
                        if (campo == "CONVENIO") comandoDB.Parameters.AddWithValue("@convenio", valor); //Agrega el parámetro en la condición del contador
                        if (campo == "DENOMINACION") comandoDB.Parameters.AddWithValue("@denominacion", valor); //Agrega un parámetro al filtro
                        if (campo == "ID") comandoDB.Parameters.AddWithValue("@id", valor); //Agrega un parámetro al filtro
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            if (lectorDB.HasRows) //Verifica si la consulta tuvo éxito
                            {
                                while (lectorDB.Read())
                                {
                                    objSindicato = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                }
                            }
                            else throw new NullReferenceException();
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                if (notificarExito) Mensaje.Advertencia("Registro solicitado No hallado.\nVerifique los datos del sindicato e intente nuevamente.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.Error("Error-M008SINDICATO: Hay un conflicto en la consulta del sindicato.", e); }
            finally { _conexion.Dispose(); }
            return objSindicato;
        }

        public bool actualizar(Sindicato objSindicato)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_ACTUALIZAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@id", objSindicato.Id); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@convenio", objSindicato.Convenio); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@denominacion", objSindicato.Denominacion); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            //Crea un comando de Base de Datos
                            using (MySqlCommand comandoDB_update = _conexion.crearComandoDB(ACTUALIZAR))
                            {
                                comandoDB_update.Parameters.AddWithValue("@id", objSindicato.Id);
                                comandoDB_update.Parameters.AddWithValue("@convenio", objSindicato.Convenio);
                                comandoDB_update.Parameters.AddWithValue("@denominacion", objSindicato.Denominacion);
                                comandoDB_update.Parameters.AddWithValue("@aporte_solidario_fijo", objSindicato.AporteSolidarioFijo);
                                comandoDB_update.Parameters.AddWithValue("@aporte_solidario_tasa", objSindicato.AporteSolidarioTasa);
                                comandoDB_update.Parameters.AddWithValue("@cuota_sindical_fijo", objSindicato.CuotaSindicalFijo);
                                comandoDB_update.Parameters.AddWithValue("@cuota_sindical_tasa", objSindicato.CuotaSindicalTasa);
                                comandoDB_update.Parameters.AddWithValue("@seguro_social_fijo", objSindicato.SeguroSocialFijo);
                                comandoDB_update.Parameters.AddWithValue("@seguro_social_tasa", objSindicato.SeguroSocialTasa);
                                comandoDB_update.Parameters.AddWithValue("@fcl_primer_anio_tasa", objSindicato.FCL_PrimerAnioTasa);
                                comandoDB_update.Parameters.AddWithValue("@fcl_masdeun_anio_tasa", objSindicato.FCL_MasDeUnAnioTasa);
                                comandoDB_update.Parameters.AddWithValue("@incluye_total_nr", objSindicato.IncluyeTotalNR);
                                comandoDB_update.Parameters.AddWithValue("@edicion_fecha", objSindicato.EdicionFecha);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario_id", objSindicato.EdicionUsuarioId);
                                comandoDB_update.Parameters.AddWithValue("@edicion_usuario", objSindicato.EdicionUsuarioDenominacion);
                                comandoDB_update.ExecuteNonQuery(); //Ejecuta el UPDATE en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Sindicatos", "Modificó el registro ID:" + objSindicato.Id.ToString() + "."); //Registra la modificación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl sindicato ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.StackTrace);
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M010SINDICATO", "M012SINDICATO", "M014SINDICATO", "M016SINDICATO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }

        public bool insertar(Sindicato objSindicato)
        {
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(OBTENER_VERIFICACION_INSERTAR)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@convenio", objSindicato.Convenio); //Agrega parámetros al comando de Base de Datos
                        comandoDB.Parameters.AddWithValue("@denominacion", objSindicato.Denominacion); //Agrega parámetros al comando de Base de Datos
                        if (comandoDB.ExecuteScalar() == null) //Verifica que la consulta No tenga éxito
                        {
                            //Crea un comando de Base de Datos
                            using (MySqlCommand comandoDB_insert = _conexion.crearComandoDB(INSERTAR))
                            {
                                comandoDB_insert.Parameters.AddWithValue("@id", objSindicato.Id);
                                comandoDB_insert.Parameters.AddWithValue("@convenio", objSindicato.Convenio);
                                comandoDB_insert.Parameters.AddWithValue("@denominacion", objSindicato.Denominacion);
                                comandoDB_insert.Parameters.AddWithValue("@aporte_solidario_fijo", objSindicato.AporteSolidarioFijo);
                                comandoDB_insert.Parameters.AddWithValue("@aporte_solidario_tasa", objSindicato.AporteSolidarioTasa);
                                comandoDB_insert.Parameters.AddWithValue("@cuota_sindical_fijo", objSindicato.CuotaSindicalFijo);
                                comandoDB_insert.Parameters.AddWithValue("@cuota_sindical_tasa", objSindicato.CuotaSindicalTasa);
                                comandoDB_insert.Parameters.AddWithValue("@seguro_social_fijo", objSindicato.SeguroSocialFijo);
                                comandoDB_insert.Parameters.AddWithValue("@seguro_social_tasa", objSindicato.SeguroSocialTasa);
                                comandoDB_insert.Parameters.AddWithValue("@fcl_primer_anio_tasa", objSindicato.FCL_PrimerAnioTasa);
                                comandoDB_insert.Parameters.AddWithValue("@fcl_masdeun_anio_tasa", objSindicato.FCL_MasDeUnAnioTasa);
                                comandoDB_insert.Parameters.AddWithValue("@incluye_total_nr", objSindicato.IncluyeTotalNR);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_fecha", objSindicato.EdicionFecha);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario_id", objSindicato.EdicionUsuarioId);
                                comandoDB_insert.Parameters.AddWithValue("@edicion_usuario", objSindicato.EdicionUsuarioDenominacion);
                                comandoDB_insert.ExecuteNonQuery(); //Ejecuta el INSERT en la Base de Datos
                                D_Auditoria.RegistrarAuditoria("Sindicatos", "Agregó el registro ID:" + objSindicato.Id.ToString() + "."); //Registra la agregación de un registro
                                return true;
                            }
                        }
                        else throw new NullReferenceException();
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Mensaje.Advertencia("Registro Existente.\nEl sindicato ya se encuentra registrado en la Base de Datos.");
                Console.WriteLine(e.ToString());
            }
            catch (MySqlException e) { Mensaje.ErrorMySql("M018SINDICATO", "M020SINDICATO", "M022SINDICATO", "M024SINDICATO", e); }
            finally { _conexion.Dispose(); }
            return false;
        }
        #endregion

        #region Métodos de Instanciación
        private Sindicato instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            Sindicato objSindicato = new Sindicato(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToString(lectorDB["convenio"]),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToDouble(lectorDB["aporte_solidario_fijo"]),
                Convert.ToDouble(lectorDB["aporte_solidario_tasa"]),
                Convert.ToDouble(lectorDB["cuota_sindical_fijo"]),
                Convert.ToDouble(lectorDB["cuota_sindical_tasa"]),
                Convert.ToDouble(lectorDB["seguro_social_fijo"]),
                Convert.ToDouble(lectorDB["seguro_social_tasa"]),
                Convert.ToDouble(lectorDB["fcl_primer_anio_tasa"]),
                Convert.ToDouble(lectorDB["fcl_masdeun_anio_tasa"]),
                Convert.ToBoolean(lectorDB["incluye_total_nr"]),
                Convert.ToDateTime(lectorDB["edicion_fecha"]),
                Convert.ToInt32(lectorDB["edicion_usuario_id"]),
                Convert.ToString(lectorDB["edicion_usuario"]));
            return objSindicato;
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