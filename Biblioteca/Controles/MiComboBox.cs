using System.Drawing;
using System.Windows.Forms;

namespace Biblioteca.Controles
{
    public partial class MiComboBox : ComboBox
    {
        public MiComboBox()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m) //Método que personaliza los bordes del ComboBox
        {
            base.WndProc(ref m);
            int anchoDelDesplegable = SystemInformation.HorizontalScrollBarArrowWidth;
            using (var g = Graphics.FromHwnd(Handle))
            {
                using (var lapiz = new Pen(Color.Gray))
                {
                    g.DrawRectangle(lapiz, 0, 0, Width - 1, Height - 1); //Dibuja los bordes en el ComboBox
                    g.DrawLine(lapiz, Width - anchoDelDesplegable, 0, Width - anchoDelDesplegable, Height); //Colorea los bordes del ComboBox
                }
            }
        }
    }
}
