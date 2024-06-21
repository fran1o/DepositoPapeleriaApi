﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Articulo
{
    public class StockArticuloInvalidaException : ArticuloException
    {
        public StockArticuloInvalidaException() : base("El stock no puede ser vacio y debe ser mayor a 0") { }
    }
}
