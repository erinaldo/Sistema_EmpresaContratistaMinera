using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormRG36852014 : Biblioteca.Formularios.FormBase
    {
        #region Atributos
        private List<CatalogoBase> lista = new List<CatalogoBase>();
        private ContextMenu menuContextual = new ContextMenu();
        #endregion

        public FormRG36852014()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormRG36852014_Load(object sender, EventArgs e)
        {
            #region Asignación de Filtro por Defecto 
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            cmbPeriodo.Text = fechaActual.Month.ToString().PadLeft(2, '0');
            txtPeriodo.Text = fechaActual.Year.ToString();
            cmbInformativo.Text = "COMPRAS";
            #endregion
            menuContextual.MenuItems.Add("Copiar texto del elemento", copiarTextoelemento); // Crea un item y lo agrega al menú contextual del boton derecho del mouse
            menuContextual.MenuItems.Add("Ver más datos…", mostrarMasDatos); // Crea un item y lo agrega al menú contextual del boton derecho del mouse
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarInformativo();
        }

        private void btnExcel_Informativo_Click(object sender, EventArgs e)
        {
            reportarInformativo();

        }

        private void btnGenerarTXT_Comprobante_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(57)) //Verifica que el usuario posea el privilegio requerido
            {
                GenerarArchivoTXT("COMPROBANTES");
            }
            else Mensaje.Restriccion();
        }

        private void btnGenerarTXT_Alicuota_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(57)) //Verifica que el usuario posea el privilegio requerido
            {
                GenerarArchivoTXT("ALICUOTAS");
            }
            else Mensaje.Restriccion();
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
        private void cargarInformativo()
        {
            string periodo = cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value);
            lista = (cmbInformativo.Text == "COMPRAS") ? new N_Compra().obtenerInformativo(periodo) : new N_Venta().obtenerInformativo(periodo); //Carga el contenido del Libro de IVA (Compras o Ventas)
            lstListado.DataSource = lista;
            lstListado.ValueMember = "Id";
            lstListado.DisplayMember = "Denominacion";
            lista = (cmbInformativo.Text == "COMPRAS") ? new N_Compra().obtenerInformativo(periodo, "CATALOGO2") : new N_Venta().obtenerInformativo(periodo, "CATALOGO2"); //Determina el Libro de IVA (Compras o Ventas)
            calcularTotal(lista); //Calcula los totales del Libro de IVA
        }

        private void calcularTotal(List<CatalogoBase> informativo)
        {
            double netoGravado = 0.00, noGravado = 0.00, exento = 0.00, impuestoInterno = 0.00, iva105 = 0.00,
                iva210 = 0.00, iva270 = 0.00, percepcionIIBB = 0.00, percepcionLH = 0.00, percepcionIVA = 0.00, total = 0.00;
            if (informativo.Count > 0)
            {
                foreach (CatalogoBase item in informativo)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string categoriaIVA = (cmbInformativo.Text == "COMPRAS") ? new N_Proveedor().obtenerObjeto("TODOS", "CUIT", Convert.ToString(campo[4]).Replace("-", "").Replace("/", ""), true).Iva
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

        private void GenerarArchivoTXT(string tipoExportacion)
        {
            string archivoTXT = Archivo.GuardarArchivo("TEXTO", "Informativo_de_" + Formulario.ValidarCampoTipoSubTitulo(cmbInformativo.Text) + "_Periodo_" + cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value) + "(" + tipoExportacion.ToLower() + ").txt");
            if (!string.IsNullOrEmpty(archivoTXT)) //Verifica que se obtuvo una ruta del archivo txt
            {
                if (lstListado.Items.Count > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Archivo.VaciarContenidoTXT(archivoTXT); //Borra todo el contenido del archivo txt indicado
                    foreach (CatalogoBase item in lista)
                    {
                        string contenido = "";
                        string fila = item.Denominacion.Replace(" | ", "|");
                        string[] campo = fila.Split('|');
                        string categoriaIVA = (cmbInformativo.Text == "COMPRAS") ? new N_Proveedor().obtenerObjeto("TODOS", "CUIT", Convert.ToString(campo[4]).Replace("-", "").Replace("/", ""), true).Iva
                            : new N_Cliente().obtenerObjeto("TODOS", "CUIT", Convert.ToString(campo[4]).Replace("-", "").Replace("/", ""), true).Iva;
                        if (tipoExportacion == "ALICUOTAS")
                        {
                            if (campo[0].Substring(4, 1) == "A" || campo[0].Substring(4, 1) == "M") //Verifica que el combrobante discrimine IVA (Tipos: A/M) 
                            {
                                string[] baseIVA = new string[] { campo[8], campo[9], campo[10] }; //Almacena la base del IVA en un vector (iva105, iva210, iva270)
                                for (int i=0; i<baseIVA.Length; i++) //Recorre el vector de la base del IVA
                                {
                                    if (Formulario.ValidarNumeroDoble(baseIVA[i]) > 0.00) //Determina si corresponde la alícuota por medio de su base de IVA 
                                    {
                                        contenido =
                                            Convert.ToString(Formulario.GenerarTipoComprobante(campo[0])).PadLeft(3, '0') + //Tipo de Comprobante
                                            (campo[1].Trim()).Split('-')[0].PadLeft(5, '0') + //Comprobante (PtoVta)
                                            (campo[1].Trim()).Split('-')[1].PadLeft(20, '0') + //Comprobante (Nro. de Comprobante)
                                            "80" + //Código de documento (Relleno utilizado por Aplicativo SIAP)
                                            (campo[4].Trim().Replace("-", "").Replace("/", "")).PadLeft(20, '0') + //CUIT del Proveedor/Cliente
                                            (campo[5].Trim().Replace("-", "").Replace(",", "")).PadLeft(15, '0') + //Neto Gravado (subTotal) 
                                            determinarCodigoDeAlicuota(i) + //Código de Alícuota
                                            (baseIVA[i].Trim().Replace("-", "").Replace(",", "")).PadLeft(15, '0'); //Monto base de IVA
                                        Archivo.EscribirTXT(archivoTXT, contenido); //Escribe la fila dentro del archivo txt (Alicuotas)
                                    }
                                }
                            }
                        }
                        if (tipoExportacion == "COMPROBANTES")
                        {
                            contenido =
                                Convert.ToString(Fecha.ValidarFecha(campo[2].Trim()).Year).PadLeft(4, '0') + //Año (Fecha)
                                Convert.ToString(Fecha.ValidarFecha(campo[2].Trim()).Month).PadLeft(2, '0') + //Año (Mes)
                                Convert.ToString(Fecha.ValidarFecha(campo[2].Trim()).Day).PadLeft(2, '0') + //Año (Día)
                                Convert.ToString(Formulario.GenerarTipoComprobante(campo[0])).PadLeft(3, '0') + //Tipo de Comprobante
                                (campo[1].Trim()).Split('-')[0].PadLeft(5, '0') + //Comprobante (PtoVta)
                                (campo[1].Trim()).Split('-')[1].PadLeft(20, '0') + //Comprobante (Nro. de Comprobante)
                                "                80" + //Código de documento (Relleno utilizado por Aplicativo SIAP)
                                (campo[4].Trim().Replace("-", "").Replace("/", "")).PadLeft(20, '0') + //CUIT del Proveedor/Cliente
                                (campo[3].Substring(0, 30)).PadRight(30, ' ') + //Razón Social del Proveedor/Cliente
                                (campo[14].Trim().Replace("-", "").Replace(",", "")).PadLeft(15, '0') + //Total   
                                (campo[6].Trim().Replace("-", "").Replace(",", "")).PadLeft(15, '0') + //No Gravado
                                "000000000000000" + //Percepción de operaciones exentas
                                (campo[13].Trim().Replace("-", "").Replace(",", "")).PadLeft(15, '0') + //Percepción IVA  
                                "000000000000000" + //Percepción Otros Imp. Nacionales
                                (Convert.ToString(Formulario.ValidarNumeroDoble(campo[11].Trim().Replace("-", "")) + Formulario.ValidarNumeroDoble(campo[12].Trim().Replace("-", ""))).Replace(",", "")).PadLeft(15, '0') + //Percepción IIBB y LH
                                "000000000000000" + //Percepción Imp. Municipales
                                (campo[7].Trim().Replace("-", "").Replace(",", "")).PadLeft(15, '0') + //Impuesto Interno 
                                "PES0001" + //Moneda y Tipo de cambio 
                                determinarCantidadDeAlicuota(campo[0], campo[8], campo[9], campo[10]) + //Cantidad alícuotas IVA (IVA %10.5, IVA %21.0, IVA %27.0)
                                determinarOperacion(categoriaIVA, campo[0], campo[8], campo[9], campo[10]) + //Código de operación
                                "00000000000000000000000000000000000000000                              000000000000000"; //Relleno utilizado por Aplicativo SIAP
                            Archivo.EscribirTXT(archivoTXT, contenido); //Escribe la fila dentro del archivo txt (Comprobantes)
                        }
                        #region Métodos Internos
                        string determinarCodigoDeAlicuota(int indice)
                        {
                            if (indice == 0) return "0004"; //IVA al %10.5
                            else if (indice == 1) return "0005"; //IVA al %21.0
                            else if (indice == 2) return "0006"; //IVA al %27.0
                            return "0003"; //IVA al %00.0
                        }
                        string determinarCantidadDeAlicuota(string tipoComprobante, string iva105, string iva210, string iva270)
                        {
                            int cantidadDeAlicuota = 0;
                            if (tipoComprobante.Substring(4, 1) == "A")
                            {
                                if (Math.Abs(Formulario.ValidarNumeroDoble(iva105)) > 0) cantidadDeAlicuota += 1;
                                else if (Math.Abs(Formulario.ValidarNumeroDoble(iva210)) > 0) cantidadDeAlicuota += 1;
                                else if (Math.Abs(Formulario.ValidarNumeroDoble(iva270)) > 0) cantidadDeAlicuota += 1;
                            }
                            return Convert.ToString(cantidadDeAlicuota).PadLeft(7, '0');
                        }
                        string determinarOperacion(string categoriaDeIVA, string tipoComprobante, string iva105, string iva210, string iva270)
                        {
                            int cantidadDeAlicuota = Formulario.ValidarNumeroEntero(determinarCantidadDeAlicuota(tipoComprobante, iva105, iva210, iva270)); //obtiene la cantidad de alicuotas de IVA
                            if (categoriaDeIVA == "SUJETO EXENTO") return "E";
                            else if (categoriaDeIVA == "RESPONSABLE INSCRIPTO" && cantidadDeAlicuota > 0) return "0";
                            return "N";
                        }
                        #endregion
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void mostrarMasDatos(object sender, EventArgs e)
        {
            if (lstListado.Items.Count > 0)
            {
                if (cmbInformativo.Text == "COMPRAS")
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(20)) //Verifica que el usuario posea el privilegio requerido
                    {
                        Compra navCompra = new N_Compra().obtenerObjeto("ID", Convert.ToString(lstListado.SelectedValue), false);
                        Formulario.AbrirFormularioHermano(this, new FormCompra(navCompra));
                    }
                    else Mensaje.Restriccion();
                }
                else if (cmbInformativo.Text == "VENTAS")
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

        private void reportarInformativo()
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
                        "$"+campo[6].Trim(), //No Gravado/Exento
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
                string tituloA = "Régimen de Información de " + Formulario.ValidarCampoTipoSubTitulo(cmbInformativo.Text);
                string tituloB = "Periodo " + cmbPeriodo.Text + "-" + Convert.ToString(txtPeriodo.Value);
                reporte.crearDocumentoExcel_ListaConTotal(tituloA, tituloB, subTitulos, new int[] { 5, 12, 8, 35, 11, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, _listaDelReporte, new List<int> { 2 }, leyendasDeTotal, valoresDeTotal, 4, 4, 29, 74);
            }
        }
        #endregion
    }
}  
