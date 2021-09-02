namespace CapaPresentacion
{
    partial class FormFondo
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
                nFondo.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFondo));
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstListado = new System.Windows.Forms.ListBox();
            this.txtSaldo = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.btnExcel_Reporte = new Biblioteca.Controles.MiButtonExcel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.cmbCuentaContable = new Biblioteca.Controles.MiComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Fondos";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // labelUsuario
            // 
            this.labelUsuario.TabIndex = 1;
            this.labelUsuario.Text = "Sesión de : ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(161, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipo de Cuenta";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lstListado.Size = new System.Drawing.Size(840, 350);
            this.lstListado.TabIndex = 8;
            this.lstListado.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstListado_MouseUp);
            // 
            // txtSaldo
            // 
            this.txtSaldo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaldo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtSaldo.ForeColor = System.Drawing.Color.Black;
            this.txtSaldo.Location = new System.Drawing.Point(160, 462);
            this.txtSaldo.MaxLength = 15;
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(100, 22);
            this.txtSaldo.TabIndex = 10;
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
            this.miLabel2.TabIndex = 9;
            this.miLabel2.Text = "Fondos a la fecha $";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExcel_Reporte
            // 
            this.btnExcel_Reporte.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExcel_Reporte.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExcel_Reporte.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExcel_Reporte.BackgroundImage")));
            this.btnExcel_Reporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExcel_Reporte.FlatAppearance.BorderSize = 0;
            this.btnExcel_Reporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Reporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Reporte.Font = new System.Drawing.Font("Arial", 9F);
            this.btnExcel_Reporte.ForeColor = System.Drawing.Color.Black;
            this.btnExcel_Reporte.Location = new System.Drawing.Point(346, 60);
            this.btnExcel_Reporte.Name = "btnExcel_Reporte";
            this.btnExcel_Reporte.Size = new System.Drawing.Size(30, 24);
            this.btnExcel_Reporte.TabIndex = 4;
            this.btnExcel_Reporte.UseVisualStyleBackColor = false;
            this.btnExcel_Reporte.Click += new System.EventHandler(this.btnExcel_Libro_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(896, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Saldo $";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(700, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cuenta Contable";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // cmbCuentaContable
            // 
            this.cmbCuentaContable.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbCuentaContable.BackColor = System.Drawing.Color.White;
            this.cmbCuentaContable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuentaContable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCuentaContable.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCuentaContable.ForeColor = System.Drawing.Color.Black;
            this.cmbCuentaContable.FormattingEnabled = true;
            this.cmbCuentaContable.Items.AddRange(new object[] {
            "TODAS LAS CUENTAS"});
            this.cmbCuentaContable.Location = new System.Drawing.Point(160, 61);
            this.cmbCuentaContable.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCuentaContable.Name = "cmbCuentaContable";
            this.cmbCuentaContable.Size = new System.Drawing.Size(185, 22);
            this.cmbCuentaContable.Sorted = true;
            this.cmbCuentaContable.TabIndex = 3;
            // 
            // FormFondo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExcel_Reporte);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstListado);
            this.Controls.Add(this.cmbCuentaContable);
            this.Controls.Add(this.miLabel1);
            this.Name = "FormFondo";
            this.Text = "Fondos";
            this.Load += new System.EventHandler(this.FormFondo_Load);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.cmbCuentaContable, 0);
            this.Controls.SetChildIndex(this.lstListado, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.txtSaldo, 0);
            this.Controls.SetChildIndex(this.btnExcel_Reporte, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ListBox lstListado;
        private Biblioteca.Controles.MiTextBoxRead txtSaldo;
        private Biblioteca.Controles.MiLabel miLabel2;
        public Biblioteca.Controles.MiButtonExcel btnExcel_Reporte;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiComboBox cmbCuentaContable;
    }
}
