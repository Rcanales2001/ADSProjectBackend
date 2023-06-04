using ADSProjectBackend.Models;
using ADSProjectBackend.Repositories;
using ADSProjectBackend.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ADSProjectBackend.Controllers
{
    [Route("ADSProject/Grupo")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly IGrupoRepositorio grupoRepositorio;

        public GrupoController(IGrupoRepositorio pGrupoRepositorio)
        {
            this.grupoRepositorio = pGrupoRepositorio;
        }

        [HttpPost("insertarGrupo")]
        public ActionResult<int> InsertarGrupo(Grupo value)
        {
            var valor = grupoRepositorio.InsertarGrupo(value);
            if (valor > 0)
            {
                return Ok(valor);
            }
            else
            {
                return BadRequest("Error al intentar insertar");
            }
        }


        [HttpGet("obtenerListaGrupos")]
        public ActionResult<List<Grupo>> ObtenerGrupos()
        {
            var valor = grupoRepositorio.ObtenerListaGrupos();
            if (valor.Count > 0)
            {
                return Ok(valor);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("obtenerGrupo/")]
        public ActionResult<Grupo> ObtenerGrupoPorId(int id)
        {
            var valor = grupoRepositorio.ObtenerGrupoPorId(id);
            if (valor != null)
            {
                return Ok(valor);
            }
            else
            {
                return NotFound("Grupo no encontrado");
            }
        }

        [HttpDelete("eliminarGrupo/")]
        public ActionResult<bool> EliminarGrupo(int id)
        {
            var valor = grupoRepositorio.ObtenerGrupoPorId(id);
            if (valor != null)
            {
                return Ok(grupoRepositorio.EliminarGrupo(id));
            }
            else
            {
                return NotFound("Grupo no encontrado");
            }
        }

        [HttpPatch("actualizarGrupo/")]
        public ActionResult<int> ActualizarGrupo(int id, [FromBody] Grupo value)
        {
            var valor = grupoRepositorio.ModificarGrupo(id, value);
            if (valor > 0)
            {
                return Ok(valor);
            }
            else
            {
                return BadRequest("Error al actualizar al grupo");
            }
        }
    }
}
