using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Dtos.Movimientos;
using LogicaNegocio.Dtos.TipoMovimientos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;


namespace LogicaAplicacion.Movimientos
{
    public class ObtenerMovimiento : IObtener<MovimientoDto>
    {
        IRepositorioMovimiento _repositorioMovimiento;

        public ObtenerMovimiento(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }
        public MovimientoDto Ejecutar(int id)
        {
            Movimiento movimiento = _repositorioMovimiento.GetById(id);
            return MovimientoMapper.ToDto(movimiento);
        }
    }
}
