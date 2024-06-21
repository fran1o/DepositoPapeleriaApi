using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuario
{
    public class PasswordUsuarioInvalidaException : UsuarioException
    {
        public PasswordUsuarioInvalidaException() : base("La contraseña debe tener un largo minimo de 6, una letra mayúscula, una minúscula, un dígito y un carácter de puntuación y signo de admiración de cierre.") { }
    }
}