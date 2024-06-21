using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.Movimientos
{
    public class ObtenerMovimientosRangoFechas: IObtenerRangoFecha<Articulo>
    {

        IRepositorioMovimiento _repositorioMovimiento;

        public ObtenerMovimientosRangoFechas(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }
 
        public PaginationRetorno<Articulo> Ejecutar(DateTime desde, DateTime hasta, int page)
        {
            return _repositorioMovimiento.GetArticulosPorFechas(desde, hasta, page);
        }

    }
}
