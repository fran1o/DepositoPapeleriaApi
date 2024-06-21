using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuario
{
    public class EmailUsuarioInvalidaException : UsuarioException
    {

        public EmailUsuarioInvalidaException() : base("El email debe ser unico y debe tener el formato habitual") { }
    }
}
