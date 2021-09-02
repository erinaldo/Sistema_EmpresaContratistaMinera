namespace CapaPresentacion
{
    partial class FormCentroCosto
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
                nCentroCosto.Dispose();
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
            this.cmbDeposito = new Biblioteca.Controles.MiComboBox();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.miLabel1 = new Biblioteca.Controles.MiLabel();
            this.txtDenominacion = new Biblioteca.Controles.MiTextBox();
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
            this.lblTituloLista.Text = "Lista de Centros de Costo";
            // 
            // cmbFiltroLista1
            // 
            this.cmbFiltroLista1.Enabled = false;
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
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(273, 36);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(49, 14);
            this.lblCatalagoTitulo3.Text = "Depósito";
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Enabled = false;
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(748, 36);
            this.lblCatalagoTitulo4.Visible = false;
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Enabled = false;
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(802, 36);
            this.lblCatalagoTitulo5.Visible = false;
            // 
            // panelLista
            // 
            this.panelLista.TabIndex = 10;
            // 
            // lblCatalagoTitulo6
            // 
            this.lblCatalagoTitulo6.Enabled = false;
            this.lblCatalagoTitulo6.Location = new System.Drawing.Point(849, 36);
            this.lblCatalagoTitulo6.Visible = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Centros de Costo";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 9;
            // 
            // cmbDeposito
            // 
            this.cmbDeposito.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmbDeposito.BackColor = System.Drawing.Color.White;
            this.cmbDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeposito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDeposito.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbDeposito.ForeColor = System.Drawing.Color.Black;
            this.cmbDeposito.FormattingEnabled = true;
            this.cmbDeposito.Items.AddRange(new object[] {
            "EMPREMINSA",
            "VELADERO"});
            this.cmbDeposito.Location = new System.Drawing.Point(160, 88);
            this.cmbDeposito.Margin = new System.Windows.Forms.Padding(1);
            this.cmbDeposito.Name = "cmbDeposito";
            this.cmbDeposito.Size = new System.Drawing.Size(129, 22);
            this.cmbDeposito.Sorted = true;
            this.cmbDeposito.TabIndex = 14;
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
            this.miLabel2.Text = "Deposito";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // miLabel1
            // 
            this.miLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel1.BackColor = System.Drawing.Color.Transparent;
            this.miLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel1.Location = new System.Drawing.Point(0, 63);
            this.miLabel1.Name = "miLabel1";
            this.miLabel1.Size = new System.Drawing.Size(160, 15);
            this.miLabel1.TabIndex = 11;
            this.miLabel1.Text = "Denominación";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenominacion
            // 
            this.txtDenominacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDenominacion.BackColor = System.Drawing.Color.White;
            this.txtDenominacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDenominacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDenominacion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtDenominacion.ForeColor = System.Drawing.Color.Black;
            this.txtDenominacion.Location = new System.Drawing.Point(160, 61);
            this.txtDenominacion.MaxLength = 25;
            this.txtDenominacion.Name = "txtDenominacion";
            this.txtDenominacion.Size = new System.Drawing.Size(240, 22);
            this.txtDenominacion.TabIndex = 12;
            // 
            // FormCentroCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.cmbDeposito);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.miLabel1);
            this.Controls.Add(this.txtDenominacion);
            this.Name = "FormCentroCosto";
            this.Text = "Centros de Costo";
            this.Load += new System.EventHandler(this.FormCentroCosto_Load);
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
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.cmbDeposito, 0);
            this.panelLista.ResumeLayout(false);
            this.panelLista.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Biblioteca.Controles.MiComboBox cmbDeposito;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBox txtDenominacion;
    }
}
