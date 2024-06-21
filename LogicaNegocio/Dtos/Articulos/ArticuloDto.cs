
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dtos.Articulos
{
    public record ArticuloDto(int Id, string NombreArt, string Descripcion, long Codigo, double Precio, int Stock)
    {
  
    }
}
