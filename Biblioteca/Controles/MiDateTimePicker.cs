using System.Windows.Forms;

namespace Biblioteca.Controles
{
    public partial class MiDateTimePicker : DateTimePicker
    {
        public MiDateTimePicker()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
