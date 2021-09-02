namespace Actualizador
{
    partial class FormPublicacionActualizacion
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
            this.txtVersionActual = new Biblioteca.Controles.MiTextBoxRead();
            this.miLabel2 = new Biblioteca.Controles.MiLabel();
            this.txtClaveAcesso = new Biblioteca.Controles.MiTextBox();
            this.btnPublicar = new Biblioteca.Controles.MiButtonBase();
            this.lblLeyenda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.Location = new System.Drawing.Point(194, 113);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitulo.Size = new System.Drawing.Size(264, 30);
            this.lblTitulo.Text = "Publicación de Actualización";
            // 
            // pictureBottom
            // 
            this.pictureBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBottom.Location = new System.Drawing.Point(0, 108);
            this.pictureBottom.Size = new System.Drawing.Size(264, 30);
            // 
            // pictureRight
            // 
            this.pictureRight.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureRight.Location = new System.Drawing.Point(263, 0);
            this.pictureRight.Size = new System.Drawing.Size(0, 138);
            // 
            // pictureLeft
            // 
            this.pictureLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureLeft.Size = new System.Drawing.Size(0, 138);
            // 
            // pictureTop1
            // 
            this.pictureTop1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureTop1.Size = new System.Drawing.Size(264, 6);
            // 
            // miLabel1
            // 
            this.miLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel1.BackColor = System.Drawing.Color.Transparent;
            this.miLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel1.Location = new System.Drawing.Point(0, 51);
            this.miLabel1.Name = "miLabel1";
            this.miLabel1.Size = new System.Drawing.Size(160, 15);
            this.miLabel1.TabIndex = 15;
            this.miLabel1.Text = "Versión actual del Sistema";
            this.miLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVersionActual
            // 
            this.txtVersionActual.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtVersionActual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtVersionActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVersionActual.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtVersionActual.ForeColor = System.Drawing.Color.Black;
            this.txtVersionActual.Location = new System.Drawing.Point(160, 48);
            this.txtVersionActual.Name = "txtVersionActual";
            this.txtVersionActual.ReadOnly = true;
            this.txtVersionActual.Size = new System.Drawing.Size(100, 22);
            this.txtVersionActual.TabIndex = 16;
            // 
            // miLabel2
            // 
            this.miLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.miLabel2.BackColor = System.Drawing.Color.Transparent;
            this.miLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.miLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.miLabel2.Location = new System.Drawing.Point(0, 78);
            this.miLabel2.Name = "miLabel2";
            this.miLabel2.Size = new System.Drawing.Size(160, 15);
            this.miLabel2.TabIndex = 17;
            this.miLabel2.Text = "Clave de Acceso";
            this.miLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtClaveAcesso
            // 
            this.txtClaveAcesso.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtClaveAcesso.BackColor = System.Drawing.Color.White;
            this.txtClaveAcesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClaveAcesso.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtClaveAcesso.ForeColor = System.Drawing.Color.Black;
            this.txtClaveAcesso.Location = new System.Drawing.Point(160, 75);
            this.txtClaveAcesso.Name = "txtClaveAcesso";
            this.txtClaveAcesso.PasswordChar = '*';
            this.txtClaveAcesso.Size = new System.Drawing.Size(100, 22);
            this.txtClaveAcesso.TabIndex = 18;
            this.txtClaveAcesso.Text = "Sergito1";
            // 
            // btnPublicar
            // 
            this.btnPublicar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPublicar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPublicar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPublicar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPublicar.FlatAppearance.BorderSize = 0;
            this.btnPublicar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPublicar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPublicar.Font = new System.Drawing.Font("Arial", 7F);
            this.btnPublicar.ForeColor = System.Drawing.Color.Black;
            this.btnPublicar.Location = new System.Drawing.Point(126, 113);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPublicar.Size = new System.Drawing.Size(65, 20);
            this.btnPublicar.TabIndex = 19;
            this.btnPublicar.Text = "Publicar";
            this.btnPublicar.UseVisualStyleBackColor = false;
            this.btnPublicar.Click += new System.EventHandler(this.btnPublicar_Click);
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeyenda.AutoSize = true;
            this.lblLeyenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblLeyenda.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeyenda.ForeColor = System.Drawing.Color.White;
            this.lblLeyenda.Location = new System.Drawing.Point(9, 116);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Size = new System.Drawing.Size(111, 14);
            this.lblLeyenda.TabIndex = 20;
            this.lblLeyenda.Text = "Procesando... Espere";
            this.lblLeyenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeyenda.Visible = false;
            // 
            // FormPublicacionActualizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(264, 138);
            this.Controls.Add(this.lblLeyenda);
            this.Controls.Add(this.btnPublicar);
            this.Controls.Add(this.txtClaveAcesso);
            this.Controls.Add(this.miLabel2);
            this.Controls.Add(this.txtVersionActual);
            this.Controls.Add(this.miLabel1);
            this.Name = "FormPublicacionActualizacion";
            this.ShowInTaskbar = true;
            this.Text = "Publicación de Actualización";
            this.Load += new System.EventHandler(this.FormPublicacionActualizacion_Load);
            this.Controls.SetChildIndex(this.pictureTop1, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.pictureBottom, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.pictureLeft, 0);
            this.Controls.SetChildIndex(this.pictureRight, 0);
            this.Controls.SetChildIndex(this.miLabel1, 0);
            this.Controls.SetChildIndex(this.txtVersionActual, 0);
            this.Controls.SetChildIndex(this.miLabel2, 0);
            this.Controls.SetChildIndex(this.txtClaveAcesso, 0);
            this.Controls.SetChildIndex(this.btnPublicar, 0);
            this.Controls.SetChildIndex(this.lblLeyenda, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Biblioteca.Controles.MiLabel miLabel1;
        private Biblioteca.Controles.MiTextBoxRead txtVersionActual;
        private Biblioteca.Controles.MiLabel miLabel2;
        private Biblioteca.Controles.MiTextBox txtClaveAcesso;
        public Biblioteca.Controles.MiButtonBase btnPublicar;
        public System.Windows.Forms.Label lblLeyenda;
    }
}
