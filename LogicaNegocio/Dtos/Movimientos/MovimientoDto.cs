using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dtos.Movimientos
{
    public record MovimientoDto(int Id, DateTime Fecha, Articulo Articulo, TipoMovimiento TipoMov, Usuario Usuario, int Cantidad)
    {

    }
}
