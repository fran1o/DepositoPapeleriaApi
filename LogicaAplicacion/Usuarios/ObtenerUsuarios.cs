using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Dtos.Usuarios;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.InterfazRepositorio;


namespace LogicaAplicacion.Usuarios
{
    public class ObtenerUsuarios : IObtenerTodos<UsuarioDto>
    {
        IRepositorioUsuario _repositorioUsuario;

        public ObtenerUsuarios(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        IEnumerable<UsuarioDto> IObtenerTodos<UsuarioDto>.Ejecutar()
        {
            IEnumerable<UsuarioDto> usuariosDto = UsuarioMapper.ToListaDto(_repositorioUsuario.GetAll());
            return usuariosDto;
        }
    }
}
