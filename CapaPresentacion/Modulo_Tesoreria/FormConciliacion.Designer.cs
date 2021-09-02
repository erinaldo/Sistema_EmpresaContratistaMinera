namespace CapaPresentacion
{
    partial class FormConciliacion
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
                nConciliacion.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConciliacion));
            this.cmbCuentaContable = new Biblioteca.Controles.MiComboBox();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstListado = new System.Windows.Forms.ListBox();
            this.btnExcel_Libro = new Biblioteca.Controles.MiButtonExcel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEstadoConciliacion = new Biblioteca.Controles.MiComboBox();
            this.btnConciliar = new Biblioteca.Controles.MiButton24x24();
            this.chkMarcarMovimientos = new Biblioteca.Controles.MiCheckBox();
            this.txtTotalDebeSinConciliar = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.txtTotalDebe = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.txtTotalHaber = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.btnDesconciliar = new Biblioteca.Controles.MiButton24x24();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalHaberSinConciliar = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.txtTotalSaldoReal = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.btnBuscar = new Biblioteca.Controles.MiButtonFind();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Conciliación de Cuentas";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 27;
            // 
            // labelUsuario
            // 
            this.labelUsuario.TabIndex = 1;
            this.labelUsuario.Text = "Sesión de : ";
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
            this.cmbCuentaContable.Location = new System.Drawing.Point(160, 61);
            this.cmbCuentaContable.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCuentaContable.Name = "cmbCuentaContable";
            this.cmbCuentaContable.Size = new System.Drawing.Size(185, 22);
            this.cmbCuentaContable.Sorted = true;
            this.cmbCuentaContable.TabIndex = 3;
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
            this.miLabel1.Text = "Cuenta contable";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(161, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Cuenta Contable";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(160, 88);
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
            this.lstListado.Location = new System.Drawing.Point(160, 107);
            this.lstListado.Name = "lstListado";
            this.lstListado.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstListado.Size = new System.Drawing.Size(840, 350);
            this.lstListado.TabIndex = 16;
            this.lstListado.SelectedIndexChanged += new System.EventHandler(this.lstListado_SelectedIndexChanged);
            this.lstListado.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstListado_MouseUp);
            // 
            // btnExcel_Libro
            // 
            this.btnExcel_Libro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExcel_Libro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExcel_Libro.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExcel_Libro.BackgroundImage")));
            this.btnExcel_Libro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExcel_Libro.FlatAppearance.BorderSize = 0;
            this.btnExcel_Libro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Libro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Libro.Font = new System.Drawing.Font("Arial", 9F);
            this.btnExcel_Libro.ForeColor = System.Drawing.Color.Black;
            this.btnExcel_Libro.Location = new System.Drawing.Point(598, 60);
            this.btnExcel_Libro.Name = "btnExcel_Libro";
            this.btnExcel_Libro.Size = new System.Drawing.Size(30, 24);
            this.btnExcel_Libro.TabIndex = 6;
            this.btnExcel_Libro.UseVisualStyleBackColor = false;
            this.btnExcel_Libro.Click += new System.EventHandler(this.btnExcel_Libro_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(350, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Fecha";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(441, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Descripción";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(707, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "Debe $";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(805, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "Haber $";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbEstadoConciliacion
            // 
            this.cmbEstadoConciliacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbEstadoConciliacion.BackColor = System.Drawing.Color.White;
            this.cmbEstadoConciliacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoConciliacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstadoConciliacion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbEstadoConciliacion.ForeColor = System.Drawing.Color.Black;
            this.cmbEstadoConciliacion.FormattingEnabled = true;
            this.cmbEstadoConciliacion.Location = new System.Drawing.Point(347, 61);
            this.cmbEstadoConciliacion.Margin = new System.Windows.Forms.Padding(1);
            this.cmbEstadoConciliacion.Name = "cmbEstadoConciliacion";
            this.cmbEstadoConciliacion.Size = new System.Drawing.Size(220, 22);
            this.cmbEstadoConciliacion.Sorted = true;
            this.cmbEstadoConciliacion.TabIndex = 4;
            // 
            // btnConciliar
            // 
            this.btnConciliar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConciliar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConciliar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConciliar.FlatAppearance.BorderSize = 0;
            this.btnConciliar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnConciliar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnConciliar.Font = new System.Drawing.Font("Arial", 8F);
            this.btnConciliar.ForeColor = System.Drawing.Color.Black;
            this.btnConciliar.Location = new System.Drawing.Point(628, 60);
            this.btnConciliar.Name = "btnConciliar";
            this.btnConciliar.Size = new System.Drawing.Size(75, 24);
            this.btnConciliar.TabIndex = 7;
            this.btnConciliar.Text = "Conciliar";
            this.btnConciliar.UseVisualStyleBackColor = false;
            this.btnConciliar.Click += new System.EventHandler(this.btnConciliar_Click);
            // 
            // chkMarcarMovimientos
            // 
            this.chkMarcarMovimientos.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkMarcarMovimientos.AutoSize = true;
            this.chkMarcarMovimientos.BackColor = System.Drawing.Color.Transparent;
            this.chkMarcarMovimientos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkMarcarMovimientos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMarcarMovimientos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkMarcarMovimientos.Location = new System.Drawing.Point(784, 63);
            this.chkMarcarMovimientos.Name = "chkMarcarMovimientos";
            this.chkMarcarMovimientos.Size = new System.Drawing.Size(168, 19);
            this.chkMarcarMovimientos.TabIndex = 9;
            this.chkMarcarMovimientos.Text = "Marcar todos los asientos";
            this.chkMarcarMovimientos.UseVisualStyleBackColor = false;
            this.chkMarcarMovimientos.CheckedChanged += new System.EventHandler(this.chkMarcarMovimientos_CheckedChanged);
            // 
            // txtTotalDebeSinConciliar
            // 
            this.txtTotalDebeSinConciliar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalDebeSinConciliar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtTotalDebeSinConciliar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalDebeSinConciliar.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtTotalDebeSinConciliar.ForeColor = System.Drawing.Color.Black;
            this.txtTotalDebeSinConciliar.Location = new System.Drawing.Point(160, 489);
            this.txtTotalDebeSinConciliar.MaxLength = 15;
            this.txtTotalDebeSinConciliar.Name = "txtTotalDebeSinConciliar";
            this.txtTotalDebeSinConciliar.ReadOnly = true;
            this.txtTotalDebeSinConciliar.Size = new System.Drawing.Size(100, 22);
            this.txtTotalDebeSinConciliar.TabIndex = 20;
            // 
            // miLabel4
            // 
            this.miLabel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel4.BackColor = System.Drawing.Color.Transparent;
            this.miLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel4.Location = new System.Drawing.Point(0, 492);
            this.miLabel4.Name = "miLabel4";
            this.miLabel4.Size = new System.Drawing.Size(160, 15);
            this.miLabel4.TabIndex = 19;
            this.miLabel4.Text = "Total debe sin conciliar $";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalDebe
            // 
            this.txtTotalDebe.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalDebe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtTotalDebe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalDebe.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtTotalDebe.ForeColor = System.Drawing.Color.Black;
            this.txtTotalDebe.Location = new System.Drawing.Point(160, 462);
            this.txtTotalDebe.MaxLength = 15;
            this.txtTotalDebe.Name = "txtTotalDebe";
            this.txtTotalDebe.ReadOnly = true;
            this.txtTotalDebe.Size = new System.Drawing.Size(100, 22);
            this.txtTotalDebe.TabIndex = 18;
            // 
            // miLabel2
            // 
            this.miLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel2.BackColor = System.Drawing.Color.Transparent;
            this.miLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel2.Location = new System.Drawing.Point(0, 465);
            this.miLabel2.Name = "miLabel2";
            this.miLabel2.Size = new System.Drawing.Size(160, 15);
            this.miLabel2.TabIndex = 17;
            this.miLabel2.Text = "Total debe $";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalHaber
            // 
            this.txtTotalHaber.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalHaber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtTotalHaber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalHaber.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtTotalHaber.ForeColor = System.Drawing.Color.Black;
            this.txtTotalHaber.Location = new System.Drawing.Point(421, 462);
            this.txtTotalHaber.MaxLength = 15;
            this.txtTotalHaber.Name = "txtTotalHaber";
            this.txtTotalHaber.ReadOnly = true;
            this.txtTotalHaber.Size = new System.Drawing.Size(100, 22);
            this.txtTotalHaber.TabIndex = 22;
            // 
            // miLabel5
            // 
            this.miLabel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel5.BackColor = System.Drawing.Color.Transparent;
            this.miLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel5.Location = new System.Drawing.Point(261, 465);
            this.miLabel5.Name = "miLabel5";
            this.miLabel5.Size = new System.Drawing.Size(160, 15);
            this.miLabel5.TabIndex = 21;
            this.miLabel5.Text = "Total haber $";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDesconciliar
            // 
            this.btnDesconciliar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDesconciliar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDesconciliar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDesconciliar.FlatAppearance.BorderSize = 0;
            this.btnDesconciliar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDesconciliar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDesconciliar.Font = new System.Drawing.Font("Arial", 8F);
            this.btnDesconciliar.ForeColor = System.Drawing.Color.Black;
            this.btnDesconciliar.Location = new System.Drawing.Point(703, 60);
            this.btnDesconciliar.Name = "btnDesconciliar";
            this.btnDesconciliar.Size = new System.Drawing.Size(75, 24);
            this.btnDesconciliar.TabIndex = 8;
            this.btnDesconciliar.Text = "Desconciliar";
            this.btnDesconciliar.UseVisualStyleBackColor = false;
            this.btnDesconciliar.Click += new System.EventHandler(this.btnDesconciliar_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(903, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "Estado";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalHaberSinConciliar
            // 
            this.txtTotalHaberSinConciliar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalHaberSinConciliar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtTotalHaberSinConciliar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalHaberSinConciliar.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtTotalHaberSinConciliar.ForeColor = System.Drawing.Color.Black;
            this.txtTotalHaberSinConciliar.Location = new System.Drawing.Point(421, 489);
            this.txtTotalHaberSinConciliar.MaxLength = 15;
            this.txtTotalHaberSinConciliar.Name = "txtTotalHaberSinConciliar";
            this.txtTotalHaberSinConciliar.ReadOnly = true;
            this.txtTotalHaberSinConciliar.Size = new System.Drawing.Size(100, 22);
            this.txtTotalHaberSinConciliar.TabIndex = 24;
            // 
            // miLabel6
            // 
            this.miLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel6.BackColor = System.Drawing.Color.Transparent;
            this.miLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel6.Location = new System.Drawing.Point(261, 492);
            this.miLabel6.Name = "miLabel6";
            this.miLabel6.Size = new System.Drawing.Size(160, 15);
            this.miLabel6.TabIndex = 23;
            this.miLabel6.Text = "Total haber sin conciliar $";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalSaldoReal
            // 
            this.txtTotalSaldoReal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalSaldoReal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtTotalSaldoReal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalSaldoReal.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtTotalSaldoReal.ForeColor = System.Drawing.Color.Black;
            this.txtTotalSaldoReal.Location = new System.Drawing.Point(900, 462);
            this.txtTotalSaldoReal.MaxLength = 15;
            this.txtTotalSaldoReal.Name = "txtTotalSaldoReal";
            this.txtTotalSaldoReal.ReadOnly = true;
            this.txtTotalSaldoReal.Size = new System.Drawing.Size(100, 22);
            this.txtTotalSaldoReal.TabIndex = 26;
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(740, 465);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(160, 15);
            this.miLabel7.TabIndex = 25;
            this.miLabel7.Text = "Total saldo real $";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnBuscar.Location = new System.Drawing.Point(568, 60);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBuscar.Size = new System.Drawing.Size(30, 24);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FormConciliacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtTotalSaldoReal);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.txtTotalHaberSinConciliar);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDesconciliar);
            this.Controls.Add(this.txtTotalHaber);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.txtTotalDebeSinConciliar);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.txtTotalDebe);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.chkMarcarMovimientos);
            this.Controls.Add(this.btnConciliar);
            this.Controls.Add(this.cmbEstadoConciliacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExcel_Libro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstListado);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.cmbCuentaContable);
            this.Name = "FormConciliacion";
            this.Text = "Conciliación de Cuentas";
            this.Load += new System.EventHandler(this.FormConciliacion_Load);
            this.Controls.SetChildIndex(this.cmbCuentaContable, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.lstListado, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnExcel_Libro, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.cmbEstadoConciliacion, 0);
            this.Controls.SetChildIndex(this.btnConciliar, 0);
            this.Controls.SetChildIndex(this.chkMarcarMovimientos, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.txtTotalDebe, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.txtTotalDebeSinConciliar, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.txtTotalHaber, 0);
            this.Controls.SetChildIndex(this.btnDesconciliar, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.txtTotalHaberSinConciliar, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.txtTotalSaldoReal, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Biblioteca.Controles.MiComboBox cmbCuentaContable;
        private Biblioteca.Controles.MiLabel miLabel1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ListBox lstListado;
        public Biblioteca.Controles.MiButtonExcel btnExcel_Libro;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        private Biblioteca.Controles.MiComboBox cmbEstadoConciliacion;
        private Biblioteca.Controles.MiButton24x24 btnConciliar;
        private Biblioteca.Controles.MiCheckBox chkMarcarMovimientos;
        private Biblioteca.Controles.MiTextBoxRead txtTotalDebeSinConciliar;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiTextBoxRead txtTotalDebe;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiTextBoxRead txtTotalHaber;
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiButton24x24 btnDesconciliar;
        public System.Windows.Forms.Label label6;
        private Biblioteca.Controles.MiTextBoxRead txtTotalHaberSinConciliar;
        private Biblioteca.Controles.MiLabel miLabel6;
        private Biblioteca.Controles.MiTextBoxRead txtTotalSaldoReal;
        private Biblioteca.Controles.MiLabel miLabel7;
        private Biblioteca.Controles.MiButtonFind btnBuscar;
    }
}
