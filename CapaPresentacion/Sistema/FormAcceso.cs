using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio.Sistema;

namespace CapaPresentacion
{
    public partial class FormAcceso : Biblioteca.Formularios.FormBaseInicio
    {
        #region Atributos
        private System.Windows.Forms.Timer temporizador;
        private N_Monitor nMonitor = new N_Monitor();
        private N_Usuario nUsuario = new N_Usuario();
        private Regex _esNumero = new Regex("[^0-9]");
        #endregion

        public FormAcceso()
        {
            InitializeComponent();
            this.txtUsuario.Text = "28005630";
            this.txtContrasenia.Text = "c_M1";
        }

        #region Eventos
        private void FormAcceso_Shown(object sender, EventArgs e)
        {
            Procesamiento procesamiento = new Procesamiento();
            procesamiento.Progresar += new Procesamiento.ProgresoHandler(progresar);
            procesamiento.Titular += new Procesamiento.TituloDeProgresoHandler(titular);
            Thread subProceso = new Thread(procesamiento.procesar);
            subProceso.Start();
            #region temporizador
            temporizador = new System.Windows.Forms.Timer();
            temporizador.Enabled = true;
            temporizador.Interval = 450;
            temporizador.Start();
            temporizador.Tick += new EventHandler(temporizador_Tick);
            #endregion
            lblVersionCompilacion.Text = "v" + Archivo.LeerTXT(Archivo.ValidarDirectorio(@"Update\"), "version.sys").Trim().PadRight(6, '0').Insert(1, ".").Insert(4, ".");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (progressBarProceso.Value == 100) //Verifica que se haya terminado de ejecutar el monitor del sistema
            {
                string documento = this.txtUsuario.Text.Trim();
                string contrasenia = this.txtContrasenia.Text.Trim();
                if (documento.Length >= 7 && documento.Length <= 8 && !_esNumero.IsMatch(documento)) //Valida el formato del DNI
                {
                    if (contrasenia.Length == 4) //Valida el formato de la contraseña
                    {
                        if (nUsuario.iniciarSesion(documento, contrasenia, true)) //Valida el documento y contraseña ingresado en relación al documento y contraseña registrado en la Base de Datos
                        {
                            Screen screen = Screen.PrimaryScreen;
                            FormPrincipal formPrincipal = new FormPrincipal(); //Crea el formulario principal del sistema
                            Global.FormularioPrincipal = formPrincipal; //Importante para las notificaciones: Almacena la referencia del formulario principal
                            formPrincipal.Location = new Point(((screen.Bounds.Width - formPrincipal.Width) / 2), 0);
                            formPrincipal.WindowState = (screen.Bounds.Width == 1024) ? FormWindowState.Maximized : FormWindowState.Normal;
                            this.Hide();
                            formPrincipal.Show(); //Muestra el formulario principal del sistema
                        }
                    }
                    else Mensaje.Advertencia("Operación Incorrecta.\nIngrese una contraseña válida e intente nuevamente.");
                }
                else Mensaje.Advertencia("Operación Incorrecta.\nIngrese el DNI de un usuario válido e intente nuevamente.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (progressBarProceso.Value == 100) //Verifica que se haya terminado de ejecutar el monitor del sistema
            {
                Application.Exit(); //Cierra la Aplicación
            }
        }

        private void linkRecuperarContrasenia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (progressBarProceso.Value == 100) //Verifica que se haya terminado de ejecutar el monitor del sistema
            {
                this.Hide();
                FormAccesoRecuperacion formRecuperarContrasenia = new FormAccesoRecuperacion();
                formRecuperarContrasenia.Show();
            }
        }

        private void temporizador_Tick(Object myObject, EventArgs myEventArgs)
        {
            Formulario.Visibilidad(((lblLeyenda.Visible) ? false : true), new Control[] { lblLeyenda });
            if (progressBarProceso.Value == 100)
            {
                temporizador.Dispose();
                Formulario.Visibilidad(false, new Control[] { lblLeyenda, progressBarProceso });
                Formulario.Visibilidad(true, new Control[] { btnAceptar, btnSalir, linkRecuperarContrasenia });
                linkRecuperarContrasenia.Enabled = true;
            }
        }
        #endregion

        #region Métodos
        protected override void cerrarAplicacion()
        {
            if (progressBarProceso.Value == 100) //Verifica que se haya terminado de ejecutar los procesos iniciales
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

        protected void titular(string leyenda)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => lblLeyenda.Text = leyenda));
            }
        }
        #endregion

