using System;
using System.Collections.Generic;
using Biblioteca.Formularios;
using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using CapaNegocio;

namespace CapaPresentacion.Catalogo
{
    public partial class FormCatalogo_Legajo : Biblioteca.Formularios.FormBaseCatalogo_LecturaF2
    {
        #region Atributos
        private Legajo objLegajo = new Legajo();
        private N_Legajo nLegajo = new N_Legajo();
        private FormBase _formularioDeOrigen;
        #endregion

        public FormCatalogo_Legajo(FormBase formularioDeOrigen)
        {
            _formularioDeOrigen = formularioDeOrigen;
            InitializeComponent();
        }

        #region Eventos
        private void FormCatalogo_Legajo_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR LEGAJOS S/BAJA" }, 0); //Establece los items del ComboBox            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT", "FILTRAR POR DENOMINACION" }, 1); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT", "FILTRAR POR DENOMINACION" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
        }
        #endregion

        #region Métodos
        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        protected override void capturarElemento()
        {
            if (lstCatalogo.SelectedValue != null)
            {
                _formularioDeOrigen.asignarVariablesDeFormulario(new string[] { "Catalogo_Legajo", objLegajo.Id.ToString() });
                this.Close();
            }
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION") { }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR CUIT") { }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la descripcion
            {
                cargarCatalogo(nLegajo.obtenerCatalago("S/BAJA", "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de CUIT
            {
                cargarCatalogo(nLegajo.obtenerCatalago("S/BAJA", "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objLegajo = nLegajo.obtenerObjeto("ID", lstCatalogo.SelectedValue.ToString(), true);
        }
        #endregion
    }
}
