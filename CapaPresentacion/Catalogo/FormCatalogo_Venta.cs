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
    public partial class FormCatalogo_Venta : Biblioteca.Formularios.FormBaseCatalogo_LecturaF2
    {
        #region Atributos
        private string _navFiltroExclusivoCobroCUIT = "";
        private Venta objVenta = new Venta();
        private N_Venta nVenta = new N_Venta();
        private FormBase _formularioDeOrigen;
        #endregion

        public FormCatalogo_Venta(FormBase formularioDeOrigen, string filtroExclusivoCobroCUIT = "TODOS")
        {
            _formularioDeOrigen = formularioDeOrigen;
            _navFiltroExclusivoCobroCUIT = filtroExclusivoCobroCUIT;
            InitializeComponent();
        }

        #region Eventos
        private void FormCatalogo_Venta_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "TODOS LOS COMPROBANTES" }, 0); //Establece los items del ComboBox
            if (_navFiltroExclusivoCobroCUIT != "TODOS") //Verifica si se ha recibido un CUIT desde el Comprobante de Cobro, de ser asi, personaliza la busqueda
            {
                txtFiltroLista.Text = _navFiltroExclusivoCobroCUIT; //Re-Asigna el valor de busqueda
                Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT",
                "FILTRAR POR FECHA (CBTE)", "FILTRAR POR FECHA DE COBRO", "FILTRAR POR PERIODO", "FILTRAR POR VTO. DE COBRO" }, 0); //Re-Establece los items del ComboBox
            }
            else
            {
                Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CAE", "FILTRAR POR CUIT",
                "FILTRAR POR DENOMINACION", "FILTRAR POR FECHA (CBTE)", "FILTRAR POR FECHA DE COBRO", "FILTRAR POR ID",
                "FILTRAR POR PERIODO" }, 2); //Establece los items del ComboBox
            }
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
                string[] ventaSolicitada = new string[] { "Catalogo_Venta",
                    objVenta.Id.ToString() };
                _formularioDeOrigen.asignarVariablesDeCuadricula(ventaSolicitada); //Datos para cuadricula
                _formularioDeOrigen.asignarVariablesDeFormulario(ventaSolicitada); //Datos para formulario
                this.Close();
            }
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR CAE")
            {
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR CUIT")
            {
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
                txtFiltroLista.Enabled = ((_navFiltroExclusivoCobroCUIT == "TODOS") ? true : false);
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
            {
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA (CBTE)")
            {
                Formulario.Visibilidad(false, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(true, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta }); //Verifica que se ha seleccionado el filtrado por fecha y habilita las casillas "desde y hasta"
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA DE COBRO")
            {
                Formulario.Visibilidad(false, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(true, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta }); //Verifica que se ha seleccionado el filtrado por fecha y habilita las casillas "desde y hasta"
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR ID")
            {
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR PERIODO")
            {
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR VTO. DE COBRO")
            {
                Formulario.Visibilidad(false, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(true, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta }); //Verifica que se ha seleccionado el filtrado por fecha y habilita las casillas "desde y hasta"
            }
            txtFiltroLista.Text = ((_navFiltroExclusivoCobroCUIT != "TODOS" && cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR CUIT") ? _navFiltroExclusivoCobroCUIT : "");
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            if (cmbFiltroLista2.Text == "FILTRAR POR CAE" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el CAE
            {
                cargarCatalogo(nVenta.obtenerCatalago(0, "CAE", txtFiltroLista.Text.Trim(), "CATALOGO2", indicePagina, Global.PaginacionTamanio, _navFiltroExclusivoCobroCUIT));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por CUIT
            {
                cargarCatalogo(nVenta.obtenerCatalago(0, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO2", indicePagina, Global.PaginacionTamanio, _navFiltroExclusivoCobroCUIT));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por Denominación
            {
                cargarCatalogo(nVenta.obtenerCatalago(0, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO2", indicePagina, Global.PaginacionTamanio, _navFiltroExclusivoCobroCUIT));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA (CBTE)") //Verifica que el tipo de filtro es por Fecha de Comprobante
            {
                cargarCatalogo(nVenta.obtenerCatalago(0, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO2", indicePagina, Global.PaginacionTamanio, _navFiltroExclusivoCobroCUIT));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA DE COBRO") //Verifica que el tipo de filtro es por Fecha de Comprobante
            {
                cargarCatalogo(nVenta.obtenerCatalago(0, "FECHA_COBRO", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO2", indicePagina, Global.PaginacionTamanio, _navFiltroExclusivoCobroCUIT));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por ID
            {
                cargarCatalogo(nVenta.obtenerCatalago(0, "ID", txtFiltroLista.Text.Trim(), "CATALOGO2", indicePagina, Global.PaginacionTamanio, _navFiltroExclusivoCobroCUIT));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR PERIODO" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por Periodo
            {
                cargarCatalogo(nVenta.obtenerCatalago(0, "PERIODO", txtFiltroLista.Text.Trim(), "CATALOGO2", indicePagina, Global.PaginacionTamanio, _navFiltroExclusivoCobroCUIT));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR VTO. DE COBRO") //Verifica que el tipo de filtro es por Fecha de Pago
            {
                cargarCatalogo(nVenta.obtenerCatalago(0, "FECHA_COBRO", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objVenta = nVenta.obtenerObjeto("ID", lstCatalogo.SelectedValue.ToString(), true);
        }
        #endregion
    }
}
