using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Biblioteca.Ayudantes
{
    public static class Mensaje
    {
        #region Métodos
        public static void Advertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ConfirmacionBoton1(string mensaje)
        {
            return MessageBox.Show(mensaje, "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult ConfirmacionBoton2(string mensaje)
        {
            return MessageBox.Show(mensaje, "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        public static void Error(string mensaje, Exception error)
        {
            string archivo = "Historial de errores - " + DateTime.Now.ToString(@"yyyy-MM") + ".txt";
            string texto = DateTime.Now.ToString(@"yyyy-MM-dd(hh:mm:ss)") + " Mensaje: " + mensaje + " Excepción: " + error.Message;
            Archivo.EscribirTXT(@"Errores\", archivo, texto);
            MessageBox.Show(mensaje, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ErrorMySql(string codigo1, string codigo2, string codigo3, string codigo4, MySqlException error)
        {
            string mensaje = "";
            string archivo = "Historial de errores - " + DateTime.Now.ToString(@"yyyy-MM") + ".txt";
            if (error.Number == 1054) mensaje = "Error-" + codigo1 + ": El nombre del campo es inválido.";
            else if(error.Number == 1064) mensaje = "Error-" + codigo2 + ": La sintaxis de la consulta es inválida.";
            else if(error.Number == 1146) mensaje = "Error-" + codigo3 + ": El nombre de la tabla es inválido.";
            else mensaje = "Error-" + codigo4 + ": Hay un conflicto en la ejecución del Query.";
            string textoTXT = DateTime.Now.ToString(@"yyyy-MM-dd(hh:mm:ss)") + " Mensaje: " + mensaje + " Excepción: " + error.Message;
            Archivo.EscribirTXT(@"Errores\", archivo, textoTXT);
            MessageBox.Show(mensaje, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Informacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void RegistroCorrecto(string operacion)
        {
            string mensaje = "";
            if (operacion == "ANULACION") mensaje = "Los datos se han anulado correctamente.";
            else if (operacion == "ELIMINACION") mensaje = "Los datos se han eliminado correctamente.";
            else if (operacion == "MODIFICACION") mensaje = "Los cambios se han registrado correctamente.";
            else if (operacion == "REGISTRACION") mensaje = "Los datos se han registrado correctamente.";
            MessageBox.Show(mensaje, "Mensaje de Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Restriccion()
        {
            MessageBox.Show("Operación restringida.\nSu usuario No posee el privilegio requerido.", "Mensaje de Restricción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void NoModificable()
        {
            MessageBox.Show("Este módulo del sistema no admite la modificación de registros.", "Mensaje de Restricción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion
    }
}