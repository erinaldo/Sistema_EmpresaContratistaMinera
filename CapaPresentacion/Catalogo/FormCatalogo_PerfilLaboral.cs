using System;
using System.Windows.Forms;
using Biblioteca.Formularios;
using Biblioteca.Ayudantes;
using CapaNegocio.Catalogo;
using Entidades;
using Entidades.Catalogo;
using CapaNegocio;

namespace CapaPresentacion.Catalogo
{
    public partial class FormCatalogo_PerfilLaboral : Biblioteca.Formularios.FormBaseModal
    {
        #region Atributos
        private long _idLegajo = 0;
        private long _idPerfilLaboral = 0;
        private long _idPerfilLaboralLegajo = 0;
        private PerfilLaboral objPerfilLaboral = new PerfilLaboral();
        private Relacion_LegajoCurriculumVitae_PerfilLaboral objRelacion_LegajoCurriculumVitae_PerfilLaboral = new Relacion_LegajoCurriculumVitae_PerfilLaboral();
        private N_PerfilLaboral nPerfilLaboral = new N_PerfilLaboral();
        private N_Relacion_LegajoCurriculumVitae_PerfilLaboral nRelacion_LegajoCurriculumVitae_PerfilLaboral = new N_Relacion_LegajoCurriculumVitae_PerfilLaboral();
        private FormBase _formularioDeOrigen;
        #endregion

        public FormCatalogo_PerfilLaboral(FormBase formularioDeOrigen, long idLegajo)
        {
            _idLegajo = idLegajo;
            _formularioDeOrigen = formularioDeOrigen;
            InitializeComponent();
        }

