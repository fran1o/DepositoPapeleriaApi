
using LogicaNegocio.Entidades;

namespace LogicaNegocio.IntefazServicios
{
    public interface IObtenerFiltroDobleString<T>
    {
        public PaginationRetorno<T> Ejecutar(string primerValor, string segundoValor, int page = 0);
    }
}
