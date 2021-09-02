namespace CapaPresentacion
{
    partial class FormArticulo
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
                nArticulo.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormArticulo));
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.txtCodigoBarras = new Biblioteca.Controles.MiMaskedTextBox();
            this.cmbEstado = new Biblioteca.Controles.MiComboBox();
            this.miLabel16 = new Biblioteca.Controles.MiLabel();
            this.txtCostoNeto = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel12 = new Biblioteca.Controles.MiLabel();
            this.txtBaseIVA = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel11 = new Biblioteca.Controles.MiLabel();
            this.cmbAlicuotaIVA = new Biblioteca.Controles.MiComboBox();
            this.miLabel10 = new Biblioteca.Controles.MiLabel();
            this.txtCostoBruto = new Biblioteca.Controles.MiTextBox();
            this.miLabel9 = new Biblioteca.Controles.MiLabel();
            this.txtStockGlobal = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel8 = new Biblioteca.Controles.MiLabel();
            this.cmbUnidad = new Biblioteca.Controles.MiComboBox();
            this.miLabel7 = new Biblioteca.Controles.MiLabel();
            this.cmbCriticidad = new Biblioteca.Controles.MiComboBox();
            this.miLabel6 = new Biblioteca.Controles.MiLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacionMarca = new Biblioteca.Controles.MiTextBox();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacionModelo = new Biblioteca.Controles.MiTextBox();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacionArticulo = new Biblioteca.Controles.MiTextBox();
            this.miLabel13 = new Biblioteca.Controles.MiLabel();
            this.miLabel14 = new Biblioteca.Controles.MiLabel();
            this.miLabel15 = new Biblioteca.Controles.MiLabel();
            this.txtUtilidad = new Biblioteca.Controles.MiTextBox();
            this.txtMargen = new Biblioteca.Controles.MiTextBox();
            this.txtPrecioBruto = new Biblioteca.Controles.MiTextBox();
            this.btnGenerarCodigo = new Biblioteca.Controles.MiButtonFind();
            this.btnImprimirCodigo = new Biblioteca.Controles.MiButtonFind();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupAlmacenEmpreminsa = new System.Windows.Forms.GroupBox();
            this.txtA1_PuntoCritico = new Biblioteca.Controles.MiMaskedTextBox();
            this.txtA1_Stock = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel19 = new Biblioteca.Controles.MiLabel();
            this.txtA1_FechaIngreso = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel18 = new Biblioteca.Controles.MiLabel();
            this.txtA1_PuntoMinimo = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel17 = new Biblioteca.Controles.MiLabel();
            this.txtA1_PuntoMaximo = new Biblioteca.Controles.MiMaskedTextBox();
            this.chkA1_PuntoMinimo = new Biblioteca.Controles.MiCheckBox();
            this.chkA1_PuntoCritico = new Biblioteca.Controles.MiCheckBox();
            this.groupAlmacenVeladero = new System.Windows.Forms.GroupBox();
            this.txtA2_PuntoCritico = new Biblioteca.Controles.MiMaskedTextBox();
            this.txtA2_Stock = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel22 = new Biblioteca.Controles.MiLabel();
            this.txtA2_FechaIngreso = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel21 = new Biblioteca.Controles.MiLabel();
            this.txtA2_PuntoMinimo = new Biblioteca.Controles.MiMaskedTextBox();
            this.miLabel20 = new Biblioteca.Controles.MiLabel();
            this.txtA2_PuntoMaximo = new Biblioteca.Controles.MiMaskedTextBox();
            this.chkA2_PuntoMinimo = new Biblioteca.Controles.MiCheckBox();
            this.chkA2_PuntoCritico = new Biblioteca.Controles.MiCheckBox();
            this.tabContenedor = new System.Windows.Forms.TabControl();
            this.panelLista.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupAlmacenEmpreminsa.SuspendLayout();
            this.groupAlmacenVeladero.SuspendLayout();
            this.tabContenedor.SuspendLayout();
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
            this.btnAnular.TabIndex = 8;
            this.btnAnular.Visible = false;
            // 
            // btnExcel_Registro
            // 
            this.btnExcel_Registro.FlatAppearance.BorderSize = 0;
            this.btnExcel_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnExcel_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExcel_Registro.Location = new System.Drawing.Point(241, 657);
            this.btnExcel_Registro.TabIndex = 6;
            // 
            // btnPDF_Registro
            // 
            this.btnPDF_Registro.FlatAppearance.BorderSize = 0;
            this.btnPDF_Registro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPDF_Registro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPDF_Registro.Location = new System.Drawing.Point(273, 657);
            this.btnPDF_Registro.TabIndex = 7;
            // 
            // lblTituloLista
            // 
            this.lblTituloLista.Text = "Lista de Artículos";
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
            this.lblCatalagoTitulo1.Size = new System.Drawing.Size(16, 14);
            this.lblCatalagoTitulo1.Text = "ID";
            // 
            // lblCatalagoTitulo2
            // 
            this.lblCatalagoTitulo2.Location = new System.Drawing.Point(63, 36);
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(343, 36);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(51, 14);
            this.lblCatalagoTitulo3.Text = "Stk. Emp.";
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(406, 36);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(80, 14);
            this.lblCatalagoTitulo4.Text = "F. Ingreso Emp.";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(497, 36);
            this.lblCatalagoTitulo5.Text = "Stk. Vel.";
            // 
            // panelLista
            // 
            this.panelLista.Controls.Add(this.label1);
            this.panelLista.Controls.Add(this.label2);
            this.panelLista.Controls.SetChildIndex(this.lstCatalogo, 0);
            this.panelLista.Controls.SetChildIndex(this.label2, 0);
            this.panelLista.Controls.SetChildIndex(this.label1, 0);
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
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(560, 36);
            this.lblCatalagoTitulo6.Size = new System.Drawing.Size(75, 14);
            this.lblCatalagoTitulo6.Text = "F. Ingreso Vel.";
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Artículos";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // miLabel5
            // 
            this.miLabel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel5.BackColor = System.Drawing.Color.Transparent;
            this.miLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel5.Location = new System.Drawing.Point(0, 145);
            this.miLabel5.Name = "miLabel5";
            this.miLabel5.Size = new System.Drawing.Size(160, 15);
            this.miLabel5.TabIndex = 17;
            this.miLabel5.Text = "Código de barras";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCodigoBarras.BackColor = System.Drawing.Color.White;
            this.txtCodigoBarras.BeepOnError = true;
            this.txtCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoBarras.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCodigoBarras.ForeColor = System.Drawing.Color.Black;
            this.txtCodigoBarras.HidePromptOnLeave = true;
            this.txtCodigoBarras.Location = new System.Drawing.Point(160, 142);
            this.txtCodigoBarras.Mask = "9999999999999999999999999";
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.PromptChar = ' ';
            this.txtCodigoBarras.Size = new System.Drawing.Size(185, 22);
            this.txtCodigoBarras.TabIndex = 18;
            this.txtCodigoBarras.Validated += new System.EventHandler(this.txtCodigoBarras_Validated);
            // 
            // cmbEstado
            // 
            this.cmbEstado.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbEstado.BackColor = System.Drawing.Color.White;
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbEstado.ForeColor = System.Drawing.Color.Black;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.ItemHeight = 14;
            this.cmbEstado.Items.AddRange(new object[] {
            "ACTIVO",
            "BAJA"});
            this.cmbEstado.Location = new System.Drawing.Point(160, 439);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(1);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(95, 22);
            this.cmbEstado.Sorted = true;
            this.cmbEstado.TabIndex = 42;
            // 
            // miLabel16
            // 
            this.miLabel16.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel16.BackColor = System.Drawing.Color.Transparent;
            this.miLabel16.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel16.Location = new System.Drawing.Point(0, 442);
            this.miLabel16.Name = "miLabel16";
            this.miLabel16.Size = new System.Drawing.Size(160, 15);
            this.miLabel16.TabIndex = 41;
            this.miLabel16.Text = "Estado";
            this.miLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCostoNeto
            // 
            this.txtCostoNeto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCostoNeto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtCostoNeto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostoNeto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCostoNeto.ForeColor = System.Drawing.Color.Black;
            this.txtCostoNeto.Location = new System.Drawing.Point(160, 331);
            this.txtCostoNeto.MaxLength = 12;
            this.txtCostoNeto.Name = "txtCostoNeto";
            this.txtCostoNeto.ReadOnly = true;
            this.txtCostoNeto.Size = new System.Drawing.Size(85, 22);
            this.txtCostoNeto.TabIndex = 34;
            // 
            // miLabel12
            // 
            this.miLabel12.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel12.BackColor = System.Drawing.Color.Transparent;
            this.miLabel12.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel12.Location = new System.Drawing.Point(0, 334);
            this.miLabel12.Name = "miLabel12";
            this.miLabel12.Size = new System.Drawing.Size(160, 15);
            this.miLabel12.TabIndex = 33;
            this.miLabel12.Text = "Costo neto $";
            this.miLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBaseIVA
            // 
            this.txtBaseIVA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtBaseIVA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtBaseIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBaseIVA.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtBaseIVA.ForeColor = System.Drawing.Color.Black;
            this.txtBaseIVA.Location = new System.Drawing.Point(160, 304);
            this.txtBaseIVA.MaxLength = 12;
            this.txtBaseIVA.Name = "txtBaseIVA";
            this.txtBaseIVA.ReadOnly = true;
            this.txtBaseIVA.Size = new System.Drawing.Size(85, 22);
            this.txtBaseIVA.TabIndex = 32;
            // 
            // miLabel11
            // 
            this.miLabel11.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel11.BackColor = System.Drawing.Color.Transparent;
            this.miLabel11.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel11.Location = new System.Drawing.Point(0, 307);
            this.miLabel11.Name = "miLabel11";
            this.miLabel11.Size = new System.Drawing.Size(160, 15);
            this.miLabel11.TabIndex = 31;
            this.miLabel11.Text = "Base IVA $";
            this.miLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbAlicuotaIVA
            // 
            this.cmbAlicuotaIVA.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbAlicuotaIVA.BackColor = System.Drawing.Color.White;
            this.cmbAlicuotaIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlicuotaIVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAlicuotaIVA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbAlicuotaIVA.ForeColor = System.Drawing.Color.Black;
            this.cmbAlicuotaIVA.FormattingEnabled = true;
            this.cmbAlicuotaIVA.ItemHeight = 14;
            this.cmbAlicuotaIVA.Items.AddRange(new object[] {
            "00.0",
            "10.5",
            "21.0",
            "27.0"});
            this.cmbAlicuotaIVA.Location = new System.Drawing.Point(160, 277);
            this.cmbAlicuotaIVA.Margin = new System.Windows.Forms.Padding(1);
            this.cmbAlicuotaIVA.Name = "cmbAlicuotaIVA";
            this.cmbAlicuotaIVA.Size = new System.Drawing.Size(45, 22);
            this.cmbAlicuotaIVA.Sorted = true;
            this.cmbAlicuotaIVA.TabIndex = 30;
            this.cmbAlicuotaIVA.SelectedIndexChanged += new System.EventHandler(this.cmbAlicuotaIVA_SelectedIndexChanged);
            // 
            // miLabel10
            // 
            this.miLabel10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel10.BackColor = System.Drawing.Color.Transparent;
            this.miLabel10.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel10.Location = new System.Drawing.Point(0, 280);
            this.miLabel10.Name = "miLabel10";
            this.miLabel10.Size = new System.Drawing.Size(160, 15);
            this.miLabel10.TabIndex = 29;
            this.miLabel10.Text = "Alícuota IVA %";
            this.miLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCostoBruto
            // 
            this.txtCostoBruto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCostoBruto.BackColor = System.Drawing.Color.White;
            this.txtCostoBruto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostoBruto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCostoBruto.ForeColor = System.Drawing.Color.Black;
            this.txtCostoBruto.Location = new System.Drawing.Point(160, 250);
            this.txtCostoBruto.MaxLength = 12;
            this.txtCostoBruto.Name = "txtCostoBruto";
            this.txtCostoBruto.Size = new System.Drawing.Size(85, 22);
            this.txtCostoBruto.TabIndex = 28;
            this.txtCostoBruto.Enter += new System.EventHandler(this.txtCostoBruto_Enter);
            this.txtCostoBruto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCostoBruto_KeyPress);
            this.txtCostoBruto.Validated += new System.EventHandler(this.txtCostoBruto_Validated);
            // 
            // miLabel9
            // 
            this.miLabel9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel9.BackColor = System.Drawing.Color.Transparent;
            this.miLabel9.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel9.Location = new System.Drawing.Point(0, 253);
            this.miLabel9.Name = "miLabel9";
            this.miLabel9.Size = new System.Drawing.Size(160, 15);
            this.miLabel9.TabIndex = 27;
            this.miLabel9.Text = "Costo bruto $";
            this.miLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStockGlobal
            // 
            this.txtStockGlobal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtStockGlobal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtStockGlobal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStockGlobal.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtStockGlobal.ForeColor = System.Drawing.Color.Black;
            this.txtStockGlobal.Location = new System.Drawing.Point(160, 222);
            this.txtStockGlobal.MaxLength = 6;
            this.txtStockGlobal.Name = "txtStockGlobal";
            this.txtStockGlobal.ReadOnly = true;
            this.txtStockGlobal.Size = new System.Drawing.Size(50, 22);
            this.txtStockGlobal.TabIndex = 26;
            // 
            // miLabel8
            // 
            this.miLabel8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel8.BackColor = System.Drawing.Color.Transparent;
            this.miLabel8.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel8.Location = new System.Drawing.Point(0, 225);
            this.miLabel8.Name = "miLabel8";
            this.miLabel8.Size = new System.Drawing.Size(160, 15);
            this.miLabel8.TabIndex = 25;
            this.miLabel8.Text = "Stock global";
            this.miLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbUnidad
            // 
            this.cmbUnidad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbUnidad.BackColor = System.Drawing.Color.White;
            this.cmbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUnidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbUnidad.ForeColor = System.Drawing.Color.Black;
            this.cmbUnidad.FormattingEnabled = true;
            this.cmbUnidad.ItemHeight = 14;
            this.cmbUnidad.Items.AddRange(new object[] {
            "KGS",
            "LTS",
            "MTS",
            "PAQ",
            "UNI"});
            this.cmbUnidad.Location = new System.Drawing.Point(160, 196);
            this.cmbUnidad.Margin = new System.Windows.Forms.Padding(1);
            this.cmbUnidad.Name = "cmbUnidad";
            this.cmbUnidad.Size = new System.Drawing.Size(55, 22);
            this.cmbUnidad.Sorted = true;
            this.cmbUnidad.TabIndex = 24;
            // 
            // miLabel7
            // 
            this.miLabel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel7.BackColor = System.Drawing.Color.Transparent;
            this.miLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel7.Location = new System.Drawing.Point(0, 199);
            this.miLabel7.Name = "miLabel7";
            this.miLabel7.Size = new System.Drawing.Size(160, 15);
            this.miLabel7.TabIndex = 23;
            this.miLabel7.Text = "Unidad de medida";
            this.miLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCriticidad
            // 
            this.cmbCriticidad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbCriticidad.BackColor = System.Drawing.Color.White;
            this.cmbCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCriticidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCriticidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCriticidad.ForeColor = System.Drawing.Color.Black;
            this.cmbCriticidad.FormattingEnabled = true;
            this.cmbCriticidad.ItemHeight = 14;
            this.cmbCriticidad.Items.AddRange(new object[] {
            "ALTA",
            "BAJA",
            "MEDIA"});
            this.cmbCriticidad.Location = new System.Drawing.Point(160, 169);
            this.cmbCriticidad.Margin = new System.Windows.Forms.Padding(1);
            this.cmbCriticidad.Name = "cmbCriticidad";
            this.cmbCriticidad.Size = new System.Drawing.Size(70, 22);
            this.cmbCriticidad.Sorted = true;
            this.cmbCriticidad.TabIndex = 22;
            // 
            // miLabel6
            // 
            this.miLabel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel6.BackColor = System.Drawing.Color.Transparent;
            this.miLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel6.Location = new System.Drawing.Point(0, 172);
            this.miLabel6.Name = "miLabel6";
            this.miLabel6.Size = new System.Drawing.Size(160, 15);
            this.miLabel6.TabIndex = 21;
            this.miLabel6.Text = "Criticidad";
            this.miLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(651, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 27;
            this.label1.Text = "Stk. Global";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(714, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 14);
            this.label2.TabIndex = 28;
            this.label2.Text = "Estado";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.miLabel3.TabIndex = 15;
            this.miLabel3.Text = "Marca";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenominacionMarca
            // 
            this.txtDenominacionMarca.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDenominacionMarca.BackColor = System.Drawing.Color.White;
            this.txtDenominacionMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDenominacionMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDenominacionMarca.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtDenominacionMarca.ForeColor = System.Drawing.Color.Black;
            this.txtDenominacionMarca.Location = new System.Drawing.Point(160, 115);
            this.txtDenominacionMarca.MaxLength = 20;
            this.txtDenominacionMarca.Name = "txtDenominacionMarca";
            this.txtDenominacionMarca.Size = new System.Drawing.Size(170, 22);
            this.txtDenominacionMarca.TabIndex = 16;
            this.txtDenominacionMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDenominacionMarca_KeyPress);
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
            this.miLabel2.TabIndex = 13;
            this.miLabel2.Text = " Tipo/Modelo";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenominacionModelo
            // 
            this.txtDenominacionModelo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDenominacionModelo.BackColor = System.Drawing.Color.White;
            this.txtDenominacionModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDenominacionModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDenominacionModelo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtDenominacionModelo.ForeColor = System.Drawing.Color.Black;
            this.txtDenominacionModelo.Location = new System.Drawing.Point(160, 88);
            this.txtDenominacionModelo.MaxLength = 20;
            this.txtDenominacionModelo.Name = "txtDenominacionModelo";
            this.txtDenominacionModelo.Size = new System.Drawing.Size(170, 22);
            this.txtDenominacionModelo.TabIndex = 14;
            this.txtDenominacionModelo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDenominacionModelo_KeyPress);
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
            this.miLabel1.Text = "Artículo";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenominacionArticulo
            // 
            this.txtDenominacionArticulo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDenominacionArticulo.BackColor = System.Drawing.Color.White;
            this.txtDenominacionArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDenominacionArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDenominacionArticulo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtDenominacionArticulo.ForeColor = System.Drawing.Color.Black;
            this.txtDenominacionArticulo.Location = new System.Drawing.Point(160, 61);
            this.txtDenominacionArticulo.MaxLength = 20;
            this.txtDenominacionArticulo.Name = "txtDenominacionArticulo";
            this.txtDenominacionArticulo.Size = new System.Drawing.Size(170, 22);
            this.txtDenominacionArticulo.TabIndex = 12;
            this.txtDenominacionArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDenominacionArticulo_KeyPress);
            // 
            // miLabel13
            // 
            this.miLabel13.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel13.BackColor = System.Drawing.Color.Transparent;
            this.miLabel13.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel13.Location = new System.Drawing.Point(0, 361);
            this.miLabel13.Name = "miLabel13";
            this.miLabel13.Size = new System.Drawing.Size(160, 15);
            this.miLabel13.TabIndex = 35;
            this.miLabel13.Text = "Utilidad %";
            this.miLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel14
            // 
            this.miLabel14.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel14.BackColor = System.Drawing.Color.Transparent;
            this.miLabel14.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel14.Location = new System.Drawing.Point(0, 388);
            this.miLabel14.Name = "miLabel14";
            this.miLabel14.Size = new System.Drawing.Size(160, 15);
            this.miLabel14.TabIndex = 37;
            this.miLabel14.Text = "Margen $";
            this.miLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel15
            // 
            this.miLabel15.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel15.BackColor = System.Drawing.Color.Transparent;
            this.miLabel15.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel15.Location = new System.Drawing.Point(0, 415);
            this.miLabel15.Name = "miLabel15";
            this.miLabel15.Size = new System.Drawing.Size(160, 15);
            this.miLabel15.TabIndex = 39;
            this.miLabel15.Text = "Precio bruto (Venta) $";
            this.miLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUtilidad
            // 
            this.txtUtilidad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtUtilidad.BackColor = System.Drawing.Color.White;
            this.txtUtilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUtilidad.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtUtilidad.ForeColor = System.Drawing.Color.Black;
            this.txtUtilidad.Location = new System.Drawing.Point(160, 358);
            this.txtUtilidad.MaxLength = 8;
            this.txtUtilidad.Name = "txtUtilidad";
            this.txtUtilidad.Size = new System.Drawing.Size(70, 22);
            this.txtUtilidad.TabIndex = 36;
            this.txtUtilidad.Enter += new System.EventHandler(this.txtUtilidad_Enter);
            this.txtUtilidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUtilidad_KeyPress);
            this.txtUtilidad.Validated += new System.EventHandler(this.txtUtilidad_Validated);
            // 
            // txtMargen
            // 
            this.txtMargen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtMargen.BackColor = System.Drawing.Color.White;
            this.txtMargen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMargen.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtMargen.ForeColor = System.Drawing.Color.Black;
            this.txtMargen.Location = new System.Drawing.Point(160, 385);
            this.txtMargen.MaxLength = 12;
            this.txtMargen.Name = "txtMargen";
            this.txtMargen.Size = new System.Drawing.Size(85, 22);
            this.txtMargen.TabIndex = 38;
            this.txtMargen.Enter += new System.EventHandler(this.txtMargen_Enter);
            this.txtMargen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMargen_KeyPress);
            this.txtMargen.Validated += new System.EventHandler(this.txtMargen_Validated);
            // 
            // txtPrecioBruto
            // 
            this.txtPrecioBruto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPrecioBruto.BackColor = System.Drawing.Color.White;
            this.txtPrecioBruto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioBruto.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtPrecioBruto.ForeColor = System.Drawing.Color.Black;
            this.txtPrecioBruto.Location = new System.Drawing.Point(160, 412);
            this.txtPrecioBruto.MaxLength = 12;
            this.txtPrecioBruto.Name = "txtPrecioBruto";
            this.txtPrecioBruto.Size = new System.Drawing.Size(85, 22);
            this.txtPrecioBruto.TabIndex = 40;
            this.txtPrecioBruto.Enter += new System.EventHandler(this.txtPrecioBruto_Enter);
            this.txtPrecioBruto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioBruto_KeyPress);
            this.txtPrecioBruto.Validated += new System.EventHandler(this.txtPrecioBruto_Validated);
            // 
            // btnGenerarCodigo
            // 
            this.btnGenerarCodigo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGenerarCodigo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGenerarCodigo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerarCodigo.BackgroundImage")));
            this.btnGenerarCodigo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerarCodigo.FlatAppearance.BorderSize = 0;
            this.btnGenerarCodigo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGenerarCodigo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGenerarCodigo.Font = new System.Drawing.Font("Arial", 9F);
            this.btnGenerarCodigo.ForeColor = System.Drawing.Color.Black;
            this.btnGenerarCodigo.Location = new System.Drawing.Point(346, 141);
            this.btnGenerarCodigo.Name = "btnGenerarCodigo";
            this.btnGenerarCodigo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnGenerarCodigo.Size = new System.Drawing.Size(24, 24);
            this.btnGenerarCodigo.TabIndex = 19;
            this.btnGenerarCodigo.UseVisualStyleBackColor = false;
            this.btnGenerarCodigo.Click += new System.EventHandler(this.btnGenerarCodigo_Click);
            // 
            // btnImprimirCodigo
            // 
            this.btnImprimirCodigo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImprimirCodigo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnImprimirCodigo.BackgroundImage = global::CapaPresentacion.Properties.Resources.icon_printer;
            this.btnImprimirCodigo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimirCodigo.FlatAppearance.BorderSize = 0;
            this.btnImprimirCodigo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnImprimirCodigo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnImprimirCodigo.Font = new System.Drawing.Font("Arial", 9F);
            this.btnImprimirCodigo.ForeColor = System.Drawing.Color.Black;
            this.btnImprimirCodigo.Location = new System.Drawing.Point(370, 141);
            this.btnImprimirCodigo.Name = "btnImprimirCodigo";
            this.btnImprimirCodigo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnImprimirCodigo.Size = new System.Drawing.Size(24, 24);
            this.btnImprimirCodigo.TabIndex = 20;
            this.btnImprimirCodigo.UseVisualStyleBackColor = false;
            this.btnImprimirCodigo.Click += new System.EventHandler(this.btnImprimirCodigo_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.groupAlmacenEmpreminsa);
            this.tabPage1.Controls.Add(this.groupAlmacenVeladero);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(460, 429);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Almacenes";
            // 
            // groupAlmacenEmpreminsa
            // 
            this.groupAlmacenEmpreminsa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupAlmacenEmpreminsa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupAlmacenEmpreminsa.Controls.Add(this.txtA1_PuntoCritico);
            this.groupAlmacenEmpreminsa.Controls.Add(this.txtA1_Stock);
            this.groupAlmacenEmpreminsa.Controls.Add(this.miLabel19);
            this.groupAlmacenEmpreminsa.Controls.Add(this.txtA1_FechaIngreso);
            this.groupAlmacenEmpreminsa.Controls.Add(this.miLabel18);
            this.groupAlmacenEmpreminsa.Controls.Add(this.txtA1_PuntoMinimo);
            this.groupAlmacenEmpreminsa.Controls.Add(this.miLabel17);
            this.groupAlmacenEmpreminsa.Controls.Add(this.txtA1_PuntoMaximo);
            this.groupAlmacenEmpreminsa.Controls.Add(this.chkA1_PuntoMinimo);
            this.groupAlmacenEmpreminsa.Controls.Add(this.chkA1_PuntoCritico);
            this.groupAlmacenEmpreminsa.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupAlmacenEmpreminsa.ForeColor = System.Drawing.Color.Gray;
            this.groupAlmacenEmpreminsa.Location = new System.Drawing.Point(7, 7);
            this.groupAlmacenEmpreminsa.Name = "groupAlmacenEmpreminsa";
            this.groupAlmacenEmpreminsa.Size = new System.Drawing.Size(445, 150);
            this.groupAlmacenEmpreminsa.TabIndex = 0;
            this.groupAlmacenEmpreminsa.TabStop = false;
            this.groupAlmacenEmpreminsa.Text = "Empreminsa";
            // 
            // txtA1_PuntoCritico
            // 
            this.txtA1_PuntoCritico.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtA1_PuntoCritico.BackColor = System.Drawing.Color.White;
            this.txtA1_PuntoCritico.BeepOnError = true;
            this.txtA1_PuntoCritico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtA1_PuntoCritico.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtA1_PuntoCritico.ForeColor = System.Drawing.Color.Black;
            this.txtA1_PuntoCritico.HidePromptOnLeave = true;
            this.txtA1_PuntoCritico.Location = new System.Drawing.Point(160, 12);
            this.txtA1_PuntoCritico.Mask = "999999";
            this.txtA1_PuntoCritico.Name = "txtA1_PuntoCritico";
            this.txtA1_PuntoCritico.PromptChar = ' ';
            this.txtA1_PuntoCritico.Size = new System.Drawing.Size(50, 22);
            this.txtA1_PuntoCritico.TabIndex = 1;
            // 
            // txtA1_Stock
            // 
            this.txtA1_Stock.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtA1_Stock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtA1_Stock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtA1_Stock.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtA1_Stock.ForeColor = System.Drawing.Color.Black;
            this.txtA1_Stock.Location = new System.Drawing.Point(160, 121);
            this.txtA1_Stock.MaxLength = 6;
            this.txtA1_Stock.Name = "txtA1_Stock";
            this.txtA1_Stock.ReadOnly = true;
            this.txtA1_Stock.Size = new System.Drawing.Size(50, 22);
            this.txtA1_Stock.TabIndex = 9;
            // 
            // miLabel19
            // 
            this.miLabel19.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel19.BackColor = System.Drawing.Color.Transparent;
            this.miLabel19.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel19.Location = new System.Drawing.Point(0, 124);
            this.miLabel19.Name = "miLabel19";
            this.miLabel19.Size = new System.Drawing.Size(160, 15);
            this.miLabel19.TabIndex = 8;
            this.miLabel19.Text = "Stock";
            this.miLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtA1_FechaIngreso
            // 
            this.txtA1_FechaIngreso.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtA1_FechaIngreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtA1_FechaIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtA1_FechaIngreso.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtA1_FechaIngreso.ForeColor = System.Drawing.Color.Black;
            this.txtA1_FechaIngreso.Location = new System.Drawing.Point(160, 93);
            this.txtA1_FechaIngreso.MaxLength = 12;
            this.txtA1_FechaIngreso.Name = "txtA1_FechaIngreso";
            this.txtA1_FechaIngreso.ReadOnly = true;
            this.txtA1_FechaIngreso.Size = new System.Drawing.Size(70, 22);
            this.txtA1_FechaIngreso.TabIndex = 7;
            // 
            // miLabel18
            // 
            this.miLabel18.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel18.BackColor = System.Drawing.Color.Transparent;
            this.miLabel18.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel18.Location = new System.Drawing.Point(0, 96);
            this.miLabel18.Name = "miLabel18";
            this.miLabel18.Size = new System.Drawing.Size(160, 15);
            this.miLabel18.TabIndex = 6;
            this.miLabel18.Text = "Fecha de ingreso";
            this.miLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtA1_PuntoMinimo
            // 
            this.txtA1_PuntoMinimo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtA1_PuntoMinimo.BackColor = System.Drawing.Color.White;
            this.txtA1_PuntoMinimo.BeepOnError = true;
            this.txtA1_PuntoMinimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtA1_PuntoMinimo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtA1_PuntoMinimo.ForeColor = System.Drawing.Color.Black;
            this.txtA1_PuntoMinimo.HidePromptOnLeave = true;
            this.txtA1_PuntoMinimo.Location = new System.Drawing.Point(160, 39);
            this.txtA1_PuntoMinimo.Mask = "999999";
            this.txtA1_PuntoMinimo.Name = "txtA1_PuntoMinimo";
            this.txtA1_PuntoMinimo.PromptChar = ' ';
            this.txtA1_PuntoMinimo.Size = new System.Drawing.Size(50, 22);
            this.txtA1_PuntoMinimo.TabIndex = 3;
            // 
            // miLabel17
            // 
            this.miLabel17.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel17.BackColor = System.Drawing.Color.Transparent;
            this.miLabel17.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel17.Location = new System.Drawing.Point(0, 69);
            this.miLabel17.Name = "miLabel17";
            this.miLabel17.Size = new System.Drawing.Size(160, 15);
            this.miLabel17.TabIndex = 4;
            this.miLabel17.Text = "Punto máximo";
            this.miLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtA1_PuntoMaximo
            // 
            this.txtA1_PuntoMaximo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtA1_PuntoMaximo.BackColor = System.Drawing.Color.White;
            this.txtA1_PuntoMaximo.BeepOnError = true;
            this.txtA1_PuntoMaximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtA1_PuntoMaximo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtA1_PuntoMaximo.ForeColor = System.Drawing.Color.Black;
            this.txtA1_PuntoMaximo.HidePromptOnLeave = true;
            this.txtA1_PuntoMaximo.Location = new System.Drawing.Point(160, 66);
            this.txtA1_PuntoMaximo.Mask = "999999";
            this.txtA1_PuntoMaximo.Name = "txtA1_PuntoMaximo";
            this.txtA1_PuntoMaximo.PromptChar = ' ';
            this.txtA1_PuntoMaximo.Size = new System.Drawing.Size(50, 22);
            this.txtA1_PuntoMaximo.TabIndex = 5;
            // 
            // chkA1_PuntoMinimo
            // 
            this.chkA1_PuntoMinimo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkA1_PuntoMinimo.AutoSize = true;
            this.chkA1_PuntoMinimo.BackColor = System.Drawing.Color.Transparent;
            this.chkA1_PuntoMinimo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkA1_PuntoMinimo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkA1_PuntoMinimo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkA1_PuntoMinimo.Location = new System.Drawing.Point(60, 42);
            this.chkA1_PuntoMinimo.Name = "chkA1_PuntoMinimo";
            this.chkA1_PuntoMinimo.Size = new System.Drawing.Size(103, 19);
            this.chkA1_PuntoMinimo.TabIndex = 2;
            this.chkA1_PuntoMinimo.Text = "Punto mínimo";
            this.chkA1_PuntoMinimo.UseVisualStyleBackColor = false;
            this.chkA1_PuntoMinimo.CheckedChanged += new System.EventHandler(this.chkA1_PuntoMinimo_CheckedChanged);
            // 
            // chkA1_PuntoCritico
            // 
            this.chkA1_PuntoCritico.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkA1_PuntoCritico.AutoSize = true;
            this.chkA1_PuntoCritico.BackColor = System.Drawing.Color.Transparent;
            this.chkA1_PuntoCritico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkA1_PuntoCritico.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkA1_PuntoCritico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkA1_PuntoCritico.Location = new System.Drawing.Point(70, 15);
            this.chkA1_PuntoCritico.Name = "chkA1_PuntoCritico";
            this.chkA1_PuntoCritico.Size = new System.Drawing.Size(93, 19);
            this.chkA1_PuntoCritico.TabIndex = 0;
            this.chkA1_PuntoCritico.Text = "Punto crítico";
            this.chkA1_PuntoCritico.UseVisualStyleBackColor = false;
            this.chkA1_PuntoCritico.CheckedChanged += new System.EventHandler(this.chkA1_PuntoCritico_CheckedChanged);
            // 
            // groupAlmacenVeladero
            // 
            this.groupAlmacenVeladero.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupAlmacenVeladero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupAlmacenVeladero.Controls.Add(this.txtA2_PuntoCritico);
            this.groupAlmacenVeladero.Controls.Add(this.txtA2_Stock);
            this.groupAlmacenVeladero.Controls.Add(this.miLabel22);
            this.groupAlmacenVeladero.Controls.Add(this.txtA2_FechaIngreso);
            this.groupAlmacenVeladero.Controls.Add(this.miLabel21);
            this.groupAlmacenVeladero.Controls.Add(this.txtA2_PuntoMinimo);
            this.groupAlmacenVeladero.Controls.Add(this.miLabel20);
            this.groupAlmacenVeladero.Controls.Add(this.txtA2_PuntoMaximo);
            this.groupAlmacenVeladero.Controls.Add(this.chkA2_PuntoMinimo);
            this.groupAlmacenVeladero.Controls.Add(this.chkA2_PuntoCritico);
            this.groupAlmacenVeladero.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupAlmacenVeladero.ForeColor = System.Drawing.Color.Gray;
            this.groupAlmacenVeladero.Location = new System.Drawing.Point(7, 162);
            this.groupAlmacenVeladero.Name = "groupAlmacenVeladero";
            this.groupAlmacenVeladero.Size = new System.Drawing.Size(445, 150);
            this.groupAlmacenVeladero.TabIndex = 1;
            this.groupAlmacenVeladero.TabStop = false;
            this.groupAlmacenVeladero.Text = "Veladero";
            // 
            // txtA2_PuntoCritico
            // 
            this.txtA2_PuntoCritico.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtA2_PuntoCritico.BackColor = System.Drawing.Color.White;
            this.txtA2_PuntoCritico.BeepOnError = true;
            this.txtA2_PuntoCritico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtA2_PuntoCritico.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtA2_PuntoCritico.ForeColor = System.Drawing.Color.Black;
            this.txtA2_PuntoCritico.HidePromptOnLeave = true;
            this.txtA2_PuntoCritico.Location = new System.Drawing.Point(160, 12);
            this.txtA2_PuntoCritico.Mask = "999999";
            this.txtA2_PuntoCritico.Name = "txtA2_PuntoCritico";
            this.txtA2_PuntoCritico.PromptChar = ' ';
            this.txtA2_PuntoCritico.Size = new System.Drawing.Size(50, 22);
            this.txtA2_PuntoCritico.TabIndex = 1;
            // 
            // txtA2_Stock
            // 
            this.txtA2_Stock.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtA2_Stock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtA2_Stock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtA2_Stock.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtA2_Stock.ForeColor = System.Drawing.Color.Black;
            this.txtA2_Stock.Location = new System.Drawing.Point(160, 121);
            this.txtA2_Stock.MaxLength = 6;
            this.txtA2_Stock.Name = "txtA2_Stock";
            this.txtA2_Stock.ReadOnly = true;
            this.txtA2_Stock.Size = new System.Drawing.Size(50, 22);
            this.txtA2_Stock.TabIndex = 9;
            // 
            // miLabel22
            // 
            this.miLabel22.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel22.BackColor = System.Drawing.Color.Transparent;
            this.miLabel22.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel22.Location = new System.Drawing.Point(0, 124);
            this.miLabel22.Name = "miLabel22";
            this.miLabel22.Size = new System.Drawing.Size(160, 15);
            this.miLabel22.TabIndex = 8;
            this.miLabel22.Text = "Stock";
            this.miLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtA2_FechaIngreso
            // 
            this.txtA2_FechaIngreso.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtA2_FechaIngreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtA2_FechaIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtA2_FechaIngreso.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtA2_FechaIngreso.ForeColor = System.Drawing.Color.Black;
            this.txtA2_FechaIngreso.Location = new System.Drawing.Point(160, 93);
            this.txtA2_FechaIngreso.MaxLength = 12;
            this.txtA2_FechaIngreso.Name = "txtA2_FechaIngreso";
            this.txtA2_FechaIngreso.ReadOnly = true;
            this.txtA2_FechaIngreso.Size = new System.Drawing.Size(70, 22);
            this.txtA2_FechaIngreso.TabIndex = 7;
            // 
            // miLabel21
            // 
            this.miLabel21.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel21.BackColor = System.Drawing.Color.Transparent;
            this.miLabel21.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel21.Location = new System.Drawing.Point(0, 96);
            this.miLabel21.Name = "miLabel21";
            this.miLabel21.Size = new System.Drawing.Size(160, 15);
            this.miLabel21.TabIndex = 6;
            this.miLabel21.Text = "Fecha de ingreso";
            this.miLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtA2_PuntoMinimo
            // 
            this.txtA2_PuntoMinimo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtA2_PuntoMinimo.BackColor = System.Drawing.Color.White;
            this.txtA2_PuntoMinimo.BeepOnError = true;
            this.txtA2_PuntoMinimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtA2_PuntoMinimo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtA2_PuntoMinimo.ForeColor = System.Drawing.Color.Black;
            this.txtA2_PuntoMinimo.HidePromptOnLeave = true;
            this.txtA2_PuntoMinimo.Location = new System.Drawing.Point(160, 39);
            this.txtA2_PuntoMinimo.Mask = "999999";
            this.txtA2_PuntoMinimo.Name = "txtA2_PuntoMinimo";
            this.txtA2_PuntoMinimo.PromptChar = ' ';
            this.txtA2_PuntoMinimo.Size = new System.Drawing.Size(50, 22);
            this.txtA2_PuntoMinimo.TabIndex = 3;
            // 
            // miLabel20
            // 
            this.miLabel20.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel20.BackColor = System.Drawing.Color.Transparent;
            this.miLabel20.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel20.Location = new System.Drawing.Point(0, 69);
            this.miLabel20.Name = "miLabel20";
            this.miLabel20.Size = new System.Drawing.Size(160, 15);
            this.miLabel20.TabIndex = 4;
            this.miLabel20.Text = "Punto máximo";
            this.miLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtA2_PuntoMaximo
            // 
            this.txtA2_PuntoMaximo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtA2_PuntoMaximo.BackColor = System.Drawing.Color.White;
            this.txtA2_PuntoMaximo.BeepOnError = true;
            this.txtA2_PuntoMaximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtA2_PuntoMaximo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtA2_PuntoMaximo.ForeColor = System.Drawing.Color.Black;
            this.txtA2_PuntoMaximo.HidePromptOnLeave = true;
            this.txtA2_PuntoMaximo.Location = new System.Drawing.Point(160, 66);
            this.txtA2_PuntoMaximo.Mask = "999999";
            this.txtA2_PuntoMaximo.Name = "txtA2_PuntoMaximo";
            this.txtA2_PuntoMaximo.PromptChar = ' ';
            this.txtA2_PuntoMaximo.Size = new System.Drawing.Size(50, 22);
            this.txtA2_PuntoMaximo.TabIndex = 5;
            // 
            // chkA2_PuntoMinimo
            // 
            this.chkA2_PuntoMinimo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkA2_PuntoMinimo.AutoSize = true;
            this.chkA2_PuntoMinimo.BackColor = System.Drawing.Color.Transparent;
            this.chkA2_PuntoMinimo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkA2_PuntoMinimo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkA2_PuntoMinimo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkA2_PuntoMinimo.Location = new System.Drawing.Point(60, 42);
            this.chkA2_PuntoMinimo.Name = "chkA2_PuntoMinimo";
            this.chkA2_PuntoMinimo.Size = new System.Drawing.Size(103, 19);
            this.chkA2_PuntoMinimo.TabIndex = 2;
            this.chkA2_PuntoMinimo.Text = "Punto mínimo";
            this.chkA2_PuntoMinimo.UseVisualStyleBackColor = false;
            this.chkA2_PuntoMinimo.CheckedChanged += new System.EventHandler(this.chkA2_PuntoMinimo_CheckedChanged);
            // 
            // chkA2_PuntoCritico
            // 
            this.chkA2_PuntoCritico.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkA2_PuntoCritico.AutoSize = true;
            this.chkA2_PuntoCritico.BackColor = System.Drawing.Color.Transparent;
            this.chkA2_PuntoCritico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkA2_PuntoCritico.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkA2_PuntoCritico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.chkA2_PuntoCritico.Location = new System.Drawing.Point(70, 15);
            this.chkA2_PuntoCritico.Name = "chkA2_PuntoCritico";
            this.chkA2_PuntoCritico.Size = new System.Drawing.Size(93, 19);
            this.chkA2_PuntoCritico.TabIndex = 0;
            this.chkA2_PuntoCritico.Text = "Punto crítico";
            this.chkA2_PuntoCritico.UseVisualStyleBackColor = false;
            this.chkA2_PuntoCritico.CheckedChanged += new System.EventHandler(this.chkA2_PuntoCritico_CheckedChanged);
            // 
            // tabContenedor
            // 
            this.tabContenedor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tabContenedor.Controls.Add(this.tabPage1);
            this.tabContenedor.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tabContenedor.Location = new System.Drawing.Point(532, 61);
            this.tabContenedor.Name = "tabContenedor";
            this.tabContenedor.SelectedIndex = 0;
            this.tabContenedor.Size = new System.Drawing.Size(468, 455);
            this.tabContenedor.TabIndex = 43;
            // 
            // FormArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.btnImprimirCodigo);
            this.Controls.Add(this.btnGenerarCodigo);
            this.Controls.Add(this.txtPrecioBruto);
            this.Controls.Add(this.miLabel15);
            this.Controls.Add(this.txtMargen);
            this.Controls.Add(this.miLabel14);
            this.Controls.Add(this.txtUtilidad);
            this.Controls.Add(this.miLabel13);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.txtDenominacionMarca);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.txtDenominacionModelo);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtDenominacionArticulo);
            this.Controls.Add(this.tabContenedor);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.miLabel16);
            this.Controls.Add(this.txtCostoNeto);
            this.Controls.Add(this.miLabel12);
            this.Controls.Add(this.txtBaseIVA);
            this.Controls.Add(this.miLabel11);
            this.Controls.Add(this.cmbAlicuotaIVA);
            this.Controls.Add(this.miLabel10);
            this.Controls.Add(this.txtCostoBruto);
            this.Controls.Add(this.miLabel9);
            this.Controls.Add(this.txtStockGlobal);
            this.Controls.Add(this.miLabel8);
            this.Controls.Add(this.cmbUnidad);
            this.Controls.Add(this.miLabel7);
            this.Controls.Add(this.cmbCriticidad);
            this.Controls.Add(this.miLabel6);
            this.Controls.Add(this.txtCodigoBarras);
            this.Controls.Add(this.miLabel5);
            this.Name = "FormArticulo";
            this.Text = "|";
            this.Load += new System.EventHandler(this.FormArticulo_Load);
            this.Shown += new System.EventHandler(this.FormArticulo_Shown);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.txtCodigoBarras, 0);
            this.Controls.SetChildIndex(this.miLabel6, 0);
            this.Controls.SetChildIndex(this.cmbCriticidad, 0);
            this.Controls.SetChildIndex(this.miLabel7, 0);
            this.Controls.SetChildIndex(this.cmbUnidad, 0);
            this.Controls.SetChildIndex(this.miLabel8, 0);
            this.Controls.SetChildIndex(this.txtStockGlobal, 0);
            this.Controls.SetChildIndex(this.miLabel9, 0);
            this.Controls.SetChildIndex(this.txtCostoBruto, 0);
            this.Controls.SetChildIndex(this.miLabel10, 0);
            this.Controls.SetChildIndex(this.cmbAlicuotaIVA, 0);
            this.Controls.SetChildIndex(this.miLabel11, 0);
            this.Controls.SetChildIndex(this.txtBaseIVA, 0);
            this.Controls.SetChildIndex(this.miLabel12, 0);
            this.Controls.SetChildIndex(this.txtCostoNeto, 0);
            this.Controls.SetChildIndex(this.miLabel16, 0);
            this.Controls.SetChildIndex(this.cmbEstado, 0);
            this.Controls.SetChildIndex(this.tabContenedor, 0);
            this.Controls.SetChildIndex(this.txtDenominacionArticulo, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.txtDenominacionModelo, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.txtDenominacionMarca, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.miLabel13, 0);
            this.Controls.SetChildIndex(this.txtUtilidad, 0);
            this.Controls.SetChildIndex(this.miLabel14, 0);
            this.Controls.SetChildIndex(this.txtMargen, 0);
            this.Controls.SetChildIndex(this.miLabel15, 0);
            this.Controls.SetChildIndex(this.txtPrecioBruto, 0);
            this.Controls.SetChildIndex(this.btnGenerarCodigo, 0);
            this.Controls.SetChildIndex(this.btnImprimirCodigo, 0);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnExcel_Registro, 0);
            this.Controls.SetChildIndex(this.btnPDF_Registro, 0);
            this.Controls.SetChildIndex(this.labelPublicacion, 0);
            this.Controls.SetChildIndex(this.panelLista, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupAlmacenEmpreminsa.ResumeLayout(false);
            this.groupAlmacenEmpreminsa.PerformLayout();
            this.groupAlmacenVeladero.ResumeLayout(false);
            this.groupAlmacenVeladero.PerformLayout();
            this.tabContenedor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Biblioteca.Controles.MiLabel miLabel5;
        private Biblioteca.Controles.MiMaskedTextBox txtCodigoBarras;
        private Biblioteca.Controles.MiComboBox cmbEstado;
        private Biblioteca.Controles.MiLabel miLabel16;
        private Biblioteca.Controles.MiTextBoxRead txtCostoNeto;
        private Biblioteca.Controles.MiLabel miLabel12;
        private Biblioteca.Controles.MiTextBoxRead txtBaseIVA;
        private Biblioteca.Controles.MiLabel miLabel11;
        private Biblioteca.Controles.MiComboBox cmbAlicuotaIVA;
        private Biblioteca.Controles.MiLabel miLabel10;
        private Biblioteca.Controles.MiTextBox txtCostoBruto;
        private Biblioteca.Controles.MiLabel miLabel9;
        private Biblioteca.Controles.MiTextBoxRead txtStockGlobal;
        private Biblioteca.Controles.MiLabel miLabel8;
        private Biblioteca.Controles.MiComboBox cmbUnidad;
        private Biblioteca.Controles.MiLabel miLabel7;
        private Biblioteca.Controles.MiComboBox cmbCriticidad;
        private Biblioteca.Controles.MiLabel miLabel6;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiTextBox txtDenominacionMarca;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiTextBox txtDenominacionModelo;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBox txtDenominacionArticulo;
        private Biblioteca.Controles.MiLabel miLabel13;
        private Biblioteca.Controles.MiLabel miLabel14;
        private Biblioteca.Controles.MiLabel miLabel15;
        private Biblioteca.Controles.MiTextBox txtUtilidad;
        private Biblioteca.Controles.MiTextBox txtMargen;
        private Biblioteca.Controles.MiTextBox txtPrecioBruto;
        private Biblioteca.Controles.MiButtonFind btnGenerarCodigo;
        private Biblioteca.Controles.MiButtonFind btnImprimirCodigo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupAlmacenEmpreminsa;
        private Biblioteca.Controles.MiMaskedTextBox txtA1_PuntoCritico;
        private Biblioteca.Controles.MiTextBoxRead txtA1_Stock;
        private Biblioteca.Controles.MiLabel miLabel19;
        private Biblioteca.Controles.MiTextBoxRead txtA1_FechaIngreso;
        private Biblioteca.Controles.MiLabel miLabel18;
        private Biblioteca.Controles.MiMaskedTextBox txtA1_PuntoMinimo;
        private Biblioteca.Controles.MiLabel miLabel17;
        private Biblioteca.Controles.MiMaskedTextBox txtA1_PuntoMaximo;
        private Biblioteca.Controles.MiCheckBox chkA1_PuntoMinimo;
        private Biblioteca.Controles.MiCheckBox chkA1_PuntoCritico;
        private System.Windows.Forms.GroupBox groupAlmacenVeladero;
        private Biblioteca.Controles.MiMaskedTextBox txtA2_PuntoCritico;
        private Biblioteca.Controles.MiTextBoxRead txtA2_Stock;
        private Biblioteca.Controles.MiLabel miLabel22;
        private Biblioteca.Controles.MiTextBoxRead txtA2_FechaIngreso;
        private Biblioteca.Controles.MiLabel miLabel21;
        private Biblioteca.Controles.MiMaskedTextBox txtA2_PuntoMinimo;
        private Biblioteca.Controles.MiLabel miLabel20;
        private Biblioteca.Controles.MiMaskedTextBox txtA2_PuntoMaximo;
        private Biblioteca.Controles.MiCheckBox chkA2_PuntoMinimo;
        private Biblioteca.Controles.MiCheckBox chkA2_PuntoCritico;
        private System.Windows.Forms.TabControl tabContenedor;
    }
}
