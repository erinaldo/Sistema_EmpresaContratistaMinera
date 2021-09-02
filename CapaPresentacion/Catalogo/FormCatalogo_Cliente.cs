using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Biblioteca.Formularios;
using Biblioteca.Ayudantes;
using Entidades;
using Entidades.Catalogo;
using CapaNegocio;

namespace CapaPresentacion.Catalogo
{
    public partial class FormCatalogo_Cliente : Biblioteca.Formularios.FormBaseCatalogo_LecturaF2
    {
        #region Atributos
        private string _navFiltro = "FILTRAR POR ESTADO: ACTIVO";
        private bool _navFiltro_Activo = false;
        private Cliente objCliente = new Cliente();
        private N_Cliente nCliente = new N_Cliente();
        private FormBase _formularioDeOrigen;
        #endregion

        public FormCatalogo_Cliente(FormBase formularioDeOrigen, string filtroEstado, bool filtroEstado_Activo = true)
        {
            _formularioDeOrigen = formularioDeOrigen;
            _navFiltro = filtroEstado;
            _navFiltro_Activo = filtroEstado_Activo;
            InitializeComponent();
        }

        #region Eventos
        private void FormCatalogo_Cliente_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO",
                "FILTRAR POR ESTADO: BAJA", "TODOS LOS ESTADOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT",
                "FILTRAR POR DENOMINACION" }, 1); //Establece los items del ComboBox
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
                _formularioDeOrigen.asignarVariablesDeFormulario(new string[] { "Catalogo_Cliente",
                    objCliente.Id.ToString(),
                    objCliente.Denominacion,
                    objCliente.Cuit,
                    Convert.ToString(objCliente.Saldo),
                    objCliente.Estado });
                this.Close();
            }
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
            {
                if (_navFiltro_Activo) cmbFiltroLista1.Enabled = true;
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR CUIT")
            {
                if (_navFiltro_Activo) cmbFiltroLista1.Enabled = true;
                if (_navFiltro_Activo) cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroEstado = "TODOS";
            if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ACTIVO") filtroEstado = "ACTIVO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: BAJA") filtroEstado = "BAJA";
            if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la descripcion
            {
                cargarCatalogo(nCliente.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de CUIT
            {
                cargarCatalogo(nCliente.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objCliente = nCliente.obtenerObjeto("TODOS", "ID", lstCatalogo.SelectedValue.ToString(), true);
        }
        #endregion
    }
}
