using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.TipoMov;
using LogicaNegocio.InterfacesRepositorio;


namespace DepositoLibreria.LogicaAccesoDatos.EF
{
    public class RepositorioTipoMovimiento : IRepositorioTipoMovimiento
    {

        public LibreriaContext _contex;

        public RepositorioTipoMovimiento(LibreriaContext contex)
        {
            _contex = contex;
        }

        public void Add(TipoMovimiento obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullRepositorioException();
            }
            //saco el validar para que funcione porque el validar no esta implementado
            try
            {
                obj.Id = 0;
                _contex.TiposMovimientos.Add(obj);
                _contex.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            TipoMovimiento tipoMov = GetById(id);
            if (tipoMov == null)
            {
                throw new NotFoundException();
            }

            if (existeTipoEnMov(id))
            {
                throw new ExisteTipoEnMovException();

            }
            _contex.TiposMovimientos.Remove(tipoMov);
            _contex.SaveChanges();
        }

        public IEnumerable<TipoMovimiento> GetAll()
        {
            return _contex.TiposMovimientos.ToList();
        }

        public TipoMovimiento GetById(int id)
        {
            if(id == null)
            {
                throw new ArgumentNullException();
            }

            TipoMovimiento tipoMov = _contex.TiposMovimientos.FirstOrDefault(tipo => tipo.Id == id);

            if(tipoMov == null)
            {
                throw new NotFoundException();
            }

            return tipoMov;
            
        }

        private bool existeTipoEnMov(int id)
        {
            bool existe = false;
            Movimiento mov = _contex.Movimientos.FirstOrDefault(mov => mov.TipoMov.Id == id);
            if(mov != null)
            {
                existe = true;
            }

            return existe;
        }
        public void Update(int id, TipoMovimiento obj)
        {
            TipoMovimiento tipoMov = GetById(id);
            if (tipoMov == null)
            {
                throw new NotFoundException();
            }
            if (existeTipoEnMov(id))
            {
                throw new ExisteTipoEnMovException();

            }
            tipoMov.Update(obj);
            _contex.TiposMovimientos.Update(tipoMov);
            _contex.SaveChanges(true);
        }

    }
}
