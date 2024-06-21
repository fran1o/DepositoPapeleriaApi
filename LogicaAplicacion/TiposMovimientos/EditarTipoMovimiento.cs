using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Dtos.TipoMovimientos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;


namespace LogicaAplicacion.TiposMovimientos
{
    public class EditarTipoMovimiento : IEditar<TipoMovimientoDto>
    {
        IRepositorioTipoMovimiento _repositorioTipoMovimiento;

        public EditarTipoMovimiento(IRepositorioTipoMovimiento repositorioTipoMovimiento)
        {
            _repositorioTipoMovimiento = repositorioTipoMovimiento;
        }

        public void Ejecutar(int id, TipoMovimientoDto tipoMovimientoDto)
        {
            TipoMovimiento tipoMovimiento = TipoMovimientoMapper.FromDto(tipoMovimientoDto);
            _repositorioTipoMovimiento.Update(id, tipoMovimiento);
        }
    }
}
