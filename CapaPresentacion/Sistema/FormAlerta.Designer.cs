namespace CapaPresentacion
{
    partial class FormAlerta
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
                nAlerta.Dispose();
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
            this.txtFiltroLista = new Biblioteca.Controles.MiTextBox();
            this.pkrFiltroListaHasta = new Biblioteca.Controles.MiDateTimePicker();
            this.pkrFiltroListaDesde = new Biblioteca.Controles.MiDateTimePicker();
            this.cmbFiltroLista3 = new Biblioteca.Controles.MiComboBox();
            this.cmbFiltroLista2 = new Biblioteca.Controles.MiComboBox();
            this.cmbFiltroLista1 = new Biblioteca.Controles.MiComboBox();
            this.btnEliminar = new Biblioteca.Controles.MiButtonBase();
            this.btnProcesar = new Biblioteca.Controles.MiButtonBase();
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(711, 91);
            this.lblCatalagoTitulo5.TabIndex = 14;
            this.lblCatalagoTitulo5.Visible = false;
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(854, 91);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(40, 14);
            this.lblCatalagoTitulo4.TabIndex = 13;
            this.lblCatalagoTitulo4.Text = "Estado";
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(763, 91);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(58, 14);
            this.lblCatalagoTitulo3.TabIndex = 12;
            this.lblCatalagoTitulo3.Text = "Caducidad";
            // 
            // lblCatalagoTitulo2
            // 
            this.lblCatalagoTitulo2.Size = new System.Drawing.Size(64, 14);
            this.lblCatalagoTitulo2.TabIndex = 11;
            this.lblCatalagoTitulo2.Text = "Descripción";
            // 
            // lblCatalagoTitulo1
            // 
            this.lblCatalagoTitulo1.Size = new System.Drawing.Size(16, 14);
            this.lblCatalagoTitulo1.TabIndex = 10;
            this.lblCatalagoTitulo1.Text = "ID";
            // 
            // lstCatalogo
            // 
            this.lstCatalogo.TabIndex = 20;
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
            this.btnPDF_Lista.FlatAppearance.BorderSize = 0;
            this.btnPDF_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Lista.Location = new System.Drawing.Point(892, 60);
            this.btnPDF_Lista.TabIndex = 9;
            // 
            // btnExcel_Lista
            // 
            this.btnExcel_Lista.FlatAppearance.BorderSize = 0;
            this.btnExcel_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Lista.Location = new System.Drawing.Point(862, 60);
            this.btnExcel_Lista.TabIndex = 8;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Alertas de Sistema";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 23;
            // 
            // txtFiltroLista
            // 
            this.txtFiltroLista.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtFiltroLista.BackColor = System.Drawing.Color.White;
            this.txtFiltroLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroLista.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtFiltroLista.ForeColor = System.Drawing.Color.Black;
            this.txtFiltroLista.Location = new System.Drawing.Point(655, 61);
            this.txtFiltroLista.MaxLength = 15;
            this.txtFiltroLista.Name = "txtFiltroLista";
            this.txtFiltroLista.Size = new System.Drawing.Size(206, 22);
            this.txtFiltroLista.TabIndex = 5;
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
            this.pkrFiltroListaHasta.Location = new System.Drawing.Point(759, 61);
            this.pkrFiltroListaHasta.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrFiltroListaHasta.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrFiltroListaHasta.Name = "pkrFiltroListaHasta";
            this.pkrFiltroListaHasta.Size = new System.Drawing.Size(102, 22);
            this.pkrFiltroListaHasta.TabIndex = 7;
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
            this.pkrFiltroListaDesde.Location = new System.Drawing.Point(655, 61);
            this.pkrFiltroListaDesde.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrFiltroListaDesde.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrFiltroListaDesde.Name = "pkrFiltroListaDesde";
            this.pkrFiltroListaDesde.Size = new System.Drawing.Size(102, 22);
            this.pkrFiltroListaDesde.TabIndex = 6;
            this.pkrFiltroListaDesde.Visible = false;
            this.pkrFiltroListaDesde.LostFocus += new System.EventHandler(this.pkrFiltroListaDesde_LostFocus);
            // 
            // cmbFiltroLista3
            // 
            this.cmbFiltroLista3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbFiltroLista3.BackColor = System.Drawing.Color.White;
            this.cmbFiltroLista3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroLista3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroLista3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbFiltroLista3.ForeColor = System.Drawing.Color.Black;
            this.cmbFiltroLista3.FormattingEnabled = true;
            this.cmbFiltroLista3.Location = new System.Drawing.Point(468, 61);
            this.cmbFiltroLista3.Margin = new System.Windows.Forms.Padding(1);
            this.cmbFiltroLista3.Name = "cmbFiltroLista3";
            this.cmbFiltroLista3.Size = new System.Drawing.Size(185, 22);
            this.cmbFiltroLista3.Sorted = true;
            this.cmbFiltroLista3.TabIndex = 4;
            this.cmbFiltroLista3.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroLista3_SelectedIndexChanged);
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
            this.cmbFiltroLista2.Location = new System.Drawing.Point(228, 61);
            this.cmbFiltroLista2.Margin = new System.Windows.Forms.Padding(1);
            this.cmbFiltroLista2.Name = "cmbFiltroLista2";
            this.cmbFiltroLista2.Size = new System.Drawing.Size(238, 22);
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
            this.cmbFiltroLista1.Items.AddRange(new object[] {
            "ALERTAS DE FACTURACION",
            "ALERTAS DE INVENTARIO",
            "ALERTAS DE RRHH",
            "ALERTAS PERSONALIZADAS"});
            this.cmbFiltroLista1.Location = new System.Drawing.Point(6, 61);
            this.cmbFiltroLista1.Margin = new System.Windows.Forms.Padding(1);
            this.cmbFiltroLista1.Name = "cmbFiltroLista1";
            this.cmbFiltroLista1.Size = new System.Drawing.Size(220, 22);
            this.cmbFiltroLista1.Sorted = true;
            this.cmbFiltroLista1.TabIndex = 2;
            this.cmbFiltroLista1.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroLista1_SelectedIndexChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEliminar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.Location = new System.Drawing.Point(83, 657);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 22;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProcesar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProcesar.FlatAppearance.BorderSize = 0;
            this.btnProcesar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnProcesar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnProcesar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnProcesar.ForeColor = System.Drawing.Color.Black;
            this.btnProcesar.Location = new System.Drawing.Point(6, 657);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnProcesar.Size = new System.Drawing.Size(75, 23);
            this.btnProcesar.TabIndex = 21;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // FormAlerta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.cmbFiltroLista3);
            this.Controls.Add(this.cmbFiltroLista2);
            this.Controls.Add(this.cmbFiltroLista1);
            this.Controls.Add(this.txtFiltroLista);
            this.Controls.Add(this.pkrFiltroListaHasta);
            this.Controls.Add(this.pkrFiltroListaDesde);
            this.Name = "FormAlerta";
            this.Text = "Alertas de Sistema";
            this.Load += new System.EventHandler(this.FormAlerta_Load);
            this.Controls.SetChildIndex(this.fondoPaginacion, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo4, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo5, 0);
            this.Controls.SetChildIndex(this.pkrFiltroListaDesde, 0);
            this.Controls.SetChildIndex(this.pkrFiltroListaHasta, 0);
            this.Controls.SetChildIndex(this.txtFiltroLista, 0);
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
            this.Controls.SetChildIndex(this.btnExcel_Lista, 0);
            this.Controls.SetChildIndex(this.btnPDF_Lista, 0);
            this.Controls.SetChildIndex(this.cmbFiltroLista1, 0);
            this.Controls.SetChildIndex(this.cmbFiltroLista2, 0);
            this.Controls.SetChildIndex(this.cmbFiltroLista3, 0);
            this.Controls.SetChildIndex(this.btnProcesar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Biblioteca.Controles.MiTextBox txtFiltroLista;
        public Biblioteca.Controles.MiDateTimePicker pkrFiltroListaHasta;
        public Biblioteca.Controles.MiDateTimePicker pkrFiltroListaDesde;
        public Biblioteca.Controles.MiComboBox cmbFiltroLista3;
        public Biblioteca.Controles.MiComboBox cmbFiltroLista2;
        public Biblioteca.Controles.MiComboBox cmbFiltroLista1;
        private Biblioteca.Controles.MiButtonBase btnEliminar;
        private Biblioteca.Controles.MiButtonBase btnProcesar;
    }
}