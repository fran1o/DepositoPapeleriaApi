using LogicaNegocio.Dtos.Articulos;
using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;


namespace LogicaAplicacion.Articulos
{
    public class EditarArticulo : IEditar<ArticuloDto>
    {
        IRepositorioArticulo _repositorioArticulo;

        public EditarArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public void Ejecutar(int id, ArticuloDto articuloDto)
        {
            Articulo articulo = ArticuloMapper.FromDto(articuloDto);
            _repositorioArticulo.Update(id, articulo);
        }
    }
}
