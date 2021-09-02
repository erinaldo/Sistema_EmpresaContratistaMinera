namespace Biblioteca.Controles
{
    partial class MiDateTimePicker
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
            // MiDateTimePicker
            // 
            this.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CalendarForeColor = System.Drawing.Color.Black;
            this.CalendarMonthBackground = System.Drawing.Color.White;
            this.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.CustomFormat = "dd/MM/yyyy";
            this.Font = new System.Drawing.Font("Arial", 9.5F);
            this.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.Size = new System.Drawing.Size(102, 22);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
