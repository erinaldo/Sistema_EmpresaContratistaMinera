namespace CapaPresentacion
{
    partial class FormUsuario
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
                nUsuario.Dispose();
                nPrivilegio.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsuario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnBuscarLegajo = new Biblioteca.Controles.MiButtonFind();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.txtCuit = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.txtContrasenia = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.cmbTipoUsuario = new Biblioteca.Controles.MiComboBox();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.txtEmailRecuperacion = new Biblioteca.Controles.MiTextBox();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.chkAlertaFacturacion = new Biblioteca.Controles.MiCheckBox();
            this.chkAlertaInventario = new Biblioteca.Controles.MiCheckBox();
            this.chkAlertaRRHH = new Biblioteca.Controles.MiCheckBox();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.gridListaPrivilegio = new Biblioteca.Controles.MiGridSelection();
            this.columnaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaDenominacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaAcceso = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListaPrivilegio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAnular.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAnular.Text = "Eliminar";
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // btnExcel_Registro
            // 
            this.btnExcel_Registro.FlatAppearance.BorderSize = 0;
            this.btnExcel_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // btnPDF_Registro
            // 
            this.btnPDF_Registro.FlatAppearance.BorderSize = 0;
            this.btnPDF_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // btnExcel_Lista
            // 
            this.btnExcel_Lista.FlatAppearance.BorderSize = 0;
            this.btnExcel_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // btnPDF_Lista
            // 
            this.btnPDF_Lista.FlatAppearance.BorderSize = 0;
            this.btnPDF_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Usuarios";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // btnBuscarLegajo
            // 
            this.btnBuscarLegajo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBuscarLegajo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarLegajo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarLegajo.BackgroundImage")));
            this.btnBuscarLegajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarLegajo.FlatAppearance.BorderSize = 0;
            this.btnBuscarLegajo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBuscarLegajo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuscarLegajo.Font = new System.Drawing.Font("Arial", 9F);
            this.btnBuscarLegajo.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarLegajo.Location = new System.Drawing.Point(476, 60);
            this.btnBuscarLegajo.Name = "btnBuscarLegajo";
            this.btnBuscarLegajo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBuscarLegajo.Size = new System.Drawing.Size(24, 24);
            this.btnBuscarLegajo.TabIndex = 13;
            this.btnBuscarLegajo.UseVisualStyleBackColor = false;
            this.btnBuscarLegajo.Click += new System.EventHandler(this.btnBuscarLegajo_Click);
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
            this.miLabel1.TabIndex = 11;
            this.miLabel1.Text = "Denominación";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenominacion
            // 
            this.txtDenominacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDenominacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtDenominacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDenominacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDenominacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtDenominacion.ForeColor = System.Drawing.Color.Black;
            this.txtDenominacion.Location = new System.Drawing.Point(160, 61);
            this.txtDenominacion.MaxLength = 35;
            this.txtDenominacion.Name = "txtDenominacion";
            this.txtDenominacion.ReadOnly = true;
            this.txtDenominacion.Size = new System.Drawing.Size(315, 22);
            this.txtDenominacion.TabIndex = 12;
            // 
            // txtCuit
            // 
            this.txtCuit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtCuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuit.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCuit.ForeColor = System.Drawing.Color.Black;
            this.txtCuit.Location = new System.Drawing.Point(160, 88);
            this.txtCuit.MaxLength = 15;
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.ReadOnly = true;
            this.txtCuit.Size = new System.Drawing.Size(100, 22);
            this.txtCuit.TabIndex = 15;
            // 
            // miLabel2
            // 
            this.miLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel2.BackColor = System.Drawing.Color.Transparent;
            this.miLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel2.Location = new System.Drawing.Point(0, 92);
            this.miLabel2.Name = "miLabel2";
            this.miLabel2.Size = new System.Drawing.Size(160, 15);
            this.miLabel2.TabIndex = 14;
            this.miLabel2.Text = "CUIL/CUIT";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtContrasenia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtContrasenia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContrasenia.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtContrasenia.ForeColor = System.Drawing.Color.Black;
            this.txtContrasenia.Location = new System.Drawing.Point(160, 115);
            this.txtContrasenia.MaxLength = 8;
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.ReadOnly = true;
            this.txtContrasenia.Size = new System.Drawing.Size(75, 22);
            this.txtContrasenia.TabIndex = 17;
            this.txtContrasenia.UseSystemPasswordChar = true;
            // 
            // miLabel3
            // 
            this.miLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel3.BackColor = System.Drawing.Color.Transparent;
            this.miLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel3.Location = new System.Drawing.Point(0, 118);
            this.miLabel3.Name = "miLabel3";
            this.miLabel3.Size = new System.Drawing.Size(160, 15);
            this.miLabel3.TabIndex = 16;
            this.miLabel3.Text = "Contraseña";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoUsuario
            // 
            this.cmbTipoUsuario.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbTipoUsuario.BackColor = System.Drawing.Color.White;
            this.cmbTipoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoUsuario.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbTipoUsuario.ForeColor = System.Drawing.Color.Black;
            this.cmbTipoUsuario.FormattingEnabled = true;
            this.cmbTipoUsuario.ItemHeight = 14;
            this.cmbTipoUsuario.Items.AddRange(new object[] {
            "OPERADOR",
            "SOPORTE TECNICO",
            "SUPERVISOR"});
            this.cmbTipoUsuario.Location = new System.Drawing.Point(160, 142);
            this.cmbTipoUsuario.Margin = new System.Windows.Forms.Padding(1);
            this.cmbTipoUsuario.Name = "cmbTipoUsuario";
            this.cmbTipoUsuario.Size = new System.Drawing.Size(125, 22);
            this.cmbTipoUsuario.Sorted = true;
            this.cmbTipoUsuario.TabIndex = 19;
            this.cmbTipoUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbTipoUsuario_SelectedIndexChanged);
            // 
            // miLabel4
            // 
            this.miLabel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel4.BackColor = System.Drawing.Color.Transparent;
            this.miLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel4.Location = new System.Drawing.Point(0, 145);
            this.miLabel4.Name = "miLabel4";
            this.miLabel4.Size = new System.Drawing.Size(160, 15);
            this.miLabel4.TabIndex = 18;
            this.miLabel4.Text = "Tipo de cuenta";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmailRecuperacion
            // 
            this.txtEmailRecuperacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEmailRecuperacion.BackColor = System.Drawing.Color.White;
            this.txtEmailRecuperacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailRecuperacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmailRecuperacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtEmailRecuperacion.ForeColor = System.Drawing.Color.Black;
            this.txtEmailRecuperacion.Location = new System.Drawing.Point(160, 169);
            this.txtEmailRecuperacion.MaxLength = 50;
            this.txtEmailRecuperacion.Name = "txtEmailRecuperacion";
            this.txtEmailRecuperacion.Size = new System.Drawing.Size(340, 22);
            this.txtEmailRecuperacion.TabIndex = 21;
            // 
            // miLabel5
            // 
            this.miLabel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel5.BackColor = System.Drawing.Color.Transparent;
            this.miLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel5.Location = new System.Drawing.Point(0, 172);
            this.miLabel5.Name = "miLabel5";
            this.miLabel5.Size = new System.Drawing.Size(160, 15);
            this.miLabel5.TabIndex = 20;
            this.miLabel5.Text = "E-mail de recuperación";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAlertaFacturacion
            // 
            this.chkAlertaFacturacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkAlertaFacturacion.AutoSize = true;
            this.chkAlertaFacturacion.BackColor = System.Drawing.Color.Transparent;
            this.chkAlertaFacturacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkAlertaFacturacion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAlertaFacturacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkAlertaFacturacion.Location = new System.Drawing.Point(160, 199);
            this.chkAlertaFacturacion.Name = "chkAlertaFacturacion";
            this.chkAlertaFacturacion.Size = new System.Drawing.Size(188, 19);
            this.chkAlertaFacturacion.TabIndex = 22;
            this.chkAlertaFacturacion.Text = "Mostrar alertas de facturación";
            this.chkAlertaFacturacion.UseVisualStyleBackColor = false;
            // 
            // chkAlertaInventario
            // 
            this.chkAlertaInventario.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkAlertaInventario.AutoSize = true;
            this.chkAlertaInventario.BackColor = System.Drawing.Color.Transparent;
            this.chkAlertaInventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkAlertaInventario.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAlertaInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkAlertaInventario.Location = new System.Drawing.Point(160, 220);
            this.chkAlertaInventario.Name = "chkAlertaInventario";
            this.chkAlertaInventario.Size = new System.Drawing.Size(181, 19);
            this.chkAlertaInventario.TabIndex = 23;
            this.chkAlertaInventario.Text = "Mostrar alertas de inventario";
            this.chkAlertaInventario.UseVisualStyleBackColor = false;
            // 
            // chkAlertaRRHH
            // 
            this.chkAlertaRRHH.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkAlertaRRHH.AutoSize = true;
            this.chkAlertaRRHH.BackColor = System.Drawing.Color.Transparent;
            this.chkAlertaRRHH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkAlertaRRHH.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAlertaRRHH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkAlertaRRHH.Location = new System.Drawing.Point(160, 241);
            this.chkAlertaRRHH.Name = "chkAlertaRRHH";
            this.chkAlertaRRHH.Size = new System.Drawing.Size(164, 19);
            this.chkAlertaRRHH.TabIndex = 24;
            this.chkAlertaRRHH.Text = "Mostrar alertas de RRHH";
            this.chkAlertaRRHH.UseVisualStyleBackColor = false;
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(0, 268);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(160, 15);
            this.miLabel7.TabIndex = 25;
            this.miLabel7.Text = "Privilegios del usuario";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gridListaPrivilegio
            // 
            this.gridListaPrivilegio.AllowUserToAddRows = false;
            this.gridListaPrivilegio.AllowUserToDeleteRows = false;
            this.gridListaPrivilegio.AllowUserToResizeColumns = false;
            this.gridListaPrivilegio.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.gridListaPrivilegio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridListaPrivilegio.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gridListaPrivilegio.BackgroundColor = System.Drawing.Color.Gray;
            this.gridListaPrivilegio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridListaPrivilegio.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridListaPrivilegio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridListaPrivilegio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridListaPrivilegio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnaID,
            this.columnaDenominacion,
            this.columnaAcceso});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridListaPrivilegio.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridListaPrivilegio.EnableHeadersVisualStyles = false;
            this.gridListaPrivilegio.GridColor = System.Drawing.Color.DarkGray;
            this.gridListaPrivilegio.Location = new System.Drawing.Point(160, 265);
            this.gridListaPrivilegio.Name = "gridListaPrivilegio";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridListaPrivilegio.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridListaPrivilegio.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.gridListaPrivilegio.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridListaPrivilegio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridListaPrivilegio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridListaPrivilegio.Size = new System.Drawing.Size(572, 239);
            this.gridListaPrivilegio.TabIndex = 26;
            // 
            // columnaID
            // 
            this.columnaID.DataPropertyName = "Id";
            this.columnaID.HeaderText = "ID";
            this.columnaID.Name = "columnaID";
            this.columnaID.Width = 35;
            // 
            // columnaDenominacion
            // 
            this.columnaDenominacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnaDenominacion.DataPropertyName = "Denominacion";
            this.columnaDenominacion.HeaderText = "Privilegio";
            this.columnaDenominacion.Name = "columnaDenominacion";
            // 
            // columnaAcceso
            // 
            this.columnaAcceso.DataPropertyName = "Permiso";
            this.columnaAcceso.FalseValue = "false";
            this.columnaAcceso.HeaderText = "Permiso";
            this.columnaAcceso.Name = "columnaAcceso";
            this.columnaAcceso.TrueValue = "true";
            this.columnaAcceso.Width = 50;
            // 
            // FormUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.gridListaPrivilegio);
            this.Controls.Add(this.chkAlertaRRHH);
            this.Controls.Add(this.chkAlertaInventario);
            this.Controls.Add(this.txtEmailRecuperacion);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.cmbTipoUsuario);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.txtContrasenia);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.btnBuscarLegajo);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtDenominacion);
            this.Controls.Add(this.chkAlertaFacturacion);
            this.Name = "FormUsuario";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.FormUsuario_Load);
            this.Controls.SetChildIndex(this.chkAlertaFacturacion, 0);
            this.Controls.SetChildIndex(this.labelPublicacion, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.btnExcel_Registro, 0);
            this.Controls.SetChildIndex(this.btnPDF_Registro, 0);
            this.Controls.SetChildIndex(this.panelLista, 0);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.btnBuscarLegajo, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.txtCuit, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.txtContrasenia, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.cmbTipoUsuario, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.txtEmailRecuperacion, 0);
            this.Controls.SetChildIndex(this.chkAlertaInventario, 0);
            this.Controls.SetChildIndex(this.chkAlertaRRHH, 0);
            this.Controls.SetChildIndex(this.gridListaPrivilegio, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListaPrivilegio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Biblioteca.Controles.MiButtonFind btnBuscarLegajo;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBox txtDenominacion;
        private Biblioteca.Controles.MiTextBoxRead txtCuit;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiTextBoxRead txtContrasenia;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiComboBox cmbTipoUsuario;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiTextBox txtEmailRecuperacion;
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiCheckBox chkAlertaFacturacion;
        private Biblioteca.Controles.MiCheckBox chkAlertaInventario;
        private Biblioteca.Controles.MiCheckBox chkAlertaRRHH;
        private Biblioteca.Controles.MiLabel miLabel7;
        private Biblioteca.Controles.MiGridSelection gridListaPrivilegio;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaDenominacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnaAcceso;
    }
}