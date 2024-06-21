using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Dtos.Articulos;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;


namespace LogicaAplicacion.Articulos
{
    public class ObtenerArticuloByName : IObtenerByString<ArticuloDto>
    {
        IRepositorioArticulo _repositorioArticulo;

        public ObtenerArticuloByName(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public IEnumerable<ArticuloDto> Ejecutar(string value)
        {
            IEnumerable<ArticuloDto> autoresDto = ArticuloMapper.ToListaDto(_repositorioArticulo.GetByName(value));
            return autoresDto;
        }
    }
}
