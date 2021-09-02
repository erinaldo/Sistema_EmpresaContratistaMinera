using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormLibroDiario : Biblioteca.Formularios.FormBase
    {
        #region Atributos
        private long _idCuentaContable = 0;
        private CuentaContable _cuentaContable = new CuentaContable();
        private N_LibroDiario nLibroDiario = new N_LibroDiario();
        private List<CatalogoBase> _lista = new List<CatalogoBase>();
        private ContextMenu menuContextual = new ContextMenu();
        #endregion

        public FormLibroDiario()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormLibroDiario_Load(object sender, EventArgs e)
        {
            #region Asignación de Fechas por Defecto 
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            pkrPeriodoDesde.Value = fechaActual.AddMonths(-1);
            pkrPeriodoHasta.Value = fechaActual;
            #endregion
            Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(new string[] { }), "TODAS LAS CUENTAS"); //Establece los items del ComboBox
            menuContextual.MenuItems.Add("Copiar texto del elemento", copiarTextoelemento); // Crea un item y lo agrega al menú contextual del boton derecho del mouse
            menuContextual.MenuItems.Add("Ver más datos…", mostrarMasDatos); // Crea un item y lo agrega al menú contextual del boton derecho del mouse
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarLibroDiario();
        }

        private void btnExcel_Libro_Click(object sender, EventArgs e)
        {
            reportarLibroDiario();
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
        private void cargarLibroDiario()
        {
            _cuentaContable = new N_CuentaContable().obtenerObjeto("DENOMINACION", cmbCuentaContable.Text, false);
            _idCuentaContable = (_cuentaContable != null) ? _cuentaContable.Id : 0;
            _lista = nLibroDiario.obtenerCatalago(_idCuentaContable, pkrPeriodoDesde.Value, pkrPeriodoHasta.Value); //Carga los Asientos Contables
            lstListado.DataSource = _lista;
            lstListado.ValueMember = "Id";
            lstListado.DisplayMember = "Denominacion";
            calcularTotal(nLibroDiario.contabilizarDebeHaber("ID_CUENTA", _idCuentaContable, pkrPeriodoDesde.Value, pkrPeriodoHasta.Value)); //Calcula el total del Debe y Haber del Libro Diario
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
            string texto = "Asiento N°" + columna[0].Trim() + "; Fecha: " + columna[1].Trim() + "; Cuenta Contable: " + columna[2].Trim() + "; " + columna[3].Trim() + "; Debe $" + columna[4].Trim() + "; Haber $" + columna[5].Trim();
            Clipboard.SetText(texto);
        }

        private void mostrarMasDatos(object sender, EventArgs e)
        {
            if (lstListado.Items.Count > 0)
            {
                string idNavegador = new N_AsientoContable().obtenerObjeto("ID", Convert.ToString(lstListado.SelectedValue), false).OrigenTipo + Convert.ToString(new N_AsientoContable().obtenerObjeto("ID", Convert.ToString(lstListado.SelectedValue), false).OrigenId).PadLeft(10, '0');
                if (idNavegador.Substring(0, 3) == "COB") //Cobranzas
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(144)) //Verifica que el usuario posea el privilegio requerido
                    {
                        Cobranza navCobranza = new N_Cobranza().obtenerObjeto("ID", idNavegador.Substring(3, 10), false);
                        Formulario.AbrirFormularioHermano(this, new FormCobranza(navCobranza));
                    }
                    else Mensaje.Restriccion();
                }
                else if (idNavegador.Substring(0, 3) == "CPR") //Comprobantes de Compra
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(20)) //Verifica que el usuario posea el privilegio requerido
                    {
                        Compra navCompra = new N_Compra().obtenerObjeto("ID", idNavegador.Substring(3, 10), false);
                        Formulario.AbrirFormularioHermano(this, new FormCompra(navCompra));
                    }
                    else Mensaje.Restriccion();
                }
                else if (idNavegador.Substring(0, 3) == "MOV") //Comprobantes de Movimientos de Fondos
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(152)) //Verifica que el usuario posea el privilegio requerido
                    {
                        MovimientoFondo navMovimientoFondo = new N_MovimientoFondo().obtenerObjeto("ID", idNavegador.Substring(3, 10), false);
                        Formulario.AbrirFormularioHermano(this, new FormMovimientoFondo(navMovimientoFondo));
                    }
                    else Mensaje.Restriccion();
                }
                else if (idNavegador.Substring(0, 3) == "PAN") //Pagos a Nómina
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(160)) //Verifica que el usuario posea el privilegio requerido
                    {
                        PagoNomina navPagoNomina = new N_PagoNomina().obtenerObjeto("ID", idNavegador.Substring(3, 10), false);
                        Formulario.AbrirFormularioHermano(this, new FormPagoNomina(navPagoNomina));
                    }
                    else Mensaje.Restriccion();
                }
                else if (idNavegador.Substring(0, 3) == "PAP") //Pagos a Proveedores
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(164)) //Verifica que el usuario posea el privilegio requerido
                    {
                        PagoProveedor navPagoProveedor = new N_PagoProveedor().obtenerObjeto("ID", idNavegador.Substring(3, 10), false);
                        Formulario.AbrirFormularioHermano(this, new FormPagoProveedor(navPagoProveedor));
                    }
                    else Mensaje.Restriccion();
                }
                else if (idNavegador.Substring(0, 3) == "PAO") //Otros Pagos
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(156)) //Verifica que el usuario posea el privilegio requerido
                    {
                        PagoOtro navPagoOtro = new N_PagoOtro().obtenerObjeto("ID", idNavegador.Substring(3, 10), false);
                        Formulario.AbrirFormularioHermano(this, new FormPagoOtro(navPagoOtro));
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

        private void reportarLibroDiario()
        {
            if (lstListado.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                _lista = nLibroDiario.obtenerCatalago(_idCuentaContable, pkrPeriodoDesde.Value, pkrPeriodoHasta.Value, "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "N° Asiento",
                    "Fecha",
                    "Cuenta Contable",
                    "Descripción",
                    "Debe $",
                    "Haber $" };
                foreach (CatalogoBase item in _lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //N° Asiento
                        campo[1].Trim(), //Fecha
                        campo[2].Trim(), //Cuenta Contable
                        campo[3].Trim(), //Descripción 
                        "$"+campo[4].Trim(), //Debe
                        "$"+campo[5].Trim() }; //Haber
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
                bool resaltarAsientoNro = (_idCuentaContable <= 0) ? true : false; //Resalta los números de asientos con color de fondo cuando se han seleccionado todas las Cuentas Contables
                string tituloA = "Libro Diario";
                string tituloB = "Periodo " + pkrPeriodoDesde.Text.Substring(0, 10).Replace("/", "-") + " Al " + pkrPeriodoHasta.Text.Substring(0, 10).Replace("/", "-");
                reporte.crearDocumentoExcel_ListaConTotal(tituloA, tituloB, subTitulos, new int[] { 12, 12, 25, 56, 12, 12 }, _listaDelReporte, new List<int> { 1 }, leyendasDeTotal, valoresDeTotal, 2, 1, 115, 100, resaltarAsientoNro);
            }
        }
        #endregion
    }
}  
