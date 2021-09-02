namespace Entidades.Sistema
{
    public class Privilegio
    {
        /* Importante: Se inicializan las variables para evitar el error de "NullReferenceException”
         * (Referencia a objeto no establecida como instancia de un objeto). Este error se da cuando
         * este objeto no tiene una definición y el mismo está contenido dentro de otro objeto que 
         * intenta instanciarlo.
        */

        #region Atributos
        private long _id = 0;
        private string _denominacion = "";
        private bool _permiso = false;
        #endregion

        #region Propiedades
        public long Id { get => _id; set => _id = value; }
        public string Denominacion { get => _denominacion; set => _denominacion = value; }
        public bool Permiso { get => _permiso; set => _permiso = value; }
        #endregion

        #region Constructores
        public Privilegio() { }
        public Privilegio(long id, string denominacion, bool permiso)
        {
            _id = id;
            _denominacion = denominacion;
            _permiso = permiso;
        }
        #endregion
    }
}