using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormMovimientoFondo : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private string[] consultaMovimientoFondo;
        private MovimientoFondo objMovimientoFondo;
        private MovimientoFondo objMovimientoFondoDB;
        private N_MovimientoFondo nMovimientoFondo = new N_MovimientoFondo();
        private N_AsientoContable nAsientoContable = new N_AsientoContable();
        private N_CuentaContable nCuentaContable = new N_CuentaContable();
        #endregion

        #region Constructores
        public FormMovimientoFondo()
        {
            InitializeComponent();
        }
        public FormMovimientoFondo(MovimientoFondo navMovimientoFondo) //Utilizado por el navegador de formularios
        {
            objMovimientoFondoDB = objMovimientoFondo = navMovimientoFondo;
            InitializeComponent();
        }
        #endregion

        #region Eventos: Formulario
        private void FormMovimientoFondo_Load(object sender, EventArgs e)
        {
            #region ToolTips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(txtCbteTPV, "Punto de venta");
            toolTip.SetToolTip(txtCbteNro, "Número de comprobante");
            toolTip.SetToolTip(pkrCbteFecha, "Fecha de comprobante");
            toolTip.SetToolTip(txtEstado, "Estado del comprobante");
            #endregion
            Formulario.ComboBox_CargarElementos(cmbCuentaContableOrigen, new N_CuentaContable().obtenerListaDeElementos(new string[] { "ACTIVO CORRIENTE > DISPONIBILIDADES" }), 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbCuentaContableDestino, new N_CuentaContable().obtenerListaDeElementos(new string[] { "ACTIVO CORRIENTE > DISPONIBILIDADES" }), 0); //Establece los items del ComboBox
            cmbCuentaContableDestino.Items.Add("RETIRO DE SOCIO"); //Importante: Agrega la cuenta "RETIRO DE SOCIO" por que corresponde a Movimientos de Fondos
            cmbCuentaContableDestino.Items.Add("RETIRO DE OTROS SOCIOS"); //Importante: Agrega la cuenta "RETIRO DE OTROS SOCIOS" por que corresponde a Movimientos de Fondos
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO", "FILTRAR POR ESTADO: ANULADO", "TODOS LOS ESTADOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR DENOMINACION", "FILTRAR POR FECHA",
                "FILTRAR POR N° PV - CBTE" }, 0); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo      
            if (objMovimientoFondoDB != null) escribirControles(objMovimientoFondoDB); //Escribe los datos solicitados mediante la navegación entre formularios
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtMonto.Text); //Verifica que se está confeccionando un nuevo Cobro. Caso contrario, impide el ingreso de datos en el TextBox
        }

        private void cmbMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMedioPago.Text == "CHEQUE")
            {
                Formulario.ComboBox_CargarElementos(cmbCuentaContableOrigen, new N_CuentaContable().obtenerListaDeElementos(new string[] { "VALORES A DEPOSITAR" }), 0); //Establece los items del ComboBox
                lblMedioNro.Text = "Cheque(nro. - vto.)";
                pkrMedioChequeVto.Text = Fecha.SistemaFecha();
                Formulario.Visibilidad(true, new Control[] { lblMedioNro, txtMedioNro, pkrMedioChequeVto });
            }
            else if (cmbMedioPago.Text == "EFECTIVO")
            {
                Formulario.ComboBox_CargarElementos(cmbCuentaContableOrigen, new N_CuentaContable().obtenerListaDeElementos(new string[] { "DISPONIBILIDADES > CAJAS" }), 0); //Establece los items del ComboBox
                Formulario.Visibilidad(false, new Control[] { lblMedioNro, txtMedioNro, pkrMedioChequeVto });
            }
            else if (cmbMedioPago.Text == "T.CREDITO" || cmbMedioPago.Text == "T.DEBITO")
            {
                Formulario.ComboBox_CargarElementos(cmbCuentaContableOrigen, new N_CuentaContable().obtenerListaDeElementos(new string[] { "TARJETAS" }), 0); //Establece los items del ComboBox
                Formulario.Visibilidad(false, new Control[] { lblMedioNro, txtMedioNro, pkrMedioChequeVto });
            }
            else if (cmbMedioPago.Text == "TRANSFERENCIA")
            {
                Formulario.ComboBox_CargarElementos(cmbCuentaContableOrigen, new N_CuentaContable().obtenerListaDeElementos(new string[] { "DISPONIBILIDADES > BANCOS" }), 0); //Establece los items del ComboBox
                lblMedioNro.Text = "N° Transacción";
                Formulario.Visibilidad(false, new Control[] { pkrMedioChequeVto });
                Formulario.Visibilidad(true, new Control[] { lblMedioNro, txtMedioNro });
            }
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(153)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (objMovimientoFondo != null)
            {
                if (objMovimientoFondo.Id <= 0 && Global.UsuarioActivo_Privilegios.Contains(153)) //Verifica que el usuario posea el privilegio requerido
                {
                    //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                    if (_controladorDeNuevoRegistro && ValidarCampoVacio())
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            objMovimientoFondo.Id = nMovimientoFondo.generarNumeroID(); //Paso 2: Genera un ID para cada Objeto
                            objMovimientoFondo.CbteNro = objMovimientoFondo.Id; //Paso 3: Establece el valor del ID como número de comprobante
                            if (nMovimientoFondo.insertar(objMovimientoFondo)) //Paso 4: Inserta el objeto principal
                            {
                                asentarTransaccion("REGISTRACION"); //Paso 5: Registra el/los Asiento/s Contable/s
                                mostrarRegistro(objMovimientoFondo);
                                Mensaje.RegistroCorrecto("REGISTRACION");
                            }
                        }
                    }
                }
                else if (objMovimientoFondo.Id > 0 && Global.UsuarioActivo_Privilegios.Contains(155)) //Verifica que el usuario posea el privilegio requerido
                {
                    if (objMovimientoFondo.CbteFecha.AddDays(Global.RegistroModificacion) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        if (objMovimientoFondo.Estado == "ACTIVO") //Verifica si el comprobante esta activo
                        {
                            //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                            if (ValidarCampoVacio())
                            {
                                if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                                {
                                    instanciarObjeto(); //Paso 1: Instancia el Objeto
                                    if (!objMovimientoFondo.Equals(objMovimientoFondoDB)) //Paso 5: Verifica que el Objeto se ha modificado 
                                    {
                                        if (nMovimientoFondo.actualizar(objMovimientoFondo)) //Paso 6: Actualiza el Objeto y Detalle
                                        {
                                            asentarTransaccion("MODIFICACION"); //Paso 9: Registra el/los Asiento/s Contable/s
                                            mostrarRegistro(objMovimientoFondo);
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
                    return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacion, cmbCuentaContableOrigen,
                    cmbCuentaContableDestino  }) && Formulario.ValidarNumeroDoble(txtMonto.Text) > 0;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (objMovimientoFondo.Id > 0) escribirControles(nMovimientoFondo.obtenerObjeto("ID", objMovimientoFondo.Id.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
            else restaurarControles();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(154)) //Verifica que el usuario posea el privilegio requerido
            {
                if (objMovimientoFondo.Id > 0)
                {
                    if (objMovimientoFondo.CbteFecha.AddDays(Global.RegistroAnulacion) >= Fecha.DTSistemaFecha()) //Verifica que la fecha interna del comprobante No supere los 10 días de su creación 
                    {
                        if (Mensaje.ConfirmacionBoton1("¿Desea anular el registro ID: " + objMovimientoFondo.Id.ToString() + "?") == DialogResult.Yes)
                        {
                            instanciarObjeto(); //Paso 1: Instancia el Objeto
                            if (nMovimientoFondo.anular(objMovimientoFondo)) //Paso 3: Verifica el exito de la actualización y muestra los datos actualizados
                            {
                                objMovimientoFondo.Estado = "ANULADO"; //Paso 4: Importante: Establece el cambio de estado en el Objeto del Módulo 
                                asentarTransaccion("ANULACION"); //Paso 7: Registra el/los Asiento/s Contable/s         
                                mostrarRegistro(objMovimientoFondo);
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

        #region Métodos de Formulario
        private void asentarTransaccion(string operacion)
        {
            double montoBruto = Formulario.ValidarNumeroDoble(txtMonto.Text);
            AsientoContable objAsientoContable = new AsientoContable();
            objAsientoContable.AsientoFecha = pkrCbteFecha.Value;
            objAsientoContable.Conciliacion = (cmbCuentaContableDestino.Text == "RETIRO DE SOCIO" || cmbCuentaContableDestino.Text == "RETIRO DE OTROS SOCIOS") ? "NO-APLICA" : "S/CONCILIAR";
            objAsientoContable.OrigenTipo = "MOV";
            objAsientoContable.OrigenId = objMovimientoFondo.Id;
            if (operacion == "REGISTRACION") objAsientoContable.AsientoNro = nAsientoContable.generarNumeroAsiento(); //Verifica que es un nuevo comprobante. Si es asi, genera un nuevo Número de Asiento
            else
            {
                AsientoContable objAsientoContablePrecedente = nAsientoContable.obtenerObjeto("MOV", objMovimientoFondo.Id); //Paso 1: En el caso de una modificación o anulación, obtiene el Asiento registrado precedentemente
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
                    new string[] { "EGR-X", "ING-X"},
                    new string[] { cmbCuentaContableOrigen.Text, cmbCuentaContableDestino.Text },
                    new double[] { montoBruto, montoBruto },
                    new string[] { "HABER", "DEBE" },
                    new string[] { "S/CONCILIAR", (cmbCuentaContableDestino.Text == "RETIRO DE SOCIO" || cmbCuentaContableDestino.Text == "RETIRO DE OTROS SOCIOS") ? "NO-APLICA" : "S/CONCILIAR" });
            }
            void crearAsientoContable(AsientoContable asiento, string[] tipoMovimiento, string[] cuentaContable, double[] monto, string[] deducirMonto, string[] deducirConciliacion)
            {
                for (int i = 0; i < cuentaContable.Length; i++)
                {
                    if (monto[i] != 0.00)
                    {
                        asiento.Descripcion = "Movimiento: " + (tipoMovimiento[i]) + " N°" + Convert.ToString(objMovimientoFondo.CbteTPV).PadLeft(5, '0') + "-" + Convert.ToString(objMovimientoFondo.CbteNro).PadLeft(8, '0');
                        asiento.CuentaContable = nCuentaContable.obtenerObjeto("DENOMINACION", cuentaContable[i], true);
                        asiento.Debe = (deducirMonto[i] == "DEBE") ? monto[i] : 0.00;
                        asiento.Haber = (deducirMonto[i] == "HABER") ? monto[i] : 0.00;
                        asiento.Conciliacion = deducirConciliacion[i];
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

        private void escribirControles(MovimientoFondo objRegistro)
        {
            this.objMovimientoFondo = objRegistro; //Iguala el Atributo de la clase con el Objeto recibido
            if (objMovimientoFondo != null)
            {
                _controladorDeNuevoRegistro = false;
                objMovimientoFondo.Id = (objMovimientoFondo != null) ? objMovimientoFondo.Id : 0;
                txtCbteTPV.Text = Convert.ToString(objMovimientoFondo.CbteTPV).PadLeft(5, '0');
                txtCbteNro.Text = Convert.ToString(objMovimientoFondo.CbteNro).PadLeft(8, '0');
                pkrCbteFecha.Value = objMovimientoFondo.CbteFecha;
                txtEstado.Text = objMovimientoFondo.Estado;
                txtDenominacion.Text = Convert.ToString(objMovimientoFondo.Denominacion);
                txtMonto.Text = Formulario.ValidarCampoMoneda(Convert.ToString(objMovimientoFondo.Monto));
                cmbMedioPago.Text = objMovimientoFondo.MedioPago;
                cmbCuentaContableOrigen.Text = (objMovimientoFondo.CuentaContableOrigen != null) ? objMovimientoFondo.CuentaContableOrigen.Denominacion : "";
                cmbCuentaContableDestino.Text = (objMovimientoFondo.CuentaContableDestino != null) ? objMovimientoFondo.CuentaContableDestino.Denominacion : "";
                txtMedioNro.Text = (objMovimientoFondo.MedioPago == "CHEQUE" || objMovimientoFondo.MedioPago == "TRANSFERENCIA") ? Convert.ToString(objMovimientoFondo.MedioNro).PadLeft(8, '0') : "";
                pkrMedioChequeVto.Value = ((objMovimientoFondo.MedioChequeVto != Fecha.ValidarFecha("01/01/9950")) ? objMovimientoFondo.MedioChequeVto : Fecha.DTSistemaFecha());
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objMovimientoFondo.EdicionFecha) + " por " + objMovimientoFondo.EdicionUsuarioDenominacion;
            }
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objMovimientoFondo = new MovimientoFondo(
                (objMovimientoFondo.Id <= 0) ? 0 : objMovimientoFondo.Id,
                Convert.ToInt32(Global.PtoVta),
                Formulario.ValidarNumeroEntero64(txtCbteNro.Text),
                pkrCbteFecha.Value,
                txtEstado.Text,
                txtDenominacion.Text,
                Formulario.ValidarNumeroDoble(txtMonto.Text),
                new N_CuentaContable().obtenerObjeto("DENOMINACION", cmbCuentaContableOrigen.Text),
                new N_CuentaContable().obtenerObjeto("DENOMINACION", cmbCuentaContableDestino.Text),
                cmbMedioPago.Text,
                Formulario.ValidarNumeroEntero64(txtMedioNro.Text),
                pkrMedioChequeVto.Value,
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            objMovimientoFondo = new MovimientoFondo(); //Importante: Restaura el Objeto del Móludo
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            Formulario.ComboBox_CargarElementos(cmbCuentaContableOrigen, new N_CuentaContable().obtenerListaDeElementos(new string[] { "DISPONIBILIDADES" }), 0); //Re-Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbCuentaContableDestino, new N_CuentaContable().obtenerListaDeElementos(new string[] { "ACTIVO CORRIENTE > DISPONIBILIDADES" }), 0); //Re-Establece los items del ComboBox
            cmbCuentaContableDestino.Items.Add("RETIRO DE SOCIO"); //Importante: Agrega la cuenta "RETIRO DE SOCIO" por que corresponde a Movimientos de Fondos
            cmbCuentaContableDestino.Items.Add("RETIRO DE OTROS SOCIOS"); //Importante: Agrega la cuenta "RETIRO DE OTROS SOCIOS" por que corresponde a Movimientos de Fondos
            txtEstado.Text = "ACTIVO";
            txtCbteTPV.Text = Global.PtoVta.ToString("00000");
            txtCbteNro.Text = "";
            pkrCbteFecha.Text = Fecha.SistemaFecha();
            txtDenominacion.Text = "";
            txtMonto.Text = "0,00";
            cmbMedioPago.Text = "EFECTIVO";
            cmbCuentaContableOrigen.Text = "CAJA CHICA";
            cmbCuentaContableDestino.Text = "CAJA CHICA";
            txtMedioNro.Text = "";
            pkrMedioChequeVto.Value = fechaActual;
            labelPublicacion.Text = "";
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacion, cmbCuentaContableOrigen,
                cmbCuentaContableDestino }); //Restauración de campos invalidados
        }

        private void mostrarRegistro(MovimientoFondo objRegistro) //Método que muestra en la pantalla el registro insertado, modificado o anulado
        {
            filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
            lstCatalogo.SelectedValue = objRegistro.Id; //Posiona la selección de la fila en el registro guardado
            objMovimientoFondoDB = objRegistro; //Importante: Se deben igualar el Objeto precedente con el actual (evita el error de nulidad) 
            escribirControles(objMovimientoFondoDB); //Escribe los datos del registro seleccionado
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
            {
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR FECHA")
            {
                Formulario.Visibilidad(false, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(true, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta }); //Verifica que se ha seleccionado el filtrado por fecha y habilita las casillas "desde y hasta"
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR ID")
            {
                cmbFiltroLista1.Enabled = false;
                Formulario.Visibilidad(true, new Control[] { txtFiltroLista });
                Formulario.Visibilidad(false, new Control[] { pkrFiltroListaDesde, pkrFiltroListaHasta });
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
            if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por Denominación
            {
                consultaMovimientoFondo = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nMovimientoFondo.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR FECHA") //Verifica que el tipo de filtro es por Fecha de Comprobante
            {
                consultaMovimientoFondo = new string[] { filtroEstado, "FECHA", pkrFiltroListaDesde.Text, pkrFiltroListaHasta.Text };
                cargarCatalogo(nMovimientoFondo.obtenerCatalago(filtroEstado, "FECHA", Convert.ToDateTime(pkrFiltroListaDesde.Text), Convert.ToDateTime(pkrFiltroListaHasta.Text), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por ID
            {
                consultaMovimientoFondo = new string[] { filtroEstado, "ID", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nMovimientoFondo.obtenerCatalago(filtroEstado, "ID", txtFiltroLista.Text.Trim(), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR N° PV - CBTE" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por ID
            {
                consultaMovimientoFondo = new string[] { filtroEstado, "COMPROBANTE", txtFiltroLista.Text.Trim().PadLeft(12, '0') };
                cargarCatalogo(nMovimientoFondo.obtenerCatalago(filtroEstado, "COMPROBANTE", txtFiltroLista.Text.Trim().PadLeft(12, '0'), "CATALOGO1", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            objMovimientoFondoDB = nMovimientoFondo.obtenerObjeto("ID", idElemento.ToString(), true);
            escribirControles(objMovimientoFondoDB); //Escribe los datos del registro seleccionado
        }

        protected override void reportarLista(string programa)
        {
            if (lstCatalogo.Items.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                List<CatalogoBase> lista = new List<CatalogoBase>();
                if (consultaMovimientoFondo.Length == 3)
                    lista = nMovimientoFondo.obtenerCatalago(consultaMovimientoFondo[0], consultaMovimientoFondo[1], consultaMovimientoFondo[2], "CATALOGO2");
                else if (consultaMovimientoFondo.Length == 4)
                    lista = nMovimientoFondo.obtenerCatalago(consultaMovimientoFondo[0], consultaMovimientoFondo[1], Fecha.ValidarFecha(consultaMovimientoFondo[2]), Fecha.ValidarFecha(consultaMovimientoFondo[3]), "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "N° Comprobante",
                    "Fecha",
                    "Estado",
                    "Medio de Pago",
                    "Monto",
                    "Denominación",
                    "Cuenta Contable (origen)",
                    "Cuenta Contable (destino)" };
            foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                        campo[0].Trim(), //N° Comprobante (PtoVta y Comprobante)
                        campo[1].Trim(), //Fecha
                        campo[2].Trim(), //Estado
                        campo[3].Trim(), //Medio de Pago
                        "$" + campo[4].Trim(), //Monto
                        campo[5].Trim(), //Denominación
                        campo[6].Trim(), //Cta. Contable Origen
                        campo[7].Trim() }; //Cta. Contable Destino
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Movimientos de Fondos", subTitulos, new int[] { 14, 10, 8, 35, 10, 35, 25, 25 }, _listaDelReporte, new List<int> { 1 }, 82); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Movimientos de Fondos", subTitulos, new float[] { 12, 8, 6, 28, 8, 28, 20, 20 }, _listaDelReporte); //Ancho: 111
            }
        }
        #endregion
    }
}
