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
    public class ObtenerUsuario : IObtener<UsuarioDto>
    {
        IRepositorioUsuario _repositorioUsuario;

        public ObtenerUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public UsuarioDto Ejecutar(int id)
        {
            Usuario usuario = _repositorioUsuario.GetById(id);
            return UsuarioMapper.ToDto(usuario);
        }
    }
}
