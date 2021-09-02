namespace CapaPresentacion
{
    partial class FormProveedor
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
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.txtCuit = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.cmbCategoriaIva = new Biblioteca.Controles.MiComboBox();
            this.txtCodigoPostal = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.cmbDistrito = new Biblioteca.Controles.MiComboBox();
            this.cmbProvincia = new Biblioteca.Controles.MiComboBox();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.txtDomicilio = new Biblioteca.Controles.MiTextBox();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.txtEmail = new Biblioteca.Controles.MiTextBox();
            this.miLabel10 = new Biblioteca.Controles.MiLabel();
            this.txtCelular = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel9 = new Biblioteca.Controles.MiLabel();
            this.txtTelefono = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel8 = new Biblioteca.Controles.MiLabel();
            this.txtPaginaWeb = new Biblioteca.Controles.MiTextBox();
            this.txtCtaBancariaNro = new Biblioteca.Controles.MiMaskedTextBox();
            this.cmbCtaBancariaTipo = new Biblioteca.Controles.MiComboBox();
            this.btnCtaBancaria = new Biblioteca.Controles.MiButtonFind();
            this.cmbCtaBancaria = new Biblioteca.Controles.MiComboBox();
            this.miLabel12 = new Biblioteca.Controles.MiLabel();
            this.miLabel11 = new Biblioteca.Controles.MiLabel();
            this.cmbEstado = new Biblioteca.Controles.MiComboBox();
            this.miLabel15 = new Biblioteca.Controles.MiLabel();
            this.tabContenedor = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtContactoEmail = new Biblioteca.Controles.MiTextBox();
            this.txtContactoDenominacion = new Biblioteca.Controles.MiTextBox();
            this.miLabel19 = new Biblioteca.Controles.MiLabel();
            this.miLabel16 = new Biblioteca.Controles.MiLabel();
            this.txtContactoCelular = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel17 = new Biblioteca.Controles.MiLabel();
            this.miLabel18 = new Biblioteca.Controles.MiLabel();
            this.txtContactoTelefono = new Biblioteca.Controles.MiMaskedTextBox();
            this.txtSaldo = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel14 = new Biblioteca.Controles.MiLabel();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.txtNombreFantasia = new Biblioteca.Controles.MiTextBox();
            this.cmbCuentaContable = new Biblioteca.Controles.MiComboBox();
            this.miLabel13 = new Biblioteca.Controles.MiLabel();
            this.panelLista.SuspendLayout();
            this.tabContenedor.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.btnAnular.Enabled = false;
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAnular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAnular.TabIndex = 8;
            this.btnAnular.Visible = false;
            // 
            // btnExcel_Registro
            // 
            this.btnExcel_Registro.FlatAppearance.BorderSize = 0;
            this.btnExcel_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Registro.Location = new System.Drawing.Point(241, 657);
            this.btnExcel_Registro.TabIndex = 6;
            // 
            // btnPDF_Registro
            // 
            this.btnPDF_Registro.FlatAppearance.BorderSize = 0;
            this.btnPDF_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Registro.Location = new System.Drawing.Point(273, 657);
            this.btnPDF_Registro.TabIndex = 7;
            // 
            // lblTituloLista
            // 
            this.lblTituloLista.Text = "Lista de Proveedores";
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
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(343, 36);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(103, 14);
            this.lblCatalagoTitulo3.Text = "Nombre de Fantasía";
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(504, 36);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(29, 14);
            this.lblCatalagoTitulo4.Text = "CUIT";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(616, 36);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(34, 14);
            this.lblCatalagoTitulo5.Text = "Saldo";
            // 
            // panelLista
            // 
            this.panelLista.TabIndex = 10;
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(721, 36);
            this.lblCatalagoTitulo6.Size = new System.Drawing.Size(40, 14);
            this.lblCatalagoTitulo6.Text = "Estado";
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Proveedores";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 9;
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
            this.miLabel1.Text = "Razón social";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenominacion
            // 
            this.txtDenominacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDenominacion.BackColor = System.Drawing.Color.White;
            this.txtDenominacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDenominacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDenominacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtDenominacion.ForeColor = System.Drawing.Color.Black;
            this.txtDenominacion.Location = new System.Drawing.Point(160, 61);
            this.txtDenominacion.MaxLength = 35;
            this.txtDenominacion.Name = "txtDenominacion";
            this.txtDenominacion.Size = new System.Drawing.Size(315, 22);
            this.txtDenominacion.TabIndex = 12;
            this.txtDenominacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDenominacion_KeyPress);
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
            this.miLabel3.TabIndex = 15;
            this.miLabel3.Text = "CUIT";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCuit
            // 
            this.txtCuit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCuit.BackColor = System.Drawing.Color.White;
            this.txtCuit.BeepOnError = true;
            this.txtCuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuit.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCuit.ForeColor = System.Drawing.Color.Black;
            this.txtCuit.HidePromptOnLeave = true;
            this.txtCuit.Location = new System.Drawing.Point(160, 115);
            this.txtCuit.Mask = "99999999999";
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.PromptChar = ' ';
            this.txtCuit.Size = new System.Drawing.Size(100, 22);
            this.txtCuit.TabIndex = 16;
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
            this.miLabel4.TabIndex = 17;
            this.miLabel4.Text = "Categoría IVA";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCategoriaIva
            // 
            this.cmbCategoriaIva.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbCategoriaIva.BackColor = System.Drawing.Color.White;
            this.cmbCategoriaIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriaIva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategoriaIva.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCategoriaIva.ForeColor = System.Drawing.Color.Black;
            this.cmbCategoriaIva.FormattingEnabled = true;
            this.cmbCategoriaIva.ItemHeight = 14;
            this.cmbCategoriaIva.Items.AddRange(new object[] {
            "CONSUMIDOR FINAL",
            "RESPONSABLE INSCRIPTO",
            "RESPONSABLE MONOTRIBUTO",
            "SUJETO EXENTO"});
            this.cmbCategoriaIva.Location = new System.Drawing.Point(160, 142);
            this.cmbCategoriaIva.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCategoriaIva.Name = "cmbCategoriaIva";
            this.cmbCategoriaIva.Size = new System.Drawing.Size(185, 22);
            this.cmbCategoriaIva.Sorted = true;
            this.cmbCategoriaIva.TabIndex = 18;
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCodigoPostal.BackColor = System.Drawing.Color.White;
            this.txtCodigoPostal.BeepOnError = true;
            this.txtCodigoPostal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoPostal.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCodigoPostal.ForeColor = System.Drawing.Color.Black;
            this.txtCodigoPostal.HidePromptOnLeave = true;
            this.txtCodigoPostal.Location = new System.Drawing.Point(475, 196);
            this.txtCodigoPostal.Mask = "99999";
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.PromptChar = ' ';
            this.txtCodigoPostal.Size = new System.Drawing.Size(45, 22);
            this.txtCodigoPostal.TabIndex = 25;
            this.txtCodigoPostal.ValidatingType = typeof(int);
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(447, 199);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(28, 15);
            this.miLabel7.TabIndex = 24;
            this.miLabel7.Text = "C.P.";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDistrito
            // 
            this.cmbDistrito.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbDistrito.BackColor = System.Drawing.Color.White;
            this.cmbDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDistrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDistrito.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbDistrito.ForeColor = System.Drawing.Color.Black;
            this.cmbDistrito.FormattingEnabled = true;
            this.cmbDistrito.ItemHeight = 14;
            this.cmbDistrito.Location = new System.Drawing.Point(317, 196);
            this.cmbDistrito.Margin = new System.Windows.Forms.Padding(1);
            this.cmbDistrito.MaxLength = 20;
            this.cmbDistrito.Name = "cmbDistrito";
            this.cmbDistrito.Size = new System.Drawing.Size(122, 22);
            this.cmbDistrito.Sorted = true;
            this.cmbDistrito.TabIndex = 23;
            this.cmbDistrito.SelectedIndexChanged += new System.EventHandler(this.cmbDistrito_SelectedIndexChanged);
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbProvincia.BackColor = System.Drawing.Color.White;
            this.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProvincia.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbProvincia.ForeColor = System.Drawing.Color.Black;
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.ItemHeight = 14;
            this.cmbProvincia.Items.AddRange(new object[] {
            "BUENOS AIRES",
            "CATAMARA",
            "CHACO",
            "CHUBUT",
            "CORDOBA",
            "CORRIENTES",
            "ENTRE RIOS",
            "FORMOSA",
            "JUJUY",
            "LA PAMPA",
            "LA RIOJA",
            "MENDOZA",
            "MISIONES",
            "NEUQUEN",
            "RIO NEGRO",
            "SALTA",
            "SAN JUAN",
            "SAN LUIS",
            "SANTA CRUZ",
            "SANTA FE",
            "SANTIAGO DEL ESTERO",
            "TIERRA DEL FUEGO",
            "TUCUMAN"});
            this.cmbProvincia.Location = new System.Drawing.Point(160, 196);
            this.cmbProvincia.Margin = new System.Windows.Forms.Padding(1);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(155, 22);
            this.cmbProvincia.Sorted = true;
            this.cmbProvincia.TabIndex = 22;
            this.cmbProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);
            this.cmbProvincia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDistrito_KeyPress);
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
            this.miLabel6.TabIndex = 21;
            this.miLabel6.Text = "Provincia - Distrito";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDomicilio.BackColor = System.Drawing.Color.White;
            this.txtDomicilio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDomicilio.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtDomicilio.ForeColor = System.Drawing.Color.Black;
            this.txtDomicilio.Location = new System.Drawing.Point(160, 169);
            this.txtDomicilio.MaxLength = 50;
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(360, 22);
            this.txtDomicilio.TabIndex = 20;
            this.txtDomicilio.Validated += new System.EventHandler(this.txtDomicilio_Validated);
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
            this.miLabel5.TabIndex = 19;
            this.miLabel5.Text = "Domicilio";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(160, 277);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(360, 22);
            this.txtEmail.TabIndex = 31;
            // 
            // miLabel10
            // 
            this.miLabel10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel10.BackColor = System.Drawing.Color.Transparent;
            this.miLabel10.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel10.Location = new System.Drawing.Point(0, 280);
            this.miLabel10.Name = "miLabel10";
            this.miLabel10.Size = new System.Drawing.Size(160, 15);
            this.miLabel10.TabIndex = 30;
            this.miLabel10.Text = "E-mail";
            this.miLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCelular
            // 
            this.txtCelular.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCelular.BackColor = System.Drawing.Color.White;
            this.txtCelular.BeepOnError = true;
            this.txtCelular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCelular.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCelular.ForeColor = System.Drawing.Color.Black;
            this.txtCelular.HidePromptOnLeave = true;
            this.txtCelular.Location = new System.Drawing.Point(160, 250);
            this.txtCelular.Mask = "9999999999999";
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.PromptChar = ' ';
            this.txtCelular.Size = new System.Drawing.Size(100, 22);
            this.txtCelular.TabIndex = 29;
            // 
            // miLabel9
            // 
            this.miLabel9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel9.BackColor = System.Drawing.Color.Transparent;
            this.miLabel9.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel9.Location = new System.Drawing.Point(0, 253);
            this.miLabel9.Name = "miLabel9";
            this.miLabel9.Size = new System.Drawing.Size(160, 15);
            this.miLabel9.TabIndex = 28;
            this.miLabel9.Text = "Celular";
            this.miLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTelefono.BackColor = System.Drawing.Color.White;
            this.txtTelefono.BeepOnError = true;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtTelefono.ForeColor = System.Drawing.Color.Black;
            this.txtTelefono.HidePromptOnLeave = true;
            this.txtTelefono.Location = new System.Drawing.Point(160, 223);
            this.txtTelefono.Mask = "9999999999999";
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.PromptChar = ' ';
            this.txtTelefono.Size = new System.Drawing.Size(100, 22);
            this.txtTelefono.TabIndex = 27;
            this.txtTelefono.ValidatingType = typeof(int);
            // 
            // miLabel8
            // 
            this.miLabel8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel8.BackColor = System.Drawing.Color.Transparent;
            this.miLabel8.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel8.Location = new System.Drawing.Point(0, 226);
            this.miLabel8.Name = "miLabel8";
            this.miLabel8.Size = new System.Drawing.Size(160, 15);
            this.miLabel8.TabIndex = 26;
            this.miLabel8.Text = "Teléfono";
            this.miLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPaginaWeb
            // 
            this.txtPaginaWeb.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPaginaWeb.BackColor = System.Drawing.Color.White;
            this.txtPaginaWeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaginaWeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtPaginaWeb.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtPaginaWeb.ForeColor = System.Drawing.Color.Black;
            this.txtPaginaWeb.Location = new System.Drawing.Point(160, 304);
            this.txtPaginaWeb.MaxLength = 50;
            this.txtPaginaWeb.Name = "txtPaginaWeb";
            this.txtPaginaWeb.Size = new System.Drawing.Size(360, 22);
            this.txtPaginaWeb.TabIndex = 33;
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
            this.txtCtaBancariaNro.Location = new System.Drawing.Point(431, 331);
            this.txtCtaBancariaNro.Mask = "9999999999";
            this.txtCtaBancariaNro.Name = "txtCtaBancariaNro";
            this.txtCtaBancariaNro.PromptChar = ' ';
            this.txtCtaBancariaNro.Size = new System.Drawing.Size(89, 22);
            this.txtCtaBancariaNro.TabIndex = 38;
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
            this.cmbCtaBancariaTipo.Location = new System.Drawing.Point(375, 331);
            this.cmbCtaBancariaTipo.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCtaBancariaTipo.Name = "cmbCtaBancariaTipo";
            this.cmbCtaBancariaTipo.Size = new System.Drawing.Size(55, 22);
            this.cmbCtaBancariaTipo.Sorted = true;
            this.cmbCtaBancariaTipo.TabIndex = 37;
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
            this.btnCtaBancaria.Location = new System.Drawing.Point(346, 330);
            this.btnCtaBancaria.Name = "btnCtaBancaria";
            this.btnCtaBancaria.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCtaBancaria.Size = new System.Drawing.Size(24, 24);
            this.btnCtaBancaria.TabIndex = 36;
            this.btnCtaBancaria.UseVisualStyleBackColor = false;
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
            this.cmbCtaBancaria.Location = new System.Drawing.Point(160, 331);
            this.cmbCtaBancaria.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCtaBancaria.Name = "cmbCtaBancaria";
            this.cmbCtaBancaria.Size = new System.Drawing.Size(185, 22);
            this.cmbCtaBancaria.Sorted = true;
            this.cmbCtaBancaria.TabIndex = 35;
            this.cmbCtaBancaria.SelectedIndexChanged += new System.EventHandler(this.cmbCtaBancaria_SelectedIndexChanged);
            // 
            // miLabel12
            // 
            this.miLabel12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel12.BackColor = System.Drawing.Color.Transparent;
            this.miLabel12.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel12.Location = new System.Drawing.Point(0, 334);
            this.miLabel12.Name = "miLabel12";
            this.miLabel12.Size = new System.Drawing.Size(160, 15);
            this.miLabel12.TabIndex = 34;
            this.miLabel12.Text = "Cuenta bancaria";
            this.miLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel11
            // 
            this.miLabel11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel11.BackColor = System.Drawing.Color.Transparent;
            this.miLabel11.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel11.Location = new System.Drawing.Point(0, 307);
            this.miLabel11.Name = "miLabel11";
            this.miLabel11.Size = new System.Drawing.Size(160, 15);
            this.miLabel11.TabIndex = 32;
            this.miLabel11.Text = "Página WEB";
            this.miLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbEstado
            // 
            this.cmbEstado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbEstado.BackColor = System.Drawing.Color.White;
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbEstado.ForeColor = System.Drawing.Color.Black;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.ItemHeight = 14;
            this.cmbEstado.Items.AddRange(new object[] {
            "ACTIVO",
            "BAJA"});
            this.cmbEstado.Location = new System.Drawing.Point(160, 412);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(1);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(95, 22);
            this.cmbEstado.Sorted = true;
            this.cmbEstado.TabIndex = 44;
            // 
            // miLabel15
            // 
            this.miLabel15.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel15.BackColor = System.Drawing.Color.Transparent;
            this.miLabel15.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel15.Location = new System.Drawing.Point(0, 415);
            this.miLabel15.Name = "miLabel15";
            this.miLabel15.Size = new System.Drawing.Size(160, 15);
            this.miLabel15.TabIndex = 43;
            this.miLabel15.Text = "Estado";
            this.miLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabContenedor
            // 
            this.tabContenedor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tabContenedor.Controls.Add(this.tabPage1);
            this.tabContenedor.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tabContenedor.Location = new System.Drawing.Point(532, 61);
            this.tabContenedor.Name = "tabContenedor";
            this.tabContenedor.SelectedIndex = 0;
            this.tabContenedor.Size = new System.Drawing.Size(468, 455);
            this.tabContenedor.TabIndex = 45;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.txtContactoEmail);
            this.tabPage1.Controls.Add(this.txtContactoDenominacion);
            this.tabPage1.Controls.Add(this.miLabel19);
            this.tabPage1.Controls.Add(this.miLabel16);
            this.tabPage1.Controls.Add(this.txtContactoCelular);
            this.tabPage1.Controls.Add(this.miLabel17);
            this.tabPage1.Controls.Add(this.miLabel18);
            this.tabPage1.Controls.Add(this.txtContactoTelefono);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(460, 429);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos del Contacto";
            // 
            // txtContactoEmail
            // 
            this.txtContactoEmail.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtContactoEmail.BackColor = System.Drawing.Color.White;
            this.txtContactoEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactoEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtContactoEmail.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtContactoEmail.ForeColor = System.Drawing.Color.Black;
            this.txtContactoEmail.Location = new System.Drawing.Point(160, 94);
            this.txtContactoEmail.MaxLength = 50;
            this.txtContactoEmail.Name = "txtContactoEmail";
            this.txtContactoEmail.Size = new System.Drawing.Size(294, 22);
            this.txtContactoEmail.TabIndex = 7;
            // 
            // txtContactoDenominacion
            // 
            this.txtContactoDenominacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtContactoDenominacion.BackColor = System.Drawing.Color.White;
            this.txtContactoDenominacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactoDenominacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactoDenominacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtContactoDenominacion.ForeColor = System.Drawing.Color.Black;
            this.txtContactoDenominacion.Location = new System.Drawing.Point(160, 12);
            this.txtContactoDenominacion.MaxLength = 30;
            this.txtContactoDenominacion.Name = "txtContactoDenominacion";
            this.txtContactoDenominacion.Size = new System.Drawing.Size(230, 22);
            this.txtContactoDenominacion.TabIndex = 1;
            // 
            // miLabel19
            // 
            this.miLabel19.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel19.BackColor = System.Drawing.Color.Transparent;
            this.miLabel19.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel19.Location = new System.Drawing.Point(0, 97);
            this.miLabel19.Name = "miLabel19";
            this.miLabel19.Size = new System.Drawing.Size(160, 15);
            this.miLabel19.TabIndex = 6;
            this.miLabel19.Text = "E-mail";
            this.miLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel16
            // 
            this.miLabel16.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel16.BackColor = System.Drawing.Color.Transparent;
            this.miLabel16.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel16.Location = new System.Drawing.Point(0, 15);
            this.miLabel16.Name = "miLabel16";
            this.miLabel16.Size = new System.Drawing.Size(160, 15);
            this.miLabel16.TabIndex = 0;
            this.miLabel16.Text = "Apellido(s) y Nombre(s)";
            this.miLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtContactoCelular
            // 
            this.txtContactoCelular.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtContactoCelular.BackColor = System.Drawing.Color.White;
            this.txtContactoCelular.BeepOnError = true;
            this.txtContactoCelular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactoCelular.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtContactoCelular.ForeColor = System.Drawing.Color.Black;
            this.txtContactoCelular.HidePromptOnLeave = true;
            this.txtContactoCelular.Location = new System.Drawing.Point(160, 66);
            this.txtContactoCelular.Mask = "9999999999999";
            this.txtContactoCelular.Name = "txtContactoCelular";
            this.txtContactoCelular.PromptChar = ' ';
            this.txtContactoCelular.Size = new System.Drawing.Size(100, 22);
            this.txtContactoCelular.TabIndex = 5;
            // 
            // miLabel17
            // 
            this.miLabel17.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel17.BackColor = System.Drawing.Color.Transparent;
            this.miLabel17.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel17.Location = new System.Drawing.Point(0, 42);
            this.miLabel17.Name = "miLabel17";
            this.miLabel17.Size = new System.Drawing.Size(160, 15);
            this.miLabel17.TabIndex = 2;
            this.miLabel17.Text = "Teléfono";
            this.miLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel18
            // 
            this.miLabel18.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel18.BackColor = System.Drawing.Color.Transparent;
            this.miLabel18.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel18.Location = new System.Drawing.Point(0, 69);
            this.miLabel18.Name = "miLabel18";
            this.miLabel18.Size = new System.Drawing.Size(160, 15);
            this.miLabel18.TabIndex = 4;
            this.miLabel18.Text = "Celular";
            this.miLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtContactoTelefono
            // 
            this.txtContactoTelefono.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtContactoTelefono.BackColor = System.Drawing.Color.White;
            this.txtContactoTelefono.BeepOnError = true;
            this.txtContactoTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactoTelefono.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtContactoTelefono.ForeColor = System.Drawing.Color.Black;
            this.txtContactoTelefono.HidePromptOnLeave = true;
            this.txtContactoTelefono.Location = new System.Drawing.Point(160, 39);
            this.txtContactoTelefono.Mask = "9999999999999";
            this.txtContactoTelefono.Name = "txtContactoTelefono";
            this.txtContactoTelefono.PromptChar = ' ';
            this.txtContactoTelefono.Size = new System.Drawing.Size(100, 22);
            this.txtContactoTelefono.TabIndex = 3;
            this.txtContactoTelefono.ValidatingType = typeof(int);
            // 
            // txtSaldo
            // 
            this.txtSaldo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaldo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtSaldo.ForeColor = System.Drawing.Color.Black;
            this.txtSaldo.Location = new System.Drawing.Point(160, 385);
            this.txtSaldo.MaxLength = 10;
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(85, 22);
            this.txtSaldo.TabIndex = 42;
            // 
            // miLabel14
            // 
            this.miLabel14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel14.BackColor = System.Drawing.Color.Transparent;
            this.miLabel14.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel14.Location = new System.Drawing.Point(0, 388);
            this.miLabel14.Name = "miLabel14";
            this.miLabel14.Size = new System.Drawing.Size(160, 15);
            this.miLabel14.TabIndex = 41;
            this.miLabel14.Text = "Saldo a la fecha $";
            this.miLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.miLabel2.TabIndex = 13;
            this.miLabel2.Text = "Nombre de fantasía";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNombreFantasia
            // 
            this.txtNombreFantasia.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtNombreFantasia.BackColor = System.Drawing.Color.White;
            this.txtNombreFantasia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreFantasia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreFantasia.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtNombreFantasia.ForeColor = System.Drawing.Color.Black;
            this.txtNombreFantasia.Location = new System.Drawing.Point(160, 88);
            this.txtNombreFantasia.MaxLength = 20;
            this.txtNombreFantasia.Name = "txtNombreFantasia";
            this.txtNombreFantasia.Size = new System.Drawing.Size(180, 22);
            this.txtNombreFantasia.TabIndex = 14;
            this.txtNombreFantasia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreFantasia_KeyPress);
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
            this.cmbCuentaContable.ItemHeight = 14;
            this.cmbCuentaContable.Location = new System.Drawing.Point(160, 358);
            this.cmbCuentaContable.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCuentaContable.Name = "cmbCuentaContable";
            this.cmbCuentaContable.Size = new System.Drawing.Size(185, 22);
            this.cmbCuentaContable.Sorted = true;
            this.cmbCuentaContable.TabIndex = 40;
            // 
            // miLabel13
            // 
            this.miLabel13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel13.BackColor = System.Drawing.Color.Transparent;
            this.miLabel13.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel13.Location = new System.Drawing.Point(0, 361);
            this.miLabel13.Name = "miLabel13";
            this.miLabel13.Size = new System.Drawing.Size(160, 15);
            this.miLabel13.TabIndex = 39;
            this.miLabel13.Text = "Cuenta contable";
            this.miLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.cmbCuentaContable);
            this.Controls.Add(this.miLabel13);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.txtNombreFantasia);
            this.Controls.Add(this.miLabel14);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.tabContenedor);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.miLabel15);
            this.Controls.Add(this.miLabel11);
            this.Controls.Add(this.txtCtaBancariaNro);
            this.Controls.Add(this.cmbCtaBancariaTipo);
            this.Controls.Add(this.btnCtaBancaria);
            this.Controls.Add(this.cmbCtaBancaria);
            this.Controls.Add(this.miLabel12);
            this.Controls.Add(this.txtPaginaWeb);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.miLabel10);
            this.Controls.Add(this.txtCelular);
            this.Controls.Add(this.miLabel9);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.miLabel8);
            this.Controls.Add(this.txtCodigoPostal);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.cmbDistrito);
            this.Controls.Add(this.cmbProvincia);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.txtDomicilio);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.cmbCategoriaIva);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtDenominacion);
            this.Name = "FormProveedor";
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.FormProveedor_Load);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.txtCuit, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.cmbCategoriaIva, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.txtDomicilio, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.cmbProvincia, 0);
            this.Controls.SetChildIndex(this.cmbDistrito, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.txtCodigoPostal, 0);
            this.Controls.SetChildIndex(this.miLabel8, 0);
            this.Controls.SetChildIndex(this.txtTelefono, 0);
            this.Controls.SetChildIndex(this.miLabel9, 0);
            this.Controls.SetChildIndex(this.txtCelular, 0);
            this.Controls.SetChildIndex(this.miLabel10, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.txtPaginaWeb, 0);
            this.Controls.SetChildIndex(this.miLabel12, 0);
            this.Controls.SetChildIndex(this.cmbCtaBancaria, 0);
            this.Controls.SetChildIndex(this.btnCtaBancaria, 0);
            this.Controls.SetChildIndex(this.cmbCtaBancariaTipo, 0);
            this.Controls.SetChildIndex(this.txtCtaBancariaNro, 0);
            this.Controls.SetChildIndex(this.miLabel11, 0);
            this.Controls.SetChildIndex(this.miLabel15, 0);
            this.Controls.SetChildIndex(this.cmbEstado, 0);
            this.Controls.SetChildIndex(this.tabContenedor, 0);
            this.Controls.SetChildIndex(this.txtSaldo, 0);
            this.Controls.SetChildIndex(this.miLabel14, 0);
            this.Controls.SetChildIndex(this.txtNombreFantasia, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnExcel_Registro, 0);
            this.Controls.SetChildIndex(this.btnPDF_Registro, 0);
            this.Controls.SetChildIndex(this.labelPublicacion, 0);
            this.Controls.SetChildIndex(this.panelLista, 0);
            this.Controls.SetChildIndex(this.miLabel13, 0);
            this.Controls.SetChildIndex(this.cmbCuentaContable, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            this.tabContenedor.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBox txtDenominacion;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiMaskedTextBox txtCuit;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiComboBox cmbCategoriaIva;
        private Biblioteca.Controles.MiMaskedTextBox txtCodigoPostal;
        private Biblioteca.Controles.MiLabel miLabel7;
        private Biblioteca.Controles.MiComboBox cmbDistrito;
        private Biblioteca.Controles.MiComboBox cmbProvincia;
        private Biblioteca.Controles.MiLabel miLabel6;
        private Biblioteca.Controles.MiTextBox txtDomicilio;
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiTextBox txtEmail;
        private Biblioteca.Controles.MiLabel miLabel10;
        private Biblioteca.Controles.MiMaskedTextBox txtCelular;
        private Biblioteca.Controles.MiLabel miLabel9;
        private Biblioteca.Controles.MiMaskedTextBox txtTelefono;
        private Biblioteca.Controles.MiLabel miLabel8;
        private Biblioteca.Controles.MiTextBox txtPaginaWeb;
        private Biblioteca.Controles.MiMaskedTextBox txtCtaBancariaNro;
        private Biblioteca.Controles.MiComboBox cmbCtaBancariaTipo;
        private Biblioteca.Controles.MiButtonFind btnCtaBancaria;
        private Biblioteca.Controles.MiComboBox cmbCtaBancaria;
        private Biblioteca.Controles.MiLabel miLabel12;
        private Biblioteca.Controles.MiLabel miLabel11;
        private Biblioteca.Controles.MiComboBox cmbEstado;
        private Biblioteca.Controles.MiLabel miLabel15;
        private System.Windows.Forms.TabControl tabContenedor;
        private System.Windows.Forms.TabPage tabPage1;
        private Biblioteca.Controles.MiTextBox txtContactoEmail;
        private Biblioteca.Controles.MiTextBox txtContactoDenominacion;
        private Biblioteca.Controles.MiLabel miLabel19;
        private Biblioteca.Controles.MiLabel miLabel16;
        private Biblioteca.Controles.MiMaskedTextBox txtContactoCelular;
        private Biblioteca.Controles.MiLabel miLabel17;
        private Biblioteca.Controles.MiLabel miLabel18;
        private Biblioteca.Controles.MiMaskedTextBox txtContactoTelefono;
        private Biblioteca.Controles.MiTextBoxRead txtSaldo;
        private Biblioteca.Controles.MiLabel miLabel14;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiTextBox txtNombreFantasia;
        private Biblioteca.Controles.MiComboBox cmbCuentaContable;
        private Biblioteca.Controles.MiLabel miLabel13;
    }
}
