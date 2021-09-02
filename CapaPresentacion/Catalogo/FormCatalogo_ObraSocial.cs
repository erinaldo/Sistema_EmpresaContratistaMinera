using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Biblioteca.Formularios;
using Biblioteca.Ayudantes;
using CapaNegocio.Catalogo;
using Entidades.Catalogo;

namespace CapaPresentacion.Catalogo
{
    public partial class FormCatalogo_ObraSocial : Biblioteca.Formularios.FormBaseCatalogo_EditableC3
    {
        #region Atributos
        private long _idObraSocial = 0;
        private ObraSocial objObraSocial = new ObraSocial();
        private N_ObraSocial nObraSocial = new N_ObraSocial();
        private FormBase _formularioDeOrigen;
        #endregion

        public FormCatalogo_ObraSocial(FormBase formularioDeOrigen)
        {
            _formularioDeOrigen = formularioDeOrigen;
            InitializeComponent();
        }

        #region Eventos
        private void FormCatalogo_ObraSocial_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR CODIGO",
                "FILTRAR POR DENOMINACION" }, 0); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(11)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                txtElementoCodigo.Focus();
            }
            else Mensaje.Restriccion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idObraSocial > 0)
            {
                escribirControles(nObraSocial.obtenerObjeto("ID", _idObraSocial.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
            }
            else
            {
                restaurarControles();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idObraSocial <= 0 && Global.UsuarioActivo_Privilegios.Contains(11)) //Verifica que el usuario posea el privilegio requerido
            {
                //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                if (ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo elemento?") == DialogResult.Yes)
                    {
                        instanciarObraSocial();
                        objObraSocial.Id = nObraSocial.generarNumeroID(); //Asigna un numero de ID al Objeto
                        nObraSocial.insertar(objObraSocial, true);
                        _idObraSocial = objObraSocial.Id; //Muestra el ID asignado
                        mostrarDatos();
                    }
                }
            }
            else if (_idObraSocial > 0 && Global.UsuarioActivo_Privilegios.Contains(13)) //Verifica que el usuario posea el privilegio requerido
            {
                //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                if (ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del elemento ID: " + _idObraSocial.ToString() + "?") == DialogResult.Yes)
                    {
                        instanciarObraSocial();
                        nObraSocial.actualizar(objObraSocial, true);
                        mostrarDatos();
                    }
                }
            }
            else Mensaje.Restriccion();
            bool ValidarCampoVacio() // Método que valida los campos requeridos
            {
                return Formulario.ValidarCampoVacio(false, new Control[] { txtElementoCodigo, txtElementoDenominacion });
            }
            void mostrarDatos() //Método que muestra en la pantalla los cambios generados
            {
                filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
                lstCatalogo.SelectedValue = _idObraSocial; //Posiona la selección de la fila en el registro guardado
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(12)) //Verifica que el usuario posea el privilegio requerido
            {
                if (Mensaje.ConfirmacionBoton1("¿Desea eliminar el elemento ID: " + _idObraSocial.ToString() + "?") == DialogResult.Yes)
                {
                    nObraSocial.eliminar(_idObraSocial, true); //Elimina los datos del registro seleccionado
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

        private void escribirControles(ObraSocial objObraSocial)
        {
            this.objObraSocial = objObraSocial; //Obtiene los datos del objeto recibido
            if (objObraSocial != null)
            {
                _idObraSocial = (objObraSocial != null) ? objObraSocial.Id : 0;
                txtElementoCodigo.Text = objObraSocial.Codigo;
                txtElementoDenominacion.Text = objObraSocial.Denominacion;
            }
        }

        private void restaurarControles()
        {
            _idObraSocial = 0;
            txtElementoCodigo.Text = "";
            txtElementoDenominacion.Text = "";
        }

        private void instanciarObraSocial()
        {
            this.objObraSocial = new ObraSocial(
                (_idObraSocial <= 0) ? 0 : _idObraSocial,
                txtElementoCodigo.Text.Trim(),
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
            if (cmbFiltroLista1.Text == "FILTRAR POR CODIGO") //Verifica que el tipo de filtro es por concidencia letra en la descripcion
            {
                cargarCatalogo(nObraSocial.obtenerCatalago("CODIGO", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista1.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la descripcion
            {
                cargarCatalogo(nObraSocial.obtenerCatalago("DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            asignarPaginacion(indicePagina);
        }

        protected override void capturarElemento()
        {
            if (lstCatalogo.SelectedValue != null)
            {
                _formularioDeOrigen.asignarVariablesDeFormulario(new string[] { "Catalogo_ObraSocial",
                objObraSocial.Id.ToString(),
                objObraSocial.Codigo,
                objObraSocial.Denominacion });
            this.Close();
            }
        }

        protected override void mostrarElemento(long idElemento)
        {
            escribirControles(nObraSocial.obtenerObjeto("ID", idElemento.ToString(), true)); //Escribe los datos del registro seleccionado
        }
        #endregion
    }
}
