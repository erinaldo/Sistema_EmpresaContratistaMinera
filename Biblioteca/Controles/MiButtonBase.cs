using System.Windows.Forms;

namespace Biblioteca.Controles
{
    public partial class MiButtonBase : Button
    {
        public MiButtonBase()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
