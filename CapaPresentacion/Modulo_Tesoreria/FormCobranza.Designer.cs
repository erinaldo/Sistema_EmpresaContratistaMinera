namespace CapaPresentacion
{
    partial class FormCobranza
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
                nCliente.Dispose();
                nCobranza.Dispose();
                nCobranzaDetalle.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCobranza));
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
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.btnBuscarCliente = new Biblioteca.Controles.MiButtonFind();
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
            this.ColIVA105 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIVA210 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIVA270 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalNeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCobroEstado = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColModificacionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarFila = new Biblioteca.Controles.MiButton24x24();
            this.btnQuitarFila = new Biblioteca.Controles.MiButton24x24();
            this.btnBuscarFila = new Biblioteca.Controles.MiButtonBase();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblIVA270 = new System.Windows.Forms.Label();
            this.lblIVA105 = new System.Windows.Forms.Label();
            this.lblIVA210 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.txtRetencionLH = new Biblioteca.Controles.MiTextBox();
            this.txtRetencionIIBB = new Biblioteca.Controles.MiTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.txtRetencionSUSS = new Biblioteca.Controles.MiTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtRetencionIVA = new Biblioteca.Controles.MiTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.txtRetencionGanancia = new Biblioteca.Controles.MiTextBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.lblMontoNeto = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.txtRetencionFondoMinero = new Biblioteca.Controles.MiTextBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.cmbMedioCobro = new Biblioteca.Controles.MiComboBox();
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
            this.groupRetencion = new System.Windows.Forms.GroupBox();
            this.chkRetencionGanancia = new Biblioteca.Controles.MiCheckBox();
            this.chkRetencionIIBB = new Biblioteca.Controles.MiCheckBox();
            this.chkRetencionSUSS = new Biblioteca.Controles.MiCheckBox();
            this.chkRetencionFondoMinero = new Biblioteca.Controles.MiCheckBox();
            this.chkRetencionIVA = new Biblioteca.Controles.MiCheckBox();
            this.chkRetencionLH = new Biblioteca.Controles.MiCheckBox();
            this.btnWord_Acuse = new Biblioteca.Controles.MiButtonBase();
            this.txtLiquidacion = new Biblioteca.Controles.MiMaskedTextBox();
            this.lblTotalRetencion = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMontoBruto = new Biblioteca.Controles.MiTextBox();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.panelLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.groupRetencion.SuspendLayout();
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
            this.lblTituloLista.Text = "Lista de Cobranzas";
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
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(157, 14);
            this.lblCatalagoTitulo4.Text = "Medio de Cobro (N° Ref. - Vto.)";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(497, 36);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(80, 14);
            this.lblCatalagoTitulo5.Text = "Monto Cobrado";
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
            this.labelTitulo.Text = "Cobranzas";
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
            // miLabel2
            // 
            this.miLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel2.BackColor = System.Drawing.Color.Transparent;
            this.miLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel2.Location = new System.Drawing.Point(432, 64);
            this.miLabel2.Name = "miLabel2";
            this.miLabel2.Size = new System.Drawing.Size(90, 15);
            this.miLabel2.TabIndex = 17;
            this.miLabel2.Text = "N° Liquidación";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBuscarCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarCliente.BackgroundImage")));
            this.btnBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarCliente.FlatAppearance.BorderSize = 0;
            this.btnBuscarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBuscarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuscarCliente.Font = new System.Drawing.Font("Arial", 9F);
            this.btnBuscarCliente.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarCliente.Location = new System.Drawing.Point(476, 87);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBuscarCliente.Size = new System.Drawing.Size(24, 24);
            this.btnBuscarCliente.TabIndex = 21;
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
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
            this.miLabel3.TabIndex = 19;
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
            this.txtDenominacion.TabIndex = 20;
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
            this.txtCategoriaIva.TabIndex = 24;
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
            this.txtCuit.TabIndex = 23;
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
            this.miLabel4.TabIndex = 22;
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
            this.txtConcepto.TabIndex = 26;
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
            this.miLabel5.TabIndex = 25;
            this.miLabel5.Text = "En concepto de ";
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
            this.ColIVA105,
            this.ColIVA210,
            this.ColIVA270,
            this.ColTotalNeto,
            this.ColCobroEstado,
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
            this.gridDetalle.TabIndex = 28;
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
            // ColIVA105
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.ColIVA105.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColIVA105.HeaderText = "IVA %10.5 $";
            this.ColIVA105.MaxInputLength = 12;
            this.ColIVA105.Name = "ColIVA105";
            this.ColIVA105.ReadOnly = true;
            this.ColIVA105.Width = 74;
            // 
            // ColIVA210
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.ColIVA210.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColIVA210.HeaderText = "IVA %21.0 $";
            this.ColIVA210.Name = "ColIVA210";
            this.ColIVA210.ReadOnly = true;
            this.ColIVA210.Width = 74;
            // 
            // ColIVA270
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.ColIVA270.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColIVA270.HeaderText = "IVA %27.0 $";
            this.ColIVA270.Name = "ColIVA270";
            this.ColIVA270.ReadOnly = true;
            this.ColIVA270.Width = 74;
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
            // ColCobroEstado
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.ColCobroEstado.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColCobroEstado.DisplayStyleForCurrentCellOnly = true;
            this.ColCobroEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColCobroEstado.HeaderText = "Estado de Cobro";
            this.ColCobroEstado.Items.AddRange(new object[] {
            "C/SALDO",
            "COBRADO",
            "S/COBRAR"});
            this.ColCobroEstado.Name = "ColCobroEstado";
            this.ColCobroEstado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCobroEstado.Sorted = true;
            this.ColCobroEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColCobroEstado.Width = 94;
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
            this.btnAgregarFila.TabIndex = 29;
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
            this.btnQuitarFila.TabIndex = 30;
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
            this.btnBuscarFila.TabIndex = 31;
            this.btnBuscarFila.UseVisualStyleBackColor = false;
            this.btnBuscarFila.Click += new System.EventHandler(this.btnBuscarFila_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(208, 352);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(98, 30);
            this.pictureBox4.TabIndex = 276;
            this.pictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 7F);
            this.label1.Location = new System.Drawing.Point(211, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Monto Bruto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(208, 337);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(98, 16);
            this.pictureBox3.TabIndex = 275;
            this.pictureBox3.TabStop = false;
            // 
            // lblIVA270
            // 
            this.lblIVA270.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblIVA270.BackColor = System.Drawing.Color.White;
            this.lblIVA270.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIVA270.Location = new System.Drawing.Point(341, 366);
            this.lblIVA270.Name = "lblIVA270";
            this.lblIVA270.Size = new System.Drawing.Size(65, 15);
            this.lblIVA270.TabIndex = 39;
            this.lblIVA270.Text = "0.00";
            this.lblIVA270.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIVA105
            // 
            this.lblIVA105.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblIVA105.BackColor = System.Drawing.Color.White;
            this.lblIVA105.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIVA105.Location = new System.Drawing.Point(341, 338);
            this.lblIVA105.Name = "lblIVA105";
            this.lblIVA105.Size = new System.Drawing.Size(65, 15);
            this.lblIVA105.TabIndex = 35;
            this.lblIVA105.Text = "0.00";
            this.lblIVA105.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIVA210
            // 
            this.lblIVA210.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblIVA210.BackColor = System.Drawing.Color.White;
            this.lblIVA210.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIVA210.Location = new System.Drawing.Point(341, 352);
            this.lblIVA210.Name = "lblIVA210";
            this.lblIVA210.Size = new System.Drawing.Size(65, 15);
            this.lblIVA210.TabIndex = 37;
            this.lblIVA210.Text = "0.00";
            this.lblIVA210.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label4.Location = new System.Drawing.Point(307, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 38;
            this.label4.Text = "%27.0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label3.Location = new System.Drawing.Point(307, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 36;
            this.label3.Text = "%21.0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label2.Location = new System.Drawing.Point(307, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "%10.5";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Location = new System.Drawing.Point(305, 337);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(102, 45);
            this.pictureBox5.TabIndex = 283;
            this.pictureBox5.TabStop = false;
            // 
            // txtRetencionLH
            // 
            this.txtRetencionLH.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtRetencionLH.BackColor = System.Drawing.Color.White;
            this.txtRetencionLH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRetencionLH.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtRetencionLH.ForeColor = System.Drawing.Color.Black;
            this.txtRetencionLH.Location = new System.Drawing.Point(444, 363);
            this.txtRetencionLH.MaxLength = 9;
            this.txtRetencionLH.Name = "txtRetencionLH";
            this.txtRetencionLH.ReadOnly = true;
            this.txtRetencionLH.Size = new System.Drawing.Size(65, 14);
            this.txtRetencionLH.TabIndex = 43;
            this.txtRetencionLH.Text = "0.00";
            this.txtRetencionLH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRetencionLH.Enter += new System.EventHandler(this.txtRetencionLH_Enter);
            this.txtRetencionLH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetencionLH_KeyPress);
            this.txtRetencionLH.Validated += new System.EventHandler(this.txtRetencionLH_Validated);
            // 
            // txtRetencionIIBB
            // 
            this.txtRetencionIIBB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtRetencionIIBB.BackColor = System.Drawing.Color.White;
            this.txtRetencionIIBB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRetencionIIBB.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtRetencionIIBB.ForeColor = System.Drawing.Color.Black;
            this.txtRetencionIIBB.Location = new System.Drawing.Point(444, 341);
            this.txtRetencionIIBB.MaxLength = 9;
            this.txtRetencionIIBB.Name = "txtRetencionIIBB";
            this.txtRetencionIIBB.ReadOnly = true;
            this.txtRetencionIIBB.Size = new System.Drawing.Size(65, 14);
            this.txtRetencionIIBB.TabIndex = 41;
            this.txtRetencionIIBB.Text = "0.00";
            this.txtRetencionIIBB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRetencionIIBB.Enter += new System.EventHandler(this.txtRetencionIIBB_Enter);
            this.txtRetencionIIBB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetencionIIBB_KeyPress);
            this.txtRetencionIIBB.Validated += new System.EventHandler(this.txtRetencionIIBB_Validated);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label6.Location = new System.Drawing.Point(411, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 42;
            this.label6.Text = "R. LH";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label5.Location = new System.Drawing.Point(411, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 40;
            this.label5.Text = "R. IIBB";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox7.BackColor = System.Drawing.Color.White;
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox7.Location = new System.Drawing.Point(409, 359);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(105, 23);
            this.pictureBox7.TabIndex = 285;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox6.BackColor = System.Drawing.Color.White;
            this.pictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox6.Location = new System.Drawing.Point(409, 337);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(105, 23);
            this.pictureBox6.TabIndex = 284;
            this.pictureBox6.TabStop = false;
            // 
            // txtRetencionSUSS
            // 
            this.txtRetencionSUSS.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtRetencionSUSS.BackColor = System.Drawing.Color.White;
            this.txtRetencionSUSS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRetencionSUSS.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtRetencionSUSS.ForeColor = System.Drawing.Color.Black;
            this.txtRetencionSUSS.Location = new System.Drawing.Point(719, 359);
            this.txtRetencionSUSS.MaxLength = 9;
            this.txtRetencionSUSS.Name = "txtRetencionSUSS";
            this.txtRetencionSUSS.ReadOnly = true;
            this.txtRetencionSUSS.Size = new System.Drawing.Size(89, 15);
            this.txtRetencionSUSS.TabIndex = 51;
            this.txtRetencionSUSS.Text = "0.00";
            this.txtRetencionSUSS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRetencionSUSS.Enter += new System.EventHandler(this.txtRetencionSUSS_Enter);
            this.txtRetencionSUSS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetencionSUSS_KeyPress);
            this.txtRetencionSUSS.Validated += new System.EventHandler(this.txtRetencionSUSS_Validated);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(810, 352);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 30);
            this.pictureBox1.TabIndex = 309;
            this.pictureBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Arial", 7F);
            this.label10.Location = new System.Drawing.Point(719, 339);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "Retención SUSS";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(810, 337);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(93, 16);
            this.pictureBox2.TabIndex = 308;
            this.pictureBox2.TabStop = false;
            // 
            // txtRetencionIVA
            // 
            this.txtRetencionIVA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtRetencionIVA.BackColor = System.Drawing.Color.White;
            this.txtRetencionIVA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRetencionIVA.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtRetencionIVA.ForeColor = System.Drawing.Color.Black;
            this.txtRetencionIVA.Location = new System.Drawing.Point(553, 341);
            this.txtRetencionIVA.MaxLength = 9;
            this.txtRetencionIVA.Name = "txtRetencionIVA";
            this.txtRetencionIVA.ReadOnly = true;
            this.txtRetencionIVA.Size = new System.Drawing.Size(65, 14);
            this.txtRetencionIVA.TabIndex = 45;
            this.txtRetencionIVA.Text = "0.00";
            this.txtRetencionIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRetencionIVA.Enter += new System.EventHandler(this.txtRetencionIVA_Enter);
            this.txtRetencionIVA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetencionIVA_KeyPress);
            this.txtRetencionIVA.Validated += new System.EventHandler(this.txtRetencionIVA_Validated);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label7.Location = new System.Drawing.Point(515, 340);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 44;
            this.label7.Text = "R. IVA";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox9.BackColor = System.Drawing.Color.White;
            this.pictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox9.Location = new System.Drawing.Point(513, 359);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(110, 23);
            this.pictureBox9.TabIndex = 305;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox8.BackColor = System.Drawing.Color.White;
            this.pictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox8.Location = new System.Drawing.Point(513, 337);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(110, 23);
            this.pictureBox8.TabIndex = 304;
            this.pictureBox8.TabStop = false;
            // 
            // txtRetencionGanancia
            // 
            this.txtRetencionGanancia.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtRetencionGanancia.BackColor = System.Drawing.Color.White;
            this.txtRetencionGanancia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRetencionGanancia.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtRetencionGanancia.ForeColor = System.Drawing.Color.Black;
            this.txtRetencionGanancia.Location = new System.Drawing.Point(553, 363);
            this.txtRetencionGanancia.MaxLength = 9;
            this.txtRetencionGanancia.Name = "txtRetencionGanancia";
            this.txtRetencionGanancia.ReadOnly = true;
            this.txtRetencionGanancia.Size = new System.Drawing.Size(65, 14);
            this.txtRetencionGanancia.TabIndex = 47;
            this.txtRetencionGanancia.Text = "0.00";
            this.txtRetencionGanancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRetencionGanancia.Enter += new System.EventHandler(this.txtRetencionGanancia_Enter);
            this.txtRetencionGanancia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetencionGanancia_KeyPress);
            this.txtRetencionGanancia.Validated += new System.EventHandler(this.txtRetencionGanancia_Validated);
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox11.BackColor = System.Drawing.Color.White;
            this.pictureBox11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox11.Location = new System.Drawing.Point(622, 352);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(95, 30);
            this.pictureBox11.TabIndex = 303;
            this.pictureBox11.TabStop = false;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label8.Location = new System.Drawing.Point(515, 363);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 46;
            this.label8.Text = "R. Gan.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox10.BackColor = System.Drawing.Color.White;
            this.pictureBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox10.Location = new System.Drawing.Point(622, 337);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(95, 16);
            this.pictureBox10.TabIndex = 302;
            this.pictureBox10.TabStop = false;
            // 
            // lblMontoNeto
            // 
            this.lblMontoNeto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblMontoNeto.BackColor = System.Drawing.Color.White;
            this.lblMontoNeto.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMontoNeto.ForeColor = System.Drawing.Color.Black;
            this.lblMontoNeto.Location = new System.Drawing.Point(905, 359);
            this.lblMontoNeto.Name = "lblMontoNeto";
            this.lblMontoNeto.Size = new System.Drawing.Size(92, 18);
            this.lblMontoNeto.TabIndex = 55;
            this.lblMontoNeto.Tag = "";
            this.lblMontoNeto.Text = "0.00";
            this.lblMontoNeto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(905, 338);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 54;
            this.label12.Text = "MONTO NETO";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox14
            // 
            this.pictureBox14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox14.BackColor = System.Drawing.Color.White;
            this.pictureBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox14.Location = new System.Drawing.Point(902, 337);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(98, 16);
            this.pictureBox14.TabIndex = 300;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox15.BackColor = System.Drawing.Color.White;
            this.pictureBox15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox15.Location = new System.Drawing.Point(902, 352);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(98, 30);
            this.pictureBox15.TabIndex = 301;
            this.pictureBox15.TabStop = false;
            // 
            // txtRetencionFondoMinero
            // 
            this.txtRetencionFondoMinero.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtRetencionFondoMinero.BackColor = System.Drawing.Color.White;
            this.txtRetencionFondoMinero.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRetencionFondoMinero.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtRetencionFondoMinero.ForeColor = System.Drawing.Color.Black;
            this.txtRetencionFondoMinero.Location = new System.Drawing.Point(625, 359);
            this.txtRetencionFondoMinero.MaxLength = 9;
            this.txtRetencionFondoMinero.Name = "txtRetencionFondoMinero";
            this.txtRetencionFondoMinero.ReadOnly = true;
            this.txtRetencionFondoMinero.Size = new System.Drawing.Size(89, 15);
            this.txtRetencionFondoMinero.TabIndex = 49;
            this.txtRetencionFondoMinero.Text = "0.00";
            this.txtRetencionFondoMinero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRetencionFondoMinero.Enter += new System.EventHandler(this.txtRetencionFondoMinero_Enter);
            this.txtRetencionFondoMinero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetencionFondoMinero_KeyPress);
            this.txtRetencionFondoMinero.Validated += new System.EventHandler(this.txtRetencionFondoMinero_Validated);
            // 
            // pictureBox13
            // 
            this.pictureBox13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox13.BackColor = System.Drawing.Color.White;
            this.pictureBox13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox13.Location = new System.Drawing.Point(716, 352);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(95, 30);
            this.pictureBox13.TabIndex = 299;
            this.pictureBox13.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Arial", 7F);
            this.label9.Location = new System.Drawing.Point(625, 339);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "R. Fondo Minero";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox12
            // 
            this.pictureBox12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox12.BackColor = System.Drawing.Color.White;
            this.pictureBox12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox12.Location = new System.Drawing.Point(716, 337);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(95, 16);
            this.pictureBox12.TabIndex = 298;
            this.pictureBox12.TabStop = false;
            // 
            // cmbMedioCobro
            // 
            this.cmbMedioCobro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbMedioCobro.BackColor = System.Drawing.Color.White;
            this.cmbMedioCobro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedioCobro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMedioCobro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbMedioCobro.ForeColor = System.Drawing.Color.Black;
            this.cmbMedioCobro.FormattingEnabled = true;
            this.cmbMedioCobro.Items.AddRange(new object[] {
            "CHEQUE",
            "EFECTIVO",
            "T.CREDITO",
            "T.DEBITO",
            "TRANSFERENCIA"});
            this.cmbMedioCobro.Location = new System.Drawing.Point(160, 387);
            this.cmbMedioCobro.Margin = new System.Windows.Forms.Padding(1);
            this.cmbMedioCobro.Name = "cmbMedioCobro";
            this.cmbMedioCobro.Size = new System.Drawing.Size(120, 22);
            this.cmbMedioCobro.Sorted = true;
            this.cmbMedioCobro.TabIndex = 60;
            this.cmbMedioCobro.SelectedIndexChanged += new System.EventHandler(this.cmbMedioCobro_SelectedIndexChanged);
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
            this.miLabel7.TabIndex = 59;
            this.miLabel7.Text = "Medio de cobro";
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
            this.cmbCuentaContable.TabIndex = 61;
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
            this.txtMedioNro.TabIndex = 63;
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
            this.lblMedioNro.TabIndex = 62;
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
            this.pkrMedioChequeVto.TabIndex = 64;
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
            this.txtCtaBancariaNro.TabIndex = 69;
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
            this.cmbCtaBancariaTipo.TabIndex = 68;
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
            this.btnCtaBancaria.TabIndex = 67;
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
            this.cmbCtaBancaria.TabIndex = 66;
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
            this.lblCtaBancaria.TabIndex = 65;
            this.lblCtaBancaria.Text = "Cuenta bancaria (cliente)";
            this.lblCtaBancaria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCtaBancaria.Visible = false;
            // 
            // groupRetencion
            // 
            this.groupRetencion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupRetencion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupRetencion.Controls.Add(this.chkRetencionGanancia);
            this.groupRetencion.Controls.Add(this.chkRetencionIIBB);
            this.groupRetencion.Controls.Add(this.chkRetencionSUSS);
            this.groupRetencion.Controls.Add(this.chkRetencionFondoMinero);
            this.groupRetencion.Controls.Add(this.chkRetencionIVA);
            this.groupRetencion.Controls.Add(this.chkRetencionLH);
            this.groupRetencion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupRetencion.ForeColor = System.Drawing.Color.Gray;
            this.groupRetencion.Location = new System.Drawing.Point(837, 55);
            this.groupRetencion.Name = "groupRetencion";
            this.groupRetencion.Size = new System.Drawing.Size(163, 82);
            this.groupRetencion.TabIndex = 27;
            this.groupRetencion.TabStop = false;
            this.groupRetencion.Text = "Retenciones";
            // 
            // chkRetencionGanancia
            // 
            this.chkRetencionGanancia.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkRetencionGanancia.AutoSize = true;
            this.chkRetencionGanancia.BackColor = System.Drawing.Color.Transparent;
            this.chkRetencionGanancia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkRetencionGanancia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetencionGanancia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkRetencionGanancia.Location = new System.Drawing.Point(58, 18);
            this.chkRetencionGanancia.Name = "chkRetencionGanancia";
            this.chkRetencionGanancia.Size = new System.Drawing.Size(86, 19);
            this.chkRetencionGanancia.TabIndex = 8;
            this.chkRetencionGanancia.Text = "Ganancias";
            this.chkRetencionGanancia.UseVisualStyleBackColor = false;
            this.chkRetencionGanancia.CheckedChanged += new System.EventHandler(this.chkRetencionGanancia_CheckedChanged);
            // 
            // chkRetencionIIBB
            // 
            this.chkRetencionIIBB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkRetencionIIBB.AutoSize = true;
            this.chkRetencionIIBB.BackColor = System.Drawing.Color.Transparent;
            this.chkRetencionIIBB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkRetencionIIBB.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetencionIIBB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkRetencionIIBB.Location = new System.Drawing.Point(6, 18);
            this.chkRetencionIIBB.Name = "chkRetencionIIBB";
            this.chkRetencionIIBB.Size = new System.Drawing.Size(48, 19);
            this.chkRetencionIIBB.TabIndex = 5;
            this.chkRetencionIIBB.Text = "IIBB";
            this.chkRetencionIIBB.UseVisualStyleBackColor = false;
            this.chkRetencionIIBB.CheckedChanged += new System.EventHandler(this.chkRetencionIIBB_CheckedChanged);
            // 
            // chkRetencionSUSS
            // 
            this.chkRetencionSUSS.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkRetencionSUSS.AutoSize = true;
            this.chkRetencionSUSS.BackColor = System.Drawing.Color.Transparent;
            this.chkRetencionSUSS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkRetencionSUSS.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetencionSUSS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkRetencionSUSS.Location = new System.Drawing.Point(58, 60);
            this.chkRetencionSUSS.Name = "chkRetencionSUSS";
            this.chkRetencionSUSS.Size = new System.Drawing.Size(59, 19);
            this.chkRetencionSUSS.TabIndex = 10;
            this.chkRetencionSUSS.Text = "SUSS";
            this.chkRetencionSUSS.UseVisualStyleBackColor = false;
            this.chkRetencionSUSS.CheckedChanged += new System.EventHandler(this.chkRetencionSUSS_CheckedChanged);
            // 
            // chkRetencionFondoMinero
            // 
            this.chkRetencionFondoMinero.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkRetencionFondoMinero.AutoSize = true;
            this.chkRetencionFondoMinero.BackColor = System.Drawing.Color.Transparent;
            this.chkRetencionFondoMinero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkRetencionFondoMinero.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetencionFondoMinero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkRetencionFondoMinero.Location = new System.Drawing.Point(58, 39);
            this.chkRetencionFondoMinero.Name = "chkRetencionFondoMinero";
            this.chkRetencionFondoMinero.Size = new System.Drawing.Size(103, 19);
            this.chkRetencionFondoMinero.TabIndex = 9;
            this.chkRetencionFondoMinero.Text = "Fondo minero";
            this.chkRetencionFondoMinero.UseVisualStyleBackColor = false;
            this.chkRetencionFondoMinero.CheckedChanged += new System.EventHandler(this.chkRetencionFondoMinero_CheckedChanged);
            // 
            // chkRetencionIVA
            // 
            this.chkRetencionIVA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkRetencionIVA.AutoSize = true;
            this.chkRetencionIVA.BackColor = System.Drawing.Color.Transparent;
            this.chkRetencionIVA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkRetencionIVA.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetencionIVA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkRetencionIVA.Location = new System.Drawing.Point(6, 60);
            this.chkRetencionIVA.Name = "chkRetencionIVA";
            this.chkRetencionIVA.Size = new System.Drawing.Size(42, 19);
            this.chkRetencionIVA.TabIndex = 7;
            this.chkRetencionIVA.Text = "IVA";
            this.chkRetencionIVA.UseVisualStyleBackColor = false;
            this.chkRetencionIVA.CheckedChanged += new System.EventHandler(this.chkRetencionIVA_CheckedChanged);
            // 
            // chkRetencionLH
            // 
            this.chkRetencionLH.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkRetencionLH.AutoSize = true;
            this.chkRetencionLH.BackColor = System.Drawing.Color.Transparent;
            this.chkRetencionLH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkRetencionLH.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetencionLH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkRetencionLH.Location = new System.Drawing.Point(6, 39);
            this.chkRetencionLH.Name = "chkRetencionLH";
            this.chkRetencionLH.Size = new System.Drawing.Size(42, 19);
            this.chkRetencionLH.TabIndex = 6;
            this.chkRetencionLH.Text = "LH";
            this.chkRetencionLH.UseVisualStyleBackColor = false;
            this.chkRetencionLH.CheckedChanged += new System.EventHandler(this.chkRetencionLH_CheckedChanged);
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
            // txtLiquidacion
            // 
            this.txtLiquidacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtLiquidacion.BackColor = System.Drawing.Color.White;
            this.txtLiquidacion.BeepOnError = true;
            this.txtLiquidacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLiquidacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtLiquidacion.ForeColor = System.Drawing.Color.Black;
            this.txtLiquidacion.HidePromptOnLeave = true;
            this.txtLiquidacion.Location = new System.Drawing.Point(522, 61);
            this.txtLiquidacion.Mask = "999999999999";
            this.txtLiquidacion.Name = "txtLiquidacion";
            this.txtLiquidacion.PromptChar = ' ';
            this.txtLiquidacion.Size = new System.Drawing.Size(88, 22);
            this.txtLiquidacion.TabIndex = 18;
            // 
            // lblTotalRetencion
            // 
            this.lblTotalRetencion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalRetencion.BackColor = System.Drawing.Color.White;
            this.lblTotalRetencion.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalRetencion.Location = new System.Drawing.Point(813, 359);
            this.lblTotalRetencion.Name = "lblTotalRetencion";
            this.lblTotalRetencion.Size = new System.Drawing.Size(87, 18);
            this.lblTotalRetencion.TabIndex = 53;
            this.lblTotalRetencion.Text = "0.00";
            this.lblTotalRetencion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Arial", 7F);
            this.label11.Location = new System.Drawing.Point(813, 338);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 52;
            this.label11.Text = "T. Retenciones";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMontoBruto
            // 
            this.txtMontoBruto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtMontoBruto.BackColor = System.Drawing.Color.White;
            this.txtMontoBruto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMontoBruto.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtMontoBruto.ForeColor = System.Drawing.Color.Black;
            this.txtMontoBruto.Location = new System.Drawing.Point(211, 359);
            this.txtMontoBruto.MaxLength = 9;
            this.txtMontoBruto.Name = "txtMontoBruto";
            this.txtMontoBruto.Size = new System.Drawing.Size(92, 15);
            this.txtMontoBruto.TabIndex = 33;
            this.txtMontoBruto.Text = "0.00";
            this.txtMontoBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMontoBruto.Enter += new System.EventHandler(this.txtMontoBruto_Enter);
            this.txtMontoBruto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoBruto_KeyPress);
            this.txtMontoBruto.Validated += new System.EventHandler(this.txtMontoBruto_Validated);
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
            this.miLabel6.TabIndex = 310;
            this.miLabel6.Text = "Cuenta Contable (destino)";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormCobranza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.txtMontoBruto);
            this.Controls.Add(this.lblTotalRetencion);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRetencionSUSS);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtRetencionFondoMinero);
            this.Controls.Add(this.label9);
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
            this.Controls.Add(this.cmbMedioCobro);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtRetencionIVA);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRetencionGanancia);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.lblMontoNeto);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pictureBox14);
            this.Controls.Add(this.pictureBox15);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.txtRetencionLH);
            this.Controls.Add(this.txtRetencionIIBB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.lblIVA270);
            this.Controls.Add(this.lblIVA105);
            this.Controls.Add(this.lblIVA210);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox5);
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
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.txtDenominacion);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.pkrCbteFecha);
            this.Controls.Add(this.txtCbteNro);
            this.Controls.Add(this.txtCbteTPV);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.groupRetencion);
            this.Controls.Add(this.txtLiquidacion);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Name = "FormCobranza";
            this.Text = "Cobranzas";
            this.Load += new System.EventHandler(this.FormCobranza_Load);
            this.Controls.SetChildIndex(this.pictureBox8, 0);
            this.Controls.SetChildIndex(this.pictureBox9, 0);
            this.Controls.SetChildIndex(this.txtLiquidacion, 0);
            this.Controls.SetChildIndex(this.groupRetencion, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.txtCbteTPV, 0);
            this.Controls.SetChildIndex(this.txtCbteNro, 0);
            this.Controls.SetChildIndex(this.pkrCbteFecha, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.btnBuscarCliente, 0);
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
            this.Controls.SetChildIndex(this.pictureBox5, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblIVA210, 0);
            this.Controls.SetChildIndex(this.lblIVA105, 0);
            this.Controls.SetChildIndex(this.lblIVA270, 0);
            this.Controls.SetChildIndex(this.pictureBox6, 0);
            this.Controls.SetChildIndex(this.pictureBox7, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtRetencionIIBB, 0);
            this.Controls.SetChildIndex(this.txtRetencionLH, 0);
            this.Controls.SetChildIndex(this.pictureBox12, 0);
            this.Controls.SetChildIndex(this.pictureBox13, 0);
            this.Controls.SetChildIndex(this.pictureBox15, 0);
            this.Controls.SetChildIndex(this.pictureBox14, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.lblMontoNeto, 0);
            this.Controls.SetChildIndex(this.pictureBox10, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.pictureBox11, 0);
            this.Controls.SetChildIndex(this.txtRetencionGanancia, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtRetencionIVA, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.cmbMedioCobro, 0);
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
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtRetencionFondoMinero, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtRetencionSUSS, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.lblTotalRetencion, 0);
            this.Controls.SetChildIndex(this.txtMontoBruto, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.groupRetencion.ResumeLayout(false);
            this.groupRetencion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Biblioteca.Controles.MiTextBoxRead txtCbteTPV;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBoxRead txtCbteNro;
        private Biblioteca.Controles.MiDateTimePicker pkrCbteFecha;
        private Biblioteca.Controles.MiTextBoxRead txtEstado;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiButtonFind btnBuscarCliente;
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
        public System.Windows.Forms.Label lblIVA270;
        public System.Windows.Forms.Label lblIVA105;
        public System.Windows.Forms.Label lblIVA210;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.PictureBox pictureBox5;
        public Biblioteca.Controles.MiTextBox txtRetencionLH;
        public Biblioteca.Controles.MiTextBox txtRetencionIIBB;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.PictureBox pictureBox7;
        public System.Windows.Forms.PictureBox pictureBox6;
        public Biblioteca.Controles.MiTextBox txtRetencionSUSS;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.PictureBox pictureBox2;
        public Biblioteca.Controles.MiTextBox txtRetencionIVA;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.PictureBox pictureBox9;
        public System.Windows.Forms.PictureBox pictureBox8;
        public Biblioteca.Controles.MiTextBox txtRetencionGanancia;
        public System.Windows.Forms.PictureBox pictureBox11;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.PictureBox pictureBox10;
        public System.Windows.Forms.Label lblMontoNeto;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.PictureBox pictureBox14;
        public System.Windows.Forms.PictureBox pictureBox15;
        public Biblioteca.Controles.MiTextBox txtRetencionFondoMinero;
        public System.Windows.Forms.PictureBox pictureBox13;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.PictureBox pictureBox12;
        private Biblioteca.Controles.MiComboBox cmbMedioCobro;
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
        private System.Windows.Forms.GroupBox groupRetencion;
        private Biblioteca.Controles.MiCheckBox chkRetencionGanancia;
        private Biblioteca.Controles.MiCheckBox chkRetencionIIBB;
        private Biblioteca.Controles.MiCheckBox chkRetencionSUSS;
        private Biblioteca.Controles.MiCheckBox chkRetencionFondoMinero;
        private Biblioteca.Controles.MiCheckBox chkRetencionIVA;
        private Biblioteca.Controles.MiCheckBox chkRetencionLH;
        private Biblioteca.Controles.MiButtonBase btnWord_Acuse;
        private Biblioteca.Controles.MiMaskedTextBox txtLiquidacion;
        public System.Windows.Forms.Label lblTotalRetencion;
        public System.Windows.Forms.Label label11;
        public Biblioteca.Controles.MiTextBox txtMontoBruto;
        private Biblioteca.Controles.MiLabel miLabel6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIVA105;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIVA210;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIVA270;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalNeto;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColCobroEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColModificacionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNula;
    }
}
