using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using Entidades;
using Entidades.Catalogo;

namespace CapaPresentacion
{
    public partial class FormArticulo : Biblioteca.Formularios.FormBaseABM_General
    {
        #region Atributos
        private double _valorArticulo_ControladorDeModificacion = 0.00;
        private long _idArticulo = 0;
        private Image _codigoBarraImagen;
        private PrintDocument _codigoBarraDocumento = new PrintDocument();
        private PrintPreviewDialog _codigoBarraPaginaVistaPrevia = new PrintPreviewDialog();
        private string[] consultaArticulo;
        private Articulo objArticulo;
        private N_Articulo nArticulo = new N_Articulo();
        #endregion

        #region Constructores
        public FormArticulo()
        {
            InitializeComponent();
        }
        public FormArticulo(Articulo navArticulo) //Utilizado por el navegador de formularios
        {
            InitializeComponent();
            escribirControles(navArticulo); //Escribe los datos solicitados mediante la navegación entre formularios
        }
        #endregion

        #region Eventos: Formulario
        private void FormArticulo_Load(object sender, EventArgs e)
        {
            Formulario.ComboBox_CargarElementos(cmbFiltroLista1, new string[] { "FILTRAR POR ESTADO: ACTIVO", "FILTRAR POR ESTADO: BAJA", "TODOS LOS ESTADOS" }, 0); //Establece los items del ComboBox
            Formulario.ComboBox_CargarElementos(cmbFiltroLista2, new string[] { "FILTRAR POR COD. BARRAS", "FILTRAR POR DENOMINACION", "FILTRAR POR ID" }, 1); //Establece los items del ComboBox
            filtrarCatalogo(0); //Carga el catálogo
        }

        private void FormArticulo_Shown(object sender, EventArgs e)
        {
            lstCatalogo.SelectedValue = _idArticulo; //Posiona la selección de la fila en el registro guardado
        }

        private void txtDenominacionArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            int longitud = txtDenominacionArticulo.Text.Length + txtDenominacionModelo.Text.Length + txtDenominacionMarca.Text.Length;
            if ((longitud > 32 && e.KeyChar != 8) || e.KeyChar == 59) e.Handled = true;
        }

