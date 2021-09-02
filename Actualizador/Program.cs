using Biblioteca.Ayudantes;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Actualizador
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");

            bool instanceCountOne = false;

            using (Mutex mtex = new Mutex(true, "Empreminsa", out instanceCountOne))
            {
                if (instanceCountOne)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Screen screen = Screen.PrimaryScreen;
                    if (screen.Bounds.Width < 1024 || screen.Bounds.Height < 768)
                    {
                        Mensaje.Advertencia("La resolución de su pantalla No cumple con los requisitos mínimos. Por motivos de seguridad se cerrará la aplicación.");
                        Application.Exit();
                    }
                    else if (screen.Bounds.Width >= 1024 && screen.Bounds.Height >= 768)
                    {
                        Application.Run(new FormPublicacionActualizacion());
                    }
                    mtex.ReleaseMutex();
                }
                else
                {
                    Mensaje.Advertencia("Operación incorrecta.\nActualmente se encuentra abierto el Sistema.");
                }
            }
        }
    }
}
