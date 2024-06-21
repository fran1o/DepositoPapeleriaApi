
namespace LogicaNegocio.InterfacesServicios
{
    public interface IObtenerByNumber<T> 
    {
        public IEnumerable<T> Ejecutar(int value);
    }
}

