using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Articulo
{
    public class NombreExisteArticuloInvalidaException : ArticuloException
    {
        public NombreExisteArticuloInvalidaException() : base("El nombre del articulo ya existe") { }
    }
}
