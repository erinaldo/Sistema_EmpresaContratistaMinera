using System;
using System.Collections.Generic;
using Biblioteca.Formularios;
using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using CapaNegocio;

namespace CapaPresentacion.Catalogo
{
    public partial class FormCatalogo_Articulo : Biblioteca.Formularios.FormBaseCatalogo_LecturaF2
    {
        #region Atributos
        private string _navFiltro = "TODOS LOS ESTADOS";
        private bool _navFiltro_Activo = false;
        private Articulo objArticulo = new Articulo();
        private N_Articulo nArticulo = new N_Articulo();
        private FormBase _formularioDeOrigen;
        #endregion

        public FormCatalogo_Articulo(FormBase formularioDeOrigen, string filtroEstado, bool filtroEstado_Activo = true)
        {
            _formularioDeOrigen = formularioDeOrigen;
            _navFiltro = filtroEstado;
            _navFiltro_Activo = filtroEstado_Activo;
            InitializeComponent();
        }

        #region Eventos
        private void FormCatalogo_Articulo_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO",
                "FILTRAR POR ESTADO: BAJA", "TODOS LOS ESTADOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR COD. BARRAS",
                "FILTRAR POR DENOMINACION", "FILTRAR POR ID" }, 1); //Establece los items del ComboBox
            cmbFiltroLista1.Text = _navFiltro; //Importante: Sistema de navegación
            cmbFiltroLista1.Enabled = _navFiltro_Activo; //Importante: Protección de datos activos por medio del sistema de navegación
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
                string[] articuloSolicitado = new string[] { "Catalogo_Articulo",
                    objArticulo.Id.ToString(),
                    objArticulo.Denominacion,
                    objArticulo.Unidad,
                    Convert.ToString(objArticulo.CostoBruto),
                    Convert.ToString(objArticulo.CostoAlicuotaIVA),
                    Convert.ToString(objArticulo.CostoBaseIVA),
                    Convert.ToString(objArticulo.CostoNeto),
                    Convert.ToString(objArticulo.A1_Stock),
                    Convert.ToString(objArticulo.A2_Stock),
                    objArticulo.Estado };
                _formularioDeOrigen.asignarVariablesDeCuadricula(articuloSolicitado); //Datos para cuadricula
                _formularioDeOrigen.asignarVariablesDeFormulario(articuloSolicitado); //Datos para formulario
                this.Close();
            }
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR COD. BARRAS")
            {
                cmbFiltroLista1.Enabled = false;
                if (!_navFiltro_Activo) cmbFiltroLista1.Text = "FILTRAR POR ESTADO: ACTIVO";
                if (_navFiltro_Activo) cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
                txtFiltroLista.MaxLength = 25;
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
            {
                if (_navFiltro_Activo) cmbFiltroLista1.Enabled = true;
                txtFiltroLista.MaxLength = 15;
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR ID")
            {
                cmbFiltroLista1.Enabled = false;
                if (!_navFiltro_Activo) cmbFiltroLista1.Text = "FILTRAR POR ESTADO: ACTIVO";
                if (_navFiltro_Activo) cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
                txtFiltroLista.MaxLength = 6;
            }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroEstado = "TODOS";
            if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ACTIVO") filtroEstado = "ACTIVO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: BAJA") filtroEstado = "BAJA";
            if (cmbFiltroLista2.Text == "FILTRAR POR COD. BARRAS" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de documento
            {
                cargarCatalogo(nArticulo.obtenerCatalago(filtroEstado, "CODIGO_BARRAS", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la descripcion
            {
                cargarCatalogo(nArticulo.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de documento
            {
                cargarCatalogo(nArticulo.obtenerCatalago(filtroEstado, "ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objArticulo = nArticulo.obtenerObjeto("TODOS", "ID", lstCatalogo.SelectedValue.ToString(), true);
        }
        #endregion
    }
}
