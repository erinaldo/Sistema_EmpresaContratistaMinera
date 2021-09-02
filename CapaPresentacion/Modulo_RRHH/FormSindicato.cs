using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormSindicato : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        string[] consultaSindicato;
        private Sindicato objSindicato; //Objeto del Módulo
        private Sindicato objSindicatoDB; //Objeto de la Base de Datos
        private N_Sindicato nSindicato = new N_Sindicato();
        #endregion

        public FormSindicato()
        {
            InitializeComponent();
        }

        #region Eventos: Formulario
        private void FormSindicato_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "TODOS LOS SINDICATOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR DENOMINACION", "FILTRAR POR ID" }, 0); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
        }

        private void txtAporteSolidarioFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtAporteSolidarioFijo.Text);
        }

        private void txtAporteSolidarioTasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtAporteSolidarioTasa.Text);
        }

        private void txtCuotaAfiliadoFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtCuotaAfiliadoFijo.Text);
        }

        private void txtCuotaAfiliadoTasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtCuotaAfiliadoTasa.Text);
        }

        private void txtSeguroSocialFijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtSeguroSocialFijo.Text);
        }

        private void txtSeguroSocialTasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtSeguroSocialTasa.Text);
        }

        private void txtFCLPrimerAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtFCLPrimerAnio.Text);
        }

        private void txtFCLMasDeUnAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtFCLMasDeUnAnio.Text);
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(136)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objSindicato != null)
            {
                if (objSindicato.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(136)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            objSindicato.Id = nSindicato.generarNumeroID(); //Paso 2: Genera un ID para cada Objeto
                            if (nSindicato.insertar(objSindicato)) //Paso 3: Inserta el objeto principal
                            {
                                mostrarRegistro(objSindicato);
                                Mensaje.RegistroCorrecto("REGISTRACION");
                            }
                        }
                    }
                }
                else if (objSindicato.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(137)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (ValidarCampoVacio())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            if (!objSindicato.Equals(objSindicatoDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                            {
                                if (nSindicato.actualizar(objSindicato))
                                {
                                    mostrarRegistro(objSindicato);
                                    Mensaje.RegistroCorrecto("MODIFICACION");
                                }
                            }
                        }
                    }
                }
                else Mensaje.Restriccion();
                bool ValidarCampoVacio() // Método que valida los campos requeridos
                {
                    return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion });
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objSindicato.Id > 0) escribirControles(objSindicatoDB); //Restaura los datos originales en base al registro seleccionado
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

        private void escribirControles(Sindicato objRegistro)
        {
            this.objSindicato = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            if (objSindicato != null)
            {
                _controladorDeNuevoRegistro = false;
                txtConvenio.Text = objSindicato.Convenio;
                txtDenominacion.Text = objSindicato.Denominacion;
                txtAporteSolidarioFijo.Text = Formulario.ValidarCampoMoneda(objSindicato.AporteSolidarioFijo);
                txtAporteSolidarioTasa.Text = Formulario.ValidarCampoMoneda(objSindicato.AporteSolidarioTasa);
                txtCuotaAfiliadoFijo.Text = Formulario.ValidarCampoMoneda(objSindicato.CuotaSindicalFijo);
                txtCuotaAfiliadoTasa.Text = Formulario.ValidarCampoMoneda(objSindicato.CuotaSindicalTasa);
                txtSeguroSocialFijo.Text = Formulario.ValidarCampoMoneda(objSindicato.SeguroSocialFijo);
                txtSeguroSocialTasa.Text = Formulario.ValidarCampoMoneda(objSindicato.SeguroSocialTasa);
                txtFCLPrimerAnio.Text = Formulario.ValidarCampoMoneda(objSindicato.FCL_PrimerAnioTasa);
                txtFCLMasDeUnAnio.Text = Formulario.ValidarCampoMoneda(objSindicato.FCL_MasDeUnAnioTasa);
                chkIncluyeTotalNR.Checked = objSindicato.IncluyeTotalNR;
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objSindicato.EdicionFecha) + " por " + objSindicato.EdicionUsuarioDenominacion;
            }
            else restaurarControles();
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objSindicato = new Sindicato(
                (objSindicato.Id <= 0) ? 0 : objSindicato.Id,
                txtConvenio.Text,
                txtDenominacion.Text,
                Formulario.ValidarNumeroDoble(txtAporteSolidarioFijo.Text),
                Formulario.ValidarNumeroDoble(txtAporteSolidarioTasa.Text),
                Formulario.ValidarNumeroDoble(txtCuotaAfiliadoFijo.Text),
                Formulario.ValidarNumeroDoble(txtCuotaAfiliadoTasa.Text),
                Formulario.ValidarNumeroDoble(txtSeguroSocialFijo.Text),
                Formulario.ValidarNumeroDoble(txtSeguroSocialTasa.Text),
                Formulario.ValidarNumeroDoble(txtFCLPrimerAnio.Text),
                Formulario.ValidarNumeroDoble(txtFCLMasDeUnAnio.Text),
                Convert.ToBoolean(chkIncluyeTotalNR.Checked),
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objSindicato = new Sindicato(); //Importante: Restaura el Objeto del Móludo
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            txtConvenio.Text = "";
            txtDenominacion.Text = "";
            txtAporteSolidarioFijo.Text = "0,00";
            txtAporteSolidarioTasa.Text = "0,00";
            txtCuotaAfiliadoFijo.Text = "0,00";
            txtCuotaAfiliadoTasa.Text = "0,00";
            txtSeguroSocialFijo.Text = "0,00";
            txtSeguroSocialTasa.Text = "0,00";
            txtFCLPrimerAnio.Text = "0,00";
            txtFCLMasDeUnAnio.Text = "0,00";
            chkIncluyeTotalNR.Checked = false;
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(Sindicato objRegistro) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objSindicatoDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            escribirControles(objSindicatoDB); //Escribe los datos del registro seleccionado
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION") { }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR ID") { }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la descripcion
            {
                consultaSindicato = new string[] { "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nSindicato.obtenerCatalago("DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de ID
            {
                consultaSindicato = new string[] { "ID", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nSindicato.obtenerCatalago("ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objSindicatoDB = nSindicato.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objSindicatoDB); //Escribe los datos del registro seleccionado
        }

        protected override void reportarRegistro(string programa)
        {
            if (objSindicato.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "ID: ",
                    "Convenio: ",
                    "Denominación: ",
                    "Aporte solidario (fijo): ",
                    "Aporte solidario (tasa): ",
                    "Cuota de afiliación (fijo): ",
                    "Cuota de afiliación (tasa): ",
                    "Seguro social (fijo): ",
                    "Seguro social (tasa): ",
                    "FCL (<1°año): ",
                    "FCL (>1°año): " };
                string[] datoDB = {
                    Convert.ToString(objSindicato.Id).PadLeft(8, '0'),
                    objSindicato.Convenio,
                    objSindicato.Denominacion,
                    "$" + Formulario.ValidarCampoMoneda(objSindicato.AporteSolidarioFijo),
                    "%" + Formulario.ValidarCampoMoneda(objSindicato.AporteSolidarioTasa),
                    "$" + Formulario.ValidarCampoMoneda(objSindicato.CuotaSindicalFijo),
                    "%" + Formulario.ValidarCampoMoneda(objSindicato.CuotaSindicalTasa),
                    "$" + Formulario.ValidarCampoMoneda(objSindicato.SeguroSocialFijo),
                    "%" + Formulario.ValidarCampoMoneda(objSindicato.SeguroSocialTasa),
                    "%" + Formulario.ValidarCampoMoneda(objSindicato.FCL_PrimerAnioTasa),
                    "%" + Formulario.ValidarCampoMoneda(objSindicato.FCL_MasDeUnAnioTasa) + 
                    ((objSindicato.IncluyeTotalNR) ? "\nLa deducción sindical incluye sumas No Remunerativas." : "") };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Sindicato", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Sindicato", subTitulo, datoDB);
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
                lista = nSindicato.obtenerCatalago(consultaSindicato[0], consultaSindicato[1], "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Convenio",
                    "Denominación",
                    "Aporte Solidario",
                    "Cuota de Afiliación",
                    "Seguro Social",
                    "FCL (<1°año y >1°año)" };
            foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //ID
                    campo[1].Trim(), //Convenio
                    campo[2].Trim(), //Denominación
                    campo[3].Trim(), //Aporte Solidario
                    campo[4].Trim(), //Cuota de Afiliación
                    campo[5].Trim(), //Seguro Social
                    campo[6].Trim() }; //FCL (<1°año - >1°año)
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Sindicatos", subTitulos, new int[] { 8, 8, 40, 18, 18, 18, 18 }, _listaDelReporte, new List<int> { }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Sindicatos", subTitulos, new float[] { 7, 7, 33, 16, 16, 16, 16 }, _listaDelReporte); //Ancho: 111
            }
        }
        #endregion
    }
}