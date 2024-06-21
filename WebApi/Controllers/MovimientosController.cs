
using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaAplicacion.Movimientos;
using LogicaNegocio.Dtos.Movimientos;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Movimientos;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfacesServicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        IAltaID<MovimientoCRUDDto> _altaMovimiento;
        IEditar<MovimientoCRUDDto> _editarMovimiento;
        IEliminar<MovimientoDto> _eliminarMovimiento;
        IObtenerTodos<MovimientoDto> _obtenerMovimientos;
        IObtener<MovimientoDto> _obtenerMovimiento;
        IObtenerByNumber<MovimientoDto> _obtenerMovimientoByPage;
        ICantidadTotal _obtenerCantidadMovimiento;
        IObtenerTodos<string> _obtenerCantidadesMovimientos;
        IObtenerFiltroDobleString<MovimientoDto> _obtenerMovimientosPorArticuloYTipo;
        IObtenerRangoFecha<Articulo> _obtenerMovimientosRangoFechas;

        int pageSize = ParametrosGenerales.pageSize;
        public MovimientosController(
            IAltaID<MovimientoCRUDDto> altaMovimiento,
            IEditar<MovimientoCRUDDto> editarMovimiento,
            IEliminar<MovimientoDto> eliminarMovimiento,
            IObtenerTodos<MovimientoDto> obtenerMovimientos,
            IObtener<MovimientoDto> obtenerMovimiento,
            IObtenerByNumber<MovimientoDto> obtenerMovimientoByPage,
            ICantidadTotal obtenerCantidadMovimiento,
            IObtenerTodos<string> obtenerCantidadesMovimientos,
            IObtenerFiltroDobleString<MovimientoDto> obtenerMovimientosPorArticuloYTipo,
            IObtenerRangoFecha<Articulo> obtenerMovimientosRangoFechas
            )
        {
            _altaMovimiento = altaMovimiento;
            _editarMovimiento = editarMovimiento;
            _eliminarMovimiento = eliminarMovimiento;
            _obtenerMovimientos = obtenerMovimientos;
            _obtenerMovimiento = obtenerMovimiento;
            _obtenerMovimientoByPage = obtenerMovimientoByPage;
            _obtenerCantidadMovimiento = obtenerCantidadMovimiento;
            _obtenerCantidadesMovimientos = obtenerCantidadesMovimientos;
            _obtenerMovimientosPorArticuloYTipo = obtenerMovimientosPorArticuloYTipo;
            _obtenerMovimientosRangoFechas = obtenerMovimientosRangoFechas;

        }


        /// <summary>
        /// Servicio que permite crear un Movimiento
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Authorize]

        public IActionResult Create(MovimientoCRUDDto movimientoDto)
        {

            try
            {
                int _id = _altaMovimiento.Ejecutar(movimientoDto);
                return Ok("Alta exitosa");
            }
            catch (CantidadInvalidaException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (ArticuloInvalidoException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (TipoMovimientoInvalidoException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (UsuarioInvalidoException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }


        }


        /// <summary>
        /// Servicio que permite editar un Movimiento
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Edit(int id, [FromBody] MovimientoCRUDDto movimientoDto)
        {

            try
            {
                var elemento = _obtenerMovimiento.Ejecutar(id);
                if (elemento == null)
                {
                    return StatusCode(404, "No se encontró el recurso con el ID especificado.");
                }

                _editarMovimiento.Ejecutar(id, movimientoDto);


                return Ok("Editado correctamente.");
            }
            catch (CantidadInvalidaException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (ArticuloInvalidoException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (TipoMovimientoInvalidoException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (UsuarioInvalidoException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error al crear el tipo de movimiento: " + e.Message);
            }
        }


        /// <summary>
        /// Servicio que permite eliminar un Movimiento
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                var elemento = _obtenerMovimiento.Ejecutar(id);
                if (elemento == null)
                {
                    return StatusCode(404, "No se encontró el recurso con el ID especificado.");
                }

                _eliminarMovimiento.Ejecutar(id);

                return Ok("Recurso eliminado correctamente.");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error al eliminar el recurso: " + e.Message);
            }
        }



        /// <summary>
        /// Servicio que brinda todos los Movimientos
        /// </summary>
        /// <remarks>
        /// Ejemplo de retorno:
        ///[
        ///{
        ///"id": 2,
        ///"fecha": "2024-06-12T17:12:56.4334076",
        ///"articulo": {
        ///"id": 2,
        ///"nombreArt": {
        ///"value": "Lápiz HB"
        ///},
        ///"descripcion": "Lápiz de grafito grado HB",
        ///"codigo": 987654,
        ///"precio": 0.99,
        ///"stock": 500
        ///},
        ///"tipoMov": {
        ///"id": 2,
        ///"nombre": "Venta",
        ///"esIncremento": true
        ///},
        ///"usuario": {
        ///"id": 2,
        ///"nombre": {
        ///"value": "Usuario Test"
        ///},
        ///"apellido": "Uno",
        ///email": "usuario-1@gmail.com",
        ///"password": "240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9",
        ///discriminator": "Usuario"
        ///},
        ///"cantidad": 5
        ///},
        ///{
        ///"id": 3,
        ///"fecha": "2024-06-12T17:12:56.4334084",
        ///"articulo": {
        ///"id": 3,
        ///"nombreArt": {
        ///"value": "Plumón Marcador"
        ///},
        ///"descripcion": "Plumón de punta fina para pizarra blanca",
        ///"codigo": 456789,
        ///"precio": 1.49,
        ///"stock": 200
        ///},
        ///"tipoMov": {
        ///"id": 2,
        ///"nombre": "Venta",
        ///"esIncremento": true
        ///},
        ///"usuario": {
        ///"id": 1,
        ///"nombre": {
        ///"value": "Super"
        ///},
        ///"apellido": "Admin",
        ///"email": "superadmin@gmail.com",
        ///"password": "240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9",
        ///"discriminator": "Encargado"
        ///},
        ///"cantidad": 5
        ///},
        ///},
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Authorize]
        public IActionResult GetAll(int page)
        {
            try
            {
                var movimientos = _obtenerMovimientoByPage.Ejecutar(page);
                var cantMovimientos = _obtenerCantidadMovimiento.Ejecutar();   
                if (movimientos.Count() == 0)
                {
                    return StatusCode(204);
                }
                PageMovimientoViewModel<MovimientoDto> returnObject = new PageMovimientoViewModel<MovimientoDto>()
                {
                    Items = movimientos,
                    PageNumber = page,
                    TotalItems = cantMovimientos,
                    TotalPages = (int)(cantMovimientos / pageSize)
                };

                return Ok(returnObject);
            }
            catch (Exception)
            {
                return StatusCode(500, "Debe estar logueado para poder realizar este servicio");
            }

        }



 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("Cantidad")]
        [Authorize]
        public IActionResult GetCantidad() {
            var cantidades = _obtenerCantidadesMovimientos.Ejecutar();
            return Ok(cantidades);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("ArticulosByDates")]
        [Authorize]
        public IActionResult GetArticulosMovimientosFechas(DateTime desde, DateTime hasta, int page)
        {
            try
            {
                var articulos = _obtenerMovimientosRangoFechas.Ejecutar(desde, hasta, page);

                PageMovimientoViewModel<Articulo> returnObject = new PageMovimientoViewModel<Articulo>()
                {
                    Items = articulos.elementos,
                    PageNumber = page,
                    TotalItems = articulos.cantidadTotal,
                    TotalPages = (int)(articulos.cantidadTotal / pageSize)
                };

                return Ok(returnObject);
            }
            catch (Exception)
            {
                return StatusCode(403, "Debe estar logueado para poder realizar este servicio");
            }
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("ByTipoAndArticle")]
        [Authorize]
        public IActionResult GetMovimientosPorTipoYArt(string articuloId, string tipoMov, int page)
        {

             
            try
            {
                var movimientos = _obtenerMovimientosPorArticuloYTipo.Ejecutar(articuloId, tipoMov, page);

                PageMovimientoViewModel<MovimientoDto> returnObject = new PageMovimientoViewModel<MovimientoDto>()
                {
                    Items = movimientos.elementos,
                    PageNumber = page,
                    TotalItems = movimientos.cantidadTotal,
                    TotalPages = (int)(movimientos.cantidadTotal / pageSize)
                };

                return Ok(returnObject);
            }
            catch (Exception)
            {
                return StatusCode(403, "Debe estar logueado para poder realizar este servicio");
            }
        }

        /// <summary>
        /// Servicio que brinda un Movimiento por su Id 
        /// </summary>
        /// <remarks>
        /// Ejemplo de retorno: id = 3
        ///{
        ///"id": 3,
        ///"fecha": "2024-06-12T17:12:56.4334084",
        ///"articulo": {
        ///"id": 3,
        ///"nombreArt": {
        ///"value": "Plumón Marcador"
        ///},
        ///"descripcion": "Plumón de punta fina para pizarra blanca",
        ///"codigo": 456789,
        ///"precio": 1.49,
        ///"stock": 200
        ///},
        ///"tipoMov": {
        ///"id": 2,
        ///"nombre": "Venta",
        ///"esIncremento": true
        ///},
        ///"usuario": {
        ///"id": 1,
        ///"nombre": {
        ///"value": "Super"
        ///},
        ///"apellido": "Admin",
        ///"email": "superadmin@gmail.com",
        ///"password": "240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9",
        ///"discriminator": "Encargado"
        ///},
        ///"cantidad": 5
        ///},
        ///},
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {

            try
            {
                
                return Ok(_obtenerMovimiento.Ejecutar(id));
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Debe estar logueado para poder realizar este servicio");
            }
        }
    }

}
