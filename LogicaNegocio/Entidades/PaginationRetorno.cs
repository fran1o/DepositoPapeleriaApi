

namespace LogicaNegocio.Entidades
{
    public class PaginationRetorno<T>
    {
        public IEnumerable<T> elementos { get; set; }
        public int cantidadTotal { get; set; }
    }
}
