using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class NombreException : DomainException
    {
        public NombreException() { }
        public NombreException(string message) : base(message) { }
    }
}
