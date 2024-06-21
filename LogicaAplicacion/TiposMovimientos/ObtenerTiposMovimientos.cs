using LogicaNegocio.Dtos.Articulos;
using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Dtos.TipoMovimientos;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.TiposMovimientos
{
    public class ObtenerTiposMovimientos : IObtenerTodos<TipoMovimientoDto>
    {
        IRepositorioTipoMovimiento _repositorioTipoMovimiento;

        public ObtenerTiposMovimientos(IRepositorioTipoMovimiento repositorioTipoMovimiento)
        {
            _repositorioTipoMovimiento = repositorioTipoMovimiento;
        }
        public IEnumerable<TipoMovimientoDto> Ejecutar()
        {
            IEnumerable<TipoMovimientoDto> tipoMovimientoDto = TipoMovimientoMapper.ToListaDto(_repositorioTipoMovimiento.GetAll());
            return tipoMovimientoDto;
        }
    }
}
