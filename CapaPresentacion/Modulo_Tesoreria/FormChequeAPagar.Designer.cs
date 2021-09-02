namespace CapaPresentacion
{
    partial class FormChequeAPagar
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
                nChequeAPagar.Dispose();
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
            this.txtChequeNomina = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.txtChequeProveedor = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.txtChequeOtro = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.txtChequeTotal = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.btnBuscar = new Biblioteca.Controles.MiButtonFind();
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(777, 91);
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(45, 14);
            this.lblCatalagoTitulo5.TabIndex = 12;
            this.lblCatalagoTitulo5.Text = "Monto $";
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(413, 91);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(74, 14);
            this.lblCatalagoTitulo4.TabIndex = 11;
            this.lblCatalagoTitulo4.Text = "Denominación";
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(322, 91);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(60, 14);
            this.lblCatalagoTitulo3.TabIndex = 10;
            this.lblCatalagoTitulo3.Text = "Fecha Vto.";
            // 
            // lblCatalagoTitulo2
            // 
            this.lblCatalagoTitulo2.Location = new System.Drawing.Point(231, 91);
            this.lblCatalagoTitulo2.Size = new System.Drawing.Size(54, 14);
            this.lblCatalagoTitulo2.TabIndex = 9;
            this.lblCatalagoTitulo2.Text = "F. Emisión";
            // 
            // lblCatalagoTitulo1
            // 
            this.lblCatalagoTitulo1.Location = new System.Drawing.Point(161, 91);
            this.lblCatalagoTitulo1.Size = new System.Drawing.Size(58, 14);
            this.lblCatalagoTitulo1.TabIndex = 8;
            this.lblCatalagoTitulo1.Text = "Cheque N°";
            // 
            // lstCatalogo
            // 
            this.lstCatalogo.Location = new System.Drawing.Point(160, 107);
            this.lstCatalogo.SelectionMode = System.Windows.Forms.SelectionMode.One;
            this.lstCatalogo.Size = new System.Drawing.Size(840, 458);
            this.lstCatalogo.TabIndex = 18;
            // 
            // fondoPaginacion
            // 
            this.fondoPaginacion.Location = new System.Drawing.Point(160, 88);
            this.fondoPaginacion.Size = new System.Drawing.Size(840, 20);
            // 
            // lblPaginacion
            // 
            this.lblPaginacion.TabIndex = 15;
            // 
            // btnPaginacionFinal
            // 
            this.btnPaginacionFinal.FlatAppearance.BorderSize = 0;
            this.btnPaginacionFinal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionFinal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionFinal.TabIndex = 17;
            // 
            // btnPaginacionPosterior
            // 
            this.btnPaginacionPosterior.FlatAppearance.BorderSize = 0;
            this.btnPaginacionPosterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionPosterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionPosterior.TabIndex = 16;
            // 
            // btnPaginacionAnterior
            // 
            this.btnPaginacionAnterior.FlatAppearance.BorderSize = 0;
            this.btnPaginacionAnterior.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionAnterior.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionAnterior.TabIndex = 14;
            // 
            // btnPaginacionInicial
            // 
            this.btnPaginacionInicial.FlatAppearance.BorderSize = 0;
            this.btnPaginacionInicial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPaginacionInicial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPaginacionInicial.TabIndex = 13;
            // 
            // btnPDF_Lista
            // 
            this.btnPDF_Lista.Enabled = false;
            this.btnPDF_Lista.FlatAppearance.BorderSize = 0;
            this.btnPDF_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Lista.Location = new System.Drawing.Point(427, 60);
            this.btnPDF_Lista.TabIndex = 7;
            this.btnPDF_Lista.Visible = false;
            // 
            // btnExcel_Lista
            // 
            this.btnExcel_Lista.FlatAppearance.BorderSize = 0;
            this.btnExcel_Lista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Lista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Lista.Location = new System.Drawing.Point(397, 60);
            this.btnExcel_Lista.TabIndex = 6;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Cheques a Pagar";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 27;
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
            // txtChequeNomina
            // 
            this.txtChequeNomina.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtChequeNomina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtChequeNomina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChequeNomina.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtChequeNomina.ForeColor = System.Drawing.Color.Black;
            this.txtChequeNomina.Location = new System.Drawing.Point(160, 597);
            this.txtChequeNomina.MaxLength = 15;
            this.txtChequeNomina.Name = "txtChequeNomina";
            this.txtChequeNomina.ReadOnly = true;
            this.txtChequeNomina.Size = new System.Drawing.Size(100, 22);
            this.txtChequeNomina.TabIndex = 22;
            // 
            // miLabel3
            // 
            this.miLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel3.BackColor = System.Drawing.Color.Transparent;
            this.miLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel3.Location = new System.Drawing.Point(0, 600);
            this.miLabel3.Name = "miLabel3";
            this.miLabel3.Size = new System.Drawing.Size(160, 15);
            this.miLabel3.TabIndex = 21;
            this.miLabel3.Text = "Cheques a nomina $";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtChequeProveedor
            // 
            this.txtChequeProveedor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtChequeProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtChequeProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChequeProveedor.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtChequeProveedor.ForeColor = System.Drawing.Color.Black;
            this.txtChequeProveedor.Location = new System.Drawing.Point(160, 570);
            this.txtChequeProveedor.MaxLength = 15;
            this.txtChequeProveedor.Name = "txtChequeProveedor";
            this.txtChequeProveedor.ReadOnly = true;
            this.txtChequeProveedor.Size = new System.Drawing.Size(100, 22);
            this.txtChequeProveedor.TabIndex = 20;
            // 
            // miLabel2
            // 
            this.miLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel2.BackColor = System.Drawing.Color.Transparent;
            this.miLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel2.Location = new System.Drawing.Point(0, 573);
            this.miLabel2.Name = "miLabel2";
            this.miLabel2.Size = new System.Drawing.Size(160, 15);
            this.miLabel2.TabIndex = 19;
            this.miLabel2.Text = "Cheques a proveedores $";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtChequeOtro
            // 
            this.txtChequeOtro.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtChequeOtro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtChequeOtro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChequeOtro.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtChequeOtro.ForeColor = System.Drawing.Color.Black;
            this.txtChequeOtro.Location = new System.Drawing.Point(421, 570);
            this.txtChequeOtro.MaxLength = 15;
            this.txtChequeOtro.Name = "txtChequeOtro";
            this.txtChequeOtro.ReadOnly = true;
            this.txtChequeOtro.Size = new System.Drawing.Size(100, 22);
            this.txtChequeOtro.TabIndex = 24;
            // 
            // miLabel4
            // 
            this.miLabel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel4.BackColor = System.Drawing.Color.Transparent;
            this.miLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel4.Location = new System.Drawing.Point(261, 573);
            this.miLabel4.Name = "miLabel4";
            this.miLabel4.Size = new System.Drawing.Size(160, 15);
            this.miLabel4.TabIndex = 23;
            this.miLabel4.Text = "Cheques a otros $";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtChequeTotal
            // 
            this.txtChequeTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtChequeTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtChequeTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChequeTotal.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtChequeTotal.ForeColor = System.Drawing.Color.Black;
            this.txtChequeTotal.Location = new System.Drawing.Point(421, 597);
            this.txtChequeTotal.MaxLength = 15;
            this.txtChequeTotal.Name = "txtChequeTotal";
            this.txtChequeTotal.ReadOnly = true;
            this.txtChequeTotal.Size = new System.Drawing.Size(100, 22);
            this.txtChequeTotal.TabIndex = 26;
            // 
            // miLabel5
            // 
            this.miLabel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel5.BackColor = System.Drawing.Color.Transparent;
            this.miLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel5.Location = new System.Drawing.Point(261, 600);
            this.miLabel5.Name = "miLabel5";
            this.miLabel5.Size = new System.Drawing.Size(160, 15);
            this.miLabel5.TabIndex = 25;
            this.miLabel5.Text = "Total cheques $";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnBuscar.Location = new System.Drawing.Point(367, 60);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBuscar.Size = new System.Drawing.Size(30, 24);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FormChequeAPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtChequeTotal);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.txtChequeOtro);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.txtChequeNomina);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.txtChequeProveedor);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.pkrIntervaloHasta);
            this.Controls.Add(this.pkrIntervaloDesde);
            this.Controls.Add(this.miLabel1);
            this.Name = "FormChequeAPagar";
            this.Text = "Cheques a Pagar";
            this.Load += new System.EventHandler(this.FormChequeAPagar_Load);
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
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.txtChequeProveedor, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.txtChequeNomina, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.txtChequeOtro, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.txtChequeTotal, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.fondoPaginacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Biblioteca.Controles.MiDateTimePicker pkrIntervaloHasta;
        public Biblioteca.Controles.MiDateTimePicker pkrIntervaloDesde;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBoxRead txtChequeNomina;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiTextBoxRead txtChequeProveedor;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiTextBoxRead txtChequeOtro;
        private Biblioteca.Controles.MiLabel miLabel4;
        private Biblioteca.Controles.MiTextBoxRead txtChequeTotal;
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiButtonFind btnBuscar;
    }
}