using System;
using System.Windows.Forms;
using Biblioteca.Formularios;
using Biblioteca.Ayudantes;
using CapaNegocio.Sistema;

namespace CapaPresentacion.Modales
{
    public partial class FormNotificacion : FormBaseModal
    {
        #region Atributos
        private bool abrirFormularioDeAlertas = false;
        #endregion

        public FormNotificacion()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FormNotificacion_Load(object sender, EventArgs e)
        {
            int caducado = new N_Alerta().obtenerObjetos("ALERTAS PERSONALIZADAS", "CADUCADO", "DENOMINACION", "").Count;
            int enProceso = new N_Alerta().obtenerObjetos("ALERTAS PERSONALIZADAS", "EN PROCESO", "DENOMINACION", "").Count;
            int sinProcesar = new N_Alerta().obtenerObjetos("ALERTAS PERSONALIZADAS", "SIN PROCESAR", "DENOMINACION", "").Count;
            lblNotificacionAlerta1.Text = ((caducado > 0) ? "Hay " + caducado.ToString() : "No hay") + ((caducado > 1) ? " alertas" : " una alerta") + " que ha" + ((caducado > 1) ? "n" : "") + " caducado";
            lblNotificacionAlerta2.Text = ((enProceso > 0) ? "Hay " + enProceso.ToString() : "No hay") + ((enProceso > 1) ? " alertas" : " una alerta") + " en proceso";
            lblNotificacionAlerta3.Text = ((sinProcesar > 0) ? "Hay " + sinProcesar.ToString() : "No hay") + ((sinProcesar > 1) ? " alertas" : " una alerta") + " sin procesar";
        }

        private void FormModalNotificacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (abrirFormularioDeAlertas)
            {
                foreach (Form hijo in Global.FormularioPrincipal.MdiChildren) hijo.Close(); //Cierra los formularios que esten abiertos
                FormAlerta formAlerta = new FormAlerta();
                formAlerta.MdiParent = Global.FormularioPrincipal;
                formAlerta.Dock = DockStyle.Fill;
                formAlerta.Show();
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            abrirFormularioDeAlertas = true;
            this.Close();
        }
        #endregion
    }
}
