using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormChequeAPagar : Biblioteca.Formularios.FormBaseReporte
    {
        #region Atributos
        private N_ChequeAPagar nChequeAPagar = new N_ChequeAPagar();
        private List<CatalogoBase> _lista = new List<CatalogoBase>();
        private ContextMenu menuContextual = new ContextMenu();
        #endregion

        public FormChequeAPagar()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario
        private void FormChequeAPagar_Load(object sender, EventArgs e)
        {
            definirMenuContextual(true, true); //Menu Contextual que se ejecuta al oprimir el boton derecho del mouse sobre el catálogo
            #region Asignación de Fechas por Defecto 
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            pkrIntervaloDesde.Value = fechaActual.AddMonths(-1);
            pkrIntervaloHasta.Value = fechaActual;
            #endregion
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            filtrarCatalogo(0); //Carga el catálogo
        }
        #endregion

        #region Métodos de Formulario
        private void calcularTotal()
        {
            txtChequeProveedor.Text = Formulario.ValidarCampoMonedaMil(nChequeAPagar.obtenerDeudaAProveedor(pkrIntervaloDesde.Value, pkrIntervaloHasta.Value));
            txtChequeNomina.Text = Formulario.ValidarCampoMonedaMil(nChequeAPagar.obtenerDeudaANomina(pkrIntervaloDesde.Value, pkrIntervaloHasta.Value));
            txtChequeOtro.Text = Formulario.ValidarCampoMonedaMil(nChequeAPagar.obtenerDeudaAOtro(pkrIntervaloDesde.Value, pkrIntervaloHasta.Value));
            txtChequeTotal.Text = Formulario.ValidarCampoMonedaMil(Formulario.ValidarNumeroDoble(txtChequeProveedor.Text) + Formulario.ValidarNumeroDoble(txtChequeNomina.Text) + Formulario.ValidarNumeroDoble(txtChequeOtro.Text));
        }

        protected override void navegarAFormulario() {
            if (lstCatalogo.Items.Count > 0)
            {
                string idNavegador = new N_AsientoContable().obtenerObjeto("ID", Convert.ToString(lstCatalogo.SelectedValue), false).OrigenTipo + Convert.ToString(new N_AsientoContable().obtenerObjeto("ID", Convert.ToString(lstCatalogo.SelectedValue), false).OrigenId).PadLeft(10, '0');
                if (idNavegador.Substring(0, 3) == "PAP") //Conciliación a Proveedores
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(164)) //Verifica que el usuario posea el privilegio requerido
                    {
                        PagoProveedor navPagoProveedor = new N_PagoProveedor().obtenerObjeto("ID", idNavegador.Substring(3, 10), false);
                        Formulario.AbrirFormularioHermano(this, new FormPagoProveedor(navPagoProveedor));
                    }
                    else Mensaje.Restriccion();
                }
                if (idNavegador.Substring(0, 3) == "PAN") //Conciliación a Proveedores
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(160)) //Verifica que el usuario posea el privilegio requerido
                    {
                        PagoNomina navPagoNomina = new N_PagoNomina().obtenerObjeto("ID", idNavegador.Substring(3, 10), false);
                        Formulario.AbrirFormularioHermano(this, new FormPagoNomina(navPagoNomina));
                    }
                    else Mensaje.Restriccion();
                }
                if (idNavegador.Substring(0, 3) == "PAO") //Conciliación a Proveedores
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(156)) //Verifica que el usuario posea el privilegio requerido
                    {
                        PagoOtro navPagoOtro = new N_PagoOtro().obtenerObjeto("ID", idNavegador.Substring(3, 10), false);
                        Formulario.AbrirFormularioHermano(this, new FormPagoOtro(navPagoOtro));
                    }
                    else Mensaje.Restriccion();
                }
            }
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            _lista = nChequeAPagar.obtenerCatalago(pkrIntervaloDesde.Value, pkrIntervaloHasta.Value, "CATALOGO1", indicePagina, Global.PaginacionTamanio);
            lstCatalogo.DataSource = _lista;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
            calcularTotal(); //Calcula los totales de los cheques adeudados 
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                _lista = nChequeAPagar.obtenerCatalago(pkrIntervaloDesde.Value, pkrIntervaloHasta.Value, "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Cheque N°",
                    "F. Emisión",
                    "F. Vto.",
                    "Denominación",
                    "Monto $",
                    "Descripción" };
                foreach (CatalogoBase item in _lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //Cheque N° 
                        campo[1].Trim(), //F. Emisión
                        campo[2].Trim(), //F. Vto.
                        campo[3].Trim(), //Denominación
                        "$"+campo[4].Trim(), //Monto
                        campo[5].Trim() }; //Descripción
                    _listaDelReporte.Add(lineaDB);
                }
                string[] leyendasDeTotal = new string[]{
                    "Cheques a Proveedores",
                    "Cheques a Nomina",
                    "Cheques a Otros",
                    "Total Cheques" };
                string[] valoresDeTotal = new string[]{
                    "$" + Formulario.ValidarCampoMoneda(txtChequeProveedor.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtChequeNomina.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtChequeOtro.Text.Replace(".", "")),
                    "$" + Formulario.ValidarCampoMoneda(txtChequeTotal.Text.Replace(".", "")) };
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                string tituloA = "Cheques a Pagar";
                string tituloB = "Intervalo " + pkrIntervaloDesde.Text.Substring(0, 10).Replace("/", "-") + " Al " + pkrIntervaloHasta.Text.Substring(0, 10).Replace("/", "-");
                reporte.crearDocumentoExcel_ListaConTotal(tituloA, tituloB, subTitulos, new int[] { 10, 10, 10, 50, 12, 40 }, _listaDelReporte, new List<int> { 1, 2 }, leyendasDeTotal, valoresDeTotal, 2, 2, 41, 100);
            }
        }
        #endregion
    }
}
