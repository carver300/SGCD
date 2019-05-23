using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGCD_API.Models;
using SGCD_API.Repositorio.Servicios;
using Microsoft.Extensions.Configuration;


namespace SGCD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly ServiciosRepository _repo = new ServiciosRepository();
        

        [HttpGet("VerServicios")]
        public IActionResult GetServicios()
        {
            
            if(!_repo.GetAll()){
                return BadRequest();
            }

            return Ok(_repo.getIEnu());

        }


        // GET api/values/5
        [HttpGet("ServicioPorId/{id}")]
        public IActionResult ServicioPorId(int id)
        {
            Servicio servicio = null;
            if(!_repo.GetById(id)){
                return BadRequest();
            }

            return Ok(_repo.getServicio());
        }

        // POST api/values
        [HttpPost("AgregarServicio")]
        public IActionResult Post(Servicio servicio)
        {
            if(!_repo.InsertServicio(servicio)){
                return BadRequest("No insertado");
            }
            return Ok("Insertado");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpGet("EliminarServicio/{id}")]
        public int Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
