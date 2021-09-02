using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormFacturaACobrar : Biblioteca.Formularios.FormBaseReporte
    {
        #region Atributos
        private N_FacturaACobrar nFacturaACobrar = new N_FacturaACobrar();
        private string _filtroCatalogo = "";
        private List<CatalogoBase> _lista = new List<CatalogoBase>();
        private ContextMenu menuContextual = new ContextMenu();
        #endregion

        public FormFacturaACobrar()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormFacturaACobrar_Load(object sender, EventArgs e)
        {
            definirMenuContextual(true, true); //Menu Contextual que se ejecuta al oprimir el boton derecho del mouse sobre el catálogo
            #region Asignación de Fechas por Defecto 
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            pkrIntervaloDesde.Value = fechaActual.AddMonths(-1);
            pkrIntervaloHasta.Value = fechaActual;
            #endregion
            Formulario.ComboBox_CargarElementos(cmbFiltro, new string[] { "FILTRAR POR CUIT", "TODOS LAS CUENTAS" }, 1); //Establece los items del ComboBox
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            filtrarCatalogo(0); //Carga el catálogo
        }
        #endregion

        #region Métodos de Formulario
        private void calcularTotal(double[] contabilidad)
        {
            txtTotalACobrar.Text = Formulario.ValidarCampoMonedaMil(contabilidad[0]); //Debe
        }

        protected override void navegarAFormulario() {
            if (lstCatalogo.Items.Count > 0)
            {
                string idNavegador = new N_AsientoContable().obtenerObjeto("ID", Convert.ToString(lstCatalogo.SelectedValue), false).OrigenTipo + Convert.ToString(new N_AsientoContable().obtenerObjeto("ID", Convert.ToString(lstCatalogo.SelectedValue), false).OrigenId).PadLeft(10, '0');
                if (idNavegador.Substring(0, 3) == "COB") //Cobranzas
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(144)) //Verifica que el usuario posea el privilegio requerido
                    {
                        Cobranza navCobranza = new N_Cobranza().obtenerObjeto("ID", idNavegador.Substring(3, 10), false);
                        Formulario.AbrirFormularioHermano(this, new FormCobranza(navCobranza));
                    }
                    else Mensaje.Restriccion();
                }
                else if (idNavegador.Substring(0, 3) == "VTA") //Comprobantes de Venta
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(173)) //Verifica que el usuario posea el privilegio requerido
                    {
                        Venta navVenta = new N_Venta().obtenerObjeto("ID", idNavegador.Substring(3, 10), false);
                        Formulario.AbrirFormularioHermano(this, new FormVenta(navVenta));
                    }
                    else Mensaje.Restriccion();
                }
            }
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            if (cmbFiltro.Text == "FILTRAR POR CUIT") _filtroCatalogo = "CUIT";
            else _filtroCatalogo = "TODOS";
            _lista = nFacturaACobrar.obtenerCatalago(_filtroCatalogo, txtFiltro.Text, pkrIntervaloDesde.Value, pkrIntervaloHasta.Value, "CATALOGO1", indicePagina, Global.PaginacionTamanio);
            lstCatalogo.DataSource = _lista;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
            calcularTotal(nFacturaACobrar.contabilizarDebeHaber(_filtroCatalogo, txtFiltro.Text, pkrIntervaloDesde.Value, pkrIntervaloHasta.Value)); //Calcula el total del Debe y Haber de la Cta. Cte.
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                _lista = nFacturaACobrar.obtenerCatalago(_filtroCatalogo, txtFiltro.Text, pkrIntervaloDesde.Value, pkrIntervaloHasta.Value, "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Denominación",
                    "CUIT",
                    "Fecha",
                    "Descripción",
                    "Monto $",
                    "Estado" };
                foreach (CatalogoBase item in _lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //Denominación
                        campo[1].Trim(), //CUIT
                        campo[2].Trim(), //Fecha
                        campo[3].Trim(), //Descripción 
                        "$"+campo[4].Trim(), //Monto 
                        campo[5].Trim()}; //estado de Cobro
                    _listaDelReporte.Add(lineaDB);
                }
                string[] leyendasDeTotal = new string[]{
                    "Total a Cobrar" };
                string[] valoresDeTotal = new string[]{
                    "$" + Formulario.ValidarCampoMoneda(txtTotalACobrar.Text.Replace(".", "")) };
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                string tituloA = "Facturas a Cobrar";
                string tituloB = "Intervalo " + pkrIntervaloDesde.Text.Substring(0, 10).Replace("/", "-") + " Al " + pkrIntervaloHasta.Text.Substring(0, 10).Replace("/", "-");
                reporte.crearDocumentoExcel_ListaConTotal(tituloA, tituloB, subTitulos, new int[] { 43, 13, 10, 43, 12, 8 }, _listaDelReporte, new List<int> { 2 }, leyendasDeTotal, valoresDeTotal, 1, 1, 115, 100, true);
            }
        }
        #endregion
    }
}
