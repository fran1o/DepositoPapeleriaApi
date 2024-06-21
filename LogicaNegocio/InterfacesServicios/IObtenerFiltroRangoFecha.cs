
using LogicaNegocio.Entidades;

namespace LogicaNegocio.IntefazServicios
{
    public interface IObtenerRangoFecha <T>
    {
        public PaginationRetorno<T> Ejecutar(DateTime desde, DateTime hasta, int page = 0);
    }
}
