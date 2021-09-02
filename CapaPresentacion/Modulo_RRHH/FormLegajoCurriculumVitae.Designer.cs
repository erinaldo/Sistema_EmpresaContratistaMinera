namespace CapaPresentacion
{
    partial class FormLegajoCurriculumVitae
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
                nLegajoCurriculumVitae.Dispose();
                nRelacion_LegajoCurriculumVitae_PerfilLaboral.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLegajoCurriculumVitae));
            this.btnBuscarLegajo = new Biblioteca.Controles.MiButtonFind();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.txtCuit = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.cmbModalidadAdmision = new Biblioteca.Controles.MiComboBox();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.cmbNivelEstudio = new Biblioteca.Controles.MiComboBox();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.txtExperienciaLaboral = new Biblioteca.Controles.MiTextBox();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.chkTrabajoEmpreminsa = new Biblioteca.Controles.MiCheckBox();
            this.txtPerfilLaboral = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.groupLicenciaConducir = new System.Windows.Forms.GroupBox();
            this.pkrLicenciaConducirVto = new Biblioteca.Controles.MiDateTimePicker();
            this.lblLicenciaConducir2 = new Biblioteca.Controles.MiLabel();
            this.chkLicenciaConducir = new Biblioteca.Controles.MiCheckBox();
            this.lblLicenciaConducir1 = new Biblioteca.Controles.MiLabel();
            this.cmbLicenciaConducirColor = new Biblioteca.Controles.MiComboBox();
            this.txtLicenciaConducirCategoria = new Biblioteca.Controles.MiTextBox();
            this.groupCertificadoAntecentes = new System.Windows.Forms.GroupBox();
            this.pkrCertificadoAntecentesEmision = new Biblioteca.Controles.MiDateTimePicker();
            this.lblCertificadoAntecentes2 = new Biblioteca.Controles.MiLabel();
            this.chkCertificadoAntecentes = new Biblioteca.Controles.MiCheckBox();
            this.lblCertificadoAntecentes1 = new Biblioteca.Controles.MiLabel();
            this.cmbCertificadoAntecentesTipo = new Biblioteca.Controles.MiComboBox();
            this.btnPerfilLaboral = new Biblioteca.Controles.MiButtonFind();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.txtCurriculumVitaeVto = new Biblioteca.Controles.MiTextBoxRead();
            this.cmbCurriculumVitaeEstado = new Biblioteca.Controles.MiComboBox();
            this.miLabel9 = new Biblioteca.Controles.MiLabel();
            this.txtCurriculumVitaeDisponibilidad = new Biblioteca.Controles.MiTextBoxRead();
            this.txtCurriculumVitaeCalificacion = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel8 = new Biblioteca.Controles.MiLabel();
            this.panelLista.SuspendLayout();
            this.groupLicenciaConducir.SuspendLayout();
            this.groupCertificadoAntecentes.SuspendLayout();
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
            this.lblTituloLista.Size = new System.Drawing.Size(318, 23);
            this.lblTituloLista.Text = "Lista de Legajos (Currículum Vitae)";
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
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(40, 14);
            this.lblCatalagoTitulo4.Text = "Estado";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(805, 36);
            this.lblCatalagoTitulo5.Text = "Campo5";
            this.lblCatalagoTitulo5.Visible = false;
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(849, 36);
            this.lblCatalagoTitulo6.Text = "Campo6";
            this.lblCatalagoTitulo6.Visible = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Legajos - Currículum Vitae";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
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
            this.btnBuscarLegajo.TabIndex = 13;
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
            this.miLabel1.TabIndex = 11;
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
            this.txtDenominacion.TabIndex = 12;
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
            this.txtCuit.TabIndex = 15;
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
            this.miLabel2.Text = "CUIL/CUIT";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbModalidadAdmision
            // 
            this.cmbModalidadAdmision.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbModalidadAdmision.BackColor = System.Drawing.Color.White;
            this.cmbModalidadAdmision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModalidadAdmision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbModalidadAdmision.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbModalidadAdmision.ForeColor = System.Drawing.Color.Black;
            this.cmbModalidadAdmision.FormattingEnabled = true;
            this.cmbModalidadAdmision.ItemHeight = 14;
            this.cmbModalidadAdmision.Items.AddRange(new object[] {
            "BUSQUEDA ESPECIFICA",
            "PRESENTACION ESPONTANEA"});
            this.cmbModalidadAdmision.Location = new System.Drawing.Point(160, 115);
            this.cmbModalidadAdmision.Margin = new System.Windows.Forms.Padding(1);
            this.cmbModalidadAdmision.Name = "cmbModalidadAdmision";
            this.cmbModalidadAdmision.Size = new System.Drawing.Size(180, 22);
            this.cmbModalidadAdmision.Sorted = true;
            this.cmbModalidadAdmision.TabIndex = 17;
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
            this.miLabel3.TabIndex = 16;
            this.miLabel3.Text = "Modalidad de admisión CV";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbNivelEstudio
            // 
            this.cmbNivelEstudio.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbNivelEstudio.BackColor = System.Drawing.Color.White;
            this.cmbNivelEstudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivelEstudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNivelEstudio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbNivelEstudio.ForeColor = System.Drawing.Color.Black;
            this.cmbNivelEstudio.FormattingEnabled = true;
            this.cmbNivelEstudio.ItemHeight = 14;
            this.cmbNivelEstudio.Items.AddRange(new object[] {
            "PRIMARIO COMPLETO",
            "PRIMARIO INCOMPLETO",
            "SECUNDARIO COMPLETO",
            "SECUNDARIO INCOMPLETO",
            "SUPERIOR COMPLETO",
            "SUPERIOR INCOMPLETO",
            "TERCIARIO COMPLETO",
            "TERCIARIO INCOMPLETO",
            "UNIVERSITARIO COMPLETO",
            "UNIVERSITARIO INCOMPLETO"});
            this.cmbNivelEstudio.Location = new System.Drawing.Point(160, 142);
            this.cmbNivelEstudio.Margin = new System.Windows.Forms.Padding(1);
            this.cmbNivelEstudio.Name = "cmbNivelEstudio";
            this.cmbNivelEstudio.Size = new System.Drawing.Size(180, 22);
            this.cmbNivelEstudio.Sorted = true;
            this.cmbNivelEstudio.TabIndex = 19;
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
            this.miLabel4.TabIndex = 18;
            this.miLabel4.Text = "Nivel de estudios";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtExperienciaLaboral
            // 
            this.txtExperienciaLaboral.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtExperienciaLaboral.BackColor = System.Drawing.Color.White;
            this.txtExperienciaLaboral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExperienciaLaboral.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtExperienciaLaboral.ForeColor = System.Drawing.Color.Black;
            this.txtExperienciaLaboral.Location = new System.Drawing.Point(160, 169);
            this.txtExperienciaLaboral.MaxLength = 250;
            this.txtExperienciaLaboral.Multiline = true;
            this.txtExperienciaLaboral.Name = "txtExperienciaLaboral";
            this.txtExperienciaLaboral.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExperienciaLaboral.Size = new System.Drawing.Size(340, 52);
            this.txtExperienciaLaboral.TabIndex = 21;
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
            this.miLabel5.TabIndex = 20;
            this.miLabel5.Text = "Experiencia laboral";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkTrabajoEmpreminsa
            // 
            this.chkTrabajoEmpreminsa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkTrabajoEmpreminsa.AutoSize = true;
            this.chkTrabajoEmpreminsa.BackColor = System.Drawing.Color.Transparent;
            this.chkTrabajoEmpreminsa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkTrabajoEmpreminsa.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrabajoEmpreminsa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkTrabajoEmpreminsa.Location = new System.Drawing.Point(160, 229);
            this.chkTrabajoEmpreminsa.Name = "chkTrabajoEmpreminsa";
            this.chkTrabajoEmpreminsa.Size = new System.Drawing.Size(160, 19);
            this.chkTrabajoEmpreminsa.TabIndex = 22;
            this.chkTrabajoEmpreminsa.Text = "Trabajó en Empreminsa";
            this.chkTrabajoEmpreminsa.UseVisualStyleBackColor = false;
            // 
            // txtPerfilLaboral
            // 
            this.txtPerfilLaboral.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPerfilLaboral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtPerfilLaboral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPerfilLaboral.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtPerfilLaboral.ForeColor = System.Drawing.Color.Black;
            this.txtPerfilLaboral.Location = new System.Drawing.Point(160, 253);
            this.txtPerfilLaboral.Multiline = true;
            this.txtPerfilLaboral.Name = "txtPerfilLaboral";
            this.txtPerfilLaboral.ReadOnly = true;
            this.txtPerfilLaboral.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPerfilLaboral.Size = new System.Drawing.Size(340, 52);
            this.txtPerfilLaboral.TabIndex = 24;
            // 
            // miLabel6
            // 
            this.miLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel6.BackColor = System.Drawing.Color.Transparent;
            this.miLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel6.Location = new System.Drawing.Point(0, 256);
            this.miLabel6.Name = "miLabel6";
            this.miLabel6.Size = new System.Drawing.Size(160, 15);
            this.miLabel6.TabIndex = 23;
            this.miLabel6.Text = "Perfiles laborales";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupLicenciaConducir
            // 
            this.groupLicenciaConducir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupLicenciaConducir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupLicenciaConducir.Controls.Add(this.pkrLicenciaConducirVto);
            this.groupLicenciaConducir.Controls.Add(this.lblLicenciaConducir2);
            this.groupLicenciaConducir.Controls.Add(this.chkLicenciaConducir);
            this.groupLicenciaConducir.Controls.Add(this.lblLicenciaConducir1);
            this.groupLicenciaConducir.Controls.Add(this.cmbLicenciaConducirColor);
            this.groupLicenciaConducir.Controls.Add(this.txtLicenciaConducirCategoria);
            this.groupLicenciaConducir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupLicenciaConducir.ForeColor = System.Drawing.Color.Gray;
            this.groupLicenciaConducir.Location = new System.Drawing.Point(160, 311);
            this.groupLicenciaConducir.Name = "groupLicenciaConducir";
            this.groupLicenciaConducir.Size = new System.Drawing.Size(291, 71);
            this.groupLicenciaConducir.TabIndex = 26;
            this.groupLicenciaConducir.TabStop = false;
            this.groupLicenciaConducir.Text = "      Licencia de conducir";
            // 
            // pkrLicenciaConducirVto
            // 
            this.pkrLicenciaConducirVto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrLicenciaConducirVto.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrLicenciaConducirVto.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrLicenciaConducirVto.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrLicenciaConducirVto.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrLicenciaConducirVto.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrLicenciaConducirVto.CustomFormat = "dd/MM/yyyy";
            this.pkrLicenciaConducirVto.Enabled = false;
            this.pkrLicenciaConducirVto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrLicenciaConducirVto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrLicenciaConducirVto.Location = new System.Drawing.Point(145, 42);
            this.pkrLicenciaConducirVto.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrLicenciaConducirVto.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrLicenciaConducirVto.Name = "pkrLicenciaConducirVto";
            this.pkrLicenciaConducirVto.Size = new System.Drawing.Size(102, 22);
            this.pkrLicenciaConducirVto.TabIndex = 0;
            this.pkrLicenciaConducirVto.Visible = false;
            // 
            // lblLicenciaConducir2
            // 
            this.lblLicenciaConducir2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLicenciaConducir2.BackColor = System.Drawing.Color.Transparent;
            this.lblLicenciaConducir2.Enabled = false;
            this.lblLicenciaConducir2.Font = new System.Drawing.Font("Arial", 9F);
            this.lblLicenciaConducir2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblLicenciaConducir2.Location = new System.Drawing.Point(0, 45);
            this.lblLicenciaConducir2.Name = "lblLicenciaConducir2";
            this.lblLicenciaConducir2.Size = new System.Drawing.Size(145, 15);
            this.lblLicenciaConducir2.TabIndex = 5;
            this.lblLicenciaConducir2.Text = "Fecha de vto.";
            this.lblLicenciaConducir2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLicenciaConducir2.Visible = false;
            // 
            // chkLicenciaConducir
            // 
            this.chkLicenciaConducir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkLicenciaConducir.AutoSize = true;
            this.chkLicenciaConducir.BackColor = System.Drawing.Color.Transparent;
            this.chkLicenciaConducir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkLicenciaConducir.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLicenciaConducir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkLicenciaConducir.Location = new System.Drawing.Point(11, 1);
            this.chkLicenciaConducir.Name = "chkLicenciaConducir";
            this.chkLicenciaConducir.Size = new System.Drawing.Size(15, 14);
            this.chkLicenciaConducir.TabIndex = 1;
            this.chkLicenciaConducir.UseVisualStyleBackColor = false;
            this.chkLicenciaConducir.CheckedChanged += new System.EventHandler(this.chkLicenciaConducir_CheckedChanged);
            // 
            // lblLicenciaConducir1
            // 
            this.lblLicenciaConducir1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLicenciaConducir1.BackColor = System.Drawing.Color.Transparent;
            this.lblLicenciaConducir1.Enabled = false;
            this.lblLicenciaConducir1.Font = new System.Drawing.Font("Arial", 9F);
            this.lblLicenciaConducir1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblLicenciaConducir1.Location = new System.Drawing.Point(0, 18);
            this.lblLicenciaConducir1.Name = "lblLicenciaConducir1";
            this.lblLicenciaConducir1.Size = new System.Drawing.Size(145, 15);
            this.lblLicenciaConducir1.TabIndex = 2;
            this.lblLicenciaConducir1.Text = "Categoría(s) - Color";
            this.lblLicenciaConducir1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLicenciaConducir1.Visible = false;
            // 
            // cmbLicenciaConducirColor
            // 
            this.cmbLicenciaConducirColor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbLicenciaConducirColor.BackColor = System.Drawing.Color.White;
            this.cmbLicenciaConducirColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLicenciaConducirColor.Enabled = false;
            this.cmbLicenciaConducirColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLicenciaConducirColor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbLicenciaConducirColor.ForeColor = System.Drawing.Color.Black;
            this.cmbLicenciaConducirColor.FormattingEnabled = true;
            this.cmbLicenciaConducirColor.ItemHeight = 14;
            this.cmbLicenciaConducirColor.Items.AddRange(new object[] {
            "CELESTE",
            "ROJO",
            "S/D",
            "VERDE"});
            this.cmbLicenciaConducirColor.Location = new System.Drawing.Point(202, 15);
            this.cmbLicenciaConducirColor.Margin = new System.Windows.Forms.Padding(1);
            this.cmbLicenciaConducirColor.Name = "cmbLicenciaConducirColor";
            this.cmbLicenciaConducirColor.Size = new System.Drawing.Size(80, 22);
            this.cmbLicenciaConducirColor.Sorted = true;
            this.cmbLicenciaConducirColor.TabIndex = 4;
            this.cmbLicenciaConducirColor.Visible = false;
            // 
            // txtLicenciaConducirCategoria
            // 
            this.txtLicenciaConducirCategoria.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtLicenciaConducirCategoria.BackColor = System.Drawing.Color.White;
            this.txtLicenciaConducirCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLicenciaConducirCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLicenciaConducirCategoria.Enabled = false;
            this.txtLicenciaConducirCategoria.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtLicenciaConducirCategoria.ForeColor = System.Drawing.Color.Black;
            this.txtLicenciaConducirCategoria.Location = new System.Drawing.Point(145, 15);
            this.txtLicenciaConducirCategoria.MaxLength = 7;
            this.txtLicenciaConducirCategoria.Name = "txtLicenciaConducirCategoria";
            this.txtLicenciaConducirCategoria.Size = new System.Drawing.Size(55, 22);
            this.txtLicenciaConducirCategoria.TabIndex = 3;
            this.txtLicenciaConducirCategoria.Visible = false;
            // 
            // groupCertificadoAntecentes
            // 
            this.groupCertificadoAntecentes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupCertificadoAntecentes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupCertificadoAntecentes.Controls.Add(this.pkrCertificadoAntecentesEmision);
            this.groupCertificadoAntecentes.Controls.Add(this.lblCertificadoAntecentes2);
            this.groupCertificadoAntecentes.Controls.Add(this.chkCertificadoAntecentes);
            this.groupCertificadoAntecentes.Controls.Add(this.lblCertificadoAntecentes1);
            this.groupCertificadoAntecentes.Controls.Add(this.cmbCertificadoAntecentesTipo);
            this.groupCertificadoAntecentes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupCertificadoAntecentes.ForeColor = System.Drawing.Color.Gray;
            this.groupCertificadoAntecentes.Location = new System.Drawing.Point(457, 311);
            this.groupCertificadoAntecentes.Name = "groupCertificadoAntecentes";
            this.groupCertificadoAntecentes.Size = new System.Drawing.Size(291, 71);
            this.groupCertificadoAntecentes.TabIndex = 27;
            this.groupCertificadoAntecentes.TabStop = false;
            this.groupCertificadoAntecentes.Text = "      Certificado de antecedentes";
            // 
            // pkrCertificadoAntecentesEmision
            // 
            this.pkrCertificadoAntecentesEmision.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrCertificadoAntecentesEmision.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrCertificadoAntecentesEmision.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrCertificadoAntecentesEmision.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrCertificadoAntecentesEmision.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrCertificadoAntecentesEmision.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrCertificadoAntecentesEmision.CustomFormat = "dd/MM/yyyy";
            this.pkrCertificadoAntecentesEmision.Enabled = false;
            this.pkrCertificadoAntecentesEmision.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrCertificadoAntecentesEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrCertificadoAntecentesEmision.Location = new System.Drawing.Point(145, 42);
            this.pkrCertificadoAntecentesEmision.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrCertificadoAntecentesEmision.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrCertificadoAntecentesEmision.Name = "pkrCertificadoAntecentesEmision";
            this.pkrCertificadoAntecentesEmision.Size = new System.Drawing.Size(102, 22);
            this.pkrCertificadoAntecentesEmision.TabIndex = 4;
            this.pkrCertificadoAntecentesEmision.Visible = false;
            // 
            // lblCertificadoAntecentes2
            // 
            this.lblCertificadoAntecentes2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCertificadoAntecentes2.BackColor = System.Drawing.Color.Transparent;
            this.lblCertificadoAntecentes2.Enabled = false;
            this.lblCertificadoAntecentes2.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCertificadoAntecentes2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblCertificadoAntecentes2.Location = new System.Drawing.Point(0, 45);
            this.lblCertificadoAntecentes2.Name = "lblCertificadoAntecentes2";
            this.lblCertificadoAntecentes2.Size = new System.Drawing.Size(145, 15);
            this.lblCertificadoAntecentes2.TabIndex = 3;
            this.lblCertificadoAntecentes2.Text = "Fecha de emisión";
            this.lblCertificadoAntecentes2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCertificadoAntecentes2.Visible = false;
            // 
            // chkCertificadoAntecentes
            // 
            this.chkCertificadoAntecentes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCertificadoAntecentes.AutoSize = true;
            this.chkCertificadoAntecentes.BackColor = System.Drawing.Color.Transparent;
            this.chkCertificadoAntecentes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkCertificadoAntecentes.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCertificadoAntecentes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkCertificadoAntecentes.Location = new System.Drawing.Point(11, 1);
            this.chkCertificadoAntecentes.Name = "chkCertificadoAntecentes";
            this.chkCertificadoAntecentes.Size = new System.Drawing.Size(15, 14);
            this.chkCertificadoAntecentes.TabIndex = 0;
            this.chkCertificadoAntecentes.UseVisualStyleBackColor = false;
            this.chkCertificadoAntecentes.CheckedChanged += new System.EventHandler(this.chkCertificadoAntecentes_CheckedChanged);
            // 
            // lblCertificadoAntecentes1
            // 
            this.lblCertificadoAntecentes1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCertificadoAntecentes1.BackColor = System.Drawing.Color.Transparent;
            this.lblCertificadoAntecentes1.Enabled = false;
            this.lblCertificadoAntecentes1.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCertificadoAntecentes1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblCertificadoAntecentes1.Location = new System.Drawing.Point(0, 18);
            this.lblCertificadoAntecentes1.Name = "lblCertificadoAntecentes1";
            this.lblCertificadoAntecentes1.Size = new System.Drawing.Size(145, 15);
            this.lblCertificadoAntecentes1.TabIndex = 1;
            this.lblCertificadoAntecentes1.Text = "Tipo";
            this.lblCertificadoAntecentes1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCertificadoAntecentes1.Visible = false;
            // 
            // cmbCertificadoAntecentesTipo
            // 
            this.cmbCertificadoAntecentesTipo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbCertificadoAntecentesTipo.BackColor = System.Drawing.Color.White;
            this.cmbCertificadoAntecentesTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCertificadoAntecentesTipo.Enabled = false;
            this.cmbCertificadoAntecentesTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCertificadoAntecentesTipo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCertificadoAntecentesTipo.ForeColor = System.Drawing.Color.Black;
            this.cmbCertificadoAntecentesTipo.FormattingEnabled = true;
            this.cmbCertificadoAntecentesTipo.ItemHeight = 14;
            this.cmbCertificadoAntecentesTipo.Items.AddRange(new object[] {
            "NACIONAL",
            "PROVINCIAL"});
            this.cmbCertificadoAntecentesTipo.Location = new System.Drawing.Point(145, 15);
            this.cmbCertificadoAntecentesTipo.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCertificadoAntecentesTipo.Name = "cmbCertificadoAntecentesTipo";
            this.cmbCertificadoAntecentesTipo.Size = new System.Drawing.Size(90, 22);
            this.cmbCertificadoAntecentesTipo.Sorted = true;
            this.cmbCertificadoAntecentesTipo.TabIndex = 2;
            this.cmbCertificadoAntecentesTipo.Visible = false;
            // 
            // btnPerfilLaboral
            // 
            this.btnPerfilLaboral.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPerfilLaboral.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPerfilLaboral.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_setup32;
            this.btnPerfilLaboral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPerfilLaboral.FlatAppearance.BorderSize = 0;
            this.btnPerfilLaboral.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPerfilLaboral.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPerfilLaboral.Font = new System.Drawing.Font("Arial", 9F);
            this.btnPerfilLaboral.ForeColor = System.Drawing.Color.Black;
            this.btnPerfilLaboral.Location = new System.Drawing.Point(501, 252);
            this.btnPerfilLaboral.Name = "btnPerfilLaboral";
            this.btnPerfilLaboral.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPerfilLaboral.Size = new System.Drawing.Size(24, 24);
            this.btnPerfilLaboral.TabIndex = 25;
            this.btnPerfilLaboral.UseVisualStyleBackColor = false;
            this.btnPerfilLaboral.Click += new System.EventHandler(this.btnPerfilLaboral_Click);
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(0, 389);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(160, 15);
            this.miLabel7.TabIndex = 28;
            this.miLabel7.Text = "Disponibilidad laboral";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCurriculumVitaeVto
            // 
            this.txtCurriculumVitaeVto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCurriculumVitaeVto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtCurriculumVitaeVto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurriculumVitaeVto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCurriculumVitaeVto.ForeColor = System.Drawing.Color.Black;
            this.txtCurriculumVitaeVto.Location = new System.Drawing.Point(241, 440);
            this.txtCurriculumVitaeVto.Name = "txtCurriculumVitaeVto";
            this.txtCurriculumVitaeVto.ReadOnly = true;
            this.txtCurriculumVitaeVto.Size = new System.Drawing.Size(75, 22);
            this.txtCurriculumVitaeVto.TabIndex = 34;
            // 
            // cmbCurriculumVitaeEstado
            // 
            this.cmbCurriculumVitaeEstado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbCurriculumVitaeEstado.BackColor = System.Drawing.Color.White;
            this.cmbCurriculumVitaeEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurriculumVitaeEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCurriculumVitaeEstado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCurriculumVitaeEstado.ForeColor = System.Drawing.Color.Black;
            this.cmbCurriculumVitaeEstado.FormattingEnabled = true;
            this.cmbCurriculumVitaeEstado.ItemHeight = 14;
            this.cmbCurriculumVitaeEstado.Items.AddRange(new object[] {
            "OBSOLETO",
            "VIGENTE"});
            this.cmbCurriculumVitaeEstado.Location = new System.Drawing.Point(160, 440);
            this.cmbCurriculumVitaeEstado.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCurriculumVitaeEstado.Name = "cmbCurriculumVitaeEstado";
            this.cmbCurriculumVitaeEstado.Size = new System.Drawing.Size(82, 22);
            this.cmbCurriculumVitaeEstado.Sorted = true;
            this.cmbCurriculumVitaeEstado.TabIndex = 33;
            this.cmbCurriculumVitaeEstado.SelectedIndexChanged += new System.EventHandler(this.cmbCurriculumVitaeEstado_SelectedIndexChanged);
            // 
            // miLabel9
            // 
            this.miLabel9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel9.BackColor = System.Drawing.Color.Transparent;
            this.miLabel9.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel9.Location = new System.Drawing.Point(0, 443);
            this.miLabel9.Name = "miLabel9";
            this.miLabel9.Size = new System.Drawing.Size(160, 15);
            this.miLabel9.TabIndex = 32;
            this.miLabel9.Text = "Estado y fecha de vto. CV";
            this.miLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCurriculumVitaeDisponibilidad
            // 
            this.txtCurriculumVitaeDisponibilidad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCurriculumVitaeDisponibilidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtCurriculumVitaeDisponibilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurriculumVitaeDisponibilidad.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCurriculumVitaeDisponibilidad.ForeColor = System.Drawing.Color.Black;
            this.txtCurriculumVitaeDisponibilidad.Location = new System.Drawing.Point(160, 386);
            this.txtCurriculumVitaeDisponibilidad.Name = "txtCurriculumVitaeDisponibilidad";
            this.txtCurriculumVitaeDisponibilidad.ReadOnly = true;
            this.txtCurriculumVitaeDisponibilidad.Size = new System.Drawing.Size(52, 22);
            this.txtCurriculumVitaeDisponibilidad.TabIndex = 29;
            // 
            // txtCurriculumVitaeCalificacion
            // 
            this.txtCurriculumVitaeCalificacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCurriculumVitaeCalificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtCurriculumVitaeCalificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurriculumVitaeCalificacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCurriculumVitaeCalificacion.ForeColor = System.Drawing.Color.Black;
            this.txtCurriculumVitaeCalificacion.Location = new System.Drawing.Point(160, 413);
            this.txtCurriculumVitaeCalificacion.Name = "txtCurriculumVitaeCalificacion";
            this.txtCurriculumVitaeCalificacion.ReadOnly = true;
            this.txtCurriculumVitaeCalificacion.Size = new System.Drawing.Size(120, 22);
            this.txtCurriculumVitaeCalificacion.TabIndex = 31;
            // 
            // miLabel8
            // 
            this.miLabel8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel8.BackColor = System.Drawing.Color.Transparent;
            this.miLabel8.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel8.Location = new System.Drawing.Point(0, 416);
            this.miLabel8.Name = "miLabel8";
            this.miLabel8.Size = new System.Drawing.Size(160, 15);
            this.miLabel8.TabIndex = 30;
            this.miLabel8.Text = "Calificación CV";
            this.miLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormLegajoCurriculumVitae
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.txtCurriculumVitaeCalificacion);
            this.Controls.Add(this.miLabel8);
            this.Controls.Add(this.txtCurriculumVitaeDisponibilidad);
            this.Controls.Add(this.txtCurriculumVitaeVto);
            this.Controls.Add(this.cmbCurriculumVitaeEstado);
            this.Controls.Add(this.miLabel9);
            this.Controls.Add(this.btnPerfilLaboral);
            this.Controls.Add(this.groupCertificadoAntecentes);
            this.Controls.Add(this.groupLicenciaConducir);
            this.Controls.Add(this.txtExperienciaLaboral);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.cmbNivelEstudio);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.cmbModalidadAdmision);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.btnBuscarLegajo);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtDenominacion);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.txtPerfilLaboral);
            this.Controls.Add(this.chkTrabajoEmpreminsa);
            this.Controls.Add(this.miLabel7);
            this.Name = "FormLegajoCurriculumVitae";
            this.Text = "Legajos - Currículum Vitae";
            this.Load += new System.EventHandler(this.FormLegajoCurriculumVitae_Load);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.chkTrabajoEmpreminsa, 0);
            this.Controls.SetChildIndex(this.txtPerfilLaboral, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.btnBuscarLegajo, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.txtCuit, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.cmbModalidadAdmision, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.cmbNivelEstudio, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.txtExperienciaLaboral, 0);
            this.Controls.SetChildIndex(this.groupLicenciaConducir, 0);
            this.Controls.SetChildIndex(this.groupCertificadoAntecentes, 0);
            this.Controls.SetChildIndex(this.btnPerfilLaboral, 0);
            this.Controls.SetChildIndex(this.miLabel9, 0);
            this.Controls.SetChildIndex(this.cmbCurriculumVitaeEstado, 0);
            this.Controls.SetChildIndex(this.txtCurriculumVitaeVto, 0);
            this.Controls.SetChildIndex(this.txtCurriculumVitaeDisponibilidad, 0);
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
            this.Controls.SetChildIndex(this.miLabel8, 0);
            this.Controls.SetChildIndex(this.txtCurriculumVitaeCalificacion, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            this.groupLicenciaConducir.ResumeLayout(false);
            this.groupLicenciaConducir.PerformLayout();
            this.groupCertificadoAntecentes.ResumeLayout(false);
            this.groupCertificadoAntecentes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Biblioteca.Controles.MiButtonFind btnBuscarLegajo;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBox txtDenominacion;
        private Biblioteca.Controles.MiTextBoxRead txtCuit;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiComboBox cmbModalidadAdmision;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiComboBox cmbNivelEstudio;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiTextBox txtExperienciaLaboral;
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiCheckBox chkTrabajoEmpreminsa;
        private Biblioteca.Controles.MiTextBoxRead txtPerfilLaboral;
        private Biblioteca.Controles.MiLabel miLabel6;
        private System.Windows.Forms.GroupBox groupLicenciaConducir;
        private Biblioteca.Controles.MiDateTimePicker pkrLicenciaConducirVto;
        private Biblioteca.Controles.MiLabel lblLicenciaConducir2;
        private Biblioteca.Controles.MiCheckBox chkLicenciaConducir;
        private Biblioteca.Controles.MiLabel lblLicenciaConducir1;
        private Biblioteca.Controles.MiComboBox cmbLicenciaConducirColor;
        private Biblioteca.Controles.MiTextBox txtLicenciaConducirCategoria;
        private System.Windows.Forms.GroupBox groupCertificadoAntecentes;
        private Biblioteca.Controles.MiDateTimePicker pkrCertificadoAntecentesEmision;
        private Biblioteca.Controles.MiLabel lblCertificadoAntecentes2;
        private Biblioteca.Controles.MiCheckBox chkCertificadoAntecentes;
        private Biblioteca.Controles.MiLabel lblCertificadoAntecentes1;
        private Biblioteca.Controles.MiComboBox cmbCertificadoAntecentesTipo;
        private Biblioteca.Controles.MiButtonFind btnPerfilLaboral;
        private Biblioteca.Controles.MiLabel miLabel7;
        private Biblioteca.Controles.MiTextBoxRead txtCurriculumVitaeVto;
        private Biblioteca.Controles.MiComboBox cmbCurriculumVitaeEstado;
        private Biblioteca.Controles.MiLabel miLabel9;
        private Biblioteca.Controles.MiTextBoxRead txtCurriculumVitaeDisponibilidad;
        private Biblioteca.Controles.MiTextBoxRead txtCurriculumVitaeCalificacion;
        private Biblioteca.Controles.MiLabel miLabel8;
    }
}