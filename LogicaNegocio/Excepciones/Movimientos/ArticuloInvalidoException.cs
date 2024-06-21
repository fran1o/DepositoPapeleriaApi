using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Movimientos
{
    public class ArticuloInvalidoException : MovimientoException
    {
        public ArticuloInvalidoException() : base("El articulo debe existir en la base de datos") { }
    }
}
