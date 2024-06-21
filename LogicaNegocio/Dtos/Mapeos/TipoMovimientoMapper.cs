using LogicaNegocio.Dtos.Articulos;
using LogicaNegocio.Dtos.TipoMovimientos;
using LogicaNegocio.Entidades;

namespace LogicaNegocio.Dtos.Mapeos
{
    public class TipoMovimientoMapper
    {

        public static TipoMovimiento FromDto(TipoMovimientoDto tipoMovimientoDto)
        {
            return new TipoMovimiento()
            {
                Id = tipoMovimientoDto.Id,
                Nombre = tipoMovimientoDto.Nombre,
                esIncremento = tipoMovimientoDto.esIncremento
            };
        }
        public static TipoMovimientoDto ToDto(TipoMovimiento tipoMovimiento)
        {
            return new TipoMovimientoDto(
                tipoMovimiento.Id,
                tipoMovimiento.Nombre,
                tipoMovimiento.esIncremento
                );
        }


        public static IEnumerable<TipoMovimientoDto> ToListaDto(IEnumerable<TipoMovimiento> movimientos)
        {
            List<TipoMovimientoDto> aux = new List<TipoMovimientoDto>();
            foreach (var tipoMovimiento in movimientos)
            {
                TipoMovimientoDto tipoMovimienoDto = ToDto(tipoMovimiento);
                aux.Add(tipoMovimienoDto);
            }
            return aux;
        }

    }
}
