using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCD_API.Models;
using SGCD_API.Repositorio.Citas;
using Microsoft.Extensions.Configuration;


namespace SGCD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly CitaRepository _repo = new CitaRepository();
        

        [HttpGet("VerPacientes")]
        public IActionResult GetCitas()
        {
            
            if(!_repo.GetAll()){
                return BadRequest();
            }

            return Ok(_repo.getIEnu());

        }


        // GET api/values/5
        [HttpGet("PacientePorId/{id}")]
        public IActionResult CitaPorId(int id)
        {
            Paciente paciente = null;
            if(!_repo.GetById(id)){
                return BadRequest();
            }

            return Ok(_repo.getPaciente());
        }

        // POST api/values
        [HttpPost("InsertarPaciente")]
        public IActionResult InsertarCita(Paciente paciente)
        {
            if(!_repo.insertarCita(new Cita())){
                return  BadRequest("No insertado");
            }
            return Ok("Insertado");
        }

        // PUT api/values/5
        [HttpPost("ActualizarPaciente")]
        public IActionResult ActualizarCita(Paciente paciente)
        {
            if (!_repo.actualizarCita(new Cita())){
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
