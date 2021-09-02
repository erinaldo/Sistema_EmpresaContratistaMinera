using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Biblioteca.Ayudantes;
using CapaNegocio;
using CapaNegocio.Sistema;
using CapaPresentacion.Modales;
using Entidades;
using Entidades.Sistema;

namespace CapaPresentacion
{
    public partial class FormPrincipal : Form
    {
        #region Atributos
        private Timer temporizador = new Timer();
        #endregion

        public FormPrincipal()
        {
            InitializeComponent();
        }

        #region Eventos
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            #region temporizador de Notificaciones
            temporizador.Enabled = true;
            temporizador.Interval = 14400000; //Se ejecuta cada 4 horas
            temporizador.Start();
            temporizador.Tick += new EventHandler(temporizador_Tick);
            #endregion
        }

        private void FormPrincipal_Shown(object sender, EventArgs e)
        {
            abrirFormularioModalNotificacion(); //Abre el formulario de notificaciones al acceder al sistema
        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            new N_Auditoria().RegistrarAuditoria("Acceso al Sistema", "Cerró sesión de sistema."); //Registra el cierre de sesión del sistema
            Application.Exit(); //Sale del Sistema cuando se hace click sobre la "x" del formulario
        }

        private void temporizador_Tick(Object myObject, EventArgs myEventArgs)
        {
            abrirFormularioModalNotificacion();
        }
        #endregion

