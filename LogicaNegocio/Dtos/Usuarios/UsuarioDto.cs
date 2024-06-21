using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dtos.Usuarios
{
    public record UsuarioDto(int Id, string Nombre, string Apellido, string Email, string Password, string Discriminator)
    {
    }
}
