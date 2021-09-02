namespace CapaPresentacion
{
    partial class FormSindicato
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
                nSindicato.Dispose();
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
            this.txtConvenio = new Biblioteca.Controles.MiTextBox();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.txtAporteSolidarioFijo = new Biblioteca.Controles.MiTextBox();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.txtAporteSolidarioTasa = new Biblioteca.Controles.MiTextBox();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.txtCuotaAfiliadoFijo = new Biblioteca.Controles.MiTextBox();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.txtCuotaAfiliadoTasa = new Biblioteca.Controles.MiTextBox();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSeguroSocialTasa = new Biblioteca.Controles.MiTextBox();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.txtSeguroSocialFijo = new Biblioteca.Controles.MiTextBox();
            this.miLabel8 = new Biblioteca.Controles.MiLabel();
            this.txtFCLMasDeUnAnio = new Biblioteca.Controles.MiTextBox();
            this.miLabel10 = new Biblioteca.Controles.MiLabel();
            this.txtFCLPrimerAnio = new Biblioteca.Controles.MiTextBox();
            this.miLabel9 = new Biblioteca.Controles.MiLabel();
            this.chkIncluyeTotalNR = new Biblioteca.Controles.MiCheckBox();
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
            this.lblTituloLista.Text = "Lista de Sindicatos";
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
            // lblCatalagoTitulo2
            // 
            this.lblCatalagoTitulo2.Size = new System.Drawing.Size(52, 14);
            this.lblCatalagoTitulo2.Text = "Convenio";
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(154, 36);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(74, 14);
            this.lblCatalagoTitulo3.Text = "Denominación";
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(350, 36);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(125, 14);
            this.lblCatalagoTitulo4.Text = "A. Sindical (fija y/o tasa)";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(497, 36);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(130, 14);
            this.lblCatalagoTitulo5.Text = "C. Afiliación (fija y/o tasa)";
            // 
            // panelLista
            // 
            this.panelLista.Controls.Add(this.label1);
            this.panelLista.Controls.SetChildIndex(this.lstCatalogo, 0);
            this.panelLista.Controls.SetChildIndex(this.pkrFiltroListaDesde, 0);
            this.panelLista.Controls.SetChildIndex(this.pkrFiltroListaHasta, 0);
            this.panelLista.Controls.SetChildIndex(this.lblTituloLista, 0);
            this.panelLista.Controls.SetChildIndex(this.cmbFiltroLista1, 0);
            this.panelLista.Controls.SetChildIndex(this.cmbFiltroLista2, 0);
            this.panelLista.Controls.SetChildIndex(this.txtFiltroLista, 0);
            this.panelLista.Controls.SetChildIndex(this.btnExcel_Lista, 0);
            this.panelLista.Controls.SetChildIndex(this.btnPDF_Lista, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo1, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo2, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo3, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo4, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo5, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo6, 0);
            this.panelLista.Controls.SetChildIndex(this.label1, 0);
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(644, 36);
            this.lblCatalagoTitulo6.Size = new System.Drawing.Size(116, 14);
            this.lblCatalagoTitulo6.Text = "S. Social (fija y/o tasa)";
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Sindicatos";
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
            this.miLabel1.Location = new System.Drawing.Point(0, 63);
            this.miLabel1.Name = "miLabel1";
            this.miLabel1.Size = new System.Drawing.Size(160, 15);
            this.miLabel1.TabIndex = 11;
            this.miLabel1.Text = "Convenio";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConvenio
            // 
            this.txtConvenio.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtConvenio.BackColor = System.Drawing.Color.White;
            this.txtConvenio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConvenio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConvenio.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtConvenio.ForeColor = System.Drawing.Color.Black;
            this.txtConvenio.Location = new System.Drawing.Point(160, 61);
            this.txtConvenio.MaxLength = 8;
            this.txtConvenio.Name = "txtConvenio";
            this.txtConvenio.Size = new System.Drawing.Size(68, 22);
            this.txtConvenio.TabIndex = 12;
            // 
            // miLabel2
            // 
            this.miLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel2.BackColor = System.Drawing.Color.Transparent;
            this.miLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel2.Location = new System.Drawing.Point(0, 90);
            this.miLabel2.Name = "miLabel2";
            this.miLabel2.Size = new System.Drawing.Size(160, 15);
            this.miLabel2.TabIndex = 13;
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
            this.txtDenominacion.MaxLength = 25;
            this.txtDenominacion.Name = "txtDenominacion";
            this.txtDenominacion.Size = new System.Drawing.Size(240, 22);
            this.txtDenominacion.TabIndex = 14;
            // 
            // txtAporteSolidarioFijo
            // 
            this.txtAporteSolidarioFijo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAporteSolidarioFijo.BackColor = System.Drawing.Color.White;
            this.txtAporteSolidarioFijo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAporteSolidarioFijo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtAporteSolidarioFijo.ForeColor = System.Drawing.Color.Black;
            this.txtAporteSolidarioFijo.Location = new System.Drawing.Point(160, 115);
            this.txtAporteSolidarioFijo.MaxLength = 11;
            this.txtAporteSolidarioFijo.Name = "txtAporteSolidarioFijo";
            this.txtAporteSolidarioFijo.Size = new System.Drawing.Size(85, 22);
            this.txtAporteSolidarioFijo.TabIndex = 16;
            this.txtAporteSolidarioFijo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAporteSolidarioFijo_KeyPress);
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
            this.miLabel3.Text = "Aporte solidario (fijo) $";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAporteSolidarioTasa
            // 
            this.txtAporteSolidarioTasa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtAporteSolidarioTasa.BackColor = System.Drawing.Color.White;
            this.txtAporteSolidarioTasa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAporteSolidarioTasa.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtAporteSolidarioTasa.ForeColor = System.Drawing.Color.Black;
            this.txtAporteSolidarioTasa.Location = new System.Drawing.Point(160, 142);
            this.txtAporteSolidarioTasa.MaxLength = 5;
            this.txtAporteSolidarioTasa.Name = "txtAporteSolidarioTasa";
            this.txtAporteSolidarioTasa.Size = new System.Drawing.Size(37, 22);
            this.txtAporteSolidarioTasa.TabIndex = 18;
            this.txtAporteSolidarioTasa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAporteSolidarioTasa_KeyPress);
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
            this.miLabel4.Text = "Aporte solidario (tasa) %";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCuotaAfiliadoFijo
            // 
            this.txtCuotaAfiliadoFijo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCuotaAfiliadoFijo.BackColor = System.Drawing.Color.White;
            this.txtCuotaAfiliadoFijo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuotaAfiliadoFijo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCuotaAfiliadoFijo.ForeColor = System.Drawing.Color.Black;
            this.txtCuotaAfiliadoFijo.Location = new System.Drawing.Point(160, 169);
            this.txtCuotaAfiliadoFijo.MaxLength = 11;
            this.txtCuotaAfiliadoFijo.Name = "txtCuotaAfiliadoFijo";
            this.txtCuotaAfiliadoFijo.Size = new System.Drawing.Size(85, 22);
            this.txtCuotaAfiliadoFijo.TabIndex = 20;
            this.txtCuotaAfiliadoFijo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuotaAfiliadoFijo_KeyPress);
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
            this.miLabel5.Text = "Cuota de afiliación (fijo) $";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCuotaAfiliadoTasa
            // 
            this.txtCuotaAfiliadoTasa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCuotaAfiliadoTasa.BackColor = System.Drawing.Color.White;
            this.txtCuotaAfiliadoTasa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuotaAfiliadoTasa.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCuotaAfiliadoTasa.ForeColor = System.Drawing.Color.Black;
            this.txtCuotaAfiliadoTasa.Location = new System.Drawing.Point(160, 196);
            this.txtCuotaAfiliadoTasa.MaxLength = 5;
            this.txtCuotaAfiliadoTasa.Name = "txtCuotaAfiliadoTasa";
            this.txtCuotaAfiliadoTasa.Size = new System.Drawing.Size(37, 22);
            this.txtCuotaAfiliadoTasa.TabIndex = 22;
            this.txtCuotaAfiliadoTasa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuotaAfiliadoTasa_KeyPress);
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
            this.miLabel6.Text = "Cuota de afiliación (tasa) %";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(791, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 14);
            this.label1.TabIndex = 26;
            this.label1.Text = "FCL (<1° y/o >1°año)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSeguroSocialTasa
            // 
            this.txtSeguroSocialTasa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSeguroSocialTasa.BackColor = System.Drawing.Color.White;
            this.txtSeguroSocialTasa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSeguroSocialTasa.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtSeguroSocialTasa.ForeColor = System.Drawing.Color.Black;
            this.txtSeguroSocialTasa.Location = new System.Drawing.Point(160, 250);
            this.txtSeguroSocialTasa.MaxLength = 5;
            this.txtSeguroSocialTasa.Name = "txtSeguroSocialTasa";
            this.txtSeguroSocialTasa.Size = new System.Drawing.Size(37, 22);
            this.txtSeguroSocialTasa.TabIndex = 26;
            this.txtSeguroSocialTasa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeguroSocialTasa_KeyPress);
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(0, 253);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(160, 15);
            this.miLabel7.TabIndex = 25;
            this.miLabel7.Text = "Seguro social (tasa) %";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSeguroSocialFijo
            // 
            this.txtSeguroSocialFijo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSeguroSocialFijo.BackColor = System.Drawing.Color.White;
            this.txtSeguroSocialFijo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSeguroSocialFijo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtSeguroSocialFijo.ForeColor = System.Drawing.Color.Black;
            this.txtSeguroSocialFijo.Location = new System.Drawing.Point(160, 223);
            this.txtSeguroSocialFijo.MaxLength = 11;
            this.txtSeguroSocialFijo.Name = "txtSeguroSocialFijo";
            this.txtSeguroSocialFijo.Size = new System.Drawing.Size(85, 22);
            this.txtSeguroSocialFijo.TabIndex = 24;
            this.txtSeguroSocialFijo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeguroSocialFijo_KeyPress);
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
            this.miLabel8.TabIndex = 23;
            this.miLabel8.Text = "Seguro social (fijo) $";
            this.miLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFCLMasDeUnAnio
            // 
            this.txtFCLMasDeUnAnio.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtFCLMasDeUnAnio.BackColor = System.Drawing.Color.White;
            this.txtFCLMasDeUnAnio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFCLMasDeUnAnio.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtFCLMasDeUnAnio.ForeColor = System.Drawing.Color.Black;
            this.txtFCLMasDeUnAnio.Location = new System.Drawing.Point(160, 304);
            this.txtFCLMasDeUnAnio.MaxLength = 5;
            this.txtFCLMasDeUnAnio.Name = "txtFCLMasDeUnAnio";
            this.txtFCLMasDeUnAnio.Size = new System.Drawing.Size(37, 22);
            this.txtFCLMasDeUnAnio.TabIndex = 30;
            this.txtFCLMasDeUnAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFCLMasDeUnAnio_KeyPress);
            // 
            // miLabel10
            // 
            this.miLabel10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel10.BackColor = System.Drawing.Color.Transparent;
            this.miLabel10.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel10.Location = new System.Drawing.Point(0, 307);
            this.miLabel10.Name = "miLabel10";
            this.miLabel10.Size = new System.Drawing.Size(160, 15);
            this.miLabel10.TabIndex = 29;
            this.miLabel10.Text = "FCL (>1°año) %";
            this.miLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFCLPrimerAnio
            // 
            this.txtFCLPrimerAnio.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtFCLPrimerAnio.BackColor = System.Drawing.Color.White;
            this.txtFCLPrimerAnio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFCLPrimerAnio.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtFCLPrimerAnio.ForeColor = System.Drawing.Color.Black;
            this.txtFCLPrimerAnio.Location = new System.Drawing.Point(160, 277);
            this.txtFCLPrimerAnio.MaxLength = 5;
            this.txtFCLPrimerAnio.Name = "txtFCLPrimerAnio";
            this.txtFCLPrimerAnio.Size = new System.Drawing.Size(37, 22);
            this.txtFCLPrimerAnio.TabIndex = 28;
            this.txtFCLPrimerAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFCLPrimerAnio_KeyPress);
            // 
            // miLabel9
            // 
            this.miLabel9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel9.BackColor = System.Drawing.Color.Transparent;
            this.miLabel9.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel9.Location = new System.Drawing.Point(0, 280);
            this.miLabel9.Name = "miLabel9";
            this.miLabel9.Size = new System.Drawing.Size(160, 15);
            this.miLabel9.TabIndex = 27;
            this.miLabel9.Text = "FCL (<1°año) %";
            this.miLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkIncluyeTotalNR
            // 
            this.chkIncluyeTotalNR.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkIncluyeTotalNR.AutoSize = true;
            this.chkIncluyeTotalNR.BackColor = System.Drawing.Color.Transparent;
            this.chkIncluyeTotalNR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkIncluyeTotalNR.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIncluyeTotalNR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkIncluyeTotalNR.Location = new System.Drawing.Point(160, 334);
            this.chkIncluyeTotalNR.Name = "chkIncluyeTotalNR";
            this.chkIncluyeTotalNR.Size = new System.Drawing.Size(335, 19);
            this.chkIncluyeTotalNR.TabIndex = 31;
            this.chkIncluyeTotalNR.Text = "La deducción sindical incluye sumas No Remunerativas";
            this.chkIncluyeTotalNR.UseVisualStyleBackColor = false;
            // 
            // FormSindicato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.chkIncluyeTotalNR);
            this.Controls.Add(this.txtFCLMasDeUnAnio);
            this.Controls.Add(this.miLabel10);
            this.Controls.Add(this.txtFCLPrimerAnio);
            this.Controls.Add(this.miLabel9);
            this.Controls.Add(this.txtSeguroSocialTasa);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.txtSeguroSocialFijo);
            this.Controls.Add(this.miLabel8);
            this.Controls.Add(this.txtCuotaAfiliadoTasa);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.txtCuotaAfiliadoFijo);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.txtAporteSolidarioTasa);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.txtAporteSolidarioFijo);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.txtDenominacion);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtConvenio);
            this.Name = "FormSindicato";
            this.Text = "Sindicatos";
            this.Load += new System.EventHandler(this.FormSindicato_Load);
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
            this.Controls.SetChildIndex(this.txtConvenio, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.txtAporteSolidarioFijo, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.txtAporteSolidarioTasa, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.txtCuotaAfiliadoFijo, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.txtCuotaAfiliadoTasa, 0);
            this.Controls.SetChildIndex(this.miLabel8, 0);
            this.Controls.SetChildIndex(this.txtSeguroSocialFijo, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.txtSeguroSocialTasa, 0);
            this.Controls.SetChildIndex(this.miLabel9, 0);
            this.Controls.SetChildIndex(this.txtFCLPrimerAnio, 0);
            this.Controls.SetChildIndex(this.miLabel10, 0);
            this.Controls.SetChildIndex(this.txtFCLMasDeUnAnio, 0);
            this.Controls.SetChildIndex(this.chkIncluyeTotalNR, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBox txtConvenio;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiTextBox txtDenominacion;
        private Biblioteca.Controles.MiTextBox txtAporteSolidarioFijo;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiTextBox txtAporteSolidarioTasa;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiTextBox txtCuotaAfiliadoFijo;
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiTextBox txtCuotaAfiliadoTasa;
        private Biblioteca.Controles.MiLabel miLabel6;
        public System.Windows.Forms.Label label1;
        private Biblioteca.Controles.MiTextBox txtSeguroSocialTasa;
        private Biblioteca.Controles.MiLabel miLabel7;
        private Biblioteca.Controles.MiTextBox txtSeguroSocialFijo;
        private Biblioteca.Controles.MiLabel miLabel8;
        private Biblioteca.Controles.MiTextBox txtFCLMasDeUnAnio;
        private Biblioteca.Controles.MiLabel miLabel10;
        private Biblioteca.Controles.MiTextBox txtFCLPrimerAnio;
        private Biblioteca.Controles.MiLabel miLabel9;
        private Biblioteca.Controles.MiCheckBox chkIncluyeTotalNR;
    }
}