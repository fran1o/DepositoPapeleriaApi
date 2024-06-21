using LogicaNegocio.Dtos.Articulos;
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dtos.Mapeos
{
    public class ArticuloMapper
    {
 
        public static Articulo FromDto(ArticuloDto articuloDto)
        {
            return new Articulo()
            {
                Id = articuloDto.Id,
                NombreArt = new Nombre(articuloDto.NombreArt),
                Descripcion = articuloDto.Descripcion,
                Codigo = articuloDto.Codigo,
                Precio = articuloDto.Precio,
                Stock = articuloDto.Stock,
            };
        }
        public static ArticuloDto ToDto(Articulo articulo)
        {
            return new ArticuloDto(
                articulo.Id,
                articulo.NombreArt.Value,
                articulo.Descripcion,
                articulo.Codigo,
                articulo.Precio,
                articulo.Stock
                );
        }

     
        public static IEnumerable<ArticuloDto> ToListaDto(IEnumerable<Articulo> articulos)
        {
            List<ArticuloDto> aux = new List<ArticuloDto>();
            foreach (var articulo in articulos)
            {
                ArticuloDto articuloDto = ToDto(articulo);
                aux.Add(articuloDto);
            }
            return aux;
        }
    }
}