        #region Eventos
        private void FormCatalogo_PerfilLaboral_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnNuevo, "Crea un nuevo elemento");
            toolTip.SetToolTip(btnGuardar, "Guarda los cambios realizados");
            toolTip.SetToolTip(btnCancelar, "Deshace los cambios realizados");
            toolTip.SetToolTip(btnEliminar, "Elimina un elemento");
            toolTip.SetToolTip(btnAgregar, "Agrega un elemento en la lista de perfiles del legajo");
            toolTip.SetToolTip(btnQuitar, "Elimina un elemento en la lista de perfiles del legajo");
            #endregion
            cargarListaA(); //Carga el griListaA
            cargarListaB(); //Carga el griListaB
        }

        private void FormCatalogo_PerfilLaboral_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formularioDeOrigen.asignarVariablesDeFormulario(new string[] { "Catalogo_PerfilLaboral", _idLegajo.ToString()});
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(14)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                txtElementoDenominacion.Focus();
            }
            else Mensaje.Restriccion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idPerfilLaboral > 0)
            {
                escribirControles(nPerfilLaboral.obtenerObjeto(_idPerfilLaboral, true)); //Re-Escribe los datos originales en base al registro seleccionado
            }
            else
            {
                restaurarControles();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idPerfilLaboral <= 0 && Global.UsuarioActivo_Privilegios.Contains(14)) //Verifica que el usuario posea el privilegio requerido
            {
                //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                if (ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo elemento?") == DialogResult.Yes)
                    {
                        instanciarPerfilLaboral();
                        objPerfilLaboral.Id = nPerfilLaboral.generarNumeroID(); //Asigna un numero de ID al Objeto
                        nPerfilLaboral.insertar(objPerfilLaboral, true);
                        _idPerfilLaboral = objPerfilLaboral.Id; //Muestra el ID asignado
                        mostrarDatos(objPerfilLaboral.Id);
                    }
                }
            }
            else if (_idPerfilLaboral > 0 && Global.UsuarioActivo_Privilegios.Contains(16)) //Verifica que el usuario posea el privilegio requerido
            {
                //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                if (ValidarCampoVacio())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del elemento ID: " + _idPerfilLaboral.ToString() + "?") == DialogResult.Yes)
                    {
                        instanciarPerfilLaboral();
                        nPerfilLaboral.actualizar(objPerfilLaboral, true);
                        mostrarDatos(objPerfilLaboral.Id);
                    }
                }
            }
            else Mensaje.Restriccion();
            bool ValidarCampoVacio() // Método que valida los campos requeridos
            {
                return Formulario.ValidarCampoVacio(false, new Control[] { txtElementoDenominacion });
            }
            void mostrarDatos(long id) //Método que muestra en la pantalla los cambios generados
            {
                cargarListaA(); //Recarga los registros en la lista
                Formulario.Grid_SeleccionarFila(gridListaA, "columnaIdA", id.ToString()); //Posionar la seleccion de la fila en el registro guardado
                escribirControles(nPerfilLaboral.obtenerObjeto(_idPerfilLaboral, true)); //Escribe los datos en base al registro guardado
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(15)) //Verifica que el usuario posea el privilegio requerido
            {
                if (Mensaje.ConfirmacionBoton1("¿Desea eliminar el elemento ID: " + _idPerfilLaboral.ToString() + "?") == DialogResult.Yes)
                {
                    nPerfilLaboral.eliminar(_idPerfilLaboral, true); //Elimina los datos del registro seleccionado
                    restaurarControles();
                    cargarListaA(); //Recarga los registros en la lista
                }
            }
            else Mensaje.Restriccion();
        }

        private void gridListaA_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridListaA.Focused)
            {
                DataGridViewRow rowA = gridListaA.Rows[e.RowIndex];
                _idPerfilLaboral = Convert.ToInt32(rowA.Cells["columnaIdA"].Value); //Almacena el ID del elemento
                txtElementoDenominacion.Text = rowA.Cells["columnaDenominacionA"].Value.ToString();
            }
        }

        private void gridListaB_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridListaB.Focused)
            {
                DataGridViewRow rowB = gridListaB.Rows[e.RowIndex];
                _idPerfilLaboralLegajo = Convert.ToInt32(rowB.Cells["columnaIdB"].Value); //Almacena el ID del elemento
            }
        }

        private void gridListaA_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridListaA.Focused)
            {
                instanciarPerfilLaboralLegajo();
                objRelacion_LegajoCurriculumVitae_PerfilLaboral.Id = nRelacion_LegajoCurriculumVitae_PerfilLaboral.generarNumeroID(); //Asigna un numero de ID al Objeto
                nRelacion_LegajoCurriculumVitae_PerfilLaboral.insertar(objRelacion_LegajoCurriculumVitae_PerfilLaboral, true); //Agrega un nuevo registro en la Base de Datos
                cargarListaB(); //Recarga la lista B
            }
        }

        private void gridListaB_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridListaB.Focused)
            {
                nRelacion_LegajoCurriculumVitae_PerfilLaboral.eliminar(_idPerfilLaboralLegajo, true); //Elimina los datos del registro seleccionado
                cargarListaB(); //Recarga la lista B
            }
        }

        private void btnEditarCatalogo_Click(object sender, EventArgs e)
        {
            Formulario.Visibilidad(new Control[] { btnEditarCatalogo, txtElementoDenominacion,
                btnNuevo, btnCancelar, btnGuardar, btnEliminar });
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (_idPerfilLaboral > 0) //Verifica que se ha seleccionado un elemento de la lista A
            {
                instanciarPerfilLaboralLegajo();
                objRelacion_LegajoCurriculumVitae_PerfilLaboral.Id = nRelacion_LegajoCurriculumVitae_PerfilLaboral.generarNumeroID(); //Asigna un numero de ID al Objeto
                nRelacion_LegajoCurriculumVitae_PerfilLaboral.insertar(objRelacion_LegajoCurriculumVitae_PerfilLaboral, true); //Inserta un nuevo registro en la Base de Datos
                _idPerfilLaboralLegajo = objRelacion_LegajoCurriculumVitae_PerfilLaboral.Id; //Muestra el ID asignado
                cargarListaB(); //Recarga la lista B
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (_idPerfilLaboralLegajo > 0) //Verifica que se ha seleccionado un elemento de la lista B
            {
                nRelacion_LegajoCurriculumVitae_PerfilLaboral.eliminar(_idPerfilLaboralLegajo, true); //Elimina los datos del registro seleccionado
                cargarListaB(); //Recarga los registros en la lista
            }
        }
        #endregion

        #region Métodos
        private void escribirControles(PerfilLaboral objPerfilLaboral)
        {
            this.objPerfilLaboral = objPerfilLaboral; //Obtiene los datos del objeto recibido
            if (objPerfilLaboral != null)
            {
                _idPerfilLaboral = (objPerfilLaboral != null) ? objPerfilLaboral.Id : 0;
                txtElementoDenominacion.Text = objPerfilLaboral.Denominacion;
            }
        }

        private void restaurarControles()
        {
            _idPerfilLaboral = 0;
            txtElementoDenominacion.Text = "";
        }

        private void instanciarPerfilLaboral()
        {
            this.objPerfilLaboral = new PerfilLaboral(
                (_idPerfilLaboral <= 0) ? 0 : _idPerfilLaboral,
                txtElementoDenominacion.Text.ToUpper()
            );
        }

        private void instanciarPerfilLaboralLegajo()
        {
            Legajo objLegajo = (_idLegajo > 0) ? new N_Legajo().obtenerObjeto("ID", _idLegajo.ToString()) : new Legajo();
            objLegajo.Id = _idLegajo;
            this.objRelacion_LegajoCurriculumVitae_PerfilLaboral = new Relacion_LegajoCurriculumVitae_PerfilLaboral(
                (_idPerfilLaboralLegajo <= 0) ? 0 : _idPerfilLaboralLegajo,
                objLegajo,
                new N_PerfilLaboral().obtenerObjeto(_idPerfilLaboral, false),
                "");
        }

        private void cargarListaA() //Método que carga la lista A
        {
            Formulario.Grid_CargarFilas(gridListaA, nPerfilLaboral.obtenerObjetos());
        }

        private void cargarListaB() //Método que carga la lista B
        {
            Formulario.Grid_CargarFilas(gridListaB, nRelacion_LegajoCurriculumVitae_PerfilLaboral.obtenerObjetos(_idLegajo));
        }
        #endregion
    }
}
