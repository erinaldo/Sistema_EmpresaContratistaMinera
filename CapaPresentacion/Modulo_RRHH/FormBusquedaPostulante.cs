using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using CapaNegocio.Catalogo;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormBusquedaPostulante : Biblioteca.Formularios.FormBaseReporte
    {
        #region Atributos
        private BusquedaPostulante objBusquedaPostulante = new BusquedaPostulante();
        private N_BusquedaPostulante nBusquedaPostulante = new N_BusquedaPostulante();
        private List<CatalogoBase> _lista = new List<CatalogoBase>();
        #endregion

        public FormBusquedaPostulante()
        {
            InitializeComponent();
        }

        #region Eventos: Formulario
        private void FormBusquedaPostulante_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbPerfilLaboral, new N_PerfilLaboral().obtenerListaDeElementos(), 0);
            cmbDisponibilidad.Text = "TODOS";
            cmbCalificacion.Text = "TODOS";
            chkCurriculumVitaeVigente.Checked = true;
            cargarListaDePostulante();
        }

        private void cmbPerfilLaboral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPerfilLaboral.Focused) cargarListaDePostulante();
        }

        private void chkTrabajoEmpreminsa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrabajoEmpreminsa.Focused) cargarListaDePostulante();

        }

        private void cmbDisponibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDisponibilidad.Focused) cargarListaDePostulante();
        }

        private void cmbCalificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCalificacion.Focused) cargarListaDePostulante();
        }

        private void chkCertificadoAntecedentesVigente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCertificadoAntecedentesVigente.Focused) cargarListaDePostulante();
        }

        private void chkCurriculumVitaeVigente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCurriculumVitaeVigente.Focused) cargarListaDePostulante();
        }

        private void chkCursoInduccionVigenteAprobado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCursoInduccionVigenteAprobado.Focused) cargarListaDePostulante();
        }

        private void chkCursoIzajeVigente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCursoIzajeVigente.Focused) cargarListaDePostulante();
        }

        private void chkExamenMedicoVigenteApto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExamenMedicoVigenteApto.Focused) cargarListaDePostulante();
        }

        private void chkLicenciaConducirVigente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLicenciaConducirVigente.Focused) cargarListaDePostulante();
        }
        #endregion

        #region Métodos
        private void cargarListaDePostulante()
        {
            _lista = nBusquedaPostulante.obtenerCatalago(cmbPerfilLaboral.Text, chkTrabajoEmpreminsa.Checked, cmbDisponibilidad.Text, cmbCalificacion.Text, chkCurriculumVitaeVigente.Checked, chkCertificadoAntecedentesVigente.Checked, chkLicenciaConducirVigente.Checked, chkCursoInduccionVigenteAprobado.Checked, chkCursoIzajeVigente.Checked, chkExamenMedicoVigenteApto.Checked); //Carga los Registros
            lstCatalogo.DataSource = _lista;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
            lstCatalogo.ClearSelected();
        }

        private List<BusquedaPostulante> obtenerSeleccionDeElementos()
        {
            List<BusquedaPostulante> listaDelCatalogo = new List<BusquedaPostulante>();
            foreach (CatalogoBase item in lstCatalogo.SelectedItems)
            {
                BusquedaPostulante objBusquedaPostulante = nBusquedaPostulante.obtenerObjeto(Convert.ToInt64(item.Id), cmbPerfilLaboral.Text, chkTrabajoEmpreminsa.Checked, cmbDisponibilidad.Text, cmbCalificacion.Text, chkCurriculumVitaeVigente.Checked, chkCertificadoAntecedentesVigente.Checked, chkLicenciaConducirVigente.Checked, chkCursoInduccionVigenteAprobado.Checked, chkCursoIzajeVigente.Checked, chkExamenMedicoVigenteApto.Checked);
                listaDelCatalogo.Add(objBusquedaPostulante);
            }
            return listaDelCatalogo;
        }

        protected override void navegarAFormulario()
        {
            if (objBusquedaPostulante.Legajo != null)
            {
                if (Global.UsuarioActivo_Privilegios.Contains(123)) //Verifica que el usuario posea el privilegio requerido
                {
                    Legajo navLegajo = new N_Legajo().obtenerObjeto("ID", Convert.ToString(objBusquedaPostulante.Legajo.Id), false);
                    Formulario.AbrirFormularioHermano(this, new FormLegajo(navLegajo));
                }
                else Mensaje.Restriccion();
            }
        }

        protected override void mostrarElemento(long idElemento)
        {
            objBusquedaPostulante = nBusquedaPostulante.obtenerObjeto(idElemento, cmbPerfilLaboral.Text, chkTrabajoEmpreminsa.Checked, cmbDisponibilidad.Text, cmbCalificacion.Text, chkCurriculumVitaeVigente.Checked, chkCertificadoAntecedentesVigente.Checked, chkLicenciaConducirVigente.Checked, chkCursoInduccionVigenteAprobado.Checked, chkCursoIzajeVigente.Checked, chkExamenMedicoVigenteApto.Checked);
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                if (lstCatalogo.SelectedItems.Count > 0)
                {
                    foreach (BusquedaPostulante item in obtenerSeleccionDeElementos())
                    {
                        CatalogoBase objCatalogoBase = new CatalogoBase(
                            item.Legajo.Id,
                            (item.Legajo.Denominacion).PadRight(35, ' ') +
                                " | " + item.Legajo.Cuit.ToString("00-00000000/0") +
                                " | " + (item.Legajo.Celular1 + ((item.Legajo.Celular1.Length > 0 && item.Legajo.Celular2.Length > 0) ? ", " : "") + item.Legajo.Celular2 + (((item.Legajo.Celular2.Length > 0 || item.Legajo.Celular2.Length > 0) && item.Legajo.Celular3.Length > 0) ? ", " : "") + item.Legajo.Celular3).PadRight(43, ' ') +
                                " | " + ((Convert.ToBoolean(item.TrabajoEmpreminsa)) ? "SI" : "NO").PadRight(5, ' ') +
                                " | " + item.CurriculumVitaeDisponibilidad.PadRight(5, ' ') +
                                " | " + item.CurriculumVitaeCalificacion.PadRight(14, ' ') +
                                " | " + item.CurriculumVitaeEstado.PadRight(8, ' ') +
                                " | " + (((item.CertificadoAntecedenteVto != Fecha.ValidarFecha("01-01-1900")) ? Fecha.ConvertirFecha(item.CertificadoAntecedenteVto.AddMonths(Global.Vigencia_Antecedentes)) + " (" + item.CertificadoAntecedenteTipo + ")" : "")).PadRight(23, ' ') +
                                " | " + ((item.LicenciaConducirVto != Fecha.ValidarFecha("01-01-1900")) ? Fecha.ConvertirFecha(item.LicenciaConducirVto) : "").PadRight(10, ' ') +
                                " | " + (((item.CursoInduccionVto != Fecha.ValidarFecha("01-01-1900")) ? Fecha.ConvertirFecha(item.CursoInduccionVto.AddMonths(Global.Vigencia_CursoInduccion)) + " (" + item.CursoInduccionEvaluacion + ")" : "")).PadRight(22, ' ') +
                                " | " + ((item.CursoIzajeVto != Fecha.ValidarFecha("01-01-1900")) ? Fecha.ConvertirFecha(item.CursoIzajeVto.AddMonths(Global.Vigencia_CursoIzaje)) : "").PadRight(10, ' ') +
                                " | " + (((item.ExamenMedicoVto != Fecha.ValidarFecha("01-01-1900")) ? Fecha.ConvertirFecha(item.ExamenMedicoVto.AddMonths(Global.Vigencia_ExamenMedico)) + " (" + item.ExamenMedicoEvaluacion + " - " + item.ExamenMedicoTipo + ")" : "")).PadRight(37, ' '));
                        lista.Add(objCatalogoBase);
                    }
                }
                else lista = nBusquedaPostulante.obtenerCatalago(cmbPerfilLaboral.Text, chkTrabajoEmpreminsa.Checked, cmbDisponibilidad.Text, cmbCalificacion.Text, chkCurriculumVitaeVigente.Checked, chkCertificadoAntecedentesVigente.Checked, chkLicenciaConducirVigente.Checked, chkCursoInduccionVigenteAprobado.Checked, chkCursoIzajeVigente.Checked, chkExamenMedicoVigenteApto.Checked, "CATALOGO2"); //Carga los Registros
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Denominación",
                    "CUIL/CUIT",
                    "Celular(es)",
                    "T.Emp.",
                    "Disp.",
                    "Calificación",
                    "C.V.",
                    "C.A. Vto. (tipo)",
                    "Lic.C. Vto.",
                    "C. Inducción Vto. (eval.)",
                    "C. Izaje Vto.",
                    "Examen Médico Vto. (eval. - tipo)" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //Denominación
                        campo[1].Trim(), //CUIL/CUIT
                        campo[2].Trim(), //Celular(es)
                        campo[3].Trim(), //Trabajó en Empreminsa
                        campo[4].Trim(), //Disponibilidad
                        campo[5].Trim(), //Calificación
                        campo[6].Trim(), //C.V.
                        campo[7].Trim(), //C.A. Vto. - Tipo
                        campo[8].Trim(), //Lic.C. Vto.
                        campo[9].Trim(), //C.Ind. Vto. - Eval.
                        campo[10].Trim(), //C.Iza. Vto. 
                        campo[11].Trim() }; //E.Med. Vto. - Eval. - Tipo
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Búsqueda de Postulantes (Perfil " + cmbPerfilLaboral.Text + ")", subTitulos, new int[] { 35, 13, 43, 5, 5, 14, 8, 23, 10, 22, 10, 37 }, _listaDelReporte, new List<int> { }, 58); //Ancho: 130
            }
        }
        #endregion
    }
}
