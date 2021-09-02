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
    public partial class FormCatalogo_ContratoTrabajo : Biblioteca.Formularios.FormBaseCatalogo_LecturaF2
    {
        #region Atributos
        private string _navFiltro = "TODOS LOS ESTADOS";
        private Contrato objContrato = new Contrato();
        private N_Contrato nContrato = new N_Contrato();
        private FormBase _formularioDeOrigen;
        #endregion

        public FormCatalogo_ContratoTrabajo(FormBase formularioDeOrigen, string filtroEstado)
        {
            _formularioDeOrigen = formularioDeOrigen;
            _navFiltro = filtroEstado;
            InitializeComponent();
        }

        #region Eventos
        private void FormCatalogo_ContratoTrabajo_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: RESCINDIDO",
                "FILTRAR POR ESTADO: VIGENTE", "TODOS LOS ESTADOS" }, 1); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR DENOMINACION",
                "FILTRAR POR DOCUMENTO", "FILTRAR POR FECHA DE ALTA", "FILTRAR POR FECHA DE BAJA",  "FILTRAR POR ID CONTRATO" }, 0); //Establece los items del ComboBox
            cmbFiltroLista1.Text = _navFiltro; //Importante: Sistema de navegación
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
                _formularioDeOrigen.asignarVariablesDeFormulario(new string[] { "Catalogo_Contrato",
                    objContrato.Id.ToString(),
                    objContrato.Legajo.Denominacion,
                    //objContrato.Legajo.Documento,
                    objContrato.CentroCosto.Id.ToString(),
                    objContrato.CentroCosto.Denominacion,
                    objContrato.ModalidadLiquidacion,
                    objContrato.Legajo.Saldo.ToString(),
                    (objContrato.Legajo.Banco != null ) ? objContrato.Legajo.Banco.Denominacion : "", //Importante: Se utiliza para los datos de transferencia en el Pago de Nómina
                    (objContrato.Legajo.Banco != null ) ? objContrato.Legajo.CtaBancariaTipo : "", //Importante: Se utiliza para los datos de transferencia en el Pago de Nómina
                    (objContrato.Legajo.Banco != null ) ? objContrato.Legajo.CtaBancariaNro : "" }); //Importante: Se utiliza para los datos de transferencia en el Pago de Nómina
                this.Close();
            }
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
            {
                cmbFiltroLista1.Enabled = true;
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DOCUMENTO")
            {
                cmbFiltroLista1.Enabled = true;
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR ID CONTRATO")
            {
                cmbFiltroLista1.Enabled = false;
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA DE ALTA")
            {
                cmbFiltroLista1.Enabled = true;
                Formulario.Visibilidad(false, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(true, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta }); //Verifica que se ha seleccionado el filtrado por fecha y habilita las casillas "desde y hasta"
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA DE BAJA")
            {
                cmbFiltroLista1.Enabled = true;
                Formulario.Visibilidad(false, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(true, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta }); //Verifica que se ha seleccionado el filtrado por fecha y habilita las casillas "desde y hasta"
            }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroEstado = "TODOS";
            if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: RESCINDIDO") filtroEstado = "RESCINDIDO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: VIGENTE") filtroEstado = "VIGENTE";
            if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la descripcion
            {
                cargarCatalogo(nContrato.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DOCUMENTO" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de documento
            {
                cargarCatalogo(nContrato.obtenerCatalago(filtroEstado, "DOCUMENTO", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA DE ALTA") //Verifica que el tipo de filtro es por el numero de documento
            {
                cargarCatalogo(nContrato.obtenerCatalago(filtroEstado, "FECHA_ALTA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA DE BAJA") //Verifica que el tipo de filtro es por el numero de documento
            {
                cargarCatalogo(nContrato.obtenerCatalago(filtroEstado, "FECHA_BAJA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR ID CONTRATO" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de documento
            {
                cargarCatalogo(nContrato.obtenerCatalago(filtroEstado, "ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objContrato = nContrato.obtenerObjeto("ID", lstCatalogo.SelectedValue.ToString(), true);
        }
        #endregion
    }
}
