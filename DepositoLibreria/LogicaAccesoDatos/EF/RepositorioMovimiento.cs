using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Dtos.Movimientos;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Movimientos;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.InterfazRepositorio;
using Microsoft.EntityFrameworkCore;


namespace DepositoLibreria.LogicaAccesoDatos.EF
{
    public class RepositorioMovimiento : IRepositorioMovimiento
    {

        public LibreriaContext _contex;

        public RepositorioMovimiento(LibreriaContext contex)
        {
            _contex = contex;
        }

        public void Add(MovimientoCRUDDto obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullRepositorioException();
            }

            Articulo art = _contex.Articulos.Find(obj.ArticuloId);
            TipoMovimiento tipoMov = _contex.TiposMovimientos.Find(obj.TipoMovId);
            Usuario usuario = _contex.Usuarios.Find(obj.UsuarioId);

            if (art == null)
            {
                throw new ArticuloInvalidoException();
            }

            if (tipoMov == null)
            {
                throw new TipoMovimientoInvalidoException();
            }

            if (usuario == null || usuario.Discriminator != "Encargado")
            {
                throw new UsuarioInvalidoException();
            }

            Movimiento movimiento = new Movimiento();
            movimiento.Id = 0;
            movimiento.FechaMov = obj.Fecha;
            movimiento.ArticuloMov = art;
            movimiento.TipoMov = tipoMov;
            movimiento.Usuario = usuario;
            movimiento.Cantidad = obj.Cantidad;

            movimiento.Validar();

            try
            {
                _contex.Movimientos.Add(movimiento);
                _contex.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Add(Movimiento obj)
        {
            throw new NotImplementedException();
        }


        public void Delete(int id)
        {
            Movimiento mov = GetById(id);
            if (mov == null)
            {
                throw new NotFoundException();
            }
            _contex.Movimientos.Remove(mov);
            _contex.SaveChanges();
        }

        public IEnumerable<Movimiento> GetAll()
        {
            return _contex.Movimientos.Include(m => m.ArticuloMov).Include(m => m.TipoMov).Include(m => m.Usuario).ToList();
        }

        public IEnumerable<Movimiento> GetAll(int page = 0)
        {

            return _contex.Movimientos.Include(m => m.ArticuloMov)
                                      .Include(m => m.TipoMov)
                                      .Include(m => m.Usuario).
                                      AsEnumerable().
                                      Skip(page * ParametrosGenerales.pageSize).
                                      Take(ParametrosGenerales.pageSize).
                                      ToList();
        }
        public Movimiento GetById(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            Console.WriteLine($"Buscando movimiento con ID: {id}");

            Movimiento mov = _contex.Movimientos
                    .Include(m => m.ArticuloMov)
                    .Include(m => m.TipoMov)
                    .Include(m => m.Usuario)
                    .FirstOrDefault(m => m.Id == id);


            if (mov == null)
            {
                throw new NotFoundException("No se encontró el movimiento con el id solicitado");
            }

            return mov;

        }

        public void Update(int id, MovimientoCRUDDto obj)
        {
            Movimiento mov = GetById(id);
            if (mov == null)
            {
                throw new NotFoundException();
            }
            Articulo art = _contex.Articulos.Find(obj.ArticuloId); ;
            TipoMovimiento tipoMov = _contex.TiposMovimientos.Find(obj.TipoMovId);
            Usuario usuario = _contex.Usuarios.Find(obj.UsuarioId);

            if (art == null)
            {
                throw new ArticuloInvalidoException();
            }

            if (tipoMov == null)
            {
                throw new TipoMovimientoInvalidoException();
            }

            if (usuario == null || usuario.Discriminator != "Encargado")
            {
                throw new UsuarioInvalidoException();
            }

            Movimiento movimiento = new Movimiento();
            movimiento.Id = 0;
            movimiento.FechaMov = obj.Fecha;
            movimiento.ArticuloMov = art;
            movimiento.TipoMov = tipoMov;
            movimiento.Usuario = usuario;
            movimiento.Cantidad = obj.Cantidad;

            movimiento.Validar();
            mov.Update(movimiento);
            _contex.Movimientos.Update(mov);
            _contex.SaveChanges(true);
        }


        public IEnumerable<string> GetCantidades(){
            var resumenMovimientos = _contex.Movimientos
                .GroupBy(m => new { Año = m.FechaMov.Year, Tipo = m.TipoMov.Nombre })
                .Select(g => new
                {
                    Año = g.Key.Año,
                    Tipo = g.Key.Tipo,
                    Cantidad = g.Sum(m => m.Cantidad)
                })
                .ToList();

            var resumenPorAño = resumenMovimientos
                .GroupBy(r => r.Año)
                .Select(g => new
                {
                    Año = g.Key,
                    Tipos = g.Select(t => new { t.Tipo, t.Cantidad }).ToList(),
                    TotalAño = g.Sum(t => t.Cantidad)
                })
                .ToList();

            List<string> retorno = new List<string>();
            foreach (var año in resumenPorAño)
            {
                retorno.Add($"Año: {año.Año}");
                foreach (var tipo in año.Tipos)
                {
                    retorno.Add($"Tipo: {tipo.Tipo} – Cantidad: {tipo.Cantidad}");
                }
                retorno.Add($"Total año {año.Año} : {año.TotalAño}");
            }

            return retorno;
        }

        public int GetCantidad()
        {
            return _contex.Movimientos.Count();
        }

        public PaginationRetorno<Articulo> GetArticulosPorFechas(DateTime desde, DateTime hasta, int page)
        {
            var articulos = _contex.Movimientos.Include(m => m.ArticuloMov)
                                     .Where(m => m.FechaMov >= desde && m.FechaMov <= hasta)
                                     .Select(m => m.ArticuloMov)
                                     .Distinct();
            var cantidadTotal = articulos.Count();
            var articulosFiltrados = articulos
                                        .AsEnumerable()
                                      .Skip(page * ParametrosGenerales.pageSize)
                                      .Take(ParametrosGenerales.pageSize)
                                      .ToList();
            
            PaginationRetorno<Articulo> retorno = new PaginationRetorno<Articulo>();
            retorno.cantidadTotal = cantidadTotal;
            retorno.elementos = articulosFiltrados;

            return retorno;
        }

        public PaginationRetorno<Movimiento> GetMovimientosPorArticuloYTipo(string articuloId, string tipoMovimiento, int page)
        {
            int articulo = int.Parse(articuloId);
            var movimientos = _contex.Movimientos
                .Include(m => m.ArticuloMov)
                .Include(m => m.TipoMov)
                .Include(m => m.Usuario)
                .Where(m => m.ArticuloMov.Id == articulo && m.TipoMov.Nombre == tipoMovimiento)
                .OrderByDescending(m => m.FechaMov)
                .ThenBy(m => m.Cantidad);
            var cantidadTotal = movimientos.Count();
            var filterMovimientos = movimientos
                .AsEnumerable()
                .Skip(page * ParametrosGenerales.pageSize)
                .Take(ParametrosGenerales.pageSize)
                .ToList();
            PaginationRetorno<Movimiento> retorno = new PaginationRetorno<Movimiento>();
            retorno.cantidadTotal = cantidadTotal;
            retorno.elementos = filterMovimientos;
            
            return retorno;
        }

        public void Update(int id, Movimiento obj)
        {
            throw new NotImplementedException();
        }
    }
}
