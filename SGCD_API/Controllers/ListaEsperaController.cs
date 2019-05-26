using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGCD_API.Models;
using SGCD_API.Repositorio.ListaEsperaRe;

namespace SGCD_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ListaEsperaController : ControllerBase
    {

        ListaEsperaRepository _repoLista = new ListaEsperaRepository();

        // GET: api/ListaEspera
        [HttpGet ("ListaDelDia")]
        public IActionResult GetListaDelDia()
        {
            if (!_repoLista.GetListaDelDia())
            {
                return BadRequest("No se encontro informacion para el dia de hoy");
            }
            return Ok(_repoLista.GetLista());
        }

        // GET: api/ListaEspera/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ListaEspera
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ListaEspera/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
