namespace CapaPresentacion
{
    partial class FormPagoNomina
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
                nPagoNomina.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPagoNomina));
            this.txtCbteNro = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.pkrCbteFecha = new Biblioteca.Controles.MiDateTimePicker();
            this.btnBuscarLegajo = new Biblioteca.Controles.MiButtonFind();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBoxRead();
            this.txtCuit = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.txtCentroCosto = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.txtEstado = new Biblioteca.Controles.MiTextBoxRead();
            this.cmbCuentaContableDestino = new Biblioteca.Controles.MiComboBox();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.txtConcepto = new Biblioteca.Controles.MiTextBox();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.txtMontoPagado = new Biblioteca.Controles.MiTextBox();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.cmbMedioPago = new Biblioteca.Controles.MiComboBox();
            this.miLabel8 = new Biblioteca.Controles.MiLabel();
            this.miLabel9 = new Biblioteca.Controles.MiLabel();
            this.cmbCuentaContableOrigen = new Biblioteca.Controles.MiComboBox();
            this.txtMedioNro = new Biblioteca.Controles.MiMaskedTextBox();
            this.lblMedioNro = new Biblioteca.Controles.MiLabel();
            this.pkrMedioChequeVto = new Biblioteca.Controles.MiDateTimePicker();
            this.txtCtaBancariaNro = new Biblioteca.Controles.MiMaskedTextBox();
            this.cmbCtaBancariaTipo = new Biblioteca.Controles.MiComboBox();
            this.btnCtaBancaria = new Biblioteca.Controles.MiButtonFind();
            this.cmbCtaBancaria = new Biblioteca.Controles.MiComboBox();
            this.lblCtaBancaria = new Biblioteca.Controles.MiLabel();
            this.btnWord_Acuse = new Biblioteca.Controles.MiButtonBase();
            this.txtCbteTPV = new Biblioteca.Controles.MiTextBoxRead();
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
            this.btnExcel_Registro.Enabled = false;
            this.btnExcel_Registro.FlatAppearance.BorderSize = 0;
            this.btnExcel_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Registro.Location = new System.Drawing.Point(354, 657);
            this.btnExcel_Registro.Visible = false;
            // 
            // btnPDF_Registro
            // 
            this.btnPDF_Registro.Enabled = false;
            this.btnPDF_Registro.FlatAppearance.BorderSize = 0;
            this.btnPDF_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Registro.Location = new System.Drawing.Point(386, 657);
            this.btnPDF_Registro.Visible = false;
            // 
            // lblTituloLista
            // 
            this.lblTituloLista.Text = "Lista de Pagos de Nómina";
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
            this.lblCatalagoTitulo2.Size = new System.Drawing.Size(54, 14);
            this.lblCatalagoTitulo2.Text = "F. Emisión";
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
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(152, 14);
            this.lblCatalagoTitulo4.Text = "Medio de Pago (N° Ref. - Vto.)";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(497, 36);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(29, 14);
            this.lblCatalagoTitulo5.Text = "Total";
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(602, 36);
            this.lblCatalagoTitulo6.Size = new System.Drawing.Size(134, 14);
            this.lblCatalagoTitulo6.Text = " Denominación - CUIL/CUIT";
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Pagos a Nómina";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
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
            this.txtCbteNro.TabIndex = 12;
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
            this.pkrCbteFecha.TabIndex = 13;
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
            this.txtEstado.Location = new System.Drawing.Point(358, 61);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(68, 22);
            this.txtEstado.TabIndex = 16;
            // 
            // cmbCuentaContableDestino
            // 
            this.cmbCuentaContableDestino.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbCuentaContableDestino.BackColor = System.Drawing.Color.White;
            this.cmbCuentaContableDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuentaContableDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCuentaContableDestino.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCuentaContableDestino.ForeColor = System.Drawing.Color.Black;
            this.cmbCuentaContableDestino.FormattingEnabled = true;
            this.cmbCuentaContableDestino.Items.AddRange(new object[] {
            "ANTICIPOS DE SUELDOS",
            "SUELDOS A PAGAR"});
            this.cmbCuentaContableDestino.Location = new System.Drawing.Point(160, 169);
            this.cmbCuentaContableDestino.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCuentaContableDestino.Name = "cmbCuentaContableDestino";
            this.cmbCuentaContableDestino.Size = new System.Drawing.Size(160, 22);
            this.cmbCuentaContableDestino.Sorted = true;
            this.cmbCuentaContableDestino.TabIndex = 34;
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(0, 172);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(160, 15);
            this.miLabel7.TabIndex = 33;
            this.miLabel7.Text = "Cuenta Contable (destino)";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtConcepto.BackColor = System.Drawing.Color.White;
            this.txtConcepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConcepto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtConcepto.ForeColor = System.Drawing.Color.Black;
            this.txtConcepto.Location = new System.Drawing.Point(160, 196);
            this.txtConcepto.MaxLength = 250;
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConcepto.Size = new System.Drawing.Size(340, 36);
            this.txtConcepto.TabIndex = 36;
            // 
            // miLabel5
            // 
            this.miLabel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel5.BackColor = System.Drawing.Color.Transparent;
            this.miLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel5.Location = new System.Drawing.Point(0, 199);
            this.miLabel5.Name = "miLabel5";
            this.miLabel5.Size = new System.Drawing.Size(160, 15);
            this.miLabel5.TabIndex = 35;
            this.miLabel5.Text = "En concepto de";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMontoPagado
            // 
            this.txtMontoPagado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtMontoPagado.BackColor = System.Drawing.Color.White;
            this.txtMontoPagado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoPagado.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtMontoPagado.ForeColor = System.Drawing.Color.Black;
            this.txtMontoPagado.Location = new System.Drawing.Point(160, 237);
            this.txtMontoPagado.MaxLength = 12;
            this.txtMontoPagado.Name = "txtMontoPagado";
            this.txtMontoPagado.Size = new System.Drawing.Size(85, 22);
            this.txtMontoPagado.TabIndex = 280;
            this.txtMontoPagado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoPagado_KeyPress);
            // 
            // miLabel6
            // 
            this.miLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel6.BackColor = System.Drawing.Color.Transparent;
            this.miLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel6.Location = new System.Drawing.Point(0, 240);
            this.miLabel6.Name = "miLabel6";
            this.miLabel6.Size = new System.Drawing.Size(160, 15);
            this.miLabel6.TabIndex = 279;
            this.miLabel6.Text = "Monto pagado $";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbMedioPago
            // 
            this.cmbMedioPago.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbMedioPago.BackColor = System.Drawing.Color.White;
            this.cmbMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedioPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMedioPago.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbMedioPago.ForeColor = System.Drawing.Color.Black;
            this.cmbMedioPago.FormattingEnabled = true;
            this.cmbMedioPago.Items.AddRange(new object[] {
            "CHEQUE",
            "EFECTIVO",
            "T.CREDITO",
            "T.DEBITO",
            "TRANSFERENCIA"});
            this.cmbMedioPago.Location = new System.Drawing.Point(160, 264);
            this.cmbMedioPago.Margin = new System.Windows.Forms.Padding(1);
            this.cmbMedioPago.Name = "cmbMedioPago";
            this.cmbMedioPago.Size = new System.Drawing.Size(120, 22);
            this.cmbMedioPago.Sorted = true;
            this.cmbMedioPago.TabIndex = 282;
            this.cmbMedioPago.SelectedIndexChanged += new System.EventHandler(this.cmbMedioPago_SelectedIndexChanged);
            // 
            // miLabel8
            // 
            this.miLabel8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel8.BackColor = System.Drawing.Color.Transparent;
            this.miLabel8.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel8.Location = new System.Drawing.Point(0, 267);
            this.miLabel8.Name = "miLabel8";
            this.miLabel8.Size = new System.Drawing.Size(160, 15);
            this.miLabel8.TabIndex = 281;
            this.miLabel8.Text = "Medio de pago";
            this.miLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel9
            // 
            this.miLabel9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel9.BackColor = System.Drawing.Color.Transparent;
            this.miLabel9.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel9.Location = new System.Drawing.Point(0, 294);
            this.miLabel9.Name = "miLabel9";
            this.miLabel9.Size = new System.Drawing.Size(160, 15);
            this.miLabel9.TabIndex = 283;
            this.miLabel9.Text = "Cuenta Contable (origen)";
            this.miLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCuentaContableOrigen
            // 
            this.cmbCuentaContableOrigen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbCuentaContableOrigen.BackColor = System.Drawing.Color.White;
            this.cmbCuentaContableOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuentaContableOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCuentaContableOrigen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCuentaContableOrigen.ForeColor = System.Drawing.Color.Black;
            this.cmbCuentaContableOrigen.FormattingEnabled = true;
            this.cmbCuentaContableOrigen.Location = new System.Drawing.Point(160, 291);
            this.cmbCuentaContableOrigen.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCuentaContableOrigen.Name = "cmbCuentaContableOrigen";
            this.cmbCuentaContableOrigen.Size = new System.Drawing.Size(185, 22);
            this.cmbCuentaContableOrigen.Sorted = true;
            this.cmbCuentaContableOrigen.TabIndex = 284;
            // 
            // txtMedioNro
            // 
            this.txtMedioNro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtMedioNro.BackColor = System.Drawing.Color.White;
            this.txtMedioNro.BeepOnError = true;
            this.txtMedioNro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMedioNro.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtMedioNro.ForeColor = System.Drawing.Color.Black;
            this.txtMedioNro.HidePromptOnLeave = true;
            this.txtMedioNro.Location = new System.Drawing.Point(160, 318);
            this.txtMedioNro.Mask = "99999999";
            this.txtMedioNro.Name = "txtMedioNro";
            this.txtMedioNro.PromptChar = ' ';
            this.txtMedioNro.Size = new System.Drawing.Size(62, 22);
            this.txtMedioNro.TabIndex = 286;
            this.txtMedioNro.Visible = false;
            // 
            // lblMedioNro
            // 
            this.lblMedioNro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblMedioNro.BackColor = System.Drawing.Color.Transparent;
            this.lblMedioNro.Font = new System.Drawing.Font("Arial", 9F);
            this.lblMedioNro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblMedioNro.Location = new System.Drawing.Point(0, 321);
            this.lblMedioNro.Name = "lblMedioNro";
            this.lblMedioNro.Size = new System.Drawing.Size(160, 15);
            this.lblMedioNro.TabIndex = 285;
            this.lblMedioNro.Text = "Cheque (nro. - vto.)";
            this.lblMedioNro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMedioNro.Visible = false;
            // 
            // pkrMedioChequeVto
            // 
            this.pkrMedioChequeVto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrMedioChequeVto.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrMedioChequeVto.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrMedioChequeVto.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrMedioChequeVto.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrMedioChequeVto.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrMedioChequeVto.CustomFormat = "dd/MM/yyyy";
            this.pkrMedioChequeVto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrMedioChequeVto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrMedioChequeVto.Location = new System.Drawing.Point(224, 318);
            this.pkrMedioChequeVto.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrMedioChequeVto.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrMedioChequeVto.Name = "pkrMedioChequeVto";
            this.pkrMedioChequeVto.Size = new System.Drawing.Size(102, 22);
            this.pkrMedioChequeVto.TabIndex = 287;
            this.pkrMedioChequeVto.Visible = false;
            // 
            // txtCtaBancariaNro
            // 
            this.txtCtaBancariaNro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCtaBancariaNro.BackColor = System.Drawing.Color.White;
            this.txtCtaBancariaNro.BeepOnError = true;
            this.txtCtaBancariaNro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCtaBancariaNro.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCtaBancariaNro.ForeColor = System.Drawing.Color.Black;
            this.txtCtaBancariaNro.HidePromptOnLeave = true;
            this.txtCtaBancariaNro.Location = new System.Drawing.Point(429, 345);
            this.txtCtaBancariaNro.Mask = "9999999999";
            this.txtCtaBancariaNro.Name = "txtCtaBancariaNro";
            this.txtCtaBancariaNro.PromptChar = ' ';
            this.txtCtaBancariaNro.Size = new System.Drawing.Size(89, 22);
            this.txtCtaBancariaNro.TabIndex = 292;
            this.txtCtaBancariaNro.Visible = false;
            // 
            // cmbCtaBancariaTipo
            // 
            this.cmbCtaBancariaTipo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbCtaBancariaTipo.BackColor = System.Drawing.Color.White;
            this.cmbCtaBancariaTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCtaBancariaTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCtaBancariaTipo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCtaBancariaTipo.ForeColor = System.Drawing.Color.Black;
            this.cmbCtaBancariaTipo.FormattingEnabled = true;
            this.cmbCtaBancariaTipo.Items.AddRange(new object[] {
            "C.A. $",
            "C.C. $",
            "S/D"});
            this.cmbCtaBancariaTipo.Location = new System.Drawing.Point(375, 345);
            this.cmbCtaBancariaTipo.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCtaBancariaTipo.Name = "cmbCtaBancariaTipo";
            this.cmbCtaBancariaTipo.Size = new System.Drawing.Size(55, 22);
            this.cmbCtaBancariaTipo.Sorted = true;
            this.cmbCtaBancariaTipo.TabIndex = 291;
            this.cmbCtaBancariaTipo.Visible = false;
            // 
            // btnCtaBancaria
            // 
            this.btnCtaBancaria.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCtaBancaria.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCtaBancaria.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_setup32;
            this.btnCtaBancaria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCtaBancaria.FlatAppearance.BorderSize = 0;
            this.btnCtaBancaria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCtaBancaria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCtaBancaria.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCtaBancaria.ForeColor = System.Drawing.Color.Black;
            this.btnCtaBancaria.Location = new System.Drawing.Point(346, 344);
            this.btnCtaBancaria.Name = "btnCtaBancaria";
            this.btnCtaBancaria.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCtaBancaria.Size = new System.Drawing.Size(24, 24);
            this.btnCtaBancaria.TabIndex = 290;
            this.btnCtaBancaria.UseVisualStyleBackColor = false;
            this.btnCtaBancaria.Visible = false;
            this.btnCtaBancaria.Click += new System.EventHandler(this.btnCtaBancaria_Click);
            // 
            // cmbCtaBancaria
            // 
            this.cmbCtaBancaria.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbCtaBancaria.BackColor = System.Drawing.Color.White;
            this.cmbCtaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCtaBancaria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCtaBancaria.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCtaBancaria.ForeColor = System.Drawing.Color.Black;
            this.cmbCtaBancaria.FormattingEnabled = true;
            this.cmbCtaBancaria.Location = new System.Drawing.Point(160, 345);
            this.cmbCtaBancaria.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCtaBancaria.Name = "cmbCtaBancaria";
            this.cmbCtaBancaria.Size = new System.Drawing.Size(185, 22);
            this.cmbCtaBancaria.Sorted = true;
            this.cmbCtaBancaria.TabIndex = 289;
            this.cmbCtaBancaria.Visible = false;
            this.cmbCtaBancaria.SelectedIndexChanged += new System.EventHandler(this.cmbCtaBancaria_SelectedIndexChanged);
            // 
            // lblCtaBancaria
            // 
            this.lblCtaBancaria.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCtaBancaria.BackColor = System.Drawing.Color.Transparent;
            this.lblCtaBancaria.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCtaBancaria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblCtaBancaria.Location = new System.Drawing.Point(0, 348);
            this.lblCtaBancaria.Name = "lblCtaBancaria";
            this.lblCtaBancaria.Size = new System.Drawing.Size(160, 15);
            this.lblCtaBancaria.TabIndex = 288;
            this.lblCtaBancaria.Text = "Cta. Bancaria (empleado)";
            this.lblCtaBancaria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCtaBancaria.Visible = false;
            // 
            // btnWord_Acuse
            // 
            this.btnWord_Acuse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWord_Acuse.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnWord_Acuse.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_word32;
            this.btnWord_Acuse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWord_Acuse.FlatAppearance.BorderSize = 0;
            this.btnWord_Acuse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnWord_Acuse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnWord_Acuse.Font = new System.Drawing.Font("Arial", 9F);
            this.btnWord_Acuse.ForeColor = System.Drawing.Color.Black;
            this.btnWord_Acuse.Location = new System.Drawing.Point(322, 657);
            this.btnWord_Acuse.Name = "btnWord_Acuse";
            this.btnWord_Acuse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnWord_Acuse.Size = new System.Drawing.Size(30, 23);
            this.btnWord_Acuse.TabIndex = 293;
            this.btnWord_Acuse.UseVisualStyleBackColor = false;
            this.btnWord_Acuse.Click += new System.EventHandler(this.btnWord_Acuse_Click);
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
            this.txtCbteTPV.TabIndex = 295;
            // 
            // FormPagoNomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.txtCbteTPV);
            this.Controls.Add(this.btnWord_Acuse);
            this.Controls.Add(this.txtCtaBancariaNro);
            this.Controls.Add(this.cmbCtaBancariaTipo);
            this.Controls.Add(this.btnCtaBancaria);
            this.Controls.Add(this.cmbCtaBancaria);
            this.Controls.Add(this.lblCtaBancaria);
            this.Controls.Add(this.txtMedioNro);
            this.Controls.Add(this.lblMedioNro);
            this.Controls.Add(this.pkrMedioChequeVto);
            this.Controls.Add(this.miLabel9);
            this.Controls.Add(this.cmbCuentaContableOrigen);
            this.Controls.Add(this.cmbMedioPago);
            this.Controls.Add(this.miLabel8);
            this.Controls.Add(this.txtMontoPagado);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.cmbCuentaContableDestino);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtCentroCosto);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.btnBuscarLegajo);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.txtDenominacion);
            this.Controls.Add(this.pkrCbteFecha);
            this.Controls.Add(this.txtCbteNro);
            this.Controls.Add(this.miLabel1);
            this.Name = "FormPagoNomina";
            this.Text = "Pagos a Nómina";
            this.Load += new System.EventHandler(this.FormPagoNomina_Load);
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
            this.Controls.SetChildIndex(this.txtCbteNro, 0);
            this.Controls.SetChildIndex(this.pkrCbteFecha, 0);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.btnBuscarLegajo, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.txtCuit, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.txtCentroCosto, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.cmbCuentaContableDestino, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.txtConcepto, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.txtMontoPagado, 0);
            this.Controls.SetChildIndex(this.miLabel8, 0);
            this.Controls.SetChildIndex(this.cmbMedioPago, 0);
            this.Controls.SetChildIndex(this.cmbCuentaContableOrigen, 0);
            this.Controls.SetChildIndex(this.miLabel9, 0);
            this.Controls.SetChildIndex(this.pkrMedioChequeVto, 0);
            this.Controls.SetChildIndex(this.lblMedioNro, 0);
            this.Controls.SetChildIndex(this.txtMedioNro, 0);
            this.Controls.SetChildIndex(this.lblCtaBancaria, 0);
            this.Controls.SetChildIndex(this.cmbCtaBancaria, 0);
            this.Controls.SetChildIndex(this.btnCtaBancaria, 0);
            this.Controls.SetChildIndex(this.cmbCtaBancariaTipo, 0);
            this.Controls.SetChildIndex(this.txtCtaBancariaNro, 0);
            this.Controls.SetChildIndex(this.btnWord_Acuse, 0);
            this.Controls.SetChildIndex(this.txtCbteTPV, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Biblioteca.Controles.MiTextBoxRead txtCbteNro;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiDateTimePicker pkrCbteFecha;
        private Biblioteca.Controles.MiButtonFind btnBuscarLegajo;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiTextBoxRead txtDenominacion;
        private Biblioteca.Controles.MiTextBoxRead txtCuit;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiTextBoxRead txtCentroCosto;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiTextBoxRead txtEstado;
        private Biblioteca.Controles.MiComboBox cmbCuentaContableDestino;
        private Biblioteca.Controles.MiLabel miLabel7;
        private Biblioteca.Controles.MiTextBox txtConcepto;
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiTextBox txtMontoPagado;
        private Biblioteca.Controles.MiLabel miLabel6;
        private Biblioteca.Controles.MiComboBox cmbMedioPago;
        private Biblioteca.Controles.MiLabel miLabel8;
        private Biblioteca.Controles.MiLabel miLabel9;
        private Biblioteca.Controles.MiComboBox cmbCuentaContableOrigen;
        private Biblioteca.Controles.MiMaskedTextBox txtMedioNro;
        private Biblioteca.Controles.MiLabel lblMedioNro;
        private Biblioteca.Controles.MiDateTimePicker pkrMedioChequeVto;
        private Biblioteca.Controles.MiMaskedTextBox txtCtaBancariaNro;
        private Biblioteca.Controles.MiComboBox cmbCtaBancariaTipo;
        private Biblioteca.Controles.MiButtonFind btnCtaBancaria;
        private Biblioteca.Controles.MiComboBox cmbCtaBancaria;
        private Biblioteca.Controles.MiLabel lblCtaBancaria;
        private Biblioteca.Controles.MiButtonBase btnWord_Acuse;
        private Biblioteca.Controles.MiTextBoxRead txtCbteTPV;
    }
}