using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormAsientoManual : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private string _codigoCuentaContable_ControladorDeModificacion = "";
        private long _idAsientoManual = 0;
        private string _primerElemento_CuentaContable = new N_CuentaContable().obtenerListaDeElementos(new string[] { })[0];  //Primer elemento de la lista de Cuentas Contables
        private string[] consultaAsientoManual;
        private AsientoManual objAsientoManual;
        private List<AsientoManualDetalle> objAsientoManualDetalle;
        private N_AsientoManual nAsientoManual = new N_AsientoManual();
        private N_AsientoManualDetalle nAsientoManualDetalle = new N_AsientoManualDetalle();
        private N_AsientoContable nAsientoContable = new N_AsientoContable();
        private N_CuentaContable nCuentaContable = new N_CuentaContable();
        #endregion

        #region Constructores
        public FormAsientoManual()
        {
            InitializeComponent();
        }
        public FormAsientoManual(AsientoManual navAsientoManual) //Utilizado por el navegador de formularios
        {
            objAsientoManual = navAsientoManual;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormAsientoManual_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(txtCbteTPV, "Punto de venta");
            toolTip.SetToolTip(txtCbteNro, "Número de comprobante");
            toolTip.SetToolTip(pkrCbteFecha, "Fecha de comprobante");
            toolTip.SetToolTip(txtEstado, "Estado del comprobante");
            #endregion
            #region Tipo de Datos
            gridDetalle.Columns[0].ValueType = typeof(System.Int32);
            gridDetalle.Columns[1].ValueType = typeof(System.String);
            gridDetalle.Columns[2].ValueType = typeof(System.Double);
            gridDetalle.Columns[3].ValueType = typeof(System.Double);
            gridDetalle.Columns[4].ValueType = typeof(System.String);
            #endregion
            Formulario.ComboBox_CargarElementos(cmbCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { }), 0);
            Formulario.ComboBox_CargarElementos(ColCuentaContable, new N_CuentaContable().obtenerListaDeElementos(new string[] { "ACTIVO CORRIENTE > DISPONIBILIDADES" }, true)); //Establece los items del ComboBox (excluye las cuentas indicadas)
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO", "FILTRAR POR ESTADO: ANULADO", "TODOS LOS ESTADOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR DENOMINACION", "FILTRAR POR FECHA",
                "FILTRAR POR N° PV - CBTE" }, 0); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo      
            if (objAsientoManual != null) escribirControles(objAsientoManual); //Escribe los datos solicitados mediante la navegación entre formularios
        }
        #endregion

        #region Eventos de Cuadricula
        private void gridDetalle_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) _codigoCuentaContable_ControladorDeModificacion = Convert.ToString(gridDetalle.CurrentRow.Cells[0].Value); //Verifica que se este dentro de la celda ID y captura el valor inicial del ID 
            if ((e.ColumnIndex == 1 || e.ColumnIndex == 4) && e.RowIndex >= 0)
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
                    gridDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = gridDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().PadLeft(6, '0'); //Formatea el código de la Cuenta Contable
                    buscarCuentaContableCodigo(e.RowIndex, Convert.ToString(gridDetalle.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)); //Busca el ID ingresado en la Base de Datos
                    if (e.RowIndex != (gridDetalle.RowCount - 1)) SendKeys.Send("{UP}"); //Bloque 1a: Mantiene el foco en la celda editada
                }
                else if ((e.ColumnIndex == 2 || e.ColumnIndex == 3) && e.RowIndex >= 0) //Verifica que se este dentro de la celda "Debe" ó "Haber" 
                {
                    if (e.RowIndex != (gridDetalle.RowCount - 1)) SendKeys.Send("{UP}"); //Bloque 1b: Mantiene el foco en la celda editada
                    calcularTotal(); //Calcula el Total del comprobante
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
            if (gridDetalle.CurrentCell.ColumnIndex == 1) gridDetalle.CurrentRow.Cells[0].Value = new N_CuentaContable().obtenerObjeto("DENOMINACION", Convert.ToString(gridDetalle.CurrentCell.Value)).Codigo;
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
            if (gridDetalle.Columns[gridDetalle.CurrentCell.ColumnIndex].Index == 1 || gridDetalle.Columns[gridDetalle.CurrentCell.ColumnIndex].Index == 4)
            {
                DataGridViewComboBoxEditingControl cmbCuadricula = e.Control as DataGridViewComboBoxEditingControl; //Convierte el control en un comboBox
                cmbCuadricula.KeyDown -= new KeyEventHandler(gridDetalle_ComboBox_KeyDown); //Paso 1: Elimina la redundancia del delegado del evento KeyDown
                cmbCuadricula.KeyDown += new KeyEventHandler(gridDetalle_ComboBox_KeyDown); //Paso 2: Agrega el delegado del evento KeyDown
                if (gridDetalle.Columns[gridDetalle.CurrentCell.ColumnIndex].Index == 1)
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
                else if (e.KeyChar == '+') //Tecla de Acesso Directo "Agregar Fila"
                {
                    e.Handled = true;
                    agregarFila();
                }
                else if (gridDetalle.CurrentCell.ColumnIndex == 0) //Verifica que el ingreso de datos sea con números enteros dentro de la celda "Código"
                {
                    if ((!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) || !_controladorDeNuevoRegistro) e.Handled = true;
                }
                else if (gridDetalle.CurrentCell.ColumnIndex == 2 || gridDetalle.CurrentCell.ColumnIndex == 3) //Verifica que el ingreso de datos sea con números decimales dentro de la celda "Debe" y "Haber"
                {
                    Formulario.ValidarCampoMoneda(e, gridDetalle.CurrentCell.GetEditedFormattedValue(gridDetalle.CurrentRow.Index, DataGridViewDataErrorContexts.Display).ToString());
                }
            }
        }

        private void gridDetalle_Leave(object sender, EventArgs e)
        {
            if (gridDetalle.Rows.Count > 0)
            {
                _codigoCuentaContable_ControladorDeModificacion = ""; //Importante: Restaura el controlador de modificacion de artículo
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
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(34)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idAsientoManual <= 0 && Global.UsuarioActivo_Privilegios.Contains(34)) //Verifica que el usuario posea el privilegio requerido
            {
                //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                if (_controladorDeNuevoRegistro && ValidarCampoVacio() && validarCuadricula())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        objAsientoManual.Id = nAsientoManual.generarNumeroID(); //Paso 2: Asigna un numero de ID al Objeto
                        objAsientoManual.CbteNro = objAsientoManual.Id; //Paso 3: Establece el valor del ID como número de comprobante
                        if (nAsientoManual.insertar(objAsientoManual)) //Paso 4: Inserta el objeto
                        {
                            _idAsientoManual = objAsientoManual.Id; //Paso 5: Iguala la variable local con el ID asignado
                            foreach (DataGridViewRow fila in gridDetalle.Rows) //Paso 6: Recorre las filas de la cuadricula 
                            {
                                #region Registra el Detalle
                                AsientoManualDetalle objAsientoManualDetalle = new AsientoManualDetalle(
                                nAsientoManualDetalle.generarNumeroID(), //Paso 7: Asigna un numero de ID al Objeto
                                objAsientoManual,
                                nCuentaContable.obtenerObjeto("DENOMINACION", Convert.ToString(fila.Cells[1].Value).Trim()), //Cuenta contable
                                Formulario.ValidarNumeroDoble(fila.Cells[2].Value.ToString()), //Debe
                                Formulario.ValidarNumeroDoble(fila.Cells[3].Value.ToString()), //Haber
                                fila.Cells[4].Value.ToString().Trim()); //Conciliación
                            nAsientoManualDetalle.insertar(objAsientoManualDetalle); //Paso 7: Inserta el Objeto en la Base de Datos
                            #endregion
                            }
                            asentarTransaccion("REGISTRACION"); //Paso 8: Registra el/los Asiento/s Contable/s
                            mostrarDatos();
                        }
                    }
                }
            }
            else if (_idAsientoManual > 0 && Global.UsuarioActivo_Privilegios.Contains(36)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objAsientoManual.CbteFecha.AddDays(10) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                {
                    if (objAsientoManual.Estado == "ACTIVO") //Verifica si el comprobante esta activo
                    {
                        //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                        if (ValidarCampoVacio() && validarCuadricula())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                if (nAsientoManual.actualizar(objAsientoManual)) //Paso 2: Actualizar el objeto
                                {
                                    foreach (DataGridViewRow fila in gridDetalle.Rows) //Paso 3: Recorre las filas de la cuadricula 
                                    {
                                        AsientoManualDetalle objAsientoManualDetalle = nAsientoManualDetalle.obtenerObjeto("ID", fila.Cells[5].Value.ToString(), false);
                                        #region Registra el Detalle
                                        objAsientoManualDetalle = new AsientoManualDetalle(
                                            Formulario.ValidarNumeroEntero(fila.Cells[5].Value.ToString()), //Id Detalle
                                            objAsientoManual,
                                            nCuentaContable.obtenerObjeto("DENOMINACION", Convert.ToString(fila.Cells[1].Value).Trim()), //Cuenta contable
                                            Formulario.ValidarNumeroDoble(fila.Cells[2].Value.ToString()), //Debe
                                            Formulario.ValidarNumeroDoble(fila.Cells[3].Value.ToString()), //Haber
                                            fila.Cells[4].Value.ToString().Trim()); //Conciliación
                                        nAsientoManualDetalle.actualizar(objAsientoManualDetalle); //Paso 4: Inserta el Objeto en la Base de Datos
                                        #endregion                                    }
                                    }
                                    asentarTransaccion("MODIFICACION"); //Paso 5: Registra el/los Asiento/s Contable/s
                                }
                                mostrarDatos();
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación incorrecta.\nLos comprobantes anulados No pueden ser modificados.");
                }
                else Mensaje.Advertencia("Operación Incorrecta. Los comprobantes que han superado los 10 días de su registración No pueden ser modificados.");
            }
            else Mensaje.Restriccion();
            bool ValidarCampoVacio() // Método que valida los campos requeridos
            {
                return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion, cmbCentroCosto  });
            }
            void mostrarDatos() //Método que muestra en la pantalla los cambios generados
            {
                filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
                lstCatalogo.SelectedValue = _idAsientoManual; //Posiona la selección de la fila en el registro guardado
                escribirControles(nAsientoManual.obtenerObjeto("ID", _idAsientoManual.ToString(), true)); //Importante: Por ultimo re-Escribe todos los controles para mayor seguridad                      }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idAsientoManual > 0) escribirControles(nAsientoManual.obtenerObjeto("ID", _idAsientoManual.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(35)) //Verifica que el usuario posea el privilegio requerido
            {
                if (_idAsientoManual > 0)
                {
                    if (objAsientoManual.CbteFecha.AddDays(10) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea anular el comprobante ID: " + _idAsientoManual.ToString() + "?") == DialogResult.Yes)
                        {
                            if (nAsientoManual.anular(objAsientoManual)) //Paso 1: Anula el comprobante
                            {
                                asentarTransaccion("ANULACION"); //Paso 2: Registra el/los Asiento/s Contable/s
                                escribirControles(nAsientoManual.obtenerObjeto("ID", _idAsientoManual.ToString(), true)); //Re-Escribe los datos del objeto seleccionado
                                filtrarCatalogo(0); //Carga el catálogo        
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación Incorrecta. Los comprobantes que han superado los 10 días de su registración No pueden ser anulados.");
                }
            }
            else Mensaje.Restriccion();
        }
        #endregion

        #region Métodos de Cuadricula
        private void agregarFila()
        {
            if (_controladorDeNuevoRegistro && gridDetalle.RowCount <= 30) //Verifica que no se superen las 30 filas en la cuadricula
            {
                string codigoCuentacontable = new N_CuentaContable().obtenerObjeto("DENOMINACION", _primerElemento_CuentaContable).Codigo;
                gridDetalle.Rows.Add(codigoCuentacontable, _primerElemento_CuentaContable, "0.00", "0.00", "NO-APLICA");
                gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                gridDetalle.FirstDisplayedScrollingRowIndex = gridDetalle.RowCount - 1; //Posiciona el scroll del gridDetalle en la celda seleccionada
                SendKeys.Send("{DOWN}"); //Mueve el foco a la nueva fila  
            }
        }

        private void agregarFilas(List<AsientoManualDetalle> detalle)
        {
            gridDetalle.Rows.Clear();
            foreach (AsientoManualDetalle item in detalle)
            {
                gridDetalle.Rows.Add();
                gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                gridDetalle.CurrentRow.Cells[0].Value = Convert.ToString(item.CuentaContable.Codigo).PadLeft(6, '0');
                gridDetalle.CurrentRow.Cells[1].Value = Convert.ToString(item.CuentaContable.Denominacion);
                gridDetalle.CurrentRow.Cells[2].Value = Convert.ToString(item.Debe);
                gridDetalle.CurrentRow.Cells[3].Value = Convert.ToString(item.Haber);
                gridDetalle.CurrentRow.Cells[4].Value = Convert.ToString(item.Conciliacion);
                gridDetalle.CurrentRow.Cells[5].Value = Formulario.ValidarNumeroEntero64(Convert.ToString(item.Id)); //Importante: Almacena el Id Detalle para identificar el ítem ante una posible modificación
            }
            if (gridDetalle.CurrentCell != null) gridDetalle.CurrentCell.Selected = false; //Quita la selección de la celda
        }

        private void buscarCuentaContableCodigo(int indiceFila, string codigoCuentaContable) //Método que busca una Cuenta contable por código
        {
            if (_controladorDeNuevoRegistro)
            {
                if (string.IsNullOrEmpty(codigoCuentaContable)) //Verifica que el código recibido sea nulo o vacío
                {
                    escribirFila(indiceFila, "", null, true);
                }
                else
                {
                    codigoCuentaContable = codigoCuentaContable.PadLeft(6, '0'); //Formatea el código recibido
                    if (codigoCuentaContable != _codigoCuentaContable_ControladorDeModificacion) //Verifica que el ID recibido ha sido modificado
                    {
                        CuentaContable objCuentaContable = new N_CuentaContable().obtenerObjeto("CODIGO", codigoCuentaContable, true); //Consulta que ejecuta una busqueda en la Base de Datos
                        if (objCuentaContable != null) //Verifica que el resultado de la consulta tenga exito
                        {
                            escribirFila(indiceFila, codigoCuentaContable, objCuentaContable, true);
                        }
                        else
                        {
                            escribirFila(indiceFila, "", null, true);
                        }
                    }
                }
            }
        }

        private void calcularTotal()
        {
            double totalDebe = 0.00;
            double totalHaber = 0.00;
            foreach (DataGridViewRow row in gridDetalle.Rows) //Recorre la cuadricula y suma los valores de las celdas indicadas 
            {
                totalDebe += Formulario.ValidarNumeroDoble(row.Cells[2].Value.ToString());
                totalHaber += Formulario.ValidarNumeroDoble(row.Cells[3].Value.ToString());
            }
            lblTotalDebe.Text = Formulario.ValidarCampoMoneda(Math.Round(totalDebe, 2));
            lblTotalHaber.Text = Formulario.ValidarCampoMoneda(Math.Round(totalHaber, 2));
        }

        private void escribirFila(int indiceFila, string codigoCuentaContable, CuentaContable objCuentaContable, bool actividad)
        {
            gridDetalle.Rows[indiceFila].Cells[0].Value = codigoCuentaContable;
            gridDetalle.Rows[indiceFila].Cells[1].Value = (objCuentaContable != null) ? objCuentaContable.Denominacion : "";
            gridDetalle.Rows[indiceFila].Cells[2].Value = "0.00";
            gridDetalle.Rows[indiceFila].Cells[3].Value = "0.00";
            gridDetalle.Rows[indiceFila].Cells[4].Value = "NO-APLICA";
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
                    if ((Formulario.ValidarNumeroEntero(fila.Cells[2].Value.ToString()) <= 0 && Formulario.ValidarNumeroEntero(fila.Cells[3].Value.ToString()) <= 0) || (Formulario.ValidarNumeroEntero(fila.Cells[2].Value.ToString()) > 0 && Formulario.ValidarNumeroEntero(fila.Cells[3].Value.ToString()) > 0)) //Verifica si hay valores inválidos
                    {
                        // ---------- BLOQUE CONTROLADOR DE DEBE-HABER INVALIDO ---------- //
                        Mensaje.Advertencia("Operación Incorrecta.\nVerifique en cada ítem del detalle que el valor del debe y haber sean válidos e intente nuevamente.");
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
        #endregion

        #region Métodos de Formulario
        private void asentarTransaccion(string operacion)
        {
            AsientoContable objAsientoContable = new AsientoContable();
            objAsientoContable.AsientoFecha = pkrCbteFecha.Value;
            objAsientoContable.Descripcion = "Asiento Manual: N°" + Convert.ToString(objAsientoManual.CbteTPV).PadLeft(5, '0') + "-" + Convert.ToString(objAsientoManual.CbteNro).PadLeft(8, '0');
            objAsientoContable.OrigenTipo = "ASM";
            objAsientoContable.OrigenId = objAsientoManual.Id;
            if (operacion == "REGISTRACION") objAsientoContable.AsientoNro = nAsientoContable.generarNumeroAsiento(); //Verifica que es un nuevo comprobante. Si es asi, genera un nuevo Número de Asiento
            else
            {
                AsientoContable objAsientoContablePrecedente = nAsientoContable.obtenerObjeto("ASM", objAsientoManual.Id); //Paso 1: En el caso de una modificación o anulación, obtiene el Asiento registrado precedentemente
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
            foreach (DataGridViewRow fila in gridDetalle.Rows) //Recorre las filas de la cuadricula 
            {
                if (operacion != "ANULACION") //Verifica que No sea una Anulación. Si es así, crea los correspondientes Asientos Contables 
                {
                    objAsientoContable.CuentaContable = nCuentaContable.obtenerObjeto("DENOMINACION", Convert.ToString(fila.Cells[1].Value), true);
                    objAsientoContable.Debe = Formulario.ValidarNumeroDoble(fila.Cells[2].Value.ToString());
                    objAsientoContable.Haber = Formulario.ValidarNumeroDoble(fila.Cells[3].Value.ToString());
                    objAsientoContable.Conciliacion = Convert.ToString(fila.Cells[4].Value);
                    nAsientoContable.insertar(objAsientoContable); //Paso 1: Registra el Asiento Contable en la Base de Datos
                    nCuentaContable.actualizarSaldo(objAsientoContable.CuentaContable.Id, ((objAsientoContable.CuentaContable.Saldo + objAsientoContable.Debe) - objAsientoContable.Haber)); //Paso 2: Actualiza el saldo en la Cuenta Contable (El Debe suma en el Saldo y el Haber resta en el Saldo)
                }
            }
        }

        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(AsientoManual objAsientoManual)
        {
            this.objAsientoManual = objAsientoManual; //Obtiene los datos del objeto recibido
            if (objAsientoManual != null)
            {
                _controladorDeNuevoRegistro = false;
                _idAsientoManual = (objAsientoManual != null) ? objAsientoManual.Id : 0;
                txtCbteTPV.Text = Convert.ToString(objAsientoManual.CbteTPV).PadLeft(5, '0');
                txtCbteNro.Text = Convert.ToString(objAsientoManual.CbteNro).PadLeft(8, '0');
                pkrCbteFecha.Value = objAsientoManual.CbteFecha;
                txtEstado.Text = objAsientoManual.Estado;
                txtDenominacion.Text =objAsientoManual.Denominacion;
                cmbCentroCosto.Text = objAsientoManual.CentroCosto.Denominacion;
                objAsientoManualDetalle = new N_AsientoManualDetalle().obtenerObjetos(_idAsientoManual); //Almacena los item de detalle de comprobante
                agregarFilas(objAsientoManualDetalle); //Escribe los item en el detalle de comprobante
                lblTotalDebe.Text = Formulario.ValidarCampoMoneda(objAsientoManual.TotalDebe);
                lblTotalHaber.Text = Formulario.ValidarCampoMoneda(objAsientoManual.TotalHaber);
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objAsientoManual.EdicionFecha) + " por " + objAsientoManual.EdicionUsuarioDenominacion;
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objAsientoManual = new AsientoManual(
                (_idAsientoManual <= 0) ? 0 : _idAsientoManual,
                Convert.ToInt32(Global.PtoVta),
                Formulario.ValidarNumeroEntero64(txtCbteNro.Text),
                fechaActual,
                txtEstado.Text,
                txtDenominacion.Text,
                new N_CentroCosto().obtenerObjeto("DENOMINACION", cmbCentroCosto.Text),
                Formulario.ValidarNumeroDoble(lblTotalDebe.Text),
                Formulario.ValidarNumeroDoble(lblTotalHaber.Text),
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(ColCuentaContable, new N_CuentaContable().obtenerListaDeElementos(new string[] { "ACTIVO CORRIENTE > DISPONIBILIDADES" }, true)); //Re-Establece los items del ComboBox (excluye las cuentas indicadas)
            _idAsientoManual = 0; //Libera el Id del Objeto seleccionado
            txtEstado.Text = "ACTIVO";
            txtCbteTPV.Text = Global.PtoVta.ToString("00000");
            txtCbteNro.Text = "";
            pkrCbteFecha.Text = Fecha.SistemaFecha();
            txtDenominacion.Text = "";
            gridDetalle.Rows.Clear();
            lblTotalDebe.Text = "0,00";
            lblTotalHaber.Text = "0,00";
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, cmbCentroCosto }); //Restauración de campos invalidados
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
            {
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA")
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
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroEstado = "TODOS";
            if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ACTIVO") filtroEstado = "ACTIVO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ANULADO") filtroEstado = "ANULADO";
            if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por Denominación
            {
                consultaAsientoManual = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nAsientoManual.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA") //Verifica que el tipo de filtro es por Fecha de Comprobante
            {
                consultaAsientoManual = new string[] { filtroEstado, "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nAsientoManual.obtenerCatalago(filtroEstado, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por ID
            {
                consultaAsientoManual = new string[] { filtroEstado, "ID", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nAsientoManual.obtenerCatalago(filtroEstado, "ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR N° PV - CBTE" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por ID
            {
                consultaAsientoManual = new string[] { filtroEstado, "COMPROBANTE", txtFiltroLista.Text.Trim().PadLeft(12, '0') };
                cargarCatalogo(nAsientoManual.obtenerCatalago(filtroEstado, "COMPROBANTE", txtFiltroLista.Text.Trim().PadLeft(12, '0'), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            escribirControles(nAsientoManual.obtenerObjeto("ID", idElemento.ToString(), true)); //Escribe los datos del registro seleccionado
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                if (consultaAsientoManual.Length == 3)
                    lista = nAsientoManual.obtenerCatalago(consultaAsientoManual[0], consultaAsientoManual[1], consultaAsientoManual[2], "CATALOGO1");
                else if (consultaAsientoManual.Length == 4)
                    lista = nAsientoManual.obtenerCatalago(consultaAsientoManual[0], consultaAsientoManual[1], Fecha.ValidarFecha(consultaAsientoManual[2]), Fecha.ValidarFecha(consultaAsientoManual[3]), "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "N° Comprobante",
                    "Fecha",
                    "Estado",
                    "Denominación",
                    "Centro de Costo",
                    "Debe",
                    "Haber" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //N° Comprobante (PtoVta y Comprobante)
                        campo[1].Trim(), //Fecha
                        campo[2].Trim(), //Estado
                        campo[3].Trim(), //Denominación
                        campo[4].Trim(), //Centro de Costo
                        "$"+campo[5].Trim(), //Debe
                        "$"+campo[6].Trim() }; //Haber
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Asientos Manuales", subTitulos, new int[] { 14, 10, 10, 48, 25, 11, 11 }, _listaDelReporte, new List<int> { 1 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Asientos Manuales", subTitulos, new float[] { 13, 9, 9, 38, 22, 10, 10 }, _listaDelReporte); //Ancho: 111
            }
        }
        #endregion
    }
}
