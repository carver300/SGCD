using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCD_API.Models;
using SGCD_API.Repositorio.Pacientes;
using Microsoft.Extensions.Configuration;


namespace SGCD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacientesRepository _repo = new PacientesRepository();
        

        [HttpGet("VerPacientes")]
        public IActionResult GetPacientes()
        {
            
            if(!_repo.GetAll()){
                return BadRequest();
            }

            return Ok(_repo.getIEnu());

        }


        // GET api/values/5
        [HttpGet("PacientePorId/{id}")]
        public IActionResult PacientePorId(int id)
        {
            Paciente paciente = null;
            if(!_repo.GetById(id)){
                return BadRequest();
            }

            return Ok(_repo.getPaciente());
        }

        // POST api/values
        [HttpPost("InsertarPaciente")]
        public IActionResult InsertarPaciente(Paciente paciente)
        {
            if(!_repo.insertPaciente(paciente)){
                return  BadRequest("No insertado");
            }
            return Ok("Insertado");
        }

        // PUT api/values/5
        [HttpPost("ActualizarPaciente")]
        public IActionResult ActualizarPaciente(Paciente paciente)
        {
            if (!_repo.UpdatePaciente(paciente)){
                return BadRequest();
            }
            return Ok(_repo.getPaciente());
        }

        // DELETE api/values/5
        [HttpPost("EliminarPaciente/{id}")]
        public int Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
