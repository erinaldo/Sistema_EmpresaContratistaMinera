using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormProveedorCtaCte : Biblioteca.Formularios.FormBaseReporte
    {
        #region Atributos
        private N_ProveedorCtaCte nProveedorCtaCte = new N_ProveedorCtaCte();
        private string _filtroCatalogo = "";
        private List<CatalogoBase> _lista = new List<CatalogoBase>();
        private ContextMenu menuContextual = new ContextMenu();
        #endregion

        public FormProveedorCtaCte()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormProveedorCtaCte_Load(object sender, EventArgs e)
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
            txtDebe.Text = Formulario.ValidarCampoMonedaMil(contabilidad[0]); //Debe
            txtHaber.Text = Formulario.ValidarCampoMonedaMil(contabilidad[1]); //Haber
        }

        protected override void navegarAFormulario() {
            if (lstCatalogo.Items.Count > 0)
            {
                string idNavegador = new N_AsientoContable().obtenerObjeto("ID", Convert.ToString(lstCatalogo.SelectedValue), false).OrigenTipo + Convert.ToString(new N_AsientoContable().obtenerObjeto("ID", Convert.ToString(lstCatalogo.SelectedValue), false).OrigenId).PadLeft(10, '0');
                if (idNavegador.Substring(0, 3) == "CPR") //Comprobantes de Compra
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(20)) //Verifica que el usuario posea el privilegio requerido
                    {
                        Compra navCompra = new N_Compra().obtenerObjeto("ID", idNavegador.Substring(3, 10), false);
                        Formulario.AbrirFormularioHermano(this, new FormCompra(navCompra));
                    }
                    else Mensaje.Restriccion();
                }
                else if (idNavegador.Substring(0, 3) == "PAP") //Conciliación a Proveedores
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(164)) //Verifica que el usuario posea el privilegio requerido
                    {
                        PagoProveedor navPagoProveedor = new N_PagoProveedor().obtenerObjeto("ID", idNavegador.Substring(3, 10), false);
                        Formulario.AbrirFormularioHermano(this, new FormPagoProveedor(navPagoProveedor));
                    }
                    else Mensaje.Restriccion();
                }
            }
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            if (cmbFiltro.Text == "FILTRAR POR CUIT") _filtroCatalogo = "CUIT";
            else _filtroCatalogo = "TODOS";
            _lista = nProveedorCtaCte.obtenerCatalago(_filtroCatalogo, txtFiltro.Text, pkrIntervaloDesde.Value, pkrIntervaloHasta.Value, "CATALOGO1", indicePagina, Global.PaginacionTamanio);
            lstCatalogo.DataSource = _lista;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
            calcularTotal(nProveedorCtaCte.contabilizarDebeHaber(_filtroCatalogo, txtFiltro.Text, pkrIntervaloDesde.Value, pkrIntervaloHasta.Value)); //Calcula el total del Debe y Haber de la Cta. Cte.
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                _lista = nProveedorCtaCte.obtenerCatalago(_filtroCatalogo, txtFiltro.Text, pkrIntervaloDesde.Value, pkrIntervaloHasta.Value, "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Denominación",
                    "CUIT",
                    "Fecha",
                    "Descripción",
                    "Debe $",
                    "Haber $",
                    "Saldo $" };
                foreach (CatalogoBase item in _lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //Denominación
                        campo[1].Trim(), //CUIT
                        campo[2].Trim(), //Fecha
                        campo[3].Trim(), //Descripción 
                        "$"+campo[4].Trim(), //Debe
                        "$"+campo[5].Trim(), //Haber
                        "$"+campo[6].Trim() }; //Saldo
                    _listaDelReporte.Add(lineaDB);
                }
                string[] leyendasDeTotal = new string[]{
                    "Total Debe",
                    "Total Haber" };
                string[] valoresDeTotal = new string[]{
                    "$" + Formulario.ValidarCampoMoneda(txtDebe.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtHaber.Text.Replace(".", "")) };
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                string tituloA = "Cta. Cte. de Proveedores";
                string tituloB = "Intervalo " + pkrIntervaloDesde.Text.Substring(0, 10).Replace("/", "-") + " Al " + pkrIntervaloHasta.Text.Substring(0, 10).Replace("/", "-");
                reporte.crearDocumentoExcel_ListaConTotal(tituloA, tituloB, subTitulos, new int[] { 35, 13, 10, 35, 12, 12, 12 }, _listaDelReporte, new List<int> { 2 }, leyendasDeTotal, valoresDeTotal, 2, 1, 115, 100, true);
            }
        }
        #endregion
    }
}
