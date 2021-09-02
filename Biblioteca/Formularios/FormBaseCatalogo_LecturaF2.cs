using Biblioteca.Ayudantes;
using System;
using System.Media;
using System.Windows.Forms;

namespace Biblioteca.Formularios
{
    public partial class FormBaseCatalogo_LecturaF2 : Biblioteca.Formularios.FormBaseModal
    {
        #region Atributos
        private int _indicePaginaActual = 0;
        ContextMenu menuContextual = new ContextMenu();
        #endregion

        public FormBaseCatalogo_LecturaF2()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FormBaseCatalogo_LecturaF2_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(cmbFiltroLista1, "Filtra por tipos de estados");
            toolTip.SetToolTip(cmbFiltroLista2, "Filtra por tipos específicos");
            toolTip.SetToolTip(txtFiltroLista, "Filtra por coincidencia");
            toolTip.SetToolTip(btnCerrar, "Cerrar catálogo");
            #endregion
        }

        private void FormBaseCatalogo_LecturaF2_Shown(object sender, EventArgs e)
        {
            txtFiltroLista.Focus();
        }

        private void cmbFiltroLista1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroLista1.Focused) filtrarCatalogo(0);
        }

        private void cmbFiltroLista2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroLista2.Focused) comboFiltro2();
        }

        private void txtFiltroLista_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") filtrarCatalogo(0);
            if (e.KeyCode == Keys.Return && cmbFiltroLista2.Text != "FILTRAR POR DENOMINACION")
            {
                e.Handled = true; 
                filtrarCatalogo(0);
            }
        }

        private void pkrFiltroListaDesde_LostFocus(object sender, EventArgs e)
        {
            filtrarCatalogo(0);
        }

        private void pkrFiltroListaHasta_LostFocus(object sender, EventArgs e)
        {
            filtrarCatalogo(0);
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
                capturarElemento();
                this.Close();
            }
        }

        private void lstCatalogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstCatalogo.SelectedValue != null)
            {
                capturarElemento();
                this.Close();
            }
        }
        #endregion

        #region Métodos
        protected void asignarPaginacion(int indicePagina)
        {
            _indicePaginaActual = (indicePagina < 0) ? 0 : indicePagina; //Establece el índice de la página actual
        }

        protected virtual void capturarElemento() { }

        protected virtual void comboFiltro2() { }

        protected virtual void filtrarCatalogo(int indicePagina) { }

        protected virtual void mostrarElemento(long idElemento) { }
        #endregion
    }
}
