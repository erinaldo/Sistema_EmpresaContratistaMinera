using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormResumenAsientoSueldo : Biblioteca.Formularios.FormBase
    {
        #region Atributos
        private N_ResumenAsientoSueldo nResumenAsientoSueldo = new N_ResumenAsientoSueldo();
        private List<CatalogoBase> _lista = new List<CatalogoBase>();
        private ContextMenu menuContextual = new ContextMenu();
        #endregion

        public FormResumenAsientoSueldo()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormResumenAsientoSueldo_Load(object sender, EventArgs e)
        {
            #region Asignación de Filtro por Defecto 
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            cmbPeriodo.Text = fechaActual.Month.ToString().PadLeft(2, '0');
            txtPeriodo.Text = fechaActual.Year.ToString();
            #endregion
            menuContextual.MenuItems.Add("Copiar texto del elemento", copiarTextoelemento); // Crea un item y lo agrega al menú contextual del boton derecho del mouse
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarResumenAsientoSueldo();
        }

        private void btnExcel_Libro_Click(object sender, EventArgs e)
        {
            reportarResumenAsientoSueldo();
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
        private void cargarResumenAsientoSueldo()
        {
            string periodo = cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value);
            _lista = nResumenAsientoSueldo.obtenerCatalago(periodo); //Carga los Asientos Contables
            lstListado.DataSource = _lista;
            lstListado.ValueMember = "Id";
            lstListado.DisplayMember = "Denominacion";
            calcularTotal(nResumenAsientoSueldo.contabilizarDebeHaber(periodo)); //Calcula el total del Debe y Haber del Resumen
        }

        private void calcularTotal(double[] contabilidad)
        {
            txtDebe.Text = Formulario.ValidarCampoMonedaMil(contabilidad[0]); //Debe
            txtHaber.Text = Formulario.ValidarCampoMonedaMil(contabilidad[1]); //Haber
        }

        private void copiarTextoelemento(object sender, EventArgs e)
        {
            string fila = lstListado.Text.Replace("  ", "");
            string[] columna = fila.Split('|');
            string texto = "Cuenta Contable: " + columna[0].Trim() + "; Debe $" + columna[1].Trim() + "; Haber $" + columna[2].Trim();
            Clipboard.SetText(texto);
        }

        private void reportarResumenAsientoSueldo()
        {
            if (lstListado.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string periodo = cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value);
                _lista = nResumenAsientoSueldo.obtenerCatalago(periodo, "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Cuenta Contable",
                    "Debe $",
                    "Haber $" };
                foreach (CatalogoBase item in _lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //Cuenta Contable 
                        "$"+campo[1].Trim(), //Debe
                        "$"+campo[2].Trim() }; //Haber
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
                string tituloA = "Resumen de Asientos de Sueldo";
                string tituloB = "Periodo " + periodo;
                reporte.crearDocumentoExcel_ListaConTotal(tituloA, tituloB, subTitulos, new int[] { 105, 12, 12 }, _listaDelReporte, new List<int> { }, leyendasDeTotal, valoresDeTotal, 2, 1, 115, 100, false);
            }
        }
        #endregion
    }
}  
