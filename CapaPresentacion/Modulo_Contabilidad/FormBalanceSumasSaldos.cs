using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormBalanceSumasSaldos : Biblioteca.Formularios.FormBase
    {
        #region Atributos
        private N_BalanceSumasSaldos nBalanceSumasSaldos = new N_BalanceSumasSaldos();
        private List<CatalogoBase> _lista = new List<CatalogoBase>();
        private ContextMenu menuContextual = new ContextMenu();
        #endregion

        public FormBalanceSumasSaldos()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormBalanceSumasSaldos_Load(object sender, EventArgs e)
        {
            #region Asignación de Fechas por Defecto 
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            pkrPeriodoDesde.Value = fechaActual.AddMonths(-1);
            pkrPeriodoHasta.Value = fechaActual;
            #endregion
            menuContextual.MenuItems.Add("Copiar texto del elemento", copiarTextoelemento); // Crea un item y lo agrega al menú contextual del boton derecho del mouse
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarBalanceSumasSaldos();
        }

        private void btnExcel_Libro_Click(object sender, EventArgs e)
        {
            reportarBalanceSumasSaldos();
        }

        private void lstListado_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = lstListado.IndexFromPoint(e.Location); //Paso 1: Almacena el incide del elemento
                if (item >= 0)
                {
                    lstListado.ClearSelected();
                    lstListado.SelectedIndex = item; //Paso 2: Marca el item por el indice del elemento
                    lstListado.SelectedItem = lstListado.Text; //Paso 3: Selecciona el item de la lista
                    menuContextual.Show(lstListado, e.Location); //Muestra el menú contextual sobre la lista del catálogo
                }
            }
        }
        #endregion

        #region Métodos de Formulario
        private void cargarBalanceSumasSaldos()
        {
            _lista = nBalanceSumasSaldos.obtenerCatalago(pkrPeriodoDesde.Value, pkrPeriodoHasta.Value); //Carga los Asientos Contables
            lstListado.DataSource = _lista;
            lstListado.ValueMember = "Id";
            lstListado.DisplayMember = "Denominacion";
            calcularTotal(nBalanceSumasSaldos.contabilizarDebeHaber(pkrPeriodoDesde.Value, pkrPeriodoHasta.Value)); //Calcula el total del Debe y Haber del Libro Mayor
        }

        private void calcularTotal(double[] contabilidad)
        {
            txtDebe.Text = Formulario.ValidarCampoMoneda(contabilidad[0]); //Debe
            txtHaber.Text = Formulario.ValidarCampoMoneda(contabilidad[1]); //Haber
        }

        private void copiarTextoelemento(object sender, EventArgs e)
        {
            string fila = lstListado.Text.Replace("  ", "");
            string[] columna = fila.Split('|');
            string texto = "Tipo de Cuenta: " + columna[0].Trim() + "; Cuenta Contable: " + columna[1].Trim() + "; Debe $" + columna[2].Trim() + "; Haber $" + columna[3].Trim() + "; Saldo $" + columna[4].Trim();
            Clipboard.SetText(texto);
        }

        private void reportarBalanceSumasSaldos()
        {
            if (lstListado.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                _lista = nBalanceSumasSaldos.obtenerCatalago(pkrPeriodoDesde.Value, pkrPeriodoHasta.Value, "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Tipo de Cuenta",
                    "Cuenta Contable",
                    "Debe $",
                    "Haber $",
                    "Saldo $" };
                foreach (CatalogoBase item in _lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //Tipo de Cuenta
                        campo[1].Trim(), //Cuenta Contable 
                        campo[2].Trim(), //Debe
                        campo[3].Trim(), //Haber
                        campo[4].Trim() }; //Saldo
                    _listaDelReporte.Add(lineaDB);
                }
                string[] leyendasDeTotal = new string[]{
                    "Total Debe",
                    "Total Haber"};
                string[] valoresDeTotal = new string[]{
                    "$" + Formulario.ValidarCampoMoneda(txtDebe.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtHaber.Text.Replace(".", "")) };
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                string tituloA = "Balance de Sumas y Saldos";
                string tituloB = "Periodo " + pkrPeriodoDesde.Text.Substring(0, 10).Replace("/", "-") + " Al " + pkrPeriodoHasta.Text.Substring(0, 10).Replace("/", "-");
                reporte.crearDocumentoExcel_ListaConTotal(tituloA, tituloB, subTitulos, new int[] { 68, 25, 12, 12, 12 }, _listaDelReporte, new List<int> { }, leyendasDeTotal, valoresDeTotal, 2, 1, 115, 100, true);
            }
        }
        #endregion
    }
}  
