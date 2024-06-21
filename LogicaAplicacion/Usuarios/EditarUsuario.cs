using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Dtos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.InterfazRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Usuarios
{
    public class EditarUsuario : IEditar<UsuarioDto>
    {
        IRepositorioUsuario _repositorioUsuario;

        public EditarUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void Ejecutar(int id, UsuarioDto usuarioDto)
        {
            Usuario usuario = UsuarioMapper.FromDto(usuarioDto);
            _repositorioUsuario.Update(id, usuario);
        }
    }
}
