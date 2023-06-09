﻿using ADSProjectBackend.Models;
using ADSProjectBackend.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace ADSProjectBackend.Controllers
{
    [Route("ADSProject/Carrera")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class CarreraController : ControllerBase
    {
        private readonly ICarreraRepositorio carreraRepositorio;

        public CarreraController(ICarreraRepositorio carreraRepositorio)
        {
            this.carreraRepositorio = carreraRepositorio;
        }

        [HttpPost("insertarCarrera")]
        public ActionResult<int> InsertarCarrera(Carrera value)
        {
            var valor = carreraRepositorio.InsertarCarrera(value);
            if (valor > 0)
            {
                return Ok(valor);
            }
            else
            {
                return BadRequest("Error al intentar insertar");
            }
        }


        [HttpGet("obtenerListaCarreras")]
        public ActionResult<List<Carrera>> ObtenerCarreras()
        {
            var valor = carreraRepositorio.ObtenerListaCarreras();
            if (valor.Count > 0)
            {
                return Ok(valor);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("obtenerCarrera/")]
        public ActionResult<Carrera> ObtenerCarreraPorId(int id)
        {
            var valor = carreraRepositorio.ObtenerCarreraPorId(id);
            if (valor != null)
            {
                return Ok(valor);
            }
            else
            {
                return NotFound("Carrera no encontrada");
            }
        }

        [HttpDelete("eliminarCarrera/")]
        public ActionResult<bool> EliminarCarrera(int id)
        {
            var valor = carreraRepositorio.ObtenerCarreraPorId(id);
            if (valor != null)
            {
                return Ok(carreraRepositorio.EliminarCarrera(id));
            }
            else
            {
                return NotFound("Carrera no encontrada");
            }
        }

        [HttpPatch("actualizarCarrera/")]
        public ActionResult<int> ActualizarCarrera(int id, [FromBody] Carrera value)
        {
            var valor = carreraRepositorio.ModificarCarrera(id, value);
            if (valor > 0)
            {
                return Ok(valor);
            }
            else
            {
                return BadRequest("Error al actualizar a la Carrera");
            }
        }
    }
}
