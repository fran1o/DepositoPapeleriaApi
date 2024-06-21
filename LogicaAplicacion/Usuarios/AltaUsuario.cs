using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Dtos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;

namespace LogicaAplicacion.Usuarios
{
    public class AltaUsuario : IAlta<UsuarioDto>
    {
        IRepositorioUsuario _repositorioUsuario;

        public AltaUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void Ejecutar(UsuarioDto usuarioDto)
        {

            Usuario usuario = UsuarioMapper.FromDto(usuarioDto);
            _repositorioUsuario.Add(usuario);

        }
    }
}
