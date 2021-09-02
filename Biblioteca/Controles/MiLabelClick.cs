using System;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteca.Controles
{
    public partial class MiLabelClick : Label
    {
        public MiLabelClick()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        #region Eventos
        private void this_MouseEnter(object sender, EventArgs e)
        {
            this.ForeColor = Color.FromArgb(57, 121, 107);
        }

        private void this_MouseLeave(object sender, EventArgs e)
        {
            this.ForeColor = Color.Gray;
        }
        #endregion
    }
}
