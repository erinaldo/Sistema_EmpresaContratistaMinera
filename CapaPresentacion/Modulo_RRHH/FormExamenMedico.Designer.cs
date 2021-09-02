namespace CapaPresentacion
{
    partial class FormExamenMedico
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
                nLegajo.Dispose();
                nExamenMedico.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExamenMedico));
            this.btnBuscarLegajo = new Biblioteca.Controles.MiButtonFind();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.txtCuit = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.lblCatalagoTitulo7 = new System.Windows.Forms.Label();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.txtInstitucion = new Biblioteca.Controles.MiTextBox();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.cmbTipoExamen = new Biblioteca.Controles.MiComboBox();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.pkrFechaExamen = new Biblioteca.Controles.MiDateTimePicker();
            this.groupEvaluacionRespirador = new System.Windows.Forms.GroupBox();
            this.pkrEvaluacionRespiradorVto = new Biblioteca.Controles.MiDateTimePicker();
            this.lblEvaluacionRespirador2 = new Biblioteca.Controles.MiLabel();
            this.pkrEvaluacionRespiradorEmision = new Biblioteca.Controles.MiDateTimePicker();
            this.lblEvaluacionRespirador1 = new Biblioteca.Controles.MiLabel();
            this.chkEvaluacionRespirador = new Biblioteca.Controles.MiCheckBox();
            this.groupCaraCompleta = new System.Windows.Forms.GroupBox();
            this.cmbCaraCompletaTamanio = new Biblioteca.Controles.MiComboBox();
            this.lblCaraCompleta4 = new Biblioteca.Controles.MiLabel();
            this.txtCaraCompletaModelo = new Biblioteca.Controles.MiTextBox();
            this.lblCaraCompleta3 = new Biblioteca.Controles.MiLabel();
            this.txtCaraCompletaMarca = new Biblioteca.Controles.MiTextBox();
            this.lblCaraCompleta2 = new Biblioteca.Controles.MiLabel();
            this.pkrCaraCompletaEmision = new Biblioteca.Controles.MiDateTimePicker();
            this.lblCaraCompleta1 = new Biblioteca.Controles.MiLabel();
            this.chkCaraCompleta = new Biblioteca.Controles.MiCheckBox();
            this.groupMediaCara = new System.Windows.Forms.GroupBox();
            this.cmbMediaCaraTamanio = new Biblioteca.Controles.MiComboBox();
            this.lblMediaCara4 = new Biblioteca.Controles.MiLabel();
            this.txtMediaCaraModelo = new Biblioteca.Controles.MiTextBox();
            this.lblMediaCara3 = new Biblioteca.Controles.MiLabel();
            this.txtMediaCaraMarca = new Biblioteca.Controles.MiTextBox();
            this.lblMediaCara2 = new Biblioteca.Controles.MiLabel();
            this.pkrMediaCaraEmision = new Biblioteca.Controles.MiDateTimePicker();
            this.lblMediaCara1 = new Biblioteca.Controles.MiLabel();
            this.chkMediaCara = new Biblioteca.Controles.MiCheckBox();
            this.txtObservacion = new Biblioteca.Controles.MiTextBox();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.cmbEvaluacionMedica = new Biblioteca.Controles.MiComboBox();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.txtEstado = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel8 = new Biblioteca.Controles.MiLabel();
            this.lblCatalagoTitulo8 = new System.Windows.Forms.Label();
            this.panelLista.SuspendLayout();
            this.groupEvaluacionRespirador.SuspendLayout();
            this.groupCaraCompleta.SuspendLayout();
            this.groupMediaCara.SuspendLayout();
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
            // lblTituloLista
            // 
            this.lblTituloLista.Text = "Lista de Exámenes Médicos";
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
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(343, 36);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(54, 14);
            this.lblCatalagoTitulo3.Text = "CUIL/CUIT";
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(455, 36);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(83, 14);
            this.lblCatalagoTitulo4.Text = "Tipo de Examen";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(574, 36);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(56, 14);
            this.lblCatalagoTitulo5.Text = "F. Examen";
            // 
            // panelLista
            // 
            this.panelLista.Controls.Add(this.lblCatalagoTitulo8);
            this.panelLista.Controls.Add(this.lblCatalagoTitulo7);
            this.panelLista.TabIndex = 11;
            this.panelLista.Controls.SetChildIndex(this.lstCatalogo, 0);
            this.panelLista.Controls.SetChildIndex(this.pkrFiltroListaDesde, 0);
            this.panelLista.Controls.SetChildIndex(this.pkrFiltroListaHasta, 0);
            this.panelLista.Controls.SetChildIndex(this.lblTituloLista, 0);
            this.panelLista.Controls.SetChildIndex(this.cmbFiltroLista1, 0);
            this.panelLista.Controls.SetChildIndex(this.cmbFiltroLista2, 0);
            this.panelLista.Controls.SetChildIndex(this.txtFiltroLista, 0);
            this.panelLista.Controls.SetChildIndex(this.btnExcel_Lista, 0);
            this.panelLista.Controls.SetChildIndex(this.btnPDF_Lista, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo1, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo2, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo3, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo4, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo5, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo6, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo7, 0);
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo8, 0);
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(665, 36);
            this.lblCatalagoTitulo6.Size = new System.Drawing.Size(68, 14);
            this.lblCatalagoTitulo6.Text = "Examen Vto.";
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Exámenes Médicos";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 10;
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
            this.btnBuscarLegajo.TabIndex = 14;
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
            this.miLabel1.TabIndex = 12;
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
            this.txtDenominacion.TabIndex = 13;
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
            this.txtCuit.TabIndex = 16;
            // 
            // miLabel2
            // 
            this.miLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel2.BackColor = System.Drawing.Color.Transparent;
            this.miLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel2.Location = new System.Drawing.Point(0, 91);
            this.miLabel2.Name = "miLabel2";
            this.miLabel2.Size = new System.Drawing.Size(160, 15);
            this.miLabel2.TabIndex = 15;
            this.miLabel2.Text = "CUIL/CUIT";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCatalagoTitulo7
            // 
            this.lblCatalagoTitulo7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo7.AutoSize = true;
            this.lblCatalagoTitulo7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo7.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo7.Location = new System.Drawing.Point(756, 36);
            this.lblCatalagoTitulo7.Name = "lblCatalagoTitulo7";
            this.lblCatalagoTitulo7.Size = new System.Drawing.Size(59, 14);
            this.lblCatalagoTitulo7.TabIndex = 25;
            this.lblCatalagoTitulo7.Text = "Evaluación";
            this.lblCatalagoTitulo7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // miLabel3
            // 
            this.miLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel3.BackColor = System.Drawing.Color.Transparent;
            this.miLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel3.Location = new System.Drawing.Point(0, 117);
            this.miLabel3.Name = "miLabel3";
            this.miLabel3.Size = new System.Drawing.Size(160, 15);
            this.miLabel3.TabIndex = 17;
            this.miLabel3.Text = "Institución";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInstitucion
            // 
            this.txtInstitucion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtInstitucion.BackColor = System.Drawing.Color.White;
            this.txtInstitucion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstitucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInstitucion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtInstitucion.ForeColor = System.Drawing.Color.Black;
            this.txtInstitucion.Location = new System.Drawing.Point(160, 115);
            this.txtInstitucion.MaxLength = 20;
            this.txtInstitucion.Name = "txtInstitucion";
            this.txtInstitucion.Size = new System.Drawing.Size(185, 22);
            this.txtInstitucion.TabIndex = 18;
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
            this.miLabel4.TabIndex = 19;
            this.miLabel4.Text = "Tipo de examen";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoExamen
            // 
            this.cmbTipoExamen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbTipoExamen.BackColor = System.Drawing.Color.White;
            this.cmbTipoExamen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoExamen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoExamen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbTipoExamen.ForeColor = System.Drawing.Color.Black;
            this.cmbTipoExamen.FormattingEnabled = true;
            this.cmbTipoExamen.ItemHeight = 14;
            this.cmbTipoExamen.Items.AddRange(new object[] {
            "ART",
            "PERIODICO",
            "PREOCUPACIONAL"});
            this.cmbTipoExamen.Location = new System.Drawing.Point(160, 142);
            this.cmbTipoExamen.Margin = new System.Windows.Forms.Padding(1);
            this.cmbTipoExamen.Name = "cmbTipoExamen";
            this.cmbTipoExamen.Size = new System.Drawing.Size(125, 22);
            this.cmbTipoExamen.Sorted = true;
            this.cmbTipoExamen.TabIndex = 20;
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
            this.miLabel5.TabIndex = 21;
            this.miLabel5.Text = "Fecha del examen";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pkrFechaExamen
            // 
            this.pkrFechaExamen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrFechaExamen.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrFechaExamen.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrFechaExamen.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrFechaExamen.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrFechaExamen.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrFechaExamen.CustomFormat = "dd/MM/yyyy";
            this.pkrFechaExamen.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrFechaExamen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrFechaExamen.Location = new System.Drawing.Point(160, 169);
            this.pkrFechaExamen.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrFechaExamen.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrFechaExamen.Name = "pkrFechaExamen";
            this.pkrFechaExamen.Size = new System.Drawing.Size(102, 22);
            this.pkrFechaExamen.TabIndex = 22;
            // 
            // groupEvaluacionRespirador
            // 
            this.groupEvaluacionRespirador.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupEvaluacionRespirador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupEvaluacionRespirador.Controls.Add(this.pkrEvaluacionRespiradorVto);
            this.groupEvaluacionRespirador.Controls.Add(this.lblEvaluacionRespirador2);
            this.groupEvaluacionRespirador.Controls.Add(this.pkrEvaluacionRespiradorEmision);
            this.groupEvaluacionRespirador.Controls.Add(this.lblEvaluacionRespirador1);
            this.groupEvaluacionRespirador.Controls.Add(this.chkEvaluacionRespirador);
            this.groupEvaluacionRespirador.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupEvaluacionRespirador.ForeColor = System.Drawing.Color.Gray;
            this.groupEvaluacionRespirador.Location = new System.Drawing.Point(160, 197);
            this.groupEvaluacionRespirador.Name = "groupEvaluacionRespirador";
            this.groupEvaluacionRespirador.Size = new System.Drawing.Size(527, 44);
            this.groupEvaluacionRespirador.TabIndex = 23;
            this.groupEvaluacionRespirador.TabStop = false;
            this.groupEvaluacionRespirador.Text = "      Evaluación médica de respirador";
            // 
            // pkrEvaluacionRespiradorVto
            // 
            this.pkrEvaluacionRespiradorVto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrEvaluacionRespiradorVto.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrEvaluacionRespiradorVto.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrEvaluacionRespiradorVto.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrEvaluacionRespiradorVto.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrEvaluacionRespiradorVto.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrEvaluacionRespiradorVto.CustomFormat = "dd/MM/yyyy";
            this.pkrEvaluacionRespiradorVto.Enabled = false;
            this.pkrEvaluacionRespiradorVto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrEvaluacionRespiradorVto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrEvaluacionRespiradorVto.Location = new System.Drawing.Point(411, 15);
            this.pkrEvaluacionRespiradorVto.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrEvaluacionRespiradorVto.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrEvaluacionRespiradorVto.Name = "pkrEvaluacionRespiradorVto";
            this.pkrEvaluacionRespiradorVto.Size = new System.Drawing.Size(102, 22);
            this.pkrEvaluacionRespiradorVto.TabIndex = 4;
            this.pkrEvaluacionRespiradorVto.Visible = false;
            // 
            // lblEvaluacionRespirador2
            // 
            this.lblEvaluacionRespirador2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblEvaluacionRespirador2.BackColor = System.Drawing.Color.Transparent;
            this.lblEvaluacionRespirador2.Enabled = false;
            this.lblEvaluacionRespirador2.Font = new System.Drawing.Font("Arial", 9F);
            this.lblEvaluacionRespirador2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblEvaluacionRespirador2.Location = new System.Drawing.Point(266, 18);
            this.lblEvaluacionRespirador2.Name = "lblEvaluacionRespirador2";
            this.lblEvaluacionRespirador2.Size = new System.Drawing.Size(145, 15);
            this.lblEvaluacionRespirador2.TabIndex = 3;
            this.lblEvaluacionRespirador2.Text = "Fecha de vto.";
            this.lblEvaluacionRespirador2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblEvaluacionRespirador2.Visible = false;
            // 
            // pkrEvaluacionRespiradorEmision
            // 
            this.pkrEvaluacionRespiradorEmision.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrEvaluacionRespiradorEmision.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrEvaluacionRespiradorEmision.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrEvaluacionRespiradorEmision.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrEvaluacionRespiradorEmision.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrEvaluacionRespiradorEmision.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrEvaluacionRespiradorEmision.CustomFormat = "dd/MM/yyyy";
            this.pkrEvaluacionRespiradorEmision.Enabled = false;
            this.pkrEvaluacionRespiradorEmision.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrEvaluacionRespiradorEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrEvaluacionRespiradorEmision.Location = new System.Drawing.Point(145, 15);
            this.pkrEvaluacionRespiradorEmision.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrEvaluacionRespiradorEmision.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrEvaluacionRespiradorEmision.Name = "pkrEvaluacionRespiradorEmision";
            this.pkrEvaluacionRespiradorEmision.Size = new System.Drawing.Size(102, 22);
            this.pkrEvaluacionRespiradorEmision.TabIndex = 2;
            this.pkrEvaluacionRespiradorEmision.Visible = false;
            // 
            // lblEvaluacionRespirador1
            // 
            this.lblEvaluacionRespirador1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblEvaluacionRespirador1.BackColor = System.Drawing.Color.Transparent;
            this.lblEvaluacionRespirador1.Enabled = false;
            this.lblEvaluacionRespirador1.Font = new System.Drawing.Font("Arial", 9F);
            this.lblEvaluacionRespirador1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblEvaluacionRespirador1.Location = new System.Drawing.Point(0, 18);
            this.lblEvaluacionRespirador1.Name = "lblEvaluacionRespirador1";
            this.lblEvaluacionRespirador1.Size = new System.Drawing.Size(145, 15);
            this.lblEvaluacionRespirador1.TabIndex = 1;
            this.lblEvaluacionRespirador1.Text = "Fecha de emisión";
            this.lblEvaluacionRespirador1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblEvaluacionRespirador1.Visible = false;
            // 
            // chkEvaluacionRespirador
            // 
            this.chkEvaluacionRespirador.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkEvaluacionRespirador.AutoSize = true;
            this.chkEvaluacionRespirador.BackColor = System.Drawing.Color.Transparent;
            this.chkEvaluacionRespirador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkEvaluacionRespirador.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEvaluacionRespirador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkEvaluacionRespirador.Location = new System.Drawing.Point(11, 1);
            this.chkEvaluacionRespirador.Name = "chkEvaluacionRespirador";
            this.chkEvaluacionRespirador.Size = new System.Drawing.Size(15, 14);
            this.chkEvaluacionRespirador.TabIndex = 0;
            this.chkEvaluacionRespirador.UseVisualStyleBackColor = false;
            this.chkEvaluacionRespirador.CheckedChanged += new System.EventHandler(this.chkEvaluacionRespirador_CheckedChanged);
            // 
            // groupCaraCompleta
            // 
            this.groupCaraCompleta.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupCaraCompleta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupCaraCompleta.Controls.Add(this.cmbCaraCompletaTamanio);
            this.groupCaraCompleta.Controls.Add(this.lblCaraCompleta4);
            this.groupCaraCompleta.Controls.Add(this.txtCaraCompletaModelo);
            this.groupCaraCompleta.Controls.Add(this.lblCaraCompleta3);
            this.groupCaraCompleta.Controls.Add(this.txtCaraCompletaMarca);
            this.groupCaraCompleta.Controls.Add(this.lblCaraCompleta2);
            this.groupCaraCompleta.Controls.Add(this.pkrCaraCompletaEmision);
            this.groupCaraCompleta.Controls.Add(this.lblCaraCompleta1);
            this.groupCaraCompleta.Controls.Add(this.chkCaraCompleta);
            this.groupCaraCompleta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupCaraCompleta.ForeColor = System.Drawing.Color.Gray;
            this.groupCaraCompleta.Location = new System.Drawing.Point(160, 246);
            this.groupCaraCompleta.Name = "groupCaraCompleta";
            this.groupCaraCompleta.Size = new System.Drawing.Size(261, 125);
            this.groupCaraCompleta.TabIndex = 24;
            this.groupCaraCompleta.TabStop = false;
            this.groupCaraCompleta.Text = "      Fit Test: Respirador de cara completa";
            // 
            // cmbCaraCompletaTamanio
            // 
            this.cmbCaraCompletaTamanio.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbCaraCompletaTamanio.BackColor = System.Drawing.Color.White;
            this.cmbCaraCompletaTamanio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCaraCompletaTamanio.Enabled = false;
            this.cmbCaraCompletaTamanio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCaraCompletaTamanio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCaraCompletaTamanio.ForeColor = System.Drawing.Color.Black;
            this.cmbCaraCompletaTamanio.FormattingEnabled = true;
            this.cmbCaraCompletaTamanio.ItemHeight = 14;
            this.cmbCaraCompletaTamanio.Items.AddRange(new object[] {
            "L",
            "M",
            "S",
            "XL"});
            this.cmbCaraCompletaTamanio.Location = new System.Drawing.Point(145, 96);
            this.cmbCaraCompletaTamanio.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCaraCompletaTamanio.Name = "cmbCaraCompletaTamanio";
            this.cmbCaraCompletaTamanio.Size = new System.Drawing.Size(40, 22);
            this.cmbCaraCompletaTamanio.Sorted = true;
            this.cmbCaraCompletaTamanio.TabIndex = 8;
            this.cmbCaraCompletaTamanio.Visible = false;
            // 
            // lblCaraCompleta4
            // 
            this.lblCaraCompleta4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCaraCompleta4.BackColor = System.Drawing.Color.Transparent;
            this.lblCaraCompleta4.Enabled = false;
            this.lblCaraCompleta4.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCaraCompleta4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblCaraCompleta4.Location = new System.Drawing.Point(0, 99);
            this.lblCaraCompleta4.Name = "lblCaraCompleta4";
            this.lblCaraCompleta4.Size = new System.Drawing.Size(145, 15);
            this.lblCaraCompleta4.TabIndex = 7;
            this.lblCaraCompleta4.Text = "Tamaño";
            this.lblCaraCompleta4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCaraCompleta4.Visible = false;
            // 
            // txtCaraCompletaModelo
            // 
            this.txtCaraCompletaModelo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCaraCompletaModelo.BackColor = System.Drawing.Color.White;
            this.txtCaraCompletaModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCaraCompletaModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCaraCompletaModelo.Enabled = false;
            this.txtCaraCompletaModelo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCaraCompletaModelo.ForeColor = System.Drawing.Color.Black;
            this.txtCaraCompletaModelo.Location = new System.Drawing.Point(145, 69);
            this.txtCaraCompletaModelo.MaxLength = 12;
            this.txtCaraCompletaModelo.Name = "txtCaraCompletaModelo";
            this.txtCaraCompletaModelo.Size = new System.Drawing.Size(110, 22);
            this.txtCaraCompletaModelo.TabIndex = 6;
            this.txtCaraCompletaModelo.Visible = false;
            // 
            // lblCaraCompleta3
            // 
            this.lblCaraCompleta3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCaraCompleta3.BackColor = System.Drawing.Color.Transparent;
            this.lblCaraCompleta3.Enabled = false;
            this.lblCaraCompleta3.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCaraCompleta3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblCaraCompleta3.Location = new System.Drawing.Point(0, 72);
            this.lblCaraCompleta3.Name = "lblCaraCompleta3";
            this.lblCaraCompleta3.Size = new System.Drawing.Size(145, 15);
            this.lblCaraCompleta3.TabIndex = 5;
            this.lblCaraCompleta3.Text = "Modelo";
            this.lblCaraCompleta3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCaraCompleta3.Visible = false;
            // 
            // txtCaraCompletaMarca
            // 
            this.txtCaraCompletaMarca.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCaraCompletaMarca.BackColor = System.Drawing.Color.White;
            this.txtCaraCompletaMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCaraCompletaMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCaraCompletaMarca.Enabled = false;
            this.txtCaraCompletaMarca.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCaraCompletaMarca.ForeColor = System.Drawing.Color.Black;
            this.txtCaraCompletaMarca.Location = new System.Drawing.Point(145, 42);
            this.txtCaraCompletaMarca.MaxLength = 12;
            this.txtCaraCompletaMarca.Name = "txtCaraCompletaMarca";
            this.txtCaraCompletaMarca.Size = new System.Drawing.Size(110, 22);
            this.txtCaraCompletaMarca.TabIndex = 4;
            this.txtCaraCompletaMarca.Visible = false;
            // 
            // lblCaraCompleta2
            // 
            this.lblCaraCompleta2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCaraCompleta2.BackColor = System.Drawing.Color.Transparent;
            this.lblCaraCompleta2.Enabled = false;
            this.lblCaraCompleta2.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCaraCompleta2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblCaraCompleta2.Location = new System.Drawing.Point(0, 45);
            this.lblCaraCompleta2.Name = "lblCaraCompleta2";
            this.lblCaraCompleta2.Size = new System.Drawing.Size(145, 15);
            this.lblCaraCompleta2.TabIndex = 3;
            this.lblCaraCompleta2.Text = "Marca";
            this.lblCaraCompleta2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCaraCompleta2.Visible = false;
            // 
            // pkrCaraCompletaEmision
            // 
            this.pkrCaraCompletaEmision.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrCaraCompletaEmision.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrCaraCompletaEmision.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrCaraCompletaEmision.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrCaraCompletaEmision.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrCaraCompletaEmision.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrCaraCompletaEmision.CustomFormat = "dd/MM/yyyy";
            this.pkrCaraCompletaEmision.Enabled = false;
            this.pkrCaraCompletaEmision.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrCaraCompletaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrCaraCompletaEmision.Location = new System.Drawing.Point(145, 15);
            this.pkrCaraCompletaEmision.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrCaraCompletaEmision.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrCaraCompletaEmision.Name = "pkrCaraCompletaEmision";
            this.pkrCaraCompletaEmision.Size = new System.Drawing.Size(102, 22);
            this.pkrCaraCompletaEmision.TabIndex = 2;
            this.pkrCaraCompletaEmision.Visible = false;
            // 
            // lblCaraCompleta1
            // 
            this.lblCaraCompleta1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCaraCompleta1.BackColor = System.Drawing.Color.Transparent;
            this.lblCaraCompleta1.Enabled = false;
            this.lblCaraCompleta1.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCaraCompleta1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblCaraCompleta1.Location = new System.Drawing.Point(0, 18);
            this.lblCaraCompleta1.Name = "lblCaraCompleta1";
            this.lblCaraCompleta1.Size = new System.Drawing.Size(145, 15);
            this.lblCaraCompleta1.TabIndex = 1;
            this.lblCaraCompleta1.Text = "Fecha de prueba";
            this.lblCaraCompleta1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCaraCompleta1.Visible = false;
            // 
            // chkCaraCompleta
            // 
            this.chkCaraCompleta.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCaraCompleta.AutoSize = true;
            this.chkCaraCompleta.BackColor = System.Drawing.Color.Transparent;
            this.chkCaraCompleta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkCaraCompleta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCaraCompleta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkCaraCompleta.Location = new System.Drawing.Point(11, 1);
            this.chkCaraCompleta.Name = "chkCaraCompleta";
            this.chkCaraCompleta.Size = new System.Drawing.Size(15, 14);
            this.chkCaraCompleta.TabIndex = 0;
            this.chkCaraCompleta.UseVisualStyleBackColor = false;
            this.chkCaraCompleta.CheckedChanged += new System.EventHandler(this.chkCaraCompleta_CheckedChanged);
            // 
            // groupMediaCara
            // 
            this.groupMediaCara.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupMediaCara.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupMediaCara.Controls.Add(this.cmbMediaCaraTamanio);
            this.groupMediaCara.Controls.Add(this.lblMediaCara4);
            this.groupMediaCara.Controls.Add(this.txtMediaCaraModelo);
            this.groupMediaCara.Controls.Add(this.lblMediaCara3);
            this.groupMediaCara.Controls.Add(this.txtMediaCaraMarca);
            this.groupMediaCara.Controls.Add(this.lblMediaCara2);
            this.groupMediaCara.Controls.Add(this.pkrMediaCaraEmision);
            this.groupMediaCara.Controls.Add(this.lblMediaCara1);
            this.groupMediaCara.Controls.Add(this.chkMediaCara);
            this.groupMediaCara.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupMediaCara.ForeColor = System.Drawing.Color.Gray;
            this.groupMediaCara.Location = new System.Drawing.Point(426, 246);
            this.groupMediaCara.Name = "groupMediaCara";
            this.groupMediaCara.Size = new System.Drawing.Size(261, 125);
            this.groupMediaCara.TabIndex = 25;
            this.groupMediaCara.TabStop = false;
            this.groupMediaCara.Text = "      Fit Test: Respirador de media cara";
            // 
            // cmbMediaCaraTamanio
            // 
            this.cmbMediaCaraTamanio.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbMediaCaraTamanio.BackColor = System.Drawing.Color.White;
            this.cmbMediaCaraTamanio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMediaCaraTamanio.Enabled = false;
            this.cmbMediaCaraTamanio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMediaCaraTamanio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbMediaCaraTamanio.ForeColor = System.Drawing.Color.Black;
            this.cmbMediaCaraTamanio.FormattingEnabled = true;
            this.cmbMediaCaraTamanio.ItemHeight = 14;
            this.cmbMediaCaraTamanio.Items.AddRange(new object[] {
            "L",
            "M",
            "S",
            "XL"});
            this.cmbMediaCaraTamanio.Location = new System.Drawing.Point(145, 96);
            this.cmbMediaCaraTamanio.Margin = new System.Windows.Forms.Padding(1);
            this.cmbMediaCaraTamanio.Name = "cmbMediaCaraTamanio";
            this.cmbMediaCaraTamanio.Size = new System.Drawing.Size(40, 22);
            this.cmbMediaCaraTamanio.Sorted = true;
            this.cmbMediaCaraTamanio.TabIndex = 81;
            this.cmbMediaCaraTamanio.Visible = false;
            // 
            // lblMediaCara4
            // 
            this.lblMediaCara4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblMediaCara4.BackColor = System.Drawing.Color.Transparent;
            this.lblMediaCara4.Enabled = false;
            this.lblMediaCara4.Font = new System.Drawing.Font("Arial", 9F);
            this.lblMediaCara4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblMediaCara4.Location = new System.Drawing.Point(0, 99);
            this.lblMediaCara4.Name = "lblMediaCara4";
            this.lblMediaCara4.Size = new System.Drawing.Size(145, 15);
            this.lblMediaCara4.TabIndex = 8;
            this.lblMediaCara4.Text = "Tamaño";
            this.lblMediaCara4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMediaCara4.Visible = false;
            // 
            // txtMediaCaraModelo
            // 
            this.txtMediaCaraModelo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtMediaCaraModelo.BackColor = System.Drawing.Color.White;
            this.txtMediaCaraModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMediaCaraModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMediaCaraModelo.Enabled = false;
            this.txtMediaCaraModelo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtMediaCaraModelo.ForeColor = System.Drawing.Color.Black;
            this.txtMediaCaraModelo.Location = new System.Drawing.Point(145, 69);
            this.txtMediaCaraModelo.MaxLength = 12;
            this.txtMediaCaraModelo.Name = "txtMediaCaraModelo";
            this.txtMediaCaraModelo.Size = new System.Drawing.Size(110, 22);
            this.txtMediaCaraModelo.TabIndex = 6;
            this.txtMediaCaraModelo.Visible = false;
            // 
            // lblMediaCara3
            // 
            this.lblMediaCara3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblMediaCara3.BackColor = System.Drawing.Color.Transparent;
            this.lblMediaCara3.Enabled = false;
            this.lblMediaCara3.Font = new System.Drawing.Font("Arial", 9F);
            this.lblMediaCara3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblMediaCara3.Location = new System.Drawing.Point(0, 72);
            this.lblMediaCara3.Name = "lblMediaCara3";
            this.lblMediaCara3.Size = new System.Drawing.Size(145, 15);
            this.lblMediaCara3.TabIndex = 5;
            this.lblMediaCara3.Text = "Modelo";
            this.lblMediaCara3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMediaCara3.Visible = false;
            // 
            // txtMediaCaraMarca
            // 
            this.txtMediaCaraMarca.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtMediaCaraMarca.BackColor = System.Drawing.Color.White;
            this.txtMediaCaraMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMediaCaraMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMediaCaraMarca.Enabled = false;
            this.txtMediaCaraMarca.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtMediaCaraMarca.ForeColor = System.Drawing.Color.Black;
            this.txtMediaCaraMarca.Location = new System.Drawing.Point(145, 42);
            this.txtMediaCaraMarca.MaxLength = 12;
            this.txtMediaCaraMarca.Name = "txtMediaCaraMarca";
            this.txtMediaCaraMarca.Size = new System.Drawing.Size(110, 22);
            this.txtMediaCaraMarca.TabIndex = 4;
            this.txtMediaCaraMarca.Visible = false;
            // 
            // lblMediaCara2
            // 
            this.lblMediaCara2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblMediaCara2.BackColor = System.Drawing.Color.Transparent;
            this.lblMediaCara2.Enabled = false;
            this.lblMediaCara2.Font = new System.Drawing.Font("Arial", 9F);
            this.lblMediaCara2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblMediaCara2.Location = new System.Drawing.Point(0, 45);
            this.lblMediaCara2.Name = "lblMediaCara2";
            this.lblMediaCara2.Size = new System.Drawing.Size(145, 15);
            this.lblMediaCara2.TabIndex = 3;
            this.lblMediaCara2.Text = "Marca";
            this.lblMediaCara2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMediaCara2.Visible = false;
            // 
            // pkrMediaCaraEmision
            // 
            this.pkrMediaCaraEmision.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pkrMediaCaraEmision.CalendarForeColor = System.Drawing.Color.Black;
            this.pkrMediaCaraEmision.CalendarMonthBackground = System.Drawing.Color.White;
            this.pkrMediaCaraEmision.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.pkrMediaCaraEmision.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.pkrMediaCaraEmision.Cursor = System.Windows.Forms.Cursors.Default;
            this.pkrMediaCaraEmision.CustomFormat = "dd/MM/yyyy";
            this.pkrMediaCaraEmision.Enabled = false;
            this.pkrMediaCaraEmision.Font = new System.Drawing.Font("Arial", 9.5F);
            this.pkrMediaCaraEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkrMediaCaraEmision.Location = new System.Drawing.Point(145, 15);
            this.pkrMediaCaraEmision.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.pkrMediaCaraEmision.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.pkrMediaCaraEmision.Name = "pkrMediaCaraEmision";
            this.pkrMediaCaraEmision.Size = new System.Drawing.Size(102, 22);
            this.pkrMediaCaraEmision.TabIndex = 2;
            this.pkrMediaCaraEmision.Visible = false;
            // 
            // lblMediaCara1
            // 
            this.lblMediaCara1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblMediaCara1.BackColor = System.Drawing.Color.Transparent;
            this.lblMediaCara1.Enabled = false;
            this.lblMediaCara1.Font = new System.Drawing.Font("Arial", 9F);
            this.lblMediaCara1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblMediaCara1.Location = new System.Drawing.Point(0, 18);
            this.lblMediaCara1.Name = "lblMediaCara1";
            this.lblMediaCara1.Size = new System.Drawing.Size(145, 15);
            this.lblMediaCara1.TabIndex = 1;
            this.lblMediaCara1.Text = "Fecha de prueba";
            this.lblMediaCara1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMediaCara1.Visible = false;
            // 
            // chkMediaCara
            // 
            this.chkMediaCara.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkMediaCara.AutoSize = true;
            this.chkMediaCara.BackColor = System.Drawing.Color.Transparent;
            this.chkMediaCara.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkMediaCara.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMediaCara.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkMediaCara.Location = new System.Drawing.Point(11, 1);
            this.chkMediaCara.Name = "chkMediaCara";
            this.chkMediaCara.Size = new System.Drawing.Size(15, 14);
            this.chkMediaCara.TabIndex = 0;
            this.chkMediaCara.UseVisualStyleBackColor = false;
            this.chkMediaCara.CheckedChanged += new System.EventHandler(this.chkMediaCara_CheckedChanged);
            // 
            // txtObservacion
            // 
            this.txtObservacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtObservacion.BackColor = System.Drawing.Color.White;
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtObservacion.ForeColor = System.Drawing.Color.Black;
            this.txtObservacion.Location = new System.Drawing.Point(160, 375);
            this.txtObservacion.MaxLength = 250;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(340, 52);
            this.txtObservacion.TabIndex = 27;
            // 
            // miLabel6
            // 
            this.miLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel6.BackColor = System.Drawing.Color.Transparent;
            this.miLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel6.Location = new System.Drawing.Point(0, 378);
            this.miLabel6.Name = "miLabel6";
            this.miLabel6.Size = new System.Drawing.Size(160, 15);
            this.miLabel6.TabIndex = 26;
            this.miLabel6.Text = "Observaciones";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbEvaluacionMedica
            // 
            this.cmbEvaluacionMedica.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbEvaluacionMedica.BackColor = System.Drawing.Color.White;
            this.cmbEvaluacionMedica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvaluacionMedica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEvaluacionMedica.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbEvaluacionMedica.ForeColor = System.Drawing.Color.Black;
            this.cmbEvaluacionMedica.FormattingEnabled = true;
            this.cmbEvaluacionMedica.ItemHeight = 14;
            this.cmbEvaluacionMedica.Items.AddRange(new object[] {
            "APTO",
            "NO APTO"});
            this.cmbEvaluacionMedica.Location = new System.Drawing.Point(160, 432);
            this.cmbEvaluacionMedica.Margin = new System.Windows.Forms.Padding(1);
            this.cmbEvaluacionMedica.Name = "cmbEvaluacionMedica";
            this.cmbEvaluacionMedica.Size = new System.Drawing.Size(75, 22);
            this.cmbEvaluacionMedica.Sorted = true;
            this.cmbEvaluacionMedica.TabIndex = 29;
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(0, 435);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(160, 15);
            this.miLabel7.TabIndex = 28;
            this.miLabel7.Text = "Evaluación médica";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstado.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtEstado.ForeColor = System.Drawing.Color.Black;
            this.txtEstado.Location = new System.Drawing.Point(160, 459);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(85, 22);
            this.txtEstado.TabIndex = 31;
            // 
            // miLabel8
            // 
            this.miLabel8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel8.BackColor = System.Drawing.Color.Transparent;
            this.miLabel8.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel8.Location = new System.Drawing.Point(0, 462);
            this.miLabel8.Name = "miLabel8";
            this.miLabel8.Size = new System.Drawing.Size(160, 15);
            this.miLabel8.TabIndex = 30;
            this.miLabel8.Text = "Estado";
            this.miLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCatalagoTitulo8
            // 
            this.lblCatalagoTitulo8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo8.AutoSize = true;
            this.lblCatalagoTitulo8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo8.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo8.Location = new System.Drawing.Point(826, 36);
            this.lblCatalagoTitulo8.Name = "lblCatalagoTitulo8";
            this.lblCatalagoTitulo8.Size = new System.Drawing.Size(40, 14);
            this.lblCatalagoTitulo8.TabIndex = 93;
            this.lblCatalagoTitulo8.Text = "Estado";
            this.lblCatalagoTitulo8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormExamenMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.miLabel8);
            this.Controls.Add(this.cmbEvaluacionMedica);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.groupMediaCara);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.pkrFechaExamen);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.cmbTipoExamen);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.txtInstitucion);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.btnBuscarLegajo);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtDenominacion);
            this.Controls.Add(this.groupEvaluacionRespirador);
            this.Controls.Add(this.groupCaraCompleta);
            this.Name = "FormExamenMedico";
            this.Text = "Exámenes Médicos";
            this.Load += new System.EventHandler(this.FormExamenMedico_Load);
            this.Controls.SetChildIndex(this.groupCaraCompleta, 0);
            this.Controls.SetChildIndex(this.groupEvaluacionRespirador, 0);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.btnBuscarLegajo, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.txtCuit, 0);
            this.Controls.SetChildIndex(this.txtInstitucion, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.cmbTipoExamen, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.pkrFechaExamen, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.groupMediaCara, 0);
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
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.txtObservacion, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.cmbEvaluacionMedica, 0);
            this.Controls.SetChildIndex(this.miLabel8, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            this.groupEvaluacionRespirador.ResumeLayout(false);
            this.groupEvaluacionRespirador.PerformLayout();
            this.groupCaraCompleta.ResumeLayout(false);
            this.groupCaraCompleta.PerformLayout();
            this.groupMediaCara.ResumeLayout(false);
            this.groupMediaCara.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Biblioteca.Controles.MiButtonFind btnBuscarLegajo;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBox txtDenominacion;
        private Biblioteca.Controles.MiTextBoxRead txtCuit;
        private Biblioteca.Controles.MiLabel miLabel2;
        public System.Windows.Forms.Label lblCatalagoTitulo7;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiTextBox txtInstitucion;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiComboBox cmbTipoExamen;
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiDateTimePicker pkrFechaExamen;
        private System.Windows.Forms.GroupBox groupEvaluacionRespirador;
        private Biblioteca.Controles.MiDateTimePicker pkrEvaluacionRespiradorVto;
        private Biblioteca.Controles.MiLabel lblEvaluacionRespirador2;
        private Biblioteca.Controles.MiDateTimePicker pkrEvaluacionRespiradorEmision;
        private Biblioteca.Controles.MiLabel lblEvaluacionRespirador1;
        private Biblioteca.Controles.MiCheckBox chkEvaluacionRespirador;
        private System.Windows.Forms.GroupBox groupCaraCompleta;
        private Biblioteca.Controles.MiDateTimePicker pkrCaraCompletaEmision;
        private Biblioteca.Controles.MiLabel lblCaraCompleta1;
        private Biblioteca.Controles.MiCheckBox chkCaraCompleta;
        private Biblioteca.Controles.MiComboBox cmbCaraCompletaTamanio;
        private Biblioteca.Controles.MiLabel lblCaraCompleta4;
        private Biblioteca.Controles.MiTextBox txtCaraCompletaModelo;
        private Biblioteca.Controles.MiLabel lblCaraCompleta3;
        private Biblioteca.Controles.MiTextBox txtCaraCompletaMarca;
        private Biblioteca.Controles.MiLabel lblCaraCompleta2;
        private System.Windows.Forms.GroupBox groupMediaCara;
        private Biblioteca.Controles.MiComboBox cmbMediaCaraTamanio;
        private Biblioteca.Controles.MiLabel lblMediaCara4;
        private Biblioteca.Controles.MiTextBox txtMediaCaraModelo;
        private Biblioteca.Controles.MiLabel lblMediaCara3;
        private Biblioteca.Controles.MiTextBox txtMediaCaraMarca;
        private Biblioteca.Controles.MiLabel lblMediaCara2;
        private Biblioteca.Controles.MiDateTimePicker pkrMediaCaraEmision;
        private Biblioteca.Controles.MiLabel lblMediaCara1;
        private Biblioteca.Controles.MiCheckBox chkMediaCara;
        private Biblioteca.Controles.MiTextBox txtObservacion;
        private Biblioteca.Controles.MiLabel miLabel6;
        private Biblioteca.Controles.MiComboBox cmbEvaluacionMedica;
        private Biblioteca.Controles.MiLabel miLabel7;
        private Biblioteca.Controles.MiTextBoxRead txtEstado;
        private Biblioteca.Controles.MiLabel miLabel8;
        public System.Windows.Forms.Label lblCatalagoTitulo8;
    }
}