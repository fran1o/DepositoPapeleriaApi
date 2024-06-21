using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Articulo
{
    public class DscArticuloInvalidaException : ArticuloException
    {
        public DscArticuloInvalidaException() : base("La descripcion debe tener minimo 5 caracteres") { }
    }
}
