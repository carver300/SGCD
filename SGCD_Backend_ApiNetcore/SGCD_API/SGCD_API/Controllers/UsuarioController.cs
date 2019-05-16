using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using SGCD_API.Models;
using SGCD_API.Services;

namespace SGCD_API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly UsuarioServices _usuarioServicio;
        public UsuarioController(UsuarioServices usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        public IActionResult prueba()
        {
            return Ok("Todo bien");
        }

        [Route("Agregar")]
        [HttpPost]
        public IActionResult Agregar([FromBody] Usuario UsuarioAgregar)
        {

            try
            {
                var folio = _usuarioServicio.Agregar(UsuarioAgregar);
                return Ok("Se ha registrado exitosamente el usuario: " + folio);

            }
            catch (SqlException e)
            {
                return Ok("Error al registrar el usuario" + e.Message);
            }

        }

        [Route("Login")]
        [HttpGet]
        public IActionResult Login([FromBody] Usuario Usuario)
        {
            try
            {
                var usuario = _usuarioServicio.Login(Usuario);

                return Ok(usuario.tipo_usuario);

            }
            catch (NullReferenceException ex)
            {
                return Ok("Error: Usuario/Contraseña inválidos");

            }


        }
        
        [Route("LoginAPP")]
        [HttpGet]
        public IActionResult LoginAPP([FromBody] Usuario Usuario)
        {
            try
            {
                var usuario = _usuarioServicio.LoginAPP(Usuario);

                return Ok(usuario);

            }
            catch (NullReferenceException ex)
            {
                return Ok("Error: Usuario/Contraseña inválidos");

            }


        }
    }
}

