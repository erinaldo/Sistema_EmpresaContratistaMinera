using Biblioteca.Ayudantes;
using System;
using System.Windows.Forms;

namespace Biblioteca.Formularios
{
    public partial class FormBase : Form
    {
        #region Atributos
        protected bool _controladorDeNuevoRegistro = false;
        #endregion

        public FormBase()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FormBase_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnCerrar, "Cierra la ventana");
            #endregion
            labelUsuario.Text = "Sesión de " + Global.UsuarioActivo_TipoUsuario.ToLower() + ": " + Global.UsuarioActivo_Denominacion; //Asigna y muestra el usuario activo
        }

        private void FormBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            controlarFoco(e);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            cerrarAplicacion();
        }
        #endregion

        #region Métodos
        protected virtual void controlarFoco(KeyPressEventArgs e) //Importante: Método Sobrescribible que mueve el foco al siguiente control del formulario
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        } 
        public virtual void asignarVariablesDeCuadricula(string[] variablesDeFormulario) { } //Importante: Método Sobrescribible para almacenar variables temporales de los formularios que contienen una cuadricula
        public virtual void asignarVariablesDeFormulario(string[] variablesDeFormulario) { } //Método Sobrescribible para almacenar variables temporales
        protected virtual void cerrarAplicacion()
        {
            this.Close(); //Cierra este formulario
        }
        #endregion
    }
}
