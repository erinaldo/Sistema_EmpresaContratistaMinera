using Biblioteca.Controles;

namespace CapaPresentacion.Modales
{
    partial class FormNotificacion
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
            this.lblNotificacionAlerta2 = new Biblioteca.Controles.MiLabel();
            this.lblNotificacionAlerta1 = new Biblioteca.Controles.MiLabel();
            this.btnAbrir = new Biblioteca.Controles.MiButtonBase();
            this.lblNotificacionAlerta3 = new Biblioteca.Controles.MiLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCerrar.Location = new System.Drawing.Point(180, 115);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(250, 30);
            this.lblTitulo.Text = "Notificación de Alertas";
            // 
            // pictureBottom
            // 
            this.pictureBottom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBottom.Location = new System.Drawing.Point(0, 110);
            this.pictureBottom.Size = new System.Drawing.Size(250, 30);
            // 
            // pictureRight
            // 
            this.pictureRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureRight.Location = new System.Drawing.Point(249, -5);
            this.pictureRight.Size = new System.Drawing.Size(0, 150);
            // 
            // pictureTop1
            // 
            this.pictureTop1.Size = new System.Drawing.Size(250, 6);
            // 
            // lblNotificacionAlerta2
            // 
            this.lblNotificacionAlerta2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNotificacionAlerta2.BackColor = System.Drawing.Color.Transparent;
            this.lblNotificacionAlerta2.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblNotificacionAlerta2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblNotificacionAlerta2.Location = new System.Drawing.Point(2, 64);
            this.lblNotificacionAlerta2.Name = "lblNotificacionAlerta2";
            this.lblNotificacionAlerta2.Size = new System.Drawing.Size(246, 18);
            this.lblNotificacionAlerta2.TabIndex = 25;
            this.lblNotificacionAlerta2.Text = "No hay alertas sin atender";
            this.lblNotificacionAlerta2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNotificacionAlerta1
            // 
            this.lblNotificacionAlerta1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNotificacionAlerta1.BackColor = System.Drawing.Color.Transparent;
            this.lblNotificacionAlerta1.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblNotificacionAlerta1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblNotificacionAlerta1.Location = new System.Drawing.Point(2, 44);
            this.lblNotificacionAlerta1.Name = "lblNotificacionAlerta1";
            this.lblNotificacionAlerta1.Size = new System.Drawing.Size(246, 18);
            this.lblNotificacionAlerta1.TabIndex = 24;
            this.lblNotificacionAlerta1.Text = "No hay alertas en proceso";
            this.lblNotificacionAlerta1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAbrir
            // 
            this.btnAbrir.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAbrir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAbrir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAbrir.FlatAppearance.BorderSize = 0;
            this.btnAbrir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAbrir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAbrir.Font = new System.Drawing.Font("Arial", 7F);
            this.btnAbrir.ForeColor = System.Drawing.Color.Black;
            this.btnAbrir.Location = new System.Drawing.Point(113, 115);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAbrir.Size = new System.Drawing.Size(65, 20);
            this.btnAbrir.TabIndex = 23;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseVisualStyleBackColor = false;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // lblNotificacionAlerta3
            // 
            this.lblNotificacionAlerta3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNotificacionAlerta3.BackColor = System.Drawing.Color.Transparent;
            this.lblNotificacionAlerta3.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblNotificacionAlerta3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblNotificacionAlerta3.Location = new System.Drawing.Point(2, 84);
            this.lblNotificacionAlerta3.Name = "lblNotificacionAlerta3";
            this.lblNotificacionAlerta3.Size = new System.Drawing.Size(246, 18);
            this.lblNotificacionAlerta3.TabIndex = 26;
            this.lblNotificacionAlerta3.Text = "No hay alertas vencidas";
            this.lblNotificacionAlerta3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormNotificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(250, 140);
            this.Controls.Add(this.lblNotificacionAlerta1);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.lblNotificacionAlerta2);
            this.Controls.Add(this.lblNotificacionAlerta3);
            this.Name = "FormNotificacion";
            this.Text = "Notificación de Alertas";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormModalNotificacion_FormClosed);
            this.Load += new System.EventHandler(this.FormNotificacion_Load);
            this.Controls.SetChildIndex(this.pictureTop1, 0);
            this.Controls.SetChildIndex(this.lblNotificacionAlerta3, 0);
            this.Controls.SetChildIndex(this.lblNotificacionAlerta2, 0);
            this.Controls.SetChildIndex(this.pictureBottom, 0);
            this.Controls.SetChildIndex(this.btnAbrir, 0);
            this.Controls.SetChildIndex(this.lblNotificacionAlerta1, 0);
            this.Controls.SetChildIndex(this.pictureLeft, 0);
            this.Controls.SetChildIndex(this.pictureRight, 0);
            this.Controls.SetChildIndex(this.lblTitulo, 0);
            this.Controls.SetChildIndex(this.btnCerrar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTop1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MiLabel lblNotificacionAlerta2;
        private MiLabel lblNotificacionAlerta1;
        private MiButtonBase btnAbrir;
        private MiLabel lblNotificacionAlerta3;
    }
}
