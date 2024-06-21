using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Dtos.TipoMovimientos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;

namespace LogicaAplicacion.TiposMovimientos
{
    public class AltaTipoMovimiento : IAltaID<TipoMovimientoDto>
    {

        IRepositorioTipoMovimiento _repositorioTipoMovimiento;

        public AltaTipoMovimiento(IRepositorioTipoMovimiento repositorioTipoMovimiento)
        {
            _repositorioTipoMovimiento = repositorioTipoMovimiento;
        }

        public int Ejecutar(TipoMovimientoDto movimientoDto)
        {
            TipoMovimiento tipoMovimiento = TipoMovimientoMapper.FromDto(movimientoDto);
            _repositorioTipoMovimiento.Add(tipoMovimiento);

            return tipoMovimiento.Id;
        }
    }
}
