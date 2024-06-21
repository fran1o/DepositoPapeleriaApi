using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfazRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DepositoLibreria.LogicaAccesoDatos.EF
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private LibreriaContext _contex;

        public RepositorioUsuario(LibreriaContext contex)
        {
            _contex = contex;
        }

        public static string getHashSHA256(string value)
        {
            using var hash = SHA256.Create();
            var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(value));
            return Convert.ToHexString(byteArray);
        }
        public void Add(Usuario obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullRepositorioException();
            }

            obj.Validar();
            try
            {
                obj.Id = 0;
                obj.Password = getHashSHA256(obj.Password);
                _contex.Usuarios.Add(obj);
                _contex.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            

        }

        public void Delete(int id)
        {
            Usuario usuario = GetById(id);
            if (usuario == null)
            {
                throw new NotFoundException();
            }
            _contex.Usuarios.Remove(usuario);
            _contex.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _contex.Usuarios.ToList();

        }

        public Usuario GetById(int id)
        {
            Usuario usuario = _contex.Usuarios.FirstOrDefault(us => us.Id == id);

            if (usuario == null)
            {
                throw new NotFoundException($"No se encontró el usuario con id {id}");
            }

            return usuario;
        }

        public Usuario GetByEmail(string email)
        {
            Usuario usuario = _contex.Usuarios.FirstOrDefault(us => us.Email == email);

            if (usuario == null)
            {
                throw new NotFoundException($"No se encontró el usuario con email {email}");
            }

            return usuario;
        }


        public IEnumerable<Usuario> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Usuario obj)
        {
            Usuario usuario = GetById(id);
            if (usuario == null)
            {
                throw new NotFoundException();
            }
            // Verifico si cambió la password
            if(usuario.Password != obj.Password)
                obj.Password = getHashSHA256(obj.Password);

            usuario.Update(obj);
            _contex.Usuarios.Update(usuario);
            _contex.SaveChanges(true);
        }

        
    }
}
