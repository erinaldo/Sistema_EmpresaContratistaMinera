using Biblioteca.Ayudantes;
using System;
using System.Windows.Forms;

namespace Biblioteca.Formularios
{
    public partial class FormBaseReporte : Biblioteca.Formularios.FormBase
    {
        #region Atributos
        private int _indicePaginaActual = 0;
        private ContextMenu menuContextual = new ContextMenu();
        #endregion

        public FormBaseReporte()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FormBaseReporte_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnExcel_Lista, "Exporta la lista a Excel");
            toolTip.SetToolTip(btnPDF_Lista, "Exporta la lista a PDF");
            #endregion
        }

        private void btnPaginacionInicial_Click(object sender, EventArgs e)
        {
            int indicePagina = 0;
            filtrarCatalogo(indicePagina);
            lblPaginacion.Text = (indicePagina + 1).ToString();
            _indicePaginaActual = indicePagina;
        }

        private void btnPaginacionAnterior_Click(object sender, EventArgs e)
        {
            if (_indicePaginaActual > 0)
            {
                int indicePagina = _indicePaginaActual - 1;
                filtrarCatalogo(indicePagina);
                lblPaginacion.Text = (indicePagina + 1).ToString();
                _indicePaginaActual = indicePagina;
            }
        }

        private void btnPaginacionPosterior_Click(object sender, EventArgs e)
        {
            if (_indicePaginaActual < Global.PaginacionIndiceMaximo)
            {
                int indicePagina = _indicePaginaActual + 1;
                filtrarCatalogo(indicePagina);
                lblPaginacion.Text = (indicePagina + 1).ToString();
                _indicePaginaActual = indicePagina;
            }
        }

        private void btnPaginacionFinal_Click(object sender, EventArgs e)
        {
            int indicePagina = Global.PaginacionIndiceMaximo;
            filtrarCatalogo(indicePagina);
            lblPaginacion.Text = (indicePagina + 1).ToString();
            _indicePaginaActual = indicePagina;
        }

        private void lstCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCatalogo.Items.Count > 0 && lstCatalogo.Focused)
            {
                try
                {
                    mostrarElemento(Convert.ToInt32(lstCatalogo.SelectedValue));
                }
                catch (IndexOutOfRangeException) { }
            }
        }

        private void lstCatalogo_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstCatalogo.SelectedValue != null && e.KeyCode.Equals(Keys.Enter)) //Verifica que se oprimió la tecla "Enter"
            {
                navegarAFormulario();
                this.Close();
            }
        }

        private void lstCatalogo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = lstCatalogo.IndexFromPoint(e.Location); //Paso 1: Almacena el incide del elemento
                if (item >= 0)
                {
                    lstCatalogo.ClearSelected();
                    lstCatalogo.SelectedIndex = item; //Paso 2: Marca el item por el indice del elemento
                    lstCatalogo.SelectedItem = lstCatalogo.Text; //Paso 3: Selecciona el item de la lista
                    menuContextual.Show(lstCatalogo, e.Location); //Muestra el menú contextual sobre la lista del catálogo
                }
            }
        }

        private void btnExcel_Lista_Click_1(object sender, EventArgs e)
        {
            reportarLista("EXCEL");
        }

        private void btnPDF_Lista_Click_1(object sender, EventArgs e)
        {
            reportarLista("PDF");
        }
        #endregion

        #region Métodos
        private void copiarTextoelemento(object sender, EventArgs e)
        {
            string texto = lstCatalogo.Text.Replace("|", "");
            Clipboard.SetText(texto);
        }

        private void mostrarMasDatos(object sender, EventArgs e)
        {
            mostrarElemento(Convert.ToInt32(lstCatalogo.SelectedValue));
            navegarAFormulario();
        }

        protected void asignarPaginacion(int indicePagina)
        {
            _indicePaginaActual = (indicePagina < 0) ? 0 : indicePagina; //Establece el índice de la página actual
        }

        protected void definirMenuContextual(bool copiarTextoElemento, bool verMasDatos)
        {
            if (copiarTextoElemento) menuContextual.MenuItems.Add("Copiar texto del elemento", copiarTextoelemento); // Crea un item y lo agrega al menú contextual del boton derecho del mouse
            if (verMasDatos) menuContextual.MenuItems.Add("Ver más datos…", mostrarMasDatos); // Crea un item y lo agrega al menú contextual del boton derecho del mouse
        }

        protected virtual void filtrarCatalogo(int indicePagina) { }

        protected virtual void navegarAFormulario() { }

        protected virtual void mostrarElemento(long idElemento) { }

        protected virtual void reportarLista(string programa) { }

        protected virtual void reportarRegistro(string programa) { }
        #endregion
    }
}
