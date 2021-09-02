using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using CapaPresentacion.Catalogo;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormSueldo : Biblioteca.Formularios.FormBaseABM_RRHH
    {
        #region Atributos
        private bool _nuevoRegitroDesdeNavegacion = false;
        private bool _controladorDeModificacionTextBox_SueldoNeto = false;
        private string _controladorDeModificacionTextBox_ValorSueldoNeto = "";
        private string[] consultaSueldo;
        private Legajo objLegajo; //Objeto Primario
        private LegajoLaboral objLegajoLaboral; //Objeto Secundario
        private Sueldo objSueldo; //Objeto del Módulo
        private Sueldo objSueldoDB; //Objeto de la Base de Datos
        private N_Legajo nLegajo = new N_Legajo();
        private N_LegajoLaboral nLegajoLaboral = new N_LegajoLaboral();
        private N_Sueldo nSueldo = new N_Sueldo();
        private N_AsientoContable nAsientoContable = new N_AsientoContable();
        private N_CuentaContable nCuentaContable = new N_CuentaContable();
        #endregion

        #region Constructores
        public FormSueldo()
        {
            InitializeComponent();
        }
        public FormSueldo(Legajo navLegajo, bool nuevoRegitroDesdeNavegacion = false) //Utilizado por el navegador de formularios
        {
            objLegajo = navLegajo;
            _nuevoRegitroDesdeNavegacion = nuevoRegitroDesdeNavegacion;
            InitializeComponent();
        }
        public FormSueldo(Sueldo navSueldo) //Utilizado por el navegador de formularios
        {
            objSueldoDB = objSueldo = navSueldo;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormSueldo_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(txtID, "Número de comprobante");
            toolTip.SetToolTip(pkrFechaEmision, "Fecha de comprobante");
            toolTip.SetToolTip(cmbPeriodo, "Periodo contable - Mes");
            toolTip.SetToolTip(txtPeriodo, "Periodo contable - Año");
            toolTip.SetToolTip(txtEstado, "Estado del comprobante");
            #endregion
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ANULADO",
                        "FILTRAR POR ESTADO: LIQUIDADO", "TODOS LOS ESTADOS" }, 1); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT",
                        "FILTRAR POR DENOMINACION", "FILTRAR POR FECHA", "FILTRAR POR PERIODO" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
            if (objLegajo != null) instanciarDesdeNavegacion(objLegajo);
            if (objSueldoDB != null && !_controladorDeNuevoRegistro) escribirControles(objSueldoDB); //Escribe los datos solicitados mediante la navegación entre formularios
        }

        private void btnBuscarLegajo_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                FormCatalogo_Legajo frm = new FormCatalogo_Legajo(this);
                frm.ShowDialog(this);
            }
        }

        private void txtSueldoBruto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtSueldoBruto.Text);
        }

        private void txtSueldoBruto_Validated(object sender, EventArgs e)
        {
            calcularLiquidacionSueldo(); //Calcula la liquidación del sueldo
        }

        private void txtSAC_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtSAC.Text);
        }

        private void txtSAC_Validated(object sender, EventArgs e)
        {
            calcularLiquidacionSueldo(); //Calcula la liquidación del sueldo
        }

        private void txtNoRemunerativo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtNoRemunerativo.Text);
        }

        private void txtNoRemunerativo_Validated(object sender, EventArgs e)
        {
            calcularLiquidacionSueldo(); //Calcula la liquidación del sueldo
        }

        private void txtIndemnizacionNR_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtIndemnizacionNR.Text);
        }

        private void txtIndemnizacionNR_Validated(object sender, EventArgs e)
        {
            calcularLiquidacionSueldo(); //Calcula la liquidación del sueldo
        }

        private void txtEmbargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtEmbargo.Text);
        }

        private void txtEmbargo_Validated(object sender, EventArgs e)
        {
            calcularLiquidacionSueldo(); //Calcula la liquidación del sueldo
        }

        private void txtImpGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtImpGanancia.Text);
        }

        private void txtImpGanancia_Validated(object sender, EventArgs e)
        {
            calcularLiquidacionSueldo(); //Calcula la liquidación del sueldo
        }

        private void txtSueldoNeto_Enter(object sender, EventArgs e)
        {
            _controladorDeModificacionTextBox_ValorSueldoNeto = txtSueldoNeto.Text;
        }

        private void txtSueldoNeto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtSueldoNeto.Text);
        }

        private void txtSueldoNeto_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSueldoNeto.Text) || txtSueldoNeto.Text == "0,00")
            {
                _controladorDeModificacionTextBox_SueldoNeto = false;
            }
            else _controladorDeModificacionTextBox_SueldoNeto = true;
            calcularLiquidacionSueldo(); //Calcula la liquidación del sueldo
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(139))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objSueldo != null)
            {
                if (objSueldo.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(139)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)) != null) //Verifica que la persona tenga un Legajo Laboral
                    {
                        if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                this.objLegajo = nLegajo.obtenerObjeto("ID", objSueldo.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                                objSueldo.Id = nSueldo.generarNumeroID(); //Paso 3: Genera un ID para cada Objeto
                                if (nSueldo.insertar(objSueldo)) //Paso 4: Inserta el objeto principal
                                {
                                    calcularCtaCte("REGISTRACION"); //Paso 5: Actualiza la Cta.Cte. del Legajo Personal
                                    asentarTransaccion("REGISTRACION"); //Paso 6: Registra el/los Asiento/s Contable/s
                                    mostrarRegistro(objSueldo);
                                    Mensaje.RegistroCorrecto("REGISTRACION");
                                }
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación incorrecta.\nLa persona No posee un legajo laboral.\nVerifique los datos e intente nuevamente.");
                }
                else if (objSueldo.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(141)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (objSueldo.FechaEmision.AddDays(Global.RegistroModificacion) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        if (objSueldo.Estado == "LIQUIDADO") //Verifica si el comprobante esta activo
                        {
                            if (ValidarCampoVacio())
                            {
                                if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                                {
                                    instanciarObjeto(); //Paso 1: Instancia el Objeto
                                    this.objLegajo = nLegajo.obtenerObjeto("ID", objSueldo.Legajo.Id.ToString(), false); //Paso 3: Importante: Re-Almacena el Objeto de la Base de Datos
                                    if (!objSueldo.Equals(objSueldoDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                                    {
                                        if (nSueldo.actualizar(objSueldo))
                                        {
                                            calcularCtaCte("MODIFICACION"); //Paso 3: Actualiza la Cta.Cte. del Legajo Personal
                                            asentarTransaccion("MODIFICACION"); //Paso 4: Registra el/los Asiento/s Contable/s
                                            mostrarRegistro(objSueldo);
                                            Mensaje.RegistroCorrecto("MODIFICACION");
                                        }
                                    }
                                }
                            }
                        }
                        else Mensaje.Advertencia("Operación incorrecta.\nLos comprobantes anulados No pueden ser modificados.");
                    }
                    else Mensaje.Advertencia("Operación Incorrecta. Los comprobantes que han superado los " + Global.RegistroModificacion + " días de su registración No pueden ser modificados.");
                }
                else Mensaje.Restriccion();
                bool ValidarCampoVacio() // Método que valida los campos requeridos
                {
                    return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion, txtCuit, txtCentroCosto });
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objSueldo.Id > 0) escribirControles(objSueldoDB); //Restaura los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(140)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objSueldo.Id > 0)
                {
                    if (objSueldo.FechaEmision.AddDays(Global.RegistroAnulacion) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea anular el registro ID: " + objSueldo.Id.ToString() + "?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            objLegajo = nLegajo.obtenerObjeto("ID", objSueldo.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                            if (nSueldo.anular(objSueldo)) //Paso 3: Verifica el exito de la actualización y muestra los datos actualizados
                            {
                                objSueldo.Estado = "ANULADO"; //Paso 4: Importante: Establece el cambio de estado en el Objeto del Módulo 
                                calcularCtaCte("ANULACION"); //Paso 5: Actualiza la Cta.Cte. del Legajo Personal
                                asentarTransaccion("ANULACION"); //Paso 6: Registra el/los Asiento/s Contable/s 
                                mostrarRegistro(objSueldo);
                                Mensaje.RegistroCorrecto("ANULACION");
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación Incorrecta. Los comprobantes que han superado los " + Global.RegistroAnulacion + " días de su registración No pueden ser anulados.");
                }
            }
            else Mensaje.Restriccion();
        }
        #endregion

        #region Métodos
        private void asentarTransaccion(string operacion)
        {
            AsientoContable objAsientoContable = new AsientoContable();
            double cuentaSueldo = Formulario.ValidarNumeroDoble(txtSueldoBruto.Text) + Formulario.ValidarNumeroDoble(txtSAC.Text) + Formulario.ValidarNumeroDoble(txtNoRemunerativo.Text) + Formulario.ValidarNumeroDoble(txtIndemnizacionNR.Text);
            double cuentaCargaSocial = Formulario.ValidarNumeroDoble(txtContribucionPatronal.Text);
            double cuentaArtScvo = Formulario.ValidarNumeroDoble(txtArtScvo.Text);
            double cuentaFCL = Formulario.ValidarNumeroDoble(txtFCL.Text);
            double cuentaCargaSocialAPagar = Formulario.ValidarNumeroDoble(txtContribucionPatronal.Text) + Formulario.ValidarNumeroDoble(txtAporte.Text);
            double cuentaSindicatoAPagar = Formulario.ValidarNumeroDoble(txtAporteSindicato.Text);
            double cuentaGananciaAPagar = Formulario.ValidarNumeroDoble(txtImpGanancia.Text);
            double cuentaArtScvoAPagar = Formulario.ValidarNumeroDoble(txtArtScvo.Text);
            double cuentaFCLAPagar = Formulario.ValidarNumeroDoble(txtFCL.Text);
            double cuentaEmbargoAPagar = Formulario.ValidarNumeroDoble(txtEmbargo.Text);
            double cuentaSueldoAPagar = Formulario.ValidarNumeroDoble(txtSueldoNeto.Text) + Formulario.ValidarNumeroDoble(txtAnticipoSueldo.Text);
            objAsientoContable.AsientoFecha = pkrFechaEmision.Value; //PONER PERIODO---------------- -- -- --- 
            objAsientoContable.Descripcion = "Sueldo: LIQ-X N°" + Convert.ToString(objSueldo.Id).PadLeft(8, '0');
            objAsientoContable.Conciliacion = "NO-APLICA";
            objAsientoContable.OrigenTipo = "LQS";
            objAsientoContable.OrigenId = objSueldo.Id;
            if (operacion == "REGISTRACION") objAsientoContable.AsientoNro = nAsientoContable.generarNumeroAsiento(); //Verifica que es un nuevo comprobante. Si es asi, genera un nuevo Número de Asiento
            else
            {
                AsientoContable objAsientoContablePrecedente = nAsientoContable.obtenerObjeto("LQS", objSueldo.Id); //Paso 1: En el caso de una modificación o anulación, obtiene el Asiento registrado precedentemente
                if (objAsientoContablePrecedente != null) //Paso 2: Importante: Verifica la existencia de al menos un Asiento contable
                {
                    objAsientoContable.AsientoNro = objAsientoContablePrecedente.AsientoNro;
                    foreach (AsientoContable item in nAsientoContable.obtenerObjetos("LIBRO_DIARIO", 0, "ASIENTO", Convert.ToString(objAsientoContable.AsientoNro))) //Paso 3: Obtiene y recorre la lista de Asientos registrados precedentemente
                    {
                        nCuentaContable.actualizarSaldo(item.CuentaContable.Id, ((item.CuentaContable.Saldo - item.Debe) + item.Haber)); //Paso 4: Restaura el saldo de la Cuenta Contable de cada Asiento
                    }
                    nAsientoContable.eliminar(objAsientoContable.AsientoNro); //Paso 5: Elimina todos los Asientos Contables en relación al Numero de Asiento
                }
            }
            if (operacion != "ANULACION") //Verifica que No sea una Anulación. Si es así, crea los correspondientes Asientos Contables 
            {
                crearAsientoContable(objAsientoContable,
                    new string[] { "SUELDOS", "CARGAS SOCIALES", "ART + SCVO", "FCL", "CARGAS SOCIALES A PAGAR", "SINDICATOS A PAGAR", "RET. GANANCIAS EFECTUADA", "ART + SCVO A PAGAR", "FCL A PAGAR", "EMBARGOS A PAGAR", "SUELDOS A PAGAR"},
                    new double[] { cuentaSueldo, cuentaCargaSocial, cuentaArtScvo, cuentaFCL, cuentaCargaSocialAPagar, cuentaSindicatoAPagar, cuentaGananciaAPagar, cuentaArtScvoAPagar, cuentaFCLAPagar,  cuentaEmbargoAPagar, cuentaSueldoAPagar },
                    new string[] { "DEBE", "DEBE", "DEBE", "DEBE", "HABER", "HABER", "HABER", "HABER", "HABER", "HABER", "HABER" },
                    new bool[] { false, false, false, false, true, true, true, true, true, true, true });
            }
            void crearAsientoContable(AsientoContable asiento, string[] cuentaContable, double[] monto, string[] deducirMonto, bool[] calcularSaldoCuentaContable)
            {
                for (int i = 0; i < cuentaContable.Length; i++)
                {
                    if (monto[i] != 0.00)
                    {
                        asiento.CuentaContable = nCuentaContable.obtenerObjeto("DENOMINACION", cuentaContable[i], true);
                        asiento.Debe = (deducirMonto[i] == "DEBE") ? monto[i] : 0.00;
                        asiento.Haber = (deducirMonto[i] == "HABER") ? monto[i] : 0.00;
                        nAsientoContable.insertar(asiento); //Paso 1: Registra el Asiento Contable en la Base de Datos
                        if (calcularSaldoCuentaContable[i]) nCuentaContable.actualizarSaldo(asiento.CuentaContable.Id, ((asiento.CuentaContable.Saldo + asiento.Debe) - asiento.Haber)); //Paso 2: Actualiza el saldo en la Cuenta Contable (El Debe suma en el Saldo y el Haber resta en el Saldo)
                    }
                }
            }
        }

        private void calcularLiquidacionSueldo()
        {
            if (objLegajoLaboral != null && objLegajoLaboral.Sindicato != null)
            {
                double montoAfectado = Formulario.ValidarNumeroDoble(txtSueldoBruto.Text) + Formulario.ValidarNumeroDoble(txtSAC.Text);
                // ----------------- APORTES ----------------- //
                double aporteEmpleado = (montoAfectado / 100) * Global.LiquidacionSueldo_AporteTasa;
                txtAporte.Text = Formulario.ValidarCampoMoneda(Math.Ceiling(aporteEmpleado * 100) / 100);
                // ------------- APORTE SINDICAL ------------- //
                double aplicaMontoNR = (objLegajoLaboral.Sindicato.IncluyeTotalNR) ? Formulario.ValidarNumeroDoble(txtNoRemunerativo.Text) : 0.00;
                double aporteSindical = (((montoAfectado + aplicaMontoNR) / 100) * (objLegajoLaboral.Sindicato.AporteSolidarioTasa + ((objLegajoLaboral.AfiliadoSindical) ? objLegajoLaboral.Sindicato.CuotaSindicalTasa : 0.00) + objLegajoLaboral.Sindicato.SeguroSocialTasa)) + objLegajoLaboral.Sindicato.AporteSolidarioFijo + ((objLegajoLaboral.AfiliadoSindical) ? objLegajoLaboral.Sindicato.CuotaSindicalFijo : 0.00) + objLegajoLaboral.Sindicato.SeguroSocialFijo;
                txtAporteSindicato.Text = Formulario.ValidarCampoMoneda(Math.Ceiling(aporteSindical * 100) / 100);
                // ---------- CONTRIBUCION PATRONAL ---------- //
                double contribucionPatronalTasa = (objLegajoLaboral.ModalidadContratacionTiempo == "TIEMPO PARCIAL") ? Global.LiquidacionSueldo_ContribTiempoParcialTasa : Global.LiquidacionSueldo_ContribTiempoCompletoTasa;
                double contribucionPatronal = (montoAfectado / 100) * contribucionPatronalTasa;
                txtContribucionPatronal.Text = Formulario.ValidarCampoMoneda(Math.Ceiling(contribucionPatronal * 100) / 100);
                // ----------- FONDO CESE LABORAL ------------ //
                int antiguedadEnAnio = Fecha.CalcularAntiguedadLaboral_Anio(objLegajoLaboral.FechaIngreso, objLegajoLaboral.FechaEgreso, objLegajoLaboral.Estado);
                double fclTasa = (antiguedadEnAnio > 0) ? objLegajoLaboral.Sindicato.FCL_MasDeUnAnioTasa : objLegajoLaboral.Sindicato.FCL_PrimerAnioTasa;
                double fcl = (Formulario.ValidarNumeroDoble(txtSueldoBruto.Text) / 100) * fclTasa;
                txtFCL.Text = Formulario.ValidarCampoMoneda(Math.Ceiling(fcl * 100) / 100);
                // --------------- ART + SCVO ---------------- //
                double totalAfectadoNR = montoAfectado + Formulario.ValidarNumeroDoble(txtNoRemunerativo.Text);
                double artSCVO = ((totalAfectadoNR / 100) * Global.LiquidacionSueldo_ArtTasa) + Global.LiquidacionSueldo_ArtFijo + Global.LiquidacionSueldo_SCVO;
                txtArtScvo.Text = Formulario.ValidarCampoMoneda(Math.Ceiling(artSCVO * 100) / 100);
                // --------------- SUELDO NETO --------------- //
                double sueldoNeto = (Formulario.ValidarNumeroDoble(txtSueldoBruto.Text) + Formulario.ValidarNumeroDoble(txtSAC.Text) + Formulario.ValidarNumeroDoble(txtNoRemunerativo.Text) + Formulario.ValidarNumeroDoble(txtIndemnizacionNR.Text)) - (Formulario.ValidarNumeroDoble(txtAnticipoSueldo.Text) + Formulario.ValidarNumeroDoble(txtEmbargo.Text) + Formulario.ValidarNumeroDoble(txtAporte.Text) + Formulario.ValidarNumeroDoble(txtAporteSindicato.Text) + Formulario.ValidarNumeroDoble(txtImpGanancia.Text));
                if (!_controladorDeModificacionTextBox_SueldoNeto) txtSueldoNeto.Text = Formulario.ValidarCampoMoneda(Math.Ceiling(sueldoNeto * 100) / 100);
            }
        }

        private void calcularCtaCte(string operacion)
        {
            double anticipo = Formulario.ValidarNumeroDoble(txtAnticipoSueldo.Text);
            double sueldoNeto = Formulario.ValidarNumeroDoble(txtSueldoNeto.Text);
            double saldo = objLegajo.Saldo;
            if (operacion == "REGISTRACION") saldo = (saldo + anticipo + sueldoNeto); //Suma el anticipo con el sueldo neto y lo suma al saldo de la Cta.Cte. del Legajo Personal
            else if (operacion == "MODIFICACION") saldo = ((saldo - (objSueldoDB.AnticipoSueldo + objSueldoDB.SueldoNeto)) + (anticipo + sueldoNeto)); //Resta del saldo de la Cta.Cte. del Legajo Personal el valor precedente (anticipo DB + sueldo neto DB) y le suma el nuevo valor (anticipo + sueldo neto)
            else if (operacion == "ANULACION") saldo = (saldo - (objSueldoDB.AnticipoSueldo + objSueldoDB.SueldoNeto)); //Resta del saldo de la Cta.Cte. del Legajo Personal el anticipo precedente mas el sueldo neto precedente
            nLegajo.actualizarSaldo(objLegajo.Id, saldo, false); //Actualiza el saldo en la Cta.Cte. del Legajo Personal 
            this.objLegajo.Saldo = saldo; //Importante: Actualiza el saldo del Objeto Maestro
        }

        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(Sueldo objRegistro)
        {
            this.objSueldo = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            if (objSueldo != null && objSueldo.Legajo != null)
            {
                if (!objSueldo.Legajo.InformacionRestringida || (objSueldo.Legajo.InformacionRestringida && Global.UsuarioActivo_Privilegios.Contains(1))) //Verifica que el usuario posea el privilegio requerido
                {
                    _controladorDeNuevoRegistro = false;
                    DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
                    objLegajo = objSueldo.Legajo;
                    objLegajoLaboral = new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id));
                    txtID.Text = Convert.ToString(objSueldo.Id).PadLeft(8, '0');
                    pkrFechaEmision.Value = objSueldo.FechaEmision;
                    string[] periodo = objSueldo.Periodo.ToString().Split('-');
                    cmbPeriodo.Text = periodo[0];
                    txtPeriodo.Text = periodo[1];
                    txtEstado.Text = objSueldo.Estado;
                    txtDenominacion.Text = objSueldo.Legajo.Denominacion;
                    txtCuit.Text = Convert.ToString(objSueldo.Legajo.Cuit);
                    txtCentroCosto.Text = (objSueldo.CentroCosto != null) ? objSueldo.CentroCosto.Denominacion : "";
                    txtConvenio.Text = (objSueldo.Sindicato != null) ? objSueldo.Sindicato.Convenio : "";
                    txtSueldoBruto.Text = Formulario.ValidarCampoMoneda(objSueldo.SueldoBruto);
                    txtSAC.Text = Formulario.ValidarCampoMoneda(objSueldo.Sac);
                    txtNoRemunerativo.Text = Formulario.ValidarCampoMoneda(objSueldo.NoRemunerativo);
                    txtIndemnizacionNR.Text = Formulario.ValidarCampoMoneda(objSueldo.IndemnizacionNR);
                    txtAnticipoSueldo.Text = Formulario.ValidarCampoMoneda(objSueldo.AnticipoSueldo);
                    txtEmbargo.Text = Formulario.ValidarCampoMoneda(objSueldo.Embargo);
                    txtAporte.Text = Formulario.ValidarCampoMoneda(objSueldo.Aporte);
                    txtAporteSindicato.Text = Formulario.ValidarCampoMoneda(objSueldo.AporteSindicato);
                    txtImpGanancia.Text = Formulario.ValidarCampoMoneda(objSueldo.ImpuestoGanancia);
                    txtSueldoNeto.Text = Formulario.ValidarCampoMoneda(objSueldo.SueldoNeto);
                    txtContribucionPatronal.Text = Formulario.ValidarCampoMoneda(objSueldo.ContribucionPatronal);
                    txtArtScvo.Text = Formulario.ValidarCampoMoneda(objSueldo.ArtScvo);
                    txtFCL.Text = Formulario.ValidarCampoMoneda(objSueldo.FondoCeseLaboral);
                    txtObservacion.Text = objSueldo.Observacion;
                    labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objSueldo.EdicionFecha) + " por " + objSueldo.EdicionUsuarioDenominacion;
                }
                else restaurarControles();
            }
        }

        private void instanciarDesdeNavegacion(Legajo objLegajo)
        {
            if (_nuevoRegitroDesdeNavegacion && !objLegajo.Baja) //Verifica la orden de "nuevo registro" y que el Legajo No este dado de baja
            {
                cmbFiltroLista1.Enabled = false; //Paso 1a: Desactiva el filtro de estados
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS"; //Paso 1b: Selecciona todos los estados 
                cmbFiltroLista2.Text = "FILTRAR POR CUIT"; //Paso 1c: Selecciona la busqueda por CUIT 
                txtFiltroLista.Text = Convert.ToString(objLegajo.Cuit); //Paso 2: Establece el CUIT recibido
                filtrarCatalogo(0); //Paso 3: Carga el catálogo
                lstCatalogo.ClearSelected(); //Paso 4: Quita la selección de la fila
                btnNuevo.PerformClick(); //Paso 5: Ejecuta automáticamente el botón "Nuevo"
                this.objLegajo = objLegajo; //Paso 6: Iguala el Atributo de la clase con el Objeto recibido
                txtDenominacion.Text = objLegajo.Denominacion;
                txtCuit.Text = Convert.ToString(objLegajo.Cuit);
                txtAnticipoSueldo.Text = (objLegajo.Saldo < 0) ? Formulario.ValidarCampoMoneda(objLegajo.Saldo * (-1)) : "0,00";
                this.objLegajoLaboral = new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id));
                txtCentroCosto.Text = (objLegajoLaboral != null && objLegajoLaboral.CentroCosto != null) ? objLegajoLaboral.CentroCosto.Denominacion : "";
                txtConvenio.Text = (objLegajoLaboral != null && objLegajoLaboral.Sindicato != null) ? objLegajoLaboral.Sindicato.Convenio : "";
            }
            else
            {
                objSueldoDB = nSueldo.obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)); //Paso 1: Busca el registro en la Base de Datos en relación al objeto maestro recibido 
                if (objSueldoDB != null)
                {
                    lstCatalogo.SelectedValue = objSueldoDB.Id; //Paso 2: Posiona la selección de la fila en el registro guardado
                    escribirControles(objSueldoDB); //Paso 3: Escribe los datos del registro indicado
                }
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objSueldo = new Sueldo(
                (objSueldo.Id <= 0) ? 0 : objSueldo.Id,
                pkrFechaEmision.Value,
                cmbPeriodo.Text + "-" + txtPeriodo.Text,
                txtEstado.Text,
                objLegajo,
                new N_CentroCosto().obtenerObjeto("DENOMINACION", txtCentroCosto.Text),
                new N_Sindicato().obtenerObjeto("CONVENIO", txtConvenio.Text),
                Formulario.ValidarNumeroDoble(txtSueldoBruto.Text),
                Formulario.ValidarNumeroDoble(txtSAC.Text),
                Formulario.ValidarNumeroDoble(txtNoRemunerativo.Text),
                Formulario.ValidarNumeroDoble(txtIndemnizacionNR.Text),
                Formulario.ValidarNumeroDoble(txtAnticipoSueldo.Text),
                Formulario.ValidarNumeroDoble(txtEmbargo.Text),
                Formulario.ValidarNumeroDoble(txtAporte.Text),
                Formulario.ValidarNumeroDoble(txtAporteSindicato.Text),
                Formulario.ValidarNumeroDoble(txtImpGanancia.Text),
                Formulario.ValidarNumeroDoble(txtSueldoNeto.Text),
                Formulario.ValidarNumeroDoble(txtContribucionPatronal.Text),
                Formulario.ValidarNumeroDoble(txtArtScvo.Text),
                Formulario.ValidarNumeroDoble(txtFCL.Text),
                txtObservacion.Text,
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objLegajo = new Legajo(); //Restaura el Objeto Primario
            objLegajoLaboral = new LegajoLaboral(); //Restaura el Objeto SubPrimario
            objSueldo = new Sueldo(); //Importante: Restaura el Objeto del Móludo
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            txtID.Text = "";
            pkrFechaEmision.Value = fechaActual;
            cmbPeriodo.Text = fechaActual.Month.ToString().PadLeft(2, '0');
            txtPeriodo.Text = fechaActual.Year.ToString();
            txtEstado.Text = "LIQUIDADO";
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            txtCentroCosto.Text = "";
            txtConvenio.Text = "";
            txtSueldoBruto.Text = "0,00";
            txtSAC.Text = "0,00";
            txtNoRemunerativo.Text = "0,00";
            txtIndemnizacionNR.Text = "0,00";
            txtAnticipoSueldo.Text = "0,00";
            txtEmbargo.Text = "0,00";
            txtAporte.Text = "0,00";
            txtAporteSindicato.Text = "0,00";
            txtImpGanancia.Text = "0,00";
            txtSueldoNeto.Text = "0,00";
            txtContribucionPatronal.Text = "0,00";
            txtArtScvo.Text = "0,00";
            txtFCL.Text = "0,00";
            txtObservacion.Text = "";
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, txtCuit, txtCentroCosto }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(Sueldo objRegistro) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objSueldoDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            escribirControles(objSueldoDB); //Escribe los datos del registro seleccionado
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR CUIT")
            {
                cmbFiltroLista1.Enabled = false;
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });

            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION" || cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR PERIODO")
            {
                cmbFiltroLista1.Enabled = true;
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA")
            {
                cmbFiltroLista1.Enabled = true;
                Formulario.Visibilidad(false, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(true, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta }); //Verifica que se ha seleccionado el filtrado por fecha y habilita las casillas "desde y hasta"
            }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroEstado = "TODOS";
            if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ANULADO") filtroEstado = "ANULADO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: LIQUIDADO") filtroEstado = "LIQUIDADO";
            if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de CUIL/CUIT
            {
                consultaSueldo = new string[] { filtroEstado, "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nSueldo.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la denominacón
            {
                consultaSueldo = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nSueldo.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA") //Verifica que el tipo de filtro es por fecha de emisión
            {
                consultaSueldo = new string[] { filtroEstado, "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nSueldo.obtenerCatalago(filtroEstado, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR PERIODO") //Verifica que el tipo de filtro es por Periodo
            {
                consultaSueldo = new string[] { filtroEstado, "PERIODO", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nSueldo.obtenerCatalago(filtroEstado, "PERIODO", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objSueldoDB = nSueldo.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objSueldoDB); //Escribe los datos del registro seleccionado
        }

        protected override void navegarA_Formulario(string destino) { NavegacionRRHH.navegarA_Formulario(destino, this, objLegajo); }

        protected override void reportarRegistro(string programa)
        {
            if (objSueldo.Id > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "N° Comprobante: ",
                    "Fecha de emisión: ",
                    "Periodo: ",
                    "Estado: ",
                    "Denominación: ",
                    "CUIL/CUIT: ",
                    "Centro de costo: ",
                    "Convenio: ",
                    "Sueldo bruto: ",
                    "SAC: ",
                    "No remunerativo: ",
                    "Indemnización (NR): ",
                    "Anticipo de sueldo: ",
                    "Embargo: ",
                    "Aporte (jubilación + PAMI + OS): ",
                    "Aporte (sindicato): ",
                    "Imp. a las Ganancias: ",
                    "Sueldo neto: ",
                    "Contribución patronal: ",
                    "ART + SCVO: ",
                    "FCL: ",
                    "Observación: " };
                string[] datoDB = {
                    objSueldo.Legajo.Id.ToString().PadLeft(8, '0'),
                    Fecha.ConvertirFecha(objSueldo.FechaEmision),
                    objSueldo.Periodo,
                    objSueldo.Estado,
                    objSueldo.Legajo.Denominacion,
                    objSueldo.Legajo.Cuit.ToString("00-00000000/0"),
                    objSueldo.CentroCosto.Denominacion,
                    ((objSueldo.Sindicato != null) ? objSueldo.Sindicato.Convenio : ""),
                    Formulario.ValidarCampoMoneda(objSueldo.SueldoBruto),
                    Formulario.ValidarCampoMoneda(objSueldo.Sac),
                    Formulario.ValidarCampoMoneda(objSueldo.NoRemunerativo),
                    Formulario.ValidarCampoMoneda(objSueldo.IndemnizacionNR),
                    Formulario.ValidarCampoMoneda(objSueldo.AnticipoSueldo),
                    Formulario.ValidarCampoMoneda(objSueldo.Embargo),
                    Formulario.ValidarCampoMoneda(objSueldo.Aporte),
                    Formulario.ValidarCampoMoneda(objSueldo.AporteSindicato),
                    Formulario.ValidarCampoMoneda(objSueldo.ImpuestoGanancia),
                    Formulario.ValidarCampoMoneda(objSueldo.SueldoNeto),
                    Formulario.ValidarCampoMoneda(objSueldo.ContribucionPatronal),
                    Formulario.ValidarCampoMoneda(objSueldo.ArtScvo),
                    Formulario.ValidarCampoMoneda(objSueldo.FondoCeseLaboral),
                    objSueldo.Observacion };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Sueldo ", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Sueldo ", subTitulo, datoDB);
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
                lista = nSueldo.obtenerCatalago(consultaSueldo[0], consultaSueldo[1], consultaSueldo[2], "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "Periodo",
                    "Estado",
                    "S.Bruto",
                    "SAC: ",
                    "No Remun.",
                    "Indem.(NR)",
                    "Anticipo",
                    "Embargo",
                    "Aporte",
                    "Aporte S.",
                    "Imp.G.",
                    "S.Neto",
                    "C.Patronal",
                    "ART+SCVO",
                    "FCL",
                    "Denominación - CUIL/CUIT" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                            campo[0].Trim(), //Periodo
                            campo[1].Trim(), //Estado
                            "$"+campo[2].Trim(), //S.Bruto
                            "$"+campo[3].Trim(), //SAC
                            "$"+campo[4].Trim(), //No Remun.
                            "$"+campo[5].Trim(), //Indem.(NR)
                            "$"+campo[6].Trim(), //Anticipo
                            "$"+campo[7].Trim(), //Embargo
                            "$"+campo[8].Trim(), //Aporte
                            "$"+campo[9].Trim(), //Aporte (sindicato)
                            "$"+campo[10].Trim(), //Imp. Ganancias
                            "$"+campo[11].Trim(), //S.Neto
                            "$"+campo[12].Trim(), //C.Patronal
                            "$"+campo[13].Trim(), //ART+SCVO
                            "$"+campo[14].Trim(), //FCL
                            campo[15] }; //Denominación - CUIL/CUIT
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                string tituloPeriodo = (cmbFiltroLista2.Text == "FILTRAR POR PERIODO") ? " (periodo " + txtFiltroLista.Text + ")" : "";
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Sueldos " + tituloPeriodo, subTitulos, new int[] { 7, 10, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 49 }, _listaDelReporte, new List<int> { }, 67); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Sueldos " + tituloPeriodo, subTitulos, new float[] { 6, 9, 8, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 25 }, _listaDelReporte); //Ancho: 111
            }
        }

        public override void asignarVariablesDeFormulario(string[] variablesDeFormulario)
        {
            if (variablesDeFormulario[0] == "Catalogo_Legajo") //Catálogo de Legajos
            {
                this.objLegajo = new N_Legajo().obtenerObjeto("ID", variablesDeFormulario[1], true);
                txtDenominacion.Text = objLegajo.Denominacion;
                txtCuit.Text = Convert.ToString(objLegajo.Cuit);
                txtAnticipoSueldo.Text = (objLegajo.Saldo < 0) ? Formulario.ValidarCampoMoneda(objLegajo.Saldo * (-1)) : "0,00";
                this.objLegajoLaboral = new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id));
                txtCentroCosto.Text = (objLegajoLaboral != null && objLegajoLaboral.CentroCosto != null) ? objLegajoLaboral.CentroCosto.Denominacion : "";
                txtCentroCosto.Text = (objLegajoLaboral != null && objLegajoLaboral.CentroCosto != null) ? objLegajoLaboral.CentroCosto.Denominacion : "";
                txtConvenio.Text = (objLegajoLaboral != null && objLegajoLaboral.Sindicato != null) ? objLegajoLaboral.Sindicato.Convenio : "";
                calcularLiquidacionSueldo(); //Re-calcula la liquidación del sueldo
            }
        }
        #endregion
    }
}
