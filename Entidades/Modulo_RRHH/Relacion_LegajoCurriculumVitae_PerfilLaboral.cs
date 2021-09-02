using Entidades.Catalogo;

namespace Entidades
{
    public class Relacion_LegajoCurriculumVitae_PerfilLaboral
    {
        /* Importante: Se inicializan las variables para evitar el error de "NullReferenceException”
         * (Referencia a objeto no establecida como instancia de un objeto). Este error se da cuando
         * este objeto no tiene una definición y el mismo está contenido dentro de otro objeto que 
         * intenta instanciarlo.
        */

        #region Atributos
        private long _id = 0;
        private Legajo _legajo = new Legajo();
        private PerfilLaboral _perfilLaboral = new PerfilLaboral();
        private string _perfilLaboralDenominacion; //Importante: Atributo necesario que posibilita la lectura de la columna del gridLista
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public Legajo Legajo { get => _legajo; set => _legajo = value; }
        public PerfilLaboral PerfilLaboral { get => _perfilLaboral; set => _perfilLaboral = value; }
        public string PerfilLaboralDenominacion { get => _perfilLaboralDenominacion; set => _perfilLaboralDenominacion = value; }
        #endregion

        #region Constructores
        public Relacion_LegajoCurriculumVitae_PerfilLaboral() { }
        public Relacion_LegajoCurriculumVitae_PerfilLaboral(long id, Legajo legajo, PerfilLaboral perfilLaboral, string perfilLaboralDenominacion)
        {
            _id = id;
            _legajo = legajo;
            _perfilLaboral = perfilLaboral;
            _perfilLaboralDenominacion = perfilLaboralDenominacion;
        }
        #endregion
    }
}