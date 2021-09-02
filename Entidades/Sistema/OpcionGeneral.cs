using System;

namespace Entidades.Sistema
{
    public class OpcionGeneral : IEquatable<OpcionGeneral>
    {
        #region Atributos
        private long _id;
        private int _ptoVta;
        private int _alertaAntecedentes;
        private int _alertaCursoInduccion;
        private int _alertaCursoIzaje;
        private int _alertaEntrevista;
        private int _alertaExamenMedico;
        private int _alertaLicenciaConducir;
        private int _vigenciaAntecedentes;
        private int _vigenciaCurriculumVitae;
        private int _vigenciaCursoInduccion;
        private int _vigenciaCursoIzaje;
        private int _vigenciaExamenMedico;
        private double _liquidacionSueldo_AporteTasa;
        private double _liquidacionSueldo_ContribTiempoCompletoTasa;
        private double _liquidacionSueldo_ContribTiempoParcialTasa;
        private double _liquidacionSueldo_ArtFijo;
        private double _liquidacionSueldo_ArtTasa;
        private double _liquidacionSueldo_SCVO;
        private double _estadoResultado_IIBBTasa;
        private double _estadoResultado_PrevisionSACDesempleoTasa;
        private double _estadoResultado_PrevisionImpGananciaTasa;
        private int _registroAnulacion;
        private int _registroModificion;
        private DateTime _edicionFecha;
        private long _edicionUsuarioId;
        private string _edicionUsuarioDenominacion;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public int PtoVta { get => _ptoVta; set => _ptoVta = value; }
        public int AlertaAntecedentes { get => _alertaAntecedentes; set => _alertaAntecedentes = value; }
        public int AlertaCursoInduccion { get => _alertaCursoInduccion; set => _alertaCursoInduccion = value; }
        public int AlertaCursoIzaje { get => _alertaCursoIzaje; set => _alertaCursoIzaje = value; }
        public int AlertaEntrevista { get => _alertaEntrevista; set => _alertaEntrevista = value; }
        public int AlertaExamenMedico { get => _alertaExamenMedico; set => _alertaExamenMedico = value; }
        public int AlertaLicenciaConducir { get => _alertaLicenciaConducir; set => _alertaLicenciaConducir = value; }
        public int VigenciaAntecedentes { get => _vigenciaAntecedentes; set => _vigenciaAntecedentes = value; }
        public int VigenciaCurriculumVitae { get => _vigenciaCurriculumVitae; set => _vigenciaCurriculumVitae = value; }
        public int VigenciaCursoInduccion { get => _vigenciaCursoInduccion; set => _vigenciaCursoInduccion = value; }
        public int VigenciaCursoIzaje { get => _vigenciaCursoIzaje; set => _vigenciaCursoIzaje = value; }
        public int VigenciaExamenMedico { get => _vigenciaExamenMedico; set => _vigenciaExamenMedico = value; }
        public double LiquidacionSueldo_AporteTasa { get => _liquidacionSueldo_AporteTasa; set => _liquidacionSueldo_AporteTasa = value; }
        public double LiquidacionSueldo_ContribTiempoCompletoTasa { get => _liquidacionSueldo_ContribTiempoCompletoTasa; set => _liquidacionSueldo_ContribTiempoCompletoTasa = value; }
        public double LiquidacionSueldo_ContribTiempoParcialTasa { get => _liquidacionSueldo_ContribTiempoParcialTasa; set => _liquidacionSueldo_ContribTiempoParcialTasa = value; }
        public double LiquidacionSueldo_ArtFijo { get => _liquidacionSueldo_ArtFijo; set => _liquidacionSueldo_ArtFijo = value; }
        public double LiquidacionSueldo_ArtTasa { get => _liquidacionSueldo_ArtTasa; set => _liquidacionSueldo_ArtTasa = value; }
        public double LiquidacionSueldo_SCVO { get => _liquidacionSueldo_SCVO; set => _liquidacionSueldo_SCVO = value; }
        public double EstadoResultado_IIBBTasa { get => _estadoResultado_IIBBTasa; set => _estadoResultado_IIBBTasa = value; }
        public double EstadoResultado_PrevisionSACDesempleoTasa { get => _estadoResultado_PrevisionSACDesempleoTasa; set => _estadoResultado_PrevisionSACDesempleoTasa = value; }
        public double EstadoResultado_PrevisionImpGananciaTasa { get => _estadoResultado_PrevisionImpGananciaTasa; set => _estadoResultado_PrevisionImpGananciaTasa = value; }
        public int RegistroAnulacion { get => _registroAnulacion; set => _registroAnulacion = value; }
        public int RegistroModificion { get => _registroModificion; set => _registroModificion = value; }
        public DateTime EdicionFecha { get => _edicionFecha; set => _edicionFecha = value; }
        public long EdicionUsuarioId { get => _edicionUsuarioId; set => _edicionUsuarioId = value; }
        public string EdicionUsuarioDenominacion { get => _edicionUsuarioDenominacion; set => _edicionUsuarioDenominacion = value; }
        #endregion

