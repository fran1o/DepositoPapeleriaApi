using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Movimientos
{
    public class TipoMovimientoInvalidoException : MovimientoException
    {
        public TipoMovimientoInvalidoException() : base("El tipo de movimiento debe ser uno de los existente") { }
    }
}
