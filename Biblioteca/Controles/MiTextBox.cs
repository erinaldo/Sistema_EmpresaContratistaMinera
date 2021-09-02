using System;
using System.Windows.Forms;

namespace Biblioteca.Controles
{
    public partial class MiTextBox : TextBox
    {
        public MiTextBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        #region Métodos
        private void MiTextBox_GotFocus(object sender, EventArgs e)
        {
            this.SelectAll(); //Selecciona todo el contenido del TextBox al recibir el foco (TAB)          
        }
        #endregion
    }
}
