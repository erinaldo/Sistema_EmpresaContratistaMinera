namespace CapaPresentacion
{
    partial class FormRentabilidadCentroCosto
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
                nRentabilidadCentroCosto.Dispose();
                nRentabilidadCentroCostoDetalleCosto.Dispose();
                nRentabilidadCentroCostoDetalleImporte.Dispose();
                nAsientoCentroCostoRentabilidadCosto.Dispose();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbPeriodo = new Biblioteca.Controles.MiComboBox();
            this.txtPeriodo = new Biblioteca.Controles.MiNumericUpDown();
            this.cmbCentroCosto = new Biblioteca.Controles.MiComboBox();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.gridDetalleImporte = new Biblioteca.Controles.MiGridEdit();
            this.ColCategoriaTrabajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColValorHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPptoHH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPptoImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRealHH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRealImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDifHH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDifImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColModificacionHH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImprimirReporteImporte = new Biblioteca.Controles.MiButton24x24();
            this.txtTotalPptoImporte = new Biblioteca.Controles.MiTextBox();
            this.txtTotalPptoHH = new Biblioteca.Controles.MiTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.txtTotalRealImporte = new Biblioteca.Controles.MiTextBox();
            this.txtTotalRealHH = new Biblioteca.Controles.MiTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtTotalDiferenciaImporte = new Biblioteca.Controles.MiTextBox();
            this.txtTotalDiferenciaHH = new Biblioteca.Controles.MiTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.lblTotalImporte = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.txtReajuste = new Biblioteca.Controles.MiTextBox();
            this.gridDetalleCosto = new Biblioteca.Controles.MiGridEdit();
            this.btnImprimirReporteCosto = new Biblioteca.Controles.MiButton24x24();
            this.txtUtilidadPpto = new Biblioteca.Controles.MiTextBox();
            this.txtTotalCostoPpto = new Biblioteca.Controles.MiTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.txtUtilidadReal = new Biblioteca.Controles.MiTextBox();
            this.txtTotalCostoReal = new Biblioteca.Controles.MiTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.txtUtilidadDif = new Biblioteca.Controles.MiTextBox();
            this.txtTotalCostoDif = new Biblioteca.Controles.MiTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.txtEstado = new Biblioteca.Controles.MiTextBoxRead();
            this.ColCuentaContable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPptoCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPptoIncidencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRealCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRealIncidencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDifCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDifIncidencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColModificacionCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCatalagoTitulo7 = new System.Windows.Forms.Label();
            this.lblCatalagoTitulo8 = new System.Windows.Forms.Label();
            this.lblCatalagoTitulo9 = new System.Windows.Forms.Label();
            this.panelLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalleImporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalleCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
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
            this.btnExcel_Registro.Enabled = false;
            this.btnExcel_Registro.FlatAppearance.BorderSize = 0;
            this.btnExcel_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Registro.Visible = false;
            // 
            // btnPDF_Registro
            // 
            this.btnPDF_Registro.Enabled = false;
            this.btnPDF_Registro.FlatAppearance.BorderSize = 0;
            this.btnPDF_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Registro.Visible = false;
            // 
            // lblTituloLista
            // 
            this.lblTituloLista.Text = "Lista de Rentabilidades (C.C.)";
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
            // lblCatalagoTitulo1
            // 
            this.lblCatalagoTitulo1.Size = new System.Drawing.Size(85, 14);
            this.lblCatalagoTitulo1.Text = "Centro de Costo";
            // 
            // lblCatalagoTitulo2
            // 
            this.lblCatalagoTitulo2.Location = new System.Drawing.Point(196, 36);
            this.lblCatalagoTitulo2.Size = new System.Drawing.Size(43, 14);
            this.lblCatalagoTitulo2.Text = "Periodo";
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(266, 36);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(40, 14);
            this.lblCatalagoTitulo3.Text = "Estado";
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(336, 36);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(69, 14);
            this.lblCatalagoTitulo4.Text = "Ppto. Importe";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(441, 36);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(66, 14);
            this.lblCatalagoTitulo5.Text = "Real Importe";
            // 
            // panelLista
            // 
            this.panelLista.Controls.Add(this.lblCatalagoTitulo9);
            this.panelLista.Controls.Add(this.lblCatalagoTitulo8);
            this.panelLista.Controls.Add(this.lblCatalagoTitulo7);
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
            this.panelLista.Controls.SetChildIndex(this.lblCatalagoTitulo9, 0);
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(546, 36);
            this.lblCatalagoTitulo6.Size = new System.Drawing.Size(49, 14);
            this.lblCatalagoTitulo6.Text = "Reajuste";
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Rentabilidad por Centros de Costo";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
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
            this.cmbPeriodo.Location = new System.Drawing.Point(352, 61);
            this.cmbPeriodo.Margin = new System.Windows.Forms.Padding(1);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(38, 22);
            this.cmbPeriodo.Sorted = true;
            this.cmbPeriodo.TabIndex = 13;
            this.cmbPeriodo.Validated += new System.EventHandler(this.cmbPeriodo_Validated);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPeriodo.BackColor = System.Drawing.Color.White;
            this.txtPeriodo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtPeriodo.ForeColor = System.Drawing.Color.Black;
            this.txtPeriodo.Location = new System.Drawing.Point(389, 61);
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
            this.txtPeriodo.TabIndex = 14;
            this.txtPeriodo.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.txtPeriodo.ValueChanged += new System.EventHandler(this.txtPeriodo_ValueChanged);
            // 
            // cmbCentroCosto
            // 
            this.cmbCentroCosto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbCentroCosto.BackColor = System.Drawing.Color.White;
            this.cmbCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCentroCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCentroCosto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCentroCosto.ForeColor = System.Drawing.Color.Black;
            this.cmbCentroCosto.FormattingEnabled = true;
            this.cmbCentroCosto.Location = new System.Drawing.Point(160, 61);
            this.cmbCentroCosto.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCentroCosto.Name = "cmbCentroCosto";
            this.cmbCentroCosto.Size = new System.Drawing.Size(190, 22);
            this.cmbCentroCosto.Sorted = true;
            this.cmbCentroCosto.TabIndex = 12;
            this.cmbCentroCosto.Validated += new System.EventHandler(this.cmbCentroCosto_Validated);
            // 
            // miLabel2
            // 
            this.miLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel2.BackColor = System.Drawing.Color.Transparent;
            this.miLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel2.Location = new System.Drawing.Point(0, 64);
            this.miLabel2.Name = "miLabel2";
            this.miLabel2.Size = new System.Drawing.Size(160, 15);
            this.miLabel2.TabIndex = 11;
            this.miLabel2.Text = "Centro de costo - Periodo";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gridDetalleImporte
            // 
            this.gridDetalleImporte.AllowUserToAddRows = false;
            this.gridDetalleImporte.AllowUserToDeleteRows = false;
            this.gridDetalleImporte.AllowUserToResizeColumns = false;
            this.gridDetalleImporte.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.gridDetalleImporte.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDetalleImporte.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gridDetalleImporte.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridDetalleImporte.BackgroundColor = System.Drawing.Color.Gray;
            this.gridDetalleImporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridDetalleImporte.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDetalleImporte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridDetalleImporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetalleImporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCategoriaTrabajo,
            this.ColValorHora,
            this.ColPptoHH,
            this.ColPptoImporte,
            this.ColRealHH,
            this.ColRealImporte,
            this.ColDifHH,
            this.ColDifImporte,
            this.ColModificacionHH,
            this.ColNula});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDetalleImporte.DefaultCellStyle = dataGridViewCellStyle11;
            this.gridDetalleImporte.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridDetalleImporte.EnableHeadersVisualStyles = false;
            this.gridDetalleImporte.GridColor = System.Drawing.Color.DarkGray;
            this.gridDetalleImporte.Location = new System.Drawing.Point(160, 88);
            this.gridDetalleImporte.MultiSelect = false;
            this.gridDetalleImporte.Name = "gridDetalleImporte";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetalleImporte.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gridDetalleImporte.RowHeadersVisible = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.gridDetalleImporte.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.gridDetalleImporte.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetalleImporte.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetalleImporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridDetalleImporte.Size = new System.Drawing.Size(745, 133);
            this.gridDetalleImporte.StandardTab = true;
            this.gridDetalleImporte.TabIndex = 16;
            this.gridDetalleImporte.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetalleImporte_CellEndEdit);
            this.gridDetalleImporte.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetalleImporte_CellEnter);
            this.gridDetalleImporte.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridDetalleImporte_DataError);
            this.gridDetalleImporte.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridDetalleImporte_EditingControlShowing);
            this.gridDetalleImporte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridDetalleImporte_KeyDown);
            this.gridDetalleImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridDetalleImporte_KeyPress);
            this.gridDetalleImporte.Leave += new System.EventHandler(this.gridDetalleImporte_Leave);
            // 
            // ColCategoriaTrabajo
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.ColCategoriaTrabajo.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColCategoriaTrabajo.HeaderText = "Categoría de Trabajo";
            this.ColCategoriaTrabajo.Name = "ColCategoriaTrabajo";
            this.ColCategoriaTrabajo.ReadOnly = true;
            this.ColCategoriaTrabajo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColCategoriaTrabajo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCategoriaTrabajo.Width = 215;
            // 
            // ColValorHora
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.ColValorHora.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColValorHora.HeaderText = "Valor Hora $";
            this.ColValorHora.MaxInputLength = 11;
            this.ColValorHora.Name = "ColValorHora";
            this.ColValorHora.Width = 80;
            // 
            // ColPptoHH
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.ColPptoHH.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColPptoHH.HeaderText = "Ppto. HH";
            this.ColPptoHH.MaxInputLength = 6;
            this.ColPptoHH.Name = "ColPptoHH";
            this.ColPptoHH.Width = 54;
            // 
            // ColPptoImporte
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.ColPptoImporte.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColPptoImporte.HeaderText = "Ppto. Importe $";
            this.ColPptoImporte.MaxInputLength = 12;
            this.ColPptoImporte.Name = "ColPptoImporte";
            this.ColPptoImporte.ReadOnly = true;
            this.ColPptoImporte.Width = 90;
            // 
            // ColRealHH
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.ColRealHH.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColRealHH.HeaderText = "Real HH";
            this.ColRealHH.MaxInputLength = 6;
            this.ColRealHH.Name = "ColRealHH";
            this.ColRealHH.Width = 54;
            // 
            // ColRealImporte
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.ColRealImporte.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColRealImporte.HeaderText = "Real Importe $";
            this.ColRealImporte.MaxInputLength = 12;
            this.ColRealImporte.Name = "ColRealImporte";
            this.ColRealImporte.ReadOnly = true;
            this.ColRealImporte.Width = 90;
            // 
            // ColDifHH
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            this.ColDifHH.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColDifHH.HeaderText = "Dif. HH";
            this.ColDifHH.MaxInputLength = 6;
            this.ColDifHH.Name = "ColDifHH";
            this.ColDifHH.ReadOnly = true;
            this.ColDifHH.Width = 54;
            // 
            // ColDifImporte
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.ColDifImporte.DefaultCellStyle = dataGridViewCellStyle10;
            this.ColDifImporte.HeaderText = "Dif. Importe $";
            this.ColDifImporte.MaxInputLength = 12;
            this.ColDifImporte.Name = "ColDifImporte";
            this.ColDifImporte.ReadOnly = true;
            this.ColDifImporte.Width = 90;
            // 
            // ColModificacionHH
            // 
            this.ColModificacionHH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColModificacionHH.HeaderText = "ModificacionHH";
            this.ColModificacionHH.Name = "ColModificacionHH";
            this.ColModificacionHH.ReadOnly = true;
            this.ColModificacionHH.Visible = false;
            // 
            // ColNula
            // 
            this.ColNula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNula.HeaderText = "";
            this.ColNula.Name = "ColNula";
            this.ColNula.ReadOnly = true;
            // 
            // btnImprimirReporteImporte
            // 
            this.btnImprimirReporteImporte.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImprimirReporteImporte.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnImprimirReporteImporte.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_excel32;
            this.btnImprimirReporteImporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimirReporteImporte.FlatAppearance.BorderSize = 0;
            this.btnImprimirReporteImporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnImprimirReporteImporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnImprimirReporteImporte.Font = new System.Drawing.Font("Arial", 8F);
            this.btnImprimirReporteImporte.ForeColor = System.Drawing.Color.Black;
            this.btnImprimirReporteImporte.Location = new System.Drawing.Point(160, 222);
            this.btnImprimirReporteImporte.Name = "btnImprimirReporteImporte";
            this.btnImprimirReporteImporte.Size = new System.Drawing.Size(24, 24);
            this.btnImprimirReporteImporte.TabIndex = 17;
            this.btnImprimirReporteImporte.UseVisualStyleBackColor = false;
            this.btnImprimirReporteImporte.Click += new System.EventHandler(this.btnImprimirReporteImporte_Click);
            // 
            // txtTotalPptoImporte
            // 
            this.txtTotalPptoImporte.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalPptoImporte.BackColor = System.Drawing.Color.White;
            this.txtTotalPptoImporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalPptoImporte.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtTotalPptoImporte.ForeColor = System.Drawing.Color.Black;
            this.txtTotalPptoImporte.Location = new System.Drawing.Point(380, 249);
            this.txtTotalPptoImporte.MaxLength = 9;
            this.txtTotalPptoImporte.Name = "txtTotalPptoImporte";
            this.txtTotalPptoImporte.ReadOnly = true;
            this.txtTotalPptoImporte.Size = new System.Drawing.Size(70, 14);
            this.txtTotalPptoImporte.TabIndex = 21;
            this.txtTotalPptoImporte.Text = "0.00";
            this.txtTotalPptoImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalPptoHH
            // 
            this.txtTotalPptoHH.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalPptoHH.BackColor = System.Drawing.Color.White;
            this.txtTotalPptoHH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalPptoHH.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtTotalPptoHH.ForeColor = System.Drawing.Color.Black;
            this.txtTotalPptoHH.Location = new System.Drawing.Point(391, 227);
            this.txtTotalPptoHH.MaxLength = 9;
            this.txtTotalPptoHH.Name = "txtTotalPptoHH";
            this.txtTotalPptoHH.ReadOnly = true;
            this.txtTotalPptoHH.Size = new System.Drawing.Size(59, 14);
            this.txtTotalPptoHH.TabIndex = 19;
            this.txtTotalPptoHH.Text = "0";
            this.txtTotalPptoHH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label2.Location = new System.Drawing.Point(332, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "T. Ppto. $";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label1.Location = new System.Drawing.Point(332, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "T. Ppto. HH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox7.BackColor = System.Drawing.Color.White;
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox7.Location = new System.Drawing.Point(330, 245);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(125, 23);
            this.pictureBox7.TabIndex = 323;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox6.BackColor = System.Drawing.Color.White;
            this.pictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox6.Location = new System.Drawing.Point(330, 223);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(125, 23);
            this.pictureBox6.TabIndex = 322;
            this.pictureBox6.TabStop = false;
            // 
            // txtTotalRealImporte
            // 
            this.txtTotalRealImporte.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalRealImporte.BackColor = System.Drawing.Color.White;
            this.txtTotalRealImporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalRealImporte.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtTotalRealImporte.ForeColor = System.Drawing.Color.Black;
            this.txtTotalRealImporte.Location = new System.Drawing.Point(504, 249);
            this.txtTotalRealImporte.MaxLength = 9;
            this.txtTotalRealImporte.Name = "txtTotalRealImporte";
            this.txtTotalRealImporte.ReadOnly = true;
            this.txtTotalRealImporte.Size = new System.Drawing.Size(70, 14);
            this.txtTotalRealImporte.TabIndex = 25;
            this.txtTotalRealImporte.Text = "0.00";
            this.txtTotalRealImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalRealHH
            // 
            this.txtTotalRealHH.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalRealHH.BackColor = System.Drawing.Color.White;
            this.txtTotalRealHH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalRealHH.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtTotalRealHH.ForeColor = System.Drawing.Color.Black;
            this.txtTotalRealHH.Location = new System.Drawing.Point(515, 227);
            this.txtTotalRealHH.MaxLength = 9;
            this.txtTotalRealHH.Name = "txtTotalRealHH";
            this.txtTotalRealHH.ReadOnly = true;
            this.txtTotalRealHH.Size = new System.Drawing.Size(59, 14);
            this.txtTotalRealHH.TabIndex = 23;
            this.txtTotalRealHH.Text = "0";
            this.txtTotalRealHH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label4.Location = new System.Drawing.Point(456, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "T. Real $";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label3.Location = new System.Drawing.Point(456, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "T. Real HH";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(454, 223);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 23);
            this.pictureBox1.TabIndex = 328;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(454, 245);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(125, 23);
            this.pictureBox2.TabIndex = 329;
            this.pictureBox2.TabStop = false;
            // 
            // txtTotalDiferenciaImporte
            // 
            this.txtTotalDiferenciaImporte.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalDiferenciaImporte.BackColor = System.Drawing.Color.White;
            this.txtTotalDiferenciaImporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalDiferenciaImporte.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtTotalDiferenciaImporte.ForeColor = System.Drawing.Color.Black;
            this.txtTotalDiferenciaImporte.Location = new System.Drawing.Point(628, 249);
            this.txtTotalDiferenciaImporte.MaxLength = 9;
            this.txtTotalDiferenciaImporte.Name = "txtTotalDiferenciaImporte";
            this.txtTotalDiferenciaImporte.ReadOnly = true;
            this.txtTotalDiferenciaImporte.Size = new System.Drawing.Size(70, 14);
            this.txtTotalDiferenciaImporte.TabIndex = 29;
            this.txtTotalDiferenciaImporte.Text = "0.00";
            this.txtTotalDiferenciaImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalDiferenciaHH
            // 
            this.txtTotalDiferenciaHH.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalDiferenciaHH.BackColor = System.Drawing.Color.White;
            this.txtTotalDiferenciaHH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalDiferenciaHH.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtTotalDiferenciaHH.ForeColor = System.Drawing.Color.Black;
            this.txtTotalDiferenciaHH.Location = new System.Drawing.Point(639, 227);
            this.txtTotalDiferenciaHH.MaxLength = 9;
            this.txtTotalDiferenciaHH.Name = "txtTotalDiferenciaHH";
            this.txtTotalDiferenciaHH.ReadOnly = true;
            this.txtTotalDiferenciaHH.Size = new System.Drawing.Size(59, 14);
            this.txtTotalDiferenciaHH.TabIndex = 27;
            this.txtTotalDiferenciaHH.Text = "0";
            this.txtTotalDiferenciaHH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label6.Location = new System.Drawing.Point(580, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 28;
            this.label6.Text = "T. Dif. $";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label5.Location = new System.Drawing.Point(580, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "T. Dif. HH";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(578, 223);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(125, 23);
            this.pictureBox3.TabIndex = 334;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(578, 245);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(125, 23);
            this.pictureBox4.TabIndex = 335;
            this.pictureBox4.TabStop = false;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Arial", 7F);
            this.label7.Location = new System.Drawing.Point(708, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Reajuste";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Location = new System.Drawing.Point(705, 238);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(93, 30);
            this.pictureBox5.TabIndex = 339;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox8.BackColor = System.Drawing.Color.White;
            this.pictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox8.Location = new System.Drawing.Point(705, 223);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(93, 16);
            this.pictureBox8.TabIndex = 338;
            this.pictureBox8.TabStop = false;
            // 
            // lblTotalImporte
            // 
            this.lblTotalImporte.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalImporte.BackColor = System.Drawing.Color.White;
            this.lblTotalImporte.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalImporte.ForeColor = System.Drawing.Color.Black;
            this.lblTotalImporte.Location = new System.Drawing.Point(803, 244);
            this.lblTotalImporte.Name = "lblTotalImporte";
            this.lblTotalImporte.Size = new System.Drawing.Size(99, 18);
            this.lblTotalImporte.TabIndex = 33;
            this.lblTotalImporte.Tag = "";
            this.lblTotalImporte.Text = "0.00";
            this.lblTotalImporte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(803, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "TOTAL IMPORTE";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox14
            // 
            this.pictureBox14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox14.BackColor = System.Drawing.Color.White;
            this.pictureBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox14.Location = new System.Drawing.Point(800, 223);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(105, 16);
            this.pictureBox14.TabIndex = 342;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox15.BackColor = System.Drawing.Color.White;
            this.pictureBox15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox15.Location = new System.Drawing.Point(800, 238);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(105, 30);
            this.pictureBox15.TabIndex = 343;
            this.pictureBox15.TabStop = false;
            // 
            // txtReajuste
            // 
            this.txtReajuste.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtReajuste.BackColor = System.Drawing.Color.White;
            this.txtReajuste.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReajuste.Font = new System.Drawing.Font("Arial", 11.5F, System.Drawing.FontStyle.Bold);
            this.txtReajuste.ForeColor = System.Drawing.Color.Black;
            this.txtReajuste.Location = new System.Drawing.Point(708, 244);
            this.txtReajuste.MaxLength = 9;
            this.txtReajuste.Name = "txtReajuste";
            this.txtReajuste.Size = new System.Drawing.Size(89, 18);
            this.txtReajuste.TabIndex = 31;
            this.txtReajuste.Text = "0.00";
            this.txtReajuste.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReajuste.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReajuste_KeyPress);
            this.txtReajuste.Validated += new System.EventHandler(this.txtReajuste_Validated);
            // 
            // gridDetalleCosto
            // 
            this.gridDetalleCosto.AllowUserToAddRows = false;
            this.gridDetalleCosto.AllowUserToDeleteRows = false;
            this.gridDetalleCosto.AllowUserToResizeColumns = false;
            this.gridDetalleCosto.AllowUserToResizeRows = false;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            this.gridDetalleCosto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle14;
            this.gridDetalleCosto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gridDetalleCosto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridDetalleCosto.BackgroundColor = System.Drawing.Color.Gray;
            this.gridDetalleCosto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridDetalleCosto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDetalleCosto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.gridDetalleCosto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetalleCosto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCuentaContable,
            this.ColPptoCosto,
            this.ColPptoIncidencia,
            this.ColRealCosto,
            this.ColRealIncidencia,
            this.ColDifCosto,
            this.ColDifIncidencia,
            this.ColModificacionCosto,
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDetalleCosto.DefaultCellStyle = dataGridViewCellStyle20;
            this.gridDetalleCosto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridDetalleCosto.EnableHeadersVisualStyles = false;
            this.gridDetalleCosto.GridColor = System.Drawing.Color.DarkGray;
            this.gridDetalleCosto.Location = new System.Drawing.Point(160, 276);
            this.gridDetalleCosto.MultiSelect = false;
            this.gridDetalleCosto.Name = "gridDetalleCosto";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetalleCosto.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.gridDetalleCosto.RowHeadersVisible = false;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            this.gridDetalleCosto.RowsDefaultCellStyle = dataGridViewCellStyle22;
            this.gridDetalleCosto.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetalleCosto.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetalleCosto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridDetalleCosto.Size = new System.Drawing.Size(745, 171);
            this.gridDetalleCosto.StandardTab = true;
            this.gridDetalleCosto.TabIndex = 34;
            this.gridDetalleCosto.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetalleCosto_CellEndEdit);
            this.gridDetalleCosto.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetalleCosto_CellEnter);
            this.gridDetalleCosto.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridDetalleCosto_DataError);
            this.gridDetalleCosto.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridDetalleCosto_EditingControlShowing);
            this.gridDetalleCosto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridDetalleCosto_KeyDown);
            this.gridDetalleCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridDetalleCosto_KeyPress);
            this.gridDetalleCosto.Leave += new System.EventHandler(this.gridDetalleCosto_Leave);
            // 
            // btnImprimirReporteCosto
            // 
            this.btnImprimirReporteCosto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImprimirReporteCosto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnImprimirReporteCosto.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_excel32;
            this.btnImprimirReporteCosto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimirReporteCosto.FlatAppearance.BorderSize = 0;
            this.btnImprimirReporteCosto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnImprimirReporteCosto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnImprimirReporteCosto.Font = new System.Drawing.Font("Arial", 8F);
            this.btnImprimirReporteCosto.ForeColor = System.Drawing.Color.Black;
            this.btnImprimirReporteCosto.Location = new System.Drawing.Point(160, 448);
            this.btnImprimirReporteCosto.Name = "btnImprimirReporteCosto";
            this.btnImprimirReporteCosto.Size = new System.Drawing.Size(24, 24);
            this.btnImprimirReporteCosto.TabIndex = 35;
            this.btnImprimirReporteCosto.UseVisualStyleBackColor = false;
            this.btnImprimirReporteCosto.Click += new System.EventHandler(this.btnImprimirReporteCosto_Click);
            // 
            // txtUtilidadPpto
            // 
            this.txtUtilidadPpto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtUtilidadPpto.BackColor = System.Drawing.Color.White;
            this.txtUtilidadPpto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUtilidadPpto.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtUtilidadPpto.ForeColor = System.Drawing.Color.Black;
            this.txtUtilidadPpto.Location = new System.Drawing.Point(528, 475);
            this.txtUtilidadPpto.MaxLength = 9;
            this.txtUtilidadPpto.Name = "txtUtilidadPpto";
            this.txtUtilidadPpto.ReadOnly = true;
            this.txtUtilidadPpto.Size = new System.Drawing.Size(75, 14);
            this.txtUtilidadPpto.TabIndex = 39;
            this.txtUtilidadPpto.Text = "0.00";
            this.txtUtilidadPpto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalCostoPpto
            // 
            this.txtTotalCostoPpto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalCostoPpto.BackColor = System.Drawing.Color.White;
            this.txtTotalCostoPpto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalCostoPpto.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtTotalCostoPpto.ForeColor = System.Drawing.Color.Black;
            this.txtTotalCostoPpto.Location = new System.Drawing.Point(539, 453);
            this.txtTotalCostoPpto.MaxLength = 9;
            this.txtTotalCostoPpto.Name = "txtTotalCostoPpto";
            this.txtTotalCostoPpto.ReadOnly = true;
            this.txtTotalCostoPpto.Size = new System.Drawing.Size(64, 14);
            this.txtTotalCostoPpto.TabIndex = 37;
            this.txtTotalCostoPpto.Text = "0.00";
            this.txtTotalCostoPpto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label9.Location = new System.Drawing.Point(459, 475);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 15);
            this.label9.TabIndex = 38;
            this.label9.Text = "Utilidad  Ppto.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label10.Location = new System.Drawing.Point(459, 453);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 15);
            this.label10.TabIndex = 36;
            this.label10.Text = "T. Costo Ppto.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox9.BackColor = System.Drawing.Color.White;
            this.pictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox9.Location = new System.Drawing.Point(457, 449);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(150, 23);
            this.pictureBox9.TabIndex = 408;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox10.BackColor = System.Drawing.Color.White;
            this.pictureBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox10.Location = new System.Drawing.Point(457, 471);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(150, 23);
            this.pictureBox10.TabIndex = 409;
            this.pictureBox10.TabStop = false;
            // 
            // txtUtilidadReal
            // 
            this.txtUtilidadReal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtUtilidadReal.BackColor = System.Drawing.Color.White;
            this.txtUtilidadReal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUtilidadReal.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtUtilidadReal.ForeColor = System.Drawing.Color.Black;
            this.txtUtilidadReal.Location = new System.Drawing.Point(677, 475);
            this.txtUtilidadReal.MaxLength = 9;
            this.txtUtilidadReal.Name = "txtUtilidadReal";
            this.txtUtilidadReal.ReadOnly = true;
            this.txtUtilidadReal.Size = new System.Drawing.Size(75, 14);
            this.txtUtilidadReal.TabIndex = 43;
            this.txtUtilidadReal.Text = "0.00";
            this.txtUtilidadReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalCostoReal
            // 
            this.txtTotalCostoReal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalCostoReal.BackColor = System.Drawing.Color.White;
            this.txtTotalCostoReal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalCostoReal.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtTotalCostoReal.ForeColor = System.Drawing.Color.Black;
            this.txtTotalCostoReal.Location = new System.Drawing.Point(688, 453);
            this.txtTotalCostoReal.MaxLength = 9;
            this.txtTotalCostoReal.Name = "txtTotalCostoReal";
            this.txtTotalCostoReal.ReadOnly = true;
            this.txtTotalCostoReal.Size = new System.Drawing.Size(64, 14);
            this.txtTotalCostoReal.TabIndex = 41;
            this.txtTotalCostoReal.Text = "0.00";
            this.txtTotalCostoReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label12.Location = new System.Drawing.Point(608, 475);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 15);
            this.label12.TabIndex = 42;
            this.label12.Text = "Utilidad  Real";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label11.Location = new System.Drawing.Point(608, 453);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 15);
            this.label11.TabIndex = 40;
            this.label11.Text = "T. Costo Real ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox11.BackColor = System.Drawing.Color.White;
            this.pictureBox11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox11.Location = new System.Drawing.Point(606, 449);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(150, 23);
            this.pictureBox11.TabIndex = 414;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox12.BackColor = System.Drawing.Color.White;
            this.pictureBox12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox12.Location = new System.Drawing.Point(606, 471);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(150, 23);
            this.pictureBox12.TabIndex = 415;
            this.pictureBox12.TabStop = false;
            // 
            // txtUtilidadDif
            // 
            this.txtUtilidadDif.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtUtilidadDif.BackColor = System.Drawing.Color.White;
            this.txtUtilidadDif.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUtilidadDif.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtUtilidadDif.ForeColor = System.Drawing.Color.Black;
            this.txtUtilidadDif.Location = new System.Drawing.Point(826, 475);
            this.txtUtilidadDif.MaxLength = 9;
            this.txtUtilidadDif.Name = "txtUtilidadDif";
            this.txtUtilidadDif.ReadOnly = true;
            this.txtUtilidadDif.Size = new System.Drawing.Size(75, 14);
            this.txtUtilidadDif.TabIndex = 47;
            this.txtUtilidadDif.Text = "0.00";
            this.txtUtilidadDif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalCostoDif
            // 
            this.txtTotalCostoDif.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalCostoDif.BackColor = System.Drawing.Color.White;
            this.txtTotalCostoDif.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalCostoDif.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtTotalCostoDif.ForeColor = System.Drawing.Color.Black;
            this.txtTotalCostoDif.Location = new System.Drawing.Point(837, 453);
            this.txtTotalCostoDif.MaxLength = 9;
            this.txtTotalCostoDif.Name = "txtTotalCostoDif";
            this.txtTotalCostoDif.ReadOnly = true;
            this.txtTotalCostoDif.Size = new System.Drawing.Size(64, 14);
            this.txtTotalCostoDif.TabIndex = 45;
            this.txtTotalCostoDif.Text = "0.00";
            this.txtTotalCostoDif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label14.Location = new System.Drawing.Point(757, 475);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 15);
            this.label14.TabIndex = 46;
            this.label14.Text = "Utilidad  Dif.";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label13.Location = new System.Drawing.Point(757, 453);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 15);
            this.label13.TabIndex = 44;
            this.label13.Text = "T. Costo Dif.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox13
            // 
            this.pictureBox13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox13.BackColor = System.Drawing.Color.White;
            this.pictureBox13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox13.Location = new System.Drawing.Point(755, 449);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(150, 23);
            this.pictureBox13.TabIndex = 420;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox16
            // 
            this.pictureBox16.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox16.BackColor = System.Drawing.Color.White;
            this.pictureBox16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox16.Location = new System.Drawing.Point(755, 471);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(150, 23);
            this.pictureBox16.TabIndex = 421;
            this.pictureBox16.TabStop = false;
            // 
            // txtEstado
            // 
            this.txtEstado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstado.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtEstado.ForeColor = System.Drawing.Color.Black;
            this.txtEstado.Location = new System.Drawing.Point(438, 61);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(86, 22);
            this.txtEstado.TabIndex = 15;
            // 
            // ColCuentaContable
            // 
            this.ColCuentaContable.HeaderText = "Cuenta Contable";
            this.ColCuentaContable.MaxInputLength = 25;
            this.ColCuentaContable.Name = "ColCuentaContable";
            this.ColCuentaContable.ReadOnly = true;
            this.ColCuentaContable.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColCuentaContable.Width = 294;
            // 
            // ColPptoCosto
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N2";
            dataGridViewCellStyle16.NullValue = null;
            this.ColPptoCosto.DefaultCellStyle = dataGridViewCellStyle16;
            this.ColPptoCosto.HeaderText = "Ppto. Costo $";
            this.ColPptoCosto.MaxInputLength = 12;
            this.ColPptoCosto.Name = "ColPptoCosto";
            this.ColPptoCosto.Width = 90;
            // 
            // ColPptoIncidencia
            // 
            this.ColPptoIncidencia.HeaderText = "Ppto. %";
            this.ColPptoIncidencia.MaxInputLength = 6;
            this.ColPptoIncidencia.Name = "ColPptoIncidencia";
            this.ColPptoIncidencia.ReadOnly = true;
            this.ColPptoIncidencia.Width = 54;
            // 
            // ColRealCosto
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N2";
            dataGridViewCellStyle17.NullValue = null;
            this.ColRealCosto.DefaultCellStyle = dataGridViewCellStyle17;
            this.ColRealCosto.HeaderText = "Real Costo $";
            this.ColRealCosto.MaxInputLength = 12;
            this.ColRealCosto.Name = "ColRealCosto";
            this.ColRealCosto.ReadOnly = true;
            this.ColRealCosto.Width = 90;
            // 
            // ColRealIncidencia
            // 
            this.ColRealIncidencia.HeaderText = "Real %";
            this.ColRealIncidencia.MaxInputLength = 6;
            this.ColRealIncidencia.Name = "ColRealIncidencia";
            this.ColRealIncidencia.ReadOnly = true;
            this.ColRealIncidencia.Width = 54;
            // 
            // ColDifCosto
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N2";
            this.ColDifCosto.DefaultCellStyle = dataGridViewCellStyle18;
            this.ColDifCosto.HeaderText = "Dif. Costo $";
            this.ColDifCosto.MaxInputLength = 12;
            this.ColDifCosto.Name = "ColDifCosto";
            this.ColDifCosto.ReadOnly = true;
            this.ColDifCosto.Width = 90;
            // 
            // ColDifIncidencia
            // 
            this.ColDifIncidencia.HeaderText = "Dif. %";
            this.ColDifIncidencia.MaxInputLength = 6;
            this.ColDifIncidencia.Name = "ColDifIncidencia";
            this.ColDifIncidencia.ReadOnly = true;
            this.ColDifIncidencia.Width = 54;
            // 
            // ColModificacionCosto
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N2";
            this.ColModificacionCosto.DefaultCellStyle = dataGridViewCellStyle19;
            this.ColModificacionCosto.HeaderText = "ModificacionCosto";
            this.ColModificacionCosto.MaxInputLength = 10;
            this.ColModificacionCosto.Name = "ColModificacionCosto";
            this.ColModificacionCosto.ReadOnly = true;
            this.ColModificacionCosto.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // lblCatalagoTitulo7
            // 
            this.lblCatalagoTitulo7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo7.AutoSize = true;
            this.lblCatalagoTitulo7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo7.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo7.Location = new System.Drawing.Point(651, 36);
            this.lblCatalagoTitulo7.Name = "lblCatalagoTitulo7";
            this.lblCatalagoTitulo7.Size = new System.Drawing.Size(67, 14);
            this.lblCatalagoTitulo7.TabIndex = 28;
            this.lblCatalagoTitulo7.Text = "Total Importe";
            this.lblCatalagoTitulo7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCatalagoTitulo8
            // 
            this.lblCatalagoTitulo8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo8.AutoSize = true;
            this.lblCatalagoTitulo8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo8.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo8.Location = new System.Drawing.Point(756, 36);
            this.lblCatalagoTitulo8.Name = "lblCatalagoTitulo8";
            this.lblCatalagoTitulo8.Size = new System.Drawing.Size(73, 14);
            this.lblCatalagoTitulo8.TabIndex = 29;
            this.lblCatalagoTitulo8.Text = "T. Ppto. Costo";
            this.lblCatalagoTitulo8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCatalagoTitulo9
            // 
            this.lblCatalagoTitulo9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo9.AutoSize = true;
            this.lblCatalagoTitulo9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo9.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo9.Location = new System.Drawing.Point(861, 36);
            this.lblCatalagoTitulo9.Name = "lblCatalagoTitulo9";
            this.lblCatalagoTitulo9.Size = new System.Drawing.Size(35, 14);
            this.lblCatalagoTitulo9.TabIndex = 30;
            this.lblCatalagoTitulo9.Text = "T.R.C.";
            this.lblCatalagoTitulo9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormRentabilidadCentroCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtUtilidadDif);
            this.Controls.Add(this.txtTotalCostoDif);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.pictureBox16);
            this.Controls.Add(this.txtUtilidadReal);
            this.Controls.Add(this.txtTotalCostoReal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.txtUtilidadPpto);
            this.Controls.Add(this.txtTotalCostoPpto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.btnImprimirReporteCosto);
            this.Controls.Add(this.gridDetalleCosto);
            this.Controls.Add(this.txtReajuste);
            this.Controls.Add(this.lblTotalImporte);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox14);
            this.Controls.Add(this.pictureBox15);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.txtTotalDiferenciaImporte);
            this.Controls.Add(this.txtTotalDiferenciaHH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.txtTotalRealImporte);
            this.Controls.Add(this.txtTotalRealHH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtTotalPptoImporte);
            this.Controls.Add(this.txtTotalPptoHH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImprimirReporteImporte);
            this.Controls.Add(this.gridDetalleImporte);
            this.Controls.Add(this.cmbCentroCosto);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.cmbPeriodo);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox7);
            this.Name = "FormRentabilidadCentroCosto";
            this.Text = "Rentabilidad por Centros de Costo";
            this.Load += new System.EventHandler(this.FormRentabilidadCentroCosto_Load);
            this.Controls.SetChildIndex(this.labelPublicacion, 0);
            this.Controls.SetChildIndex(this.pictureBox7, 0);
            this.Controls.SetChildIndex(this.pictureBox6, 0);
            this.Controls.SetChildIndex(this.txtPeriodo, 0);
            this.Controls.SetChildIndex(this.cmbPeriodo, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.cmbCentroCosto, 0);
            this.Controls.SetChildIndex(this.gridDetalleImporte, 0);
            this.Controls.SetChildIndex(this.btnImprimirReporteImporte, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtTotalPptoHH, 0);
            this.Controls.SetChildIndex(this.txtTotalPptoImporte, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtTotalRealHH, 0);
            this.Controls.SetChildIndex(this.txtTotalRealImporte, 0);
            this.Controls.SetChildIndex(this.pictureBox4, 0);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtTotalDiferenciaHH, 0);
            this.Controls.SetChildIndex(this.txtTotalDiferenciaImporte, 0);
            this.Controls.SetChildIndex(this.pictureBox8, 0);
            this.Controls.SetChildIndex(this.pictureBox5, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.pictureBox15, 0);
            this.Controls.SetChildIndex(this.pictureBox14, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.lblTotalImporte, 0);
            this.Controls.SetChildIndex(this.txtReajuste, 0);
            this.Controls.SetChildIndex(this.gridDetalleCosto, 0);
            this.Controls.SetChildIndex(this.btnImprimirReporteCosto, 0);
            this.Controls.SetChildIndex(this.pictureBox10, 0);
            this.Controls.SetChildIndex(this.pictureBox9, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtTotalCostoPpto, 0);
            this.Controls.SetChildIndex(this.txtUtilidadPpto, 0);
            this.Controls.SetChildIndex(this.pictureBox12, 0);
            this.Controls.SetChildIndex(this.pictureBox11, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtTotalCostoReal, 0);
            this.Controls.SetChildIndex(this.txtUtilidadReal, 0);
            this.Controls.SetChildIndex(this.pictureBox16, 0);
            this.Controls.SetChildIndex(this.pictureBox13, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.txtTotalCostoDif, 0);
            this.Controls.SetChildIndex(this.txtUtilidadDif, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
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
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalleImporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalleCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Biblioteca.Controles.MiComboBox cmbPeriodo;
        private Biblioteca.Controles.MiNumericUpDown txtPeriodo;
        private Biblioteca.Controles.MiComboBox cmbCentroCosto;
        private Biblioteca.Controles.MiLabel miLabel2;
        public Biblioteca.Controles.MiGridEdit gridDetalleImporte;
        public Biblioteca.Controles.MiButton24x24 btnImprimirReporteImporte;
        public Biblioteca.Controles.MiTextBox txtTotalPptoImporte;
        public Biblioteca.Controles.MiTextBox txtTotalPptoHH;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox pictureBox7;
        public System.Windows.Forms.PictureBox pictureBox6;
        public Biblioteca.Controles.MiTextBox txtTotalRealImporte;
        public Biblioteca.Controles.MiTextBox txtTotalRealHH;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox pictureBox2;
        public Biblioteca.Controles.MiTextBox txtTotalDiferenciaImporte;
        public Biblioteca.Controles.MiTextBox txtTotalDiferenciaHH;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.PictureBox pictureBox5;
        public System.Windows.Forms.PictureBox pictureBox8;
        public System.Windows.Forms.Label lblTotalImporte;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.PictureBox pictureBox14;
        public System.Windows.Forms.PictureBox pictureBox15;
        public Biblioteca.Controles.MiTextBox txtReajuste;
        public Biblioteca.Controles.MiGridEdit gridDetalleCosto;
        public Biblioteca.Controles.MiButton24x24 btnImprimirReporteCosto;
        public Biblioteca.Controles.MiTextBox txtUtilidadPpto;
        public Biblioteca.Controles.MiTextBox txtTotalCostoPpto;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.PictureBox pictureBox9;
        public System.Windows.Forms.PictureBox pictureBox10;
        public Biblioteca.Controles.MiTextBox txtUtilidadReal;
        public Biblioteca.Controles.MiTextBox txtTotalCostoReal;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.PictureBox pictureBox11;
        public System.Windows.Forms.PictureBox pictureBox12;
        public Biblioteca.Controles.MiTextBox txtUtilidadDif;
        public Biblioteca.Controles.MiTextBox txtTotalCostoDif;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.PictureBox pictureBox13;
        public System.Windows.Forms.PictureBox pictureBox16;
        private Biblioteca.Controles.MiTextBoxRead txtEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCategoriaTrabajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValorHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPptoHH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPptoImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRealHH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRealImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDifHH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDifImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColModificacionHH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNula;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCuentaContable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPptoCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPptoIncidencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRealCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRealIncidencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDifCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDifIncidencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColModificacionCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        public System.Windows.Forms.Label lblCatalagoTitulo9;
        public System.Windows.Forms.Label lblCatalagoTitulo8;
        public System.Windows.Forms.Label lblCatalagoTitulo7;
    }
}