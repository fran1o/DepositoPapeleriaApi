using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Dtos.Articulos;
using LogicaNegocio.Dtos.Mapeos;
using LogicaNegocio.Dtos.TipoMovimientos;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfacesServicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimientosController : ControllerBase
    {
        IAltaID<TipoMovimientoDto> _altaTipoMovimiento;
        IEditar<TipoMovimientoDto> _editarTipoMovimiento;
        IEliminar<TipoMovimientoDto> _eliminarTipoMovimiento;
        IObtenerTodos<TipoMovimientoDto> _obtenerTipoMovimientos;
        IObtener<TipoMovimientoDto> _obtenerTipoMovimiento;

        public TipoMovimientosController(
            IAltaID<TipoMovimientoDto> altaTipoMovimiento,
            IEditar<TipoMovimientoDto> editarTipoMovimiento,
            IEliminar<TipoMovimientoDto> eliminarTipoMovimiento,
            IObtenerTodos<TipoMovimientoDto> obtenerTipoMovimientos,
            IObtener<TipoMovimientoDto> obtenerTipoMovimiento

            )
        {
            _altaTipoMovimiento = altaTipoMovimiento;
            _editarTipoMovimiento = editarTipoMovimiento;
            _eliminarTipoMovimiento = eliminarTipoMovimiento;
            _obtenerTipoMovimientos = obtenerTipoMovimientos;
            _obtenerTipoMovimiento = obtenerTipoMovimiento;
        }

        /// <summary>
        /// Servicio que permite crear un Tipo de Movimiento
        /// </summary>
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public IActionResult Create(TipoMovimientoDto tipoMovimientoDto)
        {

                
            int _id = _altaTipoMovimiento.Ejecutar(tipoMovimientoDto);
            return CreatedAtAction("GetById", new {id = _id }, _obtenerTipoMovimiento.Ejecutar(_id));
            //Si pongo try catch no funciona
        }


        /// <summary>
        /// Servicio que permite editar un Tipo de Movimiento
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] TipoMovimientoDto tipoMovimientoDto)
        {

            try
            {
                var elemento = _obtenerTipoMovimiento.Ejecutar(id);
                if (elemento == null)
                {
                    return StatusCode(404, "No se encontró el recurso con el ID especificado.");
                }

                _editarTipoMovimiento.Ejecutar(id, tipoMovimientoDto);


                return Ok("Editado correctamente.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error al crear el tipo de movimiento: " + e.Message);
            }
        }

        /// <summary>
        /// Servicio que permite eliminar un Tipo de Movimiento
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var elemento = _obtenerTipoMovimiento.Ejecutar(id);
                if (elemento == null)
                {
                    return StatusCode(404, "No se encontró el recurso con el ID especificado.");
                }

                _eliminarTipoMovimiento.Ejecutar(id);

                return Ok("Recurso eliminado correctamente.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error al eliminar el recurso: " + e.Message);
            }
        }


        /// <summary>
        /// Servicio que brinda todos los Tipos de Movimientos
        /// </summary>
        /// <remarks>
        /// Ejemplo de retorno:
        /// [
        ///{
        ///"id": 1,
        ///"nombre": "Pepito",
        ///"esIncremento": true
        ///},
        ///{
        ///"id": 2,
        ///"nombre": "Venta",
        ///"esIncremento": true
        ///},
        ///{
        ///"id": 3,
        ///"nombre": "Devolución",
        ///"esIncremento": false
        ///}
        ///]
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]

        public IActionResult GetAll()
        {
            try
            {
                return Ok(_obtenerTipoMovimientos.Ejecutar());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Hupp" + e.Message);
            }

        }

        /// <summary>
        /// Servicio que brinda un Tipo de Movimiento por su Id
        /// </summary>
        /// /// <remarks>
        /// Ejemplo de retorno: id = 1
        ///{
        ///"id": 1,
        ///"nombre": "Compra",
        ///"esIncremento": true
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
                return Ok(_obtenerTipoMovimiento.Ejecutar(id));
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
