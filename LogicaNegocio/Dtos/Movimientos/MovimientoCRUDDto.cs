using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dtos.Movimientos
{
    public class MovimientoCRUDDto
    {

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ArticuloId { get; set; }
        public int TipoMovId { get; set; }
        public int UsuarioId { get; set; }

        public int Cantidad { get; set; }
    }
}
