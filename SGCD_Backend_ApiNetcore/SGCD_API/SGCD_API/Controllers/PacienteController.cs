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
            return Ok("Todo bien");
        }

        [Route("VerPacientes")]
        [HttpGet]
        public IActionResult verPacientes()
        {
            try { 
            var resultado = _pacienteServicio.verListado();
            return Ok(resultado);
            }
            catch(Exception e)
            {
                
                return NotFound(e.Message);
            }
        }
        [Route("PacientePorID/{id_paciente}")]
        [HttpGet]
        public IActionResult PacientePorID(int id_paciente)
        {
            try
            {
                var resultado = _pacienteServicio.ObtenerPorID(id_paciente);
                if (resultado == null) {
                    return Ok("No se encontró el paciente");
                }
                return Ok(resultado);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }


        [Route("Agregar")]
        [HttpPost]
        public IActionResult Agregar([FromBody] Paciente PacienteAgregar)
        {

            if (_pacienteServicio.Agregar(PacienteAgregar))
            {
                return Ok("Se ha registrado exitosamente al paciente");
            }
            return BadRequest("Error al agregar, por favor verifique los campos");
        }
        [Route("Editar")]
        [HttpPut]
        public IActionResult Editar([FromBody] Paciente PacienteEditar)
        {

            if (_pacienteServicio.Editar(PacienteEditar))
            {
                return Ok("Se ha registrado exitosamente la cita");
            }
            return BadRequest("Error al editar,  por favor verifique los campos");
        }

        [Route("Eliminar/{id_paciente}")]
        [HttpGet]
        public IActionResult Eliminar(int id_paciente)
        {

            if (_pacienteServicio.Eliminar(id_paciente))
            {
                return Ok("Eliminado");
            }
            return BadRequest("Se ha dado de baja exitosamente al paciente");
        }


    }
}