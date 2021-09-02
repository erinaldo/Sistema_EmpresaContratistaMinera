namespace CapaPresentacion
{
    partial class FormFacturaACobrar
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
                nFacturaACobrar.Dispose();
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
            this.pkrIntervaloHasta = new Biblioteca.Controles.MiDateTimePicker();
            this.pkrIntervaloDesde = new Biblioteca.Controles.MiDateTimePicker();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtFiltro = new Biblioteca.Controles.MiTextBox();
            this.cmbFiltro = new Biblioteca.Controles.MiComboBox();
            this.txtTotalACobrar = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.btnBuscar = new Biblioteca.Controles.MiButtonFind();
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(791, 91);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(87, 14);
            this.lblCatalagoTitulo5.TabIndex = 14;
            this.lblCatalagoTitulo5.Text = "Estado de Cobro";
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(686, 91);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(45, 14);
            this.lblCatalagoTitulo4.TabIndex = 13;
            this.lblCatalagoTitulo4.Text = "Monto $";
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(357, 91);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(64, 14);
            this.lblCatalagoTitulo3.TabIndex = 12;
            this.lblCatalagoTitulo3.Text = "Descripción";
            // 
            // lblCatalagoTitulo2
            // 
            this.lblCatalagoTitulo2.Location = new System.Drawing.Point(266, 91);
            this.lblCatalagoTitulo2.Size = new System.Drawing.Size(37, 14);
            this.lblCatalagoTitulo2.TabIndex = 11;
            this.lblCatalagoTitulo2.Text = "Fecha";
            // 
            // lblCatalagoTitulo1
            // 
            this.lblCatalagoTitulo1.Location = new System.Drawing.Point(161, 91);
            this.lblCatalagoTitulo1.Size = new System.Drawing.Size(29, 14);
            this.lblCatalagoTitulo1.TabIndex = 10;
            this.lblCatalagoTitulo1.Text = "CUIT";
            // 
            // lstCatalogo
            // 
            this.lstCatalogo.Location = new System.Drawing.Point(160, 107);
            this.lstCatalogo.SelectionMode = System.Windows.Forms.SelectionMode.One;
            this.lstCatalogo.Size = new System.Drawing.Size(840, 458);
            this.lstCatalogo.TabIndex = 20;
            // 
            // fondoPaginacion
            // 
            this.fondoPaginacion.Location = new System.Drawing.Point(160, 88);
            this.fondoPaginacion.Size = new System.Drawing.Size(840, 20);
            // 
            // lblPaginacion
            // 
            this.lblPaginacion.TabIndex = 17;
            // 
            // btnPaginacionFinal
            // 
            this.btnPaginacionFinal.FlatAppearance.BorderSize = 0;
            this.btnPaginacionFinal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionFinal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionFinal.TabIndex = 19;
            // 
            // btnPaginacionPosterior
            // 
            this.btnPaginacionPosterior.FlatAppearance.BorderSize = 0;
            this.btnPaginacionPosterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionPosterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionPosterior.TabIndex = 18;
            // 
            // btnPaginacionAnterior
            // 
            this.btnPaginacionAnterior.FlatAppearance.BorderSize = 0;
            this.btnPaginacionAnterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionAnterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionAnterior.TabIndex = 16;
            // 
            // btnPaginacionInicial
            // 
            this.btnPaginacionInicial.FlatAppearance.BorderSize = 0;
            this.btnPaginacionInicial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionInicial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionInicial.TabIndex = 15;
            // 
            // btnPDF_Lista
            // 
            this.btnPDF_Lista.Enabled = false;
            this.btnPDF_Lista.FlatAppearance.BorderSize = 0;
            this.btnPDF_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Lista.Location = new System.Drawing.Point(816, 60);
            this.btnPDF_Lista.TabIndex = 9;
            this.btnPDF_Lista.Visible = false;
            // 
            // btnExcel_Lista
            // 
            this.btnExcel_Lista.FlatAppearance.BorderSize = 0;
            this.btnExcel_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Lista.Location = new System.Drawing.Point(786, 60);
            this.btnExcel_Lista.TabIndex = 8;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Facturas a Cobrar";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 23;
            // 
            // pkrIntervaloHasta
            // 
            this.pkrIntervaloHasta.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrIntervaloHasta.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrIntervaloHasta.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrIntervaloHasta.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrIntervaloHasta.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrIntervaloHasta.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrIntervaloHasta.CustomFormat = "dd/MM/yyyy";
            this.pkrIntervaloHasta.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrIntervaloHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrIntervaloHasta.Location = new System.Drawing.Point(264, 61);
            this.pkrIntervaloHasta.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrIntervaloHasta.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrIntervaloHasta.Name = "pkrIntervaloHasta";
            this.pkrIntervaloHasta.Size = new System.Drawing.Size(102, 22);
            this.pkrIntervaloHasta.TabIndex = 4;
            // 
            // pkrIntervaloDesde
            // 
            this.pkrIntervaloDesde.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrIntervaloDesde.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrIntervaloDesde.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrIntervaloDesde.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrIntervaloDesde.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrIntervaloDesde.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrIntervaloDesde.CustomFormat = "dd/MM/yyyy";
            this.pkrIntervaloDesde.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrIntervaloDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrIntervaloDesde.Location = new System.Drawing.Point(160, 61);
            this.pkrIntervaloDesde.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrIntervaloDesde.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrIntervaloDesde.Name = "pkrIntervaloDesde";
            this.pkrIntervaloDesde.Size = new System.Drawing.Size(102, 22);
            this.pkrIntervaloDesde.TabIndex = 3;
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
            this.miLabel1.Text = "Intervalo (desde - hasta)";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtFiltro.BackColor = System.Drawing.Color.White;
            this.txtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltro.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtFiltro.ForeColor = System.Drawing.Color.Black;
            this.txtFiltro.Location = new System.Drawing.Point(550, 61);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(205, 22);
            this.txtFiltro.TabIndex = 6;
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbFiltro.BackColor = System.Drawing.Color.White;
            this.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbFiltro.ForeColor = System.Drawing.Color.Black;
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Location = new System.Drawing.Point(368, 61);
            this.cmbFiltro.Margin = new System.Windows.Forms.Padding(1);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(180, 22);
            this.cmbFiltro.Sorted = true;
            this.cmbFiltro.TabIndex = 5;
            // 
            // txtTotalACobrar
            // 
            this.txtTotalACobrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalACobrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtTotalACobrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalACobrar.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtTotalACobrar.ForeColor = System.Drawing.Color.Black;
            this.txtTotalACobrar.Location = new System.Drawing.Point(160, 570);
            this.txtTotalACobrar.MaxLength = 15;
            this.txtTotalACobrar.Name = "txtTotalACobrar";
            this.txtTotalACobrar.ReadOnly = true;
            this.txtTotalACobrar.Size = new System.Drawing.Size(100, 22);
            this.txtTotalACobrar.TabIndex = 22;
            // 
            // miLabel6
            // 
            this.miLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel6.BackColor = System.Drawing.Color.Transparent;
            this.miLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel6.Location = new System.Drawing.Point(0, 573);
            this.miLabel6.Name = "miLabel6";
            this.miLabel6.Size = new System.Drawing.Size(160, 15);
            this.miLabel6.TabIndex = 21;
            this.miLabel6.Text = "Total a cobrar $";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnBuscar.Location = new System.Drawing.Point(756, 60);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBuscar.Size = new System.Drawing.Size(30, 24);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FormFacturaACobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtTotalACobrar);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.cmbFiltro);
            this.Controls.Add(this.pkrIntervaloHasta);
            this.Controls.Add(this.pkrIntervaloDesde);
            this.Controls.Add(this.miLabel1);
            this.Name = "FormFacturaACobrar";
            this.Text = "Facturas a Cobrar";
            this.Load += new System.EventHandler(this.FormFacturaACobrar_Load);
            this.Controls.SetChildIndex(this.fondoPaginacion, 0);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.lstCatalogo, 0);
            this.Controls.SetChildIndex(this.btnPaginacionInicial, 0);
            this.Controls.SetChildIndex(this.btnPaginacionAnterior, 0);
            this.Controls.SetChildIndex(this.btnPaginacionPosterior, 0);
            this.Controls.SetChildIndex(this.btnPaginacionFinal, 0);
            this.Controls.SetChildIndex(this.lblPaginacion, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo1, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo2, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo3, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo4, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo5, 0);
            this.Controls.SetChildIndex(this.btnExcel_Lista, 0);
            this.Controls.SetChildIndex(this.btnPDF_Lista, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.pkrIntervaloDesde, 0);
            this.Controls.SetChildIndex(this.pkrIntervaloHasta, 0);
            this.Controls.SetChildIndex(this.cmbFiltro, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.txtTotalACobrar, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Biblioteca.Controles.MiDateTimePicker pkrIntervaloHasta;
        public Biblioteca.Controles.MiDateTimePicker pkrIntervaloDesde;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBox txtFiltro;
        private Biblioteca.Controles.MiComboBox cmbFiltro;
        private Biblioteca.Controles.MiTextBoxRead txtTotalACobrar;
        private Biblioteca.Controles.MiLabel miLabel6;
        private Biblioteca.Controles.MiButtonFind btnBuscar;
    }
}