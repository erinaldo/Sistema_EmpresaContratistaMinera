using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Biblioteca.Formularios;
using Biblioteca.Ayudantes;
using Entidades.Catalogo;
using CapaNegocio.Catalogo;

namespace CapaPresentacion.Catalogo
{
    public partial class FormCatalogo_CategoriaTrabajo : Biblioteca.Formularios.FormBaseCatalogo_EditableC2
    {
        #region Atributos
        private long _idCategoriaTrabajo = 0;
        private CategoriaTrabajo objCategoriaTrabajo = new CategoriaTrabajo();
        private N_CategoriaTrabajo nCategoriaTrabajo = new N_CategoriaTrabajo();
        private FormBase _formularioDeOrigen;
        #endregion

        public FormCatalogo_CategoriaTrabajo(FormBase formularioDeOrigen)
        {
            _formularioDeOrigen = formularioDeOrigen;
            InitializeComponent();
        }

        #region Eventos
        private void FormCatalogo_CategoriaTrabajo_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR DENOMINACION", "FILTRAR POR ID" }, 0); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(2)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                txtElementoDenominacion.Focus();
            }
            else Mensaje.Restriccion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idCategoriaTrabajo > 0)
            {
                escribirControles(nCategoriaTrabajo.obtenerObjeto("ID", _idCategoriaTrabajo.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
            }
            else
            {
                restaurarControles();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idCategoriaTrabajo <= 0 && Global.UsuarioActivo_Privilegios.Contains(2)) //Verifica que el usuario posea el privilegio requerido
            {
                //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                if (ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo elemento?") == DialogResult.Yes)
                    {
                        instanciarCategoriaTrabajo();
                        objCategoriaTrabajo.Id = nCategoriaTrabajo.generarNumeroID(); //Asigna un numero de ID al Objeto
                        nCategoriaTrabajo.insertar(objCategoriaTrabajo, true);
                        _idCategoriaTrabajo = objCategoriaTrabajo.Id; //Muestra el ID asignado
                        mostrarDatos(objCategoriaTrabajo.Id);
                    }
                }
            }
            else if (_idCategoriaTrabajo > 0 && Global.UsuarioActivo_Privilegios.Contains(4)) //Verifica que el usuario posea el privilegio requerido
            {
                //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                if (ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del elemento ID: " + _idCategoriaTrabajo.ToString() + "?") == DialogResult.Yes)
                    {
                        instanciarCategoriaTrabajo();
                        nCategoriaTrabajo.actualizar(objCategoriaTrabajo, true);
                        mostrarDatos(objCategoriaTrabajo.Id);
                    }
                }
            }
            else Mensaje.Restriccion();
            bool ValidarCampoVacio() // Método que valida los campos requeridos
            {
                return Formulario.ValidarCampoVacio(false, new Control[] { txtElementoDenominacion });
            }
            void mostrarDatos(long documento) //Método que muestra en la pantalla los cambios generados
            {
                filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
                lstCatalogo.SelectedValue = _idCategoriaTrabajo; //Posiona la selección de la fila en el registro guardado
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(3)) //Verifica que el usuario posea el privilegio requerido
            {
                if (_idCategoriaTrabajo > 30) //Verifica y controla que no se eliminen los registros básicos
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea eliminar el elemento ID: " + _idCategoriaTrabajo.ToString() + "?") == DialogResult.Yes)
                    {
                        nCategoriaTrabajo.eliminar(_idCategoriaTrabajo, true); //Elimina los datos del registro seleccionado
                        restaurarControles();
                        filtrarCatalogo(0); //Recarga los registros en la lista
                    }
                }
                else Mensaje.Advertencia("Operación incorrecta.\nNo se puede eliminar el elemento seleccionado porque es un registro básico del sistema.");
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

        private void escribirControles(CategoriaTrabajo objCategoriaTrabajo)
        {
            this.objCategoriaTrabajo = objCategoriaTrabajo; //Obtiene los datos del objeto recibido
            if (objCategoriaTrabajo != null)
            {
                _idCategoriaTrabajo = (objCategoriaTrabajo != null) ? objCategoriaTrabajo.Id : 0;
                txtElementoDenominacion.Text = objCategoriaTrabajo.Denominacion;
            }
        }

        private void restaurarControles()
        {
            _idCategoriaTrabajo = 0;
            txtElementoDenominacion.Text = "";
        }

        private void instanciarCategoriaTrabajo()
        {
            this.objCategoriaTrabajo = new CategoriaTrabajo(
                (_idCategoriaTrabajo <= 0) ? 0 : _idCategoriaTrabajo,
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
                cargarCatalogo(nCategoriaTrabajo.obtenerCatalago("DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista1.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de documento
            {
                cargarCatalogo(nCategoriaTrabajo.obtenerCatalago("ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            asignarPaginacion(indicePagina);
        }

        protected override void capturarElemento()
        {
            if (lstCatalogo.SelectedValue != null)
            {
                _formularioDeOrigen.asignarVariablesDeFormulario(new string[] { "Catalogo_CategoriaTrabajo",
                objCategoriaTrabajo.Id.ToString(),
                objCategoriaTrabajo.Denominacion });
                this.Close();
            }
        }

        protected override void mostrarElemento(long idElemento)
        {
            escribirControles(nCategoriaTrabajo.obtenerObjeto("ID", idElemento.ToString(), true)); //Escribe los datos del registro seleccionado
        }
        #endregion
    }
}
