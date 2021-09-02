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
    public partial class FormPagoNomina : Biblioteca.Formularios.FormBaseABM_RRHH
    {
        #region Atributos
        private bool _nuevoRegitroDesdeNavegacion = false;
        private string[] consultaPagoNomina;
        private Legajo objLegajo; //Objeto Maestro
        private LegajoLaboral objLegajoLaboral;
        private PagoNomina objPagoNomina;
        private PagoNomina objPagoNominaDB;
        private N_Legajo nLegajo = new N_Legajo();
        private N_LegajoLaboral nLegajoLaboral = new N_LegajoLaboral();
        private N_PagoNomina nPagoNomina = new N_PagoNomina();
        private N_AsientoContable nAsientoContable = new N_AsientoContable();
        private N_CuentaContable nCuentaContable = new N_CuentaContable();
        #endregion

        #region Constructores
        public FormPagoNomina()
        {
            InitializeComponent();
        }
        public FormPagoNomina(Legajo navLegajo, bool nuevoRegitroDesdeNavegacion = false) //Utilizado por el navegador de formularios
        {
            objLegajo = navLegajo;
            _nuevoRegitroDesdeNavegacion = nuevoRegitroDesdeNavegacion;
            InitializeComponent();
        }
        public FormPagoNomina(PagoNomina navPagoNomina) //Utilizado por el navegador de formularios
        {
            objPagoNominaDB = objPagoNomina = navPagoNomina;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormPagoNomina_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(txtCbteTPV, "Punto de compra");
            toolTip.SetToolTip(txtCbteNro, "Número de comprobante");
            toolTip.SetToolTip(pkrCbteFecha, "Fecha de comprobante");
            toolTip.SetToolTip(txtEstado, "Estado del comprobante");
            toolTip.SetToolTip(btnWord_Acuse, "Genera y exporta el acuse de recibo de cobro a Word");
            #endregion
            Formulario.ComboBox_CargarElementos(cmbCtaBancaria, new N_Banco().obtenerListaDeElementos(), "S/D"); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO",
                "FILTRAR POR ESTADO: ANULADO", "TODOS LOS ESTADOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR CUIT",
                "FILTRAR POR DENOMINACION", "FILTRAR POR FECHA", "FILTRAR POR N° PV - CBTE" }, 1); //Establece los items del ComboBox 
            filtrarCatalogo(0); //Carga el catálogo
            if (objLegajo != null) instanciarDesdeNavegacion(objLegajo);
            if (objPagoNominaDB != null && !_controladorDeNuevoRegistro) escribirControles(objPagoNominaDB); //Escribe los datos solicitados mediante la navegación entre formularios
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
            if (Global.UsuarioActivo_Privilegios.Contains(161))
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objPagoNomina != null)
            {
                if (objPagoNomina.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(161)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)) != null) //Verifica que la persona tenga un Legajo Laboral
                    {
                        if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                        {
                            if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                            {
                                instanciarObjeto(); //Paso 1: Instancia el Objeto
                                this.objLegajo = nLegajo.obtenerObjeto("ID", objPagoNomina.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                                objPagoNomina.Id = nPagoNomina.generarNumeroID(); //Paso 3: Genera un ID para cada Objeto
                                objPagoNomina.CbteNro = objPagoNomina.Id; //Paso 4: Establece el valor del ID como número de comprobante
                                if (nPagoNomina.insertar(objPagoNomina)) //Paso 5: Inserta el objeto principal
                                {
                                    calcularCtaCte("REGISTRACION"); //Paso 6: Actualiza la Cta.Cte. del Legajo Personal
                                    asentarTransaccion("REGISTRACION"); //Paso 7: Registra el/los Asiento/s Contable/s
                                    mostrarRegistro(objPagoNomina);
                                    Mensaje.RegistroCorrecto("REGISTRACION");
                                }
                            }
                        }
                    }
                    else Mensaje.Advertencia("Operación incorrecta.\nLa persona No posee un legajo laboral.\nVerifique los datos e intente nuevamente.");
                }
                else if (objPagoNomina.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(163)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                    if (objPagoNomina.CbteFecha.AddDays(Global.RegistroModificacion) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        if (objPagoNomina.Estado == "ACTIVO") //Verifica si el comprobante esta activo
                        {
                            {
                                if (ValidarCampoVacio())
                                {
                                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacion.Text + "?") == DialogResult.Yes)
                                    {
                                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                                        this.objLegajo = nLegajo.obtenerObjeto("ID", objPagoNomina.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                                        if (!objPagoNomina.Equals(objPagoNominaDB)) //Paso 3: Verifica que el Objeto se ha modificado 
                                        {
                                            if (nPagoNomina.actualizar(objPagoNomina)) //Paso 4: Actualiza el Objeto y Detalle
                                            {
                                                calcularCtaCte("MODIFICACION"); //Paso 5: Actualiza la Cta.Cte. del Cliente Personal
                                                asentarTransaccion("MODIFICACION"); //Paso 6: Registra el/los Asiento/s Contable/s
                                                mostrarRegistro(objPagoNomina);
                                                Mensaje.RegistroCorrecto("MODIFICACION");
                                            }
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
                    return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion, txtCuit, txtCentroCosto })
                        && Formulario.ValidarCampoVacioNumerico(false, new Control[] { txtMontoPagado });
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objPagoNomina.Id > 0) escribirControles(objPagoNominaDB); //Restaura los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(162)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objPagoNomina.Id > 0)
                {
                    if (objPagoNomina.CbteFecha.AddDays(Global.RegistroAnulacion) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea anular el registro ID: " + objPagoNomina.Id.ToString() + "?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            objLegajo = nLegajo.obtenerObjeto("ID", objPagoNomina.Legajo.Id.ToString(), false); //Paso 2: Importante: Re-Almacena el Objeto de la Base de Datos
                            if (nPagoNomina.anular(objPagoNomina)) //Paso 3: Verifica el exito de la actualización y muestra los datos actualizados
                            {
                                objPagoNomina.Estado = "ANULADO"; //Paso 4: Importante: Establece el cambio de estado en el Objeto del Módulo 
                                calcularCtaCte("ANULACION"); //Paso 6: Actualiza la Cta.Cte. del Cliente Personal
                                asentarTransaccion("ANULACION"); //Paso 7: Registra el/los Asiento/s Contable/s         
                                mostrarRegistro(objPagoNomina);
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
            if (objPagoNomina.Id > 0)
            {
                if (objPagoNomina.Estado == "ACTIVO") //Verifica si el comprobante esta activo
                {
                    Cursor.Current = Cursors.WaitCursor;
                    string ctaBancariaDenominacion = (objPagoNomina.Banco != null) ? " - " + objPagoNomina.Banco.Denominacion : "";
                    string ctaBancariaTipo = (objPagoNomina.Banco != null && objPagoNomina.CtaBancariaTipo != "S/D") ? " " + objPagoNomina.CtaBancariaTipo : "";
                    string ctaBancariaNumero = (objPagoNomina.Banco != null && !string.IsNullOrEmpty(objPagoNomina.CtaBancariaNro.Trim())) ? " N°" + objPagoNomina.CtaBancariaNro.PadLeft(10, '0') : "";
                    string[] datoDB = {
                        objPagoNomina.CbteTPV.ToString().PadLeft(5, '0') + "-" + objPagoNomina.CbteNro.ToString().PadLeft(8, '0'),
                        objPagoNomina.Legajo.Denominacion,
                        objPagoNomina.Legajo.Cuit.ToString("00-00000000/0"),
                        Fecha.ConvertirFecha_Escrita(objPagoNomina.CbteFecha),
                        Formulario.ValidarCampoMoneda(objPagoNomina.MontoPagado),
                        Formulario.GenerarNumeroTextual(Formulario.ValidarCampoMoneda(objPagoNomina.MontoPagado)),
                        (objPagoNomina.Concepto).ToUpper(),
                        objPagoNomina.MedioPago + " " + ((objPagoNomina.MedioPago == "CHEQUE") ? "N°" + Convert.ToString(objPagoNomina.MedioNro).PadLeft(8, '0')  + " CON FECHA DE COBRO " + Fecha.ConvertirFecha(objPagoNomina.MedioChequeVto) + " (" + objPagoNomina.CuentaContableOrigen.Denominacion + ")"
                               : ((objPagoNomina.MedioPago == "TRANSFERENCIA") ? "N°" + Convert.ToString(objPagoNomina.MedioNro).PadLeft(8, '0')  + ctaBancariaDenominacion + ctaBancariaTipo + ctaBancariaNumero  : "")) };
                    Reporte reporte = new Reporte();
                    reporte.crearDocumentoWord_AcusePago(objPagoNomina.Legajo.Denominacion, datoDB);
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
            objAsientoContable.Descripcion = "Pago Nómina: REC-X N°" + Convert.ToString(objPagoNomina.CbteTPV).PadLeft(5, '0') + "-" + Convert.ToString(objPagoNomina.CbteNro).PadLeft(8, '0');
            objAsientoContable.OrigenTipo = "PAN";
            objAsientoContable.OrigenId = objPagoNomina.Id;
            if (operacion == "REGISTRACION") objAsientoContable.AsientoNro = nAsientoContable.generarNumeroAsiento(); //Verifica que es un nuevo comprobante. Si es asi, genera un nuevo Número de Asiento
            else
            {
                AsientoContable objAsientoContablePrecedente = nAsientoContable.obtenerObjeto("PAN", objPagoNomina.Id); //Paso 1: En el caso de una modificación o anulación, obtiene el Asiento registrado precedentemente
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

        private void calcularCtaCte(string operacion)
        {
            double montoPagado = Formulario.ValidarNumeroDoble(txtMontoPagado.Text);
            double saldo = objLegajo.Saldo;
            if (operacion == "REGISTRACION") saldo = (saldo - montoPagado); //Resta el monto pagado al saldo de la Cta.Cte. del Legajo Personal
            else if (operacion == "MODIFICACION") saldo = ((saldo + objPagoNominaDB.MontoPagado) - montoPagado); //Suma el monto pagado precedentemente al saldo de la Cta.Cte. del Legajo Personal
            else if (operacion == "ANULACION") saldo = (saldo + objPagoNominaDB.MontoPagado); //Suma el monto pagado precedentemente del saldo la Cta.Cte. del Legajo Personal
            nLegajo.actualizarSaldo(objLegajo.Id, saldo, false); //Actualiza el saldo en la Cta.Cte. del Legajo Personal 
            this.objLegajo.Saldo = saldo; //Importante: Actualiza el saldo del Objeto Maestro
        }

        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(PagoNomina objRegistro)
        {
            this.objPagoNomina = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            if (objPagoNomina != null && objPagoNomina.Legajo != null)
            {
                if (!objPagoNomina.Legajo.InformacionRestringida || (objPagoNomina.Legajo.InformacionRestringida && Global.UsuarioActivo_Privilegios.Contains(1))) //Verifica que el usuario posea el privilegio requerido
                {
                    _controladorDeNuevoRegistro = false;
                    DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
                    txtCbteTPV.Text = Convert.ToString(objPagoNomina.CbteTPV).PadLeft(5, '0');
                    txtCbteNro.Text = Convert.ToString(objPagoNomina.CbteNro).PadLeft(8, '0');
                    pkrCbteFecha.Value = objPagoNomina.CbteFecha;
                    txtEstado.Text = objPagoNomina.Estado;
                    objLegajo = objPagoNomina.Legajo;
                    objLegajoLaboral = new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id));
                    txtDenominacion.Text = objPagoNomina.Legajo.Denominacion;
                    txtCuit.Text = Convert.ToString(objPagoNomina.Legajo.Cuit);
                    txtCentroCosto.Text = (objPagoNomina.CentroCosto != null) ? objPagoNomina.CentroCosto.Denominacion : "";
                    cmbCuentaContableDestino.Text = (objPagoNomina.CuentaContableDestino != null) ? objPagoNomina.CuentaContableDestino.Denominacion : "";
                    txtConcepto.Text = objPagoNomina.Concepto;
                    txtMontoPagado.Text = Formulario.ValidarCampoMoneda(objPagoNomina.MontoPagado);
                    cmbMedioPago.Text = objPagoNomina.MedioPago;
                    cmbCuentaContableOrigen.Text = (objPagoNomina.CuentaContableOrigen != null) ? objPagoNomina.CuentaContableOrigen.Denominacion : "";
                    txtMedioNro.Text = (objPagoNomina.MedioPago == "CHEQUE" || objPagoNomina.MedioPago == "TRANSFERENCIA") ? Convert.ToString(objPagoNomina.MedioNro).PadLeft(8, '0') : "";
                    pkrMedioChequeVto.Value = ((objPagoNomina.MedioChequeVto != Fecha.ValidarFecha("01/01/9950")) ? objPagoNomina.MedioChequeVto : fechaActual);
                    cmbCtaBancaria.Text = (objPagoNomina.Banco != null && objPagoNomina.Banco.Id > 0) ? objPagoNomina.Banco.Denominacion : "S/D";
                    cmbCtaBancariaTipo.Text = (objPagoNomina.Banco != null) ? objPagoNomina.CtaBancariaTipo : "S/D";
                    txtCtaBancariaNro.Text = (objPagoNomina.Banco != null) ? Convert.ToString(objPagoNomina.CtaBancariaNro).PadLeft(10, '0') : "";
                    labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objPagoNomina.EdicionFecha) + " por " + objPagoNomina.EdicionUsuarioDenominacion;
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
                txtMontoPagado.Text = (objLegajo.Saldo > 0) ? Formulario.ValidarCampoMoneda(objLegajo.Saldo) : "0,00";
                this.objLegajoLaboral = new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id));
                txtCentroCosto.Text = (objLegajoLaboral != null && objLegajoLaboral.CentroCosto != null) ? objLegajoLaboral.CentroCosto.Denominacion : "";
            }
            else
            {
                objPagoNominaDB = nPagoNomina.obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id)); //Paso 1: Busca el registro en la Base de Datos en relación al objeto maestro recibido 
                if (objPagoNominaDB != null)
                {
                    lstCatalogo.SelectedValue = objPagoNominaDB.Id; //Paso 2: Posiona la selección de la fila en el registro guardado
                    escribirControles(objPagoNominaDB); //Paso 3: Escribe los datos del registro indicado
                }
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objPagoNomina = new PagoNomina(
                (objPagoNomina.Id <= 0) ? 0 : objPagoNomina.Id,
                Convert.ToInt32(Global.PtoVta),
                Formulario.ValidarNumeroEntero64(txtCbteNro.Text),
                pkrCbteFecha.Value,
                txtEstado.Text,
                objLegajo,
                new N_CentroCosto().obtenerObjeto("DENOMINACION", txtCentroCosto.Text),
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
            objLegajo = new Legajo(); //Restaura el Objeto Primario
            objLegajoLaboral = new LegajoLaboral(); //Restaura el Objeto SubPrimario
            objPagoNomina = new PagoNomina(); //Importante: Restaura el Objeto del Móludo
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(cmbCtaBancaria, new N_Banco().obtenerListaDeElementos(), "S/D"); //Re-Establece los items del ComboBox
            txtCbteTPV.Text = Global.PtoVta.ToString("00000");
            txtCbteNro.Text = "";
            pkrCbteFecha.Text = Fecha.SistemaFecha();
            txtEstado.Text = "ACTIVO";
            txtDenominacion.Text = "";
            txtCuit.Text = "";
            txtCentroCosto.Text = "";
            cmbCuentaContableDestino.Text = "SUELDOS A PAGAR";
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
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, txtCuit, txtCentroCosto }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(PagoNomina objRegistro) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objPagoNominaDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            escribirControles(objPagoNominaDB); //Escribe los datos del registro seleccionado
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
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
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
            if (cmbFiltroLista2.Text == "FILTRAR POR CUIT" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de CUIL/CUIT
            {
                consultaPagoNomina = new string[] { filtroEstado, "CUIT", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nPagoNomina.obtenerCatalago(filtroEstado, "CUIT", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la denominacón
            {
                consultaPagoNomina = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nPagoNomina.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA") //Verifica que el tipo de filtro es por fecha de emisión
            {
                consultaPagoNomina = new string[] { filtroEstado, "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nPagoNomina.obtenerCatalago(filtroEstado, "FECHA", pkrFiltroListaDesde.Value, pkrFiltroListaHasta.Value, "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR N° PV - CBTE" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por ID
            {
                consultaPagoNomina = new string[] { filtroEstado, "COMPROBANTE", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nPagoNomina.obtenerCatalago(filtroEstado, "COMPROBANTE", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objPagoNominaDB = nPagoNomina.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objPagoNominaDB); //Escribe los datos del registro seleccionado
        }

        protected override void navegarA_Formulario(string destino) { NavegacionRRHH.navegarA_Formulario(destino, this, objLegajo); }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                lista = nPagoNomina.obtenerCatalago(consultaPagoNomina[0], consultaPagoNomina[1], consultaPagoNomina[2], "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "N° Comprobante",
                    "Fecha",
                    "Estado",
                    "Medio de Pago",
                    "Monto Pagado",
                    "Denominación - CUIL/CUIT" };
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
                        campo[5] }; //Denominación - CUIL/CUIT
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                string tituloPeriodo = (cmbFiltroLista2.Text == "FILTRAR POR PERIODO") ? " (periodo " + txtFiltroLista.Text + ")": "";
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Pagos a Nómina " + tituloPeriodo, subTitulos, new int[] { 8, 10, 10, 35, 12, 49 }, _listaDelReporte, new List<int> { 1 }, 77); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Pagos a Nómina " + tituloPeriodo, subTitulos, new float[] { 7, 9, 9, 30, 10, 39 }, _listaDelReporte); //Ancho: 111
            }
        }

        public override void asignarVariablesDeFormulario(string[] variablesDeFormulario)
        {
            if (variablesDeFormulario[0] == "Catalogo_Legajo") //Catálogo de Legajos
            {
                this.objLegajo = new N_Legajo().obtenerObjeto("ID", variablesDeFormulario[1], true);
                txtDenominacion.Text = objLegajo.Denominacion;
                txtCuit.Text = Convert.ToString(objLegajo.Cuit);
                txtMontoPagado.Text = (objLegajo.Saldo > 0) ? Formulario.ValidarCampoMoneda(objLegajo.Saldo) : "0,00";
                cmbCtaBancaria.Text = (!string.IsNullOrWhiteSpace(objLegajo.CtaBancariaNro)) ? objLegajo.Banco.Denominacion : "S/D";
                cmbCtaBancariaTipo.Text = (!string.IsNullOrWhiteSpace(objLegajo.CtaBancariaNro)) ? objLegajo.CtaBancariaTipo : "";
                txtCtaBancariaNro.Text = (!string.IsNullOrWhiteSpace(objLegajo.CtaBancariaNro)) ? objLegajo.CtaBancariaNro : "";
                this.objLegajoLaboral = new N_LegajoLaboral().obtenerObjeto("ID_LEGAJO", Convert.ToString(objLegajo.Id));
                txtCentroCosto.Text = (objLegajoLaboral != null && objLegajoLaboral.CentroCosto != null) ? objLegajoLaboral.CentroCosto.Denominacion : "";
            }
        }
        #endregion
    }
}
