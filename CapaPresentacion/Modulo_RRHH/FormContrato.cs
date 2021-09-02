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
    public partial class FormContrato : Biblioteca.Formularios.FormBaseABM_RRHH
    {
        #region Atributos
        private bool _nuevoRegitroDesdeNavegacion = false;
        private string[] consultaContrato;
        private Legajo objLegajo; //Objeto Primario
        private Contrato objContrato; //Objeto del Módulo
        private Contrato objContratoDB; //Objeto de la Base de Datos
        private N_Legajo nLegajo = new N_Legajo();
        private N_LegajoLaboral nLegajoLaboral = new N_LegajoLaboral();
        private N_Contrato nContrato = new N_Contrato();
        #endregion

        #region Constructores
        public FormContrato()
        {
            InitializeComponent();
        }
        public FormContrato(Legajo navLegajo, bool nuevoRegitroDesdeNavegacion = false) //Utilizado por el navegador de formularios
        {
            objLegajo = navLegajo;
            _nuevoRegitroDesdeNavegacion = nuevoRegitroDesdeNavegacion;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormContrato_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { }), 0);
            Formulario.ComboBox_CargarElementos(cmbSindicato, new N_Sindicato().obtenerListaDeElementos(new string[] { }), 0);
            Formulario.ComboBox_CargarElementos(cmbCategoria, new N_CategoriaTrabajo().obtenerListaDeElementos(), 0);
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ANULADO",
                "FILTRAR POR ESTADO: RESCINDIDO", "FILTRAR POR ESTADO: VIGENTE", "TODOS LOS ESTADOS" }, 2); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT",
                "FILTRAR POR DENOMINACION", "FILTRAR POR FECHA DE ALTA", "FILTRAR POR FECHA DE BAJA" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
            if (objLegajo != null) instanciarDesdeNavegacion(objLegajo);
        }

        private void btnBuscarLegajo_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                FormCatalogo_Legajo frm = new FormCatalogo_Legajo(this);
                frm.ShowDialog(this);
            }
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            FormCatalogo_CategoriaTrabajo frm = new FormCatalogo_CategoriaTrabajo(this);
            frm.ShowDialog(this);
        }

        private void txtRemuneracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtRemuneracion.Text);
        }

        private void btnObraSocial_Click(object sender, EventArgs e)
        {
            FormCatalogo_ObraSocial frm = new FormCatalogo_ObraSocial(this);
            frm.ShowDialog(this);
        }

        private void chkRescisionContrato_CheckedChanged(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro) chkRescisionContrato.Checked = false;
            else
            {
                txtEstado.Text = (chkRescisionContrato.Checked) ? "RESCINDIDO" : "VIGENTE"; //Establece el estado del Contrato
                Formulario.Visibilidad(chkRescisionContrato.Checked, new Control[] { lblRescisionContrato1, pkrRescisionContrato, lblRescisionContrato2, txtRescisionObservaciones });
            }
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(96))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objContrato != null)
            {
                if (objContrato.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(96)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)) != null) //Verifica que la persona tenga un Legajo Laboral
                    {
                        if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                this.objLegajo = nLegajo.obtenerObjeto("ID", objContrato.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                                objContrato.Id = nContrato.generarNumeroID(); //Paso 3: Genera un ID para cada Objeto
                                objContrato.RescisionFecha = Fecha.ValidarFecha("01/01/9950"); //Asigna una fecha super alta para que No sea alcanzada por los motores de busqueda 
                                if (nContrato.insertar(objContrato)) //Paso 4: Inserta el objeto principal
                                {
                                    actualizarLegajoLaboral(objContrato); //Paso 5: Actualiza los datos del Legajo Laboral
                                    mostrarRegistro(objContrato);
                                    Mensaje.RegistroCorrecto("REGISTRACION");
                                }
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación incorrecta.\nLa persona No posee un legajo laboral.\nVerifique los datos e intente nuevamente.");
                }
                else if (objContrato.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(98)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (objContratoDB != null && objContratoDB.Estado == "VIGENTE") //Verifica que el contrato este Vigente
                    {
                        if (ValidarCampoVacio())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                this.objLegajo = nLegajo.obtenerObjeto("ID", objContrato.Legajo.Id.ToString(), false); //Paso 3: Importante: Re-Almacena el Objeto de la Base de Datos
                                objContrato.RescisionFecha = (objContrato.Rescision) ? objContrato.RescisionFecha : Fecha.ValidarFecha("01/01/9950"); //Verifica si el contrato No esta rescindido. En tal caso, asigna una fecha super alta para que No sea alcanzada por los motores de busqueda 
                                if (!objContrato.Equals(objContratoDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                                {
                                    if (nContrato.actualizar(objContrato))
                                    {
                                        actualizarLegajoLaboral(objContrato); //Paso 5: Actualiza los datos del Legajo Laboral
                                        mostrarRegistro(objContrato);
                                        Mensaje.RegistroCorrecto("MODIFICACION");
                                    }
                                }
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación incorrecta.\nLos registros anulados o rescindidos No pueden ser modificados.");
                }
                else Mensaje.Restriccion();
                bool ValidarCampoVacio() // Método que valida los campos requeridos
                {
                    return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion, txtCuit, cmbPuesto,
                    txtSector, txtObraSocial }) && Formulario.ValidarCampoVacioNumerico(false, new Control[] { txtRemuneracion });
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objContrato.Id > 0) escribirControles(objContratoDB); //Restaura los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(97)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objContrato.Id > 0)
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea anular el registro ID: " + objContrato.Id.ToString() + "?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        objLegajo = nLegajo.obtenerObjeto("ID", objContrato.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                        if (nContrato.anular(objContrato)) //Paso 3: Verifica el exito de la actualización y muestra los datos actualizados
                        {
                            objContrato.Estado = "ANULADO"; //Paso 4: Importante: Establece el cambio de estado en el Objeto del Módulo 
                            actualizarLegajoLaboral(objContrato); //Paso 5: En el Legajo Laboral cambia el estado a "INACTIVO" y establece el valor de la fecha de egreso con la actual
                            mostrarRegistro(objContrato);
                            Mensaje.RegistroCorrecto("ANULACION");
                        }
                    }
                }
            }
            else Mensaje.Restriccion();
        }

        private void btnWord_Contrato_Click(object sender, EventArgs e)
        {
            if (objContrato.Id > 0)
            {
                if (objContrato.Estado == "VIGENTE")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string[] datoDB = {
                        Global.Empresa_RazonSocial,
                        Global.Empresa_Domicilio,
                        objContrato.Legajo.Denominacion,
                        Formulario.ValidarCampoTipoSubTitulo(objContrato.Legajo.Domicilio + ", " +
                            objContrato.Legajo.Distrito + ", " + objContrato.Legajo.Provincia),
                        Formulario.ValidarCampoTipoSubTitulo(objContrato.Legajo.Nacionalidad),
                        Formulario.enmascararDNI(Convert.ToString(objContrato.Legajo.Documento)),
                        Formulario.ValidarCampoTipoSubTitulo(objContrato.ModalidadContratacion),
                        (objContrato.CentroCosto != null) ? Formulario.ValidarCampoTipoSubTitulo(objContrato.CentroCosto.Denominacion) : "",
                        (objContrato.CategoriaTrabajo != null) ? Formulario.ValidarCampoTipoSubTitulo(objContrato.CategoriaTrabajo.Denominacion) : "",
                        (objContrato.Sindicato != null) ? ((!string.IsNullOrEmpty(objContrato.Sindicato.Convenio)) ?
                            Formulario.ValidarCampoTipoSubTitulo(objContrato.Sindicato.Denominacion + " N° " +  objContrato.Sindicato.Convenio) : "FUERA DE CONVENIO") : "",
                        objContrato.ModalidadLiquidacion,
                        objContrato.Remuneracion.ToString(),
                        objContrato.Sindicato.Id.ToString() };
                    Reporte reporte = new Reporte();
                    reporte.crearDocumentoWord_Contrato(objContrato.Legajo.Denominacion, datoDB);
                    Cursor.Current = Cursors.Default;
                }
                else Mensaje.Advertencia("Operación incorrecta.\nSeleccione un contrato vigente e intente nuevamente.");
            }
            else Mensaje.Advertencia("Operación incorrecta.\nSeleccione un registro en la pantalla e intente nuevamente.");
        }
        #endregion

        #region Métodos
        private void actualizarLegajoLaboral(Contrato contrato)
        {
            LegajoLaboral objLegajoLaboral = nLegajoLaboral.obtenerObjeto("ID_LEGAJO", Convert.ToString(contrato.Legajo.Id));
            if (objLegajoLaboral != null)
            {
                objLegajoLaboral.CentroCosto = contrato.CentroCosto;
                objLegajoLaboral.FechaIngreso = contrato.FechaAlta;
                objLegajoLaboral.FechaEgreso = ((contrato.Estado == "VIGENTE") ? Fecha.ValidarFecha("01/01/9950") : ((contrato.Estado == "RESCINDIDO") ? contrato.RescisionFecha : Fecha.ValidarFecha("01/01/9950")));
                objLegajoLaboral.ModalidadContratacion = contrato.ModalidadContratacion;
                objLegajoLaboral.ModalidadContratacionTiempo = contrato.ModalidadContratacionTiempo;
                objLegajoLaboral.Sindicato = contrato.Sindicato;
                objLegajoLaboral.AfiliadoSindical = contrato.AfiliadoSindical;
                objLegajoLaboral.CategoriaTrabajo = contrato.CategoriaTrabajo;
                objLegajoLaboral.Puesto = contrato.Puesto;
                objLegajoLaboral.Sector = contrato.Sector;
                objLegajoLaboral.ModalidadLiquidacion = contrato.ModalidadLiquidacion;
                objLegajoLaboral.Remuneracion = contrato.Remuneracion;
                objLegajoLaboral.ObraSocial = contrato.ObraSocial;
                objLegajoLaboral.Estado = ((contrato.Estado == "VIGENTE") ? "ACTIVO" : "INACTIVO");
                nLegajoLaboral.actualizar(objLegajoLaboral); //Actualiza los valores del Legajo Laboral
            }
        }

        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(Contrato objRegistro)
        {
            this.objContrato = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            if (objContrato != null && objContrato.Legajo != null)
            {
                if (!objContrato.Legajo.InformacionRestringida || (objContrato.Legajo.InformacionRestringida && Global.UsuarioActivo_Privilegios.Contains(1))) //Verifica que el usuario posea el privilegio requerido
                {
                    _controladorDeNuevoRegistro = false;
                    DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
                    objLegajo = objContrato.Legajo;
                    txtDenominacion.Text = objContrato.Legajo.Denominacion;
                    txtCuit.Text = Convert.ToString(objContrato.Legajo.Cuit);
                    cmbCentroCosto.Text = (objContrato.CentroCosto != null) ? objContrato.CentroCosto.Denominacion : "";
                    pkrFechaAlta.Value = objContrato.FechaAlta;
                    cmbModalidadContratacion.Text = objContrato.ModalidadContratacion;
                    cmbModalidadContratacionTiempo.Text = objContrato.ModalidadContratacionTiempo;
                    cmbSindicato.Text = (objContrato.CategoriaTrabajo != null) ? objContrato.Sindicato.Denominacion : "";
                    chkAfiliadoSindical.Checked = objContrato.AfiliadoSindical;
                    cmbCategoria.Text = (objContrato.CategoriaTrabajo != null) ? objContrato.CategoriaTrabajo.Denominacion : "";
                    cmbPuesto.Text = objContrato.Puesto;
                    txtSector.Text = objContrato.Sector;
                    cmbModalidadLiquidacion.Text = objContrato.ModalidadLiquidacion;
                    txtRemuneracion.Text = Formulario.ValidarCampoMoneda(objContrato.Remuneracion);
                    txtObraSocial.Text = (objContrato.ObraSocial != null) ? objContrato.ObraSocial.Codigo + " " + objContrato.ObraSocial.Denominacion : "";
                    txtEstado.Text = objContrato.Estado;
                    txtRescisionObservaciones.Text = objContrato.RescisionObservacion;
                    chkRescisionContrato.Checked = objContrato.Rescision;
                    pkrRescisionContrato.Value = objContrato.RescisionFecha;
                    labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objContrato.EdicionFecha) + " por " + objContrato.EdicionUsuarioDenominacion;
                }
                else restaurarControles();
            }
        }

        private void instanciarDesdeNavegacion(Legajo objLegajo)
        {
            if (_nuevoRegitroDesdeNavegacion && !objLegajo.Baja) //Verifica la orden de "nuevo registro" y que el Legajo No este dado de baja
            {
                cmbFiltroLista1.Enabled = false; //Paso 1a: Desactiva el filtro de estados
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS"; //Paso 1b: Selecciona todos los estados 
                cmbFiltroLista2.Text = "FILTRAR POR CUIT"; //Paso 1c: Selecciona la busqueda por CUIT                 txtFiltroLista.Text = Convert.ToString(objLegajo.Cuit); //Paso 2: Establece el CUIT recibido
                filtrarCatalogo(0); //Paso 3: Carga el catálogo
                lstCatalogo.ClearSelected(); //Paso 4: Quita la selección de la fila
                btnNuevo.PerformClick(); //Paso 5: Ejecuta automáticamente el botón "Nuevo"
                this.objLegajo = objLegajo; //Paso 6: Iguala el Atributo de la clase con el Objeto recibido
                txtDenominacion.Text = objLegajo.Denominacion;
                txtCuit.Text = Convert.ToString(objLegajo.Cuit);
            }
            else
            {
                objContratoDB = nContrato.obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)); //Paso 1: Busca el registro en la Base de Datos en relación al objeto maestro recibido 
                if (objContratoDB != null)
                {
                    lstCatalogo.SelectedValue = objContratoDB.Id; //Paso 2: Posiona la selección de la fila en el registro guardado
                    escribirControles(objContratoDB); //Paso 3: Escribe los datos del registro indicado
                }
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objContrato = new Contrato(
                (objContrato.Id <= 0) ? 0 : objContrato.Id,
                objLegajo,
                new N_CentroCosto().obtenerObjeto("DENOMINACION", cmbCentroCosto.Text),
                pkrFechaAlta.Value,
                cmbModalidadContratacion.Text,
                cmbModalidadContratacionTiempo.Text,
                new N_Sindicato().obtenerObjeto("DENOMINACION", cmbSindicato.Text),
                Convert.ToBoolean(chkAfiliadoSindical.Checked),
                new N_CategoriaTrabajo().obtenerObjeto("DENOMINACION", cmbCategoria.Text),
                cmbPuesto.Text,
                txtSector.Text,
                cmbModalidadLiquidacion.Text,
                Formulario.ValidarNumeroDoble(txtRemuneracion.Text),
                new N_ObraSocial().obtenerObjeto("CODIGO", txtObraSocial.Text.Substring(0, 6)),
                txtEstado.Text,
                chkRescisionContrato.Checked,
                pkrRescisionContrato.Value,
                txtRescisionObservaciones.Text,
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objLegajo = new Legajo(); //Restaura el Objeto Primario
            objContrato = new Contrato(); //Importante: Restaura el Objeto del Móludo
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(cmbCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { }), 0); //Restauración de los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbSindicato, new N_Sindicato().obtenerListaDeElementos(new string[] { }), 0); //Restauración de los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbCategoria, new N_CategoriaTrabajo().obtenerListaDeElementos(), 0); //Restauración de los items del ComboBox
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            pkrFechaAlta.Value = fechaActual;
            cmbModalidadContratacion.Text = "TRABAJO EVENTUAL";
            cmbModalidadContratacionTiempo.Text = "TIEMPO COMPLETO";
            chkAfiliadoSindical.Checked = false;
            cmbPuesto.SelectedIndex = 0;
            txtSector.Text = "";
            cmbModalidadLiquidacion.Text = "DIARIO";
            txtRemuneracion.Text = "0,00";
            txtObraSocial.Text = "";
            txtEstado.Text = "VIGENTE";
            txtRescisionObservaciones.Text = "";
            chkRescisionContrato.Checked = false;
            pkrRescisionContrato.Value = Fecha.ValidarFecha("01/01/9950");
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, txtCuit, cmbPuesto, txtSector,
                txtObraSocial }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(Contrato objRegistro) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objContratoDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            escribirControles(objContratoDB); //Escribe los datos del registro seleccionado
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR CUIT")
            {
                cmbFiltroLista1.Enabled = false;
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });

            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
            {
                cmbFiltroLista1.Enabled = true;
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA DE ALTA")
            {
                cmbFiltroLista1.Enabled = true;
                Formulario.Visibilidad(false, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(true, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta }); //Verifica que se ha seleccionado el filtrado por fecha y habilita las casillas "desde y hasta"
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA DE BAJA")
            {
                cmbFiltroLista1.Enabled = true;
                Formulario.Visibilidad(false, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(true, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta }); //Verifica que se ha seleccionado el filtrado por fecha y habilita las casillas "desde y hasta"
            }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroEstado = "TODOS";
            if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ANULADO") filtroEstado = "ANULADO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: RESCINDIDO") filtroEstado = "RESCINDIDO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: VIGENTE") filtroEstado = "VIGENTE";
            if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de CUIL/CUIT
            {
                consultaContrato = new string[] { filtroEstado, "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nContrato.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la denominacón
            {
                consultaContrato = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nContrato.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA DE ALTA") //Verifica que el tipo de filtro es por el numero de documento
            {
                consultaContrato = new string[] { filtroEstado, "FECHA_ALTA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nContrato.obtenerCatalago(filtroEstado, "FECHA_ALTA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA DE BAJA") //Verifica que el tipo de filtro es por el numero de documento
            {
                consultaContrato = new string[] { filtroEstado, "FECHA_BAJA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nContrato.obtenerCatalago(filtroEstado, "FECHA_BAJA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objContratoDB = nContrato.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objContratoDB); //Escribe los datos del registro seleccionado
        }

        protected override void navegarA_Formulario(string destino) { NavegacionRRHH.navegarA_Formulario(destino, this, objLegajo); }

        protected override void reportarRegistro(string programa)
        {
            if (objContrato.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "N° Legajo: ",
                    "Denominación: ",
                    "CUIL/CUIT: ",
                    "Centro de costo: ",
                    "Fecha de alta: ",
                    "Modalidad de contratación: ",
                    "Sindicato: ",
                    "Convenio: ",
                    "Afiliado al sindicato: ",
                    "Categoría: ",
                    "Puesto: ",
                    "Sector: ",
                    "Modalidad de liquidación: ",
                    "Remuneración: ",
                    "Obra social: ",
                    "Estado: ",
                    "Fecha de recisión: ",
                    "Observaciones de recisión: " };
                string[] datoDB = {
                    objContrato.Legajo.Id.ToString().PadLeft(8, '0'),
                    objContrato.Legajo.Denominacion,
                    objContrato.Legajo.Cuit.ToString("00-00000000/0"),
                    objContrato.CentroCosto.Denominacion,
                    Fecha.ConvertirFecha(objContrato.FechaAlta),
                    objContrato.ModalidadContratacion + " (" + objContrato.ModalidadContratacionTiempo + ")",
                    objContrato.Sindicato.Denominacion,
                    objContrato.Sindicato.Convenio,
                    ((objContrato.AfiliadoSindical) ? "Si" : "No"),
                    objContrato.CategoriaTrabajo.Denominacion,
                    objContrato.Puesto,
                    objContrato.Sector,
                    objContrato.ModalidadLiquidacion,
                    "$" + Formulario.ValidarCampoMoneda(objContrato.Remuneracion),
                    objContrato.ObraSocial.Codigo + " " + objContrato.ObraSocial.Denominacion,
                    objContrato.Estado,
                    ((objContrato.Rescision) ? Fecha.ConvertirFecha(objContrato.RescisionFecha) : ""),
                    ((objContrato.Rescision) ? objContrato.RescisionObservacion : "") };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Contrato de Trabajo", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Contrato de Trabajo", subTitulo, datoDB);
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
                lista = nContrato.obtenerCatalago(consultaContrato[0], consultaContrato[1], consultaContrato[2], "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Denominación",
                    "CUIL/CUIT",
                    "Centro de Costo",
                    "F. de Alta",
                    "F. de baja",
                    "Estado" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //ID
                    campo[1].Trim(), //Denominación
                    campo[2].Trim(), //CUIL/CUIT
                    campo[3].Trim(), //Centro de Costo 
                    campo[4].Trim(), //F. de Alta
                    campo[5].Trim(), //F. de baja
                    campo[6].Trim() }; //Estado
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Contratos de Trabajo", subTitulos, new int[] { 8, 76, 13, 25, 10, 10, 12 }, _listaDelReporte, new List<int> { 4, 5 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Contratos de Trabajo", subTitulos, new float[] { 7, 43, 11, 22, 9, 9, 10 }, _listaDelReporte); //Ancho: 111
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
            else if (variablesDeFormulario[0] == "Catalogo_CategoriaTrabajo") //Catálogo de Categorías
            {
                Formulario.ComboBox_CargarElementos(cmbCategoria, new N_CategoriaTrabajo().obtenerListaDeElementos(), 0); //Establece los items del ComboBox
                cmbCategoria.Text = variablesDeFormulario[2];
            }
            else if (variablesDeFormulario[0] == "Catalogo_ObraSocial") //Catálogo de Obras Sociales
            {
                txtObraSocial.Text = variablesDeFormulario[2] + " " + variablesDeFormulario[3];
            }
        }
        #endregion
    }
}
