using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Biblioteca.Formularios;
using Biblioteca.Ayudantes;
using Entidades.Catalogo;
using CapaNegocio.Catalogo;

namespace CapaPresentacion.Catalogo
{
    public partial class FormCatalogo_TipoNovedadNomina : Biblioteca.Formularios.FormBaseCatalogo_EditableC2
    {
        #region Atributos
        private long _idTipoNovedad = 0;
        private TipoNovedad objTipoNovedad = new TipoNovedad();
        private N_TipoNovedad nTipoNovedad = new N_TipoNovedad();
        private FormBase _formularioDeOrigen;
        #endregion

        public FormCatalogo_TipoNovedadNomina(FormBase formularioDeOrigen)
        {
            _formularioDeOrigen = formularioDeOrigen;
            InitializeComponent();
        }

        #region Eventos
        private void FormCatalogo_TipoNovedadNomina_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR DENOMINACION", "FILTRAR POR ID" }, 0); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(17)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                txtElementoDenominacion.Focus();
            }
            else Mensaje.Restriccion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idTipoNovedad > 0)
            {
                escribirControles(nTipoNovedad.obtenerObjeto("ID", _idTipoNovedad.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
            }
            else
            {
                restaurarControles();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idTipoNovedad <= 0 && Global.UsuarioActivo_Privilegios.Contains(17)) //Verifica que el usuario posea el privilegio requerido
            {
                //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                if (ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo elemento?") == DialogResult.Yes)
                    {
                        instanciarTipoNovedad();
                        objTipoNovedad.Id = nTipoNovedad.generarNumeroID(); //Asigna un numero de ID al Objeto
                        nTipoNovedad.insertar(objTipoNovedad, true);
                        _idTipoNovedad = objTipoNovedad.Id; //Muestra el ID asignado
                        mostrarDatos();
                    }
                }
            }
            else if (_idTipoNovedad > 0 && Global.UsuarioActivo_Privilegios.Contains(19)) //Verifica que el usuario posea el privilegio requerido
            {
                //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                if (ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del elemento ID: " + _idTipoNovedad.ToString() + "?") == DialogResult.Yes)
                    {
                        instanciarTipoNovedad();
                        nTipoNovedad.actualizar(objTipoNovedad, true);
                        mostrarDatos();
                    }
                }
            }
            else Mensaje.Restriccion();
            bool ValidarCampoVacio() // Método que valida los campos requeridos
            {
                return Formulario.ValidarCampoVacio(false, new Control[] { txtElementoDenominacion });
            }
            void mostrarDatos() //Método que muestra en la pantalla los cambios generados
            {
                filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
                lstCatalogo.SelectedValue = _idTipoNovedad; //Posiona la selección de la fila en el registro guardado
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(18)) //Verifica que el usuario posea el privilegio requerido
            {
                if (Mensaje.ConfirmacionBoton1("¿Desea eliminar el elemento ID: " + _idTipoNovedad.ToString() + "?") == DialogResult.Yes)
                {
                    nTipoNovedad.eliminar(_idTipoNovedad, true); //Elimina los datos del registro seleccionado
                    restaurarControles();
                    filtrarCatalogo(0); //Recarga los registros en la lista
                }
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
        }

        private void escribirControles(TipoNovedad objTipoNovedad)
        {
            this.objTipoNovedad = objTipoNovedad; //Obtiene los datos del objeto recibido
            if (objTipoNovedad != null)
            {
                _idTipoNovedad = (objTipoNovedad != null) ? objTipoNovedad.Id : 0;
                txtElementoDenominacion.Text = objTipoNovedad.Denominacion;
            }
        }

        private void restaurarControles()
        {
            _idTipoNovedad = 0;
            txtElementoDenominacion.Text = "";
        }

        private void instanciarTipoNovedad()
        {
            this.objTipoNovedad = new TipoNovedad(
                (_idTipoNovedad <= 0) ? 0 : _idTipoNovedad,
                txtElementoDenominacion.Text.ToUpper()
            );
        }

        protected override void comboFiltro1()
        {
            txtFiltroLista.Text = "";
            filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina)
        {
            if (cmbFiltroLista1.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la descripcion
            {
                cargarCatalogo(nTipoNovedad.obtenerCatalago("DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista1.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de documento
            {
                cargarCatalogo(nTipoNovedad.obtenerCatalago("ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            asignarPaginacion(indicePagina);
        }

        protected override void capturarElemento()
        {
            if (lstCatalogo.SelectedValue != null)
            {
                _formularioDeOrigen.asignarVariablesDeFormulario(new string[] { "Catalogo_TipoNovedad",
                objTipoNovedad.Id.ToString(),
                objTipoNovedad.Denominacion });
                this.Close();
            }
        }

        protected override void mostrarElemento(long idElemento)
        {
            escribirControles(nTipoNovedad.obtenerObjeto("ID", idElemento.ToString(), true)); //Escribe los datos del registro seleccionado
        }
        #endregion
    }
}
