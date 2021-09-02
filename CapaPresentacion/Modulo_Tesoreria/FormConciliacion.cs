using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormConciliacion : Biblioteca.Formularios.FormBase
    {
        #region Atributos
        private long _idCuentaContable = 0;
        private string _filtroEstadoConciliacion = "";
        private CuentaContable _cuentaContable = new CuentaContable();
        private N_Conciliacion nConciliacion = new N_Conciliacion();
        private ContextMenu menuContextual = new ContextMenu();
        private List<CatalogoBase> _lista = new List<CatalogoBase>();
        #endregion

        public FormConciliacion()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormConciliacion_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbCuentaContable, new N_CuentaContable().obtenerListaDeElementos(new string[] { "DISPONIBILIDADES" }), "TODAS LAS CUENTAS"); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbEstadoConciliacion, new string[] { "FILTRAR POR ESTADO: CONCILIADO", "FILTRAR POR ESTADO: S/CONCILIAR", "TODOS LOS ESTADOS" }, 1); //Establece los items del ComboBox
            menuContextual.MenuItems.Add("Copiar texto del elemento", copiarTextoelemento); // Crea un item y lo agrega al menú contextual del boton derecho del mouse
            menuContextual.MenuItems.Add("Ver más datos…", mostrarMasDatos); // Crea un item y lo agrega al menú contextual del boton derecho del mouse
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarConciliacion();
        }

        private void btnExcel_Libro_Click(object sender, EventArgs e)
        {
            reportarConciliacion();
        }

        private void btnConciliar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(149)) //Verifica que el usuario posea el privilegio requerido
            {
                List<Conciliacion> listaDeElementosSeleccionados = obtenerSeleccionDeElementos(); //Selecciona los elementos tildados
                if (listaDeElementosSeleccionados.Count > 0)
                {
                    //Actualizar: Realiza esta operación cuando la lista tiene uno o mas elementos seleccionados
                    if (Mensaje.ConfirmacionBoton1("¿Desea conciliar los asientos seleccionados?") == DialogResult.Yes)
                    {
                        nConciliacion.conciliar(listaDeElementosSeleccionados, true);
                        cargarConciliacion(); //Re-Carga el Listado
                    }
                }
                else Mensaje.Advertencia("Operación incorrecta.\nSeleccione uno o más elementos de la lista e intente nuevamente.");
            }
            else Mensaje.Restriccion();
        }

        private void btnDesconciliar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(150)) //Verifica que el usuario posea el privilegio requerido
            {
                List<Conciliacion> listaDeElementosSeleccionados = obtenerSeleccionDeElementos(); //Selecciona los elementos tildados
                if (listaDeElementosSeleccionados.Count > 0)
                {
                    //Actualizar: Realiza esta operación cuando la lista tiene uno o mas elementos seleccionados
                    if (Mensaje.ConfirmacionBoton1("¿Desea Desconciliar los asientos seleccionados?") == DialogResult.Yes)
                    {
                        nConciliacion.desconciliar(listaDeElementosSeleccionados, true);
                        cargarConciliacion(); //Re-Carga el Listado
                    }
                }
                else Mensaje.Advertencia("Operación incorrecta.\nSeleccione uno o más elementos de la lista e intente nuevamente.");
            }
            else Mensaje.Restriccion();
        }

        private void chkMarcarMovimientos_CheckedChanged(object sender, EventArgs e)
        {
            seleccionarTodosLosElementos(chkMarcarMovimientos.Checked);
        }

        private void lstListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstListado.Items.Count > 0 && lstListado.Focused)
            {
                try
                {
                  //  mostrarElemento(Convert.ToInt32(lstListado.SelectedValue));
                }
                catch (IndexOutOfRangeException) { }
            }
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
        private List<Conciliacion> obtenerSeleccionDeElementos()
        {
            List<Conciliacion> listaObjetos = new List<Conciliacion>();
            foreach (CatalogoBase item in lstListado.SelectedItems)
            {
                Conciliacion objConciliacion = nConciliacion.obtenerObjeto("ID", item.Id.ToString(), true); //Busca el Objeto en la Base de Datos
                listaObjetos.Add(objConciliacion); //Agrega el objeto a la lista
            }
            return listaObjetos;
        }

        private void cargarConciliacion()
        {
            _filtroEstadoConciliacion = "TODOS";
            if (cmbEstadoConciliacion.Text == "FILTRAR POR ESTADO: CONCILIADO") _filtroEstadoConciliacion = "CONCILIADO";
            else if (cmbEstadoConciliacion.Text == "FILTRAR POR ESTADO: S/CONCILIAR") _filtroEstadoConciliacion = "S/CONCILIAR";
            _cuentaContable = new N_CuentaContable().obtenerObjeto("DENOMINACION", cmbCuentaContable.Text, false);
            _idCuentaContable = (_cuentaContable != null) ? _cuentaContable.Id : 0;
            _lista = nConciliacion.obtenerCatalago(_filtroEstadoConciliacion, _idCuentaContable); //Carga los Asientos Contables
            lstListado.DataSource = _lista;
            lstListado.ValueMember = "Id";
            lstListado.DisplayMember = "Denominacion";
            calcularTotal(nConciliacion.contabilizarDebeHaber(_idCuentaContable)); //Calcula el total del Debe y Haber
            lstListado.ClearSelected(); //Importante: Desmarca todos los elementos del listado
        }

        private void calcularTotal(double[] contabilidad)
        {
            txtTotalDebe.Text = Formulario.ValidarCampoMonedaMil(contabilidad[0]); //Total Debe
            txtTotalDebeSinConciliar.Text = Formulario.ValidarCampoMonedaMil(contabilidad[2]); //Total Debe sin Conciliar
            txtTotalHaber.Text = Formulario.ValidarCampoMonedaMil(contabilidad[1]); //Total Haber
            txtTotalHaberSinConciliar.Text = Formulario.ValidarCampoMonedaMil(contabilidad[3]); //Total Haber sin Conciliar
            txtTotalSaldoReal.Text = Formulario.ValidarCampoMonedaMil(contabilidad[4] - contabilidad[5]); //Total Saldo Real
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
                else if (idNavegador.Substring(0, 3) == "PAN") //Conciliación a Nómina
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(160)) //Verifica que el usuario posea el privilegio requerido
                    {
                        PagoNomina navPagoNomina = new N_PagoNomina().obtenerObjeto("ID", idNavegador.Substring(3, 10), false);
                        Formulario.AbrirFormularioHermano(this, new FormPagoNomina(navPagoNomina));
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

        private void reportarConciliacion()
        {
            if (lstListado.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                _lista = nConciliacion.obtenerCatalago(_filtroEstadoConciliacion, _idCuentaContable, "CATALOGO2"); //Carga los Asientos Contables
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Cuenta Contable",
                    "Fecha",
                    "Descripción",
                    "Debe $",
                    "Haber $",
                    "Estado" };
                foreach (CatalogoBase item in _lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //Cuenta Contable
                        campo[1].Trim(), //Fecha
                        campo[2].Trim(), //Descripción
                        campo[3].Trim(), //Debe 
                        campo[4].Trim(), //Haber
                        campo[5].Trim() }; //Estado
                    _listaDelReporte.Add(lineaDB);
                }
                string[] leyendasDeTotal = new string[]{
                    "Total debe",
                    "Total debe sin conciliar",
                    "Total haber",
                    "Total haber sin conciliar",
                    "Total saldo real"};
                string[] valoresDeTotal = new string[]{
                    "$" + Formulario.ValidarCampoMoneda(txtTotalDebe.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtTotalDebeSinConciliar.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtTotalHaber.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtTotalHaberSinConciliar.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtTotalSaldoReal.Text.Replace(".", "")) };
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                bool resaltarAsientoNro = (_idCuentaContable <= 0) ? true : false; //Resalta los números de asientos con color de fondo cuando se han seleccionado todas las Cuentas Contables
                string tituloA = "Conciliación de Cuentas";
                string tituloB = "";
                reporte.crearDocumentoExcel_ListaConTotal(tituloA, tituloB, subTitulos, new int[] { 48, 10, 35, 12, 12, 12 }, _listaDelReporte, new List<int> { 1 }, leyendasDeTotal, valoresDeTotal, 2, 3, 29, 100, resaltarAsientoNro);
            }
        }

        private void seleccionarTodosLosElementos(bool seleccion)
        {
            if (seleccion) for (int i = 0; i < lstListado.Items.Count; i++) lstListado.SelectedIndex = i; //Marca todos los elementos del listado
            else lstListado.ClearSelected(); //Desmarca todos los elementos del listado
        }
        #endregion
    }
}  
