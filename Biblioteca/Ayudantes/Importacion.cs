using ClosedXML.Excel;
using System;
using System.Data;
using System.Data.OleDb;

namespace Biblioteca.Ayudantes
{
    public static class Importacion
    {
        #region Métodos
        public static DataTable ImportarXLSX(string deposito)
        {
            DataTable tabla = new DataTable();
            String archivoXLSX = Archivo.ObtenerArchivo(@"\Temp", "XLSX"); //Obtiene la ruta del archivo xlsx
            if (!string.IsNullOrEmpty(archivoXLSX)) //Verifica que se obtuvo una ruta del archivo xlsx
            {
                using (var libroDelDocumento = new XLWorkbook(archivoXLSX)) //Prepara el documento xlsx
                {
                    using (var sabanaDelDocumento = libroDelDocumento.Worksheet(1)) //Crea y especifica la pestaña del libro
                    {
                        if (libroDelDocumento.Worksheet(1).Name == deposito) //Verifica que el libro contenga una pestaña con el nombre del deposito seleccionado
                        {
                            char[] indiceColumna = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M' }; //Lista de indices de columnas
                            string ultimaColumna = indiceColumna[sabanaDelDocumento.LastColumnUsed().ColumnNumber() - 1].ToString(); //Índice alfabético de la última columna
                            string ultimaFila = sabanaDelDocumento.LastRowUsed().RowNumber().ToString(); //Índice numérico de la última fila
                            sabanaDelDocumento.Range("A4:" + ultimaColumna + ultimaFila.ToString()).SetDataType(XLDataType.Text); //Convierte todos los datos en tipo texto
                            libroDelDocumento.Save(); //Guarda los cambios en el documento
                        }
                    }
                }
                using (OleDbConnection conexionXLSX = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + archivoXLSX + "; Extended Properties='Excel 12.0 Xml; HDR=NO';")) //Cadena de conexión xlsx
                {
                    OleDbCommand comandoXLSX = new OleDbCommand { CommandText = "SELECT * FROM [" + deposito + "$]", Connection = conexionXLSX }; //Consulta al archivo xlsx
                    comandoXLSX.CommandType = CommandType.Text;
                    try
                    {
                        conexionXLSX.Open();
                        using (OleDbDataAdapter adaptadorOLE = new OleDbDataAdapter(comandoXLSX)) //Ejecuta la consulta xlsx
                        {
                            adaptadorOLE.Fill(tabla); //Cargar los datos xlsx al DataTable
                        }
                    }
                    catch (OleDbException ex)
                    {
                        Mensaje.Advertencia("Plantilla Incorrecta.\nVerifique la plantilla o el depósito seleccionado\ne intente nuevamente.");
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            return tabla;
        }
        #endregion
    }
}
