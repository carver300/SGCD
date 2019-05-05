using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCD_API.Models;
using SGCD_API.Services;

namespace SGCD_API.Controllers
{
    [Route("api/cita")]
    [ApiController]
    public class CitaController : ControllerBase
    {

        private readonly CitaServices _citaServicio;
        public CitaController(CitaServices citaServicio)
        {
            _citaServicio = citaServicio;
        }
        public IActionResult prueba()
        {
            return Ok("Todo bien");
        }

        [Route("VerCitas")]
        [HttpGet]
        public IActionResult vercitas()
        {
            var resultado = _citaServicio.verListado();
            return Ok(resultado);
        }

        [Route("CitaPorID/{id_cita}")]
        [HttpGet]
        public IActionResult ServicioPorID(int id_cita)
        {
            return Ok(_citaServicio.ObtenerPorID(id_cita));
        }

        [Route("Agregar")]
        [HttpPost]
        public IActionResult Agregar([FromBody] Cita CitaAgregar)
        {

            if (_citaServicio.Agregar(CitaAgregar))
            {
                return Ok("Se ha registrado exitosamente la cita");
            }
            return BadRequest();
        }

        [Route("Editar")]
        [HttpPut]
        public IActionResult Editar([FromBody] Cita CitaEditar)
        {

            if (_citaServicio.Editar(CitaEditar))
            {
                return Ok("Se ha modificado exitosamente la cita");
            }
            return BadRequest();
        }

    }
}
