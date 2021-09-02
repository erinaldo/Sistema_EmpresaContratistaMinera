using System.Windows.Forms;

namespace Biblioteca.Controles
{
    public partial class MiNumericUpDown : NumericUpDown
    {
        public MiNumericUpDown()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