        #region Eventos de Menú: Mi Sistema
        private void itemMiEmpresa_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(82)) abrirFormulario(new FormMiEmpresa()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemUsuarios_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(86)) abrirFormulario(new FormUsuario()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemAlertasDeSistema_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(77)) abrirFormulario(new FormAlerta()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemAuditoriaDeActividadesDeUsuarios_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(80)) abrirFormulario(new FormAuditoria()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemCalculadoraDeWindows_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Windows\System32\calc.exe");
        }

        private void itemHerramientasDeSistema_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(81)) abrirFormulario(new FormHerramienta()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemOpcionesGenerales_Click(object sender, EventArgs e) //84
        {
            if (Global.UsuarioActivo_Privilegios.Contains(84)) abrirFormulario(new FormOpcionGeneral()); //Control de Privilegios
            else Mensaje.Restriccion();
        }
        #endregion

        #region Eventos de Menú: Compras
        private void itemComprobantesDeCompra_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(20)) abrirFormulario(new FormCompra()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemOrdenesDeCompra_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(25)) abrirFormulario(new FormOrdenCompra()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemFacturasAPagar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(24)) abrirFormulario(new FormFacturaAPagar()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemCtaCteDeProveedores_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(23)) abrirFormulario(new FormProveedorCtaCte()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemProveedores_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(30)) abrirFormulario(new FormProveedor()); //Control de Privilegios
            else Mensaje.Restriccion();
        }
        #endregion

        #region Eventos de Menú: Ventas
        private void itemComprobantesDeVenta_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(173)) abrirFormulario(new FormVenta()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemFacturasACobrar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(177)) abrirFormulario(new FormFacturaACobrar()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemCtaCteDeClientes_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(176)) abrirFormulario(new FormClienteCtaCte()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemClientes_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(168)) abrirFormulario(new FormCliente()); //Control de Privilegios
            else Mensaje.Restriccion();
        }
        #endregion

        #region Eventos de Menú: RRHH
        private void itemContratosDeTrabajo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(95)) abrirFormulario(new FormContrato()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemNovedadesDeNomina_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(130)) abrirFormulario(new FormNovedadNomina()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemSueldos_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(138)) abrirFormulario(new FormSueldo()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemBusquedaDePostulantes_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(90)) abrirFormulario(new FormBusquedaPostulante()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemEntrevistasDetrabajo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(106)) abrirFormulario(new FormEntrevista()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemResumenRelevanteDeLegajos_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(134)) abrirFormulario(new FormResumenRelevanteLegajo()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemCapacitacionesLaborales_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(91)) abrirFormulario(new FormCapacitacionLaboral()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemCursosDeInducción_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(99)) abrirFormulario(new FormCursoInduccion()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemCursosDeIzaje_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(102)) abrirFormulario(new FormCursoIzaje()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemExamenesMedicos_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(110)) abrirFormulario(new FormExamenMedico()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

            #region SubMenu: Legajos
            private void itemLegajoCurriculumVitae_Click(object sender, EventArgs e)
            {
                if (Global.UsuarioActivo_Privilegios.Contains(114)) abrirFormulario(new FormLegajoCurriculumVitae()); //Control de Privilegios
                else Mensaje.Restriccion();
            }

            private void itemLegajoLaboral_Click(object sender, EventArgs e)
            {
                if (Global.UsuarioActivo_Privilegios.Contains(120)) abrirFormulario(new FormLegajoLaboral()); //Control de Privilegios
                else Mensaje.Restriccion();
            }

            private void itemLegajoPersonal_Click(object sender, EventArgs e)
            {
                if (Global.UsuarioActivo_Privilegios.Contains(123)) abrirFormulario(new FormLegajo()); //Control de Privilegios
                else Mensaje.Restriccion();
            }

            private void itemLegajoDocumentacion_Click(object sender, EventArgs e)
            {
                if (Global.UsuarioActivo_Privilegios.Contains(117)) abrirFormulario(new FormLegajoDocumentacion()); //Control de Privilegios
                else Mensaje.Restriccion();
            }

            private void itemLegajoTallesDeIndumentaria_Click(object sender, EventArgs e)
            {
                if (Global.UsuarioActivo_Privilegios.Contains(127)) abrirFormulario(new FormLegajoTalle()); //Control de Privilegios
                else Mensaje.Restriccion();
            }
            #endregion

        private void itemSindicatos_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(8)) abrirFormulario(new FormSindicato()); //Control de Privilegios
            else Mensaje.Restriccion();
        }
        #endregion

        #region Eventos de Menú: Inventario
        private void itemConsumosDeStock_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(61)) abrirFormulario(new FormConsumoStock()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemControlesDeStock_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(64)) abrirFormulario(new FormControlStock()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemMovimientosDeStock_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(70)) abrirFormulario(new FormMovimientoStock()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemEmpreminsa_Click(object sender, EventArgs e)
        {
            generarPlantilla_ControlStock("EMPREMINSA");
        }

        private void itemVeladero_Click(object sender, EventArgs e)
        {
            generarPlantilla_ControlStock("VELADERO");
        }

        private void itemFormulariosResolución2992011_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(67)) abrirFormulario(new FormFormularioR29911()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemSuministracionesDeIndumentariaYEPP_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(73)) abrirFormulario(new FormSuministracionIEPP()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemArticulos_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(58)) abrirFormulario(new FormArticulo()); //Control de Privilegios
            else Mensaje.Restriccion();
        }
        #endregion

        #region Eventos de Menú: Tesorería
        private void itemFondos_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(151)) abrirFormulario(new FormFondo()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemMovimientosDeFondos_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(152)) abrirFormulario(new FormMovimientoFondo()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemChequesAPagar_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(143)) abrirFormulario(new FormChequeAPagar()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemCobranza_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(144)) abrirFormulario(new FormCobranza()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemPagosANomina_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(160)) abrirFormulario(new FormPagoNomina()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemPagosAProveedores_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(164)) abrirFormulario(new FormPagoProveedor()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemOtrosPagos_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(156)) abrirFormulario(new FormPagoOtro()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemConciliacionDeCuentas_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(148)) abrirFormulario(new FormConciliacion()); //Control de Privilegios
            else Mensaje.Restriccion();
        }
        #endregion

        #region Eventos de Menú: Impuestos
        private void itemLibrosDeIVA_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(55)) abrirFormulario(new FormLibroIVA()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void item‎RG36852014_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(56)) abrirFormulario(new FormRG36852014()); //Control de Privilegios
            else Mensaje.Restriccion();
        }
        #endregion

        #region Eventos de Menú: Contabilidad
        private void itemAsientosManuales_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(33)) abrirFormulario(new FormAsientoManual()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemLibroDiario_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(44)) abrirFormulario(new FormLibroDiario()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemLibroMayor_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(45)) abrirFormulario(new FormLibroMayor()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemBalanceDeSumasYSaldos_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(37)) abrirFormulario(new FormBalanceSumasSaldos()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemEstadoFinanciero_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(43)) abrirFormulario(new FormEstadoFinanciero()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemEstadoDeResultados_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(42)) abrirFormulario(new FormEstadoResultados()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemResumenDeAsientosDeCompra_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(52)) abrirFormulario(new FormResumenAsientoCompra()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemResumenDeAsientosDeSueldo_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(53)) abrirFormulario(new FormResumenAsientoSueldo()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

        private void itemResumenDeAsientosDeVenta_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(54)) abrirFormulario(new FormResumenAsientoVenta()); //Control de Privilegios
            else Mensaje.Restriccion();
        }

            #region SubMenu: Centros de Costo
            private void itemConsumosPorCentrosDeCosto_Click(object sender, EventArgs e)
            {
                if (Global.UsuarioActivo_Privilegios.Contains(41)) abrirFormulario(new FormConsumoCentroCosto()); //Control de Privilegios
                else Mensaje.Restriccion();
            }

            private void itemRentabilidadPorCentrosDeCosto_Click(object sender, EventArgs e)
            {
                if (Global.UsuarioActivo_Privilegios.Contains(49)) abrirFormulario(new FormRentabilidadCentroCosto()); //Control de Privilegios
                else Mensaje.Restriccion();
            }

            private void itemCentrosDeCosto_Click(object sender, EventArgs e)
            {
                if (Global.UsuarioActivo_Privilegios.Contains(38)) abrirFormulario(new FormCentroCosto()); //Control de Privilegios
                else Mensaje.Restriccion();
            }
            #endregion

        private void itemPlanDeCuentas_Click(object sender, EventArgs e)
        {
            if (Global.UsuarioActivo_Privilegios.Contains(46)) abrirFormulario(new FormPlanDeCuenta()); //Control de Privilegios
            else Mensaje.Restriccion();
        }
        #endregion

        #region Métodos
        private void abrirFormulario(Form formulario) //Método que abre un formulario en el caso de que No se encuentre abierto
        {
            Form FormularioAbierto = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == formulario.Name).SingleOrDefault<Form>();
            if (FormularioAbierto == null)
            {
                foreach (Form hijo in this.MdiChildren) hijo.Close(); //Cierra los formularios que esten abiertos
                formulario.MdiParent = this;
                formulario.Dock = DockStyle.Fill;
                formulario.Show();
            }
        }

        private void abrirFormularioModalNotificacion()
        {
            List<Alerta> listaDeAlerta_SinAtencion = new N_Alerta().obtenerObjetos("ALERTAS PERSONALIZADAS", "SIN PROCESAR", "DENOMINACION", "");
            List<Alerta> listaDeAlerta_EnProceso = new N_Alerta().obtenerObjetos("ALERTAS PERSONALIZADAS", "CADUCADO", "DENOMINACION", "");
            if ((listaDeAlerta_SinAtencion.Count + listaDeAlerta_EnProceso.Count) > 0) //Verifica que hayan alertas sin atender o en proceso
            {
                FormNotificacion formModalNotificacion = new FormNotificacion();
                Form FormularioModalNotificacionAbierto = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == formModalNotificacion.Name).SingleOrDefault<Form>();
                if (FormularioModalNotificacionAbierto == null)  //Verifica que No este abierta una ventana de notificación
                {
                    FormAlerta formAlerta = new FormAlerta();
                    Form FormularioAlertaAbierto = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == formAlerta.Name).SingleOrDefault<Form>();
                    if (FormularioAlertaAbierto == null) formModalNotificacion.ShowDialog(this); //Verifica que No este dentro de la ventana de alertas
                }
            }
        }

        private void generarPlantilla_ControlStock(string deposito)
        {
            Cursor.Current = Cursors.WaitCursor;
            #region SubTitulos
            List<string> centroDeCostoSectores = new N_CentroCosto().obtenerListaDeElementos(new string[] { deposito });
            string[] subTitulos = new string[centroDeCostoSectores.Count + 3]; //Establece el tamaño del vector de subTitulos
            subTitulos[0] = "Código";
            subTitulos[1] = "Denominación";
            subTitulos[2] = "Recuento";
            for (int i = 0; i < centroDeCostoSectores.Count; i++) subTitulos[i + 3] = centroDeCostoSectores[i]; //coloca el nombre del resto de las columnas
            #endregion
            #region filasDB
            List<string[]> _listaDelReporte = new List<string[]>();
            List<Articulo> listaArticulos = new N_Articulo().obtenerExistencias(deposito);
            foreach (Articulo item in listaArticulos)
            {
                string[] filasDB = new string[centroDeCostoSectores.Count + 3]; //Establece el ta{año del vector de filasDB
                for (int i = 0; i < filasDB.Length; i++) filasDB[i] = "0"; //Rellena cada celda con un valor por defecto
                filasDB[0] = Convert.ToString(item.Id).PadLeft(6, '0');
                filasDB[1] = item.Denominacion.Trim();
                _listaDelReporte.Add(filasDB);
            }
            #endregion
            #region Definición de Columnas
            int[] anchoColumnas = new int[centroDeCostoSectores.Count + 3];
            for (int i = 0; i < anchoColumnas.Length; i++) anchoColumnas[i] = 25; //Rellena cada celda con un ancho por defecto
            anchoColumnas[0] = 8;
            anchoColumnas[1] = 35;
            anchoColumnas[2] = 10;
            int[] desproteccionColumnas = new int[centroDeCostoSectores.Count + 1];
            for (int i = 0; i < desproteccionColumnas.Length; i++) desproteccionColumnas[i] = i + 3; //Establece la desprotección de cada columna que corresponde con cada Sector(Centro de Costo)
            #endregion
            Cursor.Current = Cursors.Default;
            Reporte reporte = new Reporte();
            reporte.crearDocumentoExcel_PlantillaStock(deposito, subTitulos, anchoColumnas, _listaDelReporte, desproteccionColumnas); //Ancho: 99
        }

        #endregion
    }
}
