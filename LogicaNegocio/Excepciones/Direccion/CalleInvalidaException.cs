using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Direccion
{
    public class CalleInvalidaException : DireccionException
    {
        public CalleInvalidaException() : base("Debe ingresar el nombre de su calle") { }
    }
}
