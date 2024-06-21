using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Movimientos
{
    public class UsuarioInvalidoException : MovimientoException
    {

        public UsuarioInvalidoException() : base("El usuario debe existir en nuestra base de datos y ademas debe ser encargado") { }
    }
}
