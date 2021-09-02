namespace Entidades.Catalogo
{
    public class CatalogoBase
    {
        /* Herencia: Clase Base para herencia de catálogos
         * Importante: Se inicializan las variables para evitar el error de "NullReferenceException”
         * (Referencia a objeto no establecida como instancia de un objeto). Este error se da cuando
         * este objeto no tiene una definición y el mismo está contenido dentro de otro objeto que 
         * intenta instanciarlo.
        */

        #region Atributos
        private long _id = 0;
        private string _denominacion = "";
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        #endregion

        #region Constructores
        public CatalogoBase() { }
        public CatalogoBase(long id, string denominacion)
        {
            _id = id;
            _denominacion = denominacion;
        }
        #endregion
    }
}