        private void txtDenominacionModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            int longitud = txtDenominacionArticulo.Text.Length + txtDenominacionModelo.Text.Length + txtDenominacionMarca.Text.Length;
            if ((longitud > 32 && e.KeyChar != 8) || e.KeyChar == 59) e.Handled = true;
        }

        private void txtDenominacionMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            int longitud = txtDenominacionArticulo.Text.Length + txtDenominacionModelo.Text.Length + txtDenominacionMarca.Text.Length;
            if ((longitud > 32 && e.KeyChar != 8) || e.KeyChar == 59) e.Handled = true;
        }

        private void txtCodigoBarras_Validated(object sender, EventArgs e)
        {
            txtCodigoBarras.Text = (txtCodigoBarras.Text.Length != 0 && txtCodigoBarras.Text.Length > 6) ? txtCodigoBarras.Text : ""; //Importante: Los Códigos de Barras deben tener una longitud de 7 o más caractéres. Caso contrario, se debera sustituir por un código generado por el usuario o por el sistema
        }

        private void btnGenerarCodigo_Click(object sender, EventArgs e)
        {
            txtCodigoBarras.Text = (Convert.ToString(DateTime.Now.Second) + Convert.ToString(DateTime.Now.Minute) + Convert.ToString(new Random().Next(100000, 999999)) + Convert.ToString(DateTime.Now.Year) + Convert.ToString(DateTime.Now.Month) + Convert.ToString(DateTime.Now.Day) + Convert.ToString(new Random().Next(100000, 999999))).PadLeft(25, '0');
        }

        private void btnImprimirCodigo_Click(object sender, EventArgs e)
        {
            if (objArticulo != null && !string.IsNullOrWhiteSpace(objArticulo.CodigoBarras) && objArticulo.CodigoBarras == txtCodigoBarras.Text)
            {
                BarcodeLib.Barcode codigoBarra = new BarcodeLib.Barcode();
                codigoBarra.IncludeLabel = true;
                _codigoBarraImagen = codigoBarra.Encode(BarcodeLib.TYPE.CODE128, txtCodigoBarras.Text, Color.Black, Color.White, 250, 100);
                _codigoBarraDocumento.PrintPage -= new PrintPageEventHandler(codigoBarraDocumento_PrintPage);
                _codigoBarraDocumento.PrintPage += new PrintPageEventHandler(codigoBarraDocumento_PrintPage);
                _codigoBarraPaginaVistaPrevia.Name = "nombre sergio";
                _codigoBarraPaginaVistaPrevia.Document = _codigoBarraDocumento;
                _codigoBarraPaginaVistaPrevia.WindowState = FormWindowState.Maximized;
                _codigoBarraPaginaVistaPrevia.ShowDialog();
            }
        }

        private void codigoBarraDocumento_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(_codigoBarraImagen, new Point(40, 20));  //Imagen (C1 ,F1)
            e.Graphics.DrawImage(_codigoBarraImagen, new Point(40, 220)); //Imagen (C1 ,F2)
            e.Graphics.DrawImage(_codigoBarraImagen, new Point(40, 420)); //Imagen (C1 ,F3)
            e.Graphics.DrawImage(_codigoBarraImagen, new Point(40, 620)); //Imagen (C1 ,F4)
            e.Graphics.DrawImage(_codigoBarraImagen, new Point(40, 820)); //Imagen (C1 ,F5)
            e.Graphics.DrawImage(_codigoBarraImagen, new Point(350, 20));  //Imagen (C2 ,F1)
            e.Graphics.DrawImage(_codigoBarraImagen, new Point(350, 220)); //Imagen (C2 ,F2)
            e.Graphics.DrawImage(_codigoBarraImagen, new Point(350, 420)); //Imagen (C2 ,F3)
            e.Graphics.DrawImage(_codigoBarraImagen, new Point(350, 620)); //Imagen (C2 ,F4)
            e.Graphics.DrawImage(_codigoBarraImagen, new Point(350, 820)); //Imagen (C2 ,F5)
        }

        private void txtCostoBruto_Enter(object sender, EventArgs e)
        {
            _valorArticulo_ControladorDeModificacion = Formulario.ValidarNumeroDoble(txtCostoBruto.Text); //Almacena el valor al obtener el foco
        }

        private void txtCostoBruto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtCostoBruto.Text);
        }

        private void txtCostoBruto_Validated(object sender, EventArgs e)
        {
            if (Formulario.ValidarNumeroDoble(txtCostoBruto.Text) != _valorArticulo_ControladorDeModificacion) calcularCosto(); //Ejecuta el cálculo si el valor inicial difiere al valor ingresado
        }

        private void cmbAlicuotaIVA_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcularCosto();
        }

        private void txtUtilidad_Enter(object sender, EventArgs e)
        {
            _valorArticulo_ControladorDeModificacion = Formulario.ValidarNumeroDoble(txtUtilidad.Text); //Almacena el valor al obtener el foco
        }

        private void txtUtilidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtUtilidad.Text);
        }

        private void txtUtilidad_Validated(object sender, EventArgs e)
        {
            if (Formulario.ValidarNumeroDoble(txtUtilidad.Text) != _valorArticulo_ControladorDeModificacion) calcularVenta("UTILIDAD");  //Ejecuta el cálculo si el valor inicial difiere al valor ingresado
        }

        private void txtMargen_Enter(object sender, EventArgs e)
        {
            _valorArticulo_ControladorDeModificacion = Formulario.ValidarNumeroDoble(txtMargen.Text); //Almacena el valor al obtener el foco
        }

        private void txtMargen_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtMargen.Text);
        }

        private void txtMargen_Validated(object sender, EventArgs e)
        {
            if (Formulario.ValidarNumeroDoble(txtMargen.Text) != _valorArticulo_ControladorDeModificacion) calcularVenta("MARGEN"); //Ejecuta el cálculo si el valor inicial difiere al valor ingresado
        }

        private void txtPrecioBruto_Enter(object sender, EventArgs e)
        {
            _valorArticulo_ControladorDeModificacion = Formulario.ValidarNumeroDoble(txtPrecioBruto.Text); //Almacena el valor al obtener el foco
        }

        private void txtPrecioBruto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formulario.ValidarCampoMoneda(e, txtPrecioBruto.Text);
        }

        private void txtPrecioBruto_Validated(object sender, EventArgs e)
        {
            if (Formulario.ValidarNumeroDoble(txtPrecioBruto.Text) != _valorArticulo_ControladorDeModificacion) calcularVenta("PRECIO_BRUTO"); //Ejecuta el cálculo si el valor inicial difiere al valor ingresado
        }

        private void chkA1_PuntoCritico_CheckedChanged(object sender, EventArgs e)
        {
            txtA1_PuntoCritico.Text = (chkA1_PuntoCritico.Checked) ? txtA1_PuntoCritico.Text : "0";
            txtA1_PuntoCritico.ReadOnly = (chkA1_PuntoCritico.Checked) ? false : true;
        }

        private void chkA1_PuntoMinimo_CheckedChanged(object sender, EventArgs e)
        {
            txtA1_PuntoMinimo.Text = (chkA1_PuntoMinimo.Checked) ? txtA1_PuntoMinimo.Text : "0";
            txtA1_PuntoMinimo.ReadOnly = (chkA1_PuntoMinimo.Checked) ? false : true;
        }

        private void chkA2_PuntoCritico_CheckedChanged(object sender, EventArgs e)
        {
            txtA2_PuntoCritico.Text = (chkA2_PuntoCritico.Checked) ? txtA2_PuntoCritico.Text : "0";
            txtA2_PuntoCritico.ReadOnly = (chkA2_PuntoCritico.Checked) ? false : true;
        }

        private void chkA2_PuntoMinimo_CheckedChanged(object sender, EventArgs e)
        {
            txtA2_PuntoMinimo.Text = (chkA2_PuntoMinimo.Checked) ? txtA2_PuntoMinimo.Text : "0";
            txtA2_PuntoMinimo.ReadOnly = (chkA2_PuntoMinimo.Checked) ? false : true;
        }
        #endregion

        #region Eventos: Botones Inferiores
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(59)) //Verifica que el usuario posea el privilegio requerido
            {
                restaurarControles();
                _controladorDeNuevoRegistro = true;
                labelPublicacion.Text = "Usted está confeccionando un nuevo registro.";
            }
            else Mensaje.Restriccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_idArticulo <= 0 && Global.UsuarioActivo_Privilegios.Contains(59)) //Verifica que el usuario posea el privilegio requerido
            {
                //Insertar: Realiza esta operación cuando NO tiene asignado un numero de ID
                if (_controladorDeNuevoRegistro && ValidarCampoVacio() && ValidarPuntos())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los datos del nuevo registro?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        objArticulo.Id = nArticulo.generarNumeroID(); //Paso 2: Asigna un numero de ID al Objeto
                        if (nArticulo.insertar(objArticulo, true)) //Paso 3: Inserta el objeto
                        {
                            _idArticulo = objArticulo.Id; //Paso 4: Iguala la variable local con el ID asignado
                            mostrarDatos();
                        }
                    }
                }
            }
            else if (_idArticulo > 0 && Global.UsuarioActivo_Privilegios.Contains(60)) //Verifica que el usuario posea el privilegio requerido
            {
                //Actualizar: Realiza esta operación cuando SI tiene asignado un numero de ID
                if (ValidarCampoVacio() && ValidarPuntos())
                {
                    if (Mensaje.ConfirmacionBoton1("¿Desea guardar los cambios del registro de " + txtDenominacionArticulo.Text + " - " + txtDenominacionModelo.Text + " - " + txtDenominacionMarca.Text + "?") == DialogResult.Yes)
                    {
                        instanciarObjeto(); //Paso 1: Instancia el Objeto
                        nArticulo.actualizar(objArticulo, true);
                        mostrarDatos();
                    }
                }
            }
            else Mensaje.Restriccion();
            bool ValidarPuntos() // Método que valida los puntos de alerta (Crítico, mínimo y máximo)
            {
                if (chkA1_PuntoCritico.Checked && Formulario.ValidarNumeroEntero(txtA1_PuntoCritico.Text) >= Formulario.ValidarNumeroEntero(txtA1_PuntoMaximo.Text))
                {
                    Mensaje.Advertencia("Punto de Stock Incorrecto. En el almacén de EMPREMINSA,\nverifique que el punto crítico\nsea menor que el punto máximo e intente nuevamente.");
                    return false;
                }
                else if (chkA1_PuntoMinimo.Checked && (Formulario.ValidarNumeroEntero(txtA1_PuntoMinimo.Text) >= Formulario.ValidarNumeroEntero(txtA1_PuntoMaximo.Text) 
                    || Formulario.ValidarNumeroEntero(txtA1_PuntoMinimo.Text) <= Formulario.ValidarNumeroEntero(txtA1_PuntoCritico.Text)))
                {
                    Mensaje.Advertencia("Punto de Stock Incorrecto. En el almacén de EMPREMINSA,\nverifique que el punto mínimo\nsea menor que el punto máximo\ny mayor que el punto crítico e intente nuevamente.");
                    return false;
                }
                else if(chkA2_PuntoCritico.Checked && Formulario.ValidarNumeroEntero(txtA2_PuntoCritico.Text) >= Formulario.ValidarNumeroEntero(txtA2_PuntoMaximo.Text))
                {
                    Mensaje.Advertencia("Punto de Stock Incorrecto. En el almacén de VELADERO,\nverifique que el punto crítico\nsea menor que el punto máximo e intente nuevamente.");
                    return false;
                }
                else if(chkA2_PuntoMinimo.Checked && (Formulario.ValidarNumeroEntero(txtA2_PuntoMinimo.Text) >= Formulario.ValidarNumeroEntero(txtA2_PuntoMaximo.Text)
                    || Formulario.ValidarNumeroEntero(txtA2_PuntoMinimo.Text) <= Formulario.ValidarNumeroEntero(txtA2_PuntoCritico.Text)))
                {
                    Mensaje.Advertencia("Punto de Stock Incorrecto. En el almacén de VELADERO,\nverifique que el punto mínimo\nsea menor que el punto máximo\ny mayor que el punto crítico e intente nuevamente.");
                    return false;
                }
                return true; 
            }
            bool ValidarCampoVacio() // Método que valida los campos requeridos
            {
                return Formulario.ValidarCampoVacio(false, new Control[] { txtDenominacionArticulo, txtDenominacionModelo,
                txtDenominacionMarca, txtCostoBruto, cmbAlicuotaIVA });
            }
            void mostrarDatos() //Método que muestra en la pantalla los cambios generados
            {
                filtrarCatalogo(0); //Recarga el catálogo para reflejar la actualización
                lstCatalogo.SelectedValue = _idArticulo; //Posiona la selección de la fila en el registro guardado
                escribirControles(nArticulo.obtenerObjeto("TODOS", "ID", _idArticulo.ToString(), true)); //Importante: Por ultimo re-Escribe todos los controles para mayor seguridad                      }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idArticulo > 0) escribirControles(nArticulo.obtenerObjeto("TODOS", "ID", _idArticulo.ToString(), true)); //Re-Escribe los datos originales en base al registro seleccionado
            else restaurarControles();
        }
        #endregion

        #region Métodos
        private void calcularCosto()
        {
            double alicuotaIVA = Formulario.ValidarNumeroDoble(cmbAlicuotaIVA.Text.Replace(".", ",")); //Alícuota IVA
            double costoBruto = Formulario.ValidarNumeroDoble(txtCostoBruto.Text.Replace(".", ",")); //Costo Bruto
            double baseIVA = Math.Round((costoBruto / 100) * alicuotaIVA, 2);
            double costoNeto = Math.Round(costoBruto + baseIVA, 2);
            txtCostoBruto.Text = Formulario.ValidarCampoMoneda(costoBruto);
            txtBaseIVA.Text = Formulario.ValidarCampoMoneda(baseIVA);
            txtCostoNeto.Text = Formulario.ValidarCampoMoneda(costoNeto);
            calcularVenta("PRECIO_BRUTO"); //Re-Calcula los valores de Venta
        }

        private void calcularVenta(string operacion)
        {
            double costoBruto = Formulario.ValidarNumeroDoble(txtCostoBruto.Text); //Costo Bruto
            double utilidad = Formulario.ValidarNumeroDoble(txtUtilidad.Text); //Utilidad Porcentual
            double margen = Formulario.ValidarNumeroDoble(txtMargen.Text); //Margen
            double precioBruto = Formulario.ValidarNumeroDoble(txtPrecioBruto.Text); //Precio Bruto
            if (operacion == "UTILIDAD")
            {
                utilidad = (costoBruto > 0.00) ? Math.Round(utilidad, 4) : 100.0000;
                margen = (costoBruto > 0.00) ? Math.Round(((costoBruto / 100) * utilidad), 2) : margen;
                precioBruto = (costoBruto > 0.00) ? Math.Round((costoBruto + margen), 2) : precioBruto;
            }
            else if (operacion == "MARGEN")
            {
                utilidad = (costoBruto > 0.00) ? Math.Round((((100 / costoBruto) * margen)), 4) : 100.0000;
                precioBruto = (costoBruto > 0.00) ? Math.Round((costoBruto + margen), 2) : margen;
            }
            else if (operacion == "PRECIO_BRUTO")
            {
                utilidad = (costoBruto > 0.00) ? Math.Round((((100 / costoBruto) * precioBruto) - 100), 4) : 100.0000;
                margen = (costoBruto > 0.00) ? Math.Round((precioBruto - costoBruto), 2) : precioBruto;
            }
            txtUtilidad.Text = Formulario.ValidarCampoMoneda(utilidad);
            txtMargen.Text = Formulario.ValidarCampoMoneda(margen);
            txtPrecioBruto.Text = Formulario.ValidarCampoMoneda(precioBruto);
        }

        private void cargarCatalogo(List<CatalogoBase> listaDeCatalogo)
        {
            lstCatalogo.DataSource = listaDeCatalogo;
            lstCatalogo.ValueMember = "Id";
            lstCatalogo.DisplayMember = "Denominacion";
        }

        private void escribirControles(Articulo objArticulo)
        {
            this.objArticulo = objArticulo; //Obtiene los datos del objeto recibido
            if (objArticulo != null)
            {
                _controladorDeNuevoRegistro = false;
                _idArticulo = (objArticulo != null) ? objArticulo.Id : 0;
                txtDenominacionArticulo.Text = objArticulo.Denominacion.Split(';')[0].Trim();
                txtDenominacionModelo.Text = objArticulo.Denominacion.Split(';')[1].Trim();
                txtDenominacionMarca.Text = objArticulo.Denominacion.Split(';')[2].Trim();
                txtCodigoBarras.Text = objArticulo.CodigoBarras;
                cmbCriticidad.Text = objArticulo.Criticidad;
                cmbUnidad.Text = objArticulo.Unidad;
                txtStockGlobal.Text = Convert.ToString(objArticulo.StockGlobal);
                chkA1_PuntoCritico.Checked = objArticulo.A1_PuntoCritico;
                txtA1_PuntoCritico.Text = Convert.ToString(objArticulo.A1_PuntoCriticoLimite);
                chkA1_PuntoMinimo.Checked = objArticulo.A1_PuntoMinimo;
                txtA1_PuntoMinimo.Text = Convert.ToString(objArticulo.A1_PuntoMinimoLimite);
                txtA1_PuntoMaximo.Text = Convert.ToString(objArticulo.A1_PuntoMaximoLimite);
                txtA1_FechaIngreso.Text = objArticulo.A1_FechaIngreso.ToShortDateString();
                txtA1_Stock.Text = Convert.ToString(objArticulo.A1_Stock);
                chkA2_PuntoCritico.Checked = objArticulo.A2_PuntoCritico;
                txtA2_PuntoCritico.Text = Convert.ToString(objArticulo.A2_PuntoCriticoLimite);
                chkA2_PuntoMinimo.Checked = objArticulo.A2_PuntoMinimo;
                txtA2_PuntoMinimo.Text = Convert.ToString(objArticulo.A2_PuntoMinimoLimite);
                txtA2_PuntoMaximo.Text = Convert.ToString(objArticulo.A2_PuntoMaximoLimite);
                txtA2_FechaIngreso.Text = objArticulo.A2_FechaIngreso.ToShortDateString();
                txtA2_Stock.Text = Convert.ToString(objArticulo.A2_Stock);
                txtCostoBruto.Text = Formulario.ValidarCampoMoneda(objArticulo.CostoBruto);
                cmbAlicuotaIVA.Text = objArticulo.CostoAlicuotaIVA;
                txtBaseIVA.Text = Formulario.ValidarCampoMoneda(objArticulo.CostoBaseIVA);
                txtCostoNeto.Text = Formulario.ValidarCampoMoneda(objArticulo.CostoNeto);
                txtUtilidad.Text = Formulario.ValidarCampoMoneda(objArticulo.Utilidad);
                txtMargen.Text = Formulario.ValidarCampoMoneda(objArticulo.MargenBruto);
                txtPrecioBruto.Text = Formulario.ValidarCampoMoneda(objArticulo.PrecioBruto);
                cmbEstado.Text = objArticulo.Estado;
                labelPublicacion.Text = "Últimos cambios realizados el " + Fecha.ConvertirFechaHora(objArticulo.EdicionFecha) + " por " + objArticulo.EdicionUsuarioDenominacion;
            }
            else restaurarControles();
        }

        private void instanciarObjeto()
        {
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            this.objArticulo = new Articulo(
                (_idArticulo <= 0) ? 0 : _idArticulo,
                txtDenominacionArticulo.Text.ToUpper().Trim() + "; " + txtDenominacionModelo.Text.ToUpper().Trim() + "; " + txtDenominacionMarca.Text.ToUpper().Trim(),
                txtCodigoBarras.Text.Trim(),
                ((string.IsNullOrEmpty(cmbCriticidad.Text)) ? "MEDIA" : cmbCriticidad.Text), //Importante: Los ENUM en la BD nececitan recibir un dato conocido
                ((string.IsNullOrEmpty(cmbUnidad.Text)) ? "UNI" : cmbUnidad.Text), //Importante: Los ENUM en la BD nececitan recibir un dato conocido
                Formulario.ValidarNumeroEntero(txtStockGlobal.Text),
                Convert.ToBoolean(chkA1_PuntoCritico.Checked),
                Formulario.ValidarNumeroEntero(txtA1_PuntoCritico.Text),
                true, //Establece como alertado a Punto crítico A1
                Convert.ToBoolean(chkA1_PuntoMinimo.Checked),
                Formulario.ValidarNumeroEntero(txtA1_PuntoMinimo.Text),
                true, //Establece como alertado a Punto mínimo A1
                Formulario.ValidarNumeroEntero(txtA1_PuntoMaximo.Text),
                Fecha.ValidarFecha(txtA1_FechaIngreso.Text),
                Formulario.ValidarNumeroEntero(txtA1_Stock.Text),
                Convert.ToBoolean(chkA2_PuntoCritico.Checked),
                Formulario.ValidarNumeroEntero(txtA2_PuntoCritico.Text),
                true, //Etablece como alertado a Punto crítico A2
                Convert.ToBoolean(chkA2_PuntoMinimo.Checked),
                Formulario.ValidarNumeroEntero(txtA2_PuntoMinimo.Text),
                true, //Establece como alertado a Punto mínimo A2
                Formulario.ValidarNumeroEntero(txtA2_PuntoMaximo.Text),
                Fecha.ValidarFecha(txtA2_FechaIngreso.Text),
                Formulario.ValidarNumeroEntero(txtA2_Stock.Text),
                Formulario.ValidarNumeroDoble(txtCostoBruto.Text),
                ((string.IsNullOrEmpty(cmbAlicuotaIVA.Text)) ? "21.0" : cmbAlicuotaIVA.Text), //Importante: Los ENUM en la BD nececitan recibir un dato conocido
                Formulario.ValidarNumeroDoble(txtBaseIVA.Text),
                Formulario.ValidarNumeroDoble(txtCostoNeto.Text),
                Formulario.ValidarNumeroDoble(txtUtilidad.Text),
                Formulario.ValidarNumeroDoble(txtMargen.Text),
                Formulario.ValidarNumeroDoble(txtPrecioBruto.Text),
                ((string.IsNullOrEmpty(cmbEstado.Text)) ? "ACTIVO" : cmbEstado.Text), //Importante: Los ENUM en la BD nececitan recibir un dato conocido
                fechaActual,
                Global.UsuarioActivo_IdUsuario,
                Global.UsuarioActivo_Denominacion);
        }

        private void restaurarControles()
        {
            _controladorDeNuevoRegistro = false;
            DateTime fechaActual = Fecha.DTSistemaFecha(); //Importante: Almacena la respuesta del método de la fecha actual
            _idArticulo = 0; //Libera el Id del Objeto seleccionado
            txtDenominacionArticulo.Text = "";
            txtDenominacionModelo.Text = "";
            txtDenominacionMarca.Text = "";
            txtCodigoBarras.Text = "";
            cmbCriticidad.Text = "MEDIA";
            cmbUnidad.Text = "UNI";
            txtStockGlobal.Text = "0";
            chkA1_PuntoCritico.Checked = true;
            txtA1_PuntoCritico.Text = "0";
            chkA1_PuntoMinimo.Checked = true;
            txtA1_PuntoMinimo.Text = "0";
            txtA1_PuntoMaximo.Text = "0";
            txtA1_FechaIngreso.Text = fechaActual.ToShortDateString();
            txtA1_Stock.Text = "0";
            chkA2_PuntoCritico.Checked = false;
            txtA2_PuntoCritico.Text = "0";
            chkA2_PuntoMinimo.Checked = false;
            txtA2_PuntoMinimo.Text = "0";
            txtA2_PuntoMaximo.Text = "0";
            txtA2_FechaIngreso.Text = fechaActual.ToShortDateString();
            txtA2_Stock.Text = "0";
            txtCostoBruto.Text = "0.00";
            cmbAlicuotaIVA.Text = "21.0";
            txtBaseIVA.Text = "0,00";
            txtCostoNeto.Text = "0,00";
            txtUtilidad.Text = "0,00";
            txtMargen.Text = "0,0000";
            txtPrecioBruto.Text = "0,00";
            cmbEstado.Text = "ACTIVO";
            labelPublicacion.Text = "";            
            Formulario.ValidarCampoVacio(true, new Control[] { txtDenominacionArticulo, txtDenominacionModelo,
                txtDenominacionMarca, txtCostoBruto, cmbAlicuotaIVA }); //Restauración de campos invalidados
        }

        protected override void comboFiltro2()
        {
            if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR COD. BARRAS")
            {
                cmbFiltroLista1.Enabled = false;
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
                txtFiltroLista.MaxLength = 25;
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR DENOMINACION")
            {
                cmbFiltroLista1.Enabled = true;
                txtFiltroLista.MaxLength = 15;
            }
            else if (cmbFiltroLista2.SelectedItem.ToString() == "FILTRAR POR ID")
            {
                cmbFiltroLista1.Enabled = false;
                cmbFiltroLista1.Text = "TODOS LOS ESTADOS";
                txtFiltroLista.MaxLength = 6;
            }
            txtFiltroLista.Text = "";
            if (cmbFiltroLista2.Focused) filtrarCatalogo(0); //Recarga el gridLista para reflejar el filtrado
        }

        protected override void filtrarCatalogo(int indicePagina) //Método que filtra el catálogo en base a los filtros seleccionados
        {
            string filtroEstado = "TODOS";
            if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: ACTIVO") filtroEstado = "ACTIVO";
            else if (cmbFiltroLista1.Text == "FILTRAR POR ESTADO: BAJA") filtroEstado = "BAJA";
            if (cmbFiltroLista2.Text == "FILTRAR POR COD. BARRAS" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de documento
            {
                consultaArticulo = new string[] { filtroEstado, "CODIGO_BARRAS", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nArticulo.obtenerCatalago(filtroEstado, "CODIGO_BARRAS", txtFiltroLista.Text.Trim(), "CATALOGO2", indicePagina, Global.PaginacionTamanio));
                if (lstCatalogo.Items.Count > 0) escribirControles(nArticulo.obtenerObjeto("TODOS", "ID", Convert.ToString(lstCatalogo.SelectedValue), true)); //Escribe los datos del registro localizado por Código de Barras
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR DENOMINACION") //Verifica que el tipo de filtro es por concidencia letra en la descripcion
            {
                consultaArticulo = new string[] { filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nArticulo.obtenerCatalago(filtroEstado, "DENOMINACION", txtFiltroLista.Text.Trim(), "CATALOGO2", indicePagina, Global.PaginacionTamanio));
            }
            else if (cmbFiltroLista2.Text == "FILTRAR POR ID" && !string.IsNullOrEmpty(txtFiltroLista.Text)) //Verifica que el tipo de filtro es por el numero de documento
            {
                consultaArticulo = new string[] { filtroEstado, "ID", txtFiltroLista.Text.Trim() };
                cargarCatalogo(nArticulo.obtenerCatalago(filtroEstado, "ID", txtFiltroLista.Text.Trim(), "CATALOGO2", indicePagina, Global.PaginacionTamanio));
            }
            base.asignarPaginacion(indicePagina);
        }

        protected override void mostrarElemento(long idElemento)
        {
            escribirControles(nArticulo.obtenerObjeto("TODOS", "ID", idElemento.ToString(), true)); //Escribe los datos del registro seleccionado
        }

        protected override void reportarRegistro(string programa)
        {
            if (_idArticulo > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                string[] subTitulo = {
                    "N° Artículo: ",
                    "Denominación: ",
                    "Código de barras: ",
                    "Criticidad: ",
                    "Unidad de medida: ",
                    "Stock global: ",
                    "Costo bruto: ",
                    "Alícuota IVA: ",
                    "Base IVA: ",
                    "Costo neto: ",
                    "",
                    "Punto crítico: ",
                    "Punto mínimo: ",
                    "Punto máximo: ",
                    "Fecha de ingreso: ",
                    "Stock: ",
                    "",
                    "Punto crítico: ",
                    "Punto mínimo: ",
                    "Punto máximo: ",
                    "Fecha de ingreso: ",
                    "Stock: ",
                    "Estado: " };
                string[] datoDB = {
                    objArticulo.Id.ToString().PadLeft(8, '0'),
                    objArticulo.Denominacion,
                    objArticulo.CodigoBarras,
                    objArticulo.Criticidad,
                    objArticulo.Unidad,
                    Convert.ToString(objArticulo.StockGlobal),
                    "$" + Formulario.ValidarCampoMoneda(objArticulo.CostoBruto),
                    "%" + Formulario.ValidarCampoMoneda(objArticulo.CostoAlicuotaIVA),
                    "$" + Formulario.ValidarCampoMoneda(objArticulo.CostoBaseIVA),
                    "$" + Formulario.ValidarCampoMoneda(objArticulo.CostoNeto),
                    "===== ALMACEN EMPREMINSA =====",
                    (objArticulo.A1_PuntoCritico) ? Convert.ToString(objArticulo.A1_PuntoCriticoLimite) : "",
                    (objArticulo.A1_PuntoMinimo) ? Convert.ToString(objArticulo.A1_PuntoMinimoLimite) : "",
                    Convert.ToString(objArticulo.A1_PuntoMaximoLimite),
                    Fecha.ConvertirFecha(objArticulo.A1_FechaIngreso),
                    Convert.ToString(objArticulo.A1_Stock),
                    "===== ALMACEN VELADERO =====",
                    (objArticulo.A2_PuntoCritico) ? Convert.ToString(objArticulo.A2_PuntoCriticoLimite) : "",
                    (objArticulo.A2_PuntoMinimo) ? Convert.ToString(objArticulo.A2_PuntoMinimoLimite) : "",
                    Convert.ToString(objArticulo.A2_PuntoMaximoLimite),
                    Fecha.ConvertirFecha(objArticulo.A2_FechaIngreso),
                    Convert.ToString(objArticulo.A2_Stock),
                    objArticulo.Estado };
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Registro("Artículo", subTitulo, datoDB);
                if (programa == "PDF") reporte.crearDocumentoPDF_Registro("Artículo", subTitulo, datoDB);
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
                lista = nArticulo.obtenerCatalago(consultaArticulo[0], consultaArticulo[1], consultaArticulo[2], "CATALOGO2");
                List<string[]> _listaDelReporte = new List<string[]>();
                string[] subTitulos = {
                    "ID",
                    "Denominación",
                    "Stk. Emp.",
                    "F. Ingreso Emp.",
                    "Stk. Vel.",
                    "F. Ingreso Vel.",
                    "Stk. Global",
                    "Estado" };
                foreach (CatalogoBase item in lista)
                {
                    string fila = item.Denominacion.Replace(" | ", "|");
                    string[] campo = fila.Split('|');
                    string[] lineaDB = {
                    campo[0].Trim(), //ID
                    campo[1].Trim(), //Denominación
                    campo[2].Trim(), //Stk. Emp.
                    campo[3].Trim(), //F. Ingreso Emp.
                    campo[4].Trim(), //Stk. Vel.
                    campo[5].Trim(), //F. Ingreso Vel.
                    campo[6].Trim(), //Stk. Global
                    campo[7].Trim() //Estado
                };
                    _listaDelReporte.Add(lineaDB);
                }
                Cursor.Current = Cursors.Default;
                Reporte reporte = new Reporte();
                if (programa == "EXCEL") reporte.crearDocumentoExcel_Lista("Artículos", subTitulos, new int[] { 6, 60, 10, 13, 10, 13, 10, 7 }, _listaDelReporte, new List<int> { 3, 5 }); //Ancho: 129
                if (programa == "PDF") reporte.crearDocumentoPDF_Lista("Artículos", subTitulos, new float[] { 6, 50, 9, 11, 9, 11, 9, 6 }, _listaDelReporte); //Ancho: 111
            }
        }
        #endregion
    }
}