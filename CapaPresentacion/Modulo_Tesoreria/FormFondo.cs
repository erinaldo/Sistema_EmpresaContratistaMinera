using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormFondo : Biblioteca.Formularios.FormBase
    {
        #region Atributos
        private N_Fondo nFondo = new N_Fondo();
        private List<CatalogoBase> _lista = new List<CatalogoBase>();
        private ContextMenu menuContextual = new ContextMenu();
        #endregion

        public FormFondo()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormFondo_Load(object sender, EventArgs e)
        {
            #region Asignación de Fechas por Defecto 
            cmbCuentaContable.SelectedIndex = 0;
            #endregion
            menuContextual.MenuItems.Add("Copiar texto del elemento", copiarTextoelemento); // Crea un item y lo agrega al menú contextual del boton derecho del mouse
            cargarFormFondo(); //Carga la primera vista de 
        }

        private void btnExcel_Libro_Click(object sender, EventArgs e)
        {
            reportarFormFondo();
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
        private void cargarFormFondo()
        {
            _lista = nFondo.obtenerCatalago(); //Carga los Asientos Contables
            lstListado.DataSource = _lista;
            lstListado.ValueMember = "Id";
            lstListado.DisplayMember = "Denominacion";
            calcularTotal(); //Calcula el total de los fondos
        }

        private void calcularTotal()
        {
            double totalSaldo = 0;
            foreach (CatalogoBase item in _lista)
            {
                totalSaldo = totalSaldo + Formulario.ValidarNumeroDoble(item.Denominacion.Split('|')[2]); //Saldo
            }
            txtSaldo.Text = Formulario.ValidarCampoMoneda(totalSaldo); 
        }

        private void copiarTextoelemento(object sender, EventArgs e)
        {
            string fila = lstListado.Text.Replace("  ", "");
            string[] columna = fila.Split('|');
            string texto = "Tipo de Cuenta: " + columna[0].Trim() + "; Cuenta Contable: " + columna[1].Trim() + "; Saldo $" + columna[2].Trim();
            Clipboard.SetText(texto);
        }

        private void reportarFormFondo()
        {
            if (lstListado.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                _lista = nFondo.obtenerCatalago("CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Tipo de Cuenta",
                    "Cuenta Contable",
                    "Saldo $" };
                foreach (CatalogoBase item in _lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //Tipo de Cuenta
                        campo[1].Trim(), //Cuenta Contable 
                        campo[2].Trim() }; //Saldo
                    _listaDelReporte.Add(lineaDB);
                }
                string[] leyendasDeTotal = new string[]{
                    "Fondos a la fecha $"};
                string[] valoresDeTotal = new string[]{
                    "$" + Formulario.ValidarCampoMoneda(txtSaldo.Text.Replace(".", "")) };
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                string tituloA = "Fondos";
                string tituloB = "Saldos a la fecha (" + Fecha.SistemaFechaHora().Replace(":", "-").Replace("/", "-") + ")";
                reporte.crearDocumentoExcel_ListaConTotal(tituloA, tituloB, subTitulos, new int[] { 92, 25, 12 }, _listaDelReporte, new List<int> { }, leyendasDeTotal, valoresDeTotal, 1, 1, 115, 100, true);
            }
        }
        #endregion
    }
}  
