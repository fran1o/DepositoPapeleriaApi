using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Direccion
{
    public class DistanciaKmInvalidaException : DireccionException
    {
        public DistanciaKmInvalidaException() : base("Debe ingresar una distancia aproximada") { }
    }
}
