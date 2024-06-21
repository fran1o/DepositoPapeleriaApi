using LogicaNegocio.Dtos.Movimientos;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.Movimientos
{
    public class ObtenerCantidadMovimiento: ICantidadTotal
    {

        IRepositorioMovimiento _repositorioMovimiento;

        public ObtenerCantidadMovimiento(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }

        public int Ejecutar()
        {
            return _repositorioMovimiento.GetCantidad();
        }

    }
}
