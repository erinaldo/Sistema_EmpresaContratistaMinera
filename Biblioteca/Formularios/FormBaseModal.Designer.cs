using Biblioteca.Controles;

namespace Biblioteca.Formularios
{
    partial class FormBaseModal
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
            this.btnCerrar = new Biblioteca.Controles.MiButtonBase();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pictureRight = new System.Windows.Forms.PictureBox();
            this.pictureLeft = new System.Windows.Forms.PictureBox();
            this.pictureBottom = new System.Windows.Forms.PictureBox();
            this.pictureTop1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).BeginInit();
            this.SuspendLayout();
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
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 7F);
            this.btnCerrar.ForeColor = System.Drawing.Color.Black;
            this.btnCerrar.Location = new System.Drawing.Point(310, 275);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCerrar.Size = new System.Drawing.Size(65, 20);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.lblTitulo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(380, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Titulo De Formulario";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureRight
            // 
            this.pictureRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureRight.BackColor = System.Drawing.Color.Gray;
            this.pictureRight.Location = new System.Drawing.Point(379, 0);
            this.pictureRight.Name = "pictureRight";
            this.pictureRight.Size = new System.Drawing.Size(0, 300);
            this.pictureRight.TabIndex = 9;
            this.pictureRight.TabStop = false;
            // 
            // pictureLeft
            // 
            this.pictureLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureLeft.BackColor = System.Drawing.Color.Gray;
            this.pictureLeft.Location = new System.Drawing.Point(0, 0);
            this.pictureLeft.Name = "pictureLeft";
            this.pictureLeft.Size = new System.Drawing.Size(0, 300);
            this.pictureLeft.TabIndex = 8;
            this.pictureLeft.TabStop = false;
            // 
            // pictureBottom
            // 
            this.pictureBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.pictureBottom.Location = new System.Drawing.Point(0, 270);
            this.pictureBottom.Name = "pictureBottom";
            this.pictureBottom.Size = new System.Drawing.Size(380, 30);
            this.pictureBottom.TabIndex = 6;
            this.pictureBottom.TabStop = false;
            // 
            // pictureTop1
            // 
            this.pictureTop1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureTop1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.pictureTop1.Location = new System.Drawing.Point(0, 0);
            this.pictureTop1.Name = "pictureTop1";
            this.pictureTop1.Size = new System.Drawing.Size(380, 6);
            this.pictureTop1.TabIndex = 3;
            this.pictureTop1.TabStop = false;
            // 
            // FormBaseModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(380, 300);
            this.ControlBox = false;
            this.Controls.Add(this.pictureRight);
            this.Controls.Add(this.pictureLeft);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pictureBottom);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pictureTop1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "FormBaseModal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventana Modal";
            this.Load += new System.EventHandler(this.FormBaseModal_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormBaseModal_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public MiButtonBase btnCerrar;
        public System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.PictureBox pictureBottom;
        public System.Windows.Forms.PictureBox pictureRight;
        public System.Windows.Forms.PictureBox pictureLeft;
        public System.Windows.Forms.PictureBox pictureTop1;
    }
}