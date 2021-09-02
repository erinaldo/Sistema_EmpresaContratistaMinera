using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Biblioteca.Formularios;
using Biblioteca.Ayudantes;
using Entidades.Catalogo;
using CapaNegocio.Catalogo;

namespace CapaPresentacion.Catalogo
{
    public partial class FormCatalogo_ConceptoSueldo : Biblioteca.Formularios.FormBaseCatalogo_EditableC2
    {
        #region Atributos
        private long _idConceptoSueldo = 0;
        private ConceptoSueldo objConceptoSueldo = new ConceptoSueldo();
        private N_ConceptoSueldo nConceptoSueldo = new N_ConceptoSueldo();
        private FormBase _formularioDeOrigen;
        #endregion

        public FormCatalogo_ConceptoSueldo(FormBase formularioDeOrigen)
        {
            _formularioDeOrigen = formularioDeOrigen;
            InitializeComponent();
        }

        #region Eventos
        private void FormCatalogo_ConceptoSueldo_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR DENOMINACION", "FILTRAR POR ID" }, 0); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(5)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                txtElementoDenominacion.Focus();
            }
            else Mensaje.Restriccion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idConceptoSueldo > 0)
            {
                escribirControles(nConceptoSueldo.obtenerObjeto("ID", _idConceptoSueldo.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
            }
            else
            {
                restaurarControles();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idConceptoSueldo <= 0 && Global.UsuarioActivo_Privilegios.Contains(5)) //Verifica que el usuario posea el privilegio requerido
            {
                //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                if (ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo elemento?") == DialogResult.Yes)
                    {
                        instanciarConceptoSueldo();
                        objConceptoSueldo.Id = nConceptoSueldo.generarNumeroID(); //Asigna un numero de ID al Objeto
                        nConceptoSueldo.insertar(objConceptoSueldo, true);
                        _idConceptoSueldo = objConceptoSueldo.Id; //Muestra el ID asignado
                        mostrarDatos();
                    }
                }
            }
            else if (_idConceptoSueldo > 0 && Global.UsuarioActivo_Privilegios.Contains(7)) //Verifica que el usuario posea el privilegio requerido
            {
                //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                if (ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del elemento ID: " + _idConceptoSueldo.ToString() + "?") == DialogResult.Yes)
                    {
                        instanciarConceptoSueldo();
                        nConceptoSueldo.actualizar(objConceptoSueldo, true);
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
                lstCatalogo.SelectedValue = _idConceptoSueldo; //Posiona la selección de la fila en el registro guardado
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(6)) //Verifica que el usuario posea el privilegio requerido
            {
                if (Mensaje.ConfirmacionBoton1("¿Desea eliminar el elemento ID: " + _idConceptoSueldo.ToString() + "?") == DialogResult.Yes)
                {
                    nConceptoSueldo.eliminar(_idConceptoSueldo, true); //Elimina los datos del registro seleccionado
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

        private void escribirControles(ConceptoSueldo objConceptoSueldo)
        {
            this.objConceptoSueldo = objConceptoSueldo; //Obtiene los datos del objeto recibido
            if (objConceptoSueldo != null)
            {
                _idConceptoSueldo = (objConceptoSueldo != null) ? objConceptoSueldo.Id : 0;
                txtElementoDenominacion.Text = objConceptoSueldo.Denominacion;
            }
        }

        private void restaurarControles()
        {
            _idConceptoSueldo = 0;
            txtElementoDenominacion.Text = "";
        }

        private void instanciarConceptoSueldo()
        {
            this.objConceptoSueldo = new ConceptoSueldo(
                (_idConceptoSueldo <= 0) ? 0 : _idConceptoSueldo,
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
                cargarCatalogo(nConceptoSueldo.obtenerCatalago("DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista1.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de documento
            {
                cargarCatalogo(nConceptoSueldo.obtenerCatalago("ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            asignarPaginacion(indicePagina);
        }

        protected override void capturarElemento()
        {
            if (lstCatalogo.SelectedValue != null)
            {
                _formularioDeOrigen.asignarVariablesDeFormulario(new string[] { "Catalogo_ConceptoSueldo",
                objConceptoSueldo.Id.ToString(),
                objConceptoSueldo.Denominacion });
                this.Close();
            }
        }

        protected override void mostrarElemento(long idElemento)
        {
            escribirControles(nConceptoSueldo.obtenerObjeto("ID", idElemento.ToString(), true)); //Escribe los datos del registro seleccionado
        }
        #endregion
    }
}
