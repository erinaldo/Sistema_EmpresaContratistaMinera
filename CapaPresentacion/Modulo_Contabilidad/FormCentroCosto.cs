using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormCentroCosto : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private long _idCentroCosto = 0;
        string[] consultaCentroCosto;
        private CentroCosto objCentroCosto;
        private N_CentroCosto nCentroCosto = new N_CentroCosto();
        #endregion

        public FormCentroCosto()
        {
            InitializeComponent();
        }

        #region Eventos: Formulario
        private void FormCentroCosto_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "TODOS LOS CENTROS DE COSTO" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR DENOMINACION", "FILTRAR POR ID" }, 0); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(39)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idCentroCosto <= 0 && Global.UsuarioActivo_Privilegios.Contains(39)) //Verifica que el usuario posea el privilegio requerido
            {
                //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        objCentroCosto.Id = nCentroCosto.generarNumeroID(); //Paso 2: Asigna un numero de ID al Objeto
                        if (nCentroCosto.insertar(objCentroCosto)) //Paso 3: Inserta el objeto
                        {
                            _idCentroCosto = objCentroCosto.Id; //Paso 4: Iguala la variable local con el ID asignado
                            mostrarDatos();
                        }
                    }
                }
            }
            else if (_idCentroCosto > 0 && Global.UsuarioActivo_Privilegios.Contains(40)) //Verifica que el usuario posea el privilegio requerido
            {
                //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                if (ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                    {
                        CentroCosto objPrecedenteCentroCosto = nCentroCosto.obtenerObjeto("ID", _idCentroCosto.ToString(), false);
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        nCentroCosto.actualizar(objCentroCosto); //Paso 2: Actualiza el Objeto en la Base de Datos
                        mostrarDatos();
                    }
                }
            }
            else Mensaje.Restriccion();
            bool ValidarCampoVacio() // Método que valida los campos requeridos
            {
                return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion, cmbDeposito });
            }
            void mostrarDatos() //Método que muestra en la pantalla los cambios generados
            {
                filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
                lstCatalogo.SelectedValue = _idCentroCosto; //Posiona la selección de la fila en el registro guardado
                escribirControles(nCentroCosto.obtenerObjeto("ID", _idCentroCosto.ToString(), true)); //Importante: Por ultimo re-Escribe todos los controles para mayor seguridad                      }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idCentroCosto > 0) escribirControles(nCentroCosto.obtenerObjeto("ID", _idCentroCosto.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
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

        private void escribirControles(CentroCosto objCentroCosto)
        {
            this.objCentroCosto = objCentroCosto; //Obtiene los datos del objeto recibido
            if (objCentroCosto != null)
            {
                _controladorDeNuevoRegistro = false;
                _idCentroCosto = (objCentroCosto != null) ? objCentroCosto.Id : 0;
                txtDenominacion.Text = objCentroCosto.Denominacion;
                cmbDeposito.Text = objCentroCosto.Deposito;
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objCentroCosto.EdicionFecha) + " por " + objCentroCosto.EdicionUsuarioDenominacion;
            }
            else restaurarControles();
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objCentroCosto = new CentroCosto(
                (_idCentroCosto <= 0) ? 0 : _idCentroCosto,
                txtDenominacion.Text.Trim(),
                cmbDeposito.Text,
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            _idCentroCosto = 0; //Libera el Id del Objeto seleccionado
            txtDenominacion.Text = "";
            labelPublicacion.Text = "";
            //Restauración de campos invalidados
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, cmbDeposito });
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION") { }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR ID") { }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la descripcion
            {
                consultaCentroCosto = new string[] { "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCentroCosto.obtenerCatalago("DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de ID
            {
                consultaCentroCosto = new string[] { "ID", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nCentroCosto.obtenerCatalago("ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            escribirControles(nCentroCosto.obtenerObjeto("ID", idElemento.ToString(), true)); //Escribe los datos del registro seleccionado
        }

        protected override void reportarRegistro(string programa)
        {
            if (_idCentroCosto > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "ID: ",
                    "Denominación: ",
                    "Depósito: " };
                string[] datoDB = {
                    Convert.ToString(objCentroCosto.Id).PadLeft(8, '0'),
                    objCentroCosto.Denominacion,
                    objCentroCosto.Deposito };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Centro de Costo", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Centro de Costo", subTitulo, datoDB);
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
                lista = nCentroCosto.obtenerCatalago(consultaCentroCosto[0], consultaCentroCosto[1], "CATALOGO1");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Denominación",
                    "Depósito"};
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //ID
                    campo[1].Trim(), //Denominación
                    campo[2].Trim() //Depósito
                };
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Centros de Costo", subTitulos, new int[] { 10, 107, 12 }, _listaDelReporte, new List<int> { }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Centros de Costo", subTitulos, new float[] { 9, 92, 10 }, _listaDelReporte); //Ancho: 111
            }
        }
        #endregion
    }
}
