using Biblioteca.Controles;

namespace CapaPresentacion
{
    partial class FormAccesoRecuperacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccesoRecuperacion));
            this.lblUsuario = new Biblioteca.Controles.MiLabel();
            this.txtDocumento = new Biblioteca.Controles.MiMaskedTextBox();
            this.lblCorreo = new Biblioteca.Controles.MiLabel();
            this.txtCorreo = new Biblioteca.Controles.MiTextBox();
            this.lblCaptcha = new Biblioteca.Controles.MiLabel();
            this.txtCaptcha = new Biblioteca.Controles.MiTextBox();
            this.pictureCaptcha = new System.Windows.Forms.PictureBox();
            this.btnRefreshCaptcha = new Biblioteca.Controles.MiButtonRefresh();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "Recuperación de Contraseña";
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Recuperar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSalir.TabIndex = 9;
            // 
            // progressBarProceso
            // 
            this.progressBarProceso.Visible = false;
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.Visible = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 9F);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblUsuario.Location = new System.Drawing.Point(137, 108);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(53, 18);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "DNI";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDocumento.BackColor = System.Drawing.Color.White;
            this.txtDocumento.BeepOnError = true;
            this.txtDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocumento.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDocumento.ForeColor = System.Drawing.Color.Black;
            this.txtDocumento.HidePromptOnLeave = true;
            this.txtDocumento.Location = new System.Drawing.Point(190, 106);
            this.txtDocumento.Mask = "99999999";
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.PromptChar = ' ';
            this.txtDocumento.Size = new System.Drawing.Size(74, 21);
            this.txtDocumento.TabIndex = 2;
            // 
            // lblCorreo
            // 
            this.lblCorreo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCorreo.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreo.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblCorreo.Location = new System.Drawing.Point(137, 135);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(53, 18);
            this.lblCorreo.TabIndex = 3;
            this.lblCorreo.Text = "Correo";
            this.lblCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCorreo.BackColor = System.Drawing.Color.White;
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtCorreo.Font = new System.Drawing.Font("Arial", 8F);
            this.txtCorreo.ForeColor = System.Drawing.Color.Black;
            this.txtCorreo.Location = new System.Drawing.Point(190, 133);
            this.txtCorreo.MaxLength = 45;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(153, 20);
            this.txtCorreo.TabIndex = 4;
            // 
            // lblCaptcha
            // 
            this.lblCaptcha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCaptcha.BackColor = System.Drawing.Color.Transparent;
            this.lblCaptcha.Font = new System.Drawing.Font("Arial", 9F);
            this.lblCaptcha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblCaptcha.Location = new System.Drawing.Point(137, 161);
            this.lblCaptcha.Name = "lblCaptcha";
            this.lblCaptcha.Size = new System.Drawing.Size(53, 18);
            this.lblCaptcha.TabIndex = 5;
            this.lblCaptcha.Text = "Captcha";
            this.lblCaptcha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCaptcha
            // 
            this.txtCaptcha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCaptcha.BackColor = System.Drawing.Color.White;
            this.txtCaptcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCaptcha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCaptcha.Font = new System.Drawing.Font("Arial", 8F);
            this.txtCaptcha.ForeColor = System.Drawing.Color.Black;
            this.txtCaptcha.Location = new System.Drawing.Point(190, 159);
            this.txtCaptcha.MaxLength = 5;
            this.txtCaptcha.Name = "txtCaptcha";
            this.txtCaptcha.Size = new System.Drawing.Size(50, 20);
            this.txtCaptcha.TabIndex = 6;
            // 
            // pictureCaptcha
            // 
            this.pictureCaptcha.BackColor = System.Drawing.Color.LightGray;
            this.pictureCaptcha.Location = new System.Drawing.Point(246, 159);
            this.pictureCaptcha.Name = "pictureCaptcha";
            this.pictureCaptcha.Size = new System.Drawing.Size(73, 20);
            this.pictureCaptcha.TabIndex = 24;
            this.pictureCaptcha.TabStop = false;
            this.pictureCaptcha.Click += new System.EventHandler(this.pictureCaptcha_Click);
            // 
            // btnRefreshCaptcha
            // 
            this.btnRefreshCaptcha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRefreshCaptcha.BackColor = System.Drawing.Color.White;
            this.btnRefreshCaptcha.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefreshCaptcha.BackgroundImage")));
            this.btnRefreshCaptcha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefreshCaptcha.FlatAppearance.BorderSize = 0;
            this.btnRefreshCaptcha.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnRefreshCaptcha.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRefreshCaptcha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshCaptcha.ForeColor = System.Drawing.Color.Black;
            this.btnRefreshCaptcha.Location = new System.Drawing.Point(321, 158);
            this.btnRefreshCaptcha.Name = "btnRefreshCaptcha";
            this.btnRefreshCaptcha.Size = new System.Drawing.Size(22, 22);
            this.btnRefreshCaptcha.TabIndex = 10;
            this.btnRefreshCaptcha.UseVisualStyleBackColor = false;
            this.btnRefreshCaptcha.Click += new System.EventHandler(this.btnRefreshCaptcha_Click);
            // 
            // FormAccesoRecuperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(350, 226);
            this.Controls.Add(this.btnRefreshCaptcha);
            this.Controls.Add(this.pictureCaptcha);
            this.Controls.Add(this.txtCaptcha);
            this.Controls.Add(this.lblCaptcha);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.lblUsuario);
            this.Name = "FormAccesoRecuperacion";
            this.Load += new System.EventHandler(this.FormAccesoRecuperacion_Load);
            this.Shown += new System.EventHandler(this.FormAccesoRecuperacion_Shown);
            this.Controls.SetChildIndex(this.lblLeyenda, 0);
            this.Controls.SetChildIndex(this.progressBarProceso, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.lblUsuario, 0);
            this.Controls.SetChildIndex(this.txtDocumento, 0);
            this.Controls.SetChildIndex(this.lblCorreo, 0);
            this.Controls.SetChildIndex(this.txtCorreo, 0);
            this.Controls.SetChildIndex(this.lblCaptcha, 0);
            this.Controls.SetChildIndex(this.txtCaptcha, 0);
            this.Controls.SetChildIndex(this.pictureCaptcha, 0);
            this.Controls.SetChildIndex(this.btnRefreshCaptcha, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCaptcha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MiLabel lblUsuario;
        private MiMaskedTextBox txtDocumento;
        private MiLabel lblCorreo;
        private MiTextBox txtCorreo;
        private MiLabel lblCaptcha;
        private MiTextBox txtCaptcha;
        private System.Windows.Forms.PictureBox pictureCaptcha;
        private MiButtonRefresh btnRefreshCaptcha;
    }
}
