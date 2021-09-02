using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CapaDatos
{
    public class D_Fondo : IFondo, IDisposable
    {
        #region Atributos
        private ConexionDB _conexion = new ConexionDB();
        #endregion

        #region Consultas SQL
        private const string SELECT = @"SELECT data_cuenta_contable.id, codigo, denominacion, tipo_cuenta, saldo";
        private const string FROM = @" FROM data_cuenta_contable";
        private const string WHERE = @" WHERE LOWER(tipo_cuenta) LIKE LOWER('%ACTIVO CORRIENTE > DISPONIBILIDADES%')"; //Filtrar Objeto por Descripción
        private const string ORDER = @" ORDER BY tipo_cuenta ASC, denominacion ASC";
        private const string LIMIT = @" LIMIT @registro_inicial, @registro_final";
        #endregion

        #region Métodos
        public List<CatalogoBase> obtenerCatalago(string catalogo, int indicePagina, int tamanioPagina)
        {
            string paginacion = (indicePagina < 0) ? "" : LIMIT; //Verifica que el índice de la página sea válido. En tal caso, añade el operador LIMIT a la consulta 
            List<CatalogoBase> ListaDeElementos = new List<CatalogoBase>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            string[] tipoCuentaContableAntecesor = new string[] { "" }; //Importante: Se debe inicializar el primer y único valor del vector
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(@"SELECT COUNT(*)" + FROM + WHERE)) //Crea un comando de Base de Datos
                    {
                        double cuentaRegistro = Convert.ToDouble(comandoDB.ExecuteScalar()); //Ejecuta el contador de registros
                        Global.PaginacionIndiceMaximo = Convert.ToInt32(cuentaRegistro / Convert.ToDouble((tamanioPagina > 0) ? tamanioPagina : cuentaRegistro)); //Verifica que el tamaño de la página sea válido. En tal caso, calcula y toma el valor entero del número máximo de páginas en relación al tamaño de la página ingresada
                    }
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE + ORDER + paginacion)) //Crea un comando de Base de Datos
                    {
                        comandoDB.Parameters.AddWithValue("@registro_inicial", (tamanioPagina * indicePagina)); //Agrega un parámetro al filtro con el valor del registro inicial del limite
                        comandoDB.Parameters.AddWithValue("@registro_final", (((tamanioPagina * indicePagina) + tamanioPagina) - 1)); //Agrega un parámetro al filtro con el valor del registro final del limite
                        using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                string[] tipoCuentaContableActual = Convert.ToString(lectorDB["tipo_cuenta"]).Split('>');
                                if (catalogo == "CATALOGO1")
                                {
                                    CatalogoBase elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        Convert.ToString(lectorDB["tipo_cuenta"]).PadRight(75, ' ') + //Asigné el valor en 75 para cubrir el ancho del ListBox 
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(25, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["saldo"])).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                else if (catalogo == "CATALOGO2")
                                {
                                    CatalogoBase elemento;
                                    #region Fila Tipo SubTitulo
                                    if (((tipoCuentaContableActual.Length == 3) ? (tipoCuentaContableActual[2]) : tipoCuentaContableActual[0])
                                        != ((tipoCuentaContableAntecesor.Length == 3) ? (tipoCuentaContableAntecesor[2]) : tipoCuentaContableAntecesor[0]))
                                    {
                                        elemento = new CatalogoBase(
                                            Convert.ToInt64(lectorDB["id"]),
                                            Convert.ToString(lectorDB["tipo_cuenta"]).PadRight(75, ' ') + //Asigné el valor en 75 para cubrir el ancho del ListBox 
                                                " | " + ("").PadRight(25, ' ') +
                                                " | " + ("").PadLeft(12, ' '));
                                        ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                    }
                                    #endregion
                                    elemento = new CatalogoBase(
                                        Convert.ToInt64(lectorDB["id"]),
                                        ("").PadRight(75, ' ') + //Asigné el valor en 75 para cubrir el ancho del ListBox 
                                            " | " + Convert.ToString(lectorDB["denominacion"]).PadRight(25, ' ') +
                                            " | " + Formulario.ValidarCampoMoneda(Convert.ToString(lectorDB["saldo"])).PadLeft(12, ' '));
                                    ListaDeElementos.Add(elemento); //Agrega este elemento a la lista de elementos
                                }
                                tipoCuentaContableAntecesor = tipoCuentaContableActual; //Deducción de Sub-Título - Paso 2: Establece la rama principal de la Cuenta Contable actual (Importante para completar el ciclo)
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M002RESUMEN_FONDOS: Hay un conflicto en la consulta de las cuentas de fondos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeElementos;
        }

        public List<Fondo> obtenerObjetos()
        {
            List<Fondo> ListaDeObjetos = new List<Fondo>(); //Crea una lista de Objetos para almacenar los registros de la tabla
            try
            {
                if (_conexion.crearConexion()) //Verifica la creación de la conexión con el Servidor de Base de Datos
                {
                    using (MySqlCommand comandoDB = _conexion.crearComandoDB(SELECT + FROM + WHERE + ORDER)) //Crea un comando de Base de Datos
                    {
                         using (MySqlDataReader lectorDB = comandoDB.ExecuteReader())
                        {
                            while (lectorDB.Read())
                            {
                                Fondo objFondo = instanciarObjeto(lectorDB); //Crea un objeto y asigna los valores correspondientes.
                                ListaDeObjetos.Add(objFondo); //Agrega este Objeto a la lista de Objetos
                            }
                        }
                    }
                }
            }
            catch (MySqlException e) { Mensaje.Error("Error-M004RESUMEN_FONDOS: Hay un conflicto en la consulta de las cuentas de fondos.", e); }
            finally { _conexion.Dispose(); }
            return ListaDeObjetos;
        }
        #endregion

        #region Métodos de Instanciación
        private Fondo instanciarObjeto(MySqlDataReader lectorDB) //Método que crea una instancia del Objeto con información de la Base de datos
        {
            return new Fondo(
                Convert.ToInt64(lectorDB["id"]),
                Convert.ToString(lectorDB["codigo"]),
                Convert.ToString(lectorDB["denominacion"]),
                Convert.ToString(lectorDB["tipo_cuenta"]),
                Convert.ToDouble(lectorDB["saldo"]));
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
