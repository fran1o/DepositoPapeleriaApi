using LogicaNegocio.Excepciones.Articulo;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;

namespace LogicaNegocio.Entidades
{
    public class Articulo : IValidable, IEntity
    {
        public int Id { get; set; }
        public Nombre NombreArt { get; set; }
        public string Descripcion { get; set; }
        public long Codigo { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public void Validar()
        {
            ValidarNombreArt();
            ValidarDescripcion();
            ValidarCodigo();
            ValidarPrecio();
            ValidarStock();

        }

        private void ValidarNombreArt()
        {
            if (NombreArt.Value == null || NombreArt.Value.Length < 3 || NombreArt.Value.Length > 200)
            {
                throw new NombreArticuloInvalidaException();
            }

            // VERIFICAR QUE NO EXISTA UN ARTICULO CON EL MISMO CODIGO
        }

        private void ValidarDescripcion()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new DscArticuloInvalidaException();
            }
        }

        private void ValidarCodigo()
        {
            string codigo = Codigo.ToString();

            if (codigo.Length != 13)
            {
                throw new CodigoArticuloInvalidaException();
            }

            // VERIFICAR QUE NO EXISTA UN ARTICULO CON EL MISMO CODIGO
        }

        private void ValidarPrecio()
        {
            if (string.IsNullOrEmpty(Precio.ToString()) || Precio <= 0)
            {
                throw new PrecioArticuloInvalidaException();
            }
        }

        private void ValidarStock()
        {
            if (string.IsNullOrEmpty(Stock.ToString()) || Stock == 0)
            {
                throw new StockArticuloInvalidaException();
            }
        }
        public void Update(Articulo obj)
        {
            obj.Validar();
            NombreArt = obj.NombreArt;
            Descripcion = obj.Descripcion;
            Codigo = obj.Codigo;
            Precio = obj.Precio;
            Stock = obj.Stock;
        }

    }
}
