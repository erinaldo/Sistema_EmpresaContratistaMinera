using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormPlanDeCuenta : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private long _idCuentaContable = 0;
        string[] consultaCuentaContable;
        private CuentaContable objCuentaContable;
        private N_CuentaContable nCuentaContable = new N_CuentaContable();
        #endregion

        public FormPlanDeCuenta()
        {
            InitializeComponent();
        }

        #region Eventos: Formulario
        private void FormPlanDeCuenta_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR RAMA: ACTIVOS",
                "FILTRAR POR RAMA: EGRESOS", "FILTRAR POR RAMA: INGRESOS", "FILTRAR POR RAMA: PASIVOS",
                "FILTRAR POR RAMA: PATRIMONIOS", "TODOS LAS RAMAS" }, 5); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CODIGO", "FILTRAR POR DENOMINACION", "FILTRAR POR ID" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
            escribirArbol(); //Escribe el contenido del arbol
        }

        private void FormPlanDeCuenta_Shown(object sender, EventArgs e)
        {
            lstCatalogo.SelectedValue = _idCuentaContable; //Posiona la selección de la fila en el registro guardado
        }

        private void treePlanCuenta_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treePlanCuenta.SelectedNode != null && treePlanCuenta.SelectedNode.Name.Substring(0, 5) == "Hoja_")
            {
                escribirControles(nCuentaContable.obtenerObjeto("CODIGO", treePlanCuenta.SelectedNode.Name.Substring(5, 6), true)); //Escribe los datos del registro seleccionado
            }
        }

        private void btnExportarPlanDeCuenta_Click(object sender, EventArgs e)
        {
            if (treePlanCuenta.Nodes.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = { "Arbol de Cuentas Contable" };
                TreeNodeCollection nodos = treePlanCuenta.Nodes;
                foreach (TreeNode nodoPadre in nodos)
                {
                    _listaDelReporte.Add(new string[] { nodoPadre.Text }); //Captura el texto del Nodo Padre
                    foreach (TreeNode nodoHijo in nodoPadre.Nodes)
                    {
                        _listaDelReporte.Add(new string[] { "   " + nodoHijo.Text }); //Captura el texto del Nodo Hijo
                        foreach (TreeNode nodoNieto in nodoHijo.Nodes)
                        {
                            _listaDelReporte.Add(new string[] { "       " + nodoNieto.Text }); //Captura el texto del Nodo Nieto
                            foreach (TreeNode nodoBisNieto in nodoNieto.Nodes)
                            {
                                _listaDelReporte.Add(new string[] { "           " + nodoBisNieto.Text }); //Captura el texto del Nodo BisNieto
                                foreach (TreeNode nodoBisBisNieto in nodoBisNieto.Nodes)
                                {
                                    _listaDelReporte.Add(new string[] { "               " + nodoBisBisNieto.Text }); //Captura el texto del Nodo BisBisNieto
                                }
                            }
                        }
                    }
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                reporte.crearDocumentoPDF_Lista("Plan de Cuentas", subTitulos, new float[] { 111 }, _listaDelReporte); //Ancho: 111
            }

        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(47)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idCuentaContable <= 0 && Global.UsuarioActivo_Privilegios.Contains(47)) //Verifica que el usuario posea el privilegio requerido
            {
                //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        objCuentaContable.Id = nCuentaContable.generarNumeroID(); //Paso 2: Asigna un numero de ID al Objeto
                        objCuentaContable.Codigo = nCuentaContable.generarCodigoContable(Formulario.ValidarNumeroEntero(cmbTipoCuenta.Text.Substring(0, 6))); //Define un código contable
                        if (nCuentaContable.insertar(objCuentaContable)) //Paso 3: Inserta el objeto
                        {
                            _idCuentaContable = objCuentaContable.Id; //Paso 4: Iguala la variable local con el ID asignado
                            mostrarDatos();
                        }
                    }
                }
            }
            else if (_idCuentaContable > 0 && Global.UsuarioActivo_Privilegios.Contains(48)) //Verifica que el usuario posea el privilegio requerido
            {
                //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                if ((objCuentaContable.Id > 58 && objCuentaContable.Id != 78) || ((objCuentaContable.Id <= 58 || objCuentaContable.Id == 78) && Global.UsuarioActivo_IdUsuario == 1))
                {
                    if (ValidarCampoVacio())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                        {
                            CuentaContable objPrecedenteCuentaContable = nCuentaContable.obtenerObjeto("ID", _idCuentaContable.ToString(), false);
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            if (cmbTipoCuenta.Text != objPrecedenteCuentaContable.TipoCuenta) objCuentaContable.Codigo = nCuentaContable.generarCodigoContable(Formulario.ValidarNumeroEntero(cmbTipoCuenta.Text.Substring(0, 6))); //Paso 2: Verifica la correspondencia del código contable con el tipo de cuenta contable
                            nCuentaContable.actualizar(objCuentaContable); //Paso 3: Actualiza el Objeto en la Base de Datos
                            mostrarDatos();
                        }
                    }
                }
                else Mensaje.Advertencia("Operación incorrecta.\nEsta cuenta contable No puede ser modificada.");
            }
            else Mensaje.Restriccion();
            bool ValidarCampoVacio() // Método que valida los campos requeridos
            {
                return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion, cmbTipoCuenta });
            }
            void mostrarDatos() //Método que muestra en la pantalla los cambios generados
            {
                filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
                lstCatalogo.SelectedValue = _idCuentaContable; //Posiona la selección de la fila en el registro guardado
                escribirArbol(); //Paso 1: Escribe el contenido del arbol
                escribirControles(nCuentaContable.obtenerObjeto("ID", _idCuentaContable.ToString(), true)); //Paso 2: Importante: Por ultimo re-Escribe todos los controles para mayor seguridad                      }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idCuentaContable > 0) escribirControles(nCuentaContable.obtenerObjeto("ID", _idCuentaContable.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
            else restaurarControles();
        }
        #endregion

        #region Métodos
        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirArbol()
        {
            treePlanCuenta.Nodes.Clear(); //Borra todos los nodos del arbol
            #region Arbol - Estructura Básica
            treePlanCuenta.Nodes.Add("Nodo_100000", "1. ACTIVO");
                treePlanCuenta.Nodes[0].Nodes.Add("Nodo_110000", "1.1 ACTIVO CORRIENTE");
                    treePlanCuenta.Nodes[0].Nodes[0].Nodes.Add("Nodo_111000", "1.1.1 DISPONIBILIDADES");
                        treePlanCuenta.Nodes[0].Nodes[0].Nodes[0].Nodes.Add("Nodo_111100", "1.1.1.1 CAJAS");
                        treePlanCuenta.Nodes[0].Nodes[0].Nodes[0].Nodes.Add("Nodo_111200", "1.1.1.2 BANCOS");
                        treePlanCuenta.Nodes[0].Nodes[0].Nodes[0].Nodes.Add("Nodo_111300", "1.1.1.3 TARJETAS");
                        treePlanCuenta.Nodes[0].Nodes[0].Nodes[0].Nodes.Add("Nodo_111400", "1.1.1.4 VALORES A DEPOSITAR");
                    treePlanCuenta.Nodes[0].Nodes[0].Nodes.Add("Nodo_112000", "1.1.2 INVERSIONES");
                    treePlanCuenta.Nodes[0].Nodes[0].Nodes.Add("Nodo_113000", "1.1.3 CREDITOS POR VENTAS");
                    treePlanCuenta.Nodes[0].Nodes[0].Nodes.Add("Nodo_114000", "1.1.4 OTROS CREDITOS");
                    treePlanCuenta.Nodes[0].Nodes[0].Nodes.Add("Nodo_115000", "1.1.5 BIENES DE CAMBIO");
                    treePlanCuenta.Nodes[0].Nodes[0].Nodes.Add("Nodo_116000", "1.1.6 BIENES DE USO");
                    treePlanCuenta.Nodes[0].Nodes[0].Nodes.Add("Nodo_117000", "1.1.7 OTROS ACTIVOS");
                treePlanCuenta.Nodes[0].Nodes.Add("Nodo_120000", "1.2 ACTIVO NO CORRIENTE");
                    treePlanCuenta.Nodes[0].Nodes[1].Nodes.Add("Nodo_121000", "1.2.1 INVERSIONES");
                    treePlanCuenta.Nodes[0].Nodes[1].Nodes.Add("Nodo_122000", "1.2.2 CREDITOS POR VENTAS");
                    treePlanCuenta.Nodes[0].Nodes[1].Nodes.Add("Nodo_123000", "1.2.3 OTROS CREDITOS");
                    treePlanCuenta.Nodes[0].Nodes[1].Nodes.Add("Nodo_124000", "1.2.4 BIENES DE CAMBIO");
                    treePlanCuenta.Nodes[0].Nodes[1].Nodes.Add("Nodo_125000", "1.2.5 BIENES DE USO");
                    treePlanCuenta.Nodes[0].Nodes[1].Nodes.Add("Nodo_126000", "1.2.6 OTROS ACTIVOS");
            treePlanCuenta.Nodes.Add("Nodo_200000", "2. PASIVO");
                treePlanCuenta.Nodes[1].Nodes.Add("Nodo_210000", "2.1 PASIVO CORRIENTE");
                    treePlanCuenta.Nodes[1].Nodes[0].Nodes.Add("Nodo_211000", "2.1.1 DEUDAS COMERCIALES");
                    treePlanCuenta.Nodes[1].Nodes[0].Nodes.Add("Nodo_212000", "2.1.2 DEUDAS FINANCIERAS");
                    treePlanCuenta.Nodes[1].Nodes[0].Nodes.Add("Nodo_213000", "2.1.3 DEUDAS FISCALES");
                    treePlanCuenta.Nodes[1].Nodes[0].Nodes.Add("Nodo_214000", "2.1.4 DEUDAS SOCIALES");
                    treePlanCuenta.Nodes[1].Nodes[0].Nodes.Add("Nodo_215000", "2.1.5 OTRAS DEUDAS");
                treePlanCuenta.Nodes[1].Nodes.Add("Nodo_220000", "2.2 PASIVO NO CORRIENTE");
                    treePlanCuenta.Nodes[1].Nodes[1].Nodes.Add("Nodo_221000", "2.2.1 DEUDAS COMERCIALES");
                    treePlanCuenta.Nodes[1].Nodes[1].Nodes.Add("Nodo_222000", "2.2.2 DEUDAS FINANCIERAS");
                    treePlanCuenta.Nodes[1].Nodes[1].Nodes.Add("Nodo_223000", "2.2.3 DEUDAS FISCALES");
                    treePlanCuenta.Nodes[1].Nodes[1].Nodes.Add("Nodo_224000", "2.2.4 DEUDAS SOCIALES");
                    treePlanCuenta.Nodes[1].Nodes[1].Nodes.Add("Nodo_225000", "2.2.5 OTRAS DEUDAS");
            treePlanCuenta.Nodes.Add("Nodo_300000", "3. PATRIMONIO NETO");
                treePlanCuenta.Nodes[2].Nodes.Add("Nodo_310000", "3.1 CAPITAL");
                treePlanCuenta.Nodes[2].Nodes.Add("Nodo_320000", "3.2 RESERVAS");
                treePlanCuenta.Nodes[2].Nodes.Add("Nodo_330000", "3.3 RESULTADOS NO ASIGNADOS");
            treePlanCuenta.Nodes.Add("Nodo_400000", "4. INGRESOS");
                treePlanCuenta.Nodes[3].Nodes.Add("Nodo_410000", "4.1 INGRESO POR VENTAS");
                treePlanCuenta.Nodes[3].Nodes.Add("Nodo_420000", "4.2 OTROS INGRESOS");
            treePlanCuenta.Nodes.Add("Nodo_500000", "5. EGRESOS");
                treePlanCuenta.Nodes[4].Nodes.Add("Nodo_510000", "5.1 COSTO DE VENTAS");
            treePlanCuenta.Nodes[4].Nodes.Add("Nodo_520000", "5.2 COSTO DE NOMINA");
            treePlanCuenta.Nodes[4].Nodes.Add("Nodo_530000", "5.3 OTROS EGRESOS");
            #endregion
            List<CuentaContable> lista = nCuentaContable.obtenerObjetos("TODOS", "DENOMINACION", "");
            foreach (CuentaContable item in lista)
            {
                TreeNode[] nodoBuscado = treePlanCuenta.Nodes.Find("Nodo_" + item.TipoCuenta.Substring(0, 6), true); //Busca el nodo dentro del arbol
                if (nodoBuscado != null && nodoBuscado.Length > 0) nodoBuscado[0].Nodes.Add("Hoja_" + item.Codigo, item.Denominacion);
            }
        }

        private void escribirControles(CuentaContable objCuentaContable)
        {
            this.objCuentaContable = objCuentaContable; //Obtiene los datos del objeto recibido
            if (objCuentaContable != null)
            {
                _controladorDeNuevoRegistro = false;
                _idCuentaContable = (objCuentaContable != null) ? objCuentaContable.Id : 0;
                txtCodigo.Text = objCuentaContable.Codigo;
                txtDenominacion.Text = objCuentaContable.Denominacion;
                cmbTipoCuenta.Text = objCuentaContable.TipoCuenta;
                txtSaldo.Text = Formulario.ValidarCampoMoneda(objCuentaContable.Saldo);
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objCuentaContable.EdicionFecha) + " por " + objCuentaContable.EdicionUsuarioDenominacion;
                #region Expansión del Arbol
                TreeNode[] nodoBuscado = treePlanCuenta.Nodes.Find("Hoja_" + objCuentaContable.Codigo, true); //Busca el nodo dentro del arbol
                if (nodoBuscado != null && nodoBuscado.Length > 0)
                {
                    treePlanCuenta.SelectedNode = nodoBuscado[0]; //Selecciona el nodo indicado
                    treePlanCuenta.Select(); //Re-Salta el nodo seleccionado
                }
                #endregion
            }
            else restaurarControles();
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objCuentaContable = new CuentaContable(
                (_idCuentaContable <= 0) ? 0 : _idCuentaContable,
                txtCodigo.Text,
                txtDenominacion.Text.Trim(),
                cmbTipoCuenta.Text,
                Formulario.ValidarNumeroEntero(txtSaldo.Text),
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            _idCuentaContable = 0; //Libera el Id del Objeto seleccionado
            txtCodigo.Text = "";
            txtDenominacion.Text = "";
            txtSaldo.Text = "0,00";
            labelPublicacion.Text = "";
            //Restauración de campos invalidados
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, cmbTipoCuenta });
            treePlanCuenta.CollapseAll(); //Contrae todas las ramas expandidas
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR CODIGO")
            {
                cmbFiltroLista1.Enabled = true;
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
            {
                cmbFiltroLista1.Enabled = true;
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR ID")
            {
                cmbFiltroLista1.Enabled = false;
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
            }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroRamaPrincipal = "TODOS";
            if (cmbFiltroLista1.Text == "FILTRAR POR RAMA: ACTIVOS") filtroRamaPrincipal = "ACTIVO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR RAMA: EGRESOS") filtroRamaPrincipal = "EGRESOS";
            else if (cmbFiltroLista1.Text == "FILTRAR POR RAMA: INGRESOS") filtroRamaPrincipal = "INGRESOS";
            else if (cmbFiltroLista1.Text == "FILTRAR POR RAMA: PASIVOS") filtroRamaPrincipal = "PASIVO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR RAMA: PATRIMONIOS") filtroRamaPrincipal = "PATRIMONIO";
            if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la descripcion
            {
                consultaCuentaContable = new string[] { filtroRamaPrincipal, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCuentaContable.obtenerCatalago(filtroRamaPrincipal, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR CODIGO") //Verifica que el tipo de filtro es por concidencia letra en la descripcion
            {
                consultaCuentaContable = new string[] { filtroRamaPrincipal, "CODIGO", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCuentaContable.obtenerCatalago(filtroRamaPrincipal, "CODIGO", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de ID
            {
                consultaCuentaContable = new string[] { filtroRamaPrincipal, "ID", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCuentaContable.obtenerCatalago(filtroRamaPrincipal, "ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            escribirControles(nCuentaContable.obtenerObjeto("ID", idElemento.ToString(), true)); //Escribe los datos del registro seleccionado
        }

        protected override void reportarRegistro(string programa)
        {
            if (_idCuentaContable > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "ID: ",
                    "Código: ",
                    "Denominación: ",
                    "Tipo de cuenta: ",
                    "Saldo a la fecha (" + Fecha.SistemaFechaHora() + "): " };
                string[] datoDB = {
                    Convert.ToString(objCuentaContable.Id).PadLeft(8, '0'),
                    objCuentaContable.Codigo.PadLeft(6, '0'),
                    objCuentaContable.Denominacion,
                    objCuentaContable.TipoCuenta,
                    "$" + Formulario.ValidarCampoMoneda(objCuentaContable.Saldo) };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Cuenta Contable", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Cuenta Contable", subTitulo, datoDB);
                Cursor.Current = Cursors.Default;
            }
            else Mensaje.Advertencia("Operación incorrecta.\nSeleccione un registro en la pantalla e intente nuevamente.");
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                lista = nCuentaContable.obtenerCatalago(consultaCuentaContable[0], consultaCuentaContable[1], consultaCuentaContable[2], "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Código",
                    "Denominación",
                    "Tipo de cuenta",
                    "Saldo $"};
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //ID
                    campo[1].Trim(), //Código
                    campo[2].Trim(), //Denominación
                    campo[3].Trim(), //Tipo de Cuenta
                    "$"+campo[4].Trim() //Saldo Inicial
                };
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Cuentas Contables", subTitulos, new int[] { 10, 10, 30, 69, 10 }, _listaDelReporte, new List<int> { }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Cuenta Contables", subTitulos, new float[] { 9, 9, 25, 59, 9 }, _listaDelReporte); //Ancho: 111
            }
        }
        #endregion
    }
}
