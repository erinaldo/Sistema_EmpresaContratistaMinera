using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormResumenRelevanteLegajo : Biblioteca.Formularios.FormBaseReporte
    {
        #region Atributos
        CentroCosto _centroCosto = new CentroCosto();
        private ResumenRelevanteLegajo objResumenRelevanteLegajo = new ResumenRelevanteLegajo();
        private N_ResumenRelevanteLegajo nResumenRelevanteLegajo = new N_ResumenRelevanteLegajo();
        private List<CatalogoBase> _lista = new List<CatalogoBase>();
        #endregion

        public FormResumenRelevanteLegajo()
        {
            InitializeComponent();
        }

        #region Eventos: Formulario
        private void FormResumenRelevanteLegajo_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { }), "TODOS");
            cmbEstadoLaboral.Text = "TODOS";
            cargarListaDePostulante();
        }

        private void cmbEstadoLaboral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstadoLaboral.Focused) cargarListaDePostulante();
        }

        private void cmbCentroCosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCentroCosto.Focused) cargarListaDePostulante();
        }

        private void chkCertificadoAntecedentesVencido_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCertificadoAntecedentesVencido.Focused) cargarListaDePostulante();
        }

        private void chkCursoInduccionVigenteVencido_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCursoInduccionVigenteVencido.Focused) cargarListaDePostulante();
        }

        private void chkCursoIzajeVencido_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCursoIzajeVencido.Focused) cargarListaDePostulante();
        }

        private void chkExamenMedicoVigenteVencido_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExamenMedicoVigenteVencido.Focused) cargarListaDePostulante();
        }

        private void chkLicenciaConducirVencido_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLicenciaConducirVencido.Focused) cargarListaDePostulante();
        }
        #endregion

        #region Métodos
        private void cargarListaDePostulante()
        {
            _centroCosto = new N_CentroCosto().obtenerObjeto("DENOMINACION", cmbCentroCosto.Text, false);
            _lista = nResumenRelevanteLegajo.obtenerCatalago(cmbEstadoLaboral.Text, _centroCosto, chkCertificadoAntecedentesVencido.Checked, chkLicenciaConducirVencido.Checked, chkCursoInduccionVigenteVencido.Checked, chkCursoIzajeVencido.Checked, chkExamenMedicoVigenteVencido.Checked); //Carga los Registros
            lstCatalogo.DataSource = _lista;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
            lstCatalogo.ClearSelected();
        }

        private List<ResumenRelevanteLegajo> obtenerSeleccionDeElementos()
        {
            List<ResumenRelevanteLegajo> listaDelCatalogo = new List<ResumenRelevanteLegajo>();
            foreach (CatalogoBase item in lstCatalogo.SelectedItems)
            {
                ResumenRelevanteLegajo objResumenRelevanteLegajo = nResumenRelevanteLegajo.obtenerObjeto(Convert.ToInt64(item.Id), cmbEstadoLaboral.Text, _centroCosto, chkCertificadoAntecedentesVencido.Checked, chkLicenciaConducirVencido.Checked, chkCursoInduccionVigenteVencido.Checked, chkCursoIzajeVencido.Checked, chkExamenMedicoVigenteVencido.Checked);
                listaDelCatalogo.Add(objResumenRelevanteLegajo);
            }
            return listaDelCatalogo;
        }

        protected override void navegarAFormulario()
        {
            if (objResumenRelevanteLegajo.Legajo != null)
            {
                if (Global.UsuarioActivo_Privilegios.Contains(120)) //Verifica que el usuario posea el privilegio requerido
                {
                    Legajo navLegajo = new N_Legajo().obtenerObjeto("ID", Convert.ToString(objResumenRelevanteLegajo.Legajo.Id), false);
                    Formulario.AbrirFormularioHermano(this, new FormLegajo(navLegajo));
                }
                else Mensaje.Restriccion();
            }
        }

        protected override void mostrarElemento(long idElemento)
        {
            objResumenRelevanteLegajo = nResumenRelevanteLegajo.obtenerObjeto(idElemento, cmbEstadoLaboral.Text, _centroCosto, chkCertificadoAntecedentesVencido.Checked, chkLicenciaConducirVencido.Checked, chkCursoInduccionVigenteVencido.Checked, chkCursoIzajeVencido.Checked, chkExamenMedicoVigenteVencido.Checked);
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                if (lstCatalogo.SelectedItems.Count > 0)
                {
                    foreach (ResumenRelevanteLegajo item in obtenerSeleccionDeElementos())
                    {
                        CatalogoBase objCatalogoBase = new CatalogoBase(
                            item.Legajo.Id,
                            (item.Legajo.Denominacion).PadRight(35, ' ') +
                                " | " + item.Legajo.Cuit.ToString("00-00000000/0") +
                                " | " + (item.Legajo.Celular1 + ((item.Legajo.Celular1.Length > 0 && item.Legajo.Celular2.Length > 0) ? ", " : "") + item.Legajo.Celular2 + (((item.Legajo.Celular2.Length > 0 || item.Legajo.Celular2.Length > 0) && item.Legajo.Celular3.Length > 0) ? ", " : "") + item.Legajo.Celular3).PadRight(43, ' ') +
                                " | " + item.EstadoLaboral.PadRight(10, ' ') +
                                " | " + item.CentroCosto.Denominacion.PadRight(25, ' ') +
                                " | " + (((item.CertificadoAntecedenteVto != Fecha.ValidarFecha("01-01-1900")) ? Fecha.ConvertirFecha(item.CertificadoAntecedenteVto.AddMonths(Global.Vigencia_Antecedentes)) + " (" + item.CertificadoAntecedenteTipo + ")" : "")).PadRight(23, ' ') +
                                " | " + ((item.LicenciaConducirVto != Fecha.ValidarFecha("01-01-1900")) ? Fecha.ConvertirFecha(item.LicenciaConducirVto) : "").PadRight(10, ' ') +
                                " | " + (((item.CursoInduccionVto != Fecha.ValidarFecha("01-01-1900")) ? Fecha.ConvertirFecha(item.CursoInduccionVto.AddMonths(Global.Vigencia_CursoInduccion)) + " (" + item.CursoInduccionEvaluacion + ")" : "")).PadRight(22, ' ') +
                                " | " + ((item.CursoIzajeVto != Fecha.ValidarFecha("01-01-1900")) ? Fecha.ConvertirFecha(item.CursoIzajeVto.AddMonths(Global.Vigencia_CursoIzaje)) : "").PadRight(10, ' ') +
                                " | " + (((item.ExamenMedicoVto != Fecha.ValidarFecha("01-01-1900")) ? Fecha.ConvertirFecha(item.ExamenMedicoVto.AddMonths(Global.Vigencia_ExamenMedico)) + " (" + item.ExamenMedicoEvaluacion + " - " + item.ExamenMedicoTipo + ")" : "")).PadRight(37, ' '));
                        lista.Add(objCatalogoBase);
                    }
                }
                else lista = nResumenRelevanteLegajo.obtenerCatalago(cmbEstadoLaboral.Text, _centroCosto, chkCertificadoAntecedentesVencido.Checked, chkLicenciaConducirVencido.Checked, chkCursoInduccionVigenteVencido.Checked, chkCursoIzajeVencido.Checked, chkExamenMedicoVigenteVencido.Checked, "CATALOGO2"); //Carga los registros
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Denominación",
                    "CUIL/CUIT",
                    "Celular(es)",
                    "E.Laboral",
                    "Centro de Costo",
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
                        campo[3].Trim(), //Estado Laboral
                        campo[4].Trim(), //Centro de Costo
                        campo[5].Trim(), //C.A. Vto. - Tipo
                        campo[6].Trim(), //Lic.C. Vto.
                        campo[7].Trim(), //C.Ind. Vto. - Eval.
                        campo[8].Trim(), //C.Iza. Vto. 
                        campo[9].Trim() }; //E.Med. Vto. - Eval. - Tipo
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                string titulo = "Resumen Relevante de Legajos (Estado Laboral " + ((cmbEstadoLaboral.Text != "TODOS") ? cmbEstadoLaboral.Text : "ACTIVO/EN PROCESO") + ")";
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista(titulo, subTitulos, new int[] { 35, 13, 43, 10, 25, 23, 10, 22, 10, 37 }, _listaDelReporte, new List<int> { }, 58); //Ancho: 130
            }
        }
        #endregion
    }
}
