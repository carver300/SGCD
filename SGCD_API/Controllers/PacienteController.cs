﻿using System;
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
        public IEnumerable<Paciente> GetPacientes()
        {
            IEnumerable<Paciente> pacientes = null;
            
            if(!_repo.GetAll(pacientes)){
                return pacientes;
            }

            return pacientes;

        }


        // GET api/values/5
        [HttpGet("PacientePorId/{id}")]
        public Paciente PacientePorId(int id)
        {
            Paciente paciente = null;
            if(!_repo.GetById(id, paciente)){
                return paciente;
            }

            return paciente;
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
