using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Direccion
{
    public class CiudadInvalidaException : DireccionException
    {

        public CiudadInvalidaException() : base("Debe ingresar su ciudad") { }
    }
}
