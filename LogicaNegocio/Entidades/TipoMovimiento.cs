using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class TipoMovimiento : IValidable, IEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool esIncremento { get; set; }
        
        public void Validar()
        {
            throw new NotImplementedException();
        }

        public void Update(TipoMovimiento obj)
        {

            Nombre = obj.Nombre;
            esIncremento = obj.esIncremento;
        }
    }
}
