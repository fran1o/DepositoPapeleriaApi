using LogicaNegocio.Dtos.Usuarios;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.InterfazRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Usuarios
{
    public class EliminarUsuario : IEliminar<UsuarioDto>
    {
        IRepositorioUsuario _repositorioUsuario;

        public EliminarUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public void Ejecutar(int id)
        {
            _repositorioUsuario.Delete(id);
        }
    }
}
