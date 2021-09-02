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
    public partial class FormPagoProveedor : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private bool _montoBruto_ControladorDeModificacionManual = false;
        private string _montoBruto_ControladorDeModificacion = "";
        private string _idCompra_ControladorDeModificacion = "";
        private string[] consultaPagoProveedor;
        private Proveedor objProveedor; //Objeto Maestro
        private PagoProveedor objPagoProveedor;
        private PagoProveedor objPagoProveedorDB;
        private List<PagoProveedorDetalle> listaDePagoProveedorDetalle;
        private List<PagoProveedorDetalle> listaDePagoProveedorDetalleDB;
        private N_Proveedor nProveedor = new N_Proveedor();
        private N_PagoProveedor nPagoProveedor = new N_PagoProveedor();
        private N_PagoProveedorDetalle nPagoProveedorDetalle = new N_PagoProveedorDetalle();
        private string _navCuit = ""; //Sistema de Navegación: Paso1
        private N_AsientoContable nAsientoContable = new N_AsientoContable();
        private N_CuentaContable nCuentaContable = new N_CuentaContable();
        #endregion

        #region Constructores
        public FormPagoProveedor()
        {
            InitializeComponent();
        }
        public FormPagoProveedor(PagoProveedor navPagoProveedor) //Utilizado por el navegador de formularios
        {
            objPagoProveedorDB = objPagoProveedor = navPagoProveedor;
            listaDePagoProveedorDetalleDB = listaDePagoProveedorDetalle = nPagoProveedorDetalle.obtenerObjetos(objPagoProveedorDB.Id);
            InitializeComponent();
        }
        public FormPagoProveedor(string navCuit) //Sistema de Navegación: Paso2
        {
            _navCuit = navCuit;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormPagoProveedor_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(txtCbteTPV, "Punto de compra");
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
            cmbMedioPago.Text = "EFECTIVO"; //Establece el tipo de cuenta 
            Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos( new string[] { "DISPONIBILIDADES > CAJAS" }), 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbCtaBancaria, new N_Banco().obtenerListaDeElementos(), "S/D"); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO",
                "FILTRAR POR ESTADO: ANULADO", "TODOS LOS ESTADOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT",
                "FILTRAR POR DENOMINACION", "FILTRAR POR FECHA", "FILTRAR POR N° PV - CBTE" }, 1); //Establece los items del ComboBox            filtrarCatalogo(0); //Carga el catálogo
            #region Sistema de Navegación: Paso3
            if (!string.IsNullOrEmpty(_navCuit))
            {
                cmbFiltroLista2.Text = "FILTRAR POR CUIT";
                txtFiltroLista.Text = _navCuit;
            }
            #endregion
            filtrarCatalogo(0); //Carga el catálogo
            if (objPagoProveedorDB != null) escribirControles(objPagoProveedorDB, listaDePagoProveedorDetalleDB); //Escribe los datos solicitados mediante la navegación entre formularios
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                new FormCatalogo_Proveedor(this, "FILTRAR POR ESTADO: ACTIVO").ShowDialog(this);
            }
        }

        private void cmbMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMedioPago.Text == "CHEQUE")
            {
                Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(new string[] { "VALORES A DEPOSITAR" }), 0); //Establece los items del ComboBox
                lblMedioNro.Text = "Cheque(nro. - vto.)";
                pkrMedioChequeVto.Text = Fecha.SistemaFecha();
                Formulario.Visibilidad(true, new Control[] { lblMedioNro, txtMedioNro, pkrMedioChequeVto });
                Formulario.Visibilidad(false, new Control[] { lblCtaBancaria, cmbCtaBancaria, btnCtaBancaria, cmbCtaBancariaTipo, txtCtaBancariaNro });
            }
            else if (cmbMedioPago.Text == "EFECTIVO")
            {
                Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(new string[] { "DISPONIBILIDADES > CAJAS" }), 0); //Establece los items del ComboBox
                Formulario.Visibilidad(false, new Control[] { lblMedioNro, txtMedioNro, pkrMedioChequeVto,
                    lblCtaBancaria, cmbCtaBancaria, btnCtaBancaria,
                    cmbCtaBancariaTipo, txtCtaBancariaNro });
            }
            else if (cmbMedioPago.Text == "T.CREDITO" || cmbMedioPago.Text == "T.DEBITO")
            {
                Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(new string[] { "TARJETAS" }), 0); //Establece los items del ComboBox
                Formulario.Visibilidad(false, new Control[] { lblMedioNro, txtMedioNro, pkrMedioChequeVto,
                    lblCtaBancaria, cmbCtaBancaria, btnCtaBancaria,
                    cmbCtaBancariaTipo, txtCtaBancariaNro });
            }
            else if (cmbMedioPago.Text == "TRANSFERENCIA")
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
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) _idCompra_ControladorDeModificacion = Convert.ToString(gridDetalle.CurrentRow.Cells[0].Value); //Verifica que se este dentro de la celda ID y captura el valor inicial del ID 
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
                    gridDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = gridDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().PadLeft(8, '0'); //Formatea el ID de la Compra
                    buscarCompraID(e.RowIndex, Convert.ToString(gridDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)); //Busca el ID ingresado en la Base de Datos
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
                    buscarCompra(gridDetalle);
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
                _idCompra_ControladorDeModificacion = ""; //Importante: Restaura el controlador de modificacion de artículo
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
            buscarCompra(gridDetalle);
            gridDetalle.Focus();
        }
        #endregion

        #region Eventos de Totales
        private void txtMontoBruto_Enter(object sender, EventArgs e)
        {
            _montoBruto_ControladorDeModificacion = txtMontoPagado.Text;
        }

        private void txtMontoBruto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtMontoPagado.Text);
        }

        private void txtMontoBruto_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMontoPagado.Text))
            {
                _montoBruto_ControladorDeModificacionManual = false;
                calcularTotal();
            }
            else if (!string.IsNullOrWhiteSpace(txtMontoPagado.Text) && txtMontoPagado.Text != _montoBruto_ControladorDeModificacion)
            {
                _montoBruto_ControladorDeModificacionManual = true;
                calcularTotal();
            }
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(165))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objPagoProveedor.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(165)) //Verifica que el usuario posea el privilegio requerido
            {
                //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                if (_controladorDeNuevoRegistro && ValidarCampoVacio() && validarCuadricula())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        this.objProveedor = nProveedor.obtenerObjeto("TODOS", "ID", objPagoProveedor.Proveedor.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                        this.listaDePagoProveedorDetalle = new List<PagoProveedorDetalle>(); //Importante: Crea una nueva lista de Objetos por seguridad (libera los residuos de antiguas instancias)
                        objPagoProveedor.Id = nPagoProveedor.generarNumeroID(); //Paso 3: Genera un ID para cada Objeto
                        objPagoProveedor.CbteNro = objPagoProveedor.Id; //Paso 4: Establece el valor del ID como número de comprobante
                        if (nPagoProveedor.insertar(objPagoProveedor)) //Paso 5: Inserta el objeto principal
                        {
                            #region Registra el Detalle
                            long idDetalle = nPagoProveedorDetalle.generarNumeroID(); //Paso 6: Asigna un numero de ID al Objeto
                            foreach (DataGridViewRow fila in gridDetalle.Rows)
                            {
                                Compra objCompra = new N_Compra().obtenerObjeto("ID", Convert.ToString(Convert.ToInt64(fila.Cells[0].Value)), true);
                                objCompra.PagoEstado = fila.Cells[7].Value.ToString().Trim(); //Importante: Actualiza el Estado de PagoProveedor
                                PagoProveedorDetalle objPagoProveedorDetalle = new PagoProveedorDetalle(
                                    idDetalle,
                                    objPagoProveedor,
                                    objCompra);
                                listaDePagoProveedorDetalle.Add(objPagoProveedorDetalle); //Paso 8: Agrega el Objeto en la lista de Objetos
                                idDetalle++; //Paso 9: Importante: Incrementa el valor del ID Detalle
                                    /* Nota: Cuando hay más de un ítem en el detalle: El valor del ID se debe incrementar
                                    * iterativamente ya que el generador no brinda esta solución porque solo puede calcular
                                    * el valor del máximo de ID de los ítems existentes en la Base de Datos. En este caso
                                    * es solo una lista de objetos que aun No han sido insertados).*/
                            }
                            if (nPagoProveedorDetalle.insertar(listaDePagoProveedorDetalle)) actualizarComprobanteDeCompra("REGISTRACION", listaDePagoProveedorDetalle); //Paso 10: Inserta la lista de Objetos en la Base de Datos. De ser corecto, posteriormente actualiza el Estado y la Fecha de PagoProveedor de cada comprobante de venta
                            #endregion
                            calcularCtaCte("REGISTRACION"); //Paso 11: Actualiza la Cta.Cte. del Cliente Personal
                            asentarTransaccion("REGISTRACION"); //Paso 12: Registra el/los Asiento/s Contable/s
                            mostrarRegistro(objPagoProveedor, listaDePagoProveedorDetalle);
                            Mensaje.RegistroCorrecto("REGISTRACION");
                        }
                    }
                }
            }
            else if (objPagoProveedor.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(167)) //Verifica que el usuario posea el privilegio requerido
            {
                //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                if (objPagoProveedor.CbteFecha.AddDays(Global.RegistroModificacion) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                {
                    if (objPagoProveedor.Estado == "ACTIVO") //Verifica si el comprobante esta activo
                    {
                        {
                            if (ValidarCampoVacio())
                            {
                                if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                                {
                                    instanciarObjeto(); //Paso 1: Instancia el Objeto
                                    this.objProveedor = nProveedor.obtenerObjeto("TODOS", "ID", objPagoProveedor.Proveedor.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                                    this.listaDePagoProveedorDetalle = new List<PagoProveedorDetalle>(); //Importante: Crea una nueva lista de Objetos por seguridad (libera los residuos de antiguas instancias)
                                    #region Lectura del Detalle
                                    foreach (DataGridViewRow fila in gridDetalle.Rows)
                                    {
                                        Compra objCompra = new N_Compra().obtenerObjeto("ID", Convert.ToString(Convert.ToInt64(fila.Cells[0].Value)), true); //Paso 3: Importante: Re-Almacena el Objeto de la Base de Datos
                                        objCompra.PagoEstado = fila.Cells[7].Value.ToString().Trim(); //Importante: Actualiza el Estado de PagoProveedor                                      
                                        PagoProveedorDetalle objPagoProveedorDetalle = new PagoProveedorDetalle(
                                            Convert.ToInt64(fila.Cells[8].Value),
                                            objPagoProveedor,
                                            objCompra);
                                        listaDePagoProveedorDetalle.Add(objPagoProveedorDetalle); //Paso 4: Agrega el Objeto en la lista de Objetos
                                    }
                                    #endregion
                                    if (!objPagoProveedor.Equals(objPagoProveedorDB) || !nPagoProveedorDetalle.compararDetalle(listaDePagoProveedorDetalleDB, listaDePagoProveedorDetalle)) //Paso 5: Verifica que el Objeto y/o Detalle se han modificado 
                                    {
                                        if (nPagoProveedor.actualizar(objPagoProveedor)) //Paso 6: Actualiza el Objeto y Detalle
                                        {
                                            if (nPagoProveedorDetalle.actualizar(listaDePagoProveedorDetalle)) actualizarComprobanteDeCompra("MODIFICACION", listaDePagoProveedorDetalle); //Paso 7: Actualiza la lista de Objetos en la Base de Datos. De ser corecto, posteriormente actualiza el Estado y la Fecha de PagoProveedor de cada comprobante de venta
                                            calcularCtaCte("MODIFICACION"); //Paso 8: Actualiza la Cta.Cte. del Cliente Personal
                                            asentarTransaccion("MODIFICACION"); //Paso 9: Registra el/los Asiento/s Contable/s
                                            mostrarRegistro(objPagoProveedor, listaDePagoProveedorDetalle);
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
                    cmbMedioPago , cmbCuentaContable  }) && Formulario.ValidarNumeroDoble(txtMontoPagado.Text) > 0;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objPagoProveedor.Id > 0) escribirControles(objPagoProveedorDB, listaDePagoProveedorDetalleDB); //Restaura los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(166)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objPagoProveedor.Id > 0)
                {
                    if (objPagoProveedor.CbteFecha.AddDays(Global.RegistroAnulacion) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea anular el registro ID: " + objPagoProveedor.Id.ToString() + "?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            this.objProveedor = nProveedor.obtenerObjeto("TODOS", "ID", objPagoProveedor.Proveedor.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                            if (nPagoProveedor.anular(objPagoProveedor)) //Paso 3: Verifica el exito de la actualización y muestra los datos actualizados
                            {
                                objPagoProveedor.Estado = "ANULADO"; //Paso 4: Importante: Establece el cambio de estado en el Objeto del Módulo 
                                actualizarComprobanteDeCompra("ANULACION", listaDePagoProveedorDetalle); //Paso 5: Actualiza el Estado y la Fecha de PagoProveedor de cada comprobante de venta
                                calcularCtaCte("ANULACION"); //Paso 6: Actualiza la Cta.Cte. del Cliente Personal
                                asentarTransaccion("ANULACION"); //Paso 7: Registra el/los Asiento/s Contable/s         
                                mostrarRegistro(objPagoProveedor, listaDePagoProveedorDetalleDB);
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
            if (objPagoProveedor.Id > 0)
            {
                if (objPagoProveedor.Estado == "ACTIVO") //Verifica si el comprobante esta activo
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string conceptoDetalle = "";
                    string ctaBancariaDenominacion = (objPagoProveedor.Banco != null) ? " - " + objPagoProveedor.Banco.Denominacion : "";
                    string ctaBancariaTipo = (objPagoProveedor.Banco != null && objPagoProveedor.CtaBancariaTipo != "S/D") ? " " + objPagoProveedor.CtaBancariaTipo : "";
                    string ctaBancariaNumero = (objPagoProveedor.Banco != null && !string.IsNullOrEmpty(objPagoProveedor.CtaBancariaNro.Trim())) ? " N°" + objPagoProveedor.CtaBancariaNro.PadLeft(10, '0') : "";
                    foreach (DataGridViewRow fila in gridDetalle.Rows) conceptoDetalle += "\n" + fila.Cells[1].Value; //Agrega el Detalle del Comprobante al concepto
                    string[] datoDB = {
                        objPagoProveedor.CbteTPV.ToString().PadLeft(5, '0') + "-" + objPagoProveedor.CbteNro.ToString().PadLeft(8, '0'),
                        objPagoProveedor.Proveedor.Denominacion,
                        Convert.ToInt64(objPagoProveedor.Proveedor.Cuit).ToString("00-00000000/0"),
                        Fecha.ConvertirFecha_Escrita(objPagoProveedor.CbteFecha),
                        Formulario.ValidarCampoMoneda(objPagoProveedor.MontoPagado),
                        Formulario.GenerarNumeroTextual(Formulario.ValidarCampoMoneda(objPagoProveedor.MontoPagado)),
                        (objPagoProveedor.Concepto + conceptoDetalle).ToUpper(),
                        objPagoProveedor.MedioPago + " " + ((objPagoProveedor.MedioPago == "CHEQUE") ? "N°" + Convert.ToString(objPagoProveedor.MedioNro).PadLeft(8, '0')  + " CON FECHA DE COBRO " + Fecha.ConvertirFecha(objPagoProveedor.MedioChequeVto) + " (" + objPagoProveedor.CuentaContable.Denominacion + ")"
                            : ((objPagoProveedor.MedioPago == "TRANSFERENCIA") ? "N°" + Convert.ToString(objPagoProveedor.MedioNro).PadLeft(8, '0')  + ctaBancariaDenominacion + ctaBancariaTipo + ctaBancariaNumero  : "")) };
                    Reporte reporte = new Reporte();
                    reporte.crearDocumentoWord_AcusePago(objPagoProveedor.Proveedor.Denominacion, datoDB);
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
                gridDetalle.Rows.Add("", "", "0,00", "0,00", "0,00", "0,00", "0,00", "S/PAGAR");
                gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                gridDetalle.FirstDisplayedScrollingRowIndex = gridDetalle.RowCount - 1; //Posiciona el scroll del gridDetalle en la celda seleccionada
                SendKeys.Send("{DOWN}"); //Mueve el foco a la nueva fila  
            }
        }

        private void agregarFilas(List<PagoProveedorDetalle> detalle)
        {
            gridDetalle.Rows.Clear();
            foreach (PagoProveedorDetalle item in detalle)
            {
                gridDetalle.Rows.Add();
                gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                gridDetalle.CurrentRow.Cells[0].Value = Convert.ToString(item.Compra.Id).PadLeft(8, '0');
                gridDetalle.CurrentRow.Cells[1].Value = Formulario.GenerarTipoComprobante(item.Compra.AfipCbteTipo) + "  N°" + Convert.ToString(item.Compra.AfipCbteTPV).PadLeft(5, '0') + "-" + Convert.ToString(item.Compra.AfipCbteNro).PadLeft(8, '0') + " " + Fecha.ConvertirFecha(item.Compra.AfipCbteFecha);
                gridDetalle.CurrentRow.Cells[2].Value = Formulario.ValidarCampoMoneda(item.Compra.Subtotal);
                gridDetalle.CurrentRow.Cells[3].Value = Formulario.ValidarCampoMoneda(item.Compra.Iva105 + item.Compra.Iva210 + item.Compra.Iva270);
                gridDetalle.CurrentRow.Cells[4].Value = Formulario.ValidarCampoMoneda(item.Compra.PercepcionIIBB + item.Compra.PercepcionLH + item.Compra.PercepcionIVA);
                gridDetalle.CurrentRow.Cells[5].Value = Formulario.ValidarCampoMoneda(item.Compra.NoGravado);
                gridDetalle.CurrentRow.Cells[6].Value = Formulario.ValidarCampoMoneda(item.Compra.Total);
                gridDetalle.CurrentRow.Cells[7].Value = Convert.ToString(item.Compra.PagoEstado);
                gridDetalle.CurrentRow.Cells[8].Value = Formulario.ValidarNumeroEntero64(Convert.ToString(item.Id)); //Importante: Almacena el Id Detalle para identificar el ítem ante una posible modificación
            }
            if (gridDetalle.CurrentCell != null) gridDetalle.CurrentCell.Selected = false; //Quita la selección de la celda
        }

        private void buscarCompra(DataGridView cuadricula) //Método que busca una compra
        {
            if (_controladorDeNuevoRegistro)
            {
                FormCatalogo_Compra frm = new FormCatalogo_Compra(this, txtCuit.Text.Trim());
                frm.ShowDialog(this); //Abre el Catálogo de Compras
                if (cuadricula.Rows.Count > 0)
                {
                    var posicion = cuadricula.CurrentRow.Cells[0]; //Posicionamiento - Paso 1: proceso de reposicionamiento
                    cuadricula.CurrentCell = null; //Posicionamiento - Paso 2: proceso de reposicionamiento
                    cuadricula.CurrentCell = posicion; //Posicionamiento - Paso 3: proceso de reposicionamiento
                }
            }
            calcularTotal();
        }

        private void buscarCompraID(int indiceFila, string idCompra) //Método que busca una compra por ID
        {
            if (_controladorDeNuevoRegistro)
            {
                if (string.IsNullOrEmpty(idCompra)) //Verifica que el ID recibido sea nulo o vacío
                {
                    escribirFila(indiceFila, "", null, true);
                }
                else
                {
                    idCompra = idCompra.PadLeft(8, '0'); //Formatea el ID recibido
                    if (idCompra != _idCompra_ControladorDeModificacion) //Verifica que el ID recibido ha sido modificado
                    {
                        if (idCompra == "00000000") //Verifica que el ID recibido es un ID cero (Editable)
                        {
                            escribirFila(indiceFila, "00000000", null, false);
                        }
                        else
                        {
                            Compra objCompra = new N_Compra().obtenerObjeto("ID", idCompra, true, txtCuit.Text.Trim()); //Consulta que ejecuta una busqueda en la Base de Datos
                            if (objCompra != null) //Verifica que el resultado de la consulta tenga exito
                            {
                                escribirFila(indiceFila, idCompra, objCompra, true);
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

        private void calcularTotal()
        {
            double totalNeto = 0.00;
            foreach (DataGridViewRow row in gridDetalle.Rows) //Recorre la cuadricula y suma los valores de las celdas indicadas 
            {
                totalNeto += Formulario.ValidarNumeroDoble(row.Cells[6].Value.ToString());
            }
            if (_montoBruto_ControladorDeModificacionManual) txtMontoPagado.Text = Formulario.ValidarCampoMoneda(Math.Round(Formulario.ValidarNumeroDoble(txtMontoPagado.Text), 2));
            else txtMontoPagado.Text = Formulario.ValidarCampoMoneda(Math.Round(totalNeto, 2));
        }

        private void escribirFila(int indiceFila, string idCompra, Compra objCompra, bool actividad)
        {
            gridDetalle.Rows[indiceFila].Cells[0].Value = idCompra;
            gridDetalle.Rows[indiceFila].Cells[1].Value = (objCompra != null) ? Formulario.GenerarTipoComprobante(objCompra.AfipCbteTipo) + "  N°" + Convert.ToString(objCompra.AfipCbteTPV).PadLeft(5, '0') + "-" + Convert.ToString(objCompra.AfipCbteNro).PadLeft(8, '0') + " " + Fecha.ConvertirFecha(objCompra.AfipCbteFecha) : "";
            gridDetalle.Rows[indiceFila].Cells[2].Value = (objCompra != null) ? Formulario.ValidarCampoMoneda(objCompra.Subtotal) : "0,00";
            gridDetalle.Rows[indiceFila].Cells[3].Value = (objCompra != null) ? Formulario.ValidarCampoMoneda(objCompra.Iva105 + objCompra.Iva210 + objCompra.Iva270) : "0,00";
            gridDetalle.Rows[indiceFila].Cells[4].Value = (objCompra != null) ? Formulario.ValidarCampoMoneda(objCompra.PercepcionIIBB + objCompra.PercepcionLH + objCompra.PercepcionIVA) : "0,00";
            gridDetalle.Rows[indiceFila].Cells[5].Value = (objCompra != null) ? Formulario.ValidarCampoMoneda(objCompra.NoGravado) : "0,00";
            gridDetalle.Rows[indiceFila].Cells[6].Value = (objCompra != null) ? Formulario.ValidarCampoMoneda(objCompra.Total) : "0,00";
            gridDetalle.Rows[indiceFila].Cells[7].Value = (objCompra != null) ? Convert.ToString(objCompra.PagoEstado) : "S/PAGAR";
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
            if (variablesDeFormulario[0] == "Catalogo_Compra") //Catálogo de Compras
            {
                if (gridDetalle.Rows.Count > 0) // Verifica que No este vacia la cuadricula
                {
                    Compra compra = new N_Compra().obtenerObjeto("ID", variablesDeFormulario[1], false);
                    gridDetalle.CurrentRow.SetValues(
                        Convert.ToString(compra.Id).PadLeft(8, '0'),
                        Formulario.GenerarTipoComprobante(compra.AfipCbteTipo) + "  N°" + Convert.ToString(compra.AfipCbteTPV).PadLeft(5, '0') + "-" + Convert.ToString(compra.AfipCbteNro).PadLeft(8, '0') + " " + Fecha.ConvertirFecha(compra.AfipCbteFecha),
                        Formulario.ValidarCampoMoneda(compra.Subtotal),
                        Formulario.ValidarCampoMoneda(compra.Iva105 + compra.Iva210 + compra.Iva270),
                        Formulario.ValidarCampoMoneda(compra.PercepcionIIBB + compra.PercepcionLH + compra.PercepcionIVA),
                        Formulario.ValidarCampoMoneda(compra.NoGravado),
                        Formulario.ValidarCampoMoneda(compra.Total),
                        Convert.ToString(compra.PagoEstado));
                }
            }
        }
        #endregion

        #region Métodos de Formulario
        private void actualizarComprobanteDeCompra(string operacion, List<PagoProveedorDetalle> detalle)
        {
            if (detalle.Count > 0)
            {
                DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual            
                foreach (PagoProveedorDetalle objPagoProveedorDetalle in detalle)
                {
                    if (operacion == "REGISTRACION" || operacion == "MODIFICACION")
                    {
                        objPagoProveedorDetalle.Compra.PagoVto = fechaActual; //Fecha de PagoProveedor
                        objPagoProveedorDetalle.Compra.PagoAlertado = (objPagoProveedorDetalle.Compra.PagoEstado == "PAGADO") ? true : false; //Resetea el estado de alerta de PagoProveedor
                    }
                    else if (operacion == "ANULACION")
                    {
                        objPagoProveedorDetalle.Compra.PagoEstado = "S/PAGAR"; //Estado de PagoProveedor
                        objPagoProveedorDetalle.Compra.PagoAlertado = false; //Resetea el estado de alerta de PagoProveedor
                    }
                    objPagoProveedorDetalle.Compra.PagoAlertado = (objPagoProveedorDetalle.Compra.PagoVto <= fechaActual) ? true : false; //Evalua la alerta de PagoProveedor
                    new N_Compra().actualizar(objPagoProveedorDetalle.Compra);
                }
            }
        }

        private void asentarTransaccion(string operacion)
        {
            AsientoContable objAsientoContable = new AsientoContable();
            double montoPagado = Formulario.ValidarNumeroDoble(txtMontoPagado.Text);
            objAsientoContable.AsientoFecha = pkrCbteFecha.Value;
            objAsientoContable.Descripcion = "Pago Prov.: REC-X N°" + Convert.ToString(objPagoProveedor.CbteTPV).PadLeft(5, '0') + "-" + Convert.ToString(objPagoProveedor.CbteNro).PadLeft(8, '0');
            objAsientoContable.OrigenTipo = "PAP";
            objAsientoContable.OrigenId = objPagoProveedor.Id;
            if (operacion == "REGISTRACION") objAsientoContable.AsientoNro = nAsientoContable.generarNumeroAsiento(); //Verifica que es un nuevo comprobante. Si es asi, genera un nuevo Número de Asiento
            else
            {
                AsientoContable objAsientoContablePrecedente = nAsientoContable.obtenerObjeto("PAP", objPagoProveedor.Id); //Paso 1: En el caso de una modificación o anulación, obtiene el Asiento registrado precedentemente
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
                    new string[] { cmbCuentaContable.Text, "PROVEEDORES" },
                    new double[] { montoPagado, montoPagado },
                    new string[] { "HABER", "DEBE" },
                    new string[] { "S/CONCILIAR", "NO-APLICA" });
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
            double montoPagado = Formulario.ValidarNumeroDoble(txtMontoPagado.Text);
            double saldo = objProveedor.Saldo;
            if (operacion == "REGISTRACION") saldo = (saldo - montoPagado); //Resta el monto pagado al saldo de la Cta.Cte. del Proveedor 
            else if (operacion == "MODIFICACION") saldo = ((saldo + objPagoProveedorDB.MontoPagado) - montoPagado); //Suma el monto pagado precedentemente al saldo de la Cta.Cte. del Proveedor 
            else if (operacion == "ANULACION") saldo = (saldo + montoPagado); //Suma el monto pagado del saldo la Cta.Cte. del Proveedor 
            nProveedor.actualizarSaldo(objProveedor.Id, saldo, false); //Actualiza el saldo en la Cta.Cte. del Proveedor 
            this.objProveedor.Saldo = saldo; //Importante: Actualiza el saldo del Objeto Maestro
        }

        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(PagoProveedor objRegistro, List<PagoProveedorDetalle> detalle)
        {
            this.objPagoProveedor = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            this.listaDePagoProveedorDetalle = detalle; //Iguala el Atributo de la clase con la lista de Objetos recibidos
            if (objPagoProveedor != null)
            {
                _controladorDeNuevoRegistro = false;
                txtCbteTPV.Text = Convert.ToString(objPagoProveedor.CbteTPV).PadLeft(5, '0');
                txtCbteNro.Text = Convert.ToString(objPagoProveedor.CbteNro).PadLeft(8, '0');
                pkrCbteFecha.Value = objPagoProveedor.CbteFecha;
                txtEstado.Text = objPagoProveedor.Estado;
                objProveedor = objPagoProveedor.Proveedor;
                txtDenominacion.Text = objPagoProveedor.Proveedor.Denominacion;
                txtCuit.Text = objPagoProveedor.Proveedor.Cuit;
                txtCategoriaIva.Text = objPagoProveedor.Proveedor.Iva;
                txtConcepto.Text = objPagoProveedor.Concepto;
                agregarFilas(listaDePagoProveedorDetalle); //Escribe los item en el detalle de comprobante
                txtMontoPagado.Text = Formulario.ValidarCampoMoneda(Convert.ToString(objPagoProveedor.MontoPagado));
                cmbMedioPago.Text = objPagoProveedor.MedioPago;
                cmbCuentaContable.Text = (objPagoProveedor.CuentaContable != null) ? objPagoProveedor.CuentaContable.Denominacion : "";
                txtMedioNro.Text = (objPagoProveedor.MedioPago == "CHEQUE" || objPagoProveedor.MedioPago == "TRANSFERENCIA") ? Convert.ToString(objPagoProveedor.MedioNro).PadLeft(8, '0') : "";
                pkrMedioChequeVto.Value = objPagoProveedor.MedioChequeVto;
                cmbCtaBancaria.Text = (objPagoProveedor.Banco != null && objPagoProveedor.Banco.Id > 0) ? objPagoProveedor.Banco.Denominacion : "S/D";
                cmbCtaBancariaTipo.Text = (objPagoProveedor.Banco != null) ? objPagoProveedor.CtaBancariaTipo : "S/D";
                txtCtaBancariaNro.Text = (objPagoProveedor.Banco != null) ? Convert.ToString(objPagoProveedor.CtaBancariaNro).PadLeft(10, '0') : "";
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objPagoProveedor.EdicionFecha) + " por " + objPagoProveedor.EdicionUsuarioDenominacion;
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objPagoProveedor = new PagoProveedor(
                (objPagoProveedor.Id <= 0) ? 0 : objPagoProveedor.Id,
                Convert.ToInt32(Global.PtoVta),
                Formulario.ValidarNumeroEntero64(txtCbteNro.Text),
                pkrCbteFecha.Value,
                txtEstado.Text,
                objProveedor,
                txtConcepto.Text,
                Formulario.ValidarNumeroDoble(txtMontoPagado.Text),
                new N_CuentaContable().obtenerObjeto("DENOMINACION", cmbCuentaContable.Text),
                cmbMedioPago.Text,
                Formulario.ValidarNumeroEntero64(txtMedioNro.Text),
                pkrMedioChequeVto.Value,
                (cmbCtaBancaria.Text != "S/D" && (cmbMedioPago.Text == "CHEQUE" || cmbMedioPago.Text == "TRANSFERENCIA")) ? new N_Banco().obtenerObjeto("DENOMINACION", cmbCtaBancaria.Text, false) : new Banco(0, ""),
                (cmbMedioPago.Text == "TRANSFERENCIA") ? cmbCtaBancariaTipo.Text : "S/D",
                (cmbMedioPago.Text == "CHEQUE" || cmbMedioPago.Text == "TRANSFERENCIA") ? txtCtaBancariaNro.Text.PadLeft(10, '0') : "",
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objProveedor = new Proveedor(); //Restaura el Objeto maestro
            objPagoProveedor = new PagoProveedor(); //Importante: Restaura el Objeto del Móludo
            listaDePagoProveedorDetalle = new List<PagoProveedorDetalle>(); //Importante: Restaura la lista de Objetos del Móludo (Detalle)
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(cmbCtaBancaria, new N_Banco().obtenerListaDeElementos(), "S/D"); //Re-Establece los items del ComboBox
            txtCbteTPV.Text = Global.PtoVta.ToString("00000");
            txtCbteNro.Text = "";
            pkrCbteFecha.Text = Fecha.SistemaFecha();
            txtEstado.Text = "ACTIVO";
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            txtCategoriaIva.Text = "";
            txtConcepto.Text = "";
            gridDetalle.Rows.Clear();
            txtMontoPagado.Text = "0,00";
            cmbMedioPago.Text = "EFECTIVO";
            cmbCuentaContable.Text = "CAJA CHICA";
            txtMedioNro.Text = "";
            pkrMedioChequeVto.Value = fechaActual;
            cmbCtaBancaria.Text = "S/D";
            cmbCtaBancariaTipo.Text = "S/D";
            txtCtaBancariaNro.Text = "";
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, txtCuit, txtCategoriaIva,
                cmbMedioPago , cmbCuentaContable }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(PagoProveedor objRegistro, List<PagoProveedorDetalle> detalle) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objPagoProveedorDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            listaDePagoProveedorDetalleDB = detalle; //Importante: Se deben igualar la lista de Objetos precedentes con el actual (evita el error de nulidad) 
            escribirControles(objPagoProveedorDB, listaDePagoProveedorDetalleDB); //Escribe los datos del registro seleccionado
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
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR N° PV - CBTE")
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
                consultaPagoProveedor = new string[] { filtroEstado, "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nPagoProveedor.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por Denominación
            {
                consultaPagoProveedor = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nPagoProveedor.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA") //Verifica que el tipo de filtro es por Fecha de Comprobante
            {
                consultaPagoProveedor = new string[] { filtroEstado, "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nPagoProveedor.obtenerCatalago(filtroEstado, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por ID
            {
                consultaPagoProveedor = new string[] { filtroEstado, "ID", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nPagoProveedor.obtenerCatalago(filtroEstado, "ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR N° PV - CBTE" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por ID
            {
                consultaPagoProveedor = new string[] { filtroEstado, "COMPROBANTE", txtFiltroLista.Text.Trim().PadLeft(12,'0') };
                cargarCatalogo(nPagoProveedor.obtenerCatalago(filtroEstado, "COMPROBANTE", txtFiltroLista.Text.Trim().PadLeft(12, '0'), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objPagoProveedorDB = nPagoProveedor.obtenerObjeto("ID", idElemento.ToString(), true);
            listaDePagoProveedorDetalleDB = nPagoProveedorDetalle.obtenerObjetos(objPagoProveedorDB.Id); //Almacena los item de detalle de comprobante
            escribirControles(objPagoProveedorDB, listaDePagoProveedorDetalleDB); //Escribe los datos del registro seleccionado
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                if (consultaPagoProveedor.Length == 3)
                    lista = nPagoProveedor.obtenerCatalago(consultaPagoProveedor[0], consultaPagoProveedor[1], consultaPagoProveedor[2], "CATALOGO1");
                else if (consultaPagoProveedor.Length == 4)
                    lista = nPagoProveedor.obtenerCatalago(consultaPagoProveedor[0], consultaPagoProveedor[1], Fecha.ValidarFecha(consultaPagoProveedor[2]), Fecha.ValidarFecha(consultaPagoProveedor[3]), "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "N° Comprobante",
                    "Fecha",
                    "Estado",
                    "Medio de Pago",
                    "Monto Pagado",
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
                        campo[3].Trim(), //Medio de Pago
                        "$" + campo[4].Trim(), //Monto Pagado
                        campo[5].Trim().Substring(0, 35), //Denominación
                        campo[5].Trim().Substring(36, 13) }; //CUIT
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Pagos a Proveedores", subTitulos, new int[] { 14, 10, 10, 35, 12, 35, 13 }, _listaDelReporte, new List<int> { 1 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Pagos a Proveedores", subTitulos, new float[] { 13, 9, 9, 30, 10, 30, 10 }, _listaDelReporte); //Ancho: 111
            }
        }

        public override void asignarVariablesDeFormulario(string[] variablesDeFormulario) //Método Sobrescribible
        {
            if (variablesDeFormulario[0] == "Catalogo_Proveedor") //Catálogo de Proveedores
            {
                this.objProveedor = new N_Proveedor().obtenerObjeto("ACTIVO", "ID", variablesDeFormulario[1], true);
                if (txtCuit.Text != objProveedor.Cuit) gridDetalle.Rows.Clear(); //Verifica si ha cambiado el CUIT. De ser asi, libera la cuadricula de cualquier item anteriormente cargado
                txtDenominacion.Text = objProveedor.Denominacion;
                txtCuit.Text = Convert.ToString(objProveedor.Cuit);
                txtCategoriaIva.Text = objProveedor.Iva;
                cmbCtaBancaria.Text = (!string.IsNullOrWhiteSpace(objProveedor.CtaBancariaNro)) ? objProveedor.Banco.Denominacion : "S/D";
                cmbCtaBancariaTipo.Text = (!string.IsNullOrWhiteSpace(objProveedor.CtaBancariaNro)) ? objProveedor.CtaBancariaTipo : "";
                txtCtaBancariaNro.Text = (!string.IsNullOrWhiteSpace(objProveedor.CtaBancariaNro)) ? objProveedor.CtaBancariaNro : "";
            }
        }
        #endregion
    }
}
