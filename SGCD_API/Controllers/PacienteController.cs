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
        // GET api/values
        [HttpGet("VerPacientes")]
        public IEnumerable<Paciente> TraerEmpleados()
        {
            return _repo.GetAll();
        }

        // GET api/values/5
        [HttpGet("PacientePorId/{id}")]
        public Paciente PacientePorId(int id)
        {
            return  _repo.GetById(id);
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
        [HttpDelete("EliminarPaciente/{id}")]
        public int Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
