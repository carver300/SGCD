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
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpGet("EliminarPaciente/{id}")]
        public int Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
