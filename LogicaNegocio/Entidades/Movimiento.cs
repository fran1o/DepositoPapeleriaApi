using LogicaNegocio.Excepciones.Movimientos;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Movimiento : IValidable, IEntity
    {
        public int Id { get; set; }
        public DateTime FechaMov { get; set; }
        public Articulo ArticuloMov { get; set; }

        public TipoMovimiento TipoMov {  get; set; }
        public Usuario Usuario { get; set; }

        public int Cantidad { get; set; }

     
        public void Update(Movimiento obj)
        {

            FechaMov = obj.FechaMov;
            ArticuloMov = obj.ArticuloMov;
            TipoMov = obj.TipoMov;
            Usuario = obj.Usuario;
            Cantidad = obj.Cantidad;

        }

        public void Validar()
        {
            ValidarCantidad();
        }

        private void ValidarCantidad()
        {
            
            if (Cantidad <= 0 || Cantidad > ParametrosGenerales.Tope)
            {
                throw new CantidadInvalidaException();
            }
        }
    }
}
