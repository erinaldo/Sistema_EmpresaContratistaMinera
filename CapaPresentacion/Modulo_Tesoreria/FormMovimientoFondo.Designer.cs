namespace CapaPresentacion
{
    partial class FormMovimientoFondo
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
                nMovimientoFondo.Dispose();
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
            this.txtEstado = new Biblioteca.Controles.MiTextBoxRead();
            this.pkrCbteFecha = new Biblioteca.Controles.MiDateTimePicker();
            this.txtCbteNro = new Biblioteca.Controles.MiTextBoxRead();
            this.txtCbteTPV = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.txtMonto = new Biblioteca.Controles.MiTextBox();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.cmbCuentaContableOrigen = new Biblioteca.Controles.MiComboBox();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.cmbCuentaContableDestino = new Biblioteca.Controles.MiComboBox();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.txtMedioNro = new Biblioteca.Controles.MiMaskedTextBox();
            this.lblMedioNro = new Biblioteca.Controles.MiLabel();
            this.pkrMedioChequeVto = new Biblioteca.Controles.MiDateTimePicker();
            this.cmbMedioPago = new Biblioteca.Controles.MiComboBox();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
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
            this.lblTituloLista.Text = "Lista de Movimientos de Fondos";
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
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(609, 36);
            this.lblCatalagoTitulo6.Size = new System.Drawing.Size(74, 14);
            this.lblCatalagoTitulo6.Text = "Denominación";
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Movimiento de Fondos";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstado.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
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
            // txtMonto
            // 
            this.txtMonto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtMonto.BackColor = System.Drawing.Color.White;
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonto.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtMonto.ForeColor = System.Drawing.Color.Black;
            this.txtMonto.Location = new System.Drawing.Point(160, 115);
            this.txtMonto.MaxLength = 12;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(85, 22);
            this.txtMonto.TabIndex = 19;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
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
            this.miLabel3.TabIndex = 18;
            this.miLabel3.Text = "Monto $";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cmbCuentaContableOrigen.Location = new System.Drawing.Point(160, 169);
            this.cmbCuentaContableOrigen.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCuentaContableOrigen.Name = "cmbCuentaContableOrigen";
            this.cmbCuentaContableOrigen.Size = new System.Drawing.Size(185, 22);
            this.cmbCuentaContableOrigen.Sorted = true;
            this.cmbCuentaContableOrigen.TabIndex = 23;
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
            this.miLabel5.TabIndex = 22;
            this.miLabel5.Text = "Cuenta contable (origen)";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cmbCuentaContableDestino.Location = new System.Drawing.Point(160, 196);
            this.cmbCuentaContableDestino.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCuentaContableDestino.Name = "cmbCuentaContableDestino";
            this.cmbCuentaContableDestino.Size = new System.Drawing.Size(185, 22);
            this.cmbCuentaContableDestino.Sorted = true;
            this.cmbCuentaContableDestino.TabIndex = 25;
            // 
            // miLabel6
            // 
            this.miLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel6.BackColor = System.Drawing.Color.Transparent;
            this.miLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel6.Location = new System.Drawing.Point(5, 199);
            this.miLabel6.Name = "miLabel6";
            this.miLabel6.Size = new System.Drawing.Size(155, 15);
            this.miLabel6.TabIndex = 24;
            this.miLabel6.Text = "Cuenta Contable (destino)";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtMedioNro.Location = new System.Drawing.Point(160, 223);
            this.txtMedioNro.Mask = "99999999";
            this.txtMedioNro.Name = "txtMedioNro";
            this.txtMedioNro.PromptChar = ' ';
            this.txtMedioNro.Size = new System.Drawing.Size(62, 22);
            this.txtMedioNro.TabIndex = 27;
            this.txtMedioNro.Visible = false;
            // 
            // lblMedioNro
            // 
            this.lblMedioNro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblMedioNro.BackColor = System.Drawing.Color.Transparent;
            this.lblMedioNro.Font = new System.Drawing.Font("Arial", 9F);
            this.lblMedioNro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblMedioNro.Location = new System.Drawing.Point(0, 226);
            this.lblMedioNro.Name = "lblMedioNro";
            this.lblMedioNro.Size = new System.Drawing.Size(160, 15);
            this.lblMedioNro.TabIndex = 26;
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
            this.pkrMedioChequeVto.Location = new System.Drawing.Point(224, 223);
            this.pkrMedioChequeVto.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrMedioChequeVto.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrMedioChequeVto.Name = "pkrMedioChequeVto";
            this.pkrMedioChequeVto.Size = new System.Drawing.Size(102, 22);
            this.pkrMedioChequeVto.TabIndex = 28;
            this.pkrMedioChequeVto.Visible = false;
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
            this.cmbMedioPago.Location = new System.Drawing.Point(160, 142);
            this.cmbMedioPago.Margin = new System.Windows.Forms.Padding(1);
            this.cmbMedioPago.Name = "cmbMedioPago";
            this.cmbMedioPago.Size = new System.Drawing.Size(120, 22);
            this.cmbMedioPago.Sorted = true;
            this.cmbMedioPago.TabIndex = 21;
            this.cmbMedioPago.SelectedIndexChanged += new System.EventHandler(this.cmbMedioPago_SelectedIndexChanged);
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
            this.miLabel4.TabIndex = 20;
            this.miLabel4.Text = "Medio de pago";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormMovimientoFondo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.cmbMedioPago);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.txtMedioNro);
            this.Controls.Add(this.lblMedioNro);
            this.Controls.Add(this.pkrMedioChequeVto);
            this.Controls.Add(this.cmbCuentaContableOrigen);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.cmbCuentaContableDestino);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.txtDenominacion);
            this.Controls.Add(this.pkrCbteFecha);
            this.Controls.Add(this.txtCbteNro);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtCbteTPV);
            this.Name = "FormMovimientoFondo";
            this.Text = "Movimiento de Fondos";
            this.Load += new System.EventHandler(this.FormMovimientoFondo_Load);
            this.Controls.SetChildIndex(this.txtCbteTPV, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.txtCbteNro, 0);
            this.Controls.SetChildIndex(this.pkrCbteFecha, 0);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.txtMonto, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.cmbCuentaContableDestino, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.cmbCuentaContableOrigen, 0);
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
            this.Controls.SetChildIndex(this.pkrMedioChequeVto, 0);
            this.Controls.SetChildIndex(this.lblMedioNro, 0);
            this.Controls.SetChildIndex(this.txtMedioNro, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.cmbMedioPago, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
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
        private Biblioteca.Controles.MiTextBox txtMonto;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiComboBox cmbCuentaContableOrigen;
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiComboBox cmbCuentaContableDestino;
        private Biblioteca.Controles.MiLabel miLabel6;
        private Biblioteca.Controles.MiMaskedTextBox txtMedioNro;
        private Biblioteca.Controles.MiLabel lblMedioNro;
        private Biblioteca.Controles.MiDateTimePicker pkrMedioChequeVto;
        private Biblioteca.Controles.MiComboBox cmbMedioPago;
        private Biblioteca.Controles.MiLabel miLabel4;
    }
}
