namespace CapaPresentacion
{
    partial class FormPagoProveedor
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
                nProveedor.Dispose();
                nPagoProveedor.Dispose();
                nPagoProveedorDetalle.Dispose();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCbteTPV = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtCbteNro = new Biblioteca.Controles.MiTextBoxRead();
            this.pkrCbteFecha = new Biblioteca.Controles.MiDateTimePicker();
            this.txtEstado = new Biblioteca.Controles.MiTextBoxRead();
            this.btnBuscarProveedor = new Biblioteca.Controles.MiButtonFind();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.txtCategoriaIva = new Biblioteca.Controles.MiTextBoxRead();
            this.txtCuit = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.txtConcepto = new Biblioteca.Controles.MiTextBox();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.gridDetalle = new Biblioteca.Controles.MiGridEdit();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalPercepcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalNoGravado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalNeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEstadoPago = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColModificacionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarFila = new Biblioteca.Controles.MiButton24x24();
            this.btnQuitarFila = new Biblioteca.Controles.MiButton24x24();
            this.btnBuscarFila = new Biblioteca.Controles.MiButtonBase();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.cmbMedioPago = new Biblioteca.Controles.MiComboBox();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.cmbCuentaContable = new Biblioteca.Controles.MiComboBox();
            this.txtMedioNro = new Biblioteca.Controles.MiMaskedTextBox();
            this.lblMedioNro = new Biblioteca.Controles.MiLabel();
            this.pkrMedioChequeVto = new Biblioteca.Controles.MiDateTimePicker();
            this.txtCtaBancariaNro = new Biblioteca.Controles.MiMaskedTextBox();
            this.cmbCtaBancariaTipo = new Biblioteca.Controles.MiComboBox();
            this.btnCtaBancaria = new Biblioteca.Controles.MiButtonFind();
            this.cmbCtaBancaria = new Biblioteca.Controles.MiComboBox();
            this.lblCtaBancaria = new Biblioteca.Controles.MiLabel();
            this.btnWord_Acuse = new Biblioteca.Controles.MiButtonBase();
            this.txtMontoPagado = new Biblioteca.Controles.MiTextBox();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.panelLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
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
            this.btnExcel_Registro.TabIndex = 8;
            this.btnExcel_Registro.Visible = false;
            // 
            // btnPDF_Registro
            // 
            this.btnPDF_Registro.Enabled = false;
            this.btnPDF_Registro.FlatAppearance.BorderSize = 0;
            this.btnPDF_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Registro.Location = new System.Drawing.Point(386, 657);
            this.btnPDF_Registro.TabIndex = 9;
            this.btnPDF_Registro.Visible = false;
            // 
            // lblTituloLista
            // 
            this.lblTituloLista.Text = "Lista de Pagos";
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
            // panelLista
            // 
            this.panelLista.TabIndex = 11;
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(602, 36);
            this.lblCatalagoTitulo6.Size = new System.Drawing.Size(106, 14);
            this.lblCatalagoTitulo6.Text = "Denominación - CUIT";
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Pagos a Proveedores";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 10;
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
            this.txtCbteTPV.TabIndex = 13;
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
            this.miLabel1.Text = "Comprobante";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtCbteNro.TabIndex = 14;
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
            this.pkrCbteFecha.TabIndex = 15;
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstado.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtEstado.ForeColor = System.Drawing.Color.Black;
            this.txtEstado.Location = new System.Drawing.Point(358, 61);
            this.txtEstado.MaxLength = 7;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(68, 22);
            this.txtEstado.TabIndex = 16;
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBuscarProveedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarProveedor.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_find32;
            this.btnBuscarProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarProveedor.FlatAppearance.BorderSize = 0;
            this.btnBuscarProveedor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBuscarProveedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuscarProveedor.Font = new System.Drawing.Font("Arial", 9F);
            this.btnBuscarProveedor.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarProveedor.Location = new System.Drawing.Point(476, 87);
            this.btnBuscarProveedor.Name = "btnBuscarProveedor";
            this.btnBuscarProveedor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBuscarProveedor.Size = new System.Drawing.Size(24, 24);
            this.btnBuscarProveedor.TabIndex = 19;
            this.btnBuscarProveedor.UseVisualStyleBackColor = false;
            this.btnBuscarProveedor.Click += new System.EventHandler(this.btnBuscarProveedor_Click);
            // 
            // miLabel3
            // 
            this.miLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel3.BackColor = System.Drawing.Color.Transparent;
            this.miLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel3.Location = new System.Drawing.Point(0, 91);
            this.miLabel3.Name = "miLabel3";
            this.miLabel3.Size = new System.Drawing.Size(160, 15);
            this.miLabel3.TabIndex = 17;
            this.miLabel3.Text = "Denominación";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // txtCategoriaIva
            // 
            this.txtCategoriaIva.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCategoriaIva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtCategoriaIva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategoriaIva.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCategoriaIva.ForeColor = System.Drawing.Color.Black;
            this.txtCategoriaIva.Location = new System.Drawing.Point(262, 115);
            this.txtCategoriaIva.MaxLength = 23;
            this.txtCategoriaIva.Name = "txtCategoriaIva";
            this.txtCategoriaIva.ReadOnly = true;
            this.txtCategoriaIva.Size = new System.Drawing.Size(202, 22);
            this.txtCategoriaIva.TabIndex = 22;
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
            // miLabel4
            // 
            this.miLabel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel4.BackColor = System.Drawing.Color.Transparent;
            this.miLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel4.Location = new System.Drawing.Point(0, 117);
            this.miLabel4.Name = "miLabel4";
            this.miLabel4.Size = new System.Drawing.Size(160, 15);
            this.miLabel4.TabIndex = 20;
            this.miLabel4.Text = "CUIT - Categoría IVA";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtConcepto.BackColor = System.Drawing.Color.White;
            this.txtConcepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConcepto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtConcepto.ForeColor = System.Drawing.Color.Black;
            this.txtConcepto.Location = new System.Drawing.Point(160, 142);
            this.txtConcepto.MaxLength = 250;
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConcepto.Size = new System.Drawing.Size(840, 36);
            this.txtConcepto.TabIndex = 24;
            // 
            // miLabel5
            // 
            this.miLabel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel5.BackColor = System.Drawing.Color.Transparent;
            this.miLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel5.Location = new System.Drawing.Point(0, 145);
            this.miLabel5.Name = "miLabel5";
            this.miLabel5.Size = new System.Drawing.Size(160, 15);
            this.miLabel5.TabIndex = 23;
            this.miLabel5.Text = "En concepto de";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.ColDetalle,
            this.ColTotalBruto,
            this.ColTotalIVA,
            this.ColTotalPercepcion,
            this.ColTotalNoGravado,
            this.ColTotalNeto,
            this.ColEstadoPago,
            this.ColModificacionID,
            this.ColNula});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDetalle.DefaultCellStyle = dataGridViewCellStyle10;
            this.gridDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridDetalle.EnableHeadersVisualStyles = false;
            this.gridDetalle.GridColor = System.Drawing.Color.DarkGray;
            this.gridDetalle.Location = new System.Drawing.Point(160, 183);
            this.gridDetalle.MultiSelect = false;
            this.gridDetalle.Name = "gridDetalle";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.gridDetalle.RowHeadersVisible = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            this.gridDetalle.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.gridDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridDetalle.Size = new System.Drawing.Size(840, 152);
            this.gridDetalle.StandardTab = true;
            this.gridDetalle.TabIndex = 25;
            this.gridDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetalle_CellEndEdit);
            this.gridDetalle.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetalle_CellEnter);
            this.gridDetalle.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridDetalle_DataError);
            this.gridDetalle.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridDetalle_EditingControlShowing);
            this.gridDetalle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridDetalle_KeyDown);
            this.gridDetalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridDetalle_KeyPress);
            this.gridDetalle.Leave += new System.EventHandler(this.gridDetalle_Leave);
            // 
            // ColID
            // 
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.ColID.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColID.Frozen = true;
            this.ColID.HeaderText = "ID";
            this.ColID.MaxInputLength = 8;
            this.ColID.Name = "ColID";
            this.ColID.Width = 64;
            // 
            // ColDetalle
            // 
            this.ColDetalle.Frozen = true;
            this.ColDetalle.HeaderText = "Comprobante de Venta";
            this.ColDetalle.MaxInputLength = 35;
            this.ColDetalle.Name = "ColDetalle";
            this.ColDetalle.ReadOnly = true;
            this.ColDetalle.Width = 282;
            // 
            // ColTotalBruto
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.ColTotalBruto.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColTotalBruto.HeaderText = "Total Bruto $";
            this.ColTotalBruto.MaxInputLength = 11;
            this.ColTotalBruto.Name = "ColTotalBruto";
            this.ColTotalBruto.ReadOnly = true;
            this.ColTotalBruto.Width = 80;
            // 
            // ColTotalIVA
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.ColTotalIVA.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColTotalIVA.HeaderText = "Total IVA $";
            this.ColTotalIVA.MaxInputLength = 12;
            this.ColTotalIVA.Name = "ColTotalIVA";
            this.ColTotalIVA.ReadOnly = true;
            this.ColTotalIVA.Width = 74;
            // 
            // ColTotalPercepcion
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.ColTotalPercepcion.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColTotalPercepcion.HeaderText = "T. Percep. $";
            this.ColTotalPercepcion.Name = "ColTotalPercepcion";
            this.ColTotalPercepcion.ReadOnly = true;
            this.ColTotalPercepcion.Width = 74;
            // 
            // ColTotalNoGravado
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.ColTotalNoGravado.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColTotalNoGravado.HeaderText = "T. No Grav. $";
            this.ColTotalNoGravado.Name = "ColTotalNoGravado";
            this.ColTotalNoGravado.ReadOnly = true;
            this.ColTotalNoGravado.Width = 74;
            // 
            // ColTotalNeto
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.ColTotalNeto.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColTotalNeto.HeaderText = "Total Neto $";
            this.ColTotalNeto.Name = "ColTotalNeto";
            this.ColTotalNeto.ReadOnly = true;
            this.ColTotalNeto.Width = 80;
            // 
            // ColEstadoPago
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.ColEstadoPago.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColEstadoPago.DisplayStyleForCurrentCellOnly = true;
            this.ColEstadoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColEstadoPago.HeaderText = "Estado de Pago";
            this.ColEstadoPago.Items.AddRange(new object[] {
            "C/SALDO",
            "PAGADO",
            "S/PAGAR"});
            this.ColEstadoPago.Name = "ColEstadoPago";
            this.ColEstadoPago.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColEstadoPago.Sorted = true;
            this.ColEstadoPago.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColEstadoPago.Width = 94;
            // 
            // ColModificacionID
            // 
            this.ColModificacionID.HeaderText = "ModificacionID";
            this.ColModificacionID.Name = "ColModificacionID";
            this.ColModificacionID.ReadOnly = true;
            this.ColModificacionID.Visible = false;
            // 
            // ColNula
            // 
            this.ColNula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNula.HeaderText = "";
            this.ColNula.MaxInputLength = 0;
            this.ColNula.Name = "ColNula";
            this.ColNula.ReadOnly = true;
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
            this.btnAgregarFila.Location = new System.Drawing.Point(159, 336);
            this.btnAgregarFila.Name = "btnAgregarFila";
            this.btnAgregarFila.Size = new System.Drawing.Size(24, 24);
            this.btnAgregarFila.TabIndex = 26;
            this.btnAgregarFila.UseVisualStyleBackColor = false;
            this.btnAgregarFila.Click += new System.EventHandler(this.btnAgregarFila_Click);
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
            this.btnQuitarFila.Location = new System.Drawing.Point(183, 336);
            this.btnQuitarFila.Name = "btnQuitarFila";
            this.btnQuitarFila.Size = new System.Drawing.Size(24, 24);
            this.btnQuitarFila.TabIndex = 27;
            this.btnQuitarFila.UseVisualStyleBackColor = false;
            this.btnQuitarFila.Click += new System.EventHandler(this.btnQuitarFila_Click);
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
            this.btnBuscarFila.Location = new System.Drawing.Point(159, 360);
            this.btnBuscarFila.Name = "btnBuscarFila";
            this.btnBuscarFila.Size = new System.Drawing.Size(48, 23);
            this.btnBuscarFila.TabIndex = 28;
            this.btnBuscarFila.UseVisualStyleBackColor = false;
            this.btnBuscarFila.Click += new System.EventHandler(this.btnBuscarFila_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(902, 352);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(98, 30);
            this.pictureBox4.TabIndex = 276;
            this.pictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(905, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Monto Pagado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(902, 337);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(98, 16);
            this.pictureBox3.TabIndex = 275;
            this.pictureBox3.TabStop = false;
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
            this.cmbMedioPago.Location = new System.Drawing.Point(160, 387);
            this.cmbMedioPago.Margin = new System.Windows.Forms.Padding(1);
            this.cmbMedioPago.Name = "cmbMedioPago";
            this.cmbMedioPago.Size = new System.Drawing.Size(120, 22);
            this.cmbMedioPago.Sorted = true;
            this.cmbMedioPago.TabIndex = 32;
            this.cmbMedioPago.SelectedIndexChanged += new System.EventHandler(this.cmbMedioPago_SelectedIndexChanged);
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(0, 390);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(160, 15);
            this.miLabel7.TabIndex = 31;
            this.miLabel7.Text = "Medio de pago";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCuentaContable
            // 
            this.cmbCuentaContable.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbCuentaContable.BackColor = System.Drawing.Color.White;
            this.cmbCuentaContable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuentaContable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCuentaContable.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCuentaContable.ForeColor = System.Drawing.Color.Black;
            this.cmbCuentaContable.FormattingEnabled = true;
            this.cmbCuentaContable.Location = new System.Drawing.Point(160, 414);
            this.cmbCuentaContable.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCuentaContable.Name = "cmbCuentaContable";
            this.cmbCuentaContable.Size = new System.Drawing.Size(185, 22);
            this.cmbCuentaContable.Sorted = true;
            this.cmbCuentaContable.TabIndex = 34;
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
            this.txtMedioNro.Location = new System.Drawing.Point(160, 441);
            this.txtMedioNro.Mask = "99999999";
            this.txtMedioNro.Name = "txtMedioNro";
            this.txtMedioNro.PromptChar = ' ';
            this.txtMedioNro.Size = new System.Drawing.Size(62, 22);
            this.txtMedioNro.TabIndex = 36;
            this.txtMedioNro.Visible = false;
            // 
            // lblMedioNro
            // 
            this.lblMedioNro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblMedioNro.BackColor = System.Drawing.Color.Transparent;
            this.lblMedioNro.Font = new System.Drawing.Font("Arial", 9F);
            this.lblMedioNro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblMedioNro.Location = new System.Drawing.Point(0, 444);
            this.lblMedioNro.Name = "lblMedioNro";
            this.lblMedioNro.Size = new System.Drawing.Size(160, 15);
            this.lblMedioNro.TabIndex = 35;
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
            this.pkrMedioChequeVto.Location = new System.Drawing.Point(224, 441);
            this.pkrMedioChequeVto.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrMedioChequeVto.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrMedioChequeVto.Name = "pkrMedioChequeVto";
            this.pkrMedioChequeVto.Size = new System.Drawing.Size(102, 22);
            this.pkrMedioChequeVto.TabIndex = 37;
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
            this.txtCtaBancariaNro.Location = new System.Drawing.Point(429, 468);
            this.txtCtaBancariaNro.Mask = "9999999999";
            this.txtCtaBancariaNro.Name = "txtCtaBancariaNro";
            this.txtCtaBancariaNro.PromptChar = ' ';
            this.txtCtaBancariaNro.Size = new System.Drawing.Size(89, 22);
            this.txtCtaBancariaNro.TabIndex = 42;
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
            this.cmbCtaBancariaTipo.Location = new System.Drawing.Point(375, 468);
            this.cmbCtaBancariaTipo.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCtaBancariaTipo.Name = "cmbCtaBancariaTipo";
            this.cmbCtaBancariaTipo.Size = new System.Drawing.Size(55, 22);
            this.cmbCtaBancariaTipo.Sorted = true;
            this.cmbCtaBancariaTipo.TabIndex = 41;
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
            this.btnCtaBancaria.Location = new System.Drawing.Point(346, 467);
            this.btnCtaBancaria.Name = "btnCtaBancaria";
            this.btnCtaBancaria.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCtaBancaria.Size = new System.Drawing.Size(24, 24);
            this.btnCtaBancaria.TabIndex = 40;
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
            this.cmbCtaBancaria.Location = new System.Drawing.Point(160, 468);
            this.cmbCtaBancaria.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCtaBancaria.Name = "cmbCtaBancaria";
            this.cmbCtaBancaria.Size = new System.Drawing.Size(185, 22);
            this.cmbCtaBancaria.Sorted = true;
            this.cmbCtaBancaria.TabIndex = 39;
            this.cmbCtaBancaria.Visible = false;
            this.cmbCtaBancaria.SelectedIndexChanged += new System.EventHandler(this.cmbCtaBancaria_SelectedIndexChanged);
            // 
            // lblCtaBancaria
            // 
            this.lblCtaBancaria.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCtaBancaria.BackColor = System.Drawing.Color.Transparent;
            this.lblCtaBancaria.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCtaBancaria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblCtaBancaria.Location = new System.Drawing.Point(0, 471);
            this.lblCtaBancaria.Name = "lblCtaBancaria";
            this.lblCtaBancaria.Size = new System.Drawing.Size(160, 15);
            this.lblCtaBancaria.TabIndex = 38;
            this.lblCtaBancaria.Text = "Cta. Bancaria (proveedor)";
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
            this.btnWord_Acuse.TabIndex = 7;
            this.btnWord_Acuse.UseVisualStyleBackColor = false;
            this.btnWord_Acuse.Click += new System.EventHandler(this.btnWord_Acuse_Click);
            // 
            // txtMontoPagado
            // 
            this.txtMontoPagado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtMontoPagado.BackColor = System.Drawing.Color.White;
            this.txtMontoPagado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMontoPagado.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtMontoPagado.ForeColor = System.Drawing.Color.Black;
            this.txtMontoPagado.Location = new System.Drawing.Point(905, 358);
            this.txtMontoPagado.MaxLength = 9;
            this.txtMontoPagado.Name = "txtMontoPagado";
            this.txtMontoPagado.Size = new System.Drawing.Size(92, 15);
            this.txtMontoPagado.TabIndex = 30;
            this.txtMontoPagado.Text = "0.00";
            this.txtMontoPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMontoPagado.Enter += new System.EventHandler(this.txtMontoBruto_Enter);
            this.txtMontoPagado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoBruto_KeyPress);
            this.txtMontoPagado.Validated += new System.EventHandler(this.txtMontoBruto_Validated);
            // 
            // miLabel6
            // 
            this.miLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel6.BackColor = System.Drawing.Color.Transparent;
            this.miLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel6.Location = new System.Drawing.Point(0, 417);
            this.miLabel6.Name = "miLabel6";
            this.miLabel6.Size = new System.Drawing.Size(160, 15);
            this.miLabel6.TabIndex = 33;
            this.miLabel6.Text = "Cuenta Contable (origen)";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormPagoProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.txtMontoPagado);
            this.Controls.Add(this.btnWord_Acuse);
            this.Controls.Add(this.txtCtaBancariaNro);
            this.Controls.Add(this.cmbCtaBancariaTipo);
            this.Controls.Add(this.btnCtaBancaria);
            this.Controls.Add(this.cmbCtaBancaria);
            this.Controls.Add(this.lblCtaBancaria);
            this.Controls.Add(this.cmbCuentaContable);
            this.Controls.Add(this.txtMedioNro);
            this.Controls.Add(this.lblMedioNro);
            this.Controls.Add(this.pkrMedioChequeVto);
            this.Controls.Add(this.cmbMedioPago);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnBuscarFila);
            this.Controls.Add(this.btnQuitarFila);
            this.Controls.Add(this.btnAgregarFila);
            this.Controls.Add(this.gridDetalle);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.txtCategoriaIva);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.btnBuscarProveedor);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.txtDenominacion);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.pkrCbteFecha);
            this.Controls.Add(this.txtCbteNro);
            this.Controls.Add(this.txtCbteTPV);
            this.Controls.Add(this.miLabel1);
            this.Name = "FormPagoProveedor";
            this.Text = "Pagos a Proveedores";
            this.Load += new System.EventHandler(this.FormPagoProveedor_Load);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.txtCbteTPV, 0);
            this.Controls.SetChildIndex(this.txtCbteNro, 0);
            this.Controls.SetChildIndex(this.pkrCbteFecha, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.btnBuscarProveedor, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.txtCuit, 0);
            this.Controls.SetChildIndex(this.txtCategoriaIva, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.txtConcepto, 0);
            this.Controls.SetChildIndex(this.gridDetalle, 0);
            this.Controls.SetChildIndex(this.btnAgregarFila, 0);
            this.Controls.SetChildIndex(this.btnQuitarFila, 0);
            this.Controls.SetChildIndex(this.btnBuscarFila, 0);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pictureBox4, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.cmbMedioPago, 0);
            this.Controls.SetChildIndex(this.pkrMedioChequeVto, 0);
            this.Controls.SetChildIndex(this.lblMedioNro, 0);
            this.Controls.SetChildIndex(this.txtMedioNro, 0);
            this.Controls.SetChildIndex(this.cmbCuentaContable, 0);
            this.Controls.SetChildIndex(this.lblCtaBancaria, 0);
            this.Controls.SetChildIndex(this.cmbCtaBancaria, 0);
            this.Controls.SetChildIndex(this.btnCtaBancaria, 0);
            this.Controls.SetChildIndex(this.cmbCtaBancariaTipo, 0);
            this.Controls.SetChildIndex(this.txtCtaBancariaNro, 0);
            this.Controls.SetChildIndex(this.btnWord_Acuse, 0);
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
            this.Controls.SetChildIndex(this.txtMontoPagado, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Biblioteca.Controles.MiTextBoxRead txtCbteTPV;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBoxRead txtCbteNro;
        private Biblioteca.Controles.MiDateTimePicker pkrCbteFecha;
        private Biblioteca.Controles.MiTextBoxRead txtEstado;
        private Biblioteca.Controles.MiButtonFind btnBuscarProveedor;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiTextBox txtDenominacion;
        private Biblioteca.Controles.MiTextBoxRead txtCategoriaIva;
        private Biblioteca.Controles.MiTextBoxRead txtCuit;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiTextBox txtConcepto;
        private Biblioteca.Controles.MiLabel miLabel5;
        public Biblioteca.Controles.MiGridEdit gridDetalle;
        public Biblioteca.Controles.MiButton24x24 btnAgregarFila;
        public Biblioteca.Controles.MiButton24x24 btnQuitarFila;
        public Biblioteca.Controles.MiButtonBase btnBuscarFila;
        public System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox pictureBox3;
        private Biblioteca.Controles.MiComboBox cmbMedioPago;
        private Biblioteca.Controles.MiLabel miLabel7;
        private Biblioteca.Controles.MiComboBox cmbCuentaContable;
        private Biblioteca.Controles.MiMaskedTextBox txtMedioNro;
        private Biblioteca.Controles.MiLabel lblMedioNro;
        private Biblioteca.Controles.MiDateTimePicker pkrMedioChequeVto;
        private Biblioteca.Controles.MiMaskedTextBox txtCtaBancariaNro;
        private Biblioteca.Controles.MiComboBox cmbCtaBancariaTipo;
        private Biblioteca.Controles.MiButtonFind btnCtaBancaria;
        private Biblioteca.Controles.MiComboBox cmbCtaBancaria;
        private Biblioteca.Controles.MiLabel lblCtaBancaria;
        private Biblioteca.Controles.MiButtonBase btnWord_Acuse;
        public Biblioteca.Controles.MiTextBox txtMontoPagado;
        private Biblioteca.Controles.MiLabel miLabel6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalPercepcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalNoGravado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalNeto;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColEstadoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColModificacionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNula;
    }
}
