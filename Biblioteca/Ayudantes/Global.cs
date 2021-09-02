using Entidades.Sistema;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Biblioteca.Ayudantes
{
    public static class Global
    {
        //Importante: Se inicializan las variables para evitar errores en la pila de llamado
        #region Atributos de Sistema
        private static DateTime _relojDeSistema = DateTime.Now; //Almacena la fecha y hora del reloj interno del sistema
        private static Form _formularioPrincipal = null;
        private static int _paginacionIndiceMaximo = 0; //Número máximo de páginas por consulta (Listado)
        private static int _paginacionTamanio = 50; //Tamaño en relación al la cantidad de registros por página en la consulta (Listado)
        private static string _rutaDeTrabajo = Application.StartupPath.ToString() + @"\"; //Directorio principal de trabajo (Sistema)
        private static long _usuarioActivo_IdPersona = 0;
        private static long _usuarioActivo_IdUsuario = 0;
        private static string _usuarioActivo_Denominacion = "";
        private static string _usuarioActivo_Documento = "";
        private static string _usuarioActivo_TipoUsuario = "";
        private static List<string> _usuarioActivo_Alertas = new List<string>(); //Alertas personalizadas del usuario
        private static List<long> _usuarioActivo_Privilegios = new List<long>(); //Privilegios y restricciones del usuario
        private static string _ftpServidor = ""; //FTP: Servidor de actualizaciones (servidor)
        private static string _ftpUsuario = ""; //FTP: Servidor de actualizaciones (usuario)
        private static string _ftpClave = ""; //FTP: Servidor de actualizaciones (clave)
        #endregion

        #region Atributos de Opciones Generales
        private static double _liquidacionSueldo_AporteTasa = 0.000;
        private static double _liquidacionSueldo_ContribTiempoCompletoTasa = 0.000;
        private static double _liquidacionSueldo_ContribTiempoParcialTasa = 0.000;
        private static double _liquidacionSueldo_ArtFijo = 0.00;
        private static double _liquidacionSueldo_ArtTasa = 0.000;
        private static double _liquidacionSueldo_SCVO= 0.00;
        private static double _estadoResultado_IIBBTasa = 0.00;
        private static double _estadoResultado_PrevisionSACDesempleoTasa = 0.00;
        private static double _estadoResultado_PrevisionImpGananciaTasa = 0.00;
        private static int _alerta_Antecedentes = 0; //Dias
        private static int _alerta_CursoInduccion = 0; //Dias
        private static int _alerta_CursoIzaje = 0; //Dias
        private static int _alerta_Entrevista = 0; //Dias
        private static int _alerta_ExamenMedico = 0; //Dias
        private static int _alerta_LicenciaConducir = 0; //Dias
        private static int _ptoVta = 0; //Número de punto de venta
        private static int _vigencia_Antecedentes = 0; //Meses
        private static int _vigencia_CurriculumVitae = 0; //Meses
        private static int _vigencia_CursoInduccion = 0; //Meses
        private static int _vigencia_CursoIzaje = 0; //Meses
        private static int _vigencia_ExamenMedico = 0; //Meses
        private static int _registroAnulacion = 0; //Dias
        private static int _registroModificacion = 0; //Dias
        #endregion

        #region Atributos de Mi Empresa
        private static string _empresa_RazonSocial = "";
        private static string _empresa_Domicilio = "";
        private static string _empresa_Distrito = "";
        private static string _empresa_Provincia = "";
        private static string _empresa_CodigoPostal = "";
        private static string _empresa_Telefono = "";
        private static string _empresa_IVA = "";
        private static string _empresa_CUIT = "";
        private static string _empresa_IIBB = "";
        private static string _empresa_InicioActividad = "";
        #endregion

        #region Propiedades
        public static DateTime RelojDeSistema { get => _relojDeSistema; set => _relojDeSistema = value; }
        public static Form FormularioPrincipal { get => _formularioPrincipal; set => _formularioPrincipal = value; }
        public static int PaginacionIndiceMaximo { get => _paginacionIndiceMaximo; set => _paginacionIndiceMaximo = value; }
        public static int PaginacionTamanio { get => _paginacionTamanio; set => _paginacionTamanio = value; }
        public static string RutaDeTrabajo { get => _rutaDeTrabajo; set => _rutaDeTrabajo = value; }
        public static long UsuarioActivo_IdPersona { get => _usuarioActivo_IdPersona; set => _usuarioActivo_IdPersona = value; }
        public static long UsuarioActivo_IdUsuario { get => _usuarioActivo_IdUsuario; set => _usuarioActivo_IdUsuario = value; }
        public static string UsuarioActivo_Denominacion { get => _usuarioActivo_Denominacion; set => _usuarioActivo_Denominacion = value; }
        public static string UsuarioActivo_Documento { get => _usuarioActivo_Documento; set => _usuarioActivo_Documento = value; }
        public static string UsuarioActivo_TipoUsuario { get => _usuarioActivo_TipoUsuario; set => _usuarioActivo_TipoUsuario = value; }
        public static List<string> UsuarioActivo_Alertas { get => _usuarioActivo_Alertas; set => _usuarioActivo_Alertas = value; }
        public static List<long> UsuarioActivo_Privilegios { get => _usuarioActivo_Privilegios; set => _usuarioActivo_Privilegios = value; }
        public static string FtpServidor { get => _ftpServidor; set => _ftpServidor = value; }
        public static string FtpUsuario { get => _ftpUsuario; set => _ftpUsuario = value; }
        public static string FtpClave { get => _ftpClave; set => _ftpClave = value; }
        public static double LiquidacionSueldo_AporteTasa { get => _liquidacionSueldo_AporteTasa; set => _liquidacionSueldo_AporteTasa = value; }
        public static double LiquidacionSueldo_ContribTiempoCompletoTasa { get => _liquidacionSueldo_ContribTiempoCompletoTasa; set => _liquidacionSueldo_ContribTiempoCompletoTasa = value; }
        public static double LiquidacionSueldo_ContribTiempoParcialTasa { get => _liquidacionSueldo_ContribTiempoParcialTasa; set => _liquidacionSueldo_ContribTiempoParcialTasa = value; }
        public static double LiquidacionSueldo_ArtFijo { get => _liquidacionSueldo_ArtFijo; set => _liquidacionSueldo_ArtFijo = value; }
        public static double LiquidacionSueldo_ArtTasa { get => _liquidacionSueldo_ArtTasa; set => _liquidacionSueldo_ArtTasa = value; }
        public static double LiquidacionSueldo_SCVO { get => _liquidacionSueldo_SCVO; set => _liquidacionSueldo_SCVO = value; }
        public static double EstadoResultado_IIBBTasa { get => _estadoResultado_IIBBTasa; set => _estadoResultado_IIBBTasa = value; }
        public static double EstadoResultado_PrevisionSACDesempleoTasa { get => _estadoResultado_PrevisionSACDesempleoTasa; set => _estadoResultado_PrevisionSACDesempleoTasa = value; }
        public static double EstadoResultado_PrevisionImpGananciaTasa { get => _estadoResultado_PrevisionImpGananciaTasa; set => _estadoResultado_PrevisionImpGananciaTasa = value; }
        public static int Alerta_Antecedentes { get => _alerta_Antecedentes; set => _alerta_Antecedentes = value; }
        public static int Alerta_CursoInduccion { get => _alerta_CursoInduccion; set => _alerta_CursoInduccion = value; }
        public static int Alerta_CursoIzaje { get => _alerta_CursoIzaje; set => _alerta_CursoIzaje = value; }
        public static int Alerta_Entrevista { get => _alerta_Entrevista; set => _alerta_Entrevista = value; }
        public static int Alerta_ExamenMedico { get => _alerta_ExamenMedico; set => _alerta_ExamenMedico = value; }
        public static int Alerta_LicenciaConducir { get => _alerta_LicenciaConducir; set => _alerta_LicenciaConducir = value; }
        public static int PtoVta { get => _ptoVta; set => _ptoVta = value; }
        public static int Vigencia_Antecedentes { get => _vigencia_Antecedentes; set => _vigencia_Antecedentes = value; }
        public static int Vigencia_CurriculumVitae { get => _vigencia_CurriculumVitae; set => _vigencia_CurriculumVitae = value; }
        public static int Vigencia_CursoInduccion { get => _vigencia_CursoInduccion; set => _vigencia_CursoInduccion = value; }
        public static int Vigencia_CursoIzaje { get => _vigencia_CursoIzaje; set => _vigencia_CursoIzaje = value; }
        public static int Vigencia_ExamenMedico { get => _vigencia_ExamenMedico; set => _vigencia_ExamenMedico = value; }
        public static int RegistroAnulacion { get => _registroAnulacion; set => _registroAnulacion = value; }
        public static int RegistroModificacion { get => _registroModificacion; set => _registroModificacion = value; }
        public static string Empresa_RazonSocial { get => _empresa_RazonSocial; set => _empresa_RazonSocial = value; }
        public static string Empresa_Domicilio { get => _empresa_Domicilio; set => _empresa_Domicilio = value; }
        public static string Empresa_Distrito { get => _empresa_Distrito; set => _empresa_Distrito = value; }
        public static string Empresa_Provincia { get => _empresa_Provincia; set => _empresa_Provincia = value; }
        public static string Empresa_CodigoPostal { get => _empresa_CodigoPostal; set => _empresa_CodigoPostal = value; }
        public static string Empresa_Telefono { get => _empresa_Telefono; set => _empresa_Telefono = value; }
        public static string Empresa_IVA { get => _empresa_IVA; set => _empresa_IVA = value; }
        public static string Empresa_CUIT { get => _empresa_CUIT; set => _empresa_CUIT = value; }
        public static string Empresa_IIBB { get => _empresa_IIBB; set => _empresa_IIBB = value; }
        public static string Empresa_InicioActividad { get => _empresa_InicioActividad; set => _empresa_InicioActividad = value; }
        #endregion

        #region Métodos
        public static bool cargarVariablesDeCredencialFTP(CredencialFTP credencialFTP)
        {
            if (credencialFTP != null)
            {
                _ftpServidor = credencialFTP.FtpServidor;
                _ftpUsuario = credencialFTP.FtpUsuario;
                _ftpClave = credencialFTP.FtpClave;
                return true;
            }
            return false;
        }

        public static bool cargarVariablesDeOpcionesGenerales(OpcionGeneral opcionGeneral)
        {
            if (opcionGeneral != null)
            {
                _liquidacionSueldo_AporteTasa = opcionGeneral.LiquidacionSueldo_AporteTasa;
                _liquidacionSueldo_ContribTiempoCompletoTasa = opcionGeneral.LiquidacionSueldo_ContribTiempoCompletoTasa;
                _liquidacionSueldo_ContribTiempoParcialTasa = opcionGeneral.LiquidacionSueldo_ContribTiempoParcialTasa;
                _liquidacionSueldo_ArtFijo = opcionGeneral.LiquidacionSueldo_ArtFijo;
                _liquidacionSueldo_ArtTasa = opcionGeneral.LiquidacionSueldo_ArtTasa;
                _liquidacionSueldo_SCVO = opcionGeneral.LiquidacionSueldo_SCVO;
                _estadoResultado_IIBBTasa = opcionGeneral.EstadoResultado_IIBBTasa;
                _estadoResultado_PrevisionSACDesempleoTasa = opcionGeneral.EstadoResultado_PrevisionSACDesempleoTasa;
                _estadoResultado_PrevisionImpGananciaTasa = opcionGeneral.EstadoResultado_PrevisionImpGananciaTasa;
                _alerta_Antecedentes = opcionGeneral.AlertaAntecedentes;
                _alerta_CursoInduccion = opcionGeneral.AlertaCursoInduccion;
                _alerta_CursoIzaje = opcionGeneral.AlertaCursoIzaje;
                _alerta_Entrevista = opcionGeneral.AlertaEntrevista;
                _alerta_ExamenMedico = opcionGeneral.AlertaExamenMedico;
                _alerta_LicenciaConducir = opcionGeneral.AlertaLicenciaConducir;
                _ptoVta = opcionGeneral.PtoVta;
                _vigencia_Antecedentes = opcionGeneral.VigenciaAntecedentes;
                _vigencia_CurriculumVitae = opcionGeneral.VigenciaCurriculumVitae;
                _vigencia_CursoInduccion = opcionGeneral.VigenciaCursoInduccion;
                _vigencia_CursoIzaje = opcionGeneral.VigenciaCursoIzaje;
                _vigencia_ExamenMedico = opcionGeneral.VigenciaExamenMedico;
                _registroAnulacion = opcionGeneral.RegistroAnulacion;
                _registroModificacion = opcionGeneral.RegistroModificion;
                return true;
            }
            return false;
        }

        public static bool cargarVariablesDeEmpresa(MiEmpresa miEmpresa)
        {
            if (miEmpresa != null)
            {
                _empresa_RazonSocial = miEmpresa.Denominacion;
                _empresa_Domicilio = miEmpresa.Domicilio;
                _empresa_Distrito = miEmpresa.Distrito;
                _empresa_Provincia = miEmpresa.Provincia;
                _empresa_CodigoPostal = miEmpresa.Cp;
                _empresa_Telefono = miEmpresa.Telefono;
                _empresa_IVA = miEmpresa.Iva;
                _empresa_CUIT = miEmpresa.Cuit;
                _empresa_IIBB = miEmpresa.NroIngresosBrutos;
                _empresa_InicioActividad = Fecha.ConvertirFecha(miEmpresa.InicioDeActividad);
                return true;
            }
            return false;
        }
        #endregion
    }
}