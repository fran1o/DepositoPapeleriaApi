using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioArticulo : IRepositorio<Articulo>
    {
        public Articulo GetById(int id);
        public IEnumerable<Articulo> GetByName(string name);
    }
}
