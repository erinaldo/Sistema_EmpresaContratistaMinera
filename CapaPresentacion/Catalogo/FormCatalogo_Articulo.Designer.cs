namespace CapaPresentacion.Catalogo
{
    partial class FormCatalogo_Articulo
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
            this.lblCatalagoTitulo5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCatalagoTitulo4
            // 
            this.lblCatalagoTitulo4.Location = new System.Drawing.Point(406, 78);
            this.lblCatalagoTitulo4.Size = new System.Drawing.Size(46, 14);
            this.lblCatalagoTitulo4.Text = "Stk. Vel.";
            // 
            // lblCatalagoTitulo3
            // 
            this.lblCatalagoTitulo3.Location = new System.Drawing.Point(343, 78);
            this.lblCatalagoTitulo3.Size = new System.Drawing.Size(51, 14);
            this.lblCatalagoTitulo3.Text = "Stk. Emp.";
            // 
            // lblCatalagoTitulo2
            // 
            this.lblCatalagoTitulo2.Location = new System.Drawing.Point(63, 78);
            this.lblCatalagoTitulo2.Size = new System.Drawing.Size(74, 14);
            this.lblCatalagoTitulo2.Text = "Denominación";
            // 
            // lblCatalagoTitulo1
            // 
            this.lblCatalagoTitulo1.Size = new System.Drawing.Size(16, 14);
            this.lblCatalagoTitulo1.Text = "ID";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "Catálogo de Artículos";
            // 
            // lblCatalagoTitulo5
            // 
            this.lblCatalagoTitulo5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCatalagoTitulo5.AutoSize = true;
            this.lblCatalagoTitulo5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblCatalagoTitulo5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatalagoTitulo5.ForeColor = System.Drawing.Color.White;
            this.lblCatalagoTitulo5.Location = new System.Drawing.Point(469, 78);
            this.lblCatalagoTitulo5.Name = "lblCatalagoTitulo5";
            this.lblCatalagoTitulo5.Size = new System.Drawing.Size(40, 14);
            this.lblCatalagoTitulo5.TabIndex = 128;
            this.lblCatalagoTitulo5.Text = "Estado";
            this.lblCatalagoTitulo5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormCatalogo_Articulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(622, 314);
            this.Controls.Add(this.lblCatalagoTitulo5);
            this.Name = "FormCatalogo_Articulo";
            this.Text = "Catálogo de Artículos";
            this.Load += new System.EventHandler(this.FormCatalogo_Articulo_Load);
            this.Controls.SetChildIndex(this.pictureTop1, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.pictureBottom, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.pictureLeft, 0);
            this.Controls.SetChildIndex(this.pictureRight, 0);
            this.Controls.SetChildIndex(this.cmbFiltroLista1, 0);
            this.Controls.SetChildIndex(this.cmbFiltroLista2, 0);
            this.Controls.SetChildIndex(this.lstCatalogo, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo1, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo2, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo3, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo4, 0);
            this.Controls.SetChildIndex(this.pkrFiltroListaDesde, 0);
            this.Controls.SetChildIndex(this.pkrFiltroListaHasta, 0);
            this.Controls.SetChildIndex(this.txtFiltroLista, 0);
            this.Controls.SetChildIndex(this.lblCatalagoTitulo5, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lblCatalagoTitulo5;
    }
}
