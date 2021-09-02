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
    public partial class FormOrdenCompra : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private string _idArticulo_ControladorDeModificacion = "";
        private string _primerElemento_CentroDeCosto = new N_CentroCosto().obtenerListaDeElementos(new string[] { })[0]; //Primer elemento de la lista de Centro de Costos
        string[] consultaOrdenCompra;
        private Proveedor objProveedor;
        private OrdenCompra objOrdenCompra;
        private OrdenCompra objOrdenCompraDB;
        private List<OrdenCompraDetalle> listaDeOrdenCompraDetalle;
        private List<OrdenCompraDetalle> listaDeOrdenCompraDetalleDB;
        private N_Articulo nArticulo = new N_Articulo();
        private N_Proveedor nProveedor = new N_Proveedor();
        private N_OrdenCompra nOrdenCompra = new N_OrdenCompra();
        private N_OrdenCompraDetalle nOrdenCompraDetalle = new N_OrdenCompraDetalle();
        private N_AsientoContable nAsientoContable = new N_AsientoContable();
        private N_CuentaContable nCuentaContable = new N_CuentaContable();
        #endregion

        #region Constructores
        public FormOrdenCompra()
        {
            InitializeComponent();
        }
        public FormOrdenCompra(OrdenCompra navOrdenCompra) //Utilizado por el navegador de formularios
        {
            objOrdenCompraDB = objOrdenCompra = navOrdenCompra;
            listaDeOrdenCompraDetalleDB = listaDeOrdenCompraDetalle = nOrdenCompraDetalle.obtenerObjetos(objOrdenCompraDB.Id);
            InitializeComponent();
        }
        #endregion

        #region Eventos de Formulario
        private void FormOrdenCompra_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(txtCbteTPV, "Punto de compra de comprobante");
            toolTip.SetToolTip(txtCbteNro, "Número de comprobante");
            toolTip.SetToolTip(pkrCbteFecha, "Fecha de comprobante");
            toolTip.SetToolTip(txtEstado, "Estado del comprobante");
            toolTip.SetToolTip(txtAutorizacion, "Estado de la autorización del comprobante");
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
            Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(new string[] { "ACTIVO CORRIENTE > BIENES DE USO", "ACTIVO CORRIENTE > BIENES DE CAMBIO" }), 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(ColCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { })); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO",
                "FILTRAR POR ESTADO: ANULADO", "TODOS LOS ESTADOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT",
                "FILTRAR POR DENOMINACION", "FILTRAR POR FECHA (CBTE)", "FILTRAR POR ID", "FILTRAR POR N° PV - CBTE" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
            if (objOrdenCompraDB != null) escribirControles(objOrdenCompraDB, listaDeOrdenCompraDetalleDB); //Escribe los datos solicitados mediante la navegación entre formularios
        }

        private void txtCbteTipo_TextChanged(object sender, EventArgs e)
        {
            determinarIVA();
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                FormCatalogo_Proveedor frm = new FormCatalogo_Proveedor(this, "ACTIVO");
                frm.ShowDialog(this);
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
            if (Global.UsuarioActivo_Privilegios.Contains(26)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objOrdenCompra != null)
            {
                if (objOrdenCompra.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(26)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarFechaComprobante() && ValidarCampoVacio() && validarCuadricula())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            this.objProveedor = nProveedor.obtenerObjeto("TODOS", "ID", objOrdenCompra.Proveedor.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                            this.listaDeOrdenCompraDetalle = new List<OrdenCompraDetalle>(); //Importante: Crea una nueva lista de Objetos por seguridad (libera los residuos de antiguas instancias)
                            objOrdenCompra.Id = nOrdenCompra.generarNumeroID(); //Paso 3: Genera un ID para cada Objeto
                            if (nOrdenCompra.insertar(objOrdenCompra)) //Paso 4: Inserta el objeto principal
                            {
                                #region Registra el Detalle
                                long idDetalle = nOrdenCompraDetalle.generarNumeroID(); //Paso 5: Asigna un numero de ID al Objeto
                                foreach (DataGridViewRow fila in gridDetalle.Rows)
                                {
                                    OrdenCompraDetalle objOrdenCompraDetalle = new OrdenCompraDetalle(
                                        idDetalle,
                                        objOrdenCompra,
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
                                    listaDeOrdenCompraDetalle.Add(objOrdenCompraDetalle); //Paso 6: Agrega el Objeto en la lista de Objetos
                                    idDetalle++; //Importante: Incrementa el valor del ID Detalle
                                    /* Nota: Cuando hay más de un ítem en el detalle: El valor del ID se debe incrementar
                                     * iterativamente ya que el generador no brinda esta solución porque solo puede calcular
                                     * el valor del máximo de ID de los ítems existentes en la Base de Datos. En este caso
                                     * es solo una lista de objetos que aun No han sido insertados).*/
                                }
                                if (nOrdenCompraDetalle.insertar(listaDeOrdenCompraDetalle)) actualizarArticulo("REGISTRACION", listaDeOrdenCompraDetalle); //Paso 7: Inserta la lista de Objetos en la Base de Datos. De ser corecto, posteriormente actualiza el Costo y Stock de cada Artículo 
                                #endregion
                                mostrarRegistro(objOrdenCompra, listaDeOrdenCompraDetalle);
                                Mensaje.RegistroCorrecto("REGISTRACION");
                            }
                        }
                    }
                }
                else if (objOrdenCompra.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(29)) //Verifica que el usuario posea el privilegio requerido
                {
                    if (objOrdenCompra.CbteFecha.AddDays(Global.RegistroModificacion) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                        if (ValidarCampoVacio() && ValidarFechaComprobante() && validarCuadricula())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                this.objProveedor = nProveedor.obtenerObjeto("TODOS", "ID", objOrdenCompra.Proveedor.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                                this.listaDeOrdenCompraDetalle = new List<OrdenCompraDetalle>(); //Importante: Crea una nueva lista de Objetos por seguridad (libera los residuos de antiguas instancias)
                                #region Lectura del Detalle
                                foreach (DataGridViewRow fila in gridDetalle.Rows)
                                {
                                    OrdenCompraDetalle objOrdenCompraDetalle = new OrdenCompraDetalle(
                                        Formulario.ValidarNumeroEntero(fila.Cells[10].Value.ToString()), //Id Detalle
                                        objOrdenCompra,
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
                                    listaDeOrdenCompraDetalle.Add(objOrdenCompraDetalle); //Paso 3: Agrega el Objeto en la lista de Objetos
                                }
                                #endregion
                                if (!objOrdenCompra.Equals(objOrdenCompraDB) || !nOrdenCompraDetalle.compararDetalle(listaDeOrdenCompraDetalleDB, listaDeOrdenCompraDetalle)) //Paso 5: Verifica que el Objeto y/o Detalle se han modificado 
                                {
                                    if (nOrdenCompra.actualizar(objOrdenCompra)) //Paso 6: Actualiza el Objeto y Detalle
                                    {
                                        if (nOrdenCompraDetalle.actualizar(listaDeOrdenCompraDetalle)) actualizarArticulo("MODIFICACION", listaDeOrdenCompraDetalle); //Paso 7: Actualiza la lista de Objetos en la Base de Datos. De ser corecto, posteriormente actualiza el Costo y Stock de cada Artículo 
                                        mostrarRegistro(objOrdenCompra, listaDeOrdenCompraDetalle);
                                        Mensaje.RegistroCorrecto("MODIFICACION");
                                    }
                                }
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación Incorrecta. Los comprobantes que han superado los " + Global.RegistroModificacion + " días de su registración No pueden ser modificados.");
                }
                else Mensaje.Restriccion();
                bool ValidarCampoVacio() // Método que valida los campos requeridos
                {
                    return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion, txtCuit,
                    txtCategoriaIva, cmbCuentaContable })
                    && Formulario.ValidarNumeroDoble(lblTotal.Text) > 0;
                }
                bool ValidarFechaComprobante() //Método que valida la fecha del comprobante
                {
                    if (pkrCbteFecha.Value.Date > Fecha.DTSistemaFecha().Date)
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
            if (objOrdenCompra.Id > 0) escribirControles(objOrdenCompraDB, listaDeOrdenCompraDetalleDB); //Restaura los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(27)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objOrdenCompra.Id > 0)
                {
                    if (objOrdenCompra.CbteFecha.AddDays(Global.RegistroAnulacion) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea anular el registro ID: " + objOrdenCompra.Id.ToString() + "?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            objProveedor = nProveedor.obtenerObjeto("TODOS", "ID", objOrdenCompra.Proveedor.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                            if (nOrdenCompra.anular(objOrdenCompra)) //Paso 3: Verifica el exito de la actualización y muestra los datos actualizados
                            {
                                objOrdenCompra.Estado = "ANULADO"; //Paso 4: Importante: Establece el cambio de estado en el Objeto del Módulo 
                                actualizarArticulo("ANULACION", listaDeOrdenCompraDetalle); //Paso 5: Actualiza la Fecha de Ingreso de cada Artículo
                                mostrarRegistro(objOrdenCompra, listaDeOrdenCompraDetalleDB);
                                Mensaje.RegistroCorrecto("ANULACION");
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación Incorrecta. Los comprobantes que han superado los " + Global.RegistroAnulacion + " días de su registración No pueden ser anulados.");
                }
            }
            else Mensaje.Restriccion();
        }

        private void btnAutorizar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(28)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objOrdenCompra.Id > 0)
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea autorizar el comprobante ID: " + objOrdenCompra.Id.ToString() + "?") == DialogResult.Yes)
                    {
                        if (nOrdenCompra.autorizar(objOrdenCompra, true)) objOrdenCompra.Autorizacion = "AUTORIZADO"; //Autoriza el comprobante
                        mostrarRegistro(objOrdenCompra, listaDeOrdenCompraDetalle);
                    }
                }
            }
            else Mensaje.Restriccion();
        }

        private void btnWord_Comprobante_Click(object sender, EventArgs e)
        {
              if (objOrdenCompra.Id > 0)
              {
                  if (objOrdenCompra.Estado == "ACTIVO")
                  {
                      if (objOrdenCompra.Autorizacion == "AUTORIZADO")
                      {
                          Cursor.Current = Cursors.WaitCursor;
                          string[] datoDB = {
                              objOrdenCompra.CbteTPV.ToString().PadLeft(5, '0'),
                              objOrdenCompra.CbteNro.ToString().PadLeft(8, '0'),
                              Fecha.ConvertirFechaHora(objOrdenCompra.CbteFecha),
                              objOrdenCompra.Proveedor.Denominacion,
                              objOrdenCompra.Proveedor.Domicilio,
                              objOrdenCompra.Proveedor.Provincia,
                              objOrdenCompra.Proveedor.Distrito,
                              objOrdenCompra.Proveedor.Cp,
                              objOrdenCompra.Proveedor.Telefono + " " + objOrdenCompra.Proveedor.Celular,
                              objOrdenCompra.Proveedor.Cuit,
                              objOrdenCompra.Proveedor.Iva,
                              Fecha.ConvertirFecha(objOrdenCompra.FechaArribo),
                              Formulario.ValidarCampoMoneda(objOrdenCompra.Descuento),
                              Formulario.ValidarCampoMoneda(objOrdenCompra.Subtotal),
                              Formulario.ValidarCampoMoneda(objOrdenCompra.Iva105),
                              Formulario.ValidarCampoMoneda(objOrdenCompra.Iva210),
                              Formulario.ValidarCampoMoneda(objOrdenCompra.Iva270),
                              Formulario.ValidarCampoMoneda(objOrdenCompra.PercepcionIIBB),
                              Formulario.ValidarCampoMoneda(objOrdenCompra.PercepcionLH),
                              Formulario.ValidarCampoMoneda(objOrdenCompra.PercepcionIVA),
                              Formulario.ValidarCampoMoneda(objOrdenCompra.ImpuestoInterno + objOrdenCompra.NoGravado),
                              Formulario.ValidarCampoMoneda(objOrdenCompra.Total) };
                          Reporte reporte = new Reporte();
                          reporte.crearDocumentoWord_Comprobante_OrdenCompra(objOrdenCompra.Proveedor.Denominacion, datoDB, listaDeOrdenCompraDetalle);
                          Cursor.Current = Cursors.Default;
                      }
                      else Mensaje.Advertencia("Operación incorrecta.\nSeleccione un comprobante autorizado e intente nuevamente.");
                  }
                  else Mensaje.Advertencia("Operación incorrecta.\nSeleccione un comprobante ACTIVO e intente nuevamente.");
              }
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

        private void agregarFilas(List<OrdenCompraDetalle> detalle)
        {
            gridDetalle.Rows.Clear();
            foreach (OrdenCompraDetalle item in detalle)
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
                FormCatalogo_Articulo frm = new FormCatalogo_Articulo(this, "FILTRAR POR ESTADO: ACTIVO", true);
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
                            Articulo objArticulo = (idCodigo.Length <= 6) ? nArticulo.obtenerObjeto("TODOS", "ID", idCodigo.Trim(), true) : nArticulo.obtenerObjeto("TODOS", "CODIGO_BARRAS", idCodigo, true); //Consulta que ejecuta una busqueda en la Base de Datos por Código de Barras o ID
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
            double costoUnitario = string.IsNullOrWhiteSpace(Convert.ToString(gridDetalle.Rows[indiceFila].Cells[5].Value)) ? 0 : Formulario.ValidarNumeroDoble(Convert.ToString(gridDetalle.Rows[indiceFila].Cells[5].Value).Replace(".", ",")); //Costo Unitario
            double alicuotaIVA = string.IsNullOrWhiteSpace(Convert.ToString(gridDetalle.Rows[indiceFila].Cells[6].EditedFormattedValue)) ? 0 : Formulario.ValidarNumeroDoble(Convert.ToString(gridDetalle.Rows[indiceFila].Cells[6].EditedFormattedValue).Replace(".", ",")); //Alícuota IVA
            double totalBruto = cantidad * costoUnitario; //Total Bruto
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
                                && fila.Cells[4].Value.ToString() == filaDuplicada.Cells[4].Value.ToString()) controladorDeDuplicado += 1;
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
        private void actualizarArticulo(string operacion, List<OrdenCompraDetalle> detalle)
        {
            if (detalle.Count > 0)
            {
                foreach (OrdenCompraDetalle objOrdenCompraDetalle in detalle)
                {
                    if (objOrdenCompraDetalle.IdArticulo > 0) //Verifica si es un artículo del inventario
                    {
                        Articulo objArticulo = nArticulo.obtenerObjeto("TODOS", "ID", objOrdenCompraDetalle.IdArticulo.ToString().Trim(), false); //Obtiene los datos del artículo BD  
                        objArticulo.Estado = "ACTIVO"; //Re-Establece forzadamente el estado del artículo
                        if (operacion == "REGISTRACION" || operacion == "MODIFICACION") //Verifica si es una Orden de Compra. En ese caso, actualiza el Deposito y Fecha de Reposición del artículo 
                        {
                            if (objOrdenCompraDetalle.Deposito == "EMPREMINSA") objArticulo.A1_FechaIngreso = pkrFechaArribo.Value; //Verifica si el desposito es el de Empreminsa. En ese caso, actualiza la fecha de re-ingreso  
                            else if (objOrdenCompraDetalle.Deposito == "VELADERO") objArticulo.A2_FechaIngreso = pkrFechaArribo.Value; //Verifica si el desposito es el de Empreminsa. En ese caso, actualiza la fecha de re-ingreso
                        }
                        else if (operacion == "ANULACION") //Verifica si es una Orden de Compra. En ese caso, actualiza el Deposito y Fecha de Reposición del artículo 
                        {
                            if (objOrdenCompraDetalle.Deposito == "EMPREMINSA") objArticulo.A1_FechaIngreso = Fecha.DTSistemaFecha(); //Verifica si el desposito es el de Empreminsa. En ese caso, actualiza la fecha de re-ingreso  
                            else if (objOrdenCompraDetalle.Deposito == "VELADERO") objArticulo.A2_FechaIngreso = Fecha.DTSistemaFecha(); //Verifica si el desposito es el de Empreminsa. En ese caso, actualiza la fecha de re-ingreso
                        }
                        nArticulo.actualizar(objArticulo, false); //Actualiza los valores del artículo
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

        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(OrdenCompra objRegistro, List<OrdenCompraDetalle> detalle)
        {
            this.objOrdenCompra = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            this.listaDeOrdenCompraDetalle = detalle; //Iguala el Atributo de la clase con la lista de Objetos recibidos
            if (objOrdenCompra != null)
            {
                _controladorDeNuevoRegistro = false;
                _idArticulo_ControladorDeModificacion = ""; //Libera el Id del Objeto seleccionado
                txtCbteTPV.Text = Convert.ToString(objOrdenCompra.CbteTPV).PadLeft(5, '0');
                txtCbteNro.Text = Convert.ToString(objOrdenCompra.CbteNro).PadLeft(8, '0');
                pkrCbteFecha.Value = objOrdenCompra.CbteFecha;
                txtEstado.Text = objOrdenCompra.Estado;
                txtAutorizacion.Text = objOrdenCompra.Autorizacion;
                objProveedor = objOrdenCompra.Proveedor;
                txtDenominacion.Text = objOrdenCompra.Proveedor.Denominacion;
                txtCuit.Text = objOrdenCompra.Proveedor.Cuit;
                txtCategoriaIva.Text = objOrdenCompra.Proveedor.Iva;
                cmbCuentaContable.Text = objOrdenCompra.CuentaContable.Denominacion;
                pkrFechaArribo.Value = objOrdenCompra.FechaArribo;
                agregarFilas(listaDeOrdenCompraDetalle); //Escribe los item en el detalle de comprobante
                lblDescuentoPorcentual.Text = Formulario.ValidarCampoMoneda(objOrdenCompra.DescuentoPorcentual);
                txtDescuento.Text = Formulario.ValidarCampoMoneda(objOrdenCompra.Descuento);
                lblSubTotal.Text = Formulario.ValidarCampoMoneda(objOrdenCompra.Subtotal);
                lblIVA105.Text = Formulario.ValidarCampoMoneda(objOrdenCompra.Iva105);
                lblIVA210.Text = Formulario.ValidarCampoMoneda(objOrdenCompra.Iva210);
                lblIVA270.Text = Formulario.ValidarCampoMoneda(objOrdenCompra.Iva270);
                txtPercepcionIIBB.Text = Formulario.ValidarCampoMoneda(objOrdenCompra.PercepcionIIBB);
                txtPercepcionLH.Text = Formulario.ValidarCampoMoneda(objOrdenCompra.PercepcionLH);
                txtPercepcionIVA.Text = Formulario.ValidarCampoMoneda(objOrdenCompra.PercepcionIVA);
                txtNoGravado.Text = Formulario.ValidarCampoMoneda(objOrdenCompra.NoGravado);
                txtImpuestoInterno.Text = Formulario.ValidarCampoMoneda(objOrdenCompra.ImpuestoInterno);
                lblTotal.Text = Formulario.ValidarCampoMoneda(objOrdenCompra.Total);
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objOrdenCompra.EdicionFecha) + " por " + objOrdenCompra.EdicionUsuarioDenominacion;
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objOrdenCompra = new OrdenCompra(
                (objOrdenCompra.Id <= 0) ? 0 : objOrdenCompra.Id,
                ((string.IsNullOrEmpty(txtCbteTPV.Text)) ? 0 : Formulario.ValidarNumeroEntero(txtCbteTPV.Text)),
                ((string.IsNullOrEmpty(txtCbteNro.Text)) ? 0 : Formulario.ValidarNumeroEntero(txtCbteNro.Text)),
                pkrCbteFecha.Value,
                "ACTIVO",
                "S/AUTORIZAR",
                objProveedor,
                new N_CuentaContable().obtenerObjeto("DENOMINACION", cmbCuentaContable.Text),
                pkrFechaArribo.Value,
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
            objOrdenCompra = new OrdenCompra(); //Importante: Restaura el Objeto del Móludo
            listaDeOrdenCompraDetalle = new List<OrdenCompraDetalle>(); //Importante: Restaura la lista de Objetos del Móludo (Detalle)
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(new string[] { "ACTIVO CORRIENTE > BIENES DE USO", "ACTIVO CORRIENTE > BIENES DE CAMBIO" }), 0); //Re-Establece los items del ComboBox
            txtCbteTPV.Text = "";
            txtCbteNro.Text = "";
            pkrCbteFecha.Value = fechaActual;
            txtEstado.Text = "ACTIVO";
            txtAutorizacion.Text = "S/AUTORIZAR";
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            txtCategoriaIva.Text = "";
            cmbCuentaContable.Text = "COMPRA DE BIENES";
            pkrFechaArribo.Value = fechaActual;
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
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, txtCuit, txtCategoriaIva,
                cmbCuentaContable }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(OrdenCompra objRegistro, List<OrdenCompraDetalle> detalle) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objOrdenCompraDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            listaDeOrdenCompraDetalleDB = detalle; //Importante: Se deben igualar la lista de Objetos precedentes con el actual (evita el error de nulidad) 
            escribirControles(objOrdenCompraDB, listaDeOrdenCompraDetalleDB); //Escribe los datos del registro seleccionado
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR CUIT")
            {
                cmbFiltroLista1.Enabled = true;
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
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA (CBTE)")
            {
                cmbFiltroLista1.Enabled = true;
                Formulario.Visibilidad(false, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(true, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta }); //Verifica que se ha seleccionado el filtrado por fecha y habilita las casillas "desde y hasta"
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR ID")
            {
                cmbFiltroLista1.Enabled = false;
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR N° PV - CBTE")
            {
                cmbFiltroLista1.Enabled = false;
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
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
                consultaOrdenCompra = new string[] { filtroEstado, "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nOrdenCompra.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por CUIT
            {
                consultaOrdenCompra = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nOrdenCompra.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA (CBTE)") //Verifica que el tipo de filtro es por Fecha de Comprobante
            {
                consultaOrdenCompra = new string[] { filtroEstado, "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nOrdenCompra.obtenerCatalago(filtroEstado, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por Id Interno
            {
                consultaOrdenCompra = new string[] { filtroEstado, "ID", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nOrdenCompra.obtenerCatalago(filtroEstado, "ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR N° PV - CBTE" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por ID
            {
                consultaOrdenCompra = new string[] { filtroEstado, "COMPROBANTE", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nOrdenCompra.obtenerCatalago(filtroEstado, "COMPROBANTE", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objOrdenCompraDB = nOrdenCompra.obtenerObjeto("ID", idElemento.ToString(), true);
            listaDeOrdenCompraDetalleDB = nOrdenCompraDetalle.obtenerObjetos(objOrdenCompraDB.Id); //Almacena los item de detalle de comprobante
            escribirControles(objOrdenCompraDB, listaDeOrdenCompraDetalleDB); //Escribe los datos del registro seleccionado
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                if (consultaOrdenCompra.Length == 3)
                    lista = nOrdenCompra.obtenerCatalago(consultaOrdenCompra[0], consultaOrdenCompra[1], consultaOrdenCompra[2], "CATALOGO1");
                else if (consultaOrdenCompra.Length == 4)
                    lista = nOrdenCompra.obtenerCatalago(consultaOrdenCompra[0], consultaOrdenCompra[1], Fecha.ValidarFecha(consultaOrdenCompra[2]), Fecha.ValidarFecha(consultaOrdenCompra[3]), "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "N° Comprobante",
                    "Fecha",
                    "Estado",
                    "Autorización",
                    "F. Arribo",
                    "Total",
                    "Denominación",
                    "CUIT" };
            foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //Comprobante (PtoVta y Comprobante)
                        campo[1].Trim(), //Fecha
                        campo[2].Trim(), //Estado
                        campo[3].Trim(), //Autorización
                        campo[4].Trim(), //Arribo Estimado
                        "$"+campo[5].Trim(), //Total
                        campo[6].Trim().Substring(0, 35), //Denominación
                        campo[6].Trim().Substring(36, 13) }; //CUIT
                  _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Ordenes de Compra", subTitulos, new int[] { 14, 10, 10, 10, 12, 14, 46, 13 }, _listaDelReporte, new List<int> { 1, 4 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Ordenes de Compra", subTitulos, new float[] { 12, 9, 9, 9, 10, 13, 37, 12 }, _listaDelReporte); //Ancho: 111
            }
        }

        public override void asignarVariablesDeFormulario(string[] variablesDeFormulario) //Método Sobrescribible
        {
            if (variablesDeFormulario[0] == "Catalogo_Proveedor") //Catálogo de Proveedores
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