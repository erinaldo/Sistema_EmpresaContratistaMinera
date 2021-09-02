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
    public partial class FormCobranza : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private bool _montoBruto_ControladorDeModificacionManual = false;
        private string _montoBruto_ControladorDeModificacion = "";
        private string _retencionIIBB_ControladorDeModificacion = "";
        private string _retencionLH_ControladorDeModificacion = "";
        private string _retencionIVA_ControladorDeModificacion = "";
        private string _retencionGanancia_ControladorDeModificacion = "";
        private string _retencionFondoMinero_ControladorDeModificacion = "";
        private string _retencionSUSS_ControladorDeModificacion = "";
        private string _idVenta_ControladorDeModificacion = "";
        private string[] consultaCobranza;
        private Cliente objCliente;
        private Cobranza objCobranza;
        private Cobranza objCobranzaDB;
        private List<CobranzaDetalle> listaDeCobranzaDetalle;
        private List<CobranzaDetalle> listaDeCobranzaDetalleDB;
        private N_Cliente nCliente = new N_Cliente();
        private N_Cobranza nCobranza = new N_Cobranza();
        private N_CobranzaDetalle nCobranzaDetalle = new N_CobranzaDetalle();
        private string _navCuit = ""; //Sistema de Navegación: Paso1
        private N_AsientoContable nAsientoContable = new N_AsientoContable();
        private N_CuentaContable nCuentaContable = new N_CuentaContable();
        #endregion

        #region Constructores
        public FormCobranza()
        {
            InitializeComponent();
        }
        public FormCobranza(Cobranza navCobranza) //Utilizado por el navegador de formularios
        {
            objCobranzaDB = objCobranza = navCobranza;
            listaDeCobranzaDetalleDB = listaDeCobranzaDetalle = nCobranzaDetalle.obtenerObjetos(objCobranzaDB.Id); 
            InitializeComponent();
        }
        public FormCobranza(string navCuit) //Sistema de Navegación: Paso2
        {
            _navCuit = navCuit;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormCobranza_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(txtCbteTPV, "Punto de venta");
            toolTip.SetToolTip(txtCbteNro, "Número de comprobante");
            toolTip.SetToolTip(pkrCbteFecha, "Fecha de comprobante");
            toolTip.SetToolTip(txtEstado, "Estado del comprobante");
            toolTip.SetToolTip(btnWord_Acuse, "Genera y exporta el acuse de recibo de cobro a Word");
            #endregion
            #region Tipo de Datos
            gridDetalle.Columns[0].ValueType = typeof(System.Int64);
            gridDetalle.Columns[1].ValueType = typeof(System.String);
            gridDetalle.Columns[2].ValueType = typeof(System.Decimal);
            gridDetalle.Columns[3].ValueType = typeof(System.Decimal);
            gridDetalle.Columns[4].ValueType = typeof(System.Decimal);
            gridDetalle.Columns[5].ValueType = typeof(System.Decimal);
            gridDetalle.Columns[6].ValueType = typeof(System.Decimal);
            gridDetalle.Columns[7].ValueType = typeof(System.String);
            #endregion
            cmbMedioCobro.Text = "EFECTIVO"; //Establece el tipo de cuenta 
            Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(new string[] { "DISPONIBILIDADES > CAJAS" }), 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbCtaBancaria, new N_Banco().obtenerListaDeElementos(), "S/D"); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO", "FILTRAR POR ESTADO: ANULADO", "TODOS LOS ESTADOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT", "FILTRAR POR DENOMINACION",
                    "FILTRAR POR FECHA", "FILTRAR POR N° PV - CBTE", "FILTRAR POR N° LIQUIDACION" }, 1); //Establece los items del ComboBox
            #region Sistema de Navegación: Paso3
            if (!string.IsNullOrEmpty(_navCuit))
            {
                cmbFiltroLista2.Text = "FILTRAR POR CUIT";
                txtFiltroLista.Text = _navCuit;
            }
            #endregion
            filtrarCatalogo(0); //Carga el catálogo
            if (objCobranzaDB != null) escribirControles(objCobranzaDB, listaDeCobranzaDetalleDB); //Escribe los datos solicitados mediante la navegación entre formularios
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                new FormCatalogo_Cliente(this, "FILTRAR POR ESTADO: ACTIVO").ShowDialog(this);
            }
        }

        private void cmbMedioCobro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMedioCobro.Text == "CHEQUE")
            {
                Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(new string[] { "VALORES A DEPOSITAR" }), 0); //Establece los items del ComboBox
                lblMedioNro.Text = "Cheque(nro. - vto.)";
                pkrMedioChequeVto.Text = Fecha.SistemaFecha();
                Formulario.Visibilidad(true, new Control[] { lblMedioNro, txtMedioNro, pkrMedioChequeVto,
                    lblCtaBancaria, cmbCtaBancaria, btnCtaBancaria, cmbCtaBancariaTipo, txtCtaBancariaNro });
            }
            else if (cmbMedioCobro.Text == "EFECTIVO")
            {
                Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(new string[] { "DISPONIBILIDADES > CAJAS" }), 0); //Establece los items del ComboBox
                Formulario.Visibilidad(false, new Control[] { lblMedioNro, txtMedioNro, pkrMedioChequeVto,
                    lblCtaBancaria, cmbCtaBancaria, btnCtaBancaria,
                    cmbCtaBancariaTipo, txtCtaBancariaNro });
            }
            else if (cmbMedioCobro.Text == "T.CREDITO" || cmbMedioCobro.Text == "T.DEBITO")
            {
                Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(new string[] { "TARJETAS" }), 0); //Establece los items del ComboBox
                Formulario.Visibilidad(false, new Control[] { lblMedioNro, txtMedioNro, pkrMedioChequeVto,
                    lblCtaBancaria, cmbCtaBancaria, btnCtaBancaria,
                    cmbCtaBancariaTipo, txtCtaBancariaNro });
            }
            else if (cmbMedioCobro.Text == "TRANSFERENCIA")
            {
                Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(new string[] { "DISPONIBILIDADES > BANCOS" }), 0); //Establece los items del ComboBox
                lblMedioNro.Text = "N° Transacción";
                Formulario.Visibilidad(false, new Control[] { pkrMedioChequeVto });
                Formulario.Visibilidad(true, new Control[] { lblMedioNro, txtMedioNro, lblCtaBancaria, cmbCtaBancaria,
                    btnCtaBancaria, cmbCtaBancariaTipo, txtCtaBancariaNro });
            }
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

        #region Eventos de Cuadricula
        private void gridDetalle_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) _idVenta_ControladorDeModificacion = Convert.ToString(gridDetalle.CurrentRow.Cells[0].Value); //Verifica que se este dentro de la celda ID y captura el valor inicial del ID 
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0) gridDetalle.CurrentRow.Cells[1].ReadOnly = (gridDetalle.CurrentRow.Cells[0].Value.ToString() == "00000000") ? false : true; //Verifica que se este dentro de la celda Denominación. En caso de haber un código cero, permite la modificación de la denominación del comprobante
            else if ((e.ColumnIndex == 7) && e.RowIndex >= 0)
            {
                // ---------- Bloque que despliega con un click los ComboBox de la cuadricula ---------- //
                if (gridDetalle.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && gridDetalle.CurrentCell.ReadOnly == false)
                {
                    gridDetalle.BeginEdit(true); //Coloca en modo edición a la celda
                    ((ComboBox)gridDetalle.EditingControl).DroppedDown = true; //Despliega el ComboBox
                }
            }
            gridDetalle.FirstDisplayedCell = gridDetalle.CurrentCell; //Importante: Mueve las barras de desplazamiento (Vertical y Horizoltal) en relación a la celda seleccionada 
        }

        private void gridDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(gridDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString()))
            {
                if (e.ColumnIndex == 0 && e.RowIndex >= 0) //Verifica que se este dentro de la celda ID 
                {
                    gridDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = gridDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().PadLeft(8, '0'); //Formatea el ID de la Venta
                    buscarVentaID(e.RowIndex, Convert.ToString(gridDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)); //Busca el ID ingresado en la Base de Datos
                    if (e.RowIndex != (gridDetalle.RowCount - 1)) SendKeys.Send("{UP}"); //Bloque 1a: Mantiene el foco en la celda editada
                }
                else if ((e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5) && e.RowIndex >= 0) //Verifica que se este dentro de la celda "Cantidad" ó "Precio Unitario" ó "Alícuota IVA" 
                {
                    if (e.RowIndex != (gridDetalle.RowCount - 1)) SendKeys.Send("{UP}"); //Bloque 1b: Mantiene el foco en la celda editada
                }
            }
        }

        private void gridDetalle_ComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
            {
                gridDetalle.EndEdit(); //Bloque 2: Impide que el foco pase a la siguiente fila en los desplegables de la cuadricula 
                e.SuppressKeyPress = true;
                SendKeys.Send("{RIGHT}"); //Mueve el foco a la celda de la siguiente columna
            }
        }

        private void gridDetalle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            gridDetalle.CancelEdit(); //Cancela la edición y restaura su valor cuando No se ha ingresado un valor válido en la celda 
            gridDetalle.EndEdit(); //Termina la edición cuando No se ha ingresado un valor válido en la celda 
        }

        private void gridDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = System.Drawing.Color.White; //Importante: Esta linea corrige el error de los desplegables de la cuadricula cuando se ponen en negro
            e.Control.KeyPress -= new KeyPressEventHandler(gridDetalle_KeyPress); //Paso 1: Elimina la redundancia del delegado del evento KeyPress
            e.Control.KeyPress += new KeyPressEventHandler(gridDetalle_KeyPress); //Paso 2: Crea un nuevo delegado del evento KeyPress
            if (gridDetalle.Columns[gridDetalle.CurrentCell.ColumnIndex].Index == 7)
            {
                DataGridViewComboBoxEditingControl cmbCuadricula = e.Control as DataGridViewComboBoxEditingControl; //Convierte el control en un comboBox
                cmbCuadricula.KeyDown -= new KeyEventHandler(gridDetalle_ComboBox_KeyDown); //Paso 1: Elimina la redundancia del delegado del evento KeyDown
                cmbCuadricula.KeyDown += new KeyEventHandler(gridDetalle_ComboBox_KeyDown); //Paso 2: Agrega el delegado del evento KeyDown
            }
        }

        private void gridDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
            {
                gridDetalle.EndEdit(); //Bloque 2: Impide que el foco pase a la siguiente fila en los desplegables de la cuadricula 
                e.SuppressKeyPress = true;
                if (gridDetalle.CurrentCell.ColumnIndex == 7|| gridDetalle.CurrentCell.ColumnIndex == 8) gridDetalle.CurrentCell = gridDetalle.CurrentRow.Cells[0]; //Mueve el foco a la celda de la primera columna  
                else SendKeys.Send("{RIGHT}"); //Mueve el foco a la celda de la siguiente columna 
            }
        }

        private void gridDetalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gridDetalle.CurrentCell != null)
            {
                if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab) //Bloque 3: Impide que el foco pase a la siguiente fila en los desplegables de la cuadricula 
                {
                    gridDetalle.EndEdit();
                }
                else if (e.KeyChar == '-') //Tecla de Acesso Directo "Quitar Fila"
                {
                    e.Handled = true;
                    quitarFila();
                }
                else if (e.KeyChar == '*') //Tecla de Acesso Directo "Buscar Artículo"
                {
                    e.Handled = true;
                    buscarVenta(gridDetalle);
                }
                else if (e.KeyChar == '+') //Tecla de Acesso Directo "Agregar Fila"
                {
                    e.Handled = true;
                    agregarFila();
                }
                else if (gridDetalle.CurrentCell.ColumnIndex == 0) //Verifica que el ingreso de datos sea con números enteros dentro de la celda "Código"
                {
                    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
                }
            }
        }

        private void gridDetalle_Leave(object sender, EventArgs e)
        {
            if (gridDetalle.Rows.Count > 0)
            {
                _idVenta_ControladorDeModificacion = ""; //Importante: Restaura el controlador de modificacion de artículo
                gridDetalle.CurrentCell.Selected = false; //Quita la selección de la celda al perder el foco
            }

        }

        private void btnAgregarFila_Click(object sender, EventArgs e)
        {
            agregarFila();
            gridDetalle.Focus();
        }

        private void btnQuitarFila_Click(object sender, EventArgs e)
        {
            quitarFila();
            gridDetalle.Focus();
        }

        private void btnBuscarFila_Click(object sender, EventArgs e)
        {
            if (gridDetalle.RowCount <= 0) agregarFila();
            buscarVenta(gridDetalle);
            gridDetalle.Focus();
        }
        #endregion

        #region Eventos de Totales
        private void chkRetencionIIBB_CheckedChanged(object sender, EventArgs e)
        {
            calcularTotal();
            txtRetencionIIBB.ReadOnly = !chkRetencionIIBB.Checked;
        }

        private void chkRetencionLH_CheckedChanged(object sender, EventArgs e)
        {
            calcularTotal();
            txtRetencionLH.ReadOnly = !chkRetencionLH.Checked;
        }

        private void chkRetencionIVA_CheckedChanged(object sender, EventArgs e)
        {
            calcularTotal();
            txtRetencionIVA.ReadOnly = !chkRetencionIVA.Checked;
        }

        private void chkRetencionGanancia_CheckedChanged(object sender, EventArgs e)
        {
            calcularTotal();
            txtRetencionGanancia.ReadOnly = !chkRetencionGanancia.Checked;
        }

        private void chkRetencionFondoMinero_CheckedChanged(object sender, EventArgs e)
        {
            calcularTotal();
            txtRetencionFondoMinero.ReadOnly = !chkRetencionFondoMinero.Checked;
        }

        private void chkRetencionSUSS_CheckedChanged(object sender, EventArgs e)
        {
            calcularTotal();
            txtRetencionSUSS.ReadOnly = !chkRetencionSUSS.Checked;
        }

        private void txtMontoBruto_Enter(object sender, EventArgs e)
        {
            _montoBruto_ControladorDeModificacion = txtMontoBruto.Text;
        }

        private void txtMontoBruto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtMontoBruto.Text);
        }

        private void txtMontoBruto_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMontoBruto.Text))
            {
                _montoBruto_ControladorDeModificacionManual = false;
                calcularTotal();
            }
            else if (!string.IsNullOrWhiteSpace(txtMontoBruto.Text) && txtMontoBruto.Text != _montoBruto_ControladorDeModificacion)
            {
                _montoBruto_ControladorDeModificacionManual = true;
                calcularTotal();
            }
        }

        private void txtRetencionIIBB_Enter(object sender, EventArgs e)
        {
            _retencionIIBB_ControladorDeModificacion = txtRetencionIIBB.Text;
        }

        private void txtRetencionIIBB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtRetencionIIBB.Text);
        }

        private void txtRetencionIIBB_Validated(object sender, EventArgs e)
        {
            if(txtRetencionIIBB.Text != _retencionIIBB_ControladorDeModificacion) calcularRetencion("IIBB");
        }

        private void txtRetencionLH_Enter(object sender, EventArgs e)
        {
            _retencionLH_ControladorDeModificacion = txtRetencionLH.Text;
        }

        private void txtRetencionLH_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtRetencionLH.Text);
        }

        private void txtRetencionLH_Validated(object sender, EventArgs e)
        {
            if (txtRetencionLH.Text != _retencionLH_ControladorDeModificacion) calcularRetencion("LH");
        }

        private void txtRetencionIVA_Enter(object sender, EventArgs e)
        {
            _retencionIVA_ControladorDeModificacion = txtRetencionIVA.Text;
        }

        private void txtRetencionIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtRetencionIVA.Text);
        }

        private void txtRetencionIVA_Validated(object sender, EventArgs e)
        {
            if (txtRetencionIVA.Text != _retencionIVA_ControladorDeModificacion) calcularRetencion("IVA");
        }

        private void txtRetencionGanancia_Enter(object sender, EventArgs e)
        {
            _retencionGanancia_ControladorDeModificacion = txtRetencionGanancia.Text;
        }

        private void txtRetencionGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtRetencionGanancia.Text);
        }

        private void txtRetencionGanancia_Validated(object sender, EventArgs e)
        {
            if (txtRetencionGanancia.Text != _retencionGanancia_ControladorDeModificacion) calcularRetencion("GANANCIA");
        }

        private void txtRetencionFondoMinero_Enter(object sender, EventArgs e)
        {
            _retencionFondoMinero_ControladorDeModificacion = txtRetencionFondoMinero.Text;
        }

        private void txtRetencionFondoMinero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtRetencionFondoMinero.Text);
        }

        private void txtRetencionFondoMinero_Validated(object sender, EventArgs e)
        {
            if (txtRetencionFondoMinero.Text != _retencionFondoMinero_ControladorDeModificacion) calcularRetencion("FONDOMINERO");
        }

        private void txtRetencionSUSS_Enter(object sender, EventArgs e)
        {
            _retencionSUSS_ControladorDeModificacion = txtRetencionSUSS.Text;
        }

        private void txtRetencionSUSS_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtRetencionSUSS.Text);
        }

        private void txtRetencionSUSS_Validated(object sender, EventArgs e)
        {
            if (txtRetencionSUSS.Text != _retencionSUSS_ControladorDeModificacion) calcularRetencion("SUSS");
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(145))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objCobranza != null)
            {
                if (objCobranza.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(145)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarCampoVacio() && validarCuadricula())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            this.objCliente = nCliente.obtenerObjeto("TODOS", "ID", objCobranza.Cliente.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                            this.listaDeCobranzaDetalle = new List<CobranzaDetalle>(); //Importante: Crea una nueva lista de Objetos por seguridad (libera los residuos de antiguas instancias)
                            objCobranza.Id = nCobranza.generarNumeroID(); //Paso 3: Genera un ID para cada Objeto
                            objCobranza.CbteNro = objCobranza.Id; //Paso 4: Establece el valor del ID como número de comprobante
                            if (nCobranza.insertar(objCobranza)) //Paso 5: Inserta el objeto principal
                            {
                                #region Registra el Detalle
                                long idDetalle = nCobranzaDetalle.generarNumeroID(); //Paso 6: Asigna un numero de ID al Objeto
                                foreach (DataGridViewRow fila in gridDetalle.Rows)
                                {
                                    Venta objVenta = new N_Venta().obtenerObjeto("ID", Convert.ToString(Convert.ToInt64(fila.Cells[0].Value)), true);
                                    objVenta.CobranzaEstado = fila.Cells[7].Value.ToString().Trim(); //Importante: Actualiza el Estado de Cobranza
                                    CobranzaDetalle objCobranzaDetalle = new CobranzaDetalle(
                                        idDetalle,
                                        objCobranza,
                                        objVenta);
                                    listaDeCobranzaDetalle.Add(objCobranzaDetalle); //Paso 7: Agrega el Objeto en la lista de Objetos
                                    idDetalle++; //Paso 9: Importante: Incrementa el valor del ID Detalle
                                        /* Nota: Cuando hay más de un ítem en el detalle: El valor del ID se debe incrementar
                                        * iterativamente ya que el generador no brinda esta solución porque solo puede calcular
                                        * el valor del máximo de ID de los ítems existentes en la Base de Datos. En este caso
                                        * es solo una lista de objetos que aun No han sido insertados).*/
                                }
                                if (nCobranzaDetalle.insertar(listaDeCobranzaDetalle)) actualizarComprobanteDeVenta("REGISTRACION", listaDeCobranzaDetalle); //Paso 8: Inserta la lista de Objetos en la Base de Datos. De ser corecto, posteriormente actualiza el Estado y la Fecha de Cobranza de cada comprobante de venta
                                #endregion
                                calcularCtaCte("REGISTRACION"); //Paso 9: Actualiza la Cta.Cte. del Cliente Personal
                                asentarTransaccion("REGISTRACION"); //Paso 10: Registra el/los Asiento/s Contable/s
                                mostrarRegistro(objCobranza, listaDeCobranzaDetalle);
                                Mensaje.RegistroCorrecto("REGISTRACION");
                            }
                        }
                    }
                }
                else if (objCobranza.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(147)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (objCobranza.CbteFecha.AddDays(Global.RegistroModificacion) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        if (objCobranza.Estado == "ACTIVO") //Verifica si el comprobante esta activo
                        {
                            {
                                if (ValidarCampoVacio())
                                {
                                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                                    {
                                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                                        this.objCliente = nCliente.obtenerObjeto("TODOS", "ID", objCobranza.Cliente.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                                        this.listaDeCobranzaDetalle = new List<CobranzaDetalle>(); //Importante: Crea una nueva lista de Objetos por seguridad (libera los residuos de antiguas instancias)
                                        #region Lectura del Detalle
                                        foreach (DataGridViewRow fila in gridDetalle.Rows)
                                        {
                                            Venta objVenta = new N_Venta().obtenerObjeto("ID", Convert.ToString(Convert.ToInt64(fila.Cells[0].Value)), true); //Paso 3: Importante: Re-Almacena el Objeto de la Base de Datos
                                            objVenta.CobranzaEstado = fila.Cells[7].Value.ToString().Trim(); //Importante: Actualiza el Estado de Cobranza                                      
                                            CobranzaDetalle objCobranzaDetalle = new CobranzaDetalle(
                                                Convert.ToInt64(fila.Cells[8].Value),
                                                objCobranza,
                                                objVenta);
                                            listaDeCobranzaDetalle.Add(objCobranzaDetalle); //Paso 4: Agrega el Objeto en la lista de Objetos
                                        }
                                        #endregion
                                        if (!objCobranza.Equals(objCobranzaDB) || !nCobranzaDetalle.compararDetalle(listaDeCobranzaDetalleDB, listaDeCobranzaDetalle)) //Paso 5: Verifica que el Objeto y/o Detalle se han modificado 
                                        {
                                            if (nCobranza.actualizar(objCobranza)) //Paso 6: Actualiza el Objeto y Detalle
                                            {
                                                if (nCobranzaDetalle.actualizar(listaDeCobranzaDetalle)) actualizarComprobanteDeVenta("MODIFICACION", listaDeCobranzaDetalle); //Paso 7: Actualiza la lista de Objetos en la Base de Datos. De ser corecto, posteriormente actualiza el Estado y la Fecha de Cobranza de cada comprobante de venta
                                                calcularCtaCte("MODIFICACION"); //Paso 8: Actualiza la Cta.Cte. del Cliente Personal
                                                asentarTransaccion("MODIFICACION"); //Paso 9: Registra el/los Asiento/s Contable/s
                                                mostrarRegistro(objCobranza, listaDeCobranzaDetalle);
                                                Mensaje.RegistroCorrecto("MODIFICACION");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else Mensaje.Advertencia("Operación incorrecta.\nLos comprobantes anulados No pueden ser modificados.");
                    }
                    else Mensaje.Advertencia("Operación Incorrecta. Los comprobantes que han superado los " + Global.RegistroModificacion.ToString() + " días de su registración No pueden ser modificados.");
                }
                else Mensaje.Restriccion();
                bool ValidarCampoVacio() // Método que valida los campos requeridos
                {
                    return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion, txtCuit, txtCategoriaIva,
                    cmbMedioCobro , cmbCuentaContable  }) && Formulario.ValidarNumeroDoble(txtMontoBruto.Text) > 0 && Formulario.ValidarNumeroDoble(lblMontoNeto.Text) > 0;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objCobranza.Id > 0) escribirControles(objCobranzaDB, listaDeCobranzaDetalleDB); //Restaura los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(146)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objCobranza.Id > 0)
                {
                    if (objCobranza.CbteFecha.AddDays(Global.RegistroAnulacion) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea anular el registro ID: " + objCobranza.Id.ToString() + "?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            objCliente = nCliente.obtenerObjeto("TODOS", "ID", objCobranza.Cliente.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                            if (nCobranza.anular(objCobranza)) //Paso 3: Verifica el exito de la actualización y muestra los datos actualizados
                            {
                                objCobranza.Estado = "ANULADO"; //Paso 4: Importante: Establece el cambio de estado en el Objeto del Módulo 
                                actualizarComprobanteDeVenta("ANULACION", listaDeCobranzaDetalle); //Paso 5: Actualiza el Estado y la Fecha de Cobranza de cada comprobante de venta
                                calcularCtaCte("ANULACION"); //Paso 6: Actualiza la Cta.Cte. del Cliente Personal
                                asentarTransaccion("ANULACION"); //Paso 7: Registra el/los Asiento/s Contable/s         
                                mostrarRegistro(objCobranza, listaDeCobranzaDetalleDB);
                                Mensaje.RegistroCorrecto("ANULACION");
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación Incorrecta. Los comprobantes que han superado los " + Global.RegistroAnulacion + " días de su registración No pueden ser anulados.");
                }
            }
            else Mensaje.Restriccion();
        }

        private void btnWord_Acuse_Click(object sender, EventArgs e)
        {
            if (objCobranza.Id > 0)
            {
                if (objCobranza.Estado == "ACTIVO") //Verifica si el comprobante esta activo
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string conceptoDetalle = "";
                    string ctaBancariaDenominacion = (objCobranza.Banco != null) ? " - " + objCobranza.Banco.Denominacion : "";
                    string ctaBancariaTipo = (objCobranza.Banco != null && objCobranza.CtaBancariaTipo != "S/D") ? " " + objCobranza.CtaBancariaTipo : "";
                    string ctaBancariaNumero = (objCobranza.Banco != null && !string.IsNullOrEmpty(objCobranza.CtaBancariaNro.Trim())) ? " N°" + objCobranza.CtaBancariaNro.PadLeft(10, '0') : "";
                    foreach (DataGridViewRow fila in gridDetalle.Rows) conceptoDetalle += "\n" + fila.Cells[1].Value; //Agrega el Detalle del Comprobante al concepto
                    string[] datoDB = {
                        objCobranza.CbteTPV.ToString().PadLeft(5, '0') + "-" + objCobranza.CbteNro.ToString().PadLeft(8, '0'),
                        objCobranza.Cliente.Denominacion,
                        Convert.ToInt64(objCobranza.Cliente.Cuit).ToString("00-00000000/0"),
                        Fecha.ConvertirFecha_Escrita(objCobranza.CbteFecha),
                        Formulario.ValidarCampoMoneda(objCobranza.MontoBruto + objCobranza.Iva105 + objCobranza.Iva210 + objCobranza.Iva270),
                        Formulario.GenerarNumeroTextual(Formulario.ValidarCampoMoneda(objCobranza.MontoBruto + objCobranza.Iva105 + objCobranza.Iva210 + objCobranza.Iva270)),
                        (objCobranza.Concepto + conceptoDetalle).ToUpper(),
                        objCobranza.MedioPago + " " + ((objCobranza.MedioPago == "CHEQUE") ? "N°" + Convert.ToString(objCobranza.MedioNro).PadLeft(8, '0')  + " CON FECHA DE COBRO " + Fecha.ConvertirFecha(objCobranza.MedioChequeVto) + " (" + objCobranza.CuentaContable.Denominacion + ")"
                            : ((objCobranza.MedioPago == "TRANSFERENCIA") ? "N°" + Convert.ToString(objCobranza.MedioNro).PadLeft(8, '0')  + ctaBancariaDenominacion + ctaBancariaTipo + ctaBancariaNumero  : "")) };
                    Reporte reporte = new Reporte();
                    reporte.crearDocumentoWord_AcusePago(objCobranza.Cliente.Denominacion, datoDB);
                    Cursor.Current = Cursors.Default;
                }
                else Mensaje.Advertencia("Operación incorrecta.\nLos comprobantes anulados No pueden ser exportados a Word.");
            }
            else Mensaje.Advertencia("Operación incorrecta.\nSeleccione un registro en la pantalla e intente nuevamente.");
        }
        #endregion

        #region Métodos de Cuadricula
        private void agregarFila()
        {
            if (_controladorDeNuevoRegistro && gridDetalle.RowCount <= 15) //Verifica que no se superen las 15 filas en la cuadricula
            {
                gridDetalle.Rows.Add("", "", "0,00", "0,00", "0,00", "0,00", "0,00", "S/COBRAR");
                gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                gridDetalle.FirstDisplayedScrollingRowIndex = gridDetalle.RowCount - 1; //Posiciona el scroll del gridDetalle en la celda seleccionada
                SendKeys.Send("{DOWN}"); //Mueve el foco a la nueva fila  
            }
        }

        private void agregarFilas(List<CobranzaDetalle> detalle)
        {
            gridDetalle.Rows.Clear();
            foreach (CobranzaDetalle item in detalle)
            {
                gridDetalle.Rows.Add();
                gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                gridDetalle.CurrentRow.Cells[0].Value = Convert.ToString(item.Venta.Id).PadLeft(8, '0');
                gridDetalle.CurrentRow.Cells[1].Value = Formulario.GenerarTipoComprobante(item.Venta.AfipCbteTipo) + "  N°" + Convert.ToString(item.Venta.AfipCbteTPV).PadLeft(5, '0') + "-" + Convert.ToString(item.Venta.AfipCbteNro).PadLeft(8, '0') + " " + Fecha.ConvertirFecha(item.Venta.AfipCbteFecha);
                gridDetalle.CurrentRow.Cells[2].Value = Formulario.ValidarCampoMoneda(item.Venta.Subtotal);
                gridDetalle.CurrentRow.Cells[3].Value = Formulario.ValidarCampoMoneda(item.Venta.Iva105);
                gridDetalle.CurrentRow.Cells[4].Value = Formulario.ValidarCampoMoneda(item.Venta.Iva210);
                gridDetalle.CurrentRow.Cells[5].Value = Formulario.ValidarCampoMoneda(item.Venta.Iva270);
                gridDetalle.CurrentRow.Cells[6].Value = Formulario.ValidarCampoMoneda(item.Venta.Total);
                gridDetalle.CurrentRow.Cells[7].Value = Convert.ToString(item.Venta.CobranzaEstado);
                gridDetalle.CurrentRow.Cells[8].Value = Formulario.ValidarNumeroEntero64(Convert.ToString(item.Id)); //Importante: Almacena el Id Detalle para identificar el ítem ante una posible modificación
            }
            if (gridDetalle.CurrentCell != null) gridDetalle.CurrentCell.Selected = false; //Quita la selección de la celda
        }

        private void buscarVenta(DataGridView cuadricula) //Método que busca una venta
        {
            if (_controladorDeNuevoRegistro)
            {
                FormCatalogo_Venta frm = new FormCatalogo_Venta(this, txtCuit.Text.Trim());
                frm.ShowDialog(this); //Abre el Catálogo de Ventas
                if (cuadricula.Rows.Count > 0)
                {
                    var posicion = cuadricula.CurrentRow.Cells[0]; //Posicionamiento - Paso 1: proceso de reposicionamiento
                    cuadricula.CurrentCell = null; //Posicionamiento - Paso 2: proceso de reposicionamiento
                    cuadricula.CurrentCell = posicion; //Posicionamiento - Paso 3: proceso de reposicionamiento
                }
            }
            calcularTotal();
        }

        private void buscarVentaID(int indiceFila, string idVenta) //Método que busca una venta por ID
        {
            if (_controladorDeNuevoRegistro)
            {
                if (string.IsNullOrEmpty(idVenta)) //Verifica que el ID recibido sea nulo o vacío
                {
                    escribirFila(indiceFila, "", null, true);
                }
                else
                {
                    idVenta = idVenta.PadLeft(8, '0'); //Formatea el ID recibido
                    if (idVenta != _idVenta_ControladorDeModificacion) //Verifica que el ID recibido ha sido modificado
                    {
                        if (idVenta == "00000000") //Verifica que el ID recibido es un ID cero (Editable)
                        {
                            escribirFila(indiceFila, "00000000", null, false);
                        }
                        else
                        {
                            Venta objVenta = new N_Venta().obtenerObjeto("ID", idVenta, true, txtCuit.Text.Trim()); //Consulta que ejecuta una busqueda en la Base de Datos
                            if (objVenta != null) //Verifica que el resultado de la consulta tenga exito
                            {
                                escribirFila(indiceFila, idVenta, objVenta, true);
                            }
                            else
                            {
                                escribirFila(indiceFila, "", null, true);
                            }
                        }
                    }
                }
            }
            calcularTotal();
        }

        private void calcularRetencion(string controlSolicitante = "")
        {
            double montoBruto = Formulario.ValidarNumeroDoble(txtMontoBruto.Text);
            double totalIVA = Formulario.ValidarNumeroDoble(lblIVA105.Text) + Formulario.ValidarNumeroDoble(lblIVA210.Text) + Formulario.ValidarNumeroDoble(lblIVA270.Text);
            double retencionIIBB = (chkRetencionIIBB.Checked) ? (controlSolicitante != "CUADRICULA") ? Math.Round(Formulario.ValidarNumeroDoble(txtRetencionIIBB.Text), 2) : Math.Round(((montoBruto / 100) * 2.5), 2) : 0.00;
            double retencionLH = (chkRetencionLH.Checked) ? (controlSolicitante != "CUADRICULA") ? Math.Round(Formulario.ValidarNumeroDoble(txtRetencionLH.Text), 2) : Math.Round(((montoBruto / 100) * 0.5), 2) : 0.00;
            double retencionIVA = (chkRetencionIVA.Checked) ? (controlSolicitante != "CUADRICULA") ? Math.Round(Formulario.ValidarNumeroDoble(txtRetencionIVA.Text), 2) : Math.Round(((montoBruto / 100) * 10.5), 2) : 0.00;
            double retencionGanancia = (chkRetencionGanancia.Checked) ? (controlSolicitante != "CUADRICULA") ? Math.Round(Formulario.ValidarNumeroDoble(txtRetencionGanancia.Text), 2) : Math.Round(((montoBruto / 100) * 2), 2) : 0.00;
            double retencionFondoMinero = (chkRetencionFondoMinero.Checked) ? Math.Round(Formulario.ValidarNumeroDoble(txtRetencionFondoMinero.Text), 2) : 0.00;
            double retencionSUSS = (chkRetencionSUSS.Checked) ? (controlSolicitante != "CUADRICULA") ? Math.Round(Formulario.ValidarNumeroDoble(txtRetencionSUSS.Text), 2) : Math.Round(((montoBruto / 100) * 1), 2) : 0.00;
            txtRetencionIIBB.Text = (controlSolicitante == "IIBB") ?  txtRetencionIIBB.Text : Formulario.ValidarCampoMoneda(retencionIIBB);
            txtRetencionLH.Text = (controlSolicitante == "LH") ? txtRetencionLH.Text : Formulario.ValidarCampoMoneda(retencionLH);
            txtRetencionIVA.Text = (controlSolicitante == "IVA") ? txtRetencionIVA.Text : Formulario.ValidarCampoMoneda(retencionIVA);
            txtRetencionGanancia.Text = (controlSolicitante == "GANANCIA") ? txtRetencionGanancia.Text : Formulario.ValidarCampoMoneda(retencionGanancia);
            txtRetencionFondoMinero.Text = (controlSolicitante == "FONDO_MINERO") ? txtRetencionFondoMinero.Text : Formulario.ValidarCampoMoneda(retencionFondoMinero);
            txtRetencionSUSS.Text = (controlSolicitante == "SUSS") ? txtRetencionSUSS.Text : Formulario.ValidarCampoMoneda(retencionSUSS);
            lblTotalRetencion.Text = Formulario.ValidarCampoMoneda((retencionIIBB + retencionLH + retencionIVA + retencionGanancia + retencionFondoMinero + retencionSUSS));
            lblMontoNeto.Text = Formulario.ValidarCampoMoneda((montoBruto + totalIVA) - (retencionIIBB + retencionLH + retencionIVA + retencionGanancia + retencionFondoMinero + retencionSUSS));
        }

        private void calcularTotal()
        {
            double iva105 = 0.00;
            double iva210 = 0.00;
            double iva270 = 0.00;
            double montoBruto = 0.00;
            double totalNeto = 0.00;
            foreach (DataGridViewRow row in gridDetalle.Rows) //Recorre la cuadricula y suma los valores de las celdas indicadas 
            {
                montoBruto += Formulario.ValidarNumeroDoble(row.Cells[2].Value.ToString());
                iva105 += Formulario.ValidarNumeroDoble(row.Cells[3].Value.ToString());
                iva210 += Formulario.ValidarNumeroDoble(row.Cells[4].Value.ToString());
                iva270 += Formulario.ValidarNumeroDoble(row.Cells[5].Value.ToString());
                totalNeto += Formulario.ValidarNumeroDoble(row.Cells[6].Value.ToString());
            }
            if (_montoBruto_ControladorDeModificacionManual)
            {
                double tazaPorcentualBruto = (100 / montoBruto) * Formulario.ValidarNumeroDoble(txtMontoBruto.Text);
                lblIVA105.Text = Formulario.ValidarCampoMoneda(Math.Round(((iva105 / 100) * tazaPorcentualBruto), 2));
                lblIVA210.Text = Formulario.ValidarCampoMoneda(Math.Round(((iva210 / 100) * tazaPorcentualBruto), 2));
                lblIVA270.Text = Formulario.ValidarCampoMoneda(Math.Round(((iva270 / 100) * tazaPorcentualBruto), 2));
            }
            else
            {
                lblIVA105.Text = Formulario.ValidarCampoMoneda(Math.Round(iva105, 2));
                lblIVA210.Text = Formulario.ValidarCampoMoneda(Math.Round(iva210, 2));
                lblIVA270.Text = Formulario.ValidarCampoMoneda(Math.Round(iva270, 2));
                txtMontoBruto.Text = Formulario.ValidarCampoMoneda(Math.Round(montoBruto, 2));
            }
            calcularRetencion("CUADRICULA");
        }

        private void escribirFila(int indiceFila, string idVenta, Venta objVenta, bool actividad)
        {
            gridDetalle.Rows[indiceFila].Cells[0].Value = idVenta;
            gridDetalle.Rows[indiceFila].Cells[1].Value = (objVenta != null) ? Formulario.GenerarTipoComprobante(objVenta.AfipCbteTipo) + "  N°" + Convert.ToString(objVenta.AfipCbteTPV).PadLeft(5, '0') + "-" + Convert.ToString(objVenta.AfipCbteNro).PadLeft(8, '0') + " " + Fecha.ConvertirFecha(objVenta.AfipCbteFecha) : "";
            gridDetalle.Rows[indiceFila].Cells[2].Value = (objVenta != null) ? Formulario.ValidarCampoMoneda(objVenta.Subtotal) : "0,00";
            gridDetalle.Rows[indiceFila].Cells[3].Value = (objVenta != null) ? Formulario.ValidarCampoMoneda(objVenta.Iva105) : "0,00";
            gridDetalle.Rows[indiceFila].Cells[4].Value = (objVenta != null) ? Formulario.ValidarCampoMoneda(objVenta.Iva210) : "0,00";
            gridDetalle.Rows[indiceFila].Cells[5].Value = (objVenta != null) ? Formulario.ValidarCampoMoneda(objVenta.Iva270) : "0,00";
            gridDetalle.Rows[indiceFila].Cells[6].Value = (objVenta != null) ? Formulario.ValidarCampoMoneda(objVenta.Total) : "0,00";
            gridDetalle.Rows[indiceFila].Cells[7].Value = (objVenta != null) ? Convert.ToString(objVenta.CobranzaEstado) : "S/COBRAR";
        }

        private void quitarFila()
        {
            if (_controladorDeNuevoRegistro)
            {
                gridDetalle.EndEdit(); //Importante: Esta linea corrige el error de llamas reentrantes
                if (gridDetalle.Rows.Count > 0) gridDetalle.Rows.Remove(gridDetalle.CurrentRow); //Elimina la fila correspondiente al botón clickeado
                gridDetalle.CurrentCell = null; //Posicionamiento - Paso 1: proceso de reposicionamiento
                if (gridDetalle.Rows.Count > 0) gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.Rows.Count - 1].Cells[0]; //Posicionamiento - Paso 2: proceso de reposicionamiento
                calcularTotal(); //Recalcula los totales del comprobante
            }
        }

        private void quitarFilaVacia()
        {
            if (_controladorDeNuevoRegistro && gridDetalle.Rows.Count > 0)
            {
                int contador = 0;
                int numeroDefilas = gridDetalle.Rows.Count; //Almacena el número de filas de la cuadricula
                while (contador < numeroDefilas)
                {
                    /*Importante: El bloque se ejecuta en base al número de filas en la cuadricula, posteriormente 
                     * se recorre fila por fila buscando una celda de “Código” y/o “Denominación” que este vacía 
                     * para eliminarla Si se tiene éxito, se fuerza a terminar el bucle for para generar una nueva
                     * iteración del while. Para su correcto funcionamiento, esto debe ser así por una cuestión de
                     * variaciones de los índices al eliminar una fila. */
                    foreach (DataGridViewRow fila in gridDetalle.Rows)
                    {
                        if (Formulario.ValidarNumeroEntero(Convert.ToString(fila.Cells[0].Value)) <= 0 || string.IsNullOrWhiteSpace(Convert.ToString(fila.Cells[1].Value))) //Importante: Borra las filas sin código o con código en cero y la filas que no tienen descripción 
                        {
                            gridDetalle.Rows.RemoveAt(fila.Index); //Elimna la fila vacia
                            break; //Termina forzadamente el bucle
                        }
                    }
                    contador++;
                }
            }
        }

        private bool validarCuadricula()
        {
            quitarFilaVacia(); //Quita todas la filas que estan vacias en la celda del "Código" o "Denominación"
            if (gridDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in gridDetalle.Rows)
                {
                    if (Formulario.ValidarNumeroEntero(fila.Cells[0].Value.ToString()) > 0) //Verifica que sea un código de comprobante válido
                    {
                        // ----------- BLOQUE CONTROLADOR DE FILAS DUPLICADAS ----------- //
                        int controladorDeDuplicado = 0;
                        foreach (DataGridViewRow filaDuplicada in gridDetalle.Rows)
                        {
                            if (fila.Cells[0].Value.ToString() == filaDuplicada.Cells[0].Value.ToString()) controladorDeDuplicado += 1;
                        }
                        if (controladorDeDuplicado > 1) //Verifica si hay filas duplicadas
                        {
                            Mensaje.Advertencia("Operación Incorrecta.\nElimine la fila duplicada ID " + fila.Cells[0].Value.ToString() + " e intente nuevamente.");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public override void asignarVariablesDeCuadricula(string[] variablesDeFormulario) //Método Sobrescribible
        {
            if (variablesDeFormulario[0] == "Catalogo_Venta") //Catálogo de Ventas
            {
                if (gridDetalle.Rows.Count > 0) // Verifica que No este vacia la cuadricula
                {
                    Venta venta = new N_Venta().obtenerObjeto("ID", variablesDeFormulario[1], false);
                    gridDetalle.CurrentRow.SetValues(
                        Convert.ToString(venta.Id).PadLeft(8, '0'),
                        Formulario.GenerarTipoComprobante(venta.AfipCbteTipo) + "  N°" + Convert.ToString(venta.AfipCbteTPV).PadLeft(5, '0') + "-" + Convert.ToString(venta.AfipCbteNro).PadLeft(8, '0') + " " + Fecha.ConvertirFecha(venta.AfipCbteFecha),
                        Formulario.ValidarCampoMoneda(venta.Subtotal),
                        Formulario.ValidarCampoMoneda(venta.Iva105),
                        Formulario.ValidarCampoMoneda(venta.Iva210),
                        Formulario.ValidarCampoMoneda(venta.Iva270),
                        Formulario.ValidarCampoMoneda(venta.Total),
                        Convert.ToString(venta.CobranzaEstado));
                }
            }
        }
        #endregion

        #region Métodos de Formulario
        private void actualizarComprobanteDeVenta(string operacion, List<CobranzaDetalle> detalle)
        {
            if (detalle.Count > 0)
            {
                DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual            
                foreach (CobranzaDetalle objCobranzaDetalle in detalle)
                {
                    if (operacion == "REGISTRACION" || operacion == "MODIFICACION")
                    {
                        objCobranzaDetalle.Venta.CobranzaVto = fechaActual; //Fecha de Cobranza
                        objCobranzaDetalle.Venta.CobranzaAlertado = (objCobranzaDetalle.Venta.CobranzaEstado == "COBRADO") ? true : false; //Resetea el estado de alerta de Cobranza
                    }
                    else if (operacion == "ANULACION")
                    {
                        objCobranzaDetalle.Venta.CobranzaEstado = "S/COBRAR"; //Estado de Cobranza
                        objCobranzaDetalle.Venta.CobranzaAlertado = false; //Resetea el estado de alerta de Cobranza
                    }
                    objCobranzaDetalle.Venta.CobranzaAlertado = (objCobranzaDetalle.Venta.CobranzaVto <= fechaActual) ? true : false; //Evalua la alerta de Cobranza
                    new N_Venta().actualizar(objCobranzaDetalle.Venta);
                }
            }
        }

        private void asentarTransaccion(string operacion)
        {
            AsientoContable objAsientoContable = new AsientoContable();
            double montoBruto = Formulario.ValidarNumeroDoble(txtMontoBruto.Text);
            double totalIVA = Formulario.ValidarNumeroDoble(lblIVA105.Text) + Formulario.ValidarNumeroDoble(lblIVA210.Text) + Formulario.ValidarNumeroDoble(lblIVA270.Text);
            double retencionIIBB = Math.Round(Formulario.ValidarNumeroDoble(txtRetencionIIBB.Text), 2);
            double retencionLH = Math.Round(Formulario.ValidarNumeroDoble(txtRetencionLH.Text), 2);
            double retencionIVA = Math.Round(Formulario.ValidarNumeroDoble(txtRetencionIVA.Text), 2);
            double retencionGanancia = Math.Round(Formulario.ValidarNumeroDoble(txtRetencionGanancia.Text), 2);
            double retencionFondoMinero = Math.Round(Formulario.ValidarNumeroDoble(txtRetencionFondoMinero.Text), 2);
            double retencionSUSS = Math.Round(Formulario.ValidarNumeroDoble(txtRetencionSUSS.Text), 2);
            double totalNeto = Formulario.ValidarNumeroDoble(lblMontoNeto.Text);
            objAsientoContable.AsientoFecha = pkrCbteFecha.Value;
            objAsientoContable.Descripcion = "Cobranza: REC-X N°" + Convert.ToString(objCobranza.CbteTPV).PadLeft(5, '0') + "-" + Convert.ToString(objCobranza.CbteNro).PadLeft(8, '0');
            objAsientoContable.Conciliacion = "S/CONCILIAR";
            objAsientoContable.OrigenTipo = "COB";
            objAsientoContable.OrigenId = objCobranza.Id;
            if (operacion == "REGISTRACION") objAsientoContable.AsientoNro = nAsientoContable.generarNumeroAsiento(); //Verifica que es un nuevo comprobante. Si es asi, genera un nuevo Número de Asiento
            else
            {
                AsientoContable objAsientoContablePrecedente = nAsientoContable.obtenerObjeto("COB", objCobranza.Id); //Paso 1: En el caso de una modificación o anulación, obtiene el Asiento registrado precedentemente
                if (objAsientoContablePrecedente != null) //Paso 2: Importante: Verifica la existencia de al menos un Asiento contable
                {
                    objAsientoContable.AsientoNro = objAsientoContablePrecedente.AsientoNro;
                    foreach (AsientoContable item in nAsientoContable.obtenerObjetos("LIBRO_DIARIO", 0, "ASIENTO", Convert.ToString(objAsientoContable.AsientoNro))) //Paso 3: Obtiene y recorre la lista de Asientos registrados precedentemente
                    {
                        nCuentaContable.actualizarSaldo(item.CuentaContable.Id, ((item.CuentaContable.Saldo - item.Debe) + item.Haber)); //Paso 4: Restaura el saldo de la Cuenta Contable de cada Asiento
                    }
                    nAsientoContable.eliminar(objAsientoContable.AsientoNro); //Paso 5: Elimina todos los Asientos Contables en relación al Numero de Asiento
                }
            }
            if (operacion != "ANULACION") //Verifica que No sea una Anulación. Si es así, crea los correspondientes Asientos Contables 
            {
                crearAsientoContable(objAsientoContable,
                    new string[] { cmbCuentaContable.Text, "RET. IIBB SUFRIDA", "RET. IVA SUFRIDA", "RET. GANANCIAS SUFRIDA", "FONDO MINERO SUFRIDA", "RET. SUSS SUFRIDA", "DEUDORES POR VENTA" },
                    new double[] { totalNeto, (retencionIIBB + retencionLH), retencionIVA, retencionGanancia, retencionFondoMinero, retencionSUSS, (montoBruto + totalIVA) },
                    new string[] { "DEBE", "DEBE", "DEBE", "DEBE", "DEBE", "DEBE", "HABER" },
                    new string[] { "S/CONCILIAR", "NO-APLICA", "NO-APLICA", "NO-APLICA", "NO-APLICA", "NO-APLICA", "NO-APLICA" } );
            }
            void crearAsientoContable(AsientoContable asiento, string[] cuentaContable, double[] monto, string[] deducirMonto, string[] conciliarMonto)
            {
                for (int i = 0; i < cuentaContable.Length; i++)
                {
                    if (monto[i] != 0.00)
                    {
                        asiento.CuentaContable = nCuentaContable.obtenerObjeto("DENOMINACION", cuentaContable[i], true);
                        asiento.Debe = (deducirMonto[i] == "DEBE") ? monto[i] : 0.00;
                        asiento.Haber = (deducirMonto[i] == "HABER") ? monto[i] : 0.00;
                        asiento.Conciliacion = conciliarMonto[i];
                        nAsientoContable.insertar(asiento); //Paso 1: Registra el Asiento Contable en la Base de Datos
                        nCuentaContable.actualizarSaldo(asiento.CuentaContable.Id, ((asiento.CuentaContable.Saldo + asiento.Debe) - asiento.Haber)); //Paso 2: Actualiza el saldo en la Cuenta Contable (El Debe suma en el Saldo y el Haber resta en el Saldo)
                    }
                }
            }
        }

        private void calcularCtaCte(string operacion)
        {
            double montoCobrado = Formulario.ValidarNumeroDoble(txtMontoBruto.Text) + Formulario.ValidarNumeroDoble(lblIVA105.Text) + Formulario.ValidarNumeroDoble(lblIVA210.Text) + Formulario.ValidarNumeroDoble(lblIVA270.Text);
            double saldo = objCliente.Saldo;
            if (operacion == "REGISTRACION") saldo = (saldo + montoCobrado); //Suma el monto pagado al saldo de la Cta.Cte. del Cliente 
            else if (operacion == "MODIFICACION") saldo = ((saldo - (objCobranzaDB.MontoBruto + objCobranzaDB.Iva105 + objCobranzaDB.Iva210 + objCobranzaDB.Iva270)) + montoCobrado); //Resta el monto pagado precedentemente al saldo de la Cta.Cte. del Cliente
            else if (operacion == "ANULACION") saldo = (saldo - montoCobrado); //Resta el monto pagado del saldo la Cta.Cte. del Cliente 
            nCliente.actualizarSaldo(objCliente.Id, saldo, false); //Actualiza el saldo en la Cta.Cte. del Cliente  
            this.objCliente.Saldo = saldo; //Importante: Actualiza el saldo del Objeto Maestro
        }

        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(Cobranza objRegistro, List<CobranzaDetalle> detalle)
        {
            this.objCobranza = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            this.listaDeCobranzaDetalle = detalle; //Iguala el Atributo de la clase con la lista de Objetos recibidos
            if (objCobranza != null)
            {
                _controladorDeNuevoRegistro = false;
                txtCbteTPV.Text = Convert.ToString(objCobranza.CbteTPV).PadLeft(5, '0');
                txtCbteNro.Text = Convert.ToString(objCobranza.CbteNro).PadLeft(8, '0');
                pkrCbteFecha.Value = objCobranza.CbteFecha;
                txtEstado.Text = objCobranza.Estado;
                txtLiquidacion.Text = Convert.ToString(objCobranza.NroLiquidacion).PadLeft(12, '0');
                objCliente = objCobranza.Cliente;
                txtDenominacion.Text = objCobranza.Cliente.Denominacion;
                txtCuit.Text = objCobranza.Cliente.Cuit;
                txtCategoriaIva.Text = objCobranza.Cliente.Iva;
                txtConcepto.Text = objCobranza.Concepto;
                chkRetencionIIBB.Checked = (objCobranza.RetencionIIBB > 0) ? true : false;
                chkRetencionLH.Checked = Convert.ToBoolean(objCobranza.RetencionLH > 0) ? true : false;
                chkRetencionIVA.Checked = Convert.ToBoolean(objCobranza.RetencionIVA > 0) ? true : false;
                chkRetencionGanancia.Checked = Convert.ToBoolean(objCobranza.RetencionGanancia > 0) ? true : false;
                chkRetencionFondoMinero.Checked = Convert.ToBoolean(objCobranza.RetencionFondoMinero > 0) ? true : false;
                chkRetencionSUSS.Checked = Convert.ToBoolean(objCobranza.RetencionSUSS > 0) ? true : false;
                agregarFilas(listaDeCobranzaDetalle); //Escribe los item en el detalle de comprobante
                txtMontoBruto.Text = Formulario.ValidarCampoMoneda(Convert.ToString(objCobranza.MontoBruto));
                lblIVA105.Text = Formulario.ValidarCampoMoneda(Convert.ToString(objCobranza.Iva105));
                lblIVA210.Text = Formulario.ValidarCampoMoneda(Convert.ToString(objCobranza.Iva210));
                lblIVA270.Text = Formulario.ValidarCampoMoneda(Convert.ToString(objCobranza.Iva270));
                txtRetencionIIBB.Text = Formulario.ValidarCampoMoneda(Convert.ToString(objCobranza.RetencionIIBB));
                txtRetencionLH.Text = Formulario.ValidarCampoMoneda(Convert.ToString(objCobranza.RetencionLH));
                txtRetencionIVA.Text = Formulario.ValidarCampoMoneda(Convert.ToString(objCobranza.RetencionIVA));
                txtRetencionGanancia.Text = Formulario.ValidarCampoMoneda(Convert.ToString(objCobranza.RetencionGanancia));
                txtRetencionFondoMinero.Text = Formulario.ValidarCampoMoneda(Convert.ToString(objCobranza.RetencionFondoMinero));
                txtRetencionSUSS.Text = Formulario.ValidarCampoMoneda(Convert.ToString(objCobranza.RetencionSUSS));
                lblTotalRetencion.Text = Formulario.ValidarCampoMoneda(Convert.ToString(objCobranza.TotalRetencion));
                lblMontoNeto.Text = Formulario.ValidarCampoMoneda(Convert.ToString(objCobranza.TotalNeto));
                cmbMedioCobro.Text = objCobranza.MedioPago;
                cmbCuentaContable.Text = (objCobranza.CuentaContable != null) ? objCobranza.CuentaContable.Denominacion : "";
                txtMedioNro.Text = (objCobranza.MedioPago == "CHEQUE" || objCobranza.MedioPago == "TRANSFERENCIA") ? Convert.ToString(objCobranza.MedioNro).PadLeft(8, '0') : "";
                pkrMedioChequeVto.Value = objCobranza.MedioChequeVto;
                cmbCtaBancaria.Text = (objCobranza.Banco != null && objCobranza.Banco.Id > 0) ? objCobranza.Banco.Denominacion : "";
                cmbCtaBancariaTipo.Text = (objCobranza.Banco != null) ? objCobranza.CtaBancariaTipo : "S/N";
                txtCtaBancariaNro.Text = (objCobranza.Banco != null) ? Convert.ToString(objCobranza.CtaBancariaNro).PadLeft(10, '0') : "";
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objCobranza.EdicionFecha) + " por " + objCobranza.EdicionUsuarioDenominacion;
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objCobranza = new Cobranza(
                (objCobranza.Id <= 0) ? 0 : objCobranza.Id,
                Convert.ToInt32(Global.PtoVta),
                Formulario.ValidarNumeroEntero64(txtCbteNro.Text),
                pkrCbteFecha.Value,
                txtEstado.Text,
                Formulario.ValidarNumeroEntero64(txtLiquidacion.Text),
                objCliente,
                txtConcepto.Text,
                Formulario.ValidarNumeroDoble(txtMontoBruto.Text),
                Formulario.ValidarNumeroDoble(lblIVA105.Text),
                Formulario.ValidarNumeroDoble(lblIVA210.Text),
                Formulario.ValidarNumeroDoble(lblIVA270.Text),
                Formulario.ValidarNumeroDoble(txtRetencionIIBB.Text),
                Formulario.ValidarNumeroDoble(txtRetencionLH.Text),
                Formulario.ValidarNumeroDoble(txtRetencionIVA.Text),
                Formulario.ValidarNumeroDoble(txtRetencionGanancia.Text),
                Formulario.ValidarNumeroDoble(txtRetencionFondoMinero.Text),
                Formulario.ValidarNumeroDoble(txtRetencionSUSS.Text),
                Formulario.ValidarNumeroDoble(lblTotalRetencion.Text),
                Formulario.ValidarNumeroDoble(lblMontoNeto.Text),
                new N_CuentaContable().obtenerObjeto("DENOMINACION", cmbCuentaContable.Text),
                cmbMedioCobro.Text,
                Formulario.ValidarNumeroEntero64(txtMedioNro.Text),
                pkrMedioChequeVto.Value,
                (cmbCtaBancaria.Text != "S/D" && (cmbMedioCobro.Text == "CHEQUE" || cmbMedioCobro.Text == "TRANSFERENCIA")) ? new N_Banco().obtenerObjeto("DENOMINACION", cmbCtaBancaria.Text, false) : new Banco(0, ""),
                (cmbMedioCobro.Text == "TRANSFERENCIA") ? cmbCtaBancariaTipo.Text : "S/D",
                (cmbMedioCobro.Text == "CHEQUE" || cmbMedioCobro.Text == "TRANSFERENCIA") ? txtCtaBancariaNro.Text.Trim() : "",
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objCliente = new Cliente(); //Restaura el Objeto Primario
            objCobranza = new Cobranza(); //Importante: Restaura el Objeto del Móludo
            listaDeCobranzaDetalle = new List<CobranzaDetalle>(); //Importante: Restaura la lista de Objetos del Móludo (Detalle)
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(cmbCtaBancaria, new N_Banco().obtenerListaDeElementos(), "S/D"); //Re-Establece los items del ComboBox
            txtCbteTPV.Text = Global.PtoVta.ToString("00000");
            txtCbteNro.Text = "";
            pkrCbteFecha.Text = Fecha.SistemaFecha();
            txtEstado.Text = "ACTIVO";
            txtLiquidacion.Text = "";
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            txtCategoriaIva.Text = "";
            txtConcepto.Text = "";
            chkRetencionIIBB.Checked = false;
            chkRetencionLH.Checked = false;
            chkRetencionIVA.Checked = false;
            chkRetencionGanancia.Checked = false;
            chkRetencionFondoMinero.Checked = false;
            chkRetencionSUSS.Checked = false;
            gridDetalle.Rows.Clear();
            txtMontoBruto.Text = "0,00";
            lblIVA105.Text = "0,00";
            lblIVA210.Text = "0,00";
            lblIVA270.Text = "0,00";
            txtRetencionIIBB.Text = "0,00";
            txtRetencionLH.Text = "0,00";
            txtRetencionIVA.Text = "0,00";
            txtRetencionGanancia.Text = "0,00";
            txtRetencionFondoMinero.Text = "0,00";
            txtRetencionSUSS.Text = "0,00";
            lblTotalRetencion.Text = "0,00";
            lblMontoNeto.Text = "0,00";
            cmbMedioCobro.Text = "EFECTIVO";
            cmbCuentaContable.Text = "CAJA CHICA";
            txtMedioNro.Text = "";
            pkrMedioChequeVto.Value = fechaActual;
            cmbCtaBancaria.SelectedIndex = 0;
            cmbCtaBancariaTipo.Text = "S/D";
            txtCtaBancariaNro.Text = "";
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, txtCuit, txtCategoriaIva,
                cmbMedioCobro , cmbCuentaContable }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(Cobranza objRegistro, List<CobranzaDetalle> detalle) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objCobranzaDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            listaDeCobranzaDetalleDB = detalle; //Importante: Se deben igualar la lista de Objetos precedentes con el actual (evita el error de nulidad) 
            escribirControles(objCobranzaDB, listaDeCobranzaDetalleDB); //Escribe los datos del registro seleccionado
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR CUIT")
            {
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
            {
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA")
            {
                Formulario.Visibilidad(false, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(true, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta }); //Verifica que se ha seleccionado el filtrado por fecha y habilita las casillas "desde y hasta"
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR N° PV - CBTE" || cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR N° LIQUIDACION")
            {
                cmbFiltroLista1.Enabled = false;
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR PERIODO")
            {
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroEstado = "TODOS";
            if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ACTIVO") filtroEstado = "ACTIVO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ANULADO") filtroEstado = "ANULADO";
            if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por CUIT
            {
                consultaCobranza = new string[] { filtroEstado, "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCobranza.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por Denominación
            {
                consultaCobranza = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCobranza.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA") //Verifica que el tipo de filtro es por Fecha de Comprobante
            {
                consultaCobranza = new string[] { filtroEstado, "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nCobranza.obtenerCatalago(filtroEstado, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por ID
            {
                consultaCobranza = new string[] { filtroEstado, "ID", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCobranza.obtenerCatalago(filtroEstado, "ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR N° PV - CBTE" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por ID
            {
                consultaCobranza = new string[] { filtroEstado, "COMPROBANTE", txtFiltroLista.Text.Trim().PadLeft(12,'0') };
                cargarCatalogo(nCobranza.obtenerCatalago(filtroEstado, "COMPROBANTE", txtFiltroLista.Text.Trim().PadLeft(12, '0'), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR N° LIQUIDACION" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por ID
            {
                consultaCobranza = new string[] { filtroEstado, "LIQUIDACION", txtFiltroLista.Text.Trim().PadLeft(12, '0') };
                cargarCatalogo(nCobranza.obtenerCatalago(filtroEstado, "LIQUIDACION", txtFiltroLista.Text.Trim().PadLeft(12, '0'), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objCobranzaDB = nCobranza.obtenerObjeto("ID", idElemento.ToString(), true);
            listaDeCobranzaDetalleDB = nCobranzaDetalle.obtenerObjetos(objCobranzaDB.Id); //Almacena los item de detalle de comprobante
            escribirControles(objCobranzaDB, listaDeCobranzaDetalleDB); //Escribe los datos del registro seleccionado
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                if (consultaCobranza.Length == 3)
                    lista = nCobranza.obtenerCatalago(consultaCobranza[0], consultaCobranza[1], consultaCobranza[2], "CATALOGO1");
                else if (consultaCobranza.Length == 4)
                    lista = nCobranza.obtenerCatalago(consultaCobranza[0], consultaCobranza[1], Fecha.ValidarFecha(consultaCobranza[2]), Fecha.ValidarFecha(consultaCobranza[3]), "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "N° Comprobante",
                    "Fecha",
                    "Estado",
                    "Medio de Cobro",
                    "Monto Cobrado",
                    "Denominación",
                    "CUIT" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //N° Comprobante (PtoVta y Comprobante)
                        campo[1].Trim(), //Fecha
                        campo[2].Trim(), //Estado
                        campo[3].Trim(), //Medio de Cobro
                        "$" + campo[4].Trim(), //Monto Cobrado
                        campo[5].Trim().Substring(0, 35), //Denominación
                        campo[5].Trim().Substring(36, 13) }; //CUIT
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Cobranzas", subTitulos, new int[] { 14, 10, 10, 35, 12, 35, 13 }, _listaDelReporte, new List<int> { 1 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Cobranzas", subTitulos, new float[] { 13, 9, 9, 30, 10, 30, 10 }, _listaDelReporte); //Ancho: 111
            }
        }

        public override void asignarVariablesDeFormulario(string[] variablesDeFormulario) //Método Sobrescribible
        {
            if (variablesDeFormulario[0] == "Catalogo_Cliente") //Catálogo de Clientees
            {
                this.objCliente = new N_Cliente().obtenerObjeto("TODOS", "ID", variablesDeFormulario[1], true);
                if (txtCuit.Text != objCliente.Cuit) gridDetalle.Rows.Clear(); //Verifica si ha cambiado el CUIT. De ser asi, libera la cuadricula de cualquier item anteriormente cargado
                txtDenominacion.Text = objCliente.Denominacion;
                txtCuit.Text = Convert.ToString(objCliente.Cuit);
                txtCategoriaIva.Text = objCliente.Iva;
                cmbCtaBancaria.Text = (!string.IsNullOrWhiteSpace(objCliente.CtaBancariaNro)) ? objCliente.Banco.Denominacion : "S/D";
                cmbCtaBancariaTipo.Text = (!string.IsNullOrWhiteSpace(objCliente.CtaBancariaNro)) ? objCliente.CtaBancariaTipo : "";
                txtCtaBancariaNro.Text = (!string.IsNullOrWhiteSpace(objCliente.CtaBancariaNro)) ? objCliente.CtaBancariaNro : "";
            }
        }
        #endregion
    }
}
