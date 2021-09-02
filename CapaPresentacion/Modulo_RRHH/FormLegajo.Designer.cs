namespace CapaPresentacion
{
    partial class FormLegajo
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
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.cmbSexo = new Biblioteca.Controles.MiComboBox();
            this.txtDocumento = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.txtCuit = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.pkrFechaNacimiento = new Biblioteca.Controles.MiDateTimePicker();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.cmbTipoSangre = new Biblioteca.Controles.MiComboBox();
            this.cmbNacionalidad = new Biblioteca.Controles.MiComboBoxWrite();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.cmbEstadoCivil = new Biblioteca.Controles.MiComboBox();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.txtCantidadHijo = new Biblioteca.Controles.MiNumericUpDown();
            this.miLabel8 = new Biblioteca.Controles.MiLabel();
            this.txtDomicilio = new Biblioteca.Controles.MiTextBox();
            this.miLabel9 = new Biblioteca.Controles.MiLabel();
            this.txtCodigoPostal = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel10 = new Biblioteca.Controles.MiLabel();
            this.cmbDistrito = new Biblioteca.Controles.MiComboBox();
            this.cmbProvincia = new Biblioteca.Controles.MiComboBox();
            this.miLabel11 = new Biblioteca.Controles.MiLabel();
            this.chkComunidad = new Biblioteca.Controles.MiCheckBox();
            this.txtCelular3 = new Biblioteca.Controles.MiMaskedTextBox();
            this.txtCelular2 = new Biblioteca.Controles.MiMaskedTextBox();
            this.txtCelular1 = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel12 = new Biblioteca.Controles.MiLabel();
            this.txtEmail = new Biblioteca.Controles.MiTextBox();
            this.miLabel13 = new Biblioteca.Controles.MiLabel();
            this.txtCtaBancariaNro = new Biblioteca.Controles.MiMaskedTextBox();
            this.cmbCtaBancariaTipo = new Biblioteca.Controles.MiComboBox();
            this.btnCtaBancaria = new Biblioteca.Controles.MiButtonFind();
            this.cmbCtaBancaria = new Biblioteca.Controles.MiComboBox();
            this.miLabel14 = new Biblioteca.Controles.MiLabel();
            this.txtObservacion = new Biblioteca.Controles.MiTextBox();
            this.miLabel15 = new Biblioteca.Controles.MiLabel();
            this.chkInformacionRestringida = new Biblioteca.Controles.MiCheckBox();
            this.miLabel16 = new Biblioteca.Controles.MiLabel();
            this.txtSaldo = new Biblioteca.Controles.MiTextBoxRead();
            this.chkBaja = new Biblioteca.Controles.MiCheckBox();
            this.txtEdad = new Biblioteca.Controles.MiTextBoxRead();
            this.panelLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadHijo)).BeginInit();
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
            this.lblTituloLista.Text = "Lista de Legajos (Personal)";
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
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(62, 14);
            this.lblCatalagoTitulo4.Text = "Fecha Nac.";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(595, 36);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(60, 14);
            this.lblCatalagoTitulo5.Text = "Celular(es)";
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Enabled = false;
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(854, 36);
            this.lblCatalagoTitulo6.Text = "Campo6";
            this.lblCatalagoTitulo6.Visible = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Legajos - Personal";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
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
            this.miLabel1.Text = "Apellido(s) y Nombre(s)";
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
            this.txtDenominacion.TabIndex = 13;
            this.txtDenominacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDenominacion_KeyPress);
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
            this.miLabel2.TabIndex = 14;
            this.miLabel2.Text = "Sexo - N° Documento";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSexo
            // 
            this.cmbSexo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbSexo.BackColor = System.Drawing.Color.White;
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSexo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbSexo.ForeColor = System.Drawing.Color.Black;
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.ItemHeight = 14;
            this.cmbSexo.Items.AddRange(new object[] {
            "FEMENINO",
            "MASCULINO"});
            this.cmbSexo.Location = new System.Drawing.Point(160, 88);
            this.cmbSexo.Margin = new System.Windows.Forms.Padding(1);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(90, 22);
            this.cmbSexo.Sorted = true;
            this.cmbSexo.TabIndex = 15;
            this.cmbSexo.SelectedIndexChanged += new System.EventHandler(this.cmbSexo_SelectedIndexChanged);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDocumento.BackColor = System.Drawing.Color.White;
            this.txtDocumento.BeepOnError = true;
            this.txtDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumento.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtDocumento.ForeColor = System.Drawing.Color.Black;
            this.txtDocumento.HidePromptOnLeave = true;
            this.txtDocumento.Location = new System.Drawing.Point(252, 88);
            this.txtDocumento.Mask = "99999999";
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.PromptChar = ' ';
            this.txtDocumento.Size = new System.Drawing.Size(65, 22);
            this.txtDocumento.TabIndex = 16;
            this.txtDocumento.ValidatingType = typeof(int);
            this.txtDocumento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDocumento_KeyUp);
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
            this.miLabel3.Text = "CUIL/CUIT";
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
            this.txtCuit.TabIndex = 18;
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
            this.miLabel4.Text = "F. de nacimiento - Edad";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pkrFechaNacimiento
            // 
            this.pkrFechaNacimiento.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrFechaNacimiento.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrFechaNacimiento.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrFechaNacimiento.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrFechaNacimiento.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrFechaNacimiento.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            this.pkrFechaNacimiento.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrFechaNacimiento.Location = new System.Drawing.Point(160, 142);
            this.pkrFechaNacimiento.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrFechaNacimiento.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrFechaNacimiento.Name = "pkrFechaNacimiento";
            this.pkrFechaNacimiento.Size = new System.Drawing.Size(102, 22);
            this.pkrFechaNacimiento.TabIndex = 20;
            this.pkrFechaNacimiento.ValueChanged += new System.EventHandler(this.pkrFechaNacimiento_ValueChanged);
            // 
            // miLabel5
            // 
            this.miLabel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel5.BackColor = System.Drawing.Color.Transparent;
            this.miLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel5.Location = new System.Drawing.Point(331, 145);
            this.miLabel5.Name = "miLabel5";
            this.miLabel5.Size = new System.Drawing.Size(92, 15);
            this.miLabel5.TabIndex = 22;
            this.miLabel5.Text = "Tipo de sangre";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoSangre
            // 
            this.cmbTipoSangre.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbTipoSangre.BackColor = System.Drawing.Color.White;
            this.cmbTipoSangre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoSangre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoSangre.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbTipoSangre.ForeColor = System.Drawing.Color.Black;
            this.cmbTipoSangre.FormattingEnabled = true;
            this.cmbTipoSangre.ItemHeight = 14;
            this.cmbTipoSangre.Items.AddRange(new object[] {
            "A-",
            "A+",
            "AB-",
            "AB+",
            "B-",
            "B+",
            "O-",
            "O+",
            "S/D"});
            this.cmbTipoSangre.Location = new System.Drawing.Point(423, 142);
            this.cmbTipoSangre.Margin = new System.Windows.Forms.Padding(1);
            this.cmbTipoSangre.Name = "cmbTipoSangre";
            this.cmbTipoSangre.Size = new System.Drawing.Size(45, 22);
            this.cmbTipoSangre.Sorted = true;
            this.cmbTipoSangre.TabIndex = 23;
            // 
            // cmbNacionalidad
            // 
            this.cmbNacionalidad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbNacionalidad.BackColor = System.Drawing.Color.White;
            this.cmbNacionalidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbNacionalidad.ForeColor = System.Drawing.Color.Black;
            this.cmbNacionalidad.FormattingEnabled = true;
            this.cmbNacionalidad.ItemHeight = 14;
            this.cmbNacionalidad.Items.AddRange(new object[] {
            "ARGENTINA",
            "BOLIVIANA",
            "BRASILEÑA",
            "CHILENA",
            "COLOMBIANA",
            "ECUATORIANA",
            "PARAGUAYA",
            "PERUANA",
            "URUGUAYA"});
            this.cmbNacionalidad.Location = new System.Drawing.Point(160, 169);
            this.cmbNacionalidad.Margin = new System.Windows.Forms.Padding(1);
            this.cmbNacionalidad.MaxLength = 15;
            this.cmbNacionalidad.Name = "cmbNacionalidad";
            this.cmbNacionalidad.Size = new System.Drawing.Size(115, 22);
            this.cmbNacionalidad.Sorted = true;
            this.cmbNacionalidad.TabIndex = 25;
            this.cmbNacionalidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbNacionalidad_KeyPress);
            // 
            // miLabel6
            // 
            this.miLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel6.BackColor = System.Drawing.Color.Transparent;
            this.miLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel6.Location = new System.Drawing.Point(0, 172);
            this.miLabel6.Name = "miLabel6";
            this.miLabel6.Size = new System.Drawing.Size(160, 15);
            this.miLabel6.TabIndex = 24;
            this.miLabel6.Text = "Nacionalidad";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbEstadoCivil
            // 
            this.cmbEstadoCivil.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbEstadoCivil.BackColor = System.Drawing.Color.White;
            this.cmbEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoCivil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstadoCivil.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbEstadoCivil.ForeColor = System.Drawing.Color.Black;
            this.cmbEstadoCivil.FormattingEnabled = true;
            this.cmbEstadoCivil.ItemHeight = 14;
            this.cmbEstadoCivil.Items.AddRange(new object[] {
            "CASADO",
            "DIVORCIADO",
            "SEPARADO",
            "SOLTERO"});
            this.cmbEstadoCivil.Location = new System.Drawing.Point(160, 196);
            this.cmbEstadoCivil.Margin = new System.Windows.Forms.Padding(1);
            this.cmbEstadoCivil.Name = "cmbEstadoCivil";
            this.cmbEstadoCivil.Size = new System.Drawing.Size(95, 22);
            this.cmbEstadoCivil.Sorted = true;
            this.cmbEstadoCivil.TabIndex = 27;
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(0, 199);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(160, 15);
            this.miLabel7.TabIndex = 26;
            this.miLabel7.Text = "Estado civil";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCantidadHijo
            // 
            this.txtCantidadHijo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCantidadHijo.BackColor = System.Drawing.Color.White;
            this.txtCantidadHijo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCantidadHijo.ForeColor = System.Drawing.Color.Black;
            this.txtCantidadHijo.Location = new System.Drawing.Point(307, 196);
            this.txtCantidadHijo.Name = "txtCantidadHijo";
            this.txtCantidadHijo.Size = new System.Drawing.Size(38, 22);
            this.txtCantidadHijo.TabIndex = 29;
            // 
            // miLabel8
            // 
            this.miLabel8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel8.BackColor = System.Drawing.Color.Transparent;
            this.miLabel8.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel8.Location = new System.Drawing.Point(263, 199);
            this.miLabel8.Name = "miLabel8";
            this.miLabel8.Size = new System.Drawing.Size(44, 15);
            this.miLabel8.TabIndex = 28;
            this.miLabel8.Text = "Hijo(s)";
            this.miLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDomicilio.BackColor = System.Drawing.Color.White;
            this.txtDomicilio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDomicilio.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtDomicilio.ForeColor = System.Drawing.Color.Black;
            this.txtDomicilio.Location = new System.Drawing.Point(160, 223);
            this.txtDomicilio.MaxLength = 50;
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(360, 22);
            this.txtDomicilio.TabIndex = 31;
            this.txtDomicilio.Validated += new System.EventHandler(this.txtDomicilio_Validated);
            // 
            // miLabel9
            // 
            this.miLabel9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel9.BackColor = System.Drawing.Color.Transparent;
            this.miLabel9.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel9.Location = new System.Drawing.Point(0, 226);
            this.miLabel9.Name = "miLabel9";
            this.miLabel9.Size = new System.Drawing.Size(160, 15);
            this.miLabel9.TabIndex = 30;
            this.miLabel9.Text = "Domicilio";
            this.miLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtCodigoPostal.Location = new System.Drawing.Point(475, 250);
            this.txtCodigoPostal.Mask = "99999";
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.PromptChar = ' ';
            this.txtCodigoPostal.Size = new System.Drawing.Size(45, 22);
            this.txtCodigoPostal.TabIndex = 36;
            this.txtCodigoPostal.ValidatingType = typeof(int);
            // 
            // miLabel10
            // 
            this.miLabel10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel10.BackColor = System.Drawing.Color.Transparent;
            this.miLabel10.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel10.Location = new System.Drawing.Point(447, 253);
            this.miLabel10.Name = "miLabel10";
            this.miLabel10.Size = new System.Drawing.Size(28, 15);
            this.miLabel10.TabIndex = 35;
            this.miLabel10.Text = "C.P.";
            this.miLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cmbDistrito.Location = new System.Drawing.Point(317, 250);
            this.cmbDistrito.Margin = new System.Windows.Forms.Padding(1);
            this.cmbDistrito.MaxLength = 20;
            this.cmbDistrito.Name = "cmbDistrito";
            this.cmbDistrito.Size = new System.Drawing.Size(122, 22);
            this.cmbDistrito.Sorted = true;
            this.cmbDistrito.TabIndex = 34;
            this.cmbDistrito.SelectedIndexChanged += new System.EventHandler(this.cmbDistrito_SelectedIndexChanged);
            this.cmbDistrito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDistrito_KeyPress);
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
            this.cmbProvincia.Location = new System.Drawing.Point(160, 250);
            this.cmbProvincia.Margin = new System.Windows.Forms.Padding(1);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(155, 22);
            this.cmbProvincia.Sorted = true;
            this.cmbProvincia.TabIndex = 33;
            this.cmbProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);
            // 
            // miLabel11
            // 
            this.miLabel11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel11.BackColor = System.Drawing.Color.Transparent;
            this.miLabel11.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel11.Location = new System.Drawing.Point(0, 253);
            this.miLabel11.Name = "miLabel11";
            this.miLabel11.Size = new System.Drawing.Size(160, 15);
            this.miLabel11.TabIndex = 32;
            this.miLabel11.Text = "Provincia - Distrito";
            this.miLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkComunidad
            // 
            this.chkComunidad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkComunidad.AutoSize = true;
            this.chkComunidad.BackColor = System.Drawing.Color.Transparent;
            this.chkComunidad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkComunidad.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkComunidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkComunidad.Location = new System.Drawing.Point(160, 280);
            this.chkComunidad.Name = "chkComunidad";
            this.chkComunidad.Size = new System.Drawing.Size(187, 19);
            this.chkComunidad.TabIndex = 37;
            this.chkComunidad.Text = "Corresponde a la comunidad";
            this.chkComunidad.UseVisualStyleBackColor = false;
            // 
            // txtCelular3
            // 
            this.txtCelular3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCelular3.BackColor = System.Drawing.Color.White;
            this.txtCelular3.BeepOnError = true;
            this.txtCelular3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCelular3.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCelular3.ForeColor = System.Drawing.Color.Black;
            this.txtCelular3.HidePromptOnLeave = true;
            this.txtCelular3.Location = new System.Drawing.Point(364, 305);
            this.txtCelular3.Mask = "9999999999999";
            this.txtCelular3.Name = "txtCelular3";
            this.txtCelular3.PromptChar = ' ';
            this.txtCelular3.Size = new System.Drawing.Size(100, 22);
            this.txtCelular3.TabIndex = 41;
            // 
            // txtCelular2
            // 
            this.txtCelular2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCelular2.BackColor = System.Drawing.Color.White;
            this.txtCelular2.BeepOnError = true;
            this.txtCelular2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCelular2.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCelular2.ForeColor = System.Drawing.Color.Black;
            this.txtCelular2.HidePromptOnLeave = true;
            this.txtCelular2.Location = new System.Drawing.Point(262, 305);
            this.txtCelular2.Mask = "9999999999999";
            this.txtCelular2.Name = "txtCelular2";
            this.txtCelular2.PromptChar = ' ';
            this.txtCelular2.Size = new System.Drawing.Size(100, 22);
            this.txtCelular2.TabIndex = 40;
            // 
            // txtCelular1
            // 
            this.txtCelular1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCelular1.BackColor = System.Drawing.Color.White;
            this.txtCelular1.BeepOnError = true;
            this.txtCelular1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCelular1.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCelular1.ForeColor = System.Drawing.Color.Black;
            this.txtCelular1.HidePromptOnLeave = true;
            this.txtCelular1.Location = new System.Drawing.Point(160, 305);
            this.txtCelular1.Mask = "9999999999999";
            this.txtCelular1.Name = "txtCelular1";
            this.txtCelular1.PromptChar = ' ';
            this.txtCelular1.Size = new System.Drawing.Size(100, 22);
            this.txtCelular1.TabIndex = 39;
            // 
            // miLabel12
            // 
            this.miLabel12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel12.BackColor = System.Drawing.Color.Transparent;
            this.miLabel12.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel12.Location = new System.Drawing.Point(0, 308);
            this.miLabel12.Name = "miLabel12";
            this.miLabel12.Size = new System.Drawing.Size(160, 15);
            this.miLabel12.TabIndex = 38;
            this.miLabel12.Text = "Celular(es)";
            this.miLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(160, 332);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(360, 22);
            this.txtEmail.TabIndex = 43;
            // 
            // miLabel13
            // 
            this.miLabel13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel13.BackColor = System.Drawing.Color.Transparent;
            this.miLabel13.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel13.Location = new System.Drawing.Point(0, 335);
            this.miLabel13.Name = "miLabel13";
            this.miLabel13.Size = new System.Drawing.Size(160, 15);
            this.miLabel13.TabIndex = 42;
            this.miLabel13.Text = "E-mail";
            this.miLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtCtaBancariaNro.Location = new System.Drawing.Point(431, 359);
            this.txtCtaBancariaNro.Mask = "9999999999";
            this.txtCtaBancariaNro.Name = "txtCtaBancariaNro";
            this.txtCtaBancariaNro.PromptChar = ' ';
            this.txtCtaBancariaNro.Size = new System.Drawing.Size(89, 22);
            this.txtCtaBancariaNro.TabIndex = 48;
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
            this.cmbCtaBancariaTipo.Location = new System.Drawing.Point(375, 359);
            this.cmbCtaBancariaTipo.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCtaBancariaTipo.Name = "cmbCtaBancariaTipo";
            this.cmbCtaBancariaTipo.Size = new System.Drawing.Size(55, 22);
            this.cmbCtaBancariaTipo.Sorted = true;
            this.cmbCtaBancariaTipo.TabIndex = 47;
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
            this.btnCtaBancaria.Location = new System.Drawing.Point(346, 358);
            this.btnCtaBancaria.Name = "btnCtaBancaria";
            this.btnCtaBancaria.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCtaBancaria.Size = new System.Drawing.Size(24, 24);
            this.btnCtaBancaria.TabIndex = 46;
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
            this.cmbCtaBancaria.Location = new System.Drawing.Point(160, 359);
            this.cmbCtaBancaria.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCtaBancaria.Name = "cmbCtaBancaria";
            this.cmbCtaBancaria.Size = new System.Drawing.Size(185, 22);
            this.cmbCtaBancaria.Sorted = true;
            this.cmbCtaBancaria.TabIndex = 45;
            this.cmbCtaBancaria.SelectedIndexChanged += new System.EventHandler(this.cmbCtaBancaria_SelectedIndexChanged);
            // 
            // miLabel14
            // 
            this.miLabel14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel14.BackColor = System.Drawing.Color.Transparent;
            this.miLabel14.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel14.Location = new System.Drawing.Point(0, 362);
            this.miLabel14.Name = "miLabel14";
            this.miLabel14.Size = new System.Drawing.Size(160, 15);
            this.miLabel14.TabIndex = 44;
            this.miLabel14.Text = "Cuenta bancaria";
            this.miLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtObservacion.BackColor = System.Drawing.Color.White;
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtObservacion.ForeColor = System.Drawing.Color.Black;
            this.txtObservacion.Location = new System.Drawing.Point(160, 386);
            this.txtObservacion.MaxLength = 250;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(360, 52);
            this.txtObservacion.TabIndex = 50;
            // 
            // miLabel15
            // 
            this.miLabel15.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel15.BackColor = System.Drawing.Color.Transparent;
            this.miLabel15.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel15.Location = new System.Drawing.Point(0, 389);
            this.miLabel15.Name = "miLabel15";
            this.miLabel15.Size = new System.Drawing.Size(160, 15);
            this.miLabel15.TabIndex = 49;
            this.miLabel15.Text = "Observación";
            this.miLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkInformacionRestringida
            // 
            this.chkInformacionRestringida.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkInformacionRestringida.AutoSize = true;
            this.chkInformacionRestringida.BackColor = System.Drawing.Color.Transparent;
            this.chkInformacionRestringida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkInformacionRestringida.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkInformacionRestringida.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInformacionRestringida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkInformacionRestringida.Location = new System.Drawing.Point(367, 445);
            this.chkInformacionRestringida.Name = "chkInformacionRestringida";
            this.chkInformacionRestringida.Size = new System.Drawing.Size(153, 19);
            this.chkInformacionRestringida.TabIndex = 53;
            this.chkInformacionRestringida.Text = "Información restringida";
            this.chkInformacionRestringida.UseVisualStyleBackColor = false;
            // 
            // miLabel16
            // 
            this.miLabel16.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel16.BackColor = System.Drawing.Color.Transparent;
            this.miLabel16.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel16.Location = new System.Drawing.Point(0, 446);
            this.miLabel16.Name = "miLabel16";
            this.miLabel16.Size = new System.Drawing.Size(160, 15);
            this.miLabel16.TabIndex = 51;
            this.miLabel16.Text = "Saldo a la fecha $";
            this.miLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaldo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtSaldo.ForeColor = System.Drawing.Color.Black;
            this.txtSaldo.Location = new System.Drawing.Point(160, 443);
            this.txtSaldo.MaxLength = 10;
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(85, 22);
            this.txtSaldo.TabIndex = 52;
            // 
            // chkBaja
            // 
            this.chkBaja.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkBaja.AutoSize = true;
            this.chkBaja.BackColor = System.Drawing.Color.Transparent;
            this.chkBaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkBaja.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkBaja.Location = new System.Drawing.Point(160, 473);
            this.chkBaja.Name = "chkBaja";
            this.chkBaja.Size = new System.Drawing.Size(112, 19);
            this.chkBaja.TabIndex = 54;
            this.chkBaja.Text = "Baja del Legajo";
            this.chkBaja.UseVisualStyleBackColor = false;
            // 
            // txtEdad
            // 
            this.txtEdad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEdad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEdad.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtEdad.ForeColor = System.Drawing.Color.Black;
            this.txtEdad.Location = new System.Drawing.Point(264, 142);
            this.txtEdad.MaxLength = 15;
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.ReadOnly = true;
            this.txtEdad.Size = new System.Drawing.Size(60, 22);
            this.txtEdad.TabIndex = 21;
            // 
            // FormLegajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.miLabel16);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.chkBaja);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.miLabel15);
            this.Controls.Add(this.txtCtaBancariaNro);
            this.Controls.Add(this.cmbCtaBancariaTipo);
            this.Controls.Add(this.btnCtaBancaria);
            this.Controls.Add(this.cmbCtaBancaria);
            this.Controls.Add(this.miLabel14);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.miLabel13);
            this.Controls.Add(this.txtCelular3);
            this.Controls.Add(this.txtCelular2);
            this.Controls.Add(this.txtCelular1);
            this.Controls.Add(this.miLabel12);
            this.Controls.Add(this.chkComunidad);
            this.Controls.Add(this.txtCodigoPostal);
            this.Controls.Add(this.miLabel10);
            this.Controls.Add(this.cmbDistrito);
            this.Controls.Add(this.cmbProvincia);
            this.Controls.Add(this.miLabel11);
            this.Controls.Add(this.txtDomicilio);
            this.Controls.Add(this.miLabel9);
            this.Controls.Add(this.cmbEstadoCivil);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.txtCantidadHijo);
            this.Controls.Add(this.miLabel8);
            this.Controls.Add(this.cmbNacionalidad);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.pkrFechaNacimiento);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.cmbSexo);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtDenominacion);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.cmbTipoSangre);
            this.Controls.Add(this.chkInformacionRestringida);
            this.Name = "FormLegajo";
            this.Text = "Legajos - Personal";
            this.Load += new System.EventHandler(this.FormLegajo_Load);
            this.Controls.SetChildIndex(this.chkInformacionRestringida, 0);
            this.Controls.SetChildIndex(this.cmbTipoSangre, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.txtDocumento, 0);
            this.Controls.SetChildIndex(this.cmbSexo, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.txtCuit, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.pkrFechaNacimiento, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
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
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.cmbNacionalidad, 0);
            this.Controls.SetChildIndex(this.miLabel8, 0);
            this.Controls.SetChildIndex(this.txtCantidadHijo, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.cmbEstadoCivil, 0);
            this.Controls.SetChildIndex(this.miLabel9, 0);
            this.Controls.SetChildIndex(this.txtDomicilio, 0);
            this.Controls.SetChildIndex(this.miLabel11, 0);
            this.Controls.SetChildIndex(this.cmbProvincia, 0);
            this.Controls.SetChildIndex(this.cmbDistrito, 0);
            this.Controls.SetChildIndex(this.miLabel10, 0);
            this.Controls.SetChildIndex(this.txtCodigoPostal, 0);
            this.Controls.SetChildIndex(this.chkComunidad, 0);
            this.Controls.SetChildIndex(this.miLabel12, 0);
            this.Controls.SetChildIndex(this.txtCelular1, 0);
            this.Controls.SetChildIndex(this.txtCelular2, 0);
            this.Controls.SetChildIndex(this.txtCelular3, 0);
            this.Controls.SetChildIndex(this.miLabel13, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.miLabel14, 0);
            this.Controls.SetChildIndex(this.cmbCtaBancaria, 0);
            this.Controls.SetChildIndex(this.btnCtaBancaria, 0);
            this.Controls.SetChildIndex(this.cmbCtaBancariaTipo, 0);
            this.Controls.SetChildIndex(this.txtCtaBancariaNro, 0);
            this.Controls.SetChildIndex(this.miLabel15, 0);
            this.Controls.SetChildIndex(this.txtObservacion, 0);
            this.Controls.SetChildIndex(this.chkBaja, 0);
            this.Controls.SetChildIndex(this.txtSaldo, 0);
            this.Controls.SetChildIndex(this.miLabel16, 0);
            this.Controls.SetChildIndex(this.txtEdad, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadHijo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBox txtDenominacion;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiComboBox cmbSexo;
        private Biblioteca.Controles.MiMaskedTextBox txtDocumento;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiMaskedTextBox txtCuit;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiDateTimePicker pkrFechaNacimiento;
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiComboBox cmbTipoSangre;
        private Biblioteca.Controles.MiComboBoxWrite cmbNacionalidad;
        private Biblioteca.Controles.MiLabel miLabel6;
        private Biblioteca.Controles.MiComboBox cmbEstadoCivil;
        private Biblioteca.Controles.MiLabel miLabel7;
        private Biblioteca.Controles.MiNumericUpDown txtCantidadHijo;
        private Biblioteca.Controles.MiLabel miLabel8;
        private Biblioteca.Controles.MiTextBox txtDomicilio;
        private Biblioteca.Controles.MiLabel miLabel9;
        private Biblioteca.Controles.MiMaskedTextBox txtCodigoPostal;
        private Biblioteca.Controles.MiLabel miLabel10;
        private Biblioteca.Controles.MiComboBox cmbDistrito;
        private Biblioteca.Controles.MiComboBox cmbProvincia;
        private Biblioteca.Controles.MiLabel miLabel11;
        private Biblioteca.Controles.MiCheckBox chkComunidad;
        private Biblioteca.Controles.MiMaskedTextBox txtCelular3;
        private Biblioteca.Controles.MiMaskedTextBox txtCelular2;
        private Biblioteca.Controles.MiMaskedTextBox txtCelular1;
        private Biblioteca.Controles.MiLabel miLabel12;
        private Biblioteca.Controles.MiTextBox txtEmail;
        private Biblioteca.Controles.MiLabel miLabel13;
        private Biblioteca.Controles.MiMaskedTextBox txtCtaBancariaNro;
        private Biblioteca.Controles.MiComboBox cmbCtaBancariaTipo;
        private Biblioteca.Controles.MiButtonFind btnCtaBancaria;
        private Biblioteca.Controles.MiComboBox cmbCtaBancaria;
        private Biblioteca.Controles.MiLabel miLabel14;
        private Biblioteca.Controles.MiTextBox txtObservacion;
        private Biblioteca.Controles.MiLabel miLabel15;
        private Biblioteca.Controles.MiCheckBox chkInformacionRestringida;
        private Biblioteca.Controles.MiLabel miLabel16;
        private Biblioteca.Controles.MiTextBoxRead txtSaldo;
        private Biblioteca.Controles.MiCheckBox chkBaja;
        private Biblioteca.Controles.MiTextBoxRead txtEdad;
    }
}