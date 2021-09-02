namespace CapaPresentacion
{
    partial class FormRG36852014
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRG36852014));
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.cmbPeriodo = new Biblioteca.Controles.MiComboBox();
            this.txtPeriodo = new Biblioteca.Controles.MiNumericUpDown();
            this.cmbInformativo = new Biblioteca.Controles.MiComboBox();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstListado = new System.Windows.Forms.ListBox();
            this.txtTotal = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel14 = new Biblioteca.Controles.MiLabel();
            this.txtTotalPercepcion = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel13 = new Biblioteca.Controles.MiLabel();
            this.txtPercepcionIVA = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel12 = new Biblioteca.Controles.MiLabel();
            this.txtImpuestoInterno = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.txtExento = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.txtNoGravado = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.txtNetoGravado = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.txtTotalIVA = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel9 = new Biblioteca.Controles.MiLabel();
            this.txtIVA270 = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel8 = new Biblioteca.Controles.MiLabel();
            this.txtIVA210 = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.txtIVA105 = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel10 = new Biblioteca.Controles.MiLabel();
            this.txtPercepcionLH = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel11 = new Biblioteca.Controles.MiLabel();
            this.txtPercepcionIIBB = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel15 = new Biblioteca.Controles.MiLabel();
            this.btnExcel_Informativo = new Biblioteca.Controles.MiButtonExcel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGenerarTXT_Comprobante = new Biblioteca.Controles.MiButton24x24();
            this.btnGenerarTXT_Alicuota = new Biblioteca.Controles.MiButton24x24();
            this.btnBuscar = new Biblioteca.Controles.MiButtonFind();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "‎RG 3685/2014";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 45;
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
            this.miLabel1.Text = "Periodo";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbPeriodo.BackColor = System.Drawing.Color.White;
            this.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPeriodo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbPeriodo.ForeColor = System.Drawing.Color.Black;
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbPeriodo.Location = new System.Drawing.Point(160, 61);
            this.cmbPeriodo.Margin = new System.Windows.Forms.Padding(1);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(38, 22);
            this.cmbPeriodo.Sorted = true;
            this.cmbPeriodo.TabIndex = 3;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPeriodo.BackColor = System.Drawing.Color.White;
            this.txtPeriodo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtPeriodo.ForeColor = System.Drawing.Color.Black;
            this.txtPeriodo.Location = new System.Drawing.Point(197, 61);
            this.txtPeriodo.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.txtPeriodo.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(50, 22);
            this.txtPeriodo.TabIndex = 4;
            this.txtPeriodo.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            // 
            // cmbInformativo
            // 
            this.cmbInformativo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbInformativo.BackColor = System.Drawing.Color.White;
            this.cmbInformativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInformativo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbInformativo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbInformativo.ForeColor = System.Drawing.Color.Black;
            this.cmbInformativo.FormattingEnabled = true;
            this.cmbInformativo.Items.AddRange(new object[] {
            "COMPRAS",
            "VENTAS"});
            this.cmbInformativo.Location = new System.Drawing.Point(160, 88);
            this.cmbInformativo.Margin = new System.Windows.Forms.Padding(1);
            this.cmbInformativo.Name = "cmbInformativo";
            this.cmbInformativo.Size = new System.Drawing.Size(87, 22);
            this.cmbInformativo.Sorted = true;
            this.cmbInformativo.TabIndex = 6;
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
            this.miLabel2.TabIndex = 5;
            this.miLabel2.Text = "Informativo";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(161, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tipo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(160, 115);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(840, 20);
            this.pictureBox1.TabIndex = 124;
            this.pictureBox1.TabStop = false;
            // 
            // lstListado
            // 
            this.lstListado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lstListado.BackColor = System.Drawing.Color.White;
            this.lstListado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstListado.Font = new System.Drawing.Font("Lucida Console", 9F);
            this.lstListado.ForeColor = System.Drawing.Color.Black;
            this.lstListado.FormattingEnabled = true;
            this.lstListado.ItemHeight = 12;
            this.lstListado.Location = new System.Drawing.Point(160, 134);
            this.lstListado.Name = "lstListado";
            this.lstListado.Size = new System.Drawing.Size(840, 350);
            this.lstListado.TabIndex = 18;
            this.lstListado.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstListado_MouseUp);
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtTotal.ForeColor = System.Drawing.Color.Black;
            this.txtTotal.Location = new System.Drawing.Point(900, 489);
            this.txtTotal.MaxLength = 15;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 22);
            this.txtTotal.TabIndex = 44;
            // 
            // miLabel14
            // 
            this.miLabel14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel14.BackColor = System.Drawing.Color.Transparent;
            this.miLabel14.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel14.Location = new System.Drawing.Point(773, 492);
            this.miLabel14.Name = "miLabel14";
            this.miLabel14.Size = new System.Drawing.Size(127, 15);
            this.miLabel14.TabIndex = 43;
            this.miLabel14.Text = "Total $";
            this.miLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalPercepcion
            // 
            this.txtTotalPercepcion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalPercepcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtTotalPercepcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalPercepcion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtTotalPercepcion.ForeColor = System.Drawing.Color.Black;
            this.txtTotalPercepcion.Location = new System.Drawing.Point(682, 571);
            this.txtTotalPercepcion.MaxLength = 15;
            this.txtTotalPercepcion.Name = "txtTotalPercepcion";
            this.txtTotalPercepcion.ReadOnly = true;
            this.txtTotalPercepcion.Size = new System.Drawing.Size(100, 22);
            this.txtTotalPercepcion.TabIndex = 42;
            // 
            // miLabel13
            // 
            this.miLabel13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel13.BackColor = System.Drawing.Color.Transparent;
            this.miLabel13.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel13.Location = new System.Drawing.Point(522, 574);
            this.miLabel13.Name = "miLabel13";
            this.miLabel13.Size = new System.Drawing.Size(160, 15);
            this.miLabel13.TabIndex = 41;
            this.miLabel13.Text = "Total percepciones $";
            this.miLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPercepcionIVA
            // 
            this.txtPercepcionIVA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPercepcionIVA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtPercepcionIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPercepcionIVA.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtPercepcionIVA.ForeColor = System.Drawing.Color.Black;
            this.txtPercepcionIVA.Location = new System.Drawing.Point(682, 543);
            this.txtPercepcionIVA.MaxLength = 15;
            this.txtPercepcionIVA.Name = "txtPercepcionIVA";
            this.txtPercepcionIVA.ReadOnly = true;
            this.txtPercepcionIVA.Size = new System.Drawing.Size(100, 22);
            this.txtPercepcionIVA.TabIndex = 40;
            // 
            // miLabel12
            // 
            this.miLabel12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel12.BackColor = System.Drawing.Color.Transparent;
            this.miLabel12.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel12.Location = new System.Drawing.Point(522, 546);
            this.miLabel12.Name = "miLabel12";
            this.miLabel12.Size = new System.Drawing.Size(160, 15);
            this.miLabel12.TabIndex = 39;
            this.miLabel12.Text = "Total percep. IVA $";
            this.miLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImpuestoInterno
            // 
            this.txtImpuestoInterno.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtImpuestoInterno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtImpuestoInterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImpuestoInterno.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtImpuestoInterno.ForeColor = System.Drawing.Color.Black;
            this.txtImpuestoInterno.Location = new System.Drawing.Point(160, 570);
            this.txtImpuestoInterno.MaxLength = 12;
            this.txtImpuestoInterno.Name = "txtImpuestoInterno";
            this.txtImpuestoInterno.ReadOnly = true;
            this.txtImpuestoInterno.Size = new System.Drawing.Size(85, 22);
            this.txtImpuestoInterno.TabIndex = 26;
            // 
            // miLabel5
            // 
            this.miLabel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel5.BackColor = System.Drawing.Color.Transparent;
            this.miLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel5.Location = new System.Drawing.Point(0, 573);
            this.miLabel5.Name = "miLabel5";
            this.miLabel5.Size = new System.Drawing.Size(160, 15);
            this.miLabel5.TabIndex = 25;
            this.miLabel5.Text = "Total imp. interno $";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtExento
            // 
            this.txtExento.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtExento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtExento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExento.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtExento.ForeColor = System.Drawing.Color.Black;
            this.txtExento.Location = new System.Drawing.Point(160, 543);
            this.txtExento.MaxLength = 12;
            this.txtExento.Name = "txtExento";
            this.txtExento.ReadOnly = true;
            this.txtExento.Size = new System.Drawing.Size(85, 22);
            this.txtExento.TabIndex = 24;
            // 
            // miLabel4
            // 
            this.miLabel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel4.BackColor = System.Drawing.Color.Transparent;
            this.miLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel4.Location = new System.Drawing.Point(0, 546);
            this.miLabel4.Name = "miLabel4";
            this.miLabel4.Size = new System.Drawing.Size(160, 15);
            this.miLabel4.TabIndex = 23;
            this.miLabel4.Text = "Total exento $";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNoGravado
            // 
            this.txtNoGravado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtNoGravado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtNoGravado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoGravado.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtNoGravado.ForeColor = System.Drawing.Color.Black;
            this.txtNoGravado.Location = new System.Drawing.Point(160, 516);
            this.txtNoGravado.MaxLength = 12;
            this.txtNoGravado.Name = "txtNoGravado";
            this.txtNoGravado.ReadOnly = true;
            this.txtNoGravado.Size = new System.Drawing.Size(85, 22);
            this.txtNoGravado.TabIndex = 22;
            // 
            // miLabel3
            // 
            this.miLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel3.BackColor = System.Drawing.Color.Transparent;
            this.miLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel3.Location = new System.Drawing.Point(0, 519);
            this.miLabel3.Name = "miLabel3";
            this.miLabel3.Size = new System.Drawing.Size(160, 15);
            this.miLabel3.TabIndex = 21;
            this.miLabel3.Text = "Total no gravado $";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNetoGravado
            // 
            this.txtNetoGravado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtNetoGravado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtNetoGravado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNetoGravado.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtNetoGravado.ForeColor = System.Drawing.Color.Black;
            this.txtNetoGravado.Location = new System.Drawing.Point(160, 489);
            this.txtNetoGravado.MaxLength = 12;
            this.txtNetoGravado.Name = "txtNetoGravado";
            this.txtNetoGravado.ReadOnly = true;
            this.txtNetoGravado.Size = new System.Drawing.Size(85, 22);
            this.txtNetoGravado.TabIndex = 20;
            // 
            // miLabel6
            // 
            this.miLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel6.BackColor = System.Drawing.Color.Transparent;
            this.miLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel6.Location = new System.Drawing.Point(0, 492);
            this.miLabel6.Name = "miLabel6";
            this.miLabel6.Size = new System.Drawing.Size(160, 15);
            this.miLabel6.TabIndex = 19;
            this.miLabel6.Text = "Total neto gravado $";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalIVA
            // 
            this.txtTotalIVA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalIVA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtTotalIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalIVA.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtTotalIVA.ForeColor = System.Drawing.Color.Black;
            this.txtTotalIVA.Location = new System.Drawing.Point(421, 570);
            this.txtTotalIVA.MaxLength = 15;
            this.txtTotalIVA.Name = "txtTotalIVA";
            this.txtTotalIVA.ReadOnly = true;
            this.txtTotalIVA.Size = new System.Drawing.Size(100, 22);
            this.txtTotalIVA.TabIndex = 34;
            // 
            // miLabel9
            // 
            this.miLabel9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel9.BackColor = System.Drawing.Color.Transparent;
            this.miLabel9.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel9.Location = new System.Drawing.Point(261, 573);
            this.miLabel9.Name = "miLabel9";
            this.miLabel9.Size = new System.Drawing.Size(160, 15);
            this.miLabel9.TabIndex = 33;
            this.miLabel9.Text = "Total IVA $";
            this.miLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIVA270
            // 
            this.txtIVA270.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtIVA270.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtIVA270.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIVA270.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtIVA270.ForeColor = System.Drawing.Color.Black;
            this.txtIVA270.Location = new System.Drawing.Point(421, 543);
            this.txtIVA270.MaxLength = 15;
            this.txtIVA270.Name = "txtIVA270";
            this.txtIVA270.ReadOnly = true;
            this.txtIVA270.Size = new System.Drawing.Size(100, 22);
            this.txtIVA270.TabIndex = 32;
            // 
            // miLabel8
            // 
            this.miLabel8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel8.BackColor = System.Drawing.Color.Transparent;
            this.miLabel8.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel8.Location = new System.Drawing.Point(261, 546);
            this.miLabel8.Name = "miLabel8";
            this.miLabel8.Size = new System.Drawing.Size(160, 15);
            this.miLabel8.TabIndex = 31;
            this.miLabel8.Text = "Total IVA %27.0 $";
            this.miLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIVA210
            // 
            this.txtIVA210.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtIVA210.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtIVA210.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIVA210.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtIVA210.ForeColor = System.Drawing.Color.Black;
            this.txtIVA210.Location = new System.Drawing.Point(421, 516);
            this.txtIVA210.MaxLength = 15;
            this.txtIVA210.Name = "txtIVA210";
            this.txtIVA210.ReadOnly = true;
            this.txtIVA210.Size = new System.Drawing.Size(100, 22);
            this.txtIVA210.TabIndex = 30;
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(261, 519);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(160, 15);
            this.miLabel7.TabIndex = 29;
            this.miLabel7.Text = "Total IVA %21.0 $";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIVA105
            // 
            this.txtIVA105.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtIVA105.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtIVA105.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIVA105.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtIVA105.ForeColor = System.Drawing.Color.Black;
            this.txtIVA105.Location = new System.Drawing.Point(421, 489);
            this.txtIVA105.MaxLength = 15;
            this.txtIVA105.Name = "txtIVA105";
            this.txtIVA105.ReadOnly = true;
            this.txtIVA105.Size = new System.Drawing.Size(100, 22);
            this.txtIVA105.TabIndex = 28;
            // 
            // miLabel10
            // 
            this.miLabel10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel10.BackColor = System.Drawing.Color.Transparent;
            this.miLabel10.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel10.Location = new System.Drawing.Point(261, 492);
            this.miLabel10.Name = "miLabel10";
            this.miLabel10.Size = new System.Drawing.Size(160, 15);
            this.miLabel10.TabIndex = 27;
            this.miLabel10.Text = "Total IVA %10.5 $";
            this.miLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPercepcionLH
            // 
            this.txtPercepcionLH.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPercepcionLH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtPercepcionLH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPercepcionLH.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtPercepcionLH.ForeColor = System.Drawing.Color.Black;
            this.txtPercepcionLH.Location = new System.Drawing.Point(682, 516);
            this.txtPercepcionLH.MaxLength = 15;
            this.txtPercepcionLH.Name = "txtPercepcionLH";
            this.txtPercepcionLH.ReadOnly = true;
            this.txtPercepcionLH.Size = new System.Drawing.Size(100, 22);
            this.txtPercepcionLH.TabIndex = 38;
            // 
            // miLabel11
            // 
            this.miLabel11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel11.BackColor = System.Drawing.Color.Transparent;
            this.miLabel11.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel11.Location = new System.Drawing.Point(522, 519);
            this.miLabel11.Name = "miLabel11";
            this.miLabel11.Size = new System.Drawing.Size(160, 15);
            this.miLabel11.TabIndex = 37;
            this.miLabel11.Text = "Total percep. LH $";
            this.miLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPercepcionIIBB
            // 
            this.txtPercepcionIIBB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPercepcionIIBB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtPercepcionIIBB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPercepcionIIBB.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtPercepcionIIBB.ForeColor = System.Drawing.Color.Black;
            this.txtPercepcionIIBB.Location = new System.Drawing.Point(682, 489);
            this.txtPercepcionIIBB.MaxLength = 15;
            this.txtPercepcionIIBB.Name = "txtPercepcionIIBB";
            this.txtPercepcionIIBB.ReadOnly = true;
            this.txtPercepcionIIBB.Size = new System.Drawing.Size(100, 22);
            this.txtPercepcionIIBB.TabIndex = 36;
            // 
            // miLabel15
            // 
            this.miLabel15.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel15.BackColor = System.Drawing.Color.Transparent;
            this.miLabel15.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel15.Location = new System.Drawing.Point(522, 492);
            this.miLabel15.Name = "miLabel15";
            this.miLabel15.Size = new System.Drawing.Size(160, 15);
            this.miLabel15.TabIndex = 35;
            this.miLabel15.Text = "Total percep. IIBB $";
            this.miLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExcel_Informativo
            // 
            this.btnExcel_Informativo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExcel_Informativo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExcel_Informativo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExcel_Informativo.BackgroundImage")));
            this.btnExcel_Informativo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExcel_Informativo.FlatAppearance.BorderSize = 0;
            this.btnExcel_Informativo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Informativo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Informativo.Font = new System.Drawing.Font("Arial", 9F);
            this.btnExcel_Informativo.ForeColor = System.Drawing.Color.Black;
            this.btnExcel_Informativo.Location = new System.Drawing.Point(278, 87);
            this.btnExcel_Informativo.Name = "btnExcel_Informativo";
            this.btnExcel_Informativo.Size = new System.Drawing.Size(30, 24);
            this.btnExcel_Informativo.TabIndex = 8;
            this.btnExcel_Informativo.UseVisualStyleBackColor = false;
            this.btnExcel_Informativo.Click += new System.EventHandler(this.btnExcel_Informativo_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(210, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "Comprobante";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(329, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 13;
            this.label3.Text = "Fecha";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(420, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "Denominación";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(686, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "CUIT";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(798, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 14);
            this.label6.TabIndex = 16;
            this.label6.Text = "Neto Grav.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(903, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 14);
            this.label7.TabIndex = 17;
            this.label7.Text = "Total";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGenerarTXT_Comprobante
            // 
            this.btnGenerarTXT_Comprobante.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGenerarTXT_Comprobante.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGenerarTXT_Comprobante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerarTXT_Comprobante.FlatAppearance.BorderSize = 0;
            this.btnGenerarTXT_Comprobante.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGenerarTXT_Comprobante.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGenerarTXT_Comprobante.Font = new System.Drawing.Font("Arial", 8F);
            this.btnGenerarTXT_Comprobante.ForeColor = System.Drawing.Color.Black;
            this.btnGenerarTXT_Comprobante.Location = new System.Drawing.Point(309, 87);
            this.btnGenerarTXT_Comprobante.Name = "btnGenerarTXT_Comprobante";
            this.btnGenerarTXT_Comprobante.Size = new System.Drawing.Size(288, 24);
            this.btnGenerarTXT_Comprobante.TabIndex = 9;
            this.btnGenerarTXT_Comprobante.Text = "Generar archivo para aplicativo S.I.Ap. (Comprobantes)";
            this.btnGenerarTXT_Comprobante.UseVisualStyleBackColor = false;
            this.btnGenerarTXT_Comprobante.Click += new System.EventHandler(this.btnGenerarTXT_Comprobante_Click);
            // 
            // btnGenerarTXT_Alicuota
            // 
            this.btnGenerarTXT_Alicuota.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGenerarTXT_Alicuota.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGenerarTXT_Alicuota.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerarTXT_Alicuota.FlatAppearance.BorderSize = 0;
            this.btnGenerarTXT_Alicuota.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGenerarTXT_Alicuota.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGenerarTXT_Alicuota.Font = new System.Drawing.Font("Arial", 8F);
            this.btnGenerarTXT_Alicuota.ForeColor = System.Drawing.Color.Black;
            this.btnGenerarTXT_Alicuota.Location = new System.Drawing.Point(598, 87);
            this.btnGenerarTXT_Alicuota.Name = "btnGenerarTXT_Alicuota";
            this.btnGenerarTXT_Alicuota.Size = new System.Drawing.Size(260, 24);
            this.btnGenerarTXT_Alicuota.TabIndex = 10;
            this.btnGenerarTXT_Alicuota.Text = "Generar archivo para aplicativo S.I.Ap. (Alícuotas)";
            this.btnGenerarTXT_Alicuota.UseVisualStyleBackColor = false;
            this.btnGenerarTXT_Alicuota.Click += new System.EventHandler(this.btnGenerarTXT_Alicuota_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBuscar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscar.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_report32;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Location = new System.Drawing.Point(248, 87);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBuscar.Size = new System.Drawing.Size(30, 24);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FormRG36852014
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnGenerarTXT_Alicuota);
            this.Controls.Add(this.btnGenerarTXT_Comprobante);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExcel_Informativo);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.miLabel14);
            this.Controls.Add(this.txtTotalPercepcion);
            this.Controls.Add(this.miLabel13);
            this.Controls.Add(this.txtPercepcionIVA);
            this.Controls.Add(this.miLabel12);
            this.Controls.Add(this.txtImpuestoInterno);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.txtExento);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.txtNoGravado);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.txtNetoGravado);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.txtTotalIVA);
            this.Controls.Add(this.miLabel9);
            this.Controls.Add(this.txtIVA270);
            this.Controls.Add(this.miLabel8);
            this.Controls.Add(this.txtIVA210);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.txtIVA105);
            this.Controls.Add(this.miLabel10);
            this.Controls.Add(this.txtPercepcionLH);
            this.Controls.Add(this.miLabel11);
            this.Controls.Add(this.txtPercepcionIIBB);
            this.Controls.Add(this.miLabel15);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstListado);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.cmbInformativo);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.cmbPeriodo);
            this.Controls.Add(this.txtPeriodo);
            this.Name = "FormRG36852014";
            this.Text = "Régimen de Información de Compras y Ventas";
            this.Load += new System.EventHandler(this.FormRG36852014_Load);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.txtPeriodo, 0);
            this.Controls.SetChildIndex(this.cmbPeriodo, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.cmbInformativo, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.lstListado, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.miLabel15, 0);
            this.Controls.SetChildIndex(this.txtPercepcionIIBB, 0);
            this.Controls.SetChildIndex(this.miLabel11, 0);
            this.Controls.SetChildIndex(this.txtPercepcionLH, 0);
            this.Controls.SetChildIndex(this.miLabel10, 0);
            this.Controls.SetChildIndex(this.txtIVA105, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.txtIVA210, 0);
            this.Controls.SetChildIndex(this.miLabel8, 0);
            this.Controls.SetChildIndex(this.txtIVA270, 0);
            this.Controls.SetChildIndex(this.miLabel9, 0);
            this.Controls.SetChildIndex(this.txtTotalIVA, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.txtNetoGravado, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.txtNoGravado, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.txtExento, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.txtImpuestoInterno, 0);
            this.Controls.SetChildIndex(this.miLabel12, 0);
            this.Controls.SetChildIndex(this.txtPercepcionIVA, 0);
            this.Controls.SetChildIndex(this.miLabel13, 0);
            this.Controls.SetChildIndex(this.txtTotalPercepcion, 0);
            this.Controls.SetChildIndex(this.miLabel14, 0);
            this.Controls.SetChildIndex(this.txtTotal, 0);
            this.Controls.SetChildIndex(this.btnExcel_Informativo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.btnGenerarTXT_Comprobante, 0);
            this.Controls.SetChildIndex(this.btnGenerarTXT_Alicuota, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiComboBox cmbPeriodo;
        private Biblioteca.Controles.MiNumericUpDown txtPeriodo;
        private Biblioteca.Controles.MiComboBox cmbInformativo;
        private Biblioteca.Controles.MiLabel miLabel2;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ListBox lstListado;
        private Biblioteca.Controles.MiTextBoxRead txtTotal;
        private Biblioteca.Controles.MiLabel miLabel14;
        private Biblioteca.Controles.MiTextBoxRead txtTotalPercepcion;
        private Biblioteca.Controles.MiLabel miLabel13;
        private Biblioteca.Controles.MiTextBoxRead txtPercepcionIVA;
        private Biblioteca.Controles.MiLabel miLabel12;
        private Biblioteca.Controles.MiTextBoxRead txtImpuestoInterno;
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiTextBoxRead txtExento;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiTextBoxRead txtNoGravado;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiTextBoxRead txtNetoGravado;
        private Biblioteca.Controles.MiLabel miLabel6;
        private Biblioteca.Controles.MiTextBoxRead txtTotalIVA;
        private Biblioteca.Controles.MiLabel miLabel9;
        private Biblioteca.Controles.MiTextBoxRead txtIVA270;
        private Biblioteca.Controles.MiLabel miLabel8;
        private Biblioteca.Controles.MiTextBoxRead txtIVA210;
        private Biblioteca.Controles.MiLabel miLabel7;
        private Biblioteca.Controles.MiTextBoxRead txtIVA105;
        private Biblioteca.Controles.MiLabel miLabel10;
        private Biblioteca.Controles.MiTextBoxRead txtPercepcionLH;
        private Biblioteca.Controles.MiLabel miLabel11;
        private Biblioteca.Controles.MiTextBoxRead txtPercepcionIIBB;
        private Biblioteca.Controles.MiLabel miLabel15;
        public Biblioteca.Controles.MiButtonExcel btnExcel_Informativo;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        private Biblioteca.Controles.MiButton24x24 btnGenerarTXT_Comprobante;
        private Biblioteca.Controles.MiButton24x24 btnGenerarTXT_Alicuota;
        private Biblioteca.Controles.MiButtonFind btnBuscar;
    }
}
