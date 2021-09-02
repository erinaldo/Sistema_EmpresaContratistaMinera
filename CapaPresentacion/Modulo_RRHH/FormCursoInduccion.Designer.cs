namespace CapaPresentacion
{
    partial class FormCursoInduccion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                nLegajo.Dispose();
                nLegajoLaboral.Dispose();
                nCursoInduccion.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCursoInduccion));
            this.btnBuscarLegajo = new Biblioteca.Controles.MiButtonFind();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.txtCuit = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.cmbCentroCosto = new Biblioteca.Controles.MiComboBox();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.pkrFechaEmision = new Biblioteca.Controles.MiDateTimePicker();
            this.cmbEvaluacion = new Biblioteca.Controles.MiComboBox();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.txtObservacion = new Biblioteca.Controles.MiTextBox();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.txtEstado = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.lblCatalagoTitulo7 = new System.Windows.Forms.Label();
            this.panelLista.SuspendLayout();
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
            this.btnExcel_Registro.FlatAppearance.BorderSize = 0;
            this.btnExcel_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // btnPDF_Registro
            // 
            this.btnPDF_Registro.FlatAppearance.BorderSize = 0;
            this.btnPDF_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // lblTituloLista
            // 
            this.lblTituloLista.Size = new System.Drawing.Size(316, 23);
            this.lblTituloLista.Text = "Lista de Cursos de Inducción";
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
            this.lblCatalagoTitulo1.Size = new System.Drawing.Size(16, 14);
            this.lblCatalagoTitulo1.Text = "ID";
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(392, 36);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(54, 14);
            this.lblCatalagoTitulo3.Text = "CUIL/CUIT";
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(504, 36);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(54, 14);
            this.lblCatalagoTitulo4.Text = "F. Emisión";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(595, 36);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(60, 14);
            this.lblCatalagoTitulo5.Text = "Fecha Vto.";
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
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(686, 36);
            this.lblCatalagoTitulo6.Size = new System.Drawing.Size(59, 14);
            this.lblCatalagoTitulo6.Text = "Evaluación";
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Cursos de Inducción";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 10;
            // 
            // btnBuscarLegajo
            // 
            this.btnBuscarLegajo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBuscarLegajo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarLegajo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarLegajo.BackgroundImage")));
            this.btnBuscarLegajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarLegajo.FlatAppearance.BorderSize = 0;
            this.btnBuscarLegajo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBuscarLegajo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuscarLegajo.Font = new System.Drawing.Font("Arial", 9F);
            this.btnBuscarLegajo.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarLegajo.Location = new System.Drawing.Point(476, 60);
            this.btnBuscarLegajo.Name = "btnBuscarLegajo";
            this.btnBuscarLegajo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBuscarLegajo.Size = new System.Drawing.Size(24, 24);
            this.btnBuscarLegajo.TabIndex = 14;
            this.btnBuscarLegajo.UseVisualStyleBackColor = false;
            this.btnBuscarLegajo.Click += new System.EventHandler(this.btnBuscarLegajo_Click);
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
            this.miLabel1.TabIndex = 12;
            this.miLabel1.Text = "Denominación";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenominacion
            // 
            this.txtDenominacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDenominacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtDenominacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDenominacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDenominacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtDenominacion.ForeColor = System.Drawing.Color.Black;
            this.txtDenominacion.Location = new System.Drawing.Point(160, 61);
            this.txtDenominacion.MaxLength = 35;
            this.txtDenominacion.Name = "txtDenominacion";
            this.txtDenominacion.ReadOnly = true;
            this.txtDenominacion.Size = new System.Drawing.Size(315, 22);
            this.txtDenominacion.TabIndex = 13;
            // 
            // txtCuit
            // 
            this.txtCuit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtCuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuit.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCuit.ForeColor = System.Drawing.Color.Black;
            this.txtCuit.Location = new System.Drawing.Point(160, 88);
            this.txtCuit.MaxLength = 15;
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.ReadOnly = true;
            this.txtCuit.Size = new System.Drawing.Size(100, 22);
            this.txtCuit.TabIndex = 16;
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
            this.miLabel2.Text = "CUIL/CUIT";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.miLabel4.Text = "Fecha de emisión";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pkrFechaEmision
            // 
            this.pkrFechaEmision.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrFechaEmision.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrFechaEmision.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrFechaEmision.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrFechaEmision.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrFechaEmision.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrFechaEmision.CustomFormat = "dd/MM/yyyy";
            this.pkrFechaEmision.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrFechaEmision.Location = new System.Drawing.Point(160, 142);
            this.pkrFechaEmision.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrFechaEmision.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrFechaEmision.Name = "pkrFechaEmision";
            this.pkrFechaEmision.Size = new System.Drawing.Size(102, 22);
            this.pkrFechaEmision.TabIndex = 20;
            // 
            // cmbEvaluacion
            // 
            this.cmbEvaluacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbEvaluacion.BackColor = System.Drawing.Color.White;
            this.cmbEvaluacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvaluacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEvaluacion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbEvaluacion.ForeColor = System.Drawing.Color.Black;
            this.cmbEvaluacion.FormattingEnabled = true;
            this.cmbEvaluacion.Items.AddRange(new object[] {
            "APROBADO",
            "REPROBADO"});
            this.cmbEvaluacion.Location = new System.Drawing.Point(160, 169);
            this.cmbEvaluacion.Margin = new System.Windows.Forms.Padding(1);
            this.cmbEvaluacion.Name = "cmbEvaluacion";
            this.cmbEvaluacion.Size = new System.Drawing.Size(92, 22);
            this.cmbEvaluacion.Sorted = true;
            this.cmbEvaluacion.TabIndex = 22;
            // 
            // miLabel5
            // 
            this.miLabel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel5.BackColor = System.Drawing.Color.Transparent;
            this.miLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel5.Location = new System.Drawing.Point(0, 172);
            this.miLabel5.Name = "miLabel5";
            this.miLabel5.Size = new System.Drawing.Size(160, 15);
            this.miLabel5.TabIndex = 21;
            this.miLabel5.Text = "Evaluación";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtObservacion.BackColor = System.Drawing.Color.White;
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtObservacion.ForeColor = System.Drawing.Color.Black;
            this.txtObservacion.Location = new System.Drawing.Point(160, 196);
            this.txtObservacion.MaxLength = 250;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(340, 52);
            this.txtObservacion.TabIndex = 24;
            // 
            // miLabel6
            // 
            this.miLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel6.BackColor = System.Drawing.Color.Transparent;
            this.miLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel6.Location = new System.Drawing.Point(0, 199);
            this.miLabel6.Name = "miLabel6";
            this.miLabel6.Size = new System.Drawing.Size(160, 15);
            this.miLabel6.TabIndex = 23;
            this.miLabel6.Text = "Observaciones";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstado.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtEstado.ForeColor = System.Drawing.Color.Black;
            this.txtEstado.Location = new System.Drawing.Point(160, 253);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(85, 22);
            this.txtEstado.TabIndex = 26;
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(0, 256);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(160, 15);
            this.miLabel7.TabIndex = 25;
            this.miLabel7.Text = "Estado";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCatalagoTitulo7
            // 
            this.lblCatalagoTitulo7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo7.AutoSize = true;
            this.lblCatalagoTitulo7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo7.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo7.Location = new System.Drawing.Point(770, 36);
            this.lblCatalagoTitulo7.Name = "lblCatalagoTitulo7";
            this.lblCatalagoTitulo7.Size = new System.Drawing.Size(40, 14);
            this.lblCatalagoTitulo7.TabIndex = 23;
            this.lblCatalagoTitulo7.Text = "Estado";
            this.lblCatalagoTitulo7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormCursoInduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.cmbEvaluacion);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.pkrFechaEmision);
            this.Controls.Add(this.cmbCentroCosto);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.btnBuscarLegajo);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtDenominacion);
            this.Name = "FormCursoInduccion";
            this.Text = "Cursos de Inducción";
            this.Load += new System.EventHandler(this.FormCursoInduccion_Load);
            this.Controls.SetChildIndex(this.labelPublicacion, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.btnExcel_Registro, 0);
            this.Controls.SetChildIndex(this.btnPDF_Registro, 0);
            this.Controls.SetChildIndex(this.panelLista, 0);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.btnBuscarLegajo, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.txtCuit, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.cmbCentroCosto, 0);
            this.Controls.SetChildIndex(this.pkrFechaEmision, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.cmbEvaluacion, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.txtObservacion, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Biblioteca.Controles.MiButtonFind btnBuscarLegajo;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBox txtDenominacion;
        private Biblioteca.Controles.MiTextBoxRead txtCuit;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiComboBox cmbCentroCosto;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiDateTimePicker pkrFechaEmision;
        private Biblioteca.Controles.MiComboBox cmbEvaluacion;
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiTextBox txtObservacion;
        private Biblioteca.Controles.MiLabel miLabel6;
        private Biblioteca.Controles.MiTextBoxRead txtEstado;
        private Biblioteca.Controles.MiLabel miLabel7;
        public System.Windows.Forms.Label lblCatalagoTitulo7;
    }
}