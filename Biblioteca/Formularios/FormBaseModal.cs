using System.Windows.Forms;

namespace Biblioteca.Formularios
{
    public partial class FormBaseModal : Form
    {
        public FormBaseModal()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FormBaseModal_Load(object sender, System.EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnCerrar, "Cierra la ventana");
            #endregion
        }

        private void FormBaseModal_KeyPress(object sender, KeyPressEventArgs e) //Método que realiza "Tab" sobre los controles al oprimir la tecla "Enter"
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        #endregion
    }
}
