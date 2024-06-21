using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Dtos.Movimientos;
using LogicaNegocio.Dtos.TipoMovimientos;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Movimientos
{
    public class ObtenerMovimientos : IObtenerTodos<MovimientoDto>
    {
        IRepositorioMovimiento _repositorioMovimiento;

        public ObtenerMovimientos(IRepositorioMovimiento repositorioMovimiento)
        {
            _repositorioMovimiento = repositorioMovimiento;
        }
        public IEnumerable<MovimientoDto> Ejecutar()
        {
            IEnumerable<MovimientoDto> movimientoDto = MovimientoMapper.ToListaDto(_repositorioMovimiento.GetAll());
            return movimientoDto;
        }
    }
}
