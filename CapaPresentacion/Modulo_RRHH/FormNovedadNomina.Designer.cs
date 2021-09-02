namespace CapaPresentacion
{
    partial class FormNovedadNomina
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
                nNovedadNomina.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNovedadNomina));
            this.btnWord_NovedadNomina = new Biblioteca.Controles.MiButtonBase();
            this.txtID = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtPeriodo = new Biblioteca.Controles.MiNumericUpDown();
            this.cmbPeriodo = new Biblioteca.Controles.MiComboBox();
            this.pkrFechaEmision = new Biblioteca.Controles.MiDateTimePicker();
            this.btnBuscarLegajo = new Biblioteca.Controles.MiButtonFind();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.txtCuit = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.txtCentroCosto = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.btnNovedadTipo = new Biblioteca.Controles.MiButtonFind();
            this.cmbNovedadTipo = new Biblioteca.Controles.MiComboBox();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.groupUnidadExpresion = new System.Windows.Forms.GroupBox();
            this.chkMonto = new Biblioteca.Controles.MiCheckBox();
            this.txtUnidadDias = new Biblioteca.Controles.MiMaskedTextBox();
            this.chkCantidadDias = new Biblioteca.Controles.MiCheckBox();
            this.txtUnidadHoras = new Biblioteca.Controles.MiMaskedTextBox();
            this.chkCantidadHoras = new Biblioteca.Controles.MiCheckBox();
            this.pkrFechaFinalizacion = new Biblioteca.Controles.MiDateTimePicker();
            this.chkFechaFinalizacion = new Biblioteca.Controles.MiCheckBox();
            this.pkrFechaInicializacion = new Biblioteca.Controles.MiDateTimePicker();
            this.chkFechaInicializacion = new Biblioteca.Controles.MiCheckBox();
            this.txtUnidadMonto = new Biblioteca.Controles.MiTextBox();
            this.txtObservacion = new Biblioteca.Controles.MiTextBox();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.txtEstado = new Biblioteca.Controles.MiTextBoxRead();
            this.txtLiquidacionMes = new Biblioteca.Controles.MiNumericUpDown();
            this.txtLiquidacionAnio = new Biblioteca.Controles.MiNumericUpDown();
            this.btnLiquidar = new Biblioteca.Controles.MiButtonBase();
            this.panelLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).BeginInit();
            this.groupUnidadExpresion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLiquidacionMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLiquidacionAnio)).BeginInit();
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
            this.lblTituloLista.Text = "Lista de Novedades de Nómina";
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
            this.lblCatalagoTitulo1.Size = new System.Drawing.Size(64, 14);
            this.lblCatalagoTitulo1.Text = "N° Novedad";
            // 
            // lblCatalagoTitulo2
            // 
            this.lblCatalagoTitulo2.Size = new System.Drawing.Size(54, 14);
            this.lblCatalagoTitulo2.Text = "F. Emisión";
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(168, 36);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(43, 14);
            this.lblCatalagoTitulo3.Text = "Periodo";
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(238, 36);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(40, 14);
            this.lblCatalagoTitulo4.Text = "Estado";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(329, 36);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(88, 14);
            this.lblCatalagoTitulo5.Text = "Tipo de Novedad";
            // 
            // panelLista
            // 
            this.panelLista.TabIndex = 14;
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(595, 36);
            this.lblCatalagoTitulo6.Size = new System.Drawing.Size(134, 14);
            this.lblCatalagoTitulo6.Text = " Denominación - CUIL/CUIT";
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Novedades de Nómina";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 13;
            // 
            // btnWord_NovedadNomina
            // 
            this.btnWord_NovedadNomina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWord_NovedadNomina.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnWord_NovedadNomina.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_word32;
            this.btnWord_NovedadNomina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWord_NovedadNomina.FlatAppearance.BorderSize = 0;
            this.btnWord_NovedadNomina.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnWord_NovedadNomina.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnWord_NovedadNomina.Font = new System.Drawing.Font("Arial", 9F);
            this.btnWord_NovedadNomina.ForeColor = System.Drawing.Color.Black;
            this.btnWord_NovedadNomina.Location = new System.Drawing.Point(386, 657);
            this.btnWord_NovedadNomina.Name = "btnWord_NovedadNomina";
            this.btnWord_NovedadNomina.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnWord_NovedadNomina.Size = new System.Drawing.Size(30, 23);
            this.btnWord_NovedadNomina.TabIndex = 9;
            this.btnWord_NovedadNomina.UseVisualStyleBackColor = false;
            this.btnWord_NovedadNomina.Click += new System.EventHandler(this.btnWord_NovedadNomina_Click);
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
            this.txtID.Size = new System.Drawing.Size(68, 22);
            this.txtID.TabIndex = 16;
            // 
            // miLabel1
            // 
            this.miLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel1.BackColor = System.Drawing.Color.Transparent;
            this.miLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel1.Location = new System.Drawing.Point(0, 63);
            this.miLabel1.Name = "miLabel1";
            this.miLabel1.Size = new System.Drawing.Size(160, 15);
            this.miLabel1.TabIndex = 15;
            this.miLabel1.Text = "Comprobante";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPeriodo.BackColor = System.Drawing.Color.White;
            this.txtPeriodo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtPeriodo.ForeColor = System.Drawing.Color.Black;
            this.txtPeriodo.Location = new System.Drawing.Point(365, 61);
            this.txtPeriodo.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.txtPeriodo.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(50, 22);
            this.txtPeriodo.TabIndex = 19;
            this.txtPeriodo.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbPeriodo.BackColor = System.Drawing.Color.White;
            this.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPeriodo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbPeriodo.ForeColor = System.Drawing.Color.Black;
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbPeriodo.Location = new System.Drawing.Point(328, 61);
            this.cmbPeriodo.Margin = new System.Windows.Forms.Padding(1);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(38, 22);
            this.cmbPeriodo.Sorted = true;
            this.cmbPeriodo.TabIndex = 18;
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
            this.pkrFechaEmision.Location = new System.Drawing.Point(227, 61);
            this.pkrFechaEmision.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrFechaEmision.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrFechaEmision.Name = "pkrFechaEmision";
            this.pkrFechaEmision.Size = new System.Drawing.Size(102, 22);
            this.pkrFechaEmision.TabIndex = 17;
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
            this.btnBuscarLegajo.Location = new System.Drawing.Point(476, 87);
            this.btnBuscarLegajo.Name = "btnBuscarLegajo";
            this.btnBuscarLegajo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBuscarLegajo.Size = new System.Drawing.Size(24, 24);
            this.btnBuscarLegajo.TabIndex = 23;
            this.btnBuscarLegajo.UseVisualStyleBackColor = false;
            this.btnBuscarLegajo.Click += new System.EventHandler(this.btnBuscarLegajo_Click);
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
            this.miLabel2.TabIndex = 21;
            this.miLabel2.Text = "Denominación";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenominacion
            // 
            this.txtDenominacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDenominacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtDenominacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDenominacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDenominacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtDenominacion.ForeColor = System.Drawing.Color.Black;
            this.txtDenominacion.Location = new System.Drawing.Point(160, 88);
            this.txtDenominacion.MaxLength = 35;
            this.txtDenominacion.Name = "txtDenominacion";
            this.txtDenominacion.ReadOnly = true;
            this.txtDenominacion.Size = new System.Drawing.Size(315, 22);
            this.txtDenominacion.TabIndex = 22;
            // 
            // txtCuit
            // 
            this.txtCuit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtCuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuit.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCuit.ForeColor = System.Drawing.Color.Black;
            this.txtCuit.Location = new System.Drawing.Point(160, 115);
            this.txtCuit.MaxLength = 15;
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.ReadOnly = true;
            this.txtCuit.Size = new System.Drawing.Size(100, 22);
            this.txtCuit.TabIndex = 25;
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
            this.miLabel3.TabIndex = 24;
            this.miLabel3.Text = "CUIL/CUIT";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCentroCosto
            // 
            this.txtCentroCosto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCentroCosto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtCentroCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCentroCosto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCentroCosto.ForeColor = System.Drawing.Color.Black;
            this.txtCentroCosto.Location = new System.Drawing.Point(160, 142);
            this.txtCentroCosto.MaxLength = 25;
            this.txtCentroCosto.Name = "txtCentroCosto";
            this.txtCentroCosto.ReadOnly = true;
            this.txtCentroCosto.Size = new System.Drawing.Size(210, 22);
            this.txtCentroCosto.TabIndex = 27;
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
            this.miLabel4.TabIndex = 26;
            this.miLabel4.Text = "Centro de costo";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnNovedadTipo
            // 
            this.btnNovedadTipo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNovedadTipo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNovedadTipo.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_setup32;
            this.btnNovedadTipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNovedadTipo.FlatAppearance.BorderSize = 0;
            this.btnNovedadTipo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnNovedadTipo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNovedadTipo.Font = new System.Drawing.Font("Arial", 9F);
            this.btnNovedadTipo.ForeColor = System.Drawing.Color.Black;
            this.btnNovedadTipo.Location = new System.Drawing.Point(476, 168);
            this.btnNovedadTipo.Name = "btnNovedadTipo";
            this.btnNovedadTipo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNovedadTipo.Size = new System.Drawing.Size(24, 24);
            this.btnNovedadTipo.TabIndex = 30;
            this.btnNovedadTipo.UseVisualStyleBackColor = false;
            this.btnNovedadTipo.Click += new System.EventHandler(this.btnNovedadTipo_Click);
            // 
            // cmbNovedadTipo
            // 
            this.cmbNovedadTipo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbNovedadTipo.BackColor = System.Drawing.Color.White;
            this.cmbNovedadTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNovedadTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNovedadTipo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbNovedadTipo.ForeColor = System.Drawing.Color.Black;
            this.cmbNovedadTipo.FormattingEnabled = true;
            this.cmbNovedadTipo.Location = new System.Drawing.Point(160, 169);
            this.cmbNovedadTipo.Margin = new System.Windows.Forms.Padding(1);
            this.cmbNovedadTipo.Name = "cmbNovedadTipo";
            this.cmbNovedadTipo.Size = new System.Drawing.Size(315, 22);
            this.cmbNovedadTipo.Sorted = true;
            this.cmbNovedadTipo.TabIndex = 29;
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
            this.miLabel5.TabIndex = 28;
            this.miLabel5.Text = "Tipo de novedad";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupUnidadExpresion
            // 
            this.groupUnidadExpresion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupUnidadExpresion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupUnidadExpresion.Controls.Add(this.chkMonto);
            this.groupUnidadExpresion.Controls.Add(this.txtUnidadDias);
            this.groupUnidadExpresion.Controls.Add(this.chkCantidadDias);
            this.groupUnidadExpresion.Controls.Add(this.txtUnidadHoras);
            this.groupUnidadExpresion.Controls.Add(this.chkCantidadHoras);
            this.groupUnidadExpresion.Controls.Add(this.pkrFechaFinalizacion);
            this.groupUnidadExpresion.Controls.Add(this.chkFechaFinalizacion);
            this.groupUnidadExpresion.Controls.Add(this.pkrFechaInicializacion);
            this.groupUnidadExpresion.Controls.Add(this.chkFechaInicializacion);
            this.groupUnidadExpresion.Controls.Add(this.txtUnidadMonto);
            this.groupUnidadExpresion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupUnidadExpresion.ForeColor = System.Drawing.Color.Gray;
            this.groupUnidadExpresion.Location = new System.Drawing.Point(160, 196);
            this.groupUnidadExpresion.Name = "groupUnidadExpresion";
            this.groupUnidadExpresion.Size = new System.Drawing.Size(340, 152);
            this.groupUnidadExpresion.TabIndex = 31;
            this.groupUnidadExpresion.TabStop = false;
            this.groupUnidadExpresion.Text = "Unidades de expresión";
            // 
            // chkMonto
            // 
            this.chkMonto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkMonto.AutoSize = true;
            this.chkMonto.BackColor = System.Drawing.Color.Transparent;
            this.chkMonto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkMonto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMonto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkMonto.Location = new System.Drawing.Point(119, 125);
            this.chkMonto.Name = "chkMonto";
            this.chkMonto.Size = new System.Drawing.Size(69, 19);
            this.chkMonto.TabIndex = 8;
            this.chkMonto.Text = "Monto $";
            this.chkMonto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMonto.UseVisualStyleBackColor = false;
            this.chkMonto.CheckedChanged += new System.EventHandler(this.chkMonto_CheckedChanged);
            // 
            // txtUnidadDias
            // 
            this.txtUnidadDias.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtUnidadDias.BackColor = System.Drawing.Color.White;
            this.txtUnidadDias.BeepOnError = true;
            this.txtUnidadDias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnidadDias.Enabled = false;
            this.txtUnidadDias.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtUnidadDias.ForeColor = System.Drawing.Color.Black;
            this.txtUnidadDias.HidePromptOnLeave = true;
            this.txtUnidadDias.Location = new System.Drawing.Point(193, 96);
            this.txtUnidadDias.Mask = "999";
            this.txtUnidadDias.Name = "txtUnidadDias";
            this.txtUnidadDias.PromptChar = ' ';
            this.txtUnidadDias.Size = new System.Drawing.Size(28, 22);
            this.txtUnidadDias.TabIndex = 7;
            this.txtUnidadDias.Visible = false;
            // 
            // chkCantidadDias
            // 
            this.chkCantidadDias.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCantidadDias.AutoSize = true;
            this.chkCantidadDias.BackColor = System.Drawing.Color.Transparent;
            this.chkCantidadDias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkCantidadDias.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCantidadDias.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCantidadDias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkCantidadDias.Location = new System.Drawing.Point(75, 98);
            this.chkCantidadDias.Name = "chkCantidadDias";
            this.chkCantidadDias.Size = new System.Drawing.Size(113, 19);
            this.chkCantidadDias.TabIndex = 6;
            this.chkCantidadDias.Text = "Días  (cantidad)";
            this.chkCantidadDias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCantidadDias.UseVisualStyleBackColor = false;
            this.chkCantidadDias.CheckedChanged += new System.EventHandler(this.chkCantidadDias_CheckedChanged);
            // 
            // txtUnidadHoras
            // 
            this.txtUnidadHoras.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtUnidadHoras.BackColor = System.Drawing.Color.White;
            this.txtUnidadHoras.BeepOnError = true;
            this.txtUnidadHoras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnidadHoras.Enabled = false;
            this.txtUnidadHoras.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtUnidadHoras.ForeColor = System.Drawing.Color.Black;
            this.txtUnidadHoras.HidePromptOnLeave = true;
            this.txtUnidadHoras.Location = new System.Drawing.Point(193, 69);
            this.txtUnidadHoras.Mask = "999";
            this.txtUnidadHoras.Name = "txtUnidadHoras";
            this.txtUnidadHoras.PromptChar = ' ';
            this.txtUnidadHoras.Size = new System.Drawing.Size(28, 22);
            this.txtUnidadHoras.TabIndex = 5;
            this.txtUnidadHoras.Visible = false;
            // 
            // chkCantidadHoras
            // 
            this.chkCantidadHoras.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCantidadHoras.AutoSize = true;
            this.chkCantidadHoras.BackColor = System.Drawing.Color.Transparent;
            this.chkCantidadHoras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkCantidadHoras.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCantidadHoras.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCantidadHoras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkCantidadHoras.Location = new System.Drawing.Point(70, 71);
            this.chkCantidadHoras.Name = "chkCantidadHoras";
            this.chkCantidadHoras.Size = new System.Drawing.Size(118, 19);
            this.chkCantidadHoras.TabIndex = 4;
            this.chkCantidadHoras.Text = "Horas (cantidad)";
            this.chkCantidadHoras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCantidadHoras.UseVisualStyleBackColor = false;
            this.chkCantidadHoras.CheckedChanged += new System.EventHandler(this.chkCantidadHoras_CheckedChanged);
            // 
            // pkrFechaFinalizacion
            // 
            this.pkrFechaFinalizacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrFechaFinalizacion.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrFechaFinalizacion.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrFechaFinalizacion.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrFechaFinalizacion.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrFechaFinalizacion.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrFechaFinalizacion.CustomFormat = "dd/MM/yyyy hh:mm";
            this.pkrFechaFinalizacion.Enabled = false;
            this.pkrFechaFinalizacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrFechaFinalizacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrFechaFinalizacion.Location = new System.Drawing.Point(193, 42);
            this.pkrFechaFinalizacion.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrFechaFinalizacion.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrFechaFinalizacion.Name = "pkrFechaFinalizacion";
            this.pkrFechaFinalizacion.Size = new System.Drawing.Size(138, 22);
            this.pkrFechaFinalizacion.TabIndex = 3;
            this.pkrFechaFinalizacion.Visible = false;
            // 
            // chkFechaFinalizacion
            // 
            this.chkFechaFinalizacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkFechaFinalizacion.AutoSize = true;
            this.chkFechaFinalizacion.BackColor = System.Drawing.Color.Transparent;
            this.chkFechaFinalizacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkFechaFinalizacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFechaFinalizacion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFechaFinalizacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkFechaFinalizacion.Location = new System.Drawing.Point(47, 44);
            this.chkFechaFinalizacion.Name = "chkFechaFinalizacion";
            this.chkFechaFinalizacion.Size = new System.Drawing.Size(141, 19);
            this.chkFechaFinalizacion.TabIndex = 2;
            this.chkFechaFinalizacion.Text = "Fecha de finalización";
            this.chkFechaFinalizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFechaFinalizacion.UseVisualStyleBackColor = false;
            this.chkFechaFinalizacion.CheckedChanged += new System.EventHandler(this.chkFechaFinalizacion_CheckedChanged);
            // 
            // pkrFechaInicializacion
            // 
            this.pkrFechaInicializacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrFechaInicializacion.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrFechaInicializacion.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrFechaInicializacion.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrFechaInicializacion.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrFechaInicializacion.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrFechaInicializacion.CustomFormat = "dd/MM/yyyy hh:mm";
            this.pkrFechaInicializacion.Enabled = false;
            this.pkrFechaInicializacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrFechaInicializacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrFechaInicializacion.Location = new System.Drawing.Point(193, 15);
            this.pkrFechaInicializacion.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrFechaInicializacion.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrFechaInicializacion.Name = "pkrFechaInicializacion";
            this.pkrFechaInicializacion.Size = new System.Drawing.Size(138, 22);
            this.pkrFechaInicializacion.TabIndex = 1;
            this.pkrFechaInicializacion.Visible = false;
            // 
            // chkFechaInicializacion
            // 
            this.chkFechaInicializacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkFechaInicializacion.AutoSize = true;
            this.chkFechaInicializacion.BackColor = System.Drawing.Color.Transparent;
            this.chkFechaInicializacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkFechaInicializacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFechaInicializacion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFechaInicializacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkFechaInicializacion.Location = new System.Drawing.Point(38, 17);
            this.chkFechaInicializacion.Name = "chkFechaInicializacion";
            this.chkFechaInicializacion.Size = new System.Drawing.Size(150, 19);
            this.chkFechaInicializacion.TabIndex = 0;
            this.chkFechaInicializacion.Text = "Fecha de inicialización";
            this.chkFechaInicializacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFechaInicializacion.UseVisualStyleBackColor = false;
            this.chkFechaInicializacion.CheckedChanged += new System.EventHandler(this.chkFechaInicializacion_CheckedChanged);
            // 
            // txtUnidadMonto
            // 
            this.txtUnidadMonto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtUnidadMonto.BackColor = System.Drawing.Color.White;
            this.txtUnidadMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnidadMonto.Enabled = false;
            this.txtUnidadMonto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtUnidadMonto.ForeColor = System.Drawing.Color.Black;
            this.txtUnidadMonto.Location = new System.Drawing.Point(193, 123);
            this.txtUnidadMonto.MaxLength = 12;
            this.txtUnidadMonto.Name = "txtUnidadMonto";
            this.txtUnidadMonto.Size = new System.Drawing.Size(85, 22);
            this.txtUnidadMonto.TabIndex = 9;
            this.txtUnidadMonto.Visible = false;
            this.txtUnidadMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnidadMonto_KeyPress);
            // 
            // txtObservacion
            // 
            this.txtObservacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtObservacion.BackColor = System.Drawing.Color.White;
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtObservacion.ForeColor = System.Drawing.Color.Black;
            this.txtObservacion.Location = new System.Drawing.Point(160, 352);
            this.txtObservacion.MaxLength = 250;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(340, 52);
            this.txtObservacion.TabIndex = 33;
            // 
            // miLabel6
            // 
            this.miLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel6.BackColor = System.Drawing.Color.Transparent;
            this.miLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel6.Location = new System.Drawing.Point(0, 355);
            this.miLabel6.Name = "miLabel6";
            this.miLabel6.Size = new System.Drawing.Size(160, 15);
            this.miLabel6.TabIndex = 32;
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
            this.txtEstado.Location = new System.Drawing.Point(414, 61);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(86, 22);
            this.txtEstado.TabIndex = 20;
            // 
            // txtLiquidacionMes
            // 
            this.txtLiquidacionMes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLiquidacionMes.BackColor = System.Drawing.Color.White;
            this.txtLiquidacionMes.Font = new System.Drawing.Font("Arial", 10F);
            this.txtLiquidacionMes.ForeColor = System.Drawing.Color.Black;
            this.txtLiquidacionMes.Location = new System.Drawing.Point(758, 657);
            this.txtLiquidacionMes.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtLiquidacionMes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtLiquidacionMes.Name = "txtLiquidacionMes";
            this.txtLiquidacionMes.Size = new System.Drawing.Size(35, 23);
            this.txtLiquidacionMes.TabIndex = 10;
            this.txtLiquidacionMes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtLiquidacionAnio
            // 
            this.txtLiquidacionAnio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLiquidacionAnio.BackColor = System.Drawing.Color.White;
            this.txtLiquidacionAnio.Font = new System.Drawing.Font("Arial", 10F);
            this.txtLiquidacionAnio.ForeColor = System.Drawing.Color.Black;
            this.txtLiquidacionAnio.Location = new System.Drawing.Point(792, 657);
            this.txtLiquidacionAnio.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.txtLiquidacionAnio.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.txtLiquidacionAnio.Name = "txtLiquidacionAnio";
            this.txtLiquidacionAnio.Size = new System.Drawing.Size(50, 23);
            this.txtLiquidacionAnio.TabIndex = 11;
            this.txtLiquidacionAnio.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            // 
            // btnLiquidar
            // 
            this.btnLiquidar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLiquidar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLiquidar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLiquidar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLiquidar.FlatAppearance.BorderSize = 0;
            this.btnLiquidar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnLiquidar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLiquidar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnLiquidar.ForeColor = System.Drawing.Color.Black;
            this.btnLiquidar.Location = new System.Drawing.Point(844, 657);
            this.btnLiquidar.Name = "btnLiquidar";
            this.btnLiquidar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnLiquidar.Size = new System.Drawing.Size(75, 23);
            this.btnLiquidar.TabIndex = 12;
            this.btnLiquidar.Text = "Liquidar";
            this.btnLiquidar.UseVisualStyleBackColor = false;
            this.btnLiquidar.Click += new System.EventHandler(this.btnLiquidar_Click);
            // 
            // FormNovedadNomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.btnLiquidar);
            this.Controls.Add(this.txtLiquidacionAnio);
            this.Controls.Add(this.txtLiquidacionMes);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.btnNovedadTipo);
            this.Controls.Add(this.cmbNovedadTipo);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.txtCentroCosto);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.btnBuscarLegajo);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.txtDenominacion);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.cmbPeriodo);
            this.Controls.Add(this.pkrFechaEmision);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.btnWord_NovedadNomina);
            this.Controls.Add(this.groupUnidadExpresion);
            this.Name = "FormNovedadNomina";
            this.Text = "Novedades de Nómina";
            this.Load += new System.EventHandler(this.FormNovedadNomina_Load);
            this.Controls.SetChildIndex(this.groupUnidadExpresion, 0);
            this.Controls.SetChildIndex(this.btnWord_NovedadNomina, 0);
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
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.txtID, 0);
            this.Controls.SetChildIndex(this.pkrFechaEmision, 0);
            this.Controls.SetChildIndex(this.cmbPeriodo, 0);
            this.Controls.SetChildIndex(this.txtPeriodo, 0);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.btnBuscarLegajo, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.txtCuit, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.txtCentroCosto, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.cmbNovedadTipo, 0);
            this.Controls.SetChildIndex(this.btnNovedadTipo, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.txtObservacion, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.txtLiquidacionMes, 0);
            this.Controls.SetChildIndex(this.txtLiquidacionAnio, 0);
            this.Controls.SetChildIndex(this.btnLiquidar, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).EndInit();
            this.groupUnidadExpresion.ResumeLayout(false);
            this.groupUnidadExpresion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLiquidacionMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLiquidacionAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Biblioteca.Controles.MiButtonBase btnWord_NovedadNomina;
        private Biblioteca.Controles.MiTextBoxRead txtID;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiNumericUpDown txtPeriodo;
        private Biblioteca.Controles.MiComboBox cmbPeriodo;
        private Biblioteca.Controles.MiDateTimePicker pkrFechaEmision;
        private Biblioteca.Controles.MiButtonFind btnBuscarLegajo;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiTextBox txtDenominacion;
        private Biblioteca.Controles.MiTextBoxRead txtCuit;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiTextBoxRead txtCentroCosto;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiButtonFind btnNovedadTipo;
        private Biblioteca.Controles.MiComboBox cmbNovedadTipo;
        private Biblioteca.Controles.MiLabel miLabel5;
        private System.Windows.Forms.GroupBox groupUnidadExpresion;
        private Biblioteca.Controles.MiCheckBox chkMonto;
        private Biblioteca.Controles.MiMaskedTextBox txtUnidadDias;
        private Biblioteca.Controles.MiCheckBox chkCantidadDias;
        private Biblioteca.Controles.MiMaskedTextBox txtUnidadHoras;
        private Biblioteca.Controles.MiCheckBox chkCantidadHoras;
        private Biblioteca.Controles.MiDateTimePicker pkrFechaFinalizacion;
        private Biblioteca.Controles.MiCheckBox chkFechaFinalizacion;
        private Biblioteca.Controles.MiDateTimePicker pkrFechaInicializacion;
        private Biblioteca.Controles.MiCheckBox chkFechaInicializacion;
        private Biblioteca.Controles.MiTextBox txtUnidadMonto;
        private Biblioteca.Controles.MiTextBox txtObservacion;
        private Biblioteca.Controles.MiLabel miLabel6;
        private Biblioteca.Controles.MiTextBoxRead txtEstado;
        private Biblioteca.Controles.MiNumericUpDown txtLiquidacionMes;
        private Biblioteca.Controles.MiNumericUpDown txtLiquidacionAnio;
        public Biblioteca.Controles.MiButtonBase btnLiquidar;
    }
}