using System;
using System.Threading;
using Biblioteca.Ayudantes;
using CapaNegocio.Sistema;

namespace CapaPresentacion
{ 
    public partial class FormHerramienta : Biblioteca.Formularios.FormBase
    {
        #region Atributos
        private string _directorioBackup = "";
        private string _rutaBackup = "";
        private System.Windows.Forms.Timer temporizador;
        private N_Herramienta nHerramientas = new N_Herramienta();
        #endregion

        public FormHerramienta()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FormHerramienta_Load(object sender, EventArgs e)
        {
            _directorioBackup = Archivo.ValidarDirectorio(@"Backups\");
            txtDestinoBackup.Text = _directorioBackup;
        }

        private void btnCrearBackup_Click(object sender, EventArgs e)
        {
            if (!progressBarProceso.Visible) //Verifica que No se este ejecutando el proceso de recuperación
            {
                txtDestinoBackup.Text = "En Proceso..."; //Importante: Borra cualquier ruta mostrada en la caja de texto "Destino"
                procesarOperacion(new Procesamiento("CREAR_BACKUP"));
            }
        }

        private void btnBuscarBackup_Click(object sender, EventArgs e)
        {
            if (!progressBarProceso.Visible) //Verifica que No se este ejecutando el proceso de recuperación
            {
                _rutaBackup = Archivo.ObtenerArchivo(@"Backups\", "BACKUP");
                txtOrigenBackup.Text = _rutaBackup;
            }
        }

        private void btnRestaurarBackup_Click(object sender, EventArgs e)
        {
            if (!progressBarProceso.Visible) //Verifica que No se este ejecutando el proceso de recuperación
            {
                if (!string.IsNullOrEmpty(txtOrigenBackup.Text) && !string.IsNullOrEmpty(_rutaBackup)) procesarOperacion(new Procesamiento("RESTAURAR_BACKUP", _rutaBackup));
                else Mensaje.Advertencia("Archivo Inaccesible.\nEspecifique un Backup de restauración e intente nuevamente.");
            }
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
                this.Parent.Enabled = true; //Rehabilita el formulario padre
            }
        }
        #endregion

        #region Métodos
        protected override void cerrarAplicacion()
        {
            if (!progressBarProceso.Visible) //Verifica que se haya terminado de ejecutar los procesos iniciales
            {
                base.cerrarAplicacion();
            }
        }

        private void procesarOperacion(Procesamiento procesamiento)
        {
            this.Parent.Enabled = false; //Desabilita el formulario padre
            procesamiento.Progresar += new Procesamiento.ProgresoHandler(progresar);
            procesamiento.RutearBackup += new Procesamiento.RutaBackupHandler(rutearBackup);
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

        protected void progresar(int valor)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => progressBarProceso.Value = valor));
            }
        }

        protected void rutearBackup(string rutaBackup)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    _rutaBackup = rutaBackup;
                    txtDestinoBackup.Text = rutaBackup;
                }));
            }
        }
        #endregion

        #region CLASE INTERNA
        private class Procesamiento
        {
            #region Delegados y Eventos
            public delegate void RutaBackupHandler(string rutaBackup); //Delegado: Crea un puntero a una dirección de memoria que apunta a un método para mostrar el nombre del backup
            public delegate void ProgresoHandler(int valor); //Delegado: Crea un puntero a una dirección de memoria que apunta a un método para mostrar el progreso
            public event RutaBackupHandler RutearBackup; //Evento Oyente: Crea una evento que se dispara al ser invocado  
            public event ProgresoHandler Progresar; //Evento Oyente: Crea una evento que se dispara al ser invocado  
            #endregion

            #region Atributos
            private string _rutaBackup = "";
            private string _controlDeOperacion = "";
            #endregion

            #region Constructores
            public Procesamiento(string controlDeOperacion)
            {
                _controlDeOperacion = controlDeOperacion;
            }
            public Procesamiento(string controlDeOperacion, string rutaBackup)
            {
                _controlDeOperacion = controlDeOperacion;
                _rutaBackup = rutaBackup;
            }
            #endregion

            #region Métodos
            public void procesar()
            {
                Progresar(35);
                if (_controlDeOperacion == "CREAR_BACKUP") RutearBackup(new N_Herramienta().crearBackupDB()); //Crea un archivo de backup de la Base de Datos y almacena la ruta de acceso en la referencia recibida
                if (_controlDeOperacion == "RESTAURAR_BACKUP") new N_Herramienta().restaurarDB(_rutaBackup); //Restaura la Base de Datos desde un backup anteriormente creado
                Progresar(100);
            }
            #endregion
        }
        #endregion
    }
}
