using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using CapaNegocio.Catalogo;
using CapaPresentacion.Catalogo;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormPagoOtro : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private string[] consultaPagoOtro;
        private PagoOtro objPagoOtro;
        private PagoOtro objPagoOtroDB;
        private N_PagoOtro nPagoOtro = new N_PagoOtro();
        private N_AsientoContable nAsientoContable = new N_AsientoContable();
        private N_CuentaContable nCuentaContable = new N_CuentaContable();
        #endregion

        #region Constructores
        public FormPagoOtro()
        {
            InitializeComponent();
        }
        public FormPagoOtro(PagoOtro navPagoOtro) //Utilizado por el navegador de formularios
        {
            objPagoOtroDB = objPagoOtro = navPagoOtro;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormPagoOtro_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(txtCbteTPV, "Punto de compra");
            toolTip.SetToolTip(txtCbteNro, "Número de comprobante");
            toolTip.SetToolTip(pkrCbteFecha, "Fecha de comprobante");
            toolTip.SetToolTip(txtEstado, "Estado del comprobante");
            toolTip.SetToolTip(btnWord_Acuse, "Genera y exporta el acuse de recibo de cobro a Word");
            #endregion
            Formulario.ComboBox_CargarElementos(cmbCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { }), 0);
            Formulario.ComboBox_CargarElementos(cmbCuentaContableDestino, new N_CuentaContable().obtenerListaDeElementos(new string[] { "PASIVO CORRIENTE > DEUDAS FISCALES", "PASIVO CORRIENTE > DEUDAS SOCIALES" }), "GASTOS OPERATIVOS"); //Establece los items del ComboBox
            cmbCuentaContableDestino.Items.Remove("SUELDOS A PAGAR"); //Importante: Quita la cuenta "SUELDOS A PAGAR" por que No corresponde a Otros Pagos
            Formulario.ComboBox_CargarElementos(cmbCtaBancaria, new N_Banco().obtenerListaDeElementos(), "S/D"); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO",
                "FILTRAR POR ESTADO: ANULADO", "TODOS LOS ESTADOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR DENOMINACION", "FILTRAR POR FECHA", "FILTRAR POR N° PV - CBTE" }, 0); //Establece los items del ComboBox 
            filtrarCatalogo(0); //Carga el catálogo
            if (objPagoOtroDB != null) escribirControles(objPagoOtroDB); //Escribe los datos solicitados mediante la navegación entre formularios
        }

        private void btnBuscarLegajo_Click(object sender, EventArgs e)
        {
            if (_controladorDeNuevoRegistro)
            {
                FormCatalogo_Legajo frm = new FormCatalogo_Legajo(this);
                frm.ShowDialog(this);
            }
        }

        private void txtMontoPagado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtMontoPagado.Text);
        }

        private void cmbMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMedioPago.Text == "CHEQUE")
            {
                Formulario.ComboBox_CargarElementos(cmbCuentaContableOrigen, new N_CuentaContable().obtenerListaDeElementos(new string[] { "VALORES A DEPOSITAR" }), 0); //Establece los items del ComboBox
                lblMedioNro.Text = "Cheque(nro. - vto.)";
                pkrMedioChequeVto.Text = Fecha.SistemaFecha();
                Formulario.Visibilidad(true, new Control[] { lblMedioNro, txtMedioNro, pkrMedioChequeVto });
                Formulario.Visibilidad(false, new Control[] { lblCtaBancaria, cmbCtaBancaria, btnCtaBancaria, cmbCtaBancariaTipo, txtCtaBancariaNro });
            }
            else if (cmbMedioPago.Text == "EFECTIVO")
            {
                Formulario.ComboBox_CargarElementos(cmbCuentaContableOrigen, new N_CuentaContable().obtenerListaDeElementos(new string[] { "DISPONIBILIDADES > CAJAS" }), 0); //Establece los items del ComboBox
                Formulario.Visibilidad(false, new Control[] { lblMedioNro, txtMedioNro, pkrMedioChequeVto,
                    lblCtaBancaria, cmbCtaBancaria, btnCtaBancaria,
                    cmbCtaBancariaTipo, txtCtaBancariaNro });
            }
            else if (cmbMedioPago.Text == "T.CREDITO" || cmbMedioPago.Text == "T.DEBITO")
            {
                Formulario.ComboBox_CargarElementos(cmbCuentaContableOrigen, new N_CuentaContable().obtenerListaDeElementos(new string[] { "TARJETAS" }), 0); //Establece los items del ComboBox
                Formulario.Visibilidad(false, new Control[] { lblMedioNro, txtMedioNro, pkrMedioChequeVto,
                    lblCtaBancaria, cmbCtaBancaria, btnCtaBancaria,
                    cmbCtaBancariaTipo, txtCtaBancariaNro });
            }
            else if (cmbMedioPago.Text == "TRANSFERENCIA")
            {
                Formulario.ComboBox_CargarElementos(cmbCuentaContableOrigen, new N_CuentaContable().obtenerListaDeElementos(new string[] { "DISPONIBILIDADES > BANCOS" }), 0); //Establece los items del ComboBox
                lblMedioNro.Text = "N° Transacción";
                Formulario.Visibilidad(false, new Control[] { pkrMedioChequeVto });
                Formulario.Visibilidad(true, new Control[] { lblMedioNro, txtMedioNro, lblCtaBancaria, cmbCtaBancaria,
                    btnCtaBancaria, cmbCtaBancariaTipo, txtCtaBancariaNro });
            }
        }

        private void cmbCtaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCtaBancaria.Text == "S/D")
            {
                cmbCtaBancariaTipo.Text = "S/D";
                txtCtaBancariaNro.Text = "";
            }
        }

        private void btnCtaBancaria_Click(object sender, EventArgs e)
        {
            FormCatalogo_Banco frm = new FormCatalogo_Banco(this);
            frm.ShowDialog(this);
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(157))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objPagoOtro != null)
            {
                if (objPagoOtro.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(157)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            objPagoOtro.Id = nPagoOtro.generarNumeroID(); //Paso 2: Genera un ID para cada Objeto
                            objPagoOtro.CbteNro = objPagoOtro.Id; //Paso 3: Establece el valor del ID como número de comprobante
                            if (nPagoOtro.insertar(objPagoOtro)) //Paso 4: Inserta el objeto principal
                            {
                                asentarTransaccion("REGISTRACION"); //Paso 5: Registra el/los Asiento/s Contable/s
                                mostrarRegistro(objPagoOtro);
                                Mensaje.RegistroCorrecto("REGISTRACION");
                            }
                        }
                    }
                }
                else if (objPagoOtro.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(159)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (objPagoOtro.CbteFecha.AddDays(Global.RegistroModificacion) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        if (objPagoOtro.Estado == "ACTIVO") //Verifica si el comprobante esta activo
                        {
                            {
                                if (ValidarCampoVacio())
                                {
                                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                                    {
                                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                                        if (!objPagoOtro.Equals(objPagoOtroDB)) //Paso 2: Verifica que el Objeto se ha modificado 
                                        {
                                            asentarTransaccion("MODIFICACION"); //Paso 3: Registra el/los Asiento/s Contable/s
                                            mostrarRegistro(objPagoOtro);
                                            Mensaje.RegistroCorrecto("MODIFICACION");
                                        }
                                    }
                                }

                            }
                        }
                        else Mensaje.Advertencia("Operación incorrecta.\nLos comprobantes anulados No pueden ser modificados.");
                    }
                    else Mensaje.Advertencia("Operación Incorrecta. Los comprobantes que han superado los " + Global.RegistroModificacion.ToString() + " días de su registración No pueden ser modificados.");
                }
                else Mensaje.Restriccion();
                bool ValidarCampoVacio() // Método que valida los campos requeridos
                {
                    return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion, cmbCentroCosto })
                        && Formulario.ValidarCampoVacioNumerico(false, new Control[] { txtMontoPagado });
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objPagoOtro.Id > 0) escribirControles(nPagoOtro.obtenerObjeto("ID", objPagoOtro.Id.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(158)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objPagoOtro.Id > 0)
                {
                    if (objPagoOtro.CbteFecha.AddDays(Global.RegistroAnulacion) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea anular el registro ID: " + objPagoOtro.Id.ToString() + "?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            if (nPagoOtro.anular(objPagoOtro)) //Paso 2: Verifica el exito de la actualización y muestra los datos actualizados
                            {
                                objPagoOtro.Estado = "ANULADO"; //Paso 3: Importante: Establece el cambio de estado en el Objeto del Módulo 
                                asentarTransaccion("ANULACION"); //Paso 4: Registra el/los Asiento/s Contable/s         
                                mostrarRegistro(objPagoOtro);
                                Mensaje.RegistroCorrecto("ANULACION");
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación Incorrecta. Los comprobantes que han superado los " + Global.RegistroAnulacion + " días de su registración No pueden ser anulados.");
                }
            }
            else Mensaje.Restriccion();
        }

        private void btnWord_Acuse_Click(object sender, EventArgs e)
        {
            if (objPagoOtro.Id > 0)
            {
                if (objPagoOtro.Estado == "ACTIVO") //Verifica si el comprobante esta activo
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string ctaBancariaDenominacion = (objPagoOtro.Banco != null) ? " - " + objPagoOtro.Banco.Denominacion : "";
                    string ctaBancariaTipo = (objPagoOtro.Banco != null && objPagoOtro.CtaBancariaTipo != "S/D") ? " " + objPagoOtro.CtaBancariaTipo : "";
                    string ctaBancariaNumero = (objPagoOtro.Banco != null && !string.IsNullOrEmpty(objPagoOtro.CtaBancariaNro.Trim())) ? " N°" + objPagoOtro.CtaBancariaNro.PadLeft(10, '0') : "";
                    string[] datoDB = {
                        objPagoOtro.CbteTPV.ToString().PadLeft(5, '0') + "-" + objPagoOtro.CbteNro.ToString().PadLeft(8, '0'),
                        objPagoOtro.Denominacion,
                        "",
                        Fecha.ConvertirFecha_Escrita(objPagoOtro.CbteFecha),
                        Formulario.ValidarCampoMoneda(objPagoOtro.MontoPagado),
                        Formulario.GenerarNumeroTextual(Formulario.ValidarCampoMoneda(objPagoOtro.MontoPagado)),
                        (objPagoOtro.Concepto).ToUpper(),
                        objPagoOtro.MedioPago + " " + ((objPagoOtro.MedioPago == "CHEQUE") ? "N°" + Convert.ToString(objPagoOtro.MedioNro).PadLeft(8, '0')  + " CON FECHA DE COBRO " + Fecha.ConvertirFecha(objPagoOtro.MedioChequeVto) + " (" + objPagoOtro.CuentaContableOrigen.Denominacion + ")"
                            : ((objPagoOtro.MedioPago == "TRANSFERENCIA") ? "N°" + Convert.ToString(objPagoOtro.MedioNro).PadLeft(8, '0')  + ctaBancariaDenominacion + ctaBancariaTipo + ctaBancariaNumero  : "")) };
                    Reporte reporte = new Reporte();
                    reporte.crearDocumentoWord_AcusePago(objPagoOtro.Denominacion, datoDB);
                    Cursor.Current = Cursors.Default;
                }
                else Mensaje.Advertencia("Operación incorrecta.\nLos comprobantes anulados No pueden ser exportados a Word.");
            }
            else Mensaje.Advertencia("Operación incorrecta.\nSeleccione un registro en la pantalla e intente nuevamente.");
        }
        #endregion

        #region Métodos
        private void asentarTransaccion(string operacion)
        {
            AsientoContable objAsientoContable = new AsientoContable();
            double montoPagado = Formulario.ValidarNumeroDoble(txtMontoPagado.Text);
            objAsientoContable.AsientoFecha = pkrCbteFecha.Value;
            objAsientoContable.Descripcion = "Otros Pagos: REC-X N°" + Convert.ToString(objPagoOtro.CbteTPV).PadLeft(5, '0') + "-" + Convert.ToString(objPagoOtro.CbteNro).PadLeft(8, '0');
            objAsientoContable.OrigenTipo = "PAO";
            objAsientoContable.OrigenId = objPagoOtro.Id;
            if (operacion == "REGISTRACION") objAsientoContable.AsientoNro = nAsientoContable.generarNumeroAsiento(); //Verifica que es un nuevo comprobante. Si es asi, genera un nuevo Número de Asiento
            else
            {
                AsientoContable objAsientoContablePrecedente = nAsientoContable.obtenerObjeto("PAO", objPagoOtro.Id); //Paso 1: En el caso de una modificación o anulación, obtiene el Asiento registrado precedentemente
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
                    new string[] { cmbCuentaContableOrigen.Text, cmbCuentaContableDestino.Text },
                    new double[] { montoPagado, montoPagado },
                    new string[] { "HABER", "DEBE" },
                    new string[] { "S/CONCILIAR", "NO-APLICA" } );
            }
            void crearAsientoContable(AsientoContable asiento, string[] cuentaContable, double[] monto, string[] deducirMonto, string[] conciliarMonto)
            {
                for (int i = 0; i < cuentaContable.Length; i++)
                {
                    if (monto[i] != 0.00)
                    {
                        asiento.CuentaContable = nCuentaContable.obtenerObjeto("DENOMINACION", cuentaContable[i], true);
                        asiento.Debe = (deducirMonto[i] == "DEBE") ? monto[i] : 0.00;
                        asiento.Haber = (deducirMonto[i] == "HABER") ? monto[i] : 0.00;
                        asiento.Conciliacion = conciliarMonto[i];
                        nAsientoContable.insertar(asiento); //Paso 1: Registra el Asiento Contable en la Base de Datos
                        nCuentaContable.actualizarSaldo(asiento.CuentaContable.Id, ((asiento.CuentaContable.Saldo + asiento.Debe) - asiento.Haber)); //Paso 2: Actualiza el saldo en la Cuenta Contable (El Debe suma en el Saldo y el Haber resta en el Saldo)
                    }
                }
            }
        }

        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(PagoOtro objRegistro)
        {
            this.objPagoOtro = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            if (objPagoOtro != null)
            {
                _controladorDeNuevoRegistro = false;
                DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
                txtCbteTPV.Text = Convert.ToString(objPagoOtro.CbteTPV).PadLeft(5, '0');
                txtCbteNro.Text = Convert.ToString(objPagoOtro.CbteNro).PadLeft(8, '0');
                pkrCbteFecha.Value = objPagoOtro.CbteFecha;
                txtEstado.Text = objPagoOtro.Estado;
                txtDenominacion.Text = objPagoOtro.Denominacion;
                cmbCentroCosto.Text = (objPagoOtro.CentroCosto != null) ? objPagoOtro.CentroCosto.Denominacion : "";
                cmbCuentaContableDestino.Text = (objPagoOtro.CuentaContableDestino != null) ? objPagoOtro.CuentaContableDestino.Denominacion : "";
                txtConcepto.Text = objPagoOtro.Concepto;
                txtMontoPagado.Text = Formulario.ValidarCampoMoneda(objPagoOtro.MontoPagado);
                cmbMedioPago.Text = objPagoOtro.MedioPago;
                cmbCuentaContableOrigen.Text = (objPagoOtro.CuentaContableOrigen != null) ? objPagoOtro.CuentaContableOrigen.Denominacion : "";
                txtMedioNro.Text = (objPagoOtro.MedioPago == "CHEQUE" || objPagoOtro.MedioPago == "TRANSFERENCIA") ? Convert.ToString(objPagoOtro.MedioNro).PadLeft(8, '0') : "";
                pkrMedioChequeVto.Value = ((objPagoOtro.MedioChequeVto != Fecha.ValidarFecha("01/01/9950")) ? objPagoOtro.MedioChequeVto : fechaActual);
                cmbCtaBancaria.Text = (objPagoOtro.Banco != null && objPagoOtro.Banco.Id > 0) ? objPagoOtro.Banco.Denominacion : "S/D";
                cmbCtaBancariaTipo.Text = (objPagoOtro.Banco != null) ? objPagoOtro.CtaBancariaTipo : "S/D";
                txtCtaBancariaNro.Text = (objPagoOtro.Banco != null) ? Convert.ToString(objPagoOtro.CtaBancariaNro).PadLeft(10, '0') : "";
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objPagoOtro.EdicionFecha) + " por " + objPagoOtro.EdicionUsuarioDenominacion;
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objPagoOtro = new PagoOtro(
                (objPagoOtro.Id <= 0) ? 0 : objPagoOtro.Id,
                Convert.ToInt32(Global.PtoVta),
                Formulario.ValidarNumeroEntero64(txtCbteNro.Text),
                pkrCbteFecha.Value,
                txtEstado.Text,
                txtDenominacion.Text,
                new N_CentroCosto().obtenerObjeto("DENOMINACION", cmbCentroCosto.Text),
                new N_CuentaContable().obtenerObjeto("DENOMINACION", cmbCuentaContableDestino.Text),
                txtConcepto.Text,
                Formulario.ValidarNumeroDoble(txtMontoPagado.Text),
                new N_CuentaContable().obtenerObjeto("DENOMINACION", cmbCuentaContableOrigen.Text),
                cmbMedioPago.Text,
                Formulario.ValidarNumeroEntero64(txtMedioNro.Text),
                pkrMedioChequeVto.Value,
                (cmbCtaBancaria.Text != "S/D" && (cmbMedioPago.Text == "CHEQUE" || cmbMedioPago.Text == "TRANSFERENCIA")) ? new N_Banco().obtenerObjeto("DENOMINACION", cmbCtaBancaria.Text, false) : new Banco(0, ""),
                (cmbMedioPago.Text == "TRANSFERENCIA") ? cmbCtaBancariaTipo.Text : "S/D",
                (cmbMedioPago.Text == "CHEQUE" || cmbMedioPago.Text == "TRANSFERENCIA") ? txtCtaBancariaNro.Text.PadLeft(10, '0') : "",
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objPagoOtro = new PagoOtro(); //Importante: Restaura el Objeto del Móludo
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(cmbCentroCosto, new N_CentroCosto().obtenerListaDeElementos(new string[] { }), 0); //Re-Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbCuentaContableDestino, new N_CuentaContable().obtenerListaDeElementos(new string[] { "PASIVO CORRIENTE > DEUDAS FISCALES", "PASIVO CORRIENTE > DEUDAS SOCIALES" }), "GASTOS OPERATIVOS"); //Re-Establece los items del ComboBox
                cmbCuentaContableDestino.Items.Remove("SUELDOS A PAGAR"); //Importante: Quita la cuenta "SUELDOS A PAGAR" por que No corresponde a Otros Pagos
            Formulario.ComboBox_CargarElementos(cmbCtaBancaria, new N_Banco().obtenerListaDeElementos(), "S/D"); //Re-Establece los items del ComboBox
            txtCbteTPV.Text = Global.PtoVta.ToString("00000");
            txtCbteNro.Text = "";
            pkrCbteFecha.Text = Fecha.SistemaFecha();
            txtEstado.Text = "ACTIVO";
            txtDenominacion.Text = "";
            txtConcepto.Text = "";
            txtMontoPagado.Text = "0,00";
            cmbMedioPago.Text = "EFECTIVO";
            cmbCuentaContableOrigen.Text = "CAJA CHICA";
            txtMedioNro.Text = "";
            pkrMedioChequeVto.Value = fechaActual;
            cmbCtaBancaria.Text = "S/D";
            cmbCtaBancariaTipo.Text = "S/D";
            txtCtaBancariaNro.Text = "";
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, cmbCentroCosto }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(PagoOtro objRegistro) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objPagoOtroDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            escribirControles(objPagoOtroDB); //Escribe los datos del registro seleccionado
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
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
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR N° PV - CBTE")
            {
                cmbFiltroLista1.Enabled = false;
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroEstado = "TODOS";
            if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ACTIVO") filtroEstado = "ACTIVO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ANULADO") filtroEstado = "ANULADO";
            if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la denominacón
            {
                consultaPagoOtro = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nPagoOtro.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA") //Verifica que el tipo de filtro es por fecha de emisión
            {
                consultaPagoOtro = new string[] { filtroEstado, "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nPagoOtro.obtenerCatalago(filtroEstado, "FECHA", pkrFiltroListaDesde.Value, pkrFiltroListaHasta.Value, "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR N° PV - CBTE" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por ID
            {
                consultaPagoOtro = new string[] { filtroEstado, "COMPROBANTE", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nPagoOtro.obtenerCatalago(filtroEstado, "COMPROBANTE", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objPagoOtroDB = nPagoOtro.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objPagoOtroDB); //Escribe los datos del registro seleccionado
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                lista = nPagoOtro.obtenerCatalago(consultaPagoOtro[0], consultaPagoOtro[1], consultaPagoOtro[2], "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "N° Comprobante",
                    "Fecha",
                    "Estado",
                    "Medio de Pago",
                    "Monto Pagado",
                    "Denominación" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //N° Comprobante (Comprobante)
                        campo[1].Trim(), //Fecha
                        campo[2].Trim(), //Estado
                        campo[3].Trim(), //Medio de Pago
                        "$" + campo[4].Trim(), //Monto Pagado
                        campo[5] }; //Denominación
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                string tituloPeriodo = (cmbFiltroLista2.Text == "FILTRAR POR PERIODO") ? " (periodo " + txtFiltroLista.Text + ")": "";
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Otros Pagos " + tituloPeriodo, subTitulos, new int[] { 8, 10, 10, 35, 12, 49 }, _listaDelReporte, new List<int> { 1 }, 77); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Otros Pagos " + tituloPeriodo, subTitulos, new float[] { 7, 9, 9, 30, 10, 39 }, _listaDelReporte); //Ancho: 111
            }
        }
        #endregion
    }
}
