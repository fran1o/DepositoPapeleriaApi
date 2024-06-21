using LogicaNegocio.Dtos.Articulos;
using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;


namespace LogicaAplicacion.Articulos
{
    public class ObtenerArticulo : IObtener<ArticuloDto>
    {
        IRepositorioArticulo _repositorioArticulo;

        public ObtenerArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }
        public ArticuloDto Ejecutar(int id)
        {
            Articulo articulo = _repositorioArticulo.GetById(id);
            return ArticuloMapper.ToDto(articulo);
        }
    }
}
