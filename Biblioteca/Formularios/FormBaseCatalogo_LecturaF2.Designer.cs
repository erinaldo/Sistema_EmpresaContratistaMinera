namespace Biblioteca.Formularios
{
    partial class FormBaseCatalogo_LecturaF2
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
            this.btnPaginacionAnterior = new Biblioteca.Controles.MiButton20x20();
            this.btnPaginacionInicial = new Biblioteca.Controles.MiButton20x20();
            this.lblCatalagoTitulo4 = new System.Windows.Forms.Label();
            this.lblPaginacion = new System.Windows.Forms.Label();
            this.btnPaginacionFinal = new Biblioteca.Controles.MiButton20x20();
            this.btnPaginacionPosterior = new Biblioteca.Controles.MiButton20x20();
            this.lblCatalagoTitulo3 = new System.Windows.Forms.Label();
            this.lblCatalagoTitulo2 = new System.Windows.Forms.Label();
            this.lblCatalagoTitulo1 = new System.Windows.Forms.Label();
            this.fondoPaginacion = new System.Windows.Forms.PictureBox();
            this.lstCatalogo = new System.Windows.Forms.ListBox();
            this.cmbFiltroLista2 = new Biblioteca.Controles.MiComboBox();
            this.cmbFiltroLista1 = new Biblioteca.Controles.MiComboBox();
            this.txtFiltroLista = new Biblioteca.Controles.MiTextBox();
            this.pkrFiltroListaHasta = new Biblioteca.Controles.MiDateTimePicker();
            this.pkrFiltroListaDesde = new Biblioteca.Controles.MiDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.Location = new System.Drawing.Point(552, 289);
            this.btnCerrar.TabIndex = 16;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(622, 30);
            // 
            // pictureBottom
            // 
            this.pictureBottom.Location = new System.Drawing.Point(0, 284);
            this.pictureBottom.Size = new System.Drawing.Size(622, 30);
            // 
            // pictureRight
            // 
            this.pictureRight.Location = new System.Drawing.Point(621, 0);
            this.pictureRight.Size = new System.Drawing.Size(0, 314);
            // 
            // pictureLeft
            // 
            this.pictureLeft.Size = new System.Drawing.Size(0, 314);
            // 
            // pictureTop1
            // 
            this.pictureTop1.Size = new System.Drawing.Size(622, 6);
            // 
            // btnPaginacionAnterior
            // 
            this.btnPaginacionAnterior.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPaginacionAnterior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPaginacionAnterior.BackgroundImage = global::Biblioteca.Properties.Resources.icon_paginacion_anterior;
            this.btnPaginacionAnterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPaginacionAnterior.FlatAppearance.BorderSize = 0;
            this.btnPaginacionAnterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionAnterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionAnterior.Font = new System.Drawing.Font("Arial", 8F);
            this.btnPaginacionAnterior.ForeColor = System.Drawing.Color.Black;
            this.btnPaginacionAnterior.Location = new System.Drawing.Point(535, 77);
            this.btnPaginacionAnterior.Name = "btnPaginacionAnterior";
            this.btnPaginacionAnterior.Size = new System.Drawing.Size(16, 16);
            this.btnPaginacionAnterior.TabIndex = 11;
            this.btnPaginacionAnterior.UseVisualStyleBackColor = false;
            this.btnPaginacionAnterior.Click += new System.EventHandler(this.btnPaginacionAnterior_Click);
            // 
            // btnPaginacionInicial
            // 
            this.btnPaginacionInicial.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPaginacionInicial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPaginacionInicial.BackgroundImage = global::Biblioteca.Properties.Resources.icon_paginacion_inicial;
            this.btnPaginacionInicial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPaginacionInicial.FlatAppearance.BorderSize = 0;
            this.btnPaginacionInicial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionInicial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionInicial.Font = new System.Drawing.Font("Arial", 8F);
            this.btnPaginacionInicial.ForeColor = System.Drawing.Color.Black;
            this.btnPaginacionInicial.Location = new System.Drawing.Point(517, 77);
            this.btnPaginacionInicial.Name = "btnPaginacionInicial";
            this.btnPaginacionInicial.Size = new System.Drawing.Size(16, 16);
            this.btnPaginacionInicial.TabIndex = 10;
            this.btnPaginacionInicial.UseVisualStyleBackColor = false;
            this.btnPaginacionInicial.Click += new System.EventHandler(this.btnPaginacionInicial_Click);
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo4.AutoSize = true;
            this.lblCatalagoTitulo4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatalagoTitulo4.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(478, 78);
            this.lblCatalagoTitulo4.Name = "lblCatalagoTitulo4";
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(40, 14);
            this.lblCatalagoTitulo4.TabIndex = 9;
            this.lblCatalagoTitulo4.Text = "Estado";
            this.lblCatalagoTitulo4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPaginacion
            // 
            this.lblPaginacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPaginacion.BackColor = System.Drawing.Color.Gray;
            this.lblPaginacion.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblPaginacion.ForeColor = System.Drawing.Color.White;
            this.lblPaginacion.Location = new System.Drawing.Point(553, 77);
            this.lblPaginacion.Name = "lblPaginacion";
            this.lblPaginacion.Size = new System.Drawing.Size(25, 16);
            this.lblPaginacion.TabIndex = 12;
            this.lblPaginacion.Text = "1";
            this.lblPaginacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPaginacionFinal
            // 
            this.btnPaginacionFinal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPaginacionFinal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPaginacionFinal.BackgroundImage = global::Biblioteca.Properties.Resources.icon_paginacion_final;
            this.btnPaginacionFinal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPaginacionFinal.FlatAppearance.BorderSize = 0;
            this.btnPaginacionFinal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionFinal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionFinal.Font = new System.Drawing.Font("Arial", 8F);
            this.btnPaginacionFinal.ForeColor = System.Drawing.Color.Black;
            this.btnPaginacionFinal.Location = new System.Drawing.Point(598, 77);
            this.btnPaginacionFinal.Name = "btnPaginacionFinal";
            this.btnPaginacionFinal.Size = new System.Drawing.Size(16, 16);
            this.btnPaginacionFinal.TabIndex = 14;
            this.btnPaginacionFinal.UseVisualStyleBackColor = false;
            this.btnPaginacionFinal.Click += new System.EventHandler(this.btnPaginacionFinal_Click);
            // 
            // btnPaginacionPosterior
            // 
            this.btnPaginacionPosterior.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPaginacionPosterior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPaginacionPosterior.BackgroundImage = global::Biblioteca.Properties.Resources.icon_paginacion_posterior;
            this.btnPaginacionPosterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPaginacionPosterior.FlatAppearance.BorderSize = 0;
            this.btnPaginacionPosterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionPosterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionPosterior.Font = new System.Drawing.Font("Arial", 8F);
            this.btnPaginacionPosterior.ForeColor = System.Drawing.Color.Black;
            this.btnPaginacionPosterior.Location = new System.Drawing.Point(580, 77);
            this.btnPaginacionPosterior.Name = "btnPaginacionPosterior";
            this.btnPaginacionPosterior.Size = new System.Drawing.Size(16, 16);
            this.btnPaginacionPosterior.TabIndex = 13;
            this.btnPaginacionPosterior.UseVisualStyleBackColor = false;
            this.btnPaginacionPosterior.Click += new System.EventHandler(this.btnPaginacionPosterior_Click);
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo3.AutoSize = true;
            this.lblCatalagoTitulo3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatalagoTitulo3.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(350, 78);
            this.lblCatalagoTitulo3.Name = "lblCatalagoTitulo3";
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(54, 14);
            this.lblCatalagoTitulo3.TabIndex = 8;
            this.lblCatalagoTitulo3.Text = "CUIL/CUIT";
            this.lblCatalagoTitulo3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCatalagoTitulo2
            // 
            this.lblCatalagoTitulo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo2.AutoSize = true;
            this.lblCatalagoTitulo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatalagoTitulo2.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo2.Location = new System.Drawing.Point(262, 78);
            this.lblCatalagoTitulo2.Name = "lblCatalagoTitulo2";
            this.lblCatalagoTitulo2.Size = new System.Drawing.Size(23, 14);
            this.lblCatalagoTitulo2.TabIndex = 7;
            this.lblCatalagoTitulo2.Text = "DNI";
            this.lblCatalagoTitulo2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCatalagoTitulo1
            // 
            this.lblCatalagoTitulo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo1.AutoSize = true;
            this.lblCatalagoTitulo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatalagoTitulo1.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo1.Location = new System.Drawing.Point(7, 78);
            this.lblCatalagoTitulo1.Name = "lblCatalagoTitulo1";
            this.lblCatalagoTitulo1.Size = new System.Drawing.Size(74, 14);
            this.lblCatalagoTitulo1.TabIndex = 6;
            this.lblCatalagoTitulo1.Text = "Denominación";
            this.lblCatalagoTitulo1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fondoPaginacion
            // 
            this.fondoPaginacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fondoPaginacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.fondoPaginacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fondoPaginacion.Location = new System.Drawing.Point(6, 75);
            this.fondoPaginacion.Name = "fondoPaginacion";
            this.fondoPaginacion.Size = new System.Drawing.Size(610, 20);
            this.fondoPaginacion.TabIndex = 124;
            this.fondoPaginacion.TabStop = false;
            // 
            // lstCatalogo
            // 
            this.lstCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lstCatalogo.BackColor = System.Drawing.Color.White;
            this.lstCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstCatalogo.Font = new System.Drawing.Font("Lucida Console", 9F);
            this.lstCatalogo.ForeColor = System.Drawing.Color.Black;
            this.lstCatalogo.FormattingEnabled = true;
            this.lstCatalogo.ItemHeight = 12;
            this.lstCatalogo.Location = new System.Drawing.Point(7, 94);
            this.lstCatalogo.Name = "lstCatalogo";
            this.lstCatalogo.Size = new System.Drawing.Size(610, 182);
            this.lstCatalogo.TabIndex = 15;
            this.lstCatalogo.SelectedIndexChanged += new System.EventHandler(this.lstCatalogo_SelectedIndexChanged);
            this.lstCatalogo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstCatalogo_KeyDown);
            this.lstCatalogo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstCatalogo_MouseDoubleClick);
            // 
            // cmbFiltroLista2
            // 
            this.cmbFiltroLista2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbFiltroLista2.BackColor = System.Drawing.Color.White;
            this.cmbFiltroLista2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroLista2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroLista2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbFiltroLista2.ForeColor = System.Drawing.Color.Black;
            this.cmbFiltroLista2.FormattingEnabled = true;
            this.cmbFiltroLista2.ItemHeight = 14;
            this.cmbFiltroLista2.Location = new System.Drawing.Point(228, 48);
            this.cmbFiltroLista2.Margin = new System.Windows.Forms.Padding(1);
            this.cmbFiltroLista2.Name = "cmbFiltroLista2";
            this.cmbFiltroLista2.Size = new System.Drawing.Size(180, 22);
            this.cmbFiltroLista2.Sorted = true;
            this.cmbFiltroLista2.TabIndex = 2;
            this.cmbFiltroLista2.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroLista2_SelectedIndexChanged);
            // 
            // cmbFiltroLista1
            // 
            this.cmbFiltroLista1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbFiltroLista1.BackColor = System.Drawing.Color.White;
            this.cmbFiltroLista1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroLista1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFiltroLista1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbFiltroLista1.ForeColor = System.Drawing.Color.Black;
            this.cmbFiltroLista1.FormattingEnabled = true;
            this.cmbFiltroLista1.ItemHeight = 14;
            this.cmbFiltroLista1.Location = new System.Drawing.Point(6, 48);
            this.cmbFiltroLista1.Margin = new System.Windows.Forms.Padding(1);
            this.cmbFiltroLista1.Name = "cmbFiltroLista1";
            this.cmbFiltroLista1.Size = new System.Drawing.Size(220, 22);
            this.cmbFiltroLista1.Sorted = true;
            this.cmbFiltroLista1.TabIndex = 1;
            this.cmbFiltroLista1.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroLista1_SelectedIndexChanged);
            // 
            // txtFiltroLista
            // 
            this.txtFiltroLista.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtFiltroLista.BackColor = System.Drawing.Color.White;
            this.txtFiltroLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroLista.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtFiltroLista.ForeColor = System.Drawing.Color.Black;
            this.txtFiltroLista.Location = new System.Drawing.Point(410, 48);
            this.txtFiltroLista.MaxLength = 15;
            this.txtFiltroLista.Name = "txtFiltroLista";
            this.txtFiltroLista.Size = new System.Drawing.Size(206, 22);
            this.txtFiltroLista.TabIndex = 3;
            this.txtFiltroLista.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFiltroLista_KeyUp);
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
            this.pkrFiltroListaHasta.Location = new System.Drawing.Point(514, 48);
            this.pkrFiltroListaHasta.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrFiltroListaHasta.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrFiltroListaHasta.Name = "pkrFiltroListaHasta";
            this.pkrFiltroListaHasta.Size = new System.Drawing.Size(102, 22);
            this.pkrFiltroListaHasta.TabIndex = 5;
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
            this.pkrFiltroListaDesde.Location = new System.Drawing.Point(410, 48);
            this.pkrFiltroListaDesde.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrFiltroListaDesde.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrFiltroListaDesde.Name = "pkrFiltroListaDesde";
            this.pkrFiltroListaDesde.Size = new System.Drawing.Size(102, 22);
            this.pkrFiltroListaDesde.TabIndex = 4;
            this.pkrFiltroListaDesde.Visible = false;
            this.pkrFiltroListaDesde.LostFocus += new System.EventHandler(this.pkrFiltroListaDesde_LostFocus);
            // 
            // FormBaseCatalogo_LecturaF2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(622, 314);
            this.Controls.Add(this.txtFiltroLista);
            this.Controls.Add(this.pkrFiltroListaHasta);
            this.Controls.Add(this.pkrFiltroListaDesde);
            this.Controls.Add(this.btnPaginacionAnterior);
            this.Controls.Add(this.btnPaginacionInicial);
            this.Controls.Add(this.lblCatalagoTitulo4);
            this.Controls.Add(this.lblPaginacion);
            this.Controls.Add(this.btnPaginacionFinal);
            this.Controls.Add(this.btnPaginacionPosterior);
            this.Controls.Add(this.lblCatalagoTitulo3);
            this.Controls.Add(this.lblCatalagoTitulo2);
            this.Controls.Add(this.lblCatalagoTitulo1);
            this.Controls.Add(this.fondoPaginacion);
            this.Controls.Add(this.lstCatalogo);
            this.Controls.Add(this.cmbFiltroLista2);
            this.Controls.Add(this.cmbFiltroLista1);
            this.Name = "FormBaseCatalogo_LecturaF2";
            this.Load += new System.EventHandler(this.FormBaseCatalogo_LecturaF2_Load);
            this.Shown += new System.EventHandler(this.FormBaseCatalogo_LecturaF2_Shown);
            this.Controls.SetChildIndex(this.pictureTop1, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.pictureBottom, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.pictureLeft, 0);
            this.Controls.SetChildIndex(this.pictureRight, 0);
            this.Controls.SetChildIndex(this.cmbFiltroLista1, 0);
            this.Controls.SetChildIndex(this.cmbFiltroLista2, 0);
            this.Controls.SetChildIndex(this.lstCatalogo, 0);
            this.Controls.SetChildIndex(this.fondoPaginacion, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo1, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo2, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo3, 0);
            this.Controls.SetChildIndex(this.btnPaginacionPosterior, 0);
            this.Controls.SetChildIndex(this.btnPaginacionFinal, 0);
            this.Controls.SetChildIndex(this.lblPaginacion, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo4, 0);
            this.Controls.SetChildIndex(this.btnPaginacionInicial, 0);
            this.Controls.SetChildIndex(this.btnPaginacionAnterior, 0);
            this.Controls.SetChildIndex(this.pkrFiltroListaDesde, 0);
            this.Controls.SetChildIndex(this.pkrFiltroListaHasta, 0);
            this.Controls.SetChildIndex(this.txtFiltroLista, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lblCatalagoTitulo4;
        public System.Windows.Forms.Label lblCatalagoTitulo3;
        public System.Windows.Forms.Label lblCatalagoTitulo2;
        public System.Windows.Forms.Label lblCatalagoTitulo1;
        public System.Windows.Forms.ListBox lstCatalogo;
        public Controles.MiComboBox cmbFiltroLista2;
        public Controles.MiComboBox cmbFiltroLista1;
        public Controles.MiTextBox txtFiltroLista;
        public Controles.MiDateTimePicker pkrFiltroListaHasta;
        public Controles.MiDateTimePicker pkrFiltroListaDesde;
        public Controles.MiButton20x20 btnPaginacionAnterior;
        public Controles.MiButton20x20 btnPaginacionInicial;
        public System.Windows.Forms.Label lblPaginacion;
        public Controles.MiButton20x20 btnPaginacionFinal;
        public Controles.MiButton20x20 btnPaginacionPosterior;
        public System.Windows.Forms.PictureBox fondoPaginacion;
    }
}
