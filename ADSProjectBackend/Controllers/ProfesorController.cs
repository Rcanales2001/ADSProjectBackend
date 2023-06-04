using ADSProjectBackend.Models;
using ADSProjectBackend.Repositories;
using ADSProjectBackend.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace ADSProjectBackend.Controllers
{
    [Route("ADSProject/Profesor")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorRepositorio profesorRepositorio;

        public ProfesorController(IProfesorRepositorio profesorRepositorio)
        {
            this.profesorRepositorio = profesorRepositorio;
        }

        // POST api/<ProfesorController>
        [HttpPost("insertarProfesor")]
        public ActionResult<int> InsertarProfesor(Profesor value)
        {
            var valor = profesorRepositorio.InsertarProfesor(value);

            if (valor > 0)
            {
                return Ok(valor);
            }
            else
            {
                return BadRequest("Error al intentar insertar");
            }
        }


        // GET: api/<ProfesorController>
        [HttpGet("obtenerListaProfesores")]
        public ActionResult<List<Profesor>> ObtenerProfesors()
        {
            var valor = profesorRepositorio.ObtenerListaProfesores();
            if (valor.Count > 0)
            {
                return Ok(valor);
            }
            else
            {
                return NoContent();
            }
        }

        // GET: api/<ProfesorController>
        [HttpGet("obtenerProfesor/")]
        public ActionResult<Profesor> ObtenerProfesorPorId(int id)
        {
            var valor = profesorRepositorio.ObtenerProfesorPorId(id);
            if (valor != null)
            {
                return Ok(valor);
            }
            else
            {
                return NotFound("Profesor no encontrado");
            }
        }

        [HttpDelete("eliminarProfesor/")]
        public ActionResult<bool> EliminarProfesor(int id)
        {
            var valor = profesorRepositorio.ObtenerProfesorPorId(id);
            if (valor != null)
            {
                return Ok(profesorRepositorio.EliminarProfesor(id));
            }
            else
            {
                return NotFound("Profesor no encontrado");
            }
        }

        [HttpPatch("actualizarProfesor/")]
        public ActionResult<int> ActualizarProfesor(int id, [FromBody] Profesor value)
        {
            var valor = profesorRepositorio.ModificarProfesor(id, value);
            if (valor > 0)
            {
                return Ok(valor);
            }
            else
            {
                return BadRequest("Error al actualizar al Profesor");
            }
        }
    }
}
