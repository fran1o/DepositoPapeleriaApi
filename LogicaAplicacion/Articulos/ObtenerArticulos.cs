using LogicaNegocio.Dtos.Articulos;
using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;

namespace LogicaAplicacion.Articulos
{
    public class ObtenerArticulos : IObtenerTodos<ArticuloDto>
    {
        IRepositorioArticulo _repositorioArticulo;

        public ObtenerArticulos(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }
        public IEnumerable<ArticuloDto> Ejecutar()
        {
            IEnumerable<ArticuloDto> articuloDto = ArticuloMapper.ToListaDto(_repositorioArticulo.GetAll());
            return articuloDto;
        }
    }
}
