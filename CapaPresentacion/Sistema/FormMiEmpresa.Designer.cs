using Biblioteca.Controles;

namespace CapaPresentacion
{
    partial class FormMiEmpresa
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
                nMiEmpresa.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMiEmpresa));
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.txtNombreFantasia = new Biblioteca.Controles.MiTextBox();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.txtCuit = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.cmbCategoriaIva = new Biblioteca.Controles.MiComboBox();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.txtNroIngresoBruto = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.pkrInicioActividad = new Biblioteca.Controles.MiDateTimePicker();
            this.miLabel13 = new Biblioteca.Controles.MiLabel();
            this.txtPaginaWeb = new Biblioteca.Controles.MiTextBox();
            this.txtEmail = new Biblioteca.Controles.MiTextBox();
            this.miLabel12 = new Biblioteca.Controles.MiLabel();
            this.txtCelular = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel11 = new Biblioteca.Controles.MiLabel();
            this.txtTelefono = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel10 = new Biblioteca.Controles.MiLabel();
            this.txtCodigoPostal = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel9 = new Biblioteca.Controles.MiLabel();
            this.cmbDistrito = new Biblioteca.Controles.MiComboBox();
            this.cmbProvincia = new Biblioteca.Controles.MiComboBox();
            this.miLabel8 = new Biblioteca.Controles.MiLabel();
            this.txtDomicilio = new Biblioteca.Controles.MiTextBox();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.btnPDF_Registro = new Biblioteca.Controles.MiButtonPDF();
            this.btnExcel_Registro = new Biblioteca.Controles.MiButtonExcel();
            this.btnCancelar = new Biblioteca.Controles.MiButtonBase();
            this.btnGuardar = new Biblioteca.Controles.MiButtonBase();
            this.labelPublicacion = new Biblioteca.Controles.MiLabel();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Mi Empresa";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 34;
            // 
            // labelUsuario
            // 
            this.labelUsuario.TabIndex = 1;
            this.labelUsuario.Text = "Sesión de : ";
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
            this.miLabel1.TabIndex = 2;
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
            this.txtDenominacion.TabIndex = 3;
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
            this.miLabel2.TabIndex = 4;
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
            this.txtNombreFantasia.TabIndex = 5;
            this.txtNombreFantasia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreFantasia_KeyPress);
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
            this.miLabel3.TabIndex = 6;
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
            this.txtCuit.TabIndex = 7;
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
            this.miLabel4.TabIndex = 8;
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
            this.cmbCategoriaIva.TabIndex = 9;
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
            this.miLabel5.TabIndex = 10;
            this.miLabel5.Text = "N° Ingresos brutos";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNroIngresoBruto
            // 
            this.txtNroIngresoBruto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtNroIngresoBruto.BackColor = System.Drawing.Color.White;
            this.txtNroIngresoBruto.BeepOnError = true;
            this.txtNroIngresoBruto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroIngresoBruto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtNroIngresoBruto.ForeColor = System.Drawing.Color.Black;
            this.txtNroIngresoBruto.HidePromptOnLeave = true;
            this.txtNroIngresoBruto.Location = new System.Drawing.Point(160, 169);
            this.txtNroIngresoBruto.Mask = "999-999999-9";
            this.txtNroIngresoBruto.Name = "txtNroIngresoBruto";
            this.txtNroIngresoBruto.PromptChar = ' ';
            this.txtNroIngresoBruto.Size = new System.Drawing.Size(100, 22);
            this.txtNroIngresoBruto.TabIndex = 11;
            // 
            // miLabel6
            // 
            this.miLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel6.BackColor = System.Drawing.Color.Transparent;
            this.miLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel6.Location = new System.Drawing.Point(0, 198);
            this.miLabel6.Name = "miLabel6";
            this.miLabel6.Size = new System.Drawing.Size(160, 18);
            this.miLabel6.TabIndex = 12;
            this.miLabel6.Text = "Incio de actividad";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pkrInicioActividad
            // 
            this.pkrInicioActividad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrInicioActividad.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrInicioActividad.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrInicioActividad.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrInicioActividad.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrInicioActividad.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.pkrInicioActividad.CustomFormat = "dd/MM/yyyy";
            this.pkrInicioActividad.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrInicioActividad.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrInicioActividad.Location = new System.Drawing.Point(160, 196);
            this.pkrInicioActividad.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrInicioActividad.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrInicioActividad.Name = "pkrInicioActividad";
            this.pkrInicioActividad.Size = new System.Drawing.Size(102, 22);
            this.pkrInicioActividad.TabIndex = 13;
            this.pkrInicioActividad.UseWaitCursor = true;
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
            this.miLabel13.TabIndex = 27;
            this.miLabel13.Text = "Página WEB";
            this.miLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPaginaWeb
            // 
            this.txtPaginaWeb.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPaginaWeb.BackColor = System.Drawing.Color.White;
            this.txtPaginaWeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaginaWeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtPaginaWeb.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtPaginaWeb.ForeColor = System.Drawing.Color.Black;
            this.txtPaginaWeb.Location = new System.Drawing.Point(160, 358);
            this.txtPaginaWeb.MaxLength = 50;
            this.txtPaginaWeb.Name = "txtPaginaWeb";
            this.txtPaginaWeb.Size = new System.Drawing.Size(360, 22);
            this.txtPaginaWeb.TabIndex = 28;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(160, 331);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(360, 22);
            this.txtEmail.TabIndex = 26;
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
            this.miLabel12.TabIndex = 25;
            this.miLabel12.Text = "E-mail";
            this.miLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtCelular.Location = new System.Drawing.Point(160, 304);
            this.txtCelular.Mask = "9999999999999";
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.PromptChar = ' ';
            this.txtCelular.Size = new System.Drawing.Size(100, 22);
            this.txtCelular.TabIndex = 24;
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
            this.miLabel11.TabIndex = 23;
            this.miLabel11.Text = "Celular";
            this.miLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtTelefono.Location = new System.Drawing.Point(160, 277);
            this.txtTelefono.Mask = "9999999999999";
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.PromptChar = ' ';
            this.txtTelefono.Size = new System.Drawing.Size(100, 22);
            this.txtTelefono.TabIndex = 22;
            this.txtTelefono.ValidatingType = typeof(int);
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
            this.miLabel10.TabIndex = 21;
            this.miLabel10.Text = "Teléfono";
            this.miLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txtCodigoPostal.TabIndex = 20;
            this.txtCodigoPostal.ValidatingType = typeof(int);
            // 
            // miLabel9
            // 
            this.miLabel9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel9.BackColor = System.Drawing.Color.Transparent;
            this.miLabel9.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel9.Location = new System.Drawing.Point(447, 253);
            this.miLabel9.Name = "miLabel9";
            this.miLabel9.Size = new System.Drawing.Size(28, 15);
            this.miLabel9.TabIndex = 19;
            this.miLabel9.Text = "C.P.";
            this.miLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cmbDistrito.TabIndex = 18;
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
            this.cmbProvincia.TabIndex = 17;
            this.cmbProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);
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
            this.miLabel8.TabIndex = 16;
            this.miLabel8.Text = "Provincia - Distrito";
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
            this.txtDomicilio.TabIndex = 15;
            this.txtDomicilio.Validated += new System.EventHandler(this.txtDomicilio_Validated);
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
            this.miLabel7.TabIndex = 14;
            this.miLabel7.Text = "Domicilio";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPDF_Registro
            // 
            this.btnPDF_Registro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPDF_Registro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPDF_Registro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPDF_Registro.BackgroundImage")));
            this.btnPDF_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPDF_Registro.FlatAppearance.BorderSize = 0;
            this.btnPDF_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Registro.Font = new System.Drawing.Font("Arial", 9F);
            this.btnPDF_Registro.ForeColor = System.Drawing.Color.Black;
            this.btnPDF_Registro.Location = new System.Drawing.Point(196, 657);
            this.btnPDF_Registro.Name = "btnPDF_Registro";
            this.btnPDF_Registro.Size = new System.Drawing.Size(30, 23);
            this.btnPDF_Registro.TabIndex = 33;
            this.btnPDF_Registro.UseVisualStyleBackColor = false;
            this.btnPDF_Registro.Click += new System.EventHandler(this.btnPDF_Registro_Click);
            // 
            // btnExcel_Registro
            // 
            this.btnExcel_Registro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcel_Registro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExcel_Registro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExcel_Registro.BackgroundImage")));
            this.btnExcel_Registro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExcel_Registro.FlatAppearance.BorderSize = 0;
            this.btnExcel_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Registro.Font = new System.Drawing.Font("Arial", 9F);
            this.btnExcel_Registro.ForeColor = System.Drawing.Color.Black;
            this.btnExcel_Registro.Location = new System.Drawing.Point(164, 657);
            this.btnExcel_Registro.Name = "btnExcel_Registro";
            this.btnExcel_Registro.Size = new System.Drawing.Size(30, 23);
            this.btnExcel_Registro.TabIndex = 32;
            this.btnExcel_Registro.UseVisualStyleBackColor = false;
            this.btnExcel_Registro.Click += new System.EventHandler(this.btnExcel_Registro_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(83, 657);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 31;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(6, 657);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 30;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // labelPublicacion
            // 
            this.labelPublicacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPublicacion.BackColor = System.Drawing.Color.Transparent;
            this.labelPublicacion.Font = new System.Drawing.Font("Arial", 7.5F);
            this.labelPublicacion.ForeColor = System.Drawing.Color.DimGray;
            this.labelPublicacion.Location = new System.Drawing.Point(3, 634);
            this.labelPublicacion.Name = "labelPublicacion";
            this.labelPublicacion.Size = new System.Drawing.Size(519, 14);
            this.labelPublicacion.TabIndex = 29;
            this.labelPublicacion.Text = "S/D";
            this.labelPublicacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormMiEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.btnPDF_Registro);
            this.Controls.Add(this.btnExcel_Registro);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.labelPublicacion);
            this.Controls.Add(this.miLabel13);
            this.Controls.Add(this.txtPaginaWeb);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.miLabel12);
            this.Controls.Add(this.txtCelular);
            this.Controls.Add(this.miLabel11);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.miLabel10);
            this.Controls.Add(this.txtCodigoPostal);
            this.Controls.Add(this.miLabel9);
            this.Controls.Add(this.cmbDistrito);
            this.Controls.Add(this.cmbProvincia);
            this.Controls.Add(this.miLabel8);
            this.Controls.Add(this.txtDomicilio);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.pkrInicioActividad);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.txtNroIngresoBruto);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.cmbCategoriaIva);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.txtNombreFantasia);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtDenominacion);
            this.Name = "FormMiEmpresa";
            this.Text = "Mi Empresa";
            this.Load += new System.EventHandler(this.FormMiEmpresa_Load);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.txtNombreFantasia, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.txtCuit, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.cmbCategoriaIva, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.txtNroIngresoBruto, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.pkrInicioActividad, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.txtDomicilio, 0);
            this.Controls.SetChildIndex(this.miLabel8, 0);
            this.Controls.SetChildIndex(this.cmbProvincia, 0);
            this.Controls.SetChildIndex(this.cmbDistrito, 0);
            this.Controls.SetChildIndex(this.miLabel9, 0);
            this.Controls.SetChildIndex(this.txtCodigoPostal, 0);
            this.Controls.SetChildIndex(this.miLabel10, 0);
            this.Controls.SetChildIndex(this.txtTelefono, 0);
            this.Controls.SetChildIndex(this.miLabel11, 0);
            this.Controls.SetChildIndex(this.txtCelular, 0);
            this.Controls.SetChildIndex(this.miLabel12, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.txtPaginaWeb, 0);
            this.Controls.SetChildIndex(this.miLabel13, 0);
            this.Controls.SetChildIndex(this.labelPublicacion, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnExcel_Registro, 0);
            this.Controls.SetChildIndex(this.btnPDF_Registro, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MiLabel miLabel1;
        private MiTextBox txtDenominacion;
        private MiLabel miLabel2;
        private MiTextBox txtNombreFantasia;
        private MiLabel miLabel3;
        private MiMaskedTextBox txtCuit;
        private MiLabel miLabel4;
        private MiComboBox cmbCategoriaIva;
        private MiLabel miLabel5;
        private MiMaskedTextBox txtNroIngresoBruto;
        private MiLabel miLabel6;
        private MiDateTimePicker pkrInicioActividad;
        private MiLabel miLabel13;
        private MiTextBox txtPaginaWeb;
        private MiTextBox txtEmail;
        private MiLabel miLabel12;
        private MiMaskedTextBox txtCelular;
        private MiLabel miLabel11;
        private MiMaskedTextBox txtTelefono;
        private MiLabel miLabel10;
        private MiMaskedTextBox txtCodigoPostal;
        private MiLabel miLabel9;
        private MiComboBox cmbDistrito;
        private MiComboBox cmbProvincia;
        private MiLabel miLabel8;
        private MiTextBox txtDomicilio;
        private MiLabel miLabel7;
        public MiButtonPDF btnPDF_Registro;
        public MiButtonExcel btnExcel_Registro;
        public MiButtonBase btnCancelar;
        public MiButtonBase btnGuardar;
        public MiLabel labelPublicacion;
    }
}
