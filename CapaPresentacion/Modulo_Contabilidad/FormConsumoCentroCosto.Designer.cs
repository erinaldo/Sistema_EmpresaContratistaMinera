namespace CapaPresentacion
{
    partial class FormConsumoCentroCosto
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
                nConsumoCentroCosto.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsumoCentroCosto));
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.cmbPeriodo = new Biblioteca.Controles.MiComboBox();
            this.txtPeriodo = new Biblioteca.Controles.MiNumericUpDown();
            this.cmbCentroCosto = new Biblioteca.Controles.MiComboBox();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.txtConsumoTotal = new Biblioteca.Controles.MiTextBoxRead();
            this.txtDesechoTotal = new Biblioteca.Controles.MiTextBoxRead();
            this.txtTotalCostoBruto = new Biblioteca.Controles.MiTextBoxRead();
            this.txtTotalCostoNeto = new Biblioteca.Controles.MiTextBoxRead();
            this.lblCatalagoTitulo6 = new System.Windows.Forms.Label();
            this.btnBuscar = new Biblioteca.Controles.MiButtonFind();
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(609, 91);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(64, 14);
            this.lblCatalagoTitulo5.TabIndex = 13;
            this.lblCatalagoTitulo5.Text = "Costo Bruto";
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(553, 91);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(50, 14);
            this.lblCatalagoTitulo4.TabIndex = 12;
            this.lblCatalagoTitulo4.Text = "Desecho";
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(497, 91);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(52, 14);
            this.lblCatalagoTitulo3.TabIndex = 11;
            this.lblCatalagoTitulo3.Text = "Consumo";
            // 
            // lblCatalagoTitulo2
            // 
            this.lblCatalagoTitulo2.Location = new System.Drawing.Point(230, 91);
            this.lblCatalagoTitulo2.TabIndex = 10;
            // 
            // lblCatalagoTitulo1
            // 
            this.lblCatalagoTitulo1.Location = new System.Drawing.Point(161, 91);
            this.lblCatalagoTitulo1.TabIndex = 9;
            // 
            // lstCatalogo
            // 
            this.lstCatalogo.Location = new System.Drawing.Point(160, 107);
            this.lstCatalogo.SelectionMode = System.Windows.Forms.SelectionMode.One;
            this.lstCatalogo.Size = new System.Drawing.Size(840, 362);
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
            this.btnPDF_Lista.FlatAppearance.BorderSize = 0;
            this.btnPDF_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Lista.Location = new System.Drawing.Point(500, 60);
            this.btnPDF_Lista.TabIndex = 8;
            this.btnPDF_Lista.Visible = false;
            // 
            // btnExcel_Lista
            // 
            this.btnExcel_Lista.FlatAppearance.BorderSize = 0;
            this.btnExcel_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Lista.Location = new System.Drawing.Point(470, 60);
            this.btnExcel_Lista.TabIndex = 7;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Consumos por Centros de Costo";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 29;
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
            this.miLabel1.Text = "Centro de costo - Periodo";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cmbPeriodo.TabIndex = 4;
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
            this.txtPeriodo.TabIndex = 5;
            this.txtPeriodo.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
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
            this.cmbCentroCosto.TabIndex = 3;
            // 
            // miLabel2
            // 
            this.miLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel2.BackColor = System.Drawing.Color.Transparent;
            this.miLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel2.Location = new System.Drawing.Point(0, 477);
            this.miLabel2.Name = "miLabel2";
            this.miLabel2.Size = new System.Drawing.Size(160, 15);
            this.miLabel2.TabIndex = 21;
            this.miLabel2.Text = "Consumo total";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel3
            // 
            this.miLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel3.BackColor = System.Drawing.Color.Transparent;
            this.miLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel3.Location = new System.Drawing.Point(0, 505);
            this.miLabel3.Name = "miLabel3";
            this.miLabel3.Size = new System.Drawing.Size(160, 15);
            this.miLabel3.TabIndex = 23;
            this.miLabel3.Text = "Desecho total";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel4
            // 
            this.miLabel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel4.BackColor = System.Drawing.Color.Transparent;
            this.miLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel4.Location = new System.Drawing.Point(0, 532);
            this.miLabel4.Name = "miLabel4";
            this.miLabel4.Size = new System.Drawing.Size(160, 15);
            this.miLabel4.TabIndex = 25;
            this.miLabel4.Text = "Total costo bruto $";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel5
            // 
            this.miLabel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel5.BackColor = System.Drawing.Color.Transparent;
            this.miLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel5.Location = new System.Drawing.Point(0, 559);
            this.miLabel5.Name = "miLabel5";
            this.miLabel5.Size = new System.Drawing.Size(160, 15);
            this.miLabel5.TabIndex = 27;
            this.miLabel5.Text = "Total costo neto $";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConsumoTotal
            // 
            this.txtConsumoTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtConsumoTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtConsumoTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsumoTotal.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtConsumoTotal.ForeColor = System.Drawing.Color.Black;
            this.txtConsumoTotal.Location = new System.Drawing.Point(160, 474);
            this.txtConsumoTotal.MaxLength = 5;
            this.txtConsumoTotal.Name = "txtConsumoTotal";
            this.txtConsumoTotal.ReadOnly = true;
            this.txtConsumoTotal.Size = new System.Drawing.Size(45, 22);
            this.txtConsumoTotal.TabIndex = 22;
            // 
            // txtDesechoTotal
            // 
            this.txtDesechoTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDesechoTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtDesechoTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesechoTotal.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtDesechoTotal.ForeColor = System.Drawing.Color.Black;
            this.txtDesechoTotal.Location = new System.Drawing.Point(160, 502);
            this.txtDesechoTotal.MaxLength = 5;
            this.txtDesechoTotal.Name = "txtDesechoTotal";
            this.txtDesechoTotal.ReadOnly = true;
            this.txtDesechoTotal.Size = new System.Drawing.Size(45, 22);
            this.txtDesechoTotal.TabIndex = 24;
            // 
            // txtTotalCostoBruto
            // 
            this.txtTotalCostoBruto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalCostoBruto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtTotalCostoBruto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalCostoBruto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtTotalCostoBruto.ForeColor = System.Drawing.Color.Black;
            this.txtTotalCostoBruto.Location = new System.Drawing.Point(160, 529);
            this.txtTotalCostoBruto.MaxLength = 15;
            this.txtTotalCostoBruto.Name = "txtTotalCostoBruto";
            this.txtTotalCostoBruto.ReadOnly = true;
            this.txtTotalCostoBruto.Size = new System.Drawing.Size(100, 22);
            this.txtTotalCostoBruto.TabIndex = 26;
            // 
            // txtTotalCostoNeto
            // 
            this.txtTotalCostoNeto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalCostoNeto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtTotalCostoNeto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalCostoNeto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtTotalCostoNeto.ForeColor = System.Drawing.Color.Black;
            this.txtTotalCostoNeto.Location = new System.Drawing.Point(160, 556);
            this.txtTotalCostoNeto.MaxLength = 15;
            this.txtTotalCostoNeto.Name = "txtTotalCostoNeto";
            this.txtTotalCostoNeto.ReadOnly = true;
            this.txtTotalCostoNeto.Size = new System.Drawing.Size(100, 22);
            this.txtTotalCostoNeto.TabIndex = 28;
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblCatalagoTitulo6.AutoSize = true;
            this.lblCatalagoTitulo6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatalagoTitulo6.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(714, 91);
            this.lblCatalagoTitulo6.Name = "lblCatalagoTitulo6";
            this.lblCatalagoTitulo6.Size = new System.Drawing.Size(60, 14);
            this.lblCatalagoTitulo6.TabIndex = 14;
            this.lblCatalagoTitulo6.Text = "Costo Neto";
            this.lblCatalagoTitulo6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBuscar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Location = new System.Drawing.Point(440, 60);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBuscar.Size = new System.Drawing.Size(30, 24);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FormConsumoCentroCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblCatalagoTitulo6);
            this.Controls.Add(this.txtTotalCostoNeto);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.txtTotalCostoBruto);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.txtDesechoTotal);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.txtConsumoTotal);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.cmbCentroCosto);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.cmbPeriodo);
            this.Controls.Add(this.txtPeriodo);
            this.Name = "FormConsumoCentroCosto";
            this.Text = "Consumos por Centros de Costo";
            this.Load += new System.EventHandler(this.FormConsumoCentroCosto_Load);
            this.Controls.SetChildIndex(this.txtPeriodo, 0);
            this.Controls.SetChildIndex(this.cmbPeriodo, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.cmbCentroCosto, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.txtConsumoTotal, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.txtDesechoTotal, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.txtTotalCostoBruto, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.txtTotalCostoNeto, 0);
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
            this.Controls.SetChildIndex(this.lblCatalagoTitulo6, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiComboBox cmbPeriodo;
        private Biblioteca.Controles.MiNumericUpDown txtPeriodo;
        private Biblioteca.Controles.MiComboBox cmbCentroCosto;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiTextBoxRead txtConsumoTotal;
        private Biblioteca.Controles.MiTextBoxRead txtDesechoTotal;
        private Biblioteca.Controles.MiTextBoxRead txtTotalCostoBruto;
        private Biblioteca.Controles.MiTextBoxRead txtTotalCostoNeto;
        public System.Windows.Forms.Label lblCatalagoTitulo6;
        private Biblioteca.Controles.MiButtonFind btnBuscar;
    }
}