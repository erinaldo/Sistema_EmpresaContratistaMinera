using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Biblioteca.Formularios;
using Biblioteca.Ayudantes;
using Entidades.Catalogo;
using CapaNegocio.Catalogo;

namespace CapaPresentacion.Catalogo
{
    public partial class FormCatalogo_Banco : Biblioteca.Formularios.FormBaseCatalogo_EditableC2
    {
        #region Atributos
        private long _idBanco = 0;
        private Banco objBanco = new Banco();
        private N_Banco nBanco = new N_Banco();
        private FormBase _formularioDeOrigen;
        #endregion

        public FormCatalogo_Banco(FormBase formularioDeOrigen)
        {
            _formularioDeOrigen = formularioDeOrigen;
            InitializeComponent();
        }

        #region Eventos
        private void FormCatalogo_Banco_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR DENOMINACION", "FILTRAR POR ID" }, 0); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(8)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                txtElementoDenominacion.Focus();
            }
            else Mensaje.Restriccion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idBanco > 0)
            {
                escribirControles(nBanco.obtenerObjeto("ID", _idBanco.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
            }
            else
            {
                restaurarControles();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idBanco <= 0 && Global.UsuarioActivo_Privilegios.Contains(8)) //Verifica que el usuario posea el privilegio requerido
            {
                //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                if (ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo elemento?") == DialogResult.Yes)
                    {
                        instanciarBanco();
                        objBanco.Id = nBanco.generarNumeroID(); //Asigna un numero de ID al Objeto
                        nBanco.insertar(objBanco, true);
                        _idBanco = objBanco.Id; //Muestra el ID asignado
                        mostrarDatos(objBanco.Id);
                    }
                }
            }
            else if (_idBanco > 0 && Global.UsuarioActivo_Privilegios.Contains(10)) //Verifica que el usuario posea el privilegio requerido
            {
                //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                if (ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del elemento ID: " + _idBanco.ToString() + "?") == DialogResult.Yes)
                    {
                        instanciarBanco();
                        nBanco.actualizar(objBanco, true);
                        mostrarDatos(objBanco.Id);
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
                lstCatalogo.SelectedValue = _idBanco; //Posiona la selección de la fila en el registro guardado
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(9)) //Verifica que el usuario posea el privilegio requerido
            {
                if (Mensaje.ConfirmacionBoton1("¿Desea eliminar el elemento ID: " + _idBanco.ToString() + "?") == DialogResult.Yes)
                {
                    nBanco.eliminar(_idBanco, true); //Elimina los datos del registro seleccionado
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

        private void escribirControles(Banco objBanco)
        {
            this.objBanco = objBanco; //Obtiene los datos del objeto recibido
            if (objBanco != null)
            {
                _idBanco = (objBanco != null) ? objBanco.Id : 0;
                txtElementoDenominacion.Text = objBanco.Denominacion;
            }
        }

        private void restaurarControles()
        {
            _idBanco = 0;
            txtElementoDenominacion.Text = "";
        }

        private void instanciarBanco()
        {
            this.objBanco = new Banco(
                (_idBanco <= 0) ? 0 : _idBanco,
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
                cargarCatalogo(nBanco.obtenerCatalago("DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista1.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de documento
            {
                cargarCatalogo(nBanco.obtenerCatalago("ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            asignarPaginacion(indicePagina);
        }

        protected override void capturarElemento()
        {
            if (lstCatalogo.SelectedValue != null)
            {
                _formularioDeOrigen.asignarVariablesDeFormulario(new string[] { "Catalogo_Banco",
                objBanco.Id.ToString(),
                objBanco.Denominacion });
                this.Close();
            }
        }

        protected override void mostrarElemento(long idElemento)
        {
            escribirControles(nBanco.obtenerObjeto("ID", idElemento.ToString(), true)); //Escribe los datos del registro seleccionado
        }
        #endregion
    }
}
