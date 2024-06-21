using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Dtos.Movimientos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;

namespace LogicaAplicacion.Movimientos
{
    public class EditarMovimiento : IEditar<MovimientoCRUDDto>
    {
        IRepositorioMovimiento _repositorioMovimiento;

        public EditarMovimiento(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }

        public void Ejecutar(int id, MovimientoCRUDDto movimientoDto)
        {
            _repositorioMovimiento.Update(id, movimientoDto);
        }
    }
}
