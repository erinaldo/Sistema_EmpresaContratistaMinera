using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormRentabilidadCentroCosto : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private long _idRentabilidadCentroCosto = 0;
        private string _primerElemento_CentroDeCosto = new N_CentroCosto().obtenerListaDeElementos(new string[] { })[0]; //Primer elemento de la lista de Centro de Costos
        string[] consultaRentabilidadCentroCosto;
        private RentabilidadCentroCosto objRentabilidadCentroCosto;
        private RentabilidadCentroCosto objRentabilidadCentroCostoDB;
        private List<RentabilidadCentroCostoDetalleCosto> objRentabilidadCentroCostoDetalleCostoDB;
        private List<RentabilidadCentroCostoDetalleImporte> objRentabilidadCentroCostoDetalleImporteDB;
        private N_RentabilidadCentroCosto nRentabilidadCentroCosto = new N_RentabilidadCentroCosto();
        private N_RentabilidadCentroCostoDetalleCosto nRentabilidadCentroCostoDetalleCosto = new N_RentabilidadCentroCostoDetalleCosto();
        private N_RentabilidadCentroCostoDetalleImporte nRentabilidadCentroCostoDetalleImporte = new N_RentabilidadCentroCostoDetalleImporte();
        private N_AsientoCentroCostoRentabilidadCosto nAsientoCentroCostoRentabilidadCosto = new N_AsientoCentroCostoRentabilidadCosto();
        #endregion

        public FormRentabilidadCentroCosto()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormRentabilidadCentroCosto_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(cmbPeriodo, "Periodo contable - Mes");
            toolTip.SetToolTip(txtPeriodo, "Periodo contable - Año");
            toolTip.SetToolTip(txtEstado, "Estado del comprobante");
            toolTip.SetToolTip(btnNuevo, "Crea un nuevo registro");
            toolTip.SetToolTip(btnGuardar, "Guarda los cambios realizados");
            toolTip.SetToolTip(btnCancelar, "Deshace los cambios realizados");
            toolTip.SetToolTip(btnAnular, "Anular un registro");
            #endregion
            #region Tipo de Datos
            gridDetalleImporte.Columns[0].ValueType = typeof(System.String);
            gridDetalleImporte.Columns[1].ValueType = typeof(System.Decimal);
            gridDetalleImporte.Columns[2].ValueType = typeof(System.Int32);
            gridDetalleImporte.Columns[3].ValueType = typeof(System.Decimal);
            gridDetalleImporte.Columns[4].ValueType = typeof(System.Int32);
            gridDetalleImporte.Columns[5].ValueType = typeof(System.Decimal);
            gridDetalleImporte.Columns[6].ValueType = typeof(System.Int32);
            gridDetalleImporte.Columns[7].ValueType = typeof(System.Decimal);
            gridDetalleCosto.Columns[0].ValueType = typeof(System.String);
            gridDetalleCosto.Columns[1].ValueType = typeof(System.Decimal);
            gridDetalleCosto.Columns[2].ValueType = typeof(System.Decimal);
            gridDetalleCosto.Columns[3].ValueType = typeof(System.Decimal);
            gridDetalleCosto.Columns[4].ValueType = typeof(System.Decimal);
            gridDetalleCosto.Columns[5].ValueType = typeof(System.Decimal);
            gridDetalleCosto.Columns[6].ValueType = typeof(System.Decimal);
            #endregion
            Formulario.ComboBox_CargarElementos(cmbCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { "" }), 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO",
                "FILTRAR POR ESTADO: ANULADO", "TODOS LOS ESTADOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR DENOMINACION",
                "FILTRAR POR PERIODO" }, 0); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
        }

        private void cmbCentroCosto_Validated(object sender, EventArgs e)
        {
            agregarFila_Importe();
            agregarFila_Costo();
        }

        private void cmbPeriodo_Validated(object sender, EventArgs e)
        {
            agregarFila_Importe();
            agregarFila_Costo();
        }

        private void txtPeriodo_ValueChanged(object sender, EventArgs e)
        {
            if (cmbCentroCosto.Focused)
            {
                agregarFila_Importe();
                agregarFila_Costo();
            }
        }

        private void txtReajuste_Validated(object sender, EventArgs e)
        {
            calcularTotal_Costo(); //Re-Calcula el Total Importe
            calcularTotal_Importe(); //Re-Calcula el Total Importe
        }

        private void txtReajuste_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtReajuste.Text);
        }
        #endregion

        #region Eventos de Cuadricula (Importe)
        private void gridDetalleImporte_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridDetalleImporte.FirstDisplayedCell = gridDetalleImporte.CurrentCell; //Importante: Mueve las barras de desplazamiento (Vertical y Horizoltal) en relación a la celda seleccionada 
        }

        private void gridDetalleImporte_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(gridDetalleImporte.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString()))
            {
                if ((e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 4) && e.RowIndex >= 0) //Verifica que se este dentro de la celda "Valor Hora" ó "Ppto. HH" ó "Real HH" 
                {
                    if (e.RowIndex != (gridDetalleImporte.RowCount - 1)) SendKeys.Send("{UP}"); //Mantiene el foco en la celda editada
                    calcularNeto_Importe(e.RowIndex);
                }
            }
        }

        private void gridDetalleImporte_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            gridDetalleImporte.CancelEdit(); //Cancela la edición y restaura su valor cuando No se ha ingresado un valor válido en la celda 
            gridDetalleImporte.EndEdit(); //Termina la edición cuando No se ha ingresado un valor válido en la celda 
        }

        private void gridDetalleImporte_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = System.Drawing.Color.White; //Importante: Esta linea corrige el error de los desplegables de la cuadricula cuando se ponen en negro
            e.Control.KeyPress -= new KeyPressEventHandler(gridDetalleImporte_KeyPress); //Paso 1: Elimina la redundancia del delegado del evento KeyPress
            e.Control.KeyPress += new KeyPressEventHandler(gridDetalleImporte_KeyPress); //Paso 2: Crea un nuevo delegado del evento KeyPress
        }

        private void gridDetalleImporte_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
            {
                gridDetalleImporte.EndEdit(); //Impide que el foco pase a la siguiente fila en los desplegables de la cuadricula 
                e.SuppressKeyPress = true;
                if (gridDetalleImporte.CurrentCell.ColumnIndex == 7) gridDetalleImporte.CurrentCell = gridDetalleImporte.CurrentRow.Cells[0]; //Mueve el foco a la celda de la primera columna  
                else SendKeys.Send("{RIGHT}"); //Mueve el foco a la celda de la siguiente columna 
            }
        }

        private void gridDetalleImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gridDetalleImporte.CurrentCell != null)
            {
                if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab) //Bloque 3: Impide que el foco pase a la siguiente fila en los desplegables de la cuadricula 
                {
                    gridDetalleImporte.EndEdit();
                }
                else if (gridDetalleImporte.CurrentCell.ColumnIndex == 2 || gridDetalleImporte.CurrentCell.ColumnIndex == 4) //Verifica que el ingreso de datos sea con números enteros dentro de la celda "Ppto. HH" y "Real HH"
                {
                    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 7) e.Handled = true;
                }
                else if (gridDetalleImporte.CurrentCell.ColumnIndex == 1) //Verifica que el ingreso de datos sea con números decimales dentro de la celda "Valor Hora"
                {
                    Formulario.ValidarCampoMoneda(e, gridDetalleImporte.CurrentCell.GetEditedFormattedValue(gridDetalleImporte.CurrentRow.Index, DataGridViewDataErrorContexts.Display).ToString());
                }
            }
        }

        private void gridDetalleImporte_Leave(object sender, EventArgs e)
        {
            if (gridDetalleImporte.Rows.Count > 0)
            {
                gridDetalleImporte.CurrentCell.Selected = false; //Quita la selección de la celda al perder el foco
            }

        }
        #endregion

        #region Eventos de Cuadricula (Costo)
        private void gridDetalleCosto_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gridDetalleCosto.FirstDisplayedCell = gridDetalleCosto.CurrentCell; //Importante: Mueve las barras de desplazamiento (Vertical y Horizoltal) en relación a la celda seleccionada 
        }

        private void gridDetalleCosto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(gridDetalleCosto.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString()))
            {
                if ((e.ColumnIndex == 1) && e.RowIndex >= 0) //Verifica que se este dentro de la celda "Ppto. Costo" 
                {
                    if (e.RowIndex != (gridDetalleCosto.RowCount - 1)) SendKeys.Send("{UP}"); //Mantiene el foco en la celda editada
                    calcularNeto_Costo();
                }
            }
        }

        private void gridDetalleCosto_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            gridDetalleCosto.CancelEdit(); //Cancela la edición y restaura su valor cuando No se ha ingresado un valor válido en la celda 
            gridDetalleCosto.EndEdit(); //Termina la edición cuando No se ha ingresado un valor válido en la celda 
        }

        private void gridDetalleCosto_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = System.Drawing.Color.White; //Importante: Esta linea corrige el error de los desplegables de la cuadricula cuando se ponen en negro
            e.Control.KeyPress -= new KeyPressEventHandler(gridDetalleCosto_KeyPress); //Paso 1: Elimina la redundancia del delegado del evento KeyPress
            e.Control.KeyPress += new KeyPressEventHandler(gridDetalleCosto_KeyPress); //Paso 2: Crea un nuevo delegado del evento KeyPress
        }

        private void gridDetalleCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Tab)
            {
                gridDetalleCosto.EndEdit(); //Impide que el foco pase a la siguiente fila en los desplegables de la cuadricula 
                e.SuppressKeyPress = true;
                if (gridDetalleCosto.CurrentCell.ColumnIndex == 6) gridDetalleCosto.CurrentCell = gridDetalleCosto.CurrentRow.Cells[0]; //Mueve el foco a la celda de la primera columna  
                else SendKeys.Send("{RIGHT}"); //Mueve el foco a la celda de la siguiente columna 
            }
        }

        private void gridDetalleCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gridDetalleCosto.CurrentCell != null)
            {
                if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab) //Impide que el foco pase a la siguiente fila en los desplegables de la cuadricula 
                {
                    gridDetalleCosto.EndEdit();
                }
                else if (gridDetalleCosto.CurrentCell.ColumnIndex == 1) //Verifica que el ingreso de datos sea con números decimales dentro de la celda "Ppto. Costo"
                {
                    Formulario.ValidarCampoMoneda(e, gridDetalleCosto.CurrentCell.GetEditedFormattedValue(gridDetalleCosto.CurrentRow.Index, DataGridViewDataErrorContexts.Display).ToString());
                }
            }
        }

        private void gridDetalleCosto_Leave(object sender, EventArgs e)
        {
            if (gridDetalleCosto.Rows.Count > 0)
            {
                gridDetalleCosto.CurrentCell.Selected = false; //Quita la selección de la celda al perder el foco
            }

        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(50)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                agregarFila_Importe();
                agregarFila_Costo();
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idRentabilidadCentroCosto <= 0 && Global.UsuarioActivo_Privilegios.Contains(50)) //Verifica que el usuario posea el privilegio requerido
            {
                //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        objRentabilidadCentroCosto.Id = nRentabilidadCentroCosto.generarNumeroID(); //Paso 2: Genera un ID para cada Objeto
                        if (nRentabilidadCentroCosto.insertar(objRentabilidadCentroCosto)) //Paso 3: Inserta el objeto principal
                        {
                            _idRentabilidadCentroCosto = objRentabilidadCentroCosto.Id;
                            #region Registra el Detalle (Importe)
                            foreach (DataGridViewRow fila in gridDetalleImporte.Rows) //Paso 4: Recorre las filas de la cuadricula 
                            {
                                RentabilidadCentroCostoDetalleImporte objRentabilidadCentroCostoDetalleImporte = new RentabilidadCentroCostoDetalleImporte(
                                    nRentabilidadCentroCostoDetalleImporte.generarNumeroID(), //Paso 5: Asigna un numero de ID al Objeto
                                    objRentabilidadCentroCosto,
                                    Convert.ToString(fila.Cells[0].Value.ToString()), //Categoría de Trabajo
                                    Formulario.ValidarNumeroDoble(fila.Cells[1].Value.ToString()), //Valor Hora
                                    Formulario.ValidarNumeroEntero(fila.Cells[2].Value.ToString()), //Ppto. HH
                                    Formulario.ValidarNumeroDoble(fila.Cells[3].Value.ToString()), //Ppto. Importe
                                    Formulario.ValidarNumeroEntero(fila.Cells[4].Value.ToString()), //Real HH
                                    Formulario.ValidarNumeroDoble(fila.Cells[5].Value.ToString())); //Real Importe
                                nRentabilidadCentroCostoDetalleImporte.insertar(objRentabilidadCentroCostoDetalleImporte); //Paso 6: Inserta el Objeto en la Base de Datos
                            }
                            #endregion
                            #region Registra el Detalle (Costo)
                            foreach (DataGridViewRow fila in gridDetalleCosto.Rows) //Paso 4: Recorre las filas de la cuadricula 
                            {
                                RentabilidadCentroCostoDetalleCosto objRentabilidadCentroCostoDetalleCosto = new RentabilidadCentroCostoDetalleCosto(
                                    nRentabilidadCentroCostoDetalleCosto.generarNumeroID(), //Paso 7: Asigna un numero de ID al Objeto
                                    objRentabilidadCentroCosto,
                                    new N_CuentaContable().obtenerObjeto("DENOMINACION", Convert.ToString(fila.Cells[0].Value.ToString())), //Cuenta Contable
                                    Formulario.ValidarNumeroDoble(fila.Cells[1].Value.ToString()), //Ppto. Costo
                                    Formulario.ValidarNumeroDoble(fila.Cells[2].Value.ToString()), //Ppto. Incidencia
                                    Formulario.ValidarNumeroDoble(fila.Cells[3].Value.ToString()), //Real Costo
                                    Formulario.ValidarNumeroDoble(fila.Cells[4].Value.ToString())); //Real Incidencia
                                nRentabilidadCentroCostoDetalleCosto.insertar(objRentabilidadCentroCostoDetalleCosto); //Paso 8: Inserta el Objeto en la Base de Datos
                            }
                            #endregion
                            mostrarRegistro(objRentabilidadCentroCosto);
                            Mensaje.RegistroCorrecto("REGISTRACION");
                        }
                    }
                }
            }
            else if(_idRentabilidadCentroCosto <= 0) Mensaje.Restriccion();
            else if (_idRentabilidadCentroCosto > 0) Mensaje.NoModificable();
            bool ValidarCampoVacio() // Método que valida los campos requeridos
            {
                return Formulario.ValidarCampoVacio(false, new Control[] { cmbCentroCosto, cmbPeriodo });
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idRentabilidadCentroCosto > 0) escribirControles(nRentabilidadCentroCosto.obtenerObjeto("ID", _idRentabilidadCentroCosto.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(51)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objRentabilidadCentroCostoDB.Id > 0)
                {
                    DateTime FechaDelPerido = Fecha.ValidarFecha("01-" + Convert.ToString(Formulario.ValidarNumeroEntero(objRentabilidadCentroCosto.Periodo.Split('-')[0]) + 1) + "-" + objRentabilidadCentroCosto.Periodo.Split('-')[1]).AddDays(-1); //Calcula el último dia del mes
                    if (FechaDelPerido.AddMonths(3) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea anular el comprobante ID: " + _idRentabilidadCentroCosto.ToString() + "?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            objRentabilidadCentroCosto.Id = nRentabilidadCentroCosto.generarNumeroID(); //Paso 2: Genera un ID para cada Objeto
                            if (nRentabilidadCentroCosto.anular(objRentabilidadCentroCostoDB)) //Paso 3: Inserta el objeto principal
                            {
                                _idRentabilidadCentroCosto = objRentabilidadCentroCostoDB.Id;
                                mostrarRegistro(objRentabilidadCentroCostoDB);
                                Mensaje.RegistroCorrecto("ANULACION");
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación Incorrecta. Los comprobantes que han superado los 3 meses de su registración No pueden ser anulados.");
                }
            }
            else Mensaje.Restriccion();
        }
        #endregion

        #region Métodos de Cuadricula (Importe)
        private void agregarFila_Importe()
        {
            if (_controladorDeNuevoRegistro)
            {
                gridDetalleImporte.Rows.Clear(); //Libera la cuadricula
                gridDetalleImporte.Rows.Add("ADMINISTRATIVO", "0.00", "0", "0.00", "0", "0.00", "0", "0.00");
                gridDetalleImporte.Rows.Add("AYUDANTE", "0.00", "0", "0.00", "0", "0.00", "0", "0.00");
                gridDetalleImporte.Rows.Add("OFICIAL", "0.00", "0", "0.00", "0", "0.00", "0", "0.00");
                gridDetalleImporte.Rows.Add("OFICIAL ESPECIALIZADO", "0.00", "0", "0.00", "0", "0.00", "0", "0.00");
                gridDetalleImporte.Rows.Add("SUPERVISOR", "0.00", "0", "0.00", "0", "0.00", "0", "0.00");
                gridDetalleImporte.Rows.Add("SUPERVISOR GENERAL", "0.00", "0", "0.00", "0", "0.00", "0", "0.00");
                gridDetalleImporte.ClearSelection();
            }
        }

        private void agregarFilas_Importe(List<RentabilidadCentroCostoDetalleImporte> detalleImporte)
        {
            gridDetalleImporte.Rows.Clear();
            foreach (RentabilidadCentroCostoDetalleImporte item in detalleImporte)
            {
                gridDetalleImporte.Rows.Add();
                gridDetalleImporte.CurrentCell = gridDetalleImporte.Rows[gridDetalleImporte.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                gridDetalleImporte.CurrentRow.Cells[0].Value = Convert.ToString(item.Denominacion);
                gridDetalleImporte.CurrentRow.Cells[1].Value = Convert.ToString(item.ValorHora);
                gridDetalleImporte.CurrentRow.Cells[2].Value = Convert.ToString(item.PresupuestoHH);
                gridDetalleImporte.CurrentRow.Cells[3].Value = Formulario.ValidarCampoMoneda(Convert.ToString(item.PresupuestoImporte));
                gridDetalleImporte.CurrentRow.Cells[4].Value = Convert.ToString(item.RealHH);
                gridDetalleImporte.CurrentRow.Cells[5].Value = Formulario.ValidarCampoMoneda(Convert.ToString(item.RealImporte));
                gridDetalleImporte.CurrentRow.Cells[6].Value = Convert.ToString(item.RealHH - item.PresupuestoHH);
                gridDetalleImporte.CurrentRow.Cells[7].Value = Formulario.ValidarCampoMoneda(Convert.ToString(item.RealImporte - item.PresupuestoImporte));
            }
            if (gridDetalleImporte.CurrentCell != null) gridDetalleImporte.CurrentCell.Selected = false; //Quita la selección de la celda
        }

        private void calcularNeto_Importe(int indiceFila)
        {
            double valorHora = string.IsNullOrWhiteSpace(Convert.ToString(gridDetalleImporte.Rows[indiceFila].Cells[1].Value)) ? 0 : Formulario.ValidarNumeroDoble(Convert.ToString(gridDetalleImporte.Rows[indiceFila].Cells[1].Value).Replace(".", ",")); //Valor de la hora
            int presupuestoHH = string.IsNullOrWhiteSpace(Convert.ToString(gridDetalleImporte.Rows[indiceFila].Cells[2].Value)) ? 0 : Formulario.ValidarNumeroEntero(gridDetalleImporte.Rows[indiceFila].Cells[2].Value.ToString()); //Presupuesto Horas Hombre
            int realHH = string.IsNullOrWhiteSpace(Convert.ToString(gridDetalleImporte.Rows[indiceFila].Cells[4].Value)) ? 0 : Formulario.ValidarNumeroEntero(gridDetalleImporte.Rows[indiceFila].Cells[4].Value.ToString()); //Real Horas Hombre
            int diferenciaHH = (realHH - presupuestoHH); //Diferencia Horas Hombre
            double presupuestoImporte = valorHora * presupuestoHH;
            double realImporte = valorHora * realHH;
            double diferenciaImporte = valorHora * diferenciaHH;
            gridDetalleImporte.Rows[indiceFila].Cells[3].Value = Math.Round(Formulario.ValidarNumeroDoble(presupuestoImporte.ToString()), 2);
            gridDetalleImporte.Rows[indiceFila].Cells[5].Value = Math.Round(Formulario.ValidarNumeroDoble(realImporte.ToString()), 2);
            gridDetalleImporte.Rows[indiceFila].Cells[6].Value = Convert.ToString(diferenciaHH.ToString());
            gridDetalleImporte.Rows[indiceFila].Cells[7].Value = Math.Round(Formulario.ValidarNumeroDoble(diferenciaImporte.ToString()), 2);
            calcularTotal_Importe(); //Recalcula el Total del comprobante
        }

        private void calcularTotal_Importe()
        {
            int totalPptoHH = 0;
            double totalPptoImporte = 0.00;
            int totalRealHH = 0;
            double totalRealImporte = 0.00;
            double reajuste = Formulario.ValidarNumeroDoble(txtReajuste.Text);
            foreach (DataGridViewRow row in gridDetalleImporte.Rows) //Recorre la cuadricula y suma los valores de las celdas indicadas 
            {
                totalPptoHH += Formulario.ValidarNumeroEntero(row.Cells[2].Value.ToString());
                totalPptoImporte += Formulario.ValidarNumeroDoble(row.Cells[3].Value.ToString());
                totalRealHH += Formulario.ValidarNumeroEntero(row.Cells[4].Value.ToString());
                totalRealImporte += Formulario.ValidarNumeroDoble(row.Cells[5].Value.ToString());
            }
            txtTotalPptoHH.Text = Convert.ToString(totalPptoHH);
            txtTotalPptoImporte.Text = Formulario.ValidarCampoMoneda(totalPptoImporte);
            txtTotalRealHH.Text = Convert.ToString(totalRealHH);
            txtTotalRealImporte.Text = Formulario.ValidarCampoMoneda(totalRealImporte);
            txtTotalDiferenciaHH.Text = Convert.ToString(totalRealHH - totalPptoHH);
            txtTotalDiferenciaImporte.Text = Formulario.ValidarCampoMoneda(totalRealImporte - totalPptoImporte);
            lblTotalImporte.Text = Formulario.ValidarCampoMoneda(totalRealImporte + reajuste);
            calcularTotal_Costo(); //Re-Calcula los totales de los costos
        }

        private void escribirFila_Importe(int indiceFila, RentabilidadCentroCostoDetalleImporte objDetalleImporte)
        {
            gridDetalleCosto.Rows[indiceFila].Cells[0].Value = objDetalleImporte.Denominacion;
            gridDetalleCosto.Rows[indiceFila].Cells[1].Value = Formulario.ValidarCampoMoneda(Math.Round(objDetalleImporte.ValorHora,2 ));
            gridDetalleCosto.Rows[indiceFila].Cells[2].Value = Convert.ToInt32(objDetalleImporte.PresupuestoHH);
            gridDetalleCosto.Rows[indiceFila].Cells[3].Value = Formulario.ValidarCampoMoneda(Math.Round(objDetalleImporte.PresupuestoImporte, 2));
            gridDetalleCosto.Rows[indiceFila].Cells[4].Value = Convert.ToInt32(objDetalleImporte.RealHH);
            gridDetalleCosto.Rows[indiceFila].Cells[5].Value = Formulario.ValidarCampoMoneda(Math.Round(objDetalleImporte.RealImporte, 2));
            gridDetalleCosto.Rows[indiceFila].Cells[6].Value = Convert.ToInt32(objDetalleImporte.RealHH - objDetalleImporte.PresupuestoHH);
            gridDetalleCosto.Rows[indiceFila].Cells[7].Value = Formulario.ValidarCampoMoneda(Math.Round(objDetalleImporte.RealImporte - objDetalleImporte.PresupuestoImporte, 2));
        }

        private void btnImprimirReporteImporte_Click(object sender, EventArgs e)
        {
            if (!_controladorDeNuevoRegistro && gridDetalleImporte.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string periodo = cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value);
                List<CatalogoBase> listaImporte = nRentabilidadCentroCostoDetalleImporte.obtenerCatalago("ID_RENTABILIDAD", Convert.ToString(objRentabilidadCentroCosto.Id), "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Denominación",
                    "Valor Hora",
                    "Ppto. HH",
                    "Ppto. Importe",
                    "Real HH",
                    "Real Importe",
                    "Dif. HH",
                    "Dif. Importe" };
                foreach (CatalogoBase item in listaImporte)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //Denominación
                        campo[1].Trim(), //Valor Hora
                        campo[2].Trim(), //Ppto. HH 
                        campo[3].Trim(), //Ppto. Importe 
                        campo[4].Trim(), //Real HH 
                        campo[5].Trim(), //Real Importe 
                        campo[6].Trim(), //Dif. HH 
                        campo[7].Trim() }; //Dif. Importe
                    _listaDelReporte.Add(lineaDB);
                }
                string[] leyendasDeTotal = new string[]{
                    "Total Ppto. HH",
                    "Total Real HH",
                    "Total Dif. HH",
                    "Total Ppto. Importe",
                    "Total Real Importe",
                    "Total Dif. Importe",
                    "Re-ajuste",
                    "TOTAL IMPORTE" };
                string[] valoresDeTotal = new string[]{
                    Formulario.ValidarCampoMoneda(txtTotalPptoHH.Text.Replace(".", "")),
                    Formulario.ValidarCampoMoneda(txtTotalRealHH.Text.Replace(".", "")),
                    Formulario.ValidarCampoMoneda(txtTotalDiferenciaHH.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtTotalPptoImporte.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtTotalRealImporte.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtTotalDiferenciaImporte.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtReajuste.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(lblTotalImporte.Text.Replace(".", ""))};
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                string tituloA = "Rentabilidad por Centros de Costo (Importe)";
                string tituloB = cmbCentroCosto.Text + " Periodo " + cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value);
                reporte.crearDocumentoExcel_ListaConTotal(tituloA, tituloB, subTitulos, new int[] { 45, 12, 12, 12, 12, 12, 12, 12 }, _listaDelReporte, new List<int> { }, leyendasDeTotal, valoresDeTotal, 3, 3, 23, 100); //129
            }
        }
        #endregion

        #region Métodos de Cuadricula (Costo)
        private void agregarFila_Costo()
        {
            if (_controladorDeNuevoRegistro)
            {
                gridDetalleCosto.Rows.Clear(); //Libera la cuadricula
                foreach (AsientoCentroCostoRentabilidadCosto item in nAsientoCentroCostoRentabilidadCosto.obtenerObjetos(cmbCentroCosto.Text, cmbPeriodo.Text + "-" + txtPeriodo.Value))
                {
                    gridDetalleCosto.Rows.Add(item.Denominacion, item.PresupuestoCosto, item.PresupuestoCostoIncidencia, item.RealCosto, item.RealCostoIncidencia);
                }
                gridDetalleCosto.ClearSelection();
            }
        }

        private void agregarFilas_Costo(List<RentabilidadCentroCostoDetalleCosto> detalleCosto)
        {
            gridDetalleCosto.Rows.Clear();
            foreach (RentabilidadCentroCostoDetalleCosto item in detalleCosto)
            {
                gridDetalleCosto.Rows.Add();
                gridDetalleCosto.CurrentCell = gridDetalleCosto.Rows[gridDetalleCosto.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                gridDetalleCosto.CurrentRow.Cells[0].Value = Convert.ToString(item.CuentaContable.Denominacion);
                gridDetalleCosto.CurrentRow.Cells[1].Value = Formulario.ValidarCampoMoneda(Convert.ToString(item.PresupuestoCosto));
                gridDetalleCosto.CurrentRow.Cells[2].Value = Formulario.ValidarCampoMoneda(Convert.ToString(item.PresupuestoCostoIncidencia));
                gridDetalleCosto.CurrentRow.Cells[3].Value = Formulario.ValidarCampoMoneda(Convert.ToString(item.RealCosto));
                gridDetalleCosto.CurrentRow.Cells[4].Value = Formulario.ValidarCampoMoneda(Convert.ToString(item.RealCostoIncidencia));
                gridDetalleCosto.CurrentRow.Cells[5].Value = Formulario.ValidarCampoMoneda(Convert.ToString(item.PresupuestoCosto - item.RealCosto));
                gridDetalleCosto.CurrentRow.Cells[6].Value = Formulario.ValidarCampoMoneda(Convert.ToString(item.PresupuestoCostoIncidencia - item.RealCostoIncidencia));
            }
            if (gridDetalleCosto.CurrentCell != null) gridDetalleCosto.CurrentCell.Selected = false; //Quita la selección de la celda
        }

        private void calcularNeto_Costo()
        {
            calcularTotal_Costo(); //Recalcula el Total del comprobante
            foreach (DataGridViewRow row in gridDetalleCosto.Rows)
            {
                double totalCostoPresupuesto = Formulario.ValidarNumeroDoble(txtTotalCostoPpto.Text);
                double totalCostoReal = Formulario.ValidarNumeroDoble(txtTotalCostoReal.Text);
                double presupuestoCosto = string.IsNullOrWhiteSpace(Convert.ToString(row.Cells[1].Value)) ? 0 : Formulario.ValidarNumeroDoble(Convert.ToString(row.Cells[1].Value).Replace(".", ","));
                double presupuestoIncidencia = ((100 / totalCostoPresupuesto) * presupuestoCosto);
                double realCosto = string.IsNullOrWhiteSpace(Convert.ToString(row.Cells[3].Value)) ? 0 : Formulario.ValidarNumeroDoble(Convert.ToString(row.Cells[3].Value).Replace(".", ","));
                double realIncidencia = ((100 / totalCostoReal) * realCosto);
                double diferenciaCosto = (presupuestoCosto - realCosto);
                double diferenciaIncidencia = (presupuestoIncidencia - realIncidencia);
                row.Cells[2].Value = Formulario.ValidarCampoMoneda(Math.Round(presupuestoIncidencia, 2));
                row.Cells[4].Value = Formulario.ValidarCampoMoneda(Math.Round(realIncidencia, 2));
                row.Cells[5].Value = Formulario.ValidarCampoMoneda(Math.Round(diferenciaCosto, 2));
                row.Cells[6].Value = Formulario.ValidarCampoMoneda(Math.Round(diferenciaIncidencia, 2));
            }
            calcularTotal_Costo(); //Recalcula el Total del comprobante
        }

        private void calcularTotal_Costo()
        {
            double totalImporte = Formulario.ValidarNumeroDoble(lblTotalImporte.Text);
            double totalPptoCosto = 0.00;
            double totalRealCosto = 0.00;
            foreach (DataGridViewRow row in gridDetalleCosto.Rows) //Recorre la cuadricula y suma los valores de las celdas indicadas 
            {
                totalPptoCosto += Formulario.ValidarNumeroDoble(row.Cells[1].Value.ToString());
                totalRealCosto += Formulario.ValidarNumeroDoble(row.Cells[3].Value.ToString());
            }
            txtTotalCostoPpto.Text = Formulario.ValidarCampoMoneda(Math.Round(totalPptoCosto, 2));
            txtUtilidadPpto.Text = Formulario.ValidarCampoMoneda(Math.Round(totalImporte - totalPptoCosto, 2));
            txtTotalCostoReal.Text = Formulario.ValidarCampoMoneda(Math.Round(totalRealCosto, 2));
            txtUtilidadReal.Text = Formulario.ValidarCampoMoneda(Math.Round(totalImporte - totalRealCosto, 2));
            txtTotalCostoDif.Text = Formulario.ValidarCampoMoneda(Math.Round(totalPptoCosto - totalRealCosto, 2));
            txtUtilidadDif.Text = Formulario.ValidarCampoMoneda(Math.Round(totalPptoCosto - totalRealCosto, 2)); //La diferencia entre las ultilidades es equivalente a la diferencia entre el costo presupuestado menos el costo real 
        }

        private void escribirFila_Coste(int indiceFila, RentabilidadCentroCostoDetalleCosto objDetalleCoste)
        {
            
            gridDetalleCosto.Rows[indiceFila].Cells[0].Value = objDetalleCoste.CuentaContable.Denominacion;
            gridDetalleCosto.Rows[indiceFila].Cells[1].Value = Formulario.ValidarCampoMoneda(Math.Round(objDetalleCoste.PresupuestoCosto, 2));
            gridDetalleCosto.Rows[indiceFila].Cells[2].Value = Formulario.ValidarCampoMoneda(Math.Round(objDetalleCoste.PresupuestoCostoIncidencia, 2));
            gridDetalleCosto.Rows[indiceFila].Cells[3].Value = Formulario.ValidarCampoMoneda(Math.Round(objDetalleCoste.RealCosto, 2));
            gridDetalleCosto.Rows[indiceFila].Cells[4].Value = Formulario.ValidarCampoMoneda(Math.Round(objDetalleCoste.RealCostoIncidencia, 2));
            gridDetalleCosto.Rows[indiceFila].Cells[5].Value = Formulario.ValidarCampoMoneda(Math.Round(objDetalleCoste.PresupuestoCosto - objDetalleCoste.RealCosto, 2));
            gridDetalleCosto.Rows[indiceFila].Cells[6].Value = Formulario.ValidarCampoMoneda(Math.Round(objDetalleCoste.PresupuestoCostoIncidencia - objDetalleCoste.RealCostoIncidencia, 2));
        }

        private void btnImprimirReporteCosto_Click(object sender, EventArgs e)
        {
            if (!_controladorDeNuevoRegistro && gridDetalleCosto.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string periodo = cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value);
                List<CatalogoBase> listaCosto = nRentabilidadCentroCostoDetalleCosto.obtenerCatalago("ID_RENTABILIDAD", Convert.ToString(objRentabilidadCentroCosto.Id), "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Rama Contable",
                    "Cuenta Contable",
                    "Ppto. Costo",
                    "Ppto. Incidencia",
                    "Real Costo",
                    "Real Incidencia",
                    "Dif. Costo",
                    "Dif. Incidencia" };
                foreach (CatalogoBase item in listaCosto)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //Rama Contable
                        campo[1].Trim(), //Cuenta Contable
                        campo[2].Trim(), //Ppto. Costo 
                        campo[3].Trim(), //Ppto. Incidencia 
                        campo[4].Trim(), //Real Costo 
                        campo[5].Trim(), //Real Incidencia 
                        campo[6].Trim(), //Dif. Costo 
                        campo[7].Trim() }; //Dif. Incidencia
                    _listaDelReporte.Add(lineaDB);
                }
                string[] leyendasDeTotal = new string[]{
                    "Total Importe Real.",
                    "Re-ajuste",
                    "TOTAL IMPORTE",
                    "Total Costo Ppto.",
                    "Total Costo Real",
                    "Total Costo Dif.",
                    "Utilidad Ppto.",
                    "Utilidad Real",
                    "Utilidad Dif." };
                string[] valoresDeTotal = new string[]{
                    "$" + Formulario.ValidarCampoMoneda(txtTotalRealImporte.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtReajuste.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(lblTotalImporte.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtTotalCostoPpto.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtTotalCostoReal.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtTotalCostoDif.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtUtilidadPpto.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtUtilidadReal.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtUtilidadDif.Text.Replace(".", ""))};
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                string tituloA = "Rentabilidad por Centros de Costo (Costo)";
                string tituloB = cmbCentroCosto.Text + " Periodo " + cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value);
                reporte.crearDocumentoExcel_ListaConTotal(tituloA, tituloB, subTitulos, new int[] { 32, 25, 12, 12, 12, 12, 12, 12 }, _listaDelReporte, new List<int> { }, leyendasDeTotal, valoresDeTotal, 3, 3, 23, 100, true); //129
            }
        }
        #endregion

        #region Métodos de Formulario  
        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(RentabilidadCentroCosto objRentabilidadCentroCosto)
        {
            this.objRentabilidadCentroCosto = objRentabilidadCentroCosto; //Obtiene los datos del objeto recibido
            if (objRentabilidadCentroCosto != null)
            {
                _controladorDeNuevoRegistro = false;
                _idRentabilidadCentroCosto = (objRentabilidadCentroCosto != null) ? objRentabilidadCentroCosto.Id : 0;
                cmbCentroCosto.Text = objRentabilidadCentroCosto.CentroCosto.Denominacion;
                string[] periodo = objRentabilidadCentroCosto.Periodo.ToString().Split('-');
                cmbPeriodo.Text = periodo[0];
                txtPeriodo.Text = periodo[1];
                txtEstado.Text = objRentabilidadCentroCosto.Estado;
                txtTotalPptoHH.Text = Convert.ToString(objRentabilidadCentroCosto.TotalPresupuestoHH);
                txtTotalPptoImporte.Text = Formulario.ValidarCampoMoneda(Math.Round(objRentabilidadCentroCosto.TotalPresupuestoImporte, 2));
                txtTotalRealHH.Text = Convert.ToString(objRentabilidadCentroCosto.TotalRealHH);
                txtTotalRealImporte.Text = Formulario.ValidarCampoMoneda(Math.Round(objRentabilidadCentroCosto.TotalRealImporte, 2));
                txtTotalDiferenciaHH.Text = Convert.ToString(objRentabilidadCentroCosto.TotalRealHH - objRentabilidadCentroCosto.TotalPresupuestoHH);
                txtTotalDiferenciaImporte.Text = Formulario.ValidarCampoMoneda(Math.Round(objRentabilidadCentroCosto.TotalRealImporte - objRentabilidadCentroCosto.TotalPresupuestoImporte, 2));
                txtReajuste.Text = Formulario.ValidarCampoMoneda(Math.Round(objRentabilidadCentroCosto.Reajuste, 2));
                lblTotalImporte.Text = Formulario.ValidarCampoMoneda(Math.Round(objRentabilidadCentroCosto.TotalImporte, 2));
                txtTotalCostoPpto.Text = Formulario.ValidarCampoMoneda(Math.Round(objRentabilidadCentroCosto.TotalCostoPresupuesto, 2));
                txtUtilidadPpto.Text = Formulario.ValidarCampoMoneda(Math.Round(objRentabilidadCentroCosto.UtilidadPresupuesto, 2));
                txtTotalCostoReal.Text = Formulario.ValidarCampoMoneda(Math.Round(objRentabilidadCentroCosto.TotalCostoReal, 2));
                txtUtilidadReal.Text = Formulario.ValidarCampoMoneda(Math.Round(objRentabilidadCentroCosto.UtilidadReal, 2));
                txtTotalCostoDif.Text = Formulario.ValidarCampoMoneda(Math.Round(objRentabilidadCentroCosto.TotalCostoPresupuesto - objRentabilidadCentroCosto.TotalCostoReal, 2));
                txtUtilidadDif.Text = Formulario.ValidarCampoMoneda(Math.Round(objRentabilidadCentroCosto.TotalCostoPresupuesto - objRentabilidadCentroCosto.TotalCostoReal, 2));  //La diferencia entre las ultilidades es equivalente a la diferencia entre el costo presupuestado menos el costo real 
                objRentabilidadCentroCostoDetalleImporteDB = new N_RentabilidadCentroCostoDetalleImporte().obtenerObjetos(_idRentabilidadCentroCosto); //Almacena los item de detalle de comprobante
                agregarFilas_Importe(objRentabilidadCentroCostoDetalleImporteDB); //Escribe los item en el detalle de comprobante (Importe)
                objRentabilidadCentroCostoDetalleCostoDB = new N_RentabilidadCentroCostoDetalleCosto().obtenerObjetos(_idRentabilidadCentroCosto); //Almacena los item de detalle de comprobante
                agregarFilas_Costo(objRentabilidadCentroCostoDetalleCostoDB); //Escribe los item en el detalle de comprobante (Costo)
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objRentabilidadCentroCosto.EdicionFecha) + " por " + objRentabilidadCentroCosto.EdicionUsuarioDenominacion;
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objRentabilidadCentroCosto = new RentabilidadCentroCosto(
                (_idRentabilidadCentroCosto <= 0) ? 0 : _idRentabilidadCentroCosto,
                new N_CentroCosto().obtenerObjeto("DENOMINACION", cmbCentroCosto.Text),
                cmbPeriodo.Text + "-" + txtPeriodo.Text,
                txtEstado.Text,
                Formulario.ValidarNumeroEntero(txtTotalPptoHH.Text),
                Formulario.ValidarNumeroDoble(txtTotalPptoImporte.Text),
                Formulario.ValidarNumeroEntero(txtTotalRealHH.Text),
                Formulario.ValidarNumeroDoble(txtTotalRealImporte.Text),
                Formulario.ValidarNumeroDoble(txtReajuste.Text),
                Formulario.ValidarNumeroDoble(lblTotalImporte.Text),
                Formulario.ValidarNumeroDoble(txtTotalCostoPpto.Text),
                Formulario.ValidarNumeroDoble(txtUtilidadPpto.Text),
                Formulario.ValidarNumeroDoble(txtTotalCostoReal.Text),
                Formulario.ValidarNumeroDoble(txtUtilidadReal.Text),
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(cmbCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { "" }), 0); //Re-Establece los items del ComboBox
            _idRentabilidadCentroCosto = 0; //Libera el Id del Objeto seleccionado
            cmbPeriodo.Text = fechaActual.Month.ToString().PadLeft(2, '0');
            txtPeriodo.Text = fechaActual.Year.ToString();
            txtEstado.Text = "ACTIVO";
            txtTotalPptoHH.Text = "0";
            txtTotalPptoImporte.Text = "0,00";
            txtTotalRealHH.Text = "0";
            txtTotalRealImporte.Text = "0,00";
            txtTotalDiferenciaHH.Text = "0";
            txtTotalDiferenciaImporte.Text = "0,00";
            txtReajuste.Text = "0,00";
            lblTotalImporte.Text = "0,00";
            txtTotalCostoPpto.Text = "0,00";
            txtUtilidadPpto.Text = "0,00";
            txtTotalCostoReal.Text = "0,00";
            txtUtilidadReal.Text = "0,00";
            txtTotalCostoDif.Text = "0,00";
            txtUtilidadDif.Text = "0,00";
            labelPublicacion.Text = "";
            gridDetalleImporte.Rows.Clear();
            gridDetalleCosto.Rows.Clear();
            Formulario.ValidarCampoVacio(true, new Control[] { cmbCentroCosto, cmbPeriodo }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(RentabilidadCentroCosto objRentabilidadCentroCosto) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRentabilidadCentroCosto.Id; //Posiona la selección de la fila en el registro guardado
            escribirControles(objRentabilidadCentroCosto); //Escribe los datos del registro seleccionado
            objRentabilidadCentroCostoDB = objRentabilidadCentroCosto; //Importante: Se debe actualizar el Objeto precedente con el actual (evita el error de nulidad) 
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
            {
                cmbFiltroLista1.Enabled = true;
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR PERIODO")
            {
                cmbFiltroLista1.Enabled = true;
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
            if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por CUIT
            {
                consultaRentabilidadCentroCosto = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nRentabilidadCentroCosto.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR PERIODO" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por Id Interno
            {
                consultaRentabilidadCentroCosto = new string[] { filtroEstado, "PERIODO", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nRentabilidadCentroCosto.obtenerCatalago(filtroEstado, "PERIODO", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objRentabilidadCentroCostoDB = nRentabilidadCentroCosto.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objRentabilidadCentroCostoDB); //Escribe los datos del registro seleccionado
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = nRentabilidadCentroCosto.obtenerCatalago(consultaRentabilidadCentroCosto[0], consultaRentabilidadCentroCosto[1], consultaRentabilidadCentroCosto[2], "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Id",
                    "Centro de Costo",
                    "Periodo",
                    "Estado",
                    "T. Ppto. Importe",
                    "T. Real Importe",
                    "Reajuste",
                    "Total Importe",
                    "T. Ppto. Costo",
                    "T. Real Costo" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //Id
                        campo[1].Trim(), //Centro de Costo
                        campo[2].Trim(), //Periodo
                        campo[3].Trim(), //Estado
                        "$"+campo[4].Trim(), //Ppto. Importe
                        "$"+campo[5].Trim(), //Real Importe
                        "$"+campo[6].Trim(), //Reajuste
                        "$"+campo[7].Trim(), //Total Importe
                        "$"+campo[8].Trim(), //Ppto. Costo
                        "$"+campo[9].Trim() }; //Real Costo
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Rentabilidad por Centros de Costo", subTitulos, new int[] {8, 25, 9, 9, 13, 13, 13, 13, 13, 13 }, _listaDelReporte, new List<int> { }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Rentabilidad por Centros de Costo", subTitulos, new float[] { 7, 26, 8, 8, 10, 10, 10, 10, 10, 10 }, _listaDelReporte); //Ancho: 111
            }
        }
        #endregion
    }
}
