using LogicaNegocio.Dtos.Movimientos;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;

namespace LogicaAplicacion.Movimientos
{
    public class EliminarMovimiento : IEliminar<MovimientoDto>
    {
        IRepositorioMovimiento _repositorioMovimiento;

        public EliminarMovimiento(IRepositorioMovimiento repoitorioMovimiento)
        {
            _repositorioMovimiento = repoitorioMovimiento;
        }

        public void Ejecutar(int id)
        {
            _repositorioMovimiento.Delete(id);
        }
    }
}
