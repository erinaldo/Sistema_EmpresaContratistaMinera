using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormControlStock : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private string _idArticulo_ControladorDeModificacion = "";
        private string _deposito = "";
        private long _idControlStock = 0;
        string[] consultaControlStock;
        private ControlStock objControlStock;
        private List<ControlStockDetalle> objControlStockDetalle;
        private N_Articulo nArticulo = new N_Articulo();
        private N_ControlStock nControlStock = new N_ControlStock();
        private N_ControlStockDetalle nControlStockDetalle = new N_ControlStockDetalle();
        #endregion

        public FormControlStock()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormControlStock_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(txtID, "Número de comprobante");
            toolTip.SetToolTip(txtFecha, "Fecha de comprobante");
            toolTip.SetToolTip(txtEstado, "Estado del comprobante");
            toolTip.SetToolTip(btnAdherirExistencia, "Adhiere todos los artículos existentes del depósito");
            toolTip.SetToolTip(btnImportarPlantilla, "Importa el control de stock desde una plantilla de Excel");
            toolTip.SetToolTip(btnNuevo, "Crea un nuevo registro");
            toolTip.SetToolTip(btnGuardar, "Guarda los cambios realizados");
            toolTip.SetToolTip(btnCancelar, "Deshace los cambios realizados");
            toolTip.SetToolTip(btnAnular, "Anular un registro");
            #endregion
            #region Tipo de Datos
            gridDetalle.Columns[0].ValueType = typeof(System.Int32);
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

        private void cmbDeposito_Validated(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                if ((cmbDeposito.Text == "EMPREMINSA" && _deposito != "EMPREMINSA") || (cmbDeposito.Text == "VELADERO" && _deposito != "VELADERO")) //Verifica si hay una modificación. De ser asi, resetea el tipo de beneficiario seleccionado
                {
                    _deposito = cmbDeposito.Text;
                    gridDetalle.Rows.Clear(); //Elimina todas las filas de la cuadricula
                }
            }
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
                if ((e.ColumnIndex == 4) && e.RowIndex >= 0) //Verifica que se este dentro de la celda "Recuento"
                {
                    if (e.RowIndex != (gridDetalle.RowCount - 1)) SendKeys.Send("{UP}"); //Bloque 1b: Mantiene el foco en la celda editada
                    calcularDeduccion(e.RowIndex); //Calcula la Deducción de la fila
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
                if (gridDetalle.CurrentCell.ColumnIndex == 5) gridDetalle.CurrentCell = gridDetalle.CurrentRow.Cells[0]; //Mueve el foco a la celda de la primera columna  
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
            }
            else if (e.KeyChar == '*') //Tecla de Acesso Directo "Buscar Artículo"
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '+') //Tecla de Acesso Directo "Agregar Fila"
            {
                e.Handled = true;
            }
            else if (gridDetalle.CurrentCell.ColumnIndex == 4) //Verifica que el ingreso de datos sea con números enteros dentro de la celda "Recuento"
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) e.Handled = true;
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

        private void btnAdherirExistencia_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro) agregarFilas(nArticulo.obtenerExistencias(cmbDeposito.Text));
        }

        private void btnImportarPlantilla_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                agregarFilas(Importacion.ImportarXLSX(cmbDeposito.Text));
            }
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
          {
              if (Global.UsuarioActivo_Privilegios.Contains(65)) //Verifica que el usuario posea el privilegio requerido
              {
                  restaurarControles();
                  _controladorDeNuevoRegistro = true;
                  labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
              }
              else Mensaje.Restriccion();
          }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idControlStock <= 0 && _controladorDeNuevoRegistro)
            {
                if (_idControlStock <= 0 && Global.UsuarioActivo_Privilegios.Contains(65)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (ValidarCampoVacio() && validarCuadricula())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            objControlStock.Id = nControlStock.generarNumeroID(); //Paso 2: Asigna un numero de ID al Objeto
                            if (nControlStock.insertar(objControlStock, true)) //Paso 3: Inserta el objeto
                            {
                                _idControlStock = objControlStock.Id; //Paso 4: Iguala la variable local con el ID asignado
                                foreach (DataGridViewRow fila in gridDetalle.Rows) //Paso 5: Recorre las filas de la cuadricula 
                                {
                                    #region Registra el Detalle
                                    ControlStockDetalle objControlStockDetalle = new ControlStockDetalle(
                                        nControlStockDetalle.generarNumeroID(), //Paso 6: Asigna un numero de ID al Objeto
                                        objControlStock,
                                        Formulario.ValidarNumeroEntero(fila.Cells[0].Value.ToString()), //ID Código
                                        fila.Cells[1].Value.ToString().Trim(), //Denominación
                                        Formulario.ValidarNumeroEntero(fila.Cells[2].Value.ToString()), //Stock
                                        fila.Cells[3].Value.ToString().Trim(), //Unidad
                                        Formulario.ValidarNumeroEntero(fila.Cells[4].Value.ToString()), //Recuento
                                        Formulario.ValidarNumeroEntero(fila.Cells[5].Value.ToString()));//Deducción
                                    nControlStockDetalle.insertar(objControlStockDetalle, true); //Paso 7: Inserta el Objeto en la Base de Datos
                                    #endregion
                                    actualizarArticulo("REGISTRACION", fila); //Paso 8: Actualiza los Costos y Stock de cada artículo 
                                }
                                mostrarDatos();
                            }
                        }
                    }
                    bool ValidarCampoVacio() // Método que valida los campos requeridos
                    {
                        return Formulario.ValidarCampoVacio(false, new Control[] { cmbDeposito });
                    }
                    void mostrarDatos() //Método que muestra en la pantalla los cambios generados
                    {
                        filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
                        lstCatalogo.SelectedValue = _idControlStock; //Posiona la selección de la fila en el registro guardado
                        escribirControles(nControlStock.obtenerObjeto("ID", _idControlStock.ToString(), true)); //Importante: Por ultimo re-Escribe todos los controles para mayor seguridad                      }
                    }
                }
                else if (_idControlStock <= 0) Mensaje.Restriccion();
                else if (_idControlStock > 0) Mensaje.NoModificable();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
          {
              if (_idControlStock > 0) escribirControles(nControlStock.obtenerObjeto("ID", _idControlStock.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
              else restaurarControles();
          }

        private void btnAnular_Click(object sender, EventArgs e)
          {
              if (Global.UsuarioActivo_Privilegios.Contains(66)) //Verifica que el usuario posea el privilegio requerido
              {
                  if (_idControlStock > 0)
                  {
                      if (Mensaje.ConfirmacionBoton1("¿Desea anular el comprobante ID: " + _idControlStock.ToString() + "?") == DialogResult.Yes)
                      {
                              if (nControlStock.anular(_idControlStock, true)) //Paso 1: Anula el comprobante
                              {
                                  foreach (DataGridViewRow fila in gridDetalle.Rows) //Paso 3: Recorre las filas de la cuadricula 
                                  {
                                      actualizarArticulo("ANULACION", fila); //Paso 4: Actualiza los Costos y Stock de cada artículo
                                  }
                              }
                              escribirControles(nControlStock.obtenerObjeto("ID", _idControlStock.ToString(), true)); //Re-Escribe los datos del objeto seleccionado
                              filtrarCatalogo(0); //Carga el catálogo
                       }
                  }
              }
              else Mensaje.Restriccion();
          }
        #endregion

        #region Métodos de Cuadricula
        private void agregarFilas(List<ControlStockDetalle> detalle)
          {
              gridDetalle.Rows.Clear();
              foreach (ControlStockDetalle item in detalle)
              {
                  gridDetalle.Rows.Add();
                  gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                  gridDetalle.CurrentRow.Cells[0].Value = Convert.ToString(item.IdArticulo).PadLeft(6, '0');
                  gridDetalle.CurrentRow.Cells[1].Value = Convert.ToString(item.Denominacion);
                  gridDetalle.CurrentRow.Cells[2].Value = Convert.ToString(item.Stock);
                  gridDetalle.CurrentRow.Cells[3].Value = Convert.ToString(item.Unidad);
                  gridDetalle.CurrentRow.Cells[4].Value = Convert.ToString(item.Recuento);
                  gridDetalle.CurrentRow.Cells[5].Value = Convert.ToString(item.Deduccion);
              }
              if (gridDetalle.CurrentCell != null) gridDetalle.CurrentCell.Selected = false; //Quita la selección de la celda
          }

        private void agregarFilas(List<Articulo> inventario)
          {
              gridDetalle.Rows.Clear();
              foreach (Articulo item in inventario)
              {
                  gridDetalle.Rows.Add();
                  gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                  gridDetalle.CurrentRow.Cells[0].Value = Convert.ToString(item.Id).PadLeft(6, '0');
                  gridDetalle.CurrentRow.Cells[1].Value = Convert.ToString(item.Denominacion);
                  gridDetalle.CurrentRow.Cells[2].Value = Convert.ToString((cmbDeposito.Text == "EMPREMINSA") ? item.A1_Stock : (cmbDeposito.Text == "VELADERO") ? item.A2_Stock : 0);
                  gridDetalle.CurrentRow.Cells[3].Value = Convert.ToString(item.Unidad);
                  gridDetalle.CurrentRow.Cells[4].Value = "0";
                  gridDetalle.CurrentRow.Cells[5].Value = "0";
              }
              if (gridDetalle.CurrentCell != null) gridDetalle.CurrentCell.Selected = false; //Quita la selección de la celda
          }

        private void agregarFilas(DataTable datosXLSX)
          {
              gridDetalle.Rows.Clear();
              for (int i=4; i<datosXLSX.Rows.Count; i++) //Importante: "i=4" representa el espacio del encabezado de la plantilla de Excel.
              {
                  Articulo articulo = nArticulo.obtenerObjeto("TODOS", "ID", Convert.ToString(datosXLSX.Rows[i][0]), false);
                  gridDetalle.Rows.Add();
                  gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                  gridDetalle.CurrentRow.Cells[0].Value = Convert.ToString(datosXLSX.Rows[i][0]).PadLeft(6, '0');
                  gridDetalle.CurrentRow.Cells[1].Value = articulo.Denominacion;
                  gridDetalle.CurrentRow.Cells[2].Value = Convert.ToString((cmbDeposito.Text == "EMPREMINSA") ? articulo.A1_Stock : (cmbDeposito.Text == "VELADERO") ? articulo.A2_Stock : 0);
                  gridDetalle.CurrentRow.Cells[3].Value = articulo.Unidad;
                  gridDetalle.CurrentRow.Cells[4].Value = Convert.ToString(Formulario.ValidarNumeroEntero(Convert.ToString(datosXLSX.Rows[i][2])));
                  gridDetalle.CurrentRow.Cells[5].Value = Convert.ToString(Formulario.ValidarNumeroEntero(Convert.ToString(datosXLSX.Rows[i][2])) - Formulario.ValidarNumeroEntero(Convert.ToString(gridDetalle.CurrentRow.Cells[2].Value)));
              }
              if (gridDetalle.CurrentCell != null) gridDetalle.CurrentCell.Selected = false; //Quita la selección de la celda
          }

        private void calcularDeduccion(int indiceFila)
          {
              int stock = Formulario.ValidarNumeroEntero(Convert.ToString(gridDetalle.Rows[indiceFila].Cells[2].Value));
              int recuento = Formulario.ValidarNumeroEntero(Convert.ToString(gridDetalle.Rows[indiceFila].Cells[4].Value));
              gridDetalle.Rows[indiceFila].Cells[5].Value = Convert.ToString(recuento - stock);
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
            if (gridDetalle.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in gridDetalle.Rows)
                {
                    if (Formulario.ValidarNumeroEntero(fila.Cells[4].Value.ToString()) == 0 && Formulario.ValidarNumeroEntero(fila.Cells[5].Value.ToString()) == 0) //Verifica si hay el recuento y deducción es inválido
                    {
                        // ---------- BLOQUE CONTROLADOR DE CANTIDAD INVALIDA ---------- //
                        Mensaje.Advertencia("Operación Incorrecta.\nVerifique en cada ítem del detalle que el recuento y/o deducción sea válido e intente nuevamente.");
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
                        variablesDeFormulario[3]
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
                int recuento = Formulario.ValidarNumeroEntero(fila.Cells[4].Value.ToString());
                int deduccion = Formulario.ValidarNumeroEntero(fila.Cells[5].Value.ToString());
                Articulo objArticulo = nArticulo.obtenerObjeto("TODOS", "ID", fila.Cells[0].Value.ToString().Trim(), false); //Paso 9: Arrastra los datos del artículo BD  
                if (operacion == "REGISTRACION")
                {
                    if (cmbDeposito.Text == "EMPREMINSA") objArticulo.A1_Stock = recuento; //Reemplaza el stock del depósito de Empreminsa con el recuento actual
                    else if(cmbDeposito.Text == "VELADERO") objArticulo.A2_Stock = recuento; //Reemplaza el stock del depósito de Veladero con el recuento actual
                }
                else if(operacion == "ANULACION")
                {
                    if (cmbDeposito.Text == "EMPREMINSA") objArticulo.A1_Stock = recuento + Math.Abs(deduccion); //Restaura el stock del depósito de Empreminsa
                    else if(cmbDeposito.Text == "VELADERO") objArticulo.A2_Stock = recuento + Math.Abs(deduccion); //Restaura el stock del depósito de Veladero
                }
                #region Puntos de Stock
                objArticulo.A1_PuntoCriticoAlertado = (objArticulo.A1_PuntoCritico && objArticulo.A1_Stock <= objArticulo.A1_PuntoCriticoLimite) ? false : true; //Determina el disparo de la alerta 
                objArticulo.A1_PuntoMinimoAlertado = (objArticulo.A1_PuntoMinimo && objArticulo.A1_Stock <= objArticulo.A1_PuntoMinimoLimite) ? false : true; //Determina el disparo de la alerta 
                objArticulo.A2_PuntoCriticoAlertado = (objArticulo.A2_PuntoCritico && objArticulo.A2_Stock <= objArticulo.A2_PuntoCriticoLimite) ? false : true; //Determina el disparo de la alerta 
                objArticulo.A2_PuntoMinimoAlertado = (objArticulo.A2_PuntoMinimo && objArticulo.A2_Stock <= objArticulo.A2_PuntoMinimoLimite) ? false : true; //Determina el disparo de la alerta 
                #endregion
                objArticulo.StockGlobal = objArticulo.A1_Stock + objArticulo.A2_Stock; //Actualiza el stock Global
                nArticulo.actualizar(objArticulo, false); //Actualiza los valores del artículo
            }
        }

        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(ControlStock objControlStock)
        {
            this.objControlStock = objControlStock; //Obtiene los datos del objeto recibido
            if (objControlStock != null)
            {
                _controladorDeNuevoRegistro = false;
                _idArticulo_ControladorDeModificacion = ""; //Libera el Id del Objeto seleccionado
                _idControlStock = (objControlStock != null) ? objControlStock.Id : 0;
                txtID.Text = Convert.ToString(objControlStock.Id).PadLeft(8, '0');
                txtFecha.Text = Fecha.ConvertirFecha(objControlStock.Fecha);
                txtEstado.Text = objControlStock.Estado;
                cmbDeposito.Text = objControlStock.Deposito;
                txtObservacion.Text = objControlStock.Observacion;
                objControlStockDetalle = new N_ControlStockDetalle().obtenerObjetos(_idControlStock); //Almacena los item de detalle de comprobante
                agregarFilas(objControlStockDetalle); //Escribe los item en el detalle de comprobante
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objControlStock.EdicionFecha) + " por " + objControlStock.EdicionUsuarioDenominacion;
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objControlStock = new ControlStock(
                (_idControlStock <= 0) ? 0 : _idControlStock,
                fechaActual,
                "ACTIVO",
                cmbDeposito.Text,
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
            _idControlStock = 0; //Libera el Id del Objeto seleccionado
            txtID.Text = "00000000";
            txtFecha.Text = Fecha.SistemaFecha();
            txtEstado.Text = "ACTIVO";
            _deposito = "EMPREMINSA";
            cmbDeposito.Text = "EMPREMINSA";
            txtObservacion.Text = "";
            gridDetalle.Rows.Clear();
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { cmbDeposito }); //Restauración de campos invalidados
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
                consultaControlStock = new string[] { filtroEstado, "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nControlStock.obtenerCatalago(filtroEstado, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if(cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por Id interno
            {
                consultaControlStock = new string[] { filtroEstado, "ID", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nControlStock.obtenerCatalago(filtroEstado, "ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            escribirControles(nControlStock.obtenerObjeto("ID", idElemento.ToString(), true)); //Escribe los datos del registro seleccionado
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                if (consultaControlStock.Length == 3)
                    lista = nControlStock.obtenerCatalago(consultaControlStock[0], consultaControlStock[1], consultaControlStock[2], "CATALOGO1");
                else if (consultaControlStock.Length == 4)
                    lista = nControlStock.obtenerCatalago(consultaControlStock[0], consultaControlStock[1], Fecha.ValidarFecha(consultaControlStock[2]), Fecha.ValidarFecha(consultaControlStock[3]), "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "N° Cbte.",
                    "Fecha",
                    "Estado",
                    "Depósito" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //N° Cbte.
                        campo[1].Trim(), //Fecha
                        campo[2].Trim(), //Estado
                        campo[3].Trim() }; //Depósito
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Controles de Stock", subTitulos, new int[] { 10, 10, 10, 99 }, _listaDelReporte, new List<int> { 1 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Controles de Stock", subTitulos, new float[] { 9, 9, 9, 84 }, _listaDelReporte); //Ancho: 111
            }
        }

        public override void asignarVariablesDeFormulario(string[] variablesDeFormulario) { } //Método Sobrescribible
        #endregion
    }
}
