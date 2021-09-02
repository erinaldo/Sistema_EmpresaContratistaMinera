using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormEstadoResultados : Biblioteca.Formularios.FormBase
    {
        #region Atributos
        private N_EstadoResultados nEstadoResultados = new N_EstadoResultados();
        private List<CatalogoBase> _lista = new List<CatalogoBase>();
        private ContextMenu menuContextual = new ContextMenu();
        #endregion

        public FormEstadoResultados()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormEstadoResultados_Load(object sender, EventArgs e)
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
            cargarEstadoResultados();
        }

        private void btnExcel_Libro_Click(object sender, EventArgs e)
        {
            reportarEstadoResultados();
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
        private void cargarEstadoResultados()
        {
            string periodo = cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value);
            _lista = nEstadoResultados.obtenerCatalago(periodo); //Carga los Asientos Contables
            lstListado.DataSource = _lista;
            lstListado.ValueMember = "Id";
            lstListado.DisplayMember = "Denominacion";
        }

        private void copiarTextoelemento(object sender, EventArgs e)
        {
            Clipboard.SetText(lstListado.Text);
        }

        private void reportarEstadoResultados()
        {
            if (lstListado.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string periodo = cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value);
                _lista = nEstadoResultados.obtenerCatalago(periodo, "CATALOGO2"); //Carga los Asientos Contables
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Sub Título",
                    "Denominación",
                    "Total" };
                foreach (CatalogoBase item in _lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //Sub Título
                        campo[1].Trim(), //Denominación 
                        "$"+campo[2].Trim() }; //Total
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                string tituloA = "Estado de Resultados";
                string tituloB = "Periodo " + cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value);
                reporte.crearDocumentoExcel_ListaConTotal(tituloA, tituloB, subTitulos, new int[] { 40, 77, 12 }, _listaDelReporte, new List<int> { }, new string[] { }, new string[] { }, 0, 0, 29, 100, true); //129
            }
        }
        #endregion
    }
}  
