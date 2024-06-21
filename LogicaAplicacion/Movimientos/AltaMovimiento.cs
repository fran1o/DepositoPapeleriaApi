using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Dtos.Movimientos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;


namespace LogicaAplicacion.Movimientos
{
    public class AltaMovimiento : IAltaID<MovimientoCRUDDto>
    {

        IRepositorioMovimiento _repositorioMovimiento;

        public AltaMovimiento(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }

        public int Ejecutar(MovimientoCRUDDto movimientoDto)
        {
            _repositorioMovimiento.Add(movimientoDto);

            return movimientoDto.Id;
        }
    }
}
