namespace Entidades.Catalogo
{
    public class ObraSocial : CatalogoBase
    {
        /* Herencia: Esta clase hereda de la clase CatalogoBase
         * Importante: Se inicializan las variables para evitar el error de "NullReferenceException”
         * (Referencia a objeto no establecida como instancia de un objeto). Este error se da cuando
         * este objeto no tiene una definición y el mismo está contenido dentro de otro objeto que 
         * intenta instanciarlo.
        */

        #region Atributos
        private string _codigo = "";
        #endregion

        #region Propiedades
        public string Codigo { get => _codigo; set => _codigo = value; }
        #endregion

        #region Constructores
        public ObraSocial() { }
        public ObraSocial(long id, string codigo, string denominacion) : base(id, denominacion)
        {
            _codigo = codigo;
        }
        #endregion
    }
}
