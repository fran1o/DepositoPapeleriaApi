using LogicaNegocio.Dtos.Movimientos;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.Movimientos
{
    public class ObtenerCantidadMovimientos: IObtenerTodos<string>
    {

        IRepositorioMovimiento _repositorioMovimiento;

        public ObtenerCantidadMovimientos(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }

        public IEnumerable<string> Ejecutar()
        {
            return _repositorioMovimiento.GetCantidades();
        }

    }
}
