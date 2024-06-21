using LogicaNegocio.Excepciones.Articulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.TipoMov
{
    public class ExisteTipoEnMovException : TipoMovimientoException
    {
        public ExisteTipoEnMovException() : base("El tipo de movimiento esta siendo utilizado") { }
    }
}
