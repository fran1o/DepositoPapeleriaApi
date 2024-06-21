using LogicaNegocio.Dtos.Articulos;
using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Dtos.TipoMovimientos;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.TiposMovimientos
{
    public class ObtenerTipoMovimiento : IObtener<TipoMovimientoDto>
    {
        IRepositorioTipoMovimiento _repositorioTipoMovimiento;

        public ObtenerTipoMovimiento(IRepositorioTipoMovimiento repositorioTipoMovimiento)
        {
            _repositorioTipoMovimiento = repositorioTipoMovimiento;
        }
        public TipoMovimientoDto Ejecutar(int id)
        {
            TipoMovimiento tipoMovimiento = _repositorioTipoMovimiento.GetById(id);
            return TipoMovimientoMapper.ToDto(tipoMovimiento);
        }
    }
}
