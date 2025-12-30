using AlquilerAutosApi.Data;
using AlquilerAutosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlquilerAutosApi.Controllers
{
    [ApiController]
    [Route("api/autos")]
    public class AutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/autos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Autos.ToList());
        }

        // POST api/autos
        [HttpPost]
        public IActionResult Create(Auto auto)
        {
            auto.Disponible = true;
            _context.Autos.Add(auto);
            _context.SaveChanges();
            return Ok(auto);
        }

        // POST api/autos/alquilar/1
        [HttpPost("alquilar/{id}")]
        public IActionResult Alquilar(int id)
        {
            var auto = _context.Autos.Find(id);

            if (auto == null)
                return NotFound();

            if (!auto.Disponible)
                return BadRequest("Auto no disponible");

            auto.Disponible = false;
            _context.SaveChanges();
            return Ok("Auto alquilado");
        }

        // POST api/autos/devolver/1
        [HttpPost("devolver/{id}")]
        public IActionResult Devolver(int id)
        {
            var auto = _context.Autos.Find(id);

            if (auto == null)
                return NotFound();

            auto.Disponible = true;
            _context.SaveChanges();
            return Ok("Auto devuelto");
        }
    }
}
