using LogicaNegocio.Dtos.Articulos;
using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Dtos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfacesServicios;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        IAlta<UsuarioDto> _altaUsuario;
        IEditar<UsuarioDto> _editarUsuario;
        IEliminar<UsuarioDto> _eliminarUsuario;
        IObtenerTodos<UsuarioDto> _obtenerUsuarios;
        IObtener<UsuarioDto> _obtenerUsuario;
        IObtenerByEmail _obtenerUsuarioByEmail;

        public UsuariosController(
            IAlta<UsuarioDto> altaUsuario,
            IEditar<UsuarioDto> editarUsuario,
            IEliminar<UsuarioDto> eliminarUsuario,
            IObtenerTodos<UsuarioDto> obtenerUsuarios,
            IObtener<UsuarioDto> obtenerUsuario,
            IObtenerByEmail obtenerByEmail

            )
        {
            _altaUsuario = altaUsuario;
            _editarUsuario = editarUsuario;
            _eliminarUsuario = eliminarUsuario;
            _obtenerUsuarios = obtenerUsuarios;
            _obtenerUsuario = obtenerUsuario;
            _obtenerUsuarioByEmail = obtenerByEmail;
        }

        [HttpPost]
        public IActionResult ObtenerToken(CredencialesUsuarioDto credenciales)
        {
            string Email = credenciales.Email;
            string Password = credenciales.Password;

            if(Email == null || Password == null)
            {
                return StatusCode(403, "Debe completar email y password");
            }

            Usuario user = _obtenerUsuarioByEmail.Ejecutar(Email);
            if(user == null)
            {
                return StatusCode(403, "Email o contraseña invalida");
            }

            if(!user.Password.Equals(getHashSHA256(Password))) 
            {
                return StatusCode(403, "Email o contraseña invalida");
            }

            var token = ManejadorJwt.GenerarToken(user);
            return Ok(token);

        }

        public static string getHashSHA256(string value)
        {
            using var hash = SHA256.Create();
            var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(value));
            return Convert.ToHexString(byteArray);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_obtenerUsuarios.Ejecutar());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Hupp" + e.Message);
            }

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_obtenerUsuario.Ejecutar(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Hupp" + e.Message);
            }
        }
    }
}
