namespace CapaPresentacion
{
    partial class FormSueldo
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
                nSueldo.Dispose();
                nAsientoContable.Dispose();
                nCuentaContable.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSueldo));
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
            this.txtEstado = new Biblioteca.Controles.MiTextBoxRead();
            this.txtSueldoBruto = new Biblioteca.Controles.MiTextBox();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.txtSAC = new Biblioteca.Controles.MiTextBox();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.txtNoRemunerativo = new Biblioteca.Controles.MiTextBox();
            this.miLabel8 = new Biblioteca.Controles.MiLabel();
            this.txtIndemnizacionNR = new Biblioteca.Controles.MiTextBox();
            this.miLabel9 = new Biblioteca.Controles.MiLabel();
            this.txtAnticipoSueldo = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel10 = new Biblioteca.Controles.MiLabel();
            this.txtEmbargo = new Biblioteca.Controles.MiTextBox();
            this.miLabel11 = new Biblioteca.Controles.MiLabel();
            this.miLabel12 = new Biblioteca.Controles.MiLabel();
            this.txtAporte = new Biblioteca.Controles.MiTextBoxRead();
            this.txtAporteSindicato = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel13 = new Biblioteca.Controles.MiLabel();
            this.txtSueldoNeto = new Biblioteca.Controles.MiTextBox();
            this.miLabel15 = new Biblioteca.Controles.MiLabel();
            this.txtContribucionPatronal = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel16 = new Biblioteca.Controles.MiLabel();
            this.txtArtScvo = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel17 = new Biblioteca.Controles.MiLabel();
            this.txtFCL = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel18 = new Biblioteca.Controles.MiLabel();
            this.txtObservacion = new Biblioteca.Controles.MiTextBox();
            this.miLabel19 = new Biblioteca.Controles.MiLabel();
            this.txtConvenio = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.txtImpGanancia = new Biblioteca.Controles.MiTextBox();
            this.miLabel14 = new Biblioteca.Controles.MiLabel();
            this.panelLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).BeginInit();
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
            this.lblTituloLista.Text = "Lista de Sueldos";
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
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(134, 14);
            this.lblCatalagoTitulo5.Text = " Denominación - CUIL/CUIT";
            // 
            // lstCatalogo
            // 
            this.lstCatalogo.TabIndex = 17;
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(850, 36);
            this.lblCatalagoTitulo6.Text = "Campo6";
            this.lblCatalagoTitulo6.Visible = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Sueldos";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
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
            this.txtID.TabIndex = 12;
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
            this.miLabel1.TabIndex = 11;
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
            this.txtPeriodo.TabIndex = 15;
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
            this.cmbPeriodo.TabIndex = 14;
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
            this.pkrFechaEmision.TabIndex = 13;
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
            this.btnBuscarLegajo.TabIndex = 19;
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
            this.miLabel2.TabIndex = 17;
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
            this.txtDenominacion.TabIndex = 18;
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
            this.txtCuit.TabIndex = 21;
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
            this.miLabel3.TabIndex = 20;
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
            this.txtCentroCosto.TabIndex = 23;
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
            this.miLabel4.TabIndex = 22;
            this.miLabel4.Text = "Centro de costo";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtEstado.TabIndex = 16;
            // 
            // txtSueldoBruto
            // 
            this.txtSueldoBruto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSueldoBruto.BackColor = System.Drawing.Color.White;
            this.txtSueldoBruto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSueldoBruto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtSueldoBruto.ForeColor = System.Drawing.Color.Black;
            this.txtSueldoBruto.Location = new System.Drawing.Point(160, 196);
            this.txtSueldoBruto.MaxLength = 12;
            this.txtSueldoBruto.Name = "txtSueldoBruto";
            this.txtSueldoBruto.Size = new System.Drawing.Size(85, 22);
            this.txtSueldoBruto.TabIndex = 27;
            this.txtSueldoBruto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSueldoBruto_KeyPress);
            this.txtSueldoBruto.Validated += new System.EventHandler(this.txtSueldoBruto_Validated);
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
            this.miLabel6.TabIndex = 26;
            this.miLabel6.Text = "Sueldo bruto $";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSAC
            // 
            this.txtSAC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSAC.BackColor = System.Drawing.Color.White;
            this.txtSAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSAC.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtSAC.ForeColor = System.Drawing.Color.Black;
            this.txtSAC.Location = new System.Drawing.Point(160, 223);
            this.txtSAC.MaxLength = 12;
            this.txtSAC.Name = "txtSAC";
            this.txtSAC.Size = new System.Drawing.Size(85, 22);
            this.txtSAC.TabIndex = 29;
            this.txtSAC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSAC_KeyPress);
            this.txtSAC.Validated += new System.EventHandler(this.txtSAC_Validated);
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(0, 226);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(160, 15);
            this.miLabel7.TabIndex = 28;
            this.miLabel7.Text = "SAC $";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNoRemunerativo
            // 
            this.txtNoRemunerativo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtNoRemunerativo.BackColor = System.Drawing.Color.White;
            this.txtNoRemunerativo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoRemunerativo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtNoRemunerativo.ForeColor = System.Drawing.Color.Black;
            this.txtNoRemunerativo.Location = new System.Drawing.Point(160, 250);
            this.txtNoRemunerativo.MaxLength = 12;
            this.txtNoRemunerativo.Name = "txtNoRemunerativo";
            this.txtNoRemunerativo.Size = new System.Drawing.Size(85, 22);
            this.txtNoRemunerativo.TabIndex = 31;
            this.txtNoRemunerativo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoRemunerativo_KeyPress);
            this.txtNoRemunerativo.Validated += new System.EventHandler(this.txtNoRemunerativo_Validated);
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
            this.miLabel8.Text = "No remunerativo $";
            this.miLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIndemnizacionNR
            // 
            this.txtIndemnizacionNR.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtIndemnizacionNR.BackColor = System.Drawing.Color.White;
            this.txtIndemnizacionNR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIndemnizacionNR.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtIndemnizacionNR.ForeColor = System.Drawing.Color.Black;
            this.txtIndemnizacionNR.Location = new System.Drawing.Point(160, 277);
            this.txtIndemnizacionNR.MaxLength = 12;
            this.txtIndemnizacionNR.Name = "txtIndemnizacionNR";
            this.txtIndemnizacionNR.Size = new System.Drawing.Size(85, 22);
            this.txtIndemnizacionNR.TabIndex = 33;
            this.txtIndemnizacionNR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIndemnizacionNR_KeyPress);
            this.txtIndemnizacionNR.Validated += new System.EventHandler(this.txtIndemnizacionNR_Validated);
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
            this.miLabel9.TabIndex = 32;
            this.miLabel9.Text = "Indemnización (NR) $";
            this.miLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAnticipoSueldo
            // 
            this.txtAnticipoSueldo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAnticipoSueldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtAnticipoSueldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnticipoSueldo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtAnticipoSueldo.ForeColor = System.Drawing.Color.Black;
            this.txtAnticipoSueldo.Location = new System.Drawing.Point(160, 304);
            this.txtAnticipoSueldo.MaxLength = 12;
            this.txtAnticipoSueldo.Name = "txtAnticipoSueldo";
            this.txtAnticipoSueldo.ReadOnly = true;
            this.txtAnticipoSueldo.Size = new System.Drawing.Size(85, 22);
            this.txtAnticipoSueldo.TabIndex = 35;
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
            this.miLabel10.TabIndex = 34;
            this.miLabel10.Text = "Anticipo de sueldo $";
            this.miLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmbargo
            // 
            this.txtEmbargo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEmbargo.BackColor = System.Drawing.Color.White;
            this.txtEmbargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmbargo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtEmbargo.ForeColor = System.Drawing.Color.Black;
            this.txtEmbargo.Location = new System.Drawing.Point(407, 196);
            this.txtEmbargo.MaxLength = 12;
            this.txtEmbargo.Name = "txtEmbargo";
            this.txtEmbargo.Size = new System.Drawing.Size(85, 22);
            this.txtEmbargo.TabIndex = 37;
            this.txtEmbargo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmbargo_KeyPress);
            this.txtEmbargo.Validated += new System.EventHandler(this.txtEmbargo_Validated);
            // 
            // miLabel11
            // 
            this.miLabel11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel11.BackColor = System.Drawing.Color.Transparent;
            this.miLabel11.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel11.Location = new System.Drawing.Point(247, 199);
            this.miLabel11.Name = "miLabel11";
            this.miLabel11.Size = new System.Drawing.Size(160, 15);
            this.miLabel11.TabIndex = 36;
            this.miLabel11.Text = "Embargo $";
            this.miLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel12
            // 
            this.miLabel12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel12.BackColor = System.Drawing.Color.Transparent;
            this.miLabel12.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel12.Location = new System.Drawing.Point(247, 226);
            this.miLabel12.Name = "miLabel12";
            this.miLabel12.Size = new System.Drawing.Size(160, 15);
            this.miLabel12.TabIndex = 38;
            this.miLabel12.Text = "Aportes (jub. + PAMI + OS) $";
            this.miLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAporte
            // 
            this.txtAporte.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtAporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAporte.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtAporte.ForeColor = System.Drawing.Color.Black;
            this.txtAporte.Location = new System.Drawing.Point(407, 223);
            this.txtAporte.MaxLength = 12;
            this.txtAporte.Name = "txtAporte";
            this.txtAporte.ReadOnly = true;
            this.txtAporte.Size = new System.Drawing.Size(85, 22);
            this.txtAporte.TabIndex = 39;
            // 
            // txtAporteSindicato
            // 
            this.txtAporteSindicato.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAporteSindicato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtAporteSindicato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAporteSindicato.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtAporteSindicato.ForeColor = System.Drawing.Color.Black;
            this.txtAporteSindicato.Location = new System.Drawing.Point(407, 250);
            this.txtAporteSindicato.MaxLength = 12;
            this.txtAporteSindicato.Name = "txtAporteSindicato";
            this.txtAporteSindicato.ReadOnly = true;
            this.txtAporteSindicato.Size = new System.Drawing.Size(85, 22);
            this.txtAporteSindicato.TabIndex = 41;
            // 
            // miLabel13
            // 
            this.miLabel13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel13.BackColor = System.Drawing.Color.Transparent;
            this.miLabel13.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel13.Location = new System.Drawing.Point(247, 253);
            this.miLabel13.Name = "miLabel13";
            this.miLabel13.Size = new System.Drawing.Size(160, 15);
            this.miLabel13.TabIndex = 40;
            this.miLabel13.Text = "Aportes (sindicato) $";
            this.miLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSueldoNeto
            // 
            this.txtSueldoNeto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSueldoNeto.BackColor = System.Drawing.Color.White;
            this.txtSueldoNeto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSueldoNeto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtSueldoNeto.ForeColor = System.Drawing.Color.Black;
            this.txtSueldoNeto.Location = new System.Drawing.Point(654, 196);
            this.txtSueldoNeto.MaxLength = 12;
            this.txtSueldoNeto.Name = "txtSueldoNeto";
            this.txtSueldoNeto.Size = new System.Drawing.Size(85, 22);
            this.txtSueldoNeto.TabIndex = 45;
            this.txtSueldoNeto.Enter += new System.EventHandler(this.txtSueldoNeto_Enter);
            this.txtSueldoNeto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSueldoNeto_KeyPress);
            this.txtSueldoNeto.Validated += new System.EventHandler(this.txtSueldoNeto_Validated);
            // 
            // miLabel15
            // 
            this.miLabel15.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel15.BackColor = System.Drawing.Color.Transparent;
            this.miLabel15.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel15.Location = new System.Drawing.Point(494, 199);
            this.miLabel15.Name = "miLabel15";
            this.miLabel15.Size = new System.Drawing.Size(160, 15);
            this.miLabel15.TabIndex = 44;
            this.miLabel15.Text = "Sueldo neto $";
            this.miLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtContribucionPatronal
            // 
            this.txtContribucionPatronal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtContribucionPatronal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtContribucionPatronal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContribucionPatronal.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtContribucionPatronal.ForeColor = System.Drawing.Color.Black;
            this.txtContribucionPatronal.Location = new System.Drawing.Point(654, 223);
            this.txtContribucionPatronal.MaxLength = 12;
            this.txtContribucionPatronal.Name = "txtContribucionPatronal";
            this.txtContribucionPatronal.ReadOnly = true;
            this.txtContribucionPatronal.Size = new System.Drawing.Size(85, 22);
            this.txtContribucionPatronal.TabIndex = 47;
            // 
            // miLabel16
            // 
            this.miLabel16.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel16.BackColor = System.Drawing.Color.Transparent;
            this.miLabel16.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel16.Location = new System.Drawing.Point(494, 226);
            this.miLabel16.Name = "miLabel16";
            this.miLabel16.Size = new System.Drawing.Size(160, 15);
            this.miLabel16.TabIndex = 46;
            this.miLabel16.Text = "Contrib. (jub. + PAMI + OS) $";
            this.miLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtArtScvo
            // 
            this.txtArtScvo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtArtScvo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtArtScvo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArtScvo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtArtScvo.ForeColor = System.Drawing.Color.Black;
            this.txtArtScvo.Location = new System.Drawing.Point(654, 250);
            this.txtArtScvo.MaxLength = 12;
            this.txtArtScvo.Name = "txtArtScvo";
            this.txtArtScvo.ReadOnly = true;
            this.txtArtScvo.Size = new System.Drawing.Size(85, 22);
            this.txtArtScvo.TabIndex = 49;
            // 
            // miLabel17
            // 
            this.miLabel17.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel17.BackColor = System.Drawing.Color.Transparent;
            this.miLabel17.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel17.Location = new System.Drawing.Point(494, 253);
            this.miLabel17.Name = "miLabel17";
            this.miLabel17.Size = new System.Drawing.Size(160, 15);
            this.miLabel17.TabIndex = 48;
            this.miLabel17.Text = "ART + SCVO $";
            this.miLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFCL
            // 
            this.txtFCL.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtFCL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtFCL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFCL.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtFCL.ForeColor = System.Drawing.Color.Black;
            this.txtFCL.Location = new System.Drawing.Point(654, 277);
            this.txtFCL.MaxLength = 12;
            this.txtFCL.Name = "txtFCL";
            this.txtFCL.ReadOnly = true;
            this.txtFCL.Size = new System.Drawing.Size(85, 22);
            this.txtFCL.TabIndex = 51;
            // 
            // miLabel18
            // 
            this.miLabel18.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel18.BackColor = System.Drawing.Color.Transparent;
            this.miLabel18.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel18.Location = new System.Drawing.Point(494, 280);
            this.miLabel18.Name = "miLabel18";
            this.miLabel18.Size = new System.Drawing.Size(160, 15);
            this.miLabel18.TabIndex = 50;
            this.miLabel18.Text = "FCL $";
            this.miLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtObservacion.BackColor = System.Drawing.Color.White;
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtObservacion.ForeColor = System.Drawing.Color.Black;
            this.txtObservacion.Location = new System.Drawing.Point(160, 331);
            this.txtObservacion.MaxLength = 250;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(340, 52);
            this.txtObservacion.TabIndex = 53;
            // 
            // miLabel19
            // 
            this.miLabel19.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel19.BackColor = System.Drawing.Color.Transparent;
            this.miLabel19.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel19.Location = new System.Drawing.Point(0, 334);
            this.miLabel19.Name = "miLabel19";
            this.miLabel19.Size = new System.Drawing.Size(160, 15);
            this.miLabel19.TabIndex = 52;
            this.miLabel19.Text = "Observaciones";
            this.miLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConvenio
            // 
            this.txtConvenio.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtConvenio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtConvenio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConvenio.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtConvenio.ForeColor = System.Drawing.Color.Black;
            this.txtConvenio.Location = new System.Drawing.Point(160, 169);
            this.txtConvenio.MaxLength = 8;
            this.txtConvenio.Name = "txtConvenio";
            this.txtConvenio.ReadOnly = true;
            this.txtConvenio.Size = new System.Drawing.Size(68, 22);
            this.txtConvenio.TabIndex = 25;
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
            this.miLabel5.TabIndex = 24;
            this.miLabel5.Text = "Convenio";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImpGanancia
            // 
            this.txtImpGanancia.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtImpGanancia.BackColor = System.Drawing.Color.White;
            this.txtImpGanancia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImpGanancia.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtImpGanancia.ForeColor = System.Drawing.Color.Black;
            this.txtImpGanancia.Location = new System.Drawing.Point(407, 277);
            this.txtImpGanancia.MaxLength = 12;
            this.txtImpGanancia.Name = "txtImpGanancia";
            this.txtImpGanancia.Size = new System.Drawing.Size(85, 22);
            this.txtImpGanancia.TabIndex = 43;
            this.txtImpGanancia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImpGanancia_KeyPress);
            this.txtImpGanancia.Validated += new System.EventHandler(this.txtImpGanancia_Validated);
            // 
            // miLabel14
            // 
            this.miLabel14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel14.BackColor = System.Drawing.Color.Transparent;
            this.miLabel14.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel14.Location = new System.Drawing.Point(247, 280);
            this.miLabel14.Name = "miLabel14";
            this.miLabel14.Size = new System.Drawing.Size(160, 15);
            this.miLabel14.TabIndex = 42;
            this.miLabel14.Text = "Imp. a las Ganancias";
            this.miLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormSueldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.txtImpGanancia);
            this.Controls.Add(this.miLabel14);
            this.Controls.Add(this.txtConvenio);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.miLabel19);
            this.Controls.Add(this.txtFCL);
            this.Controls.Add(this.miLabel18);
            this.Controls.Add(this.txtArtScvo);
            this.Controls.Add(this.miLabel17);
            this.Controls.Add(this.txtContribucionPatronal);
            this.Controls.Add(this.miLabel16);
            this.Controls.Add(this.txtSueldoNeto);
            this.Controls.Add(this.miLabel15);
            this.Controls.Add(this.txtAporteSindicato);
            this.Controls.Add(this.miLabel13);
            this.Controls.Add(this.txtAporte);
            this.Controls.Add(this.miLabel12);
            this.Controls.Add(this.txtEmbargo);
            this.Controls.Add(this.miLabel11);
            this.Controls.Add(this.txtAnticipoSueldo);
            this.Controls.Add(this.miLabel10);
            this.Controls.Add(this.txtIndemnizacionNR);
            this.Controls.Add(this.miLabel9);
            this.Controls.Add(this.txtNoRemunerativo);
            this.Controls.Add(this.miLabel8);
            this.Controls.Add(this.txtSAC);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.txtSueldoBruto);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.txtEstado);
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
            this.Name = "FormSueldo";
            this.Text = "Sueldos";
            this.Load += new System.EventHandler(this.FormSueldo_Load);
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
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.txtSueldoBruto, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.txtSAC, 0);
            this.Controls.SetChildIndex(this.miLabel8, 0);
            this.Controls.SetChildIndex(this.txtNoRemunerativo, 0);
            this.Controls.SetChildIndex(this.miLabel9, 0);
            this.Controls.SetChildIndex(this.txtIndemnizacionNR, 0);
            this.Controls.SetChildIndex(this.miLabel10, 0);
            this.Controls.SetChildIndex(this.txtAnticipoSueldo, 0);
            this.Controls.SetChildIndex(this.miLabel11, 0);
            this.Controls.SetChildIndex(this.txtEmbargo, 0);
            this.Controls.SetChildIndex(this.miLabel12, 0);
            this.Controls.SetChildIndex(this.txtAporte, 0);
            this.Controls.SetChildIndex(this.miLabel13, 0);
            this.Controls.SetChildIndex(this.txtAporteSindicato, 0);
            this.Controls.SetChildIndex(this.miLabel15, 0);
            this.Controls.SetChildIndex(this.txtSueldoNeto, 0);
            this.Controls.SetChildIndex(this.miLabel16, 0);
            this.Controls.SetChildIndex(this.txtContribucionPatronal, 0);
            this.Controls.SetChildIndex(this.miLabel17, 0);
            this.Controls.SetChildIndex(this.txtArtScvo, 0);
            this.Controls.SetChildIndex(this.miLabel18, 0);
            this.Controls.SetChildIndex(this.txtFCL, 0);
            this.Controls.SetChildIndex(this.miLabel19, 0);
            this.Controls.SetChildIndex(this.txtObservacion, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.txtConvenio, 0);
            this.Controls.SetChildIndex(this.miLabel14, 0);
            this.Controls.SetChildIndex(this.txtImpGanancia, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private Biblioteca.Controles.MiTextBoxRead txtEstado;
        private Biblioteca.Controles.MiTextBox txtSueldoBruto;
        private Biblioteca.Controles.MiLabel miLabel6;
        private Biblioteca.Controles.MiTextBox txtSAC;
        private Biblioteca.Controles.MiLabel miLabel7;
        private Biblioteca.Controles.MiTextBox txtNoRemunerativo;
        private Biblioteca.Controles.MiLabel miLabel8;
        private Biblioteca.Controles.MiTextBox txtIndemnizacionNR;
        private Biblioteca.Controles.MiLabel miLabel9;
        private Biblioteca.Controles.MiTextBoxRead txtAnticipoSueldo;
        private Biblioteca.Controles.MiLabel miLabel10;
        private Biblioteca.Controles.MiTextBox txtEmbargo;
        private Biblioteca.Controles.MiLabel miLabel11;
        private Biblioteca.Controles.MiLabel miLabel12;
        private Biblioteca.Controles.MiTextBoxRead txtAporte;
        private Biblioteca.Controles.MiTextBoxRead txtAporteSindicato;
        private Biblioteca.Controles.MiLabel miLabel13;
        private Biblioteca.Controles.MiTextBox txtSueldoNeto;
        private Biblioteca.Controles.MiLabel miLabel15;
        private Biblioteca.Controles.MiTextBoxRead txtContribucionPatronal;
        private Biblioteca.Controles.MiLabel miLabel16;
        private Biblioteca.Controles.MiTextBoxRead txtArtScvo;
        private Biblioteca.Controles.MiLabel miLabel17;
        private Biblioteca.Controles.MiTextBoxRead txtFCL;
        private Biblioteca.Controles.MiLabel miLabel18;
        private Biblioteca.Controles.MiTextBox txtObservacion;
        private Biblioteca.Controles.MiLabel miLabel19;
        private Biblioteca.Controles.MiTextBoxRead txtConvenio;
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiTextBox txtImpGanancia;
        private Biblioteca.Controles.MiLabel miLabel14;
    }
}