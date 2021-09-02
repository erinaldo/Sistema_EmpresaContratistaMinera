namespace CapaPresentacion
{
    partial class FormContrato
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
                nContrato.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContrato));
            this.btnBuscarLegajo = new Biblioteca.Controles.MiButtonFind();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.txtCuit = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.btnWord_Contrato = new Biblioteca.Controles.MiButtonBase();
            this.lblCatalagoTitulo7 = new System.Windows.Forms.Label();
            this.cmbCentroCosto = new Biblioteca.Controles.MiComboBox();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.pkrFechaAlta = new Biblioteca.Controles.MiDateTimePicker();
            this.cmbModalidadContratacion = new Biblioteca.Controles.MiComboBox();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.cmbSindicato = new Biblioteca.Controles.MiComboBox();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.cmbCategoria = new Biblioteca.Controles.MiComboBox();
            this.btnCategoria = new Biblioteca.Controles.MiButtonFind();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.txtSector = new Biblioteca.Controles.MiTextBox();
            this.cmbPuesto = new Biblioteca.Controles.MiComboBoxWrite();
            this.miLabel8 = new Biblioteca.Controles.MiLabel();
            this.cmbModalidadLiquidacion = new Biblioteca.Controles.MiComboBox();
            this.miLabel9 = new Biblioteca.Controles.MiLabel();
            this.txtRemuneracion = new Biblioteca.Controles.MiTextBox();
            this.miLabel10 = new Biblioteca.Controles.MiLabel();
            this.btnObraSocial = new Biblioteca.Controles.MiButtonFind();
            this.txtObraSocial = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel11 = new Biblioteca.Controles.MiLabel();
            this.chkAfiliadoSindical = new Biblioteca.Controles.MiCheckBox();
            this.txtEstado = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel14 = new Biblioteca.Controles.MiLabel();
            this.groupRescisionContrato = new System.Windows.Forms.GroupBox();
            this.txtRescisionObservaciones = new Biblioteca.Controles.MiTextBox();
            this.lblRescisionContrato2 = new Biblioteca.Controles.MiLabel();
            this.chkRescisionContrato = new Biblioteca.Controles.MiCheckBox();
            this.lblRescisionContrato1 = new Biblioteca.Controles.MiLabel();
            this.pkrRescisionContrato = new Biblioteca.Controles.MiDateTimePicker();
            this.cmbModalidadContratacionTiempo = new Biblioteca.Controles.MiComboBox();
            this.panelLista.SuspendLayout();
            this.groupRescisionContrato.SuspendLayout();
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
            this.lblTituloLista.Text = "Lista de Contratos";
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
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(343, 36);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(54, 14);
            this.lblCatalagoTitulo3.Text = "CUIL/CUIT";
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(455, 36);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(85, 14);
            this.lblCatalagoTitulo4.Text = "Centro de Costo";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(651, 36);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(73, 14);
            this.lblCatalagoTitulo5.Text = "Fecha de Alta";
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
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(742, 36);
            this.lblCatalagoTitulo6.Size = new System.Drawing.Size(76, 14);
            this.lblCatalagoTitulo6.Text = "Fecha de Baja";
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Contratos de Trabajo";
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
            // btnWord_Contrato
            // 
            this.btnWord_Contrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWord_Contrato.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnWord_Contrato.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_word32;
            this.btnWord_Contrato.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWord_Contrato.FlatAppearance.BorderSize = 0;
            this.btnWord_Contrato.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnWord_Contrato.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnWord_Contrato.Font = new System.Drawing.Font("Arial", 9F);
            this.btnWord_Contrato.ForeColor = System.Drawing.Color.Black;
            this.btnWord_Contrato.Location = new System.Drawing.Point(386, 657);
            this.btnWord_Contrato.Name = "btnWord_Contrato";
            this.btnWord_Contrato.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnWord_Contrato.Size = new System.Drawing.Size(30, 23);
            this.btnWord_Contrato.TabIndex = 9;
            this.btnWord_Contrato.UseVisualStyleBackColor = false;
            this.btnWord_Contrato.Click += new System.EventHandler(this.btnWord_Contrato_Click);
            // 
            // lblCatalagoTitulo7
            // 
            this.lblCatalagoTitulo7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo7.AutoSize = true;
            this.lblCatalagoTitulo7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo7.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo7.Location = new System.Drawing.Point(833, 36);
            this.lblCatalagoTitulo7.Name = "lblCatalagoTitulo7";
            this.lblCatalagoTitulo7.Size = new System.Drawing.Size(40, 14);
            this.lblCatalagoTitulo7.TabIndex = 25;
            this.lblCatalagoTitulo7.Text = "Estado";
            this.lblCatalagoTitulo7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.miLabel4.Text = "Fecha de ALTA";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pkrFechaAlta
            // 
            this.pkrFechaAlta.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrFechaAlta.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrFechaAlta.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrFechaAlta.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrFechaAlta.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrFechaAlta.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrFechaAlta.CustomFormat = "dd/MM/yyyy";
            this.pkrFechaAlta.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrFechaAlta.Location = new System.Drawing.Point(160, 142);
            this.pkrFechaAlta.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrFechaAlta.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrFechaAlta.Name = "pkrFechaAlta";
            this.pkrFechaAlta.Size = new System.Drawing.Size(102, 22);
            this.pkrFechaAlta.TabIndex = 20;
            // 
            // cmbModalidadContratacion
            // 
            this.cmbModalidadContratacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbModalidadContratacion.BackColor = System.Drawing.Color.White;
            this.cmbModalidadContratacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModalidadContratacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbModalidadContratacion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbModalidadContratacion.ForeColor = System.Drawing.Color.Black;
            this.cmbModalidadContratacion.FormattingEnabled = true;
            this.cmbModalidadContratacion.Items.AddRange(new object[] {
            "PERIODO DE PRUEBA",
            "TRABAJO EVENTUAL",
            "TRABAJO PERMANENTE"});
            this.cmbModalidadContratacion.Location = new System.Drawing.Point(160, 169);
            this.cmbModalidadContratacion.Margin = new System.Windows.Forms.Padding(1);
            this.cmbModalidadContratacion.Name = "cmbModalidadContratacion";
            this.cmbModalidadContratacion.Size = new System.Drawing.Size(150, 22);
            this.cmbModalidadContratacion.Sorted = true;
            this.cmbModalidadContratacion.TabIndex = 22;
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
            this.miLabel5.Text = "Modalidad de contratación";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSindicato
            // 
            this.cmbSindicato.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbSindicato.BackColor = System.Drawing.Color.White;
            this.cmbSindicato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSindicato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSindicato.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbSindicato.ForeColor = System.Drawing.Color.Black;
            this.cmbSindicato.FormattingEnabled = true;
            this.cmbSindicato.Location = new System.Drawing.Point(160, 196);
            this.cmbSindicato.Margin = new System.Windows.Forms.Padding(1);
            this.cmbSindicato.Name = "cmbSindicato";
            this.cmbSindicato.Size = new System.Drawing.Size(190, 22);
            this.cmbSindicato.Sorted = true;
            this.cmbSindicato.TabIndex = 25;
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
            this.miLabel6.TabIndex = 24;
            this.miLabel6.Text = "Sindicato";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbCategoria.BackColor = System.Drawing.Color.White;
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategoria.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCategoria.ForeColor = System.Drawing.Color.Black;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(160, 223);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(190, 22);
            this.cmbCategoria.Sorted = true;
            this.cmbCategoria.TabIndex = 28;
            // 
            // btnCategoria
            // 
            this.btnCategoria.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCategoria.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCategoria.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_setup32;
            this.btnCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCategoria.FlatAppearance.BorderSize = 0;
            this.btnCategoria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCategoria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCategoria.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCategoria.ForeColor = System.Drawing.Color.Black;
            this.btnCategoria.Location = new System.Drawing.Point(351, 222);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCategoria.Size = new System.Drawing.Size(24, 24);
            this.btnCategoria.TabIndex = 29;
            this.btnCategoria.UseVisualStyleBackColor = false;
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(0, 227);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(160, 15);
            this.miLabel7.TabIndex = 27;
            this.miLabel7.Text = "Categoría";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSector
            // 
            this.txtSector.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSector.BackColor = System.Drawing.Color.White;
            this.txtSector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSector.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSector.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtSector.ForeColor = System.Drawing.Color.Black;
            this.txtSector.Location = new System.Drawing.Point(332, 250);
            this.txtSector.MaxLength = 20;
            this.txtSector.Name = "txtSector";
            this.txtSector.Size = new System.Drawing.Size(168, 22);
            this.txtSector.TabIndex = 32;
            // 
            // cmbPuesto
            // 
            this.cmbPuesto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbPuesto.BackColor = System.Drawing.Color.White;
            this.cmbPuesto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbPuesto.ForeColor = System.Drawing.Color.Black;
            this.cmbPuesto.FormattingEnabled = true;
            this.cmbPuesto.ItemHeight = 14;
            this.cmbPuesto.Items.AddRange(new object[] {
            "ADMINISTRATIVO",
            "ALBAÑIL",
            "AYUDANTE",
            "CERAMISTA",
            "DURLERO",
            "ELECTRICO",
            "ELECTROMECANICO",
            "ELECTROTECNICO",
            "ENCOFRADOR",
            "HIERRERO",
            "INSPECTOR",
            "MECANICO",
            "MONTAJISTA",
            "OPERADOR DE EQUIPO",
            "PAÑOL",
            "PINTOR",
            "PLOMERO",
            "PREVENCIONISTA",
            "SANITARISTA",
            "SOLDADOR",
            "SUPERVISOR"});
            this.cmbPuesto.Location = new System.Drawing.Point(160, 250);
            this.cmbPuesto.Margin = new System.Windows.Forms.Padding(1);
            this.cmbPuesto.MaxLength = 20;
            this.cmbPuesto.Name = "cmbPuesto";
            this.cmbPuesto.Size = new System.Drawing.Size(170, 22);
            this.cmbPuesto.Sorted = true;
            this.cmbPuesto.TabIndex = 31;
            // 
            // miLabel8
            // 
            this.miLabel8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel8.BackColor = System.Drawing.Color.Transparent;
            this.miLabel8.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel8.Location = new System.Drawing.Point(0, 253);
            this.miLabel8.Name = "miLabel8";
            this.miLabel8.Size = new System.Drawing.Size(160, 15);
            this.miLabel8.TabIndex = 30;
            this.miLabel8.Text = "Puesto - Sector";
            this.miLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbModalidadLiquidacion
            // 
            this.cmbModalidadLiquidacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbModalidadLiquidacion.BackColor = System.Drawing.Color.White;
            this.cmbModalidadLiquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModalidadLiquidacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbModalidadLiquidacion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbModalidadLiquidacion.ForeColor = System.Drawing.Color.Black;
            this.cmbModalidadLiquidacion.FormattingEnabled = true;
            this.cmbModalidadLiquidacion.Items.AddRange(new object[] {
            "DIARIO",
            "HORA",
            "MENSUAL"});
            this.cmbModalidadLiquidacion.Location = new System.Drawing.Point(160, 277);
            this.cmbModalidadLiquidacion.Margin = new System.Windows.Forms.Padding(1);
            this.cmbModalidadLiquidacion.Name = "cmbModalidadLiquidacion";
            this.cmbModalidadLiquidacion.Size = new System.Drawing.Size(85, 22);
            this.cmbModalidadLiquidacion.Sorted = true;
            this.cmbModalidadLiquidacion.TabIndex = 34;
            // 
            // miLabel9
            // 
            this.miLabel9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel9.BackColor = System.Drawing.Color.Transparent;
            this.miLabel9.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel9.Location = new System.Drawing.Point(0, 280);
            this.miLabel9.Name = "miLabel9";
            this.miLabel9.Size = new System.Drawing.Size(160, 15);
            this.miLabel9.TabIndex = 33;
            this.miLabel9.Text = "Modalidad de liquidación";
            this.miLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemuneracion
            // 
            this.txtRemuneracion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtRemuneracion.BackColor = System.Drawing.Color.White;
            this.txtRemuneracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemuneracion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtRemuneracion.ForeColor = System.Drawing.Color.Black;
            this.txtRemuneracion.Location = new System.Drawing.Point(160, 304);
            this.txtRemuneracion.MaxLength = 12;
            this.txtRemuneracion.Name = "txtRemuneracion";
            this.txtRemuneracion.Size = new System.Drawing.Size(85, 22);
            this.txtRemuneracion.TabIndex = 36;
            this.txtRemuneracion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRemuneracion_KeyPress);
            // 
            // miLabel10
            // 
            this.miLabel10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel10.BackColor = System.Drawing.Color.Transparent;
            this.miLabel10.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel10.Location = new System.Drawing.Point(0, 307);
            this.miLabel10.Name = "miLabel10";
            this.miLabel10.Size = new System.Drawing.Size(160, 15);
            this.miLabel10.TabIndex = 35;
            this.miLabel10.Text = "Remuneración $";
            this.miLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnObraSocial
            // 
            this.btnObraSocial.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnObraSocial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnObraSocial.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnObraSocial.BackgroundImage")));
            this.btnObraSocial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnObraSocial.FlatAppearance.BorderSize = 0;
            this.btnObraSocial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnObraSocial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnObraSocial.Font = new System.Drawing.Font("Arial", 9F);
            this.btnObraSocial.ForeColor = System.Drawing.Color.Black;
            this.btnObraSocial.Location = new System.Drawing.Point(501, 330);
            this.btnObraSocial.Name = "btnObraSocial";
            this.btnObraSocial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnObraSocial.Size = new System.Drawing.Size(24, 24);
            this.btnObraSocial.TabIndex = 39;
            this.btnObraSocial.UseVisualStyleBackColor = false;
            this.btnObraSocial.Click += new System.EventHandler(this.btnObraSocial_Click);
            // 
            // txtObraSocial
            // 
            this.txtObraSocial.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtObraSocial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtObraSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObraSocial.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtObraSocial.ForeColor = System.Drawing.Color.Black;
            this.txtObraSocial.Location = new System.Drawing.Point(160, 331);
            this.txtObraSocial.MaxLength = 75;
            this.txtObraSocial.Multiline = true;
            this.txtObraSocial.Name = "txtObraSocial";
            this.txtObraSocial.ReadOnly = true;
            this.txtObraSocial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObraSocial.Size = new System.Drawing.Size(340, 36);
            this.txtObraSocial.TabIndex = 38;
            // 
            // miLabel11
            // 
            this.miLabel11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel11.BackColor = System.Drawing.Color.Transparent;
            this.miLabel11.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel11.Location = new System.Drawing.Point(0, 334);
            this.miLabel11.Name = "miLabel11";
            this.miLabel11.Size = new System.Drawing.Size(160, 15);
            this.miLabel11.TabIndex = 37;
            this.miLabel11.Text = "Obra social";
            this.miLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAfiliadoSindical
            // 
            this.chkAfiliadoSindical.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkAfiliadoSindical.AutoSize = true;
            this.chkAfiliadoSindical.BackColor = System.Drawing.Color.Transparent;
            this.chkAfiliadoSindical.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkAfiliadoSindical.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAfiliadoSindical.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkAfiliadoSindical.Location = new System.Drawing.Point(356, 198);
            this.chkAfiliadoSindical.Name = "chkAfiliadoSindical";
            this.chkAfiliadoSindical.Size = new System.Drawing.Size(132, 19);
            this.chkAfiliadoSindical.TabIndex = 26;
            this.chkAfiliadoSindical.Text = "Afiliado al sindicato";
            this.chkAfiliadoSindical.UseVisualStyleBackColor = false;
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstado.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtEstado.ForeColor = System.Drawing.Color.Black;
            this.txtEstado.Location = new System.Drawing.Point(160, 372);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(90, 22);
            this.txtEstado.TabIndex = 41;
            // 
            // miLabel14
            // 
            this.miLabel14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel14.BackColor = System.Drawing.Color.Transparent;
            this.miLabel14.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel14.Location = new System.Drawing.Point(0, 375);
            this.miLabel14.Name = "miLabel14";
            this.miLabel14.Size = new System.Drawing.Size(160, 15);
            this.miLabel14.TabIndex = 40;
            this.miLabel14.Text = "Estado del contrato";
            this.miLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupRescisionContrato
            // 
            this.groupRescisionContrato.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupRescisionContrato.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupRescisionContrato.Controls.Add(this.txtRescisionObservaciones);
            this.groupRescisionContrato.Controls.Add(this.lblRescisionContrato2);
            this.groupRescisionContrato.Controls.Add(this.chkRescisionContrato);
            this.groupRescisionContrato.Controls.Add(this.lblRescisionContrato1);
            this.groupRescisionContrato.Controls.Add(this.pkrRescisionContrato);
            this.groupRescisionContrato.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupRescisionContrato.ForeColor = System.Drawing.Color.Gray;
            this.groupRescisionContrato.Location = new System.Drawing.Point(160, 400);
            this.groupRescisionContrato.Name = "groupRescisionContrato";
            this.groupRescisionContrato.Size = new System.Drawing.Size(840, 98);
            this.groupRescisionContrato.TabIndex = 42;
            this.groupRescisionContrato.TabStop = false;
            this.groupRescisionContrato.Text = "      Rescisión de Contrato";
            // 
            // txtRescisionObservaciones
            // 
            this.txtRescisionObservaciones.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtRescisionObservaciones.BackColor = System.Drawing.Color.White;
            this.txtRescisionObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRescisionObservaciones.Enabled = false;
            this.txtRescisionObservaciones.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtRescisionObservaciones.ForeColor = System.Drawing.Color.Black;
            this.txtRescisionObservaciones.Location = new System.Drawing.Point(208, 39);
            this.txtRescisionObservaciones.MaxLength = 250;
            this.txtRescisionObservaciones.Multiline = true;
            this.txtRescisionObservaciones.Name = "txtRescisionObservaciones";
            this.txtRescisionObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRescisionObservaciones.Size = new System.Drawing.Size(625, 52);
            this.txtRescisionObservaciones.TabIndex = 4;
            this.txtRescisionObservaciones.Visible = false;
            // 
            // lblRescisionContrato2
            // 
            this.lblRescisionContrato2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblRescisionContrato2.BackColor = System.Drawing.Color.Transparent;
            this.lblRescisionContrato2.Enabled = false;
            this.lblRescisionContrato2.Font = new System.Drawing.Font("Arial", 9F);
            this.lblRescisionContrato2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblRescisionContrato2.Location = new System.Drawing.Point(48, 42);
            this.lblRescisionContrato2.Name = "lblRescisionContrato2";
            this.lblRescisionContrato2.Size = new System.Drawing.Size(160, 15);
            this.lblRescisionContrato2.TabIndex = 3;
            this.lblRescisionContrato2.Text = "Observaciones";
            this.lblRescisionContrato2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRescisionContrato2.Visible = false;
            // 
            // chkRescisionContrato
            // 
            this.chkRescisionContrato.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkRescisionContrato.AutoSize = true;
            this.chkRescisionContrato.BackColor = System.Drawing.Color.Transparent;
            this.chkRescisionContrato.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkRescisionContrato.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRescisionContrato.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkRescisionContrato.Location = new System.Drawing.Point(10, 1);
            this.chkRescisionContrato.Name = "chkRescisionContrato";
            this.chkRescisionContrato.Size = new System.Drawing.Size(15, 14);
            this.chkRescisionContrato.TabIndex = 0;
            this.chkRescisionContrato.UseVisualStyleBackColor = false;
            this.chkRescisionContrato.CheckedChanged += new System.EventHandler(this.chkRescisionContrato_CheckedChanged);
            // 
            // lblRescisionContrato1
            // 
            this.lblRescisionContrato1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblRescisionContrato1.BackColor = System.Drawing.Color.Transparent;
            this.lblRescisionContrato1.Enabled = false;
            this.lblRescisionContrato1.Font = new System.Drawing.Font("Arial", 9F);
            this.lblRescisionContrato1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblRescisionContrato1.Location = new System.Drawing.Point(30, 15);
            this.lblRescisionContrato1.Name = "lblRescisionContrato1";
            this.lblRescisionContrato1.Size = new System.Drawing.Size(178, 15);
            this.lblRescisionContrato1.TabIndex = 1;
            this.lblRescisionContrato1.Text = "Fecha de rescisión de contrato";
            this.lblRescisionContrato1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRescisionContrato1.Visible = false;
            // 
            // pkrRescisionContrato
            // 
            this.pkrRescisionContrato.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrRescisionContrato.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrRescisionContrato.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrRescisionContrato.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrRescisionContrato.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrRescisionContrato.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrRescisionContrato.CustomFormat = "dd/MM/yyyy";
            this.pkrRescisionContrato.Enabled = false;
            this.pkrRescisionContrato.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrRescisionContrato.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrRescisionContrato.Location = new System.Drawing.Point(208, 12);
            this.pkrRescisionContrato.MaxDate = new System.DateTime(9950, 1, 1, 0, 0, 0, 0);
            this.pkrRescisionContrato.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrRescisionContrato.Name = "pkrRescisionContrato";
            this.pkrRescisionContrato.Size = new System.Drawing.Size(102, 22);
            this.pkrRescisionContrato.TabIndex = 2;
            this.pkrRescisionContrato.Visible = false;
            // 
            // cmbModalidadContratacionTiempo
            // 
            this.cmbModalidadContratacionTiempo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbModalidadContratacionTiempo.BackColor = System.Drawing.Color.White;
            this.cmbModalidadContratacionTiempo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModalidadContratacionTiempo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbModalidadContratacionTiempo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbModalidadContratacionTiempo.ForeColor = System.Drawing.Color.Black;
            this.cmbModalidadContratacionTiempo.FormattingEnabled = true;
            this.cmbModalidadContratacionTiempo.Items.AddRange(new object[] {
            "TIEMPO COMPLETO",
            "TIEMPO PARCIAL"});
            this.cmbModalidadContratacionTiempo.Location = new System.Drawing.Point(309, 169);
            this.cmbModalidadContratacionTiempo.Margin = new System.Windows.Forms.Padding(1);
            this.cmbModalidadContratacionTiempo.Name = "cmbModalidadContratacionTiempo";
            this.cmbModalidadContratacionTiempo.Size = new System.Drawing.Size(130, 22);
            this.cmbModalidadContratacionTiempo.Sorted = true;
            this.cmbModalidadContratacionTiempo.TabIndex = 23;
            // 
            // FormContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.cmbModalidadContratacionTiempo);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.miLabel14);
            this.Controls.Add(this.btnObraSocial);
            this.Controls.Add(this.txtObraSocial);
            this.Controls.Add(this.miLabel11);
            this.Controls.Add(this.txtRemuneracion);
            this.Controls.Add(this.miLabel10);
            this.Controls.Add(this.cmbModalidadLiquidacion);
            this.Controls.Add(this.miLabel9);
            this.Controls.Add(this.txtSector);
            this.Controls.Add(this.cmbPuesto);
            this.Controls.Add(this.miLabel8);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.btnCategoria);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.chkAfiliadoSindical);
            this.Controls.Add(this.cmbSindicato);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.cmbModalidadContratacion);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.pkrFechaAlta);
            this.Controls.Add(this.cmbCentroCosto);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.btnWord_Contrato);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.btnBuscarLegajo);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtDenominacion);
            this.Controls.Add(this.groupRescisionContrato);
            this.Name = "FormContrato";
            this.Text = "Contratos de Trabajo";
            this.Load += new System.EventHandler(this.FormContrato_Load);
            this.Controls.SetChildIndex(this.groupRescisionContrato, 0);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.btnBuscarLegajo, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.txtCuit, 0);
            this.Controls.SetChildIndex(this.btnWord_Contrato, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.cmbCentroCosto, 0);
            this.Controls.SetChildIndex(this.pkrFechaAlta, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.cmbModalidadContratacion, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.cmbSindicato, 0);
            this.Controls.SetChildIndex(this.chkAfiliadoSindical, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.btnCategoria, 0);
            this.Controls.SetChildIndex(this.cmbCategoria, 0);
            this.Controls.SetChildIndex(this.miLabel8, 0);
            this.Controls.SetChildIndex(this.cmbPuesto, 0);
            this.Controls.SetChildIndex(this.txtSector, 0);
            this.Controls.SetChildIndex(this.miLabel9, 0);
            this.Controls.SetChildIndex(this.cmbModalidadLiquidacion, 0);
            this.Controls.SetChildIndex(this.miLabel10, 0);
            this.Controls.SetChildIndex(this.txtRemuneracion, 0);
            this.Controls.SetChildIndex(this.miLabel11, 0);
            this.Controls.SetChildIndex(this.txtObraSocial, 0);
            this.Controls.SetChildIndex(this.btnObraSocial, 0);
            this.Controls.SetChildIndex(this.miLabel14, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.cmbModalidadContratacionTiempo, 0);
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
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            this.groupRescisionContrato.ResumeLayout(false);
            this.groupRescisionContrato.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Biblioteca.Controles.MiButtonFind btnBuscarLegajo;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBox txtDenominacion;
        private Biblioteca.Controles.MiTextBoxRead txtCuit;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiButtonBase btnWord_Contrato;
        public System.Windows.Forms.Label lblCatalagoTitulo7;
        private Biblioteca.Controles.MiComboBox cmbCentroCosto;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiDateTimePicker pkrFechaAlta;
        private Biblioteca.Controles.MiComboBox cmbModalidadContratacion;
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiComboBox cmbSindicato;
        private Biblioteca.Controles.MiLabel miLabel6;
        private Biblioteca.Controles.MiComboBox cmbCategoria;
        private Biblioteca.Controles.MiButtonFind btnCategoria;
        private Biblioteca.Controles.MiLabel miLabel7;
        private Biblioteca.Controles.MiTextBox txtSector;
        private Biblioteca.Controles.MiComboBoxWrite cmbPuesto;
        private Biblioteca.Controles.MiLabel miLabel8;
        private Biblioteca.Controles.MiComboBox cmbModalidadLiquidacion;
        private Biblioteca.Controles.MiLabel miLabel9;
        private Biblioteca.Controles.MiTextBox txtRemuneracion;
        private Biblioteca.Controles.MiLabel miLabel10;
        private Biblioteca.Controles.MiButtonFind btnObraSocial;
        private Biblioteca.Controles.MiTextBoxRead txtObraSocial;
        private Biblioteca.Controles.MiLabel miLabel11;
        private Biblioteca.Controles.MiCheckBox chkAfiliadoSindical;
        private Biblioteca.Controles.MiTextBoxRead txtEstado;
        private Biblioteca.Controles.MiLabel miLabel14;
        private System.Windows.Forms.GroupBox groupRescisionContrato;
        private Biblioteca.Controles.MiTextBox txtRescisionObservaciones;
        private Biblioteca.Controles.MiLabel lblRescisionContrato2;
        private Biblioteca.Controles.MiCheckBox chkRescisionContrato;
        private Biblioteca.Controles.MiLabel lblRescisionContrato1;
        private Biblioteca.Controles.MiDateTimePicker pkrRescisionContrato;
        private Biblioteca.Controles.MiComboBox cmbModalidadContratacionTiempo;
    }
}