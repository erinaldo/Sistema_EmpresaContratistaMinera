using ClosedXML.Excel;
using Entidades;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace Biblioteca.Ayudantes
{
    public class Reporte
    {
        #region Atributos
        private string directorioLogo = Archivo.ValidarDirectorio(@"Logo\");
        private string directorioPlantilla = Archivo.ValidarDirectorio(@"Plantillas\"); //Valida el directorio de plantillas
        private string directorioTempDOCX = Archivo.ValidarDirectorio(@"Temp\Docx\"); //Valida el directorio de trabajo docx
        private string directorioTempPDF = Archivo.ValidarDirectorio(@"Temp\PDF\"); //Valida el directorio de trabajo PDF
        private string directorioTempXLSX = Archivo.ValidarDirectorio(@"Temp\Xlsx\"); //Valida el directorio de trabajo de xlsx
        #endregion

        #region Métodos
        public void crearDocumentoExcel_ListaConTotal(string tituloA, string tituloB, string[] subTitulos, int[] anchos, List<string[]> datoDB, List<int> indiceColumnaTipoFecha, string[] leyendasDeTotal, string[] valoresDeTotal, int filasDeTotal, int columnasDeTotal, int longitudDeTotal, int ajustarHoja, bool resaltarFila = false)
        {
            Cursor.Current = Cursors.WaitCursor;
            string nombreDeArchivo = (tituloA + "_" + tituloB).Replace(" ", "_").Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u"); //Acondiciona el título del nombre del archivo
            string archivoXLSX = directorioTempXLSX + (nombreDeArchivo + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".xlsx"); //Directorio temporal de PDF y Excel
            char[] indiceColumna = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P' }; //Lista de indices de columnas
            char indiceColumnaFinal = indiceColumna[subTitulos.Length - 1]; //Calcula el indice de la columna final
            try
            {
                using (var libroDelDocumento = new XLWorkbook())
                {
                    using (var sabanaDelDocumento = libroDelDocumento.Worksheets.Add("Empreminsa")) //Crea y especifica el nombre del la sabana
                    {
                        sabanaDelDocumento.PageSetup.SetPaperSize(XLPaperSize.A4Paper); //Pagina: Tamaño A4
                        sabanaDelDocumento.PageSetup.SetPageOrientation(XLPageOrientation.Landscape); //Pagina: Orientación horizontal
                        sabanaDelDocumento.PageSetup.AdjustTo(ajustarHoja); //Ajusta el contenido del documento al tamaño de una hoja A4 
                        sabanaDelDocumento.PageSetup.Margins.SetTop(0.75); //Pagina: Margen superior
                        sabanaDelDocumento.PageSetup.Margins.SetBottom(0.75); //Pagina: Margen inferior
                        sabanaDelDocumento.PageSetup.Margins.SetLeft(0.5); //Pagina: Margen izquierdo
                        sabanaDelDocumento.PageSetup.Margins.SetRight(0.5); //Pagina: Margen derecho
                        for (int i = 0; i < subTitulos.Length; i++) sabanaDelDocumento.Column(indiceColumna[i].ToString()).Width = anchos[i]; //Define el ancho de cada columna
                        crearEncabezado(); //Crea el encabezado del la página
                        for (int i = 0; i < datoDB.Count; i++) //Rellena las celdas de la tabla
                        {
                            //Definición de los campos de la Base de Datos
                            sabanaDelDocumento.Row(5 + i).Height = 12; //Alto de la fila
                            sabanaDelDocumento.Row(5 + i).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left); //Textos alineados al borde izquierdo
                            sabanaDelDocumento.Row(5 + i).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top); //Textos alineados al borde superior
                            sabanaDelDocumento.Row(5 + i).Style.Alignment.SetWrapText(true); //Ajusta los textos largos al ancho de la columna
                            sabanaDelDocumento.Row(5 + i).Style.Font.SetFontName("Arial").Font.SetFontSize(8); //Tipografia, tamaño de la fuente de los Textos
                            sabanaDelDocumento.Range("A" + (5 + i).ToString(), indiceColumnaFinal + (5 + i).ToString()).Style.Border.BottomBorder = XLBorderStyleValues.Medium; //Separador de cada registro
                            sabanaDelDocumento.Range("A" + (5 + i).ToString(), indiceColumnaFinal + (5 + i).ToString()).Style.Border.BottomBorderColor = XLColor.Gray; //Color del separador de cada registro
                            for (int j = 0; j < datoDB[i].Length; j++)
                            {
                                sabanaDelDocumento.Cell(5 + i, indiceColumna[j].ToString()).Value = datoDB[i][j]; //Inserta el dato en la celda
                                if (!indiceColumnaTipoFecha.Contains(j)) sabanaDelDocumento.Cell(5 + i, indiceColumna[j].ToString()).SetDataType(XLDataType.Text); //Convierte el dato de la celda a tipo Texto Plano
                                else if (indiceColumnaTipoFecha.Contains(j)) sabanaDelDocumento.Cell(5 + i, indiceColumna[j].ToString()).SetDataType(XLDataType.DateTime).Style.DateFormat.Format = "dd/MM/yyyy"; //Convierte el dato de la celda a tipo Fecha
                                if (resaltarFila && !string.IsNullOrEmpty(datoDB[i][0].ToString())) //Verifica si se debe resaltar la fila 
                                {
                                    sabanaDelDocumento.Cell(5 + i, indiceColumna[j].ToString()).Style.Fill.BackgroundColor = XLColor.FromArgb(205, 225, 165); //Establece el color de fondo de la fila
                                    sabanaDelDocumento.Cell(5 + i, indiceColumna[j].ToString()).Style.Font.SetBold(true); //Coloca el texto en negritas
                                }
                            }
                        }
                        crearTotales(5 + datoDB.Count, leyendasDeTotal, valoresDeTotal, filasDeTotal, columnasDeTotal, longitudDeTotal); //Crea los totales de la tabla
                        sabanaDelDocumento.SetShowRowColHeaders(false); //Oculta los encabezados de las columnas y los números de las filas de la cuadricula de Excel
                        sabanaDelDocumento.SetShowGridLines(false); //Oculta las lineas de la cuadricula de Excel
                        sabanaDelDocumento.Protect(Global.UsuarioActivo_Documento); //Protege el docuemento Excel con contraseña
                        libroDelDocumento.SaveAs(archivoXLSX); //Guarda el documento en la ruta especificada
                        abrirDocumentoExcel(); //Ejecuta el documento creado
                        #region Métodos Internos
                        void crearEncabezado()
                        {
                            /* -------- Paginación -------- */
                            sabanaDelDocumento.PageSetup.Header.Right.AddText(tituloA + " " + tituloB + " - Página: ", XLHFOccurrence.AllPages); //Pie de página
                            sabanaDelDocumento.PageSetup.Header.Right.AddText(XLHFPredefinedText.PageNumber, XLHFOccurrence.AllPages); //Pie de página
                            /* ---- Logo de la Empresa ---- */
                            try
                            {
                                using (Bitmap imagenLogo = global::Biblioteca.Properties.Resources.logo_marca)
                                {
                                    var logo = sabanaDelDocumento.AddPicture(imagenLogo);
                                    logo.MoveTo(sabanaDelDocumento.Cell(1, 1).Address);
                                    logo.Scale(0.12, true);
                                }
                            }
                            catch (Exception e)
                            {
                                Mensaje.Error("Error-A002REPORTE: Hay un conflicto en la generación del Excel.\nNo se puede cargar el logo de la Empresa.", e);
                            }
                            /* ---------- Titulo ---------- */
                            sabanaDelDocumento.Cell(1, "A").Style.Alignment.SetWrapText(true); //Ajusta los textos largos al ancho de la columna
                            sabanaDelDocumento.Cell(1, "A").Value = tituloA + "\n" + tituloB;
                            sabanaDelDocumento.Range("A1", indiceColumnaFinal + (1).ToString()).Merge(); //Combina la celdas
                            sabanaDelDocumento.Row(1).Height = 65; //Alto de la fila de paginación
                            sabanaDelDocumento.Row(1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center); //Alto de la fila de paginación
                            sabanaDelDocumento.Row(1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom); //Textos alineados al borde superior
                            sabanaDelDocumento.Row(1).Style.Font.SetFontName("Times_Roman").Font.SetFontSize(16).Font.SetBold(true); //Tipografia, tamaño y estilo de negritas para el titulo
                            sabanaDelDocumento.Row(1).Style.Font.SetFontColor(XLColor.FromArgb(0, 96, 100)); //Color de letra de los subTitulos
                            /* --- Espacio de separación --- */
                            sabanaDelDocumento.Range("A2", indiceColumnaFinal + (3).ToString()).Merge(); //Combina la celdas
                            sabanaDelDocumento.Row(2).Height = 10; //Alto de la fila de paginación
                            sabanaDelDocumento.Row(3).Height = 2; //Alto de la fila del separador
                            sabanaDelDocumento.Range("A3", indiceColumnaFinal + (3).ToString()).Merge(); //Combina la celdas
                            sabanaDelDocumento.Range("A3", indiceColumnaFinal + (3).ToString()).Style.Border.SetTopBorder(XLBorderStyleValues.Medium); //Borde del separador
                            sabanaDelDocumento.Range("A3", indiceColumnaFinal + (3).ToString()).Style.Border.SetTopBorderColor(XLColor.FromArgb(0, 96, 100)); //Color del borde del separador
                            /* --------- SubTitulos -------- */
                            sabanaDelDocumento.Row(4).Height = 12; //Alto de la fila de los subtitulos
                            sabanaDelDocumento.Row(4).Style.Font.SetFontName("Times_Roman").Font.SetFontSize(8).Font.SetBold(true); //Tipografia, tamaño y estilo de negritas para los subtitulos
                            sabanaDelDocumento.Range("A4", indiceColumnaFinal + (4).ToString()).Style.Font.SetFontColor(XLColor.White); //Color de letra de los subTitulos
                            sabanaDelDocumento.Range("A4", indiceColumnaFinal + (4).ToString()).Style.Fill.SetBackgroundColor(XLColor.Gray); //Color de fondo de los subTitulos
                            for (int i = 0; i < subTitulos.Length; i++) sabanaDelDocumento.Cell(4, indiceColumna[i].ToString()).Value = subTitulos[i]; //Inserta los subTitulos de las columnas
                        }
                        void abrirDocumentoExcel()
                        {
                            ProcessStartInfo proceso = new ProcessStartInfo();
                            proceso.FileName = "EXCEL.EXE";
                            proceso.Arguments = archivoXLSX;
                            Process.Start(proceso);
                        }
                        void crearTotales(int filaInicial, string[] leyenda, string[] valor, int filas, int columnas, int longitud)
                        {
                            /* ---------- Diseño ---------- */
                            for (int i = 0; i < filas; i++)
                            {
                                sabanaDelDocumento.Range("A" + (filaInicial + i).ToString(), indiceColumnaFinal + (filaInicial + i).ToString()).Merge(); //Combinación de celdas
                                sabanaDelDocumento.Range("A" + (filaInicial + i).ToString(), indiceColumnaFinal + (filaInicial + i).ToString()).Style.Border.LeftBorder = XLBorderStyleValues.Medium; //Separador del borde izquierdo
                                sabanaDelDocumento.Range("A" + (filaInicial + i).ToString(), indiceColumnaFinal + (filaInicial + i).ToString()).Style.Border.LeftBorderColor = XLColor.Gray; //Color del borde izquierdo
                                sabanaDelDocumento.Range("A" + (filaInicial + i).ToString(), indiceColumnaFinal + (filaInicial + i).ToString()).Style.Border.RightBorder = XLBorderStyleValues.Medium; //Separador del borde derecho
                                sabanaDelDocumento.Range("A" + (filaInicial + i).ToString(), indiceColumnaFinal + (filaInicial + i).ToString()).Style.Border.RightBorderColor = XLColor.Gray; //Color del borde derecho
                                sabanaDelDocumento.Row(filaInicial + i).Height = 14; //Alto de la fila
                                sabanaDelDocumento.Cell(filaInicial + i, "A").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left); //Textos alineados al borde izquierdo
                                sabanaDelDocumento.Cell(filaInicial + i, "A").Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center); //Textos alineados al centro
                                sabanaDelDocumento.Cell(filaInicial + i, "A").Style.Alignment.SetWrapText(true); //Ajusta los textos largos al ancho de la columna
                                sabanaDelDocumento.Cell(filaInicial + i, "A").Style.Font.SetFontName("Lucida Console").Font.SetFontSize(9); //Tipografia, tamaño de la fuente de los Textos y Negritas
                            }
                            sabanaDelDocumento.Range("A" + (filaInicial + filas).ToString(), indiceColumnaFinal + (filaInicial + filas).ToString()).Style.Border.TopBorder = XLBorderStyleValues.Medium; //Separador del borde infefior
                            sabanaDelDocumento.Range("A" + (filaInicial + filas).ToString(), indiceColumnaFinal + (filaInicial + filas).ToString()).Style.Border.TopBorderColor = XLColor.Gray; //Color del borde infefior
                            /* ---- Asignación de Datos --- */
                            int indiceValor = 0;
                            for (int i = 0; i < columnas; i++) //Relleno por columna y filas
                            {
                                for (int j = 0; j < filas; j++)
                                {
                                    if (indiceValor < leyenda.Length) sabanaDelDocumento.Cell(filaInicial + j, indiceColumna[0].ToString()).Value += leyenda[indiceValor].PadLeft(longitud, ' ') + ": " + (valor[indiceValor]).PadRight(12, ' '); //Inserta el dato en la celda
                                    indiceValor += 1;
                                    sabanaDelDocumento.Cell(filaInicial + j, indiceColumna[0].ToString()).SetDataType(XLDataType.Text); //Convierte el dato de la celda de la 1er columna en tipo texto
                                }
                            }
                        }
                        #endregion
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A004REPORTE: Hay un conflicto en la generación del Excel.", e);
            }
        }

        public void crearDocumentoExcel_Lista(string titulo, string[] subTitulos, int[] anchos, List<string[]> datoDB, List<int> indiceColumnaTipoFecha, int ajustarHoja = 100)
        {
            Cursor.Current = Cursors.WaitCursor;
            string nombreDeArchivo = titulo.Replace(" ", "_").Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u"); //Acondiciona el título del nombre del archivo
            string archivoXLSX = directorioTempXLSX + ("Listado_de_" + nombreDeArchivo + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".xlsx"); //Directorio temporal de PDF y Excel
            char[] indiceColumna = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P' }; //Lista de indices de columnas
            char indiceColumnaFinal = indiceColumna[subTitulos.Length - 1]; //Calcula el indice de la columna final
            try
            {
                using (var libroDelDocumento = new XLWorkbook())
                {
                    using (var sabanaDelDocumento = libroDelDocumento.Worksheets.Add("Empreminsa")) //Crea y especifica el nombre del la sabana
                    {
                        sabanaDelDocumento.PageSetup.SetPaperSize(XLPaperSize.A4Paper); //Pagina: Tamaño A4
                        sabanaDelDocumento.PageSetup.SetPageOrientation(XLPageOrientation.Landscape); //Pagina: Orientación horizontal
                        sabanaDelDocumento.PageSetup.AdjustTo(ajustarHoja); //Ajusta el contenido del documento al tamaño de una hoja A4 
                        sabanaDelDocumento.PageSetup.Margins.SetTop(0.75); //Pagina: Margen superior
                        sabanaDelDocumento.PageSetup.Margins.SetBottom(0.75); //Pagina: Margen inferior
                        sabanaDelDocumento.PageSetup.Margins.SetLeft(0.5); //Pagina: Margen izquierdo
                        sabanaDelDocumento.PageSetup.Margins.SetRight(0.5); //Pagina: Margen derecho
                        for (int i = 0; i < subTitulos.Length; i++) sabanaDelDocumento.Column(indiceColumna[i].ToString()).Width = anchos[i]; //Define el ancho de cada columna
                        crearEncabezado(); //Crea el encabezado del la página
                        for (int i = 0; i < datoDB.Count; i++) //Rellena las celdas de la tabla
                        {
                            //Definición de los campos de la Base de Datos
                            sabanaDelDocumento.Row(5 + i).Height = 12; //Alto de la fila
                            sabanaDelDocumento.Row(5 + i).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left); //Textos alineados al borde izquierdo
                            sabanaDelDocumento.Row(5 + i).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top); //Textos alineados al borde superior
                            sabanaDelDocumento.Row(5 + i).Style.Alignment.SetWrapText(true); //Ajusta los textos largos al ancho de la columna
                            sabanaDelDocumento.Row(5 + i).Style.Font.SetFontName("Arial").Font.SetFontSize(8); //Tipografia, tamaño de la fuente de los Textos
                            sabanaDelDocumento.Range("A" + (5 + i).ToString(), indiceColumnaFinal + (5 + i).ToString()).Style.Border.BottomBorder = XLBorderStyleValues.Medium; //Separador de cada registro
                            sabanaDelDocumento.Range("A" + (5 + i).ToString(), indiceColumnaFinal + (5 + i).ToString()).Style.Border.BottomBorderColor = XLColor.Gray; //Color del separador de cada registro
                            for (int j = 0; j < datoDB[i].Length; j++)
                            {
                                sabanaDelDocumento.Cell(5 + i, indiceColumna[j].ToString()).Value = datoDB[i][j]; //Inserta el dato en la celda
                                if (!indiceColumnaTipoFecha.Contains(j)) sabanaDelDocumento.Cell(5 + i, indiceColumna[j].ToString()).SetDataType(XLDataType.Text); //Convierte el dato de la celda a tipo Texto Plano
                                else if (indiceColumnaTipoFecha.Contains(j)) sabanaDelDocumento.Cell(5 + i, indiceColumna[j].ToString()).SetDataType(XLDataType.DateTime).Style.DateFormat.Format = "dd/MM/yyyy"; //Convierte el dato de la celda a tipo Fecha
                            }
                        }
                        sabanaDelDocumento.SetShowRowColHeaders(false); //Oculta los encabezados de las columnas y los números de las filas de la cuadricula de Excel
                        sabanaDelDocumento.SetShowGridLines(false); //Oculta las lineas de la cuadricula de Excel
                        sabanaDelDocumento.PageSetup.SetShowGridlines(false); //Oculta las lineas de la cuadricula de Excel
                        sabanaDelDocumento.Protect(Global.UsuarioActivo_Documento); //Protege el docuemento Excel con contraseña
                        libroDelDocumento.SaveAs(archivoXLSX); //Guarda el documento en la ruta especificada
                        abrirDocumentoExcel(); //Ejecuta el documento creado
                        #region Métodos Internos
                        void crearEncabezado()
                        {
                            /* -------- Paginación -------- */
                            sabanaDelDocumento.PageSetup.Header.Right.AddText("Listado de " + titulo + " - Página: ", XLHFOccurrence.AllPages); //Pie de página
                            sabanaDelDocumento.PageSetup.Header.Right.AddText(XLHFPredefinedText.PageNumber, XLHFOccurrence.AllPages); //Pie de página
                            /* ---- Logo de la Empresa ---- */
                            try
                            {
                                using (Bitmap imagenLogo = global::Biblioteca.Properties.Resources.logo_marca)
                                {
                                    var logo = sabanaDelDocumento.AddPicture(imagenLogo);
                                    logo.MoveTo(sabanaDelDocumento.Cell(1, 1).Address);
                                    logo.Scale(0.12, true);
                                }
                            }
                            catch (Exception e)
                            {
                                Mensaje.Error("Error-A006REPORTE: Hay un conflicto en la generación del Excel.\nNo se puede cargar el logo de la Empresa.", e);
                            }
                            /* ---------- Titulo ---------- */
                            sabanaDelDocumento.Cell(1, "A").Value = "Listado de " + titulo;
                            sabanaDelDocumento.Range("A1", indiceColumnaFinal + (1).ToString()).Merge(); //Combina la celdas
                            sabanaDelDocumento.Row(1).Height = 65; //Alto de la fila de paginación
                            sabanaDelDocumento.Row(1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center); //Alto de la fila de paginación
                            sabanaDelDocumento.Row(1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom); //Textos alineados al borde superior
                            sabanaDelDocumento.Row(1).Style.Font.SetFontName("Times_Roman").Font.SetFontSize(16).Font.SetBold(true); //Tipografia, tamaño y estilo de negritas para el titulo
                            sabanaDelDocumento.Row(1).Style.Font.SetFontColor(XLColor.FromArgb(0, 96, 100)); //Color de letra de los subTitulos
                            /* --- Espacio de separación --- */
                            sabanaDelDocumento.Range("A2", indiceColumnaFinal + (3).ToString()).Merge(); //Combina la celdas
                            sabanaDelDocumento.Row(2).Height = 10; //Alto de la fila de paginación
                            sabanaDelDocumento.Row(3).Height = 2; //Alto de la fila del separador
                            sabanaDelDocumento.Range("A3", indiceColumnaFinal + (3).ToString()).Merge(); //Combina la celdas
                            sabanaDelDocumento.Range("A3", indiceColumnaFinal + (3).ToString()).Style.Border.SetTopBorder(XLBorderStyleValues.Medium); //Borde del separador
                            sabanaDelDocumento.Range("A3", indiceColumnaFinal + (3).ToString()).Style.Border.SetTopBorderColor(XLColor.FromArgb(0, 96, 100)); //Color del borde del separador
                            /* --------- SubTitulos -------- */
                            sabanaDelDocumento.Row(4).Height = 12; //Alto de la fila de los subtitulos
                            sabanaDelDocumento.Row(4).Style.Font.SetFontName("Times_Roman").Font.SetFontSize(8).Font.SetBold(true); //Tipografia, tamaño y estilo de negritas para los subtitulos
                            sabanaDelDocumento.Range("A4", indiceColumnaFinal + (4).ToString()).Style.Font.SetFontColor(XLColor.White); //Color de letra de los subTitulos
                            sabanaDelDocumento.Range("A4", indiceColumnaFinal + (4).ToString()).Style.Fill.SetBackgroundColor(XLColor.Gray); //Color de fondo de los subTitulos
                            for (int i = 0; i < subTitulos.Length; i++) sabanaDelDocumento.Cell(4, indiceColumna[i].ToString()).Value = subTitulos[i]; //Inserta los subTitulos de las columnas
                        }
                        void abrirDocumentoExcel()
                        {
                            ProcessStartInfo proceso = new ProcessStartInfo();
                            proceso.FileName = "EXCEL.EXE";
                            proceso.Arguments = archivoXLSX;
                            Process.Start(proceso);
                        }
                        #endregion
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A008REPORTE: Hay un conflicto en la generación del Excel.", e);
            }
        }

        public void crearDocumentoExcel_PlantillaStock(string deposito, string[] subTitulos, int[] anchos, List<string[]> datoDB, int[] desprotegerColumnas)
        {
            Cursor.Current = Cursors.WaitCursor;
            string archivoXLSX = Archivo.GuardarArchivo("XLSX", "Plantilla_de_Control_de_Stock_" + deposito + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".xlsx");
            if (!string.IsNullOrEmpty(archivoXLSX))
            {
                char[] indiceColumna = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P' }; //Lista de indices de columnas
                char indiceColumnaFinal = indiceColumna[subTitulos.Length - 1]; //Calcula el indice de la columna final
                try
                {
                    using (var libroDelDocumento = new XLWorkbook())
                    {
                        using (var sabanaDelDocumento = libroDelDocumento.Worksheets.Add(deposito)) //Crea y especifica el nombre del la sabana
                        {
                            sabanaDelDocumento.PageSetup.SetPaperSize(XLPaperSize.A4Paper); //Pagina: Tamaño A4
                            sabanaDelDocumento.PageSetup.SetPageOrientation(XLPageOrientation.Landscape); //Pagina: Orientación horizontal
                            sabanaDelDocumento.PageSetup.Margins.SetTop(0.75); //Pagina: Margen superior
                            sabanaDelDocumento.PageSetup.Margins.SetBottom(0.75); //Pagina: Margen inferior
                            sabanaDelDocumento.PageSetup.Margins.SetLeft(0.5); //Pagina: Margen izquierdo
                            sabanaDelDocumento.PageSetup.Margins.SetRight(0.5); //Pagina: Margen derecho
                            for (int i = 0; i < subTitulos.Length; i++) sabanaDelDocumento.Column(indiceColumna[i].ToString()).Width = anchos[i]; //Define el ancho de cada columna
                            crearEncabezado(); //Crea el encabezado del la página
                            for (int i = 0; i < datoDB.Count; i++) //Rellena las celdas de la tabla
                            {
                                //Definición de los campos de la Base de Datos
                                sabanaDelDocumento.Row(5 + i).Height = 12; //Alto de la fila
                                sabanaDelDocumento.Row(5 + i).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left); //Textos alineados al borde izquierdo
                                sabanaDelDocumento.Row(5 + i).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top); //Textos alineados al borde superior
                                sabanaDelDocumento.Row(5 + i).Style.Alignment.SetWrapText(true); //Ajusta los textos largos al ancho de la columna
                                sabanaDelDocumento.Row(5 + i).Style.Font.SetFontName("Arial").Font.SetFontSize(8); //Tipografia, tamaño de la fuente de los Textos
                                sabanaDelDocumento.Range("A" + (5 + i).ToString(), indiceColumnaFinal + (5 + i).ToString()).Style.Border.BottomBorder = XLBorderStyleValues.Medium; //Separador de cada registro
                                sabanaDelDocumento.Range("A" + (5 + i).ToString(), indiceColumnaFinal + (5 + i).ToString()).Style.Border.BottomBorderColor = XLColor.Gray; //Color del separador de cada registro
                                for (int j = 0; j < datoDB[i].Length; j++)
                                {
                                    sabanaDelDocumento.Cell(5 + i, indiceColumna[j].ToString()).Value = datoDB[i][j]; //Inserta el dato en la celda
                                    sabanaDelDocumento.Cell(5 + i, indiceColumna[j].ToString()).SetDataType(XLDataType.Text); //Convierte el dato de la celda en tipo texto
                                }
                            }
                            sabanaDelDocumento.SetShowRowColHeaders(false); //Oculta los encabezados de las columnas y los números de las filas de la cuadricula de Excel
                            sabanaDelDocumento.SetShowGridLines(false); //Oculta las lineas de la cuadricula de Excel
                            sabanaDelDocumento.Protect(); //Protege el docuemento Excel
                            for (int i = 0; i < desprotegerColumnas.Length; i++) sabanaDelDocumento.Range(5, desprotegerColumnas[i], datoDB.Count + 4, desprotegerColumnas[i]).Style.Protection.SetLocked(false); //Desprotege las columnas indicadas
                            libroDelDocumento.SaveAs(archivoXLSX); //Guarda el documento en la ruta especificada
                            abrirDocumentoExcel(); //Ejecuta el documento creado
                            #region Métodos Internos
                            void crearEncabezado()
                            {
                                /* -------- Paginación -------- */
                                sabanaDelDocumento.PageSetup.Header.Right.AddText("Plantilla de Control de Stock (" + deposito + ") - Página: ", XLHFOccurrence.AllPages); //Pie de página
                                sabanaDelDocumento.PageSetup.Header.Right.AddText(XLHFPredefinedText.PageNumber, XLHFOccurrence.AllPages); //Pie de página
                                                                                                                                           /* ---- Logo de la Empresa ---- */
                                try
                                {
                                    using (Bitmap imagenLogo = global::Biblioteca.Properties.Resources.logo_marca)
                                    {
                                        var logo = sabanaDelDocumento.AddPicture(imagenLogo);
                                        logo.MoveTo(sabanaDelDocumento.Cell(1, 1).Address);
                                        logo.Scale(0.12, true);
                                    }
                                }
                                catch (Exception e)
                                {
                                    Mensaje.Error("Error-A010REPORTE: Hay un conflicto en la generación de la plantilla de Excel.\nNo se puede cargar el logo de la Empresa.", e);
                                }
                                /* ---------- Titulo ---------- */
                                sabanaDelDocumento.Cell(1, "A").Value = "Plantilla de Control de Stock";
                                sabanaDelDocumento.Range("A1", indiceColumnaFinal + (1).ToString()).Merge(); //Combina la celdas
                                sabanaDelDocumento.Row(1).Height = 65; //Alto de la fila de paginación
                                sabanaDelDocumento.Row(1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center); //Alto de la fila de paginación
                                sabanaDelDocumento.Row(1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom); //Textos alineados al borde superior
                                sabanaDelDocumento.Row(1).Style.Font.SetFontName("Times_Roman").Font.SetFontSize(16).Font.SetBold(true); //Tipografia, tamaño y estilo de negritas para el titulo
                                sabanaDelDocumento.Row(1).Style.Font.SetFontColor(XLColor.FromArgb(0, 96, 100)); //Color de letra de los subTitulos
                                /* ---- Titulo Secundario ----- */
                                sabanaDelDocumento.Cell(2, "A").Value = deposito + " (" + Fecha.SistemaFecha() + ")";
                                sabanaDelDocumento.Range("A2", indiceColumnaFinal + (2).ToString()).Merge(); //Combina la celdas
                                sabanaDelDocumento.Row(2).Height = 18; //Alto de la fila de paginación
                                sabanaDelDocumento.Row(2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center); //Alto de la fila de paginación
                                sabanaDelDocumento.Row(2).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center); //Textos alineados al borde superior
                                sabanaDelDocumento.Row(2).Style.Font.SetFontName("Times_Roman").Font.SetFontSize(10).Font.SetBold(true); //Tipografia, tamaño y estilo de negritas para el titulo
                                sabanaDelDocumento.Row(2).Style.Font.SetFontColor(XLColor.FromArgb(0, 96, 100)); //Color de letra de los subTitulos
                                /* --- Espacio de separación --- */
                                sabanaDelDocumento.Row(3).Height = 2; //Alto de la fila del separador
                                sabanaDelDocumento.Range("A3", indiceColumnaFinal + (3).ToString()).Merge(); //Combina la celdas
                                sabanaDelDocumento.Range("A3", indiceColumnaFinal + (3).ToString()).Style.Border.SetTopBorder(XLBorderStyleValues.Medium); //Borde del separador
                                sabanaDelDocumento.Range("A3", indiceColumnaFinal + (3).ToString()).Style.Border.SetTopBorderColor(XLColor.FromArgb(0, 96, 100)); //Color del borde del separador
                                /* --------- SubTitulos -------- */
                                sabanaDelDocumento.Row(4).Height = 12; //Alto de la fila de los subtitulos
                                sabanaDelDocumento.Row(4).Style.Font.SetFontName("Times_Roman").Font.SetFontSize(8).Font.SetBold(true); //Tipografia, tamaño y estilo de negritas para los subtitulos
                                sabanaDelDocumento.Range("A4", indiceColumnaFinal + (4).ToString()).Style.Font.SetFontColor(XLColor.White); //Color de letra de los subTitulos
                                sabanaDelDocumento.Range("A4", indiceColumnaFinal + (4).ToString()).Style.Fill.SetBackgroundColor(XLColor.Gray); //Color de fondo de los subTitulos
                                for (int i = 0; i < subTitulos.Length; i++) sabanaDelDocumento.Cell(4, indiceColumna[i].ToString()).Value = subTitulos[i]; //Inserta los subTitulos de las columnas
                            }
                            void abrirDocumentoExcel()
                            {
                                ProcessStartInfo proceso = new ProcessStartInfo();
                                proceso.FileName = "EXCEL.EXE";
                                proceso.Arguments = archivoXLSX;
                                Process.Start(proceso);
                            }
                            #endregion
                        }
                        Cursor.Current = Cursors.Default;
                    }
                }
                catch (Exception e)
                {
                    Mensaje.Error("Error-A012REPORTE: Hay un conflicto en la generación de la plantilla de Excel.", e);
                }
            }
        }

        public void crearDocumentoExcel_Registro(string titulo, string[] subTitulos, string[] datoDB)
        {
            string archivoXLSX = directorioTempXLSX + ("Registro_de_" + Formulario.ValidarTituloReporte(titulo) + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".xlsx"); //Directorio temporal de PDF y Excel
            try
            {
                using (var libroDelDocumento = new XLWorkbook())
                {
                    using (var sabanaDelDocumento = libroDelDocumento.Worksheets.Add("Empreminsa")) //Crea y especifica el nombre del la sabana
                    {
                        sabanaDelDocumento.PageSetup.SetPaperSize(XLPaperSize.A4Paper); //Pagina: Tamaño A4
                        sabanaDelDocumento.PageSetup.SetPageOrientation(XLPageOrientation.Portrait); //Pagina: Orientación vertical
                        sabanaDelDocumento.PageSetup.Margins.SetTop(0.75); //Pagina: Margen superior
                        sabanaDelDocumento.PageSetup.Margins.SetBottom(0.75); //Pagina: Margen inferior
                        sabanaDelDocumento.PageSetup.Margins.SetLeft(0.5); //Pagina: Margen izquierdo
                        sabanaDelDocumento.PageSetup.Margins.SetRight(0.5); //Pagina: Margen derecho
                        sabanaDelDocumento.Column("A").Width = 40; //Define el ancho de la columna A
                        sabanaDelDocumento.Column("B").Width = 45; //Define el ancho de la columna B
                        crearEncabezado(); //Crea el encabezado del la página
                        for (int i = 0; i < datoDB.Length; i++) //Rellena las celdas de la tabla
                        {
                            //Definición de los campos de la Base de Datos
                            sabanaDelDocumento.Row(4 + i).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top); //Textos alineados al borde superior
                            sabanaDelDocumento.Row(4 + i).Style.Font.SetFontName("Arial").Font.SetFontSize(8).Font.SetBold(true); //Tamaño de la fuente de los Textos
                            sabanaDelDocumento.Cell(4 + i, "A").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right); //SubTitulos alineados al borde derecha
                            sabanaDelDocumento.Cell(4 + i, "A").Style.Font.SetItalic(true).Font.SetBold(true); //Fuente tipo italic y en negritas para subtitulos
                            sabanaDelDocumento.Cell(4 + i, "A").Value = subTitulos[i]; //Inserta el subTitulo en la celda
                            sabanaDelDocumento.Cell(4 + i, "B").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left; //Textos alineados al borde izquierdo
                            sabanaDelDocumento.Cell(4 + i, "B").Value = datoDB[i]; //Inserta el dato en la celda
                            sabanaDelDocumento.Cell(4 + i, "B").Style.Alignment.SetWrapText(true); //Ajusta los textos largos al ancho de la columna
                        }
                        sabanaDelDocumento.Cell(5, "B").SetDataType(XLDataType.Text); //Convierte el dato de la celda de la 5ta fila en tipo texto
                        sabanaDelDocumento.Cell(6, "B").SetDataType(XLDataType.Text); //Convierte el dato de la celda de la 6ta fila en tipo texto
                        sabanaDelDocumento.SetShowRowColHeaders(false); //Oculta los encabezados de las columnas y los números de las filas de la cuadricula de Excel
                        sabanaDelDocumento.SetShowGridLines(false); //Oculta las lineas de la cuadricula de Excel
                        sabanaDelDocumento.Protect(Global.UsuarioActivo_Documento); //Protege el docuemento Excel con contraseña
                        libroDelDocumento.SaveAs(archivoXLSX); //Guarda el documento en la ruta especificada
                        abrirDocumentoExcel(); //Ejecuta el documento creado
                        #region Métodos Internos
                        void crearEncabezado()
                        {
                            /* -------- Paginación -------- */
                            sabanaDelDocumento.PageSetup.Header.Right.AddText("Registro de " + titulo + " - Página: ", XLHFOccurrence.AllPages); //Pie de página
                            sabanaDelDocumento.PageSetup.Header.Right.AddText(XLHFPredefinedText.PageNumber, XLHFOccurrence.AllPages); //Pie de página
                            /* ---- Logo de la Empresa ---- */
                            try
                            {
                                using (Bitmap imagenLogo = global::Biblioteca.Properties.Resources.logo_marca)
                                {
                                    var logo = sabanaDelDocumento.AddPicture(imagenLogo);
                                    logo.MoveTo(sabanaDelDocumento.Cell(1, 1).Address);
                                    logo.Scale(0.10, true);
                                }
                            }
                            catch (Exception e)
                            {
                                Mensaje.Error("Error-A014REPORTE: Hay un conflicto en la generación del Excel.\nNo se puede cargar el logo de la Empresa.", e);
                            }
                            /* ---------- Titulo ---------- */
                            sabanaDelDocumento.Cell(1, "A").Value = "Registro de " + titulo;
                            sabanaDelDocumento.Range("A1", "B1").Merge(); //Combina la celdas
                            sabanaDelDocumento.Row(1).Height = 65; //Alto de la fila de paginación
                            sabanaDelDocumento.Row(1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center); //Alto de la fila de paginación
                            sabanaDelDocumento.Row(1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom); //Textos alineados al borde superior
                            sabanaDelDocumento.Row(1).Style.Font.SetFontName("Times_Roman").Font.SetFontSize(16).Font.SetBold(true); //Tipografia, tamaño y estilo de negritas para el titulo
                            sabanaDelDocumento.Row(1).Style.Font.SetFontColor(XLColor.FromArgb(0, 96, 100)); //Color de letra de los subTitulos
                            /* --- Espacio de separación --- */
                            sabanaDelDocumento.Range("A2", "B2").Merge(); //Combina la celdas
                            sabanaDelDocumento.Row(2).Height = 10; //Alto de la fila de paginación
                            /* --------- Separador --------- */
                            sabanaDelDocumento.Row(3).Height = 5; //Alto de la fila del separador
                            sabanaDelDocumento.Range("A3", "B3").Merge(); //Combina la celdas
                            sabanaDelDocumento.Range("A3", "B3").Style.Border.SetTopBorder(XLBorderStyleValues.Medium); //Borde del separador
                            sabanaDelDocumento.Range("A3", "B3").Style.Border.SetTopBorderColor(XLColor.FromArgb(0, 96, 100)); //Color del borde del separador
                        }
                        void abrirDocumentoExcel()
                        {
                            ProcessStartInfo proceso = new ProcessStartInfo();
                            proceso.FileName = "EXCEL.EXE";
                            proceso.Arguments = archivoXLSX;
                            Process.Start(proceso);
                        }
                        #endregion
                    }
                }
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A016REPORTE: Hay un conflicto en la generación del Excel.", e);
            }
        }

        public void crearDocumentoPDF_Lista(string titulo, string[] subTitulos, float[] anchos, List<string[]> datoDB)
        {
            Cursor.Current = Cursors.WaitCursor;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");
            try
            {
                string archivoPDF = directorioTempPDF + "Listado de " + titulo + DateTime.Now.ToString(@" yyyy-MM-dd(hhmmss)") + ".pdf"; //Directorio temporal de PDF y Excel
                using (Document documentoPDF = new Document(PageSize.A4.Rotate(), 15f, 15f, 15f, 15f)) //Crea el documento PDF: Define el tamaño como A4 y margenes
                {
                    PdfWriter lapiz = PdfWriter.GetInstance(documentoPDF, new FileStream(archivoPDF, FileMode.Create)); //Crea el archivo PDF                
                    EncabezadoPDF encabezadoPDF = new EncabezadoPDF("Listado de " + titulo, subTitulos, anchos); //Encabezado de la página
                    lapiz.PageEvent = encabezadoPDF;
                    documentoPDF.Open(); //Abre el documento para su confección 
                    documentoPDF.AddTitle("Empreminsa - Listado de " + titulo); //Asigna un titulo para las propiedades del documento 
                    documentoPDF.AddCreator("Empreminsa"); //Asigna un Autor para las propiedades del documento
                    PdfPTable tablaPDF = new PdfPTable(subTitulos.Length); //Crea la tabla de datos
                    tablaPDF.SpacingBefore = 5f; //Espacio sobre el margen superior
                    tablaPDF.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER; //Quita los bordes de las celas de todo la página
                    tablaPDF.WidthPercentage = 100; //Especicifica que ocuper el 100% de la página
                    tablaPDF.SetWidths(anchos); //Especifica el ancho de cada columna
                    for (int i = 0; i < datoDB.Count; i++) //Rellena las celdas de la tabla
                    {
                        for (int j = 0; j < datoDB[i].Length; j++)
                        {
                            PdfPCell celda = new PdfPCell(new iTextSharp.text.Paragraph(datoDB[i][j], FontFactory.GetFont("Arial", 8, 2))); //Crea una celda en las filas
                            celda.Border = PdfPCell.BOTTOM_BORDER; //Especifica un borde inferior para la celda
                            celda.BorderColor = new BaseColor(System.Drawing.Color.Gray); //Especifica el color del borde
                            celda.HorizontalAlignment = Element.ALIGN_LEFT; //Alinea el texto de la celda
                            tablaPDF.AddCell(celda); //Agrega la celda a la fila de la tabla
                        }
                    }
                    documentoPDF.Add(tablaPDF); //Agrega la tabla ala documento
                }
                /* --- Muestra el documento generado --- */
                System.Diagnostics.Process pdf = new System.Diagnostics.Process();
                pdf.StartInfo.FileName = archivoPDF;
                pdf.Start();
                pdf.Dispose();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A018REPORTE: Hay un conflicto en la generación del PDF.", e);
            }
        }

        public void crearDocumentoPDF_Registro(string titulo, string[] subTitulos, string[] datoDB)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");
            try
            {
                string archivoPDF = directorioTempPDF + "Registro de " + Formulario.ValidarTituloReporte(titulo) + DateTime.Now.ToString(@" yyyy-MM-dd(hhmmss)") + ".pdf"; //Directorio temporal de PDF y Excel
                using (Document documentoPDF = new Document(PageSize.A4, 15, 15, 15, 15)) //Crea el documento PDF: Define el tamaño como A4 y margenes
                {
                    PdfWriter lapiz = PdfWriter.GetInstance(documentoPDF, new FileStream(archivoPDF, FileMode.Create)); //Crea el archivo PDF
                    documentoPDF.AddTitle("Empreminsa - " + titulo); //Asigna un titulo para las propiedades del documento 
                    documentoPDF.AddCreator("Empreminsa"); //Asigna un Autor para las propiedades del documento
                    documentoPDF.Open(); //Abre el documento para su confección 
                    crearLogo(); //Crea el logo del documento
                    crearTitulo(titulo); //Crea el titulo del documento
                    PdfPTable tabla = new PdfPTable(2); //Crea la tabla de datos
                    tabla.SpacingBefore = 5f; //Espacio sobre el margen superior
                    for (int i = 0; i < subTitulos.Length; i++) { agregarFila(subTitulos[i], datoDB[i]); } //Agrega las filas a la tabla
                    documentoPDF.Add(tabla); //Agrega la tabla ala documento
                    #region Métodos Internos
                    void crearLogo()
                    {
                        using (FileStream imagenPNG = new FileStream(Archivo.ValidarDirectorio(@"Logo\") + "logo_marca.png", FileMode.Open))
                        {
                            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(imagenPNG),
                                System.Drawing.Imaging.ImageFormat.Png);
                            imagen.ScaleToFit(180f, 40f);
                            imagen.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
                            documentoPDF.Add(imagen);
                        }
                    }
                    void crearTitulo(string texto) //Título del documento
                    {
                        iTextSharp.text.Paragraph tituloPDF = new iTextSharp.text.Paragraph("Registro de " + texto, FontFactory.GetFont("Times_Roman", 16, 0, new BaseColor(0, 96, 100))); //Crea el titulo del documento
                        tituloPDF.Font.SetStyle("bold");
                        tituloPDF.Alignment = Element.ALIGN_CENTER;
                        iTextSharp.text.Paragraph paginaPDF = new iTextSharp.text.Paragraph("Página: " + lapiz.PageNumber.ToString(), FontFactory.GetFont("Times_Roman", 8, 0, new BaseColor(0, 96, 100))); //Crea el titulo del documento
                        paginaPDF.SpacingAfter = 3f; //Espacio sobre el margen inferior
                        paginaPDF.Alignment = Element.ALIGN_RIGHT;
                        LineSeparator separador = new LineSeparator(1f, 100f, new BaseColor(0, 96, 100), 1, 0); //Separador: Crea una linea de color gris
                        separador.Alignment = Element.ALIGN_BOTTOM;
                        documentoPDF.Add(tituloPDF);
                        documentoPDF.Add(paginaPDF);
                        documentoPDF.Add(separador);
                    }
                    void agregarFila(string subTitulo, string dato)
                    {
                        PdfPCell celda1 = new PdfPCell(new iTextSharp.text.Paragraph(subTitulo, FontFactory.GetFont("Arial", 10, 2)));
                        celda1.Border = PdfPCell.NO_BORDER;
                        celda1.HorizontalAlignment = Element.ALIGN_RIGHT;
                        tabla.AddCell(celda1);
                        PdfPCell celda2 = new PdfPCell(new iTextSharp.text.Paragraph(dato, FontFactory.GetFont("Arial", 10, 1)));
                        celda2.Border = PdfPCell.NO_BORDER;
                        celda2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                        tabla.AddCell(celda2);
                    }
                    #endregion
                }
                /* --- Muestra el documento generado --- */
                System.Diagnostics.Process pdf = new System.Diagnostics.Process();
                pdf.StartInfo.FileName = archivoPDF;
                pdf.Start();
                pdf.Dispose();
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A020REPORTE: Hay un conflicto en la generación del PDF.", e);
            }
        }

        public void crearDocumentoWord_AcusePago(string titulo, string[] datoDB)
        {
            string xxx = Formulario.ValidarTituloReporte(titulo);
            string archivoDocX = directorioTempDOCX + "Acuse_de_pago_de_" + Formulario.ValidarTituloReporte(titulo) + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".docx"; //Directorio temporal de PDF y Excel
            try
            {
                using (var document = DocX.Create(archivoDocX))
                {
                    var plantillaDocX = directorioPlantilla + @"Acuse_Pago.docx"; //Plantilla de acuse de pago
                    document.ApplyTemplate(plantillaDocX);
                    document.ReplaceText("TXT001_sys", datoDB[0]); //Pto.Vta. y N° de Pago
                    document.ReplaceText("TXT002_sys", datoDB[1]); //Denominación del Beneficiario
                    document.ReplaceText("TXT003_sys", datoDB[2]); //CUIL/CUIT del Beneficiario
                    document.ReplaceText("TXT004_sys", datoDB[3]); //Fecha escrita
                    document.ReplaceText("TXT005_sys", "$ " + datoDB[4]); //Monto $
                    document.ReplaceText("TXT006_sys", datoDB[5]); //Monto escrito
                    document.ReplaceText("TXT007_sys", datoDB[6]); //Concepto
                    document.ReplaceText("TXT008_sys", datoDB[7]); //Forma de pago
                    document.AddPasswordProtection(EditRestrictions.readOnly, Global.UsuarioActivo_Documento); //Protege el docuemento Excel con contraseña
                    document.Save(); //Guarda el documento archivo creado
                    abrirDocumentoWord();
                }
                #region Métodos Internos
                void abrirDocumentoWord()
                {
                    ProcessStartInfo proceso = new ProcessStartInfo();
                    Process.Start(archivoDocX);
                }
                #endregion
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A022REPORTE: Hay un conflicto en la generación del acuse de recibo.", e);
            }
        }

        public void crearDocumentoWord_Contrato(string titulo, string[] datoDB)
        {
            string archivoDocX = directorioTempDOCX + "Contrato_de_" + Formulario.ValidarTituloReporte(titulo) + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".docx"; //Directorio temporal de PDF y Excel
            try
            {
                using (var document = DocX.Create(archivoDocX))
                {
                    if (datoDB[10].Trim() == "DIARIO") datoDB[10] = "día"; //Modalidad de liquidación por día
                    else if (datoDB[10].Trim() == "HORA") datoDB[10] = "hora"; //Modalidad de liquidación por hora
                    else if (datoDB[10].Trim() == "MENSUAL") datoDB[10] = "mes"; //Modalidad de liquidación por mes
                    else if (datoDB[10].Trim() == "QUINCENAL") datoDB[10] = "quincena"; //Modalidad de liquidación por quincena
                    else if (datoDB[10].Trim() == "SEMANAL") datoDB[10] = "semana"; //Modalidad de liquidación por semana
                    #region Tipo de Convenio
                    var plantillaDocX = directorioPlantilla + @"Contrato_Eventual_Con_Convenio.docx"; //Contrato con Convenio
                    if (datoDB[12].Trim() == "") plantillaDocX = directorioPlantilla + @"Contrato_Eventual_Fuera_De_Convenio.docx"; //Contrato fuera de Convenio
                    else if (datoDB[12].Trim() == "2") plantillaDocX = directorioPlantilla + @"Contrato_Eventual_Con_Convenio_UOCRA.docx"; //Contrato con Convenio UOCRA
                    #endregion
                    document.ApplyTemplate(plantillaDocX);
                    document.ReplaceText("TXT001_sys", datoDB[0]); //Razón Social de la Empresa
                    document.ReplaceText("TXT002_sys", datoDB[1]); //Domicilio de la Empresa
                    document.ReplaceText("TXT003_sys", datoDB[2]); //Nombre del Empleado
                    document.ReplaceText("TXT004_sys", datoDB[3]); //Domicilio del Empleado
                    document.ReplaceText("TXT005_sys", datoDB[4]); //Nacionalidad del Empleado
                    document.ReplaceText("TXT006_sys", datoDB[5]); //Documento del Empleado
                    document.ReplaceText("TXT007_sys", datoDB[6]); //Tipo de contrato
                    document.ReplaceText("TXT008_sys", datoDB[7]); //Centro de costo
                    document.ReplaceText("TXT009_sys", datoDB[8]); //Categoría laboral
                    document.ReplaceText("TXT010_sys", datoDB[9]); //Sindicato
                    document.ReplaceText("TXT011_sys", datoDB[10].ToLower()); //Tipo de remuneracion
                    document.ReplaceText("TXT012_sys", "$ " + Formulario.ValidarCampoMoneda(datoDB[11])); //Remuneracion $
                    document.ReplaceText("TXT013_sys", Fecha.SistemaFecha_Escrita()); //Fecha actual escrita
                    string v = Fecha.SistemaFecha_Escrita();
                    document.ReplaceText("TXT014_sys", Fecha.SistemaFecha_Escrita().Replace("días ", "").Replace("día ", "")); //Fecha actual escrita sin la palabra "día" o "días"
                    document.AddPasswordProtection(EditRestrictions.readOnly, Global.UsuarioActivo_Documento); //Protege el docuemento Excel con contraseña
                    document.Save(); //Guarda el documento archivo creado
                    abrirDocumentoWord();
                }
                #region Métodos Internos
                void abrirDocumentoWord()
                {
                    ProcessStartInfo proceso = new ProcessStartInfo();
                    Process.Start(archivoDocX);
                }
                #endregion
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A024REPORTE: Hay un conflicto en la generación del contrato.", e);
            }
        }

        public void crearDocumentoWord_LegajoLaboralDDJJ(string titulo, string[] datoDB, string DDJJ)
        {
            #region Tipo de DDJJ
            var plantillaDocX = directorioPlantilla + @"DDJJ_Anses.docx"; //DDJJ de ANSES
            string archivoDocX = directorioTempDOCX + "DDJJ_Anses_de_" + Formulario.ValidarTituloReporte(titulo) + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".docx"; //Directorio temporal de PDF y Excel
            if (DDJJ == "ART")
            {
                plantillaDocX = directorioPlantilla + @"DDJJ_ART.docx"; //DDJJ de ART
                archivoDocX = directorioTempDOCX + "DDJJ_ART_de_" + Formulario.ValidarTituloReporte(titulo) + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".docx"; //Directorio temporal de PDF y Excel
            }
            else if (DDJJ == "DESEMPLEO")
            {
                plantillaDocX = directorioPlantilla + @"DDJJ_Desempleo.docx"; //DDJJ de Desempleo
                archivoDocX = directorioTempDOCX + "DDJJ_Desempleo_de_" + Formulario.ValidarTituloReporte(titulo) + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".docx"; //Directorio temporal de PDF y Excel
            }
            else if (DDJJ == "DOMICILIO")
            {
                plantillaDocX = directorioPlantilla + @"DDJJ_Domicilio.docx"; //DDJJ de Domicilio
                archivoDocX = directorioTempDOCX + "DDJJ_Domicilio_de_" + Formulario.ValidarTituloReporte(titulo) + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".docx"; //Directorio temporal de PDF y Excel
            }
            else if (DDJJ == "OBRA SOCIAL")
            {
                plantillaDocX = directorioPlantilla + @"DDJJ_ObraSocial.docx"; //DDJJ de Obra Social
                archivoDocX = directorioTempDOCX + "DDJJ_ObraSocial_de_" + Formulario.ValidarTituloReporte(titulo) + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".docx"; //Directorio temporal de PDF y Excel
            }
            else if (DDJJ == "PERSONAL")
            {
                plantillaDocX = directorioPlantilla + @"DDJJ_Personal.docx"; //DDJJ Personal
                archivoDocX = directorioTempDOCX + "DDJJ_Personal_de_" + Formulario.ValidarTituloReporte(titulo) + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".docx"; //Directorio temporal de PDF y Excel
            }
            else if (DDJJ == "SEGURO")
            {
                plantillaDocX = directorioPlantilla + @"DDJJ_Seguro.docx"; //DDJJ de Seguro
                archivoDocX = directorioTempDOCX + "DDJJ_Seguro_de_" + Formulario.ValidarTituloReporte(titulo) + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".docx"; //Directorio temporal de PDF y Excel
            }
            #endregion
            try
            {
                using (var document = DocX.Create(archivoDocX))
                {
                    document.ApplyTemplate(plantillaDocX);
                    document.ReplaceText("TXT001_sys", Fecha.SistemaFecha_Escrita()); //Fecha actual escrita
                    document.ReplaceText("TXT002_sys", datoDB[0]); //Denominación del empleado
                    document.ReplaceText("TXT003_sys", datoDB[1]); //N° de Legajo contable
                    document.ReplaceText("TXT004_sys", datoDB[2]); //Documento del empleado
                    document.ReplaceText("TXT005_sys", datoDB[3]); //Cuil del empleado
                    document.ReplaceText("TXT006_sys", datoDB[4]); //Denominación del centro de costo
                    if (DDJJ == "DOMICILIO")
                    {
                        document.ReplaceText("TXT007_sys", datoDB[5]); //Domicilio del empleado
                        document.ReplaceText("TXT008_sys", datoDB[6]); //Provincia del empleado
                        document.ReplaceText("TXT009_sys", datoDB[7]); //Distrito del empleado
                        document.ReplaceText("TXT010_sys", datoDB[8]); //CP del empleado
                    }
                    else if (DDJJ == "OBRA SOCIAL")
                    {
                        document.ReplaceText("_T7", (string.IsNullOrEmpty(datoDB[5])) ? "" : "SI"); //Tiene Obra Social
                        document.ReplaceText("_T8", (string.IsNullOrEmpty(datoDB[5])) ? "NO" : ""); //No tiene Obra Social
                        document.ReplaceText("TXT009_sys", datoDB[5]); //Obra Social del empleado
                        document.ReplaceText("TXT010_sys", datoDB[6]); //Códgio de la Obra Social del empleado
                    }
                    else if (DDJJ == "PERSONAL")
                    {
                        document.ReplaceText("TXT007_sys", datoDB[5]); //Fecha de nacimiento del empleado
                        document.ReplaceText("TXT008_sys", datoDB[6]); //Nacionalidad del empleado
                        document.ReplaceText("TXT009_sys", datoDB[7]); //Estado civil del empleado
                        document.ReplaceText("TXT010_sys", datoDB[8]); //Domicilio del empleado
                        document.ReplaceText("TXT011_sys", datoDB[9]); //Provincia del empleado
                        document.ReplaceText("TXT012_sys", datoDB[10]); //Distrito del empleado
                        document.ReplaceText("TXT013_sys", datoDB[11]); //CP del empleado
                        document.ReplaceText("TXT014_sys", datoDB[12]); //teléfono y/o celular del empleado
                        document.ReplaceText("TXT015_sys", datoDB[13]); //C.C.T.
                        document.ReplaceText("TXT016_sys", datoDB[14]); //Obra social
                        document.ReplaceText("TXT017_sys", datoDB[15]); //Categoría
                        document.ReplaceText("TXT018_sys", datoDB[16]); //Cargo
                        document.ReplaceText("TXT019_sys", datoDB[17]); //Licencia de concudir del empleado
                        document.ReplaceText("TXT020_sys", datoDB[18]); //Nivel de estudios del empleado
                        document.ReplaceText("TXT021_sys", datoDB[19]); //Afiliado al Sindicato
                        document.ReplaceText("TXT022_sys", datoDB[20]); //Tipo de sangre del empleado
                        document.ReplaceText("TXT023_sys", datoDB[21]); //Talle de camisa del empleado
                        document.ReplaceText("TXT024_sys", datoDB[22]); //Talle de pantalón del empleado
                        document.ReplaceText("TXT025_sys", datoDB[23]); //Talle de calzado del empleado
                        document.ReplaceText("TXT026_sys", datoDB[24]); //Estado del Curso de inducción
                        document.ReplaceText("TXT027_sys", datoDB[25]); //Vto del Curso de inducción
                        document.ReplaceText("TXT028_sys", datoDB[26]); //Estado del Control médico
                        document.ReplaceText("TXT029_sys", datoDB[27]); //Vto del Control médico
                        document.ReplaceText("TXT030_sys", datoDB[28]); //Estado del Certficado de antecedentes
                        document.ReplaceText("TXT031_sys", datoDB[29]); //Vto. del Certficado de antecedentes
                    }
                    document.AddPasswordProtection(EditRestrictions.readOnly, Global.UsuarioActivo_Documento); //Protege el docuemento Excel con contraseña
                    document.Save(); //Guarda el documento archivo creado
                    abrirDocumentoWord();
                }
                #region Métodos Internos
                void abrirDocumentoWord()
                {
                    ProcessStartInfo proceso = new ProcessStartInfo();
                    Process.Start(archivoDocX);
                }
                #endregion
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A026REPORTE: Hay un conflicto en la generación de la DDJJ " + DDJJ + ".", e);
            }
        }

        public void crearDocumentoWord_Comprobante(string titulo, string[] datoDB)
        {
            string archivoDocX = directorioTempDOCX + "Comprobante_de_" + Formulario.ValidarTituloReporte(titulo) + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".docx"; //Directorio temporal de PDF y Excel
            try
            {
                using (var document = DocX.Create(archivoDocX))
                {
                    var plantillaDocX = directorioPlantilla + @"Comprobante.docx"; //Comprobante
                    document.ApplyTemplate(plantillaDocX);
                    document.ReplaceText("TXT001_sys", datoDB[0]); //N° de Recibo
                    document.ReplaceText("TXT002_sys", datoDB[1]); //Denominación del empleado
                    document.ReplaceText("TXT003_sys", datoDB[2]); //N° de Legajo contable
                    document.ReplaceText("TXT004_sys", datoDB[3]); //Documento del empleado
                    document.ReplaceText("TXT005_sys", datoDB[4]); //Cuil del empleado
                    document.ReplaceText("TXT006_sys", datoDB[5]); //Denominación del centro de costo
                    document.ReplaceText("TXT007_sys", datoDB[6]); //Fecha actual escrita
                    document.ReplaceText("TXT008_sys", "$ " + Formulario.ValidarCampoMoneda(datoDB[7])); //Remuneracion $
                    document.ReplaceText("TXT009_sys", datoDB[8]); //Monto escrito
                    document.ReplaceText("TXT010_sys", datoDB[9]); //Concepto
                    document.ReplaceText("TXT011_sys", datoDB[10]); //Forma de pago
                    document.AddPasswordProtection(EditRestrictions.readOnly, Global.UsuarioActivo_Documento); //Protege el docuemento Excel con contraseña
                    document.Save(); //Guarda el documento archivo creado
                    abrirDocumentoWord();
                }
                #region Métodos Internos
                void abrirDocumentoWord()
                {
                    ProcessStartInfo proceso = new ProcessStartInfo();
                    Process.Start(archivoDocX);
                }
                #endregion
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A028REPORTE: Hay un conflicto en la generación del comprobante.", e);
            }
        }

        public void crearDocumentoWord_Comprobante_FormularioR29911(string titulo, string[] datoDB, List<FormularioR29911Detalle> detalle)
        {
            string archivoDocX = directorioTempDOCX + "Entrega_de_Indumentaria_y_EPP_de_" + Formulario.ValidarTituloReporte(titulo) + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".docx"; //Directorio temporal de PDF y Excel
            try
            {
                using (var document = DocX.Create(archivoDocX))
                {
                    var plantillaDocX = directorioPlantilla + @"FormularioR299-11.docx"; //Plantilla de movimiento de stock
                    document.ApplyTemplate(plantillaDocX);
                    document.ReplaceText("TXT001_sys", datoDB[0]); //N° de Comprobante
                    document.ReplaceText("TXT002_sys", Global.Empresa_RazonSocial);
                    document.ReplaceText("TXT003_sys", Global.Empresa_CUIT);
                    document.ReplaceText("TXT004_sys", Global.Empresa_Domicilio);
                    document.ReplaceText("TXT005_sys", Global.Empresa_Distrito);
                    document.ReplaceText("TXT6_sys", Global.Empresa_CodigoPostal);
                    document.ReplaceText("TXT007_sys", Global.Empresa_Provincia);
                    document.ReplaceText("TXT008_sys", datoDB[1]); //Denominacion del Empleado
                    document.ReplaceText("TXT009_sys", datoDB[2]); //Documento del Empleado
                    document.ReplaceText("TXT010_sys", datoDB[3]); //Descripción del puesto
                    document.ReplaceText("TXT011_sys", datoDB[4]); //EPP necesarios para el puesto
                    document.ReplaceText("TXT012_sys", datoDB[5]); //Información adicional    
                    for (int i = 0; i < 30; i++) //Recorre el detalle del comprobante
                    {
                        string fila = "_F" + Convert.ToString(i).PadLeft(2, '0');
                        string[] denominacion = (detalle.Count > i) ? detalle[i].Denominacion.Trim().Split(';') : new string[]{ "", "", ""};
                        document.ReplaceText("C1" + fila, denominacion[0]);
                        document.ReplaceText("C2" + fila, (denominacion.Length >= 2) ? denominacion[1] : "");
                        document.ReplaceText("C3" + fila, (denominacion.Length >= 3) ? denominacion[2] : "");
                        document.ReplaceText("C4" + fila, ((detalle.Count > i) ? detalle[i].Certificacion : ""));
                        document.ReplaceText("C5" + fila, ((detalle.Count > i) ? detalle[i].Cantidad.ToString() : ""));
                        document.ReplaceText("C6" + fila, ((detalle.Count > i) ? Fecha.ConvertirFecha(detalle[i].FechaEntrega) : ""));
                    }
                    document.AddPasswordProtection(EditRestrictions.readOnly, Global.UsuarioActivo_Documento); //Protege el docuemento Excel con contraseña
                    document.Save(); //Guarda el documento archivo creado
                    abrirDocumentoWord();
                }
                #region Métodos Internos
                void abrirDocumentoWord()
                {
                    ProcessStartInfo proceso = new ProcessStartInfo();
                    Process.Start(archivoDocX);
                }
                #endregion
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A030REPORTE: Hay un conflicto en la generación del formulario R299/11.", e);
            }
        }

        public void crearDocumentoWord_Comprobante_OrdenCompra(string titulo, string[] datoDB, List<OrdenCompraDetalle> detalle)
        {
            string archivoDocX = directorioTempDOCX + "Comprobante_Orden_de_Compra_de_" + Formulario.ValidarTituloReporte(titulo) + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".docx"; //Directorio temporal de PDF y Excel
            try
            {
                using (var document = DocX.Create(archivoDocX))
                {
                    var plantillaDocX = directorioPlantilla + @"Comprobante_Orden_Compra.docx"; //Plantilla de orden de compra
                    document.ApplyTemplate(plantillaDocX);
                    document.MarginLeft = 33.5f; //Establece el márgen izquierdo del documento
                    document.MarginRight = 33.5f; //Establece el márgen derecho del documento
                    document.ReplaceText("TXT001_sys", Global.Empresa_RazonSocial);
                    document.ReplaceText("TXT002_sys", Global.Empresa_Domicilio + " - " + Global.Empresa_Distrito + " - " + Global.Empresa_Provincia + " - Argentina");
                    document.ReplaceText("TXT003_sys", Global.Empresa_Telefono);
                    document.ReplaceText("TXT004_sys", Global.Empresa_IVA);
                    document.ReplaceText("TXT005_sys", "ORDEN DE COMPRA");
                    document.ReplaceText("TXT006_sys", datoDB[0]); //Pto.Vta.
                    document.ReplaceText("TXT007_sys", datoDB[1]); //N° de Pago
                    document.ReplaceText("TXT008_sys", datoDB[2]); //Fecha y hora
                    document.ReplaceText("TXT009_sys", Global.Empresa_CUIT);
                    document.ReplaceText("TXT010_sys", Global.Empresa_IIBB);
                    document.ReplaceText("TXT011_sys", Global.Empresa_InicioActividad);
                    document.ReplaceText("TXT012_sys", datoDB[3]); //Denominación del proveedor
                    document.ReplaceText("TXT013_sys", datoDB[4]); //Domicilio del proveedor
                    document.ReplaceText("TXT014_sys", datoDB[5]); //Provincia del proveedor
                    document.ReplaceText("TXT015_sys", datoDB[6]); //Distrito del proveedor
                    document.ReplaceText("TXT016_sys", datoDB[7]); //Código Postal del proveedor
                    document.ReplaceText("TXT017_sys", datoDB[8]); //Teléfono y celular del proveedor
                    document.ReplaceText("TXT018_sys", datoDB[9]); //CUIT del proveedor
                    document.ReplaceText("TXT019_sys", datoDB[10]); //IVA del proveedor
                    document.ReplaceText("TXT020_sys", datoDB[11]); //Fecha de arribo
                    document.ReplaceText("TOT01_sys", datoDB[12]); //Descuento
                    document.ReplaceText("TOT02_sys", datoDB[13]); //SubTotal
                    document.ReplaceText("TOT03_sys", datoDB[14]); //IVA 10.5
                    document.ReplaceText("TOT04_sys", datoDB[15]); //IVA 21.0
                    document.ReplaceText("TOT05_sys", datoDB[16]); //IVA 27.0
                    document.ReplaceText("TOT06_sys", datoDB[17]); //Percepción IIBB
                    document.ReplaceText("TOT07_sys", datoDB[18]); //Percepción LH
                    document.ReplaceText("TOT08_sys", datoDB[19]); //Percepción IVA
                    document.ReplaceText("TOT09_sys", datoDB[20]); //No Grabado
                    document.ReplaceText("TOT10_sys", datoDB[21]); //Total
                    for (int i = 0; i < 30; i++) //Recorre el detalle del comprobante
                    {
                        string fila = "_F" + Convert.ToString(i).PadLeft(2, '0');
                        document.ReplaceText("C1" + fila, ((detalle.Count > i) ? detalle[i].IdArticulo.ToString().PadLeft(6, '0') : ""));
                        document.ReplaceText("C2" + fila, ((detalle.Count > i) ? detalle[i].Denominacion : ""));
                        document.ReplaceText("C3" + fila, ((detalle.Count > i) ? detalle[i].Cantidad.ToString() : ""));
                        document.ReplaceText("C4" + fila, ((detalle.Count > i) ? detalle[i].Unidad : ""));
                        document.ReplaceText("C5" + fila, ((detalle.Count > i) ? detalle[i].Deposito : ""));
                        document.ReplaceText("C6" + fila, ((detalle.Count > i) ? Formulario.ValidarCampoMoneda(detalle[i].CostoUnitario) : ""));
                        document.ReplaceText("C7" + fila, ((detalle.Count > i) ? "%" + detalle[i].AlicuotaIVA : ""));
                        document.ReplaceText("C8" + fila, ((detalle.Count > i) ? Formulario.ValidarCampoMoneda(detalle[i].BaseIVA) : ""));
                        document.ReplaceText("C9" + fila, ((detalle.Count > i) ? Formulario.ValidarCampoMoneda(detalle[i].CostoNeto) : ""));
                    }
                    firmarDocumentoWord(document, new string[] { "Firma y sello de la Empresa" }); //Agrega la firma del usuario
                    document.AddPasswordProtection(EditRestrictions.readOnly, Global.UsuarioActivo_Documento); //Protege el docuemento Excel con contraseña
                    document.Save(); //Guarda el documento archivo creado
                    abrirDocumentoWord();
                }
                #region Métodos Internos
                void abrirDocumentoWord()
                {
                    ProcessStartInfo proceso = new ProcessStartInfo();
                    Process.Start(archivoDocX);
                }
                #endregion
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A032REPORTE: Hay un conflicto en la generación del comprobante.", e);
            }
        }

        public void crearDocumentoWord_Comprobante_MovimientoStock(string id, string[] datoDB, List<MovimientoStockDetalle> detalle)
        {
            string archivoDocX = directorioTempDOCX + "Comprobante_Movimiento_Stock_N" + id + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".docx"; //Directorio temporal de PDF y Excel
            try
            {
                using (var document = DocX.Create(archivoDocX))
                {
                    var plantillaDocX = directorioPlantilla + @"Comprobante_Movimiento_Stock.docx"; //Plantilla de movimiento de stock
                    document.ApplyTemplate(plantillaDocX);
                    document.MarginLeft = 33.5f; //Establece el márgen izquierdo del documento
                    document.MarginRight = 33.5f; //Establece el márgen derecho del documento
                    document.ReplaceText("TXT001_sys", Global.Empresa_RazonSocial);
                    document.ReplaceText("TXT002_sys", Global.Empresa_Domicilio + " - " + Global.Empresa_Distrito + " - " + Global.Empresa_Provincia + " - Argentina");
                    document.ReplaceText("TXT003_sys", Global.Empresa_Telefono);
                    document.ReplaceText("TXT004_sys", Global.Empresa_IVA);
                    document.ReplaceText("TXT005_sys", "REMITO INTERNO");
                    document.ReplaceText("TXT006_sys", datoDB[0]); //N° de Comprobante
                    document.ReplaceText("TXT007_sys", datoDB[1]); //Fecha y hora
                    document.ReplaceText("TXT008_sys", Global.Empresa_CUIT);
                    document.ReplaceText("TXT009_sys", Global.Empresa_IIBB);
                    document.ReplaceText("TXT010_sys", Global.Empresa_InicioActividad);
                    document.ReplaceText("TXT011_sys", datoDB[2]); //Depósito Origen
                    document.ReplaceText("TXT012_sys", datoDB[3]); //Depósito Destino
                    document.ReplaceText("TXT013_sys", datoDB[4]); //Arribo Estimado
                    document.ReplaceText("TXT014_sys", datoDB[5]); //Observaciones
                    for (int i = 0; i < 30; i++) //Recorre el detalle del comprobante
                    {
                        string fila = "_F" + Convert.ToString(i).PadLeft(2, '0');
                        document.ReplaceText("C1" + fila, ((detalle.Count > i) ? detalle[i].IdArticulo.ToString().PadLeft(6, '0') : ""));
                        document.ReplaceText("C2" + fila, ((detalle.Count > i) ? detalle[i].Denominacion : ""));
                        document.ReplaceText("C3" + fila, ((detalle.Count > i) ? detalle[i].Cantidad.ToString() : ""));
                        document.ReplaceText("C4" + fila, ((detalle.Count > i) ? detalle[i].Unidad : ""));
                        document.ReplaceText("C5" + fila, ((detalle.Count > i) ? detalle[i].NroSerie : ""));
                    }
                    if (datoDB[3] == "EMPREMINSA") firmarDocumentoWord(document, new string[] { "Firma de " + Global.UsuarioActivo_Denominacion}); //Agrega la firma del usuario
                    else if (datoDB[3] == "VELADERO") firmarDocumentoWord(document, new string[] { "Firma de " + Global.UsuarioActivo_Denominacion, "Firma autorizante" }); //Agrega la firma del usuario y del autorizante en Veladero
                    document.AddPasswordProtection(EditRestrictions.readOnly, Global.UsuarioActivo_Documento); //Protege el docuemento Excel con contraseña
                    document.Save(); //Guarda el documento archivo creado
                    abrirDocumentoWord();
                }
                #region Métodos Internos
                void abrirDocumentoWord()
                {
                    ProcessStartInfo proceso = new ProcessStartInfo();
                    Process.Start(archivoDocX);
                }
                #endregion
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A034REPORTE: Hay un conflicto en la generación del comprobante.", e);
            }
        }

        public void crearDocumentoWord_Comprobante_Suministracion(string id, string[] datoDB, List<SuministracionIEPPDetalle> detalle)
        {
            string archivoDocX = directorioTempDOCX + "Comprobante_Suministracion_N" + id + DateTime.Now.ToString(@"_yyyy-MM-dd(hhmmss)") + ".docx"; //Directorio temporal de PDF y Excel
            try
            {
                using (var document = DocX.Create(archivoDocX))
                {
                    var plantillaDocX = directorioPlantilla + @"Comprobante_Suministracion.docx"; //Plantilla de movimiento de stock
                    document.ApplyTemplate(plantillaDocX);
                    document.MarginLeft = 33.5f; //Establece el márgen izquierdo del documento
                    document.MarginRight = 33.5f; //Establece el márgen derecho del documento
                    document.ReplaceText("TXT001_sys", Global.Empresa_RazonSocial);
                    document.ReplaceText("TXT002_sys", Global.Empresa_Domicilio + " - " + Global.Empresa_Distrito + " - " + Global.Empresa_Provincia + " - Argentina");
                    document.ReplaceText("TXT003_sys", Global.Empresa_Telefono);
                    document.ReplaceText("TXT004_sys", Global.Empresa_IVA);
                    document.ReplaceText("TXT005_sys", datoDB[0] + " DE SUMINISTROS"); //Tipo de Operación
                    document.ReplaceText("TXT006_sys", datoDB[1]); //N° de Comprobante
                    document.ReplaceText("TXT007_sys", datoDB[2]); //Fecha y hora
                    document.ReplaceText("TXT008_sys", Global.Empresa_CUIT);
                    document.ReplaceText("TXT009_sys", Global.Empresa_IIBB);
                    document.ReplaceText("TXT010_sys", Global.Empresa_InicioActividad);
                    document.ReplaceText("TXT011_sys", datoDB[3]); //Denominación del Empleado
                    document.ReplaceText("TXT012_sys", datoDB[4]); //CUIL/CUIT
                    document.ReplaceText("TXT013_sys", datoDB[5]); //DNI
                    document.ReplaceText("TXT014_sys", datoDB[6]); //Observación
                    for (int i = 0; i < 30; i++) //Recorre el detalle del comprobante
                    {
                        string fila = "_F" + Convert.ToString(i).PadLeft(2, '0');
                        document.ReplaceText("C1" + fila, ((detalle.Count > i) ? detalle[i].IdArticulo.ToString().PadLeft(6, '0') : ""));
                        document.ReplaceText("C2" + fila, ((detalle.Count > i) ? detalle[i].Denominacion : ""));
                        document.ReplaceText("C3" + fila, ((detalle.Count > i) ? detalle[i].Certificacion : ""));
                        document.ReplaceText("C4" + fila, ((detalle.Count > i) ? detalle[i].Cantidad.ToString() : ""));
                        document.ReplaceText("C5" + fila, ((detalle.Count > i) ? detalle[i].Unidad : ""));
                        document.ReplaceText("C6" + fila, ((detalle.Count > i) ? detalle[i].Deposito : ""));
                        document.ReplaceText("C7" + fila, ((detalle.Count > i) ? detalle[i].Inventario : ""));
                    }
                    firmarDocumentoWord(document, new string[] { "Firma y sello de la Empresa", "Firma y aclaración del trabajador" }); //Agrega la firma del usuario
                    document.AddPasswordProtection(EditRestrictions.readOnly, Global.UsuarioActivo_Documento); //Protege el docuemento Excel con contraseña
                    document.Save(); //Guarda el documento archivo creado
                    abrirDocumentoWord();
                }
                #region Métodos Internos
                void abrirDocumentoWord()
                {
                    ProcessStartInfo proceso = new ProcessStartInfo();
                    Process.Start(archivoDocX);
                }
                #endregion
            }
            catch (Exception e)
            {
                Mensaje.Error("Error-A036REPORTE: Hay un conflicto en la generación del comprobante.", e);
            }
        }

        private void firmarDocumentoWord(DocX documento, string[] notaDePieDeFirma)
        {
            Table tablaFirma = documento.AddTable(3, 3);
            tablaFirma.SetWidthsPercentage(new float[] { 35f, 30f, 35f }, documento.PageWidth); //Establece el tamaño de la tabla y columnas
            tablaFirma.SetBorder(TableBorderType.InsideH, new Border(Xceed.Words.NET.BorderStyle.Tcbs_none, 0, 0, Color.White)); //Elimina los bordes internos horizontales
            tablaFirma.SetBorder(TableBorderType.InsideV, new Border(Xceed.Words.NET.BorderStyle.Tcbs_none, 0, 0, Color.White)); //Elimina los bordes internos Verticales
            int indiceColumna = 0;
            for (int i = 0; i < notaDePieDeFirma.Length; i++)
            {
                if (notaDePieDeFirma.Length == 1) indiceColumna = 1; //Define el indice de la columna en la que se debe insertar la firma cuando hay 1 firma
                if (notaDePieDeFirma.Length == 2 && i > 0) indiceColumna = 2; //Define el indice de la columna en la que se debe insertar la firma cuando hay 2 firmas
                if (notaDePieDeFirma.Length == 3) indiceColumna = i; //Define el indice de la columna en la que se debe insertar la firma cuando hay 3 firmas
                tablaFirma.Rows[0].Cells[indiceColumna].Paragraphs[0].SpacingBefore(5).AppendPicture(obtenerFirma(i)).Alignment = Alignment.center;
                tablaFirma.Rows[1].Cells[indiceColumna].Paragraphs[0].Append("-----------------------------------------------------").Font("Arial").FontSize(7).Alignment = Alignment.center;
                tablaFirma.Rows[2].Cells[indiceColumna].Paragraphs[0].Append(notaDePieDeFirma[i]).Font("Arial").FontSize(7).Alignment = Alignment.center;
            }
            documento.InsertTable(tablaFirma); //Agrega la tabla al documento
            #region Método Interno
            Picture obtenerFirma(int indice)
            {
                long a = Global.UsuarioActivo_IdUsuario;
                string archivoFirma = "f" + Convert.ToString((5091413287 / (a + 71)) * ((((a + 47) * 7) - a) + (100000 * (a + 11)))) + ".empreminsa";
                string directorioFirma = Archivo.ValidarDirectorio(@"Plantillas\Firmas\"); //Valida el directorio de Firmas
                Xceed.Words.NET.Image plantillaPNG = documento.AddImage(directorioFirma + "f78904643205134.empreminsa"); //Agrega una imagen vacia por defecto
                if (File.Exists(directorioFirma + archivoFirma) && indice == 0) plantillaPNG = documento.AddImage(directorioFirma + archivoFirma); //Agrega la imagen de la firma indicada
                return plantillaPNG.CreatePicture(40, 100); //Establece el tamaño de la imagen
            }
            #endregion
        }

        private class EncabezadoPDF : PdfPageEventHelper //Clase Interna que construye el encabezado de la página 
        {
            #region Atributos
            private string _titulo;
            private string[] _subTitulos;
            private float[] _anchos;
            #endregion

            public EncabezadoPDF(string titulo, string[] subTitulos, float[] anchos)
            {
                _titulo = titulo;
                _subTitulos = subTitulos;
                _anchos = anchos;
            }

            public override void OnStartPage(PdfWriter writer, Document document)
            {
                base.OnStartPage(writer, document);
                iTextSharp.text.Paragraph encabezado = new iTextSharp.text.Paragraph(); //Crea un contenedor para el contenido del encabezado

                #region Logo de la Empresa
                using (FileStream imagenPNG = new FileStream(Archivo.ValidarDirectorio(@"Logo\") + "logo_marca.png", FileMode.Open)) //Imagen del logo de la Empresa
                {
                    iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(imagenPNG),
                        System.Drawing.Imaging.ImageFormat.Png);
                    imagen.ScaleToFit(180f, 40f);
                    imagen.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
                    encabezado.Add(imagen);
                }
                #endregion

                #region Título
                iTextSharp.text.Paragraph tituloPDF = new iTextSharp.text.Paragraph(new Chunk(_titulo, FontFactory.GetFont("Times_Roman", 16, 1, new BaseColor(0, 96, 100)))); //Crea el titulo del documento
                tituloPDF.Alignment = Element.ALIGN_CENTER;
                encabezado.Add(tituloPDF); //Agrega el titulo del encabezado al contenedor
                #endregion

                #region Paginación
                iTextSharp.text.Paragraph paginaPDF = new iTextSharp.text.Paragraph(new Chunk("Página: " + writer.PageNumber, FontFactory.GetFont("Times_Roman", 8, 0, new BaseColor(0, 96, 100)))); //Coloca el número de página del documento
                paginaPDF.SpacingAfter = -12f; //Espacio sobre el margen inferior
                paginaPDF.Alignment = Element.ALIGN_RIGHT;
                encabezado.Add(paginaPDF); //Agrega la paginacion del encabezado al contenedor
                LineSeparator separador = new LineSeparator(1f, 100f, new BaseColor(0, 96, 100), 1, 0); //Separador: Crea una linea de color gris
                encabezado.Add(separador); //Agrega el separdor del encabezado al contenedor
                #endregion

                #region SubTitulos
                PdfPTable tablaSubTitulo = new PdfPTable(_subTitulos.Length); //Crea la tabla de datos
                tablaSubTitulo.SpacingBefore = 17f; //Espacio sobre el margen superior
                tablaSubTitulo.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER; //Quita los bordes de las celas de todo la página
                tablaSubTitulo.WidthPercentage = 100; //Especicifica que ocuper el 100% de la página
                tablaSubTitulo.SetWidths(_anchos); //Especifica el ancho de cada columna
                for (int i = 0; i < _subTitulos.Length; i++)
                {
                    PdfPCell celda = new PdfPCell(new iTextSharp.text.Paragraph(_subTitulos[i], FontFactory.GetFont("Arial", 8, 1, new BaseColor(System.Drawing.Color.White)))); //Crea una celda en las filas
                    celda.BackgroundColor = new BaseColor(System.Drawing.Color.Gray);
                    celda.Border = PdfPCell.NO_BORDER; //Especifica un borde inferior para la celda
                    celda.HorizontalAlignment = Element.ALIGN_LEFT; //Alinea el texto de la celda
                    tablaSubTitulo.AddCell(celda); //Agrega la celda a la fila de la tabla
                }
                encabezado.Add(tablaSubTitulo); //Agrega la tabla de subtitulos del encabezado al contenedor
                #endregion
                document.Add(encabezado); //Agrega el encabezado al documento
            }
        }
        #endregion
    }
}
