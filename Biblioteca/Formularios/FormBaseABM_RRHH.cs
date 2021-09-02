using Biblioteca.Ayudantes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteca.Formularios
{
    public partial class FormBaseABM_RRHH : Biblioteca.Formularios.FormBase
    {
        #region Atributos
        private int _indicePaginaActual = 0;
        #endregion

        public FormBaseABM_RRHH()
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

        #region Eventos de Navegación
        private void navItem1_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(84)) navegarA_Formulario("CURRICULUM_VITAE"); //Verifica que el usuario posea el privilegio requerido
            else Mensaje.Restriccion();
        }
        private void navItem1_MouseEnter(object sender, EventArgs e) { resaltarItemNavegacion(navItem1); }
        private void navItem1_MouseLeave(object sender, EventArgs e) { restaurarItemNavegacion(navItem1); }

        private void navItem2_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(84)) navegarA_Formulario("DOCUMENTACION"); //Verifica que el usuario posea el privilegio requerido
            else Mensaje.Restriccion();
        }
        private void navItem2_MouseEnter(object sender, EventArgs e) { resaltarItemNavegacion(navItem2); }
        private void navItem2_MouseLeave(object sender, EventArgs e) { restaurarItemNavegacion(navItem2); }

        private void navItem3_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(84)) navegarA_Formulario("LABORAL"); //Verifica que el usuario posea el privilegio requerido
            else Mensaje.Restriccion();
        }
        private void navItem3_MouseEnter(object sender, EventArgs e) { resaltarItemNavegacion(navItem3); }
        private void navItem3_MouseLeave(object sender, EventArgs e) { restaurarItemNavegacion(navItem3); }

        private void navItem4_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(84)) navegarA_Formulario("PERSONAL"); //Verifica que el usuario posea el privilegio requerido
            else Mensaje.Restriccion();
        }
        private void navItem4_MouseEnter(object sender, EventArgs e) { resaltarItemNavegacion(navItem4); }
        private void navItem4_MouseLeave(object sender, EventArgs e) { restaurarItemNavegacion(navItem4); }

        private void navItem5_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(84)) navegarA_Formulario("TALLES"); //Verifica que el usuario posea el privilegio requerido
            else Mensaje.Restriccion();
        }
        private void navItem5_MouseEnter(object sender, EventArgs e) { resaltarItemNavegacion(navItem5); }
        private void navItem5_MouseLeave(object sender, EventArgs e) { restaurarItemNavegacion(navItem5); }

        private void navItem6_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(84)) navegarA_Formulario("CAPACITACION"); //Verifica que el usuario posea el privilegio requerido
            else Mensaje.Restriccion();
        }
        private void navItem6_MouseEnter(object sender, EventArgs e) { resaltarItemNavegacion(navItem6); }
        private void navItem6_MouseLeave(object sender, EventArgs e) { restaurarItemNavegacion(navItem6); }

        private void navItem7_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(84)) navegarA_Formulario("ENTREVISTA"); //Verifica que el usuario posea el privilegio requerido
            else Mensaje.Restriccion();
        }
        private void navItem7_MouseEnter(object sender, EventArgs e) { resaltarItemNavegacion(navItem7); }
        private void navItem7_MouseLeave(object sender, EventArgs e) { restaurarItemNavegacion(navItem7); }

        private void navItem8_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(84)) navegarA_Formulario("NOVEDAD"); //Verifica que el usuario posea el privilegio requerido
            else Mensaje.Restriccion();
        }
        private void navItem8_MouseEnter(object sender, EventArgs e) { resaltarItemNavegacion(navItem8); }
        private void navItem8_MouseLeave(object sender, EventArgs e) { restaurarItemNavegacion(navItem8); }


        private void navItem9_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(84)) navegarA_Formulario("CONTRATO"); //Verifica que el usuario posea el privilegio requerido
            else Mensaje.Restriccion();
        }
        private void navItem9_MouseEnter(object sender, EventArgs e) { resaltarItemNavegacion(navItem9); }
        private void navItem9_MouseLeave(object sender, EventArgs e) { restaurarItemNavegacion(navItem9); }

        private void navItem10_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(84)) navegarA_Formulario("CURSO_INDUCCION"); //Verifica que el usuario posea el privilegio requerido
            else Mensaje.Restriccion();
        }
        private void navItem10_MouseEnter(object sender, EventArgs e) { resaltarItemNavegacion(navItem10); }
        private void navItem10_MouseLeave(object sender, EventArgs e) { restaurarItemNavegacion(navItem10); }

        private void navItem11_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(84)) navegarA_Formulario("CURSO_IZAJE"); //Verifica que el usuario posea el privilegio requerido
            else Mensaje.Restriccion();
        }
        private void navItem11_MouseEnter(object sender, EventArgs e) { resaltarItemNavegacion(navItem11); }
        private void navItem11_MouseLeave(object sender, EventArgs e) { restaurarItemNavegacion(navItem11); }

        private void navItem12_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(84)) navegarA_Formulario("EXAMEN_MEDICO"); //Verifica que el usuario posea el privilegio requerido
            else Mensaje.Restriccion();
        }
        private void navItem12_MouseEnter(object sender, EventArgs e) { resaltarItemNavegacion(navItem12); }
        private void navItem12_MouseLeave(object sender, EventArgs e) { restaurarItemNavegacion(navItem12); }

        private void navItem13_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(84)) navegarA_Formulario("PAGO"); //Verifica que el usuario posea el privilegio requerido
            else Mensaje.Restriccion();
        }
        private void navItem13_MouseEnter(object sender, EventArgs e) { resaltarItemNavegacion(navItem13); }
        private void navItem13_MouseLeave(object sender, EventArgs e) { restaurarItemNavegacion(navItem13); }

        private void navItem14_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(84)) navegarA_Formulario("SUELDO"); //Verifica que el usuario posea el privilegio requerido
            else Mensaje.Restriccion();
        }
        private void navItem14_MouseEnter(object sender, EventArgs e) { resaltarItemNavegacion(navItem14); }
        private void navItem14_MouseLeave(object sender, EventArgs e) { restaurarItemNavegacion(navItem14); }
        #endregion

        #region Métodos de Navegación
        private void resaltarItemNavegacion(Label ItemNavegacion)
        {
            ItemNavegacion.Font = new Font("Arial", 9, FontStyle.Bold | FontStyle.Italic);
            ItemNavegacion.ForeColor = Color.Blue;
        }

        private void restaurarItemNavegacion(Label ItemNavegacion)
        {
            ItemNavegacion.Font = new Font("Arial", 9, FontStyle.Italic);
            ItemNavegacion.ForeColor = Color.FromArgb(0, 54, 58);
        }

        protected virtual void navegarA_Formulario(string destino) { }
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
