using LogicaNegocio.Dtos.Movimientos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioMovimiento : IRepositorio<Movimiento>
    {
        public Movimiento GetById(int id);
        public IEnumerable<Movimiento> GetAll(int page);

        public void Add(MovimientoCRUDDto obj);

        public void Update(int id, MovimientoCRUDDto movimientoDto);
        public IEnumerable<string> GetCantidades();

        public int GetCantidad();

        public PaginationRetorno<Articulo> GetArticulosPorFechas(DateTime desde, DateTime hasta, int page);

        public PaginationRetorno<Movimiento> GetMovimientosPorArticuloYTipo(string articuloId, string tipoMovimiento, int page);
    }
}
