using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Articulo
{
    public class NombreArticuloInvalidaException : ArticuloException
    {
        public NombreArticuloInvalidaException() : base("El nombre no puede ser vacio, no puede estar anteriormente registrado y debe ser mayor a 3 caracteres") { }
    }
}
