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
    [Route("api/paciente")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteServices _pacienteServicio;
        public PacienteController(PacienteServices pacienteServicio)
        {
            _pacienteServicio = pacienteServicio;
        }
        public IActionResult prueba()
        {
            return Ok("FUNCI0NA LA API");
        }

        [Route("VerPacientes")]
        [HttpGet]
        public IActionResult verPacientes()
        {
            var resultado = _pacienteServicio.verListado();
            return Ok(resultado);
        }
        [Route("PacientePorID/{id_paciente}")]
        [HttpGet]
        public IActionResult PacientePorID(int id_paciente)
        {
            return Ok(_pacienteServicio.ObtenerPorID(id_paciente));
        }


        [Route("Agregar")]
        [HttpPost]
        public IActionResult Agregar([FromBody] Paciente PacienteAgregar)
        {

            if (_pacienteServicio.Agregar(PacienteAgregar))
            {
                return Ok("Agregado");
            }
            return BadRequest();
        }
        [Route("Editar")]
        [HttpPut]
        public IActionResult Editar([FromBody] Paciente PacienteEditar)
        {

            if (_pacienteServicio.Editar(PacienteEditar))
            {
                return Ok("Editado");
            }
            return BadRequest();
        }

        [Route("Eliminar/{id_paciente}")]
        [HttpGet]
        public IActionResult Eliminar(int id_paciente)
        {

            if (_pacienteServicio.Eliminar(id_paciente))
            {
                return Ok("Eliminado");
            }
            return BadRequest();
        }


    }
}