namespace CapaPresentacion
{
    partial class FormAsientoManual
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
                nAsientoManual.Dispose();
                nAsientoManualDetalle.Dispose();
                nAsientoContable.Dispose();
                nCuentaContable.Dispose();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtEstado = new Biblioteca.Controles.MiTextBoxRead();
            this.pkrCbteFecha = new Biblioteca.Controles.MiDateTimePicker();
            this.txtCbteNro = new Biblioteca.Controles.MiTextBoxRead();
            this.txtCbteTPV = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.btnQuitarFila = new Biblioteca.Controles.MiButton24x24();
            this.btnAgregarFila = new Biblioteca.Controles.MiButton24x24();
            this.gridDetalle = new Biblioteca.Controles.MiGridEdit();
            this.cmbCentroCosto = new Biblioteca.Controles.MiComboBox();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.lblTotalDebe = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.lblTotalHaber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblCatalagoTitulo7 = new System.Windows.Forms.Label();
            this.ColCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCuentaContable = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColConciliacion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColModificacionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.btnExcel_Registro.TabIndex = 8;
            this.btnExcel_Registro.Visible = false;
            // 
            // btnPDF_Registro
            // 
            this.btnPDF_Registro.Enabled = false;
            this.btnPDF_Registro.FlatAppearance.BorderSize = 0;
            this.btnPDF_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Registro.TabIndex = 9;
            this.btnPDF_Registro.Visible = false;
            // 
            // lblTituloLista
            // 
            this.lblTituloLista.Text = "Lista de Asientos Manuales";
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
            this.lblCatalagoTitulo1.Size = new System.Drawing.Size(85, 14);
            this.lblCatalagoTitulo1.Text = "N° Comprobante";
            // 
            // lblCatalagoTitulo2
            // 
            this.lblCatalagoTitulo2.Location = new System.Drawing.Point(119, 36);
            this.lblCatalagoTitulo2.Size = new System.Drawing.Size(37, 14);
            this.lblCatalagoTitulo2.Text = "Fecha";
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(210, 36);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(40, 14);
            this.lblCatalagoTitulo3.Text = "Estado";
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(280, 36);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(74, 14);
            this.lblCatalagoTitulo4.Text = "Denominación";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(546, 36);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(85, 14);
            this.lblCatalagoTitulo5.Text = "Centro de Costo";
            // 
            // panelLista
            // 
            this.panelLista.Controls.Add(this.lblCatalagoTitulo7);
            this.panelLista.TabIndex = 11;
            this.panelLista.Controls.SetChildIndex(this.lstCatalogo, 0);
            this.panelLista.Controls.SetChildIndex(this.pkrFiltroListaDesde, 0);
            this.panelLista.Controls.SetChildIndex(this.pkrFiltroListaHasta, 0);
            this.panelLista.Controls.SetChildIndex(this.lblTituloLista, 0);
            this.panelLista.Controls.SetChildIndex(this.cmbFiltroLista1, 0);
            this.panelLista.Controls.SetChildIndex(this.cmbFiltroLista2, 0);
            this.panelLista.Controls.SetChildIndex(this.txtFiltroLista, 0);
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
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(741, 36);
            this.lblCatalagoTitulo6.Size = new System.Drawing.Size(52, 14);
            this.lblCatalagoTitulo6.Text = "T. Debe $";
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Asientos Manuales";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 10;
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstado.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtEstado.ForeColor = System.Drawing.Color.Black;
            this.txtEstado.Location = new System.Drawing.Point(358, 61);
            this.txtEstado.MaxLength = 10;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(68, 22);
            this.txtEstado.TabIndex = 15;
            // 
            // pkrCbteFecha
            // 
            this.pkrCbteFecha.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrCbteFecha.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrCbteFecha.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrCbteFecha.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrCbteFecha.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrCbteFecha.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrCbteFecha.CustomFormat = "dd/MM/yyyy";
            this.pkrCbteFecha.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrCbteFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrCbteFecha.Location = new System.Drawing.Point(257, 61);
            this.pkrCbteFecha.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrCbteFecha.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrCbteFecha.Name = "pkrCbteFecha";
            this.pkrCbteFecha.Size = new System.Drawing.Size(102, 22);
            this.pkrCbteFecha.TabIndex = 14;
            // 
            // txtCbteNro
            // 
            this.txtCbteNro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCbteNro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtCbteNro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCbteNro.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCbteNro.ForeColor = System.Drawing.Color.Black;
            this.txtCbteNro.Location = new System.Drawing.Point(198, 61);
            this.txtCbteNro.MaxLength = 8;
            this.txtCbteNro.Name = "txtCbteNro";
            this.txtCbteNro.ReadOnly = true;
            this.txtCbteNro.Size = new System.Drawing.Size(60, 22);
            this.txtCbteNro.TabIndex = 13;
            // 
            // txtCbteTPV
            // 
            this.txtCbteTPV.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCbteTPV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtCbteTPV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCbteTPV.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCbteTPV.ForeColor = System.Drawing.Color.Black;
            this.txtCbteTPV.Location = new System.Drawing.Point(160, 61);
            this.txtCbteTPV.MaxLength = 5;
            this.txtCbteTPV.Name = "txtCbteTPV";
            this.txtCbteTPV.ReadOnly = true;
            this.txtCbteTPV.Size = new System.Drawing.Size(39, 22);
            this.txtCbteTPV.TabIndex = 12;
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
            // miLabel2
            // 
            this.miLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel2.BackColor = System.Drawing.Color.Transparent;
            this.miLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel2.Location = new System.Drawing.Point(0, 90);
            this.miLabel2.Name = "miLabel2";
            this.miLabel2.Size = new System.Drawing.Size(160, 18);
            this.miLabel2.TabIndex = 16;
            this.miLabel2.Text = "Denominación";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenominacion
            // 
            this.txtDenominacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDenominacion.BackColor = System.Drawing.Color.White;
            this.txtDenominacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDenominacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDenominacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtDenominacion.ForeColor = System.Drawing.Color.Black;
            this.txtDenominacion.Location = new System.Drawing.Point(160, 88);
            this.txtDenominacion.MaxLength = 35;
            this.txtDenominacion.Name = "txtDenominacion";
            this.txtDenominacion.Size = new System.Drawing.Size(325, 22);
            this.txtDenominacion.TabIndex = 17;
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
            this.btnQuitarFila.Location = new System.Drawing.Point(184, 306);
            this.btnQuitarFila.Name = "btnQuitarFila";
            this.btnQuitarFila.Size = new System.Drawing.Size(24, 24);
            this.btnQuitarFila.TabIndex = 41;
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
            this.btnAgregarFila.Location = new System.Drawing.Point(160, 306);
            this.btnAgregarFila.Name = "btnAgregarFila";
            this.btnAgregarFila.Size = new System.Drawing.Size(24, 24);
            this.btnAgregarFila.TabIndex = 40;
            this.btnAgregarFila.UseVisualStyleBackColor = false;
            this.btnAgregarFila.Click += new System.EventHandler(this.btnAgregarFila_Click);
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
            this.gridDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
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
            this.ColCodigo,
            this.ColCuentaContable,
            this.ColDebe,
            this.ColHaber,
            this.ColConciliacion,
            this.ColModificacionID,
            this.ColNula});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDetalle.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridDetalle.EnableHeadersVisualStyles = false;
            this.gridDetalle.GridColor = System.Drawing.Color.DarkGray;
            this.gridDetalle.Location = new System.Drawing.Point(160, 142);
            this.gridDetalle.MultiSelect = false;
            this.gridDetalle.Name = "gridDetalle";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gridDetalle.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.gridDetalle.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gridDetalle.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetalle.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridDetalle.Size = new System.Drawing.Size(545, 163);
            this.gridDetalle.StandardTab = true;
            this.gridDetalle.TabIndex = 39;
            this.gridDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetalle_CellEndEdit);
            this.gridDetalle.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetalle_CellEnter);
            this.gridDetalle.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridDetalle_DataError);
            this.gridDetalle.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridDetalle_EditingControlShowing);
            this.gridDetalle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridDetalle_KeyDown);
            this.gridDetalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridDetalle_KeyPress);
            this.gridDetalle.Leave += new System.EventHandler(this.gridDetalle_Leave);
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
            this.cmbCentroCosto.TabIndex = 43;
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
            this.miLabel3.TabIndex = 42;
            this.miLabel3.Text = "Centro de costo";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalDebe
            // 
            this.lblTotalDebe.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalDebe.BackColor = System.Drawing.Color.White;
            this.lblTotalDebe.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalDebe.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDebe.Location = new System.Drawing.Point(510, 328);
            this.lblTotalDebe.Name = "lblTotalDebe";
            this.lblTotalDebe.Size = new System.Drawing.Size(92, 18);
            this.lblTotalDebe.TabIndex = 303;
            this.lblTotalDebe.Tag = "";
            this.lblTotalDebe.Text = "0.00";
            this.lblTotalDebe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(510, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 302;
            this.label1.Text = "Total Debe";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox14
            // 
            this.pictureBox14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox14.BackColor = System.Drawing.Color.White;
            this.pictureBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox14.Location = new System.Drawing.Point(507, 307);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(98, 16);
            this.pictureBox14.TabIndex = 304;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox15.BackColor = System.Drawing.Color.White;
            this.pictureBox15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox15.Location = new System.Drawing.Point(507, 322);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(98, 30);
            this.pictureBox15.TabIndex = 305;
            this.pictureBox15.TabStop = false;
            // 
            // lblTotalHaber
            // 
            this.lblTotalHaber.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalHaber.BackColor = System.Drawing.Color.White;
            this.lblTotalHaber.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalHaber.ForeColor = System.Drawing.Color.Black;
            this.lblTotalHaber.Location = new System.Drawing.Point(610, 328);
            this.lblTotalHaber.Name = "lblTotalHaber";
            this.lblTotalHaber.Size = new System.Drawing.Size(92, 18);
            this.lblTotalHaber.TabIndex = 307;
            this.lblTotalHaber.Tag = "";
            this.lblTotalHaber.Text = "0.00";
            this.lblTotalHaber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(610, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 306;
            this.label2.Text = "Total Haber";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(607, 307);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 16);
            this.pictureBox1.TabIndex = 308;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(607, 322);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(98, 30);
            this.pictureBox2.TabIndex = 309;
            this.pictureBox2.TabStop = false;
            // 
            // lblCatalagoTitulo7
            // 
            this.lblCatalagoTitulo7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo7.AutoSize = true;
            this.lblCatalagoTitulo7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo7.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo7.Location = new System.Drawing.Point(840, 36);
            this.lblCatalagoTitulo7.Name = "lblCatalagoTitulo7";
            this.lblCatalagoTitulo7.Size = new System.Drawing.Size(56, 14);
            this.lblCatalagoTitulo7.TabIndex = 318;
            this.lblCatalagoTitulo7.Text = "T. Haber $";
            this.lblCatalagoTitulo7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ColCodigo
            // 
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.ColCodigo.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColCodigo.Frozen = true;
            this.ColCodigo.HeaderText = "Código";
            this.ColCodigo.MaxInputLength = 6;
            this.ColCodigo.Name = "ColCodigo";
            this.ColCodigo.ReadOnly = true;
            this.ColCodigo.Width = 50;
            // 
            // ColCuentaContable
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.ColCuentaContable.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColCuentaContable.DisplayStyleForCurrentCellOnly = true;
            this.ColCuentaContable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColCuentaContable.HeaderText = "Cuenta Contable";
            this.ColCuentaContable.Name = "ColCuentaContable";
            this.ColCuentaContable.Sorted = true;
            this.ColCuentaContable.Width = 215;
            // 
            // ColDebe
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.ColDebe.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColDebe.HeaderText = "Debe $";
            this.ColDebe.MaxInputLength = 11;
            this.ColDebe.Name = "ColDebe";
            this.ColDebe.Width = 80;
            // 
            // ColHaber
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.ColHaber.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColHaber.HeaderText = "Haber $";
            this.ColHaber.MaxInputLength = 12;
            this.ColHaber.Name = "ColHaber";
            this.ColHaber.Width = 80;
            // 
            // ColConciliacion
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.ColConciliacion.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColConciliacion.DisplayStyleForCurrentCellOnly = true;
            this.ColConciliacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColConciliacion.HeaderText = "Conciliación";
            this.ColConciliacion.Items.AddRange(new object[] {
            "NO-APLICA",
            "S/CONCILIAR"});
            this.ColConciliacion.Name = "ColConciliacion";
            this.ColConciliacion.Sorted = true;
            this.ColConciliacion.Width = 102;
            // 
            // ColModificacionID
            // 
            this.ColModificacionID.HeaderText = "ModificacionID";
            this.ColModificacionID.MaxInputLength = 10;
            this.ColModificacionID.Name = "ColModificacionID";
            this.ColModificacionID.ReadOnly = true;
            this.ColModificacionID.Visible = false;
            // 
            // ColNula
            // 
            this.ColNula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNula.HeaderText = "";
            this.ColNula.Name = "ColNula";
            this.ColNula.ReadOnly = true;
            // 
            // FormAsientoManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.lblTotalHaber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblTotalDebe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox14);
            this.Controls.Add(this.pictureBox15);
            this.Controls.Add(this.cmbCentroCosto);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.btnQuitarFila);
            this.Controls.Add(this.btnAgregarFila);
            this.Controls.Add(this.gridDetalle);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.txtDenominacion);
            this.Controls.Add(this.pkrCbteFecha);
            this.Controls.Add(this.txtCbteNro);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtCbteTPV);
            this.Name = "FormAsientoManual";
            this.Text = "Asientos Manuales";
            this.Load += new System.EventHandler(this.FormAsientoManual_Load);
            this.Controls.SetChildIndex(this.txtCbteTPV, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.txtCbteNro, 0);
            this.Controls.SetChildIndex(this.pkrCbteFecha, 0);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.gridDetalle, 0);
            this.Controls.SetChildIndex(this.btnAgregarFila, 0);
            this.Controls.SetChildIndex(this.btnQuitarFila, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.cmbCentroCosto, 0);
            this.Controls.SetChildIndex(this.pictureBox15, 0);
            this.Controls.SetChildIndex(this.pictureBox14, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblTotalDebe, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblTotalHaber, 0);
            this.Controls.SetChildIndex(this.btnExcel_Registro, 0);
            this.Controls.SetChildIndex(this.btnPDF_Registro, 0);
            this.Controls.SetChildIndex(this.labelPublicacion, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.panelLista, 0);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Biblioteca.Controles.MiTextBoxRead txtEstado;
        private Biblioteca.Controles.MiDateTimePicker pkrCbteFecha;
        private Biblioteca.Controles.MiTextBoxRead txtCbteNro;
        private Biblioteca.Controles.MiTextBoxRead txtCbteTPV;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiTextBox txtDenominacion;
        public Biblioteca.Controles.MiButton24x24 btnQuitarFila;
        public Biblioteca.Controles.MiButton24x24 btnAgregarFila;
        public Biblioteca.Controles.MiGridEdit gridDetalle;
        private Biblioteca.Controles.MiComboBox cmbCentroCosto;
        private Biblioteca.Controles.MiLabel miLabel3;
        public System.Windows.Forms.Label lblTotalDebe;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox pictureBox14;
        public System.Windows.Forms.PictureBox pictureBox15;
        public System.Windows.Forms.Label lblTotalHaber;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Label lblCatalagoTitulo7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodigo;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColCuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHaber;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColConciliacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColModificacionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNula;
    }
}
