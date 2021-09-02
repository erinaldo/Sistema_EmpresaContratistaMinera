using System;
using System.Text.RegularExpressions;
using System.Threading;
using Biblioteca.Ayudantes;
using CapaNegocio.Sistema;

namespace CapaPresentacion
{
    public partial class FormAccesoRecuperacion : Biblioteca.Formularios.FormBaseInicio
    {
        #region Atributos
        private string _codigoCaptcha;
        private bool _verificacionDeRecuperacion = false;
        private System.Windows.Forms.Timer temporizador;
        private N_Usuario nUsuario = new N_Usuario();
        private Regex _esNumero = new Regex("[^0-9]");
        private Regex _esCorreo = new Regex("[^0-9].[^a-z]@[^a-z].[^a-z]");
        #endregion

        public FormAccesoRecuperacion()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FormAccesoRecuperacion_Load(object sender, EventArgs e)
        {
            Captcha captcha = new Captcha(pictureCaptcha.Width, pictureCaptcha.Height);
            pictureCaptcha.Image = captcha.ImagenCaptcha;
        }

        private void FormAccesoRecuperacion_Shown(object sender, EventArgs e)
        {
            actualizarCaptcha();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!progressBarProceso.Visible) //Verifica que No se este ejecutando el proceso de recuperación
            {
                string usuario = txtDocumento.Text.Trim();
                string correo = txtCorreo.Text.Trim();
                string captcha = txtCaptcha.Text.Trim().ToLower();
                if (usuario.Length >= 7 && usuario.Length <= 8 && !_esNumero.IsMatch(usuario)) //Valida el formato del DNI
                {
                    if (correo.Length > 0 && correo.Length <= 45 && !_esCorreo.IsMatch(correo)) //Valida el formato del correo
                    {
                        if (captcha.Length == 5 && captcha == _codigoCaptcha) //Valida el codigo Captcha
                        {
                            Procesamiento procesamiento = new Procesamiento(this, txtDocumento.Text.Trim(), txtCorreo.Text.Trim());
                            procesamiento.Progresar += new Procesamiento.ProgresoHandler(progresar);
                            Thread subProceso = new Thread(procesamiento.procesar);
                            subProceso.Start();
                            #region temporizador
                            temporizador = new System.Windows.Forms.Timer();
                            temporizador.Enabled = true;
                            temporizador.Interval = 450;
                            temporizador.Start();
                            temporizador.Tick += new EventHandler(temporizador_Tick);
                            #endregion
                        }
                        else Mensaje.Advertencia("Operación Incorrecta.\nIngrese un código captcha válido e intente nuevamente.");
                    }
                    else Mensaje.Advertencia("Operación Incorrecta.\nIngrese un correo válido e intente nuevamente.");
                }
                else Mensaje.Advertencia("Operación Incorrecta.\nIngrese el DNI de un usuario válido e intente nuevamente.");
            }
        }

        private void pictureCaptcha_Click(object sender, EventArgs e)
        {
            actualizarCaptcha();
        }

        private void btnRefreshCaptcha_Click(object sender, EventArgs e)
        {
            actualizarCaptcha();
        }

        private void temporizador_Tick(Object myObject, EventArgs myEventArgs)
        {
            lblLeyenda.Visible = (lblLeyenda.Visible) ? false : true;
            progressBarProceso.Visible = true;
            if (progressBarProceso.Value == 100)
            {
                temporizador.Dispose();
                lblLeyenda.Visible = false;
                progressBarProceso.Visible = false;
                if (_verificacionDeRecuperacion) //Verifica si se ha logrado completar el proceso de recuperación de contraseña
                {
                    this.Hide(); //Oculta el formulario de recuperación de constraseña 
                    new FormAcceso().Show(); //Abre nuevamente el formulario de acceso despues de haber enviado el correo de recuperación
                }
            }
        }
        #endregion

        #region Métodos
        private void actualizarCaptcha() //Método que actualiza el código y la imagen Captcha
        {
            Captcha captcha = new Captcha(this.pictureCaptcha.Width, this.pictureCaptcha.Height);
            _codigoCaptcha = captcha.CodigoCaptcha;
            pictureCaptcha.Image = captcha.ImagenCaptcha;
        }

        protected override void cerrarAplicacion()
        {
            if (!progressBarProceso.Visible) //Verifica que No se este ejecutando el proceso de recuperación
            {
                base.cerrarAplicacion();
            }
        }

        protected void progresar(int valor)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => progressBarProceso.Value = valor));
            }
        }
        #endregion

        #region CLASE INTERNA
        private class Procesamiento
        {
            #region Atributos
            private FormAccesoRecuperacion _formulario = null;
            private string _usuario = "";
            private string _correo = "";
            public delegate void ProgresoHandler(int valor); //Delegado: Crea un puntero a una dirección de memoria que apunta a un método
            public event ProgresoHandler Progresar; //Evento Oyente: Crea una evento que se dispara al ser invocado  
            #endregion

            #region Constructores
            public Procesamiento(FormAccesoRecuperacion formulario, string usuario, string correo)
            {
                _formulario = formulario;
                _usuario = usuario;
                _correo = correo;
            }
            #endregion

            #region Métodos
            public void procesar()
            {
                Progresar(50);
                if (new N_Usuario().recuperarUsuario(_usuario, _correo, true)) _formulario._verificacionDeRecuperacion = true; //Valida el documento y contraseña ingresado en relación al documento y contraseña registrado en la Base de Datos
                Progresar(100);
            }
            #endregion
        }
        #endregion
    }
}
