namespace Entidades.Catalogo
{
    public class CategoriaTrabajo : CatalogoBase
    {
        /* Herencia: Esta clase hereda de la clase CatalogoBase
         * Importante: Se inicializan las variables para evitar el error de "NullReferenceException”
         * (Referencia a objeto no establecida como instancia de un objeto). Este error se da cuando
         * este objeto no tiene una definición y el mismo está contenido dentro de otro objeto que 
         * intenta instanciarlo.
        */

        #region Constructores
        public CategoriaTrabajo() { }
        public CategoriaTrabajo(long id, string denominacion) : base(id, denominacion) { }
        #endregion
    }
}
