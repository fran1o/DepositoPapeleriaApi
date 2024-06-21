using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Dtos.Articulos;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfacesServicios;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        IAlta<ArticuloDto> _altaArticulo;
        IEditar<ArticuloDto> _editarArticulo;
        IEliminar<ArticuloDto> _eliminarArticulo;
        IObtenerTodos<ArticuloDto> _obtenerArticulos;
        IObtener<ArticuloDto> _obtenerArticulo;

        public ArticulosController(
            IAlta<ArticuloDto> altaArticulo,
            IEditar<ArticuloDto> editarArticulo,
            IEliminar<ArticuloDto> eliminarArticulo,
            IObtenerTodos<ArticuloDto> obtenerArticulos,
            IObtener<ArticuloDto> obtenerArticulo

            )
        {
            _altaArticulo = altaArticulo;
            _editarArticulo = editarArticulo;
            _eliminarArticulo = eliminarArticulo;
            _obtenerArticulos = obtenerArticulos;
            _obtenerArticulo = obtenerArticulo;
        }

        /// <summary>
        /// Servicio que brinda todos los Articulos
        /// </summary>
        /// <remarks>
        /// Ejemplo de retorno:
        ///{
        ///"id": 4,
        ///"nombreArt": "Bolígrafo Gel",
        ///"descripcion": "Bolígrafo de tinta gel de varios colores",
        ///"codigo": 246810,
        ///"precio": 1.29,
        ///"stock": 300
        ///},
        /// {
        ///"id": 10,
        ///"nombreArt": "Cinta Adhesiva",
        ///"descripcion": "Rollo de cinta adhesiva transparente de 3/4 pulgada",
        ///"codigo": 951753,
        ///"precio": 2.29,
        ///"stock": 300
        ///},
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_obtenerArticulos.Ejecutar());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Hupp" + e.Message);
            }

        }


        /// <summary>
        /// Servicio que brinda un Articulo por su Id 
        /// </summary>
        /// <remarks>
        /// Ejemplo de retorno: id = 4
        ///{
        ///"id": 4,
        ///"nombreArt": "Bolígrafo Gel",
        ///"descripcion": "Bolígrafo de tinta gel de varios colores",
        ///"codigo": 246810,
        ///"precio": 1.29,
        ///"stock": 300
        ///}
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_obtenerArticulo.Ejecutar(id));
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Hupp" + e.Message);
            }
        }

    }
}

