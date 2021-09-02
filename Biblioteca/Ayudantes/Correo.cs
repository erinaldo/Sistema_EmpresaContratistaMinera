using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Biblioteca.Ayudantes
{
    public static class Correo
    {
        public static bool EnviarCorreo_Contrasenia(string titulo, string destinatario, string denominacion, string usuario, string contrasenia)
        {
            Cursor.Current = Cursors.WaitCursor;
            string mensaje = denominacion + ".\nEste es un mensaje automático de " + titulo + " del Sistema de Gestión Administrativa de Empremisa.\n" +
                "El mismo ha ejecutado el servicio de generación de contraseña y ha enviado una nueva contraseña a su correo de recuperación que " +
                "usted especificó en su registro de usuario. Recuerde que su registro de usuario es único y personal y No debe compartir su contraseña con nadie.\n" +
                "\nDatos para acceder al sistema:\n" +
                "Usuario: " + usuario + "\n" +
                "Contraseña: " + contrasenia + "\n" +
                "\nGracias por utilizar nuestros servicios.";
            try
            {
                //Parametros de configuración del correo
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("x@gmail.com", "Sistema de Gestión Administrativa");
                correo.To.Add(new MailAddress(destinatario, denominacion));
                correo.Subject = titulo;
                correo.SubjectEncoding = Encoding.UTF8;
                correo.Body = mensaje;
                correo.BodyEncoding = Encoding.UTF8;
                correo.Priority = MailPriority.High;
                using (SmtpClient clienteSMTP = new SmtpClient("smtp.gmail.com", 25)) //Parametros de configuración del servidor de correo
                {
                    clienteSMTP.Credentials = new NetworkCredential("x@gmail.com", "Empresa");
                    clienteSMTP.EnableSsl = true;
                    clienteSMTP.Send(correo);
                    return true;
                }
            }
            catch (FormatException e)
            {
                Mensaje.Error("Error-S001COR: El formato del email proporcionado es inválido.", e);
            }
            catch (SmtpException e)
            {
                Mensaje.Error("Error-S002COR: Hay un conflicto con el Servidor de Correo.", e);
            }
            Cursor.Current = Cursors.Default;
            return false;
        }
    }
}