        #region Constructores
        public OpcionGeneral() { }
        public OpcionGeneral(long id, int ptoVta, int alertaAntecedentes, int alertaCursoInduccion, int alertaCursoIzaje, int alertaEntrevista, int alertaExamenMedico, int alertaLicenciaConducir, int vigenciaAntecedentes, int vigenciaCurriculumVitae, int vigenciaCursoInduccion, int vigenciaCursoIzaje, int vigenciaExamenMedico, double liquidacionSueldo_AporteTasa, double liquidacionSueldo_ContribTiempoCompletoTasa, double liquidacionSueldo_ContribTiempoParcialTasa, double liquidacionSueldo_ArtFijo, double liquidacionSueldo_ArtTasa, double liquidacionSueldo_SCVO, double estadoResultado_IIBBTasa, double estadoResultado_PrevisionSACDesempleoTasa, double estadoResultado_PrevisionImpGananciaTasa, int registroAnulacion, int registroModificion, DateTime edicionFecha, long edicionUsuarioId, string edicionUsuarioDenominacion)
        {
            _id = id;
            _ptoVta = ptoVta;
            _alertaAntecedentes = alertaAntecedentes;
            _alertaCursoInduccion = alertaCursoInduccion;
            _alertaCursoIzaje = alertaCursoIzaje;
            _alertaEntrevista = alertaEntrevista;
            _alertaExamenMedico = alertaExamenMedico;
            _alertaLicenciaConducir = alertaLicenciaConducir;
            _vigenciaAntecedentes = vigenciaAntecedentes;
            _vigenciaCurriculumVitae = vigenciaCurriculumVitae;
            _vigenciaCursoInduccion = vigenciaCursoInduccion;
            _vigenciaCursoIzaje = vigenciaCursoIzaje;
            _vigenciaExamenMedico = vigenciaExamenMedico;
            _liquidacionSueldo_AporteTasa = liquidacionSueldo_AporteTasa;
            _liquidacionSueldo_ContribTiempoCompletoTasa = liquidacionSueldo_ContribTiempoCompletoTasa;
            _liquidacionSueldo_ContribTiempoParcialTasa = liquidacionSueldo_ContribTiempoParcialTasa;
            _liquidacionSueldo_ArtFijo = liquidacionSueldo_ArtFijo;
            _liquidacionSueldo_ArtTasa = liquidacionSueldo_ArtTasa;
            _liquidacionSueldo_SCVO = liquidacionSueldo_SCVO;
            _estadoResultado_IIBBTasa = estadoResultado_IIBBTasa;
            _estadoResultado_PrevisionSACDesempleoTasa = estadoResultado_PrevisionSACDesempleoTasa;
            _estadoResultado_PrevisionImpGananciaTasa = estadoResultado_PrevisionImpGananciaTasa;
            _registroAnulacion = registroAnulacion;
            _registroModificion = registroModificion;
            _edicionFecha = edicionFecha;
            _edicionUsuarioId = edicionUsuarioId;
            _edicionUsuarioDenominacion = edicionUsuarioDenominacion;
        }
        #endregion

        #region Comparación de Objeto
        public bool Equals(OpcionGeneral objOpcionGeneral)
        {
            if (objOpcionGeneral != null &&
                   _id == objOpcionGeneral._id &&
                   _ptoVta == objOpcionGeneral._ptoVta &&
                   _alertaAntecedentes == objOpcionGeneral._alertaAntecedentes &&
                   _alertaCursoInduccion == objOpcionGeneral._alertaCursoInduccion &&
                   _alertaCursoIzaje == objOpcionGeneral._alertaCursoIzaje &&
                   _alertaEntrevista == objOpcionGeneral._alertaEntrevista &&
                   _alertaExamenMedico == objOpcionGeneral._alertaExamenMedico &&
                   _alertaLicenciaConducir == objOpcionGeneral._alertaLicenciaConducir &&
                   _vigenciaAntecedentes == objOpcionGeneral._vigenciaAntecedentes &&
                   _vigenciaCurriculumVitae == objOpcionGeneral._vigenciaCurriculumVitae &&
                   _vigenciaCursoInduccion == objOpcionGeneral._vigenciaCursoInduccion &&
                   _vigenciaCursoIzaje == objOpcionGeneral._vigenciaCursoIzaje &&
                   _vigenciaExamenMedico == objOpcionGeneral._vigenciaExamenMedico &&
                   _liquidacionSueldo_AporteTasa == objOpcionGeneral._liquidacionSueldo_AporteTasa &&
                   _liquidacionSueldo_ContribTiempoCompletoTasa == objOpcionGeneral._liquidacionSueldo_ContribTiempoCompletoTasa &&
                   _liquidacionSueldo_ContribTiempoParcialTasa == objOpcionGeneral._liquidacionSueldo_ContribTiempoParcialTasa &&
                   _liquidacionSueldo_ArtFijo == objOpcionGeneral._liquidacionSueldo_ArtFijo &&
                   _liquidacionSueldo_ArtTasa == objOpcionGeneral._liquidacionSueldo_ArtTasa &&
                   _liquidacionSueldo_SCVO == objOpcionGeneral._liquidacionSueldo_SCVO &&
                   _estadoResultado_IIBBTasa == objOpcionGeneral._estadoResultado_IIBBTasa &&
                   _estadoResultado_PrevisionSACDesempleoTasa == objOpcionGeneral._estadoResultado_PrevisionSACDesempleoTasa &&
                   _estadoResultado_PrevisionImpGananciaTasa == objOpcionGeneral._estadoResultado_PrevisionImpGananciaTasa &&
                   _registroAnulacion == objOpcionGeneral._registroAnulacion &&
                   _registroModificion == objOpcionGeneral._registroModificion) return true;

            return false;
        }
        #endregion
    }
}
