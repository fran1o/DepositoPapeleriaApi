using LogicaNegocio.Dtos.Articulos;
using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfacesRepositorio;


namespace LogicaAplicacion.Articulos
{
    public class AltaArticulo : IAlta<ArticuloDto>
    {

        IRepositorioArticulo _repositorioArticulo;

        public AltaArticulo(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public void Ejecutar(ArticuloDto articuloDto)
        {
            Articulo articulo = ArticuloMapper.FromDto(articuloDto);
            _repositorioArticulo.Add(articulo);
        }
    }
}
