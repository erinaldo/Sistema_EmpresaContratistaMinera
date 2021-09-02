using System;
using System.Windows.Forms;

namespace Biblioteca.Formularios
{
    public partial class FormBaseInicio : Form
    {
        public FormBaseInicio()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FormBaseInicio_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnAceptar, "Ingresa al sistema");
            toolTip.SetToolTip(btnSalir, "Cierra el sistema");
            #endregion
        }

        private void FormBaseInicio_KeyPress(object sender, KeyPressEventArgs e) //Método que realiza "Tab" sobre los controles al oprimir la tecla "Enter"
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            cerrarAplicacion();
        }
        #endregion

        #region Métodos
        protected virtual void cerrarAplicacion()
        {
            Application.Exit(); //Cierra la Aplicación 
        }
        #endregion
    }
}
