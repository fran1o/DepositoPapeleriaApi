using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Dtos.Movimientos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Movimientos
{
    public class ObtenerMovimientoByPage : IObtenerByNumber<MovimientoDto>
    {

            IRepositorioMovimiento _repositorioMovimiento;

            public ObtenerMovimientoByPage(IRepositorioMovimiento repositorioMovimiento)
            {
                _repositorioMovimiento = repositorioMovimiento;
            }
            public IEnumerable<MovimientoDto> Ejecutar(int page)
            {
                IEnumerable<MovimientoDto> movsDto = MovimientoMapper.ToListaDto(_repositorioMovimiento.GetAll(page));
                return movsDto;
            }

    }
}
