using Biblioteca.Controles;

namespace Biblioteca.Formularios
{
    partial class FormBase
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
            this.pictureTop1 = new System.Windows.Forms.PictureBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.pictureBottom = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new Biblioteca.Controles.MiButtonBase();
            this.labelUsuario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureTop1
            // 
            this.pictureTop1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureTop1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.pictureTop1.Location = new System.Drawing.Point(0, -10);
            this.pictureTop1.Name = "pictureTop1";
            this.pictureTop1.Size = new System.Drawing.Size(1006, 20);
            this.pictureTop1.TabIndex = 1;
            this.pictureTop1.TabStop = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.labelTitulo.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(0, 9);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(1006, 40);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Titulo De Formulario";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBottom
            // 
            this.pictureBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.pictureBottom.Location = new System.Drawing.Point(0, 651);
            this.pictureBottom.Name = "pictureBottom";
            this.pictureBottom.Size = new System.Drawing.Size(1006, 36);
            this.pictureBottom.TabIndex = 3;
            this.pictureBottom.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCerrar.ForeColor = System.Drawing.Color.Black;
            this.btnCerrar.Location = new System.Drawing.Point(925, 657);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // labelUsuario
            // 
            this.labelUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.labelUsuario.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.ForeColor = System.Drawing.Color.White;
            this.labelUsuario.Location = new System.Drawing.Point(678, 14);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(325, 15);
            this.labelUsuario.TabIndex = 2;
            this.labelUsuario.Text = "Sesión del administrador: SERGIO REGALADO ALESSI";
            this.labelUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.ControlBox = false;
            this.Controls.Add(this.pictureTop1);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.pictureBottom);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormBase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Titulo De Formulario";
            this.Load += new System.EventHandler(this.FormBase_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormBase_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureTop1;
        public System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.PictureBox pictureBottom;
        public MiButtonBase btnCerrar;
        public System.Windows.Forms.Label labelUsuario;
    }
}