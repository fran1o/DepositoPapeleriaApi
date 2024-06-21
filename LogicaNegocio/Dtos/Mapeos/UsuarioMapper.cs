using LogicaNegocio.Dtos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dtos.Mapeos
{
    public class UsuarioMapper
    {

        public static Usuario FromDto(UsuarioDto usuarioDto)
        {
            return new Usuario()
            {
                Nombre = new Nombre(usuarioDto.Nombre),
                Apellido = usuarioDto.Apellido,
                Email = usuarioDto.Email,
                Password = usuarioDto.Password,
                Discriminator = "User",
                
            };


        }

        public static UsuarioDto ToDto(Usuario usuario)
        {
            return new UsuarioDto(
                usuario.Id,
                usuario.Nombre.Value,
                usuario.Apellido,
                usuario.Email,
                usuario.Password,
                usuario.Discriminator
                );
        }

        public static IEnumerable<UsuarioDto> ToListaDto(IEnumerable<Usuario> usuarios)
        {
            List<UsuarioDto> aux = new List<UsuarioDto>();
            foreach (var usuario in usuarios)
            {
                UsuarioDto usuarioDto = ToDto(usuario);
                aux.Add(usuarioDto);
            }
            return aux;
        }
    }
}
