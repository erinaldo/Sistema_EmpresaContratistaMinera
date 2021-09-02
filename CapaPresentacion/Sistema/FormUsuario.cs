using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using CapaNegocio.Sistema;
using CapaPresentacion.Catalogo;
using Entidades;
using Entidades.Catalogo;
using Entidades.Sistema;

namespace CapaPresentacion
{
    public partial class FormUsuario : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private long _idUsuario = 0;
        private List<Privilegio> _listaDePrivilegios = new List<Privilegio>();
        private string[] consultaUsuario;
        private Legajo objLegajo; //Objeto Maestro
        private Usuario objUsuario;
        private Usuario objUsuarioDB;
        private N_Usuario nUsuario = new N_Usuario();
        private N_Privilegio nPrivilegio = new N_Privilegio();
        #endregion

        #region Constructores
        public FormUsuario()
        {
            InitializeComponent();
        }
        public FormUsuario(Legajo navLegajo) //Utilizado por el navegador de formularios
        {
            objLegajo = navLegajo;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormUsuario_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR LEGAJOS C/BAJA",
                "FILTRAR POR LEGAJOS S/BAJA", "TODOS LOS LEGAJOS" }, 1); //Establece los items del ComboBox  
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT", "FILTRAR POR DENOMINACION" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
        }

        private void btnBuscarLegajo_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                FormCatalogo_Legajo frm = new FormCatalogo_Legajo(this);
                frm.ShowDialog(this);
            }
        }

        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            configurarPrivilegioPorTipoDeUsuario();
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(87))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                txtContrasenia.Text = Encriptacion.GenerarContrasenia();
                #region Privilegios Temporales
                /* Importante: Crea un número negativo que se genera en relación al ID máximo de la tabla multiplicado por
                 * el ID del usuario activo. Este número forma temporalmente el nombre de la columna que representará al
                 * usuario que se está creando. La misma se utiliza para identificar los privilegios que se han asignado
                 * a dicho usuario. Una vez registrado el usuario, se renombra a la columna con el número del ID definitivo
                 * o en su defecto la columna será eliminada.*/
                nPrivilegio.quitarColumnas_Temporales(); //Paso 1: Elimina todos las columnas temporales
                _idUsuario = (nUsuario.generarNumeroID() * -1) * Global.UsuarioActivo_IdUsuario; //Paso 2: Asigna un numero negativo para formar el nombre de la columna
                nPrivilegio.agregarColumna(_idUsuario); //Paso 3: Agrega la columna temporal en la tabla sys_privilegio
                _listaDePrivilegios = nPrivilegio.obtenerObjetos(_idUsuario); //Paso 4: Carga la lista de privilegios
                Formulario.Grid_CargarFilas(gridListaPrivilegio, _listaDePrivilegios); //Paso 5: Carga los privilegios en el gridListaPrivilegio
                configurarPrivilegioPorTipoDeUsuario(); //Paso 6: Configurar privilegios de usuario en relación al tipo de usuario
                #endregion
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idUsuario <= 0 && Global.UsuarioActivo_Privilegios.Contains(87)) //Verifica que el usuario posea el privilegio requerido
            {
                //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        objUsuario.Id = nUsuario.generarNumeroID(); //Paso 2: Genera un ID para cada Objeto
                        if (nUsuario.insertar(objUsuario)) //Paso 3: Inserta el objeto principal
                        {
                            nPrivilegio.asociarColumna(objUsuario.Id, _idUsuario); //Paso 4: Asocia la columna temporal con el usuario que se ha registrado
                            nPrivilegio.actualizar(objUsuario.Id, _listaDePrivilegios); //Paso 5: Registra los privilegios asignados al usuario
                            Correo.EnviarCorreo_Contrasenia("Asignación de Contraseña", txtEmailRecuperacion.Text, objUsuario.Legajo.Denominacion, Convert.ToString(objUsuario.Legajo.Documento), txtContrasenia.Text); //Paso 6: Envia un correo electronico al email de recuperación con la contraseña generada 
                            _idUsuario = objUsuario.Id; //Paso 7: Importante: Iguala la variable local con el ID asignado
                            mostrarRegistro(objUsuario);
                            Mensaje.RegistroCorrecto("REGISTRACION");
                        }
                    }
                }
            }
            else if (_idUsuario > 0 && Global.UsuarioActivo_Privilegios.Contains(89)) //Verifica que el usuario posea el privilegio requerido
            {
                //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                if (ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                    {
                        List<bool> controlActualizacion = new List<bool>(); //Paso 1: Almacen el/los resultado(s) de la actualización de datos
                        instanciarObjeto(); //Paso 2: Instancia el Objeto
                        if (!objUsuario.Equals(objUsuarioDB)) controlActualizacion.Add(nUsuario.actualizar(objUsuario)); //Paso 3: Verifica que el objeto se ha modificado y actualiza el Objeto 
                        if (!controlActualizacion.Contains(false)) //Paso 4: Verifica el exito de la actualización y muestra los datos actualizados
                        {
                            nPrivilegio.actualizar(objUsuario.Id, _listaDePrivilegios); //Paso 5: Actualiza los privilegios del usuario
                            mostrarRegistro(objUsuario);
                            Mensaje.RegistroCorrecto("MODIFICACION");
                        }
                    }
                }
            }
            else Mensaje.Restriccion();
            bool ValidarCampoVacio() // Método que valida los campos requeridos
            {
                return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion, txtCuit, txtEmailRecuperacion });
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idUsuario > 0) escribirControles(nUsuario.obtenerObjeto("ID", _idUsuario.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e) //Botón ELIMINAR ----------
        {
            if (_idUsuario > 0 && Global.UsuarioActivo_Privilegios.Contains(88)) //Verifica que el usuario posea el privilegio requerido
            {
                if (Mensaje.ConfirmacionBoton1("¿Desea eliminar el usuario de " + objLegajo.Denominacion + "?") == DialogResult.Yes)
                {
                    List<bool> controlActualizacion = new List<bool>(); //Paso 1: Almacen el/los resultado(s) de la actualización de datos
                    instanciarObjeto(); //Paso 2: Instancia el Objeto
                    if (!objUsuario.Equals(objUsuarioDB)) controlActualizacion.Add(nUsuario.eliminar(objUsuario)); //Paso 3: Verifica que el objeto se ha Eliminado 
                    if (!controlActualizacion.Contains(false)) //Paso 4: Verifica el exito de la actualización y muestra los datos actualizados
                    {
                        nPrivilegio.quitarColumna(objUsuario.Id); //Paso 5: Elimina los privilegios del usuario
                        restaurarControles(); //Paso 6: Restaura el formulario
                        filtrarCatalogo(0); //Paso 7: Carga el catálogo
                        lstCatalogo.ClearSelected(); //Paso 8: Quita la selección de la fila
                        Mensaje.RegistroCorrecto("MODIFICACION");
                    }
                }
            }
            else Mensaje.Restriccion();
        }
        #endregion

        #region Métodos
        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void configurarPrivilegioPorTipoDeUsuario()
        {
            List<long> tipousuarios1 = new List<long>() { };
            if (cmbTipoUsuario.Text == "OPERADOR") tipousuarios1 = new List<long>() { 2, 5, 8, 11, 14, 17, 20, 21,
                25, 26, 30, 31, 33, 34, 44, 45, 46, 55, 56, 57, 58, 59, 61, 62, 64, 65, 67, 68, 70, 71, 73,
                74, 77, 78, 79, 80, 82, 84, 86, 87, 89, 90, 91, 92, 95, 96, 99, 100, 102, 103, 106, 107, 110, 111,
                114, 115, 117, 118, 120, 121, 123, 124, 127, 128, 130, 131, 134, 135, 138, 139, 142, 143, 144,
                145, 148, 149, 152, 153, 156, 157, 160, 161, 164, 165, 168, 170, 173, 174 };
            if (cmbTipoUsuario.Text == "SOPORTE TECNICO") tipousuarios1 = new List<long>() { 81 };
            foreach (Privilegio item in _listaDePrivilegios)
            {
                if (cmbTipoUsuario.Text == "SUPERVISOR") item.Permiso = true;
                else
                {
                    if (tipousuarios1.Contains(item.Id)) item.Permiso = true;
                    else item.Permiso = false;
                }
            }
            Formulario.Grid_CargarFilas(gridListaPrivilegio, _listaDePrivilegios);
        }

        private void escribirControles(Usuario objUsuario)
        {
            this.objUsuario = objUsuario; //Iguala el Atributo de la clase con el Objeto recibido
            if (objUsuario != null)
            {
                if (!objUsuario.Legajo.InformacionRestringida || (objUsuario.Legajo.InformacionRestringida && Global.UsuarioActivo_Privilegios.Contains(1))) //Verifica que el usuario posea el privilegio requerido
                {
                    _controladorDeNuevoRegistro = false;
                    _idUsuario = (objUsuario != null) ? objUsuario.Id : 0;
                    objLegajo = objUsuario.Legajo;
                    txtDenominacion.Text = objUsuario.Legajo.Denominacion;
                    txtCuit.Text = Convert.ToString(objUsuario.Legajo.Cuit);
                    txtContrasenia.Text = "xxxx"; //Se prohibe la modificación de la Clave y solamente se puede cambiar por medio de una recuperacion de usuario 
                    cmbTipoUsuario.Text = objUsuario.TipoUsuario;
                    txtEmailRecuperacion.Text = objUsuario.EmailRecuperacion;
                    chkAlertaFacturacion.Checked = objUsuario.AlertaFacturacion;
                    chkAlertaInventario.Checked = objUsuario.AlertaInventario;
                    chkAlertaRRHH.Checked = objUsuario.AlertaRRHH;
                    _listaDePrivilegios = objUsuario.ListaDePrivilegios;
                    Formulario.Grid_CargarFilas(gridListaPrivilegio, _listaDePrivilegios);
                    labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objUsuario.EdicionFecha) + " por " + objUsuario.EdicionUsuarioDenominacion;
                }
                else restaurarControles();
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objUsuario = new Usuario(
                (_idUsuario <= 0) ? 0 : _idUsuario,
                objLegajo,
                Encriptacion.EncriptarContrasenia(txtContrasenia.Text),
                cmbTipoUsuario.Text,
                txtEmailRecuperacion.Text,
                chkAlertaFacturacion.Checked,
                chkAlertaInventario.Checked,
                chkAlertaRRHH.Checked,
                _listaDePrivilegios,
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objLegajo = new Legajo(); //Restaura el Objeto maestro
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            _idUsuario = 0; //Libera el Id del Objeto seleccionado
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            txtContrasenia.Text = "";
            cmbTipoUsuario.Text = "OPERADOR";
            txtEmailRecuperacion.Text = "";
            chkAlertaFacturacion.Checked = false;
            chkAlertaInventario.Checked = false;
            chkAlertaRRHH.Checked = false;
            _listaDePrivilegios.Clear(); //Libera la lista de privilegios
            gridListaPrivilegio.DataSource = null; //Libera la lista de privilegios
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, txtCuit }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(Usuario objUsuario) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objUsuario.Id; //Posiona la selección de la fila en el registro guardado
            escribirControles(objUsuario); //Escribe los datos del registro seleccionado
            objUsuarioDB = objUsuario; //Importante: Se debe actualizar el Objeto precedente con el actual (evita el error de nulidad) 
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR CUIT")
            {
                cmbFiltroLista1.Enabled = false;
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
            {
                cmbFiltroLista1.Enabled = true;
            }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroEstado = "TODOS";
            if (cmbFiltroLista1.Text == "FILTRAR POR LEGAJOS C/BAJA") filtroEstado = "C/BAJA";
            else if (cmbFiltroLista1.Text == "FILTRAR POR LEGAJOS S/BAJA") filtroEstado = "S/BAJA";
            if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de CUIL/CUIT
            {
                consultaUsuario = new string[] { "TODOS", "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nUsuario.obtenerCatalago("TODOS", "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la denominacón
            {
                consultaUsuario = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nUsuario.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objUsuarioDB = nUsuario.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objUsuarioDB); //Escribe los datos del registro seleccionado
        }

        protected override void reportarRegistro(string programa)
        {
            if (_idUsuario > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "N° Legajo: ",
                    "Denominación: ",
                    "CUIL/CUIT: ",
                    "Tipo de usuario: ",
                    "Email de recuperación: " };
                string[] datoDB = {
                    objLegajo.Id.ToString().PadLeft(8, '0'),
                    objLegajo.Denominacion,
                    objLegajo.Cuit.ToString("00-00000000/0"),
                    objUsuario.TipoUsuario,
                    objUsuario.EmailRecuperacion };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Usuario", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Usuario", subTitulo, datoDB);
                Cursor.Current = Cursors.Default;
            }
            else Mensaje.Advertencia("Operación incorrecta.\nSeleccione un registro en la pantalla e intente nuevamente.");
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                lista = nUsuario.obtenerCatalago(consultaUsuario[0], consultaUsuario[1], consultaUsuario[2], "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Denominación",
                    "CUIL/CUIT",
                    "Tipo de usuario" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //ID
                    campo[1].Trim(), //Denominación
                    campo[2].Trim(), //CUIL/CUIT
                    campo[3].Trim() }; //Tipo de usuario
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Usuarios", subTitulos, new int[] { 8, 93, 13, 15 }, _listaDelReporte, new List<int> { }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Usuarios", subTitulos, new float[] { 7, 80, 11, 13 }, _listaDelReporte); //Ancho: 111
            }
        }

        public override void asignarVariablesDeFormulario(string[] variablesDeFormulario)
        {
            if (variablesDeFormulario[0] == "Catalogo_Legajo") //Catálogo de Legajos
            {
                this.objLegajo = new N_Legajo().obtenerObjeto("ID", variablesDeFormulario[1], true);
                txtDenominacion.Text = objLegajo.Denominacion;
                txtCuit.Text = Convert.ToString(objLegajo.Cuit);
            }
        }
        #endregion
    }
}
