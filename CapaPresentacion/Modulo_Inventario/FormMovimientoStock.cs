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
    public partial class FormMovimientoStock : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private string _idArticulo_ControladorDeModificacion = "";
        private long _idMovimientoStock = 0;
        string[] consultaMovimientoStock;
        private MovimientoStock objMovimientoStock;
        private List<MovimientoStockDetalle> objMovimientoStockDetalle;
        private N_Articulo nArticulo = new N_Articulo();
        private N_MovimientoStock nMovimientoStock = new N_MovimientoStock();
        private N_MovimientoStockDetalle nMovimientoStockDetalle = new N_MovimientoStockDetalle();
        #endregion

        public FormMovimientoStock()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormMovimientoStock_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(txtID, "Número de comprobante");
            toolTip.SetToolTip(txtFecha, "Fecha de comprobante");
            toolTip.SetToolTip(txtEstado, "Estado del comprobante");
            toolTip.SetToolTip(btnAgregarFila, "Agrega una fila a la cuadricula");
            toolTip.SetToolTip(btnQuitarFila, "Quita una fila de la cuadricula");
            toolTip.SetToolTip(btnBuscarFila, "Busca un artículo y lo agrega en la cuadricula");
            toolTip.SetToolTip(btnNuevo, "Crea un nuevo registro");
            toolTip.SetToolTip(btnGuardar, "Guarda los cambios realizados");
            toolTip.SetToolTip(btnCancelar, "Deshace los cambios realizados");
            toolTip.SetToolTip(btnAnular, "Anular un registro");
            toolTip.SetToolTip(btnWord_Comprobante, "Exporta el registro seleccionado a Word");
            #endregion
            #region Tipo de Datos
            gridDetalle.Columns[0].ValueType = typeof(System.String);
            gridDetalle.Columns[1].ValueType = typeof(System.String);
            gridDetalle.Columns[2].ValueType = typeof(System.Int32);
            #endregion
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO",
                "FILTRAR POR ESTADO: ANULADO", "TODOS LOS ESTADOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR FECHA", "FILTRAR POR ID" }, 0); //Establece los items del ComboBox
            pkrFiltroListaDesde.Text = Fecha.FechaProgramada(-3);
            pkrFiltroListaHasta.Text = Fecha.SistemaFecha();
            filtrarCatalogo(0); //Carga el catálogo
        }

        private void cmbDeposito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepositoOrigen.Text == "EMPREMINSA") txtDepositoDestino.Text = "VELADERO";
            if (cmbDepositoOrigen.Text == "VELADERO") txtDepositoDestino.Text = "EMPREMINSA";
        }
        #endregion

        #region Eventos de Cuadricula
        private void gridDetalle_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) _idArticulo_ControladorDeModificacion = Convert.ToString(gridDetalle.CurrentRow.Cells[0].Value); //Verifica que se este dentro de la celda ID y captura el valor inicial del ID 
            else if ((e.ColumnIndex == 3) && e.RowIndex >= 0)
            {
                // ---------- Bloque que despliega con un click los ComboBox de la cuadricula ---------- //
                if (gridDetalle.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && gridDetalle.CurrentCell.ReadOnly == false)
                {
                    gridDetalle.BeginEdit(true); //Coloca en modo edición a la celda
                    ((ComboBox)gridDetalle.EditingControl).DroppedDown = true; //Despliega el ComboBox
                }
            }
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
            if (gridDetalle.Columns[gridDetalle.CurrentCell.ColumnIndex].Index == 3)
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
                if (gridDetalle.CurrentCell.ColumnIndex == 4) gridDetalle.CurrentCell = gridDetalle.CurrentRow.Cells[0]; //Mueve el foco a la celda de la primera columna  
                else SendKeys.Send("{RIGHT}"); //Mueve el foco a la celda de la siguiente columna 
            }
        }

        private void gridDetalle_KeyPress(object sender, KeyPressEventArgs e)
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
            else if (gridDetalle.CurrentCell.ColumnIndex == 0 || gridDetalle.CurrentCell.ColumnIndex == 2) //Verifica que el ingreso de datos sea con números enteros dentro de la celda "Código" y "Cantidad"
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
            }
            else if (gridDetalle.CurrentCell.ColumnIndex == 1) //Verifica que el ingreso de datos sea en mayúsculas dentro de la celda "Denominación" 
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
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

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(71)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idMovimientoStock <= 0 && Global.UsuarioActivo_Privilegios.Contains(71)) //Verifica que el usuario posea el privilegio requerido
            {
                //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                if (ValidarCampoVacio() && validarCuadricula() && validarStock())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        objMovimientoStock.Id = nMovimientoStock.generarNumeroID(); //Paso 2: Asigna un numero de ID al Objeto
                        if (nMovimientoStock.insertar(objMovimientoStock, true)) //Paso 3: Inserta el objeto
                        {
                            _idMovimientoStock = objMovimientoStock.Id; //Paso 4: Iguala la variable local con el ID asignado
                            foreach (DataGridViewRow fila in gridDetalle.Rows) //Paso 5: Recorre las filas de la cuadricula 
                            {
                                #region Registra el Detalle
                                MovimientoStockDetalle objMovimientoStockDetalle = new MovimientoStockDetalle(
                                    nMovimientoStockDetalle.generarNumeroID(), //Paso 6: Asigna un numero de ID al Objeto
                                    objMovimientoStock,
                                    Formulario.ValidarNumeroEntero(fila.Cells[0].Value.ToString()), //ID Código
                                    fila.Cells[1].Value.ToString().Trim(), //Denominación
                                    Formulario.ValidarNumeroEntero(fila.Cells[2].Value.ToString()), //Cantidad
                                    fila.Cells[3].Value.ToString().Trim(), //Unidad
                                    fila.Cells[4].Value.ToString().Trim()); //Nro de Serie
                                nMovimientoStockDetalle.insertar(objMovimientoStockDetalle, true); //Paso 7: Inserta el Objeto en la Base de Datos
                                #endregion
                                actualizarArticulo("REGISTRACION", fila); //Paso 8: Actualiza los Costos y Stock de cada artículo 
                            }
                            mostrarDatos();
                        }
                    }
                }
                bool ValidarCampoVacio() // Método que valida los campos requeridos
                {
                    return Formulario.ValidarCampoVacio(false, new Control[] { cmbDepositoOrigen, txtDepositoDestino })
                    && gridDetalle.Rows.Count > 0;
                }
                void mostrarDatos() //Método que muestra en la pantalla los cambios generados
                {
                    filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
                    lstCatalogo.SelectedValue = _idMovimientoStock; //Posiona la selección de la fila en el registro guardado
                    escribirControles(nMovimientoStock.obtenerObjeto("ID", _idMovimientoStock.ToString(), true)); //Importante: Por ultimo re-Escribe todos los controles para mayor seguridad                      }
                }
            }
            else if (_idMovimientoStock <= 0) Mensaje.Restriccion();
            else if (_idMovimientoStock > 0) Mensaje.NoModificable();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idMovimientoStock > 0) escribirControles(nMovimientoStock.obtenerObjeto("ID", _idMovimientoStock.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(72)) //Verifica que el usuario posea el privilegio requerido
            {
                if (_idMovimientoStock > 0)
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea anular el comprobante ID: " + _idMovimientoStock.ToString() + "?") == DialogResult.Yes)
                    {
                            if (nMovimientoStock.anular(_idMovimientoStock, true)) //Paso 1: Anula el comprobante
                            {
                                foreach (DataGridViewRow fila in gridDetalle.Rows) //Paso 3: Recorre las filas de la cuadricula 
                                {
                                    actualizarArticulo("ANULACION", fila); //Paso 4: Actualiza los Costos y Stock de cada artículo
                                }
                            }
                            escribirControles(nMovimientoStock.obtenerObjeto("ID", _idMovimientoStock.ToString(), true)); //Re-Escribe los datos del objeto seleccionado
                            filtrarCatalogo(0); //Carga el catálogo
                     }
                }
            }
            else Mensaje.Restriccion();
        }

        private void btnWord_Comprobante_Click(object sender, EventArgs e)
        {
            if (_idMovimientoStock > 0)
            {
                if (objMovimientoStock.Estado == "ACTIVO")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string[] datoDB = {
                    objMovimientoStock.Id.ToString().PadLeft(8, '0'),
                    Fecha.ConvertirFechaHora(objMovimientoStock.Fecha),
                    objMovimientoStock.DepositoOrigen,
                    objMovimientoStock.DepositoDestino,
                    Fecha.ConvertirFecha(objMovimientoStock.FechaArribo),
                    objMovimientoStock.Observacion };
                    Reporte reporte = new Reporte();
                    reporte.crearDocumentoWord_Comprobante_MovimientoStock(objMovimientoStock.Id.ToString().PadLeft(8, '0'), datoDB, objMovimientoStockDetalle);
                    Cursor.Current = Cursors.Default;
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
                gridDetalle.Rows.Add("", "", "0", "UNI", "");
                gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                gridDetalle.FirstDisplayedScrollingRowIndex = gridDetalle.RowCount - 1; //Posiciona el scroll del gridDetalle en la celda seleccionada
                SendKeys.Send("{DOWN}"); //Mueve el foco a la nueva fila  
            }
        }

        private void agregarFilas(List<MovimientoStockDetalle> detalle)
        {
            gridDetalle.Rows.Clear();
            foreach (MovimientoStockDetalle item in detalle)
            {
                gridDetalle.Rows.Add();
                gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                gridDetalle.CurrentRow.Cells[0].Value = Convert.ToString(item.IdArticulo).PadLeft(6, '0');
                gridDetalle.CurrentRow.Cells[1].Value = Convert.ToString(item.Denominacion);
                gridDetalle.CurrentRow.Cells[2].Value = Convert.ToString(item.Cantidad);
                gridDetalle.CurrentRow.Cells[3].Value = Convert.ToString(item.Unidad);
                gridDetalle.CurrentRow.Cells[4].Value = Convert.ToString(item.NroSerie);
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

        private void escribirFila(int indiceFila, string idArticulo, Articulo objArticulo, bool actividad)
        {
            gridDetalle.Rows[indiceFila].Cells[0].Value = idArticulo;
            gridDetalle.Rows[indiceFila].Cells[1].Value = (objArticulo != null) ? objArticulo.Denominacion : "";
            gridDetalle.Rows[indiceFila].Cells[1].ReadOnly = actividad;
            gridDetalle.Rows[indiceFila].Cells[2].Value = "0";
            gridDetalle.Rows[indiceFila].Cells[3].Value = (objArticulo != null) ? objArticulo.Unidad : "UNI";
            gridDetalle.Rows[indiceFila].Cells[3].ReadOnly = actividad;
            gridDetalle.Rows[indiceFila].Cells[4].Value = "";
        }

        private void quitarFila()
        {
            if (_controladorDeNuevoRegistro)
            {
                gridDetalle.EndEdit(); //Importante: Esta linea corrige el error de llamas reentrantes
                if (gridDetalle.Rows.Count > 0) gridDetalle.Rows.Remove(gridDetalle.CurrentRow); //Elimina la fila correspondiente al botón clickeado
                gridDetalle.CurrentCell = null; //Posicionamiento - Paso 1: proceso de reposicionamiento
                if (gridDetalle.Rows.Count > 0) gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.Rows.Count - 1].Cells[0]; //Posicionamiento - Paso 2: proceso de reposicionamiento
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
                    else if (Formulario.ValidarNumeroEntero(fila.Cells[0].Value.ToString()) > 0) //Verifica que sea un artículo del inventario
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

        private bool validarStock()
        {
            if (gridDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in gridDetalle.Rows)
                {
                    int codigo = Formulario.ValidarNumeroEntero(fila.Cells[0].Value.ToString());
                    int cantidad = Formulario.ValidarNumeroEntero(fila.Cells[2].Value.ToString());
                    Articulo articulo = nArticulo.obtenerObjeto("TODOS", "ID", fila.Cells[0].Value.ToString(), false);
                    if (codigo > 0 && cmbDepositoOrigen.Text == "EMPREMINSA" && cantidad > articulo.A1_Stock) //Verifica que la cantidad ingresada No supere el stock del deposito seleccionado
                    {
                        // ---------- BLOQUE CONTROLADOR DE STOCK INSUFICIENTE ---------- //
                        Mensaje.Advertencia("Stock Insuficiente.\nVerifique el stock del artículo ID " + articulo.Id.ToString() + " e intente nuevamente.");
                        return false;
                    }
                    else if (codigo > 0 && cmbDepositoOrigen.Text == "VELADERO" && cantidad > articulo.A2_Stock) //Verifica que la cantidad ingresada No supere el stock del deposito seleccionado
                    {
                        // ---------- BLOQUE CONTROLADOR DE STOCK INSUFICIENTE ---------- //
                        Mensaje.Advertencia("Stock Insuficiente.\nVerifique el stock del artículo ID " + articulo.Id.ToString() + " e intente nuevamente.");
                        return false;
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
                        ""
                    );
                }
            }
        }
        #endregion

        #region Métodos de Formulario  
        private void actualizarArticulo(string operacion, DataGridViewRow fila)
        {
            if (int.TryParse(fila.Cells[0].Value.ToString(), out int codigo) && codigo > 0) //Verifica si es un artículo del inventario
            {
                int cantidad = Formulario.ValidarNumeroEntero(fila.Cells[2].Value.ToString());
                Articulo objArticulo = nArticulo.obtenerObjeto("TODOS", "ID", fila.Cells[0].Value.ToString().Trim(), false); //Paso 9: Arrastra los datos del artículo BD  
                objArticulo.Estado = "ACTIVO"; //Re-Establece forzadamente el estado del artículo
                if (operacion == "REGISTRACION")
                {
                    if (cmbDepositoOrigen.Text == "EMPREMINSA")
                    {
                        objArticulo.A1_Stock = objArticulo.A1_Stock - cantidad; //Resta la cantidad al stock del depósito de Empreminsa
                        objArticulo.A2_Stock = objArticulo.A2_Stock + cantidad; //Suma la cantidad al stock en el depósito de Veladero
                        objArticulo.A2_FechaIngreso = pkrFechaArribo.Value; //Actualiza la fecha de arribo en el depósito destino
                    }
                    else if (cmbDepositoOrigen.Text == "VELADERO")
                    {
                        objArticulo.A1_Stock = objArticulo.A1_Stock + cantidad; //Suma la cantidad al stock en el depósito de Empreminsa
                        objArticulo.A2_Stock = objArticulo.A2_Stock - cantidad; //Resta la cantidad al stock del depósito de Veladero
                        objArticulo.A1_FechaIngreso = pkrFechaArribo.Value; //Actualiza la fecha de arribo en el depósito destino
                    }
                }
                else if(operacion == "ANULACION")
                {
                    if (cmbDepositoOrigen.Text == "EMPREMINSA")
                    {
                        objArticulo.A1_Stock = objArticulo.A1_Stock + cantidad; //Suma la cantidad al stock del depósito de Empreminsa
                        objArticulo.A2_Stock = objArticulo.A2_Stock - cantidad; //Resta la cantidad al stock en el depósito de Veladero
                        objArticulo.A2_FechaIngreso = Fecha.DTSistemaFecha(); //Actualiza la fecha de arribo en el depósito destino
                    }
                    else if (cmbDepositoOrigen.Text == "VELADERO")
                    {
                        objArticulo.A1_Stock = objArticulo.A1_Stock - cantidad; //Resta la cantidad al stock en el depósito de Empreminsa
                        objArticulo.A2_Stock = objArticulo.A2_Stock + cantidad; //Suma la cantidad al stock del depósito de Veladero
                        objArticulo.A1_FechaIngreso = Fecha.DTSistemaFecha(); //Actualiza la fecha de arribo en el depósito destino
                    }
                }
                #region Puntos de Stock
                objArticulo.A1_PuntoCriticoAlertado = (objArticulo.A1_PuntoCritico && objArticulo.A1_Stock <= objArticulo.A1_PuntoCriticoLimite) ? false : true; //Determina el disparo de la alerta 
                objArticulo.A1_PuntoMinimoAlertado = (objArticulo.A1_PuntoMinimo && objArticulo.A1_Stock <= objArticulo.A1_PuntoMinimoLimite) ? false : true; //Determina el disparo de la alerta 
                objArticulo.A2_PuntoCriticoAlertado = (objArticulo.A2_PuntoCritico && objArticulo.A2_Stock <= objArticulo.A2_PuntoCriticoLimite) ? false : true; //Determina el disparo de la alerta 
                objArticulo.A2_PuntoMinimoAlertado = (objArticulo.A2_PuntoMinimo && objArticulo.A2_Stock <= objArticulo.A2_PuntoMinimoLimite) ? false : true; //Determina el disparo de la alerta 
                #endregion
                nArticulo.actualizar(objArticulo, false); //Actualiza los valores del artículo
            }

        }

        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(MovimientoStock objMovimientoStock)
        {
            this.objMovimientoStock = objMovimientoStock; //Obtiene los datos del objeto recibido
            if (objMovimientoStock != null)
            {
                _controladorDeNuevoRegistro = false;
                _idArticulo_ControladorDeModificacion = ""; //Libera el Id del Objeto seleccionado
                _idMovimientoStock = (objMovimientoStock != null) ? objMovimientoStock.Id : 0;
                txtID.Text = Convert.ToString(objMovimientoStock.Id).PadLeft(8, '0');
                txtFecha.Text = Fecha.ConvertirFecha(objMovimientoStock.Fecha);
                txtEstado.Text = objMovimientoStock.Estado;
                cmbDepositoOrigen.Text = objMovimientoStock.DepositoOrigen;
                txtDepositoDestino.Text = objMovimientoStock.DepositoDestino;
                pkrFechaArribo.Value = objMovimientoStock.FechaArribo;
                txtObservacion.Text = objMovimientoStock.Observacion;
                objMovimientoStockDetalle = new N_MovimientoStockDetalle().obtenerObjetos(_idMovimientoStock); //Almacena los item de detalle de comprobante
                agregarFilas(objMovimientoStockDetalle); //Escribe los item en el detalle de comprobante
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objMovimientoStock.EdicionFecha) + " por " + objMovimientoStock.EdicionUsuarioDenominacion;
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objMovimientoStock = new MovimientoStock(
                (_idMovimientoStock <= 0) ? 0 : _idMovimientoStock,
                fechaActual,
                "ACTIVO",
                cmbDepositoOrigen.Text,
                txtDepositoDestino.Text,
                pkrFechaArribo.Value,
                txtObservacion.Text,
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion
            );
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            _idArticulo_ControladorDeModificacion = ""; //Libera el Id del Objeto seleccionado
            _idMovimientoStock = 0; //Libera el Id del Objeto seleccionado
            txtID.Text = "00000000";
            txtFecha.Text = Fecha.SistemaFecha();
            txtEstado.Text = "ACTIVO";
            cmbDepositoOrigen.Text = "EMPREMINSA";
            txtDepositoDestino.Text = "VELADERO";
            pkrFechaArribo.Value = fechaActual;
            txtObservacion.Text = "";
            gridDetalle.Rows.Clear();
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { cmbDepositoOrigen, txtDepositoDestino }); //Restauración de campos invalidados
        }

        protected override void comboFiltro2()
        {
            if(cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA")
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
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroEstado = "TODOS";
            if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ACTIVO") filtroEstado = "ACTIVO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ANULADO") filtroEstado = "ANULADO";
            if(cmbFiltroLista2.Text == "FILTRAR POR FECHA") //Verifica que el tipo de filtro es por fecha
            {
                consultaMovimientoStock = new string[] { filtroEstado, "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nMovimientoStock.obtenerCatalago(filtroEstado, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if(cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por Id interno
            {
                consultaMovimientoStock = new string[] { filtroEstado, "ID", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nMovimientoStock.obtenerCatalago(filtroEstado, "ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            escribirControles(nMovimientoStock.obtenerObjeto("ID", idElemento.ToString(), true)); //Escribe los datos del registro seleccionado
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                if (consultaMovimientoStock.Length == 3)
                    lista = nMovimientoStock.obtenerCatalago(consultaMovimientoStock[0], consultaMovimientoStock[1], consultaMovimientoStock[2], "CATALOGO1");
                else if (consultaMovimientoStock.Length == 4)
                    lista = nMovimientoStock.obtenerCatalago(consultaMovimientoStock[0], consultaMovimientoStock[1], Fecha.ValidarFecha(consultaMovimientoStock[2]), Fecha.ValidarFecha(consultaMovimientoStock[3]), "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "N° Cbte.",
                    "Fecha",
                    "Estado",
                    "D. Origen",
                    "D. Destino",
                    "F. Arribo" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //N° Cbte.
                        campo[1].Trim(), //Fecha
                        campo[2].Trim(), //Estado
                        campo[3].Trim(), //Depósito origen
                        campo[4].Trim(), //Depósito destino
                        campo[5].Trim() }; //F. Arribo
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Movimientos de Stock", subTitulos, new int[] { 10, 10, 10, 10, 10, 79 }, _listaDelReporte, new List<int> { 1, 5 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Movimientos de Stock", subTitulos, new float[] { 9, 9, 9, 9, 9, 66 }, _listaDelReporte); //Ancho: 111
            }
        }

        public override void asignarVariablesDeFormulario(string[] variablesDeFormulario) { } //Método Sobrescribible
        #endregion
    }
}
