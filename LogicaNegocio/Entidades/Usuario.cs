using LogicaNegocio.Excepciones.Usuario;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects;
using System.Text.RegularExpressions;

namespace LogicaNegocio.Entidades
{
    public class Usuario : IValidable, IEntity
    {

        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
     
        public string Discriminator { get; set; }
        public void Validar()
        {
            ValidarNombre();
            ValidarApellido();
            ValidarEmail();
            ValidarPassword();
        }


        private void ValidarNombre()
        {
            if (!Regex.IsMatch(Nombre.Value, @"^[a-zA-Z]+[a-zA-Z\s'-]*[a-zA-Z]$"))
            {
                throw new NombreUsuarioInvalidaException();
            }
        }

        private void ValidarApellido()
        {
            if (!Regex.IsMatch(Apellido, @"^[a-zA-Z]+[a-zA-Z\s'-]*[a-zA-Z]$"))
            {
                throw new ApellidoUsuarioInvalidaException();
            }
        }

        private void ValidarEmail()
        {
            if(!Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                throw new EmailUsuarioInvalidaException();
            }
            

        }


        private void ValidarPassword()
        {
            if (Password.Length < 6)
            {
                throw new PasswordUsuarioInvalidaException();
            }

            // Verificar al menos una letra mayúscula
            if (!Regex.IsMatch(Password, "[A-Z]"))
            {
                throw new PasswordUsuarioInvalidaException();
            }

            // Verificar al menos una letra minúscula
            if (!Regex.IsMatch(Password, "[a-z]"))
            {
                throw new PasswordUsuarioInvalidaException();
            }

            // Verificar al menos un dígito
            if (!Regex.IsMatch(Password, "\\d"))
            {
                throw new PasswordUsuarioInvalidaException();
            }

            // Verificar al menos un carácter de puntuación: .,;!
            if (!Regex.IsMatch(Password, "[.,;!]"))
            {
                throw new PasswordUsuarioInvalidaException();
            }
        }
        public bool Equals(Usuario other)
        {
            return Id.Equals(other.Id);
        }

        public override string ToString()
        {
            return $"{this.Nombre} {this.Apellido}";
        }


        public void Update(Usuario obj)
        {
            obj.Validar();
            Nombre = obj.Nombre;
            Apellido = obj.Apellido;
            Password = obj.Password;    
        }
    }
}
