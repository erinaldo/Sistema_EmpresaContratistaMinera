namespace CapaPresentacion
{
    partial class FormLegajoLaboral
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
                nLegajoLaboral.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLegajoLaboral));
            this.btnBuscarLegajo = new Biblioteca.Controles.MiButtonFind();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.txtCuit = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.btnLegajoLaboralDDJJ = new Biblioteca.Controles.MiButtonBase();
            this.cmbLegajoLaboralDDJJ = new Biblioteca.Controles.MiComboBox();
            this.txtCentroCosto = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.txtFechaEgreso = new Biblioteca.Controles.MiTextBoxRead();
            this.txtFechaIngreso = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.txtAntiguedad = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.txtModalidadContratacion = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.txtSindicato = new Biblioteca.Controles.MiTextBoxRead();
            this.chkAfiliadoSindical = new Biblioteca.Controles.MiCheckBox();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.txtCategoria = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel8 = new Biblioteca.Controles.MiLabel();
            this.txtPuesto = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel9 = new Biblioteca.Controles.MiLabel();
            this.txtSector = new Biblioteca.Controles.MiTextBoxRead();
            this.txtModalidadLiquidacion = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel10 = new Biblioteca.Controles.MiLabel();
            this.miLabel11 = new Biblioteca.Controles.MiLabel();
            this.txtRemuneracion = new Biblioteca.Controles.MiTextBoxRead();
            this.txtObraSocial = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel12 = new Biblioteca.Controles.MiLabel();
            this.txtObservacion = new Biblioteca.Controles.MiTextBox();
            this.miLabel13 = new Biblioteca.Controles.MiLabel();
            this.chkEstablecerEnProceso = new Biblioteca.Controles.MiCheckBox();
            this.txtEstado = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel14 = new Biblioteca.Controles.MiLabel();
            this.txtModalidadContratacionTiempo = new Biblioteca.Controles.MiTextBoxRead();
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
            this.btnAnular.Enabled = false;
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAnular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAnular.Location = new System.Drawing.Point(545, 657);
            this.btnAnular.TabIndex = 10;
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
            this.lblTituloLista.Size = new System.Drawing.Size(318, 23);
            this.lblTituloLista.Text = "Lista de Legajos (Laboral)";
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
            this.lblCatalagoTitulo4.Text = "F. Ingreso";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(595, 36);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(52, 14);
            this.lblCatalagoTitulo5.Text = "F. Egreso";
            // 
            // panelLista
            // 
            this.panelLista.TabIndex = 12;
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(686, 36);
            this.lblCatalagoTitulo6.Size = new System.Drawing.Size(40, 14);
            this.lblCatalagoTitulo6.Text = "Estado";
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Legajos - Laboral";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 11;
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
            this.btnBuscarLegajo.TabIndex = 15;
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
            this.miLabel1.TabIndex = 13;
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
            this.txtDenominacion.TabIndex = 14;
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
            this.txtCuit.TabIndex = 17;
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
            this.miLabel2.TabIndex = 16;
            this.miLabel2.Text = "CUIL/CUIT";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLegajoLaboralDDJJ
            // 
            this.btnLegajoLaboralDDJJ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLegajoLaboralDDJJ.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLegajoLaboralDDJJ.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_word32;
            this.btnLegajoLaboralDDJJ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLegajoLaboralDDJJ.FlatAppearance.BorderSize = 0;
            this.btnLegajoLaboralDDJJ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnLegajoLaboralDDJJ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLegajoLaboralDDJJ.Font = new System.Drawing.Font("Arial", 9F);
            this.btnLegajoLaboralDDJJ.ForeColor = System.Drawing.Color.Black;
            this.btnLegajoLaboralDDJJ.Location = new System.Drawing.Point(513, 657);
            this.btnLegajoLaboralDDJJ.Name = "btnLegajoLaboralDDJJ";
            this.btnLegajoLaboralDDJJ.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnLegajoLaboralDDJJ.Size = new System.Drawing.Size(30, 23);
            this.btnLegajoLaboralDDJJ.TabIndex = 9;
            this.btnLegajoLaboralDDJJ.UseVisualStyleBackColor = false;
            this.btnLegajoLaboralDDJJ.Click += new System.EventHandler(this.btnLegajoLaboralDDJJ_Click);
            // 
            // cmbLegajoLaboralDDJJ
            // 
            this.cmbLegajoLaboralDDJJ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbLegajoLaboralDDJJ.BackColor = System.Drawing.Color.White;
            this.cmbLegajoLaboralDDJJ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLegajoLaboralDDJJ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLegajoLaboralDDJJ.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.cmbLegajoLaboralDDJJ.ForeColor = System.Drawing.Color.Black;
            this.cmbLegajoLaboralDDJJ.FormattingEnabled = true;
            this.cmbLegajoLaboralDDJJ.Items.AddRange(new object[] {
            "GENERAR DDJJ ANSES",
            "GENERAR DDJJ DESEMPLEO",
            "GENERAR DDJJ DOMICILIO",
            "GENERAR DDJJ OBRA SOCIAL",
            "GENERAR DDJJ PERSONAL",
            "GENERAR DDJJ SEGURO",
            "GENERAR NOTIFICACION ART"});
            this.cmbLegajoLaboralDDJJ.Location = new System.Drawing.Point(309, 657);
            this.cmbLegajoLaboralDDJJ.Margin = new System.Windows.Forms.Padding(1);
            this.cmbLegajoLaboralDDJJ.Name = "cmbLegajoLaboralDDJJ";
            this.cmbLegajoLaboralDDJJ.Size = new System.Drawing.Size(203, 23);
            this.cmbLegajoLaboralDDJJ.Sorted = true;
            this.cmbLegajoLaboralDDJJ.TabIndex = 8;
            // 
            // txtCentroCosto
            // 
            this.txtCentroCosto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCentroCosto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtCentroCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCentroCosto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCentroCosto.ForeColor = System.Drawing.Color.Black;
            this.txtCentroCosto.Location = new System.Drawing.Point(160, 115);
            this.txtCentroCosto.MaxLength = 25;
            this.txtCentroCosto.Name = "txtCentroCosto";
            this.txtCentroCosto.ReadOnly = true;
            this.txtCentroCosto.Size = new System.Drawing.Size(210, 22);
            this.txtCentroCosto.TabIndex = 19;
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
            this.miLabel3.Text = "Centro de costo";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFechaEgreso
            // 
            this.txtFechaEgreso.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtFechaEgreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtFechaEgreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaEgreso.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtFechaEgreso.ForeColor = System.Drawing.Color.Black;
            this.txtFechaEgreso.Location = new System.Drawing.Point(237, 142);
            this.txtFechaEgreso.MaxLength = 15;
            this.txtFechaEgreso.Name = "txtFechaEgreso";
            this.txtFechaEgreso.ReadOnly = true;
            this.txtFechaEgreso.Size = new System.Drawing.Size(75, 22);
            this.txtFechaEgreso.TabIndex = 22;
            // 
            // txtFechaIngreso
            // 
            this.txtFechaIngreso.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtFechaIngreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtFechaIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaIngreso.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtFechaIngreso.ForeColor = System.Drawing.Color.Black;
            this.txtFechaIngreso.Location = new System.Drawing.Point(160, 142);
            this.txtFechaIngreso.MaxLength = 15;
            this.txtFechaIngreso.Name = "txtFechaIngreso";
            this.txtFechaIngreso.ReadOnly = true;
            this.txtFechaIngreso.Size = new System.Drawing.Size(75, 22);
            this.txtFechaIngreso.TabIndex = 21;
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
            this.miLabel4.Text = "Fecha de ingreso - Egreso";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAntiguedad
            // 
            this.txtAntiguedad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAntiguedad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtAntiguedad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAntiguedad.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtAntiguedad.ForeColor = System.Drawing.Color.Black;
            this.txtAntiguedad.Location = new System.Drawing.Point(390, 142);
            this.txtAntiguedad.MaxLength = 15;
            this.txtAntiguedad.Name = "txtAntiguedad";
            this.txtAntiguedad.ReadOnly = true;
            this.txtAntiguedad.Size = new System.Drawing.Size(85, 22);
            this.txtAntiguedad.TabIndex = 24;
            // 
            // miLabel5
            // 
            this.miLabel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel5.BackColor = System.Drawing.Color.Transparent;
            this.miLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel5.Location = new System.Drawing.Point(320, 145);
            this.miLabel5.Name = "miLabel5";
            this.miLabel5.Size = new System.Drawing.Size(70, 15);
            this.miLabel5.TabIndex = 23;
            this.miLabel5.Text = "Antiguedad";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtModalidadContratacion
            // 
            this.txtModalidadContratacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtModalidadContratacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtModalidadContratacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModalidadContratacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtModalidadContratacion.ForeColor = System.Drawing.Color.Black;
            this.txtModalidadContratacion.Location = new System.Drawing.Point(160, 169);
            this.txtModalidadContratacion.MaxLength = 20;
            this.txtModalidadContratacion.Name = "txtModalidadContratacion";
            this.txtModalidadContratacion.ReadOnly = true;
            this.txtModalidadContratacion.Size = new System.Drawing.Size(170, 22);
            this.txtModalidadContratacion.TabIndex = 26;
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
            this.miLabel6.TabIndex = 25;
            this.miLabel6.Text = "Modalidad de contratación";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSindicato
            // 
            this.txtSindicato.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSindicato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtSindicato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSindicato.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtSindicato.ForeColor = System.Drawing.Color.Black;
            this.txtSindicato.Location = new System.Drawing.Point(160, 196);
            this.txtSindicato.MaxLength = 25;
            this.txtSindicato.Name = "txtSindicato";
            this.txtSindicato.ReadOnly = true;
            this.txtSindicato.Size = new System.Drawing.Size(210, 22);
            this.txtSindicato.TabIndex = 29;
            // 
            // chkAfiliadoSindical
            // 
            this.chkAfiliadoSindical.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkAfiliadoSindical.AutoSize = true;
            this.chkAfiliadoSindical.BackColor = System.Drawing.Color.Transparent;
            this.chkAfiliadoSindical.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkAfiliadoSindical.Enabled = false;
            this.chkAfiliadoSindical.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAfiliadoSindical.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkAfiliadoSindical.Location = new System.Drawing.Point(376, 198);
            this.chkAfiliadoSindical.Name = "chkAfiliadoSindical";
            this.chkAfiliadoSindical.Size = new System.Drawing.Size(132, 19);
            this.chkAfiliadoSindical.TabIndex = 30;
            this.chkAfiliadoSindical.Text = "Afiliado al sindicato";
            this.chkAfiliadoSindical.UseVisualStyleBackColor = false;
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
            this.miLabel7.TabIndex = 28;
            this.miLabel7.Text = "Sindicato";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCategoria
            // 
            this.txtCategoria.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategoria.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCategoria.ForeColor = System.Drawing.Color.Black;
            this.txtCategoria.Location = new System.Drawing.Point(160, 223);
            this.txtCategoria.MaxLength = 30;
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.ReadOnly = true;
            this.txtCategoria.Size = new System.Drawing.Size(265, 22);
            this.txtCategoria.TabIndex = 32;
            // 
            // miLabel8
            // 
            this.miLabel8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel8.BackColor = System.Drawing.Color.Transparent;
            this.miLabel8.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel8.Location = new System.Drawing.Point(0, 227);
            this.miLabel8.Name = "miLabel8";
            this.miLabel8.Size = new System.Drawing.Size(160, 15);
            this.miLabel8.TabIndex = 31;
            this.miLabel8.Text = "Categoría";
            this.miLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPuesto
            // 
            this.txtPuesto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPuesto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtPuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPuesto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtPuesto.ForeColor = System.Drawing.Color.Black;
            this.txtPuesto.Location = new System.Drawing.Point(160, 250);
            this.txtPuesto.MaxLength = 15;
            this.txtPuesto.Name = "txtPuesto";
            this.txtPuesto.ReadOnly = true;
            this.txtPuesto.Size = new System.Drawing.Size(170, 22);
            this.txtPuesto.TabIndex = 34;
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
            this.miLabel9.TabIndex = 33;
            this.miLabel9.Text = "Puesto - Sector";
            this.miLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSector
            // 
            this.txtSector.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtSector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSector.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtSector.ForeColor = System.Drawing.Color.Black;
            this.txtSector.Location = new System.Drawing.Point(332, 250);
            this.txtSector.MaxLength = 15;
            this.txtSector.Name = "txtSector";
            this.txtSector.ReadOnly = true;
            this.txtSector.Size = new System.Drawing.Size(168, 22);
            this.txtSector.TabIndex = 35;
            // 
            // txtModalidadLiquidacion
            // 
            this.txtModalidadLiquidacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtModalidadLiquidacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtModalidadLiquidacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModalidadLiquidacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtModalidadLiquidacion.ForeColor = System.Drawing.Color.Black;
            this.txtModalidadLiquidacion.Location = new System.Drawing.Point(160, 277);
            this.txtModalidadLiquidacion.MaxLength = 7;
            this.txtModalidadLiquidacion.Name = "txtModalidadLiquidacion";
            this.txtModalidadLiquidacion.ReadOnly = true;
            this.txtModalidadLiquidacion.Size = new System.Drawing.Size(70, 22);
            this.txtModalidadLiquidacion.TabIndex = 37;
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
            this.miLabel10.TabIndex = 36;
            this.miLabel10.Text = "Modalidad de liquidación";
            this.miLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.miLabel11.TabIndex = 38;
            this.miLabel11.Text = "Remuneración $";
            this.miLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemuneracion
            // 
            this.txtRemuneracion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtRemuneracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtRemuneracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemuneracion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtRemuneracion.ForeColor = System.Drawing.Color.Black;
            this.txtRemuneracion.Location = new System.Drawing.Point(160, 304);
            this.txtRemuneracion.MaxLength = 12;
            this.txtRemuneracion.Name = "txtRemuneracion";
            this.txtRemuneracion.ReadOnly = true;
            this.txtRemuneracion.Size = new System.Drawing.Size(85, 22);
            this.txtRemuneracion.TabIndex = 39;
            // 
            // txtObraSocial
            // 
            this.txtObraSocial.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtObraSocial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtObraSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObraSocial.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtObraSocial.ForeColor = System.Drawing.Color.Black;
            this.txtObraSocial.Location = new System.Drawing.Point(160, 331);
            this.txtObraSocial.MaxLength = 75;
            this.txtObraSocial.Multiline = true;
            this.txtObraSocial.Name = "txtObraSocial";
            this.txtObraSocial.ReadOnly = true;
            this.txtObraSocial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObraSocial.Size = new System.Drawing.Size(340, 36);
            this.txtObraSocial.TabIndex = 41;
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
            this.miLabel12.TabIndex = 40;
            this.miLabel12.Text = "Obra social";
            this.miLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtObservacion.BackColor = System.Drawing.Color.White;
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtObservacion.ForeColor = System.Drawing.Color.Black;
            this.txtObservacion.Location = new System.Drawing.Point(160, 372);
            this.txtObservacion.MaxLength = 250;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(340, 52);
            this.txtObservacion.TabIndex = 43;
            // 
            // miLabel13
            // 
            this.miLabel13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel13.BackColor = System.Drawing.Color.Transparent;
            this.miLabel13.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel13.Location = new System.Drawing.Point(0, 375);
            this.miLabel13.Name = "miLabel13";
            this.miLabel13.Size = new System.Drawing.Size(160, 15);
            this.miLabel13.TabIndex = 42;
            this.miLabel13.Text = "Observaciones";
            this.miLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEstablecerEnProceso
            // 
            this.chkEstablecerEnProceso.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkEstablecerEnProceso.AutoSize = true;
            this.chkEstablecerEnProceso.BackColor = System.Drawing.Color.Transparent;
            this.chkEstablecerEnProceso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkEstablecerEnProceso.Enabled = false;
            this.chkEstablecerEnProceso.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEstablecerEnProceso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkEstablecerEnProceso.Location = new System.Drawing.Point(256, 431);
            this.chkEstablecerEnProceso.Name = "chkEstablecerEnProceso";
            this.chkEstablecerEnProceso.Size = new System.Drawing.Size(225, 19);
            this.chkEstablecerEnProceso.TabIndex = 46;
            this.chkEstablecerEnProceso.Text = "Establecer estado como en proceso";
            this.chkEstablecerEnProceso.UseVisualStyleBackColor = false;
            this.chkEstablecerEnProceso.Visible = false;
            this.chkEstablecerEnProceso.CheckedChanged += new System.EventHandler(this.chkEstablecerEnProceso_CheckedChanged);
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstado.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtEstado.ForeColor = System.Drawing.Color.Black;
            this.txtEstado.Location = new System.Drawing.Point(160, 429);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(90, 22);
            this.txtEstado.TabIndex = 45;
            this.txtEstado.TextChanged += new System.EventHandler(this.txtEstado_TextChanged);
            // 
            // miLabel14
            // 
            this.miLabel14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel14.BackColor = System.Drawing.Color.Transparent;
            this.miLabel14.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel14.Location = new System.Drawing.Point(0, 432);
            this.miLabel14.Name = "miLabel14";
            this.miLabel14.Size = new System.Drawing.Size(160, 15);
            this.miLabel14.TabIndex = 44;
            this.miLabel14.Text = "Estado laboral";
            this.miLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtModalidadContratacionTiempo
            // 
            this.txtModalidadContratacionTiempo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtModalidadContratacionTiempo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtModalidadContratacionTiempo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModalidadContratacionTiempo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtModalidadContratacionTiempo.ForeColor = System.Drawing.Color.Black;
            this.txtModalidadContratacionTiempo.Location = new System.Drawing.Point(329, 169);
            this.txtModalidadContratacionTiempo.MaxLength = 20;
            this.txtModalidadContratacionTiempo.Name = "txtModalidadContratacionTiempo";
            this.txtModalidadContratacionTiempo.ReadOnly = true;
            this.txtModalidadContratacionTiempo.Size = new System.Drawing.Size(130, 22);
            this.txtModalidadContratacionTiempo.TabIndex = 27;
            // 
            // FormLegajoLaboral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.txtModalidadContratacionTiempo);
            this.Controls.Add(this.chkEstablecerEnProceso);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.miLabel14);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.miLabel13);
            this.Controls.Add(this.txtObraSocial);
            this.Controls.Add(this.miLabel12);
            this.Controls.Add(this.txtModalidadLiquidacion);
            this.Controls.Add(this.miLabel10);
            this.Controls.Add(this.txtSector);
            this.Controls.Add(this.txtPuesto);
            this.Controls.Add(this.miLabel9);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.miLabel8);
            this.Controls.Add(this.txtSindicato);
            this.Controls.Add(this.chkAfiliadoSindical);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.txtModalidadContratacion);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.txtFechaEgreso);
            this.Controls.Add(this.txtFechaIngreso);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.txtCentroCosto);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.btnLegajoLaboralDDJJ);
            this.Controls.Add(this.cmbLegajoLaboralDDJJ);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.btnBuscarLegajo);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtDenominacion);
            this.Controls.Add(this.txtAntiguedad);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.txtRemuneracion);
            this.Controls.Add(this.miLabel11);
            this.Name = "FormLegajoLaboral";
            this.Text = "Legajos - Laboral";
            this.Load += new System.EventHandler(this.FormLegajoLaboral_Load);
            this.Controls.SetChildIndex(this.miLabel11, 0);
            this.Controls.SetChildIndex(this.txtRemuneracion, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.txtAntiguedad, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.btnBuscarLegajo, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.txtCuit, 0);
            this.Controls.SetChildIndex(this.labelPublicacion, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnExcel_Registro, 0);
            this.Controls.SetChildIndex(this.btnPDF_Registro, 0);
            this.Controls.SetChildIndex(this.panelLista, 0);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.cmbLegajoLaboralDDJJ, 0);
            this.Controls.SetChildIndex(this.btnLegajoLaboralDDJJ, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.txtCentroCosto, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.txtFechaIngreso, 0);
            this.Controls.SetChildIndex(this.txtFechaEgreso, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.txtModalidadContratacion, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.chkAfiliadoSindical, 0);
            this.Controls.SetChildIndex(this.txtSindicato, 0);
            this.Controls.SetChildIndex(this.miLabel8, 0);
            this.Controls.SetChildIndex(this.txtCategoria, 0);
            this.Controls.SetChildIndex(this.miLabel9, 0);
            this.Controls.SetChildIndex(this.txtPuesto, 0);
            this.Controls.SetChildIndex(this.txtSector, 0);
            this.Controls.SetChildIndex(this.miLabel10, 0);
            this.Controls.SetChildIndex(this.txtModalidadLiquidacion, 0);
            this.Controls.SetChildIndex(this.miLabel12, 0);
            this.Controls.SetChildIndex(this.txtObraSocial, 0);
            this.Controls.SetChildIndex(this.miLabel13, 0);
            this.Controls.SetChildIndex(this.txtObservacion, 0);
            this.Controls.SetChildIndex(this.miLabel14, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.chkEstablecerEnProceso, 0);
            this.Controls.SetChildIndex(this.txtModalidadContratacionTiempo, 0);
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
        private Biblioteca.Controles.MiButtonBase btnLegajoLaboralDDJJ;
        private Biblioteca.Controles.MiComboBox cmbLegajoLaboralDDJJ;
        private Biblioteca.Controles.MiTextBoxRead txtCentroCosto;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiTextBoxRead txtFechaEgreso;
        private Biblioteca.Controles.MiTextBoxRead txtFechaIngreso;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiTextBoxRead txtAntiguedad;
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiTextBoxRead txtModalidadContratacion;
        private Biblioteca.Controles.MiLabel miLabel6;
        private Biblioteca.Controles.MiTextBoxRead txtSindicato;
        private Biblioteca.Controles.MiCheckBox chkAfiliadoSindical;
        private Biblioteca.Controles.MiLabel miLabel7;
        private Biblioteca.Controles.MiTextBoxRead txtCategoria;
        private Biblioteca.Controles.MiLabel miLabel8;
        private Biblioteca.Controles.MiTextBoxRead txtPuesto;
        private Biblioteca.Controles.MiLabel miLabel9;
        private Biblioteca.Controles.MiTextBoxRead txtSector;
        private Biblioteca.Controles.MiTextBoxRead txtModalidadLiquidacion;
        private Biblioteca.Controles.MiLabel miLabel10;
        private Biblioteca.Controles.MiLabel miLabel11;
        private Biblioteca.Controles.MiTextBoxRead txtRemuneracion;
        private Biblioteca.Controles.MiTextBoxRead txtObraSocial;
        private Biblioteca.Controles.MiLabel miLabel12;
        private Biblioteca.Controles.MiTextBox txtObservacion;
        private Biblioteca.Controles.MiLabel miLabel13;
        private Biblioteca.Controles.MiCheckBox chkEstablecerEnProceso;
        private Biblioteca.Controles.MiTextBoxRead txtEstado;
        private Biblioteca.Controles.MiLabel miLabel14;
        private Biblioteca.Controles.MiTextBoxRead txtModalidadContratacionTiempo;
    }
}