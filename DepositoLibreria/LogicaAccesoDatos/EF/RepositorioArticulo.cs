using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace DepositoLibreria.LogicaAccesoDatos.EF
{
    public class RepositorioArticulo : IRepositorioArticulo
    {
        private LibreriaContext _contex;

        public RepositorioArticulo(LibreriaContext contex)
        {
            _contex = contex;
        }

        public void Add(Articulo obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullRepositorioException();
            }
            if (nameExists(obj.NombreArt))
            {
                throw new ArgumentNullRepositorioException();
            }

            obj.Validar();
            try
            {
                // Es importante que Id venga en 0, podria ponerlo siempre antes de hacer el add
                obj.Id = 0;
                _contex.Articulos.Add(obj);
                _contex.SaveChanges();
            }
            catch (Exception e)
            {
                // logear el problema
                throw new Exception("Hubo un problema intenta en 5");
            }
        }
        private bool nameExists(Nombre name)
        {
            // En esos casos, puede participar de forma explícita en la evaluación de cliente
            // si llamada a métodos como AsEnumerable o ToList(AsAsyncEnumerable o ToListAsync para async).
            // Al usar AsEnumerable se haría streaming de los resultados, pero al usar ToList se almacenarían
            // en búfer mediante la creación de una lista, que también consume memoria adicional.
            // Como si se realizara la enumeración varias veces, el almacenamiento de los resultados en una lista es más útil,
            // ya que solo hay una consulta a la base de datos. En función del uso determinado, debe evaluar qué método
            // es más útil para cada caso.


            Articulo unArticulo = _contex.Articulos
            .AsEnumerable()
            .FirstOrDefault(articulo => articulo.NombreArt.Value.ToLower() == name.Value.ToLower());

            return unArticulo != null;
        }
        public void Delete(int id)
        {
            Articulo articulo = GetById(id);
            if (articulo == null)
            {
                throw new NotFoundException();
            }
            _contex.Articulos.Remove(articulo);
            _contex.SaveChanges();
        }

        public void Update(int id, Articulo obj)
        {

            Articulo articulo = GetById(id);
            if (articulo == null)
            {
                throw new NotFoundException();
            }
            if  (nameExists(obj.NombreArt))
            {
                throw new NombreExisteArticuloInvalidaException();

            }
            articulo.Update(obj);
            _contex.Articulos.Update(articulo);
            _contex.SaveChanges(true);

        }

        public IEnumerable<Articulo> GetAll()
        {
            return _contex.Articulos
                .OrderBy(a => a.NombreArt)
                .ToList();
        }
        public Articulo GetById(int id)
        {
            {
                Articulo articulo = _contex.Articulos.FirstOrDefault(us => us.Id == id);

                if (articulo == null)
                {
                    throw new NotFoundException($"No se encontró el articulo con id {id}");
                }

                return articulo;
            }
        }



        public IEnumerable<Articulo> GetByName(string value)
        {
            return
              _contex.Articulos
              .Include(a => a.NombreArt)
              .AsEnumerable().
              Where(articulo => articulo.NombreArt.Value.ToLower().Contains(value.ToLower()));
        }
    }
}