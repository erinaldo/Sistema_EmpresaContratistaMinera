using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio.Sistema;
using Entidades.Catalogo;
using Entidades.Sistema;

namespace CapaPresentacion
{
    public partial class FormAuditoria : Biblioteca.Formularios.FormBaseReporte
    {
        #region Atributos
        private string[] consultaAuditoria;
        private Auditoria objAuditoria = new Auditoria();
        private N_Auditoria nAuditoria = new N_Auditoria();
        #endregion

        public FormAuditoria()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FormAuditoria_Load(object sender, EventArgs e)
        {
            definirMenuContextual(true, false); //Menu Contextual que se ejecuta al oprimir el boton derecho del mouse sobre el catálogo
            #region ToolTips: Botones de navegación
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(cmbFiltroLista1, "Filtra por tipos de módulos");
            toolTip.SetToolTip(cmbFiltroLista2, "Filtra sub tipos específicos");
            toolTip.SetToolTip(txtFiltroLista, "Filtra por coincidencia");
            #endregion
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new N_Auditoria().obtenerListaDeModulo(), "TODOS LOS MODULOS"); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR DESCRIPCION",
                "FILTRAR POR DOCUMENTO", "FILTRAR POR FECHA" }, 0); //Establece los items del ComboBox
            filtrarCatalogo(0);
        }

        private void cmbFiltroLista1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroLista1.Focused) filtrarCatalogo(0);
        }

        private void cmbFiltroLista2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroLista2.Focused) comboFiltro2();
        }

        private void txtFiltroLista_LostFocus(object sender, EventArgs e)
        {
            if (cmbFiltroLista2.Text != "FILTRAR POR DESCRIPCION") filtrarCatalogo(0);
        }

        private void txtFiltroLista_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbFiltroLista2.Text == "FILTRAR POR DESCRIPCION") filtrarCatalogo(0);
        }

        private void pkrFiltroListaDesde_LostFocus(object sender, EventArgs e)
        {
            filtrarCatalogo(0);
        }

        private void pkrFiltroListaHasta_LostFocus(object sender, EventArgs e)
        {
            filtrarCatalogo(0);
        }
        #endregion

        #region Métodos
        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
            lstCatalogo.ClearSelected(); //Importante: No debe seleccionar ningun elemento en la lista al iniciar
        }

        private List<Auditoria> obtenerSeleccionDeElementos()
        {
            List<Auditoria> listaDelCatalogo = new List<Auditoria>();
            foreach (CatalogoBase item in lstCatalogo.SelectedItems)
            {
                Auditoria objAuditoria = nAuditoria.obtenerObjeto("ID", item.Id.ToString(), true);
                listaDelCatalogo.Add(objAuditoria);
            }
            return listaDelCatalogo;
        }

        private void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DESCRIPCION")
            {
                cmbFiltroLista1.Enabled = true;
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DOCUMENTO")
            {
                cmbFiltroLista1.Enabled = true;
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR ID")
            {
                cmbFiltroLista1.Enabled = false;
                cmbFiltroLista1.Text = "TODOS LOS MODULOS";
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA")
            {
                cmbFiltroLista1.Enabled = true;
                Formulario.Visibilidad(false, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(true, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta }); //Verifica que se ha seleccionado el filtrado por fecha y habilita las casillas "desde y hasta"
            }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroModulo = "TODOS";
            if (cmbFiltroLista1.Text != "TODOS LOS MODULOS") filtroModulo = cmbFiltroLista1.Text.Trim();
            if (cmbFiltroLista2.Text == "FILTRAR POR DESCRIPCION") //Verifica que el tipo de filtro es por concidencia letra en la denominación
            {
                consultaAuditoria = new string[] { filtroModulo, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(new N_Auditoria().obtenerCatalago(filtroModulo, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DOCUMENTO" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de documento
            {
                consultaAuditoria = new string[] { filtroModulo, "DOCUMENTO", txtFiltroLista.Text.Trim() };
                cargarCatalogo(new N_Auditoria().obtenerCatalago(filtroModulo, "DOCUMENTO", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por ID
            {
                consultaAuditoria = new string[] { filtroModulo, "ID", txtFiltroLista.Text.Trim() };
                cargarCatalogo(new N_Auditoria().obtenerCatalago(filtroModulo, "ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA") //Verifica que el tipo de filtro es por fecha
            {
                consultaAuditoria = new string[] { filtroModulo, "FECHA", txtFiltroLista.Text.Trim(), pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(new N_Auditoria().obtenerCatalago(filtroModulo, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objAuditoria = nAuditoria.obtenerObjeto("ID", idElemento.ToString(), false);
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                if (lstCatalogo.SelectedItems.Count > 0)
                    foreach (Auditoria item in obtenerSeleccionDeElementos())
                    {
                        CatalogoBase objCatalogoBase = new CatalogoBase(
                            item.Id,
                            item.Id.ToString().PadLeft(8, '0') + //ID
                            " | " + Fecha.ConvertirFecha(item.Fecha) + //Fecha
                            " | " + item.Modulo + //Modulo
                            " | " + item.Denominacion); //Denominacion de actividad
                        lista.Add(objCatalogoBase);
                    }
                if (lstCatalogo.SelectedItems.Count <= 0 && consultaAuditoria.Length == 3)
                    lista = nAuditoria.obtenerCatalago(consultaAuditoria[0], consultaAuditoria[1], consultaAuditoria[2], "CATALOGO1");
                else if (lstCatalogo.SelectedItems.Count <= 0 && consultaAuditoria.Length == 4)
                    lista = nAuditoria.obtenerCatalago(consultaAuditoria[0], consultaAuditoria[1], Fecha.ValidarFecha(consultaAuditoria[2]), Fecha.ValidarFecha(consultaAuditoria[3]), "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Fecha",
                    "Módulo",
                    "Descripción" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //ID
                        campo[1].Trim(), //Fecha
                        campo[2].Trim(), //Módulo
                        campo[3].Trim() };//Denominación
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Auditoría de Actividades de Usuario", subTitulos, new int[] { 10, 10, 30, 80 }, _listaDelReporte, new List<int> { 1 }); //Ancho: 130
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Auditoría de Actividades de Usuario", subTitulos, new float[] { 8, 8, 25, 70 }, _listaDelReporte); //Ancho: 111
            }
        }
        #endregion
    }
}