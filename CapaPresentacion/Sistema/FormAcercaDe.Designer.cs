using Biblioteca.Controles;

namespace CapaPresentacion
{
    partial class FormAcercaDe
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
            this.customLabel1 = new Biblioteca.Controles.MiLabel();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.txtDescripcion = new Biblioteca.Controles.MiTextBox();
            this.customLabel4 = new Biblioteca.Controles.MiLabel();
            this.lblFechaCompilacion = new Biblioteca.Controles.MiLabel();
            this.lblVersionCompilacion = new Biblioteca.Controles.MiLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.Text = "Acerca de...";
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // labelUsuario
            // 
            this.labelUsuario.Text = "Sesión de : ";
            // 
            // customLabel1
            // 
            this.customLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customLabel1.BackColor = System.Drawing.Color.Transparent;
            this.customLabel1.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.customLabel1.Location = new System.Drawing.Point(-1, 190);
            this.customLabel1.Name = "customLabel1";
            this.customLabel1.Size = new System.Drawing.Size(1006, 38);
            this.customLabel1.TabIndex = 12;
            this.customLabel1.Text = "Sistema de Gestión Administrativa de Empremisa ";
            this.customLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureLogo
            // 
            this.pictureLogo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureLogo.BackgroundImage = global::CapaPresentacion.Properties.Resources.logo_about;
            this.pictureLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureLogo.Location = new System.Drawing.Point(215, 249);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(329, 200);
            this.pictureLogo.TabIndex = 13;
            this.pictureLogo.TabStop = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Arial", 9.5F);
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(553, 303);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(222, 146);
            this.txtDescripcion.TabIndex = 19;
            this.txtDescripcion.Text = "Descripción del producto";
            // 
            // customLabel4
            // 
            this.customLabel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customLabel4.BackColor = System.Drawing.Color.Transparent;
            this.customLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.customLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.customLabel4.Location = new System.Drawing.Point(550, 285);
            this.customLabel4.Name = "customLabel4";
            this.customLabel4.Size = new System.Drawing.Size(225, 15);
            this.customLabel4.TabIndex = 18;
            this.customLabel4.Text = "Autor: Sergio Regalado Alessi";
            this.customLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFechaCompilacion
            // 
            this.lblFechaCompilacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblFechaCompilacion.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaCompilacion.Font = new System.Drawing.Font("Arial", 9F);
            this.lblFechaCompilacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblFechaCompilacion.Location = new System.Drawing.Point(550, 267);
            this.lblFechaCompilacion.Name = "lblFechaCompilacion";
            this.lblFechaCompilacion.Size = new System.Drawing.Size(225, 15);
            this.lblFechaCompilacion.TabIndex = 17;
            this.lblFechaCompilacion.Text = "Fecha de compilación: 29/03/2018";
            this.lblFechaCompilacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVersionCompilacion
            // 
            this.lblVersionCompilacion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblVersionCompilacion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersionCompilacion.Font = new System.Drawing.Font("Arial", 9F);
            this.lblVersionCompilacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblVersionCompilacion.Location = new System.Drawing.Point(550, 249);
            this.lblVersionCompilacion.Name = "lblVersionCompilacion";
            this.lblVersionCompilacion.Size = new System.Drawing.Size(225, 15);
            this.lblVersionCompilacion.TabIndex = 16;
            this.lblVersionCompilacion.Text = "Versión: 1.0 (Compilación 1.0.11055)";
            this.lblVersionCompilacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormAcercaDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1006, 687);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.customLabel4);
            this.Controls.Add(this.lblFechaCompilacion);
            this.Controls.Add(this.lblVersionCompilacion);
            this.Controls.Add(this.pictureLogo);
            this.Controls.Add(this.customLabel1);
            this.Name = "FormAcercaDe";
            this.Text = "Acerca de...";
            this.Load += new System.EventHandler(this.FormAcercaDe_Load);
            this.Controls.SetChildIndex(this.labelTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            this.Controls.SetChildIndex(this.labelUsuario, 0);
            this.Controls.SetChildIndex(this.customLabel1, 0);
            this.Controls.SetChildIndex(this.pictureLogo, 0);
            this.Controls.SetChildIndex(this.lblVersionCompilacion, 0);
            this.Controls.SetChildIndex(this.lblFechaCompilacion, 0);
            this.Controls.SetChildIndex(this.customLabel4, 0);
            this.Controls.SetChildIndex(this.txtDescripcion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MiLabel customLabel1;
        private System.Windows.Forms.PictureBox pictureLogo;
        private MiTextBox txtDescripcion;
        private MiLabel customLabel4;
        private MiLabel lblFechaCompilacion;
        private MiLabel lblVersionCompilacion;
    }
}
