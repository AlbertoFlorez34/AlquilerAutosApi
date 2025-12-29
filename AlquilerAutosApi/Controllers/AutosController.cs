using AlquilerAutosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlquilerAutosApi.Controllers
{
    [ApiController]
    [Route("api/autos")]
    public class AutosController : ControllerBase
    {
        // "Base de datos" en memoria
        private static List<Auto> autos = new()
        {
            new Auto { Id = 1, Marca = "Toyota", Disponible = true },
            new Auto { Id = 2, Marca = "Mazda", Disponible = true },
            new Auto { Id = 3, Marca = "Chevrolet", Disponible = false }
        };

        // GET: api/autos
        [HttpGet]
        public IActionResult GetAutos()
        {
            return Ok(autos);
        }

        // POST: api/autos/alquilar/1
        [HttpPost("alquilar/{id}")]
        public IActionResult Alquilar(int id)
        {
            var auto = autos.FirstOrDefault(a => a.Id == id);

            if (auto == null)
                return NotFound("Auto no existe");

            if (!auto.Disponible)
                return BadRequest("Auto no disponible");

            auto.Disponible = false;
            return Ok("Auto alquilado");
        }

        // POST: api/autos/devolver/1
        [HttpPost("devolver/{id}")]
        public IActionResult Devolver(int id)
        {
            var auto = autos.FirstOrDefault(a => a.Id == id);

            if (auto == null)
                return NotFound("Auto no existe");

            auto.Disponible = true;
            return Ok("Auto devuelto");
        }
    }
}
