using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using CapaNegocio.Sistema;
using Entidades;
using Entidades.Catalogo;
using Entidades.Sistema;

namespace CapaPresentacion
{
    public partial class FormAlerta : Biblioteca.Formularios.FormBaseReporte
    {
        #region Atributos
        private string[] consultaAlerta;
        private Alerta objAlerta = new Alerta();
        private N_Alerta nAlerta = new N_Alerta();
        #endregion

        #region Constructores
        public FormAlerta()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void FormAlerta_Load(object sender, EventArgs e)
        {
            definirMenuContextual(true, true); //Menu Contextual que se ejecuta al oprimir el boton derecho del mouse sobre el catálogo
            #region ToolTips: Botones de navegación
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(cmbFiltroLista1, "Filtra por tipos de alertas");
            toolTip.SetToolTip(cmbFiltroLista2, "Filtra por tipos de estados");
            toolTip.SetToolTip(cmbFiltroLista3, "Filtra por sub tipos específicos");
            toolTip.SetToolTip(txtFiltroLista, "Filtra por coincidencia");
            toolTip.SetToolTip(btnProcesar, "Coloca en proceso las alertas seleccionadas");
            toolTip.SetToolTip(btnEliminar, "Elimina las alertas seleccionadas");
            #endregion
            cmbFiltroLista1.Text = "ALERTAS PERSONALIZADAS";
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR ESTADO: CADUCADO",
                "FILTRAR POR ESTADO: EN PROCESO", "FILTRAR POR ESTADO: SIN PROCESAR", "TODOS LOS ESTADOS" }, 3); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista3, new string[] { "FILTRAR POR DESCRIPCION",
                "FILTRAR POR ID", "FILTRAR POR FECHA DE VTO" }, 0); //Establece los items del ComboBox
            filtrarCatalogo(0);
        }

        private void cmbFiltroLista1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroLista1.Focused) filtrarCatalogo(0);
        }

        private void cmbFiltroLista2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0);
        }

        private void cmbFiltroLista3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroLista3.Focused) comboFiltro3();
        }

        private void txtFiltroLista_LostFocus(object sender, EventArgs e)
        {
            if (cmbFiltroLista3.Text != "FILTRAR POR DESCRIPCION") filtrarCatalogo(0);
        }

        private void txtFiltroLista_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbFiltroLista3.Text == "FILTRAR POR DESCRIPCION") filtrarCatalogo(0);
        }

        private void pkrFiltroListaDesde_LostFocus(object sender, EventArgs e)
        {
            filtrarCatalogo(0);
        }

        private void pkrFiltroListaHasta_LostFocus(object sender, EventArgs e)
        {
            filtrarCatalogo(0);
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(79)) //Verifica que el usuario posea el privilegio requerido
            {
                List<Alerta> lista = obtenerSeleccionDeElementos(); //Selecciona los elementos tildados
                if (lista.Count > 0)
                {
                    //Actualizar: Realiza esta operación cuando la lista tiene uno o mas elementos seleccionados
                    if (Mensaje.ConfirmacionBoton1("¿Desea colocar en proceso las alertas seleccionadas?") == DialogResult.Yes)
                    {
                        foreach (Alerta item in lista)
                        {
                            item.Estado = "EN PROCESO";
                            nAlerta.actualizar(item, false);
                        }
                        filtrarCatalogo(0);
                        Mensaje.Informacion("Las alertas seleccionadas se colocaron en proceso correctamente.");
                    }
                }
                else Mensaje.Advertencia("Operación incorrecta.\nSeleccione uno o más elementos de la lista e intente nuevamente.");
            }
            else Mensaje.Restriccion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(78)) //Verifica que el usuario posea el privilegio requerido
            {
                List<Alerta> lista = obtenerSeleccionDeElementos(); //Selecciona los elementos tildados
                if (lista.Count > 0)
                {
                    //Eliminar: Realiza esta operación cuando la lista tiene uno o mas elementos seleccionados
                    if (Mensaje.ConfirmacionBoton1("¿Desea eliminar las alertas seleccionadas?") == DialogResult.Yes)
                    {
                        foreach (Alerta item in lista)
                        {
                            nAlerta.eliminar(item.Id, false);
                        }
                        filtrarCatalogo(0);
                        Mensaje.Informacion("Las alertas seleccionadas se eliminaron correctamente.");
                    }
                }
                else Mensaje.Advertencia("Operación incorrecta.\nSeleccione uno o más elementos de la lista e intente nuevamente.");
            }
            else Mensaje.Restriccion();
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

        private List<Alerta> obtenerSeleccionDeElementos()
        {
            List<Alerta> listaDelCatalogo = new List<Alerta>();
            foreach (CatalogoBase item in lstCatalogo.SelectedItems)
            {
                Alerta objAlerta = nAlerta.obtenerObjeto("ID", item.Id.ToString(), true);
                listaDelCatalogo.Add(objAlerta);
            }
            return listaDelCatalogo;
        }

        private void comboFiltro3()
        {
            if (cmbFiltroLista3.SelectedItem.ToString() == "FILTRAR POR DESCRIPCION")
            {
                cmbFiltroLista1.Enabled = true;
                cmbFiltroLista2.Enabled = true;
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista3.SelectedItem.ToString() == "FILTRAR POR FECHA DE VTO")
            {
                cmbFiltroLista1.Enabled = true;
                cmbFiltroLista2.Enabled = true; Formulario.Visibilidad(false, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(true, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta }); //Verifica que se ha seleccionado el filtrado por fecha y habilita las casillas "desde y hasta"
            }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista3.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroAlerta = cmbFiltroLista1.Text;
            string filtroEstado = "TODOS";
            if (cmbFiltroLista2.Text == "FILTRAR POR ESTADO: EN PROCESO") filtroEstado = "EN PROCESO";
            else if (cmbFiltroLista2.Text == "FILTRAR POR ESTADO: SIN PROCESAR") filtroEstado = "SIN PROCESAR";
            else if (cmbFiltroLista2.Text == "FILTRAR POR ESTADO: CADUCADO") filtroEstado = "CADUCADO";
            if (cmbFiltroLista3.Text == "FILTRAR POR DESCRIPCION") //Verifica que el tipo de filtro es por concidencia letra en la denominación
            {
                consultaAlerta = new string[] { filtroAlerta, filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(new N_Alerta().obtenerCatalago(filtroAlerta, filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista3.Text == "FILTRAR POR FECHA DE VTO") //Verifica que el tipo de filtro es por fecha
            {
                consultaAlerta = new string[] { filtroAlerta, filtroEstado, "FECHA_VTO", txtFiltroLista.Text.Trim(), pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(new N_Alerta().obtenerCatalago(filtroAlerta, filtroEstado, "FECHA_VTO", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void navegarAFormulario()
        {
            if (!string.IsNullOrEmpty(objAlerta.IdNavegador))
            {
                string tipoModulo = objAlerta.IdNavegador.Substring(0, 3);
                string idModulo = objAlerta.IdNavegador.Substring(3, 10);
                if (tipoModulo == "ART")
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(58)) //Verifica que el usuario posea el privilegio requerido
                    {
                        Articulo navArticulo = new N_Articulo().obtenerObjeto("TODOS", "ID", idModulo, false);
                        Formulario.AbrirFormularioHermano(this, new FormArticulo(navArticulo));
                    }
                    else Mensaje.Restriccion();
                }
                else if(tipoModulo == "CAN" || tipoModulo == "LCO")
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(114)) //Verifica que el usuario posea el privilegio requerido
                    {
                        LegajoCurriculumVitae navLegajoCurriculumVitae = new N_LegajoCurriculumVitae().obtenerObjeto("ID", idModulo, false);
                        Formulario.AbrirFormularioHermano(this, new FormLegajoCurriculumVitae(navLegajoCurriculumVitae));
                    }
                    else Mensaje.Restriccion();
                }
                else if (tipoModulo == "CIN")
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(99)) //Verifica que el usuario posea el privilegio requerido
                    {
                        CursoInduccion navCursoInduccion = new N_CursoInduccion().obtenerObjeto("ID", idModulo, false);
                        Formulario.AbrirFormularioHermano(this, new FormCursoInduccion(navCursoInduccion));
                    }
                    else Mensaje.Restriccion();
                }
                else if (tipoModulo == "CIZ")
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(102)) //Verifica que el usuario posea el privilegio requerido
                    {
                        CursoIzaje navCursoIzaje = new N_CursoIzaje().obtenerObjeto("ID", idModulo, false);
                        Formulario.AbrirFormularioHermano(this, new FormCursoIzaje(navCursoIzaje));
                    }
                    else Mensaje.Restriccion();
                }
                else if (tipoModulo == "CPR")
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(20)) //Verifica que el usuario posea el privilegio requerido
                    {
                        Compra navCompra = new N_Compra().obtenerObjeto("ID", idModulo, false);
                        Formulario.AbrirFormularioHermano(this, new FormCompra(navCompra));
                    }
                    else Mensaje.Restriccion();
                }
                else if (tipoModulo == "EME")
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(110)) //Verifica que el usuario posea el privilegio requerido
                    {
                        ExamenMedico navExamenMedico = new N_ExamenMedico().obtenerObjeto("ID", idModulo, false);
                        Formulario.AbrirFormularioHermano(this, new FormExamenMedico(navExamenMedico));
                    }
                    else Mensaje.Restriccion();
                }
                else if (tipoModulo == "ETR")
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(106)) //Verifica que el usuario posea el privilegio requerido
                    {
                        Entrevista navEntrevista = new N_Entrevista().obtenerObjeto("ID", idModulo, false);
                        Formulario.AbrirFormularioHermano(this, new FormEntrevista(navEntrevista));
                    }
                    else Mensaje.Restriccion();
                }
                else if (tipoModulo == "VTA")
                {
                    if (Global.UsuarioActivo_Privilegios.Contains(173)) //Verifica que el usuario posea el privilegio requerido
                    {
                        Venta navVenta = new N_Venta().obtenerObjeto("ID", idModulo, false);
                        Formulario.AbrirFormularioHermano(this, new FormVenta(navVenta));
                    }
                    else Mensaje.Restriccion();
                }
            }
        }

        protected override void mostrarElemento(long idElemento)
        {
            objAlerta = nAlerta.obtenerObjeto("ID", idElemento.ToString(), false);
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                if (lstCatalogo.SelectedItems.Count > 0)
                {
                    foreach (Alerta item in obtenerSeleccionDeElementos())
                    {
                        CatalogoBase objCatalogoBase = new CatalogoBase(
                            item.Id,
                            item.Id.ToString().PadLeft(8, '0') + //Denominación
                            " | " + item.Denominacion + //Denominación
                            " | " + Fecha.ConvertirFecha(item.FechaVencimiento) + //Fecha de Vto.
                            " | " + item.Estado); //Estado
                        lista.Add(objCatalogoBase);
                    }
                }
                if (lstCatalogo.SelectedItems.Count <= 0 && consultaAlerta.Length == 4)
                    lista = nAlerta.obtenerCatalago(consultaAlerta[0], consultaAlerta[1], consultaAlerta[2], consultaAlerta[3], "CATALOGO1");
                else if (lstCatalogo.SelectedItems.Count <= 0 && consultaAlerta.Length == 5)
                    lista = nAlerta.obtenerCatalago(consultaAlerta[0], consultaAlerta[1], consultaAlerta[2], Fecha.ValidarFecha(consultaAlerta[3]), Fecha.ValidarFecha(consultaAlerta[4]), "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Descripción",
                    "Caducidad",
                    "Estado" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //ID
                        campo[1].Trim(), //Denominación
                        campo[2].Trim(), //Fecha Vto.
                        campo[3].Trim() };//Estado
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Alertas de Sistema", subTitulos, new int[] { 10, 98, 10, 12 }, _listaDelReporte, new List<int> { 2 }); //Ancho: 130
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Alertas de Sistema", subTitulos, new float[] { 8, 84, 9, 10 }, _listaDelReporte); //Ancho: 111
            }
        }
        #endregion
    }
}
