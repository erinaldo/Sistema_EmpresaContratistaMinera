namespace CapaPresentacion
{
    partial class FormPlanDeCuenta
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
                nCuentaContable.Dispose();
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
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtCodigo = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
            this.cmbTipoCuenta = new Biblioteca.Controles.MiComboBox();
            this.miLabel3 = new Biblioteca.Controles.MiLabel();
            this.miLabel5 = new Biblioteca.Controles.MiLabel();
            this.treePlanCuenta = new System.Windows.Forms.TreeView();
            this.txtSaldo = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel4 = new Biblioteca.Controles.MiLabel();
            this.btnExportarPlanDeCuenta = new System.Windows.Forms.Button();
            this.panelLista.SuspendLayout();
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
            this.btnAnular.Enabled = false;
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
            this.lblTituloLista.Text = "Lista de Cuentas Contables";
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
            this.lblCatalagoTitulo1.Size = new System.Drawing.Size(40, 14);
            this.lblCatalagoTitulo1.Text = "Código";
            // 
            // lblCatalagoTitulo2
            // 
            this.lblCatalagoTitulo2.Location = new System.Drawing.Point(63, 36);
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(260, 36);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(79, 14);
            this.lblCatalagoTitulo3.Text = "Tipo de Cuenta";
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(686, 36);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(34, 14);
            this.lblCatalagoTitulo4.Text = "Saldo";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Enabled = false;
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(800, 36);
            this.lblCatalagoTitulo5.Visible = false;
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Enabled = false;
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(849, 36);
            this.lblCatalagoTitulo6.Visible = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Plan de Cuentas";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // miLabel1
            // 
            this.miLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel1.BackColor = System.Drawing.Color.Transparent;
            this.miLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel1.Location = new System.Drawing.Point(0, 63);
            this.miLabel1.Name = "miLabel1";
            this.miLabel1.Size = new System.Drawing.Size(160, 18);
            this.miLabel1.TabIndex = 11;
            this.miLabel1.Text = "Código";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtCodigo.ForeColor = System.Drawing.Color.Black;
            this.txtCodigo.Location = new System.Drawing.Point(160, 61);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(48, 22);
            this.txtCodigo.TabIndex = 12;
            // 
            // miLabel2
            // 
            this.miLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel2.BackColor = System.Drawing.Color.Transparent;
            this.miLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel2.Location = new System.Drawing.Point(0, 90);
            this.miLabel2.Name = "miLabel2";
            this.miLabel2.Size = new System.Drawing.Size(160, 15);
            this.miLabel2.TabIndex = 13;
            this.miLabel2.Text = "Denominación";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenominacion
            // 
            this.txtDenominacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDenominacion.BackColor = System.Drawing.Color.White;
            this.txtDenominacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDenominacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDenominacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtDenominacion.ForeColor = System.Drawing.Color.Black;
            this.txtDenominacion.Location = new System.Drawing.Point(160, 88);
            this.txtDenominacion.MaxLength = 25;
            this.txtDenominacion.Name = "txtDenominacion";
            this.txtDenominacion.Size = new System.Drawing.Size(240, 22);
            this.txtDenominacion.TabIndex = 14;
            // 
            // cmbTipoCuenta
            // 
            this.cmbTipoCuenta.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbTipoCuenta.BackColor = System.Drawing.Color.White;
            this.cmbTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoCuenta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbTipoCuenta.ForeColor = System.Drawing.Color.Black;
            this.cmbTipoCuenta.FormattingEnabled = true;
            this.cmbTipoCuenta.Items.AddRange(new object[] {
            "111100 ACTIVO CORRIENTE > DISPONIBILIDADES > CAJAS",
            "111200 ACTIVO CORRIENTE > DISPONIBILIDADES > BANCOS",
            "111300 ACTIVO CORRIENTE > DISPONIBILIDADES > TARJETAS",
            "111400 ACTIVO CORRIENTE > DISPONIBILIDADES > VALORES A DEPOSITAR",
            "112000 ACTIVO CORRIENTE > INVERSIONES",
            "113000 ACTIVO CORRIENTE > CREDITOS POR VENTAS",
            "114000 ACTIVO CORRIENTE > OTROS CREDITOS",
            "115000 ACTIVO CORRIENTE > BIENES DE CAMBIO",
            "116000 ACTIVO CORRIENTE > BIENES DE USO",
            "117000 ACTIVO CORRIENTE > OTROS ACTIVOS",
            "121000 ACTIVO NO CORRIENTE > INVERSIONES",
            "122000 ACTIVO NO CORRIENTE > CREDITOS POR VENTAS",
            "123000 ACTIVO NO CORRIENTE > OTROS CREDITOS",
            "124000 ACTIVO NO CORRIENTE > BIENES DE CAMBIO",
            "125000 ACTIVO NO CORRIENTE > BIENES DE USO",
            "126000 ACTIVO NO CORRIENTE > OTROS ACTIVOS",
            "211000 PASIVO CORRIENTE > DEUDAS COMERCIALES",
            "212000 PASIVO CORRIENTE > DEUDAS FINANCIERAS",
            "213000 PASIVO CORRIENTE > DEUDAS FISCALES",
            "214000 PASIVO CORRIENTE > DEUDAS SOCIALES",
            "215000 PASIVO CORRIENTE > OTRAS DEUDAS",
            "221000 PASIVO NO CORRIENTE > DEUDAS COMERCIALES",
            "222000 PASIVO NO CORRIENTE > DEUDAS FINANCIERAS",
            "223000 PASIVO NO CORRIENTE > DEUDAS FISCALES",
            "224000 PASIVO NO CORRIENTE > DEUDAS SOCIALES",
            "225000 PASIVO NO CORRIENTE > OTRAS DEUDAS",
            "310000 PATRIMONIO NETO > CAPITAL",
            "320000 PATRIMONIO NETO > RESERVAS",
            "330000 PATRIMONIO NETO > RESULTADOS NO ASIGNADOS",
            "410000 INGRESOS > INGRESO POR VENTAS",
            "420000 INGRESOS > OTROS INGRESOS ",
            "510000 EGRESOS > COSTO DE VENTAS",
            "520000 EGRESOS > COSTO DE NOMINA",
            "530000 EGRESOS > OTROS EGRESOS"});
            this.cmbTipoCuenta.Location = new System.Drawing.Point(160, 115);
            this.cmbTipoCuenta.Margin = new System.Windows.Forms.Padding(1);
            this.cmbTipoCuenta.Name = "cmbTipoCuenta";
            this.cmbTipoCuenta.Size = new System.Drawing.Size(420, 22);
            this.cmbTipoCuenta.Sorted = true;
            this.cmbTipoCuenta.TabIndex = 16;
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
            this.miLabel3.TabIndex = 15;
            this.miLabel3.Text = "Tipo de cuenta";
            this.miLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel5
            // 
            this.miLabel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel5.BackColor = System.Drawing.Color.Transparent;
            this.miLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel5.Location = new System.Drawing.Point(0, 171);
            this.miLabel5.Name = "miLabel5";
            this.miLabel5.Size = new System.Drawing.Size(160, 15);
            this.miLabel5.TabIndex = 19;
            this.miLabel5.Text = "Plan de Cuentas";
            this.miLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // treePlanCuenta
            // 
            this.treePlanCuenta.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.treePlanCuenta.BackColor = System.Drawing.Color.White;
            this.treePlanCuenta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treePlanCuenta.ForeColor = System.Drawing.Color.Black;
            this.treePlanCuenta.Location = new System.Drawing.Point(160, 169);
            this.treePlanCuenta.Name = "treePlanCuenta";
            this.treePlanCuenta.Size = new System.Drawing.Size(840, 300);
            this.treePlanCuenta.TabIndex = 20;
            this.treePlanCuenta.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treePlanCuenta_AfterSelect);
            // 
            // txtSaldo
            // 
            this.txtSaldo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaldo.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtSaldo.ForeColor = System.Drawing.Color.Black;
            this.txtSaldo.Location = new System.Drawing.Point(160, 142);
            this.txtSaldo.MaxLength = 12;
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(85, 22);
            this.txtSaldo.TabIndex = 18;
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
            this.miLabel4.TabIndex = 17;
            this.miLabel4.Text = "Saldo a la fecha $";
            this.miLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExportarPlanDeCuenta
            // 
            this.btnExportarPlanDeCuenta.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExportarPlanDeCuenta.Location = new System.Drawing.Point(160, 472);
            this.btnExportarPlanDeCuenta.Name = "btnExportarPlanDeCuenta";
            this.btnExportarPlanDeCuenta.Size = new System.Drawing.Size(175, 23);
            this.btnExportarPlanDeCuenta.TabIndex = 21;
            this.btnExportarPlanDeCuenta.Text = "Exportar Plan de Cuentas a PDF";
            this.btnExportarPlanDeCuenta.UseVisualStyleBackColor = true;
            this.btnExportarPlanDeCuenta.Click += new System.EventHandler(this.btnExportarPlanDeCuenta_Click);
            // 
            // FormPlanDeCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.btnExportarPlanDeCuenta);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.miLabel4);
            this.Controls.Add(this.treePlanCuenta);
            this.Controls.Add(this.miLabel5);
            this.Controls.Add(this.cmbTipoCuenta);
            this.Controls.Add(this.miLabel3);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtDenominacion);
            this.Name = "FormPlanDeCuenta";
            this.Text = "Plan de Cuentas";
            this.Load += new System.EventHandler(this.FormPlanDeCuenta_Load);
            this.Shown += new System.EventHandler(this.FormPlanDeCuenta_Shown);
            this.Controls.SetChildIndex(this.btnAnular, 0);
            this.Controls.SetChildIndex(this.txtDenominacion, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.miLabel3, 0);
            this.Controls.SetChildIndex(this.cmbTipoCuenta, 0);
            this.Controls.SetChildIndex(this.miLabel5, 0);
            this.Controls.SetChildIndex(this.labelPublicacion, 0);
            this.Controls.SetChildIndex(this.btnNuevo, 0);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnExcel_Registro, 0);
            this.Controls.SetChildIndex(this.btnPDF_Registro, 0);
            this.Controls.SetChildIndex(this.panelLista, 0);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.treePlanCuenta, 0);
            this.Controls.SetChildIndex(this.miLabel4, 0);
            this.Controls.SetChildIndex(this.txtSaldo, 0);
            this.Controls.SetChildIndex(this.btnExportarPlanDeCuenta, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBoxRead txtCodigo;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiTextBox txtDenominacion;
        private Biblioteca.Controles.MiComboBox cmbTipoCuenta;
        private Biblioteca.Controles.MiLabel miLabel3;
        private Biblioteca.Controles.MiLabel miLabel5;
        private System.Windows.Forms.TreeView treePlanCuenta;
        private Biblioteca.Controles.MiTextBoxRead txtSaldo;
        private Biblioteca.Controles.MiLabel miLabel4;
        private System.Windows.Forms.Button btnExportarPlanDeCuenta;
    }
}
