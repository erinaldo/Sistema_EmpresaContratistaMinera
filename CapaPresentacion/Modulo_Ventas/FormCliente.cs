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
    public partial class FormCliente : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private double _saldo = 0.00;
        string[] consultaCliente;
        private Cliente objCliente;
        private Cliente objClienteDB;
        private N_Cliente nCliente = new N_Cliente();
        #endregion

        #region Constructores
        public FormCliente()
        {
            InitializeComponent();
        }
        public FormCliente(Cliente navCliente) //Utilizado por el navegador de formularios
        {
            objClienteDB = objCliente = navCliente;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormCliente_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbCtaBancaria, new N_Banco().obtenerListaDeElementos(), "S/D"); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(new string[] { "INGRESOS > INGRESO POR VENTAS" }), 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO", "FILTRAR POR ESTADO: BAJA", "TODOS LOS ESTADOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT", "FILTRAR POR DENOMINACION" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
            if (objCliente != null) escribirControles(objCliente);
        }

        private void txtDenominacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '.') Formulario.ValidarCampoAlfaNumerico(e, true);
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
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(170)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objCliente != null)
            {
                if (objCliente.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(170)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                    {
                        if (ValidarLongitudCuit())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                objCliente.Id = nCliente.generarNumeroID(); //Paso 2: Genera un ID para cada Objeto
                                if (nCliente.insertar(objCliente)) //Paso 3: Inserta el objeto
                                {
                                    mostrarRegistro(objCliente);
                                    Mensaje.RegistroCorrecto("REGISTRACION");
                                }
                            }
                        }
                        else Mensaje.Informacion("Operación Incorrecta. La longitud del CUIT es inválida.");
                    }
                }
                else if (objCliente.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(171)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (ValidarCampoVacio())
                    {
                        if (ValidarLongitudCuit())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                if (!objCliente.Equals(objClienteDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                                {
                                    if (nCliente.actualizar(objCliente))
                                    {
                                        mostrarRegistro(objCliente);
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
                    cmbProvincia, cmbDistrito, txtCodigoPostal, cmbEstado }) && Formulario.ValidarCampoEmail(txtEmail.Text);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objCliente.Id > 0) escribirControles(nCliente.obtenerObjeto("TODOS", "ID", objCliente.Id.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
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

        private void escribirControles(Cliente objRegistro)
        {
            this.objCliente = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            if (objCliente != null)
            {
                _controladorDeNuevoRegistro = false;
                objCliente.Id = (objCliente != null) ? objCliente.Id : 0;
                txtDenominacion.Text = objCliente.Denominacion;
                txtCuit.Text = objCliente.Cuit;
                cmbCategoriaIva.Text = Convert.ToString(objCliente.Iva);
                txtDomicilio.Text = objCliente.Domicilio;
                cmbProvincia.Text = objCliente.Provincia;
                cmbDistrito.Text = objCliente.Distrito;
                txtCodigoPostal.Text = objCliente.Cp;
                txtTelefono.Text = objCliente.Telefono;
                txtCelular.Text = objCliente.Celular;
                txtEmail.Text = objCliente.Email;
                txtPaginaWeb.Text = objCliente.PaginaWeb;
                cmbCtaBancaria.Text = (objCliente.Banco != null) ? objCliente.Banco.Denominacion : "S/D";
                cmbCtaBancariaTipo.Text = (objCliente.Banco != null) ? objCliente.CtaBancariaTipo : "S/D";
                txtCtaBancariaNro.Text = (objCliente.Banco != null) ? objCliente.CtaBancariaNro : "";
                cmbCuentaContable.Text = objCliente.CuentaContable.Denominacion;
                _saldo = (objCliente != null) ? objCliente.Saldo : 0.00;
                txtSaldo.Text = Formulario.ValidarCampoMoneda(_saldo);
                cmbEstado.Text = objCliente.Estado;
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objCliente.EdicionFecha) + " por " + objCliente.EdicionUsuarioDenominacion;
            }
            else restaurarControles();
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objCliente = new Cliente(
                (objCliente.Id <= 0) ? 0 : objCliente.Id,
                txtDenominacion.Text.ToUpper(),
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
                ((string.IsNullOrEmpty(cmbEstado.Text)) ? "ACTIVO" : cmbEstado.Text), //Importante: Los ENUM en la BD nececitan recibir un dato conocido
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objCliente = new Cliente(); //Restaura el Objeto Primario
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(cmbCtaBancaria, new N_Banco().obtenerListaDeElementos(), "S/D"); //Re-Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(new string[] { "INGRESOS > INGRESO POR VENTAS" }), 0); //Re-Establece los items del ComboBox
            txtDenominacion.Text = "";
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
            cmbCuentaContable.Text = "DEUDORES POR VENTA";
            _saldo = 0.00;
            txtSaldo.Text = "0,00";
            cmbEstado.Text = "ACTIVO";
            labelPublicacion.Text = "";           
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion , txtCuit, cmbCategoriaIva, txtDomicilio,
                cmbProvincia, cmbDistrito, txtCodigoPostal, cmbEstado }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(Cliente objRegistro) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objClienteDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            escribirControles(objClienteDB); //Escribe los datos del registro seleccionado
        }

        public override void asignarVariablesDeFormulario(string[] variablesDeFormulario) //Método Sobrescribible
        {
            if (variablesDeFormulario[0] == "Catalogo_Banco") //Catálogo de Bancos
            {
                Formulario.ComboBox_CargarElementos(cmbCtaBancaria, new N_Banco().obtenerListaDeElementos(), "S/D"); //Establece los items del ComboBox
                cmbCtaBancaria.Text = variablesDeFormulario[2];
            }
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
                consultaCliente = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCliente.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de documento
            {
                consultaCliente = new string[] { filtroEstado, "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCliente.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objClienteDB = nCliente.obtenerObjeto("TODOS", "ID", idElemento.ToString(), true);
            escribirControles(objClienteDB); //Escribe los datos del registro seleccionado
        }

        protected override void reportarRegistro(string programa)
        {
            if (objCliente.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "ID Cliente: ",
                    "Razón social: ",
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
                    "Estado: " };
                string[] datoDB = {
                    objCliente.Id.ToString().PadLeft(8, '0'),
                    objCliente.Denominacion,
                    objCliente.Cuit,
                    objCliente.Iva,
                    objCliente.Domicilio,
                    objCliente.Provincia,
                    objCliente.Distrito,
                    objCliente.Cp,
                    objCliente.Telefono,
                    objCliente.Celular,
                    objCliente.Email,
                    objCliente.PaginaWeb,
                    ((objCliente.Banco != null) ? (objCliente.Banco.Denominacion + "\n" + objCliente.CtaBancariaTipo + " N°: " + objCliente.CtaBancariaNro) : ""),
                    objCliente.CuentaContable.Denominacion,
                    "$" + Formulario.ValidarCampoMoneda(objCliente.Saldo),
                    objCliente.Estado };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Cliente", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Cliente", subTitulo, datoDB);
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
                lista = nCliente.obtenerCatalago(consultaCliente[0], consultaCliente[1], consultaCliente[2], "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Denominación",
                    "CUIT",
                    "Saldo $",
                    "Estado" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //ID
                    campo[1].Trim(), //Denominación
                    campo[2].Trim(), //CUIT
                    "$"+campo[3].Trim(), //Saldo $
                    campo[4].Trim() //Estado
                };
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Clientes", subTitulos, new int[] { 8, 87, 11, 12, 11 }, _listaDelReporte, new List<int> { }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Clientes", subTitulos, new float[] { 7, 76, 9, 10, 9 }, _listaDelReporte); //Ancho: 111
            }
        }
        #endregion
    }
}
