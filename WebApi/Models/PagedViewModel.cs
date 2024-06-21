using LogicaNegocio.Entidades;

namespace WebApp.Models
{
    public class PageMovimientoViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}
