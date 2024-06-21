using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.InterfazRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Usuarios
{
    public class ObtenerUsuarioByEmail : IObtenerByEmail
    {
        IRepositorioUsuario _repositorioUsuario;

        public ObtenerUsuarioByEmail(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public Usuario Ejecutar(string email)
        {
            Usuario usuario = _repositorioUsuario.GetByEmail(email);
            return usuario;
        }
    }
}
