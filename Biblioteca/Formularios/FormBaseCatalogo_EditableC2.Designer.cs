namespace Biblioteca.Formularios
{
    partial class FormBaseCatalogo_EditableC2
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
            this.txtFiltroLista = new Biblioteca.Controles.MiTextBox();
            this.cmbFiltroLista1 = new Biblioteca.Controles.MiComboBox();
            this.lblCatalagoTitulo1 = new System.Windows.Forms.Label();
            this.fondoPaginacion = new System.Windows.Forms.PictureBox();
            this.lstCatalogo = new System.Windows.Forms.ListBox();
            this.btnEliminar = new Biblioteca.Controles.MiButton24x24();
            this.btnGuardar = new Biblioteca.Controles.MiButton24x24();
            this.btnCancelar = new Biblioteca.Controles.MiButton24x24();
            this.btnNuevo = new Biblioteca.Controles.MiButton24x24();
            this.txtElementoDenominacion = new Biblioteca.Controles.MiTextBox();
            this.btnEditarCatalogo = new Biblioteca.Controles.MiButtonBase();
            this.lblPaginacion = new System.Windows.Forms.Label();
            this.btnPaginacionFinal = new Biblioteca.Controles.MiButton20x20();
            this.btnPaginacionPosterior = new Biblioteca.Controles.MiButton20x20();
            this.btnPaginacionAnterior = new Biblioteca.Controles.MiButton20x20();
            this.btnPaginacionInicial = new Biblioteca.Controles.MiButton20x20();
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
            this.btnCerrar.Location = new System.Drawing.Point(330, 289);
            this.btnCerrar.TabIndex = 16;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(400, 30);
            // 
            // pictureBottom
            // 
            this.pictureBottom.Location = new System.Drawing.Point(0, 284);
            this.pictureBottom.Size = new System.Drawing.Size(400, 30);
            // 
            // pictureRight
            // 
            this.pictureRight.Location = new System.Drawing.Point(399, 0);
            this.pictureRight.Size = new System.Drawing.Size(0, 314);
            // 
            // pictureLeft
            // 
            this.pictureLeft.Size = new System.Drawing.Size(0, 314);
            // 
            // pictureTop1
            // 
            this.pictureTop1.Size = new System.Drawing.Size(400, 6);
            // 
            // txtFiltroLista
            // 
            this.txtFiltroLista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFiltroLista.BackColor = System.Drawing.Color.White;
            this.txtFiltroLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroLista.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtFiltroLista.ForeColor = System.Drawing.Color.Black;
            this.txtFiltroLista.Location = new System.Drawing.Point(188, 48);
            this.txtFiltroLista.MaxLength = 15;
            this.txtFiltroLista.Name = "txtFiltroLista";
            this.txtFiltroLista.Size = new System.Drawing.Size(206, 22);
            this.txtFiltroLista.TabIndex = 2;
            this.txtFiltroLista.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFiltroLista_KeyUp);
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
            this.cmbFiltroLista1.Size = new System.Drawing.Size(180, 22);
            this.cmbFiltroLista1.Sorted = true;
            this.cmbFiltroLista1.TabIndex = 1;
            this.cmbFiltroLista1.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroLista1_SelectedIndexChanged);
            // 
            // lblCatalagoTitulo1
            // 
            this.lblCatalagoTitulo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo1.AutoSize = true;
            this.lblCatalagoTitulo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatalagoTitulo1.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo1.Location = new System.Drawing.Point(7, 77);
            this.lblCatalagoTitulo1.Name = "lblCatalagoTitulo1";
            this.lblCatalagoTitulo1.Size = new System.Drawing.Size(74, 14);
            this.lblCatalagoTitulo1.TabIndex = 3;
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
            this.fondoPaginacion.Size = new System.Drawing.Size(388, 20);
            this.fondoPaginacion.TabIndex = 82;
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
            this.lstCatalogo.Location = new System.Drawing.Point(6, 94);
            this.lstCatalogo.Name = "lstCatalogo";
            this.lstCatalogo.Size = new System.Drawing.Size(388, 158);
            this.lstCatalogo.TabIndex = 9;
            this.lstCatalogo.SelectedIndexChanged += new System.EventHandler(this.lstCatalogo_SelectedIndexChanged);
            this.lstCatalogo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstCatalogo_KeyDown);
            this.lstCatalogo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstCatalogo_MouseDoubleClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEliminar.BackgroundImage = global::Biblioteca.Properties.Resources.icon_delete32;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEliminar.Font = new System.Drawing.Font("Arial", 8F);
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.Location = new System.Drawing.Point(370, 255);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(24, 24);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGuardar.BackgroundImage = global::Biblioteca.Properties.Resources.icon_acept32;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 8F);
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(346, 255);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(24, 24);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.BackgroundImage = global::Biblioteca.Properties.Resources.icon_undo32;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 8F);
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(322, 255);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(24, 24);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNuevo.BackgroundImage = global::Biblioteca.Properties.Resources.icon_insert32;
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNuevo.Font = new System.Drawing.Font("Arial", 8F);
            this.btnNuevo.ForeColor = System.Drawing.Color.Black;
            this.btnNuevo.Location = new System.Drawing.Point(298, 255);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(24, 24);
            this.btnNuevo.TabIndex = 12;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Visible = false;
            // 
            // txtElementoDenominacion
            // 
            this.txtElementoDenominacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtElementoDenominacion.BackColor = System.Drawing.Color.White;
            this.txtElementoDenominacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtElementoDenominacion.Enabled = false;
            this.txtElementoDenominacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtElementoDenominacion.ForeColor = System.Drawing.Color.Black;
            this.txtElementoDenominacion.Location = new System.Drawing.Point(6, 254);
            this.txtElementoDenominacion.MaxLength = 25;
            this.txtElementoDenominacion.Name = "txtElementoDenominacion";
            this.txtElementoDenominacion.Size = new System.Drawing.Size(291, 22);
            this.txtElementoDenominacion.TabIndex = 11;
            this.txtElementoDenominacion.Visible = false;
            // 
            // btnEditarCatalogo
            // 
            this.btnEditarCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditarCatalogo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditarCatalogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditarCatalogo.FlatAppearance.BorderSize = 0;
            this.btnEditarCatalogo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnEditarCatalogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEditarCatalogo.Font = new System.Drawing.Font("Arial", 9F);
            this.btnEditarCatalogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditarCatalogo.Location = new System.Drawing.Point(5, 255);
            this.btnEditarCatalogo.Margin = new System.Windows.Forms.Padding(1);
            this.btnEditarCatalogo.Name = "btnEditarCatalogo";
            this.btnEditarCatalogo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEditarCatalogo.Size = new System.Drawing.Size(388, 24);
            this.btnEditarCatalogo.TabIndex = 10;
            this.btnEditarCatalogo.Text = "Mostrar herramientas de edición ";
            this.btnEditarCatalogo.UseVisualStyleBackColor = false;
            this.btnEditarCatalogo.Click += new System.EventHandler(this.btnEditarCatalogo_Click);
            // 
            // lblPaginacion
            // 
            this.lblPaginacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPaginacion.BackColor = System.Drawing.Color.Gray;
            this.lblPaginacion.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblPaginacion.ForeColor = System.Drawing.Color.White;
            this.lblPaginacion.Location = new System.Drawing.Point(331, 77);
            this.lblPaginacion.Name = "lblPaginacion";
            this.lblPaginacion.Size = new System.Drawing.Size(25, 16);
            this.lblPaginacion.TabIndex = 6;
            this.lblPaginacion.Text = "1";
            this.lblPaginacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPaginacionFinal
            // 
            this.btnPaginacionFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPaginacionFinal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPaginacionFinal.BackgroundImage = global::Biblioteca.Properties.Resources.icon_paginacion_final;
            this.btnPaginacionFinal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPaginacionFinal.FlatAppearance.BorderSize = 0;
            this.btnPaginacionFinal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionFinal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionFinal.Font = new System.Drawing.Font("Arial", 8F);
            this.btnPaginacionFinal.ForeColor = System.Drawing.Color.Black;
            this.btnPaginacionFinal.Location = new System.Drawing.Point(376, 77);
            this.btnPaginacionFinal.Name = "btnPaginacionFinal";
            this.btnPaginacionFinal.Size = new System.Drawing.Size(16, 16);
            this.btnPaginacionFinal.TabIndex = 8;
            this.btnPaginacionFinal.UseVisualStyleBackColor = false;
            this.btnPaginacionFinal.Click += new System.EventHandler(this.btnPaginacionFinal_Click);
            // 
            // btnPaginacionPosterior
            // 
            this.btnPaginacionPosterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPaginacionPosterior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPaginacionPosterior.BackgroundImage = global::Biblioteca.Properties.Resources.icon_paginacion_posterior;
            this.btnPaginacionPosterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPaginacionPosterior.FlatAppearance.BorderSize = 0;
            this.btnPaginacionPosterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionPosterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionPosterior.Font = new System.Drawing.Font("Arial", 8F);
            this.btnPaginacionPosterior.ForeColor = System.Drawing.Color.Black;
            this.btnPaginacionPosterior.Location = new System.Drawing.Point(358, 77);
            this.btnPaginacionPosterior.Name = "btnPaginacionPosterior";
            this.btnPaginacionPosterior.Size = new System.Drawing.Size(16, 16);
            this.btnPaginacionPosterior.TabIndex = 7;
            this.btnPaginacionPosterior.UseVisualStyleBackColor = false;
            this.btnPaginacionPosterior.Click += new System.EventHandler(this.btnPaginacionPosterior_Click);
            // 
            // btnPaginacionAnterior
            // 
            this.btnPaginacionAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPaginacionAnterior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPaginacionAnterior.BackgroundImage = global::Biblioteca.Properties.Resources.icon_paginacion_anterior;
            this.btnPaginacionAnterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPaginacionAnterior.FlatAppearance.BorderSize = 0;
            this.btnPaginacionAnterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionAnterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionAnterior.Font = new System.Drawing.Font("Arial", 8F);
            this.btnPaginacionAnterior.ForeColor = System.Drawing.Color.Black;
            this.btnPaginacionAnterior.Location = new System.Drawing.Point(313, 77);
            this.btnPaginacionAnterior.Name = "btnPaginacionAnterior";
            this.btnPaginacionAnterior.Size = new System.Drawing.Size(16, 16);
            this.btnPaginacionAnterior.TabIndex = 5;
            this.btnPaginacionAnterior.UseVisualStyleBackColor = false;
            this.btnPaginacionAnterior.Click += new System.EventHandler(this.btnPaginacionAnterior_Click);
            // 
            // btnPaginacionInicial
            // 
            this.btnPaginacionInicial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPaginacionInicial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPaginacionInicial.BackgroundImage = global::Biblioteca.Properties.Resources.icon_paginacion_inicial;
            this.btnPaginacionInicial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPaginacionInicial.FlatAppearance.BorderSize = 0;
            this.btnPaginacionInicial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionInicial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionInicial.Font = new System.Drawing.Font("Arial", 8F);
            this.btnPaginacionInicial.ForeColor = System.Drawing.Color.Black;
            this.btnPaginacionInicial.Location = new System.Drawing.Point(295, 77);
            this.btnPaginacionInicial.Name = "btnPaginacionInicial";
            this.btnPaginacionInicial.Size = new System.Drawing.Size(16, 16);
            this.btnPaginacionInicial.TabIndex = 4;
            this.btnPaginacionInicial.UseVisualStyleBackColor = false;
            this.btnPaginacionInicial.Click += new System.EventHandler(this.btnPaginacionInicial_Click);
            // 
            // FormBaseCatalogo_EditableC2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(400, 314);
            this.Controls.Add(this.lblPaginacion);
            this.Controls.Add(this.btnPaginacionFinal);
            this.Controls.Add(this.btnPaginacionPosterior);
            this.Controls.Add(this.btnPaginacionAnterior);
            this.Controls.Add(this.btnPaginacionInicial);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.txtElementoDenominacion);
            this.Controls.Add(this.btnEditarCatalogo);
            this.Controls.Add(this.lblCatalagoTitulo1);
            this.Controls.Add(this.fondoPaginacion);
            this.Controls.Add(this.lstCatalogo);
            this.Controls.Add(this.txtFiltroLista);
            this.Controls.Add(this.cmbFiltroLista1);
            this.Name = "FormBaseCatalogo_EditableC2";
            this.Load += new System.EventHandler(this.FormBaseModal_CatalogoC2_Load);
            this.Shown += new System.EventHandler(this.FormBaseModal_CatalogoC2_Shown);
            this.Controls.SetChildIndex(this.cmbFiltroLista1, 0);
            this.Controls.SetChildIndex(this.txtFiltroLista, 0);
            this.Controls.SetChildIndex(this.pictureTop1, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.pictureBottom, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.pictureLeft, 0);
            this.Controls.SetChildIndex(this.pictureRight, 0);
            this.Controls.SetChildIndex(this.lstCatalogo, 0);
            this.Controls.SetChildIndex(this.fondoPaginacion, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo1, 0);
            this.Controls.SetChildIndex(this.btnEditarCatalogo, 0);
            this.Controls.SetChildIndex(this.txtElementoDenominacion, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnPaginacionInicial, 0);
            this.Controls.SetChildIndex(this.btnPaginacionAnterior, 0);
            this.Controls.SetChildIndex(this.btnPaginacionPosterior, 0);
            this.Controls.SetChildIndex(this.btnPaginacionFinal, 0);
            this.Controls.SetChildIndex(this.lblPaginacion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Controles.MiTextBox txtFiltroLista;
        public Controles.MiComboBox cmbFiltroLista1;
        public System.Windows.Forms.Label lblCatalagoTitulo1;
        private System.Windows.Forms.PictureBox fondoPaginacion;
        public System.Windows.Forms.ListBox lstCatalogo;
        public Controles.MiButton24x24 btnEliminar;
        public Controles.MiButton24x24 btnGuardar;
        public Controles.MiButton24x24 btnCancelar;
        public Controles.MiButton24x24 btnNuevo;
        public Controles.MiTextBox txtElementoDenominacion;
        public Controles.MiButtonBase btnEditarCatalogo;
        public System.Windows.Forms.Label lblPaginacion;
        public Controles.MiButton20x20 btnPaginacionFinal;
        public Controles.MiButton20x20 btnPaginacionPosterior;
        public Controles.MiButton20x20 btnPaginacionAnterior;
        public Controles.MiButton20x20 btnPaginacionInicial;
    }
}
