using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormLibroIVA : Biblioteca.Formularios.FormBase
    {
        #region Atributos
        private List<CatalogoBase> lista = new List<CatalogoBase>();
        private ContextMenu menuContextual = new ContextMenu();
        #endregion

        public FormLibroIVA()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormLibroIVA_Load(object sender, EventArgs e)
        {
            #region Asignación de Filtro por Defecto 
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            cmbPeriodo.Text = fechaActual.Month.ToString().PadLeft(2, '0');
            txtPeriodo.Text = fechaActual.Year.ToString();
            cmbLibro.Text = "IVA COMPRAS";
            #endregion
            menuContextual.MenuItems.Add("Copiar texto del elemento", copiarTextoelemento); // Crea un item y lo agrega al menú contextual del boton derecho del mouse
            menuContextual.MenuItems.Add("Ver más datos…", mostrarMasDatos); // Crea un item y lo agrega al menú contextual del boton derecho del mouse
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarLibroIVA(); //Carga el catálogo
        }

        private void btnExcel_Libro_Click(object sender, EventArgs e)
        {
            reportarLibroIVA();

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
        private void cargarLibroIVA()
        {
            string periodo = cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value);
            lista = (cmbLibro.Text == "IVA COMPRAS") ? new N_Compra().obtenerLibroIVA(periodo) : new N_Venta().obtenerLibroIVA(periodo); //Carga el contenido del Libro de IVA (Compras o Ventas)
            lstListado.DataSource = lista;
            lstListado.ValueMember = "Id";
            lstListado.DisplayMember = "Denominacion";
            lista = (cmbLibro.Text == "IVA COMPRAS") ? new N_Compra().obtenerLibroIVA(periodo, "CATALOGO2") : new N_Venta().obtenerLibroIVA(periodo, "CATALOGO2"); //Determina el Libro de IVA (Compras o Ventas)
            calcularTotal(lista); //Calcula los totales del Libro de IVA
        }

        private void calcularTotal(List<CatalogoBase> libroIVA)
        {
            double netoGravado = 0.00, noGravado = 0.00, exento = 0.00, impuestoInterno = 0.00, iva105 = 0.00,
                iva210 = 0.00, iva270 = 0.00, percepcionIIBB = 0.00, percepcionLH = 0.00, percepcionIVA = 0.00, total = 0.00;
            if (libroIVA.Count > 0)
            {
                foreach (CatalogoBase item in libroIVA)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string categoriaIVA = (cmbLibro.Text == "IVA COMPRAS") ? new N_Proveedor().obtenerObjeto("TODOS", "CUIT", Convert.ToString(campo[4]).Replace("-", "").Replace("/", ""), true).Iva 
                        : new N_Cliente().obtenerObjeto("TODOS", "CUIT", Convert.ToString(campo[4]).Replace("-", "").Replace("/", ""), true).Iva;
                    netoGravado += Formulario.ValidarNumeroDoble(Convert.ToString(campo[5])); //Neto Gravado
                    noGravado += Formulario.ValidarNumeroDoble(Convert.ToString(campo[6])); //No Gravado
                    exento += (categoriaIVA == "SUJETO EXENTO") ? Formulario.ValidarNumeroDoble(Convert.ToString(campo[5])) : 0.00; //Exento
                    impuestoInterno += Formulario.ValidarNumeroDoble(Convert.ToString(campo[7])); //Imp. Interno
                    iva105 += Formulario.ValidarNumeroDoble(Convert.ToString(campo[8])); //IVA %10.5
                    iva210 += Formulario.ValidarNumeroDoble(Convert.ToString(campo[9])); //IVA %21.0
                    iva270 += Formulario.ValidarNumeroDoble(Convert.ToString(campo[10])); //IVA %27.0
                    percepcionIIBB += Formulario.ValidarNumeroDoble(Convert.ToString(campo[11])); //Percepción IIBB
                    percepcionLH += Formulario.ValidarNumeroDoble(Convert.ToString(campo[12])); //Percepción LH
                    percepcionIVA += Formulario.ValidarNumeroDoble(Convert.ToString(campo[13])); //Percepción IVA
                    total += Formulario.ValidarNumeroDoble(Convert.ToString(campo[14])); //Total
                }
            }
            txtNetoGravado.Text = Formulario.ValidarCampoMonedaMil(netoGravado);
            txtNoGravado.Text = Formulario.ValidarCampoMonedaMil(noGravado);
            txtExento.Text = Formulario.ValidarCampoMonedaMil(exento);
            txtImpuestoInterno.Text = Formulario.ValidarCampoMonedaMil(impuestoInterno);
            txtIVA105.Text = Formulario.ValidarCampoMonedaMil(iva105);
            txtIVA210.Text = Formulario.ValidarCampoMonedaMil(iva210);
            txtIVA270.Text = Formulario.ValidarCampoMonedaMil(iva270);
            txtTotalIVA.Text = Formulario.ValidarCampoMonedaMil(iva105 + iva210 + iva270); //Suma los IVA
            txtPercepcionIIBB.Text = Formulario.ValidarCampoMonedaMil(percepcionIIBB);
            txtPercepcionLH.Text = Formulario.ValidarCampoMonedaMil(percepcionLH);
            txtPercepcionIVA.Text = Formulario.ValidarCampoMonedaMil(percepcionIVA); //Suma las percepciones
            txtTotalPercepcion.Text = Formulario.ValidarCampoMonedaMil(percepcionIIBB + percepcionLH + percepcionIVA);
            txtTotal.Text = Formulario.ValidarCampoMonedaMil(total);
        }

        private void copiarTextoelemento(object sender, EventArgs e)
        {
            string fila = lstListado.Text.Replace("  ", "");
            string[] columna = fila.Split('|');
            string texto = "Comprobante: " + columna[0].Trim() + " N°" + columna[1].Trim() + "; Fecha: " + columna[2].Trim() + "; Denominación: " + columna[3].Trim() + " (" + columna[4].Trim() + "); Neto Grav. $" + columna[5].Trim() + "; Total $" + columna[6].Trim();
            Clipboard.SetText(texto);
        }

        private void mostrarMasDatos(object sender, EventArgs e)
        {
            if (lstListado.Items.Count > 0)
            {
                if (cmbLibro.Text == "IVA COMPRAS")
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(20)) //Verifica que el usuario posea el privilegio requerido
                    {
                        Compra navCompra = new N_Compra().obtenerObjeto("ID", Convert.ToString(lstListado.SelectedValue), false);
                        Formulario.AbrirFormularioHermano(this, new FormCompra(navCompra));
                    }
                    else Mensaje.Restriccion();
                }
                else if (cmbLibro.Text == "IVA VENTAS")
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(173)) //Verifica que el usuario posea el privilegio requerido
                    {
                        Venta navVenta = new N_Venta().obtenerObjeto("ID", Convert.ToString(lstListado.SelectedValue), false);
                        Formulario.AbrirFormularioHermano(this, new FormVenta(navVenta));
                    }
                    else Mensaje.Restriccion();
                }
            }
        }

        private void reportarLibroIVA()
        {
            if (lstListado.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Tipo",
                    "Comprobante",
                    "Fecha",
                    "Denominación",
                    "CUIT",
                    "Neto Grav.",
                    "No Gravado",
                    "Imp. Int.",
                    "IVA %10.5",
                    "IVA %21.0",
                    "IVA %27.0",
                    "Percep. IIBB",
                    "Percep. LH",
                    "Percep. IVA",
                    "Total" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //Tipo de Comprobante
                        campo[1].Trim(), //Comprobante (PtoVta y Nro. de Comprobante)
                        campo[2].Trim(), //Fecha
                        campo[3].Trim(), //Denominación 
                        campo[4].Trim(), //CUIT
                        "$"+campo[5].Trim(), //Neto Gravado
                        "$"+campo[6].Trim(), //No Gravado
                        "$"+campo[7].Trim(), //Imp. Interno
                        "$"+campo[8].Trim(), //IVA %10.5
                        "$"+campo[9].Trim(), //IVA %21.0
                        "$"+campo[10].Trim(), //IVA %27.0
                        "$"+campo[11].Trim(), //Percepción IIBB
                        "$"+campo[12].Trim(), //Percepción LH
                        "$"+campo[13].Trim(), //Percepción IVA
                        "$"+campo[14].Trim() }; //Total
                    _listaDelReporte.Add(lineaDB);
                }
                string[] leyendasDeTotal = new string[]{
                    "Total neto grabado",
                    "Total no grabado",
                    "Total exento",
                    "Total imp. interno",
                    "Total IVA %10.5",
                    "Total IVA %21.0",
                    "Total IVA %27.0",
                    "Total IVA",
                    "Total percep. IIBB",
                    "Total percep. LH",
                    "Total percep. IVA",
                    "Total percepciones",
                    "Total" };
                string[] valoresDeTotal = new string[]{
                    "$" + Formulario.ValidarCampoMoneda(txtNetoGravado.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtNoGravado.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtExento.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtImpuestoInterno.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtIVA105.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtIVA210.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtIVA270.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtTotalIVA.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtPercepcionIIBB.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtPercepcionLH.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtPercepcionIVA.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtTotalPercepcion.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtTotal.Text.Replace(".", ""))};
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                string tituloA = "Libro de " + Formulario.ValidarCampoTipoSubTitulo(cmbLibro.Text);
                string tituloB = "Periodo " + cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value);
                reporte.crearDocumentoExcel_ListaConTotal(tituloA, tituloB, subTitulos, new int[] { 5, 12, 8, 35, 11, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, _listaDelReporte, new List<int> { 2 }, leyendasDeTotal, valoresDeTotal, 4, 4, 29, 74);
            }
        }
        #endregion
    }
}  
