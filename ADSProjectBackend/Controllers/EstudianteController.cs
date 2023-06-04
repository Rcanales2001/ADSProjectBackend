using ADSProjectBackend.Models;
using ADSProjectBackend.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace ADSProjectBackend.Controllers
{
    [Route("ADSProject/Estudiante")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteRepositorio estudianteRepositorio;

        public EstudianteController(IEstudianteRepositorio estudianteRepositorio)
        {
            this.estudianteRepositorio = estudianteRepositorio;
        }

        // POST api/<EstudianteController>
        [HttpPost("insertarEstudiante")]
        public ActionResult<int> InsertarEstudiante(Estudiante value)
        {
            var valor = estudianteRepositorio.InsertarEstudiante(value);
            if (valor > 0)
            {
                return Ok(valor);
            }
            else
            {
                return BadRequest("Error al intentar insertar");
            }
        }


        [HttpGet("obtenerListaEstudiantes")]
        public ActionResult<List<Estudiante>> ObtenerEstudiantes()
        {
            var valor = estudianteRepositorio.ObtenerListaEstudiantes();
            if (valor.Count > 0)
            {
                return Ok(valor);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("obtenerEstudiante/")]
        public ActionResult<Estudiante> ObtenerEstudiantePorId(int id)
        {
            var valor =  estudianteRepositorio.ObtenerEstudiantePorId(id);
            if (valor != null)
            {
                return Ok(valor);
            }
            else
            {
                return NotFound("Estudiante no encontrado");
            }
        }

        [HttpDelete("eliminarEstudiante/")]
        public ActionResult<bool> EliminarEstudiante(int id)
        {
            var valor = estudianteRepositorio.ObtenerEstudiantePorId(id);
            if (valor != null)
            {
                return Ok(estudianteRepositorio.EliminarEstudiante(id));
            }
            else
            {
                return NotFound("Estudiante no encontrado");
            }
        }

        [HttpPatch("actualizarEstudiante/")]
        public ActionResult<int> ActualizarEstudiante(int id, [FromBody] Estudiante value)
        {
            var valor = estudianteRepositorio.ModificarEstudiante(id, value);
            if (valor > 0)
            {
                return Ok(valor);
            }
            else
            {
                return BadRequest("Error al actualizar al estudiante");
            }
        }
    }
}
