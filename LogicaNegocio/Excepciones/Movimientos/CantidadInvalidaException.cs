using LogicaNegocio.Excepciones.Articulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Movimientos
{
    public class CantidadInvalidaException : MovimientoException
    {
        public CantidadInvalidaException() : base("La cantidad debe ser mayor a 0") { }
    }
}
