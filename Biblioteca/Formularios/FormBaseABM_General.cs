using Biblioteca.Ayudantes;
using System;
using System.Windows.Forms;

namespace Biblioteca.Formularios
{
    public partial class FormBaseABM_General : Biblioteca.Formularios.FormBase
    {
        #region Atributos
        private int _indicePaginaActual = 0;
        #endregion

        public FormBaseABM_General()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormBaseABM_RRHH_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnNuevo, "Crea un nuevo registro");
            toolTip.SetToolTip(btnGuardar, "Guarda los cambios realizados");
            toolTip.SetToolTip(btnCancelar, "Deshace los cambios realizados");
            toolTip.SetToolTip(btnAnular, "Elimina un registro");
            toolTip.SetToolTip(btnExcel_Registro, "Exporta el registro seleccionado a Excel");
            toolTip.SetToolTip(btnPDF_Registro, "Exporta el registro seleccionado a PDF");
            toolTip.SetToolTip(cmbFiltroLista1, "Filtra por tipos de estados");
            toolTip.SetToolTip(cmbFiltroLista2, "Filtra por tipos específicos");
            toolTip.SetToolTip(txtFiltroLista, "Filtra por coincidencia");
            toolTip.SetToolTip(btnExcel_Lista, "Exporta la lista a Excel");
            toolTip.SetToolTip(btnPDF_Lista, "Exporta la lista a PDF");
            #endregion
        }

        private void cmbFiltroLista1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbFiltroLista1.Focused) filtrarCatalogo(0);
        }

        private void cmbFiltroLista2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroLista2.Focused) comboFiltro2();
        }

        private void txtFiltroLista_LostFocus(object sender, EventArgs e)
        {
            if (cmbFiltroLista2.Text != "FILTRAR POR DENOMINACION" 
                || cmbFiltroLista2.Text == "FILTRAR POR DESCRIPCION"
                || cmbFiltroLista2.Text == "FILTRAR POR N. FANTASIA") filtrarCatalogo(0);
        }

        private void txtFiltroLista_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION" 
                || cmbFiltroLista2.Text == "FILTRAR POR N. FANTASIA") filtrarCatalogo(0);
        }

        private void pkrFiltroListaDesde_Validated(object sender, EventArgs e)
        {
            filtrarCatalogo(0);
        }

        private void pkrFiltroListaHasta_Validated(object sender, EventArgs e)
        {
            filtrarCatalogo(0);
        }

        private void btnExcel_Lista_Click(object sender, EventArgs e)
        {
            reportarLista("EXCEL");
        }

        private void btnPDF_Lista_Click(object sender, EventArgs e)
        {
            reportarLista("PDF");
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

        private void btnExcel_Registro_Click(object sender, EventArgs e)
        {
            reportarRegistro("EXCEL");
        }

        private void btnPDF_Registro_Click(object sender, EventArgs e)
        {
            reportarRegistro("PDF");
        }
        #endregion

        #region Métodos
        protected void asignarPaginacion(int indicePagina)
        {
            _indicePaginaActual = (indicePagina < 0) ? 0 : indicePagina; //Establece el índice de la página actual
        }

        protected virtual void comboFiltro2() { }

        protected virtual void filtrarCatalogo(int indicePagina) { }

        protected virtual void mostrarElemento(long idElemento) { }

        protected virtual void reportarLista(string programa) { }

        protected virtual void reportarRegistro(string programa) { }
        #endregion
    }
}
