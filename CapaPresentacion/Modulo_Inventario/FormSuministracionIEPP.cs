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
    public partial class FormSuministracionIEPP : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private string _idArticulo_ControladorDeModificacion = "";
        private long _idSuministracion = 0;
        private long _idLegajo = 0;
        string[] consultaSuministracion;
        private SuministracionIEPP objSuministracionIEPP;
        private List<SuministracionIEPPDetalle> objSuministracionIEPPDetalle;
        private N_Articulo nArticulo = new N_Articulo();
        private N_SuministracionIEPP nSuministracionIEPP = new N_SuministracionIEPP();
        private N_SuministracionIEPPDetalle nSuministracionIEPPDetalle = new N_SuministracionIEPPDetalle();
        private N_Legajo nLegajo = new N_Legajo();
        #endregion

        public FormSuministracionIEPP()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormSuministracionIEPP_Load(object sender, EventArgs e)
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
            gridDetalle.Columns[3].ValueType = typeof(System.Int32);
            #endregion
            Formulario.ComboBox_CargarElementos(cmbCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { }), 0);
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO",
                "FILTRAR POR ESTADO: ANULADO", "TODOS LOS ESTADOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT", "FILTRAR POR DENOMINACION",
                "FILTRAR POR DOCUMENTO", "FILTRAR POR FECHA","FILTRAR POR ID" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
        }

        private void cmbTipoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in gridDetalle.Rows)
            {
                fila.Cells[6].ReadOnly = (_controladorDeNuevoRegistro && cmbTipoOperacion.Text == "REPOSICION") ? true : false;
            }
        }

        private void btnBuscarLegajo_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                FormCatalogo_Legajo frm = new FormCatalogo_Legajo(this);
                frm.ShowDialog(this);
            }
        }
        #endregion

        #region Eventos de Cuadricula
        private void gridDetalle_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) _idArticulo_ControladorDeModificacion = Convert.ToString(gridDetalle.CurrentRow.Cells[0].Value); //Verifica que se este dentro de la celda ID y captura el valor inicial del ID 
            else if ((e.ColumnIndex == 2 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6) && e.RowIndex >= 0)
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
            if (gridDetalle.Columns[gridDetalle.CurrentCell.ColumnIndex].Index == 2 || gridDetalle.Columns[gridDetalle.CurrentCell.ColumnIndex].Index == 4 || gridDetalle.Columns[gridDetalle.CurrentCell.ColumnIndex].Index == 5 || gridDetalle.Columns[gridDetalle.CurrentCell.ColumnIndex].Index == 6)
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
                if (gridDetalle.CurrentCell.ColumnIndex == 6) gridDetalle.CurrentCell = gridDetalle.CurrentRow.Cells[0]; //Mueve el foco a la celda de la primera columna  
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
            else if (gridDetalle.CurrentCell.ColumnIndex == 0 || gridDetalle.CurrentCell.ColumnIndex == 3) //Verifica que el ingreso de datos sea con números enteros dentro de la celda "Código" y "Cantidad"
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
            if (Global.UsuarioActivo_Privilegios.Contains(74)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idSuministracion <= 0 && Global.UsuarioActivo_Privilegios.Contains(74)) //Verifica que el usuario posea el privilegio requerido
            {
                //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                if (ValidarCampoVacio() && validarCuadricula() && validarStock())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        objSuministracionIEPP.Id = nSuministracionIEPP.generarNumeroID(); //Paso 2: Asigna un numero de ID al Objeto
                        if (nSuministracionIEPP.insertar(objSuministracionIEPP, true)) //Paso 3: Inserta el objeto
                        {
                            _idSuministracion = objSuministracionIEPP.Id; //Paso 4: Iguala la variable local con el ID asignado
                            foreach (DataGridViewRow fila in gridDetalle.Rows) //Paso 5: Recorre las filas de la cuadricula 
                            {
                                #region Registra el Detalle
                                SuministracionIEPPDetalle objSuministracionIEPPDetalle = new SuministracionIEPPDetalle(
                                    nSuministracionIEPPDetalle.generarNumeroID(), //Paso 6: Asigna un numero de ID al Objeto
                                    objSuministracionIEPP,
                                    Formulario.ValidarNumeroEntero(fila.Cells[0].Value.ToString()), //ID Código
                                    fila.Cells[1].Value.ToString().Trim(), //Denominación
                                    fila.Cells[2].Value.ToString().Trim(), //Certificación
                                    Formulario.ValidarNumeroEntero(fila.Cells[3].Value.ToString()), //Cantidad
                                    fila.Cells[4].Value.ToString().Trim(), //Unidad
                                    fila.Cells[5].Value.ToString().Trim(), //Depósito
                                    fila.Cells[6].Value.ToString().Trim()); //Inventario
                                nSuministracionIEPPDetalle.insertar(objSuministracionIEPPDetalle, false); //Paso 7: Inserta el Objeto en la Base de Datos
                                #endregion
                                actualizarArticulo("REGISTRACION", fila); //Paso 8: Actualiza los Costos y Stock de cada artículo 
                            }
                            mostrarDatos();
                        }
                    }
                }
                bool ValidarCampoVacio() // Método que valida los campos requeridos
                {
                    return Formulario.ValidarCampoVacio(false, new Control[] { cmbTipoOperacion, txtDenominacion, txtDocumento, txtCuit })
                    && gridDetalle.Rows.Count > 0;
                }
                void mostrarDatos() //Método que muestra en la pantalla los cambios generados
                {
                    filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
                    lstCatalogo.SelectedValue = _idSuministracion; //Posiona la selección de la fila en el registro guardado
                    escribirControles(nSuministracionIEPP.obtenerObjeto("ID", _idSuministracion.ToString(), true)); //Importante: Por ultimo re-Escribe todos los controles para mayor seguridad                      }
                }
            }
            else if (_idSuministracion <= 0) Mensaje.Restriccion();
            else if (_idSuministracion > 0) Mensaje.NoModificable();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idSuministracion > 0) escribirControles(nSuministracionIEPP.obtenerObjeto("ID", _idSuministracion.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(75)) //Verifica que el usuario posea el privilegio requerido
            {
                if (_idSuministracion > 0)
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea anular el comprobante ID: " + _idSuministracion.ToString() + "?") == DialogResult.Yes)
                    {
                            if (nSuministracionIEPP.anular(_idSuministracion, true)) //Paso 1: Anula el comprobante
                            {
                                foreach (DataGridViewRow fila in gridDetalle.Rows) //Paso 3: Recorre las filas de la cuadricula 
                                {
                                    actualizarArticulo("ANULACION", fila); //Paso 4: Actualiza los Costos y Stock de cada artículo
                                }
                            }
                            escribirControles(nSuministracionIEPP.obtenerObjeto("ID", _idSuministracion.ToString(), true)); //Re-Escribe los datos del objeto seleccionado
                            filtrarCatalogo(0); //Carga el catálogo
                     }
                }
            }
            else Mensaje.Restriccion();
        }

        private void btnWord_Comprobante_Click(object sender, EventArgs e)
        {
            if (_idSuministracion > 0)
            {
                if (objSuministracionIEPP.Estado == "ACTIVO")
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string[] datoDB = {
                        objSuministracionIEPP.TipoOperacion,
                        objSuministracionIEPP.Id.ToString().PadLeft(8, '0'),
                        Fecha.ConvertirFechaHora(objSuministracionIEPP.Fecha),
                        objSuministracionIEPP.Legajo.Denominacion,
                        Convert.ToString(objSuministracionIEPP.Legajo.Cuit),
                        Convert.ToString(objSuministracionIEPP.Legajo.Documento),
                        objSuministracionIEPP.Observacion };
                    Reporte reporte = new Reporte();
                    reporte.crearDocumentoWord_Comprobante_Suministracion(objSuministracionIEPP.Legajo.Denominacion, datoDB, objSuministracionIEPPDetalle);
                    Cursor.Current = Cursors.Default;
                }
                else Mensaje.Advertencia("Operación incorrecta.\nSeleccione un comprobante ACTIVO e intente nuevamente.");
            }
        }
        #endregion

        #region Métodos de Cuadricula
        private void agregarFila()
        {
            if (_controladorDeNuevoRegistro && gridDetalle.RowCount <= 15) //Verifica que no se superen las 15 filas en la cuadricula
            {
                gridDetalle.Rows.Add("", "", "NO", "0", "UNI", "EMPREMINSA", "REGISTRAR MOVIMIENTO");
                gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                gridDetalle.FirstDisplayedScrollingRowIndex = gridDetalle.RowCount - 1; //Posiciona el scroll del gridDetalle en la celda seleccionada
                SendKeys.Send("{DOWN}"); //Mueve el foco a la nueva fila  
            }
        }

        private void agregarFilas(List<SuministracionIEPPDetalle> detalle)
        {
            gridDetalle.Rows.Clear();
            foreach (SuministracionIEPPDetalle item in detalle)
            {
                gridDetalle.Rows.Add();
                gridDetalle.CurrentCell = gridDetalle.Rows[gridDetalle.RowCount - 1].Cells[0]; //Posiciona el selector del gridDetalle en la celda indicada
                gridDetalle.CurrentRow.Cells[0].Value = Convert.ToString(item.IdArticulo).PadLeft(6, '0');
                gridDetalle.CurrentRow.Cells[1].Value = Convert.ToString(item.Denominacion);
                gridDetalle.CurrentRow.Cells[2].Value = Convert.ToString(item.Certificacion);
                gridDetalle.CurrentRow.Cells[3].Value = Convert.ToString(item.Cantidad);
                gridDetalle.CurrentRow.Cells[4].Value = Convert.ToString(item.Unidad);
                gridDetalle.CurrentRow.Cells[5].Value = Convert.ToString(item.Deposito);
                gridDetalle.CurrentRow.Cells[6].Value = Convert.ToString(item.Inventario);
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
            gridDetalle.Rows[indiceFila].Cells[2].Value = "NO";
            gridDetalle.Rows[indiceFila].Cells[3].Value = "0";
            gridDetalle.Rows[indiceFila].Cells[4].Value = (objArticulo != null) ? objArticulo.Unidad : "UNI";
            gridDetalle.Rows[indiceFila].Cells[4].ReadOnly = actividad;
            gridDetalle.Rows[indiceFila].Cells[5].Value = "EMPREMINSA";
            gridDetalle.Rows[indiceFila].Cells[6].Value = "REGISTRAR MOVIMIENTO";
            gridDetalle.Rows[indiceFila].Cells[6].ReadOnly = (cmbTipoOperacion.Text == "REPOSICION") ? true : false;
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
                    if (Formulario.ValidarNumeroEntero(fila.Cells[3].Value.ToString()) <= 0) //Verifica si hay cantidades inválidas
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
                            if (cmbTipoOperacion.Text == "REPOSICION" && fila.Cells[0].Value.ToString() == filaDuplicada.Cells[0].Value.ToString() && fila.Cells[5].Value.ToString() == filaDuplicada.Cells[5].Value.ToString()) controladorDeDuplicado += 1;
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
            if (gridDetalle.Rows.Count > 0 && cmbTipoOperacion.Text == "REPOSICION")
            {
                foreach (DataGridViewRow fila in gridDetalle.Rows)
                {
                    int codigo = Formulario.ValidarNumeroEntero(fila.Cells[0].Value.ToString());
                    int cantidad = Formulario.ValidarNumeroEntero(fila.Cells[3].Value.ToString());
                    Articulo articulo = nArticulo.obtenerObjeto("TODOS", "ID", fila.Cells[0].Value.ToString(), false);
                    if (codigo > 0 && fila.Cells[5].Value.ToString() == "EMPREMINSA" && cantidad > articulo.A1_Stock) //Verifica que la cantidad ingresada No supere el stock del deposito seleccionado
                    {
                        // ---------- BLOQUE CONTROLADOR DE STOCK INSUFICIENTE ---------- //
                        Mensaje.Advertencia("Stock Insuficiente.\nVerifique el stock del articulo ID " + articulo.Id.ToString() + " e intente nuevamente.");
                        return false;
                    }
                    else if (codigo > 0 && fila.Cells[5].Value.ToString() == "VELADERO" && cantidad > articulo.A2_Stock) //Verifica que la cantidad ingresada No supere el stock del deposito seleccionado
                    {
                        // ---------- BLOQUE CONTROLADOR DE STOCK INSUFICIENTE ---------- //
                        Mensaje.Advertencia("Stock Insuficiente.\nVerifique el stock del articulo ID " + articulo.Id.ToString() + " e intente nuevamente.");
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
                        "NO",
                        "0",
                        variablesDeFormulario[3],
                        "EMPREMINSA",
                        "REGISTRAR MOVIMIENTO"
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
                int cantidad = Formulario.ValidarNumeroEntero(fila.Cells[3].Value.ToString());
                Articulo objArticulo = nArticulo.obtenerObjeto("TODOS", "ID", fila.Cells[0].Value.ToString().Trim(), false); //Paso 9: Arrastra los datos del artículo BD  
                objArticulo.Estado = "ACTIVO"; //Re-Establece forzadamente el estado del artículo
                if (operacion == "REGISTRACION")
                {
                    if (cmbTipoOperacion.Text == "REPOSICION")
                    {
                        if (fila.Cells[5].Value.ToString() == "EMPREMINSA") objArticulo.A1_Stock = objArticulo.A1_Stock - cantidad; //Resta la cantidad al stock del depósito de Empreminsa
                        else if (fila.Cells[5].Value.ToString() == "VELADERO") objArticulo.A2_Stock = objArticulo.A2_Stock - cantidad; //Resta la cantidad al stock del depósito de Veladero
                    }
                    else if (cmbTipoOperacion.Text == "DEVOLUCION" && fila.Cells[6].Value.ToString() == "REGISTRAR MOVIMIENTO")
                    {
                        if (fila.Cells[5].Value.ToString() == "EMPREMINSA") objArticulo.A1_Stock = objArticulo.A1_Stock + cantidad; //Suma la cantidad al stock del depósito de Empreminsa
                        else if(fila.Cells[5].Value.ToString() == "VELADERO") objArticulo.A2_Stock = objArticulo.A2_Stock + cantidad; //Suma la cantidad al stock del depósito de Veladero
                   }
                }
                if (operacion == "ANULACION")
                {
                    if (cmbTipoOperacion.Text == "REPOSICION")
                    {
                        if (fila.Cells[5].Value.ToString() == "EMPREMINSA") objArticulo.A1_Stock = objArticulo.A1_Stock + cantidad; //Suma la cantidad al stock del depósito de Empreminsa
                        else if (fila.Cells[5].Value.ToString() == "VELADERO") objArticulo.A2_Stock = objArticulo.A2_Stock + cantidad; //Suma la cantidad al stock del depósito de Veladero
                    }
                    else if (cmbTipoOperacion.Text == "DEVOLUCION" && fila.Cells[6].Value.ToString() == "REGISTRAR MOVIMIENTO")
                    {
                        if (fila.Cells[5].Value.ToString() == "EMPREMINSA") objArticulo.A1_Stock = objArticulo.A1_Stock - cantidad; //Resta la cantidad al stock del depósito de Empreminsa
                        else if (fila.Cells[5].Value.ToString() == "VELADERO") objArticulo.A2_Stock = objArticulo.A2_Stock - cantidad; //Resta la cantidad al stock del depósito de Veladero
                    }
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

        private void escribirControles(SuministracionIEPP objSuministracionIEPP)
        {
            this.objSuministracionIEPP = objSuministracionIEPP; //Obtiene los datos del objeto recibido
            if (objSuministracionIEPP != null)
            {
                _controladorDeNuevoRegistro = false;
                _idArticulo_ControladorDeModificacion = ""; //Libera el Id del Objeto seleccionado
                _idSuministracion = (objSuministracionIEPP != null) ? objSuministracionIEPP.Id : 0;
                txtID.Text = Convert.ToString(objSuministracionIEPP.Id).PadLeft(8, '0');
                txtFecha.Text = Fecha.ConvertirFecha(objSuministracionIEPP.Fecha);
                txtEstado.Text = objSuministracionIEPP.Estado;
                cmbTipoOperacion.Text = objSuministracionIEPP.TipoOperacion;
                _idLegajo = (objSuministracionIEPP != null) ? objSuministracionIEPP.Legajo.Id : 0;
                txtDenominacion.Text = objSuministracionIEPP.Legajo.Denominacion;
                txtDocumento.Text = Convert.ToString(objSuministracionIEPP.Legajo.Documento);
                txtCuit.Text = Convert.ToString(objSuministracionIEPP.Legajo.Cuit);
                cmbCentroCosto.Text = (objSuministracionIEPP.CentroCosto != null) ? objSuministracionIEPP.CentroCosto.Denominacion : "";
                txtObservacion.Text = objSuministracionIEPP.Observacion;
                objSuministracionIEPPDetalle = new N_SuministracionIEPPDetalle().obtenerObjetos(_idSuministracion); //Almacena los item de detalle de comprobante
                agregarFilas(objSuministracionIEPPDetalle); //Escribe los item en el detalle de comprobante
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objSuministracionIEPP.EdicionFecha) + " por " + objSuministracionIEPP.EdicionUsuarioDenominacion;
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objSuministracionIEPP = new SuministracionIEPP(
                (_idSuministracion <= 0) ? 0 : _idSuministracion,
                fechaActual,
                "ACTIVO",
                cmbTipoOperacion.Text,
                nLegajo.obtenerObjeto("ID", Convert.ToString(_idLegajo)),
                new N_CentroCosto().obtenerObjeto("DENOMINACION", cmbCentroCosto.Text),
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
            _idSuministracion = 0; //Libera el Id del Objeto seleccionado
            txtID.Text = "00000000";
            txtFecha.Text = Fecha.SistemaFecha();
            txtEstado.Text = "ACTIVO";
            cmbTipoOperacion.Text = "REPOSICION";
            _idLegajo = 0; //Libera el Id del Objeto seleccionado
            txtDenominacion.Text = "";
            txtDocumento.Text = "";
            txtCuit.Text = "";
            txtObservacion.Text = "";
            gridDetalle.Rows.Clear();
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { cmbTipoOperacion, txtDenominacion, txtDocumento, txtCuit }); //Restauración de campos invalidados
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
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DOCUMENTO")
            {
                cmbFiltroLista1.Enabled = true;
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA")
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
            if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por CUIT
            {
                consultaSuministracion = new string[] { filtroEstado, "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nSuministracionIEPP.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la descripcion
            {
                consultaSuministracion = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nSuministracionIEPP.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DOCUMENTO" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por CUIT
            {
                consultaSuministracion = new string[] { filtroEstado, "DOCUMENTO", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nSuministracionIEPP.obtenerCatalago(filtroEstado, "DOCUMENTO", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA") //Verifica que el tipo de filtro es por ña fecha de comprobante
            {
                consultaSuministracion = new string[] { filtroEstado, "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nSuministracionIEPP.obtenerCatalago(filtroEstado, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por Id interno
            {
                consultaSuministracion = new string[] { filtroEstado, "ID", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nSuministracionIEPP.obtenerCatalago(filtroEstado, "ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            escribirControles(nSuministracionIEPP.obtenerObjeto("ID", idElemento.ToString(), true)); //Escribe los datos del registro seleccionado
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                if (consultaSuministracion.Length == 3)
                    lista = nSuministracionIEPP.obtenerCatalago(consultaSuministracion[0], consultaSuministracion[1], consultaSuministracion[2], "CATALOGO1");
                else if (consultaSuministracion.Length == 4)
                    lista = nSuministracionIEPP.obtenerCatalago(consultaSuministracion[0], consultaSuministracion[1], Fecha.ValidarFecha(consultaSuministracion[2]), Fecha.ValidarFecha(consultaSuministracion[3]), "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "N° Cbte.",
                    "Fecha",
                    "Estado",
                    "T. Operación",
                    "Denominación",
                    "CUIL/CUIT",
                    "Centro de Costo" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //N° Cbte.
                        campo[1].Trim(), //Fecha
                        campo[2].Trim(), //Estado
                        campo[3].Trim(), //T. Operación
                        campo[4].Trim().Substring(0, 35), //Denominación
                        campo[4].Trim().Substring(36, 13), //CUIL/CUIT
                        campo[5].Trim() }; //Centro de Costo
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Suministraciones de Indumentaria y EPP", subTitulos, new int[] { 10, 10, 10, 10, 51, 13, 25}, _listaDelReporte, new List<int> { 1 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Suministraciones de Indumentaria y EPP", subTitulos, new float[] { 9, 9, 9, 9, 42, 11, 22}, _listaDelReporte); //Ancho: 111
            }
        }

        public override void asignarVariablesDeFormulario(string[] variablesDeFormulario) //Método Sobrescribible
        {
            if (variablesDeFormulario[0] == "Catalogo_Legajo") //Catálogo de Legajos
            {
                Legajo legajo = new N_Legajo().obtenerObjeto("ID", variablesDeFormulario[1], false);
                _idLegajo = legajo.Id;
                txtDenominacion.Text = legajo.Denominacion;
                txtCuit.Text = Convert.ToString(legajo.Cuit);
                txtDocumento.Text = Convert.ToString(legajo.Documento);
            }
        }
        #endregion
    }
}
