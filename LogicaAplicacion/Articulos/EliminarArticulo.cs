using LogicaNegocio.Dtos.Articulos;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;


namespace LogicaAplicacion.Articulos
{
    public class EliminarArticulo : IEliminar<ArticuloDto>
    {
        IRepositorioArticulo _repositorioArticulo;

        public EliminarArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public void Ejecutar(int id)
        {
            _repositorioArticulo.Delete(id);
        }
    }
}
