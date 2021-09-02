namespace CapaPresentacion
{
    partial class FormConsumoStock
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                nArticulo.Dispose();
                nConsumoStock.Dispose();
                nConsumoStockDetalle.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnBuscarFila = new Biblioteca.Controles.MiButtonBase();
            this.btnQuitarFila = new Biblioteca.Controles.MiButton24x24();
            this.btnAgregarFila = new Biblioteca.Controles.MiButton24x24();
            this.lblCatalagoTitulo7 = new System.Windows.Forms.Label();
            this.gridDetalle = new Biblioteca.Controles.MiGridEdit();
            this.txtEstado = new Biblioteca.Controles.MiTextBoxRead();
            this.txtFecha = new Biblioteca.Controles.MiTextBoxRead();
            this.txtID = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtObservacion = new Biblioteca.Controles.MiTextBox();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.cmbDeposito = new Biblioteca.Controles.MiComboBox();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.btnImportarPlantilla = new Biblioteca.Controles.MiButton24x24();
            this.btnAdherirExistencia = new Biblioteca.Controles.MiButton24x24();
            this.cmbCentroCosto = new Biblioteca.Controles.MiComboBox();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDenominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColConsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDesecho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnidad = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAlicuotaIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAnular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnExcel_Registro
            // 
            this.btnExcel_Registro.Enabled = false;
            this.btnExcel_Registro.FlatAppearance.BorderSize = 0;
            this.btnExcel_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Registro.Visible = false;
            // 
            // btnPDF_Registro
            // 
            this.btnPDF_Registro.Enabled = false;
            this.btnPDF_Registro.FlatAppearance.BorderSize = 0;
            this.btnPDF_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Registro.Visible = false;
            // 
            // lblTituloLista
            // 
            this.lblTituloLista.Size = new System.Drawing.Size(315, 23);
            this.lblTituloLista.Text = "Lista de Consumos de Stock";
            // 
            // btnExcel_Lista
            // 
            this.btnExcel_Lista.FlatAppearance.BorderSize = 0;
            this.btnExcel_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // btnPDF_Lista
            // 
            this.btnPDF_Lista.FlatAppearance.BorderSize = 0;
            this.btnPDF_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // lblCatalagoTitulo1
            // 
            this.lblCatalagoTitulo1.Size = new System.Drawing.Size(46, 14);
            this.lblCatalagoTitulo1.Text = "N° Cbte.";
            // 
            // lblCatalagoTitulo2
            // 
            this.lblCatalagoTitulo2.Location = new System.Drawing.Point(77, 36);
            this.lblCatalagoTitulo2.Size = new System.Drawing.Size(37, 14);
            this.lblCatalagoTitulo2.Text = "Fecha";
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(168, 36);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(40, 14);
            this.lblCatalagoTitulo3.Text = "Estado";
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(238, 36);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(49, 14);
            this.lblCatalagoTitulo4.Text = "Depósito";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(329, 36);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(85, 14);
            this.lblCatalagoTitulo5.Text = "Centro de Costo";
            // 
            // panelLista
            // 
            this.panelLista.Controls.Add(this.lblCatalagoTitulo7);
            this.panelLista.Controls.SetChildIndex(this.pkrFiltroListaDesde, 0);
            this.panelLista.Controls.SetChildIndex(this.pkrFiltroListaHasta, 0);
            this.panelLista.Controls.SetChildIndex(this.txtFiltroLista, 0);
            this.panelLista.Controls.SetChildIndex(this.lstCatalogo, 0);
            this.panelLista.Controls.SetChildIndex(this.lblTituloLista, 0);
            this.panelLista.Controls.SetChildIndex(this.cmbFiltroLista1, 0);
            this.panelLista.Controls.SetChildIndex(this.cmbFiltroLista2, 0);
            this.panelLista.Controls.SetChildIndex(this.btnExcel_Lista, 0);
            this.panelLista.Controls.SetChildIndex(this.btnPDF_Lista, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo1, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo2, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo3, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo4, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo5, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo6, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo7, 0);
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(782, 36);
            this.lblCatalagoTitulo6.Text = "Campo6";
            this.lblCatalagoTitulo6.Visible = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Consumos de Stock";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // btnBuscarFila
            // 
            this.btnBuscarFila.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBuscarFila.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarFila.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_find32;
            this.btnBuscarFila.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscarFila.FlatAppearance.BorderSize = 0;
            this.btnBuscarFila.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBuscarFila.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuscarFila.Font = new System.Drawing.Font("Arial", 9F);
            this.btnBuscarFila.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarFila.Location = new System.Drawing.Point(208, 379);
            this.btnBuscarFila.Name = "btnBuscarFila";
            this.btnBuscarFila.Size = new System.Drawing.Size(24, 24);
            this.btnBuscarFila.TabIndex = 24;
            this.btnBuscarFila.UseVisualStyleBackColor = false;
            this.btnBuscarFila.Click += new System.EventHandler(this.btnBuscarFila_Click);
            // 
            // btnQuitarFila
            // 
            this.btnQuitarFila.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnQuitarFila.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuitarFila.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_delete32;
            this.btnQuitarFila.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuitarFila.FlatAppearance.BorderSize = 0;
            this.btnQuitarFila.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnQuitarFila.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnQuitarFila.Font = new System.Drawing.Font("Arial", 8F);
            this.btnQuitarFila.ForeColor = System.Drawing.Color.Black;
            this.btnQuitarFila.Location = new System.Drawing.Point(184, 379);
            this.btnQuitarFila.Name = "btnQuitarFila";
            this.btnQuitarFila.Size = new System.Drawing.Size(24, 24);
            this.btnQuitarFila.TabIndex = 23;
            this.btnQuitarFila.UseVisualStyleBackColor = false;
            this.btnQuitarFila.Click += new System.EventHandler(this.btnQuitarFila_Click);
            // 
            // btnAgregarFila
            // 
            this.btnAgregarFila.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAgregarFila.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgregarFila.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_insert32;
            this.btnAgregarFila.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarFila.FlatAppearance.BorderSize = 0;
            this.btnAgregarFila.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAgregarFila.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAgregarFila.Font = new System.Drawing.Font("Arial", 8F);
            this.btnAgregarFila.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarFila.Location = new System.Drawing.Point(160, 379);
            this.btnAgregarFila.Name = "btnAgregarFila";
            this.btnAgregarFila.Size = new System.Drawing.Size(24, 24);
            this.btnAgregarFila.TabIndex = 22;
            this.btnAgregarFila.UseVisualStyleBackColor = false;
            this.btnAgregarFila.Click += new System.EventHandler(this.btnAgregarFila_Click);
            // 
            // lblCatalagoTitulo7
            // 
            this.lblCatalagoTitulo7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo7.AutoSize = true;
            this.lblCatalagoTitulo7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo7.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo7.Location = new System.Drawing.Point(834, 36);
            this.lblCatalagoTitulo7.Name = "lblCatalagoTitulo7";
            this.lblCatalagoTitulo7.Size = new System.Drawing.Size(46, 14);
            this.lblCatalagoTitulo7.TabIndex = 254;
            this.lblCatalagoTitulo7.Text = "Campo7";
            this.lblCatalagoTitulo7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCatalagoTitulo7.Visible = false;
            // 
            // gridDetalle
            // 
            this.gridDetalle.AllowUserToAddRows = false;
            this.gridDetalle.AllowUserToDeleteRows = false;
            this.gridDetalle.AllowUserToResizeColumns = false;
            this.gridDetalle.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.gridDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDetalle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gridDetalle.BackgroundColor = System.Drawing.Color.Gray;
            this.gridDetalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColDenominacion,
            this.ColConsumo,
            this.ColDesecho,
            this.ColUnidad,
            this.ColUnitario,
            this.ColAlicuotaIVA,
            this.ColNula});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDetalle.DefaultCellStyle = dataGridViewCellStyle9;
            this.gridDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridDetalle.EnableHeadersVisualStyles = false;
            this.gridDetalle.GridColor = System.Drawing.Color.DarkGray;
            this.gridDetalle.Location = new System.Drawing.Point(160, 183);
            this.gridDetalle.MultiSelect = false;
            this.gridDetalle.Name = "gridDetalle";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.gridDetalle.RowHeadersVisible = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            this.gridDetalle.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.gridDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridDetalle.Size = new System.Drawing.Size(643, 195);
            this.gridDetalle.StandardTab = true;
            this.gridDetalle.TabIndex = 21;
            this.gridDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetalle_CellEndEdit);
            this.gridDetalle.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetalle_CellEnter);
            this.gridDetalle.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridDetalle_DataError);
            this.gridDetalle.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridDetalle_EditingControlShowing);
            this.gridDetalle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridDetalle_KeyDown);
            this.gridDetalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridDetalle_KeyPress);
            this.gridDetalle.Leave += new System.EventHandler(this.gridDetalle_Leave);
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstado.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtEstado.ForeColor = System.Drawing.Color.Black;
            this.txtEstado.Location = new System.Drawing.Point(286, 61);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(68, 22);
            this.txtEstado.TabIndex = 14;
            // 
            // txtFecha
            // 
            this.txtFecha.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFecha.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtFecha.ForeColor = System.Drawing.Color.Black;
            this.txtFecha.Location = new System.Drawing.Point(219, 61);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(68, 22);
            this.txtFecha.TabIndex = 13;
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtID.ForeColor = System.Drawing.Color.Black;
            this.txtID.Location = new System.Drawing.Point(160, 61);
            this.txtID.MaxLength = 8;
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(60, 22);
            this.txtID.TabIndex = 12;
            // 
            // miLabel1
            // 
            this.miLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel1.BackColor = System.Drawing.Color.Transparent;
            this.miLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel1.Location = new System.Drawing.Point(0, 64);
            this.miLabel1.Name = "miLabel1";
            this.miLabel1.Size = new System.Drawing.Size(160, 15);
            this.miLabel1.TabIndex = 11;
            this.miLabel1.Text = "Comprobante";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtObservacion.BackColor = System.Drawing.Color.White;
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtObservacion.ForeColor = System.Drawing.Color.Black;
            this.txtObservacion.Location = new System.Drawing.Point(160, 142);
            this.txtObservacion.MaxLength = 250;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(643, 36);
            this.txtObservacion.TabIndex = 20;
            // 
            // miLabel4
            // 
            this.miLabel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel4.BackColor = System.Drawing.Color.Transparent;
            this.miLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel4.Location = new System.Drawing.Point(0, 145);
            this.miLabel4.Name = "miLabel4";
            this.miLabel4.Size = new System.Drawing.Size(160, 15);
            this.miLabel4.TabIndex = 19;
            this.miLabel4.Text = "Observaciones";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDeposito
            // 
            this.cmbDeposito.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbDeposito.BackColor = System.Drawing.Color.White;
            this.cmbDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeposito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDeposito.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbDeposito.ForeColor = System.Drawing.Color.Black;
            this.cmbDeposito.FormattingEnabled = true;
            this.cmbDeposito.Items.AddRange(new object[] {
            "EMPREMINSA",
            "VELADERO"});
            this.cmbDeposito.Location = new System.Drawing.Point(160, 88);
            this.cmbDeposito.Margin = new System.Windows.Forms.Padding(1);
            this.cmbDeposito.Name = "cmbDeposito";
            this.cmbDeposito.Size = new System.Drawing.Size(95, 22);
            this.cmbDeposito.Sorted = true;
            this.cmbDeposito.TabIndex = 16;
            this.cmbDeposito.SelectedIndexChanged += new System.EventHandler(this.cmbDeposito_SelectedIndexChanged);
            this.cmbDeposito.Validated += new System.EventHandler(this.cmbDeposito_Validated);
            // 
            // miLabel2
            // 
            this.miLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel2.BackColor = System.Drawing.Color.Transparent;
            this.miLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel2.Location = new System.Drawing.Point(0, 91);
            this.miLabel2.Name = "miLabel2";
            this.miLabel2.Size = new System.Drawing.Size(160, 15);
            this.miLabel2.TabIndex = 15;
            this.miLabel2.Text = "Depósito";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnImportarPlantilla
            // 
            this.btnImportarPlantilla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImportarPlantilla.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnImportarPlantilla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImportarPlantilla.FlatAppearance.BorderSize = 0;
            this.btnImportarPlantilla.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnImportarPlantilla.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnImportarPlantilla.Font = new System.Drawing.Font("Arial", 8F);
            this.btnImportarPlantilla.ForeColor = System.Drawing.Color.Black;
            this.btnImportarPlantilla.Location = new System.Drawing.Point(422, 379);
            this.btnImportarPlantilla.Name = "btnImportarPlantilla";
            this.btnImportarPlantilla.Size = new System.Drawing.Size(190, 24);
            this.btnImportarPlantilla.TabIndex = 26;
            this.btnImportarPlantilla.Text = "Importar Plantilla de Control de Stock";
            this.btnImportarPlantilla.UseVisualStyleBackColor = false;
            this.btnImportarPlantilla.Click += new System.EventHandler(this.btnImportarPlantilla_Click);
            // 
            // btnAdherirExistencia
            // 
            this.btnAdherirExistencia.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdherirExistencia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdherirExistencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdherirExistencia.FlatAppearance.BorderSize = 0;
            this.btnAdherirExistencia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAdherirExistencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdherirExistencia.Font = new System.Drawing.Font("Arial", 8F);
            this.btnAdherirExistencia.ForeColor = System.Drawing.Color.Black;
            this.btnAdherirExistencia.Location = new System.Drawing.Point(232, 379);
            this.btnAdherirExistencia.Name = "btnAdherirExistencia";
            this.btnAdherirExistencia.Size = new System.Drawing.Size(190, 24);
            this.btnAdherirExistencia.TabIndex = 25;
            this.btnAdherirExistencia.Text = "Adherir las Existencias del Depósito";
            this.btnAdherirExistencia.UseVisualStyleBackColor = false;
            this.btnAdherirExistencia.Click += new System.EventHandler(this.btnAdherirExistencia_Click);
            // 
            // cmbCentroCosto
            // 
            this.cmbCentroCosto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbCentroCosto.BackColor = System.Drawing.Color.White;
            this.cmbCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCentroCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCentroCosto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCentroCosto.ForeColor = System.Drawing.Color.Black;
            this.cmbCentroCosto.FormattingEnabled = true;
            this.cmbCentroCosto.Location = new System.Drawing.Point(160, 115);
            this.cmbCentroCosto.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCentroCosto.Name = "cmbCentroCosto";
            this.cmbCentroCosto.Size = new System.Drawing.Size(190, 22);
            this.cmbCentroCosto.Sorted = true;
            this.cmbCentroCosto.TabIndex = 18;
            // 
            // miLabel3
            // 
            this.miLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel3.BackColor = System.Drawing.Color.Transparent;
            this.miLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel3.Location = new System.Drawing.Point(0, 118);
            this.miLabel3.Name = "miLabel3";
            this.miLabel3.Size = new System.Drawing.Size(160, 15);
            this.miLabel3.TabIndex = 17;
            this.miLabel3.Text = "Centro de costo";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ColID
            // 
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.ColID.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColID.HeaderText = "ID";
            this.ColID.MaxInputLength = 25;
            this.ColID.Name = "ColID";
            this.ColID.Width = 50;
            // 
            // ColDenominacion
            // 
            this.ColDenominacion.HeaderText = "Denominación";
            this.ColDenominacion.MaxInputLength = 35;
            this.ColDenominacion.Name = "ColDenominacion";
            this.ColDenominacion.ReadOnly = true;
            this.ColDenominacion.Width = 270;
            // 
            // ColConsumo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.ColConsumo.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColConsumo.HeaderText = "Consumo";
            this.ColConsumo.MaxInputLength = 6;
            this.ColConsumo.Name = "ColConsumo";
            this.ColConsumo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColConsumo.Width = 60;
            // 
            // ColDesecho
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.ColDesecho.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColDesecho.HeaderText = "Desecho";
            this.ColDesecho.MaxInputLength = 6;
            this.ColDesecho.Name = "ColDesecho";
            this.ColDesecho.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDesecho.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDesecho.Width = 60;
            // 
            // ColUnidad
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.ColUnidad.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColUnidad.DisplayStyleForCurrentCellOnly = true;
            this.ColUnidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColUnidad.HeaderText = "Unidad";
            this.ColUnidad.Items.AddRange(new object[] {
            "KGS",
            "LTS",
            "MTS",
            "PAQ",
            "UNI"});
            this.ColUnidad.Name = "ColUnidad";
            this.ColUnidad.ReadOnly = true;
            this.ColUnidad.Sorted = true;
            this.ColUnidad.Width = 52;
            // 
            // ColUnitario
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.ColUnitario.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColUnitario.HeaderText = "C. Unitario $";
            this.ColUnitario.MaxInputLength = 11;
            this.ColUnitario.Name = "ColUnitario";
            this.ColUnitario.ReadOnly = true;
            this.ColUnitario.Width = 80;
            // 
            // ColAlicuotaIVA
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.ColAlicuotaIVA.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColAlicuotaIVA.HeaderText = "Alícuota";
            this.ColAlicuotaIVA.MaxInputLength = 5;
            this.ColAlicuotaIVA.Name = "ColAlicuotaIVA";
            this.ColAlicuotaIVA.ReadOnly = true;
            this.ColAlicuotaIVA.Width = 53;
            // 
            // ColNula
            // 
            this.ColNula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNula.HeaderText = "";
            this.ColNula.MaxInputLength = 0;
            this.ColNula.Name = "ColNula";
            this.ColNula.ReadOnly = true;
            // 
            // FormConsumoStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.cmbCentroCosto);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.btnImportarPlantilla);
            this.Controls.Add(this.btnAdherirExistencia);
            this.Controls.Add(this.cmbDeposito);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.gridDetalle);
            this.Controls.Add(this.btnBuscarFila);
            this.Controls.Add(this.btnQuitarFila);
            this.Controls.Add(this.btnAgregarFila);
            this.Name = "FormConsumoStock";
            this.Text = "Consumos de Stock";
            this.Load += new System.EventHandler(this.FormConsumoStock_Load);
            this.Controls.SetChildIndex(this.btnExcel_Registro, 0);
            this.Controls.SetChildIndex(this.btnPDF_Registro, 0);
            this.Controls.SetChildIndex(this.btnAgregarFila, 0);
            this.Controls.SetChildIndex(this.btnQuitarFila, 0);
            this.Controls.SetChildIndex(this.btnBuscarFila, 0);
            this.Controls.SetChildIndex(this.gridDetalle, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.txtID, 0);
            this.Controls.SetChildIndex(this.txtFecha, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.txtObservacion, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.cmbDeposito, 0);
            this.Controls.SetChildIndex(this.labelPublicacion, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.panelLista, 0);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.btnAdherirExistencia, 0);
            this.Controls.SetChildIndex(this.btnImportarPlantilla, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.cmbCentroCosto, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Biblioteca.Controles.MiButtonBase btnBuscarFila;
        public Biblioteca.Controles.MiButton24x24 btnQuitarFila;
        public Biblioteca.Controles.MiButton24x24 btnAgregarFila;
        public System.Windows.Forms.Label lblCatalagoTitulo7;
        public Biblioteca.Controles.MiGridEdit gridDetalle;
        private Biblioteca.Controles.MiTextBoxRead txtEstado;
        private Biblioteca.Controles.MiTextBoxRead txtFecha;
        private Biblioteca.Controles.MiTextBoxRead txtID;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBox txtObservacion;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiComboBox cmbDeposito;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiButton24x24 btnImportarPlantilla;
        private Biblioteca.Controles.MiButton24x24 btnAdherirExistencia;
        private Biblioteca.Controles.MiComboBox cmbCentroCosto;
        private Biblioteca.Controles.MiLabel miLabel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDenominacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColConsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDesecho;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAlicuotaIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNula;
    }
}
