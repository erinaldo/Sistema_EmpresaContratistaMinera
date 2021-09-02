namespace CapaPresentacion
{
    partial class FormAuditoria
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
                nAuditoria.Dispose();
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
            this.txtFiltroLista = new Biblioteca.Controles.MiTextBox();
            this.pkrFiltroListaHasta = new Biblioteca.Controles.MiDateTimePicker();
            this.pkrFiltroListaDesde = new Biblioteca.Controles.MiDateTimePicker();
            this.cmbFiltroLista2 = new Biblioteca.Controles.MiComboBox();
            this.cmbFiltroLista1 = new Biblioteca.Controles.MiComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Enabled = false;
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(849, 91);
            this.lblCatalagoTitulo5.TabIndex = 13;
            this.lblCatalagoTitulo5.Visible = false;
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(412, 91);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(64, 14);
            this.lblCatalagoTitulo4.TabIndex = 12;
            this.lblCatalagoTitulo4.Text = "Descripción";
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(167, 91);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(41, 14);
            this.lblCatalagoTitulo3.TabIndex = 11;
            this.lblCatalagoTitulo3.Text = "Módulo";
            // 
            // lblCatalagoTitulo2
            // 
            this.lblCatalagoTitulo2.Size = new System.Drawing.Size(37, 14);
            this.lblCatalagoTitulo2.TabIndex = 10;
            this.lblCatalagoTitulo2.Text = "Fecha";
            // 
            // lblCatalagoTitulo1
            // 
            this.lblCatalagoTitulo1.Size = new System.Drawing.Size(16, 14);
            this.lblCatalagoTitulo1.TabIndex = 9;
            this.lblCatalagoTitulo1.Text = "ID";
            // 
            // lstCatalogo
            // 
            this.lstCatalogo.TabIndex = 19;
            // 
            // lblPaginacion
            // 
            this.lblPaginacion.TabIndex = 16;
            // 
            // btnPaginacionFinal
            // 
            this.btnPaginacionFinal.FlatAppearance.BorderSize = 0;
            this.btnPaginacionFinal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionFinal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionFinal.TabIndex = 18;
            // 
            // btnPaginacionPosterior
            // 
            this.btnPaginacionPosterior.FlatAppearance.BorderSize = 0;
            this.btnPaginacionPosterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionPosterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionPosterior.TabIndex = 17;
            // 
            // btnPaginacionAnterior
            // 
            this.btnPaginacionAnterior.FlatAppearance.BorderSize = 0;
            this.btnPaginacionAnterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionAnterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionAnterior.TabIndex = 15;
            // 
            // btnPaginacionInicial
            // 
            this.btnPaginacionInicial.FlatAppearance.BorderSize = 0;
            this.btnPaginacionInicial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionInicial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionInicial.TabIndex = 14;
            // 
            // btnPDF_Lista
            // 
            this.btnPDF_Lista.FlatAppearance.BorderSize = 0;
            this.btnPDF_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Lista.Location = new System.Drawing.Point(662, 60);
            this.btnPDF_Lista.TabIndex = 8;
            // 
            // btnExcel_Lista
            // 
            this.btnExcel_Lista.FlatAppearance.BorderSize = 0;
            this.btnExcel_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Lista.Location = new System.Drawing.Point(632, 60);
            this.btnExcel_Lista.TabIndex = 7;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Auditoría de Actividades de Usuarios";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 20;
            // 
            // txtFiltroLista
            // 
            this.txtFiltroLista.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtFiltroLista.BackColor = System.Drawing.Color.White;
            this.txtFiltroLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroLista.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtFiltroLista.ForeColor = System.Drawing.Color.Black;
            this.txtFiltroLista.Location = new System.Drawing.Point(425, 61);
            this.txtFiltroLista.MaxLength = 15;
            this.txtFiltroLista.Name = "txtFiltroLista";
            this.txtFiltroLista.Size = new System.Drawing.Size(206, 22);
            this.txtFiltroLista.TabIndex = 4;
            this.txtFiltroLista.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFiltroLista_KeyUp);
            this.txtFiltroLista.LostFocus += new System.EventHandler(this.txtFiltroLista_LostFocus);
            // 
            // pkrFiltroListaHasta
            // 
            this.pkrFiltroListaHasta.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrFiltroListaHasta.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrFiltroListaHasta.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrFiltroListaHasta.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrFiltroListaHasta.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrFiltroListaHasta.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrFiltroListaHasta.CustomFormat = "dd/MM/yyyy";
            this.pkrFiltroListaHasta.Enabled = false;
            this.pkrFiltroListaHasta.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrFiltroListaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrFiltroListaHasta.Location = new System.Drawing.Point(529, 61);
            this.pkrFiltroListaHasta.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrFiltroListaHasta.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrFiltroListaHasta.Name = "pkrFiltroListaHasta";
            this.pkrFiltroListaHasta.Size = new System.Drawing.Size(102, 22);
            this.pkrFiltroListaHasta.TabIndex = 6;
            this.pkrFiltroListaHasta.Visible = false;
            this.pkrFiltroListaHasta.LostFocus += new System.EventHandler(this.pkrFiltroListaHasta_LostFocus);
            // 
            // pkrFiltroListaDesde
            // 
            this.pkrFiltroListaDesde.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrFiltroListaDesde.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrFiltroListaDesde.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrFiltroListaDesde.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrFiltroListaDesde.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrFiltroListaDesde.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrFiltroListaDesde.CustomFormat = "dd/MM/yyyy";
            this.pkrFiltroListaDesde.Enabled = false;
            this.pkrFiltroListaDesde.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrFiltroListaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrFiltroListaDesde.Location = new System.Drawing.Point(425, 61);
            this.pkrFiltroListaDesde.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrFiltroListaDesde.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrFiltroListaDesde.Name = "pkrFiltroListaDesde";
            this.pkrFiltroListaDesde.Size = new System.Drawing.Size(102, 22);
            this.pkrFiltroListaDesde.TabIndex = 5;
            this.pkrFiltroListaDesde.Visible = false;
            this.pkrFiltroListaDesde.LostFocus += new System.EventHandler(this.pkrFiltroListaDesde_LostFocus);
            // 
            // cmbFiltroLista2
            // 
            this.cmbFiltroLista2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbFiltroLista2.BackColor = System.Drawing.Color.White;
            this.cmbFiltroLista2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroLista2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroLista2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbFiltroLista2.ForeColor = System.Drawing.Color.Black;
            this.cmbFiltroLista2.FormattingEnabled = true;
            this.cmbFiltroLista2.ItemHeight = 14;
            this.cmbFiltroLista2.Location = new System.Drawing.Point(238, 61);
            this.cmbFiltroLista2.Margin = new System.Windows.Forms.Padding(1);
            this.cmbFiltroLista2.Name = "cmbFiltroLista2";
            this.cmbFiltroLista2.Size = new System.Drawing.Size(185, 22);
            this.cmbFiltroLista2.Sorted = true;
            this.cmbFiltroLista2.TabIndex = 3;
            this.cmbFiltroLista2.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroLista2_SelectedIndexChanged);
            // 
            // cmbFiltroLista1
            // 
            this.cmbFiltroLista1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbFiltroLista1.BackColor = System.Drawing.Color.White;
            this.cmbFiltroLista1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroLista1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroLista1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbFiltroLista1.ForeColor = System.Drawing.Color.Black;
            this.cmbFiltroLista1.FormattingEnabled = true;
            this.cmbFiltroLista1.ItemHeight = 14;
            this.cmbFiltroLista1.Location = new System.Drawing.Point(6, 61);
            this.cmbFiltroLista1.Margin = new System.Windows.Forms.Padding(1);
            this.cmbFiltroLista1.Name = "cmbFiltroLista1";
            this.cmbFiltroLista1.Size = new System.Drawing.Size(230, 22);
            this.cmbFiltroLista1.Sorted = true;
            this.cmbFiltroLista1.TabIndex = 2;
            this.cmbFiltroLista1.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroLista1_SelectedIndexChanged);
            // 
            // FormAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.cmbFiltroLista2);
            this.Controls.Add(this.cmbFiltroLista1);
            this.Controls.Add(this.txtFiltroLista);
            this.Controls.Add(this.pkrFiltroListaHasta);
            this.Controls.Add(this.pkrFiltroListaDesde);
            this.Name = "FormAuditoria";
            this.Text = "Auditoría de Actividades de Usuarios";
            this.Load += new System.EventHandler(this.FormAuditoria_Load);
            this.Controls.SetChildIndex(this.pkrFiltroListaDesde, 0);
            this.Controls.SetChildIndex(this.pkrFiltroListaHasta, 0);
            this.Controls.SetChildIndex(this.txtFiltroLista, 0);
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
            this.Controls.SetChildIndex(this.cmbFiltroLista1, 0);
            this.Controls.SetChildIndex(this.cmbFiltroLista2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Biblioteca.Controles.MiTextBox txtFiltroLista;
        public Biblioteca.Controles.MiDateTimePicker pkrFiltroListaHasta;
        public Biblioteca.Controles.MiDateTimePicker pkrFiltroListaDesde;
        public Biblioteca.Controles.MiComboBox cmbFiltroLista2;
        public Biblioteca.Controles.MiComboBox cmbFiltroLista1;
    }
}
