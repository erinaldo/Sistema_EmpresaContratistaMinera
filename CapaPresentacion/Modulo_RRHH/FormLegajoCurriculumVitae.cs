using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using CapaPresentacion.Catalogo;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormLegajoCurriculumVitae : Biblioteca.Formularios.FormBaseABM_RRHH
    {
        #region Atributos
        private string[] consultaLegajoCurriculumVitae;
        private Legajo objLegajo; //Objeto Maestro
        private LegajoCurriculumVitae objLegajoCurriculumVitae;
        private LegajoCurriculumVitae objLegajoCurriculumVitaeDB;
        private N_Legajo nLegajo = new N_Legajo();
        private N_LegajoCurriculumVitae nLegajoCurriculumVitae = new N_LegajoCurriculumVitae();
        private N_Relacion_LegajoCurriculumVitae_PerfilLaboral nRelacion_LegajoCurriculumVitae_PerfilLaboral = new N_Relacion_LegajoCurriculumVitae_PerfilLaboral();
        #endregion

        #region Constructores
        public FormLegajoCurriculumVitae()
        {
            InitializeComponent();
        }
        public FormLegajoCurriculumVitae(Legajo navLegajo) //Utilizado por el navegador de formularios
        {
            objLegajo = navLegajo;
            InitializeComponent();
        }
        public FormLegajoCurriculumVitae(LegajoCurriculumVitae navLegajoCurriculumVitae) //Utilizado por el navegador de formularios
        {
            objLegajoCurriculumVitaeDB = objLegajoCurriculumVitae = navLegajoCurriculumVitae;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormLegajoCurriculumVitae_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR LEGAJOS C/BAJA",
                "FILTRAR POR LEGAJOS S/BAJA", "TODOS LOS LEGAJOS" }, 1); //Establece los items del ComboBox  
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT", "FILTRAR POR DENOMINACION" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
            if (objLegajo != null) instanciarDesdeNavegacion(objLegajo);
            if (objLegajoCurriculumVitae != null) escribirControles(objLegajoCurriculumVitae); //Escribe los datos solicitados mediante la navegación entre formularios
        }

        private void btnBuscarLegajo_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                FormCatalogo_Legajo frm = new FormCatalogo_Legajo(this);
                frm.ShowDialog(this);
            }
        }

        private void btnPerfilLaboral_Click(object sender, EventArgs e)
        {
            if (objLegajo != null)
            {
                FormCatalogo_PerfilLaboral formCatalogo_PerfilLaboral = new FormCatalogo_PerfilLaboral(this, objLegajo.Id);
                formCatalogo_PerfilLaboral.ShowDialog(this);
            }
        }

        private void chkLicenciaConducir_CheckedChanged(object sender, EventArgs e)
        {
            Formulario.Visibilidad(chkLicenciaConducir.Checked, new Control[] { lblLicenciaConducir1,
                txtLicenciaConducirCategoria, cmbLicenciaConducirColor, lblLicenciaConducir2, pkrLicenciaConducirVto });
            txtLicenciaConducirCategoria.Text = "";
            cmbLicenciaConducirColor.Text = "S/D";
        }

        private void chkCertificadoAntecentes_CheckedChanged(object sender, EventArgs e)
        {
            Formulario.Visibilidad(chkCertificadoAntecentes.Checked, new Control[] { lblCertificadoAntecentes1,
                cmbCertificadoAntecentesTipo, lblCertificadoAntecentes2, pkrCertificadoAntecentesEmision });
            cmbCertificadoAntecentesTipo.Text = "PROVINCIAL";
        }

        private void cmbCurriculumVitaeEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCurriculumVitaeEstado.Enabled = !_controladorDeNuevoRegistro; //Define el estado de actividad en relación al control de un nuevo registro
            if (objLegajoCurriculumVitaeDB != null && objLegajoCurriculumVitaeDB.CurriculumVitaeEstado == "OBSOLETO" && cmbCurriculumVitaeEstado.Text == "VIGENTE")
            {
                DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
                txtCurriculumVitaeVto.Text = Fecha.ConvertirFecha(fechaActual.AddMonths(Global.Vigencia_CurriculumVitae)); //Determina la fecha de vencimiento en relación a la fecha actual
            }
            else if (objLegajoCurriculumVitaeDB != null && objLegajoCurriculumVitaeDB.CurriculumVitaeEstado == "OBSOLETO" && cmbCurriculumVitaeEstado.Text == "OBSOLETO")
            {
                txtCurriculumVitaeVto.Text = Fecha.ConvertirFecha(objLegajoCurriculumVitaeDB.CurriculumVitaeVto); //Restaura el valor precedente
            }
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(115))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
            #region Perfiles Laborales Temporales
            /* Importante: Crea un número negativo para representar el ID de la persona que se está creando.
             * Este número ID se utiliza para identificar los perfiles laborales que se han asignado a dicha 
             * persona. Posteriormente el id_persona de estos elementos serán reemplazado con el ID definitivo
             * o en su defecto, serán eliminados de la lista de Perfiles Laborales.*/
            nRelacion_LegajoCurriculumVitae_PerfilLaboral.eliminar_PerfilesTemporales(); //Paso 1: Elimina todos los elementos temporales
            objLegajo.Id = ((new N_Legajo().generarNumeroID() + 1) * -1) - (new Random().Next((71 * DateTime.Now.Minute), 4260)) * Global.UsuarioActivo_IdUsuario; //Paso 2: Asigna un numero negativo temporal para el ID del Objeto
            #endregion
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objLegajoCurriculumVitae != null)
            {
                if (objLegajoCurriculumVitae.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(115)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            this.objLegajo = nLegajo.obtenerObjeto("ID", objLegajoCurriculumVitae.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                            objLegajoCurriculumVitae.Id = nLegajoCurriculumVitae.generarNumeroID(); //Paso 3: Genera un ID para cada Objeto
                            if (nLegajoCurriculumVitae.insertar(objLegajoCurriculumVitae)) //Paso 5: Inserta el objeto principal
                            {
                                nRelacion_LegajoCurriculumVitae_PerfilLaboral.asociar_PerfilesTemporales(objLegajo.Id, objLegajo.Id); //Paso 7: Asocia los perfiles temporales a la persona
                                mostrarRegistro(objLegajoCurriculumVitae);
                                Mensaje.RegistroCorrecto("REGISTRACION");
                            }
                        }
                    }
                }
                else if (objLegajoCurriculumVitae.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(116)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (ValidarCampoVacio())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            this.objLegajo = nLegajo.obtenerObjeto("ID", objLegajoCurriculumVitae.Legajo.Id.ToString(), false); //Paso 3: Importante: Re-Almacena el Objeto de la Base de Datos
                            if (!objLegajoCurriculumVitae.Equals(objLegajoCurriculumVitaeDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                            {
                                if (nLegajoCurriculumVitae.actualizar(objLegajoCurriculumVitae))
                                {
                                    mostrarRegistro(objLegajoCurriculumVitae);
                                    Mensaje.RegistroCorrecto("MODIFICACION");
                                }
                            }
                        }
                    }
                }
                else Mensaje.Restriccion();
                bool ValidarCampoVacio() // Método que valida los campos requeridos
                {
                    return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion, txtCuit, txtPerfilLaboral });
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objLegajoCurriculumVitae.Id > 0) escribirControles(objLegajoCurriculumVitaeDB); //Restaura los datos originales en base al registro seleccionado
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

        private void escribirControles(LegajoCurriculumVitae objRegistro)
        {
            this.objLegajoCurriculumVitae = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            if (objLegajoCurriculumVitae != null && objLegajoCurriculumVitae.Legajo != null)
            {
                if (!objLegajoCurriculumVitae.Legajo.InformacionRestringida || (objLegajoCurriculumVitae.Legajo.InformacionRestringida && Global.UsuarioActivo_Privilegios.Contains(1))) //Verifica que el usuario posea el privilegio requerido
                {
                    _controladorDeNuevoRegistro = false;
                    objLegajo = objLegajoCurriculumVitae.Legajo;
                    txtDenominacion.Text = objLegajoCurriculumVitae.Legajo.Denominacion;
                    txtCuit.Text = Convert.ToString(objLegajoCurriculumVitae.Legajo.Cuit);
                    cmbModalidadAdmision.Text = objLegajoCurriculumVitae.ModalidadAdmision;
                    cmbNivelEstudio.Text = objLegajoCurriculumVitae.NivelEstudio;
                    txtExperienciaLaboral.Text = objLegajoCurriculumVitae.Experiencia;
                    chkTrabajoEmpreminsa.Checked = objLegajoCurriculumVitae.TrabajoEmpreminsa;
                    txtPerfilLaboral.Text = Formulario.ValidarCampoTipoSubTitulo(nRelacion_LegajoCurriculumVitae_PerfilLaboral.obtenerElementos(objLegajo.Id)); //Muestra los perfiles laborales que se han asignado
                    chkLicenciaConducir.Checked = objLegajoCurriculumVitae.LicenciaConducir;
                    txtLicenciaConducirCategoria.Text = (objLegajoCurriculumVitae.LicenciaConducir) ? objLegajoCurriculumVitae.LicenciaConducirCategoria : null;
                    cmbLicenciaConducirColor.Text = objLegajoCurriculumVitae.LicenciaConducirColor;
                    pkrLicenciaConducirVto.Value = objLegajoCurriculumVitae.LicenciaConducirVto;
                    chkCertificadoAntecentes.Checked = objLegajoCurriculumVitae.CertificadoAntecedente;
                    cmbCertificadoAntecentesTipo.Text = objLegajoCurriculumVitae.CertificadoAntecedenteTipo;
                    pkrCertificadoAntecentesEmision.Value = objLegajoCurriculumVitae.CertificadoAntecedenteEmision;
                    txtCurriculumVitaeDisponibilidad.Text = objLegajoCurriculumVitae.CurriculumVitaeDisponibilidad;
                    txtCurriculumVitaeCalificacion.Text = objLegajoCurriculumVitae.CurriculumVitaeCalificacion;
                    cmbCurriculumVitaeEstado.Text = objLegajoCurriculumVitae.CurriculumVitaeEstado;
                    txtCurriculumVitaeVto.Text = Fecha.ConvertirFecha(objLegajoCurriculumVitae.CurriculumVitaeVto);
                    labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objLegajoCurriculumVitae.EdicionFecha) + " por " + objLegajoCurriculumVitae.EdicionUsuarioDenominacion;
                }
                else restaurarControles();
            }
        }

        private void instanciarDesdeNavegacion(Legajo objLegajo)
        {
            objLegajoCurriculumVitaeDB = nLegajoCurriculumVitae.obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)); //Paso 1: Busca el registro en la Base de Datos en relación al objeto maestro recibido 
            if (objLegajoCurriculumVitaeDB != null)
            {
                lstCatalogo.SelectedValue = objLegajoCurriculumVitaeDB.Id; //Posiona la selección de la fila en el registro guardado
                escribirControles(objLegajoCurriculumVitaeDB); //Paso 2a: Escribe los datos del registro indicado
            }
            else
            {
                btnNuevo.PerformClick(); //Paso 2b: Ejecuta automáticamente el botón "Nuevo"
                this.objLegajo = objLegajo; //Iguala el Atributo de la clase con el Objeto recibido
                txtDenominacion.Text = objLegajo.Denominacion;
                txtCuit.Text = Convert.ToString(objLegajo.Cuit);
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objLegajoCurriculumVitae = new LegajoCurriculumVitae(
                (objLegajoCurriculumVitae.Id <= 0) ? 0 : objLegajoCurriculumVitae.Id,
                objLegajo,
                cmbModalidadAdmision.Text,
                cmbNivelEstudio.Text,
                txtExperienciaLaboral.Text,
                Convert.ToBoolean(chkTrabajoEmpreminsa.Checked),
                Convert.ToBoolean(chkLicenciaConducir.Checked),
                txtLicenciaConducirCategoria.Text,
                ((string.IsNullOrEmpty(cmbLicenciaConducirColor.Text)) ? "S/D" : cmbLicenciaConducirColor.Text), //Importante: Los ENUM en la BD nececitan recibir un dato conocido cuando el control esta oculto
                pkrLicenciaConducirVto.Value,
                ((pkrLicenciaConducirVto.Value.AddDays(Global.Alerta_LicenciaConducir) >= fechaActual.AddDays(Global.Alerta_LicenciaConducir)) ? false : true),
                Convert.ToBoolean(chkCertificadoAntecentes.Checked),
                cmbCertificadoAntecentesTipo.Text,
                pkrCertificadoAntecentesEmision.Value,
                ((pkrCertificadoAntecentesEmision.Value.AddMonths(Global.Vigencia_Antecedentes).AddDays(Global.Alerta_Antecedentes) < fechaActual.AddDays(Global.Alerta_Antecedentes)) ? true : false),
                txtCurriculumVitaeDisponibilidad.Text,
                txtCurriculumVitaeCalificacion.Text,
                cmbCurriculumVitaeEstado.Text,
                Fecha.ValidarFecha(txtCurriculumVitaeVto.Text),
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objLegajo = new Legajo(); //Restaura el Objeto Primario
            objLegajoCurriculumVitae = new LegajoCurriculumVitae(); //Importante: Restaura el Objeto del Móludo
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            cmbModalidadAdmision.Text = "BUSQUEDA ESPECIFICA";
            cmbNivelEstudio.Text = "SECUNDARIO COMPLETO";
            txtExperienciaLaboral.Text = "";
            chkTrabajoEmpreminsa.Checked = false;
            txtPerfilLaboral.Text = "";
            chkLicenciaConducir.Checked = false;
            txtLicenciaConducirCategoria.Text = "";
            cmbLicenciaConducirColor.Text = "S/D";
            pkrLicenciaConducirVto.Value = fechaActual;
            chkCertificadoAntecentes.Checked = false;
            cmbCertificadoAntecentesTipo.Text = "NACIONAL";
            pkrCertificadoAntecentesEmision.Value = fechaActual;
            txtCurriculumVitaeDisponibilidad.Text = "S/D";
            txtCurriculumVitaeCalificacion.Text = "S/CALIFICACION";
            cmbCurriculumVitaeEstado.Text = "VIGENTE";
            cmbCurriculumVitaeEstado.Enabled = false; //Importante: Desactiva la actividad del control
            txtCurriculumVitaeVto.Text = Fecha.ConvertirFecha(fechaActual.AddMonths(Global.Vigencia_CurriculumVitae));
            labelPublicacion.Text = "";          
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion , txtCuit, txtPerfilLaboral }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(LegajoCurriculumVitae objRegistro) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objLegajoCurriculumVitaeDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            escribirControles(objLegajoCurriculumVitaeDB); //Escribe los datos del registro seleccionado
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
                consultaLegajoCurriculumVitae = new string[] { "TODOS", "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nLegajoCurriculumVitae.obtenerCatalago("TODOS", "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la denominacón
            {
                consultaLegajoCurriculumVitae = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nLegajoCurriculumVitae.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objLegajoCurriculumVitaeDB = nLegajoCurriculumVitae.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objLegajoCurriculumVitaeDB); //Escribe los datos del registro seleccionado
        }

        protected override void navegarA_Formulario(string destino) { NavegacionRRHH.navegarA_Formulario(destino, this, objLegajo); }

        protected override void reportarRegistro(string programa)
        {
            if (objLegajoCurriculumVitae.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "N° Legajo: ",
                    "Denominación: ",
                    "CUIL/CUIT: ",
                    "Modalidad de admisión CV: ",
                    "Nivel de estudios: ",
                    "Experiencia laboral: ",
                    "Trabajó en Empreminsa: ",
                    "Perfiles laborales: ",
                    "Licencia de conducir: ",
                    "Certificado de antecedentes: ",
                    "Estado CV: ",
                    "Fecha de vto. CV: " };
                string[] datoDB = {
                    objLegajo.Id.ToString().PadLeft(8, '0'),
                    objLegajo.Denominacion,
                    objLegajo.Cuit.ToString("00-00000000/0"),
                    objLegajoCurriculumVitae.ModalidadAdmision,
                    objLegajoCurriculumVitae.NivelEstudio,
                    objLegajoCurriculumVitae.Experiencia,
                    ((objLegajoCurriculumVitae.TrabajoEmpreminsa) ? "Si" : "No"),
                    txtPerfilLaboral.Text,
                    ((objLegajoCurriculumVitae.LicenciaConducir) ? "Si." +
                        "\nCategoría: " + objLegajoCurriculumVitae.LicenciaConducirCategoria +
                        "\nColor: " + objLegajoCurriculumVitae.LicenciaConducirColor +
                        "\nFecha de vto.: " + Fecha.ConvertirFecha(objLegajoCurriculumVitae.LicenciaConducirVto) : "No"),
                    ((objLegajoCurriculumVitae.CertificadoAntecedente) ? "Si." +
                        "\nTipo: " + objLegajoCurriculumVitae.CertificadoAntecedenteTipo +
                        "\nFecha de emisión: " + Fecha.ConvertirFecha(objLegajoCurriculumVitae.CertificadoAntecedenteEmision) : "No"),
                    objLegajoCurriculumVitae.CurriculumVitaeEstado,
                    Fecha.ConvertirFecha(objLegajoCurriculumVitae.CurriculumVitaeVto) };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Legajo - Curriculum Vitae", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Legajo - Curriculum Vitae", subTitulo, datoDB);
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
                lista = nLegajoCurriculumVitae.obtenerCatalago(consultaLegajoCurriculumVitae[0], consultaLegajoCurriculumVitae[1], consultaLegajoCurriculumVitae[2], "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Denominación",
                    "CUIL/CUIT",
                    "Mod. de Admisión CV",
                    "Empreminsa",
                    "Disp.",
                    "Estado CV",
                    "Vto. CV" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //ID
                    campo[1].Trim(), //Denominación
                    campo[2].Trim(), //CUIL/CUIT
                    campo[3].Trim(), //Mod. de admisión CV
                    campo[4].Trim(), //Trabajó en Empreminsa
                    campo[5].Trim(), //Disponibilidad
                    campo[6].Trim(), //Estado CV
                    campo[7].Trim() }; //Vto. CV
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Legajos - Curriculum Vitae", subTitulos, new int[] { 8, 49, 13, 23, 11, 5, 10, 10 }, _listaDelReporte, new List<int> { 7 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Legajos - Curriculum Vitae", subTitulos, new float[] { 7, 41, 11, 20, 10, 4, 9, 9 }, _listaDelReporte); //Ancho: 111
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
            else if (variablesDeFormulario[0] == "Catalogo_PerfilLaboral") //Catálogo de Perfiles Laborales
            {
                txtPerfilLaboral.Text = Formulario.ValidarCampoTipoSubTitulo(nRelacion_LegajoCurriculumVitae_PerfilLaboral.obtenerElementos(objLegajo.Id)); //Muestra los perfiles laborales que se han asignado
            }
        }
        #endregion
    }
}
