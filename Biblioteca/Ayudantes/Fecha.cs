using System;
using System.Globalization;
using System.Net;
using System.Timers;

namespace Biblioteca.Ayudantes
{
    public static class Fecha
    {
        #region Método Principal
        public static void SincronizarRelojDeSistema() //Método que sincroniza e inicializa el reloj interno del sistema
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com"); //Crea una solicitud HttpWebRequest
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) //Crea una variable con la respuesta de la solicitud HttpWebRequest
                {
                    string todaysDates = response.Headers["date"]; //Selecciona la llave "date" dentro del vector de respuesta
                    var fechaOnline = DateTime.ParseExact(todaysDates, "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                        CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal); //Formate la hora y fecha para la cultura Argentina
                    Global.RelojDeSistema = fechaOnline;
                }
            }
            catch (Exception e) { Console.Write(e.ToString());}
            finally
            {
                Timer relojDeSistema = new Timer(); //Crea un timer dentro de un hilo que ejecutará el método con el reloj interno del sistema
                relojDeSistema.Interval = 1000; //Define el intervalo de cada Tick 
                relojDeSistema.Elapsed += relojDeSistema_Tick; //Delegado que invoca el evento del reloj interno del sistema
                relojDeSistema.Start(); //Ejecuta el hilo con el método del reloj interno del sistema
            }
        }

        private static void relojDeSistema_Tick(object sender, EventArgs e) //Oyente que incrementa el reloj interno del sistema
        {
            Global.RelojDeSistema = Global.RelojDeSistema.AddSeconds(1); //Actualiza el reloj interno del sistema
        }
        #endregion

        #region Métodos: Retornos de Fecha
        public static DateTime DTSistemaFecha() //Retorna una variable de tipo DateTime con la fecha actual formateada
        {
            return Global.RelojDeSistema;
        }

        public static DateTime ValidarFecha(string fecha) //Retorna una fecha desde una cadena válida
        {
            DateTime fechaValida;
            if (DateTime.TryParse(fecha, out fechaValida)) return fechaValida; //Verifica si la cadena es válida
            else return Global.RelojDeSistema;
        }

        public static string ConvertirFecha(DateTime fecha) //Retorna una cadena con una fecha formateada a partir de una fecha de tipo DateTime
        {
            return fecha.ToString("dd/MM/yyyy");
        }

        public static string ConvertirFecha_Escrita(DateTime fecha) //Retorna una cadena con una fecha formateada a partir de una fecha de tipo DateTime
        {
            int numeroDia = Convert.ToInt32(fecha.Day);
            string dia = (numeroDia > 1) ? numeroDia.ToString() + " días" : numeroDia.ToString() + " día";
            string[] nombreMes = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            string mes = nombreMes[Convert.ToInt32(fecha.Month-1)];
            string anio = fecha.Year.ToString();
            return dia + " del mes de " + mes + " de " + anio;
        }

        public static string ConvertirFechaHora(DateTime fecha) //Retorna una cadena con una fecha y hora formateada a partir de una fecha de tipo DateTime
        {
            return fecha.ToString("dd/MM/yyyy HH:mm");
        }

        public static string SistemaFecha() //Retorna una cadena con la fecha actual formateada
        {
            return Global.RelojDeSistema.ToString("dd/MM/yyyy");
        }

        public static string SistemaFecha_Escrita() //Retorna una cadena con la fecha actual formateada de modo escrito (Largo)
        {
            DateTime fechaActual = Global.RelojDeSistema;
            int numeroDia = Convert.ToInt32(fechaActual.Day);
            string dia = (numeroDia > 1) ? numeroDia.ToString() + " días" : numeroDia.ToString() + " día";
            string[] nombreMes = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            string mes = nombreMes[Convert.ToInt32(fechaActual.Month)-1];
            string anio = Convert.ToString(fechaActual.Year);
            return dia + " del mes de " + mes + " de " + anio;
        }

        public static string SistemaFechaHora() //Retorna una cadena con la fecha y hora actual formateada
        {
            return Global.RelojDeSistema.ToString("dd/MM/yyyy HH:mm");
        }
        #endregion

        #region Métodos: Cálculos de Fecha
        public static string CalcularAntiguedadLaboral(string fechaIngreso, string fechaEgreso, string estado)
        {
            string antiguedad = "";
            if (estado == "ACTIVO") calcular(ValidarFecha(fechaIngreso), DTSistemaFecha());
            else if (estado == "INACTIVO") calcular(ValidarFecha(fechaIngreso), ValidarFecha(fechaEgreso));
            void calcular(DateTime fechaInicial, DateTime fechaFinal)
            {
                double promediPorAnio = 365.25;
                double promediPorMes = 365 / 12;
                double diferenciaDias = (fechaFinal - fechaInicial).TotalDays;
                int anios = (int)Math.Truncate(diferenciaDias / promediPorAnio);
                int meses = (int)Math.Truncate((diferenciaDias - (anios * promediPorAnio)) / promediPorMes);
                int dias = (int)Math.Truncate((diferenciaDias - ((anios * promediPorAnio) + (meses * promediPorMes))));
                antiguedad = ((anios > 0) ? Convert.ToString(anios) + "a." : "") + ((meses > 0) ? Convert.ToString(meses) + "m." : "") + ((dias > 0) ? Convert.ToString(dias) + "d." : "");
            }
            return antiguedad;
        }

        public static int CalcularAntiguedadLaboral_Anio(DateTime fechaIngreso, DateTime fechaEgreso, string estado)
        {
            int antiguedadAnio = 0;
            if (estado == "ACTIVO") calcular(fechaIngreso, DTSistemaFecha());
            else if (estado == "INACTIVO") calcular(fechaIngreso, fechaEgreso);
            void calcular(DateTime fechaInicial, DateTime fechaFinal)
            {
                double promediPorAnio = 365.25;
                double diferenciaDias = (fechaFinal - fechaInicial).TotalDays;
                antiguedadAnio = (int)Math.Truncate(diferenciaDias / promediPorAnio);
            }
            return antiguedadAnio;
        }

        public static string CalcularEdad(string fechaNacimiento)
        {
            int edad = DTSistemaFecha().AddTicks(-ValidarFecha(fechaNacimiento).Ticks).Year - 1;
            return ((edad > 1) ? Convert.ToString(edad) + " años" : "");
        }

        public static DateTime FechaAlerta(string fecha, int dias) //Retorna una variable tipo DateTime con una fecha de alerta
        {
            return ValidarFecha(fecha).AddDays(-dias);
        }

        public static string FechaProgramada(int meses) //Retorna una cadena con una fecha programada y formateada a partir de la fecha actual
        {
            return Global.RelojDeSistema.AddMonths(meses).ToString("dd/MM/yyyy");
        }

        public static string FechaProgramada(string fecha, int meses) //Retorna una cadena con una fecha programada y formateada a partir de una fecha especificada
        {
            return ValidarFecha(fecha).AddMonths(meses).ToString("dd/MM/yyyy");
        }
        #endregion
    }
}
