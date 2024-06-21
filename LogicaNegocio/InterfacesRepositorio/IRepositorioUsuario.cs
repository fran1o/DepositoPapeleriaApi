using LogicaNegocio.Entidades;

namespace LogicaNegocio.InterfazRepositorio
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        public IEnumerable<Usuario> GetByName(string name);
        public Usuario GetByEmail(string email);
    }
}
