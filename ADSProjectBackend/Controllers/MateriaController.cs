using ADSProjectBackend.Models;
using ADSProjectBackend.Repositories;
using ADSProjectBackend.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ADSProjectBackend.Controllers
{
    [Route("ADSProject/Materia")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaRepositorio materiaRepositorio;

        public MateriaController(IMateriaRepositorio materiaRepositorio)
        {
            this.materiaRepositorio = materiaRepositorio;
        }

        [HttpPost("insertarMateria")]
        public ActionResult<int> InsertarMateria(Materia value)
        {
            var valor = materiaRepositorio.InsertarMateria(value);
            if (valor > 0)
            {
                return Ok(valor);
            }
            else
            {
                return BadRequest("Error al intentar insertar");
            }
        }


        [HttpGet("obtenerListaMaterias")]
        public ActionResult<List<Materia>> ObtenerMaterias()
        {
            var valor = materiaRepositorio.ObtenerListaMaterias();
            if (valor.Count > 0)
            {
                return Ok(valor);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("obtenerMateria/")]
        public ActionResult<Materia> ObtenerMateriaPorId(int id)
        {
            var valor = materiaRepositorio.ObtenerMateriaPorId(id);
            if (valor != null)
            {
                return Ok(valor);
            }
            else
            {
                return NotFound("Materia no encontrada");
            }
        }

        [HttpDelete("eliminarMateria/")]
        public ActionResult<bool> EliminarMateria(int id)
        {
            var valor = materiaRepositorio.ObtenerMateriaPorId(id);
            if (valor != null)
            {
                return Ok(materiaRepositorio.EliminarMateria(id));
            }
            else
            {
                return NotFound("Estudiante no encontrado");
            }
        }

        [HttpPatch("actualizarMateria/")]
        public ActionResult<int> ActualizarMateria(int id, [FromBody] Materia value)
        {
            var valor = materiaRepositorio.ModificarMateria(id, value);
            if (valor > 0)
            {
                return Ok(valor);
            }
            else
            {
                return BadRequest("Error al actualizar a la materia");
            }
        }
    }
}
