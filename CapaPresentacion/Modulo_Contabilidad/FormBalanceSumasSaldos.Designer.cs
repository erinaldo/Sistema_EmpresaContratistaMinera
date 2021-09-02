namespace CapaPresentacion
{
    partial class FormBalanceSumasSaldos
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
                nBalanceSumasSaldos.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBalanceSumasSaldos));
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstListado = new System.Windows.Forms.ListBox();
            this.txtHaber = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.txtDebe = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.btnExcel_Libro = new Biblioteca.Controles.MiButtonExcel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.pkrPeriodoHasta = new Biblioteca.Controles.MiDateTimePicker();
            this.pkrPeriodoDesde = new Biblioteca.Controles.MiDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new Biblioteca.Controles.MiButtonFind();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Balance de Sumas y Saldos";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 17;
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
            this.label2.TabIndex = 7;
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
            this.lstListado.TabIndex = 12;
            this.lstListado.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstListado_MouseUp);
            // 
            // txtHaber
            // 
            this.txtHaber.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtHaber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtHaber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHaber.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtHaber.ForeColor = System.Drawing.Color.Black;
            this.txtHaber.Location = new System.Drawing.Point(160, 489);
            this.txtHaber.MaxLength = 15;
            this.txtHaber.Name = "txtHaber";
            this.txtHaber.ReadOnly = true;
            this.txtHaber.Size = new System.Drawing.Size(100, 22);
            this.txtHaber.TabIndex = 16;
            // 
            // miLabel3
            // 
            this.miLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel3.BackColor = System.Drawing.Color.Transparent;
            this.miLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel3.Location = new System.Drawing.Point(0, 492);
            this.miLabel3.Name = "miLabel3";
            this.miLabel3.Size = new System.Drawing.Size(160, 15);
            this.miLabel3.TabIndex = 15;
            this.miLabel3.Text = "Total haber $";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDebe
            // 
            this.txtDebe.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDebe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtDebe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDebe.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtDebe.ForeColor = System.Drawing.Color.Black;
            this.txtDebe.Location = new System.Drawing.Point(160, 462);
            this.txtDebe.MaxLength = 15;
            this.txtDebe.Name = "txtDebe";
            this.txtDebe.ReadOnly = true;
            this.txtDebe.Size = new System.Drawing.Size(100, 22);
            this.txtDebe.TabIndex = 14;
            // 
            // miLabel6
            // 
            this.miLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel6.BackColor = System.Drawing.Color.Transparent;
            this.miLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel6.Location = new System.Drawing.Point(0, 465);
            this.miLabel6.Name = "miLabel6";
            this.miLabel6.Size = new System.Drawing.Size(160, 15);
            this.miLabel6.TabIndex = 13;
            this.miLabel6.Text = "Total debe $";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnExcel_Libro.Location = new System.Drawing.Point(397, 60);
            this.btnExcel_Libro.Name = "btnExcel_Libro";
            this.btnExcel_Libro.Size = new System.Drawing.Size(30, 24);
            this.btnExcel_Libro.TabIndex = 6;
            this.btnExcel_Libro.UseVisualStyleBackColor = false;
            this.btnExcel_Libro.Click += new System.EventHandler(this.btnExcel_Libro_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(686, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Debe $";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(791, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Haber $";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(896, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 14);
            this.label5.TabIndex = 11;
            this.label5.Text = "Saldo $";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.miLabel1.Text = "Periodo (Desde-Hasta)";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pkrPeriodoHasta
            // 
            this.pkrPeriodoHasta.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrPeriodoHasta.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrPeriodoHasta.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrPeriodoHasta.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrPeriodoHasta.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrPeriodoHasta.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrPeriodoHasta.CustomFormat = "dd/MM/yyyy";
            this.pkrPeriodoHasta.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrPeriodoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrPeriodoHasta.Location = new System.Drawing.Point(264, 61);
            this.pkrPeriodoHasta.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrPeriodoHasta.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrPeriodoHasta.Name = "pkrPeriodoHasta";
            this.pkrPeriodoHasta.Size = new System.Drawing.Size(102, 22);
            this.pkrPeriodoHasta.TabIndex = 4;
            // 
            // pkrPeriodoDesde
            // 
            this.pkrPeriodoDesde.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrPeriodoDesde.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrPeriodoDesde.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrPeriodoDesde.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrPeriodoDesde.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrPeriodoDesde.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrPeriodoDesde.CustomFormat = "dd/MM/yyyy";
            this.pkrPeriodoDesde.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrPeriodoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrPeriodoDesde.Location = new System.Drawing.Point(160, 61);
            this.pkrPeriodoDesde.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrPeriodoDesde.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrPeriodoDesde.Name = "pkrPeriodoDesde";
            this.pkrPeriodoDesde.Size = new System.Drawing.Size(102, 22);
            this.pkrPeriodoDesde.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(490, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cuenta Contable";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnBuscar.Location = new System.Drawing.Point(367, 60);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBuscar.Size = new System.Drawing.Size(30, 24);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FormBalanceSumasSaldos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.pkrPeriodoHasta);
            this.Controls.Add(this.pkrPeriodoDesde);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExcel_Libro);
            this.Controls.Add(this.txtHaber);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.txtDebe);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstListado);
            this.Controls.Add(this.miLabel1);
            this.Name = "FormBalanceSumasSaldos";
            this.Text = "Balance de Sumas y Saldos";
            this.Load += new System.EventHandler(this.FormBalanceSumasSaldos_Load);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.lstListado, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.txtDebe, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.txtHaber, 0);
            this.Controls.SetChildIndex(this.btnExcel_Libro, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.pkrPeriodoDesde, 0);
            this.Controls.SetChildIndex(this.pkrPeriodoHasta, 0);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ListBox lstListado;
        private Biblioteca.Controles.MiTextBoxRead txtHaber;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiTextBoxRead txtDebe;
        private Biblioteca.Controles.MiLabel miLabel6;
        public Biblioteca.Controles.MiButtonExcel btnExcel_Libro;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        private Biblioteca.Controles.MiLabel miLabel1;
        public Biblioteca.Controles.MiDateTimePicker pkrPeriodoHasta;
        public Biblioteca.Controles.MiDateTimePicker pkrPeriodoDesde;
        public System.Windows.Forms.Label label1;
        private Biblioteca.Controles.MiButtonFind btnBuscar;
    }
}