        #region CLASE INTERNA
        private class Procesamiento
        {
            #region Atributos
            private bool _controlDeActualizacion = false;
            public delegate void ProgresoHandler(int valor); //Delegado: Crea un puntero a una dirección de memoria que apunta a un método
            public delegate void TituloDeProgresoHandler(string leyenda); //Delegado: Crea un puntero a una dirección de memoria que apunta a un método
            public event ProgresoHandler Progresar; //Evento Oyente: Crea una evento que se dispara al ser invocado  
            public event TituloDeProgresoHandler Titular; //Evento Oyente: Crea una evento que se dispara al ser invocado  
            #endregion

            #region Métodos
            public void procesar()
            {
                Titular("Procesando... Por Favor Espere"); //Define la leyenda del título de la barra de progreso
                Fecha.SincronizarRelojDeSistema(); //Sincroniza el reloj interno del sistema
                Progresar(5);
                if (new N_Conexion().ProbarConexion())
                {
                    if (Global.cargarVariablesDeCredencialFTP(new N_CredencialFTP().obtenerObjeto("ID", "1")))
                    {
                        Progresar(10);
                        if (Global.cargarVariablesDeOpcionesGenerales(new N_OpcionGeneral().obtenerObjeto("ID", "1", true)))
                        {
                            Progresar(15);
                            if (Global.cargarVariablesDeEmpresa(new N_MiEmpresa().obtenerObjeto("ID", "1", true)))
                            {
                                Progresar(20);
                                _controlDeActualizacion = Actualizacion.CompararActualizacionFTP();
                                Progresar(25);
                                if (_controlDeActualizacion) _controlDeActualizacion = solicitarConfirmacion();
                                Progresar(30);
                                if (_controlDeActualizacion)
                                {
                                    Titular("      Actualizando el Sistema...      "); //Define la leyenda del título de la barra de progreso
                                    _controlDeActualizacion = Actualizacion.DescargarActualizacionFTP();
                                }
                                Progresar(40);
                                if (_controlDeActualizacion) _controlDeActualizacion = Actualizacion.DescomprimirActualizacion();
                                Progresar(50);
                                if (_controlDeActualizacion) //Concreta una actualización del sistema
                                {
                                    Progresar(60);
                                    Thread subProceso = new Thread(Actualizacion.EjecutarArchivoBatch); //Crea un sub proceso para ejecutar el archivo .bat
                                    subProceso.Start(); //Inicia el sub proceso que ejecutará el archivo actualizar.bat
                                }
                                else
                                {
                                    new N_Monitor().monitorearAlertas();
                                    Progresar(70);
                                    new N_Monitor().monitorearAlertasDeArticulo();
                                    Progresar(72);
                                    new N_Monitor().monitorearAlertasDeAntecedentes();
                                    Progresar(74);
                                    new N_Monitor().monitorearAlertasDeCobro();
                                    Progresar(76);
                                    new N_Monitor().monitorearAlertasDeCursoInduccion();
                                    Progresar(78);
                                    new N_Monitor().monitorearAlertasDeCursoIzaje();
                                    Progresar(80);
                                    new N_Monitor().monitorearAlertasDeEntrevista();
                                    Progresar(82);
                                    new N_Monitor().monitorearAlertasDeExamenMedico();
                                    Progresar(84);
                                    new N_Monitor().monitorearAlertasDeLicenciaConducir();
                                    Progresar(86);
                                    new N_Monitor().monitorearAlertasDePago();
                                    Progresar(88);
                                    new N_Monitor().monitorearEstados();
                                    Progresar(100);
                                }
                            }
                        }
                    }
                }
                else Application.Exit();
            }

            private bool solicitarConfirmacion()
            {
                if (Mensaje.ConfirmacionBoton1("Hay una nueva actualización del sistema que debe ejecutarse\n¿Desea ejecutar la actualización en este momento?") == DialogResult.Yes)
                {
                    return true;
                }
                Actualizacion.CancelarActualizacion(); //Cierra el Sistema
                return false;
            }
            #endregion
        }
        #endregion
    }
}
