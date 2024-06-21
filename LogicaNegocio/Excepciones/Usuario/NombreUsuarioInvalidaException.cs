using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuario
{
    public class NombreUsuarioInvalidaException : UsuarioException
    {
        public NombreUsuarioInvalidaException() : base("El nombre del usuario debe tener: caracteres alfabéticos, espacio, apóstrofe o guión del medio. Los caracteres no alfabéticos no pueden estar ubicados al principio ni al final de la cadena.") { }
    }
}
