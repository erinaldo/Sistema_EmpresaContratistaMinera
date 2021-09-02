namespace CapaPresentacion.Catalogo
{
    partial class FormCatalogo_PerfilLaboral
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
                nPerfilLaboral.Dispose();
                nRelacion_LegajoCurriculumVitae_PerfilLaboral.Dispose();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnEliminar = new Biblioteca.Controles.MiButton24x24();
            this.btnGuardar = new Biblioteca.Controles.MiButton24x24();
            this.btnCancelar = new Biblioteca.Controles.MiButton24x24();
            this.btnNuevo = new Biblioteca.Controles.MiButton24x24();
            this.txtElementoDenominacion = new Biblioteca.Controles.MiTextBox();
            this.gridListaA = new Biblioteca.Controles.MiGrid();
            this.columnaIdA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaDenominacionA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditarCatalogo = new Biblioteca.Controles.MiButtonBase();
            this.btnAgregar = new Biblioteca.Controles.MiButton24x24();
            this.btnQuitar = new Biblioteca.Controles.MiButton24x24();
            this.gridListaB = new Biblioteca.Controles.MiGrid();
            this.columnaIdB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaDenominacionB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridListaA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridListaB)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.Location = new System.Drawing.Point(590, 260);
            this.btnCerrar.TabIndex = 11;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(660, 30);
            this.lblTitulo.Text = "Catálogo de Perfiles Laborales";
            // 
            // pictureBottom
            // 
            this.pictureBottom.Location = new System.Drawing.Point(0, 255);
            this.pictureBottom.Size = new System.Drawing.Size(660, 30);
            // 
            // pictureRight
            // 
            this.pictureRight.Location = new System.Drawing.Point(659, 0);
            this.pictureRight.Size = new System.Drawing.Size(0, 285);
            // 
            // pictureLeft
            // 
            this.pictureLeft.Size = new System.Drawing.Size(0, 285);
            // 
            // pictureTop1
            // 
            this.pictureTop1.Size = new System.Drawing.Size(660, 6);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEliminar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEliminar.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_delete32;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEliminar.Font = new System.Drawing.Font("Arial", 8F);
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.Location = new System.Drawing.Point(293, 226);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(24, 24);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGuardar.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_acept32;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 8F);
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(269, 226);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(24, 24);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_undo32;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 8F);
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(245, 226);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(24, 24);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNuevo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNuevo.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_insert32;
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevo.Enabled = false;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNuevo.Font = new System.Drawing.Font("Arial", 8F);
            this.btnNuevo.ForeColor = System.Drawing.Color.Black;
            this.btnNuevo.Location = new System.Drawing.Point(221, 226);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(24, 24);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Visible = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtElementoDenominacion
            // 
            this.txtElementoDenominacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtElementoDenominacion.BackColor = System.Drawing.Color.White;
            this.txtElementoDenominacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtElementoDenominacion.Enabled = false;
            this.txtElementoDenominacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtElementoDenominacion.ForeColor = System.Drawing.Color.Black;
            this.txtElementoDenominacion.Location = new System.Drawing.Point(6, 227);
            this.txtElementoDenominacion.MaxLength = 25;
            this.txtElementoDenominacion.Name = "txtElementoDenominacion";
            this.txtElementoDenominacion.Size = new System.Drawing.Size(214, 22);
            this.txtElementoDenominacion.TabIndex = 6;
            this.txtElementoDenominacion.Visible = false;
            // 
            // gridListaA
            // 
            this.gridListaA.AllowUserToAddRows = false;
            this.gridListaA.AllowUserToDeleteRows = false;
            this.gridListaA.AllowUserToResizeColumns = false;
            this.gridListaA.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.gridListaA.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridListaA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridListaA.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridListaA.BackgroundColor = System.Drawing.Color.Gray;
            this.gridListaA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridListaA.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridListaA.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridListaA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridListaA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnaIdA,
            this.columnaDenominacionA});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridListaA.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridListaA.EnableHeadersVisualStyles = false;
            this.gridListaA.GridColor = System.Drawing.Color.DarkGray;
            this.gridListaA.Location = new System.Drawing.Point(6, 48);
            this.gridListaA.MultiSelect = false;
            this.gridListaA.Name = "gridListaA";
            this.gridListaA.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridListaA.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridListaA.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.gridListaA.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridListaA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridListaA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridListaA.Size = new System.Drawing.Size(310, 176);
            this.gridListaA.TabIndex = 1;
            this.gridListaA.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridListaA_CellDoubleClick);
            this.gridListaA.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridListaA_CellEnter);
            // 
            // columnaIdA
            // 
            this.columnaIdA.DataPropertyName = "Id";
            this.columnaIdA.HeaderText = "ID";
            this.columnaIdA.MaxInputLength = 8;
            this.columnaIdA.Name = "columnaIdA";
            this.columnaIdA.ReadOnly = true;
            this.columnaIdA.Visible = false;
            this.columnaIdA.Width = 57;
            // 
            // columnaDenominacionA
            // 
            this.columnaDenominacionA.DataPropertyName = "Denominacion";
            this.columnaDenominacionA.HeaderText = "Catálogo de Perfiles Laborales";
            this.columnaDenominacionA.MaxInputLength = 30;
            this.columnaDenominacionA.Name = "columnaDenominacionA";
            this.columnaDenominacionA.ReadOnly = true;
            this.columnaDenominacionA.Width = 307;
            // 
            // btnEditarCatalogo
            // 
            this.btnEditarCatalogo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEditarCatalogo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditarCatalogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditarCatalogo.FlatAppearance.BorderSize = 0;
            this.btnEditarCatalogo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnEditarCatalogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEditarCatalogo.Font = new System.Drawing.Font("Arial", 9F);
            this.btnEditarCatalogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditarCatalogo.Location = new System.Drawing.Point(5, 226);
            this.btnEditarCatalogo.Margin = new System.Windows.Forms.Padding(1);
            this.btnEditarCatalogo.Name = "btnEditarCatalogo";
            this.btnEditarCatalogo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEditarCatalogo.Size = new System.Drawing.Size(311, 24);
            this.btnEditarCatalogo.TabIndex = 5;
            this.btnEditarCatalogo.Text = "Mostrar herramientas de edición ";
            this.btnEditarCatalogo.UseVisualStyleBackColor = false;
            this.btnEditarCatalogo.Click += new System.EventHandler(this.btnEditarCatalogo_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAgregar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgregar.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_add20;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 8F);
            this.btnAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.Location = new System.Drawing.Point(318, 116);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(24, 24);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnQuitar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuitar.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_remove20;
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuitar.FlatAppearance.BorderSize = 0;
            this.btnQuitar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnQuitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnQuitar.Font = new System.Drawing.Font("Arial", 8F);
            this.btnQuitar.ForeColor = System.Drawing.Color.Black;
            this.btnQuitar.Location = new System.Drawing.Point(318, 140);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(24, 24);
            this.btnQuitar.TabIndex = 3;
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // gridListaB
            // 
            this.gridListaB.AllowUserToAddRows = false;
            this.gridListaB.AllowUserToDeleteRows = false;
            this.gridListaB.AllowUserToResizeColumns = false;
            this.gridListaB.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.gridListaB.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gridListaB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridListaB.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridListaB.BackgroundColor = System.Drawing.Color.Gray;
            this.gridListaB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridListaB.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridListaB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridListaB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridListaB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnaIdB,
            this.columnaDenominacionB});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridListaB.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridListaB.EnableHeadersVisualStyles = false;
            this.gridListaB.GridColor = System.Drawing.Color.DarkGray;
            this.gridListaB.Location = new System.Drawing.Point(344, 48);
            this.gridListaB.MultiSelect = false;
            this.gridListaB.Name = "gridListaB";
            this.gridListaB.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridListaB.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gridListaB.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.gridListaB.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gridListaB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridListaB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridListaB.Size = new System.Drawing.Size(310, 176);
            this.gridListaB.TabIndex = 4;
            this.gridListaB.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridListaB_CellDoubleClick);
            this.gridListaB.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridListaB_CellEnter);
            // 
            // columnaIdB
            // 
            this.columnaIdB.DataPropertyName = "Id";
            this.columnaIdB.HeaderText = "ID";
            this.columnaIdB.MaxInputLength = 8;
            this.columnaIdB.Name = "columnaIdB";
            this.columnaIdB.ReadOnly = true;
            this.columnaIdB.Visible = false;
            this.columnaIdB.Width = 57;
            // 
            // columnaDenominacionB
            // 
            this.columnaDenominacionB.DataPropertyName = "PerfilLaboralDenominacion";
            this.columnaDenominacionB.HeaderText = "Perfiles Laborales de la Persona";
            this.columnaDenominacionB.MaxInputLength = 30;
            this.columnaDenominacionB.Name = "columnaDenominacionB";
            this.columnaDenominacionB.ReadOnly = true;
            this.columnaDenominacionB.Width = 307;
            // 
            // FormCatalogo_PerfilLaboral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(660, 285);
            this.Controls.Add(this.gridListaB);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.txtElementoDenominacion);
            this.Controls.Add(this.gridListaA);
            this.Controls.Add(this.btnEditarCatalogo);
            this.Name = "FormCatalogo_PerfilLaboral";
            this.Text = "Catálogo de Perfiles Laborales";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCatalogo_PerfilLaboral_FormClosing);
            this.Load += new System.EventHandler(this.FormCatalogo_PerfilLaboral_Load);
            this.Controls.SetChildIndex(this.pictureTop1, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.pictureBottom, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.pictureLeft, 0);
            this.Controls.SetChildIndex(this.pictureRight, 0);
            this.Controls.SetChildIndex(this.btnEditarCatalogo, 0);
            this.Controls.SetChildIndex(this.gridListaA, 0);
            this.Controls.SetChildIndex(this.txtElementoDenominacion, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnEliminar, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.btnQuitar, 0);
            this.Controls.SetChildIndex(this.gridListaB, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridListaA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridListaB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Biblioteca.Controles.MiButton24x24 btnEliminar;
        private Biblioteca.Controles.MiButton24x24 btnGuardar;
        private Biblioteca.Controles.MiButton24x24 btnCancelar;
        private Biblioteca.Controles.MiButton24x24 btnNuevo;
        private Biblioteca.Controles.MiTextBox txtElementoDenominacion;
        private Biblioteca.Controles.MiGrid gridListaA;
        private Biblioteca.Controles.MiButtonBase btnEditarCatalogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaIdA;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaDenominacionA;
        private Biblioteca.Controles.MiButton24x24 btnAgregar;
        private Biblioteca.Controles.MiButton24x24 btnQuitar;
        private Biblioteca.Controles.MiGrid gridListaB;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaIdB;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaDenominacionB;
    }
}
