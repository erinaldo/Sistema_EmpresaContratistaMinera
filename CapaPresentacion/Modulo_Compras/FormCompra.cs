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
    public partial class FormCompra : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private string _idArticulo_ControladorDeModificacion = "";
        private string _pagoEstado = "";
        private string _primerElemento_CentroDeCosto = new N_CentroCosto().obtenerListaDeElementos(new string[] { })[0]; //Primer elemento de la lista de Centro de Costos
        string[] consultaCompra;
        private Proveedor objProveedor;
        private Compra objCompra;
        private Compra objCompraDB;
        private List<CompraDetalle> listaDeCompraDetalle;
        private List<CompraDetalle> listaDeCompraDetalleDB;
        private N_Articulo nArticulo = new N_Articulo();
        private N_Proveedor nProveedor = new N_Proveedor();
        private N_Compra nCompra = new N_Compra();
        private N_CompraDetalle nCompraDetalle = new N_CompraDetalle();
        private N_AsientoContable nAsientoContable = new N_AsientoContable();
        private N_CuentaContable nCuentaContable = new N_CuentaContable();
        #endregion

        #region Constructores
        public FormCompra()
        {
            InitializeComponent();
        }
        public FormCompra(Compra navCompra) //Utilizado por el navegador de formularios
        {
            objCompraDB = objCompra = navCompra;
            listaDeCompraDetalleDB = listaDeCompraDetalle = nCompraDetalle.obtenerObjetos(objCompraDB.Id);
            InitializeComponent();
        }
        #endregion

        #region Eventos de Formulario
        private void FormCompra_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(txtID, "Número de registro interno");
            toolTip.SetToolTip(txtFecha, "Fecha de registro interno");
            toolTip.SetToolTip(cmbAfipCbteTipo, "Tipo de comprobante");
            toolTip.SetToolTip(txtAfipCbteTPV, "Punto de compra de comprobante");
            toolTip.SetToolTip(txtAfipCbteNro, "Número de comprobante");
            toolTip.SetToolTip(pkrAfipCbteFecha, "Fecha de comprobante");
            toolTip.SetToolTip(cmbPeriodo, "Periodo contable - Mes");
            toolTip.SetToolTip(txtPeriodo, "Periodo contable - Año");
            toolTip.SetToolTip(btnAgregarFila, "Agrega una fila a la cuadricula");
            toolTip.SetToolTip(btnQuitarFila, "Quita una fila de la cuadricula");
            toolTip.SetToolTip(btnBuscarFila, "Busca un artículo y lo agrega en la cuadricula");
            toolTip.SetToolTip(btnNuevo, "Crea un nuevo registro");
            toolTip.SetToolTip(btnGuardar, "Guarda los cambios realizados");
            toolTip.SetToolTip(btnCancelar, "Deshace los cambios realizados");
            toolTip.SetToolTip(btnAnular, "Anular un registro");
            #endregion
            #region Tipo de Datos
            gridDetalle.Columns[0].ValueType = typeof(System.String);
            gridDetalle.Columns[1].ValueType = typeof(System.String);
            gridDetalle.Columns[2].ValueType = typeof(System.Int32);
            gridDetalle.Columns[5].ValueType = typeof(System.Decimal);
            gridDetalle.Columns[7].ValueType = typeof(System.Decimal);
            gridDetalle.Columns[8].ValueType = typeof(System.Decimal);
            #endregion
            Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(
                new string[] { "ACTIVO CORRIENTE > BIENES DE USO", "ACTIVO CORRIENTE > BIENES DE CAMBIO", "EGRESOS > OTROS EGRESOS" }), 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(ColCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { })); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "TODOS LOS COMPROBANTES" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT",
                "FILTRAR POR DENOMINACION", "FILTRAR POR FECHA (CBTE)", "FILTRAR POR ID", "FILTRAR POR N° PV - CBTE",
                "FILTRAR POR PERIODO", "FILTRAR POR VTO. DE PAGO" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
            if (objCompraDB != null) escribirControles(objCompraDB, listaDeCompraDetalleDB); //Escribe los datos solicitados mediante la navegación entre formularios
        }

        private void cmbAfipCbteTipo_TextChanged(object sender, EventArgs e)
        {
            determinarIVA();
        }

        private void txtAfipCbteTPV_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoNumerico(e, txtAfipCbteTPV.Text);
        }

        private void txtAfipCbteTPV_Validated(object sender, EventArgs e)
        {
            txtAfipCbteTPV.Text = txtAfipCbteTPV.Text.PadLeft(5, '0');
        }

        private void txtAfipCbteNro_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoNumerico(e, txtAfipCbteNro.Text);
        }

        private void txtAfipCbteNro_Validated(object sender, EventArgs e)
        {
            txtAfipCbteNro.Text = txtAfipCbteNro.Text.PadLeft(8, '0');
        }

        private void txtNumeroCodigoBarras_Click(object sender, EventArgs e)
        {
            txtNumeroCodigoBarras.SelectAll();
        }

        private void txtNumeroCodigoBarras_Validated(object sender, EventArgs e)
        {
            string codigoBarra = txtNumeroCodigoBarras.Text.Trim();
            if (codigoBarra.Length == 42)
            {
                cmbAfipCbteTipo.Text = Formulario.GenerarTipoComprobante(Formulario.ValidarNumeroEntero(codigoBarra.Substring(11, 3)));
                txtAfipCbteTPV.Text = codigoBarra.Substring(14, 5);
                buscarProveedorCUIT(codigoBarra.Substring(0, 11));
            }
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                FormCatalogo_Proveedor frm = new FormCatalogo_Proveedor(this, "ACTIVO");
                frm.ShowDialog(this);
            }
        }

        private void btnBuscarAsociacion_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                FormCatalogo_Compra frm = new FormCatalogo_Compra(this);
                frm.ShowDialog(this);
            }
        }

        private void btnQuitarAsociacion_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                txtAsociacionID.Text = "";
                txtAsociacionID.Text = "";
                txtAsociacionAfipCbteTipo.Text = "";
                txtAsociacionAfipCbteTPV.Text = "";
                txtAsociacionAfipCbteNro.Text = "";
                txtAsociacionAfipCbteFecha.Text = "";
                objProveedor = new Proveedor();
                txtDenominacion.Text = "";
                txtCuit.Text = "";
                txtCategoriaIva.Text = "";
                cmbCuentaContable.Text = "COMPRA DE SERVICIOS";
                gridDetalle.Rows.Clear(); //Borra todas la filas de la cuadricula y agrega una nueva fila vacia            }
                lblDescuentoPorcentual.Text = "0,00";
                txtDescuento.Text = "0,00";
                lblSubTotal.Text = "0,00";
                lblIVA105.Text = "0,00";
                lblIVA210.Text = "0,00";
                lblIVA270.Text = "0,00";
                txtPercepcionIIBB.Text = "0,00";
                txtPercepcionLH.Text = "0,00";
                txtPercepcionIVA.Text = "0,00";
                txtNoGravado.Text = "0,00";
                lblTotal.Text = "0,00";
            }
        }
        #endregion

        #region Eventos de Cuadricula
        private void gridDetalle_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) _idArticulo_ControladorDeModificacion = Convert.ToString(gridDetalle.CurrentRow.Cells[0].Value); //Verifica que se este dentro de la celda ID y captura el valor inicial del ID 
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0) gridDetalle.CurrentRow.Cells[1].ReadOnly = (gridDetalle.CurrentCell.Value != null && gridDetalle.CurrentRow.Cells[0].Value.ToString() == "000000") ? false : true; //Verifica que se este dentro de la celda Denominación. En caso de haber un código cero, permite la modificación de la denominación del artículo
            else if ((e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 6 || e.ColumnIndex == 9) && e.RowIndex >= 0)
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
                    if (Convert.ToString(gridDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).Length <= 6) gridDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = gridDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().PadLeft(6, '0'); //Formatea el código del artículo cuando es un ID
                    buscarArticuloID(e.RowIndex, Convert.ToString(gridDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value).Trim()); //Busca el código ingresado en la Base de Datos
                    if (e.RowIndex != (gridDetalle.RowCount - 1)) SendKeys.Send("{UP}"); //Bloque 1a: Mantiene el foco en la celda editada
                }
                else if ((e.ColumnIndex == 2 || e.ColumnIndex == 5) && e.RowIndex >= 0) //Verifica que se este dentro de la celda "Cantidad" ó "Costo Unitario" ó "Alícuota IVA" 
                {
                    if (e.RowIndex != (gridDetalle.RowCount - 1)) SendKeys.Send("{UP}"); //Bloque 1b: Mantiene el foco en la celda editada
                    calcularNeto(e.RowIndex); //Calcula el "Costo Neto" de la fila
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

        private void gridDetalle_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridDetalle.CurrentCell.Value = gridDetalle.CurrentCell.EditedFormattedValue; //Importante: Actualiza el valor con el valor de edición 
            calcularNeto(gridDetalle.CurrentRow.Index); //Re-Calcula el Costo Neto y totales           
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
            if (gridDetalle.Columns[gridDetalle.CurrentCell.ColumnIndex].Index == 3 || gridDetalle.Columns[gridDetalle.CurrentCell.ColumnIndex].Index == 4 
                || gridDetalle.Columns[gridDetalle.CurrentCell.ColumnIndex].Index == 6 || gridDetalle.Columns[gridDetalle.CurrentCell.ColumnIndex].Index == 9)
            {
                DataGridViewComboBoxEditingControl cmbCuadricula = e.Control as DataGridViewComboBoxEditingControl; //Convierte el control en un comboBox
                cmbCuadricula.KeyDown -= new KeyEventHandler(gridDetalle_ComboBox_KeyDown); //Paso 1: Elimina la redundancia del delegado del evento KeyDown
                cmbCuadricula.KeyDown += new KeyEventHandler(gridDetalle_ComboBox_KeyDown); //Paso 2: Agrega el delegado del evento KeyDown
                if (gridDetalle.Columns[gridDetalle.CurrentCell.ColumnIndex].Index == 6)
                {
                    cmbCuadricula.SelectedValueChanged -= new EventHandler(gridDetalle_ComboBox_SelectedIndexChanged); //Paso 1: Elimina la redundancia del delegado del evento SelectedIndexChanged
                    cmbCuadricula.SelectedValueChanged += new EventHandler(gridDetalle_ComboBox_SelectedIndexChanged); //Paso 2: Agrega el delegado del evento SelectedIndexChanged
                }
            }
        }

        private void gridDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
            {
                gridDetalle.EndEdit(); //Bloque 2: Impide que el foco pase a la siguiente fila en los desplegables de la cuadricula 
                e.SuppressKeyPress = true;
                if (gridDetalle.CurrentCell.ColumnIndex == 9) gridDetalle.CurrentCell = gridDetalle.CurrentRow.Cells[0]; //Mueve el foco a la celda de la primera columna  
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
                    buscarArticulo(gridDetalle);
                }
                else if (e.KeyChar == '+') //Tecla de Acesso Directo "Agregar Fila"
                {
                    e.Handled = true;
                    agregarFila();
                }
                else if (gridDetalle.CurrentCell.ColumnIndex == 0) //Verifica que el ingreso de datos sea con números enteros dentro de la celda "Código"
                {
                    if ((!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) || !_controladorDeNuevoRegistro) e.Handled = true;
                }
                else if (gridDetalle.CurrentCell.ColumnIndex == 2) //Verifica que el ingreso de datos sea con números enteros dentro de la celda "Cantidad"
                {
                    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
                }
                else if (gridDetalle.CurrentCell.ColumnIndex == 1) //Verifica que el ingreso de datos sea en mayúsculas dentro de la celda "Denominación" 
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
                else if (gridDetalle.CurrentCell.ColumnIndex == 5) //Verifica que el ingreso de datos sea con números decimales dentro de la celda "Costo Unitario"
                {
                    Formulario.ValidarCampoMoneda(e, gridDetalle.CurrentCell.GetEditedFormattedValue(gridDetalle.CurrentRow.Index, DataGridViewDataErrorContexts.Display).ToString());
                }
            }
        }

        private void gridDetalle_Leave(object sender, EventArgs e)
        {
            if (gridDetalle.Rows.Count > 0)
            {
                _idArticulo_ControladorDeModificacion = ""; //Importante: Restaura el controlador de modificacion de artículo
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
            buscarArticulo(gridDetalle);
            gridDetalle.Focus();
        }
        #endregion

        #region Eventos de Totales
        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtDescuento.Text);
        }

        private void txtDescuento_Validated(object sender, EventArgs e)
        {
            calcularTotal();
        }

        private void txtPercepcionIIBB_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtPercepcionIIBB.Text);
        }

        private void txtPercepcionIIBB_Validated(object sender, EventArgs e)
        {
            calcularTotal();
        }

        private void txtPercepcionLH_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtPercepcionLH.Text);
        }

        private void txtPercepcionLH_Validated(object sender, EventArgs e)
        {
            calcularTotal();
        }

        private void txtPercepcionIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtPercepcionIVA.Text);
        }

        private void txtPercepcionIVA_Validated(object sender, EventArgs e)
        {
            calcularTotal();
        }

        private void txtNoGravado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtNoGravado.Text);
        }

        private void txtNoGravado_Validated(object sender, EventArgs e)
        {
            calcularTotal();
        }

        private void txtImpuestoInterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtImpuestoInterno.Text);
        }

        private void txtImpuestoInterno_Validated(object sender, EventArgs e)
        {
            calcularTotal();
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(21)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objCompra != null)
            {
                if (objCompra.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(21)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarFechaComprobante() && ValidarCampoVacio() && validarCuadricula() && ValidarAsociacion())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            this.objProveedor = nProveedor.obtenerObjeto("TODOS", "ID", objCompra.Proveedor.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                            this.listaDeCompraDetalle = new List<CompraDetalle>(); //Importante: Crea una nueva lista de Objetos por seguridad (libera los residuos de antiguas instancias)
                            objCompra.Id = nCompra.generarNumeroID(); //Paso 3: Genera un ID para cada Objeto
                            if (nCompra.insertar(objCompra)) //Paso 4: Inserta el objeto principal
                            {
                                #region Registra el Detalle
                                long idDetalle = nCompraDetalle.generarNumeroID(); //Paso 5: Asigna un numero de ID al Objeto
                                foreach (DataGridViewRow fila in gridDetalle.Rows)
                                {
                                    CompraDetalle objCompraDetalle = new CompraDetalle(
                                        idDetalle,
                                        objCompra,
                                        Formulario.ValidarNumeroEntero(fila.Cells[0].Value.ToString()), //ID Código
                                        fila.Cells[1].Value.ToString().Trim(), //Denominación
                                        Formulario.ValidarNumeroEntero(fila.Cells[2].Value.ToString()), //Cantidad
                                        fila.Cells[3].Value.ToString().Trim(), //Unidad
                                        fila.Cells[4].Value.ToString().Trim(), //Deposito
                                        Formulario.ValidarNumeroDoble(fila.Cells[5].Value.ToString()), //Precio Unitario
                                        fila.Cells[6].Value.ToString(), //Alícuota IVA
                                        Formulario.ValidarNumeroDoble(fila.Cells[7].Value.ToString()), //Base IVA
                                        Formulario.ValidarNumeroDoble(fila.Cells[8].Value.ToString()), //Precio Neto
                                        new N_CentroCosto().obtenerObjeto("DENOMINACION", Convert.ToString(fila.Cells[9].Value).Trim(), true)); //Centro de Costo
                                    listaDeCompraDetalle.Add(objCompraDetalle); //Paso 6: Agrega el Objeto en la lista de Objetos
                                    idDetalle++; //Importante: Incrementa el valor del ID Detalle
                                    /* Nota: Cuando hay más de un ítem en el detalle: El valor del ID se debe incrementar
                                     * iterativamente ya que el generador no brinda esta solución porque solo puede calcular
                                     * el valor del máximo de ID de los ítems existentes en la Base de Datos. En este caso
                                     * es solo una lista de objetos que aun No han sido insertados).*/
                                }
                                if (nCompraDetalle.insertar(listaDeCompraDetalle)) actualizarArticulo("REGISTRACION", listaDeCompraDetalle); //Paso 7: Inserta la lista de Objetos en la Base de Datos. De ser corecto, posteriormente actualiza el Costo y Stock de cada Artículo 
                                #endregion
                                calcularCtaCte("REGISTRACION"); //Paso 8: Actualiza la Cta.Cte. del Proveedor Personal
                                asentarTransaccion("REGISTRACION"); //Paso 9: Registra el/los Asiento/s Contable/s
                                if (objCompra.AsociacionId > 0 && objCompra.AsociacionAfipCbteNro > 0) nCompra.registrarComoCbteAsociado(objCompra.AsociacionId, true); //Paso 10: Quita el estado de referencia en el comprobante referenciado 
                                mostrarRegistro(objCompra, listaDeCompraDetalle);
                                Mensaje.RegistroCorrecto("REGISTRACION");
                            }
                        }
                    }
                }
                else if (objCompra.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(22)) //Verifica que el usuario posea el privilegio requerido
                {
                    if (objCompra.Fecha.AddDays(Global.RegistroModificacion) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        if (!objCompra.AsociacionAplicada) //Verifica si el comprobante esta asociado. En tal caso, impide la modificación del comprobante
                        {
                            //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                            if (ValidarCampoVacio() && ValidarFechaComprobante() && validarCuadricula() && ValidarAsociacion())
                            {
                                if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                                {
                                    instanciarObjeto(); //Paso 1: Instancia el Objeto
                                    this.objProveedor = nProveedor.obtenerObjeto("TODOS", "ID", objCompra.Proveedor.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                                    this.listaDeCompraDetalle = new List<CompraDetalle>(); //Importante: Crea una nueva lista de Objetos por seguridad (libera los residuos de antiguas instancias)
                                    #region Lectura del Detalle
                                    foreach (DataGridViewRow fila in gridDetalle.Rows)
                                    {
                                        CompraDetalle objCompraDetalle = new CompraDetalle(
                                            Formulario.ValidarNumeroEntero(fila.Cells[10].Value.ToString()), //Id Detalle
                                            objCompra,
                                            Formulario.ValidarNumeroEntero(fila.Cells[0].Value.ToString()), //ID Artículo
                                            fila.Cells[1].Value.ToString().Trim(), //Denominación
                                            Formulario.ValidarNumeroEntero(fila.Cells[2].Value.ToString()), //Cantidad
                                            fila.Cells[3].Value.ToString().Trim(), //Unidad
                                            fila.Cells[4].Value.ToString().Trim(), //Deposito
                                            Formulario.ValidarNumeroDoble(fila.Cells[5].Value.ToString()), //Precio Unitario
                                            fila.Cells[6].Value.ToString(), //Alícuota IVA
                                            Formulario.ValidarNumeroDoble(fila.Cells[7].Value.ToString()), //Base IVA
                                            Formulario.ValidarNumeroDoble(fila.Cells[8].Value.ToString()), //Precio Neto
                                            new N_CentroCosto().obtenerObjeto("DENOMINACION", Convert.ToString(fila.Cells[9].Value).Trim(), true)); //Centro de Costo
                                        listaDeCompraDetalle.Add(objCompraDetalle); //Paso 3: Agrega el Objeto en la lista de Objetos
                                    }
                                    #endregion
                                    if (!objCompra.Equals(objCompraDB) || !nCompraDetalle.compararDetalle(listaDeCompraDetalleDB, listaDeCompraDetalle)) //Paso 5: Verifica que el Objeto y/o Detalle se han modificado 
                                    {
                                        if (nCompra.actualizar(objCompra)) //Paso 6: Actualiza el Objeto y Detalle
                                        {
                                            if (nCompraDetalle.actualizar(listaDeCompraDetalle)) actualizarArticulo("MODIFICACION", listaDeCompraDetalle); //Paso 7: Actualiza la lista de Objetos en la Base de Datos. De ser corecto, posteriormente actualiza el Costo y Stock de cada Artículo 
                                            calcularCtaCte("MODIFICACION"); //Paso 8: Actualiza la Cta.Cte. del Proveedor Personal
                                            asentarTransaccion("MODIFICACION"); //Paso 9: Registra el/los Asiento/s Contable/s
                                            mostrarRegistro(objCompra, listaDeCompraDetalle);
                                            Mensaje.RegistroCorrecto("MODIFICACION");
                                        }
                                    }
                                }
                            }
                        }
                        else Mensaje.Advertencia("Operación incorrecta.\nLos comprobantes que contienen una relación de asociación\nNo pueden ser modificados.");
                    }
                    else Mensaje.Advertencia("Operación Incorrecta. Los comprobantes que han superado los " + Global.RegistroModificacion + " días de su registración No pueden ser modificados.");
                }
                else Mensaje.Restriccion();
                bool ValidarCampoVacio() // Método que valida los campos requeridos
                {
                    return Formulario.ValidarCampoVacio(false, new Control[] { cmbPeriodo, cmbAfipCbteTipo,
                    txtAfipCbteTPV, txtAfipCbteNro, txtDenominacion, txtCuit, txtCategoriaIva, cmbCuentaContable })
                    && Formulario.ValidarNumeroDoble(lblTotal.Text) > 0;
                }
                bool ValidarAsociacion() // Método que valida la asociación del comprobante
                {
                    if (cmbAfipCbteTipo.Text.Split('-')[0] == "FAC" && !string.IsNullOrWhiteSpace(txtAsociacionAfipCbteTipo.Text) && (txtAsociacionAfipCbteTipo.Text.Split('-')[0] != "NCR" && txtAsociacionAfipCbteTipo.Text.Split('-')[0] != "REM"))
                    {
                        Mensaje.Advertencia("Operación Incorrecta.\nLas Facturas solo pueden hacer asociación a un Remito o Nota de Crédito.\nVerifique e intente nuevamente.");
                        return false;
                    }
                    else if (cmbAfipCbteTipo.Text.Split('-')[0] == "NCR" && !string.IsNullOrWhiteSpace(txtAsociacionAfipCbteTipo.Text) && (txtAsociacionAfipCbteTipo.Text.Split('-')[0] != "FAC" && txtAsociacionAfipCbteTipo.Text.Split('-')[0] != "NDE"))
                    {
                        Mensaje.Advertencia("Operación Incorrecta.\nLas Notas de Crédito solo pueden hacer asociación a una Factura o Nota de Débito.\nVerifique e intente nuevamente.");
                        return false;
                    }
                    else if (cmbAfipCbteTipo.Text.Split('-')[0] == "NDE" && !string.IsNullOrWhiteSpace(txtAsociacionAfipCbteTipo.Text) && (txtAsociacionAfipCbteTipo.Text.Split('-')[0] != "FAC" && txtAsociacionAfipCbteTipo.Text.Split('-')[0] != "NCR"))
                    {
                        Mensaje.Advertencia("Operación Incorrecta.\nLas Notas de Débito solo pueden hacer asociación a una Factura o Nota de Crédito.\nVerifique e intente nuevamente.");
                        return false;
                    }
                    else if (cmbAfipCbteTipo.Text.Split('-')[0] == "REM" && !string.IsNullOrWhiteSpace(txtAsociacionAfipCbteTipo.Text))
                    {
                        Mensaje.Advertencia("Operación Incorrecta.\nLos Remitos No pueden hacer asociación a otro comprobante.\nVerifique e intente nuevamente.");
                        return false;
                    }
                    return true;
                }
                bool ValidarFechaComprobante() //Método que valida la fecha del comprobante
                {
                    if (pkrAfipCbteFecha.Value.Date > Fecha.DTSistemaFecha().Date)
                    {
                        Mensaje.Advertencia("Operación Incorrecta.\nLa fecha del comprobante No puede superar la fecha actual.\nVerifique e intente nuevamente.");
                        return false;
                    }
                    return true;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objCompra.Id > 0) escribirControles(objCompraDB, listaDeCompraDetalleDB); //Restaura los datos originales en base al registro seleccionado
            else restaurarControles();
        }
        #endregion

        #region Métodos de Cuadricula
        private void agregarFila()
        {
            if (_controladorDeNuevoRegistro && gridDetalle.RowCount <= 30) //Verifica que no se superen las 30 filas en la cuadricula
            {
                gridDetalle.Rows.Add("", "", "0", "UNI", "EMPREMINSA", "0.00", "00.0", "0.00", "0.00", _primerElemento_CentroDeCosto);
                gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                gridDetalle.FirstDisplayedScrollingRowIndex = gridDetalle.RowCount - 1; //Posiciona el scroll del gridDetalle en la celda seleccionada
                SendKeys.Send("{DOWN}"); //Mueve el foco a la nueva fila  
            }
        }

        private void agregarFilas(List<CompraDetalle> detalle)
        {
            gridDetalle.Rows.Clear();
            foreach (CompraDetalle item in detalle)
            {
                gridDetalle.Rows.Add();
                gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                gridDetalle.CurrentRow.Cells[0].Value = Convert.ToString(item.IdArticulo).PadLeft(6, '0');
                gridDetalle.CurrentRow.Cells[1].Value = Convert.ToString(item.Denominacion);
                gridDetalle.CurrentRow.Cells[2].Value = Convert.ToString(item.Cantidad);
                gridDetalle.CurrentRow.Cells[3].Value = Convert.ToString(item.Unidad);
                gridDetalle.CurrentRow.Cells[4].Value = Convert.ToString(item.Deposito);
                gridDetalle.CurrentRow.Cells[5].Value = Formulario.ValidarCampoMoneda(Formulario.ValidarNumeroDoble(Convert.ToString(item.CostoUnitario)));
                gridDetalle.CurrentRow.Cells[6].Value = Convert.ToString(item.AlicuotaIVA);
                gridDetalle.CurrentRow.Cells[7].Value = Formulario.ValidarCampoMoneda(Formulario.ValidarNumeroDoble(Convert.ToString(item.BaseIVA)));
                gridDetalle.CurrentRow.Cells[8].Value = Formulario.ValidarCampoMoneda(Formulario.ValidarNumeroDoble(Convert.ToString(item.CostoNeto)));
                gridDetalle.CurrentRow.Cells[9].Value = Convert.ToString(item.CentroCosto.Denominacion);
                gridDetalle.CurrentRow.Cells[10].Value = Formulario.ValidarNumeroEntero64(Convert.ToString(item.Id)); //Importante: Almacena el Id Detalle para identificar el ítem ante una posible modificación
            }
            if (gridDetalle.CurrentCell != null) gridDetalle.CurrentCell.Selected = false; //Quita la selección de la celda
        }

        private void buscarArticulo(DataGridView cuadricula) //Método que busca un artículo
        {
            if (_controladorDeNuevoRegistro)
            {
                FormCatalogo_Articulo frm = new FormCatalogo_Articulo(this, "FILTRAR POR ESTADO: ACTIVO", false);
                frm.ShowDialog(this); //Abre el Catálogo de Artículos
                if (cuadricula.Rows.Count > 0)
                {
                    var posicion = cuadricula.CurrentRow.Cells[0]; //Posicionamiento - Paso 1: proceso de reposicionamiento
                    cuadricula.CurrentCell = null; //Posicionamiento - Paso 2: proceso de reposicionamiento
                    cuadricula.CurrentCell = posicion; //Posicionamiento - Paso 3: proceso de reposicionamiento
                }
            }
        }

        private void buscarArticuloID(int indiceFila, string idCodigo) //Método que busca un artículo por ID
        {
            if (_controladorDeNuevoRegistro)
            {
                if (string.IsNullOrEmpty(idCodigo)) //Verifica que el código recibido sea nulo o vacío
                {
                    escribirFila(indiceFila, "", null, true);
                }
                else
                {
                    idCodigo = (idCodigo.Trim().Length <= 6) ? idCodigo.Trim().PadLeft(6, '0') : idCodigo.Trim(); //Formatea el código
                    if (idCodigo != _idArticulo_ControladorDeModificacion) //Verifica que el ID recibido ha sido modificado
                    {
                        if (idCodigo == "000000") //Verifica que el ID recibido es un ID cero (Editable)
                        {
                            escribirFila(indiceFila, "000000", null, false);
                        }
                        else
                        {
                            Articulo objArticulo = (idCodigo.Length <= 6) ? nArticulo.obtenerObjeto("ACTIVO", "ID", idCodigo.Trim(), true) : nArticulo.obtenerObjeto("ACTIVO", "CODIGO_BARRAS", idCodigo, true); //Consulta que ejecuta una busqueda en la Base de Datos por Código de Barras o ID
                            if (objArticulo != null) //Verifica que el resultado de la consulta tenga exito
                            {
                                _idArticulo_ControladorDeModificacion = Convert.ToString(objArticulo.Id).PadLeft(6, '0');
                                escribirFila(indiceFila, Convert.ToString(objArticulo.Id).PadLeft(6, '0'), objArticulo, true);
                            }
                            else
                            {
                                escribirFila(indiceFila, "", null, true);
                            }
                        }
                    }
                }
            }
        }

        private void calcularNeto(int indiceFila)
        {
            int cantidad = string.IsNullOrWhiteSpace(Convert.ToString(gridDetalle.Rows[indiceFila].Cells[2].Value)) ? 0 : Formulario.ValidarNumeroEntero(gridDetalle.Rows[indiceFila].Cells[2].Value.ToString()); //Cantidad
            double precioUnitario = string.IsNullOrWhiteSpace(Convert.ToString(gridDetalle.Rows[indiceFila].Cells[5].Value)) ? 0 : Formulario.ValidarNumeroDoble(Convert.ToString(gridDetalle.Rows[indiceFila].Cells[5].Value).Replace(".", ",")); //Costo Unitario
            double alicuotaIVA = string.IsNullOrWhiteSpace(Convert.ToString(gridDetalle.Rows[indiceFila].Cells[6].EditedFormattedValue)) ? 0 : Formulario.ValidarNumeroDoble(Convert.ToString(gridDetalle.Rows[indiceFila].Cells[6].EditedFormattedValue).Replace(".", ",")); //Alícuota IVA
            double totalBruto = cantidad * precioUnitario; //Total Bruto
            double baseIva = Math.Round((totalBruto / 100) * alicuotaIVA, 2); //Base IVA
            gridDetalle.Rows[indiceFila].Cells[7].Value = Formulario.ValidarCampoMoneda(baseIva.ToString()); //Asigna el valor a la celda "Base IVA"
            gridDetalle.Rows[indiceFila].Cells[8].Value = Formulario.ValidarCampoMoneda(totalBruto + baseIva); //Asigna el valor a la celda "Costo Neto"
            calcularTotal(); //Recalcula el Total del comprobante
        }

        private void calcularTotal()
        {
            txtDescuento.Text = Formulario.ValidarCampoMoneda(txtDescuento.Text); //Verifica que el valor de la caja de texto sea válido
            txtPercepcionIIBB.Text = Formulario.ValidarCampoMoneda(txtPercepcionIIBB.Text); //Verifica que el valor de la caja de texto sea válido
            txtPercepcionLH.Text = Formulario.ValidarCampoMoneda(txtPercepcionLH.Text); //Verifica que el valor de la caja de texto sea válido
            txtPercepcionIVA.Text = Formulario.ValidarCampoMoneda(txtPercepcionIVA.Text); //Verifica que el valor de la caja de texto sea válido
            txtNoGravado.Text = Formulario.ValidarCampoMoneda(txtNoGravado.Text); //Verifica que el valor de la caja de texto sea válido
            txtImpuestoInterno.Text = Formulario.ValidarCampoMoneda(txtImpuestoInterno.Text); //Verifica que el valor de la caja de texto sea válido
            double descuento = Math.Round(Formulario.ValidarNumeroDoble(txtDescuento.Text), 2);
            double descuentoPorcentual = 00.00;
            double iva105 = 0.00;
            double iva210 = 0.00;
            double iva270 = 0.00;
            double subTotalGravado = 0.00;
            double totalGravado = 0.00;
            double percepcionIIBB = Math.Round(Formulario.ValidarNumeroDoble(txtPercepcionIIBB.Text), 2);
            double percepcionLH = Math.Round(Formulario.ValidarNumeroDoble(txtPercepcionLH.Text), 2);
            double percepcionIVA = Math.Round(Formulario.ValidarNumeroDoble(txtPercepcionIVA.Text), 2);
            double noGravado = Math.Round(Formulario.ValidarNumeroDoble(txtNoGravado.Text), 2);
            double impuestoInterno = Math.Round(Formulario.ValidarNumeroDoble(txtImpuestoInterno.Text), 2);
            foreach (DataGridViewRow row in gridDetalle.Rows) //Recorre la cuadricula y suma los valores de las celdas indicadas 
            {
                if (row.Cells[6].Value.ToString() == "10.5") iva105 += Formulario.ValidarNumeroDoble(row.Cells[7].Value.ToString());
                if (row.Cells[6].Value.ToString() == "21.0") iva210 += Formulario.ValidarNumeroDoble(row.Cells[7].Value.ToString());
                if (row.Cells[6].Value.ToString() == "27.0") iva270 += Formulario.ValidarNumeroDoble(row.Cells[7].Value.ToString());
                totalGravado += Formulario.ValidarNumeroDoble(row.Cells[8].Value.ToString());
            }
            subTotalGravado = totalGravado - (iva105 + iva210 + iva270);
            if (descuento > 0)
            {
                descuentoPorcentual = (100 * descuento) / (totalGravado - descuento);
                iva105 = iva105 / (1 + (descuentoPorcentual / 100));
                iva210 = iva210 / (1 + (descuentoPorcentual / 100));
                iva270 = iva270 / (1 + (descuentoPorcentual / 100));
                subTotalGravado = subTotalGravado / (1 + (descuentoPorcentual / 100));
                totalGravado = totalGravado - descuento;
            }
            lblDescuentoPorcentual.Text = Formulario.ValidarCampoMoneda(Math.Round(descuentoPorcentual, 2)).PadLeft(5, '0');
            lblIVA105.Text = Formulario.ValidarCampoMoneda(Math.Round(iva105, 2));
            lblIVA210.Text = Formulario.ValidarCampoMoneda(Math.Round(iva210, 2));
            lblIVA270.Text = Formulario.ValidarCampoMoneda(Math.Round(iva270, 2));
            lblSubTotal.Text = Formulario.ValidarCampoMoneda(Math.Round(subTotalGravado, 2));
            lblTotal.Text = Formulario.ValidarCampoMoneda(Math.Round(percepcionIIBB + percepcionLH + percepcionIVA + totalGravado + impuestoInterno + noGravado, 2));
        }

        private bool deducirIVA() //Método que deduce si el comprobante debe incluir el IVA 
        {
            if (txtCategoriaIva.Text == "RESPONSABLE INSCRIPTO") return true;
            if ((cmbAfipCbteTipo.Text == "A" || cmbAfipCbteTipo.Text == "M" || cmbAfipCbteTipo.Text == "R" || cmbAfipCbteTipo.Text == "X") && txtCategoriaIva.Text == "RESPONSABLE INSCRIPTO") return true;
            return false;
        }

        private void determinarIVA() //Método que determina si la cuadricula incluye el IVA
        {
            _idArticulo_ControladorDeModificacion = ""; //Importante: Restaura el controlador de modificación de artículo para completar la determinación del IVA
            foreach (DataGridViewRow fila in gridDetalle.Rows) //Recorre las celdas del gridDetalle
            {
                string codigo = Convert.ToString(gridDetalle.Rows[fila.Index].Cells[0].Value); //Almacena el código ingresado en la fila
                string cantidad = Convert.ToString(gridDetalle.Rows[fila.Index].Cells[2].Value); //Almacena la cantidad ingresada en la fila
                if (!string.IsNullOrEmpty(codigo) && Formulario.ValidarNumeroEntero(codigo) > 0)
                {
                    buscarArticuloID(fila.Index, codigo); //Re-busca el artículo ingresado en la fila actual
                    gridDetalle.Rows[fila.Index].Cells[2].Value = cantidad; //Re-establece el valor ingresado en la celda actual
                    calcularNeto(fila.Index); //Re-cálcula el neto de la fila actual
                }
                else if (!string.IsNullOrEmpty(codigo) && Formulario.ValidarNumeroEntero(codigo) == 0)
                {
                    gridDetalle.Rows[fila.Index].Cells[6].Value = "00.0";  //Re-asigna el valor de celda actual
                    gridDetalle.Rows[fila.Index].Cells[7].Value = "0.00"; //Re-asigna el valor de celda actual
                    calcularNeto(fila.Index); //Re-cálcula el neto de la fila actual
                }
            }
        }

        private void escribirFila(int indiceFila, string idArticulo, Articulo objArticulo, bool actividad)
        {
            gridDetalle.Rows[indiceFila].Cells[0].Value = idArticulo;
            gridDetalle.Rows[indiceFila].Cells[1].Value = (objArticulo != null) ? objArticulo.Denominacion : "";
            gridDetalle.Rows[indiceFila].Cells[1].ReadOnly = actividad;
            gridDetalle.Rows[indiceFila].Cells[2].Value = "0";
            gridDetalle.Rows[indiceFila].Cells[3].Value = (objArticulo != null) ? objArticulo.Unidad : "UNI";
            gridDetalle.Rows[indiceFila].Cells[3].ReadOnly = actividad;
            gridDetalle.Rows[indiceFila].Cells[4].Value = "EMPREMINSA";
            gridDetalle.Rows[indiceFila].Cells[5].Value = (objArticulo != null) ? Formulario.ValidarCampoMoneda(objArticulo.CostoBruto) : "0.00";
            gridDetalle.Rows[indiceFila].Cells[6].Value = (objArticulo != null) ? ((deducirIVA()) ? objArticulo.CostoAlicuotaIVA : "00.0") : "00.0";
            gridDetalle.Rows[indiceFila].Cells[7].Value = "0.00";
            gridDetalle.Rows[indiceFila].Cells[8].Value = "0.00";
            gridDetalle.Rows[indiceFila].Cells[9].Value = _primerElemento_CentroDeCosto;
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
                        if (string.IsNullOrWhiteSpace(Convert.ToString(fila.Cells[0].Value)) || string.IsNullOrWhiteSpace(Convert.ToString(fila.Cells[1].Value)))
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
                    if (Formulario.ValidarNumeroEntero(fila.Cells[2].Value.ToString()) <= 0) //Verifica si hay cantidades inválidas
                    {
                        // ---------- BLOQUE CONTROLADOR DE CANTIDAD INVALIDA ---------- //
                        Mensaje.Advertencia("Operación Incorrecta.\nVerifique en cada ítem del detalle que la cantidad sea válida e intente nuevamente.");
                        return false;
                    }
                    else if (Formulario.ValidarNumeroEntero(fila.Cells[0].Value.ToString()) > 0) //Verifica que sea un artículo del incomprario
                    {
                        // ----------- BLOQUE CONTROLADOR DE FILAS DUPLICADAS ----------- //
                        int controladorDeDuplicado = 0;
                        foreach (DataGridViewRow filaDuplicada in gridDetalle.Rows)
                        {
                            if (fila.Cells[0].Value.ToString() == filaDuplicada.Cells[0].Value.ToString()
                                && fila.Cells[4].Value.ToString() == filaDuplicada.Cells[4].Value.ToString()
                                && fila.Cells[9].Value.ToString() == filaDuplicada.Cells[9].Value.ToString()) controladorDeDuplicado += 1;
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
            if (variablesDeFormulario[0] == "Catalogo_Articulo") //Catálogo de Artículos
            {
                if (gridDetalle.Rows.Count > 0) // Verifica que No este vacia la cuadricula
                {
                    gridDetalle.CurrentRow.SetValues(
                        variablesDeFormulario[1].PadLeft(6, '0'),
                        variablesDeFormulario[2],
                        "0",
                        variablesDeFormulario[3],
                        "EMPREMINSA",
                        variablesDeFormulario[4],
                        ((deducirIVA()) ? variablesDeFormulario[5] : "00.0"),
                        "0.00",
                        "0.00",
                        _primerElemento_CentroDeCosto //Selecciona el primer elemento de la lista de Centros de Costos
                    );
                }
            }
        }
        #endregion

        #region Métodos de Formulario  
        private void actualizarArticulo(string operacion, List<CompraDetalle> detalle)
        {
            if (detalle.Count > 0)
            {
                int indiceDeLaLista = 0; //Importante: Establece un indice en común para identificar el Objecto en ambas listas
                foreach (CompraDetalle objCompraDetalle in detalle)
                {
                    if (objCompraDetalle.IdArticulo > 0) //Verifica si es un artículo del inventario
                    {
                        Articulo objArticulo = nArticulo.obtenerObjeto("TODOS", "ID", objCompraDetalle.IdArticulo.ToString().Trim(), false); //Obtiene los datos del artículo BD  
                        objArticulo.Estado = "ACTIVO"; //Re-Establece forzadamente el estado del artículo
                        if ((operacion == "REGISTRACION" || operacion == "MODIFICACION") && cmbAfipCbteTipo.Text.Split('-')[0] == "FAC") //Verifica si es una Factura. En ese caso, actualiza los costos del artículo 
                        {
                            objArticulo.CostoBruto = Formulario.ValidarNumeroDoble(objCompraDetalle.CostoUnitario.ToString());
                            objArticulo.CostoAlicuotaIVA = objCompraDetalle.AlicuotaIVA.ToString(); //Re-Asigna el valor de la Alícuota IVA
                            objArticulo.CostoBaseIVA = ((objArticulo.CostoBruto / 100) * Formulario.ValidarNumeroDoble(objArticulo.CostoAlicuotaIVA.Replace(".", ","))); //Re-Calcula el valor del Costo Base IVA
                            objArticulo.CostoNeto = objArticulo.CostoBruto + objArticulo.CostoBaseIVA; //Re-Calcula el valor del Costo Neto
                            objArticulo.Utilidad = (objArticulo.CostoBruto > 0.00) ? Math.Round((((100 / objArticulo.CostoBruto) * objArticulo.PrecioBruto) - 100), 4) : 100.0000; //Re-Calcula el valor del Margen Bruto
                            objArticulo.MargenBruto = (objArticulo.CostoBruto > 0.00) ? Math.Round((objArticulo.PrecioBruto - objArticulo.CostoBruto), 2) : objArticulo.CostoBruto; //Re-Calcula el valor de la Utilidad Porcentual
                        }
                        if (cmbAfipCbteTipo.Text.Split('-')[0] == "FAC" || cmbAfipCbteTipo.Text.Split('-')[0] == "REM") //Verifica si el comprobante es una "FAC" O "REM"
                        {
                            if (operacion == "REGISTRACION" && txtAsociacionAfipCbteTipo.Text.Split('-')[0] != "REM") //Verifica que el comprobante No este haciendo asociación a un remito
                            {
                                if (objCompraDetalle.Deposito == "EMPREMINSA") objArticulo.A1_Stock = (objArticulo.A1_Stock + objCompraDetalle.Cantidad); //Verifica si el desposito es el de Empreminsa. En ese caso, suma el stock del artículo menos la cantidad actual  
                                else if (objCompraDetalle.Deposito == "VELADERO") objArticulo.A2_Stock = (objArticulo.A2_Stock + objCompraDetalle.Cantidad); //Verifica si el desposito es el de Veladero. En ese caso, suma el stock del artículo menos la cantidad actual  
                            }
                            else if (operacion == "MODIFICACION" && txtAsociacionAfipCbteTipo.Text.Split('-')[0] != "REM") //Verifica que el comprobante No este haciendo asociación a un remito
                            {
                                CompraDetalle objCompraDetalleDB = listaDeCompraDetalleDB[indiceDeLaLista];
                                if (Formulario.GenerarTipoComprobante(objCompraDB.AfipCbteTipo).Split('-')[0] == "NCR") //Verifica si el Tipo de Comprobante precedente es una NCR
                                {
                                    // ----- SITUACION DE CONVERSION DE COMPROBANTE ----- //
                                    if (objCompraDetalleDB.Deposito == "EMPREMINSA") objArticulo.A1_Stock = (objArticulo.A1_Stock + objCompraDetalleDB.Cantidad); //Verifica si el desposito precedente es el de Empreminsa. En ese caso, suma el stock del artículo con la cantidad precedente  
                                    else if (objCompraDetalleDB.Deposito == "VELADERO") objArticulo.A2_Stock = (objArticulo.A2_Stock + objCompraDetalleDB.Cantidad); //Verifica si el desposito precedente es el de Veladero. En ese caso, suma el stock del artículo con la cantidad precedente  
                                    if (objCompraDetalle.Deposito == "EMPREMINSA") objArticulo.A1_Stock = (objArticulo.A1_Stock + objCompraDetalle.Cantidad); //Verifica si el desposito es el de Empreminsa. En ese caso, suma la cantidad actual con el stock del depósito seleccionado.
                                    else if (objCompraDetalle.Deposito == "VELADERO") objArticulo.A2_Stock = (objArticulo.A2_Stock + objCompraDetalle.Cantidad); //Verifica si el desposito es el de Empreminsa. En ese caso, suma la cantidad actual con el stock del depósito seleccionado.
                                }
                                else
                                {
                                    if (objCompraDetalleDB.Deposito == "EMPREMINSA") objArticulo.A1_Stock = (objArticulo.A1_Stock - objCompraDetalleDB.Cantidad); //Verifica si el desposito precedente es el de Empreminsa. En ese caso, resta el stock del artículo con la cantidad precedente  
                                    else if (objCompraDetalleDB.Deposito == "VELADERO") objArticulo.A2_Stock = (objArticulo.A2_Stock - objCompraDetalleDB.Cantidad); //Verifica si el desposito precedente es el de Veladero. En ese caso, resta el stock del artículo con la cantidad precedente  
                                    if (objCompraDetalle.Deposito == "EMPREMINSA") objArticulo.A1_Stock = (objArticulo.A1_Stock + objCompraDetalle.Cantidad); //Verifica si el desposito es el de Empreminsa. En ese caso, suma la cantidad actual con el stock del depósito seleccionado.
                                    else if (objCompraDetalle.Deposito == "VELADERO") objArticulo.A2_Stock = (objArticulo.A2_Stock + objCompraDetalle.Cantidad); //Verifica si el desposito es el de Empreminsa. En ese caso, suma la cantidad actual con el stock del depósito seleccionado.
                                }
                            }
                        }
                        if (cmbAfipCbteTipo.Text.Split('-')[0] == "NCR") //Verifica si el comprobante es una "NCR"
                        {
                            if (operacion == "REGISTRACION")
                            {
                                if (objCompraDetalle.Deposito == "EMPREMINSA") objArticulo.A1_Stock = (objArticulo.A1_Stock - objCompraDetalle.Cantidad); //Verifica si el desposito es el de Empreminsa. En ese caso, resta el stock del artículo menos la cantidad actual  
                                else if (objCompraDetalle.Deposito == "VELADERO") objArticulo.A2_Stock = (objArticulo.A2_Stock - objCompraDetalle.Cantidad); //Verifica si el desposito es el de Veladero. En ese caso, resta el stock del artículo menos la cantidad actual  
                            }
                            else if (operacion == "MODIFICACION" && txtAsociacionAfipCbteTipo.Text.Split('-')[0] != "REM") //Verifica que el comprobante No este haciendo asociación a un remito
                            {
                                CompraDetalle objCompraDetalleDB = listaDeCompraDetalleDB[indiceDeLaLista];
                                if (Formulario.GenerarTipoComprobante(objCompraDB.AfipCbteTipo).Split('-')[0] == "NCR") //Verifica si el Tipo de Comprobante precedente es una NCR
                                {
                                    if (objCompraDetalleDB.Deposito == "EMPREMINSA") objArticulo.A1_Stock = (objArticulo.A1_Stock + objCompraDetalleDB.Cantidad); //Verifica si el desposito precedente es el de Empreminsa. En ese caso, suma el stock del artículo con la cantidad precedente  
                                    else if (objCompraDetalleDB.Deposito == "VELADERO") objArticulo.A2_Stock = (objArticulo.A2_Stock + objCompraDetalleDB.Cantidad); //Verifica si el desposito precedente es el de Veladero. En ese caso, suma el stock del artículo con la cantidad precedente  
                                    if (objCompraDetalle.Deposito == "EMPREMINSA") objArticulo.A1_Stock = (objArticulo.A1_Stock - objCompraDetalle.Cantidad); //Verifica si el desposito es el de Empreminsa. En ese caso, resta la cantidad actual con el stock del depósito seleccionado.
                                    else if (objCompraDetalle.Deposito == "VELADERO") objArticulo.A2_Stock = (objArticulo.A2_Stock - objCompraDetalle.Cantidad); //Verifica si el desposito es el de Empreminsa. En ese caso, resta la cantidad actual con el stock del depósito seleccionado.
                                }
                                else
                                {
                                    // ----- SITUACION DE CONVERSION DE COMPROBANTE ----- //
                                    if (objCompraDetalleDB.Deposito == "EMPREMINSA") objArticulo.A1_Stock = (objArticulo.A1_Stock - objCompraDetalleDB.Cantidad); //Verifica si el desposito precedente es el de Empreminsa. En ese caso, resta el stock del artículo con la cantidad precedente  
                                    else if (objCompraDetalleDB.Deposito == "VELADERO") objArticulo.A2_Stock = (objArticulo.A2_Stock - objCompraDetalleDB.Cantidad); //Verifica si el desposito precedente es el de Veladero. En ese caso, resta el stock del artículo con la cantidad precedente  
                                    if (objCompraDetalle.Deposito == "EMPREMINSA") objArticulo.A1_Stock = (objArticulo.A1_Stock - objCompraDetalle.Cantidad); //Verifica si el desposito es el de Empreminsa. En ese caso, resta la cantidad actual con el stock del depósito seleccionado.
                                    else if (objCompraDetalle.Deposito == "VELADERO") objArticulo.A2_Stock = (objArticulo.A2_Stock - objCompraDetalle.Cantidad); //Verifica si el desposito es el de Empreminsa. En ese caso, resta la cantidad actual con el stock del depósito seleccionado.
                                }
                            }
                        }
                        objArticulo.StockGlobal = objArticulo.A1_Stock + objArticulo.A2_Stock; //Calcula el Stock Global sumando las existencias del artículo que se han calculado en cada depósito 
                        #region Puntos de Stock
                        objArticulo.A1_PuntoCriticoAlertado = (objArticulo.A1_PuntoCritico && objArticulo.A1_Stock <= objArticulo.A1_PuntoCriticoLimite) ? false : true; //Determina el disparo de la alerta 
                        objArticulo.A1_PuntoMinimoAlertado = (objArticulo.A1_PuntoMinimo && objArticulo.A1_Stock <= objArticulo.A1_PuntoMinimoLimite) ? false : true; //Determina el disparo de la alerta 
                        objArticulo.A2_PuntoCriticoAlertado = (objArticulo.A2_PuntoCritico && objArticulo.A2_Stock <= objArticulo.A2_PuntoCriticoLimite) ? false : true; //Determina el disparo de la alerta 
                        objArticulo.A2_PuntoMinimoAlertado = (objArticulo.A2_PuntoMinimo && objArticulo.A2_Stock <= objArticulo.A2_PuntoMinimoLimite) ? false : true; //Determina el disparo de la alerta 
                        #endregion
                        nArticulo.actualizar(objArticulo, false); //Actualiza los valores del artículo
                    }
                    indiceDeLaLista++;
                }
            }
        }

        private void asentarTransaccion(string operacion)
        {
            string tipoDeComprobante = cmbAfipCbteTipo.Text.Split('-')[0];
            if (tipoDeComprobante == "FAC" || tipoDeComprobante == "NDE" || tipoDeComprobante == "NCR")
            {
                AsientoContable objAsientoContable = new AsientoContable();
                double montoGravado = Formulario.ValidarNumeroDoble(lblSubTotal.Text);
                double montoIVA = Formulario.ValidarNumeroDoble(lblIVA105.Text) + Formulario.ValidarNumeroDoble(lblIVA210.Text) + Formulario.ValidarNumeroDoble(lblIVA270.Text);
                double montoPercepcionIIBB = Formulario.ValidarNumeroDoble(txtPercepcionIIBB.Text);
                double montoPercepcionLH = Formulario.ValidarNumeroDoble(txtPercepcionLH.Text);
                double montoPercepcionIVA = Formulario.ValidarNumeroDoble(txtPercepcionIVA.Text);
                double montoNoGravado = Formulario.ValidarNumeroDoble(txtNoGravado.Text);
                double montoImpuestoInterno = Formulario.ValidarNumeroDoble(txtImpuestoInterno.Text);
                double montoTotal = Formulario.ValidarNumeroDoble(lblTotal.Text);
                objAsientoContable.AsientoFecha = pkrAfipCbteFecha.Value;
                objAsientoContable.Descripcion = "Compra: " + cmbAfipCbteTipo.Text + " N°" + Convert.ToString(objCompra.AfipCbteTPV).PadLeft(5, '0') + "-" + Convert.ToString(objCompra.AfipCbteNro).PadLeft(8, '0');
                objAsientoContable.Conciliacion = "NO-APLICA";
                objAsientoContable.OrigenTipo = "CPR";
                objAsientoContable.OrigenId = objCompra.Id;
                if (operacion == "REGISTRACION") objAsientoContable.AsientoNro = nAsientoContable.generarNumeroAsiento(); //Verifica que es un nuevo comprobante. Si es asi, genera un nuevo Número de Asiento
                else
                {
                    AsientoContable objAsientoContablePrecedente = nAsientoContable.obtenerObjeto("CPR", objCompra.Id); //Paso 1: En el caso de una modificación o anulación, obtiene el Asiento registrado precedentemente
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
                crearAsientoContable(objAsientoContable,
                    new string[] { cmbCuentaContable.Text, "IVA CREDITO FISCAL", "PERCEPCION IIBB SUFRIDA", "PERCEPCION IVA SUFRIDA", "IMP. INTERNOS SUFRIDA", "PROVEEDORES" },
                    new double[] { montoGravado, montoIVA, (montoPercepcionIIBB + montoPercepcionLH), montoPercepcionIVA, (montoImpuestoInterno + montoNoGravado), montoTotal },
                    new string[] { "HABER_DEBE", "HABER_DEBE", "HABER_DEBE", "HABER_DEBE", "HABER_DEBE", "DEBE_HABER" });
                void crearAsientoContable(AsientoContable asiento, string[] cuentaContable, double[] monto, string[] deducirMonto)
                {
                    for (int i = 0; i < cuentaContable.Length; i++)
                    {
                        if (monto[i] != 0.00)
                        {
                            asiento.CuentaContable = nCuentaContable.obtenerObjeto("DENOMINACION", cuentaContable[i], true);
                            asiento.Debe = (deducirMonto[i] == "DEBE_HABER") ? ((tipoDeComprobante == "NCR") ? monto[i] : 0.00) : ((tipoDeComprobante == "FAC" || tipoDeComprobante == "NDE") ? monto[i] : 0.00);
                            asiento.Haber = (deducirMonto[i] == "DEBE_HABER") ? ((tipoDeComprobante == "FAC" || tipoDeComprobante == "NDE") ? monto[i] : 0.00) : ((tipoDeComprobante == "NCR") ? monto[i] : 0.00);
                            nAsientoContable.insertar(asiento); //Paso 1: Registra el Asiento Contable en la Base de Datos
                            nCuentaContable.actualizarSaldo(asiento.CuentaContable.Id, ((asiento.CuentaContable.Saldo + asiento.Debe) - asiento.Haber)); //Paso 2: Actualiza el saldo en la Cuenta Contable (El Debe suma en el Saldo y el Haber resta en el Saldo)
                        }
                    }
                }
            }
        }

        private void buscarProveedorCUIT(string cuit) //Método que busca un Proveedor por CUIT
        {
            if (_controladorDeNuevoRegistro && !string.IsNullOrEmpty(cuit))
            {
                Proveedor proveedor = new N_Proveedor().obtenerObjeto("ACTIVO", "CUIT", cuit, true);
                objProveedor.Id = (proveedor != null) ? proveedor.Id : 0;
                txtDenominacion.Text = (proveedor != null) ? proveedor.Denominacion : "";
                txtCuit.Text = (proveedor != null) ? proveedor.Cuit : "";
                txtCategoriaIva.Text = (proveedor != null) ? proveedor.Iva : "";
            }
        }

        private void calcularCtaCte(string operacion)
        {
            double monto = Formulario.ValidarNumeroDoble(lblTotal.Text);
            double saldo = nProveedor.obtenerObjeto("TODOS", "ID", objProveedor.Id.ToString(), false).Saldo; //Almacena el saldo del proveedor que esta registrado en su Cta. Cte.
            if (operacion == "REGISTRACION")
            {
                if (cmbAfipCbteTipo.Text.Split('-')[0] == "FAC") saldo = (saldo + monto); //Verifica si el comprobante es una "FAC". En ese caso, suma el saldo de la Cta.Cte. del proveedor con el monto del comprobante
                else if (cmbAfipCbteTipo.Text.Split('-')[0] == "NCR") saldo = (saldo - monto); //Verifica si el comprobante es una "NCR". En ese caso, resta el saldo de la Cta.Cte. del proveedor menos el monto del comprobante
                else if (cmbAfipCbteTipo.Text.Split('-')[0] == "NDE") saldo = (saldo + monto); //Verifica si el comprobante es una "NDE". En ese caso, suma el saldo de la Cta.Cte. del proveedor con el monto del comprobante
            }
            else if (operacion == "MODIFICACION")
            {
                // ---------- BLOQUE QUE RESTAURA EL SALDO PRECEDENTE ---------- //
                if (cmbAfipCbteTipo.Text.Split('-')[0] == "FAC" || cmbAfipCbteTipo.Text.Split('-')[0] == "NDE") //Verifica si el comprobante actual es una "FAC" o "NDE"
                {
                    if (Formulario.GenerarTipoComprobante(objCompraDB.AfipCbteTipo).Split('-')[0] == "NCR") //Verifica si el Tipo de Comprobante precedente es una NCR
                    {
                        saldo = (saldo + objCompraDB.Total) + monto; //Suma el monto precedente al saldo de la Cta.Cte. del proveedor para calcular el saldo precedente. Seguidamente, suma dicho saldo precedente con el monto del comprobante actual
                    }
                    else saldo = (saldo - objCompraDB.Total) + monto; //Resta el monto precedente con el saldo de la Cta.Cte. del proveedor para calcular el saldo precedente. Seguidamente, suma dicho saldo precedente con el monto del comprobante actual
                }
                if (cmbAfipCbteTipo.Text.Split('-')[0] == "NCR") //Verifica si el comprobante actual es una "NCR"
                {
                    if (Formulario.GenerarTipoComprobante(objCompraDB.AfipCbteTipo).Split('-')[0] == "NCR") //Verifica si el Tipo de Comprobante precedente es una NCR
                    {
                        saldo = (saldo + objCompraDB.Total) - monto; //Suma el monto precedente con el saldo de la Cta.Cte. del proveedor para calcular el saldo precedente. Seguidamente, resta dicho saldo precedente con el monto del comprobante actual
                    }
                    else saldo = (saldo - objCompraDB.Total) - monto; //Resta el monto precedente al saldo de la Cta.Cte. del proveedor para calcular el saldo precedente. Seguidamente, resta dicho saldo precedente con el monto del comprobante actual
                }
            }
            nProveedor.actualizarSaldo(objProveedor.Id, saldo); //Actualiza el saldo en la Cta.Cte. del proveedor 
        }

        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(Compra objRegistro, List<CompraDetalle> detalle)
        {
            this.objCompra = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            this.listaDeCompraDetalle = detalle; //Iguala el Atributo de la clase con la lista de Objetos recibidos
            if (objCompra != null)
            {
                _controladorDeNuevoRegistro = false;
                _idArticulo_ControladorDeModificacion = ""; //Libera el Id del Objeto seleccionado
                objCompra.Id = (objCompra != null) ? objCompra.Id : 0;
                txtID.Text = Convert.ToString(objCompra.Id).PadLeft(10, '0');
                txtFecha.Text = Fecha.ConvertirFecha(objCompra.Fecha);
                string[] periodo = objCompra.Periodo.ToString().Split('-');
                cmbPeriodo.Text = periodo[0];
                txtPeriodo.Text = periodo[1];
                cmbAfipCbteTipo.Text = Formulario.GenerarTipoComprobante(objCompra.AfipCbteTipo);
                txtAfipCbteTPV.Text = Convert.ToString(objCompra.AfipCbteTPV).PadLeft(5, '0');
                txtAfipCbteNro.Text = Convert.ToString(objCompra.AfipCbteNro).PadLeft(8, '0');
                pkrAfipCbteFecha.Value = objCompra.AfipCbteFecha;
                txtNumeroCodigoBarras.Text = objCompra.AfipCodigoBarras;
                objProveedor = objCompra.Proveedor;
                txtDenominacion.Text = objCompra.Proveedor.Denominacion;
                txtCuit.Text = objCompra.Proveedor.Cuit;
                txtCategoriaIva.Text = objCompra.Proveedor.Iva;
                cmbCuentaContable.Text = objCompra.CuentaContable.Denominacion;
                pkrPagoVto.Value = objCompra.PagoVto;
                _pagoEstado = objCompra.PagoEstado;
                txtAsociacionID.Text = (objCompra.AsociacionId <= 0) ? "" : Convert.ToString(objCompra.AsociacionId).PadLeft(10, '0');
                txtAsociacionAfipCbteTipo.Text = (objCompra.AsociacionAfipCbteNro > 0) ? Formulario.GenerarTipoComprobante(objCompra.AsociacionAfipCbteTipo) : "";
                txtAsociacionAfipCbteTPV.Text = (objCompra.AsociacionAfipCbteNro <= 0) ? "" : Convert.ToString(objCompra.AsociacionAfipCbteTPV).PadLeft(5, '0');
                txtAsociacionAfipCbteNro.Text = (objCompra.AsociacionAfipCbteNro <= 0) ? "" : Convert.ToString(objCompra.AsociacionAfipCbteNro).PadLeft(8, '0');
                txtAsociacionAfipCbteFecha.Text = (objCompra.AsociacionAfipCbteNro <= 0) ? "" : Fecha.ConvertirFecha(objCompra.AsociacionAfipCbteFecha);
                agregarFilas(listaDeCompraDetalleDB); //Escribe los item en el detalle de comprobante
                lblDescuentoPorcentual.Text = Formulario.ValidarCampoMoneda(objCompra.DescuentoPorcentual);
                txtDescuento.Text = Formulario.ValidarCampoMoneda(objCompra.Descuento);
                lblSubTotal.Text = Formulario.ValidarCampoMoneda(objCompra.Subtotal);
                lblIVA105.Text = Formulario.ValidarCampoMoneda(objCompra.Iva105);
                lblIVA210.Text = Formulario.ValidarCampoMoneda(objCompra.Iva210);
                lblIVA270.Text = Formulario.ValidarCampoMoneda(objCompra.Iva270);
                txtPercepcionIIBB.Text = Formulario.ValidarCampoMoneda(objCompra.PercepcionIIBB);
                txtPercepcionLH.Text = Formulario.ValidarCampoMoneda(objCompra.PercepcionLH);
                txtPercepcionIVA.Text = Formulario.ValidarCampoMoneda(objCompra.PercepcionIVA);
                txtNoGravado.Text = Formulario.ValidarCampoMoneda(objCompra.NoGravado);
                txtImpuestoInterno.Text = Formulario.ValidarCampoMoneda(objCompra.ImpuestoInterno);
                lblTotal.Text = Formulario.ValidarCampoMoneda(objCompra.Total);
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objCompra.EdicionFecha) + " por " + objCompra.EdicionUsuarioDenominacion;
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objCompra = new Compra(
                (objCompra.Id <= 0) ? 0 : objCompra.Id,
                fechaActual,
                cmbPeriodo.Text + "-" + txtPeriodo.Text,
                Formulario.GenerarTipoComprobante(cmbAfipCbteTipo.Text),
                ((string.IsNullOrEmpty(txtAfipCbteTPV.Text)) ? 0 : Formulario.ValidarNumeroEntero(txtAfipCbteTPV.Text)),
                ((string.IsNullOrEmpty(txtAfipCbteNro.Text)) ? 0 : Formulario.ValidarNumeroEntero(txtAfipCbteNro.Text)),
                pkrAfipCbteFecha.Value,
                txtNumeroCodigoBarras.Text,
                objProveedor,
                new N_CuentaContable().obtenerObjeto("DENOMINACION", cmbCuentaContable.Text),
                pkrPagoVto.Value,
                _pagoEstado,
                (_controladorDeNuevoRegistro) ? false : (pkrPagoVto.Value <= fechaActual) ? true : false, //Evalua la alerta de Cobro
                ((string.IsNullOrEmpty(txtAsociacionID.Text)) ? 0 : Formulario.ValidarNumeroEntero64(txtAsociacionID.Text)),
                Formulario.GenerarTipoComprobante(txtAsociacionAfipCbteTipo.Text),
                ((string.IsNullOrEmpty(txtAsociacionAfipCbteTPV.Text)) ? 0 : Formulario.ValidarNumeroEntero(txtAsociacionAfipCbteTPV.Text)),
                ((string.IsNullOrEmpty(txtAsociacionAfipCbteNro.Text)) ? 0 : Formulario.ValidarNumeroEntero64(txtAsociacionAfipCbteNro.Text)),
                ((string.IsNullOrEmpty(txtAsociacionAfipCbteFecha.Text)) ? fechaActual : Fecha.ValidarFecha(txtAsociacionAfipCbteFecha.Text)),
                false,
                Formulario.ValidarNumeroDoble(lblDescuentoPorcentual.Text),
                Formulario.ValidarNumeroDoble(txtDescuento.Text),
                Formulario.ValidarNumeroDoble(lblSubTotal.Text),
                Formulario.ValidarNumeroDoble(lblIVA105.Text),
                Formulario.ValidarNumeroDoble(lblIVA210.Text),
                Formulario.ValidarNumeroDoble(lblIVA270.Text),
                Formulario.ValidarNumeroDoble(txtPercepcionIIBB.Text),
                Formulario.ValidarNumeroDoble(txtPercepcionLH.Text),
                Formulario.ValidarNumeroDoble(txtPercepcionIVA.Text),
                Formulario.ValidarNumeroDoble(txtNoGravado.Text),
                Formulario.ValidarNumeroDoble(txtImpuestoInterno.Text),
                Formulario.ValidarNumeroDoble(lblTotal.Text),
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            _idArticulo_ControladorDeModificacion = ""; //Libera el Id del Objeto seleccionado
            objProveedor = new Proveedor(); //Restaura el Objeto Primario
            objCompra = new Compra(); //Importante: Restaura el Objeto del Móludo
            listaDeCompraDetalle = new List<CompraDetalle>(); //Importante: Restaura la lista de Objetos del Móludo (Detalle)
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(
                new string[] { "ACTIVO CORRIENTE > BIENES DE USO", "ACTIVO CORRIENTE > BIENES DE CAMBIO", "EGRESOS > OTROS EGRESOS" }), 0); //Establece los items del ComboBox
            txtID.Text = "";
            txtFecha.Text = Fecha.SistemaFecha();
            cmbPeriodo.Text = fechaActual.Month.ToString().PadLeft(2, '0');
            txtPeriodo.Text = fechaActual.Year.ToString();
            cmbAfipCbteTipo.Text = "FAC-A";
            txtAfipCbteTPV.Text = "";
            txtAfipCbteNro.Text = "";
            pkrAfipCbteFecha.Value = fechaActual;
            txtNumeroCodigoBarras.Text = "";
            txtAsociacionID.Text = "";
            txtAsociacionID.Text = "";
            txtAsociacionAfipCbteTipo.Text = "";
            txtAsociacionAfipCbteTPV.Text = "";
            txtAsociacionAfipCbteNro.Text = "";
            txtAsociacionAfipCbteFecha.Text = "";
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            txtCategoriaIva.Text = "";
            cmbCuentaContable.Text = "COMPRA DE BIENES";
            pkrPagoVto.Value = fechaActual;
            _pagoEstado = "S/PAGAR";
            gridDetalle.Rows.Clear();
            lblDescuentoPorcentual.Text = "0,00";
            txtDescuento.Text = "0,00";
            lblSubTotal.Text = "0,00";
            lblIVA105.Text = "0,00";
            lblIVA210.Text = "0,00";
            lblIVA270.Text = "0,00";
            txtPercepcionIIBB.Text = "0,00";
            txtPercepcionLH.Text = "0,00";
            txtPercepcionIVA.Text = "0,00";
            txtNoGravado.Text = "0,00";
            txtImpuestoInterno.Text = "0,00";
            lblTotal.Text = "0,00";
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { cmbPeriodo, cmbAfipCbteTipo, txtAfipCbteTPV, txtAfipCbteNro,
                txtDenominacion, txtCuit, txtCategoriaIva, cmbCuentaContable }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(Compra objRegistro, List<CompraDetalle> detalle) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objCompraDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            listaDeCompraDetalleDB = detalle; //Importante: Se deben igualar la lista de Objetos precedentes con el actual (evita el error de nulidad) 
            escribirControles(objCompraDB, listaDeCompraDetalleDB); //Escribe los datos del registro seleccionado
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
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA (CBTE)")
            {
                Formulario.Visibilidad(false, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(true, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta }); //Verifica que se ha seleccionado el filtrado por fecha y habilita las casillas "desde y hasta"
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR ID")
            {
                cmbFiltroLista1.Enabled = false;
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
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
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR VTO. DE PAGO")
            {
                Formulario.Visibilidad(false, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(true, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta }); //Verifica que se ha seleccionado el filtrado por fecha y habilita las casillas "desde y hasta"
            }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por CUIT
            {
                consultaCompra = new string[] { "0", "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCompra.obtenerCatalago(0, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por CUIT
            {
                consultaCompra = new string[] { "0", "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCompra.obtenerCatalago(0, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA (CBTE)") //Verifica que el tipo de filtro es por Fecha de Comprobante
            {
                consultaCompra = new string[] { "0", "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nCompra.obtenerCatalago(0, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por Id Interno
            {
                consultaCompra = new string[] { "0", "ID", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCompra.obtenerCatalago(0, "ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR N° PV - CBTE" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por ID
            {
                consultaCompra = new string[] { "0", "COMPROBANTE", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCompra.obtenerCatalago(0, "COMPROBANTE", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR PERIODO" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por Periodo
            {
                consultaCompra = new string[] { "0", "PERIODO", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCompra.obtenerCatalago(0, "PERIODO", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR VTO. DE PAGO") //Verifica que el tipo de filtro es por Fecha de Pago
            {
                consultaCompra = new string[] { "0", "FECHA_PAGO", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nCompra.obtenerCatalago(0, "FECHA_PAGO", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objCompraDB = nCompra.obtenerObjeto("ID", idElemento.ToString(), true);
            listaDeCompraDetalleDB = nCompraDetalle.obtenerObjetos(objCompraDB.Id); //Almacena los item de detalle de comprobante
            escribirControles(objCompraDB, listaDeCompraDetalleDB); //Escribe los datos del registro seleccionado
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                if (consultaCompra.Length == 3)
                    lista = nCompra.obtenerCatalago(Convert.ToInt32(consultaCompra[0]), consultaCompra[1], consultaCompra[2], "CATALOGO1");
                else if (consultaCompra.Length == 4)
                    lista = nCompra.obtenerCatalago(Convert.ToInt32(consultaCompra[0]), consultaCompra[1], Fecha.ValidarFecha(consultaCompra[2]), Fecha.ValidarFecha(consultaCompra[3]), "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Tipo",
                    "N° Comprobante",
                    "Fecha",
                    "Periodo",
                    "F. de Pago",
                    "Total",
                    "Denominación",
                    "CUIT" };
            foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //Tipo
                        campo[1].Trim(), //Comprobante (PtoVta y Comprobante)
                        campo[2].Trim(), //Fecha
                        campo[3].Trim(), //Periodo
                        campo[4].Trim(), //Fecha de Pago
                        "$"+campo[5].Trim(), //Total
                        campo[6].Trim().Substring(0, 35), //Denominación
                        campo[6].Trim().Substring(36, 13) }; //CUIT
                  _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Comprobantes de Compra", subTitulos, new int[] { 7, 14, 10, 10, 10, 12, 53, 13 }, _listaDelReporte, new List<int> { 2, 3, 4 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Comprobantes de Compra", subTitulos, new float[] { 5, 12, 9, 9, 9, 11, 43, 12 }, _listaDelReporte); //Ancho: 111
            }
        }

        public override void asignarVariablesDeFormulario(string[] variablesDeFormulario)
        {
            if (variablesDeFormulario[0] == "Catalogo_Compra") //Catálogo de Comprobantes de Compras
            {
                Compra compra = nCompra.obtenerObjeto("ID", variablesDeFormulario[1], true);
                txtAsociacionID.Text = Convert.ToString(compra.Id).PadLeft(10, '0');
                txtAsociacionAfipCbteTipo.Text = Formulario.GenerarTipoComprobante(compra.AfipCbteTipo);
                txtAsociacionAfipCbteTPV.Text = Convert.ToString(compra.AfipCbteTPV).PadLeft(5, '0');
                txtAsociacionAfipCbteNro.Text = Convert.ToString(compra.AfipCbteNro).PadLeft(8, '0');
                txtAsociacionAfipCbteFecha.Text = Fecha.ConvertirFecha(compra.AfipCbteFecha);
                objProveedor = compra.Proveedor;
                txtDenominacion.Text = compra.Proveedor.Denominacion;
                txtCuit.Text = Convert.ToString(compra.Proveedor.Cuit);
                txtCategoriaIva.Text = Convert.ToString(compra.Proveedor.Iva);
                cmbCuentaContable.Text = compra.CuentaContable.Denominacion;
                listaDeCompraDetalle = nCompraDetalle.obtenerObjetos(compra.Id); //Almacena los item de detalle de comprobante
                agregarFilas(listaDeCompraDetalle); //Escribe los item en el detalle de comprobante
                #region Escribe los Totales
                lblDescuentoPorcentual.Text = Formulario.ValidarCampoMoneda(compra.DescuentoPorcentual);
                txtDescuento.Text = Formulario.ValidarCampoMoneda(compra.Descuento);
                txtPercepcionIIBB.Text = Formulario.ValidarCampoMoneda(compra.PercepcionIIBB);
                txtPercepcionLH.Text = Formulario.ValidarCampoMoneda(compra.PercepcionLH);
                txtPercepcionIVA.Text = Formulario.ValidarCampoMoneda(compra.PercepcionIVA);
                txtNoGravado.Text = Formulario.ValidarCampoMoneda(compra.NoGravado);
                txtImpuestoInterno.Text = Formulario.ValidarCampoMoneda(compra.ImpuestoInterno);
                determinarIVA(); //Ejecuta el método que determina el IVA en la cuadricula
                #endregion
            }
            else if (variablesDeFormulario[0] == "Catalogo_Proveedor") //Catálogo de Proveedores
            {
                this.objProveedor = new N_Proveedor().obtenerObjeto("TODOS", "ID", variablesDeFormulario[1], true);
                if (txtCuit.Text != objProveedor.Cuit) gridDetalle.Rows.Clear(); //Verifica si ha cambiado el CUIT. De ser asi, libera la cuadricula de cualquier item anteriormente cargado
                txtDenominacion.Text = objProveedor.Denominacion;
                txtCuit.Text = Convert.ToString(objProveedor.Cuit);
                txtCategoriaIva.Text = objProveedor.Iva;
                cmbCuentaContable.Text = objProveedor.CuentaContable.Denominacion;
                determinarIVA(); //Ejecuta el método que determina el IVA en la cuadricula
            }
        }
        #endregion
    }
}