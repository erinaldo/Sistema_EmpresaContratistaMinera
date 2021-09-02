using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormConsumoCentroCosto : Biblioteca.Formularios.FormBaseReporte
    {
        #region Atributos
        private N_ConsumoCentroCosto nConsumoCentroCosto = new N_ConsumoCentroCosto();
        private List<CatalogoBase> _lista = new List<CatalogoBase>();
        private ContextMenu menuContextual = new ContextMenu();
        #endregion

        public FormConsumoCentroCosto()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormConsumoCentroCosto_Load(object sender, EventArgs e)
        {
            definirMenuContextual(true, false); //Menu Contextual que se ejecuta al oprimir el boton derecho del mouse sobre el catálogo
            #region Asignación de Filtro por Defecto 
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            cmbPeriodo.Text = fechaActual.Month.ToString().PadLeft(2, '0');
            txtPeriodo.Text = fechaActual.Year.ToString();
            #endregion
            Formulario.ComboBox_CargarElementos(cmbCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { }), 0);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            filtrarCatalogo(0); //Carga el catálogo
        }

        private void lstCatalogo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = lstCatalogo.IndexFromPoint(e.Location); //Paso 1: Almacena el incide del elemento
                if (item >= 0)
                {
                    lstCatalogo.ClearSelected();
                    lstCatalogo.SelectedIndex = item; //Paso 2: Marca el item por el indice del elemento
                    lstCatalogo.SelectedItem = lstCatalogo.Text; //Paso 3: Selecciona el item de la lista
                    menuContextual.Show(lstCatalogo, e.Location); //Muestra el menú contextual sobre la lista del catálogo
                }
            }
        }
        #endregion

        #region Métodos de Formulario
        private void calcularTotal(double[] totales)
        {
            txtConsumoTotal.Text = Convert.ToString((int)totales[0]);
            txtDesechoTotal.Text = Convert.ToString((int)totales[1]);
            txtTotalCostoBruto.Text = Formulario.ValidarCampoMonedaMil(totales[2]);
            txtTotalCostoNeto.Text = Formulario.ValidarCampoMonedaMil(totales[3]);
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string periodo = cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value);
            _lista = nConsumoCentroCosto.obtenerCatalago(cmbCentroCosto.Text, periodo); //Carga los registros
            lstCatalogo.DataSource = _lista;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
            calcularTotal(nConsumoCentroCosto.obtenerConsumoTotal(cmbCentroCosto.Text, periodo)); //Calcula los totales del Consumo del Centro de Costo
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string periodo = cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value);
                _lista = nConsumoCentroCosto.obtenerCatalago(cmbCentroCosto.Text, periodo); //Carga los registros
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Denominación",
                    "Consumo",
                    "Desecho",
                    "Costo Bruto",
                    "Costo Neto" };
                foreach (CatalogoBase item in _lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //ID Artículo 
                        campo[1].Trim(), //Denominación 
                        campo[2].Trim(), //Consumo 
                        campo[3].Trim(), //Desecho 
                        "$"+campo[4].Trim(), //Costo Bruto
                        "$"+campo[5].Trim() }; //Costo Neto 
                    _listaDelReporte.Add(lineaDB);
                }
                string[] leyendasDeTotal = new string[]{
                    "Consumo total",
                    "Desecho total",
                    "Total costo bruto",
                    "Total costo neto" };
                string[] valoresDeTotal = new string[]{
                    txtConsumoTotal.Text,
                    txtDesechoTotal.Text,
                    "$" + Formulario.ValidarCampoMoneda(txtTotalCostoBruto.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtTotalCostoNeto.Text.Replace(".", ""))};
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                string tituloA = "Consumos por Centros de Costo (" + cmbCentroCosto.Text + ")";
                string tituloB = "Periodo " + cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value);
                reporte.crearDocumentoExcel_ListaConTotal(tituloA, tituloB, subTitulos, new int[] { 8, 73, 12, 12, 12, 12 }, _listaDelReporte, new List<int> { }, leyendasDeTotal, valoresDeTotal, 2, 2, 39, 100); //129
            }
        }
        #endregion
    }
}
