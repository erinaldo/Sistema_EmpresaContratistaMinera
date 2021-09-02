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
    public partial class FormLegajo : Biblioteca.Formularios.FormBaseABM_RRHH
    {
        #region Atributos
        private double _saldo = 0.00;
        private string[] consultaLegajo;
        private Legajo objLegajo;
        private Legajo objLegajoDB;
        private N_Legajo nLegajo = new N_Legajo();
        #endregion

        #region Constructores
        public FormLegajo()
        {
            InitializeComponent();
        }
        public FormLegajo(Legajo navLegajo) //Utilizado por el navegador de formularios
        {
            objLegajoDB = objLegajo = navLegajo;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormLegajo_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbCtaBancaria, new N_Banco().obtenerListaDeElementos(), "S/D"); //Establece los items del ComboBox
            if (Global.UsuarioActivo_Privilegios.Contains(125)) chkBaja.Enabled = true; //Verifica que el usuario posea el privilegio requerido
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR LEGAJOS C/BAJA",
                "FILTRAR POR LEGAJOS S/BAJA", "TODOS LOS LEGAJOS" }, 1); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT", "FILTRAR POR DENOMINACION" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
            if (objLegajo != null) escribirControles(objLegajo);
        }

        private void txtDenominacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '.') Formulario.ValidarCampoAlfaNumerico(e, true);
        }

        private void cmbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbSexo.Text)) txtCuit.Text = Formulario.GenerarCuitCuil(cmbSexo.Text, txtDocumento.Text);
        }

        private void txtDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            //if (!string.IsNullOrEmpty(cmbSexo.Text)) txtCuit.Text = Formulario.GenerarCuitCuil(cmbSexo.Text, txtDocumento.Text);
        }

        private void pkrFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            txtEdad.Text = Fecha.CalcularEdad(pkrFechaNacimiento.Text);
        }

        private void cmbNacionalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoAlfabetico(e, true);
        }

        private void txtDomicilio_Validated(object sender, EventArgs e)
        {
            txtDomicilio.Text = Formulario.ValidarCampoTipoSubTitulo(txtDomicilio.Text);
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Formulario.GenerarDistritos(cmbProvincia.Text, cmbDistrito);
            txtCodigoPostal.Text = (cmbDistrito.Text == "CAPITAL") ? "5400" : "";
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
            if (Global.UsuarioActivo_Privilegios.Contains(124))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objLegajo != null)
            {
                if (objLegajo.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(124)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                    {
                        if (ValidarLongitudCuit())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                objLegajo.Id = nLegajo.generarNumeroID(); //Paso 2: Genera un ID para cada Objeto
                                if (nLegajo.insertar(objLegajo)) //Paso 3: Inserta el objeto
                                {
                                    mostrarRegistro(objLegajo);
                                    Mensaje.RegistroCorrecto("REGISTRACION");
                                }
                            }
                        }
                        else Mensaje.Informacion("Operación Incorrecta. La longitud del CUIT es inválida.");
                    }
                }
                else if (objLegajo.Id > 1 && Global.UsuarioActivo_Privilegios.Contains(126)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (ValidarCampoVacio())
                    {
                        if (ValidarLongitudCuit())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                if (!objLegajo.Equals(objLegajoDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                                {
                                    if (nLegajo.actualizar(objLegajo))
                                    {
                                        mostrarRegistro(objLegajo);
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
                    return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion , cmbSexo, txtDocumento,
                    txtCuit, cmbNacionalidad, cmbEstadoCivil, txtDomicilio, cmbProvincia, cmbDistrito, txtCodigoPostal
                    }) && Formulario.ValidarCampoEmail(txtEmail.Text);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objLegajo.Id > 0) escribirControles(objLegajoDB); //Re-Escribe los datos originales en base al registro seleccionado
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

        private void escribirControles(Legajo objRegistro)
        {
            this.objLegajo = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            if (objLegajo != null)
            {
                if (objLegajo != null && !objLegajo.InformacionRestringida || (objLegajo.InformacionRestringida && Global.UsuarioActivo_Privilegios.Contains(1))) //Verifica que el usuario posea el privilegio requerido
                {
                    _controladorDeNuevoRegistro = false;
                    objLegajo.Id = (objLegajo != null) ? objLegajo.Id : 0;
                    txtDenominacion.Text = objLegajo.Denominacion;
                    cmbSexo.Text = Convert.ToString(objLegajo.Sexo);
                    txtDocumento.Text = Convert.ToString(objLegajo.Documento);
                    txtCuit.Text = Convert.ToString(objLegajo.Cuit);
                    pkrFechaNacimiento.Value = (objLegajo.FechaNacimiento >= pkrFechaNacimiento.MinDate) ? objLegajo.FechaNacimiento : pkrFechaNacimiento.MinDate;
                    cmbTipoSangre.Text = objLegajo.TipoSangre;
                    cmbNacionalidad.Text = objLegajo.Nacionalidad;
                    cmbEstadoCivil.Text = objLegajo.EstadoCivil;
                    txtCantidadHijo.Text = Convert.ToString(objLegajo.CantidadHijo);
                    txtDomicilio.Text = objLegajo.Domicilio;
                    cmbProvincia.Text = objLegajo.Provincia;
                    cmbDistrito.Text = objLegajo.Distrito;
                    txtCodigoPostal.Text = Convert.ToString(objLegajo.Cp);
                    chkComunidad.Checked = objLegajo.Comunidad;
                    txtCelular1.Text = objLegajo.Celular1;
                    txtCelular2.Text = objLegajo.Celular2;
                    txtCelular3.Text = objLegajo.Celular3;
                    txtEmail.Text = objLegajo.Email;
                    cmbCtaBancaria.Text = (objLegajo.Banco != null) ? objLegajo.Banco.Denominacion : "S/D";
                    cmbCtaBancariaTipo.Text = (objLegajo.Banco != null) ? objLegajo.CtaBancariaTipo : "S/D";
                    txtCtaBancariaNro.Text = (objLegajo.Banco != null) ? objLegajo.CtaBancariaNro.Trim() : "";
                    txtObservacion.Text = objLegajo.Observacion;
                    _saldo = (objLegajo != null) ? objLegajo.Saldo : 0.00;
                    txtSaldo.Text = Formulario.ValidarCampoMoneda(_saldo);
                    chkBaja.Checked = objLegajo.Baja;
                    chkInformacionRestringida.Checked = objLegajo.InformacionRestringida;
                    labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objLegajo.EdicionFecha) + " por " + objLegajo.EdicionUsuarioDenominacion;
                }
                else Mensaje.Restriccion();
            }
            else restaurarControles();
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objLegajo = new Legajo(
                (objLegajo.Id <= 0) ? 0 : objLegajo.Id,
                txtDenominacion.Text.ToUpper(),
                cmbSexo.Text,
                Formulario.ValidarNumeroEntero64(txtDocumento.Text),
                Formulario.ValidarNumeroEntero64(txtCuit.Text),
                pkrFechaNacimiento.Value,
                cmbTipoSangre.Text,
                cmbNacionalidad.Text.ToUpper(),
                cmbEstadoCivil.Text,
                Formulario.ValidarNumeroEntero(txtCantidadHijo.Text),
                txtDomicilio.Text,
                cmbProvincia.Text.ToUpper(),
                cmbDistrito.Text.ToUpper(),
                Formulario.ValidarNumeroEntero(txtCodigoPostal.Text),
                Convert.ToBoolean(chkComunidad.Checked),
                txtCelular1.Text,
                txtCelular2.Text,
                txtCelular3.Text,
                txtEmail.Text.ToLower(),
                ((cmbCtaBancaria.Text == "S/D") ? new Banco(0, "") : new N_Banco().obtenerObjeto("DENOMINACION", cmbCtaBancaria.Text, false)),
                cmbCtaBancariaTipo.Text,
                txtCtaBancariaNro.Text,
                txtObservacion.Text,
                _saldo,
                Convert.ToBoolean(chkBaja.Checked),
                Convert.ToBoolean(chkInformacionRestringida.Checked),
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objLegajo = new Legajo(); //Restaura el Objeto Primario
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(cmbCtaBancaria, new N_Banco().obtenerListaDeElementos(), "S/D"); //Re-Establece los items del ComboBox
            txtDenominacion.Text = "";
            cmbSexo.Text = "MASCULINO";
            txtDocumento.Text = "";
            txtCuit.Text = "";
            pkrFechaNacimiento.Text = Fecha.FechaProgramada(-300);
            cmbTipoSangre.Text = "S/D";
            cmbNacionalidad.SelectedIndex = 0;
            cmbEstadoCivil.Text = "SOLTERO";
            txtCantidadHijo.Text = "0";
            txtDomicilio.Text = "";
            cmbProvincia.Text = "SAN JUAN";
            Formulario.GenerarDistritos(cmbProvincia.Text, cmbDistrito);
            txtCodigoPostal.Text = "5400";
            chkComunidad.Checked = false;
            txtCelular1.Text = "";
            txtCelular2.Text = "";
            txtCelular3.Text = "";
            txtEmail.Text = "";
            cmbCtaBancaria.Text = "S/D";
            cmbCtaBancariaTipo.Text = "S/D";
            txtCtaBancariaNro.Text = "";
            _saldo = 0.00;
            txtSaldo.Text = "0,00";
            chkBaja.Checked = false;
            chkInformacionRestringida.Checked = false;
            labelPublicacion.Text = "";
            //Restauración de campos invalidados
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion , cmbSexo, txtDocumento, txtCuit,
                cmbNacionalidad, txtDomicilio, cmbProvincia, cmbDistrito, txtCodigoPostal });
        }

        private void mostrarRegistro(Legajo objRegistro) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objLegajoDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            escribirControles(objLegajoDB); //Escribe los datos del registro seleccionado
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR CUIT")
            {
                cmbFiltroLista1.Enabled = false;
                cmbFiltroLista1.Text = "TODOS LOS LEGAJOS";
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
                consultaLegajo = new string[] {"TODOS", "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nLegajo.obtenerCatalago("TODOS", "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO2", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la denominacón
            {
                consultaLegajo = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nLegajo.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO2", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objLegajoDB = nLegajo.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objLegajoDB); //Escribe los datos del registro seleccionado
        }

        protected override void navegarA_Formulario(string destino) { NavegacionRRHH.navegarA_Formulario(destino, this, objLegajo); }

        protected override void reportarRegistro(string programa)
        {
            if (objLegajo.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "N° Legajo: ",
                    "Denominación: ",
                    "Documento: ",
                    "CUIL/CUIT: ",
                    "Fecha de nacimiento: ",
                    "Tipo de sangre: ",
                    "Nacionalidad: ",
                    "Estado civil: ",
                    "Hijo(s): ",
                    "Domicilio: ",
                    "Provincia: ",
                    "Distrito: ",
                    "Código postal: ",
                    "Celular(es): ",
                    "E-mail: ",
                    "Cuenta bancaria: ",
                    "Observación: ",
                    "Saldo: ",
                    "Baja del Legajo: " };
                string celular1 = objLegajo.Celular1.Trim();
                string celular2 = objLegajo.Celular2.Trim();
                string celular3 = objLegajo.Celular3.Trim();
                string[] datoDB = {
                    objLegajo.Id.ToString().PadLeft(8, '0'),
                    objLegajo.Denominacion,
                    objLegajo.Sexo + " - " + Convert.ToString(objLegajo.Documento),
                    objLegajo.Cuit.ToString("00-00000000/0"),
                    Fecha.ConvertirFecha(objLegajo.FechaNacimiento),
                    objLegajo.TipoSangre,
                    objLegajo.Nacionalidad,
                    objLegajo.EstadoCivil,
                    ((objLegajo.CantidadHijo > 0) ? "Si, " + Convert.ToString(objLegajo.CantidadHijo) : "No"),
                    objLegajo.Domicilio,
                    objLegajo.Provincia,
                    objLegajo.Distrito,
                    objLegajo.Cp + ((objLegajo.Comunidad) ? " Corresponde a la comunidad" : ""),
                    celular1 + ((celular1.Length > 0 && celular2.Length > 0) ? ", " : "") + celular2 + (((celular1.Length > 0 || celular2.Length > 0) && celular3.Length > 0) ? ", " : "") + celular3,
                    objLegajo.Email,
                    ((objLegajo.Banco != null) ? (objLegajo.Banco.Denominacion + "\n" + objLegajo.CtaBancariaTipo + " N°: " + objLegajo.CtaBancariaNro) : ""),
                    objLegajo.Observacion,
                    "$" + Formulario.ValidarCampoMoneda(objLegajo.Saldo),
                    ((objLegajo.Baja) ? "Si" : "No") };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Legajo - Personal", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Legajo - Personal", subTitulo, datoDB);
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
                lista = nLegajo.obtenerCatalago(consultaLegajo[0], consultaLegajo[1], consultaLegajo[2], "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Denominación",
                    "CUIL/CUIT",
                    "Fecha Nac.",
                    "Celular(es)" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //ID
                    campo[1].Trim(), //Denominación + Baja
                    campo[2].Trim(), //CUIL/CUIT
                    campo[3].Trim(), //F. Nacimiento
                    campo[4].Trim() //Celular(es)
                };
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Legajos - Personal", subTitulos, new int[] { 10, 53, 13, 10, 43 }, _listaDelReporte, new List<int> { 3 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Legajos - Personal", subTitulos, new float[] { 8, 43, 11, 9, 40 }, _listaDelReporte); //Ancho: 111
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
