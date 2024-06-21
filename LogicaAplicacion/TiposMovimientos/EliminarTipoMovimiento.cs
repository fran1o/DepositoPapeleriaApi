using LogicaNegocio.Dtos.Articulos;
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
    public class EliminarTipoMovimiento : IEliminar<TipoMovimientoDto>
    {
        IRepositorioTipoMovimiento _repositorioTipoMovimiento;

        public EliminarTipoMovimiento(IRepositorioTipoMovimiento repositorioTipoMovimiento)
        {
            _repositorioTipoMovimiento = repositorioTipoMovimiento;
        }

        public void Ejecutar(int id)
        {
            _repositorioTipoMovimiento.Delete(id);
        }
    }
}
