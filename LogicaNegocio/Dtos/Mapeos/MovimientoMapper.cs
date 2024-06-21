using LogicaNegocio.Dtos.Articulos;
using LogicaNegocio.Dtos.Movimientos;
using LogicaNegocio.Dtos.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dtos.Mapeos
{
    public class MovimientoMapper
    {

        public static Movimiento FromDto(MovimientoDto movimientoDto)
        {
            return new Movimiento()
            {
                Id = movimientoDto.Id,
                FechaMov = movimientoDto.Fecha,
                ArticuloMov = movimientoDto.Articulo,
                TipoMov = movimientoDto.TipoMov,
                Usuario = movimientoDto.Usuario,
                Cantidad = movimientoDto.Cantidad,
            };
        }
        public static MovimientoDto ToDto(Movimiento mov)
        {
            return new MovimientoDto(
                mov.Id,
                mov.FechaMov,
                mov.ArticuloMov,
                mov.TipoMov,
                mov.Usuario,
                mov.Cantidad
                );
        }

        public static IEnumerable<MovimientoDto> ToListaDto(IEnumerable<Movimiento> movimientos)
        {
            List<MovimientoDto> aux = new List<MovimientoDto>();
            foreach (var mov in movimientos)
            {
                MovimientoDto movDto = ToDto(mov);
                aux.Add(movDto);
            }
            return aux;
        }
    }
}
