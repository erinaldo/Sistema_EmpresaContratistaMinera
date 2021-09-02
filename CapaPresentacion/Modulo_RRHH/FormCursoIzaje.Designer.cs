namespace CapaPresentacion
{
    partial class FormCursoIzaje
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
                nCursoIzaje.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCursoIzaje));
            this.btnBuscarLegajo = new Biblioteca.Controles.MiButtonFind();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.txtCuit = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.cmbCentroCosto = new Biblioteca.Controles.MiComboBox();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.pkrFechaEmision = new Biblioteca.Controles.MiDateTimePicker();
            this.chkItem1 = new Biblioteca.Controles.MiCheckBox();
            this.chkItem2 = new Biblioteca.Controles.MiCheckBox();
            this.chkItem3 = new Biblioteca.Controles.MiCheckBox();
            this.chkItem4 = new Biblioteca.Controles.MiCheckBox();
            this.chkItem5 = new Biblioteca.Controles.MiCheckBox();
            this.chkItem6 = new Biblioteca.Controles.MiCheckBox();
            this.chkItem7 = new Biblioteca.Controles.MiCheckBox();
            this.txtObservacion = new Biblioteca.Controles.MiTextBox();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.miLabel8 = new Biblioteca.Controles.MiLabel();
            this.txtEstado = new Biblioteca.Controles.MiTextBoxRead();
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
            this.lblTituloLista.Size = new System.Drawing.Size(316, 23);
            this.lblTituloLista.Text = "Lista de Cursos de Izaje";
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
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(54, 14);
            this.lblCatalagoTitulo4.Text = "F. Emisión";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(595, 36);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(60, 14);
            this.lblCatalagoTitulo5.Text = "Fecha Vto.";
            // 
            // panelLista
            // 
            this.panelLista.TabIndex = 13;
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(686, 36);
            this.lblCatalagoTitulo6.Size = new System.Drawing.Size(40, 14);
            this.lblCatalagoTitulo6.Text = "Estado";
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Cursos de Izaje";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 12;
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
            this.btnBuscarLegajo.TabIndex = 16;
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
            this.miLabel1.TabIndex = 14;
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
            this.txtDenominacion.TabIndex = 15;
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
            this.txtCuit.TabIndex = 18;
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
            this.miLabel2.Text = "CUIL/CUIT";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cmbCentroCosto.TabIndex = 20;
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
            this.miLabel3.TabIndex = 19;
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
            this.miLabel4.TabIndex = 21;
            this.miLabel4.Text = "Fecha de emisión";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.pkrFechaEmision.Location = new System.Drawing.Point(160, 142);
            this.pkrFechaEmision.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrFechaEmision.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrFechaEmision.Name = "pkrFechaEmision";
            this.pkrFechaEmision.Size = new System.Drawing.Size(102, 22);
            this.pkrFechaEmision.TabIndex = 22;
            // 
            // chkItem1
            // 
            this.chkItem1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkItem1.AutoSize = true;
            this.chkItem1.BackColor = System.Drawing.Color.Transparent;
            this.chkItem1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkItem1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkItem1.Location = new System.Drawing.Point(160, 171);
            this.chkItem1.Name = "chkItem1";
            this.chkItem1.Size = new System.Drawing.Size(111, 19);
            this.chkItem1.TabIndex = 40;
            this.chkItem1.Text = "Autoelevadores";
            this.chkItem1.UseVisualStyleBackColor = false;
            // 
            // chkItem2
            // 
            this.chkItem2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkItem2.AutoSize = true;
            this.chkItem2.BackColor = System.Drawing.Color.Transparent;
            this.chkItem2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkItem2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItem2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkItem2.Location = new System.Drawing.Point(160, 192);
            this.chkItem2.Name = "chkItem2";
            this.chkItem2.Size = new System.Drawing.Size(159, 19);
            this.chkItem2.TabIndex = 41;
            this.chkItem2.Text = "Hidrogruas hasta 20t.m.";
            this.chkItem2.UseVisualStyleBackColor = false;
            // 
            // chkItem3
            // 
            this.chkItem3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkItem3.AutoSize = true;
            this.chkItem3.BackColor = System.Drawing.Color.Transparent;
            this.chkItem3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkItem3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItem3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkItem3.Location = new System.Drawing.Point(160, 213);
            this.chkItem3.Name = "chkItem3";
            this.chkItem3.Size = new System.Drawing.Size(160, 19);
            this.chkItem3.TabIndex = 42;
            this.chkItem3.Text = "Manipulador telescópico";
            this.chkItem3.UseVisualStyleBackColor = false;
            // 
            // chkItem4
            // 
            this.chkItem4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkItem4.AutoSize = true;
            this.chkItem4.BackColor = System.Drawing.Color.Transparent;
            this.chkItem4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkItem4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItem4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkItem4.Location = new System.Drawing.Point(160, 234);
            this.chkItem4.Name = "chkItem4";
            this.chkItem4.Size = new System.Drawing.Size(226, 19);
            this.chkItem4.TabIndex = 43;
            this.chkItem4.Text = "Minicargador de dirección deslizante";
            this.chkItem4.UseVisualStyleBackColor = false;
            // 
            // chkItem5
            // 
            this.chkItem5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkItem5.AutoSize = true;
            this.chkItem5.BackColor = System.Drawing.Color.Transparent;
            this.chkItem5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkItem5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItem5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkItem5.Location = new System.Drawing.Point(160, 255);
            this.chkItem5.Name = "chkItem5";
            this.chkItem5.Size = new System.Drawing.Size(195, 19);
            this.chkItem5.TabIndex = 44;
            this.chkItem5.Text = "Plataforma de trabajo en altura";
            this.chkItem5.UseVisualStyleBackColor = false;
            // 
            // chkItem6
            // 
            this.chkItem6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkItem6.AutoSize = true;
            this.chkItem6.BackColor = System.Drawing.Color.Transparent;
            this.chkItem6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkItem6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItem6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkItem6.Location = new System.Drawing.Point(160, 276);
            this.chkItem6.Name = "chkItem6";
            this.chkItem6.Size = new System.Drawing.Size(93, 19);
            this.chkItem6.TabIndex = 45;
            this.chkItem6.Text = "Puente grúa";
            this.chkItem6.UseVisualStyleBackColor = false;
            // 
            // chkItem7
            // 
            this.chkItem7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkItem7.AutoSize = true;
            this.chkItem7.BackColor = System.Drawing.Color.Transparent;
            this.chkItem7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkItem7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItem7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkItem7.Location = new System.Drawing.Point(160, 297);
            this.chkItem7.Name = "chkItem7";
            this.chkItem7.Size = new System.Drawing.Size(108, 19);
            this.chkItem7.TabIndex = 46;
            this.chkItem7.Text = "Otras licencias";
            this.chkItem7.UseVisualStyleBackColor = false;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtObservacion.BackColor = System.Drawing.Color.White;
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtObservacion.ForeColor = System.Drawing.Color.Black;
            this.txtObservacion.Location = new System.Drawing.Point(160, 321);
            this.txtObservacion.MaxLength = 250;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(340, 52);
            this.txtObservacion.TabIndex = 48;
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(0, 324);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(160, 15);
            this.miLabel7.TabIndex = 47;
            this.miLabel7.Text = "Observaciones";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel8
            // 
            this.miLabel8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel8.BackColor = System.Drawing.Color.Transparent;
            this.miLabel8.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel8.Location = new System.Drawing.Point(0, 381);
            this.miLabel8.Name = "miLabel8";
            this.miLabel8.Size = new System.Drawing.Size(160, 15);
            this.miLabel8.TabIndex = 49;
            this.miLabel8.Text = "Estado";
            this.miLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstado.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtEstado.ForeColor = System.Drawing.Color.Black;
            this.txtEstado.Location = new System.Drawing.Point(160, 378);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(85, 22);
            this.txtEstado.TabIndex = 50;
            // 
            // FormCursoIzaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.miLabel8);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.chkItem7);
            this.Controls.Add(this.chkItem6);
            this.Controls.Add(this.chkItem5);
            this.Controls.Add(this.chkItem4);
            this.Controls.Add(this.chkItem3);
            this.Controls.Add(this.chkItem2);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.pkrFechaEmision);
            this.Controls.Add(this.cmbCentroCosto);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.btnBuscarLegajo);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtDenominacion);
            this.Controls.Add(this.chkItem1);
            this.Name = "FormCursoIzaje";
            this.Text = "Cursos de Izaje";
            this.Load += new System.EventHandler(this.FormCursoIzaje_Load);
            this.Controls.SetChildIndex(this.chkItem1, 0);
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
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.btnBuscarLegajo, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.txtCuit, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.cmbCentroCosto, 0);
            this.Controls.SetChildIndex(this.pkrFechaEmision, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.chkItem2, 0);
            this.Controls.SetChildIndex(this.chkItem3, 0);
            this.Controls.SetChildIndex(this.chkItem4, 0);
            this.Controls.SetChildIndex(this.chkItem5, 0);
            this.Controls.SetChildIndex(this.chkItem6, 0);
            this.Controls.SetChildIndex(this.chkItem7, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.txtObservacion, 0);
            this.Controls.SetChildIndex(this.miLabel8, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Biblioteca.Controles.MiButtonFind btnBuscarLegajo;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBox txtDenominacion;
        private Biblioteca.Controles.MiTextBoxRead txtCuit;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiComboBox cmbCentroCosto;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiDateTimePicker pkrFechaEmision;
        private Biblioteca.Controles.MiCheckBox chkItem1;
        private Biblioteca.Controles.MiCheckBox chkItem2;
        private Biblioteca.Controles.MiCheckBox chkItem3;
        private Biblioteca.Controles.MiCheckBox chkItem4;
        private Biblioteca.Controles.MiCheckBox chkItem5;
        private Biblioteca.Controles.MiCheckBox chkItem6;
        private Biblioteca.Controles.MiCheckBox chkItem7;
        private Biblioteca.Controles.MiTextBox txtObservacion;
        private Biblioteca.Controles.MiLabel miLabel7;
        private Biblioteca.Controles.MiLabel miLabel8;
        private Biblioteca.Controles.MiTextBoxRead txtEstado;
    }
}