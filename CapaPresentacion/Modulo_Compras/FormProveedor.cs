using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using CapaNegocio.Catalogo;
using CapaPresentacion.Catalogo;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormProveedor : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private double _saldo = 0.00;
        string[] consultaProveedor;
        private Proveedor objProveedor;
        private Proveedor objProveedorDB;
        private N_Proveedor nProveedor = new N_Proveedor();
        #endregion

        #region Constructores
        public FormProveedor()
        {
            InitializeComponent();
        }
        public FormProveedor(Proveedor navProveedor) //Utilizado por el navegador de formularios
        {
            objProveedorDB = objProveedor = navProveedor;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormProveedor_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbCtaBancaria, new N_Banco().obtenerListaDeElementos(), "S/D"); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(
                new string[] { "ACTIVO CORRIENTE > BIENES DE USO", "ACTIVO CORRIENTE > BIENES DE CAMBIO", "EGRESOS > OTROS EGRESOS" }), 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO", "FILTRAR POR ESTADO: BAJA", "TODOS LOS ESTADOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT", "FILTRAR POR DENOMINACION",
                "FILTRAR POR ID", "FILTRAR POR N. FANTASIA" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
            if (objProveedor != null) escribirControles(objProveedor);
        }

        private void txtDenominacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '-' && e.KeyChar != '.') Formulario.ValidarCampoAlfaNumerico(e, true);
        }

        private void txtNombreFantasia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '-' && e.KeyChar != '.') Formulario.ValidarCampoAlfaNumerico(e, true);
        }

        private void txtDomicilio_Validated(object sender, EventArgs e)
        {
            txtDomicilio.Text = Formulario.ValidarCampoTipoSubTitulo(txtDomicilio.Text);
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Formulario.GenerarDistritos(cmbProvincia.Text, cmbDistrito);
            txtCodigoPostal.Text = "";
        }

        private void cmbDistrito_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoAlfaNumerico(e, true);
        }

        private void cmbDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigoPostal.Text = Formulario.GenerarCodigoPostal(cmbDistrito.Text);
        }

        private void cmbCtaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCtaBancaria.Text == "S/D")
            {
                cmbCtaBancariaTipo.Text = "S/D";
                txtCtaBancariaNro.Text = "";
            }
        }

        private void btnCtaBancaria_Click(object sender, EventArgs e)
        {
            FormCatalogo_Banco frm = new FormCatalogo_Banco(this);
            frm.ShowDialog(this);
        }

        private void txtContactoDenominacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoAlfabetico(e, true);
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(31)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objProveedor != null)
            {
                if (objProveedor.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(31)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                    {
                        if (ValidarLongitudCuit())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                objProveedor.Id = nProveedor.generarNumeroID(); //Paso 2: Genera un ID para cada Objeto
                                if (nProveedor.insertar(objProveedor)) //Paso 3: Inserta el objeto
                                {
                                    mostrarRegistro(objProveedor);
                                    Mensaje.RegistroCorrecto("REGISTRACION");
                                }
                            }
                        }
                        else Mensaje.Informacion("Operación Incorrecta. La longitud del CUIT es inválida.");
                    }
                }
                else if (objProveedor.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(32)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (ValidarCampoVacio())
                    {
                        if (ValidarLongitudCuit())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                if (!objProveedor.Equals(objProveedorDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                                {
                                    if (nProveedor.actualizar(objProveedor))
                                    {
                                        mostrarRegistro(objProveedor);
                                        Mensaje.RegistroCorrecto("MODIFICACION");
                                    }
                                }
                            }
                        }
                        else Mensaje.Informacion("Operación Incorrecta. La longitud del CUIT es inválida.");
                    }
                }
                else Mensaje.Restriccion();
                bool ValidarLongitudCuit() // Método que valida la longitud del CUIT
                {
                    if (txtCuit.Text.Length == 11) return true;
                    return false;
                }
                bool ValidarCampoVacio() // Método que valida los campos requeridos
                {
                    return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion , txtCuit, cmbCategoriaIva, txtDomicilio,
                    cmbProvincia, cmbDistrito, txtCodigoPostal, cmbEstado }) && Formulario.ValidarCampoEmail(txtEmail.Text)
                        && Formulario.ValidarCampoEmail(txtContactoEmail.Text);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objProveedor.Id > 0) escribirControles(nProveedor.obtenerObjeto("TODOS", "ID", objProveedor.Id.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
            else restaurarControles();
        }
        #endregion

        #region Métodos
        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(Proveedor objRegistro)
        {
            this.objProveedor = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            if (objProveedor != null)
            {
                _controladorDeNuevoRegistro = false;
                objProveedor.Id = (objProveedor != null) ? objProveedor.Id : 0;
                txtDenominacion.Text = objProveedor.Denominacion;
                txtNombreFantasia.Text = objProveedor.NombreFantasia;
                txtCuit.Text = objProveedor.Cuit;
                cmbCategoriaIva.Text = Convert.ToString(objProveedor.Iva);
                txtDomicilio.Text = objProveedor.Domicilio;
                cmbProvincia.Text = objProveedor.Provincia;
                cmbDistrito.Text = objProveedor.Distrito;
                txtCodigoPostal.Text = objProveedor.Cp;
                txtTelefono.Text = objProveedor.Telefono;
                txtCelular.Text = objProveedor.Celular;
                txtEmail.Text = objProveedor.Email;
                txtPaginaWeb.Text = objProveedor.PaginaWeb;
                cmbCtaBancaria.Text = (objProveedor.Banco != null) ? objProveedor.Banco.Denominacion : "S/D";
                cmbCtaBancariaTipo.Text = (objProveedor.Banco != null) ? objProveedor.CtaBancariaTipo : "S/D";
                txtCtaBancariaNro.Text = (objProveedor.Banco != null) ? objProveedor.CtaBancariaNro : "";
                cmbCuentaContable.Text = objProveedor.CuentaContable.Denominacion;
                _saldo = (objProveedor != null) ? objProveedor.Saldo : 0.00;
                txtSaldo.Text = Formulario.ValidarCampoMoneda(_saldo);
                txtContactoDenominacion.Text = objProveedor.ContactoDenominacion;
                txtContactoTelefono.Text = objProveedor.ContactoTelefono;
                txtContactoCelular.Text = objProveedor.ContactoCelular;
                txtContactoEmail.Text = objProveedor.ContactoEmail;
                cmbEstado.Text = objProveedor.Estado;
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objProveedor.EdicionFecha) + " por " + objProveedor.EdicionUsuarioDenominacion;
            }
            else restaurarControles();
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objProveedor = new Proveedor(
                (objProveedor.Id <= 0) ? 0 : objProveedor.Id,
                txtDenominacion.Text.Trim(),
                txtNombreFantasia.Text.Trim(),
                txtCuit.Text,
                ((string.IsNullOrEmpty(cmbCategoriaIva.Text)) ? "CONSUMIDOR FINAL" : cmbCategoriaIva.Text), //Importante: Los ENUM en la BD nececitan recibir un dato conocido
                txtDomicilio.Text,
                cmbProvincia.Text.ToUpper(),
                cmbDistrito.Text.ToUpper(),
                txtCodigoPostal.Text,
                txtTelefono.Text,
                txtCelular.Text,
                txtEmail.Text.ToLower(),
                txtPaginaWeb.Text.ToLower(),
                ((cmbCtaBancaria.Text == "S/D") ? new Banco(0, "") : new N_Banco().obtenerObjeto("DENOMINACION", cmbCtaBancaria.Text, false)),
                cmbCtaBancariaTipo.Text,
                txtCtaBancariaNro.Text,
                new N_CuentaContable().obtenerObjeto("DENOMINACION", cmbCuentaContable.Text),
                _saldo,
                txtContactoDenominacion.Text,
                txtContactoTelefono.Text,
                txtContactoCelular.Text,
                txtContactoEmail.Text,
                ((string.IsNullOrEmpty(cmbEstado.Text)) ? "ACTIVO" : cmbEstado.Text), //Importante: Los ENUM en la BD nececitan recibir un dato conocido
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objProveedor = new Proveedor(); //Restaura el Objeto Primario
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(cmbCtaBancaria, new N_Banco().obtenerListaDeElementos(), "S/D"); //Re-Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(
                new string[] { "ACTIVO CORRIENTE > BIENES DE USO", "ACTIVO CORRIENTE > BIENES DE CAMBIO", "EGRESOS > OTROS EGRESOS" }), 0); //Establece los items del ComboBox
            txtDenominacion.Text = "";
            txtNombreFantasia.Text = "";
            txtCuit.Text = "";
            cmbCategoriaIva.Text = "RESPONSABLE INSCRIPTO";
            txtDomicilio.Text = "";
            cmbProvincia.Text = "SAN JUAN";
            Formulario.GenerarDistritos(cmbProvincia.Text, cmbDistrito);
            txtCodigoPostal.Text = "5400";
            txtTelefono.Text = "0264";
            txtCelular.Text = "";
            txtEmail.Text = "";
            txtPaginaWeb.Text = "";
            cmbCtaBancaria.Text = "S/D";
            cmbCtaBancariaTipo.Text = "S/D";
            txtCtaBancariaNro.Text = "";
            cmbCuentaContable.Text = "PROVEEDORES";
            _saldo = 0.00;
            txtSaldo.Text = "0,00";
            txtContactoDenominacion.Text = "";
            txtContactoTelefono.Text = "";
            txtContactoCelular.Text = "";
            txtContactoEmail.Text = "";
            cmbEstado.Text = "ACTIVO";
            labelPublicacion.Text = "";        
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion , txtCuit, cmbCategoriaIva, txtDomicilio,
                cmbProvincia, cmbDistrito, txtCodigoPostal, cmbEstado }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(Proveedor objProveedor) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objProveedor.Id; //Posiona la selección de la fila en el registro guardado
            escribirControles(objProveedor); //Escribe los datos del registro seleccionado
            objProveedorDB = objProveedor; //Importante: Se debe actualizar el Objeto precedente con el actual (evita el error de nulidad) 
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
            {
                cmbFiltroLista1.Enabled = true;
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR CUIT")
            {
                cmbFiltroLista1.Enabled = false;
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR ID")
            {
                cmbFiltroLista1.Enabled = false;
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR N. FANTASIA")
            {
                cmbFiltroLista1.Enabled = true;
            }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroEstado = "TODOS";
            if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ACTIVO") filtroEstado = "ACTIVO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: BAJA") filtroEstado = "BAJA";
            if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la descripcion
            {
                consultaProveedor = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nProveedor.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO2", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de CUIT
            {
                consultaProveedor = new string[] { filtroEstado, "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nProveedor.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO2", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de ID
            {
                consultaProveedor = new string[] { filtroEstado, "ID", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nProveedor.obtenerCatalago(filtroEstado, "ID", txtFiltroLista.Text.Trim(), "CATALOGO2", indicePagina, Global.PaginacionTamanio));
            }
            if (cmbFiltroLista2.Text == "FILTRAR POR N. FANTASIA") //Verifica que el tipo de filtro es por concidencia letra en la descripcion del nombre de fantasía
            {
                consultaProveedor = new string[] { filtroEstado, "FANTASIA", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nProveedor.obtenerCatalago(filtroEstado, "FANTASIA", txtFiltroLista.Text.Trim(), "CATALOGO2", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objProveedorDB = nProveedor.obtenerObjeto("TODOS", "ID", idElemento.ToString(), true);
            escribirControles(objProveedorDB); //Escribe los datos del registro seleccionado
        }

        protected override void reportarRegistro(string programa)
        {
            if (objProveedor != null && objProveedor.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "ID Proveedor: ",
                    "Razón social: ",
                    "Nombre de fantasía: ",
                    "CUIT: ",
                    "Categoría frente al IVA: ",
                    "Domicilio: ",
                    "Provincia: ",
                    "Distrito: ",
                    "Código postal: ",
                    "Teléfono: ",
                    "Celular: ",
                    "E-mail: ",
                    "Página WEB: ",
                    "Cuenta bancaria: ",
                    "Cuenta contable: ",
                    "Saldo a la fecha (" + Fecha.SistemaFechaHora() + "): ",
                    "Datos del contacto: ",
                    "Estado: " };
                string[] datoDB = {
                    objProveedor.Id.ToString().PadLeft(8, '0'),
                    objProveedor.Denominacion,
                    objProveedor.NombreFantasia,
                    objProveedor.Cuit,
                    objProveedor.Iva,
                    objProveedor.Domicilio,
                    objProveedor.Provincia,
                    objProveedor.Distrito,
                    objProveedor.Cp,
                    objProveedor.Telefono,
                    objProveedor.Celular,
                    objProveedor.Email,
                    objProveedor.PaginaWeb,
                    ((objProveedor.Banco != null) ? (objProveedor.Banco.Denominacion + "\n" + objProveedor.CtaBancariaTipo + " N°: " + objProveedor.CtaBancariaNro) : ""),
                    objProveedor.CuentaContable.Denominacion,
                    "$" + Formulario.ValidarCampoMoneda(objProveedor.Saldo),
                    ((!string.IsNullOrEmpty(objProveedor.ContactoDenominacion)) ? objProveedor.ContactoDenominacion : "") +
                    ((!string.IsNullOrEmpty(objProveedor.ContactoTelefono)) ? "\n" + objProveedor.ContactoTelefono : "") +
                    ((!string.IsNullOrEmpty(objProveedor.ContactoCelular)) ? "\n" + objProveedor.ContactoCelular : "") +
                    ((!string.IsNullOrEmpty(objProveedor.ContactoEmail)) ? "\n" + objProveedor.ContactoEmail : ""),
                    objProveedor.Estado };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Proveedor", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Proveedor", subTitulo, datoDB);
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
                lista = nProveedor.obtenerCatalago(consultaProveedor[0], consultaProveedor[1], consultaProveedor[2], "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Razón Social",
                    "Nombre de Fantasía",
                    "CUIT",
                    "Cuenta Contable",
                    "Saldo $",
                    "Estado" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //ID
                    campo[1].Trim(), //Razón social
                    campo[2].Trim(), //Nombre de fantasía
                    campo[3].Trim(), //CUIT
                    campo[4].Trim(), //Cuenta Contable
                    "$"+campo[5].Trim(), //Saldo
                    campo[6].Trim() //Estado
                };
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Proveedores", subTitulos, new int[] { 10, 45, 20, 11, 25, 12, 11 }, _listaDelReporte, new List<int> { }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Proveedores", subTitulos, new float[] { 8, 38, 18, 9, 19, 10, 9 }, _listaDelReporte); //Ancho: 111
            }
        }

        public override void asignarVariablesDeFormulario(string[] variablesDeFormulario) //Método Sobrescribible
        {
            if (variablesDeFormulario[0] == "Catalogo_Banco") //Catálogo de Bancos
            {
                Formulario.ComboBox_CargarElementos(cmbCtaBancaria, new N_Banco().obtenerListaDeElementos(), "S/D"); //Establece los items del ComboBox
                cmbCtaBancaria.Text = variablesDeFormulario[2];
            }
        }
        #endregion
    }
}
