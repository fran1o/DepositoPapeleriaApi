using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Direccion
{
    public class NumeroInvalidaException : DireccionException
    {

        public NumeroInvalidaException() : base("Debe ingresar un numero de puerta") { }
    }
}
