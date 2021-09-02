using System;
using System.Windows.Forms;

namespace Biblioteca.Controles
{
    public partial class MiMaskedTextBox : MaskedTextBox
    {
        public MiMaskedTextBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        #region Métodos
        private void MiMaskedTextBox_GotFocus(object sender, EventArgs e)
        {
            this.SelectAll(); //Selecciona todo el contenido del TextBox al recibir el foco (TAB)          
        }
        #endregion
    }
}
