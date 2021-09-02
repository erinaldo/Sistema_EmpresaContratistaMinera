using Biblioteca.Controles;

namespace CapaPresentacion
{
    partial class FormAcceso
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
                nMonitor.Dispose();
                nUsuario.Dispose();
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
            this.linkRecuperarContrasenia = new System.Windows.Forms.LinkLabel();
            this.txtContrasenia = new Biblioteca.Controles.MiTextBox();
            this.lblContrasenia = new Biblioteca.Controles.MiLabel();
            this.txtUsuario = new Biblioteca.Controles.MiMaskedTextBox();
            this.lblDNI = new Biblioteca.Controles.MiLabel();
            this.lblVersionCompilacion = new Biblioteca.Controles.MiLabel();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "Acceso al Sistema";
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Ingresar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // progressBarProceso
            // 
            this.progressBarProceso.TabIndex = 7;
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.TabIndex = 6;
            // 
            // linkRecuperarContrasenia
            // 
            this.linkRecuperarContrasenia.ActiveLinkColor = System.Drawing.Color.Maroon;
            this.linkRecuperarContrasenia.Location = new System.Drawing.Point(140, 170);
            this.linkRecuperarContrasenia.Name = "linkRecuperarContrasenia";
            this.linkRecuperarContrasenia.Size = new System.Drawing.Size(203, 13);
            this.linkRecuperarContrasenia.TabIndex = 10;
            this.linkRecuperarContrasenia.TabStop = true;
            this.linkRecuperarContrasenia.Text = "¿Olvido Su Contraseña?";
            this.linkRecuperarContrasenia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkRecuperarContrasenia.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRecuperarContrasenia_LinkClicked);
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtContrasenia.BackColor = System.Drawing.Color.White;
            this.txtContrasenia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContrasenia.Font = new System.Drawing.Font("Arial", 9F);
            this.txtContrasenia.ForeColor = System.Drawing.Color.Black;
            this.txtContrasenia.Location = new System.Drawing.Point(255, 137);
            this.txtContrasenia.MaxLength = 4;
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.Size = new System.Drawing.Size(88, 21);
            this.txtContrasenia.TabIndex = 5;
            this.txtContrasenia.UseSystemPasswordChar = true;
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblContrasenia.BackColor = System.Drawing.Color.Transparent;
            this.lblContrasenia.Font = new System.Drawing.Font("Arial", 9F);
            this.lblContrasenia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblContrasenia.Location = new System.Drawing.Point(139, 139);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(116, 18);
            this.lblContrasenia.TabIndex = 4;
            this.lblContrasenia.Text = "Contraseña";
            this.lblContrasenia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.BeepOnError = true;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Arial", 9F);
            this.txtUsuario.ForeColor = System.Drawing.Color.Black;
            this.txtUsuario.HidePromptOnLeave = true;
            this.txtUsuario.Location = new System.Drawing.Point(255, 110);
            this.txtUsuario.Mask = "99999999";
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PromptChar = ' ';
            this.txtUsuario.Size = new System.Drawing.Size(88, 21);
            this.txtUsuario.TabIndex = 3;
            // 
            // lblDNI
            // 
            this.lblDNI.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDNI.BackColor = System.Drawing.Color.Transparent;
            this.lblDNI.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDNI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblDNI.Location = new System.Drawing.Point(139, 112);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(116, 18);
            this.lblDNI.TabIndex = 2;
            this.lblDNI.Text = "Nro. de Documento";
            this.lblDNI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVersionCompilacion
            // 
            this.lblVersionCompilacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblVersionCompilacion.AutoSize = true;
            this.lblVersionCompilacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.lblVersionCompilacion.Font = new System.Drawing.Font("Arial", 7F);
            this.lblVersionCompilacion.ForeColor = System.Drawing.Color.Black;
            this.lblVersionCompilacion.Location = new System.Drawing.Point(298, 34);
            this.lblVersionCompilacion.Name = "lblVersionCompilacion";
            this.lblVersionCompilacion.Size = new System.Drawing.Size(51, 13);
            this.lblVersionCompilacion.TabIndex = 1;
            this.lblVersionCompilacion.Text = "v1.10050";
            this.lblVersionCompilacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(350, 226);
            this.Controls.Add(this.lblVersionCompilacion);
            this.Controls.Add(this.txtContrasenia);
            this.Controls.Add(this.lblContrasenia);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.linkRecuperarContrasenia);
            this.Name = "FormAcceso";
            this.Shown += new System.EventHandler(this.FormAcceso_Shown);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.lblLeyenda, 0);
            this.Controls.SetChildIndex(this.progressBarProceso, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.linkRecuperarContrasenia, 0);
            this.Controls.SetChildIndex(this.lblDNI, 0);
            this.Controls.SetChildIndex(this.txtUsuario, 0);
            this.Controls.SetChildIndex(this.lblContrasenia, 0);
            this.Controls.SetChildIndex(this.txtContrasenia, 0);
            this.Controls.SetChildIndex(this.lblVersionCompilacion, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkRecuperarContrasenia;
        private MiTextBox txtContrasenia;
        private MiLabel lblContrasenia;
        private MiMaskedTextBox txtUsuario;
        private MiLabel lblDNI;
        public MiLabel lblVersionCompilacion;
    }
}
