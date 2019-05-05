using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGCD_API.Models;
using SGCD_API.Services;

namespace SGCD_API.Controllers
{
    [Route("api/servicio")]
    [ApiController]
    public class ServicioController : ControllerBase
    {

        private readonly ServicioServices _servicioServicio;
        public ServicioController(ServicioServices servicioServicio)
        {
            _servicioServicio = servicioServicio;
        }
        public IActionResult prueba()
        {
            return Ok("Todo bien");
        }
   
        [Route("VerServicios")]
        [HttpGet]
        public IActionResult verServicios()
        {
            var resultado = _servicioServicio.verListado();
            return Ok(resultado);
        }

        [Route("ServicioPorID/{id_servicio}")]
        [HttpGet]
        public IActionResult ServicioPorID(int id_servicio)
        {
            return Ok(_servicioServicio.ObtenerPorID(id_servicio));
        }

        [Route("Agregar")]
        [HttpPost]
        public IActionResult Agregar([FromBody] Servicio ServicioAgregar)
        {

            if (_servicioServicio.Agregar(ServicioAgregar))
            {
                return Ok("Se ha registrado exitosamente el servicio");
            }
            return BadRequest();
        }

        [Route("Editar")]
        [HttpPut]
        public IActionResult Editar([FromBody] Servicio ServicioEditar)
        {

            if (_servicioServicio.Editar(ServicioEditar))
            {
                return Ok("Se ha modificado exitosamente el servicio");
            }
            return BadRequest();
        }

        [Route("Eliminar/{id_servicio}")]
        [HttpGet]
        public IActionResult Eliminar(int id_servicio)
        {

            if (_servicioServicio.Eliminar(id_servicio))
            {
                return Ok("Se ha eliminado exitosamente el servicio");
            }
            return BadRequest();
        }

    }
}

