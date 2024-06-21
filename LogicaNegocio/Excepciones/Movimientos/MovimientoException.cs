using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Movimientos
{
    public class MovimientoException : DomainException
    {
        public MovimientoException() { }

        public MovimientoException(string message) : base(message) { }
    }
}
