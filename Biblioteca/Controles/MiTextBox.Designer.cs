namespace Biblioteca.Controles
{
    partial class MiTextBox
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

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MiTextBox
            // 
            this.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Font = new System.Drawing.Font("Arial", 9.5F);
            this.ForeColor = System.Drawing.Color.Black;
            this.ResumeLayout(false);
            this.GotFocus += new System.EventHandler(this.MiTextBox_GotFocus);
        }

        #endregion
    }
}
