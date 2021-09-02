using Biblioteca.Controles;

namespace Biblioteca.Formularios
{
    partial class FormBaseInicio
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.progressBarProceso = new System.Windows.Forms.ProgressBar();
            this.lblLeyenda = new System.Windows.Forms.Label();
            this.pictureMarca = new System.Windows.Forms.PictureBox();
            this.pictureIcono = new System.Windows.Forms.PictureBox();
            this.pictureBottom = new System.Windows.Forms.PictureBox();
            this.pictureTop1 = new System.Windows.Forms.PictureBox();
            this.btnSalir = new Biblioteca.Controles.MiButtonBase();
            this.btnAceptar = new Biblioteca.Controles.MiButtonBase();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMarca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.lblTitulo.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(350, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Titulo del Form";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBarProceso
            // 
            this.progressBarProceso.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.progressBarProceso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.progressBarProceso.Location = new System.Drawing.Point(17, 209);
            this.progressBarProceso.Name = "progressBarProceso";
            this.progressBarProceso.Size = new System.Drawing.Size(158, 10);
            this.progressBarProceso.Step = 1;
            this.progressBarProceso.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarProceso.TabIndex = 3;
            this.progressBarProceso.Value = 5;
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLeyenda.AutoSize = true;
            this.lblLeyenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblLeyenda.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeyenda.ForeColor = System.Drawing.Color.White;
            this.lblLeyenda.Location = new System.Drawing.Point(16, 193);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Size = new System.Drawing.Size(161, 14);
            this.lblLeyenda.TabIndex = 2;
            this.lblLeyenda.Text = "Procesando... Por Favor Espere";
            this.lblLeyenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureMarca
            // 
            this.pictureMarca.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.pictureMarca.BackgroundImage = global::Biblioteca.Properties.Resources.logo_marca;
            this.pictureMarca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureMarca.Location = new System.Drawing.Point(140, 55);
            this.pictureMarca.Name = "pictureMarca";
            this.pictureMarca.Size = new System.Drawing.Size(203, 41);
            this.pictureMarca.TabIndex = 6;
            this.pictureMarca.TabStop = false;
            // 
            // pictureIcono
            // 
            this.pictureIcono.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.pictureIcono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureIcono.Image = global::Biblioteca.Properties.Resources.logo_inicio;
            this.pictureIcono.Location = new System.Drawing.Point(5, 55);
            this.pictureIcono.Name = "pictureIcono";
            this.pictureIcono.Size = new System.Drawing.Size(128, 128);
            this.pictureIcono.TabIndex = 5;
            this.pictureIcono.TabStop = false;
            // 
            // pictureBottom
            // 
            this.pictureBottom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.pictureBottom.Location = new System.Drawing.Point(0, 189);
            this.pictureBottom.Name = "pictureBottom";
            this.pictureBottom.Size = new System.Drawing.Size(350, 38);
            this.pictureBottom.TabIndex = 2;
            this.pictureBottom.TabStop = false;
            // 
            // pictureTop1
            // 
            this.pictureTop1.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.pictureTop1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureTop1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.pictureTop1.Location = new System.Drawing.Point(0, 0);
            this.pictureTop1.Name = "pictureTop1";
            this.pictureTop1.Size = new System.Drawing.Size(350, 10);
            this.pictureTop1.TabIndex = 0;
            this.pictureTop1.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSalir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSalir.Font = new System.Drawing.Font("Arial", 9F);
            this.btnSalir.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.Location = new System.Drawing.Point(268, 196);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAceptar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAceptar.Font = new System.Drawing.Font("Arial", 9F);
            this.btnAceptar.ForeColor = System.Drawing.Color.Black;
            this.btnAceptar.Location = new System.Drawing.Point(191, 196);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            // 
            // FormBaseInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(350, 226);
            this.ControlBox = false;
            this.Controls.Add(this.progressBarProceso);
            this.Controls.Add(this.lblLeyenda);
            this.Controls.Add(this.pictureMarca);
            this.Controls.Add(this.pictureIcono);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.pictureBottom);
            this.Controls.Add(this.pictureTop1);
            this.Controls.Add(this.lblTitulo);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBaseInicio";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empreminsa";
            this.Load += new System.EventHandler(this.FormBaseInicio_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormBaseInicio_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureMarca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.PictureBox pictureTop1;
        public System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pictureBottom;
        private System.Windows.Forms.PictureBox pictureIcono;
        private System.Windows.Forms.PictureBox pictureMarca;
        public MiButtonBase btnAceptar;
        public MiButtonBase btnSalir;
        public System.Windows.Forms.ProgressBar progressBarProceso;
        public System.Windows.Forms.Label lblLeyenda;
    }
}