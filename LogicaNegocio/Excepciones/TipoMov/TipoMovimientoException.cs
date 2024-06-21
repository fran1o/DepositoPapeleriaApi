using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.TipoMov
{
    public class TipoMovimientoException : DomainException
    {
        public TipoMovimientoException() { }

        public TipoMovimientoException(string message) : base(message) { }
    }
}
