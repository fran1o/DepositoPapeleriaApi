
namespace LogicaNegocio.InterfacesServicios
{
    public interface IAgregarElemento<T, E>
    {
        void Ejecutar(T padre, E elemento);
    }
}
