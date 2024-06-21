using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Dtos.Movimientos;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.Movimientos
{
    public class ObtenerMovimientosPorTipoYArt: IObtenerFiltroDobleString<MovimientoDto>
    {

        IRepositorioMovimiento _repositorioMovimiento;

        public ObtenerMovimientosPorTipoYArt(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }
 

        public PaginationRetorno<MovimientoDto> Ejecutar(string articuloId, string tipoMovimiento, int page)
        {
            PaginationRetorno<Movimiento>  mov = _repositorioMovimiento.GetMovimientosPorArticuloYTipo(articuloId, tipoMovimiento, page);

            PaginationRetorno<MovimientoDto> retorno = new PaginationRetorno<MovimientoDto>();
            retorno.cantidadTotal = mov.cantidadTotal;
            retorno.elementos = MovimientoMapper.ToListaDto(mov.elementos);
            
            return retorno;
        }

    }
}
