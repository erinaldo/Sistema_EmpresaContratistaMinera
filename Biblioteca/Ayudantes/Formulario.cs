using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Biblioteca.Ayudantes
{
    public static class Formulario
    {
        #region Métodos: Asistencia al Formulario   
        public static void AbrirFormularioHermano(Form formularioOrigen, Form formularioDestino)
        {
            formularioDestino.MdiParent = formularioOrigen.MdiParent;
            formularioOrigen.Close();
            formularioDestino.Dock = DockStyle.Fill;
            formularioDestino.Show();
        }

        public static string enmascararDNI(string documento)
        {
            string mascara = "";
            int tamanio = documento.Length;
            if (tamanio == 7) mascara = documento.Substring(0, 1) + "." + documento.Substring(1, 3) + "." + documento.Substring(4, 3);
            if (tamanio == 8) mascara = documento.Substring(0, 2) + "." + documento.Substring(2, 3) + "." + documento.Substring(5, 3);
            return mascara;
        }

        public static string GenerarCodigoPostal(string distrito)
        {
            string cp = null;
            if (distrito == "25 DE MAYO") cp = "5443";
            else if (distrito == "9 DE JULIO") cp = "5417";
            else if (distrito == "ALBARDON") cp = "5419";
            else if (distrito == "ANGACO NORTE") cp = "5415";
            else if (distrito == "ANGACO SUD") cp = "5417";
            else if (distrito == "CALINGASTA") cp = "5403";
            else if (distrito == "CAPITAL") cp = "5400";
            else if (distrito == "CAUCETE") cp = "5442";
            else if (distrito == "CHIMBAS") cp = "5413";
            else if (distrito == "IGLESIA") cp = "5467";
            else if (distrito == "JACHAL") cp = "5460";
            else if (distrito == "POCITO") cp = "5429";
            else if (distrito == "RAWSON") cp = "5425";
            else if (distrito == "RIVADAVIA") cp = "5400";
            else if (distrito == "SAN MARTIN") cp = "5439";
            else if (distrito == "SANTA LUCIA") cp = "5411";
            else if (distrito == "SARMIENTO") cp = "5447";
            else if (distrito == "ULLUM") cp = "5409";
            else if (distrito == "VALLE FERTIL") cp = "5449";
            else if (distrito == "ZONDA") cp = "5401";
            return cp;
        }

        public static string GenerarCuitCuil(string sexo, string documento)
        {
            string CuitCuil = null;
            if (documento.Length == 7 || documento.Length == 8) //Verifica que el documento tenga una longitud válida
            {
                documento = (documento.Length == 8) ? documento : "0" + documento;
                string sexoDocomento = null;
                if (sexo == "FEMENINO") sexoDocomento = "27" + documento;
                if (sexo == "MASCULINO") sexoDocomento = "20" + documento;

                int aux = 0; //Variable auxuliar
                char[] vectorSexoDocomento = sexoDocomento.ToArray();
                int[] vectorSerie = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 }; //Serie oficial para calcular CUIT/CUIL
                //Recorre ambos vectores: multiplica cada elemnto y suma los resultados
                for (int i = 0; i < 10; i++) aux += vectorSerie[i] * Convert.ToInt32(vectorSexoDocomento[i].ToString());
                int aux2 = aux - ((aux / 11) * 11); //Variable auxuliar
                int aux3 = 11 - aux2;
                CuitCuil = sexoDocomento + aux3.ToString();
            }
            return CuitCuil;
        }

        public static void GenerarDistritos(string provincia, ComboBox combo)
        {
            if (provincia == "SAN JUAN")
            {
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
                //Agrega elementos al comboBox
                combo.Items.Clear(); //Libera los items que anteriormente sea han cargado en el ComboBox
                combo.Items.AddRange(new object[] { "25 DE MAYO", "9 DE JULIO", "ALBARDON", "ANGACO NORTE", "ANGACO SUD",
                    "CALINGASTA", "CAPITAL", "CAUCETE", "CHIMBAS", "IGLESIA", "JACHAL", "POCITO", "RAWSON", "RIVADAVIA",
                    "SAN MARTIN", "SANTA LUCIA", "SARMIENTO", "ULLUM", "VALLE FERTIL", "ZONDA" });
                combo.Text = "CAPITAL"; //Selecciona un elemento
            }
            else {
                combo.DropDownStyle = ComboBoxStyle.Simple;
                combo.Items.Clear();
                combo.Text = "";
            }
        }

        public static string GenerarNumeroTextual(string valorMonetario)
        {
            string preparacion1 = valorMonetario.Replace(".", ","); //Verifica que contenga la coma
            string preparacion2 = ((preparacion1.Contains(',')) ? preparacion1 : preparacion1 + ",00"); //
            string[] numeroMonetario = preparacion2.Split(','); //Separa la parte entera de la parte decimal
            string parteEntera = numeroMonetario[0].PadLeft(9, '0');
            string parteDecimal = numeroMonetario[1].PadRight(2, '0').Substring(0, 2); //Forma y limita los centavos a dos cifras
            // --------- Variables del sistema de numeración decimal --------- //
            string[] unidad = new string[] { "", "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Ocho", "Nueve" };
            string[] decena = new string[] { "Diez", "Once", "Veinte", "Treinta", "Cuarenta", "Cincuenta", "Sesenta", "Setenta", "Ochenta", "Noventa" };
            string[] centena = new string[] { "", "Ciento", "Doscientos", "Trescientos", "Cuatrocientos", "Quinientos", "Seiscientos", "Setecientos", "Ochocientos", "Novecientos" };
            string[] otros = new string[] { "Diez", "Once", "Doce", "Trece", "Catorce", "Quince", "Dieciséis", "Diecisiete", "Dieciocho", "Diecinueve" };
            // ---------- Variables representativas de cada digito ---------- //
            int digito1 = Convert.ToInt32(parteEntera.Substring(8, 1)); //Unidad
            int digito2 = Convert.ToInt32(parteEntera.Substring(7, 1)); //Decena
            int digito3 = Convert.ToInt32(parteEntera.Substring(6, 1)); //Centena
            int digito4 = Convert.ToInt32(parteEntera.Substring(5, 1)); //Unidad De mil
            int digito5 = Convert.ToInt32(parteEntera.Substring(4, 1)); //Decena De mil
            int digito6 = Convert.ToInt32(parteEntera.Substring(3, 1)); //Centena De mil
            int digito7 = Convert.ToInt32(parteEntera.Substring(2, 1)); //Unidad de millón
            int digito8 = Convert.ToInt32(parteEntera.Substring(1, 1)); //Decena de millón
            int digito9 = Convert.ToInt32(parteEntera.Substring(0, 1)); //Centena de millón
            int valCentena = Convert.ToInt32(parteEntera.Substring(6, 3));
            int valMil = Convert.ToInt32(parteEntera.Substring(5, 4));
            int valCentenaMil = Convert.ToInt32(parteEntera.Substring(3, 6));
            int valMillon = Convert.ToInt32(parteEntera.Substring(2, 7));
            int valMillonDecena = Convert.ToInt32(parteEntera.Substring(1, 8));
            int valMillonCentena = Convert.ToInt32(parteEntera.Substring(0, 9));
            // ------- Condicionales que determinan el valor del número ------- //
            string valorTextual = " " + unidad[digito1]; //Valor de unidad
            if (digito2 == 1) valorTextual = " " + otros[digito1]; //Valor de primera decena
            if (digito2 >= 2) valorTextual = " " + decena[digito2] + ((digito1 > 0) ? " y " + unidad[digito1] : ""); //Valor de segunda a novena decena
            if (valCentena == 100) valorTextual = " Cien"; //El valor es cien
            if (valCentena >= 101) valorTextual = " " + centena[digito3] + valorTextual; //Valor de primera a novena centena
            if (valMil >= 1000 && valMil <= 1999) valorTextual = " Mil" + valorTextual; //Valor de primera unidad de mil
            if (valMil >= 2000) valorTextual = ((digito5 == 0) ? " " + unidad[digito4] : "") + " Mil" + valorTextual; //Valor de segunda a novena unidad de mil
            if (digito5 == 1) valorTextual = " " + otros[digito4] + ((digito4 == 0) ? " Mil" : "") + valorTextual; //Valor de primera decena de mil
            if (digito5 >= 2) valorTextual = " " + decena[digito5] + ((digito4 == 0) ? " Mil" : "") + ((digito4 > 0) ? " y " + unidad[digito4] : "") + valorTextual; //Valor de segunda a novena decena de mil
            if (valCentenaMil >= 100000 && valCentenaMil <= 100999) valorTextual = " Cien Mil" + valorTextual; //Valor de primera centena de mil hasta 100999
            if (valCentenaMil >= 101000) valorTextual = " " + centena[digito6] + ((digito5 == 0) ? ((digito4 == 0) ? " Mil" : ((digito4 == 1) ? " Un" : "")) : "") + valorTextual; //Valor de primera centena de mil desde 101000 hasta novena centena
            if (valMillon >= 1000000 && valMillonDecena <= 1999999) valorTextual = " Un Millón" + valorTextual; //Valor de primera unidad de millón
            if (valMillon >= 2000000 && digito8 == 0) valorTextual = " " + unidad[digito7] + " Millones" + valorTextual; //Valor de primera unidad de millón
            if (valMillonDecena >= 10000000) valorTextual = " " + ((digito8 == 1) ? otros[digito7] : decena[digito8] + ((digito7 > 0) ? " y " + unidad[digito7] : "")) + " Millones" + valorTextual; //Valor de primera a novena decena de millón
            if (valMillonCentena >= 100000000 && valMillonCentena <= 100999999) valorTextual = " Cien Millones" + valorTextual; //Valor de primera centena de millón hasta 100999999
            if (valMillonCentena >= 101000000) valorTextual = " " + centena[digito9] + valorTextual; //Valor de primera centena de mil desde 101000000 hasta novena centena
            return valorTextual + " con " + parteDecimal + "/100.-"; //Retorna el valor textual correspondiente al valor numérico
        }

        public static int GenerarTipoComprobante(string tipoComprobante)
        {
            switch (tipoComprobante)
            {
                case "FAC-A": return 01;
                case "FAC-B": return 06;
                case "FAC-C": return 11;
                case "FAC-M": return 51;
                case "NCR-A": return 03;
                case "NCR-B": return 08;
                case "NCR-C": return 13;
                case "NCR-M": return 53;
                case "NDE-A": return 02;
                case "NDE-B": return 07;
                case "NDE-C": return 12;
                case "NDE-M": return 52;
                case "REM-R": return 91;
                default: return 00;
            }
        }

        public static string GenerarTipoComprobante(int tipoComprobante)
        {
            switch (tipoComprobante)
            {
                case 01: return "FAC-A";
                case 06: return "FAC-B";
                case 11: return "FAC-C";
                case 51: return "FAC-M";
                case 03: return "NCR-A";
                case 08: return "NCR-B";
                case 13: return "NCR-C";
                case 53: return "NCR-M";
                case 02: return "NDE-A";
                case 07: return "NDE-B";
                case 12: return "NDE-C";
                case 52: return "NDE-M";
                case 91: return "REM-R";
                case 00: return "REM-X";
                default: return "";
            }
        }
        #endregion

        #region Métodos: Manipulación de controles de formulario
        public static void ComboBox_CargarElementos(ComboBox combo, string[] elementos, int itemSeleccionado)
        {
            combo.Items.Clear(); //libera el ComboBox
            foreach (string elemento in elementos)
            {
                combo.Items.Add(elemento); //Agrega elementos al comboBox
            }
            if (elementos.Length > 0) combo.SelectedIndex = itemSeleccionado; //Selecciona un elemento específico
        }

        public static void ComboBox_CargarElementos(ComboBox combo, List<string> elementos, int itemSeleccionado)
        {
            combo.Items.Clear();
            foreach (string elemento in elementos)
            {
                combo.Items.Add(elemento); //Agrega elementos al comboBox
            }
            if (elementos.Count > 0) combo.SelectedIndex = itemSeleccionado; //Selecciona un elemento específico
        }

        public static void ComboBox_CargarElementos(DataGridViewComboBoxColumn combo, List<string> elementos)
        {
            combo.Items.Clear();
            foreach (string elemento in elementos)
            {
                combo.Items.Add(elemento); //Agrega elementos al comboBox
            }
        }

        public static void ComboBox_CargarElementos(ComboBox combo, List<string> elementos, string itemEspecifico)
        {
            combo.Items.Clear();
            foreach (string elemento in elementos)
            {
                combo.Items.Add(elemento); //Agrega elementos al comboBox
            }
            combo.Items.Add(itemEspecifico); //Agrega un elemnto especifico al comboBox
            if (elementos.Count > 0) combo.Text = itemEspecifico; //Selecciona el elemento específico
        }

        public static void Grid_CargarFilas<T>(DataGridView grid, List<T> lista)
        {
            if (lista.Count > 0) {
                grid.AutoGenerateColumns = false;
                if (lista[0] != null) //Verifica que la lista No este vacia
                {
                    grid.DataSource = typeof(List<T>);
                    grid.DataSource = lista;
                }
                else grid.DataSource = null; //Libera todas las filas del DataGrid
                grid.ClearSelection(); //Quita la selección inicial de la primera fila
            }
            else grid.DataSource = null; //Libera todas las filas del DataGrid (Importante para busqueda por denominación)
        }

        public static DataGridViewRow Grid_SeleccionarFila(DataGridView grid, string columna, string valor)
        {
            DataGridViewRow indiceFila = null; //Variable que almacena el indice de la fila
            foreach (DataGridViewRow fila in grid.Rows) //Recorre todas las filas de la columna indicada
            {
                string valorDeCelda = Convert.ToString(fila.Cells[columna].Value);
                if (valorDeCelda == Convert.ToString(valor))
                {
                    grid.Rows[fila.Index].Selected = true; //Selecciona la fila
                    indiceFila = grid.Rows[fila.Index]; //Almacena el indice de la fila
                }
            }
            return indiceFila;
        }

        public static void Actividad(bool activo, Control[] controles)
        {
            foreach (Control elemento in controles)
            {
                elemento.Enabled = activo;
            }
        }

        public static void Actividad(bool activo, CheckBox[] controles)
        {
            foreach (CheckBox elemento in controles)
            {
                if (activo)
                {
                    elemento.Enabled = true;
                }
                else
                {
                    elemento.Enabled = false;
                    elemento.Checked = false;
                }
            }
        }

        public static void ValidarCampoAlfabetico(KeyPressEventArgs e, bool ponerTeclaEnMayuscula)
        {
            string teclasPermitidos = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ"; //Vector de los caracteres permitidos
            if (!teclasPermitidos.Contains(e.KeyChar.ToString())) e.Handled = true; //Permite el ingreso teclas numericas
            if (e.KeyChar == Convert.ToChar(8)) e.Handled = false; //Tecla permitida: Retroceso (Borrar)
            if (e.KeyChar == Convert.ToChar(32)) e.Handled = false; //Tecla permitida: Espaciadora (Espacio)
            if (ponerTeclaEnMayuscula) e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray(0, 1)[0]; //Pone texto en mayusculas
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab) SendKeys.Send("{TAB}"); //Permite mover el foco al siguiente control ("Enter" ó "Tab")
            if (Char.IsControl(e.KeyChar) && (e.KeyChar != (char)Keys.C || e.KeyChar != (char)Keys.V || e.KeyChar != (char)Keys.X)) e.Handled = false; //Tecla permitida: Ctrl+C, Ctrl+V y Ctrl+X (Copiar, Pegar y Cortar)
        }

        public static void ValidarCampoAlfaNumerico(KeyPressEventArgs e, bool ponerTeclaEnMayuscula)
        {
            string teclasPermitidos = "abcdefghijklmnñopqrstuvwxyz0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"; //Vector de los caracteres permitidos
            if (!teclasPermitidos.Contains(e.KeyChar.ToString())) e.Handled = true; //Permite el ingreso teclas numericas
            if (e.KeyChar == Convert.ToChar(8)) e.Handled = false; //Tecla permitida: Retroceso (Borrar)
            if (e.KeyChar == Convert.ToChar(32)) e.Handled = false; //Tecla permitida: Espaciadora (Espacio)
            if (ponerTeclaEnMayuscula) e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray(0, 1)[0]; //Pone texto en mayusculas
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab) SendKeys.Send("{TAB}"); //Permite mover el foco al siguiente control ("Enter" ó "Tab")
            if (Char.IsControl(e.KeyChar) && (e.KeyChar != (char)Keys.C || e.KeyChar != (char)Keys.V || e.KeyChar != (char)Keys.X)) e.Handled = false; //Tecla permitida: Ctrl+C, Ctrl+V y Ctrl+X (Copiar, Pegar y Cortar)
        }

        public static bool ValidarCampoEmail(string email)
        {
            bool validacion = true;
            string caracteresValidos = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (!Regex.IsMatch(email, caracteresValidos) && !string.IsNullOrEmpty(email))
            {
                validacion = false;
            }
            if (!validacion) Mensaje.Advertencia("Operación Incorrecta.\nIngrese un e-mail válido e intente nuevamente.");
            return validacion;
        }

        public static void ValidarCampoNumerico(KeyPressEventArgs e, string texto)
        {
            if (!("0123456789").Contains(e.KeyChar.ToString())) e.Handled = true; //Permite el ingreso teclas numericas
            if (e.KeyChar == Convert.ToChar(8)) e.Handled = false; //Tecla permitida: Retroceso (Borrar)
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab) SendKeys.Send("{TAB}"); //Permite mover el foco al siguiente control ("Enter" ó "Tab")
            if (Char.IsControl(e.KeyChar) && (e.KeyChar != (char)Keys.C || e.KeyChar != (char)Keys.V || e.KeyChar != (char)Keys.X)) e.Handled = false; //Tecla permitida: Ctrl+C, Ctrl+V y Ctrl+X (Copiar, Pegar y Cortar)
        }

        public static void ValidarCampoMoneda(KeyPressEventArgs e, string texto)
        {
            if (e.KeyChar == Convert.ToChar(46)) e.KeyChar = (char)44; //Verifica que el punto decimal sea siempre una "coma"
            int cantidadPuntoDecimal = 0; //Control Decimal: Variable que almacena la cantidad de "comas"
            foreach (char caracter in texto) { if (caracter == ',') ++cantidadPuntoDecimal; } //Control Decimal: Recorre y almacena la cantidad de "coma"
            if (!("0123456789").Contains(e.KeyChar.ToString())) e.Handled = true; //Permite el ingreso de las teclas numéricas
            if (e.KeyChar == Convert.ToChar(8)) e.Handled = false; //Permite el ingreso de la tecla "Retroceso" (Borrar)
            if (e.KeyChar == Convert.ToChar(37) || e.KeyChar == Convert.ToChar(39)) e.Handled = false; //Permite el ingreso de las teclas "Izquierda-Derecha"
            if (e.KeyChar == Convert.ToChar(44) && cantidadPuntoDecimal < 1) e.Handled = false;
            if (e.KeyChar == Convert.ToChar(44) && cantidadPuntoDecimal > 0) SystemSounds.Beep.Play(); //Emite un sonido de error al intentar ingresar mas de una "coma"
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab) SendKeys.Send("{TAB}"); //Permite mover el foco al siguiente control ("Enter" ó "Tab")
            if (Char.IsControl(e.KeyChar) && (e.KeyChar != (char)Keys.C || e.KeyChar != (char)Keys.V || e.KeyChar != (char)Keys.X)) e.Handled = false; //Tecla permitida: Ctrl+C, Ctrl+V y Ctrl+X (Copiar, Pegar y Cortar)
        }

        public static string ValidarCampoMoneda(double numero)
        {
            return ValidarCampoMoneda(Convert.ToString(numero)); //Invoca al método original
        }

        public static string ValidarCampoMoneda(string monto)
        {
            string resultado = "";
            string valor = monto.Replace(".", ","); //Verifica que el punto decimal sea siempre una "coma"
            int cantidadPuntoDecimal = 0; //Control Decimal: Variable que almacena la cantidad de "comas"
            foreach (char caracter in valor) { if (caracter == ',') ++cantidadPuntoDecimal; } //Control Decimal: Recorre y almacena la cantidad de "comas"
            if (cantidadPuntoDecimal == 1)
            {
                if (valor.Split(',')[1].Length == 1) resultado = valor + "0"; //Formatea y completa la última cifra del termino decimal 
                else resultado = valor;
            }
            else if (cantidadPuntoDecimal < 1) { resultado = valor + ",00"; } //Formatea y completa ambas cifras del termino decimal
            else if (cantidadPuntoDecimal > 1) { resultado = Convert.ToDouble(valor.Replace(",", "")).ToString("##########,##"); }
            return resultado;
        }

        public static string ValidarCampoMonedaMil(double numero)
        {
            string monedaMil = ValidarCampoMoneda(Convert.ToString(numero)); //Invoca al método original
            return double.Parse(monedaMil).ToString("N2");
        }

        public static string ValidarCampoMonedaMil(string numero)
        {
            string monedaMil = ValidarCampoMoneda(numero); //Invoca al método original
            return double.Parse(monedaMil).ToString("N2");
        }

        public static string ValidarCampoTipoSubTitulo(string texto)
        {
            texto = texto.ToLower(); //Transforma todo el texto en minúsculas 
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(texto); //Coloca en mayúscula la primera letra de cada palabra 
        }

        public static bool ValidarCampoVacio(bool restaurar, Control[] cajas)
        {
            bool validacion = true;
            foreach (Control elemento in cajas)
            {
                if (!string.IsNullOrEmpty(elemento.Text) || restaurar) //Verifica que el valor No sea nulo ni vacio y que si restaurar es verdadero debe restaurar los colores 
                {
                    if (elemento.Name.Substring(0, 3).Trim() == "txt")
                    {
                        TextBoxBase textBoxBase = (TextBoxBase) elemento; //Realiza casting de clase "Control" a "TextBox"
                        elemento.BackColor = (textBoxBase.ReadOnly) ? Color.FromArgb(245, 250, 240) : Color.White; //Restaura el color de fondo la caja en base al modo de escritura/lectura
                    }
                    else elemento.BackColor = Color.White; //Restaura el color de fondo la caja
                }
                else
                {
                    elemento.BackColor = Color.PapayaWhip; //Sobresalta la caja cambiando el color de fondo
                    validacion = false;
                }
            }
            if (!validacion) Mensaje.Advertencia("Operación Incorrecta.\nIngrese el valor requerido e intente nuevamente.");
            return validacion;
        }

        public static bool ValidarCampoVacioNumerico(bool restaurar, Control[] cajas)
        {
            bool validacion = true;
            foreach (Control elemento in cajas)
            {
                if ((!string.IsNullOrEmpty(elemento.Text) && Convert.ToDouble(elemento.Text) > 0.00) || restaurar) //Verifica que el valor No sea nulo ni vacio y que si restaurar es verdadero debe restaurar los colores 
                {
                    if (elemento.Name.Substring(0, 3).Trim() == "txt")
                    {
                        TextBoxBase textBoxBase = (TextBoxBase)elemento; //Realiza casting de clase "Control" a "TextBox"
                        elemento.BackColor = (textBoxBase.ReadOnly) ? Color.FromArgb(245, 250, 240) : Color.White; //Restaura el color de fondo la caja en base al modo de escritura/lectura
                    }
                    else elemento.BackColor = Color.White; //Restaura el color de fondo la caja
                }
                else
                {
                    elemento.BackColor = Color.PapayaWhip; //Sobresalta la caja cambiando el color de fondo
                    validacion = false;
                }
            }
            if (!validacion) Mensaje.Advertencia("Operación Incorrecta.\nIngrese el valor requerido e intente nuevamente.");
            return validacion;
        }

        public static double ValidarNumeroDoble(string numero)
        {
            double.TryParse(numero, out double numeroEntero); //Verifica que el valor se pueda convertir en un número doble
            return numeroEntero;
        }

        public static int ValidarNumeroEntero(string numero)
        {
            int.TryParse(numero, out int numeroEntero); //Verifica que el valor se pueda convertir en un número entero
            return numeroEntero;
        }

        public static long ValidarNumeroEntero64(string numero)
        {
            long.TryParse(numero, out long numeroEntero); //Verifica que el valor se pueda convertir en un número entero
            return numeroEntero;
        }

        public static string ValidarTituloReporte(string titulo)
        {
            string sinAcentos = titulo.ToLower().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u");
            string sinSimbolos = sinAcentos.Replace("&", "Y").Replace(".", "").Replace(",", "").Replace(" ", "_");
            return sinSimbolos.ToUpper();
        }

        public static void Visibilidad(Control[] controles)
        {
            foreach (Control elemento in controles)
            {
                if (elemento.Visible) elemento.Visible = false;
                else elemento.Visible = true;
                if (elemento.Enabled) elemento.Enabled = false;
                else elemento.Enabled = true;
            }
        }

        public static void Visibilidad(bool visible, Control[] controles)
        {
            foreach (Control elemento in controles)
            {
                if (visible)
                {
                    elemento.Enabled = true;
                    elemento.Visible = true;
                }
                else
                {
                    elemento.Enabled = false;
                    elemento.Visible = false;
                }
            }
        }
        #endregion
    }
}