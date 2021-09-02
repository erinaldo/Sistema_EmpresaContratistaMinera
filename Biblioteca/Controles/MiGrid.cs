using System.Windows.Forms;

namespace Biblioteca.Controles
{
    public partial class MiGrid : DataGridView
    {
        public MiGrid()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
