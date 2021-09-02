namespace CapaPresentacion
{
    partial class FormEstadoResultados
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
                nEstadoResultados.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEstadoResultados));
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.cmbPeriodo = new Biblioteca.Controles.MiComboBox();
            this.txtPeriodo = new Biblioteca.Controles.MiNumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstListado = new System.Windows.Forms.ListBox();
            this.btnExcel_Libro = new Biblioteca.Controles.MiButtonExcel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscar = new Biblioteca.Controles.MiButtonFind();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Estado de Resultados";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 11;
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
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(161, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Grupo";
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
            this.lstListado.Size = new System.Drawing.Size(840, 530);
            this.lstListado.TabIndex = 10;
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
            this.btnExcel_Libro.Location = new System.Drawing.Point(278, 60);
            this.btnExcel_Libro.Name = "btnExcel_Libro";
            this.btnExcel_Libro.Size = new System.Drawing.Size(30, 24);
            this.btnExcel_Libro.TabIndex = 6;
            this.btnExcel_Libro.UseVisualStyleBackColor = false;
            this.btnExcel_Libro.Click += new System.EventHandler(this.btnExcel_Libro_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(385, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Denominación";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(903, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Monto";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnBuscar.Location = new System.Drawing.Point(248, 60);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBuscar.Size = new System.Drawing.Size(30, 24);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FormEstadoResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExcel_Libro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstListado);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.cmbPeriodo);
            this.Controls.Add(this.txtPeriodo);
            this.Name = "FormEstadoResultados";
            this.Text = "Estado de Resultados";
            this.Load += new System.EventHandler(this.FormEstadoResultados_Load);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.txtPeriodo, 0);
            this.Controls.SetChildIndex(this.cmbPeriodo, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.lstListado, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnExcel_Libro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
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
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ListBox lstListado;
        public Biblioteca.Controles.MiButtonExcel btnExcel_Libro;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        private Biblioteca.Controles.MiButtonFind btnBuscar;
    }
}
