using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;

namespace Biblioteca.Ayudantes
{
    public class Captcha
    {
        #region Atributos
        private string codigoCaptcha;
        private Image imagenCaptcha;
        #endregion

        #region Propiedades
        public string CodigoCaptcha { get => codigoCaptcha; set => codigoCaptcha = value; }
        public Image ImagenCaptcha { get => imagenCaptcha; set => imagenCaptcha = value; }
        #endregion

        #region Constructores
        public Captcha(int x, int y)
        {
            this.generarCaptcha(x, y);
        }
        #endregion

        #region Métodos
        private void generarCaptcha(int x, int y)
        {
            Random rnd = new Random();
            //Crea una imagen de 32bits
            Bitmap imagen = new Bitmap(x, y, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(imagen);
            //Rellena la imagen con un fondo tramado
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectangulo = new Rectangle(0, 0, x, y);
            HatchBrush tramado = new HatchBrush(HatchStyle.SmallConfetti, rdnColor(92, 128, rnd), Color.LightGray);
            g.FillRectangle(tramado, rectangulo);
            //Dibuja algunas líneas de forma aleatoria en la imagen
            for (int a = 0; a < 4; a++)
            {
                Pen linea = new Pen(rdnColor(92, 192, rnd), rnd.Next(0, 3));
                g.DrawLine(linea, 0, rnd.Next(2, y), x, rnd.Next(2, y));
                g.DrawLine(linea, rnd.Next(5, x), rnd.Next(2, y), rnd.Next(5, x), rnd.Next(2, y));
            }
            //Genera un código captcha de forma aleatoria con caractéres y numeros
            StringBuilder codigo = new StringBuilder();
            string caracteresValidos = "23456789ABDEFGHJKLMNPRSTUWXZ23456789";
            for (int a = 0; a < 5; a++)
            {
                codigo.Append(caracteresValidos[rnd.Next(caracteresValidos.Length)]);
            }
            //Dibuja el código captcha
            int d = 0;
            for (int a = 0; a < codigo.Length; a++)
            {
                Font fuente = new Font("Arial", rnd.Next(12, 17), FontStyle.Bold);
                SolidBrush fuenteSolida = new SolidBrush(rdnColor(32, 96, rnd));
                g.DrawString(codigo[a].ToString(), fuente, fuenteSolida, d, 0);
                d += x / (codigo.Length + 1);
            }
            this.CodigoCaptcha = Convert.ToString(codigo).ToLower();
            this.ImagenCaptcha = imagen;
         }
        
        private static Color rdnColor(int i, int j, Random rnd) //Método que genera un color aleatorio dentro de un rango especificado
        {
            Color color = Color.FromArgb(rnd.Next(i, j), rnd.Next(i, j), rnd.Next(i, j));
            return color;
        }
        #endregion
    }
}
