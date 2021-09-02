using Biblioteca.Controles;

namespace CapaPresentacion
{
    partial class FormHerramienta
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
                nHerramientas.Dispose();
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
            this.groupBoxBackup = new System.Windows.Forms.GroupBox();
            this.btnRestaurarBackup = new Biblioteca.Controles.MiButtonBase();
            this.txtOrigenBackup = new Biblioteca.Controles.MiTextBoxRead();
            this.lblOrigenBackup = new Biblioteca.Controles.MiLabel();
            this.btnBuscarBackup = new Biblioteca.Controles.MiButtonBase();
            this.txtDestinoBackup = new Biblioteca.Controles.MiTextBoxRead();
            this.lblDestinoBackup = new Biblioteca.Controles.MiLabel();
            this.btnCrearBackup = new Biblioteca.Controles.MiButtonBase();
            this.progressBarProceso = new System.Windows.Forms.ProgressBar();
            this.lblLeyenda = new System.Windows.Forms.Label();
            this.groupBoxBackup.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Herramientas de Sistema";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.TabIndex = 6;
            // 
            // labelUsuario
            // 
            this.labelUsuario.TabIndex = 1;
            this.labelUsuario.Text = "Sesión de : ";
            // 
            // groupBoxBackup
            // 
            this.groupBoxBackup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBoxBackup.Controls.Add(this.btnRestaurarBackup);
            this.groupBoxBackup.Controls.Add(this.txtOrigenBackup);
            this.groupBoxBackup.Controls.Add(this.lblOrigenBackup);
            this.groupBoxBackup.Controls.Add(this.btnBuscarBackup);
            this.groupBoxBackup.Controls.Add(this.txtDestinoBackup);
            this.groupBoxBackup.Controls.Add(this.lblDestinoBackup);
            this.groupBoxBackup.Controls.Add(this.btnCrearBackup);
            this.groupBoxBackup.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxBackup.ForeColor = System.Drawing.Color.Gray;
            this.groupBoxBackup.Location = new System.Drawing.Point(6, 56);
            this.groupBoxBackup.Name = "groupBoxBackup";
            this.groupBoxBackup.Size = new System.Drawing.Size(994, 77);
            this.groupBoxBackup.TabIndex = 2;
            this.groupBoxBackup.TabStop = false;
            this.groupBoxBackup.Text = "Backups de Base de Datos";
            // 
            // btnRestaurarBackup
            // 
            this.btnRestaurarBackup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRestaurarBackup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRestaurarBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRestaurarBackup.FlatAppearance.BorderSize = 0;
            this.btnRestaurarBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnRestaurarBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRestaurarBackup.Font = new System.Drawing.Font("Arial", 9F);
            this.btnRestaurarBackup.ForeColor = System.Drawing.Color.Black;
            this.btnRestaurarBackup.Location = new System.Drawing.Point(910, 47);
            this.btnRestaurarBackup.Name = "btnRestaurarBackup";
            this.btnRestaurarBackup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnRestaurarBackup.Size = new System.Drawing.Size(75, 23);
            this.btnRestaurarBackup.TabIndex = 6;
            this.btnRestaurarBackup.Text = "Restaurar";
            this.btnRestaurarBackup.UseVisualStyleBackColor = false;
            this.btnRestaurarBackup.Click += new System.EventHandler(this.btnRestaurarBackup_Click);
            // 
            // txtOrigenBackup
            // 
            this.txtOrigenBackup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtOrigenBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtOrigenBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrigenBackup.Font = new System.Drawing.Font("Arial", 9F);
            this.txtOrigenBackup.ForeColor = System.Drawing.Color.Black;
            this.txtOrigenBackup.Location = new System.Drawing.Point(162, 48);
            this.txtOrigenBackup.Name = "txtOrigenBackup";
            this.txtOrigenBackup.ReadOnly = true;
            this.txtOrigenBackup.Size = new System.Drawing.Size(610, 21);
            this.txtOrigenBackup.TabIndex = 4;
            // 
            // lblOrigenBackup
            // 
            this.lblOrigenBackup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblOrigenBackup.BackColor = System.Drawing.Color.Transparent;
            this.lblOrigenBackup.Font = new System.Drawing.Font("Arial", 9F);
            this.lblOrigenBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblOrigenBackup.Location = new System.Drawing.Point(12, 51);
            this.lblOrigenBackup.Name = "lblOrigenBackup";
            this.lblOrigenBackup.Size = new System.Drawing.Size(150, 15);
            this.lblOrigenBackup.TabIndex = 3;
            this.lblOrigenBackup.Text = "Ruta Origen de Backup";
            this.lblOrigenBackup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBuscarBackup
            // 
            this.btnBuscarBackup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscarBackup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscarBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscarBackup.FlatAppearance.BorderSize = 0;
            this.btnBuscarBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBuscarBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnBuscarBackup.Font = new System.Drawing.Font("Arial", 9F);
            this.btnBuscarBackup.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarBackup.Location = new System.Drawing.Point(774, 47);
            this.btnBuscarBackup.Name = "btnBuscarBackup";
            this.btnBuscarBackup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBuscarBackup.Size = new System.Drawing.Size(135, 23);
            this.btnBuscarBackup.TabIndex = 5;
            this.btnBuscarBackup.Text = "Seleccionar Backup";
            this.btnBuscarBackup.UseVisualStyleBackColor = false;
            this.btnBuscarBackup.Click += new System.EventHandler(this.btnBuscarBackup_Click);
            // 
            // txtDestinoBackup
            // 
            this.txtDestinoBackup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDestinoBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.txtDestinoBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDestinoBackup.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDestinoBackup.ForeColor = System.Drawing.Color.Black;
            this.txtDestinoBackup.Location = new System.Drawing.Point(162, 21);
            this.txtDestinoBackup.Name = "txtDestinoBackup";
            this.txtDestinoBackup.ReadOnly = true;
            this.txtDestinoBackup.Size = new System.Drawing.Size(686, 21);
            this.txtDestinoBackup.TabIndex = 1;
            // 
            // lblDestinoBackup
            // 
            this.lblDestinoBackup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDestinoBackup.BackColor = System.Drawing.Color.Transparent;
            this.lblDestinoBackup.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDestinoBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblDestinoBackup.Location = new System.Drawing.Point(12, 24);
            this.lblDestinoBackup.Name = "lblDestinoBackup";
            this.lblDestinoBackup.Size = new System.Drawing.Size(150, 15);
            this.lblDestinoBackup.TabIndex = 0;
            this.lblDestinoBackup.Text = "Ruta Destino de Backup";
            this.lblDestinoBackup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCrearBackup
            // 
            this.btnCrearBackup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCrearBackup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCrearBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCrearBackup.FlatAppearance.BorderSize = 0;
            this.btnCrearBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCrearBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCrearBackup.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCrearBackup.ForeColor = System.Drawing.Color.Black;
            this.btnCrearBackup.Location = new System.Drawing.Point(850, 20);
            this.btnCrearBackup.Name = "btnCrearBackup";
            this.btnCrearBackup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCrearBackup.Size = new System.Drawing.Size(135, 23);
            this.btnCrearBackup.TabIndex = 2;
            this.btnCrearBackup.Text = "Crear Backup";
            this.btnCrearBackup.UseVisualStyleBackColor = false;
            this.btnCrearBackup.Click += new System.EventHandler(this.btnCrearBackup_Click);
            // 
            // progressBarProceso
            // 
            this.progressBarProceso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarProceso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.progressBarProceso.Location = new System.Drawing.Point(751, 670);
            this.progressBarProceso.Name = "progressBarProceso";
            this.progressBarProceso.Size = new System.Drawing.Size(158, 10);
            this.progressBarProceso.Step = 1;
            this.progressBarProceso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarProceso.TabIndex = 5;
            this.progressBarProceso.Visible = false;
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLeyenda.AutoSize = true;
            this.lblLeyenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.lblLeyenda.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeyenda.ForeColor = System.Drawing.Color.White;
            this.lblLeyenda.Location = new System.Drawing.Point(750, 654);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Size = new System.Drawing.Size(161, 14);
            this.lblLeyenda.TabIndex = 4;
            this.lblLeyenda.Text = "Procesando... Por Favor Espere";
            this.lblLeyenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeyenda.Visible = false;
            // 
            // FormHerramienta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.progressBarProceso);
            this.Controls.Add(this.lblLeyenda);
            this.Controls.Add(this.groupBoxBackup);
            this.Name = "FormHerramienta";
            this.Text = "Herramientas de Sistema";
            this.Load += new System.EventHandler(this.FormHerramienta_Load);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.groupBoxBackup, 0);
            this.Controls.SetChildIndex(this.lblLeyenda, 0);
            this.Controls.SetChildIndex(this.progressBarProceso, 0);
            this.groupBoxBackup.ResumeLayout(false);
            this.groupBoxBackup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBoxBackup;
        private MiButtonBase btnRestaurarBackup;
        private MiTextBoxRead txtOrigenBackup;
        private MiLabel lblOrigenBackup;
        private MiButtonBase btnBuscarBackup;
        private MiTextBoxRead txtDestinoBackup;
        private MiLabel lblDestinoBackup;
        private MiButtonBase btnCrearBackup;
        public System.Windows.Forms.ProgressBar progressBarProceso;
        public System.Windows.Forms.Label lblLeyenda;
    }
}
