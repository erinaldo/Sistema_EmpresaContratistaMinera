namespace CapaPresentacion
{
    partial class FormLegajoDocumentacion
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
                nLegajoDocumentacion.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLegajoDocumentacion));
            this.btnBuscarLegajo = new Biblioteca.Controles.MiButtonFind();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.txtCuit = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.txtOtraDocumentacion = new Biblioteca.Controles.MiTextBox();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.chkRoles = new Biblioteca.Controles.MiCheckBox();
            this.chkReglamentoRRHH = new Biblioteca.Controles.MiCheckBox();
            this.chkExamenMedico = new Biblioteca.Controles.MiCheckBox();
            this.chkDocumentacionFamiliar = new Biblioteca.Controles.MiCheckBox();
            this.chkDDJJ = new Biblioteca.Controles.MiCheckBox();
            this.chkCurriculumVitae = new Biblioteca.Controles.MiCheckBox();
            this.chkCredencialART = new Biblioteca.Controles.MiCheckBox();
            this.chkCopiaTitulo = new Biblioteca.Controles.MiCheckBox();
            this.chkCopiaMatricula = new Biblioteca.Controles.MiCheckBox();
            this.chkCopiaLC = new Biblioteca.Controles.MiCheckBox();
            this.chkCopiaDNI = new Biblioteca.Controles.MiCheckBox();
            this.chkCopiaCA = new Biblioteca.Controles.MiCheckBox();
            this.chkContratoLaboral = new Biblioteca.Controles.MiCheckBox();
            this.chkAltaAFIP = new Biblioteca.Controles.MiCheckBox();
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
            this.btnAnular.Visible = false;
            // 
            // btnExcel_Registro
            // 
            this.btnExcel_Registro.FlatAppearance.BorderSize = 0;
            this.btnExcel_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Registro.Location = new System.Drawing.Point(241, 657);
            // 
            // btnPDF_Registro
            // 
            this.btnPDF_Registro.FlatAppearance.BorderSize = 0;
            this.btnPDF_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Registro.Location = new System.Drawing.Point(273, 657);
            // 
            // lblTituloLista
            // 
            this.lblTituloLista.Size = new System.Drawing.Size(318, 23);
            this.lblTituloLista.Text = "Lista de Legajos (Documentación)";
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
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(752, 36);
            this.lblCatalagoTitulo4.Text = "Campo4";
            this.lblCatalagoTitulo4.Visible = false;
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(801, 36);
            this.lblCatalagoTitulo5.Text = "Campo5";
            this.lblCatalagoTitulo5.Visible = false;
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(851, 36);
            this.lblCatalagoTitulo6.Text = "Campo6";
            this.lblCatalagoTitulo6.Visible = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Legajos - Documentación";
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
            this.btnBuscarLegajo.TabIndex = 14;
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
            this.miLabel1.TabIndex = 12;
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
            this.txtDenominacion.TabIndex = 13;
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
            this.txtCuit.TabIndex = 16;
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
            this.miLabel2.TabIndex = 15;
            this.miLabel2.Text = "CUIL/CUIT";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOtraDocumentacion
            // 
            this.txtOtraDocumentacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtOtraDocumentacion.BackColor = System.Drawing.Color.White;
            this.txtOtraDocumentacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOtraDocumentacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtOtraDocumentacion.ForeColor = System.Drawing.Color.Black;
            this.txtOtraDocumentacion.Location = new System.Drawing.Point(160, 428);
            this.txtOtraDocumentacion.MaxLength = 250;
            this.txtOtraDocumentacion.Multiline = true;
            this.txtOtraDocumentacion.Name = "txtOtraDocumentacion";
            this.txtOtraDocumentacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOtraDocumentacion.Size = new System.Drawing.Size(340, 52);
            this.txtOtraDocumentacion.TabIndex = 32;
            // 
            // miLabel3
            // 
            this.miLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel3.BackColor = System.Drawing.Color.Transparent;
            this.miLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel3.Location = new System.Drawing.Point(0, 431);
            this.miLabel3.Name = "miLabel3";
            this.miLabel3.Size = new System.Drawing.Size(160, 15);
            this.miLabel3.TabIndex = 31;
            this.miLabel3.Text = "Otra documentación";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkRoles
            // 
            this.chkRoles.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkRoles.AutoSize = true;
            this.chkRoles.BackColor = System.Drawing.Color.Transparent;
            this.chkRoles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkRoles.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRoles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkRoles.Location = new System.Drawing.Point(160, 403);
            this.chkRoles.Name = "chkRoles";
            this.chkRoles.Size = new System.Drawing.Size(59, 19);
            this.chkRoles.TabIndex = 30;
            this.chkRoles.Text = "Roles";
            this.chkRoles.UseVisualStyleBackColor = false;
            // 
            // chkReglamentoRRHH
            // 
            this.chkReglamentoRRHH.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkReglamentoRRHH.AutoSize = true;
            this.chkReglamentoRRHH.BackColor = System.Drawing.Color.Transparent;
            this.chkReglamentoRRHH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkReglamentoRRHH.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReglamentoRRHH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkReglamentoRRHH.Location = new System.Drawing.Point(160, 381);
            this.chkReglamentoRRHH.Name = "chkReglamentoRRHH";
            this.chkReglamentoRRHH.Size = new System.Drawing.Size(150, 19);
            this.chkReglamentoRRHH.TabIndex = 29;
            this.chkReglamentoRRHH.Text = "Reglamento de RRHH";
            this.chkReglamentoRRHH.UseVisualStyleBackColor = false;
            // 
            // chkExamenMedico
            // 
            this.chkExamenMedico.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkExamenMedico.AutoSize = true;
            this.chkExamenMedico.BackColor = System.Drawing.Color.Transparent;
            this.chkExamenMedico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkExamenMedico.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExamenMedico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkExamenMedico.Location = new System.Drawing.Point(160, 359);
            this.chkExamenMedico.Name = "chkExamenMedico";
            this.chkExamenMedico.Size = new System.Drawing.Size(115, 19);
            this.chkExamenMedico.TabIndex = 28;
            this.chkExamenMedico.Text = "Examen médico";
            this.chkExamenMedico.UseVisualStyleBackColor = false;
            // 
            // chkDocumentacionFamiliar
            // 
            this.chkDocumentacionFamiliar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkDocumentacionFamiliar.AutoSize = true;
            this.chkDocumentacionFamiliar.BackColor = System.Drawing.Color.Transparent;
            this.chkDocumentacionFamiliar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkDocumentacionFamiliar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDocumentacionFamiliar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkDocumentacionFamiliar.Location = new System.Drawing.Point(160, 337);
            this.chkDocumentacionFamiliar.Name = "chkDocumentacionFamiliar";
            this.chkDocumentacionFamiliar.Size = new System.Drawing.Size(157, 19);
            this.chkDocumentacionFamiliar.TabIndex = 27;
            this.chkDocumentacionFamiliar.Text = "Documentación familiar";
            this.chkDocumentacionFamiliar.UseVisualStyleBackColor = false;
            // 
            // chkDDJJ
            // 
            this.chkDDJJ.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkDDJJ.AutoSize = true;
            this.chkDDJJ.BackColor = System.Drawing.Color.Transparent;
            this.chkDDJJ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkDDJJ.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDDJJ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkDDJJ.Location = new System.Drawing.Point(160, 315);
            this.chkDDJJ.Name = "chkDDJJ";
            this.chkDDJJ.Size = new System.Drawing.Size(56, 19);
            this.chkDDJJ.TabIndex = 26;
            this.chkDDJJ.Text = "DDJJ";
            this.chkDDJJ.UseVisualStyleBackColor = false;
            // 
            // chkCurriculumVitae
            // 
            this.chkCurriculumVitae.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCurriculumVitae.AutoSize = true;
            this.chkCurriculumVitae.BackColor = System.Drawing.Color.Transparent;
            this.chkCurriculumVitae.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkCurriculumVitae.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCurriculumVitae.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkCurriculumVitae.Location = new System.Drawing.Point(160, 293);
            this.chkCurriculumVitae.Name = "chkCurriculumVitae";
            this.chkCurriculumVitae.Size = new System.Drawing.Size(115, 19);
            this.chkCurriculumVitae.TabIndex = 25;
            this.chkCurriculumVitae.Text = "Currículum vitae";
            this.chkCurriculumVitae.UseVisualStyleBackColor = false;
            // 
            // chkCredencialART
            // 
            this.chkCredencialART.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCredencialART.AutoSize = true;
            this.chkCredencialART.BackColor = System.Drawing.Color.Transparent;
            this.chkCredencialART.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkCredencialART.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCredencialART.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkCredencialART.Location = new System.Drawing.Point(160, 271);
            this.chkCredencialART.Name = "chkCredencialART";
            this.chkCredencialART.Size = new System.Drawing.Size(128, 19);
            this.chkCredencialART.TabIndex = 24;
            this.chkCredencialART.Text = "Credencial de ART";
            this.chkCredencialART.UseVisualStyleBackColor = false;
            // 
            // chkCopiaTitulo
            // 
            this.chkCopiaTitulo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCopiaTitulo.AutoSize = true;
            this.chkCopiaTitulo.BackColor = System.Drawing.Color.Transparent;
            this.chkCopiaTitulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkCopiaTitulo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCopiaTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkCopiaTitulo.Location = new System.Drawing.Point(160, 249);
            this.chkCopiaTitulo.Name = "chkCopiaTitulo";
            this.chkCopiaTitulo.Size = new System.Drawing.Size(105, 19);
            this.chkCopiaTitulo.TabIndex = 23;
            this.chkCopiaTitulo.Text = "Copia de título";
            this.chkCopiaTitulo.UseVisualStyleBackColor = false;
            // 
            // chkCopiaMatricula
            // 
            this.chkCopiaMatricula.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCopiaMatricula.AutoSize = true;
            this.chkCopiaMatricula.BackColor = System.Drawing.Color.Transparent;
            this.chkCopiaMatricula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkCopiaMatricula.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCopiaMatricula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkCopiaMatricula.Location = new System.Drawing.Point(160, 227);
            this.chkCopiaMatricula.Name = "chkCopiaMatricula";
            this.chkCopiaMatricula.Size = new System.Drawing.Size(130, 19);
            this.chkCopiaMatricula.TabIndex = 22;
            this.chkCopiaMatricula.Text = "Copia de matrícula";
            this.chkCopiaMatricula.UseVisualStyleBackColor = false;
            // 
            // chkCopiaLC
            // 
            this.chkCopiaLC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCopiaLC.AutoSize = true;
            this.chkCopiaLC.BackColor = System.Drawing.Color.Transparent;
            this.chkCopiaLC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkCopiaLC.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCopiaLC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkCopiaLC.Location = new System.Drawing.Point(160, 205);
            this.chkCopiaLC.Name = "chkCopiaLC";
            this.chkCopiaLC.Size = new System.Drawing.Size(188, 19);
            this.chkCopiaLC.TabIndex = 21;
            this.chkCopiaLC.Text = "Copia de licencia de conducir";
            this.chkCopiaLC.UseVisualStyleBackColor = false;
            // 
            // chkCopiaDNI
            // 
            this.chkCopiaDNI.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCopiaDNI.AutoSize = true;
            this.chkCopiaDNI.BackColor = System.Drawing.Color.Transparent;
            this.chkCopiaDNI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkCopiaDNI.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCopiaDNI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkCopiaDNI.Location = new System.Drawing.Point(160, 183);
            this.chkCopiaDNI.Name = "chkCopiaDNI";
            this.chkCopiaDNI.Size = new System.Drawing.Size(100, 19);
            this.chkCopiaDNI.TabIndex = 20;
            this.chkCopiaDNI.Text = "Copia de DNI";
            this.chkCopiaDNI.UseVisualStyleBackColor = false;
            // 
            // chkCopiaCA
            // 
            this.chkCopiaCA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCopiaCA.AutoSize = true;
            this.chkCopiaCA.BackColor = System.Drawing.Color.Transparent;
            this.chkCopiaCA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkCopiaCA.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCopiaCA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkCopiaCA.Location = new System.Drawing.Point(160, 161);
            this.chkCopiaCA.Name = "chkCopiaCA";
            this.chkCopiaCA.Size = new System.Drawing.Size(230, 19);
            this.chkCopiaCA.TabIndex = 19;
            this.chkCopiaCA.Text = "Copia de certificado de antecedentes";
            this.chkCopiaCA.UseVisualStyleBackColor = false;
            // 
            // chkContratoLaboral
            // 
            this.chkContratoLaboral.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkContratoLaboral.AutoSize = true;
            this.chkContratoLaboral.BackColor = System.Drawing.Color.Transparent;
            this.chkContratoLaboral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkContratoLaboral.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkContratoLaboral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkContratoLaboral.Location = new System.Drawing.Point(160, 139);
            this.chkContratoLaboral.Name = "chkContratoLaboral";
            this.chkContratoLaboral.Size = new System.Drawing.Size(114, 19);
            this.chkContratoLaboral.TabIndex = 18;
            this.chkContratoLaboral.Text = "Contrato laboral";
            this.chkContratoLaboral.UseVisualStyleBackColor = false;
            // 
            // chkAltaAFIP
            // 
            this.chkAltaAFIP.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkAltaAFIP.AutoSize = true;
            this.chkAltaAFIP.BackColor = System.Drawing.Color.Transparent;
            this.chkAltaAFIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkAltaAFIP.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAltaAFIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkAltaAFIP.Location = new System.Drawing.Point(160, 117);
            this.chkAltaAFIP.Name = "chkAltaAFIP";
            this.chkAltaAFIP.Size = new System.Drawing.Size(90, 19);
            this.chkAltaAFIP.TabIndex = 17;
            this.chkAltaAFIP.Text = "Alta de AFIP";
            this.chkAltaAFIP.UseVisualStyleBackColor = false;
            // 
            // FormLegajoDocumentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.txtOtraDocumentacion);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.chkRoles);
            this.Controls.Add(this.chkReglamentoRRHH);
            this.Controls.Add(this.chkExamenMedico);
            this.Controls.Add(this.chkDocumentacionFamiliar);
            this.Controls.Add(this.chkDDJJ);
            this.Controls.Add(this.chkCurriculumVitae);
            this.Controls.Add(this.chkCredencialART);
            this.Controls.Add(this.chkCopiaTitulo);
            this.Controls.Add(this.chkCopiaMatricula);
            this.Controls.Add(this.chkCopiaLC);
            this.Controls.Add(this.chkCopiaDNI);
            this.Controls.Add(this.chkCopiaCA);
            this.Controls.Add(this.chkContratoLaboral);
            this.Controls.Add(this.chkAltaAFIP);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.btnBuscarLegajo);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtDenominacion);
            this.Name = "FormLegajoDocumentacion";
            this.Text = "Legajo - Documentación";
            this.Load += new System.EventHandler(this.FormLegajoDocumentacion_Load);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.btnBuscarLegajo, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.txtCuit, 0);
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
            this.Controls.SetChildIndex(this.chkAltaAFIP, 0);
            this.Controls.SetChildIndex(this.chkContratoLaboral, 0);
            this.Controls.SetChildIndex(this.chkCopiaCA, 0);
            this.Controls.SetChildIndex(this.chkCopiaDNI, 0);
            this.Controls.SetChildIndex(this.chkCopiaLC, 0);
            this.Controls.SetChildIndex(this.chkCopiaMatricula, 0);
            this.Controls.SetChildIndex(this.chkCopiaTitulo, 0);
            this.Controls.SetChildIndex(this.chkCredencialART, 0);
            this.Controls.SetChildIndex(this.chkCurriculumVitae, 0);
            this.Controls.SetChildIndex(this.chkDDJJ, 0);
            this.Controls.SetChildIndex(this.chkDocumentacionFamiliar, 0);
            this.Controls.SetChildIndex(this.chkExamenMedico, 0);
            this.Controls.SetChildIndex(this.chkReglamentoRRHH, 0);
            this.Controls.SetChildIndex(this.chkRoles, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.txtOtraDocumentacion, 0);
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
        private Biblioteca.Controles.MiTextBox txtOtraDocumentacion;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiCheckBox chkRoles;
        private Biblioteca.Controles.MiCheckBox chkReglamentoRRHH;
        private Biblioteca.Controles.MiCheckBox chkExamenMedico;
        private Biblioteca.Controles.MiCheckBox chkDocumentacionFamiliar;
        private Biblioteca.Controles.MiCheckBox chkDDJJ;
        private Biblioteca.Controles.MiCheckBox chkCurriculumVitae;
        private Biblioteca.Controles.MiCheckBox chkCredencialART;
        private Biblioteca.Controles.MiCheckBox chkCopiaTitulo;
        private Biblioteca.Controles.MiCheckBox chkCopiaMatricula;
        private Biblioteca.Controles.MiCheckBox chkCopiaLC;
        private Biblioteca.Controles.MiCheckBox chkCopiaDNI;
        private Biblioteca.Controles.MiCheckBox chkCopiaCA;
        private Biblioteca.Controles.MiCheckBox chkContratoLaboral;
        private Biblioteca.Controles.MiCheckBox chkAltaAFIP;
    }
}